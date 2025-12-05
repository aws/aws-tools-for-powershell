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
using Amazon.PartnerCentralAccount;
using Amazon.PartnerCentralAccount.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCAA
{
    /// <summary>
    /// Retrieves the current status and details of a verification process for a partner account.
    /// This operation allows partners to check the progress and results of business or registrant
    /// verification processes.
    /// </summary>
    [Cmdlet("Get", "PCAAVerification")]
    [OutputType("Amazon.PartnerCentralAccount.Model.GetVerificationResponse")]
    [AWSCmdlet("Calls the Partner Central Account API GetVerification API operation.", Operation = new[] {"GetVerification"}, SelectReturnType = typeof(Amazon.PartnerCentralAccount.Model.GetVerificationResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralAccount.Model.GetVerificationResponse",
        "This cmdlet returns an Amazon.PartnerCentralAccount.Model.GetVerificationResponse object containing multiple properties."
    )]
    public partial class GetPCAAVerificationCmdlet : AmazonPartnerCentralAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter VerificationType
        /// <summary>
        /// <para>
        /// <para>The type of verification to retrieve information for. Valid values include business
        /// verification for company registration details and registrant verification for individual
        /// identity confirmation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralAccount.VerificationType")]
        public Amazon.PartnerCentralAccount.VerificationType VerificationType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralAccount.Model.GetVerificationResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralAccount.Model.GetVerificationResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralAccount.Model.GetVerificationResponse, GetPCAAVerificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.VerificationType = this.VerificationType;
            #if MODULAR
            if (this.VerificationType == null && ParameterWasBound(nameof(this.VerificationType)))
            {
                WriteWarning("You are passing $null as a value for parameter VerificationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PartnerCentralAccount.Model.GetVerificationRequest();
            
            if (cmdletContext.VerificationType != null)
            {
                request.VerificationType = cmdletContext.VerificationType;
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
        
        private Amazon.PartnerCentralAccount.Model.GetVerificationResponse CallAWSServiceOperation(IAmazonPartnerCentralAccount client, Amazon.PartnerCentralAccount.Model.GetVerificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Account API", "GetVerification");
            try
            {
                return client.GetVerificationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PartnerCentralAccount.VerificationType VerificationType { get; set; }
            public System.Func<Amazon.PartnerCentralAccount.Model.GetVerificationResponse, GetPCAAVerificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
