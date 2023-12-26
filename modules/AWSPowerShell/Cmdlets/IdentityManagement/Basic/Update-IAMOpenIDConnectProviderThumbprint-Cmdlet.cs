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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Replaces the existing list of server certificate thumbprints associated with an OpenID
    /// Connect (OIDC) provider resource object with a new list of thumbprints.
    /// 
    ///  
    /// <para>
    /// The list that you pass with this operation completely replaces the existing list of
    /// thumbprints. (The lists are not merged.)
    /// </para><para>
    /// Typically, you need to update a thumbprint only when the identity provider certificate
    /// changes, which occurs rarely. However, if the provider's certificate <i>does</i> change,
    /// any attempt to assume an IAM role that specifies the OIDC provider as a principal
    /// fails until the certificate thumbprint is updated.
    /// </para><note><para>
    /// Amazon Web Services secures communication with some OIDC identity providers (IdPs)
    /// through our library of trusted root certificate authorities (CAs) instead of using
    /// a certificate thumbprint to verify your IdP server certificate. In these cases, your
    /// legacy thumbprint remains in your configuration, but is no longer used for validation.
    /// These OIDC IdPs include Auth0, GitHub, GitLab, Google, and those that use an Amazon
    /// S3 bucket to host a JSON Web Key Set (JWKS) endpoint.
    /// </para></note><note><para>
    /// Trust for the OIDC provider is derived from the provider certificate and is validated
    /// by the thumbprint. Therefore, it is best to limit access to the <code>UpdateOpenIDConnectProviderThumbprint</code>
    /// operation to highly privileged users.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "IAMOpenIDConnectProviderThumbprint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management UpdateOpenIDConnectProviderThumbprint API operation.", Operation = new[] {"UpdateOpenIDConnectProviderThumbprint"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderThumbprintResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderThumbprintResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderThumbprintResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIAMOpenIDConnectProviderThumbprintCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OpenIDConnectProviderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM OIDC provider resource object for which
        /// you want to update the thumbprint. You can get a list of OIDC provider ARNs by using
        /// the <a>ListOpenIDConnectProviders</a> operation.</para><para>For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>.</para>
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
        public System.String OpenIDConnectProviderArn { get; set; }
        #endregion
        
        #region Parameter ThumbprintList
        /// <summary>
        /// <para>
        /// <para>A list of certificate thumbprints that are associated with the specified IAM OpenID
        /// Connect provider. For more information, see <a>CreateOpenIDConnectProvider</a>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] ThumbprintList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderThumbprintResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OpenIDConnectProviderArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OpenIDConnectProviderArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OpenIDConnectProviderArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OpenIDConnectProviderArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMOpenIDConnectProviderThumbprint (UpdateOpenIDConnectProviderThumbprint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderThumbprintResponse, UpdateIAMOpenIDConnectProviderThumbprintCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OpenIDConnectProviderArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.OpenIDConnectProviderArn = this.OpenIDConnectProviderArn;
            #if MODULAR
            if (this.OpenIDConnectProviderArn == null && ParameterWasBound(nameof(this.OpenIDConnectProviderArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OpenIDConnectProviderArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ThumbprintList != null)
            {
                context.ThumbprintList = new List<System.String>(this.ThumbprintList);
            }
            #if MODULAR
            if (this.ThumbprintList == null && ParameterWasBound(nameof(this.ThumbprintList)))
            {
                WriteWarning("You are passing $null as a value for parameter ThumbprintList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderThumbprintRequest();
            
            if (cmdletContext.OpenIDConnectProviderArn != null)
            {
                request.OpenIDConnectProviderArn = cmdletContext.OpenIDConnectProviderArn;
            }
            if (cmdletContext.ThumbprintList != null)
            {
                request.ThumbprintList = cmdletContext.ThumbprintList;
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
        
        private Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderThumbprintResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderThumbprintRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "UpdateOpenIDConnectProviderThumbprint");
            try
            {
                #if DESKTOP
                return client.UpdateOpenIDConnectProviderThumbprint(request);
                #elif CORECLR
                return client.UpdateOpenIDConnectProviderThumbprintAsync(request).GetAwaiter().GetResult();
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
            public System.String OpenIDConnectProviderArn { get; set; }
            public List<System.String> ThumbprintList { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderThumbprintResponse, UpdateIAMOpenIDConnectProviderThumbprintCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
