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
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Returns a list of insights in your organization. You can specify which insights are
    /// returned by their start time, one or more statuses (<c>ONGOING</c>, <c>CLOSED</c>,
    /// and <c>CLOSED</c>), one or more severities (<c>LOW</c>, <c>MEDIUM</c>, and <c>HIGH</c>),
    /// and type (<c>REACTIVE</c> or <c>PROACTIVE</c>). 
    /// 
    ///  
    /// <para>
    ///  Use the <c>Filters</c> parameter to specify status and severity search parameters.
    /// Use the <c>Type</c> parameter to specify <c>REACTIVE</c> or <c>PROACTIVE</c> in your
    /// search. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "DGURUOrganizationInsight", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsGuru.Model.SearchOrganizationInsightsResponse")]
    [AWSCmdlet("Calls the Amazon DevOps Guru SearchOrganizationInsights API operation.", Operation = new[] {"SearchOrganizationInsights"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.SearchOrganizationInsightsResponse))]
    [AWSCmdletOutput("Amazon.DevOpsGuru.Model.SearchOrganizationInsightsResponse",
        "This cmdlet returns an Amazon.DevOpsGuru.Model.SearchOrganizationInsightsResponse object containing multiple properties."
    )]
    public partial class SearchDGURUOrganizationInsightCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account. </para>
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
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter StartTimeRange_FromTime
        /// <summary>
        /// <para>
        /// <para> The start time of the time range. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTimeRange_FromTime { get; set; }
        #endregion
        
        #region Parameter ServiceCollection_ServiceName
        /// <summary>
        /// <para>
        /// <para>An array of strings that each specifies the name of an Amazon Web Services service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ServiceCollection_ServiceNames")]
        public System.String[] ServiceCollection_ServiceName { get; set; }
        #endregion
        
        #region Parameter Filters_Severity
        /// <summary>
        /// <para>
        /// <para> An array of severity values used to search for insights. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Severities")]
        public System.String[] Filters_Severity { get; set; }
        #endregion
        
        #region Parameter CloudFormation_StackName
        /// <summary>
        /// <para>
        /// <para> An array of CloudFormation stack names. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ResourceCollection_CloudFormation_StackNames")]
        public System.String[] CloudFormation_StackName { get; set; }
        #endregion
        
        #region Parameter Filters_Status
        /// <summary>
        /// <para>
        /// <para> An array of status values used to search for insights. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Statuses")]
        public System.String[] Filters_Status { get; set; }
        #endregion
        
        #region Parameter ResourceCollection_Tag
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services tags that are used by resources in the resource collection.</para><para>Tags help you identify and organize your Amazon Web Services resources. Many Amazon
        /// Web Services services support tagging, so you can assign the same tag to resources
        /// from different services to indicate that the resources are related. For example, you
        /// can assign the same tag to an Amazon DynamoDB table resource that you assign to an
        /// Lambda function. For more information about using tags, see the <a href="https://docs.aws.amazon.com/whitepapers/latest/tagging-best-practices/tagging-best-practices.html">Tagging
        /// best practices</a> whitepaper. </para><para>Each Amazon Web Services tag has two parts. </para><ul><li><para>A tag <i>key</i> (for example, <c>CostCenter</c>, <c>Environment</c>, <c>Project</c>,
        /// or <c>Secret</c>). Tag <i>keys</i> are case-sensitive.</para></li><li><para>An optional field known as a tag <i>value</i> (for example, <c>111122223333</c>, <c>Production</c>,
        /// or a team name). Omitting the tag <i>value</i> is the same as using an empty string.
        /// Like tag <i>keys</i>, tag <i>values</i> are case-sensitive.</para></li></ul><para>Together these are known as <i>key</i>-<i>value</i> pairs.</para><important><para>The string used for a <i>key</i> in a tag that you use to define your resource coverage
        /// must begin with the prefix <c>Devops-guru-</c>. The tag <i>key</i> might be <c>DevOps-Guru-deployment-application</c>
        /// or <c>devops-guru-rds-application</c>. When you create a <i>key</i>, the case of characters
        /// in the <i>key</i> can be whatever you choose. After you create a <i>key</i>, it is
        /// case-sensitive. For example, DevOps Guru works with a <i>key</i> named <c>devops-guru-rds</c>
        /// and a <i>key</i> named <c>DevOps-Guru-RDS</c>, and these act as two different <i>keys</i>.
        /// Possible <i>key</i>/<i>value</i> pairs in your application might be <c>Devops-Guru-production-application/RDS</c>
        /// or <c>Devops-Guru-production-application/containers</c>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ResourceCollection_Tags")]
        public Amazon.DevOpsGuru.Model.TagCollection[] ResourceCollection_Tag { get; set; }
        #endregion
        
        #region Parameter StartTimeRange_ToTime
        /// <summary>
        /// <para>
        /// <para> The end time of the time range. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTimeRange_ToTime { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para> The type of insights you are searching for (<c>REACTIVE</c> or <c>PROACTIVE</c>).
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DevOpsGuru.InsightType")]
        public Amazon.DevOpsGuru.InsightType Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to use to retrieve the next page of results for this operation.
        /// If this value is null, it retrieves the first page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.SearchOrganizationInsightsResponse).
        /// Specifying the name of a property of type Amazon.DevOpsGuru.Model.SearchOrganizationInsightsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Type), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-DGURUOrganizationInsight (SearchOrganizationInsights)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.SearchOrganizationInsightsResponse, SearchDGURUOrganizationInsightCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CloudFormation_StackName != null)
            {
                context.CloudFormation_StackName = new List<System.String>(this.CloudFormation_StackName);
            }
            if (this.ResourceCollection_Tag != null)
            {
                context.ResourceCollection_Tag = new List<Amazon.DevOpsGuru.Model.TagCollection>(this.ResourceCollection_Tag);
            }
            if (this.ServiceCollection_ServiceName != null)
            {
                context.ServiceCollection_ServiceName = new List<System.String>(this.ServiceCollection_ServiceName);
            }
            if (this.Filters_Severity != null)
            {
                context.Filters_Severity = new List<System.String>(this.Filters_Severity);
            }
            if (this.Filters_Status != null)
            {
                context.Filters_Status = new List<System.String>(this.Filters_Status);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StartTimeRange_FromTime = this.StartTimeRange_FromTime;
            context.StartTimeRange_ToTime = this.StartTimeRange_ToTime;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DevOpsGuru.Model.SearchOrganizationInsightsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.DevOpsGuru.Model.SearchOrganizationInsightsFilters();
            List<System.String> requestFilters_filters_Severity = null;
            if (cmdletContext.Filters_Severity != null)
            {
                requestFilters_filters_Severity = cmdletContext.Filters_Severity;
            }
            if (requestFilters_filters_Severity != null)
            {
                request.Filters.Severities = requestFilters_filters_Severity;
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
            Amazon.DevOpsGuru.Model.ServiceCollection requestFilters_filters_ServiceCollection = null;
            
             // populate ServiceCollection
            var requestFilters_filters_ServiceCollectionIsNull = true;
            requestFilters_filters_ServiceCollection = new Amazon.DevOpsGuru.Model.ServiceCollection();
            List<System.String> requestFilters_filters_ServiceCollection_serviceCollection_ServiceName = null;
            if (cmdletContext.ServiceCollection_ServiceName != null)
            {
                requestFilters_filters_ServiceCollection_serviceCollection_ServiceName = cmdletContext.ServiceCollection_ServiceName;
            }
            if (requestFilters_filters_ServiceCollection_serviceCollection_ServiceName != null)
            {
                requestFilters_filters_ServiceCollection.ServiceNames = requestFilters_filters_ServiceCollection_serviceCollection_ServiceName;
                requestFilters_filters_ServiceCollectionIsNull = false;
            }
             // determine if requestFilters_filters_ServiceCollection should be set to null
            if (requestFilters_filters_ServiceCollectionIsNull)
            {
                requestFilters_filters_ServiceCollection = null;
            }
            if (requestFilters_filters_ServiceCollection != null)
            {
                request.Filters.ServiceCollection = requestFilters_filters_ServiceCollection;
                requestFiltersIsNull = false;
            }
            Amazon.DevOpsGuru.Model.ResourceCollection requestFilters_filters_ResourceCollection = null;
            
             // populate ResourceCollection
            var requestFilters_filters_ResourceCollectionIsNull = true;
            requestFilters_filters_ResourceCollection = new Amazon.DevOpsGuru.Model.ResourceCollection();
            List<Amazon.DevOpsGuru.Model.TagCollection> requestFilters_filters_ResourceCollection_resourceCollection_Tag = null;
            if (cmdletContext.ResourceCollection_Tag != null)
            {
                requestFilters_filters_ResourceCollection_resourceCollection_Tag = cmdletContext.ResourceCollection_Tag;
            }
            if (requestFilters_filters_ResourceCollection_resourceCollection_Tag != null)
            {
                requestFilters_filters_ResourceCollection.Tags = requestFilters_filters_ResourceCollection_resourceCollection_Tag;
                requestFilters_filters_ResourceCollectionIsNull = false;
            }
            Amazon.DevOpsGuru.Model.CloudFormationCollection requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation = null;
            
             // populate CloudFormation
            var requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormationIsNull = true;
            requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation = new Amazon.DevOpsGuru.Model.CloudFormationCollection();
            List<System.String> requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation_cloudFormation_StackName = null;
            if (cmdletContext.CloudFormation_StackName != null)
            {
                requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation_cloudFormation_StackName = cmdletContext.CloudFormation_StackName;
            }
            if (requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation_cloudFormation_StackName != null)
            {
                requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation.StackNames = requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation_cloudFormation_StackName;
                requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormationIsNull = false;
            }
             // determine if requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation should be set to null
            if (requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormationIsNull)
            {
                requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation = null;
            }
            if (requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation != null)
            {
                requestFilters_filters_ResourceCollection.CloudFormation = requestFilters_filters_ResourceCollection_filters_ResourceCollection_CloudFormation;
                requestFilters_filters_ResourceCollectionIsNull = false;
            }
             // determine if requestFilters_filters_ResourceCollection should be set to null
            if (requestFilters_filters_ResourceCollectionIsNull)
            {
                requestFilters_filters_ResourceCollection = null;
            }
            if (requestFilters_filters_ResourceCollection != null)
            {
                request.Filters.ResourceCollection = requestFilters_filters_ResourceCollection;
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
            
             // populate StartTimeRange
            var requestStartTimeRangeIsNull = true;
            request.StartTimeRange = new Amazon.DevOpsGuru.Model.StartTimeRange();
            System.DateTime? requestStartTimeRange_startTimeRange_FromTime = null;
            if (cmdletContext.StartTimeRange_FromTime != null)
            {
                requestStartTimeRange_startTimeRange_FromTime = cmdletContext.StartTimeRange_FromTime.Value;
            }
            if (requestStartTimeRange_startTimeRange_FromTime != null)
            {
                request.StartTimeRange.FromTime = requestStartTimeRange_startTimeRange_FromTime.Value;
                requestStartTimeRangeIsNull = false;
            }
            System.DateTime? requestStartTimeRange_startTimeRange_ToTime = null;
            if (cmdletContext.StartTimeRange_ToTime != null)
            {
                requestStartTimeRange_startTimeRange_ToTime = cmdletContext.StartTimeRange_ToTime.Value;
            }
            if (requestStartTimeRange_startTimeRange_ToTime != null)
            {
                request.StartTimeRange.ToTime = requestStartTimeRange_startTimeRange_ToTime.Value;
                requestStartTimeRangeIsNull = false;
            }
             // determine if request.StartTimeRange should be set to null
            if (requestStartTimeRangeIsNull)
            {
                request.StartTimeRange = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.DevOpsGuru.Model.SearchOrganizationInsightsResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.SearchOrganizationInsightsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "SearchOrganizationInsights");
            try
            {
                return client.SearchOrganizationInsightsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public List<System.String> CloudFormation_StackName { get; set; }
            public List<Amazon.DevOpsGuru.Model.TagCollection> ResourceCollection_Tag { get; set; }
            public List<System.String> ServiceCollection_ServiceName { get; set; }
            public List<System.String> Filters_Severity { get; set; }
            public List<System.String> Filters_Status { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTimeRange_FromTime { get; set; }
            public System.DateTime? StartTimeRange_ToTime { get; set; }
            public Amazon.DevOpsGuru.InsightType Type { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.SearchOrganizationInsightsResponse, SearchDGURUOrganizationInsightCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
