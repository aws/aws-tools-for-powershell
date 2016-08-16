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
    /// using any of the following functions:
    /// 
    ///  <ul><li><para><a>GenerateDataKey</a></para></li><li><para><a>GenerateDataKeyWithoutPlaintext</a></para></li><li><para><a>Encrypt</a></para></li></ul><para>
    /// Note that if a caller has been granted access permissions to all keys (through, for
    /// example, IAM user policies that grant <code>Decrypt</code> permission on all resources),
    /// then ciphertext encrypted by using keys in other accounts where the key grants access
    /// to the caller can be decrypted. To remedy this, we recommend that you do not grant
    /// <code>Decrypt</code> access in an IAM user policy. Instead grant <code>Decrypt</code>
    /// access only in key policies. If you must grant <code>Decrypt</code> access in an IAM
    /// user policy, you should scope the resource to specific keys or to specific trusted
    /// accounts.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSDecrypt")]
    [OutputType("Amazon.KeyManagementService.Model.DecryptResponse")]
    [AWSCmdlet("Invokes the Decrypt operation against AWS Key Management Service.", Operation = new[] {"Decrypt"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.DecryptResponse",
        "This cmdlet returns a Amazon.KeyManagementService.Model.DecryptResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeKMSDecryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CiphertextBlob
        /// <summary>
        /// <para>
        /// <para>Ciphertext to be decrypted. The blob includes metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.MemoryStream CiphertextBlob { get; set; }
        #endregion
        
        #region Parameter EncryptionContext
        /// <summary>
        /// <para>
        /// <para>The encryption context. If this was specified in the <a>Encrypt</a> function, it must
        /// be specified here or the decryption operation will fail. For more information, see
        /// <a href="http://docs.aws.amazon.com/kms/latest/developerguide/encrypt-context.html">Encryption
        /// Context</a>.</para>
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CiphertextBlob = this.CiphertextBlob;
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
            var request = new Amazon.KeyManagementService.Model.DecryptRequest();
            
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
        
        private static Amazon.KeyManagementService.Model.DecryptResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.DecryptRequest request)
        {
            #if DESKTOP
            return client.Decrypt(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DecryptAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.IO.MemoryStream CiphertextBlob { get; set; }
            public Dictionary<System.String, System.String> EncryptionContext { get; set; }
            public List<System.String> GrantTokens { get; set; }
        }
        
    }
}
