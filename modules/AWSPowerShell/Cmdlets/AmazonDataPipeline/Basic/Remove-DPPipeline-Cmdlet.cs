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
    /// Deletes a pipeline, its pipeline definition, and its run history. AWS Data Pipeline
    /// attempts to cancel instances associated with the pipeline that are currently being
    /// processed by task runners.
    /// 
    ///  
    /// <para>
    /// Deleting a pipeline cannot be undone. You cannot query or restore a deleted pipeline.
    /// To temporarily pause a pipeline instead of deleting it, call <a>SetStatus</a> with
    /// the status set to <code>PAUSE</code> on individual components. Components that are
    /// paused by <a>SetStatus</a> can be resumed.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "DPPipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Data Pipeline DeletePipeline API operation.", Operation = new[] {"DeletePipeline"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the PipelineId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.DataPipeline.Model.DeletePipelineResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveDPPipelineCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PipelineId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the PipelineId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PipelineId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DPPipeline (DeletePipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.PipelineId = this.PipelineId;
            
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
            var request = new Amazon.DataPipeline.Model.DeletePipelineRequest();
            
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineId = cmdletContext.PipelineId;
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
                    pipelineOutput = this.PipelineId;
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
        
        private Amazon.DataPipeline.Model.DeletePipelineResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.DeletePipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Pipeline", "DeletePipeline");
            try
            {
                #if DESKTOP
                return client.DeletePipeline(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeletePipelineAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String PipelineId { get; set; }
        }
        
    }
}
