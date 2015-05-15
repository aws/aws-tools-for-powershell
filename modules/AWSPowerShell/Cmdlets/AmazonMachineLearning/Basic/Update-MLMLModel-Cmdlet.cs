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
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Updates the <code>MLModelName</code> and the <code>ScoreThreshold</code> of an <code>MLModel</code>.
    /// 
    ///  
    /// <para>
    /// You can use the <a>GetMLModel</a> operation to view the contents of the updated data
    /// element.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MLMLModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateMLModel operation against Amazon Machine Learning.", Operation = new[] {"UpdateMLModel"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type UpdateMLModelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateMLMLModelCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The ID assigned to the <code>MLModel</code> during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ModelId")]
        public String MLModelId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <code>MLModel</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String MLModelName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <code>ScoreThreshold</code> used in binary classification <code>MLModel</code>
        /// that marks the boundary between a positive prediction and a negative prediction.</para><para>Output values greater than or equal to the <code>ScoreThreshold</code> receive a positive
        /// result from the <code>MLModel</code>, such as <code>true</code>. Output values less
        /// than the <code>ScoreThreshold</code> receive a negative response from the <code>MLModel</code>,
        /// such as <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Single ScoreThreshold { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("MLModelId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MLMLModel (UpdateMLModel)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.MLModelId = this.MLModelId;
            context.MLModelName = this.MLModelName;
            if (ParameterWasBound("ScoreThreshold"))
                context.ScoreThreshold = this.ScoreThreshold;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateMLModelRequest();
            
            if (cmdletContext.MLModelId != null)
            {
                request.MLModelId = cmdletContext.MLModelId;
            }
            if (cmdletContext.MLModelName != null)
            {
                request.MLModelName = cmdletContext.MLModelName;
            }
            if (cmdletContext.ScoreThreshold != null)
            {
                request.ScoreThreshold = cmdletContext.ScoreThreshold.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateMLModel(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.MLModelId;
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
            public String MLModelId { get; set; }
            public String MLModelName { get; set; }
            public Single? ScoreThreshold { get; set; }
        }
        
    }
}
