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
    /// Adds target(s) to a rule. Targets are the resources that can be invoked when a rule
    /// is triggered. For example, AWS Lambda functions, Amazon Kinesis streams, and built-in
    /// targets. Updates the target(s) if they are already associated with the role. In other
    /// words, if there is already a target with the given target ID, then the target associated
    /// with that ID is updated.
    /// 
    ///  
    /// <para>
    /// In order to be able to make API calls against the resources you own, Amazon CloudWatch
    /// Events needs the appropriate permissions. For AWS Lambda and Amazon SNS resources,
    /// CloudWatch Events relies on resource-based policies. For Amazon Kinesis streams, CloudWatch
    /// Events relies on IAM roles. For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/EventsTargetPermissions.html">Permissions
    /// for Sending Events to Targets</a> in the <b><i>Amazon CloudWatch Developer Guide</i></b>.
    /// </para><para><b>Input</b> and <b>InputPath</b> are mutually-exclusive and optional parameters of
    /// a target. When a rule is triggered due to a matched event, if for a target:
    /// </para><ul><li>Neither <b>Input</b> nor <b>InputPath</b> is specified, then the entire
    /// event is passed to the target in JSON form.</li><li><b>InputPath</b> is specified
    /// in the form of JSONPath (e.g. <b>$.detail</b>), then only the part of the event specified
    /// in the path is passed to the target (e.g. only the detail part of the event is passed).
    /// </li><li><b>Input</b> is specified in the form of a valid JSON, then the matched
    /// event is overridden with this constant.</li></ul><para><b>Note:</b> When you add targets to a rule, when the associated rule triggers, new
    /// or updated targets might not be immediately invoked. Please allow a short period of
    /// time for changes to take effect. 
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
        /// <para>The name of the rule you want to add targets to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Rule { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>List of targets you want to update or add to the rule.</para>
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
        
        private static Amazon.CloudWatchEvents.Model.PutTargetsResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.PutTargetsRequest request)
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
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Rule { get; set; }
            public List<Amazon.CloudWatchEvents.Model.Target> Targets { get; set; }
        }
        
    }
}
