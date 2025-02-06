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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Use this operation to <i>suppress</i> anomaly detection for a specified anomaly or
    /// pattern. If you suppress an anomaly, CloudWatch Logs won't report new occurrences
    /// of that anomaly and won't update that anomaly with new data. If you suppress a pattern,
    /// CloudWatch Logs won't report any anomalies related to that pattern.
    /// 
    ///  
    /// <para>
    /// You must specify either <c>anomalyId</c> or <c>patternId</c>, but you can't specify
    /// both parameters in the same operation.
    /// </para><para>
    /// If you have previously used this operation to suppress detection of a pattern or anomaly,
    /// you can use it again to cause CloudWatch Logs to end the suppression. To do this,
    /// use this operation and specify the anomaly or pattern to stop suppressing, and omit
    /// the <c>suppressionType</c> and <c>suppressionPeriod</c> parameters.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CWLAnomaly", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs UpdateAnomaly API operation.", Operation = new[] {"UpdateAnomaly"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.UpdateAnomalyResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchLogs.Model.UpdateAnomalyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchLogs.Model.UpdateAnomalyResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWLAnomalyCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the anomaly detector that this operation is to act on.</para>
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
        
        #region Parameter AnomalyId
        /// <summary>
        /// <para>
        /// <para>If you are suppressing or unsuppressing an anomaly, specify its unique ID here. You
        /// can find anomaly IDs by using the <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_ListAnomalies.html">ListAnomalies</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalyId { get; set; }
        #endregion
        
        #region Parameter Baseline
        /// <summary>
        /// <para>
        /// <para>Set this to <c>true</c> to prevent CloudWatch Logs from displaying this behavior as
        /// an anomaly in the future. The behavior is then treated as baseline behavior. However,
        /// if similar but more severe occurrences of this behavior occur in the future, those
        /// will still be reported as anomalies. </para><para>The default is <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Baseline { get; set; }
        #endregion
        
        #region Parameter PatternId
        /// <summary>
        /// <para>
        /// <para>If you are suppressing or unsuppressing an pattern, specify its unique ID here. You
        /// can find pattern IDs by using the <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_ListAnomalies.html">ListAnomalies</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PatternId { get; set; }
        #endregion
        
        #region Parameter SuppressionType
        /// <summary>
        /// <para>
        /// <para>Use this to specify whether the suppression to be temporary or infinite. If you specify
        /// <c>LIMITED</c>, you must also specify a <c>suppressionPeriod</c>. If you specify <c>INFINITE</c>,
        /// any value for <c>suppressionPeriod</c> is ignored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.SuppressionType")]
        public Amazon.CloudWatchLogs.SuppressionType SuppressionType { get; set; }
        #endregion
        
        #region Parameter SuppressionPeriod_SuppressionUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether the value of <c>value</c> is in seconds, minutes, or hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.SuppressionUnit")]
        public Amazon.CloudWatchLogs.SuppressionUnit SuppressionPeriod_SuppressionUnit { get; set; }
        #endregion
        
        #region Parameter SuppressionPeriod_Value
        /// <summary>
        /// <para>
        /// <para>Specifies the number of seconds, minutes or hours to suppress this anomaly. There
        /// is no maximum.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SuppressionPeriod_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.UpdateAnomalyResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AnomalyDetectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWLAnomaly (UpdateAnomaly)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.UpdateAnomalyResponse, UpdateCWLAnomalyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
            #if MODULAR
            if (this.AnomalyDetectorArn == null && ParameterWasBound(nameof(this.AnomalyDetectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyId = this.AnomalyId;
            context.Baseline = this.Baseline;
            context.PatternId = this.PatternId;
            context.SuppressionPeriod_SuppressionUnit = this.SuppressionPeriod_SuppressionUnit;
            context.SuppressionPeriod_Value = this.SuppressionPeriod_Value;
            context.SuppressionType = this.SuppressionType;
            
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
            var request = new Amazon.CloudWatchLogs.Model.UpdateAnomalyRequest();
            
            if (cmdletContext.AnomalyDetectorArn != null)
            {
                request.AnomalyDetectorArn = cmdletContext.AnomalyDetectorArn;
            }
            if (cmdletContext.AnomalyId != null)
            {
                request.AnomalyId = cmdletContext.AnomalyId;
            }
            if (cmdletContext.Baseline != null)
            {
                request.Baseline = cmdletContext.Baseline.Value;
            }
            if (cmdletContext.PatternId != null)
            {
                request.PatternId = cmdletContext.PatternId;
            }
            
             // populate SuppressionPeriod
            var requestSuppressionPeriodIsNull = true;
            request.SuppressionPeriod = new Amazon.CloudWatchLogs.Model.SuppressionPeriod();
            Amazon.CloudWatchLogs.SuppressionUnit requestSuppressionPeriod_suppressionPeriod_SuppressionUnit = null;
            if (cmdletContext.SuppressionPeriod_SuppressionUnit != null)
            {
                requestSuppressionPeriod_suppressionPeriod_SuppressionUnit = cmdletContext.SuppressionPeriod_SuppressionUnit;
            }
            if (requestSuppressionPeriod_suppressionPeriod_SuppressionUnit != null)
            {
                request.SuppressionPeriod.SuppressionUnit = requestSuppressionPeriod_suppressionPeriod_SuppressionUnit;
                requestSuppressionPeriodIsNull = false;
            }
            System.Int32? requestSuppressionPeriod_suppressionPeriod_Value = null;
            if (cmdletContext.SuppressionPeriod_Value != null)
            {
                requestSuppressionPeriod_suppressionPeriod_Value = cmdletContext.SuppressionPeriod_Value.Value;
            }
            if (requestSuppressionPeriod_suppressionPeriod_Value != null)
            {
                request.SuppressionPeriod.Value = requestSuppressionPeriod_suppressionPeriod_Value.Value;
                requestSuppressionPeriodIsNull = false;
            }
             // determine if request.SuppressionPeriod should be set to null
            if (requestSuppressionPeriodIsNull)
            {
                request.SuppressionPeriod = null;
            }
            if (cmdletContext.SuppressionType != null)
            {
                request.SuppressionType = cmdletContext.SuppressionType;
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
        
        private Amazon.CloudWatchLogs.Model.UpdateAnomalyResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.UpdateAnomalyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "UpdateAnomaly");
            try
            {
                #if DESKTOP
                return client.UpdateAnomaly(request);
                #elif CORECLR
                return client.UpdateAnomalyAsync(request).GetAwaiter().GetResult();
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
            public System.String AnomalyId { get; set; }
            public System.Boolean? Baseline { get; set; }
            public System.String PatternId { get; set; }
            public Amazon.CloudWatchLogs.SuppressionUnit SuppressionPeriod_SuppressionUnit { get; set; }
            public System.Int32? SuppressionPeriod_Value { get; set; }
            public Amazon.CloudWatchLogs.SuppressionType SuppressionType { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.UpdateAnomalyResponse, UpdateCWLAnomalyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
