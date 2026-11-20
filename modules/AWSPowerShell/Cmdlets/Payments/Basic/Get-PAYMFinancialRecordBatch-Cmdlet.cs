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
    /// Retrieves up to 100 financial records in one request, including the details that are
    /// specific to each record's type. Identify each record by its ID or by its invoice ID.
    /// Results can be partial: each key that you request appears once in the response, either
    /// as a record in <c>financialRecords</c> or as an error in <c>errors</c>. A key that
    /// matches no record on your account is returned in <c>errors</c> and doesn't fail the
    /// request. This operation provides strongly consistent reads.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have Amazon Web Services Identity and Access Management
    /// (IAM) permission for both <c>payments:BatchGetFinancialRecord</c> and <c>payments:GetPaymentStatus</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PAYMFinancialRecordBatch")]
    [OutputType("Amazon.Payments.Model.BatchGetFinancialRecordResponse")]
    [AWSCmdlet("Calls the AWS Payments BatchGetFinancialRecord API operation.", Operation = new[] {"BatchGetFinancialRecord"}, SelectReturnType = typeof(Amazon.Payments.Model.BatchGetFinancialRecordResponse))]
    [AWSCmdletOutput("Amazon.Payments.Model.BatchGetFinancialRecordResponse",
        "This cmdlet returns an Amazon.Payments.Model.BatchGetFinancialRecordResponse object containing multiple properties."
    )]
    public partial class GetPAYMFinancialRecordBatchCmdlet : AmazonPaymentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The keys of the financial records to retrieve. Each key is either the record's ID
        /// or its invoice ID.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Keys")]
        public Amazon.Payments.Model.FinancialRecordKey[] Key { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Payments.Model.BatchGetFinancialRecordResponse).
        /// Specifying the name of a property of type Amazon.Payments.Model.BatchGetFinancialRecordResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Payments.Model.BatchGetFinancialRecordResponse, GetPAYMFinancialRecordBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Key != null)
            {
                context.Key = new List<Amazon.Payments.Model.FinancialRecordKey>(this.Key);
            }
            #if MODULAR
            if (this.Key == null && ParameterWasBound(nameof(this.Key)))
            {
                WriteWarning("You are passing $null as a value for parameter Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Payments.Model.BatchGetFinancialRecordRequest();
            
            if (cmdletContext.Key != null)
            {
                request.Keys = cmdletContext.Key;
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
        
        private Amazon.Payments.Model.BatchGetFinancialRecordResponse CallAWSServiceOperation(IAmazonPayments client, Amazon.Payments.Model.BatchGetFinancialRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Payments", "BatchGetFinancialRecord");
            try
            {
                return client.BatchGetFinancialRecordAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Payments.Model.FinancialRecordKey> Key { get; set; }
            public System.Func<Amazon.Payments.Model.BatchGetFinancialRecordResponse, GetPAYMFinancialRecordBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
