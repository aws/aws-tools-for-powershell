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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Updates an existing log anomaly detector.
    /// </summary>
    [Cmdlet("Update", "CWLLogAnomalyDetector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs UpdateLogAnomalyDetector API operation.", Operation = new[] {"UpdateLogAnomalyDetector"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.UpdateLogAnomalyDetectorResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchLogs.Model.UpdateLogAnomalyDetectorResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchLogs.Model.UpdateLogAnomalyDetectorResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWLLogAnomalyDetectorCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the anomaly detector that you want to update.</para>
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
        public System.String AnomalyDetectorArn { get; set; }
        #endregion
        
        #region Parameter AnomalyVisibilityTime
        /// <summary>
        /// <para>
        /// <para>The number of days to use as the life cycle of anomalies. After this time, anomalies
        /// are automatically baselined and the anomaly detector model will treat new occurrences
        /// of similar event as normal. Therefore, if you do not correct the cause of an anomaly
        /// during this time, it will be considered normal going forward and will not be detected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? AnomalyVisibilityTime { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Use this parameter to pause or restart the anomaly detector. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter EvaluationFrequency
        /// <summary>
        /// <para>
        /// <para>Specifies how often the anomaly detector runs and look for anomalies. Set this value
        /// according to the frequency that the log group receives new logs. For example, if the
        /// log group receives new log events every 10 minutes, then setting <c>evaluationFrequency</c>
        /// to <c>FIFTEEN_MIN</c> might be appropriate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.EvaluationFrequency")]
        public Amazon.CloudWatchLogs.EvaluationFrequency EvaluationFrequency { get; set; }
        #endregion
        
        #region Parameter FilterPattern
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterPattern { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.UpdateLogAnomalyDetectorResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AnomalyDetectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWLLogAnomalyDetector (UpdateLogAnomalyDetector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.UpdateLogAnomalyDetectorResponse, UpdateCWLLogAnomalyDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
            #if MODULAR
            if (this.AnomalyDetectorArn == null && ParameterWasBound(nameof(this.AnomalyDetectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyVisibilityTime = this.AnomalyVisibilityTime;
            context.Enabled = this.Enabled;
            #if MODULAR
            if (this.Enabled == null && ParameterWasBound(nameof(this.Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationFrequency = this.EvaluationFrequency;
            context.FilterPattern = this.FilterPattern;
            
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
            var request = new Amazon.CloudWatchLogs.Model.UpdateLogAnomalyDetectorRequest();
            
            if (cmdletContext.AnomalyDetectorArn != null)
            {
                request.AnomalyDetectorArn = cmdletContext.AnomalyDetectorArn;
            }
            if (cmdletContext.AnomalyVisibilityTime != null)
            {
                request.AnomalyVisibilityTime = cmdletContext.AnomalyVisibilityTime.Value;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EvaluationFrequency != null)
            {
                request.EvaluationFrequency = cmdletContext.EvaluationFrequency;
            }
            if (cmdletContext.FilterPattern != null)
            {
                request.FilterPattern = cmdletContext.FilterPattern;
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
        
        private Amazon.CloudWatchLogs.Model.UpdateLogAnomalyDetectorResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.UpdateLogAnomalyDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "UpdateLogAnomalyDetector");
            try
            {
                return client.UpdateLogAnomalyDetectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? AnomalyVisibilityTime { get; set; }
            public System.Boolean? Enabled { get; set; }
            public Amazon.CloudWatchLogs.EvaluationFrequency EvaluationFrequency { get; set; }
            public System.String FilterPattern { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.UpdateLogAnomalyDetectorResponse, UpdateCWLLogAnomalyDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
