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
    /// You can reencrypt data using CMKs in different AWS accounts.
    /// </para><para>
    /// Unlike other operations, <code>ReEncrypt</code> is authorized twice, once as <code>ReEncryptFrom</code>
    /// on the source CMK and once as <code>ReEncryptTo</code> on the destination CMK. We
    /// recommend that you include the <code>"kms:ReEncrypt*"</code> permission in your <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">key
    /// policies</a> to permit reencryption from or to the CMK. This permission is automatically
    /// included in the key policy when you create a CMK through the console. But you must
    /// include it manually when you create a CMK programmatically or when you set a key policy
    /// with the <a>PutKeyPolicy</a> operation.
    /// </para><para>
    /// The result of this operation varies with the key state of the CMK. For details, see
    /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">How
    /// Key State Affects Use of a Customer Master Key</a> in the <i>AWS Key Management Service
    /// Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSReEncrypt", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ReEncryptResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service ReEncrypt API operation.", Operation = new[] {"ReEncrypt"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.ReEncryptResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ReEncryptResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.ReEncryptResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeKMSReEncryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CiphertextBlob
        /// <summary>
        /// <para>
        /// <para>Ciphertext of the data to reencrypt.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] CiphertextBlob { get; set; }
        #endregion
        
        #region Parameter DestinationEncryptionContext
        /// <summary>
        /// <para>
        /// <para>Encryption context to use when the data is reencrypted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DestinationEncryptionContext { get; set; }
        #endregion
        
        #region Parameter DestinationKeyId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the CMK that is used to reencrypt the data.</para><para>To specify a CMK, use its key ID, Amazon Resource Name (ARN), alias name, or alias
        /// ARN. When using an alias name, prefix it with <code>"alias/"</code>. To specify a
        /// CMK in a different AWS account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias ARN: <code>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.
        /// To get the alias name and alias ARN, use <a>ListAliases</a>.</para>
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
        public System.String DestinationKeyId { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#grant_token">Grant
        /// Tokens</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable SourceEncryptionContext { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.ReEncryptResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.ReEncryptResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DestinationKeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-KMSReEncrypt (ReEncrypt)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.ReEncryptResponse, InvokeKMSReEncryptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CiphertextBlob = this.CiphertextBlob;
            #if MODULAR
            if (this.CiphertextBlob == null && ParameterWasBound(nameof(this.CiphertextBlob)))
            {
                WriteWarning("You are passing $null as a value for parameter CiphertextBlob which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DestinationEncryptionContext != null)
            {
                context.DestinationEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationEncryptionContext.Keys)
                {
                    context.DestinationEncryptionContext.Add((String)hashKey, (String)(this.DestinationEncryptionContext[hashKey]));
                }
            }
            context.DestinationKeyId = this.DestinationKeyId;
            #if MODULAR
            if (this.DestinationKeyId == null && ParameterWasBound(nameof(this.DestinationKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GrantToken != null)
            {
                context.GrantToken = new List<System.String>(this.GrantToken);
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
            System.IO.MemoryStream _CiphertextBlobStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.ReEncryptRequest();
                
                if (cmdletContext.CiphertextBlob != null)
                {
                    _CiphertextBlobStream = new System.IO.MemoryStream(cmdletContext.CiphertextBlob);
                    request.CiphertextBlob = _CiphertextBlobStream;
                }
                if (cmdletContext.DestinationEncryptionContext != null)
                {
                    request.DestinationEncryptionContext = cmdletContext.DestinationEncryptionContext;
                }
                if (cmdletContext.DestinationKeyId != null)
                {
                    request.DestinationKeyId = cmdletContext.DestinationKeyId;
                }
                if (cmdletContext.GrantToken != null)
                {
                    request.GrantTokens = cmdletContext.GrantToken;
                }
                if (cmdletContext.SourceEncryptionContext != null)
                {
                    request.SourceEncryptionContext = cmdletContext.SourceEncryptionContext;
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
                if( _CiphertextBlobStream != null)
                {
                    _CiphertextBlobStream.Dispose();
                }
            }
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
                return client.ReEncryptAsync(request).GetAwaiter().GetResult();
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
            public byte[] CiphertextBlob { get; set; }
            public Dictionary<System.String, System.String> DestinationEncryptionContext { get; set; }
            public System.String DestinationKeyId { get; set; }
            public List<System.String> GrantToken { get; set; }
            public Dictionary<System.String, System.String> SourceEncryptionContext { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.ReEncryptResponse, InvokeKMSReEncryptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
