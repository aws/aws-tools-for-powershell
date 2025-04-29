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
using Amazon.IoTEvents;
using Amazon.IoTEvents.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTE
{
    /// <summary>
    /// Updates an alarm model. Any alarms that were created based on the previous version
    /// are deleted and then created again as new data arrives.
    /// </summary>
    [Cmdlet("Update", "IOTEAlarmModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTEvents.Model.UpdateAlarmModelResponse")]
    [AWSCmdlet("Calls the AWS IoT Events UpdateAlarmModel API operation.", Operation = new[] {"UpdateAlarmModel"}, SelectReturnType = typeof(Amazon.IoTEvents.Model.UpdateAlarmModelResponse))]
    [AWSCmdletOutput("Amazon.IoTEvents.Model.UpdateAlarmModelResponse",
        "This cmdlet returns an Amazon.IoTEvents.Model.UpdateAlarmModelResponse object containing multiple properties."
    )]
    public partial class UpdateIOTEAlarmModelCmdlet : AmazonIoTEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AlarmEventActions_AlarmAction
        /// <summary>
        /// <para>
        /// <para>Specifies one or more supported actions to receive notifications when the alarm state
        /// changes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmEventActions_AlarmActions")]
        public Amazon.IoTEvents.Model.AlarmAction[] AlarmEventActions_AlarmAction { get; set; }
        #endregion
        
        #region Parameter AlarmModelDescription
        /// <summary>
        /// <para>
        /// <para>The description of the alarm model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AlarmModelDescription { get; set; }
        #endregion
        
        #region Parameter AlarmModelName
        /// <summary>
        /// <para>
        /// <para>The name of the alarm model.</para>
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
        public System.String AlarmModelName { get; set; }
        #endregion
        
        #region Parameter SimpleRule_ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>The comparison operator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmRule_SimpleRule_ComparisonOperator")]
        [AWSConstantClassSource("Amazon.IoTEvents.ComparisonOperator")]
        public Amazon.IoTEvents.ComparisonOperator SimpleRule_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter InitializationConfiguration_DisabledOnInitialization
        /// <summary>
        /// <para>
        /// <para>The value must be <c>TRUE</c> or <c>FALSE</c>. If <c>FALSE</c>, all alarm instances
        /// created based on the alarm model are activated. The default value is <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmCapabilities_InitializationConfiguration_DisabledOnInitialization")]
        public System.Boolean? InitializationConfiguration_DisabledOnInitialization { get; set; }
        #endregion
        
        #region Parameter AcknowledgeFlow_Enabled
        /// <summary>
        /// <para>
        /// <para>The value must be <c>TRUE</c> or <c>FALSE</c>. If <c>TRUE</c>, you receive a notification
        /// when the alarm state changes. You must choose to acknowledge the notification before
        /// the alarm state can return to <c>NORMAL</c>. If <c>FALSE</c>, you won't receive notifications.
        /// The alarm automatically changes to the <c>NORMAL</c> state when the input property
        /// value returns to the specified range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmCapabilities_AcknowledgeFlow_Enabled")]
        public System.Boolean? AcknowledgeFlow_Enabled { get; set; }
        #endregion
        
        #region Parameter SimpleRule_InputProperty
        /// <summary>
        /// <para>
        /// <para>The value on the left side of the comparison operator. You can specify an AWS IoT
        /// Events input attribute as an input property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmRule_SimpleRule_InputProperty")]
        public System.String SimpleRule_InputProperty { get; set; }
        #endregion
        
        #region Parameter AlarmNotification_NotificationAction
        /// <summary>
        /// <para>
        /// <para>Contains the notification settings of an alarm model. The settings apply to all alarms
        /// that were created based on this alarm model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmNotification_NotificationActions")]
        public Amazon.IoTEvents.Model.NotificationAction[] AlarmNotification_NotificationAction { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that allows the alarm to perform actions and access AWS resources.
        /// For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a> in the <i>AWS General Reference</i>.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Severity
        /// <summary>
        /// <para>
        /// <para>A non-negative integer that reflects the severity level of the alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Severity { get; set; }
        #endregion
        
        #region Parameter SimpleRule_Threshold
        /// <summary>
        /// <para>
        /// <para>The value on the right side of the comparison operator. You can enter a number or
        /// specify an AWS IoT Events input attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmRule_SimpleRule_Threshold")]
        public System.String SimpleRule_Threshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEvents.Model.UpdateAlarmModelResponse).
        /// Specifying the name of a property of type Amazon.IoTEvents.Model.UpdateAlarmModelResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTEAlarmModel (UpdateAlarmModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTEvents.Model.UpdateAlarmModelResponse, UpdateIOTEAlarmModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcknowledgeFlow_Enabled = this.AcknowledgeFlow_Enabled;
            context.InitializationConfiguration_DisabledOnInitialization = this.InitializationConfiguration_DisabledOnInitialization;
            if (this.AlarmEventActions_AlarmAction != null)
            {
                context.AlarmEventActions_AlarmAction = new List<Amazon.IoTEvents.Model.AlarmAction>(this.AlarmEventActions_AlarmAction);
            }
            context.AlarmModelDescription = this.AlarmModelDescription;
            context.AlarmModelName = this.AlarmModelName;
            #if MODULAR
            if (this.AlarmModelName == null && ParameterWasBound(nameof(this.AlarmModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter AlarmModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AlarmNotification_NotificationAction != null)
            {
                context.AlarmNotification_NotificationAction = new List<Amazon.IoTEvents.Model.NotificationAction>(this.AlarmNotification_NotificationAction);
            }
            context.SimpleRule_ComparisonOperator = this.SimpleRule_ComparisonOperator;
            context.SimpleRule_InputProperty = this.SimpleRule_InputProperty;
            context.SimpleRule_Threshold = this.SimpleRule_Threshold;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Severity = this.Severity;
            
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
            var request = new Amazon.IoTEvents.Model.UpdateAlarmModelRequest();
            
            
             // populate AlarmCapabilities
            var requestAlarmCapabilitiesIsNull = true;
            request.AlarmCapabilities = new Amazon.IoTEvents.Model.AlarmCapabilities();
            Amazon.IoTEvents.Model.AcknowledgeFlow requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow = null;
            
             // populate AcknowledgeFlow
            var requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlowIsNull = true;
            requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow = new Amazon.IoTEvents.Model.AcknowledgeFlow();
            System.Boolean? requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow_acknowledgeFlow_Enabled = null;
            if (cmdletContext.AcknowledgeFlow_Enabled != null)
            {
                requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow_acknowledgeFlow_Enabled = cmdletContext.AcknowledgeFlow_Enabled.Value;
            }
            if (requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow_acknowledgeFlow_Enabled != null)
            {
                requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow.Enabled = requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow_acknowledgeFlow_Enabled.Value;
                requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlowIsNull = false;
            }
             // determine if requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow should be set to null
            if (requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlowIsNull)
            {
                requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow = null;
            }
            if (requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow != null)
            {
                request.AlarmCapabilities.AcknowledgeFlow = requestAlarmCapabilities_alarmCapabilities_AcknowledgeFlow;
                requestAlarmCapabilitiesIsNull = false;
            }
            Amazon.IoTEvents.Model.InitializationConfiguration requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration = null;
            
             // populate InitializationConfiguration
            var requestAlarmCapabilities_alarmCapabilities_InitializationConfigurationIsNull = true;
            requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration = new Amazon.IoTEvents.Model.InitializationConfiguration();
            System.Boolean? requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration_initializationConfiguration_DisabledOnInitialization = null;
            if (cmdletContext.InitializationConfiguration_DisabledOnInitialization != null)
            {
                requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration_initializationConfiguration_DisabledOnInitialization = cmdletContext.InitializationConfiguration_DisabledOnInitialization.Value;
            }
            if (requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration_initializationConfiguration_DisabledOnInitialization != null)
            {
                requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration.DisabledOnInitialization = requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration_initializationConfiguration_DisabledOnInitialization.Value;
                requestAlarmCapabilities_alarmCapabilities_InitializationConfigurationIsNull = false;
            }
             // determine if requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration should be set to null
            if (requestAlarmCapabilities_alarmCapabilities_InitializationConfigurationIsNull)
            {
                requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration = null;
            }
            if (requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration != null)
            {
                request.AlarmCapabilities.InitializationConfiguration = requestAlarmCapabilities_alarmCapabilities_InitializationConfiguration;
                requestAlarmCapabilitiesIsNull = false;
            }
             // determine if request.AlarmCapabilities should be set to null
            if (requestAlarmCapabilitiesIsNull)
            {
                request.AlarmCapabilities = null;
            }
            
             // populate AlarmEventActions
            var requestAlarmEventActionsIsNull = true;
            request.AlarmEventActions = new Amazon.IoTEvents.Model.AlarmEventActions();
            List<Amazon.IoTEvents.Model.AlarmAction> requestAlarmEventActions_alarmEventActions_AlarmAction = null;
            if (cmdletContext.AlarmEventActions_AlarmAction != null)
            {
                requestAlarmEventActions_alarmEventActions_AlarmAction = cmdletContext.AlarmEventActions_AlarmAction;
            }
            if (requestAlarmEventActions_alarmEventActions_AlarmAction != null)
            {
                request.AlarmEventActions.AlarmActions = requestAlarmEventActions_alarmEventActions_AlarmAction;
                requestAlarmEventActionsIsNull = false;
            }
             // determine if request.AlarmEventActions should be set to null
            if (requestAlarmEventActionsIsNull)
            {
                request.AlarmEventActions = null;
            }
            if (cmdletContext.AlarmModelDescription != null)
            {
                request.AlarmModelDescription = cmdletContext.AlarmModelDescription;
            }
            if (cmdletContext.AlarmModelName != null)
            {
                request.AlarmModelName = cmdletContext.AlarmModelName;
            }
            
             // populate AlarmNotification
            var requestAlarmNotificationIsNull = true;
            request.AlarmNotification = new Amazon.IoTEvents.Model.AlarmNotification();
            List<Amazon.IoTEvents.Model.NotificationAction> requestAlarmNotification_alarmNotification_NotificationAction = null;
            if (cmdletContext.AlarmNotification_NotificationAction != null)
            {
                requestAlarmNotification_alarmNotification_NotificationAction = cmdletContext.AlarmNotification_NotificationAction;
            }
            if (requestAlarmNotification_alarmNotification_NotificationAction != null)
            {
                request.AlarmNotification.NotificationActions = requestAlarmNotification_alarmNotification_NotificationAction;
                requestAlarmNotificationIsNull = false;
            }
             // determine if request.AlarmNotification should be set to null
            if (requestAlarmNotificationIsNull)
            {
                request.AlarmNotification = null;
            }
            
             // populate AlarmRule
            var requestAlarmRuleIsNull = true;
            request.AlarmRule = new Amazon.IoTEvents.Model.AlarmRule();
            Amazon.IoTEvents.Model.SimpleRule requestAlarmRule_alarmRule_SimpleRule = null;
            
             // populate SimpleRule
            var requestAlarmRule_alarmRule_SimpleRuleIsNull = true;
            requestAlarmRule_alarmRule_SimpleRule = new Amazon.IoTEvents.Model.SimpleRule();
            Amazon.IoTEvents.ComparisonOperator requestAlarmRule_alarmRule_SimpleRule_simpleRule_ComparisonOperator = null;
            if (cmdletContext.SimpleRule_ComparisonOperator != null)
            {
                requestAlarmRule_alarmRule_SimpleRule_simpleRule_ComparisonOperator = cmdletContext.SimpleRule_ComparisonOperator;
            }
            if (requestAlarmRule_alarmRule_SimpleRule_simpleRule_ComparisonOperator != null)
            {
                requestAlarmRule_alarmRule_SimpleRule.ComparisonOperator = requestAlarmRule_alarmRule_SimpleRule_simpleRule_ComparisonOperator;
                requestAlarmRule_alarmRule_SimpleRuleIsNull = false;
            }
            System.String requestAlarmRule_alarmRule_SimpleRule_simpleRule_InputProperty = null;
            if (cmdletContext.SimpleRule_InputProperty != null)
            {
                requestAlarmRule_alarmRule_SimpleRule_simpleRule_InputProperty = cmdletContext.SimpleRule_InputProperty;
            }
            if (requestAlarmRule_alarmRule_SimpleRule_simpleRule_InputProperty != null)
            {
                requestAlarmRule_alarmRule_SimpleRule.InputProperty = requestAlarmRule_alarmRule_SimpleRule_simpleRule_InputProperty;
                requestAlarmRule_alarmRule_SimpleRuleIsNull = false;
            }
            System.String requestAlarmRule_alarmRule_SimpleRule_simpleRule_Threshold = null;
            if (cmdletContext.SimpleRule_Threshold != null)
            {
                requestAlarmRule_alarmRule_SimpleRule_simpleRule_Threshold = cmdletContext.SimpleRule_Threshold;
            }
            if (requestAlarmRule_alarmRule_SimpleRule_simpleRule_Threshold != null)
            {
                requestAlarmRule_alarmRule_SimpleRule.Threshold = requestAlarmRule_alarmRule_SimpleRule_simpleRule_Threshold;
                requestAlarmRule_alarmRule_SimpleRuleIsNull = false;
            }
             // determine if requestAlarmRule_alarmRule_SimpleRule should be set to null
            if (requestAlarmRule_alarmRule_SimpleRuleIsNull)
            {
                requestAlarmRule_alarmRule_SimpleRule = null;
            }
            if (requestAlarmRule_alarmRule_SimpleRule != null)
            {
                request.AlarmRule.SimpleRule = requestAlarmRule_alarmRule_SimpleRule;
                requestAlarmRuleIsNull = false;
            }
             // determine if request.AlarmRule should be set to null
            if (requestAlarmRuleIsNull)
            {
                request.AlarmRule = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Severity != null)
            {
                request.Severity = cmdletContext.Severity.Value;
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
        
        private Amazon.IoTEvents.Model.UpdateAlarmModelResponse CallAWSServiceOperation(IAmazonIoTEvents client, Amazon.IoTEvents.Model.UpdateAlarmModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events", "UpdateAlarmModel");
            try
            {
                return client.UpdateAlarmModelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AcknowledgeFlow_Enabled { get; set; }
            public System.Boolean? InitializationConfiguration_DisabledOnInitialization { get; set; }
            public List<Amazon.IoTEvents.Model.AlarmAction> AlarmEventActions_AlarmAction { get; set; }
            public System.String AlarmModelDescription { get; set; }
            public System.String AlarmModelName { get; set; }
            public List<Amazon.IoTEvents.Model.NotificationAction> AlarmNotification_NotificationAction { get; set; }
            public Amazon.IoTEvents.ComparisonOperator SimpleRule_ComparisonOperator { get; set; }
            public System.String SimpleRule_InputProperty { get; set; }
            public System.String SimpleRule_Threshold { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? Severity { get; set; }
            public System.Func<Amazon.IoTEvents.Model.UpdateAlarmModelResponse, UpdateIOTEAlarmModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
