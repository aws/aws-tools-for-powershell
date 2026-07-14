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
    /// Streams an S3 object's bytes to PowerShell, block by block, over a TransferUtility
    /// download stream. PowerShell calls Read(readCount) repeatedly until it gets an empty
    /// list (EOF), then Close(). Only one block is held in memory at a time, so any object
    /// size works without a temp file.
    ///
    /// Read() contract (verified against FileSystemContentStream): in byte mode return a
    /// list of boxed System.Byte; in text mode return a list of strings (lines). An empty
    /// list signals end of content.
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

        // A bare readable Stream (from OpenStreamAsync, possibly a parallel multipart download
        // behind a forward-only facade) plus the owned download CancellationTokenSource to
        // release when the reader closes. onDispose runs on Close/Dispose (may be null).
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
                // The caller resolves -Encoding (defaulting to UTF-8 no-BOM) via ResolveEncoding, so
                // encoding is non-null in practice; the ?? is a defensive guard, not the default path.
                var enc = encoding ?? new System.Text.UTF8Encoding(false);
                // leaveOpen:true so the StreamReader does NOT dispose _stream - Dispose() owns the
                // stream's lifetime in one place (no double-dispose, and byte/text modes symmetric).
                // netstandard2.0 has no 3-arg overload, so pass the default 1KB buffer + leaveOpen.
                _textReader = new StreamReader(_stream, enc, detectEncodingFromByteOrderMarks: true,
                    bufferSize: 1024, leaveOpen: true);
            }
        }

        // 80 KB transfer chunk - large enough to amortize per-call overhead, small enough
        // to keep memory bounded. (Byte-per-call reads were ~32 KB/s; this is the fix.)
        private const int ChunkSize = 80 * 1024;
        private readonly byte[] _chunk = new byte[ChunkSize];

        public IList Read(long readCount)
        {
            var blocks = new ArrayList();

            if (_asByteStream)
            {
                // Return ONE byte[] block per call (a full buffer fill), not one byte. The
                // content writer flattens byte[] elements, and Get-Content -AsByteStream
                // unrolls them downstream. Empty list => EOF.
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

        // Fill buf with up to count bytes, looping because a single Stream.Read on an HTTP
        // body may return fewer bytes than asked even when not at EOF.
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
