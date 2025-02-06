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
using Amazon.MainframeModernization;
using Amazon.MainframeModernization.Model;

namespace Amazon.PowerShell.Cmdlets.AMM
{
    /// <summary>
    /// Lists all the job steps for a JCL file to restart a batch job. This is only applicable
    /// for Micro Focus engine with versions 8.0.6 and above.
    /// </summary>
    [Cmdlet("Get", "AMMBatchJobRestartPointList")]
    [OutputType("Amazon.MainframeModernization.Model.JobStep")]
    [AWSCmdlet("Calls the M2 ListBatchJobRestartPoints API operation.", Operation = new[] {"ListBatchJobRestartPoints"}, SelectReturnType = typeof(Amazon.MainframeModernization.Model.ListBatchJobRestartPointsResponse))]
    [AWSCmdletOutput("Amazon.MainframeModernization.Model.JobStep or Amazon.MainframeModernization.Model.ListBatchJobRestartPointsResponse",
        "This cmdlet returns a collection of Amazon.MainframeModernization.Model.JobStep objects.",
        "The service call response (type Amazon.MainframeModernization.Model.ListBatchJobRestartPointsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAMMBatchJobRestartPointListCmdlet : AmazonMainframeModernizationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the application.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter AuthSecretsManagerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Secrets Manager containing user's credentials for authentication
        /// and authorization for List Batch Job Restart Points operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthSecretsManagerArn { get; set; }
        #endregion
        
        #region Parameter ExecutionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the batch job execution.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ExecutionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BatchJobSteps'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MainframeModernization.Model.ListBatchJobRestartPointsResponse).
        /// Specifying the name of a property of type Amazon.MainframeModernization.Model.ListBatchJobRestartPointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BatchJobSteps";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MainframeModernization.Model.ListBatchJobRestartPointsResponse, GetAMMBatchJobRestartPointListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthSecretsManagerArn = this.AuthSecretsManagerArn;
            context.ExecutionId = this.ExecutionId;
            #if MODULAR
            if (this.ExecutionId == null && ParameterWasBound(nameof(this.ExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MainframeModernization.Model.ListBatchJobRestartPointsRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.AuthSecretsManagerArn != null)
            {
                request.AuthSecretsManagerArn = cmdletContext.AuthSecretsManagerArn;
            }
            if (cmdletContext.ExecutionId != null)
            {
                request.ExecutionId = cmdletContext.ExecutionId;
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
        
        private Amazon.MainframeModernization.Model.ListBatchJobRestartPointsResponse CallAWSServiceOperation(IAmazonMainframeModernization client, Amazon.MainframeModernization.Model.ListBatchJobRestartPointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "M2", "ListBatchJobRestartPoints");
            try
            {
                #if DESKTOP
                return client.ListBatchJobRestartPoints(request);
                #elif CORECLR
                return client.ListBatchJobRestartPointsAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String AuthSecretsManagerArn { get; set; }
            public System.String ExecutionId { get; set; }
            public System.Func<Amazon.MainframeModernization.Model.ListBatchJobRestartPointsResponse, GetAMMBatchJobRestartPointListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BatchJobSteps;
        }
        
    }
}
