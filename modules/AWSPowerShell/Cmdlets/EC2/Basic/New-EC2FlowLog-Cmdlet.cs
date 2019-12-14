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
    /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/flow-logs.html#flow-log-records">Flow
    /// Log Records</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para><para>
    /// When publishing to CloudWatch Logs, flow log records are published to a log group,
    /// and each network interface has a unique log stream in the log group. When publishing
    /// to Amazon S3, flow log records for all of the monitored network interfaces are published
    /// to a single log file object that is stored in the specified bucket.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/flow-logs.html">VPC
    /// Flow Logs</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2FlowLog", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateFlowLogsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateFlowLogs API operation.", Operation = new[] {"CreateFlowLogs"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateFlowLogsResponse), LegacyAlias="New-EC2FlowLogs")]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateFlowLogsResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateFlowLogsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2FlowLogCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter DeliverLogsPermissionArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the IAM role that permits Amazon EC2 to publish flow logs to a CloudWatch
        /// Logs log group in your account.</para><para>If you specify <code>LogDestinationType</code> as <code>s3</code>, do not specify
        /// <code>DeliverLogsPermissionArn</code> or <code>LogGroupName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliverLogsPermissionArn { get; set; }
        #endregion
        
        #region Parameter LogDestination
        /// <summary>
        /// <para>
        /// <para>Specifies the destination to which the flow log data is to be published. Flow log
        /// data can be published to a CloudWatch Logs log group or an Amazon S3 bucket. The value
        /// specified for this parameter depends on the value specified for <code>LogDestinationType</code>.</para><para>If <code>LogDestinationType</code> is not specified or <code>cloud-watch-logs</code>,
        /// specify the Amazon Resource Name (ARN) of the CloudWatch Logs log group. For example,
        /// to publish to a log group called <code>my-logs</code>, specify <code>arn:aws:logs:us-east-1:123456789012:log-group:my-logs</code>.
        /// Alternatively, use <code>LogGroupName</code> instead.</para><para>If LogDestinationType is <code>s3</code>, specify the ARN of the Amazon S3 bucket.
        /// You can also specify a subfolder in the bucket. To specify a subfolder in the bucket,
        /// use the following ARN format: <code>bucket_ARN/subfolder_name/</code>. For example,
        /// to specify a subfolder named <code>my-logs</code> in a bucket named <code>my-bucket</code>,
        /// use the following ARN: <code>arn:aws:s3:::my-bucket/my-logs/</code>. You cannot use
        /// <code>AWSLogs</code> as a subfolder name. This is a reserved term.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogDestination { get; set; }
        #endregion
        
        #region Parameter LogDestinationType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of destination to which the flow log data is to be published. Flow
        /// log data can be published to CloudWatch Logs or Amazon S3. To publish flow log data
        /// to CloudWatch Logs, specify <code>cloud-watch-logs</code>. To publish flow log data
        /// to Amazon S3, specify <code>s3</code>.</para><para>If you specify <code>LogDestinationType</code> as <code>s3</code>, do not specify
        /// <code>DeliverLogsPermissionArn</code> or <code>LogGroupName</code>.</para><para>Default: <code>cloud-watch-logs</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.LogDestinationType")]
        public Amazon.EC2.LogDestinationType LogDestinationType { get; set; }
        #endregion
        
        #region Parameter LogFormat
        /// <summary>
        /// <para>
        /// <para>The fields to include in the flow log record, in the order in which they should appear.
        /// For a list of available fields, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/flow-logs.html#flow-log-records">Flow
        /// Log Records</a>. If you omit this parameter, the flow log is created using the default
        /// format. If you specify this parameter, you must specify at least one field.</para><para>Specify the fields using the <code>${field-id}</code> format, separated by spaces.
        /// For the AWS CLI, use single quotation marks (' ') to surround the parameter value.</para><para>Only applicable to flow logs that are published to an Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogFormat { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of a new or existing CloudWatch Logs log group where Amazon EC2 publishes
        /// your flow logs.</para><para>If you specify <code>LogDestinationType</code> as <code>s3</code>, do not specify
        /// <code>DeliverLogsPermissionArn</code> or <code>LogGroupName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet, network interface, or VPC for which you want to create a flow
        /// log.</para><para>Constraints: Maximum of 1000 resources</para>
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
        /// <para>The type of resource for which to create the flow log. For example, if you specified
        /// a VPC ID for the <code>ResourceId</code> property, specify <code>VPC</code> for this
        /// property.</para>
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
        
        #region Parameter TrafficType
        /// <summary>
        /// <para>
        /// <para>The type of traffic to log. You can log traffic that the resource accepts or rejects,
        /// or all traffic.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.TrafficType")]
        public Amazon.EC2.TrafficType TrafficType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a>.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LogGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LogGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LogGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2FlowLog (CreateFlowLogs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateFlowLogsResponse, NewEC2FlowLogCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LogGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DeliverLogsPermissionArn = this.DeliverLogsPermissionArn;
            context.LogDestination = this.LogDestination;
            context.LogDestinationType = this.LogDestinationType;
            context.LogFormat = this.LogFormat;
            context.LogGroupName = this.LogGroupName;
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
            context.TrafficType = this.TrafficType;
            #if MODULAR
            if (this.TrafficType == null && ParameterWasBound(nameof(this.TrafficType)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateFlowLogsRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeliverLogsPermissionArn != null)
            {
                request.DeliverLogsPermissionArn = cmdletContext.DeliverLogsPermissionArn;
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
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceIds = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
            public System.String DeliverLogsPermissionArn { get; set; }
            public System.String LogDestination { get; set; }
            public Amazon.EC2.LogDestinationType LogDestinationType { get; set; }
            public System.String LogFormat { get; set; }
            public System.String LogGroupName { get; set; }
            public List<System.String> ResourceId { get; set; }
            public Amazon.EC2.FlowLogsResourceType ResourceType { get; set; }
            public Amazon.EC2.TrafficType TrafficType { get; set; }
            public System.Func<Amazon.EC2.Model.CreateFlowLogsResponse, NewEC2FlowLogCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
