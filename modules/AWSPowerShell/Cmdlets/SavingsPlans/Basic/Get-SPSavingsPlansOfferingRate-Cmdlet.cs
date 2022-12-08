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
using Amazon.SavingsPlans;
using Amazon.SavingsPlans.Model;

namespace Amazon.PowerShell.Cmdlets.SP
{
    /// <summary>
    /// Describes the specified Savings Plans offering rates.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SPSavingsPlansOfferingRate")]
    [OutputType("Amazon.SavingsPlans.Model.SavingsPlanOfferingRate")]
    [AWSCmdlet("Calls the AWS Savings Plans DescribeSavingsPlansOfferingRates API operation.", Operation = new[] {"DescribeSavingsPlansOfferingRates"}, SelectReturnType = typeof(Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesResponse))]
    [AWSCmdletOutput("Amazon.SavingsPlans.Model.SavingsPlanOfferingRate or Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesResponse",
        "This cmdlet returns a collection of Amazon.SavingsPlans.Model.SavingsPlanOfferingRate objects.",
        "The service call response (type Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSPSavingsPlansOfferingRateCmdlet : AmazonSavingsPlansClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.SavingsPlans.Model.SavingsPlanOfferingRateFilterElement[] Filter { get; set; }
        #endregion
        
        #region Parameter Operation
        /// <summary>
        /// <para>
        /// <para>The specific AWS operation for the line item in the billing report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operations")]
        public System.String[] Operation { get; set; }
        #endregion
        
        #region Parameter Product
        /// <summary>
        /// <para>
        /// <para>The AWS products.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Products")]
        public System.String[] Product { get; set; }
        #endregion
        
        #region Parameter SavingsPlanOfferingId
        /// <summary>
        /// <para>
        /// <para>The IDs of the offerings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SavingsPlanOfferingIds")]
        public System.String[] SavingsPlanOfferingId { get; set; }
        #endregion
        
        #region Parameter SavingsPlanPaymentOption
        /// <summary>
        /// <para>
        /// <para>The payment options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SavingsPlanPaymentOptions")]
        public System.String[] SavingsPlanPaymentOption { get; set; }
        #endregion
        
        #region Parameter SavingsPlanType
        /// <summary>
        /// <para>
        /// <para>The plan types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SavingsPlanTypes")]
        public System.String[] SavingsPlanType { get; set; }
        #endregion
        
        #region Parameter ServiceCode
        /// <summary>
        /// <para>
        /// <para>The services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceCodes")]
        public System.String[] ServiceCode { get; set; }
        #endregion
        
        #region Parameter UsageType
        /// <summary>
        /// <para>
        /// <para>The usage details of the line item in the billing report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UsageTypes")]
        public System.String[] UsageType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve additional
        /// results, make another call with the returned token value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SearchResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesResponse).
        /// Specifying the name of a property of type Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SearchResults";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesResponse, GetSPSavingsPlansOfferingRateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.SavingsPlans.Model.SavingsPlanOfferingRateFilterElement>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.Operation != null)
            {
                context.Operation = new List<System.String>(this.Operation);
            }
            if (this.Product != null)
            {
                context.Product = new List<System.String>(this.Product);
            }
            if (this.SavingsPlanOfferingId != null)
            {
                context.SavingsPlanOfferingId = new List<System.String>(this.SavingsPlanOfferingId);
            }
            if (this.SavingsPlanPaymentOption != null)
            {
                context.SavingsPlanPaymentOption = new List<System.String>(this.SavingsPlanPaymentOption);
            }
            if (this.SavingsPlanType != null)
            {
                context.SavingsPlanType = new List<System.String>(this.SavingsPlanType);
            }
            if (this.ServiceCode != null)
            {
                context.ServiceCode = new List<System.String>(this.ServiceCode);
            }
            if (this.UsageType != null)
            {
                context.UsageType = new List<System.String>(this.UsageType);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Operation != null)
            {
                request.Operations = cmdletContext.Operation;
            }
            if (cmdletContext.Product != null)
            {
                request.Products = cmdletContext.Product;
            }
            if (cmdletContext.SavingsPlanOfferingId != null)
            {
                request.SavingsPlanOfferingIds = cmdletContext.SavingsPlanOfferingId;
            }
            if (cmdletContext.SavingsPlanPaymentOption != null)
            {
                request.SavingsPlanPaymentOptions = cmdletContext.SavingsPlanPaymentOption;
            }
            if (cmdletContext.SavingsPlanType != null)
            {
                request.SavingsPlanTypes = cmdletContext.SavingsPlanType;
            }
            if (cmdletContext.ServiceCode != null)
            {
                request.ServiceCodes = cmdletContext.ServiceCode;
            }
            if (cmdletContext.UsageType != null)
            {
                request.UsageTypes = cmdletContext.UsageType;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesResponse CallAWSServiceOperation(IAmazonSavingsPlans client, Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Savings Plans", "DescribeSavingsPlansOfferingRates");
            try
            {
                #if DESKTOP
                return client.DescribeSavingsPlansOfferingRates(request);
                #elif CORECLR
                return client.DescribeSavingsPlansOfferingRatesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SavingsPlans.Model.SavingsPlanOfferingRateFilterElement> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Operation { get; set; }
            public List<System.String> Product { get; set; }
            public List<System.String> SavingsPlanOfferingId { get; set; }
            public List<System.String> SavingsPlanPaymentOption { get; set; }
            public List<System.String> SavingsPlanType { get; set; }
            public List<System.String> ServiceCode { get; set; }
            public List<System.String> UsageType { get; set; }
            public System.Func<Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingRatesResponse, GetSPSavingsPlansOfferingRateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SearchResults;
        }
        
    }
}
