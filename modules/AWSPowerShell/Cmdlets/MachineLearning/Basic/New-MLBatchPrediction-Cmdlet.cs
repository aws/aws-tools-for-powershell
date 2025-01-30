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
    /// Generates predictions for a group of observations. The observations to process exist
    /// in one or more data files referenced by a <c>DataSource</c>. This operation creates
    /// a new <c>BatchPrediction</c>, and uses an <c>MLModel</c> and the data files referenced
    /// by the <c>DataSource</c> as information sources. 
    /// 
    ///  
    /// <para><c>CreateBatchPrediction</c> is an asynchronous operation. In response to <c>CreateBatchPrediction</c>,
    /// Amazon Machine Learning (Amazon ML) immediately returns and sets the <c>BatchPrediction</c>
    /// status to <c>PENDING</c>. After the <c>BatchPrediction</c> completes, Amazon ML sets
    /// the status to <c>COMPLETED</c>. 
    /// </para><para>
    /// You can poll for status updates by using the <a>GetBatchPrediction</a> operation and
    /// checking the <c>Status</c> parameter of the result. After the <c>COMPLETED</c> status
    /// appears, the results are available in the location specified by the <c>OutputUri</c>
    /// parameter.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLBatchPrediction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Machine Learning CreateBatchPrediction API operation.", Operation = new[] {"CreateBatchPrediction"}, SelectReturnType = typeof(Amazon.MachineLearning.Model.CreateBatchPredictionResponse))]
    [AWSCmdletOutput("System.String or Amazon.MachineLearning.Model.CreateBatchPredictionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MachineLearning.Model.CreateBatchPredictionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMLBatchPredictionCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BatchPredictionDataSourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the <c>DataSource</c> that points to the group of observations to predict.</para>
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
        public System.String BatchPredictionDataSourceId { get; set; }
        #endregion
        
        #region Parameter BatchPredictionId
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <c>BatchPrediction</c>.</para>
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
        public System.String BatchPredictionId { get; set; }
        #endregion
        
        #region Parameter BatchPredictionName
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <c>BatchPrediction</c>. <c>BatchPredictionName</c>
        /// can only use the UTF-8 character set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Name")]
        public System.String BatchPredictionName { get; set; }
        #endregion
        
        #region Parameter MLModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the <c>MLModel</c> that will generate predictions for the group of observations.
        /// </para>
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
        
        #region Parameter OutputUri
        /// <summary>
        /// <para>
        /// <para>The location of an Amazon Simple Storage Service (Amazon S3) bucket or directory to
        /// store the batch prediction results. The following substrings are not allowed in the
        /// <c>s3 key</c> portion of the <c>outputURI</c> field: ':', '//', '/./', '/../'.</para><para>Amazon ML needs permissions to store and retrieve the logs on your behalf. For information
        /// about how to set permissions, see the <a href="https://docs.aws.amazon.com/machine-learning/latest/dg">Amazon
        /// Machine Learning Developer Guide</a>.</para>
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
        public System.String OutputUri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BatchPredictionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MachineLearning.Model.CreateBatchPredictionResponse).
        /// Specifying the name of a property of type Amazon.MachineLearning.Model.CreateBatchPredictionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BatchPredictionId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLBatchPrediction (CreateBatchPrediction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MachineLearning.Model.CreateBatchPredictionResponse, NewMLBatchPredictionCmdlet>(Select) ??
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
            context.BatchPredictionDataSourceId = this.BatchPredictionDataSourceId;
            #if MODULAR
            if (this.BatchPredictionDataSourceId == null && ParameterWasBound(nameof(this.BatchPredictionDataSourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter BatchPredictionDataSourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BatchPredictionId = this.BatchPredictionId;
            #if MODULAR
            if (this.BatchPredictionId == null && ParameterWasBound(nameof(this.BatchPredictionId)))
            {
                WriteWarning("You are passing $null as a value for parameter BatchPredictionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BatchPredictionName = this.BatchPredictionName;
            context.MLModelId = this.MLModelId;
            #if MODULAR
            if (this.MLModelId == null && ParameterWasBound(nameof(this.MLModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter MLModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputUri = this.OutputUri;
            #if MODULAR
            if (this.OutputUri == null && ParameterWasBound(nameof(this.OutputUri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
        
        private Amazon.MachineLearning.Model.CreateBatchPredictionResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateBatchPredictionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "CreateBatchPrediction");
            try
            {
                #if DESKTOP
                return client.CreateBatchPrediction(request);
                #elif CORECLR
                return client.CreateBatchPredictionAsync(request).GetAwaiter().GetResult();
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
            public System.String BatchPredictionDataSourceId { get; set; }
            public System.String BatchPredictionId { get; set; }
            public System.String BatchPredictionName { get; set; }
            public System.String MLModelId { get; set; }
            public System.String OutputUri { get; set; }
            public System.Func<Amazon.MachineLearning.Model.CreateBatchPredictionResponse, NewMLBatchPredictionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BatchPredictionId;
        }
        
    }
}
