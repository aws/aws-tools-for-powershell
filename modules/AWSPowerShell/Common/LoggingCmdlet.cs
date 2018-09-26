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

using Microsoft.PowerShell.Commands;
using Amazon;
using System.Management.Automation;
using System.Diagnostics;
using System.Globalization;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Adds a single trace listener to the specified trace source. Given a name and file path, 
    /// creates a TextWriterTraceListener with the given name and file path, and adds it to the 
    /// listeners for the trace source.
    /// <para>If Source is not specified, 'Amazon' is assumed, which represents all SDK API calls. 
    /// In the case where there are multiple listeners for multiple sources, Trace calls for an
    /// API will go to the most specific source only. For example, if one listener is added to 'Amazon.S3' and
    /// another on 'Amazon', then S3 calls will only be logged to the former listener.</para>
    /// </summary>
    [Cmdlet("Add", "AWSLoggingListener", DefaultParameterSetName = ParamSet_SimpleListener)]
    [OutputType("None")]
    [AWSCmdlet("Adds a listener to aws service calls and enable logging.")]
    [AWSCmdletOutput("None", "This cmdlet does not produce any output.")]
    public class AddLoggerCmdlet : PSCmdlet
    {
        const string ParamSet_SimpleListener = "SimpleListener";
        const string ParamSet_CustomListener = "CustomListener";

        /// <summary>
        /// The name of the logger.
        /// </summary>
        [Parameter(Position=0, Mandatory=true, ParameterSetName = ParamSet_SimpleListener)]
        public string Name { get; set; }

        /// <summary>
        /// File path to write the log to.
        /// </summary>
        [Parameter(Position=1, Mandatory=true, ParameterSetName = ParamSet_SimpleListener)]
        public string LogFilePath { get; set; }

        /// <summary>
        /// Specify a custom trace listener object.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ParamSet_CustomListener)]
        public TraceListener TraceListener { get; set; }

        /// <summary>
        /// Specify a source to log responses for.
        /// <para>
        /// Defaults to all responses (i.e. 'Amazon'). To limit to a specific service (for example DynamoDB), use 'Amazon.DynamoDB'.)
        /// </para>
        /// </summary>
        [Parameter]
        public string Source { get; set; }

        protected override void ProcessRecord()
        {
            var listener = this.ParameterSetName.Equals(ParamSet_SimpleListener, StringComparison.OrdinalIgnoreCase)  
                ? new TextWriterTraceListener(LogFilePath, Name)
                : TraceListener;
            
            AWSConfigs.AddTraceListener(Source ?? "Amazon", listener);

            AWSConfigs.LoggingConfig.LogTo |= LoggingOptions.SystemDiagnostics;
            
            Trace.AutoFlush = true;

            // bump the logging level up to OnError at least. Might already be configured higher.
            if (AWSConfigs.LoggingConfig.LogResponses == ResponseLoggingOption.Never)
                AWSConfigs.LoggingConfig.LogResponses = ResponseLoggingOption.OnError;
        }
    }

    /// <summary>
    /// Remove a listener from and AWS API trace source.
    /// </summary>
    [Cmdlet("Remove", "AWSLoggingListener")]
    [OutputType("None")]
    [AWSCmdlet("Removes a logger from the specified source (e.g. 'Amazon', or 'Amazon.S3') by name.")]
    [AWSCmdletOutput("None", "This cmdlet does not produce any output.")]
    public class RemoveLoggerCmdlet : PSCmdlet
    {
        /// <summary>
        /// Source to remove the listener from.
        /// <para>
        /// Examples: 'Amazon', or 'Amazon.DynamoDB'.
        /// </para>
        /// </summary>
        [Parameter(Position=0, Mandatory=true)]
        public string Source { get; set; }

        /// <summary>
        /// Name of the trace listener to remove.
        /// </summary>
        [Parameter(Position=1, Mandatory=true)]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            AWSConfigs.RemoveTraceListener(Source, Name);
        }
    }

    /// <summary>
    /// Modify when to produce log entries.
    /// </summary>
    [Cmdlet("Set", "AWSResponseLogging")]
    [OutputType("None")]
    [AWSCmdlet("Modify response logging options for AWS service requests.")]
    [AWSCmdletOutput("None", "This cmdlet does not produce any output.")]
    public class SetResponseLoggingCmdlet : PSCmdlet
    {
        const string 
            ResponseLogging_All   = "Always",
            ResponseLogging_Error = "OnError",
            ResponseLogging_Never = "Never";

        /// <summary>
        /// When to log responses.
        /// </summary>
        /// <remarks>
        /// Must be one of 'Always', 'OnError', or 'Never'.
        /// </remarks>
        [Parameter(Position=0)]
        public string Level { get; set; }

        protected override void ProcessRecord()
        {
            if (Level.Equals(ResponseLogging_All, StringComparison.OrdinalIgnoreCase))
                AWSConfigs.LoggingConfig.LogResponses = ResponseLoggingOption.Always;
            else if (Level.Equals(ResponseLogging_Error, StringComparison.OrdinalIgnoreCase))
                AWSConfigs.LoggingConfig.LogResponses = ResponseLoggingOption.OnError;
            else if (Level.Equals(ResponseLogging_Never, StringComparison.OrdinalIgnoreCase))
                AWSConfigs.LoggingConfig.LogResponses = ResponseLoggingOption.Never;
            else
                ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException("Level must be one of 'Always', 'OnError', or 'Never'"),
                    "ArgumentException",
                    ErrorCategory.InvalidArgument,
                    Level));
        }
    }

    [Cmdlet("Enable", "AWSMetricsLogging")]
    [OutputType("None")]
    [AWSCmdlet("Enable logging of metrics data for AWS service requests.")]
    [AWSCmdletOutput("None", "This cmdlet does not produce any output.")]
    public class EnableMetricsLoggingCmdlet : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            AWSConfigs.LoggingConfig.LogMetrics = true;
        }
    }

    [Cmdlet("Disable", "AWSMetricsLogging")]
    [OutputType("None")]
    [AWSCmdlet("Disable logging of metrics data for AWS service requests.")]
    [AWSCmdletOutput("None", "This cmdlet does not produce any output.")]
    public class DisableMetricsLoggingCmdlet : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            AWSConfigs.LoggingConfig.LogMetrics = false;
        }
    }
}
