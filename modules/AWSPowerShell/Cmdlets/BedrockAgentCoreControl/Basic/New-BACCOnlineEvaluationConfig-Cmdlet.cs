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
    /// Creates an online evaluation configuration for continuous monitoring of agent performance.
    /// Online evaluation automatically samples live traffic from CloudWatch logs at specified
    /// rates and applies evaluators to assess agent quality in production.
    /// </summary>
    [Cmdlet("New", "BACCOnlineEvaluationConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateOnlineEvaluationConfig API operation.", Operation = new[] {"CreateOnlineEvaluationConfig"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigResponse object containing multiple properties."
    )]
    public partial class NewBACCOnlineEvaluationConfigCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The description of the online evaluation configuration that explains its monitoring
        /// purpose and scope. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnableOnCreate
        /// <summary>
        /// <para>
        /// <para> Whether to enable the online evaluation configuration immediately upon creation.
        /// If true, evaluation begins automatically. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? EnableOnCreate { get; set; }
        #endregion
        
        #region Parameter EvaluationExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the IAM role that grants permissions to read from
        /// CloudWatch logs, write evaluation results, and invoke Amazon Bedrock models for evaluation.
        /// </para>
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
        public System.String EvaluationExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Evaluator
        /// <summary>
        /// <para>
        /// <para> The list of evaluators to apply during online evaluation. Can include both built-in
        /// evaluators and custom evaluators created with <c>CreateEvaluator</c>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Evaluators")]
        public Amazon.BedrockAgentCoreControl.Model.EvaluatorReference[] Evaluator { get; set; }
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
        
        #region Parameter OnlineEvaluationConfigName
        /// <summary>
        /// <para>
        /// <para> The name of the online evaluation configuration. Must be unique within your account.
        /// </para>
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
        public System.String OnlineEvaluationConfigName { get; set; }
        #endregion
        
        #region Parameter SamplingConfig_SamplingPercentage
        /// <summary>
        /// <para>
        /// <para> The percentage of agent traces to sample for evaluation, ranging from 0.01% to 100%.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OnlineEvaluationConfigName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCOnlineEvaluationConfig (CreateOnlineEvaluationConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigResponse, NewBACCOnlineEvaluationConfigCmdlet>(Select) ??
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
            context.EnableOnCreate = this.EnableOnCreate;
            #if MODULAR
            if (this.EnableOnCreate == null && ParameterWasBound(nameof(this.EnableOnCreate)))
            {
                WriteWarning("You are passing $null as a value for parameter EnableOnCreate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationExecutionRoleArn = this.EvaluationExecutionRoleArn;
            #if MODULAR
            if (this.EvaluationExecutionRoleArn == null && ParameterWasBound(nameof(this.EvaluationExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Evaluator != null)
            {
                context.Evaluator = new List<Amazon.BedrockAgentCoreControl.Model.EvaluatorReference>(this.Evaluator);
            }
            #if MODULAR
            if (this.Evaluator == null && ParameterWasBound(nameof(this.Evaluator)))
            {
                WriteWarning("You are passing $null as a value for parameter Evaluator which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OnlineEvaluationConfigName = this.OnlineEvaluationConfigName;
            #if MODULAR
            if (this.OnlineEvaluationConfigName == null && ParameterWasBound(nameof(this.OnlineEvaluationConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter OnlineEvaluationConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Rule_Filter != null)
            {
                context.Rule_Filter = new List<Amazon.BedrockAgentCoreControl.Model.Filter>(this.Rule_Filter);
            }
            context.SamplingConfig_SamplingPercentage = this.SamplingConfig_SamplingPercentage;
            #if MODULAR
            if (this.SamplingConfig_SamplingPercentage == null && ParameterWasBound(nameof(this.SamplingConfig_SamplingPercentage)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingConfig_SamplingPercentage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigRequest();
            
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
            if (cmdletContext.EnableOnCreate != null)
            {
                request.EnableOnCreate = cmdletContext.EnableOnCreate.Value;
            }
            if (cmdletContext.EvaluationExecutionRoleArn != null)
            {
                request.EvaluationExecutionRoleArn = cmdletContext.EvaluationExecutionRoleArn;
            }
            if (cmdletContext.Evaluator != null)
            {
                request.Evaluators = cmdletContext.Evaluator;
            }
            if (cmdletContext.OnlineEvaluationConfigName != null)
            {
                request.OnlineEvaluationConfigName = cmdletContext.OnlineEvaluationConfigName;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateOnlineEvaluationConfig");
            try
            {
                return client.CreateOnlineEvaluationConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? EnableOnCreate { get; set; }
            public System.String EvaluationExecutionRoleArn { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.EvaluatorReference> Evaluator { get; set; }
            public System.String OnlineEvaluationConfigName { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.Filter> Rule_Filter { get; set; }
            public System.Double? SamplingConfig_SamplingPercentage { get; set; }
            public System.Int32? SessionConfig_SessionTimeoutMinute { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateOnlineEvaluationConfigResponse, NewBACCOnlineEvaluationConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
