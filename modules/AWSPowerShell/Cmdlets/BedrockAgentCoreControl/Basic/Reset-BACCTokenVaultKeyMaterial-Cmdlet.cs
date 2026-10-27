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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Resets the key material for a token vault whose customer managed KMS key has been
    /// deleted, and re-encrypts the token vault with an Amazon Web Services managed key so
    /// that you can use the token vault again.
    /// 
    ///  <important><para>
    /// This operation can't be undone. The reset permanently deletes the OAuth2 access tokens
    /// and refresh tokens stored in the token vault, including tokens obtained through all
    /// supported flows. After the reset, your agents must complete these flows again to get
    /// new tokens, and for user-delegated flows your users must authorize access again. The
    /// reset doesn't delete your credential providers or their configuration.
    /// </para></important><para>
    /// You can reset a token vault only if its customer managed key has been deleted. If
    /// the key still exists, including when it's disabled or scheduled for deletion, this
    /// operation returns a <c>ValidationException</c>. To use the token vault again, enable
    /// the key or cancel its scheduled deletion in KMS. To switch to a different key, use
    /// <c>SetTokenVaultCMK</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Reset", "BACCTokenVaultKeyMaterial", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer ResetTokenVaultKeyMaterial API operation.", Operation = new[] {"ResetTokenVaultKeyMaterial"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialResponse object containing multiple properties."
    )]
    public partial class ResetBACCTokenVaultKeyMaterialCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TokenVaultId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the token vault to reset. To reset your account's default
        /// token vault, specify <c>default</c>.</para>
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
        public System.String TokenVaultId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TokenVaultId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-BACCTokenVaultKeyMaterial (ResetTokenVaultKeyMaterial)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialResponse, ResetBACCTokenVaultKeyMaterialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TokenVaultId = this.TokenVaultId;
            #if MODULAR
            if (this.TokenVaultId == null && ParameterWasBound(nameof(this.TokenVaultId)))
            {
                WriteWarning("You are passing $null as a value for parameter TokenVaultId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialRequest();
            
            if (cmdletContext.TokenVaultId != null)
            {
                request.TokenVaultId = cmdletContext.TokenVaultId;
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
        
        private Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "ResetTokenVaultKeyMaterial");
            try
            {
                return client.ResetTokenVaultKeyMaterialAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TokenVaultId { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.ResetTokenVaultKeyMaterialResponse, ResetBACCTokenVaultKeyMaterialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
