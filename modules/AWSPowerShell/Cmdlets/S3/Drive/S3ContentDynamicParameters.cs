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
    /// Verified necessity: -AsByteStream / -Raw / -Encoding are NOT static Get-Content
    /// parameters - the provider must supply them, exactly as FileSystemProvider does.
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
        /// Text encoding name for decoding the object's bytes (ignored with -AsByteStream).
        /// Typed as string (not System.Text.Encoding) so the friendly names work -
        /// `-Encoding UTF8` etc. The built-in cmdlet uses a PowerShell-internal transform
        /// attribute we deliberately don't depend on; we map the common names ourselves.
        /// </summary>
        [Parameter]
        public string Encoding { get; set; }
    }

    /// <summary>Dynamic parameters contributed to Set-Content on an S3 path.</summary>
    public sealed class S3ContentWriterDynamicParameters
    {
        /// <summary>Write the pipeline's raw bytes instead of encoding text.</summary>
        [Parameter]
        public SwitchParameter AsByteStream { get; set; }

        /// <summary>
        /// Text encoding used to write text-mode content (ignored with -AsByteStream). Accepts the
        /// same friendly names as Get-Content's -Encoding (e.g. UTF8, Unicode, ASCII); defaults to
        /// UTF-8 (no BOM) when unspecified. Line endings are always LF, so an object written on any
        /// OS is byte-identical - use -AsByteStream when you need exact control over the bytes.
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
        /// Storage class for THIS upload; overrides the drive's default (-StorageClass at mount).
        /// Null when unspecified -> fall back to the drive default, then S3's STANDARD.
        /// </summary>
        [Parameter]
        public S3StorageClass StorageClass { get; set; }
    }
}
