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
    /// Adds tasks, schedules, and preconditions to the specified pipeline. You can use <code>PutPipelineDefinition</code>
    /// to populate a new pipeline.
    /// 
    ///  
    /// <para><code>PutPipelineDefinition</code> also validates the configuration as it adds it
    /// to the pipeline. Changes to the pipeline are saved unless one of the following three
    /// validation errors exists in the pipeline. 
    /// </para><ol><li>An object is missing a name or identifier field.</li><li>A string or reference
    /// field is empty.</li><li>The number of objects in the pipeline exceeds the maximum
    /// allowed objects.</li><li>The pipeline is in a FINISHED state.</li></ol><para>
    ///  Pipeline object definitions are passed to the <code>PutPipelineDefinition</code>
    /// action and returned by the <a>GetPipelineDefinition</a> action. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "DPPipelineDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataPipeline.Model.PutPipelineDefinitionResponse")]
    [AWSCmdlet("Invokes the PutPipelineDefinition operation against AWS Data Pipeline.", Operation = new[] {"PutPipelineDefinition"})]
    [AWSCmdletOutput("Amazon.DataPipeline.Model.PutPipelineDefinitionResponse",
        "This cmdlet returns a Amazon.DataPipeline.Model.PutPipelineDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteDPPipelineDefinitionCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        #region Parameter ParameterObject
        /// <summary>
        /// <para>
        /// <para>The parameter objects used with the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ParameterObjects")]
        public Amazon.DataPipeline.Model.ParameterObject[] ParameterObject { get; set; }
        #endregion
        
        #region Parameter ParameterValue
        /// <summary>
        /// <para>
        /// <para>The parameter values used with the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ParameterValues")]
        public Amazon.DataPipeline.Model.ParameterValue[] ParameterValue { get; set; }
        #endregion
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PipelineId { get; set; }
        #endregion
        
        #region Parameter PipelineObject
        /// <summary>
        /// <para>
        /// <para>The objects that define the pipeline. These objects overwrite the existing pipeline
        /// definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("PipelineObjects")]
        public Amazon.DataPipeline.Model.PipelineObject[] PipelineObject { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-DPPipelineDefinition (PutPipelineDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ParameterObject != null)
            {
                context.ParameterObjects = new List<Amazon.DataPipeline.Model.ParameterObject>(this.ParameterObject);
            }
            if (this.ParameterValue != null)
            {
                context.ParameterValues = new List<Amazon.DataPipeline.Model.ParameterValue>(this.ParameterValue);
            }
            context.PipelineId = this.PipelineId;
            if (this.PipelineObject != null)
            {
                context.PipelineObjects = new List<Amazon.DataPipeline.Model.PipelineObject>(this.PipelineObject);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DataPipeline.Model.PutPipelineDefinitionRequest();
            
            if (cmdletContext.ParameterObjects != null)
            {
                request.ParameterObjects = cmdletContext.ParameterObjects;
            }
            if (cmdletContext.ParameterValues != null)
            {
                request.ParameterValues = cmdletContext.ParameterValues;
            }
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineId = cmdletContext.PipelineId;
            }
            if (cmdletContext.PipelineObjects != null)
            {
                request.PipelineObjects = cmdletContext.PipelineObjects;
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
        
        private static Amazon.DataPipeline.Model.PutPipelineDefinitionResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.PutPipelineDefinitionRequest request)
        {
            return client.PutPipelineDefinition(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.DataPipeline.Model.ParameterObject> ParameterObjects { get; set; }
            public List<Amazon.DataPipeline.Model.ParameterValue> ParameterValues { get; set; }
            public System.String PipelineId { get; set; }
            public List<Amazon.DataPipeline.Model.PipelineObject> PipelineObjects { get; set; }
        }
        
    }
}
