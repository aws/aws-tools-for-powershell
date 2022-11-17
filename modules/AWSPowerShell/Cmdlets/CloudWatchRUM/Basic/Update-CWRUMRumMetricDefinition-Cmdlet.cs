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
using Amazon.CloudWatchRUM;
using Amazon.CloudWatchRUM.Model;

namespace Amazon.PowerShell.Cmdlets.CWRUM
{
    /// <summary>
    /// Modifies one existing metric definition for CloudWatch RUM extended metrics. For more
    /// information about extended metrics, see <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_BatchCreateRumMetricsDefinitions.html">BatchCreateRumMetricsDefinitions</a>.
    /// </summary>
    [Cmdlet("Update", "CWRUMRumMetricDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CloudWatch RUM UpdateRumMetricDefinition API operation.", Operation = new[] {"UpdateRumMetricDefinition"}, SelectReturnType = typeof(Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCWRUMRumMetricDefinitionCmdlet : AmazonCloudWatchRUMClientCmdlet, IExecutor
    {
        
        #region Parameter AppMonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch RUM app monitor that sends these metrics.</para>
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
        public System.String AppMonitorName { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The destination to send the metrics to. Valid values are <code>CloudWatch</code> and
        /// <code>Evidently</code>. If you specify <code>Evidently</code>, you must also specify
        /// the ARN of the CloudWatchEvidently experiment that will receive the metrics and an
        /// IAM role that has permission to write to the experiment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchRUM.MetricDestination")]
        public Amazon.CloudWatchRUM.MetricDestination Destination { get; set; }
        #endregion
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>This parameter is required if <code>Destination</code> is <code>Evidently</code>.
        /// If <code>Destination</code> is <code>CloudWatch</code>, do not use this parameter.</para><para>This parameter specifies the ARN of the Evidently experiment that is to receive the
        /// metrics. You must have already defined this experiment as a valid destination. For
        /// more information, see <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_PutRumMetricsDestination.html">PutRumMetricsDestination</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_DimensionKey
        /// <summary>
        /// <para>
        /// <para>Use this field only if you are sending the metric to CloudWatch.</para><para>This field is a map of field paths to dimension names. It defines the dimensions to
        /// associate with this metric in CloudWatch. Valid values for the entries in this field
        /// are the following:</para><ul><li><para><code>"metadata.pageId": "PageId"</code></para></li><li><para><code>"metadata.browserName": "BrowserName"</code></para></li><li><para><code>"metadata.deviceType": "DeviceType"</code></para></li><li><para><code>"metadata.osName": "OSName"</code></para></li><li><para><code>"metadata.countryCode": "CountryCode"</code></para></li><li><para><code>"event_details.fileType": "FileType"</code></para></li></ul><para> All dimensions listed in this field must also be included in <code>EventPattern</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricDefinition_DimensionKeys")]
        public System.Collections.Hashtable MetricDefinition_DimensionKey { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_EventPattern
        /// <summary>
        /// <para>
        /// <para>The pattern that defines the metric, specified as a JSON object. RUM checks events
        /// that happen in a user's session against the pattern, and events that match the pattern
        /// are sent to the metric destination.</para><para>When you define extended metrics, the metric definition is not valid if <code>EventPattern</code>
        /// is omitted.</para><para>Example event patterns:</para><ul><li><para><code>'{ "event_type": ["com.amazon.rum.js_error_event"], "metadata": { "browserName":
        /// [ "Chrome", "Safari" ], } }'</code></para></li><li><para><code>'{ "event_type": ["com.amazon.rum.performance_navigation_event"], "metadata":
        /// { "browserName": [ "Chrome", "Firefox" ] }, "event_details": { "duration": [{ "numeric":
        /// [ "&lt;", 2000 ] }] } }'</code></para></li><li><para><code>'{ "event_type": ["com.amazon.rum.performance_navigation_event"], "metadata":
        /// { "browserName": [ "Chrome", "Safari" ], "countryCode": [ "US" ] }, "event_details":
        /// { "duration": [{ "numeric": [ "&gt;=", 2000, "&lt;", 8000 ] }] } }'</code></para></li></ul><para>If the metrics destination' is <code>CloudWatch</code> and the event also matches
        /// a value in <code>DimensionKeys</code>, then the metric is published with the specified
        /// dimensions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricDefinition_EventPattern { get; set; }
        #endregion
        
        #region Parameter MetricDefinitionId
        /// <summary>
        /// <para>
        /// <para>The ID of the metric definition to update.</para>
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
        public System.String MetricDefinitionId { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_Name
        /// <summary>
        /// <para>
        /// <para>The name for the metric that is defined in this structure. Valid values are the following:</para><ul><li><para><code>PerformanceNavigationDuration</code></para></li><li><para><code>PerformanceResourceDuration </code></para></li><li><para><code>NavigationSatisfiedTransaction</code></para></li><li><para><code>NavigationToleratedTransaction</code></para></li><li><para><code>NavigationFrustratedTransaction</code></para></li><li><para><code>WebVitalsCumulativeLayoutShift</code></para></li><li><para><code>WebVitalsFirstInputDelay</code></para></li><li><para><code>WebVitalsLargestContentfulPaint</code></para></li><li><para><code>JsErrorCount</code></para></li><li><para><code>HttpErrorCount</code></para></li><li><para><code>SessionCount</code></para></li></ul>
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
        public System.String MetricDefinition_Name { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_UnitLabel
        /// <summary>
        /// <para>
        /// <para>The CloudWatch metric unit to use for this metric. If you omit this field, the metric
        /// is recorded with no unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricDefinition_UnitLabel { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_ValueKey
        /// <summary>
        /// <para>
        /// <para>The field within the event object that the metric value is sourced from.</para><para>If you omit this field, a hardcoded value of 1 is pushed as the metric value. This
        /// is useful if you just want to count the number of events that the filter catches.
        /// </para><para>If this metric is sent to CloudWatch Evidently, this field will be passed to Evidently
        /// raw and Evidently will handle data extraction from the event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricDefinition_ValueKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MetricDefinitionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MetricDefinitionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MetricDefinitionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MetricDefinitionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWRUMRumMetricDefinition (UpdateRumMetricDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse, UpdateCWRUMRumMetricDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MetricDefinitionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppMonitorName = this.AppMonitorName;
            #if MODULAR
            if (this.AppMonitorName == null && ParameterWasBound(nameof(this.AppMonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter AppMonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Destination = this.Destination;
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationArn = this.DestinationArn;
            if (this.MetricDefinition_DimensionKey != null)
            {
                context.MetricDefinition_DimensionKey = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.MetricDefinition_DimensionKey.Keys)
                {
                    context.MetricDefinition_DimensionKey.Add((String)hashKey, (String)(this.MetricDefinition_DimensionKey[hashKey]));
                }
            }
            context.MetricDefinition_EventPattern = this.MetricDefinition_EventPattern;
            context.MetricDefinition_Name = this.MetricDefinition_Name;
            #if MODULAR
            if (this.MetricDefinition_Name == null && ParameterWasBound(nameof(this.MetricDefinition_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricDefinition_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricDefinition_UnitLabel = this.MetricDefinition_UnitLabel;
            context.MetricDefinition_ValueKey = this.MetricDefinition_ValueKey;
            context.MetricDefinitionId = this.MetricDefinitionId;
            #if MODULAR
            if (this.MetricDefinitionId == null && ParameterWasBound(nameof(this.MetricDefinitionId)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricDefinitionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionRequest();
            
            if (cmdletContext.AppMonitorName != null)
            {
                request.AppMonitorName = cmdletContext.AppMonitorName;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
            }
            
             // populate MetricDefinition
            var requestMetricDefinitionIsNull = true;
            request.MetricDefinition = new Amazon.CloudWatchRUM.Model.MetricDefinitionRequest();
            Dictionary<System.String, System.String> requestMetricDefinition_metricDefinition_DimensionKey = null;
            if (cmdletContext.MetricDefinition_DimensionKey != null)
            {
                requestMetricDefinition_metricDefinition_DimensionKey = cmdletContext.MetricDefinition_DimensionKey;
            }
            if (requestMetricDefinition_metricDefinition_DimensionKey != null)
            {
                request.MetricDefinition.DimensionKeys = requestMetricDefinition_metricDefinition_DimensionKey;
                requestMetricDefinitionIsNull = false;
            }
            System.String requestMetricDefinition_metricDefinition_EventPattern = null;
            if (cmdletContext.MetricDefinition_EventPattern != null)
            {
                requestMetricDefinition_metricDefinition_EventPattern = cmdletContext.MetricDefinition_EventPattern;
            }
            if (requestMetricDefinition_metricDefinition_EventPattern != null)
            {
                request.MetricDefinition.EventPattern = requestMetricDefinition_metricDefinition_EventPattern;
                requestMetricDefinitionIsNull = false;
            }
            System.String requestMetricDefinition_metricDefinition_Name = null;
            if (cmdletContext.MetricDefinition_Name != null)
            {
                requestMetricDefinition_metricDefinition_Name = cmdletContext.MetricDefinition_Name;
            }
            if (requestMetricDefinition_metricDefinition_Name != null)
            {
                request.MetricDefinition.Name = requestMetricDefinition_metricDefinition_Name;
                requestMetricDefinitionIsNull = false;
            }
            System.String requestMetricDefinition_metricDefinition_UnitLabel = null;
            if (cmdletContext.MetricDefinition_UnitLabel != null)
            {
                requestMetricDefinition_metricDefinition_UnitLabel = cmdletContext.MetricDefinition_UnitLabel;
            }
            if (requestMetricDefinition_metricDefinition_UnitLabel != null)
            {
                request.MetricDefinition.UnitLabel = requestMetricDefinition_metricDefinition_UnitLabel;
                requestMetricDefinitionIsNull = false;
            }
            System.String requestMetricDefinition_metricDefinition_ValueKey = null;
            if (cmdletContext.MetricDefinition_ValueKey != null)
            {
                requestMetricDefinition_metricDefinition_ValueKey = cmdletContext.MetricDefinition_ValueKey;
            }
            if (requestMetricDefinition_metricDefinition_ValueKey != null)
            {
                request.MetricDefinition.ValueKey = requestMetricDefinition_metricDefinition_ValueKey;
                requestMetricDefinitionIsNull = false;
            }
             // determine if request.MetricDefinition should be set to null
            if (requestMetricDefinitionIsNull)
            {
                request.MetricDefinition = null;
            }
            if (cmdletContext.MetricDefinitionId != null)
            {
                request.MetricDefinitionId = cmdletContext.MetricDefinitionId;
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
        
        private Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse CallAWSServiceOperation(IAmazonCloudWatchRUM client, Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch RUM", "UpdateRumMetricDefinition");
            try
            {
                #if DESKTOP
                return client.UpdateRumMetricDefinition(request);
                #elif CORECLR
                return client.UpdateRumMetricDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String AppMonitorName { get; set; }
            public Amazon.CloudWatchRUM.MetricDestination Destination { get; set; }
            public System.String DestinationArn { get; set; }
            public Dictionary<System.String, System.String> MetricDefinition_DimensionKey { get; set; }
            public System.String MetricDefinition_EventPattern { get; set; }
            public System.String MetricDefinition_Name { get; set; }
            public System.String MetricDefinition_UnitLabel { get; set; }
            public System.String MetricDefinition_ValueKey { get; set; }
            public System.String MetricDefinitionId { get; set; }
            public System.Func<Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse, UpdateCWRUMRumMetricDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
