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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Updates the analysis rule policy for an intermediate table. Only the intermediate
    /// table owner can call this operation.
    /// </summary>
    [Cmdlet("Update", "CRSIntermediateTableAnalysisRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.IntermediateTableAnalysisRule")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service UpdateIntermediateTableAnalysisRule API operation.", Operation = new[] {"UpdateIntermediateTableAnalysisRule"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.IntermediateTableAnalysisRule or Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.IntermediateTableAnalysisRule object.",
        "The service call response (type Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCRSIntermediateTableAnalysisRuleCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnalysisRulePolicy_V1_Custom_AdditionalAnalyses
        /// <summary>
        /// <para>
        /// <para>The setting that controls whether additional analyses are allowed on the intermediate
        /// table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CleanRooms.AdditionalAnalyses")]
        public Amazon.CleanRooms.AdditionalAnalyses AnalysisRulePolicy_V1_Custom_AdditionalAnalyses { get; set; }
        #endregion
        
        #region Parameter AnalysisRulePolicy_V1_Custom_AggregationThreshold
        /// <summary>
        /// <para>
        /// <para>The aggregation thresholds that each query output group must satisfy. Clean Rooms
        /// filters out any group that represents fewer than the specified number of distinct
        /// identities. You can specify at most one threshold. You can't use aggregation thresholds
        /// with differential privacy, or when <c>allowedAnalyses</c> allows only jobs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_AggregationThresholds")]
        public Amazon.CleanRooms.Model.AggregationThreshold[] AnalysisRulePolicy_V1_Custom_AggregationThreshold { get; set; }
        #endregion
        
        #region Parameter AnalysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses
        /// <summary>
        /// <para>
        /// <para>The list of allowed additional analyses for the intermediate table.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AnalysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses { get; set; }
        #endregion
        
        #region Parameter AnalysisRulePolicy_V1_Custom_AllowedAnalyses
        /// <summary>
        /// <para>
        /// <para>The list of allowed analyses that can be performed on the intermediate table.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AnalysisRulePolicy_V1_Custom_AllowedAnalyses { get; set; }
        #endregion
        
        #region Parameter AnalysisRulePolicy_V1_Custom_AllowedAnalysisProvider
        /// <summary>
        /// <para>
        /// <para>The list of Amazon Web Services account IDs for the allowed analysis providers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_AllowedAnalysisProviders")]
        public System.String[] AnalysisRulePolicy_V1_Custom_AllowedAnalysisProvider { get; set; }
        #endregion
        
        #region Parameter AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn
        /// <summary>
        /// <para>
        /// <para>The columns that a query can compare to another column, for example, in a join, a
        /// WHERE clause, a GROUP BY clause, or a window function. Clean Rooms rejects a query
        /// that uses any other column in a column-to-column comparison. Specify an empty list
        /// to block column-to-column comparison on every column.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumns")]
        public System.String[] AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn { get; set; }
        #endregion
        
        #region Parameter AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn
        /// <summary>
        /// <para>
        /// <para>The columns that a query can compare to literal values, for example, in a WHERE clause.
        /// Clean Rooms rejects a query that compares any other column to a literal value. Specify
        /// an empty list to block literal comparison on every column. You can't specify a column
        /// that you also use as an identity column in an aggregation threshold.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumns")]
        public System.String[] AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn { get; set; }
        #endregion
        
        #region Parameter AnalysisRulePolicy_V1_Custom_AllowedResultReceiver
        /// <summary>
        /// <para>
        /// <para>The list of Amazon Web Services account IDs that are allowed to receive results from
        /// queries run on the intermediate table.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_AllowedResultReceivers")]
        public System.String[] AnalysisRulePolicy_V1_Custom_AllowedResultReceiver { get; set; }
        #endregion
        
        #region Parameter AnalysisRuleType
        /// <summary>
        /// <para>
        /// <para>The type of analysis rule to update. Currently, only <c>CUSTOM</c> is supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.IntermediateTableAnalysisRuleType")]
        public Amazon.CleanRooms.IntermediateTableAnalysisRuleType AnalysisRuleType { get; set; }
        #endregion
        
        #region Parameter AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Column
        /// <summary>
        /// <para>
        /// <para>The name of the column (such as user_id) that contains the unique identifier of your
        /// users whose privacy you want to protect. If you want to turn on diﬀerential privacy
        /// for two or more tables in a collaboration, you must conﬁgure the same column as the
        /// user identiﬁer column in both analysis rules.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Columns")]
        public Amazon.CleanRooms.Model.DifferentialPrivacyColumn[] AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Column { get; set; }
        #endregion
        
        #region Parameter AnalysisRulePolicy_V1_Custom_DisallowedOutputColumn
        /// <summary>
        /// <para>
        /// <para>The list of columns that are not allowed in the query output.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_DisallowedOutputColumns")]
        public System.String[] AnalysisRulePolicy_V1_Custom_DisallowedOutputColumn { get; set; }
        #endregion
        
        #region Parameter IntermediateTableIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the intermediate table for which to update the analysis rule.</para>
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
        public System.String IntermediateTableIdentifier { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the membership that contains the intermediate table.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalysisRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.IntermediateTableIdentifier),
                nameof(this.MembershipIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CRSIntermediateTableAnalysisRule (UpdateIntermediateTableAnalysisRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleResponse, UpdateCRSIntermediateTableAnalysisRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnalysisRulePolicy_V1_Custom_AdditionalAnalyses = this.AnalysisRulePolicy_V1_Custom_AdditionalAnalyses;
            if (this.AnalysisRulePolicy_V1_Custom_AggregationThreshold != null)
            {
                context.AnalysisRulePolicy_V1_Custom_AggregationThreshold = new List<Amazon.CleanRooms.Model.AggregationThreshold>(this.AnalysisRulePolicy_V1_Custom_AggregationThreshold);
            }
            if (this.AnalysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses != null)
            {
                context.AnalysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses = new List<System.String>(this.AnalysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses);
            }
            if (this.AnalysisRulePolicy_V1_Custom_AllowedAnalyses != null)
            {
                context.AnalysisRulePolicy_V1_Custom_AllowedAnalyses = new List<System.String>(this.AnalysisRulePolicy_V1_Custom_AllowedAnalyses);
            }
            if (this.AnalysisRulePolicy_V1_Custom_AllowedAnalysisProvider != null)
            {
                context.AnalysisRulePolicy_V1_Custom_AllowedAnalysisProvider = new List<System.String>(this.AnalysisRulePolicy_V1_Custom_AllowedAnalysisProvider);
            }
            if (this.AnalysisRulePolicy_V1_Custom_AllowedResultReceiver != null)
            {
                context.AnalysisRulePolicy_V1_Custom_AllowedResultReceiver = new List<System.String>(this.AnalysisRulePolicy_V1_Custom_AllowedResultReceiver);
            }
            if (this.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn != null)
            {
                context.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn = new List<System.String>(this.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn);
            }
            if (this.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn != null)
            {
                context.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn = new List<System.String>(this.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn);
            }
            if (this.AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Column != null)
            {
                context.AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Column = new List<Amazon.CleanRooms.Model.DifferentialPrivacyColumn>(this.AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Column);
            }
            if (this.AnalysisRulePolicy_V1_Custom_DisallowedOutputColumn != null)
            {
                context.AnalysisRulePolicy_V1_Custom_DisallowedOutputColumn = new List<System.String>(this.AnalysisRulePolicy_V1_Custom_DisallowedOutputColumn);
            }
            context.AnalysisRuleType = this.AnalysisRuleType;
            #if MODULAR
            if (this.AnalysisRuleType == null && ParameterWasBound(nameof(this.AnalysisRuleType)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisRuleType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IntermediateTableIdentifier = this.IntermediateTableIdentifier;
            #if MODULAR
            if (this.IntermediateTableIdentifier == null && ParameterWasBound(nameof(this.IntermediateTableIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IntermediateTableIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleRequest();
            
            
             // populate AnalysisRulePolicy
            var requestAnalysisRulePolicyIsNull = true;
            request.AnalysisRulePolicy = new Amazon.CleanRooms.Model.IntermediateTableAnalysisRulePolicy();
            Amazon.CleanRooms.Model.IntermediateTableAnalysisRulePolicyV1 requestAnalysisRulePolicy_analysisRulePolicy_V1 = null;
            
             // populate V1
            var requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1 = new Amazon.CleanRooms.Model.IntermediateTableAnalysisRulePolicyV1();
            Amazon.CleanRooms.Model.IntermediateTableAnalysisRuleCustom requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom = null;
            
             // populate Custom
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom = new Amazon.CleanRooms.Model.IntermediateTableAnalysisRuleCustom();
            Amazon.CleanRooms.AdditionalAnalyses requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AdditionalAnalyses = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_AdditionalAnalyses != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AdditionalAnalyses = cmdletContext.AnalysisRulePolicy_V1_Custom_AdditionalAnalyses;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AdditionalAnalyses != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AdditionalAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AdditionalAnalyses;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<Amazon.CleanRooms.Model.AggregationThreshold> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AggregationThreshold = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_AggregationThreshold != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AggregationThreshold = cmdletContext.AnalysisRulePolicy_V1_Custom_AggregationThreshold;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AggregationThreshold != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AggregationThresholds = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AggregationThreshold;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses = cmdletContext.AnalysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AllowedAdditionalAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAnalyses = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_AllowedAnalyses != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAnalyses = cmdletContext.AnalysisRulePolicy_V1_Custom_AllowedAnalyses;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAnalyses != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AllowedAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAnalyses;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAnalysisProvider = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_AllowedAnalysisProvider != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAnalysisProvider = cmdletContext.AnalysisRulePolicy_V1_Custom_AllowedAnalysisProvider;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAnalysisProvider != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AllowedAnalysisProviders = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedAnalysisProvider;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedResultReceiver = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_AllowedResultReceiver != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedResultReceiver = cmdletContext.AnalysisRulePolicy_V1_Custom_AllowedResultReceiver;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedResultReceiver != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AllowedResultReceivers = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_AllowedResultReceiver;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DisallowedOutputColumn = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_DisallowedOutputColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DisallowedOutputColumn = cmdletContext.AnalysisRulePolicy_V1_Custom_DisallowedOutputColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DisallowedOutputColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.DisallowedOutputColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DisallowedOutputColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            Amazon.CleanRooms.Model.DifferentialPrivacyConfiguration requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy = null;
            
             // populate DifferentialPrivacy
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacyIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy = new Amazon.CleanRooms.Model.DifferentialPrivacyConfiguration();
            List<Amazon.CleanRooms.Model.DifferentialPrivacyColumn> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy_analysisRulePolicy_V1_Custom_DifferentialPrivacy_Column = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Column != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy_analysisRulePolicy_V1_Custom_DifferentialPrivacy_Column = cmdletContext.AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Column;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy_analysisRulePolicy_V1_Custom_DifferentialPrivacy_Column != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy.Columns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_DifferentialPrivacy_analysisRulePolicy_V1_Custom_DifferentialPrivacy_Column;
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
            Amazon.CleanRooms.Model.ComparisonControls requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls = null;
            
             // populate ComparisonControls
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControlsIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls = new Amazon.CleanRooms.Model.ComparisonControls();
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls_analysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls_analysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn = cmdletContext.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls_analysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls.AllowedColumnComparisonColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls_analysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControlsIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls_analysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn = null;
            if (cmdletContext.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls_analysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn = cmdletContext.AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls_analysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls.AllowedLiteralComparisonColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls_analysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControlsIsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControlsIsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.ComparisonControls = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_analysisRulePolicy_V1_Custom_ComparisonControls;
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
            if (cmdletContext.IntermediateTableIdentifier != null)
            {
                request.IntermediateTableIdentifier = cmdletContext.IntermediateTableIdentifier;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
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
        
        private Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "UpdateIntermediateTableAnalysisRule");
            try
            {
                return client.UpdateIntermediateTableAnalysisRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CleanRooms.AdditionalAnalyses AnalysisRulePolicy_V1_Custom_AdditionalAnalyses { get; set; }
            public List<Amazon.CleanRooms.Model.AggregationThreshold> AnalysisRulePolicy_V1_Custom_AggregationThreshold { get; set; }
            public List<System.String> AnalysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses { get; set; }
            public List<System.String> AnalysisRulePolicy_V1_Custom_AllowedAnalyses { get; set; }
            public List<System.String> AnalysisRulePolicy_V1_Custom_AllowedAnalysisProvider { get; set; }
            public List<System.String> AnalysisRulePolicy_V1_Custom_AllowedResultReceiver { get; set; }
            public List<System.String> AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedColumnComparisonColumn { get; set; }
            public List<System.String> AnalysisRulePolicy_V1_Custom_ComparisonControls_AllowedLiteralComparisonColumn { get; set; }
            public List<Amazon.CleanRooms.Model.DifferentialPrivacyColumn> AnalysisRulePolicy_V1_Custom_DifferentialPrivacy_Column { get; set; }
            public List<System.String> AnalysisRulePolicy_V1_Custom_DisallowedOutputColumn { get; set; }
            public Amazon.CleanRooms.IntermediateTableAnalysisRuleType AnalysisRuleType { get; set; }
            public System.String IntermediateTableIdentifier { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.Func<Amazon.CleanRooms.Model.UpdateIntermediateTableAnalysisRuleResponse, UpdateCRSIntermediateTableAnalysisRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalysisRule;
        }
        
    }
}
