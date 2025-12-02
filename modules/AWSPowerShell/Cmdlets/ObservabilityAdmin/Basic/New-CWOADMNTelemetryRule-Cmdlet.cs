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
using Amazon.ObservabilityAdmin;
using Amazon.ObservabilityAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.CWOADMN
{
    /// <summary>
    /// Creates a telemetry rule that defines how telemetry should be configured for Amazon
    /// Web Services resources in your account. The rule specifies which resources should
    /// have telemetry enabled and how that telemetry data should be collected based on resource
    /// type, telemetry type, and selection criteria.
    /// </summary>
    [Cmdlet("New", "CWOADMNTelemetryRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service CreateTelemetryRule API operation.", Operation = new[] {"CreateTelemetryRule"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWOADMNTelemetryRuleCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudtrailParameters_AdvancedEventSelector
        /// <summary>
        /// <para>
        /// <para> The advanced event selectors to use for filtering Amazon Web Services CloudTrail
        /// events. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_CloudtrailParameters_AdvancedEventSelectors")]
        public Amazon.ObservabilityAdmin.Model.AdvancedEventSelector[] CloudtrailParameters_AdvancedEventSelector { get; set; }
        #endregion
        
        #region Parameter LoggingFilter_DefaultBehavior
        /// <summary>
        /// <para>
        /// <para> The default action (KEEP or DROP) for log records that don't match any filter conditions.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_DefaultBehavior")]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.FilterBehavior")]
        public Amazon.ObservabilityAdmin.FilterBehavior LoggingFilter_DefaultBehavior { get; set; }
        #endregion
        
        #region Parameter DestinationConfiguration_DestinationPattern
        /// <summary>
        /// <para>
        /// <para> The pattern used to generate the destination path or name, supporting macros like
        /// &lt;resourceId&gt; and &lt;accountId&gt;. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_DestinationPattern")]
        public System.String DestinationConfiguration_DestinationPattern { get; set; }
        #endregion
        
        #region Parameter DestinationConfiguration_DestinationType
        /// <summary>
        /// <para>
        /// <para> The type of destination for the telemetry data (e.g., "Amazon CloudWatch Logs", "S3").
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_DestinationType")]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.DestinationType")]
        public Amazon.ObservabilityAdmin.DestinationType DestinationConfiguration_DestinationType { get; set; }
        #endregion
        
        #region Parameter ELBLoadBalancerLoggingParameters_FieldDelimiter
        /// <summary>
        /// <para>
        /// <para> The delimiter character used to separate fields in ELB access log entries when using
        /// plain text format. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_FieldDelimiter")]
        public System.String ELBLoadBalancerLoggingParameters_FieldDelimiter { get; set; }
        #endregion
        
        #region Parameter LoggingFilter_Filter
        /// <summary>
        /// <para>
        /// <para> A list of filter conditions that determine log record handling behavior. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_Filters")]
        public Amazon.ObservabilityAdmin.Model.Filter[] LoggingFilter_Filter { get; set; }
        #endregion
        
        #region Parameter VPCFlowLogParameters_LogFormat
        /// <summary>
        /// <para>
        /// <para> The format in which VPC Flow Log entries should be logged. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_VPCFlowLogParameters_LogFormat")]
        public System.String VPCFlowLogParameters_LogFormat { get; set; }
        #endregion
        
        #region Parameter WAFLoggingParameters_LogType
        /// <summary>
        /// <para>
        /// <para> The type of WAF logs to collect (currently supports WAF_LOGS). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_WAFLoggingParameters_LogType")]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.WAFLogType")]
        public Amazon.ObservabilityAdmin.WAFLogType WAFLoggingParameters_LogType { get; set; }
        #endregion
        
        #region Parameter LogDeliveryParameters_LogType
        /// <summary>
        /// <para>
        /// <para>The type of log that the source is sending.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_LogDeliveryParameters_LogTypes")]
        public System.String[] LogDeliveryParameters_LogType { get; set; }
        #endregion
        
        #region Parameter VPCFlowLogParameters_MaxAggregationInterval
        /// <summary>
        /// <para>
        /// <para> The maximum interval in seconds between the capture of flow log records. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_VPCFlowLogParameters_MaxAggregationInterval")]
        public System.Int32? VPCFlowLogParameters_MaxAggregationInterval { get; set; }
        #endregion
        
        #region Parameter ELBLoadBalancerLoggingParameters_OutputFormat
        /// <summary>
        /// <para>
        /// <para> The format for ELB access log entries (plain text or JSON format). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_OutputFormat")]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.OutputFormat")]
        public Amazon.ObservabilityAdmin.OutputFormat ELBLoadBalancerLoggingParameters_OutputFormat { get; set; }
        #endregion
        
        #region Parameter WAFLoggingParameters_RedactedField
        /// <summary>
        /// <para>
        /// <para> The fields to redact from WAF logs to protect sensitive information. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_WAFLoggingParameters_RedactedFields")]
        public Amazon.ObservabilityAdmin.Model.FieldToMatch[] WAFLoggingParameters_RedactedField { get; set; }
        #endregion
        
        #region Parameter Rule_ResourceType
        /// <summary>
        /// <para>
        /// <para> The type of Amazon Web Services resource to configure telemetry for (e.g., "AWS::EC2::VPC",
        /// "AWS::EKS::Cluster", "AWS::WAFv2::WebACL"). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.ResourceType")]
        public Amazon.ObservabilityAdmin.ResourceType Rule_ResourceType { get; set; }
        #endregion
        
        #region Parameter DestinationConfiguration_RetentionInDay
        /// <summary>
        /// <para>
        /// <para> The number of days to retain the telemetry data in the destination. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_RetentionInDays")]
        public System.Int32? DestinationConfiguration_RetentionInDay { get; set; }
        #endregion
        
        #region Parameter RuleName
        /// <summary>
        /// <para>
        /// <para> A unique name for the telemetry rule being created. </para>
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
        public System.String RuleName { get; set; }
        #endregion
        
        #region Parameter Rule_Scope
        /// <summary>
        /// <para>
        /// <para> The organizational scope to which the rule applies, specified using accounts or organizational
        /// units. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Rule_Scope { get; set; }
        #endregion
        
        #region Parameter Rule_SelectionCriterion
        /// <summary>
        /// <para>
        /// <para> Criteria for selecting which resources the rule applies to, such as resource tags.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_SelectionCriteria")]
        public System.String Rule_SelectionCriterion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> The key-value pairs to associate with the telemetry rule resource for categorization
        /// and management purposes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetrySourceType
        /// <summary>
        /// <para>
        /// <para> The specific telemetry source types to configure for the resource, such as VPC_FLOW_LOGS
        /// or EKS_AUDIT_LOGS. TelemetrySourceTypes must be correlated with the specific resource
        /// type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_TelemetrySourceTypes")]
        public System.String[] Rule_TelemetrySourceType { get; set; }
        #endregion
        
        #region Parameter Rule_TelemetryType
        /// <summary>
        /// <para>
        /// <para> The type of telemetry to collect (Logs, Metrics, or Traces). </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.TelemetryType")]
        public Amazon.ObservabilityAdmin.TelemetryType Rule_TelemetryType { get; set; }
        #endregion
        
        #region Parameter VPCFlowLogParameters_TrafficType
        /// <summary>
        /// <para>
        /// <para> The type of traffic to log (ACCEPT, REJECT, or ALL). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_DestinationConfiguration_VPCFlowLogParameters_TrafficType")]
        public System.String VPCFlowLogParameters_TrafficType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RuleArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RuleArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleName' instead. This parameter will be removed in a future version.")]
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWOADMNTelemetryRule (CreateTelemetryRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleResponse, NewCWOADMNTelemetryRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CloudtrailParameters_AdvancedEventSelector != null)
            {
                context.CloudtrailParameters_AdvancedEventSelector = new List<Amazon.ObservabilityAdmin.Model.AdvancedEventSelector>(this.CloudtrailParameters_AdvancedEventSelector);
            }
            context.DestinationConfiguration_DestinationPattern = this.DestinationConfiguration_DestinationPattern;
            context.DestinationConfiguration_DestinationType = this.DestinationConfiguration_DestinationType;
            context.ELBLoadBalancerLoggingParameters_FieldDelimiter = this.ELBLoadBalancerLoggingParameters_FieldDelimiter;
            context.ELBLoadBalancerLoggingParameters_OutputFormat = this.ELBLoadBalancerLoggingParameters_OutputFormat;
            if (this.LogDeliveryParameters_LogType != null)
            {
                context.LogDeliveryParameters_LogType = new List<System.String>(this.LogDeliveryParameters_LogType);
            }
            context.DestinationConfiguration_RetentionInDay = this.DestinationConfiguration_RetentionInDay;
            context.VPCFlowLogParameters_LogFormat = this.VPCFlowLogParameters_LogFormat;
            context.VPCFlowLogParameters_MaxAggregationInterval = this.VPCFlowLogParameters_MaxAggregationInterval;
            context.VPCFlowLogParameters_TrafficType = this.VPCFlowLogParameters_TrafficType;
            context.LoggingFilter_DefaultBehavior = this.LoggingFilter_DefaultBehavior;
            if (this.LoggingFilter_Filter != null)
            {
                context.LoggingFilter_Filter = new List<Amazon.ObservabilityAdmin.Model.Filter>(this.LoggingFilter_Filter);
            }
            context.WAFLoggingParameters_LogType = this.WAFLoggingParameters_LogType;
            if (this.WAFLoggingParameters_RedactedField != null)
            {
                context.WAFLoggingParameters_RedactedField = new List<Amazon.ObservabilityAdmin.Model.FieldToMatch>(this.WAFLoggingParameters_RedactedField);
            }
            context.Rule_ResourceType = this.Rule_ResourceType;
            context.Rule_Scope = this.Rule_Scope;
            context.Rule_SelectionCriterion = this.Rule_SelectionCriterion;
            if (this.Rule_TelemetrySourceType != null)
            {
                context.Rule_TelemetrySourceType = new List<System.String>(this.Rule_TelemetrySourceType);
            }
            context.Rule_TelemetryType = this.Rule_TelemetryType;
            #if MODULAR
            if (this.Rule_TelemetryType == null && ParameterWasBound(nameof(this.Rule_TelemetryType)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule_TelemetryType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleName = this.RuleName;
            #if MODULAR
            if (this.RuleName == null && ParameterWasBound(nameof(this.RuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleRequest();
            
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.ObservabilityAdmin.Model.TelemetryRule();
            Amazon.ObservabilityAdmin.ResourceType requestRule_rule_ResourceType = null;
            if (cmdletContext.Rule_ResourceType != null)
            {
                requestRule_rule_ResourceType = cmdletContext.Rule_ResourceType;
            }
            if (requestRule_rule_ResourceType != null)
            {
                request.Rule.ResourceType = requestRule_rule_ResourceType;
                requestRuleIsNull = false;
            }
            System.String requestRule_rule_Scope = null;
            if (cmdletContext.Rule_Scope != null)
            {
                requestRule_rule_Scope = cmdletContext.Rule_Scope;
            }
            if (requestRule_rule_Scope != null)
            {
                request.Rule.Scope = requestRule_rule_Scope;
                requestRuleIsNull = false;
            }
            System.String requestRule_rule_SelectionCriterion = null;
            if (cmdletContext.Rule_SelectionCriterion != null)
            {
                requestRule_rule_SelectionCriterion = cmdletContext.Rule_SelectionCriterion;
            }
            if (requestRule_rule_SelectionCriterion != null)
            {
                request.Rule.SelectionCriteria = requestRule_rule_SelectionCriterion;
                requestRuleIsNull = false;
            }
            List<System.String> requestRule_rule_TelemetrySourceType = null;
            if (cmdletContext.Rule_TelemetrySourceType != null)
            {
                requestRule_rule_TelemetrySourceType = cmdletContext.Rule_TelemetrySourceType;
            }
            if (requestRule_rule_TelemetrySourceType != null)
            {
                request.Rule.TelemetrySourceTypes = requestRule_rule_TelemetrySourceType;
                requestRuleIsNull = false;
            }
            Amazon.ObservabilityAdmin.TelemetryType requestRule_rule_TelemetryType = null;
            if (cmdletContext.Rule_TelemetryType != null)
            {
                requestRule_rule_TelemetryType = cmdletContext.Rule_TelemetryType;
            }
            if (requestRule_rule_TelemetryType != null)
            {
                request.Rule.TelemetryType = requestRule_rule_TelemetryType;
                requestRuleIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.TelemetryDestinationConfiguration requestRule_rule_DestinationConfiguration = null;
            
             // populate DestinationConfiguration
            var requestRule_rule_DestinationConfigurationIsNull = true;
            requestRule_rule_DestinationConfiguration = new Amazon.ObservabilityAdmin.Model.TelemetryDestinationConfiguration();
            System.String requestRule_rule_DestinationConfiguration_destinationConfiguration_DestinationPattern = null;
            if (cmdletContext.DestinationConfiguration_DestinationPattern != null)
            {
                requestRule_rule_DestinationConfiguration_destinationConfiguration_DestinationPattern = cmdletContext.DestinationConfiguration_DestinationPattern;
            }
            if (requestRule_rule_DestinationConfiguration_destinationConfiguration_DestinationPattern != null)
            {
                requestRule_rule_DestinationConfiguration.DestinationPattern = requestRule_rule_DestinationConfiguration_destinationConfiguration_DestinationPattern;
                requestRule_rule_DestinationConfigurationIsNull = false;
            }
            Amazon.ObservabilityAdmin.DestinationType requestRule_rule_DestinationConfiguration_destinationConfiguration_DestinationType = null;
            if (cmdletContext.DestinationConfiguration_DestinationType != null)
            {
                requestRule_rule_DestinationConfiguration_destinationConfiguration_DestinationType = cmdletContext.DestinationConfiguration_DestinationType;
            }
            if (requestRule_rule_DestinationConfiguration_destinationConfiguration_DestinationType != null)
            {
                requestRule_rule_DestinationConfiguration.DestinationType = requestRule_rule_DestinationConfiguration_destinationConfiguration_DestinationType;
                requestRule_rule_DestinationConfigurationIsNull = false;
            }
            System.Int32? requestRule_rule_DestinationConfiguration_destinationConfiguration_RetentionInDay = null;
            if (cmdletContext.DestinationConfiguration_RetentionInDay != null)
            {
                requestRule_rule_DestinationConfiguration_destinationConfiguration_RetentionInDay = cmdletContext.DestinationConfiguration_RetentionInDay.Value;
            }
            if (requestRule_rule_DestinationConfiguration_destinationConfiguration_RetentionInDay != null)
            {
                requestRule_rule_DestinationConfiguration.RetentionInDays = requestRule_rule_DestinationConfiguration_destinationConfiguration_RetentionInDay.Value;
                requestRule_rule_DestinationConfigurationIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.CloudtrailParameters requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters = null;
            
             // populate CloudtrailParameters
            var requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParametersIsNull = true;
            requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters = new Amazon.ObservabilityAdmin.Model.CloudtrailParameters();
            List<Amazon.ObservabilityAdmin.Model.AdvancedEventSelector> requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters_cloudtrailParameters_AdvancedEventSelector = null;
            if (cmdletContext.CloudtrailParameters_AdvancedEventSelector != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters_cloudtrailParameters_AdvancedEventSelector = cmdletContext.CloudtrailParameters_AdvancedEventSelector;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters_cloudtrailParameters_AdvancedEventSelector != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters.AdvancedEventSelectors = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters_cloudtrailParameters_AdvancedEventSelector;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParametersIsNull = false;
            }
             // determine if requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters should be set to null
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParametersIsNull)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters = null;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters != null)
            {
                requestRule_rule_DestinationConfiguration.CloudtrailParameters = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_CloudtrailParameters;
                requestRule_rule_DestinationConfigurationIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.LogDeliveryParameters requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters = null;
            
             // populate LogDeliveryParameters
            var requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParametersIsNull = true;
            requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters = new Amazon.ObservabilityAdmin.Model.LogDeliveryParameters();
            List<System.String> requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters_logDeliveryParameters_LogType = null;
            if (cmdletContext.LogDeliveryParameters_LogType != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters_logDeliveryParameters_LogType = cmdletContext.LogDeliveryParameters_LogType;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters_logDeliveryParameters_LogType != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters.LogTypes = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters_logDeliveryParameters_LogType;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParametersIsNull = false;
            }
             // determine if requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters should be set to null
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParametersIsNull)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters = null;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters != null)
            {
                requestRule_rule_DestinationConfiguration.LogDeliveryParameters = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_LogDeliveryParameters;
                requestRule_rule_DestinationConfigurationIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.ELBLoadBalancerLoggingParameters requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters = null;
            
             // populate ELBLoadBalancerLoggingParameters
            var requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParametersIsNull = true;
            requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters = new Amazon.ObservabilityAdmin.Model.ELBLoadBalancerLoggingParameters();
            System.String requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_eLBLoadBalancerLoggingParameters_FieldDelimiter = null;
            if (cmdletContext.ELBLoadBalancerLoggingParameters_FieldDelimiter != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_eLBLoadBalancerLoggingParameters_FieldDelimiter = cmdletContext.ELBLoadBalancerLoggingParameters_FieldDelimiter;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_eLBLoadBalancerLoggingParameters_FieldDelimiter != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters.FieldDelimiter = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_eLBLoadBalancerLoggingParameters_FieldDelimiter;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParametersIsNull = false;
            }
            Amazon.ObservabilityAdmin.OutputFormat requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_eLBLoadBalancerLoggingParameters_OutputFormat = null;
            if (cmdletContext.ELBLoadBalancerLoggingParameters_OutputFormat != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_eLBLoadBalancerLoggingParameters_OutputFormat = cmdletContext.ELBLoadBalancerLoggingParameters_OutputFormat;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_eLBLoadBalancerLoggingParameters_OutputFormat != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters.OutputFormat = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters_eLBLoadBalancerLoggingParameters_OutputFormat;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParametersIsNull = false;
            }
             // determine if requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters should be set to null
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParametersIsNull)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters = null;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters != null)
            {
                requestRule_rule_DestinationConfiguration.ELBLoadBalancerLoggingParameters = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_ELBLoadBalancerLoggingParameters;
                requestRule_rule_DestinationConfigurationIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.VPCFlowLogParameters requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters = null;
            
             // populate VPCFlowLogParameters
            var requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParametersIsNull = true;
            requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters = new Amazon.ObservabilityAdmin.Model.VPCFlowLogParameters();
            System.String requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_LogFormat = null;
            if (cmdletContext.VPCFlowLogParameters_LogFormat != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_LogFormat = cmdletContext.VPCFlowLogParameters_LogFormat;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_LogFormat != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters.LogFormat = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_LogFormat;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParametersIsNull = false;
            }
            System.Int32? requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_MaxAggregationInterval = null;
            if (cmdletContext.VPCFlowLogParameters_MaxAggregationInterval != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_MaxAggregationInterval = cmdletContext.VPCFlowLogParameters_MaxAggregationInterval.Value;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_MaxAggregationInterval != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters.MaxAggregationInterval = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_MaxAggregationInterval.Value;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParametersIsNull = false;
            }
            System.String requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_TrafficType = null;
            if (cmdletContext.VPCFlowLogParameters_TrafficType != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_TrafficType = cmdletContext.VPCFlowLogParameters_TrafficType;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_TrafficType != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters.TrafficType = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters_vPCFlowLogParameters_TrafficType;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParametersIsNull = false;
            }
             // determine if requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters should be set to null
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParametersIsNull)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters = null;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters != null)
            {
                requestRule_rule_DestinationConfiguration.VPCFlowLogParameters = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_VPCFlowLogParameters;
                requestRule_rule_DestinationConfigurationIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.WAFLoggingParameters requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters = null;
            
             // populate WAFLoggingParameters
            var requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParametersIsNull = true;
            requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters = new Amazon.ObservabilityAdmin.Model.WAFLoggingParameters();
            Amazon.ObservabilityAdmin.WAFLogType requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_wAFLoggingParameters_LogType = null;
            if (cmdletContext.WAFLoggingParameters_LogType != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_wAFLoggingParameters_LogType = cmdletContext.WAFLoggingParameters_LogType;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_wAFLoggingParameters_LogType != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters.LogType = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_wAFLoggingParameters_LogType;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParametersIsNull = false;
            }
            List<Amazon.ObservabilityAdmin.Model.FieldToMatch> requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_wAFLoggingParameters_RedactedField = null;
            if (cmdletContext.WAFLoggingParameters_RedactedField != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_wAFLoggingParameters_RedactedField = cmdletContext.WAFLoggingParameters_RedactedField;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_wAFLoggingParameters_RedactedField != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters.RedactedFields = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_wAFLoggingParameters_RedactedField;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParametersIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.LoggingFilter requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter = null;
            
             // populate LoggingFilter
            var requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilterIsNull = true;
            requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter = new Amazon.ObservabilityAdmin.Model.LoggingFilter();
            Amazon.ObservabilityAdmin.FilterBehavior requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_loggingFilter_DefaultBehavior = null;
            if (cmdletContext.LoggingFilter_DefaultBehavior != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_loggingFilter_DefaultBehavior = cmdletContext.LoggingFilter_DefaultBehavior;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_loggingFilter_DefaultBehavior != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter.DefaultBehavior = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_loggingFilter_DefaultBehavior;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilterIsNull = false;
            }
            List<Amazon.ObservabilityAdmin.Model.Filter> requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_loggingFilter_Filter = null;
            if (cmdletContext.LoggingFilter_Filter != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_loggingFilter_Filter = cmdletContext.LoggingFilter_Filter;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_loggingFilter_Filter != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter.Filters = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter_loggingFilter_Filter;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilterIsNull = false;
            }
             // determine if requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter should be set to null
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilterIsNull)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter = null;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter != null)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters.LoggingFilter = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters_rule_DestinationConfiguration_WAFLoggingParameters_LoggingFilter;
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParametersIsNull = false;
            }
             // determine if requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters should be set to null
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParametersIsNull)
            {
                requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters = null;
            }
            if (requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters != null)
            {
                requestRule_rule_DestinationConfiguration.WAFLoggingParameters = requestRule_rule_DestinationConfiguration_rule_DestinationConfiguration_WAFLoggingParameters;
                requestRule_rule_DestinationConfigurationIsNull = false;
            }
             // determine if requestRule_rule_DestinationConfiguration should be set to null
            if (requestRule_rule_DestinationConfigurationIsNull)
            {
                requestRule_rule_DestinationConfiguration = null;
            }
            if (requestRule_rule_DestinationConfiguration != null)
            {
                request.Rule.DestinationConfiguration = requestRule_rule_DestinationConfiguration;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
            }
            if (cmdletContext.RuleName != null)
            {
                request.RuleName = cmdletContext.RuleName;
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
        
        private Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "CreateTelemetryRule");
            try
            {
                #if DESKTOP
                return client.CreateTelemetryRule(request);
                #elif CORECLR
                return client.CreateTelemetryRuleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ObservabilityAdmin.Model.AdvancedEventSelector> CloudtrailParameters_AdvancedEventSelector { get; set; }
            public System.String DestinationConfiguration_DestinationPattern { get; set; }
            public Amazon.ObservabilityAdmin.DestinationType DestinationConfiguration_DestinationType { get; set; }
            public System.String ELBLoadBalancerLoggingParameters_FieldDelimiter { get; set; }
            public Amazon.ObservabilityAdmin.OutputFormat ELBLoadBalancerLoggingParameters_OutputFormat { get; set; }
            public List<System.String> LogDeliveryParameters_LogType { get; set; }
            public System.Int32? DestinationConfiguration_RetentionInDay { get; set; }
            public System.String VPCFlowLogParameters_LogFormat { get; set; }
            public System.Int32? VPCFlowLogParameters_MaxAggregationInterval { get; set; }
            public System.String VPCFlowLogParameters_TrafficType { get; set; }
            public Amazon.ObservabilityAdmin.FilterBehavior LoggingFilter_DefaultBehavior { get; set; }
            public List<Amazon.ObservabilityAdmin.Model.Filter> LoggingFilter_Filter { get; set; }
            public Amazon.ObservabilityAdmin.WAFLogType WAFLoggingParameters_LogType { get; set; }
            public List<Amazon.ObservabilityAdmin.Model.FieldToMatch> WAFLoggingParameters_RedactedField { get; set; }
            public Amazon.ObservabilityAdmin.ResourceType Rule_ResourceType { get; set; }
            public System.String Rule_Scope { get; set; }
            public System.String Rule_SelectionCriterion { get; set; }
            public List<System.String> Rule_TelemetrySourceType { get; set; }
            public Amazon.ObservabilityAdmin.TelemetryType Rule_TelemetryType { get; set; }
            public System.String RuleName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.CreateTelemetryRuleResponse, NewCWOADMNTelemetryRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RuleArn;
        }
        
    }
}
