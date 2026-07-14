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
    ///   GetContentWriter --> start UploadAsync(bridge) on a background task (it blocks on Read)
    ///   Write(blocks)     --> flatten + bridge.Produce(bytes)   [pipeline thread]
    ///   Close()           --> bridge.CompleteProducing() (EOF) then await the upload task
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
        private readonly PushPullStream _bridge;
        private readonly Task _uploadTask;
        // The real upload failure, captured the instant the fault continuation fires - BEFORE
        // _uploadTask.IsFaulted is necessarily observable. Without this, a fault that cancels the
        // bridge can surface as a bare OperationCanceledException, masking the real S3 error.
        private volatile Exception _uploadFault;
        private bool _disposed;

        internal S3TransferContentWriter(
            TransferUtility transferUtility, string bucket, string key, bool asByteStream,
            CancellationTokenSource cts, Action onComplete, Action<Exception> onFault,
            Action onDispose,
            S3StorageClass storageClass = null, System.Text.Encoding encoding = null)
        {
            _asByteStream = asByteStream;
            _encoding = encoding ?? new System.Text.UTF8Encoding(false);
            _cts = cts;
            _onComplete = onComplete;
            _onFault = onFault;
            _onDispose = onDispose;
            _transferUtility = transferUtility;
            _bridge = new PushPullStream(cts.Token);

            var request = new TransferUtilityUploadRequest
            {
                BucketName = bucket,
                Key = key,
                InputStream = _bridge,
                AutoCloseStream = false,            // we own the bridge's lifetime
                AutoResetStreamPosition = false,    // non-seekable; reset would throw
            };
            // Apply the resolved storage class only when set; leaving it null lets S3 default to
            // STANDARD (same as an upload with no storage class specified).
            if (storageClass != null)
                request.StorageClass = storageClass;

            // Start the upload now so TU is already pulling by the time Write() pushes. Do NOT
            // await here. If it faults (e.g. AccessDenied) while we're blocked in Produce, the
            // continuation cancels the CTS so Produce unblocks and Write/Close can surface it.
            _uploadTask = transferUtility.UploadAsync(request, cts.Token);
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
                using (var ms = new MemoryStream())
                {
                    foreach (var item in content)
                        AppendItem(ms, item);
                    if (ms.Length > 0)
                        _bridge.Produce(ms.ToArray());   // blocks under backpressure
                }
                return content;   // contract: return what we were handed
            }
            catch (OperationCanceledException)
            {
                // The bridge was cancelled - almost always because the upload faulted. Surface
                // the real upload exception rather than the cancellation.
                ThrowIfUploadFaulted();
                throw;
            }
        }

        public void Close()
        {
            try
            {
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
                var bytes = _encoding.GetBytes(item.ToString() + "\n");
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
            if (_uploadTask.IsFaulted)
                ExceptionDispatchInfo.Capture(
                    _uploadTask.Exception?.GetBaseException() ?? new IOException("S3 upload failed.")).Throw();
        }

        public void Seek(long offset, SeekOrigin origin) =>
            throw new NotSupportedException("Seeking is not supported on an S3 upload stream.");

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            // If we're tearing down WITHOUT a clean Close (error/Ctrl+C), make sure the upload
            // task stops: cancel, which faults TU's Read and triggers ITS abort-of-multipart.
            if (!_uploadTask.IsCompleted)
            {
                S3Cancellation.SafeCancel(_cts);
                try { _uploadTask.GetAwaiter().GetResult(); } catch { /* swallow on teardown */ }
            }

            _bridge?.Dispose();
            _cts?.Dispose();
            // Dispose the TransferUtility AFTER the upload task has settled (above). Verified the TU
            // does NOT dispose the IAmazonS3 client we passed in (it only disposes clients it created
            // itself - _shouldDispose flag), so the drive's shared per-region client is safe.
            _transferUtility?.Dispose();
            _onDispose?.Invoke();
        }
    }
}
