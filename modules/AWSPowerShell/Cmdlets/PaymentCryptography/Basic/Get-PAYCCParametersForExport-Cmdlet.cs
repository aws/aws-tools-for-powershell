/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.PaymentCryptography;
using Amazon.PaymentCryptography.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PAYCC
{
    /// <summary>
    /// Gets the export token and the signing key certificate to initiate a TR-34 key export
    /// from Amazon Web Services Payment Cryptography.
    /// 
    ///  
    /// <para>
    /// The signing key certificate signs the wrapped key under export within the TR-34 key
    /// payload. The export token and signing key certificate must be in place and operational
    /// before calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ExportKey.html">ExportKey</a>.
    /// The export token expires in 30 days. You can use the same export token to export multiple
    /// keys from your service account.
    /// </para><para><b>Cross-account use:</b> This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ExportKey.html">ExportKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetParametersForImport.html">GetParametersForImport</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "PAYCCParametersForExport")]
    [OutputType("Amazon.PaymentCryptography.Model.GetParametersForExportResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane GetParametersForExport API operation.", Operation = new[] {"GetParametersForExport"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.GetParametersForExportResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptography.Model.GetParametersForExportResponse",
        "This cmdlet returns an Amazon.PaymentCryptography.Model.GetParametersForExportResponse object containing multiple properties."
    )]
    public partial class GetPAYCCParametersForExportCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KeyMaterialType
        /// <summary>
        /// <para>
        /// <para>The key block format type (for example, TR-34 or TR-31) to use during key material
        /// export. Export token is only required for a TR-34 key export, <c>TR34_KEY_BLOCK</c>.
        /// Export token is not required for TR-31 key export.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyMaterialType")]
        public Amazon.PaymentCryptography.KeyMaterialType KeyMaterialType { get; set; }
        #endregion
        
        #region Parameter SigningKeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The signing key algorithm to generate a signing key certificate. This certificate
        /// signs the wrapped key under export within the TR-34 key block. <c>RSA_2048</c> is
        /// the only signing key algorithm allowed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyAlgorithm")]
        public Amazon.PaymentCryptography.KeyAlgorithm SigningKeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.GetParametersForExportResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.GetParametersForExportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.GetParametersForExportResponse, GetPAYCCParametersForExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KeyMaterialType = this.KeyMaterialType;
            #if MODULAR
            if (this.KeyMaterialType == null && ParameterWasBound(nameof(this.KeyMaterialType)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyMaterialType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SigningKeyAlgorithm = this.SigningKeyAlgorithm;
            #if MODULAR
            if (this.SigningKeyAlgorithm == null && ParameterWasBound(nameof(this.SigningKeyAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter SigningKeyAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PaymentCryptography.Model.GetParametersForExportRequest();
            
            if (cmdletContext.KeyMaterialType != null)
            {
                request.KeyMaterialType = cmdletContext.KeyMaterialType;
            }
            if (cmdletContext.SigningKeyAlgorithm != null)
            {
                request.SigningKeyAlgorithm = cmdletContext.SigningKeyAlgorithm;
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
        
        private Amazon.PaymentCryptography.Model.GetParametersForExportResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.GetParametersForExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "GetParametersForExport");
            try
            {
                return client.GetParametersForExportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PaymentCryptography.KeyMaterialType KeyMaterialType { get; set; }
            public Amazon.PaymentCryptography.KeyAlgorithm SigningKeyAlgorithm { get; set; }
            public System.Func<Amazon.PaymentCryptography.Model.GetParametersForExportResponse, GetPAYCCParametersForExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
