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
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// One-way bridge between PowerShell's PUSH content model and TransferUtility's PULL model.
    ///
    /// PowerShell hands the upload writer blocks via Write()/Close() (it pushes). TransferUtility
    /// wants to read an input Stream on its own clock (it pulls). This Stream sits between them:
    /// the writer calls <see cref="Produce"/> to enqueue byte chunks; TransferUtility calls
    /// <see cref="Read"/> to dequeue them. A bounded queue gives backpressure - if TU falls
    /// behind, Produce blocks instead of buffering unboundedly (memory stays ~capacity x chunk).
    ///
    /// CanSeek is false and Length throws on purpose: that is what routes TransferUtility into
    /// its non-seekable / unknown-length multipart path (UploadUnseekableStreamAsync), which
    /// reads to end-of-stream rather than needing a size up front.
    /// </summary>
    internal sealed class PushPullStream : Stream
    {
        // 8 chunks of buffering before Produce() blocks. Each chunk is one Write() call's worth of
        // bytes (sized by the engine's content block size, not a fixed flush), so the in-flight
        // memory ceiling is 8 x that block size - the backpressure bound.
        private readonly BlockingCollection<byte[]> _chunks = new BlockingCollection<byte[]>(boundedCapacity: 8);
        private readonly CancellationToken _token;
        private byte[] _current;
        private int _pos;

        internal PushPullStream(CancellationToken token) => _token = token;

        /// <summary>Enqueue a chunk (the writer's producing side). Blocks under backpressure.</summary>
        internal void Produce(byte[] data) => _chunks.Add(data, _token);

        /// <summary>Signal end-of-stream. The next exhausting Read returns 0 (clean EOF).</summary>
        internal void CompleteProducing() => _chunks.CompleteAdding();

        public override bool CanRead => true;
        public override bool CanSeek => false;     // <-- selects TU's unseekable upload path
        public override bool CanWrite => false;

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_current == null || _pos >= _current.Length)
            {
                try
                {
                    _current = _chunks.Take(_token);   // blocks until a chunk, EOF, or cancel
                    _pos = 0;
                }
                catch (InvalidOperationException)
                {
                    return 0;   // CompleteAdding + drained => clean EOF => TU completes the upload
                }
                // OperationCanceledException is intentionally NOT caught: on cancel we want TU's
                // Read to FAULT (so it aborts the multipart upload), not see a fake EOF and
                // complete a truncated object.
            }

            int n = Math.Min(count, _current.Length - _pos);
            Array.Copy(_current, _pos, buffer, offset, n);
            _pos += n;
            return n;
        }

        public override void Flush() { }
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        public override long Length => throw new NotSupportedException();   // unknown length => TU multipart-streams
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _chunks?.Dispose();
            base.Dispose(disposing);
        }
    }
}
