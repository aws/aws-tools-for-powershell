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
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Collection of helpers for working with PowerShell objects
    /// </summary>
    public static class PSHelpers
    {
        /// <summary>
        /// Converts a (possibly) relative path into an absolute one
        /// </summary>
        /// <param name="path">Current path</param>
        /// <param name="relativeOrAbsolutePath">Path to convert</param>
        /// <returns>Absolute path</returns>
        public static string PSPathToAbsolute(PathIntrinsics path, string relativeOrAbsolutePath)
        {
            if (string.IsNullOrEmpty(relativeOrAbsolutePath))
                return relativeOrAbsolutePath;

            string driveName;
            if (path.IsPSAbsolute(relativeOrAbsolutePath, out driveName))
                return relativeOrAbsolutePath;
            else
                return path.GetUnresolvedProviderPathFromPSPath(relativeOrAbsolutePath);
        }
    }
}
