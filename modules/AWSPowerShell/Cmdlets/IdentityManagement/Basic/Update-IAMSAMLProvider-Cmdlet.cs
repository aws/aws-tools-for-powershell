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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Updates the metadata document, SAML encryption settings, and private keys for an existing
    /// SAML provider. To rotate private keys, add your new private key and then remove the
    /// old key in a separate request.
    /// </summary>
    [Cmdlet("Update", "IAMSAMLProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Identity and Access Management UpdateSAMLProvider API operation.", Operation = new[] {"UpdateSAMLProvider"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.UpdateSAMLProviderResponse))]
    [AWSCmdletOutput("System.String or Amazon.IdentityManagement.Model.UpdateSAMLProviderResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IdentityManagement.Model.UpdateSAMLProviderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIAMSAMLProviderCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddPrivateKey
        /// <summary>
        /// <para>
        /// <para>Specifies the new private key from your external identity provider. The private key
        /// must be a .pem file that uses AES-GCM or AES-CBC encryption algorithm to decrypt SAML
        /// assertions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AddPrivateKey { get; set; }
        #endregion
        
        #region Parameter AssertionEncryptionMode
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption setting for the SAML provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IdentityManagement.AssertionEncryptionModeType")]
        public Amazon.IdentityManagement.AssertionEncryptionModeType AssertionEncryptionMode { get; set; }
        #endregion
        
        #region Parameter RemovePrivateKey
        /// <summary>
        /// <para>
        /// <para>The Key ID of the private key to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemovePrivateKey { get; set; }
        #endregion
        
        #region Parameter SAMLMetadataDocument
        /// <summary>
        /// <para>
        /// <para>An XML document generated by an identity provider (IdP) that supports SAML 2.0. The
        /// document includes the issuer's name, expiration information, and keys that can be
        /// used to validate the SAML authentication response (assertions) that are received from
        /// the IdP. You must generate the metadata document using the identity management software
        /// that is used as your IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SAMLMetadataDocument { get; set; }
        #endregion
        
        #region Parameter SAMLProviderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the SAML provider to update.</para><para>For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
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
        public System.String SAMLProviderArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SAMLProviderArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.UpdateSAMLProviderResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.UpdateSAMLProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SAMLProviderArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SAMLProviderArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMSAMLProvider (UpdateSAMLProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.UpdateSAMLProviderResponse, UpdateIAMSAMLProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AddPrivateKey = this.AddPrivateKey;
            context.AssertionEncryptionMode = this.AssertionEncryptionMode;
            context.RemovePrivateKey = this.RemovePrivateKey;
            context.SAMLMetadataDocument = this.SAMLMetadataDocument;
            context.SAMLProviderArn = this.SAMLProviderArn;
            #if MODULAR
            if (this.SAMLProviderArn == null && ParameterWasBound(nameof(this.SAMLProviderArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SAMLProviderArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.UpdateSAMLProviderRequest();
            
            if (cmdletContext.AddPrivateKey != null)
            {
                request.AddPrivateKey = cmdletContext.AddPrivateKey;
            }
            if (cmdletContext.AssertionEncryptionMode != null)
            {
                request.AssertionEncryptionMode = cmdletContext.AssertionEncryptionMode;
            }
            if (cmdletContext.RemovePrivateKey != null)
            {
                request.RemovePrivateKey = cmdletContext.RemovePrivateKey;
            }
            if (cmdletContext.SAMLMetadataDocument != null)
            {
                request.SAMLMetadataDocument = cmdletContext.SAMLMetadataDocument;
            }
            if (cmdletContext.SAMLProviderArn != null)
            {
                request.SAMLProviderArn = cmdletContext.SAMLProviderArn;
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
        
        private Amazon.IdentityManagement.Model.UpdateSAMLProviderResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.UpdateSAMLProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "UpdateSAMLProvider");
            try
            {
                return client.UpdateSAMLProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AddPrivateKey { get; set; }
            public Amazon.IdentityManagement.AssertionEncryptionModeType AssertionEncryptionMode { get; set; }
            public System.String RemovePrivateKey { get; set; }
            public System.String SAMLMetadataDocument { get; set; }
            public System.String SAMLProviderArn { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.UpdateSAMLProviderResponse, UpdateIAMSAMLProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SAMLProviderArn;
        }
        
    }
}
