/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections;
using System.IO;
using System.Management.Automation.Provider;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// UPLOAD writer built on the SDK's <see cref="TransferUtility"/>.
    ///
    /// The hard problem is direction: PowerShell PUSHES blocks at Write()/Close(); TransferUtility
    /// PULLS from an input Stream. We bridge them with <see cref="PushPullStream"/> and run the
    /// upload on a BACKGROUND task that reads the bridge while the pipeline thread feeds it:
    ///
    ///   GetContentWriter --> create the bridge; no S3 upload exists yet
    ///   Write(blocks)     --> flatten into an 80 KiB buffer, lazily start UploadAsync, Produce
    ///   Close()           --> flush, start an empty upload if needed, then EOF/await
    ///
    /// Because the bridge is non-seekable / unknown-length, TransferUtility takes its
    /// UploadUnseekableStreamAsync path (reads to EOF, multipart) - so we inherit its part
    /// management and its abort-on-failure. We no longer Initiate/UploadPart/Complete by hand.
    ///
    /// Threading rule: NEVER touch the cmdlet write methods from the background task. Faults are
    /// surfaced by rethrowing on the pipeline thread (Write/Close). Cancellation (Ctrl+C) cancels
    /// the shared CTS, which faults TransferUtility's Read -> it aborts its own multipart upload.
    /// </summary>
    internal sealed class S3TransferContentWriter : IContentWriter
    {
        private readonly bool _asByteStream;
        private readonly System.Text.Encoding _encoding;   // text-mode encoding (ignored in byte mode)
        private readonly CancellationTokenSource _cts;
        private readonly Action _onComplete;     // cache invalidation, on success only
        private readonly Action<Exception> _onFault;  // surfaces fault via the provider's WriteError (PowerShell swallows Close() throws)
        private readonly Action _onDispose;       // unregisters the provider's content-op tracking
        private readonly TransferUtility _transferUtility;   // owned; disposed on teardown (does NOT dispose our shared client)
        private readonly string _bucket;
        private readonly string _key;
        private readonly S3StorageClass _storageClass;
        private readonly bool _noNewline;
        private readonly PushPullStream _bridge;
        private readonly MemoryStream _pending = new MemoryStream();
        private Task _uploadTask;
        // The real upload failure, captured the instant the fault continuation fires - BEFORE
        // _uploadTask.IsFaulted is necessarily observable. Without this, a fault that cancels the
        // bridge can surface as a bare OperationCanceledException, masking the real S3 error.
        private volatile Exception _uploadFault;
        private bool _wrotePreamble;
        private bool _failedBeforeClose;
        private bool _disposed;

        internal S3TransferContentWriter(
            TransferUtility transferUtility, string bucket, string key, bool asByteStream,
            CancellationTokenSource cts, Action onComplete, Action<Exception> onFault,
            Action onDispose,
            S3StorageClass storageClass = null, System.Text.Encoding encoding = null,
            bool noNewline = false)
        {
            _asByteStream = asByteStream;
            _encoding = encoding ?? new System.Text.UTF8Encoding(false);
            _cts = cts;
            _onComplete = onComplete;
            _onFault = onFault;
            _onDispose = onDispose;
            _transferUtility = transferUtility;
            _bucket = bucket;
            _key = key;
            _storageClass = storageClass;
            _noNewline = noNewline;
            _bridge = new PushPullStream(cts.Token);
        }

        private void EnsureUploadStarted()
        {
            if (_uploadTask != null) return;

            var request = new TransferUtilityUploadRequest
            {
                BucketName = _bucket,
                Key = _key,
                InputStream = _bridge,
                AutoCloseStream = false,            // we own the bridge's lifetime
                AutoResetStreamPosition = false,    // non-seekable; reset would throw
            };
            // Apply the resolved storage class only when set; leaving it null lets S3 default to
            // STANDARD (same as an upload with no storage class specified).
            if (_storageClass != null)
                request.StorageClass = _storageClass;

            // Start the upload lazily, after content has successfully flattened. That keeps
            // unsupported operations (Add-Content calls Seek) and invalid byte-stream input from
            // replacing an existing S3 object with an empty one before the provider can fail.
            _uploadTask = _transferUtility.UploadAsync(request, _cts.Token);
            _uploadTask.ContinueWith(t =>
            {
                // Record the real fault FIRST (so Write/Close can surface it even before the task
                // state is observable as Faulted), THEN cancel so a blocked Produce unblocks.
                if (t.Exception != null) _uploadFault = t.Exception.GetBaseException();
                S3Cancellation.SafeCancel(_cts);
            }, TaskContinuationOptions.NotOnRanToCompletion);
        }

        public IList Write(IList content)
        {
            ThrowIfUploadFaulted();
            try
            {
                foreach (var item in content)
                {
                    AppendItem(_pending, item);
                    if (_pending.Length >= BufferedUploadChunkSize)
                        FlushPending();
                }
                return content;   // contract: return what we were handed
            }
            catch (OperationCanceledException)
            {
                // The bridge was cancelled - almost always because the upload faulted. Surface
                // the real upload exception rather than the cancellation.
                ThrowIfUploadFaulted();
                _failedBeforeClose = true;
                S3Cancellation.SafeCancel(_cts);
                throw;
            }
            catch
            {
                _failedBeforeClose = true;
                S3Cancellation.SafeCancel(_cts);
                throw;
            }
        }

        public void Close()
        {
            try
            {
                if (_failedBeforeClose)
                    return;

                FlushPending();
                EnsureUploadStarted();
                _bridge.CompleteProducing();          // EOF -> TU finishes reading and completes
                _uploadTask.GetAwaiter().GetResult(); // throws here if the upload faulted
                _onComplete?.Invoke();                // success: let the provider invalidate its cache
            }
            catch (Exception ex)
            {
                // PowerShell's engine silently swallows exceptions thrown from IContentWriter.Close()
                // (verified empirically: small uploads fault at Close, and -ErrorAction Stop has no
                // effect). Surface the fault via the provider's WriteError callback so it reaches the
                // pipeline. Re-throw as well (for callers that DO handle Close exceptions, e.g. a
                // future engine fix or direct .NET callers). The dual surface (WriteError + throw) is
                // safe: if the throw IS swallowed, WriteError has already reported it; if it's NOT
                // swallowed, WriteError was a harmless additional report and the throw propagates.
                _onFault?.Invoke(ex);
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        // Match the reader's chunk size: large enough to avoid one S3 bridge push per byte when
        // local Get-Content -AsByteStream emits byte records, small enough to keep memory bounded.
        private const int BufferedUploadChunkSize = 80 * 1024;

        private void FlushPending()
        {
            if (_pending.Length == 0) return;

            EnsureUploadStarted();
            _bridge.Produce(_pending.ToArray());   // blocks under backpressure
            _pending.SetLength(0);
            _pending.Position = 0;
        }

        // Flatten the IList element shapes the engine produces into bytes: byte / byte[] / nested
        // object[] in byte mode; ToString()+"\n" (in the configured encoding) in text mode. Line
        // endings are always LF so an object is byte-identical regardless of the writing OS;
        // -AsByteStream is the path for exact byte control.
        private void AppendItem(Stream sink, object item)
        {
            if (item == null) return;

            if (_asByteStream)
            {
                if (item is byte b) { sink.WriteByte(b); return; }
                if (item is byte[] arr) { sink.Write(arr, 0, arr.Length); return; }
                if (item is object[] objs) { foreach (var o in objs) AppendItem(sink, o); return; }
                throw new InvalidCastException(
                    $"Expected byte content with -AsByteStream but got {item.GetType().Name}.");
            }
            else
            {
                if (!_wrotePreamble)
                {
                    var preamble = _encoding.GetPreamble();
                    if (preamble.Length > 0)
                        sink.Write(preamble, 0, preamble.Length);
                    _wrotePreamble = true;
                }

                var text = _noNewline ? item.ToString() : item.ToString() + "\n";
                var bytes = _encoding.GetBytes(text);
                sink.Write(bytes, 0, bytes.Length);
            }
        }

        // If the background upload already failed, rethrow its real cause on the pipeline thread.
        // Prefer _uploadFault (captured by the continuation the instant the fault fires) over the
        // task's IsFaulted/Exception, which may lag in the cancel-vs-fault race window - that lag
        // is exactly what would otherwise let a bare OperationCanceledException mask the real S3 error.
        private void ThrowIfUploadFaulted()
        {
            // Rethrow via ExceptionDispatchInfo so the original SDK call stack is preserved rather
            // than reset to this line (a plain `throw fault;` would discard it).
            var fault = _uploadFault;
            if (fault != null) ExceptionDispatchInfo.Capture(fault).Throw();
            if (_uploadTask != null && _uploadTask.IsFaulted)
                ExceptionDispatchInfo.Capture(
                    _uploadTask.Exception?.GetBaseException() ?? new IOException("S3 upload failed.")).Throw();
        }

        public void Seek(long offset, SeekOrigin origin)
        {
            _failedBeforeClose = true;
            S3Cancellation.SafeCancel(_cts);
            throw new NotSupportedException(
                "Seeking or appending is not supported on an S3 upload stream. Use Set-Content to replace the object.");
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            // If we're tearing down WITHOUT a clean Close (error/Ctrl+C), make sure the upload
            // task stops: cancel, which faults TU's Read and triggers ITS abort-of-multipart.
            if (_uploadTask != null && !_uploadTask.IsCompleted)
            {
                S3Cancellation.SafeCancel(_cts);
                try { _uploadTask.GetAwaiter().GetResult(); } catch { /* swallow on teardown */ }
            }

            _bridge?.Dispose();
            _pending?.Dispose();
            _cts?.Dispose();
            // Dispose the TransferUtility AFTER the upload task has settled (above). Verified the TU
            // does NOT dispose the IAmazonS3 client we passed in (it only disposes clients it created
            // itself - _shouldDispose flag), so the drive's shared per-region client is safe.
            _transferUtility?.Dispose();
            _onDispose?.Invoke();
        }
    }
}
