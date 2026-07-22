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
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public sealed partial class S3Provider
    {
        // ---- Content: download / upload (IContentCmdletProvider) -------------

        // Backs Get-Content (download). Opens the object via TransferUtility.OpenStream (parallel
        // multipart + ranged retries) and returns a reader that pulls blocks lazily, so any size
        // streams back with bounded memory.
        public IContentReader GetContentReader(string path)
        {
            if (!TryParseObjectPath(path,
                    "Get-Content requires a path to an S3 object (bucket\\key).",
                    "InvalidContentPath", out var bucket, out var key))
                return null;

            // -AsByteStream / -Raw / -Encoding are dynamic parameters. On a pipeline bind
            // (Get-ChildItem | Get-Content) the engine hands us FileSystem's dynamic-params object, not
            // ours, so ReadContentReaderParams reads them by name off either type rather than casting.
            bool asByteStream, raw;
            System.Text.Encoding encoding;
            try
            {
                ReadContentReaderParams(DynamicParameters, out asByteStream, out raw, out encoding);
            }
            catch (ArgumentException ex)
            {
                WriteError(new ErrorRecord(ex, "BadEncoding", ErrorCategory.InvalidArgument, path));
                return null;
            }

            // The CTS must outlive this method: multipart OpenStream fetches parts on background tasks
            // as the reader reads, so the token stays live for the whole read. The reader owns it and
            // disposes it on Close; StopProcessing cancels it via the content-CTS set.
            var readerCts = new CancellationTokenSource();
            RegisterContentCts(readerCts);
            Drive.BeginContentOperation();   // keep the drive's clients alive for the whole read
            var handedOff = false;   // true once the reader owns readerCts (success path)
            try
            {
                // TU is only needed to open the stream (dispose eagerly); disposing it leaves our
                // shared client and the opened multipart stream intact.
                Stream stream;
                using (var tu = TransferUtilityForBucket(bucket))
                {
                    var req = new Amazon.S3.Transfer.TransferUtilityOpenStreamRequest
                    {
                        BucketName = bucket,
                        Key = key,
                        MultipartDownloadType = Amazon.S3.Transfer.MultipartDownloadType.PART,
                    };
                    stream = tu.OpenStreamAsync(req, readerCts.Token).GetAwaiter().GetResult();
                }
                var reader = new S3ContentReader(stream, readerCts, asByteStream, raw, encoding,
                    onDispose: () => { UnregisterContentCts(readerCts); Drive.EndContentOperation(); });
                handedOff = true;   // reader now owns readerCts; the finally must NOT dispose it
                return reader;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex))
            {
                WriteError(new ErrorRecord(ex, "ObjectNotFound", ErrorCategory.ObjectNotFound, path));
                return null;
            }
            catch (AmazonS3Exception ex)
            {
                WriteError(new ErrorRecord(ex, "GetContentFailed", ErrorCategory.ReadError, path));
                return null;
            }
            finally
            {
                // On any non-success exit, release readerCts and end the content op. On success the
                // reader owns it (via onDispose), so leave it alone.
                if (!handedOff)
                {
                    UnregisterContentCts(readerCts);
                    readerCts.Dispose();
                    Drive.EndContentOperation();
                }
            }
        }

        public object GetContentReaderDynamicParameters(string path) =>
            new S3ContentReaderDynamicParameters();

        // Read AsByteStream / Raw / Encoding off our dynamic-params type or, on a pipeline bind,
        // FileSystem's (same property names, but its Encoding is a System.Text.Encoding, not a string).
        private static void ReadContentReaderParams(object dp, out bool asByteStream, out bool raw, out System.Text.Encoding encoding)
        {
            asByteStream = false; raw = false; encoding = ResolveEncoding(null);   // default UTF-8 no-BOM
            if (dp == null) return;

            if (dp is S3ContentReaderDynamicParameters ours)
            {
                asByteStream = ours.AsByteStream.IsPresent;
                raw = ours.Raw.IsPresent;
                encoding = ResolveEncoding(ours.Encoding);
                return;
            }

            // Foreign params object (e.g. FileSystem's): read by property name.
            var t = dp.GetType();
            asByteStream = ReadSwitchLike(dp, t, "AsByteStream");
            raw = ReadSwitchLike(dp, t, "Raw");
            var enc = t.GetProperty("Encoding")?.GetValue(dp);
            if (enc is System.Text.Encoding realEnc)
                encoding = realEnc;                          // FileSystem hands a ready Encoding object
            else if (enc is string encName && encName.Length > 0)
                encoding = ResolveEncoding(encName);         // our shape: a friendly name
            // else: leave the UTF-8 default
        }

        // As ReadContentReaderParams, for the writer. S3-only params (PartSize, StorageClass) stay
        // available only from our native type.
        private static void ReadContentWriterParams(object dp, out bool asByteStream, out bool noNewline, out System.Text.Encoding encoding)
        {
            asByteStream = false; noNewline = false; encoding = ResolveEncoding(null);   // default UTF-8 no-BOM
            if (dp == null) return;

            if (dp is S3ContentWriterDynamicParameters ours)
            {
                asByteStream = ours.AsByteStream.IsPresent;
                noNewline = ours.NoNewline.IsPresent;
                encoding = ResolveEncoding(ours.Encoding);
                return;
            }

            // Foreign params object (e.g. FileSystem's): read by property name.
            var t = dp.GetType();
            asByteStream = ReadSwitchLike(dp, t, "AsByteStream");
            noNewline = ReadSwitchLike(dp, t, "NoNewline");
            encoding = ReadEncodingLike(t.GetProperty("Encoding")?.GetValue(dp), encoding);
        }

        // True if property 'name' on dp is a set SwitchParameter or a true bool.
        private static bool ReadSwitchLike(object dp, Type t, string name)
        {
            var val = t.GetProperty(name)?.GetValue(dp);
            if (val == null) return false;
            if (val is SwitchParameter sw) return sw.IsPresent;
            if (val is bool b) return b;
            return false;
        }

        private static System.Text.Encoding ReadEncodingLike(object val, System.Text.Encoding defaultEncoding)
        {
            if (val == null) return defaultEncoding;
            if (val is System.Text.Encoding realEnc) return realEnc;

            var encName = val as string;
            if (encName == null && val.GetType().IsEnum)
                encName = val.ToString();   // Windows PowerShell 5.1 FileSystem dynamic params use an enum.

            if (string.IsNullOrWhiteSpace(encName))
                return defaultEncoding;

            // FileSystem's Windows PowerShell enum uses String/Unknown as unspecified sentinels.
            if (string.Equals(encName, "String", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(encName, "Unknown", StringComparison.OrdinalIgnoreCase))
                return defaultEncoding;

            return ResolveEncoding(encName);
        }

        // Backs Set-Content (upload). The writer feeds TU a non-seekable bridge stream, so every upload
        // takes TU's multipart path: the object is replaced only at CompleteMultipartUpload, and TU
        // aborts on failure/cancellation. Bounded memory (the bridge applies backpressure), no temp file.
        public IContentWriter GetContentWriter(string path)
        {
            if (!TryParseObjectPath(path,
                    "Set-Content requires a path to an S3 object (bucket\\key).",
                    "InvalidContentPath", out var bucket, out var key))
                return null;

            bool asByteStream, noNewline;
            System.Text.Encoding encoding;
            try
            {
                ReadContentWriterParams(DynamicParameters, out asByteStream, out noNewline, out encoding);
            }
            catch (ArgumentException ex)
            {
                WriteError(new ErrorRecord(ex, "BadEncoding", ErrorCategory.InvalidArgument, path));
                return null;
            }

            var writerParams = DynamicParameters as S3ContentWriterDynamicParameters;
            // Per-upload -StorageClass wins, else the drive default, else null (nothing set on the request).
            var storageClass = writerParams?.StorageClass ?? Drive.DefaultStorageClass;
            var partSize = writerParams != null && writerParams.PartSize > 0
                ? writerParams.PartSize
                : MultipartThreshold;
            var cache = Drive.ListingCache;

            // Register the writer's CTS in the content-CTS set so Ctrl+C cancels the in-flight upload.
            // On success the writer owns the CTS + TU; otherwise the finally releases them (handedOff guard).
            var writerCts = new CancellationTokenSource();
            RegisterContentCts(writerCts);
            Drive.BeginContentOperation();   // keep the drive's clients alive for the whole upload
            Amazon.S3.Transfer.TransferUtility tu = null;
            var handedOff = false;
            try
            {
                tu = TransferUtilityForBucket(bucket);
                var writer = new S3TransferContentWriter(tu, bucket, key, asByteStream, writerCts,
                    onComplete: () => cache.InvalidateForKey(bucket, key),
                    onFault: ex => WriteError(new ErrorRecord(ex, "UploadFailed",
                        ErrorCategory.WriteError, $"{bucket}\\{key}")),
                    onDispose: () => { UnregisterContentCts(writerCts); Drive.EndContentOperation(); },
                    partSize: partSize,
                    storageClass: storageClass,
                    encoding: encoding,
                    noNewline: noNewline);
                handedOff = true;   // writer now owns tu + writerCts
                return writer;
            }
            finally
            {
                if (!handedOff)
                {
                    UnregisterContentCts(writerCts);
                    tu?.Dispose();
                    writerCts.Dispose();
                    Drive.EndContentOperation();
                }
            }
        }

        public object GetContentWriterDynamicParameters(string path) =>
            new S3ContentWriterDynamicParameters();

        public void ClearContent(string path)
        {
            throw new PSNotSupportedException(
                "Clear-Content is not supported by the S3 drive.");
        }

        public object ClearContentDynamicParameters(string path) => null;

    }
}
