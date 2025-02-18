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
using Amazon.ServerlessApplicationRepository;
using Amazon.ServerlessApplicationRepository.Model;

namespace Amazon.PowerShell.Cmdlets.SAR
{
    /// <summary>
    /// Retrieves the policy for the application.
    /// </summary>
    [Cmdlet("Get", "SARApplicationPolicy")]
    [OutputType("Amazon.ServerlessApplicationRepository.Model.ApplicationPolicyStatement")]
    [AWSCmdlet("Calls the AWS Serverless Application Repository GetApplicationPolicy API operation.", Operation = new[] {"GetApplicationPolicy"}, SelectReturnType = typeof(Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyResponse))]
    [AWSCmdletOutput("Amazon.ServerlessApplicationRepository.Model.ApplicationPolicyStatement or Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyResponse",
        "This cmdlet returns a collection of Amazon.ServerlessApplicationRepository.Model.ApplicationPolicyStatement objects.",
        "The service call response (type Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSARApplicationPolicyCmdlet : AmazonServerlessApplicationRepositoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the application.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Statements'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyResponse).
        /// Specifying the name of a property of type Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Statements";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyResponse, GetSARApplicationPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
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
        
        private Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyResponse CallAWSServiceOperation(IAmazonServerlessApplicationRepository client, Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Serverless Application Repository", "GetApplicationPolicy");
            try
            {
                return client.GetApplicationPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ServerlessApplicationRepository.Model.GetApplicationPolicyResponse, GetSARApplicationPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Statements;
        }
        
    }
}
