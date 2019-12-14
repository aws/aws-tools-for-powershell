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
    /// Returns the items you need to import key material into a symmetric, customer managed
    /// customer master key (CMK). For more information about importing key material into
    /// AWS KMS, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// Key Material</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// This operation returns a public key and an import token. Use the public key to encrypt
    /// the symmetric key material. Store the import token to send with a subsequent <a>ImportKeyMaterial</a>
    /// request.
    /// </para><para>
    /// You must specify the key ID of the symmetric CMK into which you will import key material.
    /// This CMK's <code>Origin</code> must be <code>EXTERNAL</code>. You must also specify
    /// the wrapping algorithm and type of wrapping key (public key) that you will use to
    /// encrypt the key material. You cannot perform this operation on an asymmetric CMK or
    /// on any CMK in a different AWS account.
    /// </para><para>
    /// To import key material, you must use the public key and import token from the same
    /// response. These items are valid for 24 hours. The expiration date and time appear
    /// in the <code>GetParametersForImport</code> response. You cannot use an expired token
    /// in an <a>ImportKeyMaterial</a> request. If your key and token expire, send another
    /// <code>GetParametersForImport</code> request.
    /// </para><para>
    /// The CMK that you use for this operation must be in a compatible key state. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">How
    /// Key State Affects Use of a Customer Master Key</a> in the <i>AWS Key Management Service
    /// Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KMSParametersForImport")]
    [OutputType("Amazon.KeyManagementService.Model.GetParametersForImportResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service GetParametersForImport API operation.", Operation = new[] {"GetParametersForImport"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GetParametersForImportResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GetParametersForImportResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.GetParametersForImportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKMSParametersForImportCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the symmetric CMK into which you will import key material. The <code>Origin</code>
        /// of the CMK must be <code>EXTERNAL</code>.</para><para>Specify the key ID or the Amazon Resource Name (ARN) of the CMK.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter WrappingAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm you will use to encrypt the key material before importing it with <a>ImportKeyMaterial</a>.
        /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys-encrypt-key-material.html">Encrypt
        /// the Key Material</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.AlgorithmSpec")]
        public Amazon.KeyManagementService.AlgorithmSpec WrappingAlgorithm { get; set; }
        #endregion
        
        #region Parameter WrappingKeySpec
        /// <summary>
        /// <para>
        /// <para>The type of wrapping key (public key) to return in the response. Only 2048-bit RSA
        /// public keys are supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.WrappingKeySpec")]
        public Amazon.KeyManagementService.WrappingKeySpec WrappingKeySpec { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.GetParametersForImportResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.GetParametersForImportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KeyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KeyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KeyId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.GetParametersForImportResponse, GetKMSParametersForImportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KeyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WrappingAlgorithm = this.WrappingAlgorithm;
            #if MODULAR
            if (this.WrappingAlgorithm == null && ParameterWasBound(nameof(this.WrappingAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter WrappingAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WrappingKeySpec = this.WrappingKeySpec;
            #if MODULAR
            if (this.WrappingKeySpec == null && ParameterWasBound(nameof(this.WrappingKeySpec)))
            {
                WriteWarning("You are passing $null as a value for parameter WrappingKeySpec which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.KeyManagementService.Model.GetParametersForImportRequest();
            
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.WrappingAlgorithm != null)
            {
                request.WrappingAlgorithm = cmdletContext.WrappingAlgorithm;
            }
            if (cmdletContext.WrappingKeySpec != null)
            {
                request.WrappingKeySpec = cmdletContext.WrappingKeySpec;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.GetParametersForImportResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GetParametersForImportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GetParametersForImport");
            try
            {
                #if DESKTOP
                return client.GetParametersForImport(request);
                #elif CORECLR
                return client.GetParametersForImportAsync(request).GetAwaiter().GetResult();
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
            public System.String KeyId { get; set; }
            public Amazon.KeyManagementService.AlgorithmSpec WrappingAlgorithm { get; set; }
            public Amazon.KeyManagementService.WrappingKeySpec WrappingKeySpec { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.GetParametersForImportResponse, GetKMSParametersForImportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
