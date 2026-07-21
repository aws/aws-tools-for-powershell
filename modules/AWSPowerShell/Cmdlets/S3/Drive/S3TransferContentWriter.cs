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
    /// Upload writer over the SDK's <see cref="TransferUtility"/>. PowerShell pushes blocks at
    /// Write()/Close(); TU pulls from an input Stream. A <see cref="PushPullStream"/> bridges the two,
    /// with the upload running on a background task that reads the bridge while the pipeline feeds it.
    ///
    /// The bridge is non-seekable, so TU takes its unseekable multipart path (reads to EOF, aborts on
    /// failure). Faults are surfaced only on the pipeline thread (Write/Close), never from the
    /// background task; Ctrl+C cancels the shared CTS, which faults TU's Read into aborting the upload.
    /// </summary>
    internal sealed class S3TransferContentWriter : IContentWriter
    {
        private readonly bool _asByteStream;
        private readonly System.Text.Encoding _encoding;   // text-mode encoding (ignored in byte mode)
        private readonly CancellationTokenSource _cts;
        private readonly Action _onComplete;     // cache invalidation, on success only
        private readonly Action<Exception> _onFault;  // surfaces a fault via the provider's WriteError
        private readonly Action _onDispose;       // unregisters the provider's content-op tracking
        private readonly TransferUtility _transferUtility;   // owned; disposed on teardown
        private readonly string _bucket;
        private readonly string _key;
        private readonly S3StorageClass _storageClass;
        private readonly long _partSize;
        private readonly bool _noNewline;
        private readonly PushPullStream _bridge;
        private readonly MemoryStream _pending = new MemoryStream();
        private Task _uploadTask;
        // The real upload failure, captured by the fault continuation before _uploadTask.IsFaulted is
        // observable - otherwise a bridge cancel could surface as a bare OperationCanceledException.
        private volatile Exception _uploadFault;
        private bool _wrotePreamble;
        private bool _failedBeforeClose;
        private bool _disposed;

        internal S3TransferContentWriter(
            TransferUtility transferUtility, string bucket, string key, bool asByteStream,
            CancellationTokenSource cts, Action onComplete, Action<Exception> onFault,
            Action onDispose,
            long partSize = 0,
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
            _partSize = partSize;
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
            if (_storageClass != null)   // leave unset to let S3 default to STANDARD
                request.StorageClass = _storageClass;
            if (_partSize > 0)
                request.PartSize = _partSize;

            // Started lazily, only after content flattens, so an unsupported op (Add-Content's Seek) or
            // invalid byte input can't replace an existing object with an empty one first.
            _uploadTask = _transferUtility.UploadAsync(request, _cts.Token);
            _uploadTask.ContinueWith(t =>
            {
                // Record the fault before cancelling, so Write/Close can surface it even before the
                // task is observably Faulted; the cancel then unblocks a waiting Produce.
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
                // The bridge was cancelled, almost always by an upload fault - surface that instead.
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
                // The engine swallows exceptions thrown from Close(), so a fault here would never reach
                // the pipeline. Report it via WriteError AND rethrow: whichever the caller observes, the
                // other is harmless.
                _onFault?.Invoke(ex);
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        // Buffer before pushing to the bridge, so byte-record input doesn't push one byte at a time.
        private const int BufferedUploadChunkSize = 80 * 1024;

        private void FlushPending()
        {
            if (_pending.Length == 0) return;

            EnsureUploadStarted();
            _bridge.Produce(_pending.ToArray());   // blocks under backpressure
            _pending.SetLength(0);
            _pending.Position = 0;
        }

        // Flatten one engine-produced element to bytes: byte / byte[] / nested object[] in byte mode;
        // ToString() + "\n" (LF always) in the configured encoding in text mode.
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

        // If the background upload failed, rethrow its real cause on the pipeline thread. Prefer
        // _uploadFault over the task's Exception, which can lag in the cancel-vs-fault race.
        private void ThrowIfUploadFaulted()
        {
            // ExceptionDispatchInfo preserves the original SDK call stack (a plain `throw` would reset it).
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

            // Teardown without a clean Close (error/Ctrl+C): cancel so TU's Read faults and aborts its
            // multipart upload, then wait for it to settle before disposing below.
            if (_uploadTask != null && !_uploadTask.IsCompleted)
            {
                S3Cancellation.SafeCancel(_cts);
                try { _uploadTask.GetAwaiter().GetResult(); } catch { /* swallow on teardown */ }
            }

            _bridge?.Dispose();
            _pending?.Dispose();
            _cts?.Dispose();
            // Safe: TU only disposes clients it created itself, not our shared per-region client.
            _transferUtility?.Dispose();
            _onDispose?.Invoke();
        }
    }
}
