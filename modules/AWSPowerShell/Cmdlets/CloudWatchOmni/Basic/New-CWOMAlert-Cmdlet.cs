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
using Amazon.CloudWatchOmni;
using Amazon.CloudWatchOmni.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOM
{
    /// <summary>
    /// Creates a new alert within a space.
    /// 
    ///  
    /// <para>
    /// Use GetAlert and ListAlerts to retrieve alerts, UpdateAlert to modify one, and DeleteAlert
    /// to remove it.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWOMAlert", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchOmni.Model.CreateAlertResponse")]
    [AWSCmdlet("Calls the CloudWatch Omni CreateAlert API operation.", Operation = new[] {"CreateAlert"}, SelectReturnType = typeof(Amazon.CloudWatchOmni.Model.CreateAlertResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchOmni.Model.CreateAlertResponse",
        "This cmdlet returns an Amazon.CloudWatchOmni.Model.CreateAlertResponse object containing multiple properties."
    )]
    public partial class NewCWOMAlertCmdlet : AmazonCloudWatchOmniClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Rule_TelemetryRule_Condition_Comparator
        /// <summary>
        /// <para>
        /// <para>The comparison operator applied to the threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.Comparator")]
        public Amazon.CloudWatchOmni.Comparator Rule_TelemetryRule_Condition_Comparator { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_Condition_CriticalThreshold
        /// <summary>
        /// <para>
        /// <para>The value at which the alert enters the CRITICAL state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Rule_TelemetryRule_Condition_CriticalThreshold { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the alert.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_Query_Expression
        /// <summary>
        /// <para>
        /// <para>The query expression to evaluate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Rule_TelemetryRule_Query_Expression { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_Evaluation_IntervalSecond
        /// <summary>
        /// <para>
        /// <para>The interval between evaluations, in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_TelemetryRule_Evaluation_IntervalSeconds")]
        public System.Int32? Rule_TelemetryRule_Evaluation_IntervalSecond { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_Query_Language
        /// <summary>
        /// <para>
        /// <para>The query language of the expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.QueryLanguage")]
        public Amazon.CloudWatchOmni.QueryLanguage Rule_TelemetryRule_Query_Language { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Alert name, for display. Max 256 (the AlarmName budget). Not the alert's identity:
        /// the backend mints a separate uuid as the {@link AlertId}, so the name need not be
        /// unique within a space and addressing an alert never depends on it. UpdateAlert accepts
        /// a new name to rename the alert.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NotificationRule
        /// <summary>
        /// <para>
        /// <para>The notification rules that determine when and where notifications are sent.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotificationRules")]
        public Amazon.CloudWatchOmni.Model.NotificationRule[] NotificationRule { get; set; }
        #endregion
        
        #region Parameter NotificationsEnabled
        /// <summary>
        /// <para>
        /// <para>Whether actions (notifications) are enabled for this alert. Defaults to true when
        /// omitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NotificationsEnabled { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_Evaluation_PendingDurationSecond
        /// <summary>
        /// <para>
        /// <para>The duration a breach must persist before the alert fires, in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_TelemetryRule_Evaluation_PendingDurationSeconds")]
        public System.Int32? Rule_TelemetryRule_Evaluation_PendingDurationSecond { get; set; }
        #endregion
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>The ID of the access profile the alert uses to evaluate its query and execute notifications.
        /// The caller supplies it: there is no managed alert profile, and the service does not
        /// pick one on the caller's behalf.</para>
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
        public System.String ProfileId { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_Evaluation_RecoveryDurationSecond
        /// <summary>
        /// <para>
        /// <para>The duration a recovery must persist before the alert clears, in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_TelemetryRule_Evaluation_RecoveryDurationSeconds")]
        public System.Int32? Rule_TelemetryRule_Evaluation_RecoveryDurationSecond { get; set; }
        #endregion
        
        #region Parameter SpaceId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the space to create the alert in.</para>
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
        public System.String SpaceId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the alert.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_Condition_ThresholdField
        /// <summary>
        /// <para>
        /// <para>The field the threshold is evaluated against.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Rule_TelemetryRule_Condition_ThresholdField { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_Condition_ThresholdMode
        /// <summary>
        /// <para>
        /// <para>How the threshold is applied to query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.ThresholdMode")]
        public Amazon.CloudWatchOmni.ThresholdMode Rule_TelemetryRule_Condition_ThresholdMode { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_NoData_TreatAs
        /// <summary>
        /// <para>
        /// <para>The state to report when an evaluation produces no data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.AlertState")]
        public Amazon.CloudWatchOmni.AlertState Rule_TelemetryRule_NoData_TreatAs { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryRule_Condition_WarningThreshold
        /// <summary>
        /// <para>
        /// <para>The value at which the alert enters the WARNING state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Rule_TelemetryRule_Condition_WarningThreshold { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token for safe retries. Retrying with the same token within the idempotency
        /// window returns the original alert instead of creating a duplicate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchOmni.Model.CreateAlertResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchOmni.Model.CreateAlertResponse will result in that property being returned.
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
                nameof(this.ProfileId),
                nameof(this.SpaceId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWOMAlert (CreateAlert)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchOmni.Model.CreateAlertResponse, NewCWOMAlertCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NotificationRule != null)
            {
                context.NotificationRule = new List<Amazon.CloudWatchOmni.Model.NotificationRule>(this.NotificationRule);
            }
            context.NotificationsEnabled = this.NotificationsEnabled;
            context.ProfileId = this.ProfileId;
            #if MODULAR
            if (this.ProfileId == null && ParameterWasBound(nameof(this.ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rule_TelemetryRule_Condition_Comparator = this.Rule_TelemetryRule_Condition_Comparator;
            context.Rule_TelemetryRule_Condition_CriticalThreshold = this.Rule_TelemetryRule_Condition_CriticalThreshold;
            context.Rule_TelemetryRule_Condition_ThresholdField = this.Rule_TelemetryRule_Condition_ThresholdField;
            context.Rule_TelemetryRule_Condition_ThresholdMode = this.Rule_TelemetryRule_Condition_ThresholdMode;
            context.Rule_TelemetryRule_Condition_WarningThreshold = this.Rule_TelemetryRule_Condition_WarningThreshold;
            context.Rule_TelemetryRule_Evaluation_IntervalSecond = this.Rule_TelemetryRule_Evaluation_IntervalSecond;
            context.Rule_TelemetryRule_Evaluation_PendingDurationSecond = this.Rule_TelemetryRule_Evaluation_PendingDurationSecond;
            context.Rule_TelemetryRule_Evaluation_RecoveryDurationSecond = this.Rule_TelemetryRule_Evaluation_RecoveryDurationSecond;
            context.Rule_TelemetryRule_NoData_TreatAs = this.Rule_TelemetryRule_NoData_TreatAs;
            context.Rule_TelemetryRule_Query_Expression = this.Rule_TelemetryRule_Query_Expression;
            context.Rule_TelemetryRule_Query_Language = this.Rule_TelemetryRule_Query_Language;
            context.SpaceId = this.SpaceId;
            #if MODULAR
            if (this.SpaceId == null && ParameterWasBound(nameof(this.SpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.CloudWatchOmni.Model.CreateAlertRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NotificationRule != null)
            {
                request.NotificationRules = cmdletContext.NotificationRule;
            }
            if (cmdletContext.NotificationsEnabled != null)
            {
                request.NotificationsEnabled = cmdletContext.NotificationsEnabled.Value;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
            }
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.CloudWatchOmni.Model.Rule();
            Amazon.CloudWatchOmni.Model.TelemetryRule requestRule_rule_TelemetryRule = null;
            
             // populate TelemetryRule
            var requestRule_rule_TelemetryRuleIsNull = true;
            requestRule_rule_TelemetryRule = new Amazon.CloudWatchOmni.Model.TelemetryRule();
            Amazon.CloudWatchOmni.Model.NoData requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData = null;
            
             // populate NoData
            var requestRule_rule_TelemetryRule_rule_TelemetryRule_NoDataIsNull = true;
            requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData = new Amazon.CloudWatchOmni.Model.NoData();
            Amazon.CloudWatchOmni.AlertState requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData_rule_TelemetryRule_NoData_TreatAs = null;
            if (cmdletContext.Rule_TelemetryRule_NoData_TreatAs != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData_rule_TelemetryRule_NoData_TreatAs = cmdletContext.Rule_TelemetryRule_NoData_TreatAs;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData_rule_TelemetryRule_NoData_TreatAs != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData.TreatAs = requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData_rule_TelemetryRule_NoData_TreatAs;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_NoDataIsNull = false;
            }
             // determine if requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData should be set to null
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_NoDataIsNull)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData = null;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData != null)
            {
                requestRule_rule_TelemetryRule.NoData = requestRule_rule_TelemetryRule_rule_TelemetryRule_NoData;
                requestRule_rule_TelemetryRuleIsNull = false;
            }
            Amazon.CloudWatchOmni.Model.AlertRuleQuery requestRule_rule_TelemetryRule_rule_TelemetryRule_Query = null;
            
             // populate Query
            var requestRule_rule_TelemetryRule_rule_TelemetryRule_QueryIsNull = true;
            requestRule_rule_TelemetryRule_rule_TelemetryRule_Query = new Amazon.CloudWatchOmni.Model.AlertRuleQuery();
            System.String requestRule_rule_TelemetryRule_rule_TelemetryRule_Query_rule_TelemetryRule_Query_Expression = null;
            if (cmdletContext.Rule_TelemetryRule_Query_Expression != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Query_rule_TelemetryRule_Query_Expression = cmdletContext.Rule_TelemetryRule_Query_Expression;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Query_rule_TelemetryRule_Query_Expression != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Query.Expression = requestRule_rule_TelemetryRule_rule_TelemetryRule_Query_rule_TelemetryRule_Query_Expression;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_QueryIsNull = false;
            }
            Amazon.CloudWatchOmni.QueryLanguage requestRule_rule_TelemetryRule_rule_TelemetryRule_Query_rule_TelemetryRule_Query_Language = null;
            if (cmdletContext.Rule_TelemetryRule_Query_Language != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Query_rule_TelemetryRule_Query_Language = cmdletContext.Rule_TelemetryRule_Query_Language;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Query_rule_TelemetryRule_Query_Language != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Query.Language = requestRule_rule_TelemetryRule_rule_TelemetryRule_Query_rule_TelemetryRule_Query_Language;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_QueryIsNull = false;
            }
             // determine if requestRule_rule_TelemetryRule_rule_TelemetryRule_Query should be set to null
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_QueryIsNull)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Query = null;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Query != null)
            {
                requestRule_rule_TelemetryRule.Query = requestRule_rule_TelemetryRule_rule_TelemetryRule_Query;
                requestRule_rule_TelemetryRuleIsNull = false;
            }
            Amazon.CloudWatchOmni.Model.AlertEvaluation requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation = null;
            
             // populate Evaluation
            var requestRule_rule_TelemetryRule_rule_TelemetryRule_EvaluationIsNull = true;
            requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation = new Amazon.CloudWatchOmni.Model.AlertEvaluation();
            System.Int32? requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_IntervalSecond = null;
            if (cmdletContext.Rule_TelemetryRule_Evaluation_IntervalSecond != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_IntervalSecond = cmdletContext.Rule_TelemetryRule_Evaluation_IntervalSecond.Value;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_IntervalSecond != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation.IntervalSeconds = requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_IntervalSecond.Value;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_EvaluationIsNull = false;
            }
            System.Int32? requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_PendingDurationSecond = null;
            if (cmdletContext.Rule_TelemetryRule_Evaluation_PendingDurationSecond != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_PendingDurationSecond = cmdletContext.Rule_TelemetryRule_Evaluation_PendingDurationSecond.Value;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_PendingDurationSecond != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation.PendingDurationSeconds = requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_PendingDurationSecond.Value;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_EvaluationIsNull = false;
            }
            System.Int32? requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_RecoveryDurationSecond = null;
            if (cmdletContext.Rule_TelemetryRule_Evaluation_RecoveryDurationSecond != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_RecoveryDurationSecond = cmdletContext.Rule_TelemetryRule_Evaluation_RecoveryDurationSecond.Value;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_RecoveryDurationSecond != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation.RecoveryDurationSeconds = requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation_rule_TelemetryRule_Evaluation_RecoveryDurationSecond.Value;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_EvaluationIsNull = false;
            }
             // determine if requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation should be set to null
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_EvaluationIsNull)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation = null;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation != null)
            {
                requestRule_rule_TelemetryRule.Evaluation = requestRule_rule_TelemetryRule_rule_TelemetryRule_Evaluation;
                requestRule_rule_TelemetryRuleIsNull = false;
            }
            Amazon.CloudWatchOmni.Model.AlertCondition requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition = null;
            
             // populate Condition
            var requestRule_rule_TelemetryRule_rule_TelemetryRule_ConditionIsNull = true;
            requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition = new Amazon.CloudWatchOmni.Model.AlertCondition();
            Amazon.CloudWatchOmni.Comparator requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_Comparator = null;
            if (cmdletContext.Rule_TelemetryRule_Condition_Comparator != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_Comparator = cmdletContext.Rule_TelemetryRule_Condition_Comparator;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_Comparator != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition.Comparator = requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_Comparator;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_ConditionIsNull = false;
            }
            System.Double? requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_CriticalThreshold = null;
            if (cmdletContext.Rule_TelemetryRule_Condition_CriticalThreshold != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_CriticalThreshold = cmdletContext.Rule_TelemetryRule_Condition_CriticalThreshold.Value;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_CriticalThreshold != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition.CriticalThreshold = requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_CriticalThreshold.Value;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_ConditionIsNull = false;
            }
            System.String requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_ThresholdField = null;
            if (cmdletContext.Rule_TelemetryRule_Condition_ThresholdField != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_ThresholdField = cmdletContext.Rule_TelemetryRule_Condition_ThresholdField;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_ThresholdField != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition.ThresholdField = requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_ThresholdField;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_ConditionIsNull = false;
            }
            Amazon.CloudWatchOmni.ThresholdMode requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_ThresholdMode = null;
            if (cmdletContext.Rule_TelemetryRule_Condition_ThresholdMode != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_ThresholdMode = cmdletContext.Rule_TelemetryRule_Condition_ThresholdMode;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_ThresholdMode != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition.ThresholdMode = requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_ThresholdMode;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_ConditionIsNull = false;
            }
            System.Double? requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_WarningThreshold = null;
            if (cmdletContext.Rule_TelemetryRule_Condition_WarningThreshold != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_WarningThreshold = cmdletContext.Rule_TelemetryRule_Condition_WarningThreshold.Value;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_WarningThreshold != null)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition.WarningThreshold = requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition_rule_TelemetryRule_Condition_WarningThreshold.Value;
                requestRule_rule_TelemetryRule_rule_TelemetryRule_ConditionIsNull = false;
            }
             // determine if requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition should be set to null
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_ConditionIsNull)
            {
                requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition = null;
            }
            if (requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition != null)
            {
                requestRule_rule_TelemetryRule.Condition = requestRule_rule_TelemetryRule_rule_TelemetryRule_Condition;
                requestRule_rule_TelemetryRuleIsNull = false;
            }
             // determine if requestRule_rule_TelemetryRule should be set to null
            if (requestRule_rule_TelemetryRuleIsNull)
            {
                requestRule_rule_TelemetryRule = null;
            }
            if (requestRule_rule_TelemetryRule != null)
            {
                request.Rule.TelemetryRule = requestRule_rule_TelemetryRule;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
            }
            if (cmdletContext.SpaceId != null)
            {
                request.SpaceId = cmdletContext.SpaceId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CloudWatchOmni.Model.CreateAlertResponse CallAWSServiceOperation(IAmazonCloudWatchOmni client, Amazon.CloudWatchOmni.Model.CreateAlertRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Omni", "CreateAlert");
            try
            {
                return client.CreateAlertAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.CloudWatchOmni.Model.NotificationRule> NotificationRule { get; set; }
            public System.Boolean? NotificationsEnabled { get; set; }
            public System.String ProfileId { get; set; }
            public Amazon.CloudWatchOmni.Comparator Rule_TelemetryRule_Condition_Comparator { get; set; }
            public System.Double? Rule_TelemetryRule_Condition_CriticalThreshold { get; set; }
            public System.String Rule_TelemetryRule_Condition_ThresholdField { get; set; }
            public Amazon.CloudWatchOmni.ThresholdMode Rule_TelemetryRule_Condition_ThresholdMode { get; set; }
            public System.Double? Rule_TelemetryRule_Condition_WarningThreshold { get; set; }
            public System.Int32? Rule_TelemetryRule_Evaluation_IntervalSecond { get; set; }
            public System.Int32? Rule_TelemetryRule_Evaluation_PendingDurationSecond { get; set; }
            public System.Int32? Rule_TelemetryRule_Evaluation_RecoveryDurationSecond { get; set; }
            public Amazon.CloudWatchOmni.AlertState Rule_TelemetryRule_NoData_TreatAs { get; set; }
            public System.String Rule_TelemetryRule_Query_Expression { get; set; }
            public Amazon.CloudWatchOmni.QueryLanguage Rule_TelemetryRule_Query_Language { get; set; }
            public System.String SpaceId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CloudWatchOmni.Model.CreateAlertResponse, NewCWOMAlertCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
