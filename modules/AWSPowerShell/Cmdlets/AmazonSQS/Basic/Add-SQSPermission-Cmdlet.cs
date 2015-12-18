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
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Amazon.PowerShell.Cmdlets.SQS
{
    /// <summary>
    /// Adds a permission to a queue for a specific <a href="http://docs.aws.amazon.com/general/latest/gr/glos-chap.html#P">principal</a>.
    /// This allows for sharing access to the queue.
    /// 
    ///  
    /// <para>
    /// When you create a queue, you have full control access rights for the queue. Only you
    /// (as owner of the queue) can grant or deny permissions to the queue. For more information
    /// about these permissions, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/acp-overview.html">Shared
    /// Queues</a> in the <i>Amazon SQS Developer Guide</i>.
    /// </para><note><para><code>AddPermission</code> writes an Amazon SQS-generated policy. If you want to write
    /// your own policy, use <a>SetQueueAttributes</a> to upload your policy. For more information
    /// about writing your own policy, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/AccessPolicyLanguage.html">Using
    /// The Access Policy Language</a> in the <i>Amazon SQS Developer Guide</i>.
    /// </para></note><note>Some API actions take lists of parameters. These lists are specified
    /// using the <code>param.n</code> notation. Values of <code>n</code> are integers starting
    /// from 1. For example, a parameter list with two elements looks like this: </note><para><code>&amp;Attribute.1=this</code></para><para><code>&amp;Attribute.2=that</code></para>
    /// </summary>
    [Cmdlet("Add", "SQSPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the AddPermission operation against Amazon Simple Queue Service.", Operation = new[] {"AddPermission"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the QueueUrl parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SQS.Model.AddPermissionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class AddSQSPermissionCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action the client wants to allow for the specified principal. The following are
        /// valid values: <code>* | SendMessage | ReceiveMessage | DeleteMessage | ChangeMessageVisibility
        /// | GetQueueAttributes | GetQueueUrl</code>. For more information about these actions,
        /// see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/acp-overview.html#PermissionTypes">Understanding
        /// Permissions</a> in the <i>Amazon SQS Developer Guide</i>.</para><para>Specifying <code>SendMessage</code>, <code>DeleteMessage</code>, or <code>ChangeMessageVisibility</code>
        /// for the <code>ActionName.n</code> also grants permissions for the corresponding batch
        /// versions of those actions: <code>SendMessageBatch</code>, <code>DeleteMessageBatch</code>,
        /// and <code>ChangeMessageVisibilityBatch</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("ActionNames","Actions")]
        public System.String[] Action { get; set; }
        #endregion
        
        #region Parameter AWSAccountId
        /// <summary>
        /// <para>
        /// <para>The AWS account number of the <a href="http://docs.aws.amazon.com/general/latest/gr/glos-chap.html#P">principal</a>
        /// who will be given permission. The principal must have an AWS account, but does not
        /// need to be signed up for Amazon SQS. For information about locating the AWS account
        /// identification, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/AWSCredentials.html">Your
        /// AWS Identifiers</a> in the <i>Amazon SQS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("AWSAccountIds")]
        public System.String[] AWSAccountId { get; set; }
        #endregion
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>The unique identification of the permission you're setting (e.g., <code>AliceSendMessage</code>).
        /// Constraints: Maximum 80 characters; alphanumeric characters, hyphens (-), and underscores
        /// (_) are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Label { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue to take action on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueUrl { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the QueueUrl parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AWSAccountId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-SQSPermission (AddPermission)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Action != null)
            {
                context.Actions = new List<System.String>(this.Action);
            }
            if (this.AWSAccountId != null)
            {
                context.AWSAccountIds = new List<System.String>(this.AWSAccountId);
            }
            context.Label = this.Label;
            context.QueueUrl = this.QueueUrl;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SQS.Model.AddPermissionRequest();
            
            if (cmdletContext.Actions != null)
            {
                request.Actions = cmdletContext.Actions;
            }
            if (cmdletContext.AWSAccountIds != null)
            {
                request.AWSAccountIds = cmdletContext.AWSAccountIds;
            }
            if (cmdletContext.Label != null)
            {
                request.Label = cmdletContext.Label;
            }
            if (cmdletContext.QueueUrl != null)
            {
                request.QueueUrl = cmdletContext.QueueUrl;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.AddPermission(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.QueueUrl;
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
            public List<System.String> Actions { get; set; }
            public List<System.String> AWSAccountIds { get; set; }
            public System.String Label { get; set; }
            public System.String QueueUrl { get; set; }
        }
        
    }
}
