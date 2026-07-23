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

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Streams an S3 object to Get-Content over a TransferUtility download stream, one block in memory
    /// at a time. Read() returns a list per call (byte[] blocks in byte mode, strings in text mode) and
    /// an empty list at EOF, matching FileSystemContentStream's contract.
    /// </summary>
    internal sealed class S3ContentReader : IContentReader
    {
        private readonly System.Threading.CancellationTokenSource _downloadCts;   // disposed on Close
        private readonly Action _onDispose;   // lets the provider unregister the CTS
        private readonly Stream _stream;
        private readonly bool _asByteStream;
        private readonly bool _raw;
        private StreamReader _textReader;
        private bool _rawDone;   // -Raw returns everything in one Read, then EOF

        // stream: the forward-only download stream. downloadCts: owned, released on Close.
        internal S3ContentReader(Stream stream, System.Threading.CancellationTokenSource downloadCts,
            bool asByteStream, bool raw, System.Text.Encoding encoding, Action onDispose = null)
        {
            _stream = stream;
            _downloadCts = downloadCts;
            _onDispose = onDispose;
            _asByteStream = asByteStream;
            _raw = raw;
            if (!_asByteStream)
            {
                var enc = encoding ?? new System.Text.UTF8Encoding(false);   // defensive; caller resolves it
                // leaveOpen so Dispose() owns _stream's lifetime alone. netstandard2.0 lacks the 3-arg
                // overload, hence the explicit buffer size.
                _textReader = new StreamReader(_stream, enc, detectEncodingFromByteOrderMarks: true,
                    bufferSize: 1024, leaveOpen: true);
            }
        }

        // 80 KiB transfer chunk - large enough to amortize per-call overhead, small enough
        // to keep memory bounded.
        private const int ChunkSize = 80 * 1024;
        private readonly byte[] _chunk = new byte[ChunkSize];

        public IList Read(long readCount)
        {
            var blocks = new ArrayList();

            if (_asByteStream)
            {
                // One byte[] block per call, not one byte; Get-Content -AsByteStream unrolls it downstream.
                int n = ReadFull(_stream, _chunk, ChunkSize);
                if (n > 0)
                {
                    var block = new byte[n];
                    Array.Copy(_chunk, block, n);
                    blocks.Add(block);
                }
            }
            else if (_raw)
            {
                // -Raw: whole object as a single string, then EOF on the next call.
                if (!_rawDone)
                {
                    blocks.Add(_textReader.ReadToEnd());
                    _rawDone = true;
                }
            }
            else
            {
                // Text mode: readCount lines (Get-Content default ReadCount = 1).
                long limit = readCount <= 0 ? long.MaxValue : readCount;
                for (long i = 0; i < limit; i++)
                {
                    var line = _textReader.ReadLine();
                    if (line == null) break;     // EOF
                    blocks.Add(line);
                }
            }

            return blocks;                       // empty list => end of content
        }

        // Fill buf with up to count bytes, looping because one Stream.Read on an HTTP body may return
        // fewer bytes than asked without being at EOF.
        private static int ReadFull(Stream s, byte[] buf, int count)
        {
            int total = 0;
            while (total < count)
            {
                int r = s.Read(buf, total, count - total);
                if (r == 0) break;               // EOF
                total += r;
            }
            return total;
        }

        // S3 response stream is forward-only HTTP; seeking is not supported.
        public void Seek(long offset, SeekOrigin origin) =>
            throw new NotSupportedException("Seeking is not supported on an S3 content stream.");

        public void Close() => Dispose();

        public void Dispose()
        {
            _textReader?.Dispose();
            _stream?.Dispose();
            _downloadCts?.Dispose();
            _onDispose?.Invoke();   // let the provider unregister this CTS from its live set
        }
    }
}
