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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Sets a metrics configuration (specified by the metrics configuration ID) for the bucket.
    /// You can have up to 1,000 metrics configurations per bucket. If you're updating an
    /// existing metrics configuration, note that this is a full replacement of the existing
    /// metrics configuration. If you don't include the elements you want to keep, they are
    /// erased.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have permissions to perform the <code>s3:PutMetricsConfiguration</code>
    /// action. The bucket owner has this permission by default. The bucket owner can grant
    /// this permission to others. For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-with-s3-actions.html#using-with-s3-actions-related-to-bucket-subresources">Permissions
    /// Related to Bucket Subresource Operations</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/s3-access-control.html">Managing
    /// Access Permissions to Your Amazon S3 Resources</a>.
    /// </para><para>
    /// For information about CloudWatch request metrics for Amazon S3, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/cloudwatch-monitoring.html">Monitoring
    /// Metrics with Amazon CloudWatch</a>.
    /// </para><para>
    /// The following operations are related to <code>PutBucketMetricsConfiguration</code>:
    /// </para><ul><li><para><a>DeleteBucketMetricsConfiguration</a></para></li><li><para><a>PutBucketMetricsConfiguration</a></para></li><li><para><a>ListBucketMetricsConfigurations</a></para></li></ul><para><code>GetBucketLifecycle</code> has the following special error:
    /// </para><ul><li><para>
    /// Error code: <code>TooManyConfigurations</code></para><ul><li><para>
    /// Description: You are attempting to create a new configuration but have already reached
    /// the 1,000-configuration limit.
    /// </para></li><li><para>
    /// HTTP Status Code: HTTP 400 Bad Request
    /// </para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3BucketMetricsConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketMetricsConfiguration API operation.", Operation = new[] {"PutBucketMetricsConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketMetricsConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketMetricsConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketMetricsConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3BucketMetricsConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket for which the metrics configuration is set.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter MetricsFilter_MetricsFilterPredicate
        /// <summary>
        /// <para>
        /// Filter Predicate setup for specific filter types.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricsConfiguration_MetricsFilter_MetricsFilterPredicate")]
        public Amazon.S3.Model.MetricsFilterPredicate MetricsFilter_MetricsFilterPredicate { get; set; }
        #endregion
        
        #region Parameter MetricsId
        /// <summary>
        /// <para>
        /// The ID used to identify the metrics configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricsId { get; set; }
        #endregion
        
        #region Parameter MetricsConfiguration_MetricsId
        /// <summary>
        /// <para>
        /// The ID used to identify the metrics configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricsConfiguration_MetricsId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketMetricsConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketMetricsConfiguration (PutBucketMetricsConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketMetricsConfigurationResponse, WriteS3BucketMetricsConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.MetricsId = this.MetricsId;
            context.MetricsConfiguration_MetricsId = this.MetricsConfiguration_MetricsId;
            context.MetricsFilter_MetricsFilterPredicate = this.MetricsFilter_MetricsFilterPredicate;
            
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
            var request = new Amazon.S3.Model.PutBucketMetricsConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.MetricsId != null)
            {
                request.MetricsId = cmdletContext.MetricsId;
            }
            
             // populate MetricsConfiguration
            var requestMetricsConfigurationIsNull = true;
            request.MetricsConfiguration = new Amazon.S3.Model.MetricsConfiguration();
            System.String requestMetricsConfiguration_metricsConfiguration_MetricsId = null;
            if (cmdletContext.MetricsConfiguration_MetricsId != null)
            {
                requestMetricsConfiguration_metricsConfiguration_MetricsId = cmdletContext.MetricsConfiguration_MetricsId;
            }
            if (requestMetricsConfiguration_metricsConfiguration_MetricsId != null)
            {
                request.MetricsConfiguration.MetricsId = requestMetricsConfiguration_metricsConfiguration_MetricsId;
                requestMetricsConfigurationIsNull = false;
            }
            Amazon.S3.Model.MetricsFilter requestMetricsConfiguration_metricsConfiguration_MetricsFilter = null;
            
             // populate MetricsFilter
            var requestMetricsConfiguration_metricsConfiguration_MetricsFilterIsNull = true;
            requestMetricsConfiguration_metricsConfiguration_MetricsFilter = new Amazon.S3.Model.MetricsFilter();
            Amazon.S3.Model.MetricsFilterPredicate requestMetricsConfiguration_metricsConfiguration_MetricsFilter_metricsFilter_MetricsFilterPredicate = null;
            if (cmdletContext.MetricsFilter_MetricsFilterPredicate != null)
            {
                requestMetricsConfiguration_metricsConfiguration_MetricsFilter_metricsFilter_MetricsFilterPredicate = cmdletContext.MetricsFilter_MetricsFilterPredicate;
            }
            if (requestMetricsConfiguration_metricsConfiguration_MetricsFilter_metricsFilter_MetricsFilterPredicate != null)
            {
                requestMetricsConfiguration_metricsConfiguration_MetricsFilter.MetricsFilterPredicate = requestMetricsConfiguration_metricsConfiguration_MetricsFilter_metricsFilter_MetricsFilterPredicate;
                requestMetricsConfiguration_metricsConfiguration_MetricsFilterIsNull = false;
            }
             // determine if requestMetricsConfiguration_metricsConfiguration_MetricsFilter should be set to null
            if (requestMetricsConfiguration_metricsConfiguration_MetricsFilterIsNull)
            {
                requestMetricsConfiguration_metricsConfiguration_MetricsFilter = null;
            }
            if (requestMetricsConfiguration_metricsConfiguration_MetricsFilter != null)
            {
                request.MetricsConfiguration.MetricsFilter = requestMetricsConfiguration_metricsConfiguration_MetricsFilter;
                requestMetricsConfigurationIsNull = false;
            }
             // determine if request.MetricsConfiguration should be set to null
            if (requestMetricsConfigurationIsNull)
            {
                request.MetricsConfiguration = null;
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
        
        private Amazon.S3.Model.PutBucketMetricsConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketMetricsConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketMetricsConfiguration");
            try
            {
                #if DESKTOP
                return client.PutBucketMetricsConfiguration(request);
                #elif CORECLR
                return client.PutBucketMetricsConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public System.String MetricsId { get; set; }
            public System.String MetricsConfiguration_MetricsId { get; set; }
            public Amazon.S3.Model.MetricsFilterPredicate MetricsFilter_MetricsFilterPredicate { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketMetricsConfigurationResponse, WriteS3BucketMetricsConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
