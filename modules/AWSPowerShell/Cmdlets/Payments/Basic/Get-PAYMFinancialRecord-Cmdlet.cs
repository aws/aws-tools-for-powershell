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
    /// Retrieves a single financial record, including the details that are specific to its
    /// type. Specify exactly one of the following:
    /// 
    ///  <ul><li><para>
    /// The ID that Amazon Web Services Payments issued for the record, in <c>identifier</c>.
    /// </para></li><li><para>
    /// The invoice ID that Amazon Web Services Invoicing issued for an invoice or a credit
    /// memo, in <c>invoiceIdentifier</c>.
    /// </para></li></ul><para>
    /// If you specify both or neither, the request fails with <c>ValidationException</c>.
    /// If no record on your account matches, the request fails with <c>ResourceNotFoundException</c>.
    /// </para><para>
    /// This operation provides strongly consistent reads.
    /// </para><para>
    /// To use this operation, you must have Amazon Web Services Identity and Access Management
    /// (IAM) permission for both <c>payments:GetFinancialRecord</c> and <c>payments:GetPaymentStatus</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PAYMFinancialRecord")]
    [OutputType("Amazon.Payments.Model.FinancialRecord")]
    [AWSCmdlet("Calls the AWS Payments GetFinancialRecord API operation.", Operation = new[] {"GetFinancialRecord"}, SelectReturnType = typeof(Amazon.Payments.Model.GetFinancialRecordResponse))]
    [AWSCmdletOutput("Amazon.Payments.Model.FinancialRecord or Amazon.Payments.Model.GetFinancialRecordResponse",
        "This cmdlet returns an Amazon.Payments.Model.FinancialRecord object.",
        "The service call response (type Amazon.Payments.Model.GetFinancialRecordResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPAYMFinancialRecordCmdlet : AmazonPaymentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The ID that Amazon Web Services Payments issued for the financial record, as returned
        /// in <c>id</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter InvoiceIdentifier
        /// <summary>
        /// <para>
        /// <para>The invoice ID that Amazon Web Services Invoicing issued for an invoice or a credit
        /// memo. The operation returns the record that has this invoice ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvoiceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FinancialRecord'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Payments.Model.GetFinancialRecordResponse).
        /// Specifying the name of a property of type Amazon.Payments.Model.GetFinancialRecordResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FinancialRecord";
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
                context.Select = CreateSelectDelegate<Amazon.Payments.Model.GetFinancialRecordResponse, GetPAYMFinancialRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Identifier = this.Identifier;
            context.InvoiceIdentifier = this.InvoiceIdentifier;
            
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
            var request = new Amazon.Payments.Model.GetFinancialRecordRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.InvoiceIdentifier != null)
            {
                request.InvoiceIdentifier = cmdletContext.InvoiceIdentifier;
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
        
        private Amazon.Payments.Model.GetFinancialRecordResponse CallAWSServiceOperation(IAmazonPayments client, Amazon.Payments.Model.GetFinancialRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Payments", "GetFinancialRecord");
            try
            {
                return client.GetFinancialRecordAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InvoiceIdentifier { get; set; }
            public System.Func<Amazon.Payments.Model.GetFinancialRecordResponse, GetPAYMFinancialRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FinancialRecord;
        }
        
    }
}
