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
using Amazon.ComputeOptimizerAutomation;
using Amazon.ComputeOptimizerAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.COA
{
    /// <summary>
    /// Returns a summary of the recommended actions that match your rule preview configuration
    /// and criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "COAAutomationRulePreviewSummaryList")]
    [OutputType("Amazon.ComputeOptimizerAutomation.Model.PreviewResultSummary")]
    [AWSCmdlet("Calls the Compute Optimizer Automation Service ListAutomationRulePreviewSummaries API operation.", Operation = new[] {"ListAutomationRulePreviewSummaries"}, SelectReturnType = typeof(Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizerAutomation.Model.PreviewResultSummary or Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesResponse",
        "This cmdlet returns a collection of Amazon.ComputeOptimizerAutomation.Model.PreviewResultSummary objects.",
        "The service call response (type Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCOAAutomationRulePreviewSummaryListCmdlet : AmazonComputeOptimizerAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OrganizationScope_AccountId
        /// <summary>
        /// <para>
        /// <para>List of Amazon Web Services account IDs to include in the organization scope.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationScope_AccountIds")]
        public System.String[] OrganizationScope_AccountId { get; set; }
        #endregion
        
        #region Parameter Criteria_EbsVolumeSizeInGib
        /// <summary>
        /// <para>
        /// <para>Filter criteria for EBS volume sizes in gibibytes (GiB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition[] Criteria_EbsVolumeSizeInGib { get; set; }
        #endregion
        
        #region Parameter Criteria_EbsVolumeType
        /// <summary>
        /// <para>
        /// <para>Filter criteria for EBS volume types, such as gp2, gp3, io1, io2, st1, or sc1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition[] Criteria_EbsVolumeType { get; set; }
        #endregion
        
        #region Parameter Criteria_EstimatedMonthlySaving
        /// <summary>
        /// <para>
        /// <para>Filter criteria for estimated monthly cost savings from the recommended action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_EstimatedMonthlySavings")]
        public Amazon.ComputeOptimizerAutomation.Model.DoubleCriteriaCondition[] Criteria_EstimatedMonthlySaving { get; set; }
        #endregion
        
        #region Parameter Criteria_LookBackPeriodInDay
        /// <summary>
        /// <para>
        /// <para>Filter criteria for the lookback period in days used to analyze resource utilization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_LookBackPeriodInDays")]
        public Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition[] Criteria_LookBackPeriodInDay { get; set; }
        #endregion
        
        #region Parameter RecommendedActionType
        /// <summary>
        /// <para>
        /// <para>The types of recommended actions to include in the preview.</para>
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
        [Alias("RecommendedActionTypes")]
        public System.String[] RecommendedActionType { get; set; }
        #endregion
        
        #region Parameter Criteria_Region
        /// <summary>
        /// <para>
        /// <para>Filter criteria for Amazon Web Services regions where resources must be located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition[] Criteria_Region { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourceArn
        /// <summary>
        /// <para>
        /// <para>Filter criteria for specific resource ARNs to include or exclude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition[] Criteria_ResourceArn { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourceTag
        /// <summary>
        /// <para>
        /// <para>Filter criteria for resource tags, allowing filtering by tag key and value combinations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.ResourceTagsCriteriaCondition[] Criteria_ResourceTag { get; set; }
        #endregion
        
        #region Parameter Criteria_RestartNeeded
        /// <summary>
        /// <para>
        /// <para>Filter criteria indicating whether the recommended action requires a resource restart.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition[] Criteria_RestartNeeded { get; set; }
        #endregion
        
        #region Parameter RuleType
        /// <summary>
        /// <para>
        /// <para>The type of rule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ComputeOptimizerAutomation.RuleType")]
        public Amazon.ComputeOptimizerAutomation.RuleType RuleType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of automation rule preview summaries to return in a single response.
        /// Valid range is 1-1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token used for pagination to retrieve the next set of results when the response
        /// is truncated.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PreviewResultSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PreviewResultSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesResponse, GetCOAAutomationRulePreviewSummaryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Criteria_EbsVolumeSizeInGib != null)
            {
                context.Criteria_EbsVolumeSizeInGib = new List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition>(this.Criteria_EbsVolumeSizeInGib);
            }
            if (this.Criteria_EbsVolumeType != null)
            {
                context.Criteria_EbsVolumeType = new List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition>(this.Criteria_EbsVolumeType);
            }
            if (this.Criteria_EstimatedMonthlySaving != null)
            {
                context.Criteria_EstimatedMonthlySaving = new List<Amazon.ComputeOptimizerAutomation.Model.DoubleCriteriaCondition>(this.Criteria_EstimatedMonthlySaving);
            }
            if (this.Criteria_LookBackPeriodInDay != null)
            {
                context.Criteria_LookBackPeriodInDay = new List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition>(this.Criteria_LookBackPeriodInDay);
            }
            if (this.Criteria_Region != null)
            {
                context.Criteria_Region = new List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition>(this.Criteria_Region);
            }
            if (this.Criteria_ResourceArn != null)
            {
                context.Criteria_ResourceArn = new List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition>(this.Criteria_ResourceArn);
            }
            if (this.Criteria_ResourceTag != null)
            {
                context.Criteria_ResourceTag = new List<Amazon.ComputeOptimizerAutomation.Model.ResourceTagsCriteriaCondition>(this.Criteria_ResourceTag);
            }
            if (this.Criteria_RestartNeeded != null)
            {
                context.Criteria_RestartNeeded = new List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition>(this.Criteria_RestartNeeded);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.OrganizationScope_AccountId != null)
            {
                context.OrganizationScope_AccountId = new List<System.String>(this.OrganizationScope_AccountId);
            }
            if (this.RecommendedActionType != null)
            {
                context.RecommendedActionType = new List<System.String>(this.RecommendedActionType);
            }
            #if MODULAR
            if (this.RecommendedActionType == null && ParameterWasBound(nameof(this.RecommendedActionType)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommendedActionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleType = this.RuleType;
            #if MODULAR
            if (this.RuleType == null && ParameterWasBound(nameof(this.RuleType)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesRequest();
            
            
             // populate Criteria
            var requestCriteriaIsNull = true;
            request.Criteria = new Amazon.ComputeOptimizerAutomation.Model.Criteria();
            List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition> requestCriteria_criteria_EbsVolumeSizeInGib = null;
            if (cmdletContext.Criteria_EbsVolumeSizeInGib != null)
            {
                requestCriteria_criteria_EbsVolumeSizeInGib = cmdletContext.Criteria_EbsVolumeSizeInGib;
            }
            if (requestCriteria_criteria_EbsVolumeSizeInGib != null)
            {
                request.Criteria.EbsVolumeSizeInGib = requestCriteria_criteria_EbsVolumeSizeInGib;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> requestCriteria_criteria_EbsVolumeType = null;
            if (cmdletContext.Criteria_EbsVolumeType != null)
            {
                requestCriteria_criteria_EbsVolumeType = cmdletContext.Criteria_EbsVolumeType;
            }
            if (requestCriteria_criteria_EbsVolumeType != null)
            {
                request.Criteria.EbsVolumeType = requestCriteria_criteria_EbsVolumeType;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.DoubleCriteriaCondition> requestCriteria_criteria_EstimatedMonthlySaving = null;
            if (cmdletContext.Criteria_EstimatedMonthlySaving != null)
            {
                requestCriteria_criteria_EstimatedMonthlySaving = cmdletContext.Criteria_EstimatedMonthlySaving;
            }
            if (requestCriteria_criteria_EstimatedMonthlySaving != null)
            {
                request.Criteria.EstimatedMonthlySavings = requestCriteria_criteria_EstimatedMonthlySaving;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition> requestCriteria_criteria_LookBackPeriodInDay = null;
            if (cmdletContext.Criteria_LookBackPeriodInDay != null)
            {
                requestCriteria_criteria_LookBackPeriodInDay = cmdletContext.Criteria_LookBackPeriodInDay;
            }
            if (requestCriteria_criteria_LookBackPeriodInDay != null)
            {
                request.Criteria.LookBackPeriodInDays = requestCriteria_criteria_LookBackPeriodInDay;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> requestCriteria_criteria_Region = null;
            if (cmdletContext.Criteria_Region != null)
            {
                requestCriteria_criteria_Region = cmdletContext.Criteria_Region;
            }
            if (requestCriteria_criteria_Region != null)
            {
                request.Criteria.Region = requestCriteria_criteria_Region;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> requestCriteria_criteria_ResourceArn = null;
            if (cmdletContext.Criteria_ResourceArn != null)
            {
                requestCriteria_criteria_ResourceArn = cmdletContext.Criteria_ResourceArn;
            }
            if (requestCriteria_criteria_ResourceArn != null)
            {
                request.Criteria.ResourceArn = requestCriteria_criteria_ResourceArn;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.ResourceTagsCriteriaCondition> requestCriteria_criteria_ResourceTag = null;
            if (cmdletContext.Criteria_ResourceTag != null)
            {
                requestCriteria_criteria_ResourceTag = cmdletContext.Criteria_ResourceTag;
            }
            if (requestCriteria_criteria_ResourceTag != null)
            {
                request.Criteria.ResourceTag = requestCriteria_criteria_ResourceTag;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> requestCriteria_criteria_RestartNeeded = null;
            if (cmdletContext.Criteria_RestartNeeded != null)
            {
                requestCriteria_criteria_RestartNeeded = cmdletContext.Criteria_RestartNeeded;
            }
            if (requestCriteria_criteria_RestartNeeded != null)
            {
                request.Criteria.RestartNeeded = requestCriteria_criteria_RestartNeeded;
                requestCriteriaIsNull = false;
            }
             // determine if request.Criteria should be set to null
            if (requestCriteriaIsNull)
            {
                request.Criteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate OrganizationScope
            var requestOrganizationScopeIsNull = true;
            request.OrganizationScope = new Amazon.ComputeOptimizerAutomation.Model.OrganizationScope();
            List<System.String> requestOrganizationScope_organizationScope_AccountId = null;
            if (cmdletContext.OrganizationScope_AccountId != null)
            {
                requestOrganizationScope_organizationScope_AccountId = cmdletContext.OrganizationScope_AccountId;
            }
            if (requestOrganizationScope_organizationScope_AccountId != null)
            {
                request.OrganizationScope.AccountIds = requestOrganizationScope_organizationScope_AccountId;
                requestOrganizationScopeIsNull = false;
            }
             // determine if request.OrganizationScope should be set to null
            if (requestOrganizationScopeIsNull)
            {
                request.OrganizationScope = null;
            }
            if (cmdletContext.RecommendedActionType != null)
            {
                request.RecommendedActionTypes = cmdletContext.RecommendedActionType;
            }
            if (cmdletContext.RuleType != null)
            {
                request.RuleType = cmdletContext.RuleType;
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
        
        private Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesResponse CallAWSServiceOperation(IAmazonComputeOptimizerAutomation client, Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Compute Optimizer Automation Service", "ListAutomationRulePreviewSummaries");
            try
            {
                #if DESKTOP
                return client.ListAutomationRulePreviewSummaries(request);
                #elif CORECLR
                return client.ListAutomationRulePreviewSummariesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition> Criteria_EbsVolumeSizeInGib { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> Criteria_EbsVolumeType { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.DoubleCriteriaCondition> Criteria_EstimatedMonthlySaving { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition> Criteria_LookBackPeriodInDay { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> Criteria_Region { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> Criteria_ResourceArn { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.ResourceTagsCriteriaCondition> Criteria_ResourceTag { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> Criteria_RestartNeeded { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> OrganizationScope_AccountId { get; set; }
            public List<System.String> RecommendedActionType { get; set; }
            public Amazon.ComputeOptimizerAutomation.RuleType RuleType { get; set; }
            public System.Func<Amazon.ComputeOptimizerAutomation.Model.ListAutomationRulePreviewSummariesResponse, GetCOAAutomationRulePreviewSummaryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PreviewResultSummaries;
        }
        
    }
}
