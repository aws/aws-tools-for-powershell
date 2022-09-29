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
    /// Creates a new version with a new encrypted secret value and attaches it to the secret.
    /// The version can contain a new <code>SecretString</code> value or a new <code>SecretBinary</code>
    /// value. 
    /// 
    ///  
    /// <para>
    /// We recommend you avoid calling <code>PutSecretValue</code> at a sustained rate of
    /// more than once every 10 minutes. When you update the secret value, Secrets Manager
    /// creates a new version of the secret. Secrets Manager removes outdated versions when
    /// there are more than 100, but it does not remove versions created less than 24 hours
    /// ago. If you call <code>PutSecretValue</code> more than once every 10 minutes, you
    /// create more versions than Secrets Manager removes, and you will reach the quota for
    /// secret versions.
    /// </para><para>
    /// You can specify the staging labels to attach to the new version in <code>VersionStages</code>.
    /// If you don't include <code>VersionStages</code>, then Secrets Manager automatically
    /// moves the staging label <code>AWSCURRENT</code> to this version. If this operation
    /// creates the first version for the secret, then Secrets Manager automatically attaches
    /// the staging label <code>AWSCURRENT</code> to it. If this operation moves the staging
    /// label <code>AWSCURRENT</code> from another version to this version, then Secrets Manager
    /// also automatically moves the staging label <code>AWSPREVIOUS</code> to the version
    /// that <code>AWSCURRENT</code> was removed from.
    /// </para><para>
    /// This operation is idempotent. If you call this operation with a <code>ClientRequestToken</code>
    /// that matches an existing version's VersionId, and you specify the same secret data,
    /// the operation succeeds but does nothing. However, if the secret data is different,
    /// then the operation fails because you can't modify an existing version; you can only
    /// create new ones.
    /// </para><para>
    /// Secrets Manager generates a CloudTrail log entry when you call this action. Do not
    /// include sensitive information in request parameters except <code>SecretBinary</code>
    /// or <code>SecretString</code> because it might be logged. For more information, see
    /// <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/retrieve-ct-entries.html">Logging
    /// Secrets Manager events with CloudTrail</a>.
    /// </para><para><b>Required permissions: </b><code>secretsmanager:PutSecretValue</code>. For more
    /// information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/reference_iam-permissions.html#reference_iam-permissions_actions">
    /// IAM policy actions for Secrets Manager</a> and <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access.html">Authentication
    /// and access control in Secrets Manager</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "SECSecretValue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.PutSecretValueResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager PutSecretValue API operation.", Operation = new[] {"PutSecretValue"}, SelectReturnType = typeof(Amazon.SecretsManager.Model.PutSecretValueResponse))]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.PutSecretValueResponse",
        "This cmdlet returns an Amazon.SecretsManager.Model.PutSecretValueResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSECSecretValueCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the new version of the secret. </para><note><para>If you use the Amazon Web Services CLI or one of the Amazon Web Services SDKs to call
        /// this operation, then you can leave this parameter empty because they generate a random
        /// UUID for you. If you don't use the SDK and instead generate a raw HTTP request to
        /// the Secrets Manager service endpoint, then you must generate a <code>ClientRequestToken</code>
        /// yourself for new versions and include that value in the request. </para></note><para>This value helps ensure idempotency. Secrets Manager uses this value to prevent the
        /// accidental creation of duplicate versions if there are failures and retries during
        /// the Lambda rotation function processing. We recommend that you generate a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type</a>
        /// value to ensure uniqueness within the specified secret. </para><ul><li><para>If the <code>ClientRequestToken</code> value isn't already associated with a version
        /// of the secret then a new version of the secret is created. </para></li><li><para>If a version with this value already exists and that version's <code>SecretString</code>
        /// or <code>SecretBinary</code> values are the same as those in the request then the
        /// request is ignored. The operation is idempotent. </para></li><li><para>If a version with this value already exists and the version of the <code>SecretString</code>
        /// and <code>SecretBinary</code> values are different from those in the request, then
        /// the request fails because you can't modify a secret version. You can only create new
        /// versions to store new secret values.</para></li></ul><para>This value becomes the <code>VersionId</code> of the new version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter SecretBinary
        /// <summary>
        /// <para>
        /// <para>The binary data to encrypt and store in the new version of the secret. To use this
        /// parameter in the command-line tools, we recommend that you store your binary data
        /// in a file and then pass the contents of the file as a parameter. </para><para>You must include <code>SecretBinary</code> or <code>SecretString</code>, but not both.</para><para>You can't access this value from the Secrets Manager console.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] SecretBinary { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>The ARN or name of the secret to add a new version to.</para><para>For an ARN, we recommend that you specify a complete ARN rather than a partial ARN.
        /// See <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/troubleshoot.html#ARN_secretnamehyphen">Finding
        /// a secret from a partial ARN</a>.</para><para>If the secret doesn't already exist, use <code>CreateSecret</code> instead.</para>
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
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter SecretString
        /// <summary>
        /// <para>
        /// <para>The text to encrypt and store in the new version of the secret. </para><para>You must include <code>SecretBinary</code> or <code>SecretString</code>, but not both.</para><para>We recommend you create the secret string as JSON key/value pairs, as shown in the
        /// example.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SecretString { get; set; }
        #endregion
        
        #region Parameter VersionStage
        /// <summary>
        /// <para>
        /// <para>A list of staging labels to attach to this version of the secret. Secrets Manager
        /// uses staging labels to track versions of a secret through the rotation process.</para><para>If you specify a staging label that's already associated with a different version
        /// of the same secret, then Secrets Manager removes the label from the other version
        /// and attaches it to this version. If you specify <code>AWSCURRENT</code>, and it is
        /// already attached to another version, then Secrets Manager also moves the staging label
        /// <code>AWSPREVIOUS</code> to the version that <code>AWSCURRENT</code> was removed from.</para><para>If you don't include <code>VersionStages</code>, then Secrets Manager automatically
        /// moves the staging label <code>AWSCURRENT</code> to this version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VersionStages")]
        public System.String[] VersionStage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecretsManager.Model.PutSecretValueResponse).
        /// Specifying the name of a property of type Amazon.SecretsManager.Model.PutSecretValueResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SecretId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SECSecretValue (PutSecretValue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecretsManager.Model.PutSecretValueResponse, WriteSECSecretValueCmdlet>(Select) ??
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
            context.ClientRequestToken = this.ClientRequestToken;
            context.SecretBinary = this.SecretBinary;
            context.SecretId = this.SecretId;
            #if MODULAR
            if (this.SecretId == null && ParameterWasBound(nameof(this.SecretId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecretId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecretString = this.SecretString;
            if (this.VersionStage != null)
            {
                context.VersionStage = new List<System.String>(this.VersionStage);
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
                var request = new Amazon.SecretsManager.Model.PutSecretValueRequest();
                
                if (cmdletContext.ClientRequestToken != null)
                {
                    request.ClientRequestToken = cmdletContext.ClientRequestToken;
                }
                if (cmdletContext.SecretBinary != null)
                {
                    _SecretBinaryStream = new System.IO.MemoryStream(cmdletContext.SecretBinary);
                    request.SecretBinary = _SecretBinaryStream;
                }
                if (cmdletContext.SecretId != null)
                {
                    request.SecretId = cmdletContext.SecretId;
                }
                if (cmdletContext.SecretString != null)
                {
                    request.SecretString = cmdletContext.SecretString;
                }
                if (cmdletContext.VersionStage != null)
                {
                    request.VersionStages = cmdletContext.VersionStage;
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
        
        private Amazon.SecretsManager.Model.PutSecretValueResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.PutSecretValueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "PutSecretValue");
            try
            {
                #if DESKTOP
                return client.PutSecretValue(request);
                #elif CORECLR
                return client.PutSecretValueAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public byte[] SecretBinary { get; set; }
            public System.String SecretId { get; set; }
            public System.String SecretString { get; set; }
            public List<System.String> VersionStage { get; set; }
            public System.Func<Amazon.SecretsManager.Model.PutSecretValueResponse, WriteSECSecretValueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
