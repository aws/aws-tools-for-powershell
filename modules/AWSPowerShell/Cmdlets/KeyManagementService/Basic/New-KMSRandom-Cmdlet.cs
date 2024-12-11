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
    /// Returns a random byte string that is cryptographically secure.
    /// 
    ///  
    /// <para>
    /// You must use the <c>NumberOfBytes</c> parameter to specify the length of the random
    /// byte string. There is no default value for string length.
    /// </para><para>
    /// By default, the random byte string is generated in KMS. To generate the byte string
    /// in the CloudHSM cluster associated with an CloudHSM key store, use the <c>CustomKeyStoreId</c>
    /// parameter.
    /// </para><para><c>GenerateRandom</c> also supports <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/nitro-enclave.html">Amazon
    /// Web Services Nitro Enclaves</a>, which provide an isolated compute environment in
    /// Amazon EC2. To call <c>GenerateRandom</c> for a Nitro enclave, use the <a href="https://docs.aws.amazon.com/enclaves/latest/user/developing-applications.html#sdk">Amazon
    /// Web Services Nitro Enclaves SDK</a> or any Amazon Web Services SDK. Use the <c>Recipient</c>
    /// parameter to provide the attestation document for the enclave. Instead of plaintext
    /// bytes, the response includes the plaintext bytes encrypted under the public key from
    /// the attestation document (<c>CiphertextForRecipient</c>).For information about the
    /// interaction between KMS and Amazon Web Services Nitro Enclaves, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/services-nitro-enclaves.html">How
    /// Amazon Web Services Nitro Enclaves uses KMS</a> in the <i>Key Management Service Developer
    /// Guide</i>.
    /// </para><para>
    /// For more information about entropy and random number generation, see <a href="https://docs.aws.amazon.com/kms/latest/cryptographic-details/">Key
    /// Management Service Cryptographic Details</a>.
    /// </para><para><b>Cross-account use</b>: Not applicable. <c>GenerateRandom</c> does not use any
    /// account-specific resources, such as KMS keys.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:GenerateRandom</a>
    /// (IAM policy)
    /// </para><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSRandom", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.IO.MemoryStream")]
    [AWSCmdlet("Calls the AWS Key Management Service GenerateRandom API operation.", Operation = new[] {"GenerateRandom"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GenerateRandomResponse))]
    [AWSCmdletOutput("System.IO.MemoryStream or Amazon.KeyManagementService.Model.GenerateRandomResponse",
        "This cmdlet returns a System.IO.MemoryStream object.",
        "The service call response (type Amazon.KeyManagementService.Model.GenerateRandomResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKMSRandomCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Recipient_AttestationDocument
        /// <summary>
        /// <para>
        /// <para>The attestation document for an Amazon Web Services Nitro Enclave. This document includes
        /// the enclave's public key.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Recipient_AttestationDocument { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Generates the random byte string in the CloudHSM cluster that is associated with the
        /// specified CloudHSM key store. To find the ID of a custom key store, use the <a>DescribeCustomKeyStores</a>
        /// operation.</para><para>External key store IDs are not valid for this parameter. If you specify the ID of
        /// an external key store, <c>GenerateRandom</c> throws an <c>UnsupportedOperationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter Recipient_KeyEncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>The encryption algorithm that KMS should use with the public key for an Amazon Web
        /// Services Nitro Enclave to encrypt plaintext values for the response. The only valid
        /// value is <c>RSAES_OAEP_SHA_256</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.KeyEncryptionMechanism")]
        public Amazon.KeyManagementService.KeyEncryptionMechanism Recipient_KeyEncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter NumberOfBytes
        /// <summary>
        /// <para>
        /// <para>The length of the random byte string. This parameter is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Int32? NumberOfBytes { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Plaintext'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.GenerateRandomResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.GenerateRandomResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Plaintext";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSRandom (GenerateRandom)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.GenerateRandomResponse, NewKMSRandomCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            context.NumberOfBytes = this.NumberOfBytes;
            context.Recipient_AttestationDocument = this.Recipient_AttestationDocument;
            context.Recipient_KeyEncryptionAlgorithm = this.Recipient_KeyEncryptionAlgorithm;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Recipient_AttestationDocumentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.GenerateRandomRequest();
                
                if (cmdletContext.CustomKeyStoreId != null)
                {
                    request.CustomKeyStoreId = cmdletContext.CustomKeyStoreId;
                }
                if (cmdletContext.NumberOfBytes != null)
                {
                    request.NumberOfBytes = cmdletContext.NumberOfBytes.Value;
                }
                
                 // populate Recipient
                var requestRecipientIsNull = true;
                request.Recipient = new Amazon.KeyManagementService.Model.RecipientInfo();
                System.IO.MemoryStream requestRecipient_recipient_AttestationDocument = null;
                if (cmdletContext.Recipient_AttestationDocument != null)
                {
                    _Recipient_AttestationDocumentStream = new System.IO.MemoryStream(cmdletContext.Recipient_AttestationDocument);
                    requestRecipient_recipient_AttestationDocument = _Recipient_AttestationDocumentStream;
                }
                if (requestRecipient_recipient_AttestationDocument != null)
                {
                    request.Recipient.AttestationDocument = requestRecipient_recipient_AttestationDocument;
                    requestRecipientIsNull = false;
                }
                Amazon.KeyManagementService.KeyEncryptionMechanism requestRecipient_recipient_KeyEncryptionAlgorithm = null;
                if (cmdletContext.Recipient_KeyEncryptionAlgorithm != null)
                {
                    requestRecipient_recipient_KeyEncryptionAlgorithm = cmdletContext.Recipient_KeyEncryptionAlgorithm;
                }
                if (requestRecipient_recipient_KeyEncryptionAlgorithm != null)
                {
                    request.Recipient.KeyEncryptionAlgorithm = requestRecipient_recipient_KeyEncryptionAlgorithm;
                    requestRecipientIsNull = false;
                }
                 // determine if request.Recipient should be set to null
                if (requestRecipientIsNull)
                {
                    request.Recipient = null;
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
                if( _Recipient_AttestationDocumentStream != null)
                {
                    _Recipient_AttestationDocumentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.GenerateRandomResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GenerateRandomRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GenerateRandom");
            try
            {
                #if DESKTOP
                return client.GenerateRandom(request);
                #elif CORECLR
                return client.GenerateRandomAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomKeyStoreId { get; set; }
            public System.Int32? NumberOfBytes { get; set; }
            public byte[] Recipient_AttestationDocument { get; set; }
            public Amazon.KeyManagementService.KeyEncryptionMechanism Recipient_KeyEncryptionAlgorithm { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.GenerateRandomResponse, NewKMSRandomCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Plaintext;
        }
        
    }
}
