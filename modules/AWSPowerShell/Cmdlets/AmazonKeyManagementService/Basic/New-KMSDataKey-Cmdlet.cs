/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Returns a data encryption key that you can use in your application to encrypt data
    /// locally.
    /// 
    ///  
    /// <para>
    /// You must specify the customer master key (CMK) under which to generate the data key.
    /// You must also specify the length of the data key using either the <code>KeySpec</code>
    /// or <code>NumberOfBytes</code> field. You must specify one field or the other, but
    /// not both. For common key lengths (128-bit and 256-bit symmetric keys), we recommend
    /// that you use <code>KeySpec</code>.
    /// </para><para>
    /// This operation returns a plaintext copy of the data key in the <code>Plaintext</code>
    /// field of the response, and an encrypted copy of the data key in the <code>CiphertextBlob</code>
    /// field. The data key is encrypted under the CMK specified in the <code>KeyId</code>
    /// field of the request.
    /// </para><para>
    /// We recommend that you use the following pattern to encrypt data locally in your application:
    /// </para><ol><li><para>
    /// Use this operation (<code>GenerateDataKey</code>) to retrieve a data encryption key.
    /// </para></li><li><para>
    /// Use the plaintext data encryption key (returned in the <code>Plaintext</code> field
    /// of the response) to encrypt data locally, then erase the plaintext data key from memory.
    /// </para></li><li><para>
    /// Store the encrypted data key (returned in the <code>CiphertextBlob</code> field of
    /// the response) alongside the locally encrypted data.
    /// </para></li></ol><para>
    /// To decrypt data locally:
    /// </para><ol><li><para>
    /// Use the <a>Decrypt</a> operation to decrypt the encrypted data key into a plaintext
    /// copy of the data key.
    /// </para></li><li><para>
    /// Use the plaintext data key to decrypt data locally, then erase the plaintext data
    /// key from memory.
    /// </para></li></ol><para>
    /// To return only an encrypted copy of the data key, use <a>GenerateDataKeyWithoutPlaintext</a>.
    /// To return a random byte string that is cryptographically secure, use <a>GenerateRandom</a>.
    /// </para><para>
    /// If you use the optional <code>EncryptionContext</code> field, you must store at least
    /// enough information to be able to reconstruct the full encryption context when you
    /// later send the ciphertext to the <a>Decrypt</a> operation. It is a good practice to
    /// choose an encryption context that you can reconstruct on the fly to better secure
    /// the ciphertext. For more information, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/encryption-context.html">Encryption
    /// Context</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSDataKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.GenerateDataKeyResponse")]
    [AWSCmdlet("Invokes the GenerateDataKey operation against AWS Key Management Service.", Operation = new[] {"GenerateDataKey"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GenerateDataKeyResponse",
        "This cmdlet returns a Amazon.KeyManagementService.Model.GenerateDataKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSDataKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter EncryptionContext
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs that represents additional authenticated data.</para><para>For more information, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/encryption-context.html">Encryption
        /// Context</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable EncryptionContext { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens.</para><para>For more information, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#grant_token">Grant
        /// Tokens</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the CMK under which to generate and encrypt the data encryption
        /// key.</para><para>A valid identifier is the unique key ID or the Amazon Resource Name (ARN) of the CMK,
        /// or the alias name or ARN of an alias that refers to the CMK. Examples:</para><ul><li><para>Unique key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>CMK ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias ARN: <code>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter KeySpec
        /// <summary>
        /// <para>
        /// <para>The length of the data encryption key. Use <code>AES_128</code> to generate a 128-bit
        /// symmetric key, or <code>AES_256</code> to generate a 256-bit symmetric key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.DataKeySpec")]
        public Amazon.KeyManagementService.DataKeySpec KeySpec { get; set; }
        #endregion
        
        #region Parameter NumberOfBytes
        /// <summary>
        /// <para>
        /// <para>The length of the data encryption key in bytes. For example, use the value 64 to generate
        /// a 512-bit data key (64 bytes is 512 bits). For common key lengths (128-bit and 256-bit
        /// symmetric keys), we recommend that you use the <code>KeySpec</code> field instead
        /// of this one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NumberOfBytes { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSDataKey (GenerateDataKey)"))
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
            
            if (this.EncryptionContext != null)
            {
                context.EncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionContext.Keys)
                {
                    context.EncryptionContext.Add((String)hashKey, (String)(this.EncryptionContext[hashKey]));
                }
            }
            if (this.GrantToken != null)
            {
                context.GrantTokens = new List<System.String>(this.GrantToken);
            }
            context.KeyId = this.KeyId;
            context.KeySpec = this.KeySpec;
            if (ParameterWasBound("NumberOfBytes"))
                context.NumberOfBytes = this.NumberOfBytes;
            
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
            var request = new Amazon.KeyManagementService.Model.GenerateDataKeyRequest();
            
            if (cmdletContext.EncryptionContext != null)
            {
                request.EncryptionContext = cmdletContext.EncryptionContext;
            }
            if (cmdletContext.GrantTokens != null)
            {
                request.GrantTokens = cmdletContext.GrantTokens;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.KeySpec != null)
            {
                request.KeySpec = cmdletContext.KeySpec;
            }
            if (cmdletContext.NumberOfBytes != null)
            {
                request.NumberOfBytes = cmdletContext.NumberOfBytes.Value;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.GenerateDataKeyResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GenerateDataKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GenerateDataKey");
            #if DESKTOP
            return client.GenerateDataKey(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GenerateDataKeyAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> EncryptionContext { get; set; }
            public List<System.String> GrantTokens { get; set; }
            public System.String KeyId { get; set; }
            public Amazon.KeyManagementService.DataKeySpec KeySpec { get; set; }
            public System.Int32? NumberOfBytes { get; set; }
        }
        
    }
}
