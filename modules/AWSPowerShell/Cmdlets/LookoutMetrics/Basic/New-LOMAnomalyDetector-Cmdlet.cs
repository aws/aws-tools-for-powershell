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
    /// Creates an anomaly detector.
    /// </summary>
    [Cmdlet("New", "LOMAnomalyDetector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics CreateAnomalyDetector API operation.", Operation = new[] {"CreateAnomalyDetector"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.CreateAnomalyDetectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.LookoutMetrics.Model.CreateAnomalyDetectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LookoutMetrics.Model.CreateAnomalyDetectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLOMAnomalyDetectorCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnomalyDetectorDescription
        /// <summary>
        /// <para>
        /// <para>A description of the detector.</para>
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
        
        #region Parameter AnomalyDetectorName
        /// <summary>
        /// <para>
        /// <para>The name of the detector.</para>
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
        public System.String AnomalyDetectorName { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key to use to encrypt your data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/lookoutmetrics/latest/dev/detectors-tags.html">tags</a>
        /// to apply to the anomaly detector.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnomalyDetectorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.CreateAnomalyDetectorResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.CreateAnomalyDetectorResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AnomalyDetectorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LOMAnomalyDetector (CreateAnomalyDetector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.CreateAnomalyDetectorResponse, NewLOMAnomalyDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyDetectorConfig_AnomalyDetectorFrequency = this.AnomalyDetectorConfig_AnomalyDetectorFrequency;
            context.AnomalyDetectorDescription = this.AnomalyDetectorDescription;
            context.AnomalyDetectorName = this.AnomalyDetectorName;
            #if MODULAR
            if (this.AnomalyDetectorName == null && ParameterWasBound(nameof(this.AnomalyDetectorName)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyArn = this.KmsKeyArn;
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
            var request = new Amazon.LookoutMetrics.Model.CreateAnomalyDetectorRequest();
            
            
             // populate AnomalyDetectorConfig
            request.AnomalyDetectorConfig = new Amazon.LookoutMetrics.Model.AnomalyDetectorConfig();
            Amazon.LookoutMetrics.Frequency requestAnomalyDetectorConfig_anomalyDetectorConfig_AnomalyDetectorFrequency = null;
            if (cmdletContext.AnomalyDetectorConfig_AnomalyDetectorFrequency != null)
            {
                requestAnomalyDetectorConfig_anomalyDetectorConfig_AnomalyDetectorFrequency = cmdletContext.AnomalyDetectorConfig_AnomalyDetectorFrequency;
            }
            if (requestAnomalyDetectorConfig_anomalyDetectorConfig_AnomalyDetectorFrequency != null)
            {
                request.AnomalyDetectorConfig.AnomalyDetectorFrequency = requestAnomalyDetectorConfig_anomalyDetectorConfig_AnomalyDetectorFrequency;
            }
            if (cmdletContext.AnomalyDetectorDescription != null)
            {
                request.AnomalyDetectorDescription = cmdletContext.AnomalyDetectorDescription;
            }
            if (cmdletContext.AnomalyDetectorName != null)
            {
                request.AnomalyDetectorName = cmdletContext.AnomalyDetectorName;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
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
        
        private Amazon.LookoutMetrics.Model.CreateAnomalyDetectorResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.CreateAnomalyDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "CreateAnomalyDetector");
            try
            {
                return client.CreateAnomalyDetectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.LookoutMetrics.Frequency AnomalyDetectorConfig_AnomalyDetectorFrequency { get; set; }
            public System.String AnomalyDetectorDescription { get; set; }
            public System.String AnomalyDetectorName { get; set; }
            public System.String KmsKeyArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.CreateAnomalyDetectorResponse, NewLOMAnomalyDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnomalyDetectorArn;
        }
        
    }
}
