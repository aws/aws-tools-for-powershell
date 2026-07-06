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
using Amazon.Billing;
using Amazon.Billing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AWSB
{
    /// <summary>
    /// Returns the list of Amazon Web Services account credits for the specified account.
    /// Each credit includes its identifier, type, monetary amounts, applicable products,
    /// expiration, sharing configuration, and current enabled status.
    /// 
    ///  
    /// <para>
    /// When the caller is the management account of a consolidated billing family and <c>payerAccountFlag</c>
    /// is <c>true</c>, the response aggregates credits across the entire family. Otherwise,
    /// the response includes only credits owned by the account specified in <c>accountId</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSBCredit")]
    [OutputType("Amazon.Billing.Model.CreditData")]
    [AWSCmdlet("Calls the AWS Billing GetCredits API operation.", Operation = new[] {"GetCredits"}, SelectReturnType = typeof(Amazon.Billing.Model.GetCreditsResponse))]
    [AWSCmdletOutput("Amazon.Billing.Model.CreditData or Amazon.Billing.Model.GetCreditsResponse",
        "This cmdlet returns a collection of Amazon.Billing.Model.CreditData objects.",
        "The service call response (type Amazon.Billing.Model.GetCreditsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAWSBCreditCmdlet : AmazonBillingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID. Must be a 12-digit numeric string.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The end date for the credit period as Unix epoch seconds. Must not be a future date
        /// and must be on or after <c>startDate</c>. Defaults to the current date when omitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter PayerAccountFlag
        /// <summary>
        /// <para>
        /// <para>When <c>true</c> and the caller is the management account, the response aggregates
        /// credits across the entire consolidated billing family. When <c>false</c> or omitted,
        /// returns only credits for the specified <c>accountId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PayerAccountFlag { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The start date for the credit period as Unix epoch seconds. Must be a past date that
        /// is not more than one year before the current date.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartDate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Credits'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Billing.Model.GetCreditsResponse).
        /// Specifying the name of a property of type Amazon.Billing.Model.GetCreditsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Credits";
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
                context.Select = CreateSelectDelegate<Amazon.Billing.Model.GetCreditsResponse, GetAWSBCreditCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndDate = this.EndDate;
            context.PayerAccountFlag = this.PayerAccountFlag;
            context.StartDate = this.StartDate;
            #if MODULAR
            if (this.StartDate == null && ParameterWasBound(nameof(this.StartDate)))
            {
                WriteWarning("You are passing $null as a value for parameter StartDate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Billing.Model.GetCreditsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.PayerAccountFlag != null)
            {
                request.PayerAccountFlag = cmdletContext.PayerAccountFlag.Value;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
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
        
        private Amazon.Billing.Model.GetCreditsResponse CallAWSServiceOperation(IAmazonBilling client, Amazon.Billing.Model.GetCreditsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing", "GetCredits");
            try
            {
                return client.GetCreditsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.DateTime? EndDate { get; set; }
            public System.Boolean? PayerAccountFlag { get; set; }
            public System.DateTime? StartDate { get; set; }
            public System.Func<Amazon.Billing.Model.GetCreditsResponse, GetAWSBCreditCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Credits;
        }
        
    }
}
