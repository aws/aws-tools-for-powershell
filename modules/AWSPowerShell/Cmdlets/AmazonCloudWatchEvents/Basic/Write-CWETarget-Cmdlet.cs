/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// You can configure the following as targets for CloudWatch Events:
    /// </para><ul><li><para>
    /// EC2 instances
    /// </para></li><li><para>
    /// AWS Lambda functions
    /// </para></li><li><para>
    /// Streams in Amazon Kinesis Streams
    /// </para></li><li><para>
    /// Delivery streams in Amazon Kinesis Firehose
    /// </para></li><li><para>
    /// Amazon ECS tasks
    /// </para></li><li><para>
    /// AWS Step Functions state machines
    /// </para></li><li><para>
    /// Amazon SNS topics
    /// </para></li><li><para>
    /// Amazon SQS queues
    /// </para></li></ul><para>
    /// Note that creating rules with built-in targets is supported only in the AWS Management
    /// Console.
    /// </para><para>
    /// For some target types, <code>PutTargets</code> provides target-specific parameters.
    /// If the target is an Amazon Kinesis stream, you can optionally specify which shard
    /// the event goes to by using the <code>KinesisParameters</code> argument. To invoke
    /// a command on multiple EC2 instances with one rule, you can use the <code>RunCommandParameters</code>
    /// field.
    /// </para><para>
    /// To be able to make API calls against the resources that you own, Amazon CloudWatch
    /// Events needs the appropriate permissions. For AWS Lambda and Amazon SNS resources,
    /// CloudWatch Events relies on resource-based policies. For EC2 instances, Amazon Kinesis
    /// streams, and AWS Step Functions state machines, CloudWatch Events relies on IAM roles
    /// that you specify in the <code>RoleARN</code> argument in <code>PutTargets</code>.
    /// For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/events/auth-and-access-control-cwe.html">Authentication
    /// and Access Control</a> in the <i>Amazon CloudWatch Events User Guide</i>.
    /// </para><para>
    /// If another AWS account is in the same region and has granted you permission (using
    /// <code>PutPermission</code>), you can set that account's event bus as a target of the
    /// rules in your account. To send the matched events to the other account, specify that
    /// account's event bus as the <code>Arn</code> when you run <code>PutTargets</code>.
    /// For more information about enabling cross-account events, see <a>PutPermission</a>.
    /// </para><para><b>Input</b>, <b>InputPath</b> and <b>InputTransformer</b> are mutually exclusive
    /// and optional parameters of a target. When a rule is triggered due to a matched event:
    /// </para><ul><li><para>
    /// If none of the following arguments are specified for a target, then the entire event
    /// is passed to the target in JSON form (unless the target is Amazon EC2 Run Command
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
    /// When you specify <code>Input</code>, <code>InputPath</code>, or <code>InputTransformer</code>,
    /// you must use JSON dot notation, not bracket notation.
    /// </para><para>
    /// When you add targets to a rule and the associated rule triggers soon after, new or
    /// updated targets might not be immediately invoked. Please allow a short period of time
    /// for changes to take effect.
    /// </para><para>
    /// This action can partially fail if too many requests are made at the same time. If
    /// that happens, <code>FailedEntryCount</code> is non-zero in the response and each entry
    /// in <code>FailedEntries</code> provides the ID of the failed target and the error code.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWETarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvents.Model.PutTargetsResultEntry")]
    [AWSCmdlet("Invokes the PutTargets operation against Amazon CloudWatch Events.", Operation = new[] {"PutTargets"})]
    [AWSCmdletOutput("Amazon.CloudWatchEvents.Model.PutTargetsResultEntry",
        "This cmdlet returns a collection of PutTargetsResultEntry objects.",
        "The service call response (type Amazon.CloudWatchEvents.Model.PutTargetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWETargetCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The name of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Rule { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets to update or add to the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Targets")]
        public Amazon.CloudWatchEvents.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Rule", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWETarget (PutTargets)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Rule = this.Rule;
            if (this.Target != null)
            {
                context.Targets = new List<Amazon.CloudWatchEvents.Model.Target>(this.Target);
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
            var request = new Amazon.CloudWatchEvents.Model.PutTargetsRequest();
            
            if (cmdletContext.Rule != null)
            {
                request.Rule = cmdletContext.Rule;
            }
            if (cmdletContext.Targets != null)
            {
                request.Targets = cmdletContext.Targets;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FailedEntries;
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
        
        private Amazon.CloudWatchEvents.Model.PutTargetsResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.PutTargetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Events", "PutTargets");
            try
            {
                #if DESKTOP
                return client.PutTargets(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutTargetsAsync(request);
                return task.Result;
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
            public System.String Rule { get; set; }
            public List<Amazon.CloudWatchEvents.Model.Target> Targets { get; set; }
        }
        
    }
}
