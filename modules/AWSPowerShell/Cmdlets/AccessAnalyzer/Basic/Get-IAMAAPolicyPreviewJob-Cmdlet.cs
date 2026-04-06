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
using Amazon.AccessAnalyzer;
using Amazon.AccessAnalyzer.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAMAA
{
    /// <summary>
    /// Retrieves the metadata, parameters, and status for a policy preview job. Use this
    /// operation to monitor job progress and retrieve the Amazon S3 location of the completed
    /// analysis report.
    /// 
    ///  <note><para>
    /// Job data has a time-to-live (TTL) of 14 days and will be deleted after expiration.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "IAMAAPolicyPreviewJob")]
    [OutputType("Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobResponse")]
    [AWSCmdlet("Calls the AWS IAM Access Analyzer GetPolicyPreviewJob API operation.", Operation = new[] {"GetPolicyPreviewJob"}, SelectReturnType = typeof(Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobResponse))]
    [AWSCmdletOutput("Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobResponse",
        "This cmdlet returns an Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobResponse object containing multiple properties."
    )]
    public partial class GetIAMAAPolicyPreviewJobCmdlet : AmazonAccessAnalyzerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the policy preview job to retrieve. This is the job ID returned
        /// by <c>StartPolicyPreviewJob</c>.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobResponse).
        /// Specifying the name of a property of type Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobResponse, GetIAMAAPolicyPreviewJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
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
        
        private Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobResponse CallAWSServiceOperation(IAmazonAccessAnalyzer client, Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IAM Access Analyzer", "GetPolicyPreviewJob");
            try
            {
                return client.GetPolicyPreviewJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String JobId { get; set; }
            public System.Func<Amazon.AccessAnalyzer.Model.GetPolicyPreviewJobResponse, GetIAMAAPolicyPreviewJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
