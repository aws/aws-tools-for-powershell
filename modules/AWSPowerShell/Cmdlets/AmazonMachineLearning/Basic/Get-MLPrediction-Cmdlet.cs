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
    /// Generates a prediction for the observation using the specified <code>ML Model</code>.
    /// 
    ///  <note><title>Note</title><para>
    /// Not all response parameters will be populated. Whether a response parameter is populated
    /// depends on the type of model requested.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "MLPrediction")]
    [OutputType("Amazon.MachineLearning.Model.Prediction")]
    [AWSCmdlet("Invokes the Predict operation against Amazon Machine Learning.", Operation = new[] {"Predict"})]
    [AWSCmdletOutput("Amazon.MachineLearning.Model.Prediction",
        "This cmdlet returns a Prediction object.",
        "The service call response (type PredictResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetMLPredictionCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A unique identifier of the <code>MLModel</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ModelId")]
        public String MLModelId { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PredictEndpoint { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable Record { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.MLModelId = this.MLModelId;
            context.PredictEndpoint = this.PredictEndpoint;
            if (this.Record != null)
            {
                context.Record = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Record.Keys)
                {
                    context.Record.Add((String)hashKey, (String)(this.Record[hashKey]));
                }
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new PredictRequest();
            
            if (cmdletContext.MLModelId != null)
            {
                request.MLModelId = cmdletContext.MLModelId;
            }
            if (cmdletContext.PredictEndpoint != null)
            {
                request.PredictEndpoint = cmdletContext.PredictEndpoint;
            }
            if (cmdletContext.Record != null)
            {
                request.Record = cmdletContext.Record;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.Predict(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Prediction;
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
            public String PredictEndpoint { get; set; }
            public Dictionary<String, String> Record { get; set; }
        }
        
    }
}
