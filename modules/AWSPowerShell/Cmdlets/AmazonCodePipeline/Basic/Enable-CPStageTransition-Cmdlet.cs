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
    /// Enables artifacts in a pipeline to transition to a stage in a pipeline.
    /// </summary>
    [Cmdlet("Enable", "CPStageTransition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the EnableStageTransition operation against AWS CodePipeline.", Operation = new[] {"EnableStageTransition"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.CodePipeline.Model.EnableStageTransitionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EnableCPStageTransitionCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline in which you want to enable the flow of artifacts from one
        /// stage to another.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name of the stage where you want to enable the transition of artifacts, either
        /// into the stage (inbound) or from that stage to the next stage (outbound).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StageName { get; set; }
        #endregion
        
        #region Parameter TransitionType
        /// <summary>
        /// <para>
        /// <para>Specifies whether artifacts will be allowed to enter the stage and be processed by
        /// the actions in that stage (inbound) or whether already-processed artifacts will be
        /// allowed to transition to the next stage (outbound).</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-CPStageTransition (EnableStageTransition)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.PipelineName = this.PipelineName;
            context.StageName = this.StageName;
            context.TransitionType = this.TransitionType;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodePipeline.Model.EnableStageTransitionRequest();
            
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
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
                var response = client.EnableStageTransition(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String PipelineName { get; set; }
            public System.String StageName { get; set; }
            public Amazon.CodePipeline.StageTransitionType TransitionType { get; set; }
        }
        
    }
}
