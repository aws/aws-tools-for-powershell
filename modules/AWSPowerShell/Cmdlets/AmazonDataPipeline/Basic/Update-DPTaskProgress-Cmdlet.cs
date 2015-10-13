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
    /// Task runners call <code>ReportTaskProgress</code> when assigned a task to acknowledge
    /// that it has the task. If the web service does not receive this acknowledgement within
    /// 2 minutes, it assigns the task in a subsequent <a>PollForTask</a> call. After this
    /// initial acknowledgement, the task runner only needs to report progress every 15 minutes
    /// to maintain its ownership of the task. You can change this reporting time from 15
    /// minutes by specifying a <code>reportProgressTimeout</code> field in your pipeline.
    /// 
    ///  
    /// <para>
    /// If a task runner does not report its status after 5 minutes, AWS Data Pipeline assumes
    /// that the task runner is unable to process the task and reassigns the task in a subsequent
    /// response to <a>PollForTask</a>. Task runners should call <code>ReportTaskProgress</code>
    /// every 60 seconds.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DPTaskProgress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Invokes the ReportTaskProgress operation against AWS Data Pipeline.", Operation = new[] {"ReportTaskProgress"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.DataPipeline.Model.ReportTaskProgressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateDPTaskProgressCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that define the properties of the ReportTaskProgressInput object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Fields")]
        public Amazon.DataPipeline.Model.Field[] Field { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the task assigned to the task runner. This value is provided in the response
        /// for <a>PollForTask</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TaskId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TaskId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DPTaskProgress (ReportTaskProgress)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Field != null)
            {
                context.Fields = new List<Amazon.DataPipeline.Model.Field>(this.Field);
            }
            context.TaskId = this.TaskId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DataPipeline.Model.ReportTaskProgressRequest();
            
            if (cmdletContext.Fields != null)
            {
                request.Fields = cmdletContext.Fields;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ReportTaskProgress(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Canceled;
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
            public List<Amazon.DataPipeline.Model.Field> Fields { get; set; }
            public System.String TaskId { get; set; }
        }
        
    }
}
