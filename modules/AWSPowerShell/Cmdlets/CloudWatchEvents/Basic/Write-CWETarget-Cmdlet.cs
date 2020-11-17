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
using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;

namespace Amazon.PowerShell.Cmdlets.CWE
{
    /// <summary>
    /// Adds the specified targets to the specified rule, or updates the targets if they are
    /// already associated with the rule.
    /// 
    ///  
    /// <para>
    /// Targets are the resources that are invoked when a rule is triggered.
    /// </para><para>
    /// You can configure the following as targets for Events:
    /// </para><ul><li><para>
    /// EC2 instances
    /// </para></li><li><para>
    /// SSM Run Command
    /// </para></li><li><para>
    /// SSM Automation
    /// </para></li><li><para>
    /// AWS Lambda functions
    /// </para></li><li><para>
    /// Data streams in Amazon Kinesis Data Streams
    /// </para></li><li><para>
    /// Data delivery streams in Amazon Kinesis Data Firehose
    /// </para></li><li><para>
    /// Amazon ECS tasks
    /// </para></li><li><para>
    /// AWS Step Functions state machines
    /// </para></li><li><para>
    /// AWS Batch jobs
    /// </para></li><li><para>
    /// AWS CodeBuild projects
    /// </para></li><li><para>
    /// Pipelines in AWS CodePipeline
    /// </para></li><li><para>
    /// Amazon Inspector assessment templates
    /// </para></li><li><para>
    /// Amazon SNS topics
    /// </para></li><li><para>
    /// Amazon SQS queues, including FIFO queues
    /// </para></li><li><para>
    /// The default event bus of another AWS account
    /// </para></li><li><para>
    /// Amazon API Gateway REST APIs
    /// </para></li><li><para>
    /// Redshift Clusters to invoke Data API ExecuteStatement on
    /// </para></li></ul><para>
    /// Creating rules with built-in targets is supported only in the AWS Management Console.
    /// The built-in targets are <code>EC2 CreateSnapshot API call</code>, <code>EC2 RebootInstances
    /// API call</code>, <code>EC2 StopInstances API call</code>, and <code>EC2 TerminateInstances
    /// API call</code>. 
    /// </para><para>
    /// For some target types, <code>PutTargets</code> provides target-specific parameters.
    /// If the target is a Kinesis data stream, you can optionally specify which shard the
    /// event goes to by using the <code>KinesisParameters</code> argument. To invoke a command
    /// on multiple EC2 instances with one rule, you can use the <code>RunCommandParameters</code>
    /// field.
    /// </para><para>
    /// To be able to make API calls against the resources that you own, Amazon EventBridge
    /// (CloudWatch Events) needs the appropriate permissions. For AWS Lambda and Amazon SNS
    /// resources, EventBridge relies on resource-based policies. For EC2 instances, Kinesis
    /// data streams, AWS Step Functions state machines and API Gateway REST APIs, EventBridge
    /// relies on IAM roles that you specify in the <code>RoleARN</code> argument in <code>PutTargets</code>.
    /// For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/auth-and-access-control-eventbridge.html">Authentication
    /// and Access Control</a> in the <i>Amazon EventBridge User Guide</i>.
    /// </para><para>
    /// If another AWS account is in the same region and has granted you permission (using
    /// <code>PutPermission</code>), you can send events to that account. Set that account's
    /// event bus as a target of the rules in your account. To send the matched events to
    /// the other account, specify that account's event bus as the <code>Arn</code> value
    /// when you run <code>PutTargets</code>. If your account sends events to another account,
    /// your account is charged for each sent event. Each event sent to another account is
    /// charged as a custom event. The account receiving the event is not charged. For more
    /// information, see <a href="https://aws.amazon.com/eventbridge/pricing/">Amazon EventBridge
    /// (CloudWatch Events) Pricing</a>.
    /// </para><note><para><code>Input</code>, <code>InputPath</code>, and <code>InputTransformer</code> are
    /// not available with <code>PutTarget</code> if the target is an event bus of a different
    /// AWS account.
    /// </para></note><para>
    /// If you are setting the event bus of another account as the target, and that account
    /// granted permission to your account through an organization instead of directly by
    /// the account ID, then you must specify a <code>RoleArn</code> with proper permissions
    /// in the <code>Target</code> structure. For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eventbridge-cross-account-event-delivery.html">Sending
    /// and Receiving Events Between AWS Accounts</a> in the <i>Amazon EventBridge User Guide</i>.
    /// </para><para>
    /// For more information about enabling cross-account events, see <a>PutPermission</a>.
    /// </para><para><b>Input</b>, <b>InputPath</b>, and <b>InputTransformer</b> are mutually exclusive
    /// and optional parameters of a target. When a rule is triggered due to a matched event:
    /// </para><ul><li><para>
    /// If none of the following arguments are specified for a target, then the entire event
    /// is passed to the target in JSON format (unless the target is Amazon EC2 Run Command
    /// or Amazon ECS task, in which case nothing from the event is passed to the target).
    /// </para></li><li><para>
    /// If <b>Input</b> is specified in the form of valid JSON, then the matched event is
    /// overridden with this constant.
    /// </para></li><li><para>
    /// If <b>InputPath</b> is specified in the form of JSONPath (for example, <code>$.detail</code>),
    /// then only the part of the event specified in the path is passed to the target (for
    /// example, only the detail part of the event is passed).
    /// </para></li><li><para>
    /// If <b>InputTransformer</b> is specified, then one or more specified JSONPaths are
    /// extracted from the event and used as values in a template that you specify as the
    /// input to the target.
    /// </para></li></ul><para>
    /// When you specify <code>InputPath</code> or <code>InputTransformer</code>, you must
    /// use JSON dot notation, not bracket notation.
    /// </para><para>
    /// When you add targets to a rule and the associated rule triggers soon after, new or
    /// updated targets might not be immediately invoked. Allow a short period of time for
    /// changes to take effect.
    /// </para><para>
    /// This action can partially fail if too many requests are made at the same time. If
    /// that happens, <code>FailedEntryCount</code> is non-zero in the response and each entry
    /// in <code>FailedEntries</code> provides the ID of the failed target and the error code.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWETarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvents.Model.PutTargetsResultEntry")]
    [AWSCmdlet("Calls the Amazon CloudWatch Events PutTargets API operation.", Operation = new[] {"PutTargets"}, SelectReturnType = typeof(Amazon.CloudWatchEvents.Model.PutTargetsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvents.Model.PutTargetsResultEntry or Amazon.CloudWatchEvents.Model.PutTargetsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchEvents.Model.PutTargetsResultEntry objects.",
        "The service call response (type Amazon.CloudWatchEvents.Model.PutTargetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWETargetCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        #region Parameter EventBusName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the event bus associated with the rule. If you omit this, the default
        /// event bus is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventBusName { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The name of the rule.</para>
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
        public System.String Rule { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets to update or add to the rule.</para>
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
        [Alias("Targets")]
        public Amazon.CloudWatchEvents.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedEntries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvents.Model.PutTargetsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvents.Model.PutTargetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedEntries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Rule parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Rule' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Rule' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Rule), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWETarget (PutTargets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvents.Model.PutTargetsResponse, WriteCWETargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Rule;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EventBusName = this.EventBusName;
            context.Rule = this.Rule;
            #if MODULAR
            if (this.Rule == null && ParameterWasBound(nameof(this.Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Target != null)
            {
                context.Target = new List<Amazon.CloudWatchEvents.Model.Target>(this.Target);
            }
            #if MODULAR
            if (this.Target == null && ParameterWasBound(nameof(this.Target)))
            {
                WriteWarning("You are passing $null as a value for parameter Target which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvents.Model.PutTargetsRequest();
            
            if (cmdletContext.EventBusName != null)
            {
                request.EventBusName = cmdletContext.EventBusName;
            }
            if (cmdletContext.Rule != null)
            {
                request.Rule = cmdletContext.Rule;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
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
        
        private Amazon.CloudWatchEvents.Model.PutTargetsResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.PutTargetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Events", "PutTargets");
            try
            {
                #if DESKTOP
                return client.PutTargets(request);
                #elif CORECLR
                return client.PutTargetsAsync(request).GetAwaiter().GetResult();
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
            public System.String EventBusName { get; set; }
            public System.String Rule { get; set; }
            public List<Amazon.CloudWatchEvents.Model.Target> Target { get; set; }
            public System.Func<Amazon.CloudWatchEvents.Model.PutTargetsResponse, WriteCWETargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedEntries;
        }
        
    }
}
