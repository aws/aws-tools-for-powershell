/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// You can use the <code>GetMetricWidgetImage</code> API to retrieve a snapshot graph
    /// of one or more Amazon CloudWatch metrics as a bitmap image. You can then embed this
    /// image into your services and products, such as wiki pages, reports, and documents.
    /// You could also retrieve images regularly, such as every minute, and create your own
    /// custom live dashboard.
    /// 
    ///  
    /// <para>
    /// The graph you retrieve can include all CloudWatch metric graph features, including
    /// metric math and horizontal and vertical annotations.
    /// </para><para>
    /// There is a limit of 20 transactions per second for this API. Each <code>GetMetricWidgetImage</code>
    /// action has the following limits:
    /// </para><ul><li><para>
    /// As many as 100 metrics in the graph.
    /// </para></li><li><para>
    /// Up to 100 KB uncompressed payload.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "CWMetricWidgetImage")]
    [OutputType("System.IO.MemoryStream")]
    [AWSCmdlet("Calls the Amazon CloudWatch GetMetricWidgetImage API operation.", Operation = new[] {"GetMetricWidgetImage"})]
    [AWSCmdletOutput("System.IO.MemoryStream",
        "This cmdlet returns a MemoryStream object.",
        "The service call response (type Amazon.CloudWatch.Model.GetMetricWidgetImageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWMetricWidgetImageCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter MetricWidget
        /// <summary>
        /// <para>
        /// <para>A JSON string that defines the bitmap graph to be retrieved. The string includes the
        /// metrics to include in the graph, statistics, annotations, title, axis limits, and
        /// so on. You can include only one <code>MetricWidget</code> parameter in each <code>GetMetricWidgetImage</code>
        /// call.</para><para>For more information about the syntax of <code>MetricWidget</code> see <a>CloudWatch-Metric-Widget-Structure</a>.</para><para>If any metric on the graph could not load all the requested data points, an orange
        /// triangle with an exclamation point appears next to the graph legend.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MetricWidget { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para>The format of the resulting image. Only PNG images are supported.</para><para>The default is <code>png</code>. If you specify <code>png</code>, the API returns
        /// an HTTP response with the content-type set to <code>text/xml</code>. The image data
        /// is in a <code>MetricWidgetImage</code> field. For example:</para><para><code> &lt;GetMetricWidgetImageResponse xmlns=&lt;URLstring&gt;&gt;</code></para><para><code> &lt;GetMetricWidgetImageResult&gt;</code></para><para><code> &lt;MetricWidgetImage&gt;</code></para><para><code> iVBORw0KGgoAAAANSUhEUgAAAlgAAAGQEAYAAAAip...</code></para><para><code> &lt;/MetricWidgetImage&gt;</code></para><para><code> &lt;/GetMetricWidgetImageResult&gt;</code></para><para><code> &lt;ResponseMetadata&gt;</code></para><para><code> &lt;RequestId&gt;6f0d4192-4d42-11e8-82c1-f539a07e0e3b&lt;/RequestId&gt;</code></para><para><code> &lt;/ResponseMetadata&gt;</code></para><para><code>&lt;/GetMetricWidgetImageResponse&gt;</code></para><para>The <code>image/png</code> setting is intended only for custom HTTP requests. For
        /// most use cases, and all actions using an AWS SDK, you should use <code>png</code>.
        /// If you specify <code>image/png</code>, the HTTP response has a content-type set to
        /// <code>image/png</code>, and the body of the response is a PNG image. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputFormat { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.MetricWidget = this.MetricWidget;
            context.OutputFormat = this.OutputFormat;
            
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
            var request = new Amazon.CloudWatch.Model.GetMetricWidgetImageRequest();
            
            if (cmdletContext.MetricWidget != null)
            {
                request.MetricWidget = cmdletContext.MetricWidget;
            }
            if (cmdletContext.OutputFormat != null)
            {
                request.OutputFormat = cmdletContext.OutputFormat;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.MetricWidgetImage;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CloudWatch.Model.GetMetricWidgetImageResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.GetMetricWidgetImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "GetMetricWidgetImage");
            try
            {
                #if DESKTOP
                return client.GetMetricWidgetImage(request);
                #elif CORECLR
                return client.GetMetricWidgetImageAsync(request).GetAwaiter().GetResult();
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
            public System.String MetricWidget { get; set; }
            public System.String OutputFormat { get; set; }
        }
        
    }
}
