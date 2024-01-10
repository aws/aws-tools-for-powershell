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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// You can use the <c>GetMetricWidgetImage</c> API to retrieve a snapshot graph of one
    /// or more Amazon CloudWatch metrics as a bitmap image. You can then embed this image
    /// into your services and products, such as wiki pages, reports, and documents. You could
    /// also retrieve images regularly, such as every minute, and create your own custom live
    /// dashboard.
    /// 
    ///  
    /// <para>
    /// The graph you retrieve can include all CloudWatch metric graph features, including
    /// metric math and horizontal and vertical annotations.
    /// </para><para>
    /// There is a limit of 20 transactions per second for this API. Each <c>GetMetricWidgetImage</c>
    /// action has the following limits:
    /// </para><ul><li><para>
    /// As many as 100 metrics in the graph.
    /// </para></li><li><para>
    /// Up to 100 KB uncompressed payload.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "CWMetricWidgetImage")]
    [OutputType("System.IO.MemoryStream")]
    [AWSCmdlet("Calls the Amazon CloudWatch GetMetricWidgetImage API operation.", Operation = new[] {"GetMetricWidgetImage"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.GetMetricWidgetImageResponse))]
    [AWSCmdletOutput("System.IO.MemoryStream or Amazon.CloudWatch.Model.GetMetricWidgetImageResponse",
        "This cmdlet returns a System.IO.MemoryStream object.",
        "The service call response (type Amazon.CloudWatch.Model.GetMetricWidgetImageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWMetricWidgetImageCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MetricWidget
        /// <summary>
        /// <para>
        /// <para>A JSON string that defines the bitmap graph to be retrieved. The string includes the
        /// metrics to include in the graph, statistics, annotations, title, axis limits, and
        /// so on. You can include only one <c>MetricWidget</c> parameter in each <c>GetMetricWidgetImage</c>
        /// call.</para><para>For more information about the syntax of <c>MetricWidget</c> see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/CloudWatch-Metric-Widget-Structure.html">GetMetricWidgetImage:
        /// Metric Widget Structure and Syntax</a>.</para><para>If any metric on the graph could not load all the requested data points, an orange
        /// triangle with an exclamation point appears next to the graph legend.</para>
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
        public System.String MetricWidget { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para>The format of the resulting image. Only PNG images are supported.</para><para>The default is <c>png</c>. If you specify <c>png</c>, the API returns an HTTP response
        /// with the content-type set to <c>text/xml</c>. The image data is in a <c>MetricWidgetImage</c>
        /// field. For example:</para><para><c> &lt;GetMetricWidgetImageResponse xmlns=&lt;URLstring&gt;&gt;</c></para><para><c> &lt;GetMetricWidgetImageResult&gt;</c></para><para><c> &lt;MetricWidgetImage&gt;</c></para><para><c> iVBORw0KGgoAAAANSUhEUgAAAlgAAAGQEAYAAAAip...</c></para><para><c> &lt;/MetricWidgetImage&gt;</c></para><para><c> &lt;/GetMetricWidgetImageResult&gt;</c></para><para><c> &lt;ResponseMetadata&gt;</c></para><para><c> &lt;RequestId&gt;6f0d4192-4d42-11e8-82c1-f539a07e0e3b&lt;/RequestId&gt;</c></para><para><c> &lt;/ResponseMetadata&gt;</c></para><para><c>&lt;/GetMetricWidgetImageResponse&gt;</c></para><para>The <c>image/png</c> setting is intended only for custom HTTP requests. For most use
        /// cases, and all actions using an Amazon Web Services SDK, you should use <c>png</c>.
        /// If you specify <c>image/png</c>, the HTTP response has a content-type set to <c>image/png</c>,
        /// and the body of the response is a PNG image. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputFormat { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricWidgetImage'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.GetMetricWidgetImageResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.GetMetricWidgetImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricWidgetImage";
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.GetMetricWidgetImageResponse, GetCWMetricWidgetImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MetricWidget = this.MetricWidget;
            #if MODULAR
            if (this.MetricWidget == null && ParameterWasBound(nameof(this.MetricWidget)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricWidget which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            public System.Func<Amazon.CloudWatch.Model.GetMetricWidgetImageResponse, GetCWMetricWidgetImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricWidgetImage;
        }
        
    }
}
