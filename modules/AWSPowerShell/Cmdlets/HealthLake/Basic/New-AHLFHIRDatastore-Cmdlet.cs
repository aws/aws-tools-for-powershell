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
using Amazon.HealthLake;
using Amazon.HealthLake.Model;

namespace Amazon.PowerShell.Cmdlets.AHL
{
    /// <summary>
    /// Create a FHIR-enabled data store.
    /// </summary>
    [Cmdlet("New", "AHLFHIRDatastore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.HealthLake.Model.CreateFHIRDatastoreResponse")]
    [AWSCmdlet("Calls the Amazon HealthLake CreateFHIRDatastore API operation.", Operation = new[] {"CreateFHIRDatastore"}, SelectReturnType = typeof(Amazon.HealthLake.Model.CreateFHIRDatastoreResponse))]
    [AWSCmdletOutput("Amazon.HealthLake.Model.CreateFHIRDatastoreResponse",
        "This cmdlet returns an Amazon.HealthLake.Model.CreateFHIRDatastoreResponse object containing multiple properties."
    )]
    public partial class NewAHLFHIRDatastoreCmdlet : AmazonHealthLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdentityProviderConfiguration_AuthorizationStrategy
        /// <summary>
        /// <para>
        /// <para>The authorization strategy selected when the HealthLake data store is created.</para><note><para>HealthLake provides support for both SMART on FHIR V1 and V2 as described below.</para><ul><li><para><c>SMART_ON_FHIR_V1</c> – Support for only SMART on FHIR V1, which includes <c>read</c>
        /// (read/search) and <c>write</c> (create/update/delete) permissions.</para></li><li><para><c>SMART_ON_FHIR</c> – Support for both SMART on FHIR V1 and V2, which includes <c>create</c>,
        /// <c>read</c>, <c>update</c>, <c>delete</c>, and <c>search</c> permissions.</para></li><li><para><c>AWS_AUTH</c> – The default HealthLake authorization strategy; not affiliated with
        /// SMART on FHIR.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.HealthLake.AuthorizationStrategy")]
        public Amazon.HealthLake.AuthorizationStrategy IdentityProviderConfiguration_AuthorizationStrategy { get; set; }
        #endregion
        
        #region Parameter KmsEncryptionConfig_CmkType
        /// <summary>
        /// <para>
        /// <para>The type of customer-managed-key (CMK) used for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SseConfiguration_KmsEncryptionConfig_CmkType")]
        [AWSConstantClassSource("Amazon.HealthLake.CmkType")]
        public Amazon.HealthLake.CmkType KmsEncryptionConfig_CmkType { get; set; }
        #endregion
        
        #region Parameter DatastoreName
        /// <summary>
        /// <para>
        /// <para>The data store name (user-generated).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatastoreName { get; set; }
        #endregion
        
        #region Parameter DatastoreTypeVersion
        /// <summary>
        /// <para>
        /// <para>The FHIR release version supported by the data store. Current support is for version
        /// <c>R4</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.HealthLake.FHIRVersion")]
        public Amazon.HealthLake.FHIRVersion DatastoreTypeVersion { get; set; }
        #endregion
        
        #region Parameter IdentityProviderConfiguration_FineGrainedAuthorizationEnabled
        /// <summary>
        /// <para>
        /// <para>The parameter to enable SMART on FHIR fine-grained authorization for the data store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IdentityProviderConfiguration_FineGrainedAuthorizationEnabled { get; set; }
        #endregion
        
        #region Parameter IdentityProviderConfiguration_IdpLambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function to use to decode the access
        /// token created by the authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderConfiguration_IdpLambdaArn { get; set; }
        #endregion
        
        #region Parameter KmsEncryptionConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service (KMS) encryption key id/alias used to encrypt the data
        /// store contents at rest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SseConfiguration_KmsEncryptionConfig_KmsKeyId")]
        public System.String KmsEncryptionConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter IdentityProviderConfiguration_Metadata
        /// <summary>
        /// <para>
        /// <para>The JSON metadata elements to use in your identity provider configuration. Required
        /// elements are listed based on the launch specification of the SMART application. For
        /// more information on all possible elements, see <a href="https://build.fhir.org/ig/HL7/smart-app-launch/conformance.html#metadata">Metadata</a>
        /// in SMART's App Launch specification.</para><para><c>authorization_endpoint</c>: The URL to the OAuth2 authorization endpoint.</para><para><c>grant_types_supported</c>: An array of grant types that are supported at the token
        /// endpoint. You must provide at least one grant type option. Valid options are <c>authorization_code</c>
        /// and <c>client_credentials</c>.</para><para><c>token_endpoint</c>: The URL to the OAuth2 token endpoint.</para><para><c>capabilities</c>: An array of strings of the SMART capabilities that the authorization
        /// server supports.</para><para><c>code_challenge_methods_supported</c>: An array of strings of supported PKCE code
        /// challenge methods. You must include the <c>S256</c> method in the array of PKCE code
        /// challenge methods.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderConfiguration_Metadata { get; set; }
        #endregion
        
        #region Parameter PreloadDataConfig_PreloadDataType
        /// <summary>
        /// <para>
        /// <para>The type of preloaded data. Only Synthea preloaded data is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.HealthLake.PreloadDataType")]
        public Amazon.HealthLake.PreloadDataType PreloadDataConfig_PreloadDataType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The resource tags applied to a data store when it is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.HealthLake.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An optional user-provided token to ensure API idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.HealthLake.Model.CreateFHIRDatastoreResponse).
        /// Specifying the name of a property of type Amazon.HealthLake.Model.CreateFHIRDatastoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatastoreTypeVersion parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatastoreTypeVersion' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatastoreTypeVersion' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatastoreName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AHLFHIRDatastore (CreateFHIRDatastore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.HealthLake.Model.CreateFHIRDatastoreResponse, NewAHLFHIRDatastoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatastoreTypeVersion;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DatastoreName = this.DatastoreName;
            context.DatastoreTypeVersion = this.DatastoreTypeVersion;
            #if MODULAR
            if (this.DatastoreTypeVersion == null && ParameterWasBound(nameof(this.DatastoreTypeVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter DatastoreTypeVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityProviderConfiguration_AuthorizationStrategy = this.IdentityProviderConfiguration_AuthorizationStrategy;
            context.IdentityProviderConfiguration_FineGrainedAuthorizationEnabled = this.IdentityProviderConfiguration_FineGrainedAuthorizationEnabled;
            context.IdentityProviderConfiguration_IdpLambdaArn = this.IdentityProviderConfiguration_IdpLambdaArn;
            context.IdentityProviderConfiguration_Metadata = this.IdentityProviderConfiguration_Metadata;
            context.PreloadDataConfig_PreloadDataType = this.PreloadDataConfig_PreloadDataType;
            context.KmsEncryptionConfig_CmkType = this.KmsEncryptionConfig_CmkType;
            context.KmsEncryptionConfig_KmsKeyId = this.KmsEncryptionConfig_KmsKeyId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.HealthLake.Model.Tag>(this.Tag);
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
            var request = new Amazon.HealthLake.Model.CreateFHIRDatastoreRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatastoreName != null)
            {
                request.DatastoreName = cmdletContext.DatastoreName;
            }
            if (cmdletContext.DatastoreTypeVersion != null)
            {
                request.DatastoreTypeVersion = cmdletContext.DatastoreTypeVersion;
            }
            
             // populate IdentityProviderConfiguration
            var requestIdentityProviderConfigurationIsNull = true;
            request.IdentityProviderConfiguration = new Amazon.HealthLake.Model.IdentityProviderConfiguration();
            Amazon.HealthLake.AuthorizationStrategy requestIdentityProviderConfiguration_identityProviderConfiguration_AuthorizationStrategy = null;
            if (cmdletContext.IdentityProviderConfiguration_AuthorizationStrategy != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_AuthorizationStrategy = cmdletContext.IdentityProviderConfiguration_AuthorizationStrategy;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_AuthorizationStrategy != null)
            {
                request.IdentityProviderConfiguration.AuthorizationStrategy = requestIdentityProviderConfiguration_identityProviderConfiguration_AuthorizationStrategy;
                requestIdentityProviderConfigurationIsNull = false;
            }
            System.Boolean? requestIdentityProviderConfiguration_identityProviderConfiguration_FineGrainedAuthorizationEnabled = null;
            if (cmdletContext.IdentityProviderConfiguration_FineGrainedAuthorizationEnabled != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_FineGrainedAuthorizationEnabled = cmdletContext.IdentityProviderConfiguration_FineGrainedAuthorizationEnabled.Value;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_FineGrainedAuthorizationEnabled != null)
            {
                request.IdentityProviderConfiguration.FineGrainedAuthorizationEnabled = requestIdentityProviderConfiguration_identityProviderConfiguration_FineGrainedAuthorizationEnabled.Value;
                requestIdentityProviderConfigurationIsNull = false;
            }
            System.String requestIdentityProviderConfiguration_identityProviderConfiguration_IdpLambdaArn = null;
            if (cmdletContext.IdentityProviderConfiguration_IdpLambdaArn != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_IdpLambdaArn = cmdletContext.IdentityProviderConfiguration_IdpLambdaArn;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_IdpLambdaArn != null)
            {
                request.IdentityProviderConfiguration.IdpLambdaArn = requestIdentityProviderConfiguration_identityProviderConfiguration_IdpLambdaArn;
                requestIdentityProviderConfigurationIsNull = false;
            }
            System.String requestIdentityProviderConfiguration_identityProviderConfiguration_Metadata = null;
            if (cmdletContext.IdentityProviderConfiguration_Metadata != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_Metadata = cmdletContext.IdentityProviderConfiguration_Metadata;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_Metadata != null)
            {
                request.IdentityProviderConfiguration.Metadata = requestIdentityProviderConfiguration_identityProviderConfiguration_Metadata;
                requestIdentityProviderConfigurationIsNull = false;
            }
             // determine if request.IdentityProviderConfiguration should be set to null
            if (requestIdentityProviderConfigurationIsNull)
            {
                request.IdentityProviderConfiguration = null;
            }
            
             // populate PreloadDataConfig
            var requestPreloadDataConfigIsNull = true;
            request.PreloadDataConfig = new Amazon.HealthLake.Model.PreloadDataConfig();
            Amazon.HealthLake.PreloadDataType requestPreloadDataConfig_preloadDataConfig_PreloadDataType = null;
            if (cmdletContext.PreloadDataConfig_PreloadDataType != null)
            {
                requestPreloadDataConfig_preloadDataConfig_PreloadDataType = cmdletContext.PreloadDataConfig_PreloadDataType;
            }
            if (requestPreloadDataConfig_preloadDataConfig_PreloadDataType != null)
            {
                request.PreloadDataConfig.PreloadDataType = requestPreloadDataConfig_preloadDataConfig_PreloadDataType;
                requestPreloadDataConfigIsNull = false;
            }
             // determine if request.PreloadDataConfig should be set to null
            if (requestPreloadDataConfigIsNull)
            {
                request.PreloadDataConfig = null;
            }
            
             // populate SseConfiguration
            var requestSseConfigurationIsNull = true;
            request.SseConfiguration = new Amazon.HealthLake.Model.SseConfiguration();
            Amazon.HealthLake.Model.KmsEncryptionConfig requestSseConfiguration_sseConfiguration_KmsEncryptionConfig = null;
            
             // populate KmsEncryptionConfig
            var requestSseConfiguration_sseConfiguration_KmsEncryptionConfigIsNull = true;
            requestSseConfiguration_sseConfiguration_KmsEncryptionConfig = new Amazon.HealthLake.Model.KmsEncryptionConfig();
            Amazon.HealthLake.CmkType requestSseConfiguration_sseConfiguration_KmsEncryptionConfig_kmsEncryptionConfig_CmkType = null;
            if (cmdletContext.KmsEncryptionConfig_CmkType != null)
            {
                requestSseConfiguration_sseConfiguration_KmsEncryptionConfig_kmsEncryptionConfig_CmkType = cmdletContext.KmsEncryptionConfig_CmkType;
            }
            if (requestSseConfiguration_sseConfiguration_KmsEncryptionConfig_kmsEncryptionConfig_CmkType != null)
            {
                requestSseConfiguration_sseConfiguration_KmsEncryptionConfig.CmkType = requestSseConfiguration_sseConfiguration_KmsEncryptionConfig_kmsEncryptionConfig_CmkType;
                requestSseConfiguration_sseConfiguration_KmsEncryptionConfigIsNull = false;
            }
            System.String requestSseConfiguration_sseConfiguration_KmsEncryptionConfig_kmsEncryptionConfig_KmsKeyId = null;
            if (cmdletContext.KmsEncryptionConfig_KmsKeyId != null)
            {
                requestSseConfiguration_sseConfiguration_KmsEncryptionConfig_kmsEncryptionConfig_KmsKeyId = cmdletContext.KmsEncryptionConfig_KmsKeyId;
            }
            if (requestSseConfiguration_sseConfiguration_KmsEncryptionConfig_kmsEncryptionConfig_KmsKeyId != null)
            {
                requestSseConfiguration_sseConfiguration_KmsEncryptionConfig.KmsKeyId = requestSseConfiguration_sseConfiguration_KmsEncryptionConfig_kmsEncryptionConfig_KmsKeyId;
                requestSseConfiguration_sseConfiguration_KmsEncryptionConfigIsNull = false;
            }
             // determine if requestSseConfiguration_sseConfiguration_KmsEncryptionConfig should be set to null
            if (requestSseConfiguration_sseConfiguration_KmsEncryptionConfigIsNull)
            {
                requestSseConfiguration_sseConfiguration_KmsEncryptionConfig = null;
            }
            if (requestSseConfiguration_sseConfiguration_KmsEncryptionConfig != null)
            {
                request.SseConfiguration.KmsEncryptionConfig = requestSseConfiguration_sseConfiguration_KmsEncryptionConfig;
                requestSseConfigurationIsNull = false;
            }
             // determine if request.SseConfiguration should be set to null
            if (requestSseConfigurationIsNull)
            {
                request.SseConfiguration = null;
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
        
        private Amazon.HealthLake.Model.CreateFHIRDatastoreResponse CallAWSServiceOperation(IAmazonHealthLake client, Amazon.HealthLake.Model.CreateFHIRDatastoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon HealthLake", "CreateFHIRDatastore");
            try
            {
                #if DESKTOP
                return client.CreateFHIRDatastore(request);
                #elif CORECLR
                return client.CreateFHIRDatastoreAsync(request).GetAwaiter().GetResult();
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
            public System.String DatastoreName { get; set; }
            public Amazon.HealthLake.FHIRVersion DatastoreTypeVersion { get; set; }
            public Amazon.HealthLake.AuthorizationStrategy IdentityProviderConfiguration_AuthorizationStrategy { get; set; }
            public System.Boolean? IdentityProviderConfiguration_FineGrainedAuthorizationEnabled { get; set; }
            public System.String IdentityProviderConfiguration_IdpLambdaArn { get; set; }
            public System.String IdentityProviderConfiguration_Metadata { get; set; }
            public Amazon.HealthLake.PreloadDataType PreloadDataConfig_PreloadDataType { get; set; }
            public Amazon.HealthLake.CmkType KmsEncryptionConfig_CmkType { get; set; }
            public System.String KmsEncryptionConfig_KmsKeyId { get; set; }
            public List<Amazon.HealthLake.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.HealthLake.Model.CreateFHIRDatastoreResponse, NewAHLFHIRDatastoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
