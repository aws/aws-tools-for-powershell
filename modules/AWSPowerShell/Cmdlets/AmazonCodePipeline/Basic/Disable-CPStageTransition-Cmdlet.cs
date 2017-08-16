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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Prevents artifacts in a pipeline from transitioning to the next stage in the pipeline.
    /// </summary>
    [Cmdlet("Disable", "CPStageTransition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the DisableStageTransition operation against AWS CodePipeline.", Operation = new[] {"DisableStageTransition"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.CodePipeline.Model.DisableStageTransitionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisableCPStageTransitionCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline in which you want to disable the flow of artifacts from one
        /// stage to another.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>The reason given to the user why a stage is disabled, such as waiting for manual approval
        /// or manual tests. This message is displayed in the pipeline console UI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name of the stage where you want to disable the inbound or outbound transition
        /// of artifacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StageName { get; set; }
        #endregion
        
        #region Parameter TransitionType
        /// <summary>
        /// <para>
        /// <para>Specifies whether artifacts will be prevented from transitioning into the stage and
        /// being processed by the actions in that stage (inbound), or prevented from transitioning
        /// from the stage after they have been processed by the actions in that stage (outbound).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodePipeline.StageTransitionType")]
        public Amazon.CodePipeline.StageTransitionType TransitionType { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PipelineName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-CPStageTransition (DisableStageTransition)"))
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
            
            context.PipelineName = this.PipelineName;
            context.Reason = this.Reason;
            context.StageName = this.StageName;
            context.TransitionType = this.TransitionType;
            
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
            var request = new Amazon.CodePipeline.Model.DisableStageTransitionRequest();
            
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
            }
            if (cmdletContext.StageName != null)
            {
                request.StageName = cmdletContext.StageName;
            }
            if (cmdletContext.TransitionType != null)
            {
                request.TransitionType = cmdletContext.TransitionType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.CodePipeline.Model.DisableStageTransitionResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.DisableStageTransitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "DisableStageTransition");
            try
            {
                #if DESKTOP
                return client.DisableStageTransition(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DisableStageTransitionAsync(request);
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
            public System.String PipelineName { get; set; }
            public System.String Reason { get; set; }
            public System.String StageName { get; set; }
            public Amazon.CodePipeline.StageTransitionType TransitionType { get; set; }
        }
        
    }
}
