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
    /// Encrypts data on the server side with a new customer master key (CMK) without exposing
    /// the plaintext of the data on the client side. The data is first decrypted and then
    /// reencrypted. You can also use this operation to change the encryption context of a
    /// ciphertext.
    /// 
    ///  
    /// <para>
    /// Unlike other operations, <code>ReEncrypt</code> is authorized twice, once as <code>ReEncryptFrom</code>
    /// on the source CMK and once as <code>ReEncryptTo</code> on the destination CMK. We
    /// recommend that you include the <code>"kms:ReEncrypt*"</code> permission in your <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">key
    /// policies</a> to permit reencryption from or to the CMK. This permission is automatically
    /// included in the key policy when you create a CMK through the console, but you must
    /// include it manually when you create a CMK programmatically or when you set a key policy
    /// with the <a>PutKeyPolicy</a> operation.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSReEncrypt", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ReEncryptResponse")]
    [AWSCmdlet("Invokes the ReEncrypt operation against AWS Key Management Service.", Operation = new[] {"ReEncrypt"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ReEncryptResponse",
        "This cmdlet returns a Amazon.KeyManagementService.Model.ReEncryptResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeKMSReEncryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CiphertextBlob
        /// <summary>
        /// <para>
        /// <para>Ciphertext of the data to reencrypt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.MemoryStream CiphertextBlob { get; set; }
        #endregion
        
        #region Parameter DestinationEncryptionContext
        /// <summary>
        /// <para>
        /// <para>Encryption context to use when the data is reencrypted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable DestinationEncryptionContext { get; set; }
        #endregion
        
        #region Parameter DestinationKeyId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the CMK to use to reencrypt the data. This value can be a
        /// globally unique identifier, a fully specified ARN to either an alias or a key, or
        /// an alias name prefixed by "alias/".</para><ul><li><para>Key ARN Example - arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012</para></li><li><para>Alias ARN Example - arn:aws:kms:us-east-1:123456789012:alias/MyAliasName</para></li><li><para>Globally Unique Key ID Example - 12345678-1234-1234-1234-123456789012</para></li><li><para>Alias Name Example - alias/MyAliasName</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DestinationKeyId { get; set; }
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
        
        #region Parameter SourceEncryptionContext
        /// <summary>
        /// <para>
        /// <para>Encryption context used to encrypt and decrypt the data specified in the <code>CiphertextBlob</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable SourceEncryptionContext { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CiphertextBlob = this.CiphertextBlob;
            if (this.DestinationEncryptionContext != null)
            {
                context.DestinationEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationEncryptionContext.Keys)
                {
                    context.DestinationEncryptionContext.Add((String)hashKey, (String)(this.DestinationEncryptionContext[hashKey]));
                }
            }
            context.DestinationKeyId = this.DestinationKeyId;
            if (this.GrantToken != null)
            {
                context.GrantTokens = new List<System.String>(this.GrantToken);
            }
            if (this.SourceEncryptionContext != null)
            {
                context.SourceEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SourceEncryptionContext.Keys)
                {
                    context.SourceEncryptionContext.Add((String)hashKey, (String)(this.SourceEncryptionContext[hashKey]));
                }
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
            var request = new Amazon.KeyManagementService.Model.ReEncryptRequest();
            
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
        
        private Amazon.KeyManagementService.Model.ReEncryptResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.ReEncryptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "ReEncrypt");
            try
            {
                #if DESKTOP
                return client.ReEncrypt(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ReEncryptAsync(request);
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
            public System.IO.MemoryStream CiphertextBlob { get; set; }
            public Dictionary<System.String, System.String> DestinationEncryptionContext { get; set; }
            public System.String DestinationKeyId { get; set; }
            public List<System.String> GrantTokens { get; set; }
            public Dictionary<System.String, System.String> SourceEncryptionContext { get; set; }
        }
        
    }
}
