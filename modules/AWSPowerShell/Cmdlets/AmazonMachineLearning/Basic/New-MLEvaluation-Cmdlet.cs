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
    /// Creates a new <code>Evaluation</code> of an <code>MLModel</code>. An <code>MLModel</code>
    /// is evaluated on a set of observations associated to a <code>DataSource</code>. Like
    /// a <code>DataSource</code> for an <code>MLModel</code>, the <code>DataSource</code>
    /// for an <code>Evaluation</code> contains values for the <code>Target Variable</code>.
    /// The <code>Evaluation</code> compares the predicted result for each observation to
    /// the actual outcome and provides a summary so that you know how effective the <code>MLModel</code>
    /// functions on the test data. Evaluation generates a relevant performance metric, such
    /// as BinaryAUC, RegressionRMSE or MulticlassAvgFScore based on the corresponding <code>MLModelType</code>:
    /// <code>BINARY</code>, <code>REGRESSION</code> or <code>MULTICLASS</code>. 
    /// 
    ///  
    /// <para><code>CreateEvaluation</code> is an asynchronous operation. In response to <code>CreateEvaluation</code>,
    /// Amazon Machine Learning (Amazon ML) immediately returns and sets the evaluation status
    /// to <code>PENDING</code>. After the <code>Evaluation</code> is created and ready for
    /// use, Amazon ML sets the status to <code>COMPLETED</code>. 
    /// </para><para>
    /// You can use the <code>GetEvaluation</code> operation to check progress of the evaluation
    /// during the creation operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateEvaluation operation against Amazon Machine Learning.", Operation = new[] {"CreateEvaluation"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.MachineLearning.Model.CreateEvaluationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMLEvaluationCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter EvaluationDataSourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the <code>DataSource</code> for the evaluation. The schema of the <code>DataSource</code>
        /// must match the schema used to create the <code>MLModel</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EvaluationDataSourceId { get; set; }
        #endregion
        
        #region Parameter EvaluationId
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <code>Evaluation</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EvaluationId { get; set; }
        #endregion
        
        #region Parameter EvaluationName
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <code>Evaluation</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Name")]
        public System.String EvaluationName { get; set; }
        #endregion
        
        #region Parameter MLModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the <code>MLModel</code> to evaluate.</para><para>The schema used in creating the <code>MLModel</code> must match the schema of the
        /// <code>DataSource</code> used in the <code>Evaluation</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ModelId")]
        public System.String MLModelId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLEvaluation (CreateEvaluation)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.EvaluationDataSourceId = this.EvaluationDataSourceId;
            context.EvaluationId = this.EvaluationId;
            context.EvaluationName = this.EvaluationName;
            context.MLModelId = this.MLModelId;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EvaluationId;
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
        
        private static Amazon.MachineLearning.Model.CreateEvaluationResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateEvaluationRequest request)
        {
            #if DESKTOP
            return client.CreateEvaluation(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateEvaluationAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String EvaluationDataSourceId { get; set; }
            public System.String EvaluationId { get; set; }
            public System.String EvaluationName { get; set; }
            public System.String MLModelId { get; set; }
        }
        
    }
}
