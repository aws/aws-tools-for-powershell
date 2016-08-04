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
    /// Creates a new <code>MLModel</code> using the <code>DataSource</code> and the recipe
    /// as information sources. 
    /// 
    ///  
    /// <para>
    /// An <code>MLModel</code> is nearly immutable. Users can update only the <code>MLModelName</code>
    /// and the <code>ScoreThreshold</code> in an <code>MLModel</code> without creating a
    /// new <code>MLModel</code>. 
    /// </para><para><code>CreateMLModel</code> is an asynchronous operation. In response to <code>CreateMLModel</code>,
    /// Amazon Machine Learning (Amazon ML) immediately returns and sets the <code>MLModel</code>
    /// status to <code>PENDING</code>. After the <code>MLModel</code> has been created and
    /// ready is for use, Amazon ML sets the status to <code>COMPLETED</code>. 
    /// </para><para>
    /// You can use the <code>GetMLModel</code> operation to check the progress of the <code>MLModel</code>
    /// during the creation operation.
    /// </para><para><code>CreateMLModel</code> requires a <code>DataSource</code> with computed statistics,
    /// which can be created by setting <code>ComputeStatistics</code> to <code>true</code>
    /// in <code>CreateDataSourceFromRDS</code>, <code>CreateDataSourceFromS3</code>, or <code>CreateDataSourceFromRedshift</code>
    /// operations. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateMLModel operation against Amazon Machine Learning.", Operation = new[] {"CreateMLModel"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.MachineLearning.Model.CreateMLModelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewMLModelCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter MLModelId
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <code>MLModel</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ModelId")]
        public System.String MLModelId { get; set; }
        #endregion
        
        #region Parameter MLModelName
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <code>MLModel</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Name")]
        public System.String MLModelName { get; set; }
        #endregion
        
        #region Parameter MLModelType
        /// <summary>
        /// <para>
        /// <para>The category of supervised learning that this <code>MLModel</code> will address. Choose
        /// from the following types:</para><ul><li>Choose <code>REGRESSION</code> if the <code>MLModel</code> will be used
        /// to predict a numeric value.</li><li>Choose <code>BINARY</code> if the <code>MLModel</code>
        /// result has two possible values.</li><li>Choose <code>MULTICLASS</code> if the <code>MLModel</code>
        /// result has a limited number of values. </li></ul><para> For more information, see the <a href="http://docs.aws.amazon.com/machine-learning/latest/dg">Amazon
        /// Machine Learning Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ModelType")]
        [AWSConstantClassSource("Amazon.MachineLearning.MLModelType")]
        public Amazon.MachineLearning.MLModelType MLModelType { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of the training parameters in the <code>MLModel</code>. The list is implemented
        /// as a map of key-value pairs.</para><para>The following is the current set of training parameters: </para><ul><li><para><code>sgd.maxMLModelSizeInBytes</code> - The maximum allowed size of the model. Depending
        /// on the input data, the size of the model might affect its performance.</para><para> The value is an integer that ranges from <code>100000</code> to <code>2147483648</code>.
        /// The default value is <code>33554432</code>.</para></li><li><para><code>sgd.maxPasses</code> - The number of times that the training process traverses
        /// the observations to build the <code>MLModel</code>. The value is an integer that ranges
        /// from <code>1</code> to <code>10000</code>. The default value is <code>10</code>.</para></li><li><para><code>sgd.shuffleType</code> - Whether Amazon ML shuffles the training data. Shuffling
        /// the data improves a model's ability to find the optimal solution for a variety of
        /// data types. The valid values are <code>auto</code> and <code>none</code>. The default
        /// value is <code>none</code>. We strongly recommend that you shuffle your data.</para></li><li><para><code>sgd.l1RegularizationAmount</code> - The coefficient regularization L1 norm.
        /// It controls overfitting the data by penalizing large coefficients. This tends to drive
        /// coefficients to zero, resulting in a sparse feature set. If you use this parameter,
        /// start by specifying a small value, such as <code>1.0E-08</code>.</para><para>The value is a double that ranges from <code>0</code> to <code>MAX_DOUBLE</code>.
        /// The default is to not use L1 normalization. This parameter can't be used when <code>L2</code>
        /// is specified. Use this parameter sparingly.</para></li><li><para><code>sgd.l2RegularizationAmount</code> - The coefficient regularization L2 norm.
        /// It controls overfitting the data by penalizing large coefficients. This tends to drive
        /// coefficients to small, nonzero values. If you use this parameter, start by specifying
        /// a small value, such as <code>1.0E-08</code>.</para><para>The value is a double that ranges from <code>0</code> to <code>MAX_DOUBLE</code>.
        /// The default is to not use L2 normalization. This parameter can't be used when <code>L1</code>
        /// is specified. Use this parameter sparingly.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter Recipe
        /// <summary>
        /// <para>
        /// <para>The data recipe for creating the <code>MLModel</code>. You must specify either the
        /// recipe or its URI. If you don't specify a recipe or its URI, Amazon ML creates a default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Recipe { get; set; }
        #endregion
        
        #region Parameter RecipeUri
        /// <summary>
        /// <para>
        /// <para>The Amazon Simple Storage Service (Amazon S3) location and file name that contains
        /// the <code>MLModel</code> recipe. You must specify either the recipe or its URI. If
        /// you don't specify a recipe or its URI, Amazon ML creates a default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RecipeUri { get; set; }
        #endregion
        
        #region Parameter TrainingDataSourceId
        /// <summary>
        /// <para>
        /// <para>The <code>DataSource</code> that points to the training data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrainingDataSourceId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("MLModelId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLModel (CreateMLModel)"))
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
            context.MLModelType = this.MLModelType;
            if (this.Parameter != null)
            {
                context.Parameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameters.Add((String)hashKey, (String)(this.Parameter[hashKey]));
                }
            }
            context.Recipe = this.Recipe;
            context.RecipeUri = this.RecipeUri;
            context.TrainingDataSourceId = this.TrainingDataSourceId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MachineLearning.Model.CreateMLModelRequest();
            
            if (cmdletContext.MLModelId != null)
            {
                request.MLModelId = cmdletContext.MLModelId;
            }
            if (cmdletContext.MLModelName != null)
            {
                request.MLModelName = cmdletContext.MLModelName;
            }
            if (cmdletContext.MLModelType != null)
            {
                request.MLModelType = cmdletContext.MLModelType;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.Recipe != null)
            {
                request.Recipe = cmdletContext.Recipe;
            }
            if (cmdletContext.RecipeUri != null)
            {
                request.RecipeUri = cmdletContext.RecipeUri;
            }
            if (cmdletContext.TrainingDataSourceId != null)
            {
                request.TrainingDataSourceId = cmdletContext.TrainingDataSourceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.MachineLearning.Model.CreateMLModelResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateMLModelRequest request)
        {
            return client.CreateMLModel(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String MLModelId { get; set; }
            public System.String MLModelName { get; set; }
            public Amazon.MachineLearning.MLModelType MLModelType { get; set; }
            public Dictionary<System.String, System.String> Parameters { get; set; }
            public System.String Recipe { get; set; }
            public System.String RecipeUri { get; set; }
            public System.String TrainingDataSourceId { get; set; }
        }
        
    }
}
