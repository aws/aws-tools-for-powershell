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

namespace Amazon.PowerShell.Cmdlets.S3
{
    public sealed partial class S3Provider
    {
        // ---- Unsupported operations ------------------------------------------
        //
        // Out-of-scope container/navigation mutators. Without these overrides the base provider throws
        // the engine's GENERIC "provider does not support this operation", which reads as a defect next
        // to the S3-specific guidance the content ops give. Override them to throw a single, consistent,
        // actionable PSNotSupportedException so all unsupported operations look the same. (Add-Content,
        // which routes through the content writer, not a provider method, is rejected in
        // S3TransferContentWriter.Seek, and ClearContent below; both use the same message shape.)

        // Shared message: "<Cmdlet> is not supported by the S3 drive. <guidance>"
        internal static PSNotSupportedException Unsupported(string op, string guidance) =>
            new PSNotSupportedException($"{op} is not supported by the S3 drive. {guidance}");

        protected override void NewItem(string path, string itemTypeName, object newItemValue) =>
            throw Unsupported("New-Item",
                "S3 has no directories - a prefix appears once an object exists under it. Create an object with Set-Content (or Write-S3Object).");

        protected override void CopyItem(string path, string copyPath, bool recurse) =>
            throw Unsupported("Copy-Item",
                "Use Copy-S3Object, or pipe Get-Content to Set-Content.");

        protected override void MoveItem(string path, string destination) =>
            throw Unsupported("Move-Item",
                "Use Copy-S3Object then Remove-Item.");

        protected override void RenameItem(string path, string newName) =>
            throw Unsupported("Rename-Item",
                "Use Copy-S3Object to the new key then Remove-Item the old one.");
    }
}
