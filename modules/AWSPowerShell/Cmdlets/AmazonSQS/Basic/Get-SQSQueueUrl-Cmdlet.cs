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
    /// Returns the URL of an existing queue. This action provides a simple way to retrieve
    /// the URL of an Amazon SQS queue. 
    /// 
    ///  
    /// <para>
    ///  To access a queue that belongs to another AWS account, use the <code>QueueOwnerAWSAccountId</code>
    /// parameter to specify the account ID of the queue's owner. The queue's owner must grant
    /// you permission to access the queue. For more information about shared queue access,
    /// see <a>AddPermission</a> or go to <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/acp-overview.html">Shared
    /// Queues</a> in the <i>Amazon SQS Developer Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SQSQueueUrl")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the GetQueueUrl operation against Amazon Simple Queue Service.", Operation = new[] {"GetQueueUrl"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SQS.Model.GetQueueUrlResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetSQSQueueUrlCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the queue whose URL must be fetched. Maximum 80 characters; alphanumeric
        /// characters, hyphens (-), and underscores (_) are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The AWS account ID of the account that created the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String QueueOwnerAWSAccountId { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.QueueName = this.QueueName;
            context.QueueOwnerAWSAccountId = this.QueueOwnerAWSAccountId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SQS.Model.GetQueueUrlRequest();
            
            if (cmdletContext.QueueName != null)
            {
                request.QueueName = cmdletContext.QueueName;
            }
            if (cmdletContext.QueueOwnerAWSAccountId != null)
            {
                request.QueueOwnerAWSAccountId = cmdletContext.QueueOwnerAWSAccountId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetQueueUrl(request);
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
            public System.String QueueName { get; set; }
            public System.String QueueOwnerAWSAccountId { get; set; }
        }
        
    }
}
