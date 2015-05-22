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
    /// Encrypts data on the server side with a new customer master key without exposing the
    /// plaintext of the data on the client side. The data is first decrypted and then encrypted.
    /// This operation can also be used to change the encryption context of a ciphertext.
    /// 
    /// 
    ///  
    /// <para>
    /// Unlike other actions, <code>ReEncrypt</code> is authorized twice - once as <code>ReEncryptFrom</code>
    /// on the source key and once as <code>ReEncryptTo</code> on the destination key. We
    /// therefore recommend that you include the <code>"action":"kms:ReEncrypt*"</code> statement
    /// in your key policies to permit re-encryption from or to the key. The statement is
    /// included automatically when you authorize use of the key through the console but must
    /// be included manually when you set a policy by using the <a>PutKeyPolicy</a> function.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSReEncrypt", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ReEncryptResponse")]
    [AWSCmdlet("Invokes the ReEncrypt operation against AWS Key Management Service.", Operation = new[] {"ReEncrypt"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ReEncryptResponse",
        "This cmdlet returns a ReEncryptResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class InvokeKMSReEncryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Ciphertext of the data to re-encrypt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.MemoryStream CiphertextBlob { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Encryption context to be used when the data is re-encrypted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable DestinationEncryptionContext { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the customer master key used to re-encrypt the data. This
        /// value can be a globally unique identifier, a fully specified ARN to either an alias
        /// or a key, or an alias name prefixed by "alias/". <ul><li>Key ARN Example - arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012</li><li>Alias ARN Example - arn:aws:kms:us-east-1:123456789012:alias/MyAliasName</li><li>Globally Unique Key ID Example - 12345678-1234-1234-1234-123456789012</li><li>Alias
        /// Name Example - alias/MyAliasName</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DestinationKeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For more information, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#grant_token">Grant
        /// Tokens</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Encryption context used to encrypt and decrypt the data specified in the <code>CiphertextBlob</code>
        /// parameter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable SourceEncryptionContext { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DestinationKeyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-KMSReEncrypt (ReEncrypt)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CiphertextBlob = this.CiphertextBlob;
            if (this.DestinationEncryptionContext != null)
            {
                context.DestinationEncryptionContext = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationEncryptionContext.Keys)
                {
                    context.DestinationEncryptionContext.Add((String)hashKey, (String)(this.DestinationEncryptionContext[hashKey]));
                }
            }
            context.DestinationKeyId = this.DestinationKeyId;
            if (this.GrantToken != null)
            {
                context.GrantTokens = new List<String>(this.GrantToken);
            }
            if (this.SourceEncryptionContext != null)
            {
                context.SourceEncryptionContext = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SourceEncryptionContext.Keys)
                {
                    context.SourceEncryptionContext.Add((String)hashKey, (String)(this.SourceEncryptionContext[hashKey]));
                }
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ReEncryptRequest();
            
            if (cmdletContext.CiphertextBlob != null)
            {
                request.CiphertextBlob = cmdletContext.CiphertextBlob;
            }
            if (cmdletContext.DestinationEncryptionContext != null)
            {
                request.DestinationEncryptionContext = cmdletContext.DestinationEncryptionContext;
            }
            if (cmdletContext.DestinationKeyId != null)
            {
                request.DestinationKeyId = cmdletContext.DestinationKeyId;
            }
            if (cmdletContext.GrantTokens != null)
            {
                request.GrantTokens = cmdletContext.GrantTokens;
            }
            if (cmdletContext.SourceEncryptionContext != null)
            {
                request.SourceEncryptionContext = cmdletContext.SourceEncryptionContext;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ReEncrypt(request);
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
            public System.IO.MemoryStream CiphertextBlob { get; set; }
            public Dictionary<String, String> DestinationEncryptionContext { get; set; }
            public String DestinationKeyId { get; set; }
            public List<String> GrantTokens { get; set; }
            public Dictionary<String, String> SourceEncryptionContext { get; set; }
        }
        
    }
}
