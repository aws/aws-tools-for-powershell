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
using System.Collections.Generic;
using System.Reflection;
using Amazon.Util.Internal;
using System.Collections.ObjectModel;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Helper class for cmdlet parameters dealing with file size. 
    /// Allow entering size units such as 5KB, 10MB, 12GB, 14TB.
    /// </summary>
    public class FileSize
    {
        private static readonly Dictionary<string, int> _unitConverters = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            // Unit Suffix, Logrithmic Multiple
            { "bytes", 0 },
            { "KB", 1 },
            { "MB", 2  },
            { "GB", 3  },
            { "TB", 4  }
        };

        const long OneKBInBytes = 1024L;

        public FileSize(string rawString)
        {
            FileSizeInBytes = ParseBytes(rawString);
        }

        public long? FileSizeInBytes { get; }

        /// <summary>
        /// Converts the string <paramref name="rawString"></paramref> representing the file size to the value in bytes. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <example> 1KB would return 1024</example>
        public static bool TryParseBytes(string rawString, out long? value)
        {
            try
            {
                value = ParseBytes(rawString);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        /// <summary>
        /// Converts the string <paramref name="rawString"></paramref> representing the file size to the value in bytes.
        /// </summary>
        /// <example> 1KB would return 1024</example>
        public static long ParseBytes(string rawString)
        {
            if (string.IsNullOrWhiteSpace(rawString))
                throw new ArgumentException("Missing value for argument.", nameof(rawString));

            rawString = rawString.Trim();

            // Find the last non-alphabetic character.
            int extensionStartIndex = 0;
            for (int counter = rawString.Length - 1; counter >= 0; counter--)
            {
                // Stop if we find something other than a letter.
                if (!char.IsLetter(rawString, counter))
                {
                    extensionStartIndex = counter + 1;
                    break;
                }
            }

            // Get the numeric part.
            double number = double.Parse(rawString.Substring(0, extensionStartIndex));

            // Get the extension.
            string sizeSuffix;
            if (extensionStartIndex < rawString.Length)
            {
                sizeSuffix = rawString.Substring(extensionStartIndex).Trim();
            }
            else
            {
                sizeSuffix = "bytes";
            }

            if (_unitConverters.TryGetValue(sizeSuffix, out var sizeLogMultiple))
            {
                return (long)Math.Round(number * Math.Pow(OneKBInBytes, sizeLogMultiple));
            }
            else
            {
                throw new FormatException("Unsupported file size extension " + sizeSuffix + ".");
            }
        }

        public static implicit operator FileSize(string s)
        {
            return new FileSize(s);
        }
    }
}
