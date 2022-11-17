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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Updates a metric attribution.
    /// </summary>
    [Cmdlet("Update", "PERSMetricAttribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize UpdateMetricAttribution API operation.", Operation = new[] {"UpdateMetricAttribution"}, SelectReturnType = typeof(Amazon.Personalize.Model.UpdateMetricAttributionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.UpdateMetricAttributionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.UpdateMetricAttributionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePERSMetricAttributionCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        #region Parameter AddMetric
        /// <summary>
        /// <para>
        /// <para>Add new metric attributes to the metric attribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddMetrics")]
        public Amazon.Personalize.Model.MetricAttribute[] AddMetric { get; set; }
        #endregion
        
        #region Parameter S3DataDestination_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Key Management Service (KMS) key that Amazon
        /// Personalize uses to encrypt or decrypt the input and output files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricsOutputConfig_S3DataDestination_KmsKeyArn")]
        public System.String S3DataDestination_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter MetricAttributionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the metric attribution to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String MetricAttributionArn { get; set; }
        #endregion
        
        #region Parameter S3DataDestination_Path
        /// <summary>
        /// <para>
        /// <para>The file path of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricsOutputConfig_S3DataDestination_Path")]
        public System.String S3DataDestination_Path { get; set; }
        #endregion
        
        #region Parameter RemoveMetric
        /// <summary>
        /// <para>
        /// <para>Remove metric attributes from the metric attribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveMetrics")]
        public System.String[] RemoveMetric { get; set; }
        #endregion
        
        #region Parameter MetricsOutputConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role that has permissions to add
        /// data to your output Amazon S3 bucket and add metrics to Amazon CloudWatch. For more
        /// information, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/measuring-recommendation-impact.html">Measuring
        /// impact of recommendations</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricsOutputConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricAttributionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.UpdateMetricAttributionResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.UpdateMetricAttributionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricAttributionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MetricAttributionArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MetricAttributionArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MetricAttributionArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MetricAttributionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PERSMetricAttribution (UpdateMetricAttribution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.UpdateMetricAttributionResponse, UpdatePERSMetricAttributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MetricAttributionArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddMetric != null)
            {
                context.AddMetric = new List<Amazon.Personalize.Model.MetricAttribute>(this.AddMetric);
            }
            context.MetricAttributionArn = this.MetricAttributionArn;
            context.MetricsOutputConfig_RoleArn = this.MetricsOutputConfig_RoleArn;
            context.S3DataDestination_KmsKeyArn = this.S3DataDestination_KmsKeyArn;
            context.S3DataDestination_Path = this.S3DataDestination_Path;
            if (this.RemoveMetric != null)
            {
                context.RemoveMetric = new List<System.String>(this.RemoveMetric);
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
            var request = new Amazon.Personalize.Model.UpdateMetricAttributionRequest();
            
            if (cmdletContext.AddMetric != null)
            {
                request.AddMetrics = cmdletContext.AddMetric;
            }
            if (cmdletContext.MetricAttributionArn != null)
            {
                request.MetricAttributionArn = cmdletContext.MetricAttributionArn;
            }
            
             // populate MetricsOutputConfig
            var requestMetricsOutputConfigIsNull = true;
            request.MetricsOutputConfig = new Amazon.Personalize.Model.MetricAttributionOutput();
            System.String requestMetricsOutputConfig_metricsOutputConfig_RoleArn = null;
            if (cmdletContext.MetricsOutputConfig_RoleArn != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_RoleArn = cmdletContext.MetricsOutputConfig_RoleArn;
            }
            if (requestMetricsOutputConfig_metricsOutputConfig_RoleArn != null)
            {
                request.MetricsOutputConfig.RoleArn = requestMetricsOutputConfig_metricsOutputConfig_RoleArn;
                requestMetricsOutputConfigIsNull = false;
            }
            Amazon.Personalize.Model.S3DataConfig requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination = null;
            
             // populate S3DataDestination
            var requestMetricsOutputConfig_metricsOutputConfig_S3DataDestinationIsNull = true;
            requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination = new Amazon.Personalize.Model.S3DataConfig();
            System.String requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_KmsKeyArn = null;
            if (cmdletContext.S3DataDestination_KmsKeyArn != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_KmsKeyArn = cmdletContext.S3DataDestination_KmsKeyArn;
            }
            if (requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_KmsKeyArn != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination.KmsKeyArn = requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_KmsKeyArn;
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestinationIsNull = false;
            }
            System.String requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_Path = null;
            if (cmdletContext.S3DataDestination_Path != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_Path = cmdletContext.S3DataDestination_Path;
            }
            if (requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_Path != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination.Path = requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_Path;
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestinationIsNull = false;
            }
             // determine if requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination should be set to null
            if (requestMetricsOutputConfig_metricsOutputConfig_S3DataDestinationIsNull)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination = null;
            }
            if (requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination != null)
            {
                request.MetricsOutputConfig.S3DataDestination = requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination;
                requestMetricsOutputConfigIsNull = false;
            }
             // determine if request.MetricsOutputConfig should be set to null
            if (requestMetricsOutputConfigIsNull)
            {
                request.MetricsOutputConfig = null;
            }
            if (cmdletContext.RemoveMetric != null)
            {
                request.RemoveMetrics = cmdletContext.RemoveMetric;
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
        
        private Amazon.Personalize.Model.UpdateMetricAttributionResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.UpdateMetricAttributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "UpdateMetricAttribution");
            try
            {
                #if DESKTOP
                return client.UpdateMetricAttribution(request);
                #elif CORECLR
                return client.UpdateMetricAttributionAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Personalize.Model.MetricAttribute> AddMetric { get; set; }
            public System.String MetricAttributionArn { get; set; }
            public System.String MetricsOutputConfig_RoleArn { get; set; }
            public System.String S3DataDestination_KmsKeyArn { get; set; }
            public System.String S3DataDestination_Path { get; set; }
            public List<System.String> RemoveMetric { get; set; }
            public System.Func<Amazon.Personalize.Model.UpdateMetricAttributionResponse, UpdatePERSMetricAttributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricAttributionArn;
        }
        
    }
}
