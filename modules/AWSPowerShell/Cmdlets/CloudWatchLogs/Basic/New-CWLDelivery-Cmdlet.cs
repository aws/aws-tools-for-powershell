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
    /// Creates a <i>delivery</i>. A delivery is a connection between a logical <i>delivery
    /// source</i> and a logical <i>delivery destination</i> that you have already created.
    /// 
    ///  
    /// <para>
    /// Only some Amazon Web Services services support being configured as a delivery source
    /// using this operation. These services are listed as <b>Supported [V2 Permissions]</b>
    /// in the table at <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/AWS-logs-and-resource-policy.html">Enabling
    /// logging from Amazon Web Services services.</a></para><para>
    /// A delivery destination can represent a log group in CloudWatch Logs, an Amazon S3
    /// bucket, or a delivery stream in Firehose.
    /// </para><para>
    /// To configure logs delivery between a supported Amazon Web Services service and a destination,
    /// you must do the following:
    /// </para><ul><li><para>
    /// Create a delivery source, which is a logical object that represents the resource that
    /// is actually sending the logs. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDeliverySource.html">PutDeliverySource</a>.
    /// </para></li><li><para>
    /// Create a <i>delivery destination</i>, which is a logical object that represents the
    /// actual delivery destination. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDeliveryDestination.html">PutDeliveryDestination</a>.
    /// </para></li><li><para>
    /// If you are delivering logs cross-account, you must use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDeliveryDestinationPolicy.html">PutDeliveryDestinationPolicy</a>
    /// in the destination account to assign an IAM policy to the destination. This policy
    /// allows delivery to that destination. 
    /// </para></li><li><para>
    /// Use <c>CreateDelivery</c> to create a <i>delivery</i> by pairing exactly one delivery
    /// source and one delivery destination. 
    /// </para></li></ul><para>
    /// You can configure a single delivery source to send logs to multiple destinations by
    /// creating multiple deliveries. You can also create multiple deliveries to configure
    /// multiple delivery sources to send logs to the same delivery destination.
    /// </para><para>
    /// To update an existing delivery configuration, use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_UpdateDeliveryConfiguration.html">UpdateDeliveryConfiguration</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWLDelivery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.Delivery")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs CreateDelivery API operation.", Operation = new[] {"CreateDelivery"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.CreateDeliveryResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.Delivery or Amazon.CloudWatchLogs.Model.CreateDeliveryResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.Delivery object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.CreateDeliveryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWLDeliveryCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeliveryDestinationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the delivery destination to use for this delivery.</para>
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
        public System.String DeliveryDestinationArn { get; set; }
        #endregion
        
        #region Parameter DeliverySourceName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery source to use for this delivery.</para>
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
        public System.String DeliverySourceName { get; set; }
        #endregion
        
        #region Parameter S3DeliveryConfiguration_EnableHiveCompatiblePath
        /// <summary>
        /// <para>
        /// <para>This parameter causes the S3 objects that contain delivered logs to use a prefix structure
        /// that allows for integration with Apache Hive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? S3DeliveryConfiguration_EnableHiveCompatiblePath { get; set; }
        #endregion
        
        #region Parameter FieldDelimiter
        /// <summary>
        /// <para>
        /// <para>The field delimiter to use between record fields when the final output format of a
        /// delivery is in <c>Plain</c>, <c>W3C</c>, or <c>Raw</c> format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldDelimiter { get; set; }
        #endregion
        
        #region Parameter RecordField
        /// <summary>
        /// <para>
        /// <para>The list of record fields to be delivered to the destination, in order. If the delivery's
        /// log source has mandatory fields, they must be included in this list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecordFields")]
        public System.String[] RecordField { get; set; }
        #endregion
        
        #region Parameter S3DeliveryConfiguration_SuffixPath
        /// <summary>
        /// <para>
        /// <para>This string allows re-configuring the S3 object prefix to contain either static or
        /// variable sections. The valid variables to use in the suffix path will vary by each
        /// log source. To find the values supported for the suffix path for each log source,
        /// use the <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_DescribeConfigurationTemplates.html">DescribeConfigurationTemplates</a>
        /// operation and check the <c>allowedSuffixPathFields</c> field in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DeliveryConfiguration_SuffixPath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of key-value pairs to associate with the resource.</para><para>For more information about tagging, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Delivery'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.CreateDeliveryResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.CreateDeliveryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Delivery";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWLDelivery (CreateDelivery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.CreateDeliveryResponse, NewCWLDeliveryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeliveryDestinationArn = this.DeliveryDestinationArn;
            #if MODULAR
            if (this.DeliveryDestinationArn == null && ParameterWasBound(nameof(this.DeliveryDestinationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryDestinationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeliverySourceName = this.DeliverySourceName;
            #if MODULAR
            if (this.DeliverySourceName == null && ParameterWasBound(nameof(this.DeliverySourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliverySourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FieldDelimiter = this.FieldDelimiter;
            if (this.RecordField != null)
            {
                context.RecordField = new List<System.String>(this.RecordField);
            }
            context.S3DeliveryConfiguration_EnableHiveCompatiblePath = this.S3DeliveryConfiguration_EnableHiveCompatiblePath;
            context.S3DeliveryConfiguration_SuffixPath = this.S3DeliveryConfiguration_SuffixPath;
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
            var request = new Amazon.CloudWatchLogs.Model.CreateDeliveryRequest();
            
            if (cmdletContext.DeliveryDestinationArn != null)
            {
                request.DeliveryDestinationArn = cmdletContext.DeliveryDestinationArn;
            }
            if (cmdletContext.DeliverySourceName != null)
            {
                request.DeliverySourceName = cmdletContext.DeliverySourceName;
            }
            if (cmdletContext.FieldDelimiter != null)
            {
                request.FieldDelimiter = cmdletContext.FieldDelimiter;
            }
            if (cmdletContext.RecordField != null)
            {
                request.RecordFields = cmdletContext.RecordField;
            }
            
             // populate S3DeliveryConfiguration
            var requestS3DeliveryConfigurationIsNull = true;
            request.S3DeliveryConfiguration = new Amazon.CloudWatchLogs.Model.S3DeliveryConfiguration();
            System.Boolean? requestS3DeliveryConfiguration_s3DeliveryConfiguration_EnableHiveCompatiblePath = null;
            if (cmdletContext.S3DeliveryConfiguration_EnableHiveCompatiblePath != null)
            {
                requestS3DeliveryConfiguration_s3DeliveryConfiguration_EnableHiveCompatiblePath = cmdletContext.S3DeliveryConfiguration_EnableHiveCompatiblePath.Value;
            }
            if (requestS3DeliveryConfiguration_s3DeliveryConfiguration_EnableHiveCompatiblePath != null)
            {
                request.S3DeliveryConfiguration.EnableHiveCompatiblePath = requestS3DeliveryConfiguration_s3DeliveryConfiguration_EnableHiveCompatiblePath.Value;
                requestS3DeliveryConfigurationIsNull = false;
            }
            System.String requestS3DeliveryConfiguration_s3DeliveryConfiguration_SuffixPath = null;
            if (cmdletContext.S3DeliveryConfiguration_SuffixPath != null)
            {
                requestS3DeliveryConfiguration_s3DeliveryConfiguration_SuffixPath = cmdletContext.S3DeliveryConfiguration_SuffixPath;
            }
            if (requestS3DeliveryConfiguration_s3DeliveryConfiguration_SuffixPath != null)
            {
                request.S3DeliveryConfiguration.SuffixPath = requestS3DeliveryConfiguration_s3DeliveryConfiguration_SuffixPath;
                requestS3DeliveryConfigurationIsNull = false;
            }
             // determine if request.S3DeliveryConfiguration should be set to null
            if (requestS3DeliveryConfigurationIsNull)
            {
                request.S3DeliveryConfiguration = null;
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
        
        private Amazon.CloudWatchLogs.Model.CreateDeliveryResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.CreateDeliveryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "CreateDelivery");
            try
            {
                #if DESKTOP
                return client.CreateDelivery(request);
                #elif CORECLR
                return client.CreateDeliveryAsync(request).GetAwaiter().GetResult();
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
            public System.String DeliveryDestinationArn { get; set; }
            public System.String DeliverySourceName { get; set; }
            public System.String FieldDelimiter { get; set; }
            public List<System.String> RecordField { get; set; }
            public System.Boolean? S3DeliveryConfiguration_EnableHiveCompatiblePath { get; set; }
            public System.String S3DeliveryConfiguration_SuffixPath { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.CreateDeliveryResponse, NewCWLDeliveryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Delivery;
        }
        
    }
}
