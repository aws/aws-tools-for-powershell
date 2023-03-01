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
using Amazon.Pricing;
using Amazon.Pricing.Model;

namespace Amazon.PowerShell.Cmdlets.PLS
{
    /// <summary>
    /// <i><b>This feature is in preview release and is subject to change. Your use of Amazon
    /// Web Services Price List API is subject to the Beta Service Participation terms of
    /// the <a href="https://aws.amazon.com/service-terms/">Amazon Web Services Service Terms</a>
    /// (Section 1.10).</b></i><para>
    /// This returns a list of Price List references that the requester if authorized to view,
    /// given a <code>ServiceCode</code>, <code>CurrencyCode</code>, and an <code>EffectiveDate</code>.
    /// Use without a <code>RegionCode</code> filter to list Price List references from all
    /// available Amazon Web Services Regions. Use with a <code>RegionCode</code> filter to
    /// get the Price List reference that's specific to a specific Amazon Web Services Region.
    /// You can use the <code>PriceListArn</code> from the response to get your preferred
    /// Price List files through the <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_pricing_GetPriceListFileUrl.html"><code>GetPriceListFileUrl</code></a> API.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "PLSPriceListList")]
    [OutputType("Amazon.Pricing.Model.PriceList")]
    [AWSCmdlet("Calls the AWS Price List Service ListPriceLists API operation.", Operation = new[] {"ListPriceLists"}, SelectReturnType = typeof(Amazon.Pricing.Model.ListPriceListsResponse))]
    [AWSCmdletOutput("Amazon.Pricing.Model.PriceList or Amazon.Pricing.Model.ListPriceListsResponse",
        "This cmdlet returns a collection of Amazon.Pricing.Model.PriceList objects.",
        "The service call response (type Amazon.Pricing.Model.ListPriceListsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPLSPriceListListCmdlet : AmazonPricingClientCmdlet, IExecutor
    {
        
        #region Parameter CurrencyCode
        /// <summary>
        /// <para>
        /// <para>The three alphabetical character ISO-4217 currency code that the Price List files
        /// are denominated in. </para>
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
        public System.String CurrencyCode { get; set; }
        #endregion
        
        #region Parameter EffectiveDate
        /// <summary>
        /// <para>
        /// <para>The date that the Price List file prices are effective from. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EffectiveDate { get; set; }
        #endregion
        
        #region Parameter RegionCode
        /// <summary>
        /// <para>
        /// <para>This is used to filter the Price List by Amazon Web Services Region. For example,
        /// to get the price list only for the <code>US East (N. Virginia)</code> Region, use
        /// <code>us-east-1</code>. If nothing is specified, you retrieve price lists for all
        /// applicable Regions. The available <code>RegionCode</code> list can be retrieved from
        /// <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_pricing_GetAttributeValues.html"><code>GetAttributeValues</code></a> API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegionCode { get; set; }
        #endregion
        
        #region Parameter ServiceCode
        /// <summary>
        /// <para>
        /// <para>The service code or the Savings Plan service code for the attributes that you want
        /// to retrieve. For example, to get the list of applicable Amazon EC2 price lists, use
        /// <code>AmazonEC2</code>. For a full list of service codes containing On-Demand and
        /// Reserved Instance (RI) pricing, use the <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_pricing_DescribeServices.html#awscostmanagement-pricing_DescribeServices-request-FormatVersion"><code>DescribeServices</code></a> API.</para><para>To retrieve the Compute Savings Plan price lists, use <code>ComputeSavingsPlans</code>.
        /// To retrieve Machine Learning Savings Plans price lists, use <code>MachineLearningSavingsPlans</code>.
        /// </para>
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
        public System.String ServiceCode { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in the response. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results that you want to retrieve.
        /// </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PriceLists'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pricing.Model.ListPriceListsResponse).
        /// Specifying the name of a property of type Amazon.Pricing.Model.ListPriceListsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PriceLists";
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
                context.Select = CreateSelectDelegate<Amazon.Pricing.Model.ListPriceListsResponse, GetPLSPriceListListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CurrencyCode = this.CurrencyCode;
            #if MODULAR
            if (this.CurrencyCode == null && ParameterWasBound(nameof(this.CurrencyCode)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrencyCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EffectiveDate = this.EffectiveDate;
            #if MODULAR
            if (this.EffectiveDate == null && ParameterWasBound(nameof(this.EffectiveDate)))
            {
                WriteWarning("You are passing $null as a value for parameter EffectiveDate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RegionCode = this.RegionCode;
            context.ServiceCode = this.ServiceCode;
            #if MODULAR
            if (this.ServiceCode == null && ParameterWasBound(nameof(this.ServiceCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Pricing.Model.ListPriceListsRequest();
            
            if (cmdletContext.CurrencyCode != null)
            {
                request.CurrencyCode = cmdletContext.CurrencyCode;
            }
            if (cmdletContext.EffectiveDate != null)
            {
                request.EffectiveDate = cmdletContext.EffectiveDate.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.RegionCode != null)
            {
                request.RegionCode = cmdletContext.RegionCode;
            }
            if (cmdletContext.ServiceCode != null)
            {
                request.ServiceCode = cmdletContext.ServiceCode;
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
        
        private Amazon.Pricing.Model.ListPriceListsResponse CallAWSServiceOperation(IAmazonPricing client, Amazon.Pricing.Model.ListPriceListsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Price List Service", "ListPriceLists");
            try
            {
                #if DESKTOP
                return client.ListPriceLists(request);
                #elif CORECLR
                return client.ListPriceListsAsync(request).GetAwaiter().GetResult();
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
            public System.String CurrencyCode { get; set; }
            public System.DateTime? EffectiveDate { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String RegionCode { get; set; }
            public System.String ServiceCode { get; set; }
            public System.Func<Amazon.Pricing.Model.ListPriceListsResponse, GetPLSPriceListListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PriceLists;
        }
        
    }
}
