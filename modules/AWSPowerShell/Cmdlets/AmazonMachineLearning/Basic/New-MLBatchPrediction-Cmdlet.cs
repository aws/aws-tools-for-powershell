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
    /// Generates predictions for a group of observations. The observations to process exist
    /// in one or more data files referenced by a <code>DataSource</code>. This operation
    /// creates a new <code>BatchPrediction</code>, and uses an <code>MLModel</code> and the
    /// data files referenced by the <code>DataSource</code> as information sources. 
    /// 
    ///  
    /// <para><code>CreateBatchPrediction</code> is an asynchronous operation. In response to <code>CreateBatchPrediction</code>,
    /// Amazon Machine Learning (Amazon ML) immediately returns and sets the <code>BatchPrediction</code>
    /// status to <code>PENDING</code>. After the <code>BatchPrediction</code> completes,
    /// Amazon ML sets the status to <code>COMPLETED</code>. 
    /// </para><para>
    /// You can poll for status updates by using the <a>GetBatchPrediction</a> operation and
    /// checking the <code>Status</code> parameter of the result. After the <code>COMPLETED</code>
    /// status appears, the results are available in the location specified by the <code>OutputUri</code>
    /// parameter.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLBatchPrediction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateBatchPrediction operation against Amazon Machine Learning.", Operation = new[] {"CreateBatchPrediction"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.MachineLearning.Model.CreateBatchPredictionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMLBatchPredictionCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter BatchPredictionDataSourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the <code>DataSource</code> that points to the group of observations to
        /// predict.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BatchPredictionDataSourceId { get; set; }
        #endregion
        
        #region Parameter BatchPredictionId
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <code>BatchPrediction</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BatchPredictionId { get; set; }
        #endregion
        
        #region Parameter BatchPredictionName
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <code>BatchPrediction</code>. <code>BatchPredictionName</code>
        /// can only use the UTF-8 character set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Name")]
        public System.String BatchPredictionName { get; set; }
        #endregion
        
        #region Parameter MLModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the <code>MLModel</code> that will generate predictions for the group of
        /// observations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ModelId")]
        public System.String MLModelId { get; set; }
        #endregion
        
        #region Parameter OutputUri
        /// <summary>
        /// <para>
        /// <para>The location of an Amazon Simple Storage Service (Amazon S3) bucket or directory to
        /// store the batch prediction results. The following substrings are not allowed in the
        /// <code>s3 key</code> portion of the <code>outputURI</code> field: ':', '//', '/./',
        /// '/../'.</para><para>Amazon ML needs permissions to store and retrieve the logs on your behalf. For information
        /// about how to set permissions, see the <a href="http://docs.aws.amazon.com/machine-learning/latest/dg">Amazon
        /// Machine Learning Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputUri { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLBatchPrediction (CreateBatchPrediction)"))
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
            
            context.BatchPredictionDataSourceId = this.BatchPredictionDataSourceId;
            context.BatchPredictionId = this.BatchPredictionId;
            context.BatchPredictionName = this.BatchPredictionName;
            context.MLModelId = this.MLModelId;
            context.OutputUri = this.OutputUri;
            
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
            var request = new Amazon.MachineLearning.Model.CreateBatchPredictionRequest();
            
            if (cmdletContext.BatchPredictionDataSourceId != null)
            {
                request.BatchPredictionDataSourceId = cmdletContext.BatchPredictionDataSourceId;
            }
            if (cmdletContext.BatchPredictionId != null)
            {
                request.BatchPredictionId = cmdletContext.BatchPredictionId;
            }
            if (cmdletContext.BatchPredictionName != null)
            {
                request.BatchPredictionName = cmdletContext.BatchPredictionName;
            }
            if (cmdletContext.MLModelId != null)
            {
                request.MLModelId = cmdletContext.MLModelId;
            }
            if (cmdletContext.OutputUri != null)
            {
                request.OutputUri = cmdletContext.OutputUri;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.BatchPredictionId;
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
        
        private Amazon.MachineLearning.Model.CreateBatchPredictionResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateBatchPredictionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "CreateBatchPrediction");
            #if DESKTOP
            return client.CreateBatchPrediction(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateBatchPredictionAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String BatchPredictionDataSourceId { get; set; }
            public System.String BatchPredictionId { get; set; }
            public System.String BatchPredictionName { get; set; }
            public System.String MLModelId { get; set; }
            public System.String OutputUri { get; set; }
        }
        
    }
}
