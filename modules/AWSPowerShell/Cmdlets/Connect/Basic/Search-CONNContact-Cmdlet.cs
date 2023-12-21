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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Searches contacts in an Amazon Connect instance.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "CONNContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.SearchContactsResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service SearchContacts API operation.", Operation = new[] {"SearchContacts"}, SelectReturnType = typeof(Amazon.Connect.Model.SearchContactsResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.SearchContactsResponse",
        "This cmdlet returns an Amazon.Connect.Model.SearchContactsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchCONNContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SearchCriteria_AgentId
        /// <summary>
        /// <para>
        /// <para>The array of agent ids</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_AgentIds")]
        public System.String[] SearchCriteria_AgentId { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_Channel
        /// <summary>
        /// <para>
        /// <para>The array of channels</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_Channels")]
        public System.String[] SearchCriteria_Channel { get; set; }
        #endregion
        
        #region Parameter Transcript_Criterion
        /// <summary>
        /// <para>
        /// <para>The array of transcript search criteria</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_ContactAnalysis_Transcript_Criteria")]
        public Amazon.Connect.Model.TranscriptCriteria[] Transcript_Criterion { get; set; }
        #endregion
        
        #region Parameter SearchableContactAttributes_Criterion
        /// <summary>
        /// <para>
        /// <para>The array of searhale contact attribute criteria</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_SearchableContactAttributes_Criteria")]
        public Amazon.Connect.Model.SearchableContactAttributesCriteria[] SearchableContactAttributes_Criterion { get; set; }
        #endregion
        
        #region Parameter TimeRange_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the time range.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeRange_EndTime { get; set; }
        #endregion
        
        #region Parameter Sort_FieldName
        /// <summary>
        /// <para>
        /// <para>The name of the field on which to sort.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.SortableFieldName")]
        public Amazon.Connect.SortableFieldName Sort_FieldName { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_InitiationMethod
        /// <summary>
        /// <para>
        /// <para>The array of initiaton methods</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_InitiationMethods")]
        public System.String[] SearchCriteria_InitiationMethod { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of Amazon Connect instance. You can find the instance ID in the Amazon
        /// Resource Name (ARN) of the instance</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter AgentHierarchyGroups_L1Id
        /// <summary>
        /// <para>
        /// <para>The identifiers for level 1 hierarchy groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_AgentHierarchyGroups_L1Ids")]
        public System.String[] AgentHierarchyGroups_L1Id { get; set; }
        #endregion
        
        #region Parameter AgentHierarchyGroups_L2Id
        /// <summary>
        /// <para>
        /// <para>The identifiers for level 2 hierarchy groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_AgentHierarchyGroups_L2Ids")]
        public System.String[] AgentHierarchyGroups_L2Id { get; set; }
        #endregion
        
        #region Parameter AgentHierarchyGroups_L3Id
        /// <summary>
        /// <para>
        /// <para>The identifiers for level 3 hierarchy groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_AgentHierarchyGroups_L3Ids")]
        public System.String[] AgentHierarchyGroups_L3Id { get; set; }
        #endregion
        
        #region Parameter AgentHierarchyGroups_L4Id
        /// <summary>
        /// <para>
        /// <para>The identifiers for level 4 hierarchy groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_AgentHierarchyGroups_L4Ids")]
        public System.String[] AgentHierarchyGroups_L4Id { get; set; }
        #endregion
        
        #region Parameter AgentHierarchyGroups_L5Id
        /// <summary>
        /// <para>
        /// <para>The identifiers for level 5 hierarchy groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_AgentHierarchyGroups_L5Ids")]
        public System.String[] AgentHierarchyGroups_L5Id { get; set; }
        #endregion
        
        #region Parameter Transcript_MatchType
        /// <summary>
        /// <para>
        /// <para>The match type of multiple transcript criteira</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_ContactAnalysis_Transcript_MatchType")]
        [AWSConstantClassSource("Amazon.Connect.SearchContactsMatchType")]
        public Amazon.Connect.SearchContactsMatchType Transcript_MatchType { get; set; }
        #endregion
        
        #region Parameter SearchableContactAttributes_MatchType
        /// <summary>
        /// <para>
        /// <para>The match type of multiple searchable contact attributes criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_SearchableContactAttributes_MatchType")]
        [AWSConstantClassSource("Amazon.Connect.SearchContactsMatchType")]
        public Amazon.Connect.SearchContactsMatchType SearchableContactAttributes_MatchType { get; set; }
        #endregion
        
        #region Parameter Sort_Order
        /// <summary>
        /// <para>
        /// <para>An ascending or descending sort.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.SortOrder")]
        public Amazon.Connect.SortOrder Sort_Order { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_QueueId
        /// <summary>
        /// <para>
        /// <para>The array of queue ids.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_QueueIds")]
        public System.String[] SearchCriteria_QueueId { get; set; }
        #endregion
        
        #region Parameter TimeRange_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the time range.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeRange_StartTime { get; set; }
        #endregion
        
        #region Parameter TimeRange_Type
        /// <summary>
        /// <para>
        /// <para>The type of timestamp to search</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.SearchContactsTimeRangeType")]
        public Amazon.Connect.SearchContactsTimeRangeType TimeRange_Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.SearchContactsResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.SearchContactsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-CONNContact (SearchContacts)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.SearchContactsResponse, SearchCONNContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.AgentHierarchyGroups_L1Id != null)
            {
                context.AgentHierarchyGroups_L1Id = new List<System.String>(this.AgentHierarchyGroups_L1Id);
            }
            if (this.AgentHierarchyGroups_L2Id != null)
            {
                context.AgentHierarchyGroups_L2Id = new List<System.String>(this.AgentHierarchyGroups_L2Id);
            }
            if (this.AgentHierarchyGroups_L3Id != null)
            {
                context.AgentHierarchyGroups_L3Id = new List<System.String>(this.AgentHierarchyGroups_L3Id);
            }
            if (this.AgentHierarchyGroups_L4Id != null)
            {
                context.AgentHierarchyGroups_L4Id = new List<System.String>(this.AgentHierarchyGroups_L4Id);
            }
            if (this.AgentHierarchyGroups_L5Id != null)
            {
                context.AgentHierarchyGroups_L5Id = new List<System.String>(this.AgentHierarchyGroups_L5Id);
            }
            if (this.SearchCriteria_AgentId != null)
            {
                context.SearchCriteria_AgentId = new List<System.String>(this.SearchCriteria_AgentId);
            }
            if (this.SearchCriteria_Channel != null)
            {
                context.SearchCriteria_Channel = new List<System.String>(this.SearchCriteria_Channel);
            }
            if (this.Transcript_Criterion != null)
            {
                context.Transcript_Criterion = new List<Amazon.Connect.Model.TranscriptCriteria>(this.Transcript_Criterion);
            }
            context.Transcript_MatchType = this.Transcript_MatchType;
            if (this.SearchCriteria_InitiationMethod != null)
            {
                context.SearchCriteria_InitiationMethod = new List<System.String>(this.SearchCriteria_InitiationMethod);
            }
            if (this.SearchCriteria_QueueId != null)
            {
                context.SearchCriteria_QueueId = new List<System.String>(this.SearchCriteria_QueueId);
            }
            if (this.SearchableContactAttributes_Criterion != null)
            {
                context.SearchableContactAttributes_Criterion = new List<Amazon.Connect.Model.SearchableContactAttributesCriteria>(this.SearchableContactAttributes_Criterion);
            }
            context.SearchableContactAttributes_MatchType = this.SearchableContactAttributes_MatchType;
            context.Sort_FieldName = this.Sort_FieldName;
            context.Sort_Order = this.Sort_Order;
            context.TimeRange_EndTime = this.TimeRange_EndTime;
            #if MODULAR
            if (this.TimeRange_EndTime == null && ParameterWasBound(nameof(this.TimeRange_EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeRange_EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeRange_StartTime = this.TimeRange_StartTime;
            #if MODULAR
            if (this.TimeRange_StartTime == null && ParameterWasBound(nameof(this.TimeRange_StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeRange_StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeRange_Type = this.TimeRange_Type;
            #if MODULAR
            if (this.TimeRange_Type == null && ParameterWasBound(nameof(this.TimeRange_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeRange_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.SearchContactsRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate SearchCriteria
            var requestSearchCriteriaIsNull = true;
            request.SearchCriteria = new Amazon.Connect.Model.SearchCriteria();
            List<System.String> requestSearchCriteria_searchCriteria_AgentId = null;
            if (cmdletContext.SearchCriteria_AgentId != null)
            {
                requestSearchCriteria_searchCriteria_AgentId = cmdletContext.SearchCriteria_AgentId;
            }
            if (requestSearchCriteria_searchCriteria_AgentId != null)
            {
                request.SearchCriteria.AgentIds = requestSearchCriteria_searchCriteria_AgentId;
                requestSearchCriteriaIsNull = false;
            }
            List<System.String> requestSearchCriteria_searchCriteria_Channel = null;
            if (cmdletContext.SearchCriteria_Channel != null)
            {
                requestSearchCriteria_searchCriteria_Channel = cmdletContext.SearchCriteria_Channel;
            }
            if (requestSearchCriteria_searchCriteria_Channel != null)
            {
                request.SearchCriteria.Channels = requestSearchCriteria_searchCriteria_Channel;
                requestSearchCriteriaIsNull = false;
            }
            List<System.String> requestSearchCriteria_searchCriteria_InitiationMethod = null;
            if (cmdletContext.SearchCriteria_InitiationMethod != null)
            {
                requestSearchCriteria_searchCriteria_InitiationMethod = cmdletContext.SearchCriteria_InitiationMethod;
            }
            if (requestSearchCriteria_searchCriteria_InitiationMethod != null)
            {
                request.SearchCriteria.InitiationMethods = requestSearchCriteria_searchCriteria_InitiationMethod;
                requestSearchCriteriaIsNull = false;
            }
            List<System.String> requestSearchCriteria_searchCriteria_QueueId = null;
            if (cmdletContext.SearchCriteria_QueueId != null)
            {
                requestSearchCriteria_searchCriteria_QueueId = cmdletContext.SearchCriteria_QueueId;
            }
            if (requestSearchCriteria_searchCriteria_QueueId != null)
            {
                request.SearchCriteria.QueueIds = requestSearchCriteria_searchCriteria_QueueId;
                requestSearchCriteriaIsNull = false;
            }
            Amazon.Connect.Model.ContactAnalysis requestSearchCriteria_searchCriteria_ContactAnalysis = null;
            
             // populate ContactAnalysis
            var requestSearchCriteria_searchCriteria_ContactAnalysisIsNull = true;
            requestSearchCriteria_searchCriteria_ContactAnalysis = new Amazon.Connect.Model.ContactAnalysis();
            Amazon.Connect.Model.Transcript requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript = null;
            
             // populate Transcript
            var requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_TranscriptIsNull = true;
            requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript = new Amazon.Connect.Model.Transcript();
            List<Amazon.Connect.Model.TranscriptCriteria> requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript_transcript_Criterion = null;
            if (cmdletContext.Transcript_Criterion != null)
            {
                requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript_transcript_Criterion = cmdletContext.Transcript_Criterion;
            }
            if (requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript_transcript_Criterion != null)
            {
                requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript.Criteria = requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript_transcript_Criterion;
                requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_TranscriptIsNull = false;
            }
            Amazon.Connect.SearchContactsMatchType requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript_transcript_MatchType = null;
            if (cmdletContext.Transcript_MatchType != null)
            {
                requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript_transcript_MatchType = cmdletContext.Transcript_MatchType;
            }
            if (requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript_transcript_MatchType != null)
            {
                requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript.MatchType = requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript_transcript_MatchType;
                requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_TranscriptIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript should be set to null
            if (requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_TranscriptIsNull)
            {
                requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript = null;
            }
            if (requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript != null)
            {
                requestSearchCriteria_searchCriteria_ContactAnalysis.Transcript = requestSearchCriteria_searchCriteria_ContactAnalysis_searchCriteria_ContactAnalysis_Transcript;
                requestSearchCriteria_searchCriteria_ContactAnalysisIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_ContactAnalysis should be set to null
            if (requestSearchCriteria_searchCriteria_ContactAnalysisIsNull)
            {
                requestSearchCriteria_searchCriteria_ContactAnalysis = null;
            }
            if (requestSearchCriteria_searchCriteria_ContactAnalysis != null)
            {
                request.SearchCriteria.ContactAnalysis = requestSearchCriteria_searchCriteria_ContactAnalysis;
                requestSearchCriteriaIsNull = false;
            }
            Amazon.Connect.Model.SearchableContactAttributes requestSearchCriteria_searchCriteria_SearchableContactAttributes = null;
            
             // populate SearchableContactAttributes
            var requestSearchCriteria_searchCriteria_SearchableContactAttributesIsNull = true;
            requestSearchCriteria_searchCriteria_SearchableContactAttributes = new Amazon.Connect.Model.SearchableContactAttributes();
            List<Amazon.Connect.Model.SearchableContactAttributesCriteria> requestSearchCriteria_searchCriteria_SearchableContactAttributes_searchableContactAttributes_Criterion = null;
            if (cmdletContext.SearchableContactAttributes_Criterion != null)
            {
                requestSearchCriteria_searchCriteria_SearchableContactAttributes_searchableContactAttributes_Criterion = cmdletContext.SearchableContactAttributes_Criterion;
            }
            if (requestSearchCriteria_searchCriteria_SearchableContactAttributes_searchableContactAttributes_Criterion != null)
            {
                requestSearchCriteria_searchCriteria_SearchableContactAttributes.Criteria = requestSearchCriteria_searchCriteria_SearchableContactAttributes_searchableContactAttributes_Criterion;
                requestSearchCriteria_searchCriteria_SearchableContactAttributesIsNull = false;
            }
            Amazon.Connect.SearchContactsMatchType requestSearchCriteria_searchCriteria_SearchableContactAttributes_searchableContactAttributes_MatchType = null;
            if (cmdletContext.SearchableContactAttributes_MatchType != null)
            {
                requestSearchCriteria_searchCriteria_SearchableContactAttributes_searchableContactAttributes_MatchType = cmdletContext.SearchableContactAttributes_MatchType;
            }
            if (requestSearchCriteria_searchCriteria_SearchableContactAttributes_searchableContactAttributes_MatchType != null)
            {
                requestSearchCriteria_searchCriteria_SearchableContactAttributes.MatchType = requestSearchCriteria_searchCriteria_SearchableContactAttributes_searchableContactAttributes_MatchType;
                requestSearchCriteria_searchCriteria_SearchableContactAttributesIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_SearchableContactAttributes should be set to null
            if (requestSearchCriteria_searchCriteria_SearchableContactAttributesIsNull)
            {
                requestSearchCriteria_searchCriteria_SearchableContactAttributes = null;
            }
            if (requestSearchCriteria_searchCriteria_SearchableContactAttributes != null)
            {
                request.SearchCriteria.SearchableContactAttributes = requestSearchCriteria_searchCriteria_SearchableContactAttributes;
                requestSearchCriteriaIsNull = false;
            }
            Amazon.Connect.Model.AgentHierarchyGroups requestSearchCriteria_searchCriteria_AgentHierarchyGroups = null;
            
             // populate AgentHierarchyGroups
            var requestSearchCriteria_searchCriteria_AgentHierarchyGroupsIsNull = true;
            requestSearchCriteria_searchCriteria_AgentHierarchyGroups = new Amazon.Connect.Model.AgentHierarchyGroups();
            List<System.String> requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L1Id = null;
            if (cmdletContext.AgentHierarchyGroups_L1Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L1Id = cmdletContext.AgentHierarchyGroups_L1Id;
            }
            if (requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L1Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups.L1Ids = requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L1Id;
                requestSearchCriteria_searchCriteria_AgentHierarchyGroupsIsNull = false;
            }
            List<System.String> requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L2Id = null;
            if (cmdletContext.AgentHierarchyGroups_L2Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L2Id = cmdletContext.AgentHierarchyGroups_L2Id;
            }
            if (requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L2Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups.L2Ids = requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L2Id;
                requestSearchCriteria_searchCriteria_AgentHierarchyGroupsIsNull = false;
            }
            List<System.String> requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L3Id = null;
            if (cmdletContext.AgentHierarchyGroups_L3Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L3Id = cmdletContext.AgentHierarchyGroups_L3Id;
            }
            if (requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L3Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups.L3Ids = requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L3Id;
                requestSearchCriteria_searchCriteria_AgentHierarchyGroupsIsNull = false;
            }
            List<System.String> requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L4Id = null;
            if (cmdletContext.AgentHierarchyGroups_L4Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L4Id = cmdletContext.AgentHierarchyGroups_L4Id;
            }
            if (requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L4Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups.L4Ids = requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L4Id;
                requestSearchCriteria_searchCriteria_AgentHierarchyGroupsIsNull = false;
            }
            List<System.String> requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L5Id = null;
            if (cmdletContext.AgentHierarchyGroups_L5Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L5Id = cmdletContext.AgentHierarchyGroups_L5Id;
            }
            if (requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L5Id != null)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups.L5Ids = requestSearchCriteria_searchCriteria_AgentHierarchyGroups_agentHierarchyGroups_L5Id;
                requestSearchCriteria_searchCriteria_AgentHierarchyGroupsIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_AgentHierarchyGroups should be set to null
            if (requestSearchCriteria_searchCriteria_AgentHierarchyGroupsIsNull)
            {
                requestSearchCriteria_searchCriteria_AgentHierarchyGroups = null;
            }
            if (requestSearchCriteria_searchCriteria_AgentHierarchyGroups != null)
            {
                request.SearchCriteria.AgentHierarchyGroups = requestSearchCriteria_searchCriteria_AgentHierarchyGroups;
                requestSearchCriteriaIsNull = false;
            }
             // determine if request.SearchCriteria should be set to null
            if (requestSearchCriteriaIsNull)
            {
                request.SearchCriteria = null;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.Connect.Model.Sort();
            Amazon.Connect.SortableFieldName requestSort_sort_FieldName = null;
            if (cmdletContext.Sort_FieldName != null)
            {
                requestSort_sort_FieldName = cmdletContext.Sort_FieldName;
            }
            if (requestSort_sort_FieldName != null)
            {
                request.Sort.FieldName = requestSort_sort_FieldName;
                requestSortIsNull = false;
            }
            Amazon.Connect.SortOrder requestSort_sort_Order = null;
            if (cmdletContext.Sort_Order != null)
            {
                requestSort_sort_Order = cmdletContext.Sort_Order;
            }
            if (requestSort_sort_Order != null)
            {
                request.Sort.Order = requestSort_sort_Order;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
            }
            
             // populate TimeRange
            var requestTimeRangeIsNull = true;
            request.TimeRange = new Amazon.Connect.Model.SearchContactsTimeRange();
            System.DateTime? requestTimeRange_timeRange_EndTime = null;
            if (cmdletContext.TimeRange_EndTime != null)
            {
                requestTimeRange_timeRange_EndTime = cmdletContext.TimeRange_EndTime.Value;
            }
            if (requestTimeRange_timeRange_EndTime != null)
            {
                request.TimeRange.EndTime = requestTimeRange_timeRange_EndTime.Value;
                requestTimeRangeIsNull = false;
            }
            System.DateTime? requestTimeRange_timeRange_StartTime = null;
            if (cmdletContext.TimeRange_StartTime != null)
            {
                requestTimeRange_timeRange_StartTime = cmdletContext.TimeRange_StartTime.Value;
            }
            if (requestTimeRange_timeRange_StartTime != null)
            {
                request.TimeRange.StartTime = requestTimeRange_timeRange_StartTime.Value;
                requestTimeRangeIsNull = false;
            }
            Amazon.Connect.SearchContactsTimeRangeType requestTimeRange_timeRange_Type = null;
            if (cmdletContext.TimeRange_Type != null)
            {
                requestTimeRange_timeRange_Type = cmdletContext.TimeRange_Type;
            }
            if (requestTimeRange_timeRange_Type != null)
            {
                request.TimeRange.Type = requestTimeRange_timeRange_Type;
                requestTimeRangeIsNull = false;
            }
             // determine if request.TimeRange should be set to null
            if (requestTimeRangeIsNull)
            {
                request.TimeRange = null;
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
        
        private Amazon.Connect.Model.SearchContactsResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.SearchContactsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "SearchContacts");
            try
            {
                #if DESKTOP
                return client.SearchContacts(request);
                #elif CORECLR
                return client.SearchContactsAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> AgentHierarchyGroups_L1Id { get; set; }
            public List<System.String> AgentHierarchyGroups_L2Id { get; set; }
            public List<System.String> AgentHierarchyGroups_L3Id { get; set; }
            public List<System.String> AgentHierarchyGroups_L4Id { get; set; }
            public List<System.String> AgentHierarchyGroups_L5Id { get; set; }
            public List<System.String> SearchCriteria_AgentId { get; set; }
            public List<System.String> SearchCriteria_Channel { get; set; }
            public List<Amazon.Connect.Model.TranscriptCriteria> Transcript_Criterion { get; set; }
            public Amazon.Connect.SearchContactsMatchType Transcript_MatchType { get; set; }
            public List<System.String> SearchCriteria_InitiationMethod { get; set; }
            public List<System.String> SearchCriteria_QueueId { get; set; }
            public List<Amazon.Connect.Model.SearchableContactAttributesCriteria> SearchableContactAttributes_Criterion { get; set; }
            public Amazon.Connect.SearchContactsMatchType SearchableContactAttributes_MatchType { get; set; }
            public Amazon.Connect.SortableFieldName Sort_FieldName { get; set; }
            public Amazon.Connect.SortOrder Sort_Order { get; set; }
            public System.DateTime? TimeRange_EndTime { get; set; }
            public System.DateTime? TimeRange_StartTime { get; set; }
            public Amazon.Connect.SearchContactsTimeRangeType TimeRange_Type { get; set; }
            public System.Func<Amazon.Connect.Model.SearchContactsResponse, SearchCONNContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
