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
    /// Validates the specified pipeline definition to ensure that it is well formed and can
    /// be run without error.
    /// </summary>
    [Cmdlet("Test", "DPPipelineDefinition")]
    [OutputType("Amazon.DataPipeline.Model.ValidatePipelineDefinitionResult")]
    [AWSCmdlet("Invokes the ValidatePipelineDefinition operation against AWS Data Pipeline.", Operation = new[] {"ValidatePipelineDefinition"})]
    [AWSCmdletOutput("Amazon.DataPipeline.Model.ValidatePipelineDefinitionResult",
        "This cmdlet returns a ValidatePipelineDefinitionResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class TestDPPipelineDefinitionCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The parameter objects used with the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ParameterObjects")]
        public Amazon.DataPipeline.Model.ParameterObject[] ParameterObject { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The parameter values used with the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ParameterValues")]
        public Amazon.DataPipeline.Model.ParameterValue[] ParameterValue { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String PipelineId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The objects that define the pipeline changes to validate against the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("PipelineObjects")]
        public Amazon.DataPipeline.Model.PipelineObject[] PipelineObject { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ParameterObject != null)
            {
                context.ParameterObjects = new List<ParameterObject>(this.ParameterObject);
            }
            if (this.ParameterValue != null)
            {
                context.ParameterValues = new List<ParameterValue>(this.ParameterValue);
            }
            context.PipelineId = this.PipelineId;
            if (this.PipelineObject != null)
            {
                context.PipelineObjects = new List<PipelineObject>(this.PipelineObject);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ValidatePipelineDefinitionRequest();
            
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
                var response = client.ValidatePipelineDefinition(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<ParameterObject> ParameterObjects { get; set; }
            public List<ParameterValue> ParameterValues { get; set; }
            public String PipelineId { get; set; }
            public List<PipelineObject> PipelineObjects { get; set; }
        }
        
    }
}
