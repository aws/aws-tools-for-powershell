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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// Retrieves the margin summary report, which includes the Amazon Web Services cost and
    /// charged amount (pro forma cost) by Amazon Web Service for a specific billing group.
    /// </summary>
    [Cmdlet("Get", "ABCBillingGroupCostReport")]
    [OutputType("Amazon.BillingConductor.Model.BillingGroupCostReportResultElement")]
    [AWSCmdlet("Calls the AWSBillingConductor GetBillingGroupCostReport API operation.", Operation = new[] {"GetBillingGroupCostReport"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.GetBillingGroupCostReportResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.BillingGroupCostReportResultElement or Amazon.BillingConductor.Model.GetBillingGroupCostReportResponse",
        "This cmdlet returns a collection of Amazon.BillingConductor.Model.BillingGroupCostReportResultElement objects.",
        "The service call response (type Amazon.BillingConductor.Model.GetBillingGroupCostReportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetABCBillingGroupCostReportCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) that uniquely identifies the billing group.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_ExclusiveEndBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The exclusive end billing period that defines a billing period range for the margin
        /// summary. For example, if you choose a billing period that starts in October 2023 and
        /// ends in December 2023, the margin summary will only include data from October 2023
        /// and November 2023.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingPeriodRange_ExclusiveEndBillingPeriod { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>A list of strings that specify the attributes that are used to break down costs in
        /// the margin summary reports for the billing group. For example, you can view your costs
        /// by the Amazon Web Service name or the billing period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] GroupBy { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_InclusiveStartBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The inclusive start billing period that defines a billing period range for the margin
        /// summary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingPeriodRange_InclusiveStartBillingPeriod { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of margin summary reports to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token used on subsequent calls to get reports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BillingGroupCostReportResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.GetBillingGroupCostReportResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.GetBillingGroupCostReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BillingGroupCostReportResults";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.GetBillingGroupCostReportResponse, GetABCBillingGroupCostReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BillingPeriodRange_ExclusiveEndBillingPeriod = this.BillingPeriodRange_ExclusiveEndBillingPeriod;
            context.BillingPeriodRange_InclusiveStartBillingPeriod = this.BillingPeriodRange_InclusiveStartBillingPeriod;
            if (this.GroupBy != null)
            {
                context.GroupBy = new List<System.String>(this.GroupBy);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.BillingConductor.Model.GetBillingGroupCostReportRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate BillingPeriodRange
            var requestBillingPeriodRangeIsNull = true;
            request.BillingPeriodRange = new Amazon.BillingConductor.Model.BillingPeriodRange();
            System.String requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_ExclusiveEndBillingPeriod != null)
            {
                requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod = cmdletContext.BillingPeriodRange_ExclusiveEndBillingPeriod;
            }
            if (requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod != null)
            {
                request.BillingPeriodRange.ExclusiveEndBillingPeriod = requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod;
                requestBillingPeriodRangeIsNull = false;
            }
            System.String requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_InclusiveStartBillingPeriod != null)
            {
                requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod = cmdletContext.BillingPeriodRange_InclusiveStartBillingPeriod;
            }
            if (requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod != null)
            {
                request.BillingPeriodRange.InclusiveStartBillingPeriod = requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod;
                requestBillingPeriodRangeIsNull = false;
            }
             // determine if request.BillingPeriodRange should be set to null
            if (requestBillingPeriodRangeIsNull)
            {
                request.BillingPeriodRange = null;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.BillingConductor.Model.GetBillingGroupCostReportResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.GetBillingGroupCostReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "GetBillingGroupCostReport");
            try
            {
                #if DESKTOP
                return client.GetBillingGroupCostReport(request);
                #elif CORECLR
                return client.GetBillingGroupCostReportAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String BillingPeriodRange_ExclusiveEndBillingPeriod { get; set; }
            public System.String BillingPeriodRange_InclusiveStartBillingPeriod { get; set; }
            public List<System.String> GroupBy { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BillingConductor.Model.GetBillingGroupCostReportResponse, GetABCBillingGroupCostReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BillingGroupCostReportResults;
        }
        
    }
}
