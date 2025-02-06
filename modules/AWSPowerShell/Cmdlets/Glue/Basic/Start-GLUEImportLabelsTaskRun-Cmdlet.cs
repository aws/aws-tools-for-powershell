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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Enables you to provide additional labels (examples of truth) to be used to teach the
    /// machine learning transform and improve its quality. This API operation is generally
    /// used as part of the active learning workflow that starts with the <c>StartMLLabelingSetGenerationTaskRun</c>
    /// call and that ultimately results in improving the quality of your machine learning
    /// transform. 
    /// 
    ///  
    /// <para>
    /// After the <c>StartMLLabelingSetGenerationTaskRun</c> finishes, Glue machine learning
    /// will have generated a series of questions for humans to answer. (Answering these questions
    /// is often called 'labeling' in the machine learning workflows). In the case of the
    /// <c>FindMatches</c> transform, these questions are of the form, “What is the correct
    /// way to group these rows together into groups composed entirely of matching records?”
    /// After the labeling process is finished, users upload their answers/labels with a call
    /// to <c>StartImportLabelsTaskRun</c>. After <c>StartImportLabelsTaskRun</c> finishes,
    /// all future runs of the machine learning transform use the new and improved labels
    /// and perform a higher-quality transformation.
    /// </para><para>
    /// By default, <c>StartMLLabelingSetGenerationTaskRun</c> continually learns from and
    /// combines all labels that you upload unless you set <c>Replace</c> to true. If you
    /// set <c>Replace</c> to true, <c>StartImportLabelsTaskRun</c> deletes and forgets all
    /// previously uploaded labels and learns only from the exact set that you upload. Replacing
    /// labels can be helpful if you realize that you previously uploaded incorrect labels,
    /// and you believe that they are having a negative effect on your transform quality.
    /// </para><para>
    /// You can check on the status of your task run by calling the <c>GetMLTaskRun</c> operation.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "GLUEImportLabelsTaskRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue StartImportLabelsTaskRun API operation.", Operation = new[] {"StartImportLabelsTaskRun"}, SelectReturnType = typeof(Amazon.Glue.Model.StartImportLabelsTaskRunResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.StartImportLabelsTaskRunResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.StartImportLabelsTaskRunResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartGLUEImportLabelsTaskRunCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InputS3Path
        /// <summary>
        /// <para>
        /// <para>The Amazon Simple Storage Service (Amazon S3) path from where you import the labels.</para>
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
        public System.String InputS3Path { get; set; }
        #endregion
        
        #region Parameter ReplaceAllLabel
        /// <summary>
        /// <para>
        /// <para>Indicates whether to overwrite your existing labels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplaceAllLabels")]
        public System.Boolean? ReplaceAllLabel { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.StartImportLabelsTaskRunResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.StartImportLabelsTaskRunResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransformId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GLUEImportLabelsTaskRun (StartImportLabelsTaskRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.StartImportLabelsTaskRunResponse, StartGLUEImportLabelsTaskRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InputS3Path = this.InputS3Path;
            #if MODULAR
            if (this.InputS3Path == null && ParameterWasBound(nameof(this.InputS3Path)))
            {
                WriteWarning("You are passing $null as a value for parameter InputS3Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplaceAllLabel = this.ReplaceAllLabel;
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
            var request = new Amazon.Glue.Model.StartImportLabelsTaskRunRequest();
            
            if (cmdletContext.InputS3Path != null)
            {
                request.InputS3Path = cmdletContext.InputS3Path;
            }
            if (cmdletContext.ReplaceAllLabel != null)
            {
                request.ReplaceAllLabels = cmdletContext.ReplaceAllLabel.Value;
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
        
        private Amazon.Glue.Model.StartImportLabelsTaskRunResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.StartImportLabelsTaskRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "StartImportLabelsTaskRun");
            try
            {
                #if DESKTOP
                return client.StartImportLabelsTaskRun(request);
                #elif CORECLR
                return client.StartImportLabelsTaskRunAsync(request).GetAwaiter().GetResult();
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
            public System.String InputS3Path { get; set; }
            public System.Boolean? ReplaceAllLabel { get; set; }
            public System.String TransformId { get; set; }
            public System.Func<Amazon.Glue.Model.StartImportLabelsTaskRunResponse, StartGLUEImportLabelsTaskRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskRunId;
        }
        
    }
}
