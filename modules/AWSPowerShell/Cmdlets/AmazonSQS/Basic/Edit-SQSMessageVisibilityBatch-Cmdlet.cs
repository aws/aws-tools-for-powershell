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
    /// Changes the visibility timeout of multiple messages. This is a batch version of <a>ChangeMessageVisibility</a>.
    /// The result of the action on each message is reported individually in the response.
    /// You can send up to 10 <a>ChangeMessageVisibility</a> requests with each <code>ChangeMessageVisibilityBatch</code>
    /// action.
    /// 
    ///  <important>Because the batch request can result in a combination of successful and
    /// unsuccessful actions, you should check for batch errors even when the call returns
    /// an HTTP status code of 200.</important><note>Some API actions take lists of parameters.
    /// These lists are specified using the <code>param.n</code> notation. Values of <code>n</code>
    /// are integers starting from 1. For example, a parameter list with two elements looks
    /// like this: </note><para><code>&amp;Attribute.1=this</code></para><para><code>&amp;Attribute.2=that</code></para>
    /// </summary>
    [Cmdlet("Edit", "SQSMessageVisibilityBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SQS.Model.ChangeMessageVisibilityBatchResponse")]
    [AWSCmdlet("Invokes the ChangeMessageVisibilityBatch operation against Amazon Simple Queue Service.", Operation = new[] {"ChangeMessageVisibilityBatch"})]
    [AWSCmdletOutput("Amazon.SQS.Model.ChangeMessageVisibilityBatchResponse",
        "This cmdlet returns a Amazon.SQS.Model.ChangeMessageVisibilityBatchResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditSQSMessageVisibilityBatchCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>A list of receipt handles of the messages for which the visibility timeout must be
        /// changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Entries")]
        public Amazon.SQS.Model.ChangeMessageVisibilityBatchRequestEntry[] Entry { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("QueueUrl", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-SQSMessageVisibilityBatch (ChangeMessageVisibilityBatch)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Entry != null)
            {
                context.Entries = new List<Amazon.SQS.Model.ChangeMessageVisibilityBatchRequestEntry>(this.Entry);
            }
            context.QueueUrl = this.QueueUrl;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SQS.Model.ChangeMessageVisibilityBatchRequest();
            
            if (cmdletContext.Entries != null)
            {
                request.Entries = cmdletContext.Entries;
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
                var response = client.ChangeMessageVisibilityBatch(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
            public List<Amazon.SQS.Model.ChangeMessageVisibilityBatchRequestEntry> Entries { get; set; }
            public System.String QueueUrl { get; set; }
        }
        
    }
}
