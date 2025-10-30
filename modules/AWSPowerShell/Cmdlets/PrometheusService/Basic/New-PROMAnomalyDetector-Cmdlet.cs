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
using Amazon.PrometheusService;
using Amazon.PrometheusService.Model;

namespace Amazon.PowerShell.Cmdlets.PROM
{
    /// <summary>
    /// Creates an anomaly detector within a workspace using the Random Cut Forest algorithm
    /// for time-series analysis. The anomaly detector analyzes Amazon Managed Service for
    /// Prometheus metrics to identify unusual patterns and behaviors.
    /// </summary>
    [Cmdlet("New", "PROMAnomalyDetector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PrometheusService.Model.CreateAnomalyDetectorResponse")]
    [AWSCmdlet("Calls the Amazon Prometheus Service CreateAnomalyDetector API operation.", Operation = new[] {"CreateAnomalyDetector"}, SelectReturnType = typeof(Amazon.PrometheusService.Model.CreateAnomalyDetectorResponse))]
    [AWSCmdletOutput("Amazon.PrometheusService.Model.CreateAnomalyDetectorResponse",
        "This cmdlet returns an Amazon.PrometheusService.Model.CreateAnomalyDetectorResponse object containing multiple properties."
    )]
    public partial class NewPROMAnomalyDetectorCmdlet : AmazonPrometheusServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the anomaly detector.</para>
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
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter IgnoreNearExpectedFromAbove_Amount
        /// <summary>
        /// <para>
        /// <para>The absolute amount by which values can differ from expected values before being considered
        /// anomalous.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RandomCutForest_IgnoreNearExpectedFromAbove_Amount")]
        public System.Double? IgnoreNearExpectedFromAbove_Amount { get; set; }
        #endregion
        
        #region Parameter IgnoreNearExpectedFromBelow_Amount
        /// <summary>
        /// <para>
        /// <para>The absolute amount by which values can differ from expected values before being considered
        /// anomalous.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RandomCutForest_IgnoreNearExpectedFromBelow_Amount")]
        public System.Double? IgnoreNearExpectedFromBelow_Amount { get; set; }
        #endregion
        
        #region Parameter EvaluationIntervalInSecond
        /// <summary>
        /// <para>
        /// <para>The frequency, in seconds, at which the anomaly detector evaluates metrics. The default
        /// value is 60 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationIntervalInSeconds")]
        public System.Int32? EvaluationIntervalInSecond { get; set; }
        #endregion
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>The Amazon Managed Service for Prometheus metric labels to associate with the anomaly
        /// detector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Labels")]
        public System.Collections.Hashtable Label { get; set; }
        #endregion
        
        #region Parameter MissingDataAction_MarkAsAnomaly
        /// <summary>
        /// <para>
        /// <para>Marks missing data points as anomalies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MissingDataAction_MarkAsAnomaly { get; set; }
        #endregion
        
        #region Parameter RandomCutForest_Query
        /// <summary>
        /// <para>
        /// <para>The Prometheus query used to retrieve the time-series data for anomaly detection.</para><important><para>Random Cut Forest queries must be wrapped by a supported PromQL aggregation operator.
        /// For more information, see <a href="https://prometheus.io/docs/prometheus/latest/querying/operators/#aggregation-operators">Aggregation
        /// operators</a> on the <i>Prometheus docs</i> website.</para><para><b>Supported PromQL aggregation operators</b>: <c>avg</c>, <c>count</c>, <c>group</c>,
        /// <c>max</c>, <c>min</c>, <c>quantile</c>, <c>stddev</c>, <c>stdvar</c>, and <c>sum</c>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RandomCutForest_Query")]
        public System.String RandomCutForest_Query { get; set; }
        #endregion
        
        #region Parameter IgnoreNearExpectedFromAbove_Ratio
        /// <summary>
        /// <para>
        /// <para>The ratio by which values can differ from expected values before being considered
        /// anomalous.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RandomCutForest_IgnoreNearExpectedFromAbove_Ratio")]
        public System.Double? IgnoreNearExpectedFromAbove_Ratio { get; set; }
        #endregion
        
        #region Parameter IgnoreNearExpectedFromBelow_Ratio
        /// <summary>
        /// <para>
        /// <para>The ratio by which values can differ from expected values before being considered
        /// anomalous.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RandomCutForest_IgnoreNearExpectedFromBelow_Ratio")]
        public System.Double? IgnoreNearExpectedFromBelow_Ratio { get; set; }
        #endregion
        
        #region Parameter RandomCutForest_SampleSize
        /// <summary>
        /// <para>
        /// <para>The number of data points sampled from the input stream for the Random Cut Forest
        /// algorithm. The default number is 256 consecutive data points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RandomCutForest_SampleSize")]
        public System.Int32? RandomCutForest_SampleSize { get; set; }
        #endregion
        
        #region Parameter RandomCutForest_ShingleSize
        /// <summary>
        /// <para>
        /// <para>The number of consecutive data points used to create a shingle for the Random Cut
        /// Forest algorithm. The default number is 8 consecutive data points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RandomCutForest_ShingleSize")]
        public System.Int32? RandomCutForest_ShingleSize { get; set; }
        #endregion
        
        #region Parameter MissingDataAction_Skip
        /// <summary>
        /// <para>
        /// <para>Skips evaluation when data is missing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MissingDataAction_Skip { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata to apply to the anomaly detector to assist with categorization and organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the workspace where the anomaly detector will be created.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PrometheusService.Model.CreateAnomalyDetectorResponse).
        /// Specifying the name of a property of type Amazon.PrometheusService.Model.CreateAnomalyDetectorResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PROMAnomalyDetector (CreateAnomalyDetector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PrometheusService.Model.CreateAnomalyDetectorResponse, NewPROMAnomalyDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Alias = this.Alias;
            #if MODULAR
            if (this.Alias == null && ParameterWasBound(nameof(this.Alias)))
            {
                WriteWarning("You are passing $null as a value for parameter Alias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.IgnoreNearExpectedFromAbove_Amount = this.IgnoreNearExpectedFromAbove_Amount;
            context.IgnoreNearExpectedFromAbove_Ratio = this.IgnoreNearExpectedFromAbove_Ratio;
            context.IgnoreNearExpectedFromBelow_Amount = this.IgnoreNearExpectedFromBelow_Amount;
            context.IgnoreNearExpectedFromBelow_Ratio = this.IgnoreNearExpectedFromBelow_Ratio;
            context.RandomCutForest_Query = this.RandomCutForest_Query;
            context.RandomCutForest_SampleSize = this.RandomCutForest_SampleSize;
            context.RandomCutForest_ShingleSize = this.RandomCutForest_ShingleSize;
            context.EvaluationIntervalInSecond = this.EvaluationIntervalInSecond;
            if (this.Label != null)
            {
                context.Label = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Label.Keys)
                {
                    context.Label.Add((String)hashKey, (System.String)(this.Label[hashKey]));
                }
            }
            context.MissingDataAction_MarkAsAnomaly = this.MissingDataAction_MarkAsAnomaly;
            context.MissingDataAction_Skip = this.MissingDataAction_Skip;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PrometheusService.Model.CreateAnomalyDetectorRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Alias = cmdletContext.Alias;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.PrometheusService.Model.AnomalyDetectorConfiguration();
            Amazon.PrometheusService.Model.RandomCutForestConfiguration requestConfiguration_configuration_RandomCutForest = null;
            
             // populate RandomCutForest
            var requestConfiguration_configuration_RandomCutForestIsNull = true;
            requestConfiguration_configuration_RandomCutForest = new Amazon.PrometheusService.Model.RandomCutForestConfiguration();
            System.String requestConfiguration_configuration_RandomCutForest_randomCutForest_Query = null;
            if (cmdletContext.RandomCutForest_Query != null)
            {
                requestConfiguration_configuration_RandomCutForest_randomCutForest_Query = cmdletContext.RandomCutForest_Query;
            }
            if (requestConfiguration_configuration_RandomCutForest_randomCutForest_Query != null)
            {
                requestConfiguration_configuration_RandomCutForest.Query = requestConfiguration_configuration_RandomCutForest_randomCutForest_Query;
                requestConfiguration_configuration_RandomCutForestIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_RandomCutForest_randomCutForest_SampleSize = null;
            if (cmdletContext.RandomCutForest_SampleSize != null)
            {
                requestConfiguration_configuration_RandomCutForest_randomCutForest_SampleSize = cmdletContext.RandomCutForest_SampleSize.Value;
            }
            if (requestConfiguration_configuration_RandomCutForest_randomCutForest_SampleSize != null)
            {
                requestConfiguration_configuration_RandomCutForest.SampleSize = requestConfiguration_configuration_RandomCutForest_randomCutForest_SampleSize.Value;
                requestConfiguration_configuration_RandomCutForestIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_RandomCutForest_randomCutForest_ShingleSize = null;
            if (cmdletContext.RandomCutForest_ShingleSize != null)
            {
                requestConfiguration_configuration_RandomCutForest_randomCutForest_ShingleSize = cmdletContext.RandomCutForest_ShingleSize.Value;
            }
            if (requestConfiguration_configuration_RandomCutForest_randomCutForest_ShingleSize != null)
            {
                requestConfiguration_configuration_RandomCutForest.ShingleSize = requestConfiguration_configuration_RandomCutForest_randomCutForest_ShingleSize.Value;
                requestConfiguration_configuration_RandomCutForestIsNull = false;
            }
            Amazon.PrometheusService.Model.IgnoreNearExpected requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove = null;
            
             // populate IgnoreNearExpectedFromAbove
            var requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAboveIsNull = true;
            requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove = new Amazon.PrometheusService.Model.IgnoreNearExpected();
            System.Double? requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove_ignoreNearExpectedFromAbove_Amount = null;
            if (cmdletContext.IgnoreNearExpectedFromAbove_Amount != null)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove_ignoreNearExpectedFromAbove_Amount = cmdletContext.IgnoreNearExpectedFromAbove_Amount.Value;
            }
            if (requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove_ignoreNearExpectedFromAbove_Amount != null)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove.Amount = requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove_ignoreNearExpectedFromAbove_Amount.Value;
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAboveIsNull = false;
            }
            System.Double? requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove_ignoreNearExpectedFromAbove_Ratio = null;
            if (cmdletContext.IgnoreNearExpectedFromAbove_Ratio != null)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove_ignoreNearExpectedFromAbove_Ratio = cmdletContext.IgnoreNearExpectedFromAbove_Ratio.Value;
            }
            if (requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove_ignoreNearExpectedFromAbove_Ratio != null)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove.Ratio = requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove_ignoreNearExpectedFromAbove_Ratio.Value;
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAboveIsNull = false;
            }
             // determine if requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove should be set to null
            if (requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAboveIsNull)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove = null;
            }
            if (requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove != null)
            {
                requestConfiguration_configuration_RandomCutForest.IgnoreNearExpectedFromAbove = requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromAbove;
                requestConfiguration_configuration_RandomCutForestIsNull = false;
            }
            Amazon.PrometheusService.Model.IgnoreNearExpected requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow = null;
            
             // populate IgnoreNearExpectedFromBelow
            var requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelowIsNull = true;
            requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow = new Amazon.PrometheusService.Model.IgnoreNearExpected();
            System.Double? requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow_ignoreNearExpectedFromBelow_Amount = null;
            if (cmdletContext.IgnoreNearExpectedFromBelow_Amount != null)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow_ignoreNearExpectedFromBelow_Amount = cmdletContext.IgnoreNearExpectedFromBelow_Amount.Value;
            }
            if (requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow_ignoreNearExpectedFromBelow_Amount != null)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow.Amount = requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow_ignoreNearExpectedFromBelow_Amount.Value;
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelowIsNull = false;
            }
            System.Double? requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow_ignoreNearExpectedFromBelow_Ratio = null;
            if (cmdletContext.IgnoreNearExpectedFromBelow_Ratio != null)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow_ignoreNearExpectedFromBelow_Ratio = cmdletContext.IgnoreNearExpectedFromBelow_Ratio.Value;
            }
            if (requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow_ignoreNearExpectedFromBelow_Ratio != null)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow.Ratio = requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow_ignoreNearExpectedFromBelow_Ratio.Value;
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelowIsNull = false;
            }
             // determine if requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow should be set to null
            if (requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelowIsNull)
            {
                requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow = null;
            }
            if (requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow != null)
            {
                requestConfiguration_configuration_RandomCutForest.IgnoreNearExpectedFromBelow = requestConfiguration_configuration_RandomCutForest_configuration_RandomCutForest_IgnoreNearExpectedFromBelow;
                requestConfiguration_configuration_RandomCutForestIsNull = false;
            }
             // determine if requestConfiguration_configuration_RandomCutForest should be set to null
            if (requestConfiguration_configuration_RandomCutForestIsNull)
            {
                requestConfiguration_configuration_RandomCutForest = null;
            }
            if (requestConfiguration_configuration_RandomCutForest != null)
            {
                request.Configuration.RandomCutForest = requestConfiguration_configuration_RandomCutForest;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.EvaluationIntervalInSecond != null)
            {
                request.EvaluationIntervalInSeconds = cmdletContext.EvaluationIntervalInSecond.Value;
            }
            if (cmdletContext.Label != null)
            {
                request.Labels = cmdletContext.Label;
            }
            
             // populate MissingDataAction
            var requestMissingDataActionIsNull = true;
            request.MissingDataAction = new Amazon.PrometheusService.Model.AnomalyDetectorMissingDataAction();
            System.Boolean? requestMissingDataAction_missingDataAction_MarkAsAnomaly = null;
            if (cmdletContext.MissingDataAction_MarkAsAnomaly != null)
            {
                requestMissingDataAction_missingDataAction_MarkAsAnomaly = cmdletContext.MissingDataAction_MarkAsAnomaly.Value;
            }
            if (requestMissingDataAction_missingDataAction_MarkAsAnomaly != null)
            {
                request.MissingDataAction.MarkAsAnomaly = requestMissingDataAction_missingDataAction_MarkAsAnomaly.Value;
                requestMissingDataActionIsNull = false;
            }
            System.Boolean? requestMissingDataAction_missingDataAction_Skip = null;
            if (cmdletContext.MissingDataAction_Skip != null)
            {
                requestMissingDataAction_missingDataAction_Skip = cmdletContext.MissingDataAction_Skip.Value;
            }
            if (requestMissingDataAction_missingDataAction_Skip != null)
            {
                request.MissingDataAction.Skip = requestMissingDataAction_missingDataAction_Skip.Value;
                requestMissingDataActionIsNull = false;
            }
             // determine if request.MissingDataAction should be set to null
            if (requestMissingDataActionIsNull)
            {
                request.MissingDataAction = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
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
        
        private Amazon.PrometheusService.Model.CreateAnomalyDetectorResponse CallAWSServiceOperation(IAmazonPrometheusService client, Amazon.PrometheusService.Model.CreateAnomalyDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Prometheus Service", "CreateAnomalyDetector");
            try
            {
                #if DESKTOP
                return client.CreateAnomalyDetector(request);
                #elif CORECLR
                return client.CreateAnomalyDetectorAsync(request).GetAwaiter().GetResult();
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
            public System.String Alias { get; set; }
            public System.String ClientToken { get; set; }
            public System.Double? IgnoreNearExpectedFromAbove_Amount { get; set; }
            public System.Double? IgnoreNearExpectedFromAbove_Ratio { get; set; }
            public System.Double? IgnoreNearExpectedFromBelow_Amount { get; set; }
            public System.Double? IgnoreNearExpectedFromBelow_Ratio { get; set; }
            public System.String RandomCutForest_Query { get; set; }
            public System.Int32? RandomCutForest_SampleSize { get; set; }
            public System.Int32? RandomCutForest_ShingleSize { get; set; }
            public System.Int32? EvaluationIntervalInSecond { get; set; }
            public Dictionary<System.String, System.String> Label { get; set; }
            public System.Boolean? MissingDataAction_MarkAsAnomaly { get; set; }
            public System.Boolean? MissingDataAction_Skip { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.PrometheusService.Model.CreateAnomalyDetectorResponse, NewPROMAnomalyDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
