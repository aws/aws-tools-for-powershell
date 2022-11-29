/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the configuration of the specified Amazon Web Services Verified Access trust
    /// provider.
    /// </summary>
    [Cmdlet("Edit", "EC2VerifiedAccessTrustProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VerifiedAccessTrustProvider")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVerifiedAccessTrustProvider API operation.", Operation = new[] {"ModifyVerifiedAccessTrustProvider"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VerifiedAccessTrustProvider or Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse",
        "This cmdlet returns an Amazon.EC2.Model.VerifiedAccessTrustProvider object.",
        "The service call response (type Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VerifiedAccessTrustProviderCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the Amazon Web Services Verified Access trust provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OidcOptions_Scope
        /// <summary>
        /// <para>
        /// <para>OpenID Connect (OIDC) scopes are used by an application during authentication to authorize
        /// access to a user's details. Each scope returns a specific set of user attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcOptions_Scope { get; set; }
        #endregion
        
        #region Parameter VerifiedAccessTrustProviderId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Verified Access trust provider.</para>
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
        public System.String VerifiedAccessTrustProviderId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure idempotency of your modification
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VerifiedAccessTrustProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VerifiedAccessTrustProvider";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VerifiedAccessTrustProviderId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VerifiedAccessTrustProviderId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VerifiedAccessTrustProviderId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VerifiedAccessTrustProviderId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VerifiedAccessTrustProvider (ModifyVerifiedAccessTrustProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse, EditEC2VerifiedAccessTrustProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VerifiedAccessTrustProviderId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.OidcOptions_Scope = this.OidcOptions_Scope;
            context.VerifiedAccessTrustProviderId = this.VerifiedAccessTrustProviderId;
            #if MODULAR
            if (this.VerifiedAccessTrustProviderId == null && ParameterWasBound(nameof(this.VerifiedAccessTrustProviderId)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifiedAccessTrustProviderId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate OidcOptions
            var requestOidcOptionsIsNull = true;
            request.OidcOptions = new Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderOidcOptions();
            System.String requestOidcOptions_oidcOptions_Scope = null;
            if (cmdletContext.OidcOptions_Scope != null)
            {
                requestOidcOptions_oidcOptions_Scope = cmdletContext.OidcOptions_Scope;
            }
            if (requestOidcOptions_oidcOptions_Scope != null)
            {
                request.OidcOptions.Scope = requestOidcOptions_oidcOptions_Scope;
                requestOidcOptionsIsNull = false;
            }
             // determine if request.OidcOptions should be set to null
            if (requestOidcOptionsIsNull)
            {
                request.OidcOptions = null;
            }
            if (cmdletContext.VerifiedAccessTrustProviderId != null)
            {
                request.VerifiedAccessTrustProviderId = cmdletContext.VerifiedAccessTrustProviderId;
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
        
        private Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVerifiedAccessTrustProvider");
            try
            {
                #if DESKTOP
                return client.ModifyVerifiedAccessTrustProvider(request);
                #elif CORECLR
                return client.ModifyVerifiedAccessTrustProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String OidcOptions_Scope { get; set; }
            public System.String VerifiedAccessTrustProviderId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse, EditEC2VerifiedAccessTrustProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VerifiedAccessTrustProvider;
        }
        
    }
}
