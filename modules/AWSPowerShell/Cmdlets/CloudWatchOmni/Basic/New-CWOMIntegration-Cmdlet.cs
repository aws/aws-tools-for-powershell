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
using Amazon.CloudWatchOmni;
using Amazon.CloudWatchOmni.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOM
{
    /// <summary>
    /// Creates an integration with a third-party provider. Returns the integration identifier
    /// and its initial status; when the provider requires interactive consent, an authorization
    /// URL is returned for the user to complete setup.
    /// </summary>
    [Cmdlet("New", "CWOMIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchOmni.Model.Integration")]
    [AWSCmdlet("Calls the CloudWatch Omni CreateIntegration API operation.", Operation = new[] {"CreateIntegration"}, SelectReturnType = typeof(Amazon.CloudWatchOmni.Model.CreateIntegrationResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchOmni.Model.Integration or Amazon.CloudWatchOmni.Model.CreateIntegrationResponse",
        "This cmdlet returns an Amazon.CloudWatchOmni.Model.Integration object.",
        "The service call response (type Amazon.CloudWatchOmni.Model.CreateIntegrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWOMIntegrationCmdlet : AmazonCloudWatchOmniClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Credential_ApiKeyCredential_ApiKeyValue
        /// <summary>
        /// <para>
        /// <para>The API key value used to authenticate with the external system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credential_ApiKeyCredential_ApiKeyValue { get; set; }
        #endregion
        
        #region Parameter Credential_OauthCodeCredential_AuthCode
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 authorization code returned by the external system's authorization endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credential_OauthCodeCredential_AuthCode { get; set; }
        #endregion
        
        #region Parameter Credential_OauthClientCredential_ClientId
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 client identifier registered with the external system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credential_OauthClientCredential_ClientId { get; set; }
        #endregion
        
        #region Parameter Credential_OauthClientCredential_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 client secret that pairs with the client identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credential_OauthClientCredential_ClientSecret { get; set; }
        #endregion
        
        #region Parameter IntegrationAttribute
        /// <summary>
        /// <para>
        /// <para>Provider-specific attributes to associate with the integration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationAttributes")]
        public System.Collections.Hashtable IntegrationAttribute { get; set; }
        #endregion
        
        #region Parameter IntegrationType
        /// <summary>
        /// <para>
        /// <para>The type of third-party provider to integrate with.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.IntegrationType")]
        public Amazon.CloudWatchOmni.IntegrationType IntegrationType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the new integration; unique within the account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Credential_OauthClientCredential_ProviderId
        /// <summary>
        /// <para>
        /// <para>The identifier of the OAuth provider that issued the client credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credential_OauthClientCredential_ProviderId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of the IAM role assumed to access the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to apply to the integration at creation time (Tagris tag-on-create).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token for safe retries. Retrying with the same token returns the original
        /// integration instead of creating a duplicate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Integration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchOmni.Model.CreateIntegrationResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchOmni.Model.CreateIntegrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Integration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWOMIntegration (CreateIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchOmni.Model.CreateIntegrationResponse, NewCWOMIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Credential_ApiKeyCredential_ApiKeyValue = this.Credential_ApiKeyCredential_ApiKeyValue;
            context.Credential_OauthClientCredential_ClientId = this.Credential_OauthClientCredential_ClientId;
            context.Credential_OauthClientCredential_ClientSecret = this.Credential_OauthClientCredential_ClientSecret;
            context.Credential_OauthClientCredential_ProviderId = this.Credential_OauthClientCredential_ProviderId;
            context.Credential_OauthCodeCredential_AuthCode = this.Credential_OauthCodeCredential_AuthCode;
            if (this.IntegrationAttribute != null)
            {
                context.IntegrationAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.IntegrationAttribute.Keys)
                {
                    context.IntegrationAttribute.Add((String)hashKey, (System.String)(this.IntegrationAttribute[hashKey]));
                }
            }
            context.IntegrationType = this.IntegrationType;
            #if MODULAR
            if (this.IntegrationType == null && ParameterWasBound(nameof(this.IntegrationType)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.CloudWatchOmni.Model.CreateIntegrationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Credential
            var requestCredentialIsNull = true;
            request.Credential = new Amazon.CloudWatchOmni.Model.IntegrationCredential();
            Amazon.CloudWatchOmni.Model.ApiKeyCredential requestCredential_credential_ApiKeyCredential = null;
            
             // populate ApiKeyCredential
            var requestCredential_credential_ApiKeyCredentialIsNull = true;
            requestCredential_credential_ApiKeyCredential = new Amazon.CloudWatchOmni.Model.ApiKeyCredential();
            System.String requestCredential_credential_ApiKeyCredential_credential_ApiKeyCredential_ApiKeyValue = null;
            if (cmdletContext.Credential_ApiKeyCredential_ApiKeyValue != null)
            {
                requestCredential_credential_ApiKeyCredential_credential_ApiKeyCredential_ApiKeyValue = cmdletContext.Credential_ApiKeyCredential_ApiKeyValue;
            }
            if (requestCredential_credential_ApiKeyCredential_credential_ApiKeyCredential_ApiKeyValue != null)
            {
                requestCredential_credential_ApiKeyCredential.ApiKeyValue = requestCredential_credential_ApiKeyCredential_credential_ApiKeyCredential_ApiKeyValue;
                requestCredential_credential_ApiKeyCredentialIsNull = false;
            }
             // determine if requestCredential_credential_ApiKeyCredential should be set to null
            if (requestCredential_credential_ApiKeyCredentialIsNull)
            {
                requestCredential_credential_ApiKeyCredential = null;
            }
            if (requestCredential_credential_ApiKeyCredential != null)
            {
                request.Credential.ApiKeyCredential = requestCredential_credential_ApiKeyCredential;
                requestCredentialIsNull = false;
            }
            Amazon.CloudWatchOmni.Model.OAuthCodeCredential requestCredential_credential_OauthCodeCredential = null;
            
             // populate OauthCodeCredential
            var requestCredential_credential_OauthCodeCredentialIsNull = true;
            requestCredential_credential_OauthCodeCredential = new Amazon.CloudWatchOmni.Model.OAuthCodeCredential();
            System.String requestCredential_credential_OauthCodeCredential_credential_OauthCodeCredential_AuthCode = null;
            if (cmdletContext.Credential_OauthCodeCredential_AuthCode != null)
            {
                requestCredential_credential_OauthCodeCredential_credential_OauthCodeCredential_AuthCode = cmdletContext.Credential_OauthCodeCredential_AuthCode;
            }
            if (requestCredential_credential_OauthCodeCredential_credential_OauthCodeCredential_AuthCode != null)
            {
                requestCredential_credential_OauthCodeCredential.AuthCode = requestCredential_credential_OauthCodeCredential_credential_OauthCodeCredential_AuthCode;
                requestCredential_credential_OauthCodeCredentialIsNull = false;
            }
             // determine if requestCredential_credential_OauthCodeCredential should be set to null
            if (requestCredential_credential_OauthCodeCredentialIsNull)
            {
                requestCredential_credential_OauthCodeCredential = null;
            }
            if (requestCredential_credential_OauthCodeCredential != null)
            {
                request.Credential.OauthCodeCredential = requestCredential_credential_OauthCodeCredential;
                requestCredentialIsNull = false;
            }
            Amazon.CloudWatchOmni.Model.OAuthClientCredential requestCredential_credential_OauthClientCredential = null;
            
             // populate OauthClientCredential
            var requestCredential_credential_OauthClientCredentialIsNull = true;
            requestCredential_credential_OauthClientCredential = new Amazon.CloudWatchOmni.Model.OAuthClientCredential();
            System.String requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ClientId = null;
            if (cmdletContext.Credential_OauthClientCredential_ClientId != null)
            {
                requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ClientId = cmdletContext.Credential_OauthClientCredential_ClientId;
            }
            if (requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ClientId != null)
            {
                requestCredential_credential_OauthClientCredential.ClientId = requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ClientId;
                requestCredential_credential_OauthClientCredentialIsNull = false;
            }
            System.String requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ClientSecret = null;
            if (cmdletContext.Credential_OauthClientCredential_ClientSecret != null)
            {
                requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ClientSecret = cmdletContext.Credential_OauthClientCredential_ClientSecret;
            }
            if (requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ClientSecret != null)
            {
                requestCredential_credential_OauthClientCredential.ClientSecret = requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ClientSecret;
                requestCredential_credential_OauthClientCredentialIsNull = false;
            }
            System.String requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ProviderId = null;
            if (cmdletContext.Credential_OauthClientCredential_ProviderId != null)
            {
                requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ProviderId = cmdletContext.Credential_OauthClientCredential_ProviderId;
            }
            if (requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ProviderId != null)
            {
                requestCredential_credential_OauthClientCredential.ProviderId = requestCredential_credential_OauthClientCredential_credential_OauthClientCredential_ProviderId;
                requestCredential_credential_OauthClientCredentialIsNull = false;
            }
             // determine if requestCredential_credential_OauthClientCredential should be set to null
            if (requestCredential_credential_OauthClientCredentialIsNull)
            {
                requestCredential_credential_OauthClientCredential = null;
            }
            if (requestCredential_credential_OauthClientCredential != null)
            {
                request.Credential.OauthClientCredential = requestCredential_credential_OauthClientCredential;
                requestCredentialIsNull = false;
            }
             // determine if request.Credential should be set to null
            if (requestCredentialIsNull)
            {
                request.Credential = null;
            }
            if (cmdletContext.IntegrationAttribute != null)
            {
                request.IntegrationAttributes = cmdletContext.IntegrationAttribute;
            }
            if (cmdletContext.IntegrationType != null)
            {
                request.IntegrationType = cmdletContext.IntegrationType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CloudWatchOmni.Model.CreateIntegrationResponse CallAWSServiceOperation(IAmazonCloudWatchOmni client, Amazon.CloudWatchOmni.Model.CreateIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Omni", "CreateIntegration");
            try
            {
                return client.CreateIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Credential_ApiKeyCredential_ApiKeyValue { get; set; }
            public System.String Credential_OauthClientCredential_ClientId { get; set; }
            public System.String Credential_OauthClientCredential_ClientSecret { get; set; }
            public System.String Credential_OauthClientCredential_ProviderId { get; set; }
            public System.String Credential_OauthCodeCredential_AuthCode { get; set; }
            public Dictionary<System.String, System.String> IntegrationAttribute { get; set; }
            public Amazon.CloudWatchOmni.IntegrationType IntegrationType { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CloudWatchOmni.Model.CreateIntegrationResponse, NewCWOMIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Integration;
        }
        
    }
}
