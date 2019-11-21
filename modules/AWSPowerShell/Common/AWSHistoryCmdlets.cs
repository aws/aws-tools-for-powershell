/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Text;
using System.Management.Automation;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Clears the contents of the AWS cmdlet history buffer ($AWSHistory) in the current shell.
    /// </summary>
    [Cmdlet("Clear", "AWSHistory")]
    [AWSCmdlet("Clears the contents of the AWS cmdlet history buffer ($AWSHistory) in the current shell.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class ClearAWSHistoryCmdlet : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            AWSCmdletHistoryBuffer.Instance.Clear();
        }
    }

    /// <summary>
    /// <para>
    /// Configures the $AWSHistory instance for the current session. 
    /// </para>
    /// <para>
    /// A history buffer size of 0 disables overall AWS cmdlet activity recording and clears any data currently 
    /// in the buffer. If the new size is smaller than the current data in the buffer, older records are deleted.
    /// </para>
    /// <para>
    /// By default, only service responses are recorded for a cmdlet. Use the -EnableRequestRecording switch
    /// to turn on tracing of service requests in the buffer.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "AWSHistoryConfiguration")]
    [AWSCmdlet("Configures how the $AWSHistory session variable records AWS cmdlet processing.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class SetAWSHistoryConfigurationCmdlet : PSCmdlet
    {
        /// <summary>
        /// The maximum number of AWS cmdlet invocations that will be held in the history buffer.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public int? MaxCmdletHistory { get; set; }

        /// <summary>
        /// The maximum number of service responses (and requests, if enabled)
        /// that will be recorded for a single AWS cmdlet.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public int? MaxServiceCallHistory { get; set; }

        /// <summary>
        /// If set, also records the service requests that a cmdlet makes. Default: Off.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter RecordServiceRequests { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (MaxCmdletHistory != null)
            {
                if (MaxCmdletHistory.Value >= 0)
                    AWSCmdletHistoryBuffer.Instance.MaxHistoryLength = MaxCmdletHistory.Value;
                else
                    this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Negative values are not valid."),
                                                                "ArgumentException",
                                                                ErrorCategory.InvalidArgument,
                                                                this.MaxCmdletHistory));
            }

            if (MaxServiceCallHistory != null)
            {
                if (MaxServiceCallHistory.Value > 0)
                    AWSCmdletHistoryBuffer.Instance.ServiceCallHistoryLength = MaxServiceCallHistory.Value;
                else
                    this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Value must be greater than 0."),
                                                                "ArgumentException",
                                                                ErrorCategory.InvalidArgument,
                                                                this.MaxServiceCallHistory));
            }

            AWSCmdletHistoryBuffer.Instance.RecordServiceRequests = RecordServiceRequests.IsPresent;
        }
    }
}
