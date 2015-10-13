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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates or updates a <code>Destination</code>. A destination encapsulates a physical
    /// resource (such as a Kinesis stream) and allows you to subscribe to a real-time stream
    /// of log events of a different account, ingested through <code class="code">PutLogEvents</code>
    /// requests. Currently, the only supported physical resource is a Amazon Kinesis stream
    /// belonging to the same account as the destination. 
    /// 
    ///  
    /// <para>
    ///  A destination controls what is written to its Amazon Kinesis stream through an access
    /// policy. By default, PutDestination does not set any access policy with the destination,
    /// which means a cross-account user will not be able to call <code>PutSubscriptionFilter</code>
    /// against this destination. To enable that, the destination owner must call <code>PutDestinationPolicy</code>
    /// after PutDestination. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.Destination")]
    [AWSCmdlet("Invokes the PutDestination operation against Amazon CloudWatch Logs.", Operation = new[] {"PutDestination"})]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.Destination",
        "This cmdlet returns a Destination object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.PutDestinationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCWLDestinationCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A name for the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DestinationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that grants Amazon CloudWatch Logs permissions to do Amazon
        /// Kinesis PutRecord requests on the desitnation stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of an Amazon Kinesis stream to deliver matching log events to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetArn { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DestinationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLDestination (PutDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DestinationName = this.DestinationName;
            context.RoleArn = this.RoleArn;
            context.TargetArn = this.TargetArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatchLogs.Model.PutDestinationRequest();
            
            if (cmdletContext.DestinationName != null)
            {
                request.DestinationName = cmdletContext.DestinationName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutDestination(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Destination;
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
            public System.String DestinationName { get; set; }
            public System.String RoleArn { get; set; }
            public System.String TargetArn { get; set; }
        }
        
    }
}
