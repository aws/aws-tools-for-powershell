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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates or updates a logical <i>delivery source</i>. A delivery source represents
    /// an Amazon Web Services resource that sends logs to an logs delivery destination. The
    /// destination can be CloudWatch Logs, Amazon S3, Firehose or X-Ray for sending traces.
    /// 
    ///  
    /// <para>
    /// To configure logs delivery between a delivery destination and an Amazon Web Services
    /// service that is supported as a delivery source, you must do the following:
    /// </para><ul><li><para>
    /// Use <c>PutDeliverySource</c> to create a delivery source, which is a logical object
    /// that represents the resource that is actually sending the logs. 
    /// </para></li><li><para>
    /// Use <c>PutDeliveryDestination</c> to create a <i>delivery destination</i>, which is
    /// a logical object that represents the actual delivery destination. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDeliveryDestination.html">PutDeliveryDestination</a>.
    /// </para></li><li><para>
    /// If you are delivering logs cross-account, you must use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDeliveryDestinationPolicy.html">PutDeliveryDestinationPolicy</a>
    /// in the destination account to assign an IAM policy to the destination. This policy
    /// allows delivery to that destination. 
    /// </para></li><li><para>
    /// Use <c>CreateDelivery</c> to create a <i>delivery</i> by pairing exactly one delivery
    /// source and one delivery destination. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_CreateDelivery.html">CreateDelivery</a>.
    /// 
    /// </para></li></ul><para>
    /// You can configure a single delivery source to send logs to multiple destinations by
    /// creating multiple deliveries. You can also create multiple deliveries to configure
    /// multiple delivery sources to send logs to the same delivery destination.
    /// </para><para>
    /// Only some Amazon Web Services services support being configured as a delivery source.
    /// These services are listed as <b>Supported [V2 Permissions]</b> in the table at <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/AWS-logs-and-resource-policy.html">Enabling
    /// logging from Amazon Web Services services.</a></para><para>
    /// If you use this operation to update an existing delivery source, all the current delivery
    /// source parameters are overwritten with the new parameter values that you specify.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLDeliverySource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.DeliverySource")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutDeliverySource API operation.", Operation = new[] {"PutDeliverySource"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutDeliverySourceResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.DeliverySource or Amazon.CloudWatchLogs.Model.PutDeliverySourceResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.DeliverySource object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.PutDeliverySourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCWLDeliverySourceCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogType
        /// <summary>
        /// <para>
        /// <para>Defines the type of log that the source is sending.</para><ul><li><para>For Amazon Bedrock Agents, the valid values are <c>APPLICATION_LOGS</c> and <c>EVENT_LOGS</c>.</para></li><li><para>For Amazon Bedrock Knowledge Bases, the valid value is <c>APPLICATION_LOGS</c>.</para></li><li><para>For Amazon Bedrock AgentCore Runtime, the valid values are <c>APPLICATION_LOGS</c>,
        /// <c>USAGE_LOGS</c> and <c>TRACES</c>.</para></li><li><para>For Amazon Bedrock AgentCore Tools, the valid values are <c>APPLICATION_LOGS</c>,
        /// <c>USAGE_LOGS</c> and <c>TRACES</c>.</para></li><li><para>For Amazon Bedrock AgentCore Identity, the valid values are <c>APPLICATION_LOGS</c>
        /// and <c>TRACES</c>.</para></li><li><para>For Amazon Bedrock AgentCore Gateway, the valid values are <c>APPLICATION_LOGS</c>
        /// and <c>TRACES</c>.</para></li><li><para>For CloudFront, the valid value is <c>ACCESS_LOGS</c>.</para></li><li><para>For Amazon CodeWhisperer, the valid value is <c>EVENT_LOGS</c>.</para></li><li><para>For Elemental MediaPackage, the valid values are <c>EGRESS_ACCESS_LOGS</c> and <c>INGRESS_ACCESS_LOGS</c>.</para></li><li><para>For Elemental MediaTailor, the valid values are <c>AD_DECISION_SERVER_LOGS</c>, <c>MANIFEST_SERVICE_LOGS</c>,
        /// and <c>TRANSCODE_LOGS</c>.</para></li><li><para>For Entity Resolution, the valid value is <c>WORKFLOW_LOGS</c>.</para></li><li><para>For IAM Identity Center, the valid value is <c>ERROR_LOGS</c>.</para></li><li><para>For Network Load Balancer, the valid value is <c>NLB_ACCESS_LOGS</c>.</para></li><li><para>For PCS, the valid values are <c>PCS_SCHEDULER_LOGS</c> and <c>PCS_JOBCOMP_LOGS</c>.</para></li><li><para>For Amazon Web Services RTB Fabric, the valid values is <c>APPLICATION_LOGS</c>.</para></li><li><para>For Amazon Q, the valid values are <c>EVENT_LOGS</c> and <c>SYNC_JOB_LOGS</c>.</para></li><li><para>For Amazon SES mail manager, the valid values are <c>APPLICATION_LOGS</c> and <c>TRAFFIC_POLICY_DEBUG_LOGS</c>.</para></li><li><para>For Amazon WorkMail, the valid values are <c>ACCESS_CONTROL_LOGS</c>, <c>AUTHENTICATION_LOGS</c>,
        /// <c>WORKMAIL_AVAILABILITY_PROVIDER_LOGS</c>, <c>WORKMAIL_MAILBOX_ACCESS_LOGS</c>, and
        /// <c>WORKMAIL_PERSONAL_ACCESS_TOKEN_LOGS</c>.</para></li><li><para>For Amazon VPC Route Server, the valid value is <c>EVENT_LOGS</c>.</para></li></ul>
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
        public System.String LogType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for this delivery source. This name must be unique for all delivery sources
        /// in your account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services resource that is generating and sending logs. For
        /// example, <c>arn:aws:workmail:us-east-1:123456789012:organization/m-1234EXAMPLEabcd1234abcd1234abcd1234</c></para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of key-value pairs to associate with the resource.</para><para>For more information about tagging, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a></para><para />
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeliverySource'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutDeliverySourceResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.PutDeliverySourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeliverySource";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLDeliverySource (PutDeliverySource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutDeliverySourceResponse, WriteCWLDeliverySourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LogType = this.LogType;
            #if MODULAR
            if (this.LogType == null && ParameterWasBound(nameof(this.LogType)))
            {
                WriteWarning("You are passing $null as a value for parameter LogType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CloudWatchLogs.Model.PutDeliverySourceRequest();
            
            if (cmdletContext.LogType != null)
            {
                request.LogType = cmdletContext.LogType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.CloudWatchLogs.Model.PutDeliverySourceResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutDeliverySourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutDeliverySource");
            try
            {
                return client.PutDeliverySourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LogType { get; set; }
            public System.String Name { get; set; }
            public System.String ResourceArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutDeliverySourceResponse, WriteCWLDeliverySourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeliverySource;
        }
        
    }
}
