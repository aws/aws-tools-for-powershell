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

using System.Management.Automation;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Dynamic parameters contributed to Get-Content when the target is an S3 path.
    /// -AsByteStream / -Raw / -Encoding are not static Get-Content parameters, so the
    /// provider supplies them, as FileSystemProvider does.
    /// </summary>
    public sealed class S3ContentReaderDynamicParameters
    {
        /// <summary>Return the object's raw bytes instead of decoded text.</summary>
        [Parameter]
        public SwitchParameter AsByteStream { get; set; }

        /// <summary>Return the whole object as a single string instead of line by line.</summary>
        [Parameter]
        public SwitchParameter Raw { get; set; }

        /// <summary>
        /// Text encoding for decoding the object (ignored with -AsByteStream). A friendly name
        /// (e.g. UTF8), typed as string and mapped ourselves rather than via the built-in cmdlet's
        /// PowerShell-internal transform.
        /// </summary>
        [Parameter]
        public string Encoding { get; set; }
    }

    /// <summary>Dynamic parameters contributed to Set-Content on an S3 path.</summary>
    public sealed class S3ContentWriterDynamicParameters
    {
        private const long MinMultipartUploadPartSize = 5L * 1024 * 1024;
        private const long MaxMultipartUploadPartSize = 5L * 1024 * 1024 * 1024;

        /// <summary>Write the pipeline's raw bytes instead of encoding text.</summary>
        [Parameter]
        public SwitchParameter AsByteStream { get; set; }

        /// <summary>
        /// Text encoding for writing (ignored with -AsByteStream); same friendly names as Get-Content's
        /// -Encoding, defaulting to UTF-8 no-BOM. Line endings are always LF; use -AsByteStream for
        /// exact byte control.
        /// </summary>
        [Parameter]
        public string Encoding { get; set; }

        /// <summary>
        /// Do not append the provider's default LF after each text value. Ignored with
        /// -AsByteStream, where bytes are written exactly as provided.
        /// </summary>
        [Parameter]
        public SwitchParameter NoNewline { get; set; }

        /// <summary>
        /// Storage class for this upload; overrides the drive default. Null -> drive default, then STANDARD.
        /// </summary>
        [Parameter]
        public S3StorageClass StorageClass { get; set; }

        /// <summary>
        /// Multipart part size for this upload, overriding the provider default. Between S3's 5 MiB and 5 GiB.
        /// </summary>
        [Parameter]
        [ValidateRange(MinMultipartUploadPartSize, MaxMultipartUploadPartSize)]
        public long PartSize { get; set; }
    }
}
