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
    /// Adds target(s) to a rule. Updates the target(s) if they are already associated with
    /// the role. In other words, if there is already a target with the given target ID, then
    /// the target associated with that ID is updated.
    /// 
    ///  
    /// <para><b>Note:</b> When you make a change with this action, when the associated rule triggers,
    /// new or updated targets might not be immediately invoked. Please allow a short period
    /// of time for changes to take effect. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWETarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvents.Model.PutTargetsResultEntry")]
    [AWSCmdlet("Invokes the PutTargets operation against Amazon CloudWatch Events.", Operation = new[] {"PutTargets"})]
    [AWSCmdletOutput("Amazon.CloudWatchEvents.Model.PutTargetsResultEntry",
        "This cmdlet returns a collection of PutTargetsResultEntry objects.",
        "The service call response (type Amazon.CloudWatchEvents.Model.PutTargetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCWETargetCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
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
            
            context.Rule = this.Rule;
            if (this.Target != null)
            {
                context.Targets = new List<Amazon.CloudWatchEvents.Model.Target>(this.Target);
            }
            
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
                var response = client.PutTargets(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Rule { get; set; }
            public List<Amazon.CloudWatchEvents.Model.Target> Targets { get; set; }
        }
        
    }
}
