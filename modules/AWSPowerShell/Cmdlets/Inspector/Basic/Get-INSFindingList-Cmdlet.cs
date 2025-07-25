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
using Amazon.Inspector;
using Amazon.Inspector.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Lists findings that are generated by the assessment runs that are specified by the
    /// ARNs of the assessment runs.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "INSFindingList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Inspector ListFindings API operation.", Operation = new[] {"ListFindings"}, SelectReturnType = typeof(Amazon.Inspector.Model.ListFindingsResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector.Model.ListFindingsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Inspector.Model.ListFindingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINSFindingListCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter_AgentId
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, one of the values that is specified for this data
        /// type property must be the exact match of the value of the <b>agentId</b> property
        /// of the <a>Finding</a> data type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_AgentIds")]
        public System.String[] Filter_AgentId { get; set; }
        #endregion
        
        #region Parameter AssessmentRunArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the assessment runs that generate the findings that you want to list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("AssessmentRunArns")]
        public System.String[] AssessmentRunArn { get; set; }
        #endregion
        
        #region Parameter Filter_Attribute
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, the list of values that are specified for this data
        /// type property must be contained in the list of values of the <b>attributes</b> property
        /// of the <a>Finding</a> data type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Attributes")]
        public Amazon.Inspector.Model.Attribute[] Filter_Attribute { get; set; }
        #endregion
        
        #region Parameter Filter_AutoScalingGroup
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, one of the values that is specified for this data
        /// type property must be the exact match of the value of the <b>autoScalingGroup</b>
        /// property of the <a>Finding</a> data type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_AutoScalingGroups")]
        public System.String[] Filter_AutoScalingGroup { get; set; }
        #endregion
        
        #region Parameter CreationTimeRange_BeginDate
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_CreationTimeRange_BeginDate")]
        public System.DateTime? CreationTimeRange_BeginDate { get; set; }
        #endregion
        
        #region Parameter CreationTimeRange_EndDate
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_CreationTimeRange_EndDate")]
        public System.DateTime? CreationTimeRange_EndDate { get; set; }
        #endregion
        
        #region Parameter Filter_RuleName
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, one of the values that is specified for this data
        /// type property must be the exact match of the value of the <b>ruleName</b> property
        /// of the <a>Finding</a> data type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_RuleNames")]
        public System.String[] Filter_RuleName { get; set; }
        #endregion
        
        #region Parameter Filter_RulesPackageArn
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, one of the values that is specified for this data
        /// type property must be the exact match of the value of the <b>rulesPackageArn</b> property
        /// of the <a>Finding</a> data type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_RulesPackageArns")]
        public System.String[] Filter_RulesPackageArn { get; set; }
        #endregion
        
        #region Parameter Filter_Severity
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, one of the values that is specified for this data
        /// type property must be the exact match of the value of the <b>severity</b> property
        /// of the <a>Finding</a> data type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Severities")]
        public System.String[] Filter_Severity { get; set; }
        #endregion
        
        #region Parameter Filter_UserAttribute
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, the value that is specified for this data type property
        /// must be contained in the list of values of the <b>userAttributes</b> property of the
        /// <a>Finding</a> data type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_UserAttributes")]
        public Amazon.Inspector.Model.Attribute[] Filter_UserAttribute { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>You can use this parameter to indicate the maximum number of items you want in the
        /// response. The default value is 10. The maximum value is 500.</para>
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
        /// <para>You can use this parameter when paginating results. Set the value of this parameter
        /// to null on your first call to the <b>ListFindings</b> action. Subsequent calls to
        /// the action fill <b>nextToken</b> in the request with the value of <b>NextToken</b>
        /// from the previous response to continue listing data.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FindingArns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector.Model.ListFindingsResponse).
        /// Specifying the name of a property of type Amazon.Inspector.Model.ListFindingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FindingArns";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector.Model.ListFindingsResponse, GetINSFindingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssessmentRunArn != null)
            {
                context.AssessmentRunArn = new List<System.String>(this.AssessmentRunArn);
            }
            if (this.Filter_AgentId != null)
            {
                context.Filter_AgentId = new List<System.String>(this.Filter_AgentId);
            }
            if (this.Filter_Attribute != null)
            {
                context.Filter_Attribute = new List<Amazon.Inspector.Model.Attribute>(this.Filter_Attribute);
            }
            if (this.Filter_AutoScalingGroup != null)
            {
                context.Filter_AutoScalingGroup = new List<System.String>(this.Filter_AutoScalingGroup);
            }
            context.CreationTimeRange_BeginDate = this.CreationTimeRange_BeginDate;
            context.CreationTimeRange_EndDate = this.CreationTimeRange_EndDate;
            if (this.Filter_RuleName != null)
            {
                context.Filter_RuleName = new List<System.String>(this.Filter_RuleName);
            }
            if (this.Filter_RulesPackageArn != null)
            {
                context.Filter_RulesPackageArn = new List<System.String>(this.Filter_RulesPackageArn);
            }
            if (this.Filter_Severity != null)
            {
                context.Filter_Severity = new List<System.String>(this.Filter_Severity);
            }
            if (this.Filter_UserAttribute != null)
            {
                context.Filter_UserAttribute = new List<Amazon.Inspector.Model.Attribute>(this.Filter_UserAttribute);
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
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Inspector.Model.ListFindingsRequest();
            
            if (cmdletContext.AssessmentRunArn != null)
            {
                request.AssessmentRunArns = cmdletContext.AssessmentRunArn;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Inspector.Model.FindingFilter();
            List<System.String> requestFilter_filter_AgentId = null;
            if (cmdletContext.Filter_AgentId != null)
            {
                requestFilter_filter_AgentId = cmdletContext.Filter_AgentId;
            }
            if (requestFilter_filter_AgentId != null)
            {
                request.Filter.AgentIds = requestFilter_filter_AgentId;
                requestFilterIsNull = false;
            }
            List<Amazon.Inspector.Model.Attribute> requestFilter_filter_Attribute = null;
            if (cmdletContext.Filter_Attribute != null)
            {
                requestFilter_filter_Attribute = cmdletContext.Filter_Attribute;
            }
            if (requestFilter_filter_Attribute != null)
            {
                request.Filter.Attributes = requestFilter_filter_Attribute;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_AutoScalingGroup = null;
            if (cmdletContext.Filter_AutoScalingGroup != null)
            {
                requestFilter_filter_AutoScalingGroup = cmdletContext.Filter_AutoScalingGroup;
            }
            if (requestFilter_filter_AutoScalingGroup != null)
            {
                request.Filter.AutoScalingGroups = requestFilter_filter_AutoScalingGroup;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_RuleName = null;
            if (cmdletContext.Filter_RuleName != null)
            {
                requestFilter_filter_RuleName = cmdletContext.Filter_RuleName;
            }
            if (requestFilter_filter_RuleName != null)
            {
                request.Filter.RuleNames = requestFilter_filter_RuleName;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_RulesPackageArn = null;
            if (cmdletContext.Filter_RulesPackageArn != null)
            {
                requestFilter_filter_RulesPackageArn = cmdletContext.Filter_RulesPackageArn;
            }
            if (requestFilter_filter_RulesPackageArn != null)
            {
                request.Filter.RulesPackageArns = requestFilter_filter_RulesPackageArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Severity = null;
            if (cmdletContext.Filter_Severity != null)
            {
                requestFilter_filter_Severity = cmdletContext.Filter_Severity;
            }
            if (requestFilter_filter_Severity != null)
            {
                request.Filter.Severities = requestFilter_filter_Severity;
                requestFilterIsNull = false;
            }
            List<Amazon.Inspector.Model.Attribute> requestFilter_filter_UserAttribute = null;
            if (cmdletContext.Filter_UserAttribute != null)
            {
                requestFilter_filter_UserAttribute = cmdletContext.Filter_UserAttribute;
            }
            if (requestFilter_filter_UserAttribute != null)
            {
                request.Filter.UserAttributes = requestFilter_filter_UserAttribute;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_CreationTimeRange = null;
            
             // populate CreationTimeRange
            var requestFilter_filter_CreationTimeRangeIsNull = true;
            requestFilter_filter_CreationTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_CreationTimeRange_creationTimeRange_BeginDate = null;
            if (cmdletContext.CreationTimeRange_BeginDate != null)
            {
                requestFilter_filter_CreationTimeRange_creationTimeRange_BeginDate = cmdletContext.CreationTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_CreationTimeRange_creationTimeRange_BeginDate != null)
            {
                requestFilter_filter_CreationTimeRange.BeginDate = requestFilter_filter_CreationTimeRange_creationTimeRange_BeginDate.Value;
                requestFilter_filter_CreationTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreationTimeRange_creationTimeRange_EndDate = null;
            if (cmdletContext.CreationTimeRange_EndDate != null)
            {
                requestFilter_filter_CreationTimeRange_creationTimeRange_EndDate = cmdletContext.CreationTimeRange_EndDate.Value;
            }
            if (requestFilter_filter_CreationTimeRange_creationTimeRange_EndDate != null)
            {
                requestFilter_filter_CreationTimeRange.EndDate = requestFilter_filter_CreationTimeRange_creationTimeRange_EndDate.Value;
                requestFilter_filter_CreationTimeRangeIsNull = false;
            }
             // determine if requestFilter_filter_CreationTimeRange should be set to null
            if (requestFilter_filter_CreationTimeRangeIsNull)
            {
                requestFilter_filter_CreationTimeRange = null;
            }
            if (requestFilter_filter_CreationTimeRange != null)
            {
                request.Filter.CreationTimeRange = requestFilter_filter_CreationTimeRange;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Inspector.Model.ListFindingsRequest();
            if (cmdletContext.AssessmentRunArn != null)
            {
                request.AssessmentRunArns = cmdletContext.AssessmentRunArn;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Inspector.Model.FindingFilter();
            List<System.String> requestFilter_filter_AgentId = null;
            if (cmdletContext.Filter_AgentId != null)
            {
                requestFilter_filter_AgentId = cmdletContext.Filter_AgentId;
            }
            if (requestFilter_filter_AgentId != null)
            {
                request.Filter.AgentIds = requestFilter_filter_AgentId;
                requestFilterIsNull = false;
            }
            List<Amazon.Inspector.Model.Attribute> requestFilter_filter_Attribute = null;
            if (cmdletContext.Filter_Attribute != null)
            {
                requestFilter_filter_Attribute = cmdletContext.Filter_Attribute;
            }
            if (requestFilter_filter_Attribute != null)
            {
                request.Filter.Attributes = requestFilter_filter_Attribute;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_AutoScalingGroup = null;
            if (cmdletContext.Filter_AutoScalingGroup != null)
            {
                requestFilter_filter_AutoScalingGroup = cmdletContext.Filter_AutoScalingGroup;
            }
            if (requestFilter_filter_AutoScalingGroup != null)
            {
                request.Filter.AutoScalingGroups = requestFilter_filter_AutoScalingGroup;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_RuleName = null;
            if (cmdletContext.Filter_RuleName != null)
            {
                requestFilter_filter_RuleName = cmdletContext.Filter_RuleName;
            }
            if (requestFilter_filter_RuleName != null)
            {
                request.Filter.RuleNames = requestFilter_filter_RuleName;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_RulesPackageArn = null;
            if (cmdletContext.Filter_RulesPackageArn != null)
            {
                requestFilter_filter_RulesPackageArn = cmdletContext.Filter_RulesPackageArn;
            }
            if (requestFilter_filter_RulesPackageArn != null)
            {
                request.Filter.RulesPackageArns = requestFilter_filter_RulesPackageArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Severity = null;
            if (cmdletContext.Filter_Severity != null)
            {
                requestFilter_filter_Severity = cmdletContext.Filter_Severity;
            }
            if (requestFilter_filter_Severity != null)
            {
                request.Filter.Severities = requestFilter_filter_Severity;
                requestFilterIsNull = false;
            }
            List<Amazon.Inspector.Model.Attribute> requestFilter_filter_UserAttribute = null;
            if (cmdletContext.Filter_UserAttribute != null)
            {
                requestFilter_filter_UserAttribute = cmdletContext.Filter_UserAttribute;
            }
            if (requestFilter_filter_UserAttribute != null)
            {
                request.Filter.UserAttributes = requestFilter_filter_UserAttribute;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_CreationTimeRange = null;
            
             // populate CreationTimeRange
            var requestFilter_filter_CreationTimeRangeIsNull = true;
            requestFilter_filter_CreationTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_CreationTimeRange_creationTimeRange_BeginDate = null;
            if (cmdletContext.CreationTimeRange_BeginDate != null)
            {
                requestFilter_filter_CreationTimeRange_creationTimeRange_BeginDate = cmdletContext.CreationTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_CreationTimeRange_creationTimeRange_BeginDate != null)
            {
                requestFilter_filter_CreationTimeRange.BeginDate = requestFilter_filter_CreationTimeRange_creationTimeRange_BeginDate.Value;
                requestFilter_filter_CreationTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreationTimeRange_creationTimeRange_EndDate = null;
            if (cmdletContext.CreationTimeRange_EndDate != null)
            {
                requestFilter_filter_CreationTimeRange_creationTimeRange_EndDate = cmdletContext.CreationTimeRange_EndDate.Value;
            }
            if (requestFilter_filter_CreationTimeRange_creationTimeRange_EndDate != null)
            {
                requestFilter_filter_CreationTimeRange.EndDate = requestFilter_filter_CreationTimeRange_creationTimeRange_EndDate.Value;
                requestFilter_filter_CreationTimeRangeIsNull = false;
            }
             // determine if requestFilter_filter_CreationTimeRange should be set to null
            if (requestFilter_filter_CreationTimeRangeIsNull)
            {
                requestFilter_filter_CreationTimeRange = null;
            }
            if (requestFilter_filter_CreationTimeRange != null)
            {
                request.Filter.CreationTimeRange = requestFilter_filter_CreationTimeRange;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                }
                
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
                    int _receivedThisCall = response.FindingArns?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Inspector.Model.ListFindingsResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.ListFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "ListFindings");
            try
            {
                return client.ListFindingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AssessmentRunArn { get; set; }
            public List<System.String> Filter_AgentId { get; set; }
            public List<Amazon.Inspector.Model.Attribute> Filter_Attribute { get; set; }
            public List<System.String> Filter_AutoScalingGroup { get; set; }
            public System.DateTime? CreationTimeRange_BeginDate { get; set; }
            public System.DateTime? CreationTimeRange_EndDate { get; set; }
            public List<System.String> Filter_RuleName { get; set; }
            public List<System.String> Filter_RulesPackageArn { get; set; }
            public List<System.String> Filter_Severity { get; set; }
            public List<Amazon.Inspector.Model.Attribute> Filter_UserAttribute { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Inspector.Model.ListFindingsResponse, GetINSFindingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FindingArns;
        }
        
    }
}
