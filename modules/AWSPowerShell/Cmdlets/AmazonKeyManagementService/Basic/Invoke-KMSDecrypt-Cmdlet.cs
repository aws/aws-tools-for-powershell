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
    /// Decrypts ciphertext. Ciphertext is plaintext that has been previously encrypted by
    /// using the <a>Encrypt</a> function.
    /// </summary>
    [Cmdlet("Invoke", "KMSDecrypt")]
    [OutputType("Amazon.KeyManagementService.Model.DecryptResult")]
    [AWSCmdlet("Invokes the Decrypt operation against AWS Key Management Service.", Operation = new[] {"Decrypt"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.DecryptResult",
        "This cmdlet returns a DecryptResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class InvokeKMSDecryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Ciphertext including metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.MemoryStream CiphertextBlob { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The encryption context. If this was specified in the <a>Encrypt</a> function, it must
        /// be specified here or the decryption operation will fail. For more information, see
        /// <a href="http://docs.aws.amazon.com/kms/latest/developerguide/encrypt-context.html">Encryption
        /// Context</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable EncryptionContext { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens that represent grants which can be used to provide long term
        /// permissions to perform decryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CiphertextBlob = this.CiphertextBlob;
            if (this.EncryptionContext != null)
            {
                context.EncryptionContext = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionContext.Keys)
                {
                    context.EncryptionContext.Add((String)hashKey, (String)(this.EncryptionContext[hashKey]));
                }
            }
            if (this.GrantToken != null)
            {
                context.GrantTokens = new List<String>(this.GrantToken);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DecryptRequest();
            
            if (cmdletContext.CiphertextBlob != null)
            {
                request.CiphertextBlob = cmdletContext.CiphertextBlob;
            }
            if (cmdletContext.EncryptionContext != null)
            {
                request.EncryptionContext = cmdletContext.EncryptionContext;
            }
            if (cmdletContext.GrantTokens != null)
            {
                request.GrantTokens = cmdletContext.GrantTokens;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.Decrypt(request);
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
            public Dictionary<String, String> EncryptionContext { get; set; }
            public List<String> GrantTokens { get; set; }
        }
        
    }
}
