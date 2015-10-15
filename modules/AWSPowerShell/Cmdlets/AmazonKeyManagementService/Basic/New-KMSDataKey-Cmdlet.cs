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
    /// Generates a data key that you can use in your application to locally encrypt data.
    /// This call returns a plaintext version of the key in the <code>Plaintext</code> field
    /// of the response object and an encrypted copy of the key in the <code>CiphertextBlob</code>
    /// field. The key is encrypted by using the master key specified by the <code>KeyId</code>
    /// field. To decrypt the encrypted key, pass it to the <code>Decrypt</code> API. 
    /// 
    ///  
    /// <para>
    /// We recommend that you use the following pattern to locally encrypt data: call the
    /// <code>GenerateDataKey</code> API, use the key returned in the <code>Plaintext</code>
    /// response field to locally encrypt data, and then erase the plaintext data key from
    /// memory. Store the encrypted data key (contained in the <code>CiphertextBlob</code>
    /// field) alongside of the locally encrypted data. 
    /// </para><note>You should not call the <code>Encrypt</code> function to re-encrypt your data
    /// keys within a region. <code>GenerateDataKey</code> always returns the data key encrypted
    /// and tied to the customer master key that will be used to decrypt it. There is no need
    /// to decrypt it twice. </note><para>
    /// If you decide to use the optional <code>EncryptionContext</code> parameter, you must
    /// also store the context in full or at least store enough information along with the
    /// encrypted data to be able to reconstruct the context when submitting the ciphertext
    /// to the <code>Decrypt</code> API. It is a good practice to choose a context that you
    /// can reconstruct on the fly to better secure the ciphertext. For more information about
    /// how this parameter is used, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/encrypt-context.html">Encryption
    /// Context</a>. 
    /// </para><para>
    /// To decrypt data, pass the encrypted data key to the <code>Decrypt</code> API. <code>Decrypt</code>
    /// uses the associated master key to decrypt the encrypted data key and returns it as
    /// plaintext. Use the plaintext data key to locally decrypt your data and then erase
    /// the key from memory. You must specify the encryption context, if any, that you specified
    /// when you generated the key. The encryption context is logged by CloudTrail, and you
    /// can use this log to help track the use of particular data. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSDataKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.GenerateDataKeyResponse")]
    [AWSCmdlet("Invokes the GenerateDataKey operation against AWS Key Management Service.", Operation = new[] {"GenerateDataKey"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GenerateDataKeyResponse",
        "This cmdlet returns a Amazon.KeyManagementService.Model.GenerateDataKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewKMSDataKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Name/value pair that contains additional data to be authenticated during the encryption
        /// and decryption processes that use the key. This value is logged by AWS CloudTrail
        /// to provide context around the data encrypted by the key. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable EncryptionContext { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens.</para><para>For more information, go to <a href="http://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#grant_token">Grant
        /// Tokens</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the customer master key. This value can be a globally unique
        /// identifier, a fully specified ARN to either an alias or a key, or an alias name prefixed
        /// by "alias/". <ul><li>Key ARN Example - arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012</li><li>Alias ARN Example - arn:aws:kms:us-east-1:123456789012:alias/MyAliasName</li><li>Globally Unique Key ID Example - 12345678-1234-1234-1234-123456789012</li><li>Alias
        /// Name Example - alias/MyAliasName</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String KeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Value that identifies the encryption algorithm and key size to generate a data key
        /// for. Currently this can be AES_128 or AES_256. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KeyManagementService.DataKeySpec KeySpec { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Integer that contains the number of bytes to generate. Common values are 128, 256,
        /// 512, and 1024. 1024 is the current limit. We recommend that you use the <code>KeySpec</code>
        /// parameter instead. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NumberOfBytes { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
                var response = client.GenerateDataKey(request);
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
