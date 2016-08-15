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
        "The service call response (type Amazon.MachineLearning.Model.PredictResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMLPredictionCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter MLModelId
        /// <summary>
        /// <para>
        /// <para>A unique identifier of the <code>MLModel</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ModelId")]
        public System.String MLModelId { get; set; }
        #endregion
        
        #region Parameter PredictEndpoint
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PredictEndpoint { get; set; }
        #endregion
        
        #region Parameter Record
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable Record { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.MLModelId = this.MLModelId;
            context.PredictEndpoint = this.PredictEndpoint;
            if (this.Record != null)
            {
                context.Record = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Record.Keys)
                {
                    context.Record.Add((String)hashKey, (String)(this.Record[hashKey]));
                }
            }
            
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
            var request = new Amazon.MachineLearning.Model.PredictRequest();
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.MachineLearning.Model.PredictResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.PredictRequest request)
        {
            #if DESKTOP
            return client.Predict(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PredictAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String MLModelId { get; set; }
            public System.String PredictEndpoint { get; set; }
            public Dictionary<System.String, System.String> Record { get; set; }
        }
        
    }
}
