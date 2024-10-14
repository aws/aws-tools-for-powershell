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
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Creates a new secret. A <i>secret</i> can be a password, a set of credentials such
    /// as a user name and password, an OAuth token, or other secret information that you
    /// store in an encrypted form in Secrets Manager. The secret also includes the connection
    /// information to access a database or other service, which Secrets Manager doesn't encrypt.
    /// A secret in Secrets Manager consists of both the protected secret data and the important
    /// information needed to manage the secret.
    /// 
    ///  
    /// <para>
    /// For secrets that use <i>managed rotation</i>, you need to create the secret through
    /// the managing service. For more information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/service-linked-secrets.html">Secrets
    /// Manager secrets managed by other Amazon Web Services services</a>. 
    /// </para><para>
    /// For information about creating a secret in the console, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/manage_create-basic-secret.html">Create
    /// a secret</a>.
    /// </para><para>
    /// To create a secret, you can provide the secret value to be encrypted in either the
    /// <c>SecretString</c> parameter or the <c>SecretBinary</c> parameter, but not both.
    /// If you include <c>SecretString</c> or <c>SecretBinary</c> then Secrets Manager creates
    /// an initial secret version and automatically attaches the staging label <c>AWSCURRENT</c>
    /// to it.
    /// </para><para>
    /// For database credentials you want to rotate, for Secrets Manager to be able to rotate
    /// the secret, you must make sure the JSON you store in the <c>SecretString</c> matches
    /// the <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/reference_secret_json_structure.html">JSON
    /// structure of a database secret</a>.
    /// </para><para>
    /// If you don't specify an KMS encryption key, Secrets Manager uses the Amazon Web Services
    /// managed key <c>aws/secretsmanager</c>. If this key doesn't already exist in your account,
    /// then Secrets Manager creates it for you automatically. All users and roles in the
    /// Amazon Web Services account automatically have access to use <c>aws/secretsmanager</c>.
    /// Creating <c>aws/secretsmanager</c> can result in a one-time significant delay in returning
    /// the result.
    /// </para><para>
    /// If the secret is in a different Amazon Web Services account from the credentials calling
    /// the API, then you can't use <c>aws/secretsmanager</c> to encrypt the secret, and you
    /// must create and use a customer managed KMS key. 
    /// </para><para>
    /// Secrets Manager generates a CloudTrail log entry when you call this action. Do not
    /// include sensitive information in request parameters except <c>SecretBinary</c> or
    /// <c>SecretString</c> because it might be logged. For more information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/retrieve-ct-entries.html">Logging
    /// Secrets Manager events with CloudTrail</a>.
    /// </para><para><b>Required permissions: </b><c>secretsmanager:CreateSecret</c>. If you include
    /// tags in the secret, you also need <c>secretsmanager:TagResource</c>. To add replica
    /// Regions, you must also have <c>secretsmanager:ReplicateSecretToRegions</c>. For more
    /// information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/reference_iam-permissions.html#reference_iam-permissions_actions">
    /// IAM policy actions for Secrets Manager</a> and <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access.html">Authentication
    /// and access control in Secrets Manager</a>. 
    /// </para><para>
    /// To encrypt the secret with a KMS key other than <c>aws/secretsmanager</c>, you need
    /// <c>kms:GenerateDataKey</c> and <c>kms:Decrypt</c> permission to the key. 
    /// </para><important><para>
    /// When you enter commands in a command shell, there is a risk of the command history
    /// being accessed or utilities having access to your command parameters. This is a concern
    /// if the command includes the value of a secret. Learn how to <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/security_cli-exposure-risks.html">Mitigate
    /// the risks of using command-line tools to store Secrets Manager secrets</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "SECSecret", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.CreateSecretResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager CreateSecret API operation.", Operation = new[] {"CreateSecret"}, SelectReturnType = typeof(Amazon.SecretsManager.Model.CreateSecretResponse))]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.CreateSecretResponse",
        "This cmdlet returns an Amazon.SecretsManager.Model.CreateSecretResponse object containing multiple properties."
    )]
    public partial class NewSECSecretCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddReplicaRegion
        /// <summary>
        /// <para>
        /// <para>A list of Regions and KMS keys to replicate secrets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddReplicaRegions")]
        public Amazon.SecretsManager.Model.ReplicaRegionType[] AddReplicaRegion { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>If you include <c>SecretString</c> or <c>SecretBinary</c>, then Secrets Manager creates
        /// an initial version for the secret, and this parameter specifies the unique identifier
        /// for the new version. </para><note><para>If you use the Amazon Web Services CLI or one of the Amazon Web Services SDKs to call
        /// this operation, then you can leave this parameter empty. The CLI or SDK generates
        /// a random UUID for you and includes it as the value for this parameter in the request.
        /// </para></note><para>If you generate a raw HTTP request to the Secrets Manager service endpoint, then you
        /// must generate a <c>ClientRequestToken</c> and include it in the request.</para><para>This value helps ensure idempotency. Secrets Manager uses this value to prevent the
        /// accidental creation of duplicate versions if there are failures and retries during
        /// a rotation. We recommend that you generate a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type</a>
        /// value to ensure uniqueness of your versions within the specified secret. </para><ul><li><para>If the <c>ClientRequestToken</c> value isn't already associated with a version of
        /// the secret then a new version of the secret is created. </para></li><li><para>If a version with this value already exists and the version <c>SecretString</c> and
        /// <c>SecretBinary</c> values are the same as those in the request, then the request
        /// is ignored.</para></li><li><para>If a version with this value already exists and that version's <c>SecretString</c>
        /// and <c>SecretBinary</c> values are different from those in the request, then the request
        /// fails because you cannot modify an existing version. Instead, use <a>PutSecretValue</a>
        /// to create a new version.</para></li></ul><para>This value becomes the <c>VersionId</c> of the new version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ForceOverwriteReplicaSecret
        /// <summary>
        /// <para>
        /// <para>Specifies whether to overwrite a secret with the same name in the destination Region.
        /// By default, secrets aren't overwritten.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceOverwriteReplicaSecret { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ARN, key ID, or alias of the KMS key that Secrets Manager uses to encrypt the
        /// secret value in the secret. An alias is always prefixed by <c>alias/</c>, for example
        /// <c>alias/aws/secretsmanager</c>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/alias-about.html">About
        /// aliases</a>.</para><para>To use a KMS key in a different account, use the key ARN or the alias ARN.</para><para>If you don't specify this value, then Secrets Manager uses the key <c>aws/secretsmanager</c>.
        /// If that key doesn't yet exist, then Secrets Manager creates it for you automatically
        /// the first time it encrypts the secret value.</para><para>If the secret is in a different Amazon Web Services account from the credentials calling
        /// the API, then you can't use <c>aws/secretsmanager</c> to encrypt the secret, and you
        /// must create and use a customer managed KMS key. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new secret.</para><para>The secret name can contain ASCII letters, numbers, and the following characters:
        /// /_+=.@-</para><para>Do not end your secret name with a hyphen followed by six characters. If you do so,
        /// you risk confusion and unexpected results when searching for a secret by partial ARN.
        /// Secrets Manager automatically adds a hyphen and six random characters after the secret
        /// name at the end of the ARN.</para>
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
        
        #region Parameter SecretBinary
        /// <summary>
        /// <para>
        /// <para>The binary data to encrypt and store in the new version of the secret. We recommend
        /// that you store your binary data in a file and then pass the contents of the file as
        /// a parameter.</para><para>Either <c>SecretString</c> or <c>SecretBinary</c> must have a value, but not both.</para><para>This parameter is not available in the Secrets Manager console.</para><para>Sensitive: This field contains sensitive information, so the service does not include
        /// it in CloudTrail log entries. If you create your own log entries, you must also avoid
        /// logging the information in this field.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] SecretBinary { get; set; }
        #endregion
        
        #region Parameter SecretString
        /// <summary>
        /// <para>
        /// <para>The text data to encrypt and store in this new version of the secret. We recommend
        /// you use a JSON structure of key/value pairs for your secret value.</para><para>Either <c>SecretString</c> or <c>SecretBinary</c> must have a value, but not both.</para><para>If you create a secret by using the Secrets Manager console then Secrets Manager puts
        /// the protected secret text in only the <c>SecretString</c> parameter. The Secrets Manager
        /// console stores the information as a JSON structure of key/value pairs that a Lambda
        /// rotation function can parse.</para><para>Sensitive: This field contains sensitive information, so the service does not include
        /// it in CloudTrail log entries. If you create your own log entries, you must also avoid
        /// logging the information in this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SecretString { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to attach to the secret. Each tag is a key and value pair of strings
        /// in a JSON text string, for example:</para><para><c>[{"Key":"CostCenter","Value":"12345"},{"Key":"environment","Value":"production"}]</c></para><para>Secrets Manager tag key names are case sensitive. A tag with the key "ABC" is a different
        /// tag from one with key "abc".</para><para>If you check tags in permissions policies as part of your security strategy, then
        /// adding or removing a tag can change permissions. If the completion of this operation
        /// would result in you losing your permissions for this secret, then Secrets Manager
        /// blocks the operation and returns an <c>Access Denied</c> error. For more information,
        /// see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access_examples.html#tag-secrets-abac">Control
        /// access to secrets using tags</a> and <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access_examples.html#auth-and-access_tags2">Limit
        /// access to identities with tags that match secrets' tags</a>.</para><para>For information about how to format a JSON parameter for the various command line
        /// tool environments, see <a href="https://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#cli-using-param-json">Using
        /// JSON for Parameters</a>. If your command-line tool or SDK requires quotation marks
        /// around the parameter, you should use single quotes to avoid confusion with the double
        /// quotes required in the JSON text.</para><para>For tag quotas and naming restrictions, see <a href="https://docs.aws.amazon.com/general/latest/gr/arg.html#taged-reference-quotas">Service
        /// quotas for Tagging</a> in the <i>Amazon Web Services General Reference guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SecretsManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecretsManager.Model.CreateSecretResponse).
        /// Specifying the name of a property of type Amazon.SecretsManager.Model.CreateSecretResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SecretString parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SecretString' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SecretString' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SECSecret (CreateSecret)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecretsManager.Model.CreateSecretResponse, NewSECSecretCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SecretString;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddReplicaRegion != null)
            {
                context.AddReplicaRegion = new List<Amazon.SecretsManager.Model.ReplicaRegionType>(this.AddReplicaRegion);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            context.ForceOverwriteReplicaSecret = this.ForceOverwriteReplicaSecret;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecretBinary = this.SecretBinary;
            context.SecretString = this.SecretString;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SecretsManager.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _SecretBinaryStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SecretsManager.Model.CreateSecretRequest();
                
                if (cmdletContext.AddReplicaRegion != null)
                {
                    request.AddReplicaRegions = cmdletContext.AddReplicaRegion;
                }
                if (cmdletContext.ClientRequestToken != null)
                {
                    request.ClientRequestToken = cmdletContext.ClientRequestToken;
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                if (cmdletContext.ForceOverwriteReplicaSecret != null)
                {
                    request.ForceOverwriteReplicaSecret = cmdletContext.ForceOverwriteReplicaSecret.Value;
                }
                if (cmdletContext.KmsKeyId != null)
                {
                    request.KmsKeyId = cmdletContext.KmsKeyId;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.SecretBinary != null)
                {
                    _SecretBinaryStream = new System.IO.MemoryStream(cmdletContext.SecretBinary);
                    request.SecretBinary = _SecretBinaryStream;
                }
                if (cmdletContext.SecretString != null)
                {
                    request.SecretString = cmdletContext.SecretString;
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
            finally
            {
                if( _SecretBinaryStream != null)
                {
                    _SecretBinaryStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SecretsManager.Model.CreateSecretResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.CreateSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "CreateSecret");
            try
            {
                #if DESKTOP
                return client.CreateSecret(request);
                #elif CORECLR
                return client.CreateSecretAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecretsManager.Model.ReplicaRegionType> AddReplicaRegion { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? ForceOverwriteReplicaSecret { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public byte[] SecretBinary { get; set; }
            public System.String SecretString { get; set; }
            public List<Amazon.SecretsManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SecretsManager.Model.CreateSecretResponse, NewSECSecretCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
