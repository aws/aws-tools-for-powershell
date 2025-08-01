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
    /// Updates an existing telemetry rule that applies across an Amazon Web Services Organization.
    /// This operation can only be called by the organization's management account or a delegated
    /// administrator account.
    /// </summary>
    [Cmdlet("Update", "CWOADMNTelemetryRuleForOrganization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service UpdateTelemetryRuleForOrganization API operation.", Operation = new[] {"UpdateTelemetryRuleForOrganization"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationResponse))]
    [AWSCmdletOutput("System.String or Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWOADMNTelemetryRuleForOrganizationCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter Rule_ResourceType
        /// <summary>
        /// <para>
        /// <para> The type of Amazon Web Services resource to configure telemetry for (e.g., "AWS::EC2::VPC").
        /// </para>
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
        
        #region Parameter RuleIdentifier
        /// <summary>
        /// <para>
        /// <para> The identifier (name or ARN) of the organization telemetry rule to update. </para>
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
        public System.String RuleIdentifier { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RuleArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWOADMNTelemetryRuleForOrganization (UpdateTelemetryRuleForOrganization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationResponse, UpdateCWOADMNTelemetryRuleForOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DestinationConfiguration_DestinationPattern = this.DestinationConfiguration_DestinationPattern;
            context.DestinationConfiguration_DestinationType = this.DestinationConfiguration_DestinationType;
            context.DestinationConfiguration_RetentionInDay = this.DestinationConfiguration_RetentionInDay;
            context.VPCFlowLogParameters_LogFormat = this.VPCFlowLogParameters_LogFormat;
            context.VPCFlowLogParameters_MaxAggregationInterval = this.VPCFlowLogParameters_MaxAggregationInterval;
            context.VPCFlowLogParameters_TrafficType = this.VPCFlowLogParameters_TrafficType;
            context.Rule_ResourceType = this.Rule_ResourceType;
            context.Rule_Scope = this.Rule_Scope;
            context.Rule_SelectionCriterion = this.Rule_SelectionCriterion;
            context.Rule_TelemetryType = this.Rule_TelemetryType;
            #if MODULAR
            if (this.Rule_TelemetryType == null && ParameterWasBound(nameof(this.Rule_TelemetryType)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule_TelemetryType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleIdentifier = this.RuleIdentifier;
            #if MODULAR
            if (this.RuleIdentifier == null && ParameterWasBound(nameof(this.RuleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationRequest();
            
            
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
            if (cmdletContext.RuleIdentifier != null)
            {
                request.RuleIdentifier = cmdletContext.RuleIdentifier;
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
        
        private Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "UpdateTelemetryRuleForOrganization");
            try
            {
                #if DESKTOP
                return client.UpdateTelemetryRuleForOrganization(request);
                #elif CORECLR
                return client.UpdateTelemetryRuleForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationConfiguration_DestinationPattern { get; set; }
            public Amazon.ObservabilityAdmin.DestinationType DestinationConfiguration_DestinationType { get; set; }
            public System.Int32? DestinationConfiguration_RetentionInDay { get; set; }
            public System.String VPCFlowLogParameters_LogFormat { get; set; }
            public System.Int32? VPCFlowLogParameters_MaxAggregationInterval { get; set; }
            public System.String VPCFlowLogParameters_TrafficType { get; set; }
            public Amazon.ObservabilityAdmin.ResourceType Rule_ResourceType { get; set; }
            public System.String Rule_Scope { get; set; }
            public System.String Rule_SelectionCriterion { get; set; }
            public Amazon.ObservabilityAdmin.TelemetryType Rule_TelemetryType { get; set; }
            public System.String RuleIdentifier { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.UpdateTelemetryRuleForOrganizationResponse, UpdateCWOADMNTelemetryRuleForOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RuleArn;
        }
        
    }
}
