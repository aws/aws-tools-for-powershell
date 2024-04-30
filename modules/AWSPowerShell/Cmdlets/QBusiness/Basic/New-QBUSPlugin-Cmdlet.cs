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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Creates an Amazon Q Business plugin.
    /// </summary>
    [Cmdlet("New", "QBUSPlugin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QBusiness.Model.CreatePluginResponse")]
    [AWSCmdlet("Calls the Amazon QBusiness CreatePlugin API operation.", Operation = new[] {"CreatePlugin"}, SelectReturnType = typeof(Amazon.QBusiness.Model.CreatePluginResponse))]
    [AWSCmdletOutput("Amazon.QBusiness.Model.CreatePluginResponse",
        "This cmdlet returns an Amazon.QBusiness.Model.CreatePluginResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQBUSPluginCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomPluginConfiguration_ApiSchemaType
        /// <summary>
        /// <para>
        /// <para>The type of OpenAPI schema to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.APISchemaType")]
        public Amazon.QBusiness.APISchemaType CustomPluginConfiguration_ApiSchemaType { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the application that will contain the plugin.</para>
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
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket that contains the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomPluginConfiguration_ApiSchema_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter CustomPluginConfiguration_Description
        /// <summary>
        /// <para>
        /// <para>A description for your custom plugin configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPluginConfiguration_Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A the name for your plugin.</para>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter S3_Key
        /// <summary>
        /// <para>
        /// <para>The name of the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomPluginConfiguration_ApiSchema_S3_Key")]
        public System.String S3_Key { get; set; }
        #endregion
        
        #region Parameter AuthConfiguration_NoAuthConfiguration
        /// <summary>
        /// <para>
        /// <para>Information about invoking a custom plugin without any authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QBusiness.Model.NoAuthConfiguration AuthConfiguration_NoAuthConfiguration { get; set; }
        #endregion
        
        #region Parameter ApiSchema_Payload
        /// <summary>
        /// <para>
        /// <para>The JSON or YAML-formatted payload defining the OpenAPI schema for a custom plugin.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomPluginConfiguration_ApiSchema_Payload")]
        public System.String ApiSchema_Payload { get; set; }
        #endregion
        
        #region Parameter BasicAuthConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role used by Amazon Q Business to access the basic authentication
        /// credentials stored in a Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfiguration_BasicAuthConfiguration_RoleArn")]
        public System.String BasicAuthConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter OAuth2ClientCredentialConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role used by Amazon Q Business to access the OAuth 2.0 authentication
        /// credentials stored in a Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfiguration_OAuth2ClientCredentialConfiguration_RoleArn")]
        public System.String OAuth2ClientCredentialConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter BasicAuthConfiguration_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret that stores the basic authentication credentials
        /// used for plugin configuration..</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfiguration_BasicAuthConfiguration_SecretArn")]
        public System.String BasicAuthConfiguration_SecretArn { get; set; }
        #endregion
        
        #region Parameter OAuth2ClientCredentialConfiguration_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret that stores the OAuth 2.0 credentials/token
        /// used for plugin configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfiguration_OAuth2ClientCredentialConfiguration_SecretArn")]
        public System.String OAuth2ClientCredentialConfiguration_SecretArn { get; set; }
        #endregion
        
        #region Parameter ServerUrl
        /// <summary>
        /// <para>
        /// <para>The source URL used for plugin configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerUrl { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that identify or categorize the data source connector. You
        /// can also use tags to help control access to the data source connector. Tag keys and
        /// values can consist of Unicode letters, digits, white space, and any of the following
        /// symbols: _ . : / = + - @.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QBusiness.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of plugin you want to create.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QBusiness.PluginType")]
        public Amazon.QBusiness.PluginType Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that you provide to identify the request to create your Amazon Q Business
        /// plugin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.CreatePluginResponse).
        /// Specifying the name of a property of type Amazon.QBusiness.Model.CreatePluginResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QBUSPlugin (CreatePlugin)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.CreatePluginResponse, NewQBUSPluginCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BasicAuthConfiguration_RoleArn = this.BasicAuthConfiguration_RoleArn;
            context.BasicAuthConfiguration_SecretArn = this.BasicAuthConfiguration_SecretArn;
            context.AuthConfiguration_NoAuthConfiguration = this.AuthConfiguration_NoAuthConfiguration;
            context.OAuth2ClientCredentialConfiguration_RoleArn = this.OAuth2ClientCredentialConfiguration_RoleArn;
            context.OAuth2ClientCredentialConfiguration_SecretArn = this.OAuth2ClientCredentialConfiguration_SecretArn;
            context.ClientToken = this.ClientToken;
            context.ApiSchema_Payload = this.ApiSchema_Payload;
            context.S3_Bucket = this.S3_Bucket;
            context.S3_Key = this.S3_Key;
            context.CustomPluginConfiguration_ApiSchemaType = this.CustomPluginConfiguration_ApiSchemaType;
            context.CustomPluginConfiguration_Description = this.CustomPluginConfiguration_Description;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerUrl = this.ServerUrl;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QBusiness.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QBusiness.Model.CreatePluginRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate AuthConfiguration
            var requestAuthConfigurationIsNull = true;
            request.AuthConfiguration = new Amazon.QBusiness.Model.PluginAuthConfiguration();
            Amazon.QBusiness.Model.NoAuthConfiguration requestAuthConfiguration_authConfiguration_NoAuthConfiguration = null;
            if (cmdletContext.AuthConfiguration_NoAuthConfiguration != null)
            {
                requestAuthConfiguration_authConfiguration_NoAuthConfiguration = cmdletContext.AuthConfiguration_NoAuthConfiguration;
            }
            if (requestAuthConfiguration_authConfiguration_NoAuthConfiguration != null)
            {
                request.AuthConfiguration.NoAuthConfiguration = requestAuthConfiguration_authConfiguration_NoAuthConfiguration;
                requestAuthConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.BasicAuthConfiguration requestAuthConfiguration_authConfiguration_BasicAuthConfiguration = null;
            
             // populate BasicAuthConfiguration
            var requestAuthConfiguration_authConfiguration_BasicAuthConfigurationIsNull = true;
            requestAuthConfiguration_authConfiguration_BasicAuthConfiguration = new Amazon.QBusiness.Model.BasicAuthConfiguration();
            System.String requestAuthConfiguration_authConfiguration_BasicAuthConfiguration_basicAuthConfiguration_RoleArn = null;
            if (cmdletContext.BasicAuthConfiguration_RoleArn != null)
            {
                requestAuthConfiguration_authConfiguration_BasicAuthConfiguration_basicAuthConfiguration_RoleArn = cmdletContext.BasicAuthConfiguration_RoleArn;
            }
            if (requestAuthConfiguration_authConfiguration_BasicAuthConfiguration_basicAuthConfiguration_RoleArn != null)
            {
                requestAuthConfiguration_authConfiguration_BasicAuthConfiguration.RoleArn = requestAuthConfiguration_authConfiguration_BasicAuthConfiguration_basicAuthConfiguration_RoleArn;
                requestAuthConfiguration_authConfiguration_BasicAuthConfigurationIsNull = false;
            }
            System.String requestAuthConfiguration_authConfiguration_BasicAuthConfiguration_basicAuthConfiguration_SecretArn = null;
            if (cmdletContext.BasicAuthConfiguration_SecretArn != null)
            {
                requestAuthConfiguration_authConfiguration_BasicAuthConfiguration_basicAuthConfiguration_SecretArn = cmdletContext.BasicAuthConfiguration_SecretArn;
            }
            if (requestAuthConfiguration_authConfiguration_BasicAuthConfiguration_basicAuthConfiguration_SecretArn != null)
            {
                requestAuthConfiguration_authConfiguration_BasicAuthConfiguration.SecretArn = requestAuthConfiguration_authConfiguration_BasicAuthConfiguration_basicAuthConfiguration_SecretArn;
                requestAuthConfiguration_authConfiguration_BasicAuthConfigurationIsNull = false;
            }
             // determine if requestAuthConfiguration_authConfiguration_BasicAuthConfiguration should be set to null
            if (requestAuthConfiguration_authConfiguration_BasicAuthConfigurationIsNull)
            {
                requestAuthConfiguration_authConfiguration_BasicAuthConfiguration = null;
            }
            if (requestAuthConfiguration_authConfiguration_BasicAuthConfiguration != null)
            {
                request.AuthConfiguration.BasicAuthConfiguration = requestAuthConfiguration_authConfiguration_BasicAuthConfiguration;
                requestAuthConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.OAuth2ClientCredentialConfiguration requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration = null;
            
             // populate OAuth2ClientCredentialConfiguration
            var requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfigurationIsNull = true;
            requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration = new Amazon.QBusiness.Model.OAuth2ClientCredentialConfiguration();
            System.String requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration_oAuth2ClientCredentialConfiguration_RoleArn = null;
            if (cmdletContext.OAuth2ClientCredentialConfiguration_RoleArn != null)
            {
                requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration_oAuth2ClientCredentialConfiguration_RoleArn = cmdletContext.OAuth2ClientCredentialConfiguration_RoleArn;
            }
            if (requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration_oAuth2ClientCredentialConfiguration_RoleArn != null)
            {
                requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration.RoleArn = requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration_oAuth2ClientCredentialConfiguration_RoleArn;
                requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfigurationIsNull = false;
            }
            System.String requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration_oAuth2ClientCredentialConfiguration_SecretArn = null;
            if (cmdletContext.OAuth2ClientCredentialConfiguration_SecretArn != null)
            {
                requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration_oAuth2ClientCredentialConfiguration_SecretArn = cmdletContext.OAuth2ClientCredentialConfiguration_SecretArn;
            }
            if (requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration_oAuth2ClientCredentialConfiguration_SecretArn != null)
            {
                requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration.SecretArn = requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration_oAuth2ClientCredentialConfiguration_SecretArn;
                requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfigurationIsNull = false;
            }
             // determine if requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration should be set to null
            if (requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfigurationIsNull)
            {
                requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration = null;
            }
            if (requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration != null)
            {
                request.AuthConfiguration.OAuth2ClientCredentialConfiguration = requestAuthConfiguration_authConfiguration_OAuth2ClientCredentialConfiguration;
                requestAuthConfigurationIsNull = false;
            }
             // determine if request.AuthConfiguration should be set to null
            if (requestAuthConfigurationIsNull)
            {
                request.AuthConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CustomPluginConfiguration
            var requestCustomPluginConfigurationIsNull = true;
            request.CustomPluginConfiguration = new Amazon.QBusiness.Model.CustomPluginConfiguration();
            Amazon.QBusiness.APISchemaType requestCustomPluginConfiguration_customPluginConfiguration_ApiSchemaType = null;
            if (cmdletContext.CustomPluginConfiguration_ApiSchemaType != null)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchemaType = cmdletContext.CustomPluginConfiguration_ApiSchemaType;
            }
            if (requestCustomPluginConfiguration_customPluginConfiguration_ApiSchemaType != null)
            {
                request.CustomPluginConfiguration.ApiSchemaType = requestCustomPluginConfiguration_customPluginConfiguration_ApiSchemaType;
                requestCustomPluginConfigurationIsNull = false;
            }
            System.String requestCustomPluginConfiguration_customPluginConfiguration_Description = null;
            if (cmdletContext.CustomPluginConfiguration_Description != null)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_Description = cmdletContext.CustomPluginConfiguration_Description;
            }
            if (requestCustomPluginConfiguration_customPluginConfiguration_Description != null)
            {
                request.CustomPluginConfiguration.Description = requestCustomPluginConfiguration_customPluginConfiguration_Description;
                requestCustomPluginConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.APISchema requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema = null;
            
             // populate ApiSchema
            var requestCustomPluginConfiguration_customPluginConfiguration_ApiSchemaIsNull = true;
            requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema = new Amazon.QBusiness.Model.APISchema();
            System.String requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_apiSchema_Payload = null;
            if (cmdletContext.ApiSchema_Payload != null)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_apiSchema_Payload = cmdletContext.ApiSchema_Payload;
            }
            if (requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_apiSchema_Payload != null)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema.Payload = requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_apiSchema_Payload;
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchemaIsNull = false;
            }
            Amazon.QBusiness.Model.S3 requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3 = null;
            
             // populate S3
            var requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3IsNull = true;
            requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3 = new Amazon.QBusiness.Model.S3();
            System.String requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3_s3_Bucket != null)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3.Bucket = requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3_s3_Bucket;
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3IsNull = false;
            }
            System.String requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3_s3_Key = null;
            if (cmdletContext.S3_Key != null)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3_s3_Key = cmdletContext.S3_Key;
            }
            if (requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3_s3_Key != null)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3.Key = requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3_s3_Key;
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3IsNull = false;
            }
             // determine if requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3 should be set to null
            if (requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3IsNull)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3 = null;
            }
            if (requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3 != null)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema.S3 = requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema_customPluginConfiguration_ApiSchema_S3;
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchemaIsNull = false;
            }
             // determine if requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema should be set to null
            if (requestCustomPluginConfiguration_customPluginConfiguration_ApiSchemaIsNull)
            {
                requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema = null;
            }
            if (requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema != null)
            {
                request.CustomPluginConfiguration.ApiSchema = requestCustomPluginConfiguration_customPluginConfiguration_ApiSchema;
                requestCustomPluginConfigurationIsNull = false;
            }
             // determine if request.CustomPluginConfiguration should be set to null
            if (requestCustomPluginConfigurationIsNull)
            {
                request.CustomPluginConfiguration = null;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.ServerUrl != null)
            {
                request.ServerUrl = cmdletContext.ServerUrl;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.QBusiness.Model.CreatePluginResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.CreatePluginRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "CreatePlugin");
            try
            {
                #if DESKTOP
                return client.CreatePlugin(request);
                #elif CORECLR
                return client.CreatePluginAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String BasicAuthConfiguration_RoleArn { get; set; }
            public System.String BasicAuthConfiguration_SecretArn { get; set; }
            public Amazon.QBusiness.Model.NoAuthConfiguration AuthConfiguration_NoAuthConfiguration { get; set; }
            public System.String OAuth2ClientCredentialConfiguration_RoleArn { get; set; }
            public System.String OAuth2ClientCredentialConfiguration_SecretArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ApiSchema_Payload { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.String S3_Key { get; set; }
            public Amazon.QBusiness.APISchemaType CustomPluginConfiguration_ApiSchemaType { get; set; }
            public System.String CustomPluginConfiguration_Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String ServerUrl { get; set; }
            public List<Amazon.QBusiness.Model.Tag> Tag { get; set; }
            public Amazon.QBusiness.PluginType Type { get; set; }
            public System.Func<Amazon.QBusiness.Model.CreatePluginResponse, NewQBUSPluginCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
