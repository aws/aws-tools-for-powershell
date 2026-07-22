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
        // ---- Cancellation ----------------------------------------------------

        private volatile CancellationTokenSource _currentCts;

        // Content reader/writer CTSes span a whole streamed read/upload, outliving the single SDK call
        // that _currentCts tracks. A set, because several can be live at once (e.g. Get-Content |
        // Set-Content) and StopProcessing must cancel all of them.
        private readonly System.Collections.Concurrent.ConcurrentDictionary<CancellationTokenSource, byte> _contentCtses =
            new System.Collections.Concurrent.ConcurrentDictionary<CancellationTokenSource, byte>();

        private void RegisterContentCts(CancellationTokenSource cts) => _contentCtses.TryAdd(cts, 0);
        private void UnregisterContentCts(CancellationTokenSource cts) => _contentCtses.TryRemove(cts, out _);

        protected override void StopProcessing()
        {
            base.StopProcessing();
            S3Cancellation.SafeCancel(_currentCts);
            foreach (var cts in _contentCtses.Keys)
                S3Cancellation.SafeCancel(cts);
        }

        // Block on an async SDK call, wiring its cancellation token to Ctrl+C (StopProcessing).
        private T RunSync<T>(Func<CancellationToken, Task<T>> op)
        {
            using (var cts = new CancellationTokenSource())
            {
                _currentCts = cts;
                try { return op(cts.Token).GetAwaiter().GetResult(); }
                finally { _currentCts = null; }
            }
        }

    }
}
