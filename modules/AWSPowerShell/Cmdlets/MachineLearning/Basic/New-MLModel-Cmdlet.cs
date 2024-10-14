/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a new <c>MLModel</c> using the <c>DataSource</c> and the recipe as information
    /// sources. 
    /// 
    ///  
    /// <para>
    /// An <c>MLModel</c> is nearly immutable. Users can update only the <c>MLModelName</c>
    /// and the <c>ScoreThreshold</c> in an <c>MLModel</c> without creating a new <c>MLModel</c>.
    /// 
    /// </para><para><c>CreateMLModel</c> is an asynchronous operation. In response to <c>CreateMLModel</c>,
    /// Amazon Machine Learning (Amazon ML) immediately returns and sets the <c>MLModel</c>
    /// status to <c>PENDING</c>. After the <c>MLModel</c> has been created and ready is for
    /// use, Amazon ML sets the status to <c>COMPLETED</c>. 
    /// </para><para>
    /// You can use the <c>GetMLModel</c> operation to check the progress of the <c>MLModel</c>
    /// during the creation operation.
    /// </para><para><c>CreateMLModel</c> requires a <c>DataSource</c> with computed statistics, which
    /// can be created by setting <c>ComputeStatistics</c> to <c>true</c> in <c>CreateDataSourceFromRDS</c>,
    /// <c>CreateDataSourceFromS3</c>, or <c>CreateDataSourceFromRedshift</c> operations.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Machine Learning CreateMLModel API operation.", Operation = new[] {"CreateMLModel"}, SelectReturnType = typeof(Amazon.MachineLearning.Model.CreateMLModelResponse))]
    [AWSCmdletOutput("System.String or Amazon.MachineLearning.Model.CreateMLModelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MachineLearning.Model.CreateMLModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMLModelCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MLModelId
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <c>MLModel</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ModelId")]
        public System.String MLModelId { get; set; }
        #endregion
        
        #region Parameter MLModelName
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <c>MLModel</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Name")]
        public System.String MLModelName { get; set; }
        #endregion
        
        #region Parameter MLModelType
        /// <summary>
        /// <para>
        /// <para>The category of supervised learning that this <c>MLModel</c> will address. Choose
        /// from the following types:</para><ul><li><para>Choose <c>REGRESSION</c> if the <c>MLModel</c> will be used to predict a numeric value.</para></li><li><para>Choose <c>BINARY</c> if the <c>MLModel</c> result has two possible values.</para></li><li><para>Choose <c>MULTICLASS</c> if the <c>MLModel</c> result has a limited number of values.</para></li></ul><para> For more information, see the <a href="https://docs.aws.amazon.com/machine-learning/latest/dg">Amazon
        /// Machine Learning Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ModelType")]
        [AWSConstantClassSource("Amazon.MachineLearning.MLModelType")]
        public Amazon.MachineLearning.MLModelType MLModelType { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of the training parameters in the <c>MLModel</c>. The list is implemented as
        /// a map of key-value pairs.</para><para>The following is the current set of training parameters:</para><ul><li><para><c>sgd.maxMLModelSizeInBytes</c> - The maximum allowed size of the model. Depending
        /// on the input data, the size of the model might affect its performance.</para><para> The value is an integer that ranges from <c>100000</c> to <c>2147483648</c>. The
        /// default value is <c>33554432</c>.</para></li><li><para><c>sgd.maxPasses</c> - The number of times that the training process traverses the
        /// observations to build the <c>MLModel</c>. The value is an integer that ranges from
        /// <c>1</c> to <c>10000</c>. The default value is <c>10</c>.</para></li><li><para><c>sgd.shuffleType</c> - Whether Amazon ML shuffles the training data. Shuffling
        /// the data improves a model's ability to find the optimal solution for a variety of
        /// data types. The valid values are <c>auto</c> and <c>none</c>. The default value is
        /// <c>none</c>. We strongly recommend that you shuffle your data.</para></li><li><para><c>sgd.l1RegularizationAmount</c> - The coefficient regularization L1 norm. It controls
        /// overfitting the data by penalizing large coefficients. This tends to drive coefficients
        /// to zero, resulting in a sparse feature set. If you use this parameter, start by specifying
        /// a small value, such as <c>1.0E-08</c>.</para><para>The value is a double that ranges from <c>0</c> to <c>MAX_DOUBLE</c>. The default
        /// is to not use L1 normalization. This parameter can't be used when <c>L2</c> is specified.
        /// Use this parameter sparingly.</para></li><li><para><c>sgd.l2RegularizationAmount</c> - The coefficient regularization L2 norm. It controls
        /// overfitting the data by penalizing large coefficients. This tends to drive coefficients
        /// to small, nonzero values. If you use this parameter, start by specifying a small value,
        /// such as <c>1.0E-08</c>.</para><para>The value is a double that ranges from <c>0</c> to <c>MAX_DOUBLE</c>. The default
        /// is to not use L2 normalization. This parameter can't be used when <c>L1</c> is specified.
        /// Use this parameter sparingly.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter Recipe
        /// <summary>
        /// <para>
        /// <para>The data recipe for creating the <c>MLModel</c>. You must specify either the recipe
        /// or its URI. If you don't specify a recipe or its URI, Amazon ML creates a default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Recipe { get; set; }
        #endregion
        
        #region Parameter RecipeUri
        /// <summary>
        /// <para>
        /// <para>The Amazon Simple Storage Service (Amazon S3) location and file name that contains
        /// the <c>MLModel</c> recipe. You must specify either the recipe or its URI. If you don't
        /// specify a recipe or its URI, Amazon ML creates a default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecipeUri { get; set; }
        #endregion
        
        #region Parameter TrainingDataSourceId
        /// <summary>
        /// <para>
        /// <para>The <c>DataSource</c> that points to the training data.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TrainingDataSourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MLModelId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MachineLearning.Model.CreateMLModelResponse).
        /// Specifying the name of a property of type Amazon.MachineLearning.Model.CreateMLModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MLModelId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MLModelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MLModelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MLModelId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MLModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLModel (CreateMLModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MachineLearning.Model.CreateMLModelResponse, NewMLModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MLModelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MLModelId = this.MLModelId;
            #if MODULAR
            if (this.MLModelId == null && ParameterWasBound(nameof(this.MLModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter MLModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MLModelName = this.MLModelName;
            context.MLModelType = this.MLModelType;
            #if MODULAR
            if (this.MLModelType == null && ParameterWasBound(nameof(this.MLModelType)))
            {
                WriteWarning("You are passing $null as a value for parameter MLModelType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (System.String)(this.Parameter[hashKey]));
                }
            }
            context.Recipe = this.Recipe;
            context.RecipeUri = this.RecipeUri;
            context.TrainingDataSourceId = this.TrainingDataSourceId;
            #if MODULAR
            if (this.TrainingDataSourceId == null && ParameterWasBound(nameof(this.TrainingDataSourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingDataSourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.MachineLearning.Model.CreateMLModelResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateMLModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "CreateMLModel");
            try
            {
                #if DESKTOP
                return client.CreateMLModel(request);
                #elif CORECLR
                return client.CreateMLModelAsync(request).GetAwaiter().GetResult();
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
            public System.String MLModelId { get; set; }
            public System.String MLModelName { get; set; }
            public Amazon.MachineLearning.MLModelType MLModelType { get; set; }
            public Dictionary<System.String, System.String> Parameter { get; set; }
            public System.String Recipe { get; set; }
            public System.String RecipeUri { get; set; }
            public System.String TrainingDataSourceId { get; set; }
            public System.Func<Amazon.MachineLearning.Model.CreateMLModelResponse, NewMLModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MLModelId;
        }
        
    }
}
