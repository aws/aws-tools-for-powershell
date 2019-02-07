/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Stores a new encrypted secret value in the specified secret. To do this, the operation
    /// creates a new version and attaches it to the secret. The version can contain a new
    /// <code>SecretString</code> value or a new <code>SecretBinary</code> value. You can
    /// also specify the staging labels that are initially attached to the new version.
    /// 
    ///  <note><para>
    /// The Secrets Manager console uses only the <code>SecretString</code> field. To add
    /// binary data to a secret with the <code>SecretBinary</code> field you must use the
    /// AWS CLI or one of the AWS SDKs.
    /// </para></note><ul><li><para>
    /// If this operation creates the first version for the secret then Secrets Manager automatically
    /// attaches the staging label <code>AWSCURRENT</code> to the new version.
    /// </para></li><li><para>
    /// If another version of this secret already exists, then this operation does not automatically
    /// move any staging labels other than those that you explicitly specify in the <code>VersionStages</code>
    /// parameter.
    /// </para></li><li><para>
    /// If this operation moves the staging label <code>AWSCURRENT</code> from another version
    /// to this version (because you included it in the <code>StagingLabels</code> parameter)
    /// then Secrets Manager also automatically moves the staging label <code>AWSPREVIOUS</code>
    /// to the version that <code>AWSCURRENT</code> was removed from.
    /// </para></li><li><para>
    /// This operation is idempotent. If a version with a <code>VersionId</code> with the
    /// same value as the <code>ClientRequestToken</code> parameter already exists and you
    /// specify the same secret data, the operation succeeds but does nothing. However, if
    /// the secret data is different, then the operation fails because you cannot modify an
    /// existing version; you can only create new ones.
    /// </para></li></ul><note><ul><li><para>
    /// If you call an operation that needs to encrypt or decrypt the <code>SecretString</code>
    /// or <code>SecretBinary</code> for a secret in the same account as the calling user
    /// and that secret doesn't specify a AWS KMS encryption key, Secrets Manager uses the
    /// account's default AWS managed customer master key (CMK) with the alias <code>aws/secretsmanager</code>.
    /// If this key doesn't already exist in your account then Secrets Manager creates it
    /// for you automatically. All users and roles in the same AWS account automatically have
    /// access to use the default CMK. Note that if an Secrets Manager API call results in
    /// AWS having to create the account's AWS-managed CMK, it can result in a one-time significant
    /// delay in returning the result.
    /// </para></li><li><para>
    /// If the secret is in a different AWS account from the credentials calling an API that
    /// requires encryption or decryption of the secret value then you must create and use
    /// a custom AWS KMS CMK because you can't access the default CMK for the account using
    /// credentials from a different AWS account. Store the ARN of the CMK in the secret when
    /// you create the secret or when you update it by including it in the <code>KMSKeyId</code>.
    /// If you call an API that must encrypt or decrypt <code>SecretString</code> or <code>SecretBinary</code>
    /// using credentials from a different account then the AWS KMS key policy must grant
    /// cross-account access to that other account's user or role for both the kms:GenerateDataKey
    /// and kms:Decrypt operations.
    /// </para></li></ul></note><para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:PutSecretValue
    /// </para></li><li><para>
    /// kms:GenerateDataKey - needed only if you use a customer-managed AWS KMS key to encrypt
    /// the secret. You do not need this permission to use the account's default AWS managed
    /// CMK for Secrets Manager.
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To retrieve the encrypted value you store in the version of a secret, use <a>GetSecretValue</a>.
    /// </para></li><li><para>
    /// To create a secret, use <a>CreateSecret</a>.
    /// </para></li><li><para>
    /// To get the details for a secret, use <a>DescribeSecret</a>.
    /// </para></li><li><para>
    /// To list the versions attached to a secret, use <a>ListSecretVersionIds</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "SECSecretValue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.PutSecretValueResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager PutSecretValue API operation.", Operation = new[] {"PutSecretValue"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.PutSecretValueResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.PutSecretValueResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSECSecretValueCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies a unique identifier for the new version of the secret. </para><note><para>If you use the AWS CLI or one of the AWS SDK to call this operation, then you can
        /// leave this parameter empty. The CLI or SDK generates a random UUID for you and includes
        /// that in the request. If you don't use the SDK and instead generate a raw HTTP request
        /// to the Secrets Manager service endpoint, then you must generate a <code>ClientRequestToken</code>
        /// yourself for new versions and include that value in the request. </para></note><para>This value helps ensure idempotency. Secrets Manager uses this value to prevent the
        /// accidental creation of duplicate versions if there are failures and retries during
        /// the Lambda rotation function's processing. We recommend that you generate a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type</a>
        /// value to ensure uniqueness within the specified secret. </para><ul><li><para>If the <code>ClientRequestToken</code> value isn't already associated with a version
        /// of the secret then a new version of the secret is created. </para></li><li><para>If a version with this value already exists and that version's <code>SecretString</code>
        /// or <code>SecretBinary</code> values are the same as those in the request then the
        /// request is ignored (the operation is idempotent). </para></li><li><para>If a version with this value already exists and that version's <code>SecretString</code>
        /// and <code>SecretBinary</code> values are different from those in the request then
        /// the request fails because you cannot modify an existing secret version. You can only
        /// create new versions to store new secret values.</para></li></ul><para>This value becomes the <code>VersionId</code> of the new version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter SecretBinary
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies binary data that you want to encrypt and store in the new version
        /// of the secret. To use this parameter in the command-line tools, we recommend that
        /// you store your binary data in a file and then use the appropriate technique for your
        /// tool to pass the contents of the file as a parameter. Either <code>SecretBinary</code>
        /// or <code>SecretString</code> must have a value, but not both. They cannot both be
        /// empty.</para><para>This parameter is not accessible if the secret using the Secrets Manager console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] SecretBinary { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret to which you want to add a new version. You can specify either
        /// the Amazon Resource Name (ARN) or the friendly name of the secret. The secret must
        /// already exist.</para><note><para>If you specify an ARN, we generally recommend that you specify a complete ARN. You
        /// can specify a partial ARN too—for example, if you don’t include the final hyphen and
        /// six random characters that Secrets Manager adds at the end of the ARN when you created
        /// the secret. A partial ARN match can work as long as it uniquely matches only one secret.
        /// However, if your secret has a name that ends in a hyphen followed by six characters
        /// (before Secrets Manager adds the hyphen and six characters to the ARN) and you try
        /// to use that as a partial ARN, then those characters cause Secrets Manager to assume
        /// that you’re specifying a complete ARN. This confusion can cause unexpected results.
        /// To avoid this situation, we recommend that you don’t create secret names that end
        /// with a hyphen followed by six characters.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter SecretString
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies text data that you want to encrypt and store in this new version
        /// of the secret. Either <code>SecretString</code> or <code>SecretBinary</code> must
        /// have a value, but not both. They cannot both be empty.</para><para>If you create this secret by using the Secrets Manager console then Secrets Manager
        /// puts the protected secret text in only the <code>SecretString</code> parameter. The
        /// Secrets Manager console stores the information as a JSON structure of key/value pairs
        /// that the default Lambda rotation function knows how to parse.</para><para>For storing multiple values, we recommend that you use a JSON text string argument
        /// and specify key/value pairs. For information on how to format a JSON parameter for
        /// the various command line tool environments, see <a href="https://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#cli-using-param-json">Using
        /// JSON for Parameters</a> in the <i>AWS CLI User Guide</i>.</para><para> For example:</para><para><code>[{"username":"bob"},{"password":"abc123xyz456"}]</code></para><para>If your command-line tool or SDK requires quotation marks around the parameter, you
        /// should use single quotes to avoid confusion with the double quotes required in the
        /// JSON text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SecretString { get; set; }
        #endregion
        
        #region Parameter VersionStage
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies a list of staging labels that are attached to this version of
        /// the secret. These staging labels are used to track the versions through the rotation
        /// process by the Lambda rotation function.</para><para>A staging label must be unique to a single version of the secret. If you specify a
        /// staging label that's already associated with a different version of the same secret
        /// then that staging label is automatically removed from the other version and attached
        /// to this version.</para><para>If you do not specify a value for <code>VersionStages</code> then Secrets Manager
        /// automatically moves the staging label <code>AWSCURRENT</code> to this new version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VersionStages")]
        public System.String[] VersionStage { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SecretId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SECSecretValue (PutSecretValue)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientRequestToken = this.ClientRequestToken;
            context.SecretBinary = this.SecretBinary;
            context.SecretId = this.SecretId;
            context.SecretString = this.SecretString;
            if (this.VersionStage != null)
            {
                context.VersionStages = new List<System.String>(this.VersionStage);
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
                if (cmdletContext.VersionStages != null)
                {
                    request.VersionStages = cmdletContext.VersionStages;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response;
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response,
                        Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutSecretValueAsync(request);
                return task.Result;
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
            public List<System.String> VersionStages { get; set; }
        }
        
    }
}
