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
using Amazon.LookoutMetrics;
using Amazon.LookoutMetrics.Model;

namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Creates an alert for an anomaly detector.
    /// </summary>
    [Cmdlet("New", "LOMAlert", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics CreateAlert API operation.", Operation = new[] {"CreateAlert"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.CreateAlertResponse))]
    [AWSCmdletOutput("System.String or Amazon.LookoutMetrics.Model.CreateAlertResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LookoutMetrics.Model.CreateAlertResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLOMAlertCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        #region Parameter AlertDescription
        /// <summary>
        /// <para>
        /// <para>A description of the alert.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AlertDescription { get; set; }
        #endregion
        
        #region Parameter AlertName
        /// <summary>
        /// <para>
        /// <para>The name of the alert.</para>
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
        public System.String AlertName { get; set; }
        #endregion
        
        #region Parameter AlertSensitivityThreshold
        /// <summary>
        /// <para>
        /// <para>An integer from 0 to 100 specifying the alert sensitivity threshold.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? AlertSensitivityThreshold { get; set; }
        #endregion
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the detector to which the alert is attached.</para>
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
        public System.String AnomalyDetectorArn { get; set; }
        #endregion
        
        #region Parameter LambdaConfiguration_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_LambdaConfiguration_LambdaArn")]
        public System.String LambdaConfiguration_LambdaArn { get; set; }
        #endregion
        
        #region Parameter LambdaConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that has permission to invoke the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_LambdaConfiguration_RoleArn")]
        public System.String LambdaConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter SNSConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that has access to the target SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_SNSConfiguration_RoleArn")]
        public System.String SNSConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter SNSConfiguration_SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the target SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_SNSConfiguration_SnsTopicArn")]
        public System.String SNSConfiguration_SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/lookoutmetrics/latest/dev/detectors-tags.html">tags</a>
        /// to apply to the alert.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AlertArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.CreateAlertResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.CreateAlertResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AlertArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AnomalyDetectorArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AnomalyDetectorArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AnomalyDetectorArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AlertName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LOMAlert (CreateAlert)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.CreateAlertResponse, NewLOMAlertCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AnomalyDetectorArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LambdaConfiguration_LambdaArn = this.LambdaConfiguration_LambdaArn;
            context.LambdaConfiguration_RoleArn = this.LambdaConfiguration_RoleArn;
            context.SNSConfiguration_RoleArn = this.SNSConfiguration_RoleArn;
            context.SNSConfiguration_SnsTopicArn = this.SNSConfiguration_SnsTopicArn;
            context.AlertDescription = this.AlertDescription;
            context.AlertName = this.AlertName;
            #if MODULAR
            if (this.AlertName == null && ParameterWasBound(nameof(this.AlertName)))
            {
                WriteWarning("You are passing $null as a value for parameter AlertName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AlertSensitivityThreshold = this.AlertSensitivityThreshold;
            #if MODULAR
            if (this.AlertSensitivityThreshold == null && ParameterWasBound(nameof(this.AlertSensitivityThreshold)))
            {
                WriteWarning("You are passing $null as a value for parameter AlertSensitivityThreshold which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
            #if MODULAR
            if (this.AnomalyDetectorArn == null && ParameterWasBound(nameof(this.AnomalyDetectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.LookoutMetrics.Model.CreateAlertRequest();
            
            
             // populate Action
            var requestActionIsNull = true;
            request.Action = new Amazon.LookoutMetrics.Model.Action();
            Amazon.LookoutMetrics.Model.LambdaConfiguration requestAction_action_LambdaConfiguration = null;
            
             // populate LambdaConfiguration
            var requestAction_action_LambdaConfigurationIsNull = true;
            requestAction_action_LambdaConfiguration = new Amazon.LookoutMetrics.Model.LambdaConfiguration();
            System.String requestAction_action_LambdaConfiguration_lambdaConfiguration_LambdaArn = null;
            if (cmdletContext.LambdaConfiguration_LambdaArn != null)
            {
                requestAction_action_LambdaConfiguration_lambdaConfiguration_LambdaArn = cmdletContext.LambdaConfiguration_LambdaArn;
            }
            if (requestAction_action_LambdaConfiguration_lambdaConfiguration_LambdaArn != null)
            {
                requestAction_action_LambdaConfiguration.LambdaArn = requestAction_action_LambdaConfiguration_lambdaConfiguration_LambdaArn;
                requestAction_action_LambdaConfigurationIsNull = false;
            }
            System.String requestAction_action_LambdaConfiguration_lambdaConfiguration_RoleArn = null;
            if (cmdletContext.LambdaConfiguration_RoleArn != null)
            {
                requestAction_action_LambdaConfiguration_lambdaConfiguration_RoleArn = cmdletContext.LambdaConfiguration_RoleArn;
            }
            if (requestAction_action_LambdaConfiguration_lambdaConfiguration_RoleArn != null)
            {
                requestAction_action_LambdaConfiguration.RoleArn = requestAction_action_LambdaConfiguration_lambdaConfiguration_RoleArn;
                requestAction_action_LambdaConfigurationIsNull = false;
            }
             // determine if requestAction_action_LambdaConfiguration should be set to null
            if (requestAction_action_LambdaConfigurationIsNull)
            {
                requestAction_action_LambdaConfiguration = null;
            }
            if (requestAction_action_LambdaConfiguration != null)
            {
                request.Action.LambdaConfiguration = requestAction_action_LambdaConfiguration;
                requestActionIsNull = false;
            }
            Amazon.LookoutMetrics.Model.SNSConfiguration requestAction_action_SNSConfiguration = null;
            
             // populate SNSConfiguration
            var requestAction_action_SNSConfigurationIsNull = true;
            requestAction_action_SNSConfiguration = new Amazon.LookoutMetrics.Model.SNSConfiguration();
            System.String requestAction_action_SNSConfiguration_sNSConfiguration_RoleArn = null;
            if (cmdletContext.SNSConfiguration_RoleArn != null)
            {
                requestAction_action_SNSConfiguration_sNSConfiguration_RoleArn = cmdletContext.SNSConfiguration_RoleArn;
            }
            if (requestAction_action_SNSConfiguration_sNSConfiguration_RoleArn != null)
            {
                requestAction_action_SNSConfiguration.RoleArn = requestAction_action_SNSConfiguration_sNSConfiguration_RoleArn;
                requestAction_action_SNSConfigurationIsNull = false;
            }
            System.String requestAction_action_SNSConfiguration_sNSConfiguration_SnsTopicArn = null;
            if (cmdletContext.SNSConfiguration_SnsTopicArn != null)
            {
                requestAction_action_SNSConfiguration_sNSConfiguration_SnsTopicArn = cmdletContext.SNSConfiguration_SnsTopicArn;
            }
            if (requestAction_action_SNSConfiguration_sNSConfiguration_SnsTopicArn != null)
            {
                requestAction_action_SNSConfiguration.SnsTopicArn = requestAction_action_SNSConfiguration_sNSConfiguration_SnsTopicArn;
                requestAction_action_SNSConfigurationIsNull = false;
            }
             // determine if requestAction_action_SNSConfiguration should be set to null
            if (requestAction_action_SNSConfigurationIsNull)
            {
                requestAction_action_SNSConfiguration = null;
            }
            if (requestAction_action_SNSConfiguration != null)
            {
                request.Action.SNSConfiguration = requestAction_action_SNSConfiguration;
                requestActionIsNull = false;
            }
             // determine if request.Action should be set to null
            if (requestActionIsNull)
            {
                request.Action = null;
            }
            if (cmdletContext.AlertDescription != null)
            {
                request.AlertDescription = cmdletContext.AlertDescription;
            }
            if (cmdletContext.AlertName != null)
            {
                request.AlertName = cmdletContext.AlertName;
            }
            if (cmdletContext.AlertSensitivityThreshold != null)
            {
                request.AlertSensitivityThreshold = cmdletContext.AlertSensitivityThreshold.Value;
            }
            if (cmdletContext.AnomalyDetectorArn != null)
            {
                request.AnomalyDetectorArn = cmdletContext.AnomalyDetectorArn;
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
        
        private Amazon.LookoutMetrics.Model.CreateAlertResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.CreateAlertRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "CreateAlert");
            try
            {
                #if DESKTOP
                return client.CreateAlert(request);
                #elif CORECLR
                return client.CreateAlertAsync(request).GetAwaiter().GetResult();
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
            public System.String LambdaConfiguration_LambdaArn { get; set; }
            public System.String LambdaConfiguration_RoleArn { get; set; }
            public System.String SNSConfiguration_RoleArn { get; set; }
            public System.String SNSConfiguration_SnsTopicArn { get; set; }
            public System.String AlertDescription { get; set; }
            public System.String AlertName { get; set; }
            public System.Int32? AlertSensitivityThreshold { get; set; }
            public System.String AnomalyDetectorArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.CreateAlertResponse, NewLOMAlertCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AlertArn;
        }
        
    }
}
