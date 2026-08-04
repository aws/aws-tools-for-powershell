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

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Uniform item emitted for buckets, folders, and objects, giving every listed item the same
    /// surface (Name, Size, LastModified, Type) for Get-ChildItem columns and pipeline filters - which
    /// the raw SDK models don't (S3Bucket has BucketName not Name; S3Object has no Name).
    ///
    /// Name is the leaf only; use the PSPath the provider attaches for an unambiguous identity, since
    /// a recursive listing can surface the same leaf Name under different prefixes.
    /// </summary>
    public sealed class S3ItemInfo
    {
        // Public contract matched by the format.ps1xml view, README, and tests - keep the exact strings
        // (consts, not an enum, to keep the on-the-wire values stable).
        public const string TypeBucket = "Bucket";
        public const string TypeFolder = "Folder";
        public const string TypeObject = "Object";

        public string Name { get; private set; }
        public string Type { get; private set; }          // TypeBucket | TypeFolder | TypeObject
        public long? Size { get; private set; }            // null for containers
        public DateTime? LastModified { get; private set; }

        public static S3ItemInfo Bucket(string name, DateTime? created) =>
            new S3ItemInfo { Name = name, Type = TypeBucket, LastModified = created };

        public static S3ItemInfo Folder(string name) =>
            new S3ItemInfo { Name = name, Type = TypeFolder };

        public static S3ItemInfo File(string name, long? size, DateTime? lastModified) =>
            new S3ItemInfo { Name = name, Type = TypeObject, Size = size, LastModified = lastModified };

        public override string ToString() => Name;
    }
}
