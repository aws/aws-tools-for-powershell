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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// A paginated call to retrieve a list of billing groups for the given billing period.
    /// If you don't provide a billing group, the current billing period is used.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
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
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_Arn
        /// <summary>
        /// <para>
        /// <para>The list of billing group Amazon Resource Names (ARNs) to retrieve information.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter Filters_BillingGroupType
        /// <summary>
        /// <para>
        /// <para> Filter billing groups by their type. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_BillingGroupTypes")]
        public System.String[] Filters_BillingGroupType { get; set; }
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
        
        #region Parameter Filters_Name
        /// <summary>
        /// <para>
        /// <para> Filter billing groups by their names. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Names")]
        public Amazon.BillingConductor.Model.StringSearch[] Filters_Name { get; set; }
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
        
        #region Parameter Filters_PrimaryAccountId
        /// <summary>
        /// <para>
        /// <para> A list of primary account IDs to filter the billing groups. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_PrimaryAccountIds")]
        public System.String[] Filters_PrimaryAccountId { get; set; }
        #endregion
        
        #region Parameter Filters_ResponsibilityTransferArn
        /// <summary>
        /// <para>
        /// <para> Filter billing groups by their responsibility transfer ARNs. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ResponsibilityTransferArns")]
        public System.String[] Filters_ResponsibilityTransferArn { get; set; }
        #endregion
        
        #region Parameter Filters_Status
        /// <summary>
        /// <para>
        /// <para> A list of billing groups to retrieve their current status for a specific time range
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that's used on subsequent calls to get billing groups. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListBillingGroupsResponse, GetABCBillingGroupListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingPeriod = this.BillingPeriod;
            if (this.Filters_Arn != null)
            {
                context.Filters_Arn = new List<System.String>(this.Filters_Arn);
            }
            context.Filters_AutoAssociate = this.Filters_AutoAssociate;
            if (this.Filters_BillingGroupType != null)
            {
                context.Filters_BillingGroupType = new List<System.String>(this.Filters_BillingGroupType);
            }
            if (this.Filters_Name != null)
            {
                context.Filters_Name = new List<Amazon.BillingConductor.Model.StringSearch>(this.Filters_Name);
            }
            context.Filters_PricingPlan = this.Filters_PricingPlan;
            if (this.Filters_PrimaryAccountId != null)
            {
                context.Filters_PrimaryAccountId = new List<System.String>(this.Filters_PrimaryAccountId);
            }
            if (this.Filters_ResponsibilityTransferArn != null)
            {
                context.Filters_ResponsibilityTransferArn = new List<System.String>(this.Filters_ResponsibilityTransferArn);
            }
            if (this.Filters_Status != null)
            {
                context.Filters_Status = new List<System.String>(this.Filters_Status);
            }
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
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
            List<System.String> requestFilters_filters_BillingGroupType = null;
            if (cmdletContext.Filters_BillingGroupType != null)
            {
                requestFilters_filters_BillingGroupType = cmdletContext.Filters_BillingGroupType;
            }
            if (requestFilters_filters_BillingGroupType != null)
            {
                request.Filters.BillingGroupTypes = requestFilters_filters_BillingGroupType;
                requestFiltersIsNull = false;
            }
            List<Amazon.BillingConductor.Model.StringSearch> requestFilters_filters_Name = null;
            if (cmdletContext.Filters_Name != null)
            {
                requestFilters_filters_Name = cmdletContext.Filters_Name;
            }
            if (requestFilters_filters_Name != null)
            {
                request.Filters.Names = requestFilters_filters_Name;
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
            List<System.String> requestFilters_filters_PrimaryAccountId = null;
            if (cmdletContext.Filters_PrimaryAccountId != null)
            {
                requestFilters_filters_PrimaryAccountId = cmdletContext.Filters_PrimaryAccountId;
            }
            if (requestFilters_filters_PrimaryAccountId != null)
            {
                request.Filters.PrimaryAccountIds = requestFilters_filters_PrimaryAccountId;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_ResponsibilityTransferArn = null;
            if (cmdletContext.Filters_ResponsibilityTransferArn != null)
            {
                requestFilters_filters_ResponsibilityTransferArn = cmdletContext.Filters_ResponsibilityTransferArn;
            }
            if (requestFilters_filters_ResponsibilityTransferArn != null)
            {
                request.Filters.ResponsibilityTransferArns = requestFilters_filters_ResponsibilityTransferArn;
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
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.BillingConductor.Model.ListBillingGroupsResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListBillingGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListBillingGroups");
            try
            {
                return client.ListBillingGroupsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Filters_BillingGroupType { get; set; }
            public List<Amazon.BillingConductor.Model.StringSearch> Filters_Name { get; set; }
            public System.String Filters_PricingPlan { get; set; }
            public List<System.String> Filters_PrimaryAccountId { get; set; }
            public List<System.String> Filters_ResponsibilityTransferArn { get; set; }
            public List<System.String> Filters_Status { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BillingConductor.Model.ListBillingGroupsResponse, GetABCBillingGroupListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BillingGroups;
        }
        
    }
}
