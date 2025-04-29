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
using Amazon.ConnectCampaignsV2;
using Amazon.ConnectCampaignsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCS2
{
    /// <summary>
    /// Provides summary information about the campaigns under the specified Amazon Connect
    /// account.
    /// </summary>
    [Cmdlet("Get", "CCS2CampaignList")]
    [OutputType("Amazon.ConnectCampaignsV2.Model.CampaignSummary")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 ListCampaigns API operation.", Operation = new[] {"ListCampaigns"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.ListCampaignsResponse))]
    [AWSCmdletOutput("Amazon.ConnectCampaignsV2.Model.CampaignSummary or Amazon.ConnectCampaignsV2.Model.ListCampaignsResponse",
        "This cmdlet returns a collection of Amazon.ConnectCampaignsV2.Model.CampaignSummary objects.",
        "The service call response (type Amazon.ConnectCampaignsV2.Model.ListCampaignsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCCS2CampaignListCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceIdFilter_Operator
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_InstanceIdFilter_Operator")]
        [AWSConstantClassSource("Amazon.ConnectCampaignsV2.InstanceIdFilterOperator")]
        public Amazon.ConnectCampaignsV2.InstanceIdFilterOperator InstanceIdFilter_Operator { get; set; }
        #endregion
        
        #region Parameter InstanceIdFilter_Value
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_InstanceIdFilter_Value")]
        public System.String InstanceIdFilter_Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CampaignSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.ListCampaignsResponse).
        /// Specifying the name of a property of type Amazon.ConnectCampaignsV2.Model.ListCampaignsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CampaignSummaryList";
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
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.ListCampaignsResponse, GetCCS2CampaignListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceIdFilter_Operator = this.InstanceIdFilter_Operator;
            context.InstanceIdFilter_Value = this.InstanceIdFilter_Value;
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
            var request = new Amazon.ConnectCampaignsV2.Model.ListCampaignsRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConnectCampaignsV2.Model.CampaignFilters();
            Amazon.ConnectCampaignsV2.Model.InstanceIdFilter requestFilters_filters_InstanceIdFilter = null;
            
             // populate InstanceIdFilter
            var requestFilters_filters_InstanceIdFilterIsNull = true;
            requestFilters_filters_InstanceIdFilter = new Amazon.ConnectCampaignsV2.Model.InstanceIdFilter();
            Amazon.ConnectCampaignsV2.InstanceIdFilterOperator requestFilters_filters_InstanceIdFilter_instanceIdFilter_Operator = null;
            if (cmdletContext.InstanceIdFilter_Operator != null)
            {
                requestFilters_filters_InstanceIdFilter_instanceIdFilter_Operator = cmdletContext.InstanceIdFilter_Operator;
            }
            if (requestFilters_filters_InstanceIdFilter_instanceIdFilter_Operator != null)
            {
                requestFilters_filters_InstanceIdFilter.Operator = requestFilters_filters_InstanceIdFilter_instanceIdFilter_Operator;
                requestFilters_filters_InstanceIdFilterIsNull = false;
            }
            System.String requestFilters_filters_InstanceIdFilter_instanceIdFilter_Value = null;
            if (cmdletContext.InstanceIdFilter_Value != null)
            {
                requestFilters_filters_InstanceIdFilter_instanceIdFilter_Value = cmdletContext.InstanceIdFilter_Value;
            }
            if (requestFilters_filters_InstanceIdFilter_instanceIdFilter_Value != null)
            {
                requestFilters_filters_InstanceIdFilter.Value = requestFilters_filters_InstanceIdFilter_instanceIdFilter_Value;
                requestFilters_filters_InstanceIdFilterIsNull = false;
            }
             // determine if requestFilters_filters_InstanceIdFilter should be set to null
            if (requestFilters_filters_InstanceIdFilterIsNull)
            {
                requestFilters_filters_InstanceIdFilter = null;
            }
            if (requestFilters_filters_InstanceIdFilter != null)
            {
                request.Filters.InstanceIdFilter = requestFilters_filters_InstanceIdFilter;
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
        
        private Amazon.ConnectCampaignsV2.Model.ListCampaignsResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.ListCampaignsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "ListCampaigns");
            try
            {
                return client.ListCampaignsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ConnectCampaignsV2.InstanceIdFilterOperator InstanceIdFilter_Operator { get; set; }
            public System.String InstanceIdFilter_Value { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.ListCampaignsResponse, GetCCS2CampaignListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CampaignSummaryList;
        }
        
    }
}
