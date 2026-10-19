/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;

namespace Amazon.PowerShell.Common.Internal
{
    /// <summary>
    /// Validates names and values before writing AWS configuration or credentials INI files.
    /// </summary>
    public static class IniValidationUtils
    {
        private static readonly char[] InvalidSectionNameChars = { '\r', '\n', '[', ']' };

        private static readonly char[] LineBreakChars = { '\r', '\n' };

        /// <summary>
        /// Validates that an INI section name component is not empty or whitespace
        /// and does not contain line breaks or square brackets.
        /// </summary>
        public static void ValidateSectionNameComponent(string name, string paramName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{paramName} must have value set.", paramName);
            }

            if (name.IndexOfAny(InvalidSectionNameChars) >= 0)
            {
                throw new ArgumentException(
                    $"{paramName} contains invalid characters. Line breaks and '[' or ']' are not allowed.",
                    paramName);
            }
        }

        /// <summary>
        /// Validates that an INI property value does not contain line breaks.
        /// </summary>
        public static void ValidatePropertyValue(string value, string paramName)
        {
            if (!string.IsNullOrEmpty(value) && value.IndexOfAny(LineBreakChars) >= 0)
            {
                throw new ArgumentException(
                    $"{paramName} contains invalid characters. Line breaks are not allowed.",
                    paramName);
            }
        }

    }
}
