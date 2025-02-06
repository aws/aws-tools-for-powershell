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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates one or more flow logs to capture information about IP traffic for a specific
    /// network interface, subnet, or VPC. 
    /// 
    ///  
    /// <para>
    /// Flow log data for a monitored network interface is recorded as flow log records, which
    /// are log events consisting of fields that describe the traffic flow. For more information,
    /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/flow-log-records.html">Flow
    /// log records</a> in the <i>Amazon VPC User Guide</i>.
    /// </para><para>
    /// When publishing to CloudWatch Logs, flow log records are published to a log group,
    /// and each network interface has a unique log stream in the log group. When publishing
    /// to Amazon S3, flow log records for all of the monitored network interfaces are published
    /// to a single log file object that is stored in the specified bucket.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/flow-logs.html">VPC
    /// Flow Logs</a> in the <i>Amazon VPC User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2FlowLog", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateFlowLogsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateFlowLogs API operation.", Operation = new[] {"CreateFlowLogs"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateFlowLogsResponse), LegacyAlias="New-EC2FlowLogs")]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateFlowLogsResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateFlowLogsResponse object containing multiple properties."
    )]
    public partial class NewEC2FlowLogCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeliverCrossAccountRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that allows Amazon EC2 to publish flow logs across accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliverCrossAccountRole { get; set; }
        #endregion
        
        #region Parameter DeliverLogsPermissionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that allows Amazon EC2 to publish flow logs to the log destination.</para><para>This parameter is required if the destination type is <c>cloud-watch-logs</c>, or
        /// if the destination type is <c>kinesis-data-firehose</c> and the delivery stream and
        /// the resources to monitor are in different accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliverLogsPermissionArn { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_FileFormat
        /// <summary>
        /// <para>
        /// <para>The format for the flow log. The default is <c>plain-text</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DestinationFileFormat")]
        public Amazon.EC2.DestinationFileFormat DestinationOptions_FileFormat { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_HiveCompatiblePartition
        /// <summary>
        /// <para>
        /// <para>Indicates whether to use Hive-compatible prefixes for flow logs stored in Amazon S3.
        /// The default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationOptions_HiveCompatiblePartitions")]
        public System.Boolean? DestinationOptions_HiveCompatiblePartition { get; set; }
        #endregion
        
        #region Parameter LogDestination
        /// <summary>
        /// <para>
        /// <para>The destination for the flow log data. The meaning of this parameter depends on the
        /// destination type.</para><ul><li><para>If the destination type is <c>cloud-watch-logs</c>, specify the ARN of a CloudWatch
        /// Logs log group. For example:</para><para>arn:aws:logs:<i>region</i>:<i>account_id</i>:log-group:<i>my_group</i></para><para>Alternatively, use the <c>LogGroupName</c> parameter.</para></li><li><para>If the destination type is <c>s3</c>, specify the ARN of an S3 bucket. For example:</para><para>arn:aws:s3:::<i>my_bucket</i>/<i>my_subfolder</i>/</para><para>The subfolder is optional. Note that you can't use <c>AWSLogs</c> as a subfolder name.</para></li><li><para>If the destination type is <c>kinesis-data-firehose</c>, specify the ARN of a Kinesis
        /// Data Firehose delivery stream. For example:</para><para>arn:aws:firehose:<i>region</i>:<i>account_id</i>:deliverystream:<i>my_stream</i></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogDestination { get; set; }
        #endregion
        
        #region Parameter LogDestinationType
        /// <summary>
        /// <para>
        /// <para>The type of destination for the flow log data.</para><para>Default: <c>cloud-watch-logs</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.LogDestinationType")]
        public Amazon.EC2.LogDestinationType LogDestinationType { get; set; }
        #endregion
        
        #region Parameter LogFormat
        /// <summary>
        /// <para>
        /// <para>The fields to include in the flow log record. List the fields in the order in which
        /// they should appear. If you omit this parameter, the flow log is created using the
        /// default format. If you specify this parameter, you must include at least one field.
        /// For more information about the available fields, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/flow-log-records.html">Flow
        /// log records</a> in the <i>Amazon VPC User Guide</i> or <a href="https://docs.aws.amazon.com/vpc/latest/tgw/tgw-flow-logs.html#flow-log-records">Transit
        /// Gateway Flow Log records</a> in the <i>Amazon Web Services Transit Gateway Guide</i>.</para><para>Specify the fields using the <c>${field-id}</c> format, separated by spaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogFormat { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of a new or existing CloudWatch Logs log group where Amazon EC2 publishes
        /// your flow logs.</para><para>This parameter is valid only if the destination type is <c>cloud-watch-logs</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter MaxAggregationInterval
        /// <summary>
        /// <para>
        /// <para>The maximum interval of time during which a flow of packets is captured and aggregated
        /// into a flow log record. The possible values are 60 seconds (1 minute) or 600 seconds
        /// (10 minutes). This parameter must be 60 seconds for transit gateway resource types.</para><para>When a network interface is attached to a <a href="https://docs.aws.amazon.com/ec2/latest/instancetypes/ec2-nitro-instances.html">Nitro-based
        /// instance</a>, the aggregation interval is always 60 seconds or less, regardless of
        /// the value that you specify.</para><para>Default: 600</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxAggregationInterval { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_PerHourPartition
        /// <summary>
        /// <para>
        /// <para>Indicates whether to partition the flow log per hour. This reduces the cost and response
        /// time for queries. The default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DestinationOptions_PerHourPartition { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the resources to monitor. For example, if the resource type is <c>VPC</c>,
        /// specify the IDs of the VPCs.</para><para>Constraints: Maximum of 25 for transit gateway resource types. Maximum of 1000 for
        /// the other resource types.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ResourceIds")]
        public System.String[] ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of resource to monitor.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.FlowLogsResourceType")]
        public Amazon.EC2.FlowLogsResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the flow logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TrafficType
        /// <summary>
        /// <para>
        /// <para>The type of traffic to monitor (accepted traffic, rejected traffic, or all traffic).
        /// This parameter is not supported for transit gateway resource types. It is required
        /// for the other resource types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TrafficType")]
        public Amazon.EC2.TrafficType TrafficType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateFlowLogsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateFlowLogsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2FlowLog (CreateFlowLogs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateFlowLogsResponse, NewEC2FlowLogCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DeliverCrossAccountRole = this.DeliverCrossAccountRole;
            context.DeliverLogsPermissionArn = this.DeliverLogsPermissionArn;
            context.DestinationOptions_FileFormat = this.DestinationOptions_FileFormat;
            context.DestinationOptions_HiveCompatiblePartition = this.DestinationOptions_HiveCompatiblePartition;
            context.DestinationOptions_PerHourPartition = this.DestinationOptions_PerHourPartition;
            context.LogDestination = this.LogDestination;
            context.LogDestinationType = this.LogDestinationType;
            context.LogFormat = this.LogFormat;
            context.LogGroupName = this.LogGroupName;
            context.MaxAggregationInterval = this.MaxAggregationInterval;
            if (this.ResourceId != null)
            {
                context.ResourceId = new List<System.String>(this.ResourceId);
            }
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TrafficType = this.TrafficType;
            
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
            var request = new Amazon.EC2.Model.CreateFlowLogsRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeliverCrossAccountRole != null)
            {
                request.DeliverCrossAccountRole = cmdletContext.DeliverCrossAccountRole;
            }
            if (cmdletContext.DeliverLogsPermissionArn != null)
            {
                request.DeliverLogsPermissionArn = cmdletContext.DeliverLogsPermissionArn;
            }
            
             // populate DestinationOptions
            var requestDestinationOptionsIsNull = true;
            request.DestinationOptions = new Amazon.EC2.Model.DestinationOptionsRequest();
            Amazon.EC2.DestinationFileFormat requestDestinationOptions_destinationOptions_FileFormat = null;
            if (cmdletContext.DestinationOptions_FileFormat != null)
            {
                requestDestinationOptions_destinationOptions_FileFormat = cmdletContext.DestinationOptions_FileFormat;
            }
            if (requestDestinationOptions_destinationOptions_FileFormat != null)
            {
                request.DestinationOptions.FileFormat = requestDestinationOptions_destinationOptions_FileFormat;
                requestDestinationOptionsIsNull = false;
            }
            System.Boolean? requestDestinationOptions_destinationOptions_HiveCompatiblePartition = null;
            if (cmdletContext.DestinationOptions_HiveCompatiblePartition != null)
            {
                requestDestinationOptions_destinationOptions_HiveCompatiblePartition = cmdletContext.DestinationOptions_HiveCompatiblePartition.Value;
            }
            if (requestDestinationOptions_destinationOptions_HiveCompatiblePartition != null)
            {
                request.DestinationOptions.HiveCompatiblePartitions = requestDestinationOptions_destinationOptions_HiveCompatiblePartition.Value;
                requestDestinationOptionsIsNull = false;
            }
            System.Boolean? requestDestinationOptions_destinationOptions_PerHourPartition = null;
            if (cmdletContext.DestinationOptions_PerHourPartition != null)
            {
                requestDestinationOptions_destinationOptions_PerHourPartition = cmdletContext.DestinationOptions_PerHourPartition.Value;
            }
            if (requestDestinationOptions_destinationOptions_PerHourPartition != null)
            {
                request.DestinationOptions.PerHourPartition = requestDestinationOptions_destinationOptions_PerHourPartition.Value;
                requestDestinationOptionsIsNull = false;
            }
             // determine if request.DestinationOptions should be set to null
            if (requestDestinationOptionsIsNull)
            {
                request.DestinationOptions = null;
            }
            if (cmdletContext.LogDestination != null)
            {
                request.LogDestination = cmdletContext.LogDestination;
            }
            if (cmdletContext.LogDestinationType != null)
            {
                request.LogDestinationType = cmdletContext.LogDestinationType;
            }
            if (cmdletContext.LogFormat != null)
            {
                request.LogFormat = cmdletContext.LogFormat;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.MaxAggregationInterval != null)
            {
                request.MaxAggregationInterval = cmdletContext.MaxAggregationInterval.Value;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceIds = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TrafficType != null)
            {
                request.TrafficType = cmdletContext.TrafficType;
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
        
        private Amazon.EC2.Model.CreateFlowLogsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateFlowLogsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateFlowLogs");
            try
            {
                #if DESKTOP
                return client.CreateFlowLogs(request);
                #elif CORECLR
                return client.CreateFlowLogsAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DeliverCrossAccountRole { get; set; }
            public System.String DeliverLogsPermissionArn { get; set; }
            public Amazon.EC2.DestinationFileFormat DestinationOptions_FileFormat { get; set; }
            public System.Boolean? DestinationOptions_HiveCompatiblePartition { get; set; }
            public System.Boolean? DestinationOptions_PerHourPartition { get; set; }
            public System.String LogDestination { get; set; }
            public Amazon.EC2.LogDestinationType LogDestinationType { get; set; }
            public System.String LogFormat { get; set; }
            public System.String LogGroupName { get; set; }
            public System.Int32? MaxAggregationInterval { get; set; }
            public List<System.String> ResourceId { get; set; }
            public Amazon.EC2.FlowLogsResourceType ResourceType { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.TrafficType TrafficType { get; set; }
            public System.Func<Amazon.EC2.Model.CreateFlowLogsResponse, NewEC2FlowLogCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
