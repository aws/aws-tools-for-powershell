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
    /// Creates a new queue, or returns the URL of an existing one. When you request <code>CreateQueue</code>,
    /// you provide a name for the queue. To successfully create a new queue, you must provide
    /// a name that is unique within the scope of your own queues.
    /// 
    ///  <note><para>
    /// If you delete a queue, you must wait at least 60 seconds before creating a queue with
    /// the same name.
    /// </para></note><para>
    /// You may pass one or more attributes in the request. If you do not provide a value
    /// for any attribute, the queue will have the default value for that attribute. Permitted
    /// attributes are the same that can be set using <a>SetQueueAttributes</a>.
    /// </para><note><para>
    /// Use <a>GetQueueUrl</a> to get a queue's URL. <a>GetQueueUrl</a> requires only the
    /// <code>QueueName</code> parameter.
    /// </para></note><para>
    /// If you provide the name of an existing queue, along with the exact names and values
    /// of all the queue's attributes, <code>CreateQueue</code> returns the queue URL for
    /// the existing queue. If the queue name, attribute names, or attribute values do not
    /// match an existing queue, <code>CreateQueue</code> returns an error.
    /// </para><note>Some API actions take lists of parameters. These lists are specified using
    /// the <code>param.n</code> notation. Values of <code>n</code> are integers starting
    /// from 1. For example, a parameter list with two elements looks like this: </note><para><code>&amp;Attribute.1=this</code></para><para><code>&amp;Attribute.2=that</code></para>
    /// </summary>
    [Cmdlet("New", "SQSQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateQueue operation against Amazon Simple Queue Service.", Operation = new[] {"CreateQueue"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SQS.Model.CreateQueueResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewSQSQueueCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A map of attributes with their corresponding values.</para><para>The following lists the names, descriptions, and values of the special request parameters
        /// the <code>CreateQueue</code> action uses:</para><para><ul><li><code>DelaySeconds</code> - The time in seconds that the delivery of all
        /// messages in the queue will be delayed. An integer from 0 to 900 (15 minutes). The
        /// default for this attribute is 0 (zero).</li><li><code>MaximumMessageSize</code>
        /// - The limit of how many bytes a message can contain before Amazon SQS rejects it.
        /// An integer from 1024 bytes (1 KiB) up to 262144 bytes (256 KiB). The default for this
        /// attribute is 262144 (256 KiB).</li><li><code>MessageRetentionPeriod</code> - The
        /// number of seconds Amazon SQS retains a message. Integer representing seconds, from
        /// 60 (1 minute) to 1209600 (14 days). The default for this attribute is 345600 (4 days).</li><li><code>Policy</code> - The queue's policy. A valid AWS policy. For more information
        /// about policy structure, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/PoliciesOverview.html">Overview
        /// of AWS IAM Policies</a> in the <i>Amazon IAM User Guide</i>.</li><li><code>ReceiveMessageWaitTimeSeconds</code>
        /// - The time for which a <a>ReceiveMessage</a> call will wait for a message to arrive.
        /// An integer from 0 to 20 (seconds). The default for this attribute is 0. </li><li><code>VisibilityTimeout</code> - The visibility timeout for the queue. An integer
        /// from 0 to 43200 (12 hours). The default for this attribute is 30. For more information
        /// about visibility timeout, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/AboutVT.html">Visibility
        /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>.</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name for the queue to be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueName { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("QueueName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SQSQueue (CreateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.QueueName = this.QueueName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SQS.Model.CreateQueueRequest();
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            if (cmdletContext.QueueName != null)
            {
                request.QueueName = cmdletContext.QueueName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateQueue(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.QueueUrl;
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
            public Dictionary<System.String, System.String> Attributes { get; set; }
            public System.String QueueName { get; set; }
        }
        
    }
}
