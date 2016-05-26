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
using Amazon.DataPipeline;
using Amazon.DataPipeline.Model;

namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Task runners call <code>PollForTask</code> to receive a task to perform from AWS Data
    /// Pipeline. The task runner specifies which tasks it can perform by setting a value
    /// for the <code>workerGroup</code> parameter. The task returned can come from any of
    /// the pipelines that match the <code>workerGroup</code> value passed in by the task
    /// runner and that was launched using the IAM user credentials specified by the task
    /// runner.
    /// 
    ///  
    /// <para>
    /// If tasks are ready in the work queue, <code>PollForTask</code> returns a response
    /// immediately. If no tasks are available in the queue, <code>PollForTask</code> uses
    /// long-polling and holds on to a poll connection for up to a 90 seconds, during which
    /// time the first newly scheduled task is handed to the task runner. To accomodate this,
    /// set the socket timeout in your task runner to 90 seconds. The task runner should not
    /// call <code>PollForTask</code> again on the same <code>workerGroup</code> until it
    /// receives a response, and this can take up to 90 seconds. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DPTask")]
    [OutputType("Amazon.DataPipeline.Model.TaskObject")]
    [AWSCmdlet("Invokes the PollForTask operation against AWS Data Pipeline.", Operation = new[] {"PollForTask"})]
    [AWSCmdletOutput("Amazon.DataPipeline.Model.TaskObject",
        "This cmdlet returns a TaskObject object.",
        "The service call response (type Amazon.DataPipeline.Model.PollForTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetDPTaskCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        #region Parameter InstanceIdentity_Document
        /// <summary>
        /// <para>
        /// <para>A description of an EC2 instance that is generated when the instance is launched and
        /// exposed to the instance via the instance metadata service in the form of a JSON representation
        /// of an object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceIdentity_Document { get; set; }
        #endregion
        
        #region Parameter Hostname
        /// <summary>
        /// <para>
        /// <para>The public DNS name of the calling task runner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Hostname { get; set; }
        #endregion
        
        #region Parameter InstanceIdentity_Signature
        /// <summary>
        /// <para>
        /// <para>A signature which can be used to verify the accuracy and authenticity of the information
        /// provided in the instance identity document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceIdentity_Signature { get; set; }
        #endregion
        
        #region Parameter WorkerGroup
        /// <summary>
        /// <para>
        /// <para>The type of task the task runner is configured to accept and process. The worker group
        /// is set as a field on objects in the pipeline when they are created. You can only specify
        /// a single value for <code>workerGroup</code> in the call to <code>PollForTask</code>.
        /// There are no wildcard values permitted in <code>workerGroup</code>; the string must
        /// be an exact, case-sensitive, match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String WorkerGroup { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Hostname = this.Hostname;
            context.InstanceIdentity_Document = this.InstanceIdentity_Document;
            context.InstanceIdentity_Signature = this.InstanceIdentity_Signature;
            context.WorkerGroup = this.WorkerGroup;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DataPipeline.Model.PollForTaskRequest();
            
            if (cmdletContext.Hostname != null)
            {
                request.Hostname = cmdletContext.Hostname;
            }
            
             // populate InstanceIdentity
            bool requestInstanceIdentityIsNull = true;
            request.InstanceIdentity = new Amazon.DataPipeline.Model.InstanceIdentity();
            System.String requestInstanceIdentity_instanceIdentity_Document = null;
            if (cmdletContext.InstanceIdentity_Document != null)
            {
                requestInstanceIdentity_instanceIdentity_Document = cmdletContext.InstanceIdentity_Document;
            }
            if (requestInstanceIdentity_instanceIdentity_Document != null)
            {
                request.InstanceIdentity.Document = requestInstanceIdentity_instanceIdentity_Document;
                requestInstanceIdentityIsNull = false;
            }
            System.String requestInstanceIdentity_instanceIdentity_Signature = null;
            if (cmdletContext.InstanceIdentity_Signature != null)
            {
                requestInstanceIdentity_instanceIdentity_Signature = cmdletContext.InstanceIdentity_Signature;
            }
            if (requestInstanceIdentity_instanceIdentity_Signature != null)
            {
                request.InstanceIdentity.Signature = requestInstanceIdentity_instanceIdentity_Signature;
                requestInstanceIdentityIsNull = false;
            }
             // determine if request.InstanceIdentity should be set to null
            if (requestInstanceIdentityIsNull)
            {
                request.InstanceIdentity = null;
            }
            if (cmdletContext.WorkerGroup != null)
            {
                request.WorkerGroup = cmdletContext.WorkerGroup;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TaskObject;
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
        
        private static Amazon.DataPipeline.Model.PollForTaskResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.PollForTaskRequest request)
        {
            return client.PollForTask(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Hostname { get; set; }
            public System.String InstanceIdentity_Document { get; set; }
            public System.String InstanceIdentity_Signature { get; set; }
            public System.String WorkerGroup { get; set; }
        }
        
    }
}
