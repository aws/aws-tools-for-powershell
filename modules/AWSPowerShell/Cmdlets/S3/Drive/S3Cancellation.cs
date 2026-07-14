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
using System.Threading;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>Small cancellation helpers shared by the provider and the content writer.</summary>
    internal static class S3Cancellation
    {
        /// <summary>
        /// Cancel a CancellationTokenSource, swallowing the ObjectDisposedException that races when
        /// the source has already been torn down. A no-op on null.
        /// </summary>
        internal static void SafeCancel(CancellationTokenSource cts)
        {
            try { cts?.Cancel(); } catch (ObjectDisposedException) { /* already torn down */ }
        }
    }
}
