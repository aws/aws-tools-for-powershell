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

namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Updates a detector. After activation, you can only change a detector's ingestion delay
    /// and description.
    /// </summary>
    [Cmdlet("Update", "LOMAnomalyDetector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics UpdateAnomalyDetector API operation.", Operation = new[] {"UpdateAnomalyDetector"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateLOMAnomalyDetectorCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the detector to update.</para>
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
        
        #region Parameter AnomalyDetectorDescription
        /// <summary>
        /// <para>
        /// <para>The updated detector description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalyDetectorDescription { get; set; }
        #endregion
        
        #region Parameter AnomalyDetectorConfig_AnomalyDetectorFrequency
        /// <summary>
        /// <para>
        /// <para>The frequency at which the detector analyzes its source data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LookoutMetrics.Frequency")]
        public Amazon.LookoutMetrics.Frequency AnomalyDetectorConfig_AnomalyDetectorFrequency { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an AWS KMS encryption key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnomalyDetectorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnomalyDetectorArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LOMAnomalyDetector (UpdateAnomalyDetector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorResponse, UpdateLOMAnomalyDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
            #if MODULAR
            if (this.AnomalyDetectorArn == null && ParameterWasBound(nameof(this.AnomalyDetectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyDetectorConfig_AnomalyDetectorFrequency = this.AnomalyDetectorConfig_AnomalyDetectorFrequency;
            context.AnomalyDetectorDescription = this.AnomalyDetectorDescription;
            context.KmsKeyArn = this.KmsKeyArn;
            
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
            var request = new Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorRequest();
            
            if (cmdletContext.AnomalyDetectorArn != null)
            {
                request.AnomalyDetectorArn = cmdletContext.AnomalyDetectorArn;
            }
            
             // populate AnomalyDetectorConfig
            var requestAnomalyDetectorConfigIsNull = true;
            request.AnomalyDetectorConfig = new Amazon.LookoutMetrics.Model.AnomalyDetectorConfig();
            Amazon.LookoutMetrics.Frequency requestAnomalyDetectorConfig_anomalyDetectorConfig_AnomalyDetectorFrequency = null;
            if (cmdletContext.AnomalyDetectorConfig_AnomalyDetectorFrequency != null)
            {
                requestAnomalyDetectorConfig_anomalyDetectorConfig_AnomalyDetectorFrequency = cmdletContext.AnomalyDetectorConfig_AnomalyDetectorFrequency;
            }
            if (requestAnomalyDetectorConfig_anomalyDetectorConfig_AnomalyDetectorFrequency != null)
            {
                request.AnomalyDetectorConfig.AnomalyDetectorFrequency = requestAnomalyDetectorConfig_anomalyDetectorConfig_AnomalyDetectorFrequency;
                requestAnomalyDetectorConfigIsNull = false;
            }
             // determine if request.AnomalyDetectorConfig should be set to null
            if (requestAnomalyDetectorConfigIsNull)
            {
                request.AnomalyDetectorConfig = null;
            }
            if (cmdletContext.AnomalyDetectorDescription != null)
            {
                request.AnomalyDetectorDescription = cmdletContext.AnomalyDetectorDescription;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
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
        
        private Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "UpdateAnomalyDetector");
            try
            {
                return client.UpdateAnomalyDetectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.LookoutMetrics.Frequency AnomalyDetectorConfig_AnomalyDetectorFrequency { get; set; }
            public System.String AnomalyDetectorDescription { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.UpdateAnomalyDetectorResponse, UpdateLOMAnomalyDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnomalyDetectorArn;
        }
        
    }
}
