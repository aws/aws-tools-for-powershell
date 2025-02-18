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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Delete a verification token. A verification token is an Amazon Web Services-generated
    /// random value that you can use to prove ownership of an external resource. For example,
    /// you can use a verification token to validate that you control a public IP address
    /// range when you bring an IP address range to Amazon Web Services (BYOIP).
    /// </summary>
    [Cmdlet("Remove", "EC2IpamExternalResourceVerificationToken", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.IpamExternalResourceVerificationToken")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DeleteIpamExternalResourceVerificationToken API operation.", Operation = new[] {"DeleteIpamExternalResourceVerificationToken"}, SelectReturnType = typeof(Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamExternalResourceVerificationToken or Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamExternalResourceVerificationToken object.",
        "The service call response (type Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveEC2IpamExternalResourceVerificationTokenCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IpamExternalResourceVerificationTokenId
        /// <summary>
        /// <para>
        /// <para>The token ID.</para>
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
        public System.String IpamExternalResourceVerificationTokenId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamExternalResourceVerificationToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamExternalResourceVerificationToken";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamExternalResourceVerificationTokenId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2IpamExternalResourceVerificationToken (DeleteIpamExternalResourceVerificationToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenResponse, RemoveEC2IpamExternalResourceVerificationTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IpamExternalResourceVerificationTokenId = this.IpamExternalResourceVerificationTokenId;
            #if MODULAR
            if (this.IpamExternalResourceVerificationTokenId == null && ParameterWasBound(nameof(this.IpamExternalResourceVerificationTokenId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamExternalResourceVerificationTokenId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenRequest();
            
            if (cmdletContext.IpamExternalResourceVerificationTokenId != null)
            {
                request.IpamExternalResourceVerificationTokenId = cmdletContext.IpamExternalResourceVerificationTokenId;
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
        
        private Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DeleteIpamExternalResourceVerificationToken");
            try
            {
                return client.DeleteIpamExternalResourceVerificationTokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IpamExternalResourceVerificationTokenId { get; set; }
            public System.Func<Amazon.EC2.Model.DeleteIpamExternalResourceVerificationTokenResponse, RemoveEC2IpamExternalResourceVerificationTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamExternalResourceVerificationToken;
        }
        
    }
}
