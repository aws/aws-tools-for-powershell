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
    /// Task runners call <code>SetTaskStatus</code> to notify AWS Data Pipeline that a task
    /// is completed and provide information about the final status. A task runner makes this
    /// call regardless of whether the task was sucessful. A task runner does not need to
    /// call <code>SetTaskStatus</code> for tasks that are canceled by the web service during
    /// a call to <a>ReportTaskProgress</a>.
    /// </summary>
    [Cmdlet("Set", "DPTaskStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetTaskStatus operation against AWS Data Pipeline.", Operation = new[] {"SetTaskStatus"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the TaskId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.DataPipeline.Model.SetTaskStatusResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SetDPTaskStatusCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        #region Parameter ErrorId
        /// <summary>
        /// <para>
        /// <para>If an error occurred during the task, this value specifies the error code. This value
        /// is set on the physical attempt object. It is used to display error information to
        /// the user. It should not start with string "Service_" which is reserved by the system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String ErrorId { get; set; }
        #endregion
        
        #region Parameter ErrorMessage
        /// <summary>
        /// <para>
        /// <para>If an error occurred during the task, this value specifies a text description of the
        /// error. This value is set on the physical attempt object. It is used to display error
        /// information to the user. The web service does not parse this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String ErrorMessage { get; set; }
        #endregion
        
        #region Parameter ErrorStackTrace
        /// <summary>
        /// <para>
        /// <para>If an error occurred during the task, this value specifies the stack trace associated
        /// with the error. This value is set on the physical attempt object. It is used to display
        /// error information to the user. The web service does not parse this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public System.String ErrorStackTrace { get; set; }
        #endregion
        
        #region Parameter TaskId
        /// <summary>
        /// <para>
        /// <para>The ID of the task assigned to the task runner. This value is provided in the response
        /// for <a>PollForTask</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TaskId { get; set; }
        #endregion
        
        #region Parameter TaskStatus
        /// <summary>
        /// <para>
        /// <para>If <code>FINISHED</code>, the task successfully completed. If <code>FAILED</code>,
        /// the task ended unsuccessfully. Preconditions use false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [AWSConstantClassSource("Amazon.DataPipeline.TaskStatus")]
        public Amazon.DataPipeline.TaskStatus TaskStatus { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the TaskId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TaskId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-DPTaskStatus (SetTaskStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ErrorId = this.ErrorId;
            context.ErrorMessage = this.ErrorMessage;
            context.ErrorStackTrace = this.ErrorStackTrace;
            context.TaskId = this.TaskId;
            context.TaskStatus = this.TaskStatus;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DataPipeline.Model.SetTaskStatusRequest();
            
            if (cmdletContext.ErrorId != null)
            {
                request.ErrorId = cmdletContext.ErrorId;
            }
            if (cmdletContext.ErrorMessage != null)
            {
                request.ErrorMessage = cmdletContext.ErrorMessage;
            }
            if (cmdletContext.ErrorStackTrace != null)
            {
                request.ErrorStackTrace = cmdletContext.ErrorStackTrace;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
            }
            if (cmdletContext.TaskStatus != null)
            {
                request.TaskStatus = cmdletContext.TaskStatus;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.TaskId;
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
        
        private static Amazon.DataPipeline.Model.SetTaskStatusResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.SetTaskStatusRequest request)
        {
            return client.SetTaskStatus(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ErrorId { get; set; }
            public System.String ErrorMessage { get; set; }
            public System.String ErrorStackTrace { get; set; }
            public System.String TaskId { get; set; }
            public Amazon.DataPipeline.TaskStatus TaskStatus { get; set; }
        }
        
    }
}
