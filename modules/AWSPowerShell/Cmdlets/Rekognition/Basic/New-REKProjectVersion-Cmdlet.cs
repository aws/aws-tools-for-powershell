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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Creates a new version of Amazon Rekognition project (like a Custom Labels model or
    /// a custom adapter) and begins training. Models and adapters are managed as part of
    /// a Rekognition project. The response from <c>CreateProjectVersion</c> is an Amazon
    /// Resource Name (ARN) for the project version. 
    /// 
    ///  
    /// <para>
    /// The FeatureConfig operation argument allows you to configure specific model or adapter
    /// settings. You can provide a description to the project version by using the VersionDescription
    /// argment. Training can take a while to complete. You can get the current status by
    /// calling <a>DescribeProjectVersions</a>. Training completed successfully if the value
    /// of the <c>Status</c> field is <c>TRAINING_COMPLETED</c>. Once training has successfully
    /// completed, call <a>DescribeProjectVersions</a> to get the training results and evaluate
    /// the model.
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:CreateProjectVersion</c>
    /// action.
    /// </para><note><para><i>The following applies only to projects with Amazon Rekognition Custom Labels as
    /// the chosen feature:</i></para><para>
    /// You can train a model in a project that doesn't have associated datasets by specifying
    /// manifest files in the <c>TrainingData</c> and <c>TestingData</c> fields. 
    /// </para><para>
    /// If you open the console after training a model with manifest files, Amazon Rekognition
    /// Custom Labels creates the datasets for you using the most recent manifest files. You
    /// can no longer train a model version for the project by specifying manifest files.
    /// 
    /// </para><para>
    /// Instead of training with a project without associated datasets, we recommend that
    /// you use the manifest files to create training and test datasets for the project.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "REKProjectVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition CreateProjectVersion API operation.", Operation = new[] {"CreateProjectVersion"}, SelectReturnType = typeof(Amazon.Rekognition.Model.CreateProjectVersionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.CreateProjectVersionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.CreateProjectVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewREKProjectVersionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TestingData_Asset
        /// <summary>
        /// <para>
        /// <para>The assets used for testing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestingData_Assets")]
        public Amazon.Rekognition.Model.Asset[] TestingData_Asset { get; set; }
        #endregion
        
        #region Parameter TrainingData_Asset
        /// <summary>
        /// <para>
        /// <para>A manifest file that contains references to the training images and ground-truth annotations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingData_Assets")]
        public Amazon.Rekognition.Model.Asset[] TrainingData_Asset { get; set; }
        #endregion
        
        #region Parameter TestingData_AutoCreate
        /// <summary>
        /// <para>
        /// <para>If specified, Rekognition splits training dataset to create a test dataset for the
        /// training job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TestingData_AutoCreate { get; set; }
        #endregion
        
        #region Parameter ContentModeration_ConfidenceThreshold
        /// <summary>
        /// <para>
        /// <para>The confidence level you plan to use to identify if unsafe content is present during
        /// inference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FeatureConfig_ContentModeration_ConfidenceThreshold")]
        public System.Single? ContentModeration_ConfidenceThreshold { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier for your AWS Key Management Service key (AWS KMS key). You can supply
        /// the Amazon Resource Name (ARN) of your KMS key, the ID of your KMS key, an alias for
        /// your KMS key, or an alias ARN. The key is used to encrypt training images, test images,
        /// and manifest files copied into the service for the project version. Your source images
        /// are unaffected. The key is also used to encrypt training results and manifest files
        /// written to the output Amazon S3 bucket (<c>OutputConfig</c>).</para><para>If you choose to use your own KMS key, you need the following permissions on the KMS
        /// key.</para><ul><li><para>kms:CreateGrant</para></li><li><para>kms:DescribeKey</para></li><li><para>kms:GenerateDataKey</para></li><li><para>kms:Decrypt</para></li></ul><para>If you don't specify a value for <c>KmsKeyId</c>, images copied into the service are
        /// encrypted using a key that AWS owns and manages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Rekognition project that will manage the project version you
        /// want to train.</para>
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
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket where training output is placed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3Bucket { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix applied to the training output files. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A set of tags (key-value pairs) that you want to attach to the project version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>A description applied to the project version being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para>A name for the version of the project version. This value must be unique.</para>
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
        public System.String VersionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProjectVersionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.CreateProjectVersionResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.CreateProjectVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProjectVersionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VersionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VersionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VersionName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VersionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-REKProjectVersion (CreateProjectVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.CreateProjectVersionResponse, NewREKProjectVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VersionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContentModeration_ConfidenceThreshold = this.ContentModeration_ConfidenceThreshold;
            context.KmsKeyId = this.KmsKeyId;
            context.OutputConfig_S3Bucket = this.OutputConfig_S3Bucket;
            context.OutputConfig_S3KeyPrefix = this.OutputConfig_S3KeyPrefix;
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.TestingData_Asset != null)
            {
                context.TestingData_Asset = new List<Amazon.Rekognition.Model.Asset>(this.TestingData_Asset);
            }
            context.TestingData_AutoCreate = this.TestingData_AutoCreate;
            if (this.TrainingData_Asset != null)
            {
                context.TrainingData_Asset = new List<Amazon.Rekognition.Model.Asset>(this.TrainingData_Asset);
            }
            context.VersionDescription = this.VersionDescription;
            context.VersionName = this.VersionName;
            #if MODULAR
            if (this.VersionName == null && ParameterWasBound(nameof(this.VersionName)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Rekognition.Model.CreateProjectVersionRequest();
            
            
             // populate FeatureConfig
            var requestFeatureConfigIsNull = true;
            request.FeatureConfig = new Amazon.Rekognition.Model.CustomizationFeatureConfig();
            Amazon.Rekognition.Model.CustomizationFeatureContentModerationConfig requestFeatureConfig_featureConfig_ContentModeration = null;
            
             // populate ContentModeration
            var requestFeatureConfig_featureConfig_ContentModerationIsNull = true;
            requestFeatureConfig_featureConfig_ContentModeration = new Amazon.Rekognition.Model.CustomizationFeatureContentModerationConfig();
            System.Single? requestFeatureConfig_featureConfig_ContentModeration_contentModeration_ConfidenceThreshold = null;
            if (cmdletContext.ContentModeration_ConfidenceThreshold != null)
            {
                requestFeatureConfig_featureConfig_ContentModeration_contentModeration_ConfidenceThreshold = cmdletContext.ContentModeration_ConfidenceThreshold.Value;
            }
            if (requestFeatureConfig_featureConfig_ContentModeration_contentModeration_ConfidenceThreshold != null)
            {
                requestFeatureConfig_featureConfig_ContentModeration.ConfidenceThreshold = requestFeatureConfig_featureConfig_ContentModeration_contentModeration_ConfidenceThreshold.Value;
                requestFeatureConfig_featureConfig_ContentModerationIsNull = false;
            }
             // determine if requestFeatureConfig_featureConfig_ContentModeration should be set to null
            if (requestFeatureConfig_featureConfig_ContentModerationIsNull)
            {
                requestFeatureConfig_featureConfig_ContentModeration = null;
            }
            if (requestFeatureConfig_featureConfig_ContentModeration != null)
            {
                request.FeatureConfig.ContentModeration = requestFeatureConfig_featureConfig_ContentModeration;
                requestFeatureConfigIsNull = false;
            }
             // determine if request.FeatureConfig should be set to null
            if (requestFeatureConfigIsNull)
            {
                request.FeatureConfig = null;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.Rekognition.Model.OutputConfig();
            System.String requestOutputConfig_outputConfig_S3Bucket = null;
            if (cmdletContext.OutputConfig_S3Bucket != null)
            {
                requestOutputConfig_outputConfig_S3Bucket = cmdletContext.OutputConfig_S3Bucket;
            }
            if (requestOutputConfig_outputConfig_S3Bucket != null)
            {
                request.OutputConfig.S3Bucket = requestOutputConfig_outputConfig_S3Bucket;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3KeyPrefix = null;
            if (cmdletContext.OutputConfig_S3KeyPrefix != null)
            {
                requestOutputConfig_outputConfig_S3KeyPrefix = cmdletContext.OutputConfig_S3KeyPrefix;
            }
            if (requestOutputConfig_outputConfig_S3KeyPrefix != null)
            {
                request.OutputConfig.S3KeyPrefix = requestOutputConfig_outputConfig_S3KeyPrefix;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TestingData
            var requestTestingDataIsNull = true;
            request.TestingData = new Amazon.Rekognition.Model.TestingData();
            List<Amazon.Rekognition.Model.Asset> requestTestingData_testingData_Asset = null;
            if (cmdletContext.TestingData_Asset != null)
            {
                requestTestingData_testingData_Asset = cmdletContext.TestingData_Asset;
            }
            if (requestTestingData_testingData_Asset != null)
            {
                request.TestingData.Assets = requestTestingData_testingData_Asset;
                requestTestingDataIsNull = false;
            }
            System.Boolean? requestTestingData_testingData_AutoCreate = null;
            if (cmdletContext.TestingData_AutoCreate != null)
            {
                requestTestingData_testingData_AutoCreate = cmdletContext.TestingData_AutoCreate.Value;
            }
            if (requestTestingData_testingData_AutoCreate != null)
            {
                request.TestingData.AutoCreate = requestTestingData_testingData_AutoCreate.Value;
                requestTestingDataIsNull = false;
            }
             // determine if request.TestingData should be set to null
            if (requestTestingDataIsNull)
            {
                request.TestingData = null;
            }
            
             // populate TrainingData
            var requestTrainingDataIsNull = true;
            request.TrainingData = new Amazon.Rekognition.Model.TrainingData();
            List<Amazon.Rekognition.Model.Asset> requestTrainingData_trainingData_Asset = null;
            if (cmdletContext.TrainingData_Asset != null)
            {
                requestTrainingData_trainingData_Asset = cmdletContext.TrainingData_Asset;
            }
            if (requestTrainingData_trainingData_Asset != null)
            {
                request.TrainingData.Assets = requestTrainingData_trainingData_Asset;
                requestTrainingDataIsNull = false;
            }
             // determine if request.TrainingData should be set to null
            if (requestTrainingDataIsNull)
            {
                request.TrainingData = null;
            }
            if (cmdletContext.VersionDescription != null)
            {
                request.VersionDescription = cmdletContext.VersionDescription;
            }
            if (cmdletContext.VersionName != null)
            {
                request.VersionName = cmdletContext.VersionName;
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
        
        private Amazon.Rekognition.Model.CreateProjectVersionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.CreateProjectVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "CreateProjectVersion");
            try
            {
                #if DESKTOP
                return client.CreateProjectVersion(request);
                #elif CORECLR
                return client.CreateProjectVersionAsync(request).GetAwaiter().GetResult();
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
            public System.Single? ContentModeration_ConfidenceThreshold { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String OutputConfig_S3Bucket { get; set; }
            public System.String OutputConfig_S3KeyPrefix { get; set; }
            public System.String ProjectArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.Rekognition.Model.Asset> TestingData_Asset { get; set; }
            public System.Boolean? TestingData_AutoCreate { get; set; }
            public List<Amazon.Rekognition.Model.Asset> TrainingData_Asset { get; set; }
            public System.String VersionDescription { get; set; }
            public System.String VersionName { get; set; }
            public System.Func<Amazon.Rekognition.Model.CreateProjectVersionResponse, NewREKProjectVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProjectVersionArn;
        }
        
    }
}
