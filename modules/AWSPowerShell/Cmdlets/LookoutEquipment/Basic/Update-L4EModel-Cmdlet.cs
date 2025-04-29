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
using Amazon.LookoutEquipment;
using Amazon.LookoutEquipment.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.L4E
{
    /// <summary>
    /// Updates a model in the account.
    /// </summary>
    [Cmdlet("Update", "L4EModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment UpdateModel API operation.", Operation = new[] {"UpdateModel"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.UpdateModelResponse))]
    [AWSCmdletOutput("None or Amazon.LookoutEquipment.Model.UpdateModelResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LookoutEquipment.Model.UpdateModelResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateL4EModelCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3InputConfiguration_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket holding the label data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LabelsInputConfiguration_S3InputConfiguration_Bucket")]
        public System.String S3InputConfiguration_Bucket { get; set; }
        #endregion
        
        #region Parameter S3OutputConfiguration_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where the pointwise model diagnostics are located.
        /// You must be the owner of the Amazon S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelDiagnosticsOutputConfiguration_S3OutputConfiguration_Bucket")]
        public System.String S3OutputConfiguration_Bucket { get; set; }
        #endregion
        
        #region Parameter ModelDiagnosticsOutputConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (KMS) key identifier to encrypt the
        /// pointwise model diagnostics files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelDiagnosticsOutputConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LabelsInputConfiguration_LabelGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the label group to be used for label data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LabelsInputConfiguration_LabelGroupName { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the model to update.</para>
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
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter S3InputConfiguration_Prefix
        /// <summary>
        /// <para>
        /// <para> The prefix for the S3 bucket used for the label data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LabelsInputConfiguration_S3InputConfiguration_Prefix")]
        public System.String S3InputConfiguration_Prefix { get; set; }
        #endregion
        
        #region Parameter S3OutputConfiguration_Prefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 prefix for the location of the pointwise model diagnostics. The prefix
        /// specifies the folder and evaluation result file name. (<c>bucket</c>).</para><para>When you call <c>CreateModel</c> or <c>UpdateModel</c>, specify the path within the
        /// bucket that you want Lookout for Equipment to save the model to. During training,
        /// Lookout for Equipment creates the model evaluation model as a compressed JSON file
        /// with the name <c>model_diagnostics_results.json.gz</c>.</para><para>When you call <c>DescribeModel</c> or <c>DescribeModelVersion</c>, <c>prefix</c> contains
        /// the file path and filename of the model evaluation file. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelDiagnosticsOutputConfiguration_S3OutputConfiguration_Prefix")]
        public System.String S3OutputConfiguration_Prefix { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the model to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.UpdateModelResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-L4EModel (UpdateModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.UpdateModelResponse, UpdateL4EModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LabelsInputConfiguration_LabelGroupName = this.LabelsInputConfiguration_LabelGroupName;
            context.S3InputConfiguration_Bucket = this.S3InputConfiguration_Bucket;
            context.S3InputConfiguration_Prefix = this.S3InputConfiguration_Prefix;
            context.ModelDiagnosticsOutputConfiguration_KmsKeyId = this.ModelDiagnosticsOutputConfiguration_KmsKeyId;
            context.S3OutputConfiguration_Bucket = this.S3OutputConfiguration_Bucket;
            context.S3OutputConfiguration_Prefix = this.S3OutputConfiguration_Prefix;
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.LookoutEquipment.Model.UpdateModelRequest();
            
            
             // populate LabelsInputConfiguration
            var requestLabelsInputConfigurationIsNull = true;
            request.LabelsInputConfiguration = new Amazon.LookoutEquipment.Model.LabelsInputConfiguration();
            System.String requestLabelsInputConfiguration_labelsInputConfiguration_LabelGroupName = null;
            if (cmdletContext.LabelsInputConfiguration_LabelGroupName != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_LabelGroupName = cmdletContext.LabelsInputConfiguration_LabelGroupName;
            }
            if (requestLabelsInputConfiguration_labelsInputConfiguration_LabelGroupName != null)
            {
                request.LabelsInputConfiguration.LabelGroupName = requestLabelsInputConfiguration_labelsInputConfiguration_LabelGroupName;
                requestLabelsInputConfigurationIsNull = false;
            }
            Amazon.LookoutEquipment.Model.LabelsS3InputConfiguration requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration = null;
            
             // populate S3InputConfiguration
            var requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfigurationIsNull = true;
            requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration = new Amazon.LookoutEquipment.Model.LabelsS3InputConfiguration();
            System.String requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket = null;
            if (cmdletContext.S3InputConfiguration_Bucket != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket = cmdletContext.S3InputConfiguration_Bucket;
            }
            if (requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration.Bucket = requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket;
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfigurationIsNull = false;
            }
            System.String requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix = null;
            if (cmdletContext.S3InputConfiguration_Prefix != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix = cmdletContext.S3InputConfiguration_Prefix;
            }
            if (requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration.Prefix = requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix;
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfigurationIsNull = false;
            }
             // determine if requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration should be set to null
            if (requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfigurationIsNull)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration = null;
            }
            if (requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration != null)
            {
                request.LabelsInputConfiguration.S3InputConfiguration = requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration;
                requestLabelsInputConfigurationIsNull = false;
            }
             // determine if request.LabelsInputConfiguration should be set to null
            if (requestLabelsInputConfigurationIsNull)
            {
                request.LabelsInputConfiguration = null;
            }
            
             // populate ModelDiagnosticsOutputConfiguration
            var requestModelDiagnosticsOutputConfigurationIsNull = true;
            request.ModelDiagnosticsOutputConfiguration = new Amazon.LookoutEquipment.Model.ModelDiagnosticsOutputConfiguration();
            System.String requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_KmsKeyId = null;
            if (cmdletContext.ModelDiagnosticsOutputConfiguration_KmsKeyId != null)
            {
                requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_KmsKeyId = cmdletContext.ModelDiagnosticsOutputConfiguration_KmsKeyId;
            }
            if (requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_KmsKeyId != null)
            {
                request.ModelDiagnosticsOutputConfiguration.KmsKeyId = requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_KmsKeyId;
                requestModelDiagnosticsOutputConfigurationIsNull = false;
            }
            Amazon.LookoutEquipment.Model.ModelDiagnosticsS3OutputConfiguration requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration = null;
            
             // populate S3OutputConfiguration
            var requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfigurationIsNull = true;
            requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration = new Amazon.LookoutEquipment.Model.ModelDiagnosticsS3OutputConfiguration();
            System.String requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Bucket = null;
            if (cmdletContext.S3OutputConfiguration_Bucket != null)
            {
                requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Bucket = cmdletContext.S3OutputConfiguration_Bucket;
            }
            if (requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Bucket != null)
            {
                requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration.Bucket = requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Bucket;
                requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfigurationIsNull = false;
            }
            System.String requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Prefix = null;
            if (cmdletContext.S3OutputConfiguration_Prefix != null)
            {
                requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Prefix = cmdletContext.S3OutputConfiguration_Prefix;
            }
            if (requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Prefix != null)
            {
                requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration.Prefix = requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Prefix;
                requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfigurationIsNull = false;
            }
             // determine if requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration should be set to null
            if (requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfigurationIsNull)
            {
                requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration = null;
            }
            if (requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration != null)
            {
                request.ModelDiagnosticsOutputConfiguration.S3OutputConfiguration = requestModelDiagnosticsOutputConfiguration_modelDiagnosticsOutputConfiguration_S3OutputConfiguration;
                requestModelDiagnosticsOutputConfigurationIsNull = false;
            }
             // determine if request.ModelDiagnosticsOutputConfiguration should be set to null
            if (requestModelDiagnosticsOutputConfigurationIsNull)
            {
                request.ModelDiagnosticsOutputConfiguration = null;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.LookoutEquipment.Model.UpdateModelResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.UpdateModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "UpdateModel");
            try
            {
                return client.UpdateModelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LabelsInputConfiguration_LabelGroupName { get; set; }
            public System.String S3InputConfiguration_Bucket { get; set; }
            public System.String S3InputConfiguration_Prefix { get; set; }
            public System.String ModelDiagnosticsOutputConfiguration_KmsKeyId { get; set; }
            public System.String S3OutputConfiguration_Bucket { get; set; }
            public System.String S3OutputConfiguration_Prefix { get; set; }
            public System.String ModelName { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.UpdateModelResponse, UpdateL4EModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
