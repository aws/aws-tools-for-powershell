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
    /// A paginated call to retrieve a list of billing groups for the given billing period.
    /// If you don't provide a billing group, the current billing period is used.
    /// </summary>
    [Cmdlet("Get", "ABCBillingGroupList")]
    [OutputType("Amazon.BillingConductor.Model.BillingGroupListElement")]
    [AWSCmdlet("Calls the AWSBillingConductor ListBillingGroups API operation.", Operation = new[] {"ListBillingGroups"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.ListBillingGroupsResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.BillingGroupListElement or Amazon.BillingConductor.Model.ListBillingGroupsResponse",
        "This cmdlet returns a collection of Amazon.BillingConductor.Model.BillingGroupListElement objects.",
        "The service call response (type Amazon.BillingConductor.Model.ListBillingGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetABCBillingGroupListCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_Arn
        /// <summary>
        /// <para>
        /// <para>The list of billing group Amazon Resource Names (ARNs) to retrieve information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Arns")]
        public System.String[] Filters_Arn { get; set; }
        #endregion
        
        #region Parameter Filters_AutoAssociate
        /// <summary>
        /// <para>
        /// <para>Specifies if this billing group will automatically associate newly added Amazon Web
        /// Services accounts that join your consolidated billing family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Filters_AutoAssociate { get; set; }
        #endregion
        
        #region Parameter BillingPeriod
        /// <summary>
        /// <para>
        /// <para>The preferred billing period to get billing groups. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BillingPeriod { get; set; }
        #endregion
        
        #region Parameter Filters_PricingPlan
        /// <summary>
        /// <para>
        /// <para>The pricing plan Amazon Resource Names (ARNs) to retrieve information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_PricingPlan { get; set; }
        #endregion
        
        #region Parameter Filters_Status
        /// <summary>
        /// <para>
        /// <para> A list of billing groups to retrieve their current status for a specific time range
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Statuses")]
        public System.String[] Filters_Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of billing groups to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that's used on subsequent calls to get billing groups. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BillingGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.ListBillingGroupsResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.ListBillingGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BillingGroups";
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
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListBillingGroupsResponse, GetABCBillingGroupListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingPeriod = this.BillingPeriod;
            if (this.Filters_Arn != null)
            {
                context.Filters_Arn = new List<System.String>(this.Filters_Arn);
            }
            context.Filters_AutoAssociate = this.Filters_AutoAssociate;
            context.Filters_PricingPlan = this.Filters_PricingPlan;
            if (this.Filters_Status != null)
            {
                context.Filters_Status = new List<System.String>(this.Filters_Status);
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
            var request = new Amazon.BillingConductor.Model.ListBillingGroupsRequest();
            
            if (cmdletContext.BillingPeriod != null)
            {
                request.BillingPeriod = cmdletContext.BillingPeriod;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.BillingConductor.Model.ListBillingGroupsFilter();
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
            System.Boolean? requestFilters_filters_AutoAssociate = null;
            if (cmdletContext.Filters_AutoAssociate != null)
            {
                requestFilters_filters_AutoAssociate = cmdletContext.Filters_AutoAssociate.Value;
            }
            if (requestFilters_filters_AutoAssociate != null)
            {
                request.Filters.AutoAssociate = requestFilters_filters_AutoAssociate.Value;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_PricingPlan = null;
            if (cmdletContext.Filters_PricingPlan != null)
            {
                requestFilters_filters_PricingPlan = cmdletContext.Filters_PricingPlan;
            }
            if (requestFilters_filters_PricingPlan != null)
            {
                request.Filters.PricingPlan = requestFilters_filters_PricingPlan;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Status = null;
            if (cmdletContext.Filters_Status != null)
            {
                requestFilters_filters_Status = cmdletContext.Filters_Status;
            }
            if (requestFilters_filters_Status != null)
            {
                request.Filters.Statuses = requestFilters_filters_Status;
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
        
        private Amazon.BillingConductor.Model.ListBillingGroupsResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListBillingGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListBillingGroups");
            try
            {
                #if DESKTOP
                return client.ListBillingGroups(request);
                #elif CORECLR
                return client.ListBillingGroupsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filters_Arn { get; set; }
            public System.Boolean? Filters_AutoAssociate { get; set; }
            public System.String Filters_PricingPlan { get; set; }
            public List<System.String> Filters_Status { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BillingConductor.Model.ListBillingGroupsResponse, GetABCBillingGroupListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BillingGroups;
        }
        
    }
}
