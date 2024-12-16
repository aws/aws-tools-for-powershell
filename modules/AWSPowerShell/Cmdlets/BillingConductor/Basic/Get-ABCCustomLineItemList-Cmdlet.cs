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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// A paginated call to get a list of all custom line items (FFLIs) for the given billing
    /// period. If you don't provide a billing period, the current billing period is used.
    /// </summary>
    [Cmdlet("Get", "ABCCustomLineItemList")]
    [OutputType("Amazon.BillingConductor.Model.CustomLineItemListElement")]
    [AWSCmdlet("Calls the AWSBillingConductor ListCustomLineItems API operation.", Operation = new[] {"ListCustomLineItems"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.ListCustomLineItemsResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.CustomLineItemListElement or Amazon.BillingConductor.Model.ListCustomLineItemsResponse",
        "This cmdlet returns a collection of Amazon.BillingConductor.Model.CustomLineItemListElement objects.",
        "The service call response (type Amazon.BillingConductor.Model.ListCustomLineItemsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetABCCustomLineItemListCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services accounts in which this custom line item will be applied to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_AccountIds")]
        public System.String[] Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter Filters_Arn
        /// <summary>
        /// <para>
        /// <para>A list of custom line item ARNs to retrieve information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Arns")]
        public System.String[] Filters_Arn { get; set; }
        #endregion
        
        #region Parameter Filters_BillingGroup
        /// <summary>
        /// <para>
        /// <para>The billing group Amazon Resource Names (ARNs) to retrieve information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_BillingGroups")]
        public System.String[] Filters_BillingGroup { get; set; }
        #endregion
        
        #region Parameter BillingPeriod
        /// <summary>
        /// <para>
        /// <para> The preferred billing period to get custom line items (FFLIs). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BillingPeriod { get; set; }
        #endregion
        
        #region Parameter Filters_Name
        /// <summary>
        /// <para>
        /// <para>A list of custom line items to retrieve information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Names")]
        public System.String[] Filters_Name { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of billing groups to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The pagination token that's used on subsequent calls to get custom line items (FFLIs).
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomLineItems'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.ListCustomLineItemsResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.ListCustomLineItemsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomLineItems";
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
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListCustomLineItemsResponse, GetABCCustomLineItemListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingPeriod = this.BillingPeriod;
            if (this.Filters_AccountId != null)
            {
                context.Filters_AccountId = new List<System.String>(this.Filters_AccountId);
            }
            if (this.Filters_Arn != null)
            {
                context.Filters_Arn = new List<System.String>(this.Filters_Arn);
            }
            if (this.Filters_BillingGroup != null)
            {
                context.Filters_BillingGroup = new List<System.String>(this.Filters_BillingGroup);
            }
            if (this.Filters_Name != null)
            {
                context.Filters_Name = new List<System.String>(this.Filters_Name);
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
            var request = new Amazon.BillingConductor.Model.ListCustomLineItemsRequest();
            
            if (cmdletContext.BillingPeriod != null)
            {
                request.BillingPeriod = cmdletContext.BillingPeriod;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.BillingConductor.Model.ListCustomLineItemsFilter();
            List<System.String> requestFilters_filters_AccountId = null;
            if (cmdletContext.Filters_AccountId != null)
            {
                requestFilters_filters_AccountId = cmdletContext.Filters_AccountId;
            }
            if (requestFilters_filters_AccountId != null)
            {
                request.Filters.AccountIds = requestFilters_filters_AccountId;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Arn = null;
            if (cmdletContext.Filters_Arn != null)
            {
                requestFilters_filters_Arn = cmdletContext.Filters_Arn;
            }
            if (requestFilters_filters_Arn != null)
            {
                request.Filters.Arns = requestFilters_filters_Arn;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_BillingGroup = null;
            if (cmdletContext.Filters_BillingGroup != null)
            {
                requestFilters_filters_BillingGroup = cmdletContext.Filters_BillingGroup;
            }
            if (requestFilters_filters_BillingGroup != null)
            {
                request.Filters.BillingGroups = requestFilters_filters_BillingGroup;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Name = null;
            if (cmdletContext.Filters_Name != null)
            {
                requestFilters_filters_Name = cmdletContext.Filters_Name;
            }
            if (requestFilters_filters_Name != null)
            {
                request.Filters.Names = requestFilters_filters_Name;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
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
        
        private Amazon.BillingConductor.Model.ListCustomLineItemsResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListCustomLineItemsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListCustomLineItems");
            try
            {
                #if DESKTOP
                return client.ListCustomLineItems(request);
                #elif CORECLR
                return client.ListCustomLineItemsAsync(request).GetAwaiter().GetResult();
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
            public System.String BillingPeriod { get; set; }
            public List<System.String> Filters_AccountId { get; set; }
            public List<System.String> Filters_Arn { get; set; }
            public List<System.String> Filters_BillingGroup { get; set; }
            public List<System.String> Filters_Name { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BillingConductor.Model.ListCustomLineItemsResponse, GetABCCustomLineItemListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomLineItems;
        }
        
    }
}
