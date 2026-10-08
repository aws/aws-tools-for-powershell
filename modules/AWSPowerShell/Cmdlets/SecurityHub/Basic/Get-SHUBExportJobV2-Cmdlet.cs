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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Returns the details of a single findings export job, including its current <c>Status</c>,
    /// the <c>Destination</c> it writes to, the <c>OutputConfiguration</c> it was started
    /// with, and its <c>StartedAt</c> and <c>EndedAt</c> timestamps. Use this operation to
    /// poll an export job that you started with <c>StartExportJobV2</c> until it reaches
    /// a terminal state (<c>SUCCEEDED</c>, <c>FAILED</c>, or <c>CANCELLED</c>).
    /// 
    ///  
    /// <para>
    /// If the job failed, the response includes a <c>FailureCode</c> and <c>FailureMessage</c>
    /// that describe the reason. Input values such as <c>Scopes</c> and <c>Filters</c> are
    /// echoed back as they were submitted, with relative date ranges returned unresolved.
    /// If no export job matches the <c>ExportJobId</c> that you provide, this operation returns
    /// a <c>ResourceNotFoundException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SHUBExportJobV2")]
    [OutputType("Amazon.SecurityHub.Model.GetExportJobV2Response")]
    [AWSCmdlet("Calls the AWS Security Hub GetExportJobV2 API operation.", Operation = new[] {"GetExportJobV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetExportJobV2Response))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.GetExportJobV2Response",
        "This cmdlet returns an Amazon.SecurityHub.Model.GetExportJobV2Response object containing multiple properties."
    )]
    public partial class GetSHUBExportJobV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExportJobId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the export job to retrieve. This is the value returned by
        /// <c>StartExportJobV2</c>.</para>
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
        public System.String ExportJobId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetExportJobV2Response).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetExportJobV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetExportJobV2Response, GetSHUBExportJobV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExportJobId = this.ExportJobId;
            #if MODULAR
            if (this.ExportJobId == null && ParameterWasBound(nameof(this.ExportJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.GetExportJobV2Request();
            
            if (cmdletContext.ExportJobId != null)
            {
                request.ExportJobId = cmdletContext.ExportJobId;
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
        
        private Amazon.SecurityHub.Model.GetExportJobV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetExportJobV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetExportJobV2");
            try
            {
                return client.GetExportJobV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ExportJobId { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetExportJobV2Response, GetSHUBExportJobV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
