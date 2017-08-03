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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Used by workers to retrieve a task (with the specified activity ARN) scheduled for
    /// execution by a running state machine. This initiates a long poll, where the service
    /// holds the HTTP connection open and responds as soon as a task becomes available (i.e.
    /// an execution of a task of this type is needed.) The maximum time the service holds
    /// on to the request before responding is 60 seconds. If no task is available within
    /// 60 seconds, the poll will return an empty result, that is, the <code>taskToken</code>
    /// returned is an empty string.
    /// 
    ///  <important><para>
    /// Workers should set their client side socket timeout to at least 65 seconds (5 seconds
    /// higher than the maximum time the service may hold the poll request).
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "SFNActivityTask")]
    [OutputType("Amazon.StepFunctions.Model.GetActivityTaskResponse")]
    [AWSCmdlet("Invokes the GetActivityTask operation against Amazon Step Functions.", Operation = new[] {"GetActivityTask"})]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.GetActivityTaskResponse",
        "This cmdlet returns a Amazon.StepFunctions.Model.GetActivityTaskResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSFNActivityTaskCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        #region Parameter ActivityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the activity to retrieve tasks from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ActivityArn { get; set; }
        #endregion
        
        #region Parameter WorkerName
        /// <summary>
        /// <para>
        /// <para>An arbitrary name may be provided in order to identify the worker that the task is
        /// assigned to. This name will be used when it is logged in the execution history.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WorkerName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ActivityArn = this.ActivityArn;
            context.WorkerName = this.WorkerName;
            
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
            var request = new Amazon.StepFunctions.Model.GetActivityTaskRequest();
            
            if (cmdletContext.ActivityArn != null)
            {
                request.ActivityArn = cmdletContext.ActivityArn;
            }
            if (cmdletContext.WorkerName != null)
            {
                request.WorkerName = cmdletContext.WorkerName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.StepFunctions.Model.GetActivityTaskResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.GetActivityTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Step Functions", "GetActivityTask");
            #if DESKTOP
            return client.GetActivityTask(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetActivityTaskAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ActivityArn { get; set; }
            public System.String WorkerName { get; set; }
        }
        
    }
}
