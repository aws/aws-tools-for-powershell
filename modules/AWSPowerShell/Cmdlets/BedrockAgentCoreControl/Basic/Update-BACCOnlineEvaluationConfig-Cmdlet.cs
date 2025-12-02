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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Updates an online evaluation configuration's settings, including rules, data sources,
    /// evaluators, and execution status. Changes take effect immediately for ongoing evaluations.
    /// </summary>
    [Cmdlet("Update", "BACCOnlineEvaluationConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdateOnlineEvaluationConfig API operation.", Operation = new[] {"UpdateOnlineEvaluationConfig"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigResponse object containing multiple properties."
    )]
    public partial class UpdateBACCOnlineEvaluationConfigCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The updated description of the online evaluation configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EvaluationExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para> The updated Amazon Resource Name (ARN) of the IAM role used for evaluation execution.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EvaluationExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Evaluator
        /// <summary>
        /// <para>
        /// <para> The updated list of evaluators to apply during online evaluation. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Evaluators")]
        public Amazon.BedrockAgentCoreControl.Model.EvaluatorReference[] Evaluator { get; set; }
        #endregion
        
        #region Parameter ExecutionStatus
        /// <summary>
        /// <para>
        /// <para> The updated execution status to enable or disable the online evaluation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.OnlineEvaluationExecutionStatus")]
        public Amazon.BedrockAgentCoreControl.OnlineEvaluationExecutionStatus ExecutionStatus { get; set; }
        #endregion
        
        #region Parameter Rule_Filter
        /// <summary>
        /// <para>
        /// <para> The list of filters that determine which agent traces should be included in the evaluation
        /// based on trace properties. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Filters")]
        public Amazon.BedrockAgentCoreControl.Model.Filter[] Rule_Filter { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroupName
        /// <summary>
        /// <para>
        /// <para> The list of CloudWatch log group names to monitor for agent traces.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfig_CloudWatchLogs_LogGroupNames")]
        public System.String[] CloudWatchLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter OnlineEvaluationConfigId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the online evaluation configuration to update. </para>
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
        public System.String OnlineEvaluationConfigId { get; set; }
        #endregion
        
        #region Parameter SamplingConfig_SamplingPercentage
        /// <summary>
        /// <para>
        /// <para> The percentage of agent traces to sample for evaluation, ranging from 0.01% to 100%.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_SamplingConfig_SamplingPercentage")]
        public System.Double? SamplingConfig_SamplingPercentage { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_ServiceName
        /// <summary>
        /// <para>
        /// <para> The list of service names to filter traces within the specified log groups. Used
        /// to identify relevant agent sessions. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfig_CloudWatchLogs_ServiceNames")]
        public System.String[] CloudWatchLogs_ServiceName { get; set; }
        #endregion
        
        #region Parameter SessionConfig_SessionTimeoutMinute
        /// <summary>
        /// <para>
        /// <para> The number of minutes of inactivity after which an agent session is considered complete
        /// and ready for evaluation. Default is 15 minutes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_SessionConfig_SessionTimeoutMinutes")]
        public System.Int32? SessionConfig_SessionTimeoutMinute { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If you don't specify this field, a value is randomly generated for
        /// you. If this token matches a previous request, the service ignores the request, but
        /// doesn't return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OnlineEvaluationConfigId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCOnlineEvaluationConfig (UpdateOnlineEvaluationConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigResponse, UpdateBACCOnlineEvaluationConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.CloudWatchLogs_LogGroupName != null)
            {
                context.CloudWatchLogs_LogGroupName = new List<System.String>(this.CloudWatchLogs_LogGroupName);
            }
            if (this.CloudWatchLogs_ServiceName != null)
            {
                context.CloudWatchLogs_ServiceName = new List<System.String>(this.CloudWatchLogs_ServiceName);
            }
            context.Description = this.Description;
            context.EvaluationExecutionRoleArn = this.EvaluationExecutionRoleArn;
            if (this.Evaluator != null)
            {
                context.Evaluator = new List<Amazon.BedrockAgentCoreControl.Model.EvaluatorReference>(this.Evaluator);
            }
            context.ExecutionStatus = this.ExecutionStatus;
            context.OnlineEvaluationConfigId = this.OnlineEvaluationConfigId;
            #if MODULAR
            if (this.OnlineEvaluationConfigId == null && ParameterWasBound(nameof(this.OnlineEvaluationConfigId)))
            {
                WriteWarning("You are passing $null as a value for parameter OnlineEvaluationConfigId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Rule_Filter != null)
            {
                context.Rule_Filter = new List<Amazon.BedrockAgentCoreControl.Model.Filter>(this.Rule_Filter);
            }
            context.SamplingConfig_SamplingPercentage = this.SamplingConfig_SamplingPercentage;
            context.SessionConfig_SessionTimeoutMinute = this.SessionConfig_SessionTimeoutMinute;
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DataSourceConfig
            var requestDataSourceConfigIsNull = true;
            request.DataSourceConfig = new Amazon.BedrockAgentCoreControl.Model.DataSourceConfig();
            Amazon.BedrockAgentCoreControl.Model.CloudWatchLogsInputConfig requestDataSourceConfig_dataSourceConfig_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestDataSourceConfig_dataSourceConfig_CloudWatchLogsIsNull = true;
            requestDataSourceConfig_dataSourceConfig_CloudWatchLogs = new Amazon.BedrockAgentCoreControl.Model.CloudWatchLogsInputConfig();
            List<System.String> requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_cloudWatchLogs_LogGroupName = null;
            if (cmdletContext.CloudWatchLogs_LogGroupName != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_cloudWatchLogs_LogGroupName = cmdletContext.CloudWatchLogs_LogGroupName;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_cloudWatchLogs_LogGroupName != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs.LogGroupNames = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_cloudWatchLogs_LogGroupName;
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogsIsNull = false;
            }
            List<System.String> requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_cloudWatchLogs_ServiceName = null;
            if (cmdletContext.CloudWatchLogs_ServiceName != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_cloudWatchLogs_ServiceName = cmdletContext.CloudWatchLogs_ServiceName;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_cloudWatchLogs_ServiceName != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs.ServiceNames = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_cloudWatchLogs_ServiceName;
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogsIsNull = false;
            }
             // determine if requestDataSourceConfig_dataSourceConfig_CloudWatchLogs should be set to null
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogsIsNull)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs = null;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs != null)
            {
                request.DataSourceConfig.CloudWatchLogs = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs;
                requestDataSourceConfigIsNull = false;
            }
             // determine if request.DataSourceConfig should be set to null
            if (requestDataSourceConfigIsNull)
            {
                request.DataSourceConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EvaluationExecutionRoleArn != null)
            {
                request.EvaluationExecutionRoleArn = cmdletContext.EvaluationExecutionRoleArn;
            }
            if (cmdletContext.Evaluator != null)
            {
                request.Evaluators = cmdletContext.Evaluator;
            }
            if (cmdletContext.ExecutionStatus != null)
            {
                request.ExecutionStatus = cmdletContext.ExecutionStatus;
            }
            if (cmdletContext.OnlineEvaluationConfigId != null)
            {
                request.OnlineEvaluationConfigId = cmdletContext.OnlineEvaluationConfigId;
            }
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.BedrockAgentCoreControl.Model.Rule();
            List<Amazon.BedrockAgentCoreControl.Model.Filter> requestRule_rule_Filter = null;
            if (cmdletContext.Rule_Filter != null)
            {
                requestRule_rule_Filter = cmdletContext.Rule_Filter;
            }
            if (requestRule_rule_Filter != null)
            {
                request.Rule.Filters = requestRule_rule_Filter;
                requestRuleIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SamplingConfig requestRule_rule_SamplingConfig = null;
            
             // populate SamplingConfig
            var requestRule_rule_SamplingConfigIsNull = true;
            requestRule_rule_SamplingConfig = new Amazon.BedrockAgentCoreControl.Model.SamplingConfig();
            System.Double? requestRule_rule_SamplingConfig_samplingConfig_SamplingPercentage = null;
            if (cmdletContext.SamplingConfig_SamplingPercentage != null)
            {
                requestRule_rule_SamplingConfig_samplingConfig_SamplingPercentage = cmdletContext.SamplingConfig_SamplingPercentage.Value;
            }
            if (requestRule_rule_SamplingConfig_samplingConfig_SamplingPercentage != null)
            {
                requestRule_rule_SamplingConfig.SamplingPercentage = requestRule_rule_SamplingConfig_samplingConfig_SamplingPercentage.Value;
                requestRule_rule_SamplingConfigIsNull = false;
            }
             // determine if requestRule_rule_SamplingConfig should be set to null
            if (requestRule_rule_SamplingConfigIsNull)
            {
                requestRule_rule_SamplingConfig = null;
            }
            if (requestRule_rule_SamplingConfig != null)
            {
                request.Rule.SamplingConfig = requestRule_rule_SamplingConfig;
                requestRuleIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SessionConfig requestRule_rule_SessionConfig = null;
            
             // populate SessionConfig
            var requestRule_rule_SessionConfigIsNull = true;
            requestRule_rule_SessionConfig = new Amazon.BedrockAgentCoreControl.Model.SessionConfig();
            System.Int32? requestRule_rule_SessionConfig_sessionConfig_SessionTimeoutMinute = null;
            if (cmdletContext.SessionConfig_SessionTimeoutMinute != null)
            {
                requestRule_rule_SessionConfig_sessionConfig_SessionTimeoutMinute = cmdletContext.SessionConfig_SessionTimeoutMinute.Value;
            }
            if (requestRule_rule_SessionConfig_sessionConfig_SessionTimeoutMinute != null)
            {
                requestRule_rule_SessionConfig.SessionTimeoutMinutes = requestRule_rule_SessionConfig_sessionConfig_SessionTimeoutMinute.Value;
                requestRule_rule_SessionConfigIsNull = false;
            }
             // determine if requestRule_rule_SessionConfig should be set to null
            if (requestRule_rule_SessionConfigIsNull)
            {
                requestRule_rule_SessionConfig = null;
            }
            if (requestRule_rule_SessionConfig != null)
            {
                request.Rule.SessionConfig = requestRule_rule_SessionConfig;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdateOnlineEvaluationConfig");
            try
            {
                return client.UpdateOnlineEvaluationConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CloudWatchLogs_LogGroupName { get; set; }
            public List<System.String> CloudWatchLogs_ServiceName { get; set; }
            public System.String Description { get; set; }
            public System.String EvaluationExecutionRoleArn { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.EvaluatorReference> Evaluator { get; set; }
            public Amazon.BedrockAgentCoreControl.OnlineEvaluationExecutionStatus ExecutionStatus { get; set; }
            public System.String OnlineEvaluationConfigId { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.Filter> Rule_Filter { get; set; }
            public System.Double? SamplingConfig_SamplingPercentage { get; set; }
            public System.Int32? SessionConfig_SessionTimeoutMinute { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateOnlineEvaluationConfigResponse, UpdateBACCOnlineEvaluationConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
