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
using System.Threading;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Retrieves a large logging object (LLO) and streams it back. This API is used to fetch
    /// the content of large portions of log events that have been ingested through the PutOpenTelemetryLogs
    /// API. When log events contain fields that would cause the total event size to exceed
    /// 1MB, CloudWatch Logs automatically processes up to 10 fields, starting with the largest
    /// fields. Each field is truncated as needed to keep the total event size as close to
    /// 1MB as possible. The excess portions are stored as Large Log Objects (LLOs) and these
    /// fields are processed separately and LLO reference system fields (in the format <c>@ptr.$[path.to.field]</c>)
    /// are added. The path in the reference field reflects the original JSON structure where
    /// the large field was located. For example, this could be <c>@ptr.$['input']['message']</c>,
    /// <c>@ptr.$['AAA']['BBB']['CCC']['DDD']</c>, <c>@ptr.$['AAA']</c>, or any other path
    /// matching your log structure.
    /// </summary>
    [Cmdlet("Get", "CWLLogObject")]
    [OutputType("Amazon.CloudWatchLogs.Model.GetLogObjectResponseStream")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs GetLogObject API operation.", Operation = new[] {"GetLogObject"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.GetLogObjectResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.GetLogObjectResponseStream or Amazon.CloudWatchLogs.Model.GetLogObjectResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.GetLogObjectResponseStream object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.GetLogObjectResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWLLogObjectCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogObjectPointer
        /// <summary>
        /// <para>
        /// <para>A pointer to the specific log object to retrieve. This is a required parameter that
        /// uniquely identifies the log object within CloudWatch Logs. The pointer is typically
        /// obtained from a previous query or filter operation.</para>
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
        public System.String LogObjectPointer { get; set; }
        #endregion
        
        #region Parameter Unmask
        /// <summary>
        /// <para>
        /// <para>A boolean flag that indicates whether to unmask sensitive log data. When set to true,
        /// any masked or redacted data in the log object will be displayed in its original form.
        /// Default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Unmask { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FieldStream'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.GetLogObjectResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.GetLogObjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FieldStream";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.GetLogObjectResponse, GetCWLLogObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LogObjectPointer = this.LogObjectPointer;
            #if MODULAR
            if (this.LogObjectPointer == null && ParameterWasBound(nameof(this.LogObjectPointer)))
            {
                WriteWarning("You are passing $null as a value for parameter LogObjectPointer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Unmask = this.Unmask;
            
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
            var request = new Amazon.CloudWatchLogs.Model.GetLogObjectRequest();
            
            if (cmdletContext.LogObjectPointer != null)
            {
                request.LogObjectPointer = cmdletContext.LogObjectPointer;
            }
            if (cmdletContext.Unmask != null)
            {
                request.Unmask = cmdletContext.Unmask.Value;
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
        
        private Amazon.CloudWatchLogs.Model.GetLogObjectResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.GetLogObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "GetLogObject");
            try
            {
                return client.GetLogObjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LogObjectPointer { get; set; }
            public System.Boolean? Unmask { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.GetLogObjectResponse, GetCWLLogObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FieldStream;
        }
        
    }
}
