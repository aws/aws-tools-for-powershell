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
using System.Threading;
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Starts the active learning workflow for your machine learning transform to improve
    /// the transform's quality by generating label sets and adding labels.
    /// 
    ///  
    /// <para>
    /// When the <c>StartMLLabelingSetGenerationTaskRun</c> finishes, Glue will have generated
    /// a "labeling set" or a set of questions for humans to answer.
    /// </para><para>
    /// In the case of the <c>FindMatches</c> transform, these questions are of the form,
    /// “What is the correct way to group these rows together into groups composed entirely
    /// of matching records?” 
    /// </para><para>
    /// After the labeling process is finished, you can upload your labels with a call to
    /// <c>StartImportLabelsTaskRun</c>. After <c>StartImportLabelsTaskRun</c> finishes, all
    /// future runs of the machine learning transform will use the new and improved labels
    /// and perform a higher-quality transformation.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "GLUEMLLabelingSetGenerationTaskRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue StartMLLabelingSetGenerationTaskRun API operation.", Operation = new[] {"StartMLLabelingSetGenerationTaskRun"}, SelectReturnType = typeof(Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartGLUEMLLabelingSetGenerationTaskRunCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OutputS3Path
        /// <summary>
        /// <para>
        /// <para>The Amazon Simple Storage Service (Amazon S3) path where you generate the labeling
        /// set.</para>
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
        public System.String OutputS3Path { get; set; }
        #endregion
        
        #region Parameter TransformId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the machine learning transform.</para>
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
        public System.String TransformId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskRunId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskRunId";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransformId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GLUEMLLabelingSetGenerationTaskRun (StartMLLabelingSetGenerationTaskRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunResponse, StartGLUEMLLabelingSetGenerationTaskRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OutputS3Path = this.OutputS3Path;
            #if MODULAR
            if (this.OutputS3Path == null && ParameterWasBound(nameof(this.OutputS3Path)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputS3Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransformId = this.TransformId;
            #if MODULAR
            if (this.TransformId == null && ParameterWasBound(nameof(this.TransformId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunRequest();
            
            if (cmdletContext.OutputS3Path != null)
            {
                request.OutputS3Path = cmdletContext.OutputS3Path;
            }
            if (cmdletContext.TransformId != null)
            {
                request.TransformId = cmdletContext.TransformId;
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
        
        private Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "StartMLLabelingSetGenerationTaskRun");
            try
            {
                return client.StartMLLabelingSetGenerationTaskRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String OutputS3Path { get; set; }
            public System.String TransformId { get; set; }
            public System.Func<Amazon.Glue.Model.StartMLLabelingSetGenerationTaskRunResponse, StartGLUEMLLabelingSetGenerationTaskRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskRunId;
        }
        
    }
}
