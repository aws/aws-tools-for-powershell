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
    /// Returns an <code>MLModel</code> that includes detailed metadata, data source information,
    /// and the current status of the <code>MLModel</code>.
    /// 
    ///  
    /// <para><code>GetMLModel</code> provides results in normal or verbose format. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "MLModel")]
    [OutputType("Amazon.MachineLearning.Model.GetMLModelResponse")]
    [AWSCmdlet("Invokes the GetMLModel operation against Amazon Machine Learning.", Operation = new[] {"GetMLModel"})]
    [AWSCmdletOutput("Amazon.MachineLearning.Model.GetMLModelResponse",
        "This cmdlet returns a Amazon.MachineLearning.Model.GetMLModelResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetMLModelCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter MLModelId
        /// <summary>
        /// <para>
        /// <para>The ID assigned to the <code>MLModel</code> at creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ModelId")]
        public System.String MLModelId { get; set; }
        #endregion
        
        #region Parameter VerboseResponse
        /// <summary>
        /// <para>
        /// <para>Specifies whether the <code>GetMLModel</code> operation should return <code>Recipe</code>.</para><para>If true, <code>Recipe</code> is returned.</para><para>If false, <code>Recipe</code> is not returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean VerboseResponse { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.MLModelId = this.MLModelId;
            if (ParameterWasBound("VerboseResponse"))
                context.VerboseResponse = this.VerboseResponse;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MachineLearning.Model.GetMLModelRequest();
            
            if (cmdletContext.MLModelId != null)
            {
                request.MLModelId = cmdletContext.MLModelId;
            }
            if (cmdletContext.VerboseResponse != null)
            {
                request.Verbose = cmdletContext.VerboseResponse.Value;
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
        
        private static Amazon.MachineLearning.Model.GetMLModelResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.GetMLModelRequest request)
        {
            return client.GetMLModel(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String MLModelId { get; set; }
            public System.Boolean? VerboseResponse { get; set; }
        }
        
    }
}
