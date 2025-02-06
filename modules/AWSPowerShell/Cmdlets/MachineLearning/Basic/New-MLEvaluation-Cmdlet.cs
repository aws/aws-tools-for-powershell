/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a new <c>Evaluation</c> of an <c>MLModel</c>. An <c>MLModel</c> is evaluated
    /// on a set of observations associated to a <c>DataSource</c>. Like a <c>DataSource</c>
    /// for an <c>MLModel</c>, the <c>DataSource</c> for an <c>Evaluation</c> contains values
    /// for the <c>Target Variable</c>. The <c>Evaluation</c> compares the predicted result
    /// for each observation to the actual outcome and provides a summary so that you know
    /// how effective the <c>MLModel</c> functions on the test data. Evaluation generates
    /// a relevant performance metric, such as BinaryAUC, RegressionRMSE or MulticlassAvgFScore
    /// based on the corresponding <c>MLModelType</c>: <c>BINARY</c>, <c>REGRESSION</c> or
    /// <c>MULTICLASS</c>. 
    /// 
    ///  
    /// <para><c>CreateEvaluation</c> is an asynchronous operation. In response to <c>CreateEvaluation</c>,
    /// Amazon Machine Learning (Amazon ML) immediately returns and sets the evaluation status
    /// to <c>PENDING</c>. After the <c>Evaluation</c> is created and ready for use, Amazon
    /// ML sets the status to <c>COMPLETED</c>. 
    /// </para><para>
    /// You can use the <c>GetEvaluation</c> operation to check progress of the evaluation
    /// during the creation operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Machine Learning CreateEvaluation API operation.", Operation = new[] {"CreateEvaluation"}, SelectReturnType = typeof(Amazon.MachineLearning.Model.CreateEvaluationResponse))]
    [AWSCmdletOutput("System.String or Amazon.MachineLearning.Model.CreateEvaluationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MachineLearning.Model.CreateEvaluationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMLEvaluationCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EvaluationDataSourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the <c>DataSource</c> for the evaluation. The schema of the <c>DataSource</c>
        /// must match the schema used to create the <c>MLModel</c>.</para>
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
        public System.String EvaluationDataSourceId { get; set; }
        #endregion
        
        #region Parameter EvaluationId
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <c>Evaluation</c>.</para>
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
        public System.String EvaluationId { get; set; }
        #endregion
        
        #region Parameter EvaluationName
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <c>Evaluation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Name")]
        public System.String EvaluationName { get; set; }
        #endregion
        
        #region Parameter MLModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the <c>MLModel</c> to evaluate.</para><para>The schema used in creating the <c>MLModel</c> must match the schema of the <c>DataSource</c>
        /// used in the <c>Evaluation</c>.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EvaluationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MachineLearning.Model.CreateEvaluationResponse).
        /// Specifying the name of a property of type Amazon.MachineLearning.Model.CreateEvaluationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EvaluationId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLEvaluation (CreateEvaluation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MachineLearning.Model.CreateEvaluationResponse, NewMLEvaluationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EvaluationDataSourceId = this.EvaluationDataSourceId;
            #if MODULAR
            if (this.EvaluationDataSourceId == null && ParameterWasBound(nameof(this.EvaluationDataSourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationDataSourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationId = this.EvaluationId;
            #if MODULAR
            if (this.EvaluationId == null && ParameterWasBound(nameof(this.EvaluationId)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationName = this.EvaluationName;
            context.MLModelId = this.MLModelId;
            #if MODULAR
            if (this.MLModelId == null && ParameterWasBound(nameof(this.MLModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter MLModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MachineLearning.Model.CreateEvaluationRequest();
            
            if (cmdletContext.EvaluationDataSourceId != null)
            {
                request.EvaluationDataSourceId = cmdletContext.EvaluationDataSourceId;
            }
            if (cmdletContext.EvaluationId != null)
            {
                request.EvaluationId = cmdletContext.EvaluationId;
            }
            if (cmdletContext.EvaluationName != null)
            {
                request.EvaluationName = cmdletContext.EvaluationName;
            }
            if (cmdletContext.MLModelId != null)
            {
                request.MLModelId = cmdletContext.MLModelId;
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
        
        private Amazon.MachineLearning.Model.CreateEvaluationResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateEvaluationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "CreateEvaluation");
            try
            {
                #if DESKTOP
                return client.CreateEvaluation(request);
                #elif CORECLR
                return client.CreateEvaluationAsync(request).GetAwaiter().GetResult();
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
            public System.String EvaluationDataSourceId { get; set; }
            public System.String EvaluationId { get; set; }
            public System.String EvaluationName { get; set; }
            public System.String MLModelId { get; set; }
            public System.Func<Amazon.MachineLearning.Model.CreateEvaluationResponse, NewMLEvaluationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EvaluationId;
        }
        
    }
}
