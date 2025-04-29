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
using Amazon.LookoutMetrics;
using Amazon.LookoutMetrics.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Make changes to an existing alert.
    /// </summary>
    [Cmdlet("Update", "LOMAlert", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics UpdateAlert API operation.", Operation = new[] {"UpdateAlert"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.UpdateAlertResponse))]
    [AWSCmdletOutput("System.String or Amazon.LookoutMetrics.Model.UpdateAlertResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LookoutMetrics.Model.UpdateAlertResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateLOMAlertCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AlertArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the alert to update.</para>
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
        public System.String AlertArn { get; set; }
        #endregion
        
        #region Parameter AlertDescription
        /// <summary>
        /// <para>
        /// <para>A description of the alert.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AlertDescription { get; set; }
        #endregion
        
        #region Parameter AlertSensitivityThreshold
        /// <summary>
        /// <para>
        /// <para>An integer from 0 to 100 specifying the alert sensitivity threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AlertSensitivityThreshold { get; set; }
        #endregion
        
        #region Parameter AlertFilters_DimensionFilterList
        /// <summary>
        /// <para>
        /// <para>The list of DimensionFilter objects that are used for dimension-based filtering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LookoutMetrics.Model.DimensionFilter[] AlertFilters_DimensionFilterList { get; set; }
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
        
        #region Parameter AlertFilters_MetricList
        /// <summary>
        /// <para>
        /// <para>The list of measures that you want to get alerts for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AlertFilters_MetricList { get; set; }
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
        
        #region Parameter SNSConfiguration_SnsFormat
        /// <summary>
        /// <para>
        /// <para>The format of the SNS topic.</para><ul><li><para><c>JSON</c> – Send JSON alerts with an anomaly ID and a link to the anomaly detail
        /// page. This is the default.</para></li><li><para><c>LONG_TEXT</c> – Send human-readable alerts with information about the impacted
        /// timeseries and a link to the anomaly detail page. We recommend this for email.</para></li><li><para><c>SHORT_TEXT</c> – Send human-readable alerts with a link to the anomaly detail
        /// page. We recommend this for SMS.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_SNSConfiguration_SnsFormat")]
        [AWSConstantClassSource("Amazon.LookoutMetrics.SnsFormat")]
        public Amazon.LookoutMetrics.SnsFormat SNSConfiguration_SnsFormat { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AlertArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.UpdateAlertResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.UpdateAlertResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AlertArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AlertArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LOMAlert (UpdateAlert)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.UpdateAlertResponse, UpdateLOMAlertCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LambdaConfiguration_LambdaArn = this.LambdaConfiguration_LambdaArn;
            context.LambdaConfiguration_RoleArn = this.LambdaConfiguration_RoleArn;
            context.SNSConfiguration_RoleArn = this.SNSConfiguration_RoleArn;
            context.SNSConfiguration_SnsFormat = this.SNSConfiguration_SnsFormat;
            context.SNSConfiguration_SnsTopicArn = this.SNSConfiguration_SnsTopicArn;
            context.AlertArn = this.AlertArn;
            #if MODULAR
            if (this.AlertArn == null && ParameterWasBound(nameof(this.AlertArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AlertArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AlertDescription = this.AlertDescription;
            if (this.AlertFilters_DimensionFilterList != null)
            {
                context.AlertFilters_DimensionFilterList = new List<Amazon.LookoutMetrics.Model.DimensionFilter>(this.AlertFilters_DimensionFilterList);
            }
            if (this.AlertFilters_MetricList != null)
            {
                context.AlertFilters_MetricList = new List<System.String>(this.AlertFilters_MetricList);
            }
            context.AlertSensitivityThreshold = this.AlertSensitivityThreshold;
            
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
            var request = new Amazon.LookoutMetrics.Model.UpdateAlertRequest();
            
            
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
            Amazon.LookoutMetrics.SnsFormat requestAction_action_SNSConfiguration_sNSConfiguration_SnsFormat = null;
            if (cmdletContext.SNSConfiguration_SnsFormat != null)
            {
                requestAction_action_SNSConfiguration_sNSConfiguration_SnsFormat = cmdletContext.SNSConfiguration_SnsFormat;
            }
            if (requestAction_action_SNSConfiguration_sNSConfiguration_SnsFormat != null)
            {
                requestAction_action_SNSConfiguration.SnsFormat = requestAction_action_SNSConfiguration_sNSConfiguration_SnsFormat;
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
            if (cmdletContext.AlertArn != null)
            {
                request.AlertArn = cmdletContext.AlertArn;
            }
            if (cmdletContext.AlertDescription != null)
            {
                request.AlertDescription = cmdletContext.AlertDescription;
            }
            
             // populate AlertFilters
            var requestAlertFiltersIsNull = true;
            request.AlertFilters = new Amazon.LookoutMetrics.Model.AlertFilters();
            List<Amazon.LookoutMetrics.Model.DimensionFilter> requestAlertFilters_alertFilters_DimensionFilterList = null;
            if (cmdletContext.AlertFilters_DimensionFilterList != null)
            {
                requestAlertFilters_alertFilters_DimensionFilterList = cmdletContext.AlertFilters_DimensionFilterList;
            }
            if (requestAlertFilters_alertFilters_DimensionFilterList != null)
            {
                request.AlertFilters.DimensionFilterList = requestAlertFilters_alertFilters_DimensionFilterList;
                requestAlertFiltersIsNull = false;
            }
            List<System.String> requestAlertFilters_alertFilters_MetricList = null;
            if (cmdletContext.AlertFilters_MetricList != null)
            {
                requestAlertFilters_alertFilters_MetricList = cmdletContext.AlertFilters_MetricList;
            }
            if (requestAlertFilters_alertFilters_MetricList != null)
            {
                request.AlertFilters.MetricList = requestAlertFilters_alertFilters_MetricList;
                requestAlertFiltersIsNull = false;
            }
             // determine if request.AlertFilters should be set to null
            if (requestAlertFiltersIsNull)
            {
                request.AlertFilters = null;
            }
            if (cmdletContext.AlertSensitivityThreshold != null)
            {
                request.AlertSensitivityThreshold = cmdletContext.AlertSensitivityThreshold.Value;
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
        
        private Amazon.LookoutMetrics.Model.UpdateAlertResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.UpdateAlertRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "UpdateAlert");
            try
            {
                return client.UpdateAlertAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.LookoutMetrics.SnsFormat SNSConfiguration_SnsFormat { get; set; }
            public System.String SNSConfiguration_SnsTopicArn { get; set; }
            public System.String AlertArn { get; set; }
            public System.String AlertDescription { get; set; }
            public List<Amazon.LookoutMetrics.Model.DimensionFilter> AlertFilters_DimensionFilterList { get; set; }
            public List<System.String> AlertFilters_MetricList { get; set; }
            public System.Int32? AlertSensitivityThreshold { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.UpdateAlertResponse, UpdateLOMAlertCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AlertArn;
        }
        
    }
}
