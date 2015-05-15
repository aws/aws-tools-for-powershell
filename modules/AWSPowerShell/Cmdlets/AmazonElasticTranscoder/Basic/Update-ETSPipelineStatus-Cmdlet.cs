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
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;

namespace Amazon.PowerShell.Cmdlets.ETS
{
    /// <summary>
    /// The UpdatePipelineStatus operation pauses or reactivates a pipeline, so that the pipeline
    /// stops or restarts the processing of jobs.
    /// 
    ///  
    /// <para>
    /// Changing the pipeline status is useful if you want to cancel one or more jobs. You
    /// can't cancel jobs after Elastic Transcoder has started processing them; if you pause
    /// the pipeline to which you submitted the jobs, you have more time to get the job IDs
    /// for the jobs that you want to cancel, and to send a <a>CancelJob</a> request. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ETSPipelineStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticTranscoder.Model.Pipeline")]
    [AWSCmdlet("Invokes the UpdatePipelineStatus operation against Amazon Elastic Transcoder.", Operation = new[] {"UpdatePipelineStatus"})]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.Pipeline",
        "This cmdlet returns a Pipeline object.",
        "The service call response (type UpdatePipelineStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateETSPipelineStatusCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The identifier of the pipeline to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String Id { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The desired status of the pipeline:</para><ul><li><code>Active</code>: The pipeline is processing jobs.</li><li><code>Paused</code>:
        /// The pipeline is not currently processing jobs.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String Status { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Id", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ETSPipelineStatus (UpdatePipelineStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Id = this.Id;
            context.Status = this.Status;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdatePipelineStatusRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdatePipelineStatus(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Pipeline;
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
            public String Id { get; set; }
            public String Status { get; set; }
        }
        
    }
}
