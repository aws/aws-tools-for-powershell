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
    /// Describes the offerings for the specified Savings Plans.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SPSavingsPlansOffering")]
    [OutputType("Amazon.SavingsPlans.Model.SavingsPlanOffering")]
    [AWSCmdlet("Calls the AWS Savings Plans DescribeSavingsPlansOfferings API operation.", Operation = new[] {"DescribeSavingsPlansOfferings"}, SelectReturnType = typeof(Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsResponse))]
    [AWSCmdletOutput("Amazon.SavingsPlans.Model.SavingsPlanOffering or Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsResponse",
        "This cmdlet returns a collection of Amazon.SavingsPlans.Model.SavingsPlanOffering objects.",
        "The service call response (type Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSPSavingsPlansOfferingCmdlet : AmazonSavingsPlansClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Currency
        /// <summary>
        /// <para>
        /// <para>The currencies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Currencies")]
        public System.String[] Currency { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The descriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptions")]
        public System.String[] Description { get; set; }
        #endregion
        
        #region Parameter Duration
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Durations")]
        public System.Int64[] Duration { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.SavingsPlans.Model.SavingsPlanOfferingFilterElement[] Filter { get; set; }
        #endregion
        
        #region Parameter OfferingId
        /// <summary>
        /// <para>
        /// <para>The IDs of the offerings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OfferingIds")]
        public System.String[] OfferingId { get; set; }
        #endregion
        
        #region Parameter Operation
        /// <summary>
        /// <para>
        /// <para>The specific Amazon Web Services operation for the line item in the billing report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operations")]
        public System.String[] Operation { get; set; }
        #endregion
        
        #region Parameter PaymentOption
        /// <summary>
        /// <para>
        /// <para>The payment options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PaymentOptions")]
        public System.String[] PaymentOption { get; set; }
        #endregion
        
        #region Parameter PlanType
        /// <summary>
        /// <para>
        /// <para>The plan types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlanTypes")]
        public System.String[] PlanType { get; set; }
        #endregion
        
        #region Parameter ProductType
        /// <summary>
        /// <para>
        /// <para>The product type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SavingsPlans.SavingsPlanProductType")]
        public Amazon.SavingsPlans.SavingsPlanProductType ProductType { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsResponse).
        /// Specifying the name of a property of type Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsResponse, GetSPSavingsPlansOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Currency != null)
            {
                context.Currency = new List<System.String>(this.Currency);
            }
            if (this.Description != null)
            {
                context.Description = new List<System.String>(this.Description);
            }
            if (this.Duration != null)
            {
                context.Duration = new List<System.Int64>(this.Duration);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.SavingsPlans.Model.SavingsPlanOfferingFilterElement>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.OfferingId != null)
            {
                context.OfferingId = new List<System.String>(this.OfferingId);
            }
            if (this.Operation != null)
            {
                context.Operation = new List<System.String>(this.Operation);
            }
            if (this.PaymentOption != null)
            {
                context.PaymentOption = new List<System.String>(this.PaymentOption);
            }
            if (this.PlanType != null)
            {
                context.PlanType = new List<System.String>(this.PlanType);
            }
            context.ProductType = this.ProductType;
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
            var request = new Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsRequest();
            
            if (cmdletContext.Currency != null)
            {
                request.Currencies = cmdletContext.Currency;
            }
            if (cmdletContext.Description != null)
            {
                request.Descriptions = cmdletContext.Description;
            }
            if (cmdletContext.Duration != null)
            {
                request.Durations = cmdletContext.Duration;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OfferingId != null)
            {
                request.OfferingIds = cmdletContext.OfferingId;
            }
            if (cmdletContext.Operation != null)
            {
                request.Operations = cmdletContext.Operation;
            }
            if (cmdletContext.PaymentOption != null)
            {
                request.PaymentOptions = cmdletContext.PaymentOption;
            }
            if (cmdletContext.PlanType != null)
            {
                request.PlanTypes = cmdletContext.PlanType;
            }
            if (cmdletContext.ProductType != null)
            {
                request.ProductType = cmdletContext.ProductType;
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
        
        private Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsResponse CallAWSServiceOperation(IAmazonSavingsPlans client, Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Savings Plans", "DescribeSavingsPlansOfferings");
            try
            {
                #if DESKTOP
                return client.DescribeSavingsPlansOfferings(request);
                #elif CORECLR
                return client.DescribeSavingsPlansOfferingsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Currency { get; set; }
            public List<System.String> Description { get; set; }
            public List<System.Int64> Duration { get; set; }
            public List<Amazon.SavingsPlans.Model.SavingsPlanOfferingFilterElement> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> OfferingId { get; set; }
            public List<System.String> Operation { get; set; }
            public List<System.String> PaymentOption { get; set; }
            public List<System.String> PlanType { get; set; }
            public Amazon.SavingsPlans.SavingsPlanProductType ProductType { get; set; }
            public List<System.String> ServiceCode { get; set; }
            public List<System.String> UsageType { get; set; }
            public System.Func<Amazon.SavingsPlans.Model.DescribeSavingsPlansOfferingsResponse, GetSPSavingsPlansOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SearchResults;
        }
        
    }
}
