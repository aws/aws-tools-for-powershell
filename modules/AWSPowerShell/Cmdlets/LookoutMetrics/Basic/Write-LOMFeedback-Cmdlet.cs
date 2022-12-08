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
    /// Add feedback for an anomalous metric.
    /// </summary>
    [Cmdlet("Write", "LOMFeedback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics PutFeedback API operation.", Operation = new[] {"PutFeedback"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.PutFeedbackResponse))]
    [AWSCmdletOutput("None or Amazon.LookoutMetrics.Model.PutFeedbackResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LookoutMetrics.Model.PutFeedbackResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteLOMFeedbackCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the anomaly detector.</para>
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
        
        #region Parameter AnomalyGroupTimeSeriesFeedback_AnomalyGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the anomaly group.</para>
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
        public System.String AnomalyGroupTimeSeriesFeedback_AnomalyGroupId { get; set; }
        #endregion
        
        #region Parameter AnomalyGroupTimeSeriesFeedback_IsAnomaly
        /// <summary>
        /// <para>
        /// <para>Feedback on whether the metric is a legitimate anomaly.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? AnomalyGroupTimeSeriesFeedback_IsAnomaly { get; set; }
        #endregion
        
        #region Parameter AnomalyGroupTimeSeriesFeedback_TimeSeriesId
        /// <summary>
        /// <para>
        /// <para>The ID of the metric.</para>
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
        public System.String AnomalyGroupTimeSeriesFeedback_TimeSeriesId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.PutFeedbackResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AnomalyDetectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LOMFeedback (PutFeedback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.PutFeedbackResponse, WriteLOMFeedbackCmdlet>(Select) ??
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
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
            #if MODULAR
            if (this.AnomalyDetectorArn == null && ParameterWasBound(nameof(this.AnomalyDetectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId = this.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId;
            #if MODULAR
            if (this.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId == null && ParameterWasBound(nameof(this.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyGroupTimeSeriesFeedback_AnomalyGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyGroupTimeSeriesFeedback_IsAnomaly = this.AnomalyGroupTimeSeriesFeedback_IsAnomaly;
            #if MODULAR
            if (this.AnomalyGroupTimeSeriesFeedback_IsAnomaly == null && ParameterWasBound(nameof(this.AnomalyGroupTimeSeriesFeedback_IsAnomaly)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyGroupTimeSeriesFeedback_IsAnomaly which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyGroupTimeSeriesFeedback_TimeSeriesId = this.AnomalyGroupTimeSeriesFeedback_TimeSeriesId;
            #if MODULAR
            if (this.AnomalyGroupTimeSeriesFeedback_TimeSeriesId == null && ParameterWasBound(nameof(this.AnomalyGroupTimeSeriesFeedback_TimeSeriesId)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyGroupTimeSeriesFeedback_TimeSeriesId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LookoutMetrics.Model.PutFeedbackRequest();
            
            if (cmdletContext.AnomalyDetectorArn != null)
            {
                request.AnomalyDetectorArn = cmdletContext.AnomalyDetectorArn;
            }
            
             // populate AnomalyGroupTimeSeriesFeedback
            var requestAnomalyGroupTimeSeriesFeedbackIsNull = true;
            request.AnomalyGroupTimeSeriesFeedback = new Amazon.LookoutMetrics.Model.AnomalyGroupTimeSeriesFeedback();
            System.String requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_AnomalyGroupId = null;
            if (cmdletContext.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId != null)
            {
                requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_AnomalyGroupId = cmdletContext.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId;
            }
            if (requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_AnomalyGroupId != null)
            {
                request.AnomalyGroupTimeSeriesFeedback.AnomalyGroupId = requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_AnomalyGroupId;
                requestAnomalyGroupTimeSeriesFeedbackIsNull = false;
            }
            System.Boolean? requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_IsAnomaly = null;
            if (cmdletContext.AnomalyGroupTimeSeriesFeedback_IsAnomaly != null)
            {
                requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_IsAnomaly = cmdletContext.AnomalyGroupTimeSeriesFeedback_IsAnomaly.Value;
            }
            if (requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_IsAnomaly != null)
            {
                request.AnomalyGroupTimeSeriesFeedback.IsAnomaly = requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_IsAnomaly.Value;
                requestAnomalyGroupTimeSeriesFeedbackIsNull = false;
            }
            System.String requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_TimeSeriesId = null;
            if (cmdletContext.AnomalyGroupTimeSeriesFeedback_TimeSeriesId != null)
            {
                requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_TimeSeriesId = cmdletContext.AnomalyGroupTimeSeriesFeedback_TimeSeriesId;
            }
            if (requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_TimeSeriesId != null)
            {
                request.AnomalyGroupTimeSeriesFeedback.TimeSeriesId = requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_TimeSeriesId;
                requestAnomalyGroupTimeSeriesFeedbackIsNull = false;
            }
             // determine if request.AnomalyGroupTimeSeriesFeedback should be set to null
            if (requestAnomalyGroupTimeSeriesFeedbackIsNull)
            {
                request.AnomalyGroupTimeSeriesFeedback = null;
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
        
        private Amazon.LookoutMetrics.Model.PutFeedbackResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.PutFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "PutFeedback");
            try
            {
                #if DESKTOP
                return client.PutFeedback(request);
                #elif CORECLR
                return client.PutFeedbackAsync(request).GetAwaiter().GetResult();
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
            public System.String AnomalyDetectorArn { get; set; }
            public System.String AnomalyGroupTimeSeriesFeedback_AnomalyGroupId { get; set; }
            public System.Boolean? AnomalyGroupTimeSeriesFeedback_IsAnomaly { get; set; }
            public System.String AnomalyGroupTimeSeriesFeedback_TimeSeriesId { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.PutFeedbackResponse, WriteLOMFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
