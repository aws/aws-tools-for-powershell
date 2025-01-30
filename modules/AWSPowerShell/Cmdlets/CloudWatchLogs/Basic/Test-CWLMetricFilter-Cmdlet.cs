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
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Tests the filter pattern of a metric filter against a sample of log event messages.
    /// You can use this operation to validate the correctness of a metric filter pattern.
    /// </summary>
    [Cmdlet("Test", "CWLMetricFilter")]
    [OutputType("Amazon.CloudWatchLogs.Model.MetricFilterMatchRecord")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs TestMetricFilter API operation.", Operation = new[] {"TestMetricFilter"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.TestMetricFilterResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.MetricFilterMatchRecord or Amazon.CloudWatchLogs.Model.TestMetricFilterResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchLogs.Model.MetricFilterMatchRecord objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.TestMetricFilterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestCWLMetricFilterCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FilterPattern
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FilterPattern { get; set; }
        #endregion
        
        #region Parameter LogEventMessage
        /// <summary>
        /// <para>
        /// <para>The log event messages to test.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LogEventMessages")]
        public System.String[] LogEventMessage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Matches'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.TestMetricFilterResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.TestMetricFilterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Matches";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FilterPattern parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FilterPattern' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FilterPattern' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.TestMetricFilterResponse, TestCWLMetricFilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FilterPattern;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FilterPattern = this.FilterPattern;
            #if MODULAR
            if (this.FilterPattern == null && ParameterWasBound(nameof(this.FilterPattern)))
            {
                WriteWarning("You are passing $null as a value for parameter FilterPattern which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LogEventMessage != null)
            {
                context.LogEventMessage = new List<System.String>(this.LogEventMessage);
            }
            #if MODULAR
            if (this.LogEventMessage == null && ParameterWasBound(nameof(this.LogEventMessage)))
            {
                WriteWarning("You are passing $null as a value for parameter LogEventMessage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatchLogs.Model.TestMetricFilterRequest();
            
            if (cmdletContext.FilterPattern != null)
            {
                request.FilterPattern = cmdletContext.FilterPattern;
            }
            if (cmdletContext.LogEventMessage != null)
            {
                request.LogEventMessages = cmdletContext.LogEventMessage;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatchLogs.Model.TestMetricFilterResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.TestMetricFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "TestMetricFilter");
            try
            {
                #if DESKTOP
                return client.TestMetricFilter(request);
                #elif CORECLR
                return client.TestMetricFilterAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String FilterPattern { get; set; }
            public List<System.String> LogEventMessage { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.TestMetricFilterResponse, TestCWLMetricFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Matches;
        }
        
    }
}
