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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// Creates a configuration profile, which is information that enables AppConfig to access
    /// the configuration source. Valid configuration sources include the following:
    /// 
    ///  <ul><li><para>
    /// Configuration data in YAML, JSON, and other formats stored in the AppConfig hosted
    /// configuration store
    /// </para></li><li><para>
    /// Configuration data stored as objects in an Amazon Simple Storage Service (Amazon S3)
    /// bucket
    /// </para></li><li><para>
    /// Pipelines stored in CodePipeline
    /// </para></li><li><para>
    /// Secrets stored in Secrets Manager
    /// </para></li><li><para>
    /// Standard and secure string parameters stored in Amazon Web Services Systems Manager
    /// Parameter Store
    /// </para></li><li><para>
    /// Configuration data in SSM documents stored in the Systems Manager document store
    /// </para></li></ul><para>
    /// A configuration profile includes the following information:
    /// </para><ul><li><para>
    /// The URI location of the configuration data.
    /// </para></li><li><para>
    /// The Identity and Access Management (IAM) role that provides access to the configuration
    /// data.
    /// </para></li><li><para>
    /// A validator for the configuration data. Available validators include either a JSON
    /// Schema or an Amazon Web Services Lambda function.
    /// </para></li></ul><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/appconfig/latest/userguide/appconfig-creating-configuration-and-profile.html">Create
    /// a Configuration and a Configuration Profile</a> in the <i>AppConfig User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "APPCConfigurationProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.CreateConfigurationProfileResponse")]
    [AWSCmdlet("Calls the AWS AppConfig CreateConfigurationProfile API operation.", Operation = new[] {"CreateConfigurationProfile"}, SelectReturnType = typeof(Amazon.AppConfig.Model.CreateConfigurationProfileResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.CreateConfigurationProfileResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.CreateConfigurationProfileResponse object containing multiple properties."
    )]
    public partial class NewAPPCConfigurationProfileCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The application ID.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the configuration profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for an Key Management Service key to encrypt new configuration data
        /// versions in the AppConfig hosted configuration store. This attribute is only used
        /// for <c>hosted</c> configuration types. The identifier can be an KMS key ID, alias,
        /// or the Amazon Resource Name (ARN) of the key ID or alias. To encrypt data managed
        /// in other configuration stores, see the documentation for how to specify an KMS key
        /// for that particular service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter LocationUri
        /// <summary>
        /// <para>
        /// <para>A URI to locate the configuration. You can specify the following:</para><ul><li><para>For the AppConfig hosted configuration store and for feature flags, specify <c>hosted</c>.</para></li><li><para>For an Amazon Web Services Systems Manager Parameter Store parameter, specify either
        /// the parameter name in the format <c>ssm-parameter://&lt;parameter name&gt;</c> or
        /// the ARN.</para></li><li><para>For an Amazon Web Services CodePipeline pipeline, specify the URI in the following
        /// format: <c>codepipeline</c>://&lt;pipeline name&gt;.</para></li><li><para>For an Secrets Manager secret, specify the URI in the following format: <c>secretsmanager</c>://&lt;secret
        /// name&gt;.</para></li><li><para>For an Amazon S3 object, specify the URI in the following format: <c>s3://&lt;bucket&gt;/&lt;objectKey&gt;
        /// </c>. Here is an example: <c>s3://my-bucket/my-app/us-east-1/my-config.json</c></para></li><li><para>For an SSM document, specify either the document name in the format <c>ssm-document://&lt;document
        /// name&gt;</c> or the Amazon Resource Name (ARN).</para></li></ul>
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
        public System.String LocationUri { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the configuration profile.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RetrievalRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role with permission to access the configuration at the specified
        /// <c>LocationUri</c>.</para><important><para>A retrieval role ARN is not required for configurations stored in the AppConfig hosted
        /// configuration store. It is required for all other sources that store your configuration.
        /// </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RetrievalRoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata to assign to the configuration profile. Tags help organize and categorize
        /// your AppConfig resources. Each tag consists of a key and an optional value, both of
        /// which you define.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of configurations contained in the profile. AppConfig supports <c>feature
        /// flags</c> and <c>freeform</c> configurations. We recommend you create feature flag
        /// configurations to enable or disable new features and freeform configurations to distribute
        /// configurations to an application. When calling this API, enter one of the following
        /// values for <c>Type</c>:</para><para><c>AWS.AppConfig.FeatureFlags</c></para><para><c>AWS.Freeform</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter Validator
        /// <summary>
        /// <para>
        /// <para>A list of methods for validating the configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Validators")]
        public Amazon.AppConfig.Model.Validator[] Validator { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.CreateConfigurationProfileResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.CreateConfigurationProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APPCConfigurationProfile (CreateConfigurationProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.CreateConfigurationProfileResponse, NewAPPCConfigurationProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            context.LocationUri = this.LocationUri;
            #if MODULAR
            if (this.LocationUri == null && ParameterWasBound(nameof(this.LocationUri)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetrievalRoleArn = this.RetrievalRoleArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            if (this.Validator != null)
            {
                context.Validator = new List<Amazon.AppConfig.Model.Validator>(this.Validator);
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
            var request = new Amazon.AppConfig.Model.CreateConfigurationProfileRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            if (cmdletContext.LocationUri != null)
            {
                request.LocationUri = cmdletContext.LocationUri;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RetrievalRoleArn != null)
            {
                request.RetrievalRoleArn = cmdletContext.RetrievalRoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.Validator != null)
            {
                request.Validators = cmdletContext.Validator;
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
        
        private Amazon.AppConfig.Model.CreateConfigurationProfileResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.CreateConfigurationProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "CreateConfigurationProfile");
            try
            {
                #if DESKTOP
                return client.CreateConfigurationProfile(request);
                #elif CORECLR
                return client.CreateConfigurationProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public System.String LocationUri { get; set; }
            public System.String Name { get; set; }
            public System.String RetrievalRoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Type { get; set; }
            public List<Amazon.AppConfig.Model.Validator> Validator { get; set; }
            public System.Func<Amazon.AppConfig.Model.CreateConfigurationProfileResponse, NewAPPCConfigurationProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
