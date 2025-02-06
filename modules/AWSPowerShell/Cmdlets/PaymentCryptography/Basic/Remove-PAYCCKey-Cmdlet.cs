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
using Amazon.PaymentCryptography;
using Amazon.PaymentCryptography.Model;

namespace Amazon.PowerShell.Cmdlets.PAYCC
{
    /// <summary>
    /// Deletes the key material and metadata associated with Amazon Web Services Payment
    /// Cryptography key.
    /// 
    ///  
    /// <para>
    /// Key deletion is irreversible. After a key is deleted, you can't perform cryptographic
    /// operations using the key. For example, you can't decrypt data that was encrypted by
    /// a deleted Amazon Web Services Payment Cryptography key, and the data may become unrecoverable.
    /// Because key deletion is destructive, Amazon Web Services Payment Cryptography has
    /// a safety mechanism to prevent accidental deletion of a key. When you call this operation,
    /// Amazon Web Services Payment Cryptography disables the specified key but doesn't delete
    /// it until after a waiting period set using <c>DeleteKeyInDays</c>. The default waiting
    /// period is 7 days. During the waiting period, the <c>KeyState</c> is <c>DELETE_PENDING</c>.
    /// After the key is deleted, the <c>KeyState</c> is <c>DELETE_COMPLETE</c>.
    /// </para><para>
    /// You should delete a key only when you are sure that you don't need to use it anymore
    /// and no other parties are utilizing this key. If you aren't sure, consider deactivating
    /// it instead by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_StopKeyUsage.html">StopKeyUsage</a>.
    /// </para><para><b>Cross-account use:</b> This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_RestoreKey.html">RestoreKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_StartKeyUsage.html">StartKeyUsage</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_StopKeyUsage.html">StopKeyUsage</a></para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "PAYCCKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.PaymentCryptography.Model.Key")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane DeleteKey API operation.", Operation = new[] {"DeleteKey"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.DeleteKeyResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptography.Model.Key or Amazon.PaymentCryptography.Model.DeleteKeyResponse",
        "This cmdlet returns an Amazon.PaymentCryptography.Model.Key object.",
        "The service call response (type Amazon.PaymentCryptography.Model.DeleteKeyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemovePAYCCKeyCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeleteKeyInDay
        /// <summary>
        /// <para>
        /// <para>The waiting period for key deletion. The default value is seven days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteKeyInDays")]
        public System.Int32? DeleteKeyInDay { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the key that is scheduled for deletion.</para>
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
        public System.String KeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Key'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.DeleteKeyResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.DeleteKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Key";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-PAYCCKey (DeleteKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.DeleteKeyResponse, RemovePAYCCKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeleteKeyInDay = this.DeleteKeyInDay;
            context.KeyIdentifier = this.KeyIdentifier;
            #if MODULAR
            if (this.KeyIdentifier == null && ParameterWasBound(nameof(this.KeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PaymentCryptography.Model.DeleteKeyRequest();
            
            if (cmdletContext.DeleteKeyInDay != null)
            {
                request.DeleteKeyInDays = cmdletContext.DeleteKeyInDay.Value;
            }
            if (cmdletContext.KeyIdentifier != null)
            {
                request.KeyIdentifier = cmdletContext.KeyIdentifier;
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
        
        private Amazon.PaymentCryptography.Model.DeleteKeyResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.DeleteKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "DeleteKey");
            try
            {
                #if DESKTOP
                return client.DeleteKey(request);
                #elif CORECLR
                return client.DeleteKeyAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DeleteKeyInDay { get; set; }
            public System.String KeyIdentifier { get; set; }
            public System.Func<Amazon.PaymentCryptography.Model.DeleteKeyResponse, RemovePAYCCKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Key;
        }
        
    }
}
