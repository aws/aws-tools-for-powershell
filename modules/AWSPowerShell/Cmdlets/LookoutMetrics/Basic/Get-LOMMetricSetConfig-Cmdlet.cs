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
using Amazon.LookoutMetrics;
using Amazon.LookoutMetrics.Model;

namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Detects an Amazon S3 dataset's file format, interval, and offset.
    /// </summary>
    [Cmdlet("Get", "LOMMetricSetConfig")]
    [OutputType("Amazon.LookoutMetrics.Model.DetectedMetricSetConfig")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics DetectMetricSetConfig API operation.", Operation = new[] {"DetectMetricSetConfig"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.DetectMetricSetConfigResponse))]
    [AWSCmdletOutput("Amazon.LookoutMetrics.Model.DetectedMetricSetConfig or Amazon.LookoutMetrics.Model.DetectMetricSetConfigResponse",
        "This cmdlet returns an Amazon.LookoutMetrics.Model.DetectedMetricSetConfig object.",
        "The service call response (type Amazon.LookoutMetrics.Model.DetectMetricSetConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLOMMetricSetConfigCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>An anomaly detector ARN.</para>
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
        
        #region Parameter S3SourceConfig_HistoricalDataPathList
        /// <summary>
        /// <para>
        /// <para>The config's historical data path list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoDetectionMetricSource_S3SourceConfig_HistoricalDataPathList")]
        public System.String[] S3SourceConfig_HistoricalDataPathList { get; set; }
        #endregion
        
        #region Parameter S3SourceConfig_TemplatedPathList
        /// <summary>
        /// <para>
        /// <para>The config's templated path list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoDetectionMetricSource_S3SourceConfig_TemplatedPathList")]
        public System.String[] S3SourceConfig_TemplatedPathList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DetectedMetricSetConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.DetectMetricSetConfigResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.DetectMetricSetConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DetectedMetricSetConfig";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.DetectMetricSetConfigResponse, GetLOMMetricSetConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
            #if MODULAR
            if (this.AnomalyDetectorArn == null && ParameterWasBound(nameof(this.AnomalyDetectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.S3SourceConfig_HistoricalDataPathList != null)
            {
                context.S3SourceConfig_HistoricalDataPathList = new List<System.String>(this.S3SourceConfig_HistoricalDataPathList);
            }
            if (this.S3SourceConfig_TemplatedPathList != null)
            {
                context.S3SourceConfig_TemplatedPathList = new List<System.String>(this.S3SourceConfig_TemplatedPathList);
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
            var request = new Amazon.LookoutMetrics.Model.DetectMetricSetConfigRequest();
            
            if (cmdletContext.AnomalyDetectorArn != null)
            {
                request.AnomalyDetectorArn = cmdletContext.AnomalyDetectorArn;
            }
            
             // populate AutoDetectionMetricSource
            var requestAutoDetectionMetricSourceIsNull = true;
            request.AutoDetectionMetricSource = new Amazon.LookoutMetrics.Model.AutoDetectionMetricSource();
            Amazon.LookoutMetrics.Model.AutoDetectionS3SourceConfig requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig = null;
            
             // populate S3SourceConfig
            var requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfigIsNull = true;
            requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig = new Amazon.LookoutMetrics.Model.AutoDetectionS3SourceConfig();
            List<System.String> requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig_s3SourceConfig_HistoricalDataPathList = null;
            if (cmdletContext.S3SourceConfig_HistoricalDataPathList != null)
            {
                requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig_s3SourceConfig_HistoricalDataPathList = cmdletContext.S3SourceConfig_HistoricalDataPathList;
            }
            if (requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig_s3SourceConfig_HistoricalDataPathList != null)
            {
                requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig.HistoricalDataPathList = requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig_s3SourceConfig_HistoricalDataPathList;
                requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfigIsNull = false;
            }
            List<System.String> requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig_s3SourceConfig_TemplatedPathList = null;
            if (cmdletContext.S3SourceConfig_TemplatedPathList != null)
            {
                requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig_s3SourceConfig_TemplatedPathList = cmdletContext.S3SourceConfig_TemplatedPathList;
            }
            if (requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig_s3SourceConfig_TemplatedPathList != null)
            {
                requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig.TemplatedPathList = requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig_s3SourceConfig_TemplatedPathList;
                requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfigIsNull = false;
            }
             // determine if requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig should be set to null
            if (requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfigIsNull)
            {
                requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig = null;
            }
            if (requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig != null)
            {
                request.AutoDetectionMetricSource.S3SourceConfig = requestAutoDetectionMetricSource_autoDetectionMetricSource_S3SourceConfig;
                requestAutoDetectionMetricSourceIsNull = false;
            }
             // determine if request.AutoDetectionMetricSource should be set to null
            if (requestAutoDetectionMetricSourceIsNull)
            {
                request.AutoDetectionMetricSource = null;
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
        
        private Amazon.LookoutMetrics.Model.DetectMetricSetConfigResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.DetectMetricSetConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "DetectMetricSetConfig");
            try
            {
                #if DESKTOP
                return client.DetectMetricSetConfig(request);
                #elif CORECLR
                return client.DetectMetricSetConfigAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> S3SourceConfig_HistoricalDataPathList { get; set; }
            public List<System.String> S3SourceConfig_TemplatedPathList { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.DetectMetricSetConfigResponse, GetLOMMetricSetConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DetectedMetricSetConfig;
        }
        
    }
}
