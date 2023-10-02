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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates an inference experiment using the configurations specified in the request.
    /// 
    /// 
    ///  
    /// <para>
    ///  Use this API to setup and schedule an experiment to compare model variants on a Amazon
    /// SageMaker inference endpoint. For more information about inference experiments, see
    /// <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/shadow-tests.html">Shadow
    /// tests</a>. 
    /// </para><para>
    ///  Amazon SageMaker begins your experiment at the scheduled time and routes traffic
    /// to your endpoint's model variants based on your specified configuration. 
    /// </para><para>
    ///  While the experiment is in progress or after it has concluded, you can view metrics
    /// that compare your model variants. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/shadow-tests-view-monitor-edit.html">View,
    /// monitor, and edit shadow tests</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMInferenceExperiment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateInferenceExperiment API operation.", Operation = new[] {"CreateInferenceExperiment"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateInferenceExperimentResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateInferenceExperimentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateInferenceExperimentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMInferenceExperimentCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContentType_CsvContentType
        /// <summary>
        /// <para>
        /// <para>The list of all content type headers that Amazon SageMaker will treat as CSV and capture
        /// accordingly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataStorageConfig_ContentType_CsvContentTypes")]
        public System.String[] ContentType_CsvContentType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the inference experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DataStorageConfig_Destination
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket where the inference request and response data is stored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataStorageConfig_Destination { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para> The name of the Amazon SageMaker endpoint on which you want to run the inference
        /// experiment. </para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter Schedule_EndTime
        /// <summary>
        /// <para>
        /// <para>The timestamp at which the inference experiment ended or will end.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Schedule_EndTime { get; set; }
        #endregion
        
        #region Parameter ContentType_JsonContentType
        /// <summary>
        /// <para>
        /// <para>The list of all content type headers that SageMaker will treat as JSON and capture
        /// accordingly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataStorageConfig_ContentType_JsonContentTypes")]
        public System.String[] ContentType_JsonContentType { get; set; }
        #endregion
        
        #region Parameter DataStorageConfig_KmsKey
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services Key Management Service key that Amazon SageMaker uses to
        /// encrypt captured data at rest using Amazon S3 server-side encryption. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataStorageConfig_KmsKey { get; set; }
        #endregion
        
        #region Parameter KmsKey
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// Amazon SageMaker uses to encrypt data on the storage volume attached to the ML compute
        /// instance that hosts the endpoint. The <code>KmsKey</code> can be any of the following
        /// formats: </para><ul><li><para>KMS key ID</para><para><code>"1234abcd-12ab-34cd-56ef-1234567890ab"</code></para></li><li><para>Amazon Resource Name (ARN) of a KMS key</para><para><code>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</code></para></li><li><para>KMS key Alias</para><para><code>"alias/ExampleAlias"</code></para></li><li><para>Amazon Resource Name (ARN) of a KMS key Alias</para><para><code>"arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias"</code></para></li></ul><para> If you use a KMS key ID or an alias of your KMS key, the Amazon SageMaker execution
        /// role must include permissions to call <code>kms:Encrypt</code>. If you don't provide
        /// a KMS key ID, Amazon SageMaker uses the default KMS key for Amazon S3 for your role's
        /// account. Amazon SageMaker uses server-side encryption with KMS managed keys for <code>OutputDataConfig</code>.
        /// If you use a bucket policy with an <code>s3:PutObject</code> permission that only
        /// allows objects with server-side encryption, set the condition key of <code>s3:x-amz-server-side-encryption</code>
        /// to <code>"aws:kms"</code>. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingKMSEncryption.html">KMS
        /// managed Encryption Keys</a> in the <i>Amazon Simple Storage Service Developer Guide.</i></para><para> The KMS key policy must grant permission to the IAM role that you specify in your
        /// <code>CreateEndpoint</code> and <code>UpdateEndpoint</code> requests. For more information,
        /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">Using
        /// Key Policies in Amazon Web Services KMS</a> in the <i>Amazon Web Services Key Management
        /// Service Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKey { get; set; }
        #endregion
        
        #region Parameter ModelVariant
        /// <summary>
        /// <para>
        /// <para> An array of <code>ModelVariantConfig</code> objects. There is one for each variant
        /// in the inference experiment. Each <code>ModelVariantConfig</code> object in the array
        /// describes the infrastructure configuration for the corresponding variant. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ModelVariants")]
        public Amazon.SageMaker.Model.ModelVariantConfig[] ModelVariant { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the inference experiment.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the IAM role that Amazon SageMaker can assume to access model artifacts
        /// and container images, and manage Amazon SageMaker Inference endpoints for model deployment.
        /// </para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter ShadowModeConfig_ShadowModelVariant
        /// <summary>
        /// <para>
        /// <para>List of shadow variant configurations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ShadowModeConfig_ShadowModelVariants")]
        public Amazon.SageMaker.Model.ShadowModelVariantConfig[] ShadowModeConfig_ShadowModelVariant { get; set; }
        #endregion
        
        #region Parameter ShadowModeConfig_SourceModelVariantName
        /// <summary>
        /// <para>
        /// <para> The name of the production variant, which takes all the inference requests. </para>
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
        public System.String ShadowModeConfig_SourceModelVariantName { get; set; }
        #endregion
        
        #region Parameter Schedule_StartTime
        /// <summary>
        /// <para>
        /// <para>The timestamp at which the inference experiment started or will start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Schedule_StartTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> Array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/ARG/latest/userguide/tagging.html">Tagging
        /// your Amazon Web Services Resources</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para> The type of the inference experiment that you want to run. The following types of
        /// experiments are possible: </para><ul><li><para><code>ShadowMode</code>: You can use this type to validate a shadow variant. For
        /// more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/shadow-tests.html">Shadow
        /// tests</a>. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.InferenceExperimentType")]
        public Amazon.SageMaker.InferenceExperimentType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InferenceExperimentArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateInferenceExperimentResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateInferenceExperimentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InferenceExperimentArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMInferenceExperiment (CreateInferenceExperiment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateInferenceExperimentResponse, NewSMInferenceExperimentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ContentType_CsvContentType != null)
            {
                context.ContentType_CsvContentType = new List<System.String>(this.ContentType_CsvContentType);
            }
            if (this.ContentType_JsonContentType != null)
            {
                context.ContentType_JsonContentType = new List<System.String>(this.ContentType_JsonContentType);
            }
            context.DataStorageConfig_Destination = this.DataStorageConfig_Destination;
            context.DataStorageConfig_KmsKey = this.DataStorageConfig_KmsKey;
            context.Description = this.Description;
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKey = this.KmsKey;
            if (this.ModelVariant != null)
            {
                context.ModelVariant = new List<Amazon.SageMaker.Model.ModelVariantConfig>(this.ModelVariant);
            }
            #if MODULAR
            if (this.ModelVariant == null && ParameterWasBound(nameof(this.ModelVariant)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelVariant which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schedule_EndTime = this.Schedule_EndTime;
            context.Schedule_StartTime = this.Schedule_StartTime;
            if (this.ShadowModeConfig_ShadowModelVariant != null)
            {
                context.ShadowModeConfig_ShadowModelVariant = new List<Amazon.SageMaker.Model.ShadowModelVariantConfig>(this.ShadowModeConfig_ShadowModelVariant);
            }
            #if MODULAR
            if (this.ShadowModeConfig_ShadowModelVariant == null && ParameterWasBound(nameof(this.ShadowModeConfig_ShadowModelVariant)))
            {
                WriteWarning("You are passing $null as a value for parameter ShadowModeConfig_ShadowModelVariant which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShadowModeConfig_SourceModelVariantName = this.ShadowModeConfig_SourceModelVariantName;
            #if MODULAR
            if (this.ShadowModeConfig_SourceModelVariantName == null && ParameterWasBound(nameof(this.ShadowModeConfig_SourceModelVariantName)))
            {
                WriteWarning("You are passing $null as a value for parameter ShadowModeConfig_SourceModelVariantName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreateInferenceExperimentRequest();
            
            
             // populate DataStorageConfig
            var requestDataStorageConfigIsNull = true;
            request.DataStorageConfig = new Amazon.SageMaker.Model.InferenceExperimentDataStorageConfig();
            System.String requestDataStorageConfig_dataStorageConfig_Destination = null;
            if (cmdletContext.DataStorageConfig_Destination != null)
            {
                requestDataStorageConfig_dataStorageConfig_Destination = cmdletContext.DataStorageConfig_Destination;
            }
            if (requestDataStorageConfig_dataStorageConfig_Destination != null)
            {
                request.DataStorageConfig.Destination = requestDataStorageConfig_dataStorageConfig_Destination;
                requestDataStorageConfigIsNull = false;
            }
            System.String requestDataStorageConfig_dataStorageConfig_KmsKey = null;
            if (cmdletContext.DataStorageConfig_KmsKey != null)
            {
                requestDataStorageConfig_dataStorageConfig_KmsKey = cmdletContext.DataStorageConfig_KmsKey;
            }
            if (requestDataStorageConfig_dataStorageConfig_KmsKey != null)
            {
                request.DataStorageConfig.KmsKey = requestDataStorageConfig_dataStorageConfig_KmsKey;
                requestDataStorageConfigIsNull = false;
            }
            Amazon.SageMaker.Model.CaptureContentTypeHeader requestDataStorageConfig_dataStorageConfig_ContentType = null;
            
             // populate ContentType
            var requestDataStorageConfig_dataStorageConfig_ContentTypeIsNull = true;
            requestDataStorageConfig_dataStorageConfig_ContentType = new Amazon.SageMaker.Model.CaptureContentTypeHeader();
            List<System.String> requestDataStorageConfig_dataStorageConfig_ContentType_contentType_CsvContentType = null;
            if (cmdletContext.ContentType_CsvContentType != null)
            {
                requestDataStorageConfig_dataStorageConfig_ContentType_contentType_CsvContentType = cmdletContext.ContentType_CsvContentType;
            }
            if (requestDataStorageConfig_dataStorageConfig_ContentType_contentType_CsvContentType != null)
            {
                requestDataStorageConfig_dataStorageConfig_ContentType.CsvContentTypes = requestDataStorageConfig_dataStorageConfig_ContentType_contentType_CsvContentType;
                requestDataStorageConfig_dataStorageConfig_ContentTypeIsNull = false;
            }
            List<System.String> requestDataStorageConfig_dataStorageConfig_ContentType_contentType_JsonContentType = null;
            if (cmdletContext.ContentType_JsonContentType != null)
            {
                requestDataStorageConfig_dataStorageConfig_ContentType_contentType_JsonContentType = cmdletContext.ContentType_JsonContentType;
            }
            if (requestDataStorageConfig_dataStorageConfig_ContentType_contentType_JsonContentType != null)
            {
                requestDataStorageConfig_dataStorageConfig_ContentType.JsonContentTypes = requestDataStorageConfig_dataStorageConfig_ContentType_contentType_JsonContentType;
                requestDataStorageConfig_dataStorageConfig_ContentTypeIsNull = false;
            }
             // determine if requestDataStorageConfig_dataStorageConfig_ContentType should be set to null
            if (requestDataStorageConfig_dataStorageConfig_ContentTypeIsNull)
            {
                requestDataStorageConfig_dataStorageConfig_ContentType = null;
            }
            if (requestDataStorageConfig_dataStorageConfig_ContentType != null)
            {
                request.DataStorageConfig.ContentType = requestDataStorageConfig_dataStorageConfig_ContentType;
                requestDataStorageConfigIsNull = false;
            }
             // determine if request.DataStorageConfig should be set to null
            if (requestDataStorageConfigIsNull)
            {
                request.DataStorageConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.KmsKey != null)
            {
                request.KmsKey = cmdletContext.KmsKey;
            }
            if (cmdletContext.ModelVariant != null)
            {
                request.ModelVariants = cmdletContext.ModelVariant;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.SageMaker.Model.InferenceExperimentSchedule();
            System.DateTime? requestSchedule_schedule_EndTime = null;
            if (cmdletContext.Schedule_EndTime != null)
            {
                requestSchedule_schedule_EndTime = cmdletContext.Schedule_EndTime.Value;
            }
            if (requestSchedule_schedule_EndTime != null)
            {
                request.Schedule.EndTime = requestSchedule_schedule_EndTime.Value;
                requestScheduleIsNull = false;
            }
            System.DateTime? requestSchedule_schedule_StartTime = null;
            if (cmdletContext.Schedule_StartTime != null)
            {
                requestSchedule_schedule_StartTime = cmdletContext.Schedule_StartTime.Value;
            }
            if (requestSchedule_schedule_StartTime != null)
            {
                request.Schedule.StartTime = requestSchedule_schedule_StartTime.Value;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            
             // populate ShadowModeConfig
            var requestShadowModeConfigIsNull = true;
            request.ShadowModeConfig = new Amazon.SageMaker.Model.ShadowModeConfig();
            List<Amazon.SageMaker.Model.ShadowModelVariantConfig> requestShadowModeConfig_shadowModeConfig_ShadowModelVariant = null;
            if (cmdletContext.ShadowModeConfig_ShadowModelVariant != null)
            {
                requestShadowModeConfig_shadowModeConfig_ShadowModelVariant = cmdletContext.ShadowModeConfig_ShadowModelVariant;
            }
            if (requestShadowModeConfig_shadowModeConfig_ShadowModelVariant != null)
            {
                request.ShadowModeConfig.ShadowModelVariants = requestShadowModeConfig_shadowModeConfig_ShadowModelVariant;
                requestShadowModeConfigIsNull = false;
            }
            System.String requestShadowModeConfig_shadowModeConfig_SourceModelVariantName = null;
            if (cmdletContext.ShadowModeConfig_SourceModelVariantName != null)
            {
                requestShadowModeConfig_shadowModeConfig_SourceModelVariantName = cmdletContext.ShadowModeConfig_SourceModelVariantName;
            }
            if (requestShadowModeConfig_shadowModeConfig_SourceModelVariantName != null)
            {
                request.ShadowModeConfig.SourceModelVariantName = requestShadowModeConfig_shadowModeConfig_SourceModelVariantName;
                requestShadowModeConfigIsNull = false;
            }
             // determine if request.ShadowModeConfig should be set to null
            if (requestShadowModeConfigIsNull)
            {
                request.ShadowModeConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.SageMaker.Model.CreateInferenceExperimentResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateInferenceExperimentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateInferenceExperiment");
            try
            {
                #if DESKTOP
                return client.CreateInferenceExperiment(request);
                #elif CORECLR
                return client.CreateInferenceExperimentAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ContentType_CsvContentType { get; set; }
            public List<System.String> ContentType_JsonContentType { get; set; }
            public System.String DataStorageConfig_Destination { get; set; }
            public System.String DataStorageConfig_KmsKey { get; set; }
            public System.String Description { get; set; }
            public System.String EndpointName { get; set; }
            public System.String KmsKey { get; set; }
            public List<Amazon.SageMaker.Model.ModelVariantConfig> ModelVariant { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.DateTime? Schedule_EndTime { get; set; }
            public System.DateTime? Schedule_StartTime { get; set; }
            public List<Amazon.SageMaker.Model.ShadowModelVariantConfig> ShadowModeConfig_ShadowModelVariant { get; set; }
            public System.String ShadowModeConfig_SourceModelVariantName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public Amazon.SageMaker.InferenceExperimentType Type { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateInferenceExperimentResponse, NewSMInferenceExperimentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InferenceExperimentArn;
        }
        
    }
}
