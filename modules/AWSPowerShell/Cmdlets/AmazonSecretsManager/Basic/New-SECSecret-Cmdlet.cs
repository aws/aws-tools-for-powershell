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
    /// Creates a new secret. A secret in Secrets Manager consists of both the protected secret
    /// data and the important information needed to manage the secret.
    /// 
    ///  
    /// <para>
    /// Secrets Manager stores the encrypted secret data in one of a collection of "versions"
    /// associated with the secret. Each version contains a copy of the encrypted secret data.
    /// Each version is associated with one or more "staging labels" that identify where the
    /// version is in the rotation cycle. The <code>SecretVersionsToStages</code> field of
    /// the secret contains the mapping of staging labels to the active versions of the secret.
    /// Versions without a staging label are considered deprecated and are not included in
    /// the list.
    /// </para><para>
    /// You provide the secret data to be encrypted by putting text in either the <code>SecretString</code>
    /// parameter or binary data in the <code>SecretBinary</code> parameter, but not both.
    /// If you include <code>SecretString</code> or <code>SecretBinary</code> then Secrets
    /// Manager also creates an initial secret version and automatically attaches the staging
    /// label <code>AWSCURRENT</code> to the new version.
    /// </para><note><ul><li><para>
    /// If you call an operation that needs to encrypt or decrypt the <code>SecretString</code>
    /// or <code>SecretBinary</code> for a secret in the same account as the calling user
    /// and that secret doesn't specify a KMS encryption key, Secrets Manager uses the account's
    /// default AWS managed customer master key (CMK) with the alias <code>aws/secretsmanager</code>.
    /// If this key doesn't already exist in your account then Secrets Manager creates it
    /// for you automatically. All users in the same AWS account automatically have access
    /// to use the default CMK. Note that if an Secrets Manager API call results in AWS having
    /// to create the account's AWS-managed CMK, it can result in a one-time significant delay
    /// in returning the result.
    /// </para></li><li><para>
    /// If the secret is in a different AWS account from the credentials calling an API that
    /// requires encryption or decryption of the secret value then you must create and use
    /// a custom KMS CMK because you can't access the default CMK for the account using credentials
    /// from a different AWS account. Store the ARN of the CMK in the secret when you create
    /// the secret or when you update it by including it in the <code>KMSKeyId</code>. If
    /// you call an API that must encrypt or decrypt <code>SecretString</code> or <code>SecretBinary</code>
    /// using credentials from a different account then the KMS key policy must grant cross-account
    /// access to that other account's user or role for both the kms:GenerateDataKey and kms:Decrypt
    /// operations.
    /// </para></li></ul></note><para></para><para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:CreateSecret
    /// </para></li><li><para>
    /// kms:GenerateDataKey - needed only if you use a customer-created KMS key to encrypt
    /// the secret. You do not need this permission to use the account's default AWS managed
    /// CMK for Secrets Manager.
    /// </para></li><li><para>
    /// kms:Decrypt - needed only if you use a customer-created KMS key to encrypt the secret.
    /// You do not need this permission to use the account's default AWS managed CMK for Secrets
    /// Manager.
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To delete a secret, use <a>DeleteSecret</a>.
    /// </para></li><li><para>
    /// To modify an existing secret, use <a>UpdateSecret</a>.
    /// </para></li><li><para>
    /// To create a new version of a secret, use <a>PutSecretValue</a>.
    /// </para></li><li><para>
    /// To retrieve the encrypted secure string and secure binary values, use <a>GetSecretValue</a>.
    /// </para></li><li><para>
    /// To retrieve all other details for a secret, use <a>DescribeSecret</a>. This does not
    /// include the encrypted secure string and secure binary values.
    /// </para></li><li><para>
    /// To retrieve the list of secret versions associated with the current secret, use <a>DescribeSecret</a>
    /// and examine the <code>SecretVersionsToStages</code> response value.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "SECSecret", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.CreateSecretResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager CreateSecret API operation.", Operation = new[] {"CreateSecret"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.CreateSecretResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.CreateSecretResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSECSecretCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>(Optional) If you include <code>SecretString</code> or <code>SecretBinary</code>,
        /// then an initial version is created as part of the secret, and this parameter specifies
        /// a unique identifier for the new version. </para><note><para>If you use the AWS CLI or one of the AWS SDK to call this operation, then you can
        /// leave this parameter empty. The CLI or SDK generates a random UUID for you and includes
        /// as the value for this parameter in the request. If you don't use the SDK and instead
        /// generate a raw HTTP request to the Secrets Manager service endpoint, then you must
        /// generate a <code>ClientRequestToken</code> yourself for the new version and include
        /// that value in the request.</para></note><para>This value helps ensure idempotency. Secrets Manager uses this value to prevent the
        /// accidental creation of duplicate versions if there are failures and retries during
        /// a rotation. We recommend that you generate a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type</a>
        /// value to ensure uniqueness of your versions within the specified secret. </para><ul><li><para>If the <code>ClientRequestToken</code> value isn't already associated with a version
        /// of the secret then a new version of the secret is created. </para></li><li><para>If a version with this value already exists and that version's <code>SecretString</code>
        /// and <code>SecretBinary</code> values are the same as those in the request, then the
        /// request is ignored (the operation is idempotent).</para></li><li><para>If a version with this value already exists and that version's <code>SecretString</code>
        /// and <code>SecretBinary</code> values are different from those in the request then
        /// the request fails because you cannot modify an existing version. Instead, use <a>PutSecretValue</a>
        /// to create a new version.</para></li></ul><para>This value becomes the <code>SecretVersionId</code> of the new version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies a user-provided description of the secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies the ARN or alias of the AWS KMS customer master key (CMK) to
        /// be used to encrypt the <code>SecretString</code> or <code>SecretBinary</code> values
        /// in the versions stored in this secret.</para><para>If you don't specify this value, then Secrets Manager defaults to using the AWS account's
        /// default CMK (the one named <code>aws/secretsmanager</code>). If a KMS CMK with that
        /// name doesn't yet exist, then Secrets Manager creates it for you automatically the
        /// first time it needs to encrypt a version's <code>SecretString</code> or <code>SecretBinary</code>
        /// fields.</para><important><para>You can use the account's default CMK to encrypt and decrypt only if you call this
        /// operation using credentials from the same account that owns the secret. If the secret
        /// is in a different account, then you must create a custom CMK and specify the ARN in
        /// this field. </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the friendly name of the new secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SecretBinary
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies binary data that you want to encrypt and store in the new version
        /// of the secret. To use this parameter in the command-line tools, we recommend that
        /// you store your binary data in a file and then use the appropriate technique for your
        /// tool to pass the contents of the file as a parameter.</para><para>Either <code>SecretString</code> or <code>SecretBinary</code> must have a value, but
        /// not both. They cannot both be empty.</para><para>This parameter is not available using the Secrets Manager console. It can be accessed
        /// only by using the AWS CLI or one of the AWS SDKs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] SecretBinary { get; set; }
        #endregion
        
        #region Parameter SecretString
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies text data that you want to encrypt and store in this new version
        /// of the secret.</para><para>Either <code>SecretString</code> or <code>SecretBinary</code> must have a value, but
        /// not both. They cannot both be empty.</para><para>If you create a secret by using the Secrets Manager console then Secrets Manager puts
        /// the protected secret text in only the <code>SecretString</code> parameter. The Secrets
        /// Manager console stores the information as a JSON structure of key/value pairs that
        /// the Lambda rotation function knows how to parse.</para><para>For storing multiple values, we recommend that you use a JSON text string argument
        /// and specify key/value pairs. For information on how to format a JSON parameter for
        /// the various command line tool environments, see <a href="http://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#cli-using-param-json">Using
        /// JSON for Parameters</a> in the <i>AWS CLI User Guide</i>. For example:</para><para><code>[{"username":"bob"},{"password":"abc123xyz456"}]</code></para><para>If your command-line tool or SDK requires quotation marks around the parameter, you
        /// should use single quotes to avoid confusion with the double quotes required in the
        /// JSON text. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SecretString { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies a list of user-defined tags that are attached to the secret.
        /// Each tag is a "Key" and "Value" pair of strings. This operation only appends tags
        /// to the existing list of tags. To remove tags, you must use <a>UntagResource</a>.</para><important><ul><li><para>Secrets Manager tag key names are case sensitive. A tag with the key "ABC" is a different
        /// tag from one with key "abc".</para></li><li><para>If you check tags in IAM policy <code>Condition</code> elements as part of your security
        /// strategy, then adding or removing a tag can change permissions. If the successful
        /// completion of this operation would result in you losing your permissions for this
        /// secret, then this operation is blocked and returns an <code>Access Denied</code> error.</para></li></ul></important><para>This parameter requires a JSON text string argument. For information on how to format
        /// a JSON parameter for the various command line tool environments, see <a href="http://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#cli-using-param-json">Using
        /// JSON for Parameters</a> in the <i>AWS CLI User Guide</i>. For example:</para><para><code>[{"Key":"CostCenter","Value":"12345"},{"Key":"environment","Value":"production"}]</code></para><para>If your command-line tool or SDK requires quotation marks around the parameter, you
        /// should use single quotes to avoid confusion with the double quotes required in the
        /// JSON text. </para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per secret—50</para></li><li><para>Maximum key length—127 Unicode characters in UTF-8</para></li><li><para>Maximum value length—255 Unicode characters in UTF-8</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Do not use the <code>aws:</code> prefix in your tag names or values because it is
        /// reserved for AWS use. You can't edit or delete tag names or values with this prefix.
        /// Tags with this prefix do not count against your tags per secret limit.</para></li><li><para>If your tagging schema will be used across multiple services and resources, remember
        /// that other services might have restrictions on allowed characters. Generally allowed
        /// characters are: letters, spaces, and numbers representable in UTF-8, plus the following
        /// special characters: + - = . _ : / @.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SecretsManager.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SECSecret (CreateSecret)"))
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
            context.Description = this.Description;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            context.SecretBinary = this.SecretBinary;
            context.SecretString = this.SecretString;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SecretsManager.Model.Tag>(this.Tag);
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
                
                if (cmdletContext.ClientRequestToken != null)
                {
                    request.ClientRequestToken = cmdletContext.ClientRequestToken;
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
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
                if (cmdletContext.Tags != null)
                {
                    request.Tags = cmdletContext.Tags;
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
        
        private Amazon.SecretsManager.Model.CreateSecretResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.CreateSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "CreateSecret");
            try
            {
                #if DESKTOP
                return client.CreateSecret(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateSecretAsync(request);
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
            public System.String Description { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public byte[] SecretBinary { get; set; }
            public System.String SecretString { get; set; }
            public List<Amazon.SecretsManager.Model.Tag> Tags { get; set; }
        }
        
    }
}
