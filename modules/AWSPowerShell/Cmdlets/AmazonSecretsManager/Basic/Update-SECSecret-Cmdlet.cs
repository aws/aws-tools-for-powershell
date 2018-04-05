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
    /// Modifies many of the details of a secret. If you include a <code>ClientRequestToken</code>
    /// and either <code>SecretString</code> or <code>SecretBinary</code> then it also creates
    /// a new version attached to the secret.
    /// 
    ///  
    /// <para>
    /// To modify the rotation configuration of a secret, use <a>RotateSecret</a> instead.
    /// </para><note><para>
    /// The AWS Secrets Manager console uses only the <code>SecretString</code> parameter
    /// and therefore limits you to encrypting and storing only a text string. To encrypt
    /// and store binary data as part of the version of a secret, you must use either the
    /// AWS CLI or one of the AWS SDKs.
    /// </para></note><ul><li><para>
    /// If this update creates the first version of the secret or if you did not include the
    /// <code>VersionStages</code> parameter then Secrets Manager automatically attaches the
    /// staging label <code>AWSCURRENT</code> to the new version and removes it from any version
    /// that had it previously. The previous version (if any) is then given the staging label
    /// <code>AWSPREVIOUS</code>.
    /// </para></li><li><para>
    /// If a version with a <code>SecretVersionId</code> with the same value as the <code>ClientRequestToken</code>
    /// parameter already exists, the operation generates an error. You cannot modify an existing
    /// version, you can only create new ones.
    /// </para></li></ul><important><ul><li><para>
    /// If you call an operation that needs to encrypt or decrypt the <code>SecretString</code>
    /// and <code>SecretBinary</code> for a secret in the same account as the calling user
    /// and that secret doesn't specify a KMS encryption key, AWS Secrets Manager uses the
    /// account's default AWS managed customer master key (CMK) with the alias <code>aws/secretsmanager</code>.
    /// If this key doesn't already exist in your account then AWS Secrets Manager creates
    /// it for you automatically. All users in the same AWS account automatically have access
    /// to use the default CMK. Note that if an AWS Secrets Manager API call results in AWS
    /// having to create the account's AWS-managed CMK, it can result in a one-time significant
    /// delay in returning the result.
    /// </para></li><li><para>
    /// If the secret is in a different AWS account from the credentials calling an API that
    /// requires encryption or decryption of the secret value then you must create and use
    /// a custom KMS CMK because you can't access the default CMK for the account using credentials
    /// from a different AWS account. Store the ARN of the CMK in the secret when you create
    /// the secret or when you update it by including it in the <code>KMSKeyId</code>. If
    /// you call an API that must encrypt or decrypt <code>SecretString</code> or <code>SecretBinary</code>
    /// using credentials from a different account then the KMS key policy must grant cross-account
    /// access to that other account's user or role.
    /// </para></li></ul></important><para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:UpdateSecret
    /// </para></li><li><para>
    /// kms:GenerateDataKey - needed only if you use a custom KMS key to encrypt the secret.
    /// You do not need this permission to use the account's AWS managed CMK for Secrets Manager.
    /// </para></li><li><para>
    /// kms:Decrypt - needed only if you use a custom KMS key to encrypt the secret. You do
    /// not need this permission to use the account's AWS managed CMK for Secrets Manager.
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To create a new secret, use <a>CreateSecret</a>.
    /// </para></li><li><para>
    /// To add only a new version to an existing secret, use <a>PutSecretValue</a>.
    /// </para></li><li><para>
    /// To get the details for a secret, use <a>DescribeSecret</a>.
    /// </para></li><li><para>
    /// To list the versions contained in a secret, use <a>ListSecretVersionIds</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "SECSecret", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.UpdateSecretResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager UpdateSecret API operation.", Operation = new[] {"UpdateSecret"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.UpdateSecretResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.UpdateSecretResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSECSecretCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>(Optional) If you want to add a new version to the secret, this parameter specifies
        /// a unique identifier for the new version that helps ensure idempotency. </para><para>If you use the AWS CLI or one of the AWS SDK to call this operation, then you can
        /// leave this parameter empty. The CLI or SDK generates a random UUID for you and includes
        /// that in the request. If you don't use the SDK and instead generate a raw HTTP request
        /// to the AWS Secrets Manager service endpoint, then you must generate a <code>ClientRequestToken</code>
        /// yourself for new versions and include that value in the request.</para><para>You typically only need to interact with this value if you implement your own retry
        /// logic and want to ensure that a given secret is not created twice. We recommend that
        /// you generate a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type</a>
        /// value to ensure uniqueness within the specified secret. </para><para>Secrets Manager uses this value to prevent the accidental creation of duplicate versions
        /// if there are failures and retries during the Lambda rotation function's processing.</para><ul><li><para>If the <code>ClientRequestToken</code> value isn't already associated with a version
        /// of the secret then a new version of the secret is created. </para></li><li><para>If a version with this value already exists and that version's <code>SecretString</code>
        /// and <code>SecretBinary</code> values are the same as those in the request then the
        /// request is ignored (the operation is idempotent). </para></li><li><para>If a version with this value already exists and that version's <code>SecretString</code>
        /// and <code>SecretBinary</code> values are different from the request then an error
        /// occurs because you cannot modify an existing secret value.</para></li></ul><para>This value becomes the <code>SecretVersionId</code> of the new version.</para>
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
        /// <para>(Optional) Specifies the ARN or alias of the KMS customer master key (CMK) to be used
        /// to encrypt the protected text in the versions of this secret.</para><para>If you don't specify this value, then Secrets Manager defaults to using the default
        /// CMK in the account (the one named <code>aws/secretsmanager</code>). If a KMS CMK with
        /// that name doesn't exist, then AWS Secrets Manager creates it for you automatically
        /// the first time it needs to encrypt a version's <code>Plaintext</code> or <code>PlaintextString</code>
        /// fields.</para><important><para>You can only use the account's default CMK to encrypt and decrypt if you call this
        /// operation using credentials from the same account that owns the secret. If the secret
        /// is in a different account, then you must create a custom CMK and provide the ARN in
        /// this field. </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SecretBinary
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies binary data that you want to encrypt and store in the new version
        /// of the secret. To use this parameter in the command-line tools, we recommend that
        /// you store your binary data in a file and then use the appropriate technique for your
        /// tool to pass the contents of the file as a parameter. Either <code>SecretBinary</code>
        /// or <code>SecretString</code> must have a value. They cannot both be empty.</para><para>This parameter is not accessible using the Secrets Manager console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] SecretBinary { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret that you want to update or to which you want to add a new version.
        /// You can specify either the Amazon Resource Name (ARN) or the friendly name of the
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter SecretString
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies text data that you want to encrypt and store in this new version
        /// of the secret. Either <code>SecretBinary</code> or <code>SecretString</code> must
        /// have a value. They cannot both be empty.</para><para>If you create this secret by using the Secrets Manager console then Secrets Manager
        /// puts the protected secret text in only the <code>SecretString</code> parameter. The
        /// Secrets Manager console stores the information as a JSON structure of key/value pairs
        /// that the default Lambda rotation function knows how to parse.</para><para>For storing multiple values, we recommend that you use a JSON text string argument
        /// and specify key/value pairs. For information on how to format a JSON parameter for
        /// the various command line tool environments, see <a href="http://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#cli-using-param-json">Using
        /// JSON for Parameters</a> in the <i>AWS CLI User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SecretString { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SECSecret (UpdateSecret)"))
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
            context.SecretBinary = this.SecretBinary;
            context.SecretId = this.SecretId;
            context.SecretString = this.SecretString;
            
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
                var request = new Amazon.SecretsManager.Model.UpdateSecretRequest();
                
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
        
        private Amazon.SecretsManager.Model.UpdateSecretResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.UpdateSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "UpdateSecret");
            try
            {
                #if DESKTOP
                return client.UpdateSecret(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateSecretAsync(request);
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
            public byte[] SecretBinary { get; set; }
            public System.String SecretId { get; set; }
            public System.String SecretString { get; set; }
        }
        
    }
}
