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
    /// Updates an existing consent portal.
    /// </summary>
    [Cmdlet("Update", "BACCConsentPortal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdateConsentPortal API operation.", Operation = new[] {"UpdateConsentPortal"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalResponse object containing multiple properties."
    )]
    public partial class UpdateBACCConsentPortalCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdpConfig_Audience
        /// <summary>
        /// <para>
        /// <para>The audience value that the consent portal includes when requesting tokens from the
        /// identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpConfig_Audience { get; set; }
        #endregion
        
        #region Parameter ConsentPortalIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the consent portal. You can specify either the consent portal ID
        /// or its Amazon Resource Name (ARN).</para>
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
        public System.String ConsentPortalIdentifier { get; set; }
        #endregion
        
        #region Parameter IdpConfig_CredentialProviderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the OAuth2 credential provider used to authenticate
        /// end users to the consent portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpConfig_CredentialProviderArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the consent portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the consent portal assumes to
        /// access the resources defined in its sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter IdpConfig_Scope
        /// <summary>
        /// <para>
        /// <para>The OAuth2 scopes that the consent portal requests when authenticating end users.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdpConfig_Scopes")]
        public System.String[] IdpConfig_Scope { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConsentPortalIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCConsentPortal (UpdateConsentPortal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalResponse, UpdateBACCConsentPortalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConsentPortalIdentifier = this.ConsentPortalIdentifier;
            #if MODULAR
            if (this.ConsentPortalIdentifier == null && ParameterWasBound(nameof(this.ConsentPortalIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConsentPortalIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.IdpConfig_Audience = this.IdpConfig_Audience;
            context.IdpConfig_CredentialProviderArn = this.IdpConfig_CredentialProviderArn;
            if (this.IdpConfig_Scope != null)
            {
                context.IdpConfig_Scope = new List<System.String>(this.IdpConfig_Scope);
            }
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalRequest();
            
            if (cmdletContext.ConsentPortalIdentifier != null)
            {
                request.ConsentPortalIdentifier = cmdletContext.ConsentPortalIdentifier;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate IdpConfig
            var requestIdpConfigIsNull = true;
            request.IdpConfig = new Amazon.BedrockAgentCoreControl.Model.ConsentPortalIdpConfig();
            System.String requestIdpConfig_idpConfig_Audience = null;
            if (cmdletContext.IdpConfig_Audience != null)
            {
                requestIdpConfig_idpConfig_Audience = cmdletContext.IdpConfig_Audience;
            }
            if (requestIdpConfig_idpConfig_Audience != null)
            {
                request.IdpConfig.Audience = requestIdpConfig_idpConfig_Audience;
                requestIdpConfigIsNull = false;
            }
            System.String requestIdpConfig_idpConfig_CredentialProviderArn = null;
            if (cmdletContext.IdpConfig_CredentialProviderArn != null)
            {
                requestIdpConfig_idpConfig_CredentialProviderArn = cmdletContext.IdpConfig_CredentialProviderArn;
            }
            if (requestIdpConfig_idpConfig_CredentialProviderArn != null)
            {
                request.IdpConfig.CredentialProviderArn = requestIdpConfig_idpConfig_CredentialProviderArn;
                requestIdpConfigIsNull = false;
            }
            List<System.String> requestIdpConfig_idpConfig_Scope = null;
            if (cmdletContext.IdpConfig_Scope != null)
            {
                requestIdpConfig_idpConfig_Scope = cmdletContext.IdpConfig_Scope;
            }
            if (requestIdpConfig_idpConfig_Scope != null)
            {
                request.IdpConfig.Scopes = requestIdpConfig_idpConfig_Scope;
                requestIdpConfigIsNull = false;
            }
             // determine if request.IdpConfig should be set to null
            if (requestIdpConfigIsNull)
            {
                request.IdpConfig = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdateConsentPortal");
            try
            {
                return client.UpdateConsentPortalAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConsentPortalIdentifier { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String IdpConfig_Audience { get; set; }
            public System.String IdpConfig_CredentialProviderArn { get; set; }
            public List<System.String> IdpConfig_Scope { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateConsentPortalResponse, UpdateBACCConsentPortalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
