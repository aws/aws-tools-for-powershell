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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a new analysis rule for a configured table. Currently, only one analysis rule
    /// can be created for a given configured table.
    /// </summary>
    [Cmdlet("New", "CRSConfiguredTableAnalysisRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.ConfiguredTableAnalysisRule")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateConfiguredTableAnalysisRule API operation.", Operation = new[] {"CreateConfiguredTableAnalysisRule"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ConfiguredTableAnalysisRule or Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ConfiguredTableAnalysisRule object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRSConfiguredTableAnalysisRuleCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Aggregation_AdditionalAnalysis
        /// <summary>
        /// <para>
        /// <para> An indicator as to whether additional analyses (such as Clean Rooms ML) can be applied
        /// to the output of the direct query. </para><para>The <c>additionalAnalyses</c> parameter is currently supported for the list analysis
        /// rule (<c>AnalysisRuleList</c>) and the custom analysis rule (<c>AnalysisRuleCustom</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_AdditionalAnalyses")]
        [AWSConstantClassSource("Amazon.CleanRooms.AdditionalAnalyses")]
        public Amazon.CleanRooms.AdditionalAnalyses Aggregation_AdditionalAnalysis { get; set; }
        #endregion
        
        #region Parameter Custom_AdditionalAnalysis
        /// <summary>
        /// <para>
        /// <para> An indicator as to whether additional analyses (such as Clean Rooms ML) can be applied
        /// to the output of the direct query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_AdditionalAnalyses")]
        [AWSConstantClassSource("Amazon.CleanRooms.AdditionalAnalyses")]
        public Amazon.CleanRooms.AdditionalAnalyses Custom_AdditionalAnalysis { get; set; }
        #endregion
        
        #region Parameter List_AdditionalAnalysis
        /// <summary>
        /// <para>
        /// <para> An indicator as to whether additional analyses (such as Clean Rooms ML) can be applied
        /// to the output of the direct query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_List_AdditionalAnalyses")]
        [AWSConstantClassSource("Amazon.CleanRooms.AdditionalAnalyses")]
        public Amazon.CleanRooms.AdditionalAnalyses List_AdditionalAnalysis { get; set; }
        #endregion
        
        #region Parameter Aggregation_AggregateColumn
        /// <summary>
        /// <para>
        /// <para>The columns that query runners are allowed to use in aggregation queries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_AggregateColumns")]
        public Amazon.CleanRooms.Model.AggregateColumn[] Aggregation_AggregateColumn { get; set; }
        #endregion
        
        #region Parameter Custom_AllowedAnalysis
        /// <summary>
        /// <para>
        /// <para>The ARN of the analysis templates that are allowed by the custom analysis rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_AllowedAnalyses")]
        public System.String[] Custom_AllowedAnalysis { get; set; }
        #endregion
        
        #region Parameter Custom_AllowedAnalysisProvider
        /// <summary>
        /// <para>
        /// <para>The IDs of the Amazon Web Services accounts that are allowed to query by the custom
        /// analysis rule. Required when <c>allowedAnalyses</c> is <c>ANY_QUERY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_AllowedAnalysisProviders")]
        public System.String[] Custom_AllowedAnalysisProvider { get; set; }
        #endregion
        
        #region Parameter Aggregation_AllowedJoinOperator
        /// <summary>
        /// <para>
        /// <para>Which logical operators (if any) are to be used in an INNER JOIN match condition.
        /// Default is <c>AND</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_AllowedJoinOperators")]
        public System.String[] Aggregation_AllowedJoinOperator { get; set; }
        #endregion
        
        #region Parameter List_AllowedJoinOperator
        /// <summary>
        /// <para>
        /// <para>The logical operators (if any) that are to be used in an INNER JOIN match condition.
        /// Default is <c>AND</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_List_AllowedJoinOperators")]
        public System.String[] List_AllowedJoinOperator { get; set; }
        #endregion
        
        #region Parameter AnalysisRuleType
        /// <summary>
        /// <para>
        /// <para>The type of analysis rule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.ConfiguredTableAnalysisRuleType")]
        public Amazon.CleanRooms.ConfiguredTableAnalysisRuleType AnalysisRuleType { get; set; }
        #endregion
        
        #region Parameter DifferentialPrivacy_Column
        /// <summary>
        /// <para>
        /// <para>The name of the column (such as user_id) that contains the unique identifier of your
        /// users whose privacy you want to protect. If you want to turn on diﬀerential privacy
        /// for two or more tables in a collaboration, you must conﬁgure the same column as the
        /// user identiﬁer column in both analysis rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Columns")]
        public Amazon.CleanRooms.Model.DifferentialPrivacyColumn[] DifferentialPrivacy_Column { get; set; }
        #endregion
        
        #region Parameter ConfiguredTableIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the configured table to create the analysis rule for. Currently
        /// accepts the configured table ID. </para>
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
        public System.String ConfiguredTableIdentifier { get; set; }
        #endregion
        
        #region Parameter Aggregation_DimensionColumn
        /// <summary>
        /// <para>
        /// <para>The columns that query runners are allowed to select, group by, or filter by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_DimensionColumns")]
        public System.String[] Aggregation_DimensionColumn { get; set; }
        #endregion
        
        #region Parameter Custom_DisallowedOutputColumn
        /// <summary>
        /// <para>
        /// <para> A list of columns that aren't allowed to be shown in the query output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_DisallowedOutputColumns")]
        public System.String[] Custom_DisallowedOutputColumn { get; set; }
        #endregion
        
        #region Parameter Aggregation_JoinColumn
        /// <summary>
        /// <para>
        /// <para>Columns in configured table that can be used in join statements and/or as aggregate
        /// columns. They can never be outputted directly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_JoinColumns")]
        public System.String[] Aggregation_JoinColumn { get; set; }
        #endregion
        
        #region Parameter List_JoinColumn
        /// <summary>
        /// <para>
        /// <para>Columns that can be used to join a configured table with the table of the member who
        /// can query and other members' configured tables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_List_JoinColumns")]
        public System.String[] List_JoinColumn { get; set; }
        #endregion
        
        #region Parameter Aggregation_JoinRequired
        /// <summary>
        /// <para>
        /// <para>Control that requires member who runs query to do a join with their configured table
        /// and/or other configured table in query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_JoinRequired")]
        [AWSConstantClassSource("Amazon.CleanRooms.JoinRequiredOption")]
        public Amazon.CleanRooms.JoinRequiredOption Aggregation_JoinRequired { get; set; }
        #endregion
        
        #region Parameter List_ListColumn
        /// <summary>
        /// <para>
        /// <para>Columns that can be listed in the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_List_ListColumns")]
        public System.String[] List_ListColumn { get; set; }
        #endregion
        
        #region Parameter Aggregation_OutputConstraint
        /// <summary>
        /// <para>
        /// <para>Columns that must meet a specific threshold value (after an aggregation function is
        /// applied to it) for each output row to be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_OutputConstraints")]
        public Amazon.CleanRooms.Model.AggregationConstraint[] Aggregation_OutputConstraint { get; set; }
        #endregion
        
        #region Parameter Aggregation_ScalarFunction
        /// <summary>
        /// <para>
        /// <para>Set of scalar functions that are allowed to be used on dimension columns and the output
        /// of aggregation of metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_ScalarFunctions")]
        public System.String[] Aggregation_ScalarFunction { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalysisRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnalysisRule";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfiguredTableIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSConfiguredTableAnalysisRule (CreateConfiguredTableAnalysisRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse, NewCRSConfiguredTableAnalysisRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Aggregation_AdditionalAnalysis = this.Aggregation_AdditionalAnalysis;
            if (this.Aggregation_AggregateColumn != null)
            {
                context.Aggregation_AggregateColumn = new List<Amazon.CleanRooms.Model.AggregateColumn>(this.Aggregation_AggregateColumn);
            }
            if (this.Aggregation_AllowedJoinOperator != null)
            {
                context.Aggregation_AllowedJoinOperator = new List<System.String>(this.Aggregation_AllowedJoinOperator);
            }
            if (this.Aggregation_DimensionColumn != null)
            {
                context.Aggregation_DimensionColumn = new List<System.String>(this.Aggregation_DimensionColumn);
            }
            if (this.Aggregation_JoinColumn != null)
            {
                context.Aggregation_JoinColumn = new List<System.String>(this.Aggregation_JoinColumn);
            }
            context.Aggregation_JoinRequired = this.Aggregation_JoinRequired;
            if (this.Aggregation_OutputConstraint != null)
            {
                context.Aggregation_OutputConstraint = new List<Amazon.CleanRooms.Model.AggregationConstraint>(this.Aggregation_OutputConstraint);
            }
            if (this.Aggregation_ScalarFunction != null)
            {
                context.Aggregation_ScalarFunction = new List<System.String>(this.Aggregation_ScalarFunction);
            }
            context.Custom_AdditionalAnalysis = this.Custom_AdditionalAnalysis;
            if (this.Custom_AllowedAnalysis != null)
            {
                context.Custom_AllowedAnalysis = new List<System.String>(this.Custom_AllowedAnalysis);
            }
            if (this.Custom_AllowedAnalysisProvider != null)
            {
                context.Custom_AllowedAnalysisProvider = new List<System.String>(this.Custom_AllowedAnalysisProvider);
            }
            if (this.DifferentialPrivacy_Column != null)
            {
                context.DifferentialPrivacy_Column = new List<Amazon.CleanRooms.Model.DifferentialPrivacyColumn>(this.DifferentialPrivacy_Column);
            }
            if (this.Custom_DisallowedOutputColumn != null)
            {
                context.Custom_DisallowedOutputColumn = new List<System.String>(this.Custom_DisallowedOutputColumn);
            }
            context.List_AdditionalAnalysis = this.List_AdditionalAnalysis;
            if (this.List_AllowedJoinOperator != null)
            {
                context.List_AllowedJoinOperator = new List<System.String>(this.List_AllowedJoinOperator);
            }
            if (this.List_JoinColumn != null)
            {
                context.List_JoinColumn = new List<System.String>(this.List_JoinColumn);
            }
            if (this.List_ListColumn != null)
            {
                context.List_ListColumn = new List<System.String>(this.List_ListColumn);
            }
            context.AnalysisRuleType = this.AnalysisRuleType;
            #if MODULAR
            if (this.AnalysisRuleType == null && ParameterWasBound(nameof(this.AnalysisRuleType)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisRuleType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfiguredTableIdentifier = this.ConfiguredTableIdentifier;
            #if MODULAR
            if (this.ConfiguredTableIdentifier == null && ParameterWasBound(nameof(this.ConfiguredTableIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredTableIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleRequest();
            
            
             // populate AnalysisRulePolicy
            var requestAnalysisRulePolicyIsNull = true;
            request.AnalysisRulePolicy = new Amazon.CleanRooms.Model.ConfiguredTableAnalysisRulePolicy();
            Amazon.CleanRooms.Model.ConfiguredTableAnalysisRulePolicyV1 requestAnalysisRulePolicy_analysisRulePolicy_V1 = null;
            
             // populate V1
            var requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1 = new Amazon.CleanRooms.Model.ConfiguredTableAnalysisRulePolicyV1();
            Amazon.CleanRooms.Model.AnalysisRuleList requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List = null;
            
             // populate List
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List = new Amazon.CleanRooms.Model.AnalysisRuleList();
            Amazon.CleanRooms.AdditionalAnalyses requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AdditionalAnalysis = null;
            if (cmdletContext.List_AdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AdditionalAnalysis = cmdletContext.List_AdditionalAnalysis;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List.AdditionalAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AdditionalAnalysis;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedJoinOperator = null;
            if (cmdletContext.List_AllowedJoinOperator != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedJoinOperator = cmdletContext.List_AllowedJoinOperator;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedJoinOperator != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List.AllowedJoinOperators = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedJoinOperator;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_JoinColumn = null;
            if (cmdletContext.List_JoinColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_JoinColumn = cmdletContext.List_JoinColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_JoinColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List.JoinColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_JoinColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_ListColumn = null;
            if (cmdletContext.List_ListColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_ListColumn = cmdletContext.List_ListColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_ListColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List.ListColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_ListColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1.List = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List;
                requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = false;
            }
            Amazon.CleanRooms.Model.AnalysisRuleCustom requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom = null;
            
             // populate Custom
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom = new Amazon.CleanRooms.Model.AnalysisRuleCustom();
            Amazon.CleanRooms.AdditionalAnalyses requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AdditionalAnalysis = null;
            if (cmdletContext.Custom_AdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AdditionalAnalysis = cmdletContext.Custom_AdditionalAnalysis;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AdditionalAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AdditionalAnalysis;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAnalysis = null;
            if (cmdletContext.Custom_AllowedAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAnalysis = cmdletContext.Custom_AllowedAnalysis;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AllowedAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAnalysis;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAnalysisProvider = null;
            if (cmdletContext.Custom_AllowedAnalysisProvider != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAnalysisProvider = cmdletContext.Custom_AllowedAnalysisProvider;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAnalysisProvider != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AllowedAnalysisProviders = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAnalysisProvider;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_DisallowedOutputColumn = null;
            if (cmdletContext.Custom_DisallowedOutputColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_DisallowedOutputColumn = cmdletContext.Custom_DisallowedOutputColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_DisallowedOutputColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.DisallowedOutputColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_DisallowedOutputColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            Amazon.CleanRooms.Model.DifferentialPrivacyConfiguration requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy = null;
            
             // populate DifferentialPrivacy
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacyIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy = new Amazon.CleanRooms.Model.DifferentialPrivacyConfiguration();
            List<Amazon.CleanRooms.Model.DifferentialPrivacyColumn> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy_differentialPrivacy_Column = null;
            if (cmdletContext.DifferentialPrivacy_Column != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy_differentialPrivacy_Column = cmdletContext.DifferentialPrivacy_Column;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy_differentialPrivacy_Column != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy.Columns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy_differentialPrivacy_Column;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacyIsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacyIsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.DifferentialPrivacy = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1.Custom = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom;
                requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = false;
            }
            Amazon.CleanRooms.Model.AnalysisRuleAggregation requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation = null;
            
             // populate Aggregation
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation = new Amazon.CleanRooms.Model.AnalysisRuleAggregation();
            Amazon.CleanRooms.AdditionalAnalyses requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AdditionalAnalysis = null;
            if (cmdletContext.Aggregation_AdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AdditionalAnalysis = cmdletContext.Aggregation_AdditionalAnalysis;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.AdditionalAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AdditionalAnalysis;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<Amazon.CleanRooms.Model.AggregateColumn> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AggregateColumn = null;
            if (cmdletContext.Aggregation_AggregateColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AggregateColumn = cmdletContext.Aggregation_AggregateColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AggregateColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.AggregateColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AggregateColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedJoinOperator = null;
            if (cmdletContext.Aggregation_AllowedJoinOperator != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedJoinOperator = cmdletContext.Aggregation_AllowedJoinOperator;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedJoinOperator != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.AllowedJoinOperators = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedJoinOperator;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_DimensionColumn = null;
            if (cmdletContext.Aggregation_DimensionColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_DimensionColumn = cmdletContext.Aggregation_DimensionColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_DimensionColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.DimensionColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_DimensionColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinColumn = null;
            if (cmdletContext.Aggregation_JoinColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinColumn = cmdletContext.Aggregation_JoinColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.JoinColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            Amazon.CleanRooms.JoinRequiredOption requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinRequired = null;
            if (cmdletContext.Aggregation_JoinRequired != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinRequired = cmdletContext.Aggregation_JoinRequired;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinRequired != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.JoinRequired = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinRequired;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<Amazon.CleanRooms.Model.AggregationConstraint> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_OutputConstraint = null;
            if (cmdletContext.Aggregation_OutputConstraint != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_OutputConstraint = cmdletContext.Aggregation_OutputConstraint;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_OutputConstraint != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.OutputConstraints = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_OutputConstraint;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_ScalarFunction = null;
            if (cmdletContext.Aggregation_ScalarFunction != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_ScalarFunction = cmdletContext.Aggregation_ScalarFunction;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_ScalarFunction != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.ScalarFunctions = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_ScalarFunction;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1.Aggregation = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation;
                requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1 should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1 = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1 != null)
            {
                request.AnalysisRulePolicy.V1 = requestAnalysisRulePolicy_analysisRulePolicy_V1;
                requestAnalysisRulePolicyIsNull = false;
            }
             // determine if request.AnalysisRulePolicy should be set to null
            if (requestAnalysisRulePolicyIsNull)
            {
                request.AnalysisRulePolicy = null;
            }
            if (cmdletContext.AnalysisRuleType != null)
            {
                request.AnalysisRuleType = cmdletContext.AnalysisRuleType;
            }
            if (cmdletContext.ConfiguredTableIdentifier != null)
            {
                request.ConfiguredTableIdentifier = cmdletContext.ConfiguredTableIdentifier;
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
        
        private Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateConfiguredTableAnalysisRule");
            try
            {
                return client.CreateConfiguredTableAnalysisRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CleanRooms.AdditionalAnalyses Aggregation_AdditionalAnalysis { get; set; }
            public List<Amazon.CleanRooms.Model.AggregateColumn> Aggregation_AggregateColumn { get; set; }
            public List<System.String> Aggregation_AllowedJoinOperator { get; set; }
            public List<System.String> Aggregation_DimensionColumn { get; set; }
            public List<System.String> Aggregation_JoinColumn { get; set; }
            public Amazon.CleanRooms.JoinRequiredOption Aggregation_JoinRequired { get; set; }
            public List<Amazon.CleanRooms.Model.AggregationConstraint> Aggregation_OutputConstraint { get; set; }
            public List<System.String> Aggregation_ScalarFunction { get; set; }
            public Amazon.CleanRooms.AdditionalAnalyses Custom_AdditionalAnalysis { get; set; }
            public List<System.String> Custom_AllowedAnalysis { get; set; }
            public List<System.String> Custom_AllowedAnalysisProvider { get; set; }
            public List<Amazon.CleanRooms.Model.DifferentialPrivacyColumn> DifferentialPrivacy_Column { get; set; }
            public List<System.String> Custom_DisallowedOutputColumn { get; set; }
            public Amazon.CleanRooms.AdditionalAnalyses List_AdditionalAnalysis { get; set; }
            public List<System.String> List_AllowedJoinOperator { get; set; }
            public List<System.String> List_JoinColumn { get; set; }
            public List<System.String> List_ListColumn { get; set; }
            public Amazon.CleanRooms.ConfiguredTableAnalysisRuleType AnalysisRuleType { get; set; }
            public System.String ConfiguredTableIdentifier { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse, NewCRSConfiguredTableAnalysisRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalysisRule;
        }
        
    }
}
