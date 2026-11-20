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
using Amazon.Payments;
using Amazon.Payments.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PAYM
{
    /// <summary>
    /// Retrieves a payment instrument on your account, including the details that are specific
    /// to its payment method, such as a card's last four digits. Identify the instrument
    /// by its Amazon Resource Name (ARN) or by its ID. <c>ListPaymentInstruments</c> returns
    /// both.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have Amazon Web Services Identity and Access Management
    /// (IAM) permission for <c>payments:GetPaymentInstrument</c>. You can scope this permission
    /// to the instrument's ARN.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PAYMPaymentInstrument")]
    [OutputType("Amazon.Payments.Model.PaymentInstrument")]
    [AWSCmdlet("Calls the AWS Payments GetPaymentInstrument API operation.", Operation = new[] {"GetPaymentInstrument"}, SelectReturnType = typeof(Amazon.Payments.Model.GetPaymentInstrumentResponse))]
    [AWSCmdletOutput("Amazon.Payments.Model.PaymentInstrument or Amazon.Payments.Model.GetPaymentInstrumentResponse",
        "This cmdlet returns an Amazon.Payments.Model.PaymentInstrument object.",
        "The service call response (type Amazon.Payments.Model.GetPaymentInstrumentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPAYMPaymentInstrumentCmdlet : AmazonPaymentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The instrument to retrieve. Specify one of the following:</para><ul><li><para>The Amazon Resource Name (ARN) of the instrument, as <c>ListPaymentInstruments</c>
        /// returns in <c>arn</c>. The ARN must be for an instrument on your account.</para></li><li><para>The ID of the instrument, as <c>ListPaymentInstruments</c> returns in <c>id</c>.</para></li></ul>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PaymentInstrument'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Payments.Model.GetPaymentInstrumentResponse).
        /// Specifying the name of a property of type Amazon.Payments.Model.GetPaymentInstrumentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PaymentInstrument";
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
                context.Select = CreateSelectDelegate<Amazon.Payments.Model.GetPaymentInstrumentResponse, GetPAYMPaymentInstrumentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Payments.Model.GetPaymentInstrumentRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
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
        
        private Amazon.Payments.Model.GetPaymentInstrumentResponse CallAWSServiceOperation(IAmazonPayments client, Amazon.Payments.Model.GetPaymentInstrumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Payments", "GetPaymentInstrument");
            try
            {
                return client.GetPaymentInstrumentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public System.Func<Amazon.Payments.Model.GetPaymentInstrumentResponse, GetPAYMPaymentInstrumentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PaymentInstrument;
        }
        
    }
}
