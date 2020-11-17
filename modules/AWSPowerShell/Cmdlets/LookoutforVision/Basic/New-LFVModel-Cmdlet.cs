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
using Amazon.LookoutforVision;
using Amazon.LookoutforVision.Model;

namespace Amazon.PowerShell.Cmdlets.LFV
{
    /// <summary>
    /// Creates a new version of a model within an an Amazon Lookout for Vision project. <code>CreateModel</code>
    /// is an asynchronous operation in which Amazon Lookout for Vision trains, tests, and
    /// evaluates a new version of a model. 
    /// 
    ///  
    /// <para>
    /// To get the current status, check the <code>Status</code> field returned in the response
    /// from <a>DescribeModel</a>.
    /// </para><para>
    /// If the project has a single dataset, Amazon Lookout for Vision internally splits the
    /// dataset to create a training and a test dataset. If the project has a training and
    /// a test dataset, Lookout for Vision uses the respective datasets to train and test
    /// the model. 
    /// </para><para>
    /// After training completes, the evaluation metrics are stored at the location specified
    /// in <code>OutputConfig</code>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "LFVModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutforVision.Model.ModelMetadata")]
    [AWSCmdlet("Calls the Amazon Lookout for Vision CreateModel API operation.", Operation = new[] {"CreateModel"}, SelectReturnType = typeof(Amazon.LookoutforVision.Model.CreateModelResponse))]
    [AWSCmdletOutput("Amazon.LookoutforVision.Model.ModelMetadata or Amazon.LookoutforVision.Model.CreateModelResponse",
        "This cmdlet returns an Amazon.LookoutforVision.Model.ModelMetadata object.",
        "The service call response (type Amazon.LookoutforVision.Model.CreateModelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLFVModelCmdlet : AmazonLookoutforVisionClientCmdlet, IExecutor
    {
        
        #region Parameter EvaluationManifest_Bucket
        /// <summary>
        /// <para>
        /// <para>The bucket that contains the training output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Description_EvaluationManifest_Bucket")]
        public System.String EvaluationManifest_Bucket { get; set; }
        #endregion
        
        #region Parameter EvaluationResult_Bucket
        /// <summary>
        /// <para>
        /// <para>The bucket that contains the training output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Description_EvaluationResult_Bucket")]
        public System.String EvaluationResult_Bucket { get; set; }
        #endregion
        
        #region Parameter S3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket that contain the manifest file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Description_OutputConfig_S3Location_Bucket")]
        public System.String S3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter Output_S3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket that contain the manifest file.</para>
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
        [Alias("OutputConfig_S3Location_Bucket")]
        public System.String Output_S3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter Description_CreationTimestamp
        /// <summary>
        /// <para>
        /// <para>The unix timestamp for the date and time that the model was created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Description_CreationTimestamp { get; set; }
        #endregion
        
        #region Parameter Description_Description
        /// <summary>
        /// <para>
        /// <para>The description for the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description_Description { get; set; }
        #endregion
        
        #region Parameter Description_EvaluationEndTimestamp
        /// <summary>
        /// <para>
        /// <para>The unix timestamp for the date and time that the evaluation ended. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Description_EvaluationEndTimestamp { get; set; }
        #endregion
        
        #region Parameter Performance_F1Score
        /// <summary>
        /// <para>
        /// <para>The overall F1 score metric for the trained model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Description_Performance_F1Score")]
        public System.Single? Performance_F1Score { get; set; }
        #endregion
        
        #region Parameter EvaluationManifest_Key
        /// <summary>
        /// <para>
        /// <para>The location of the training output in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Description_EvaluationManifest_Key")]
        public System.String EvaluationManifest_Key { get; set; }
        #endregion
        
        #region Parameter EvaluationResult_Key
        /// <summary>
        /// <para>
        /// <para>The location of the training output in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Description_EvaluationResult_Key")]
        public System.String EvaluationResult_Key { get; set; }
        #endregion
        
        #region Parameter Description_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifer for the AWS Key Management Service (AWS KMS) key that was used to encrypt
        /// the model during training.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the AWS Key Management Service (AWS KMS) customer master key (CMK)
        /// to use for encypting the model. If this parameter is not specified, the model is encrypted
        /// by a key that AWS owns and manages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Description_ModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description_ModelArn { get; set; }
        #endregion
        
        #region Parameter Description_ModelVersion
        /// <summary>
        /// <para>
        /// <para>The version of the model</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description_ModelVersion { get; set; }
        #endregion
        
        #region Parameter Performance_Precision
        /// <summary>
        /// <para>
        /// <para>The overall precision metric value for the trained model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Description_Performance_Precision")]
        public System.Single? Performance_Precision { get; set; }
        #endregion
        
        #region Parameter S3Location_Prefix
        /// <summary>
        /// <para>
        /// <para>The path and name of the manifest file with the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Description_OutputConfig_S3Location_Prefix")]
        public System.String S3Location_Prefix { get; set; }
        #endregion
        
        #region Parameter Output_S3Location_Prefix
        /// <summary>
        /// <para>
        /// <para>The path and name of the manifest file with the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_S3Location_Prefix")]
        public System.String Output_S3Location_Prefix { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project in which you want to create a model version.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter Performance_Recall
        /// <summary>
        /// <para>
        /// <para>The overall recall metric value for the trained model. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Description_Performance_Recall")]
        public System.Single? Performance_Recall { get; set; }
        #endregion
        
        #region Parameter Description_Status
        /// <summary>
        /// <para>
        /// <para>The status of the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LookoutforVision.ModelStatus")]
        public Amazon.LookoutforVision.ModelStatus Description_Status { get; set; }
        #endregion
        
        #region Parameter Description_StatusMessage
        /// <summary>
        /// <para>
        /// <para>The status message for the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description_StatusMessage { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>ClientToken is an idempotency token that ensures a call to <code>CreateModel</code>
        /// completes only once. You choose the value to pass. For example, An issue, such as
        /// an network outage, might prevent you from getting a response from <code>CreateModel</code>.
        /// In this case, safely retry your call to <code>CreateModel</code> by using the same
        /// <code>ClientToken</code> parameter value. An error occurs if the other input parameters
        /// are not the same as in the first request. Using a different value for <code>ClientToken</code>
        /// is considered a new call to <code>CreateModel</code>. An idempotency token is active
        /// for 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutforVision.Model.CreateModelResponse).
        /// Specifying the name of a property of type Amazon.LookoutforVision.Model.CreateModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelMetadata";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LFVModel (CreateModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutforVision.Model.CreateModelResponse, NewLFVModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description_CreationTimestamp = this.Description_CreationTimestamp;
            context.Description_Description = this.Description_Description;
            context.Description_EvaluationEndTimestamp = this.Description_EvaluationEndTimestamp;
            context.EvaluationManifest_Bucket = this.EvaluationManifest_Bucket;
            context.EvaluationManifest_Key = this.EvaluationManifest_Key;
            context.EvaluationResult_Bucket = this.EvaluationResult_Bucket;
            context.EvaluationResult_Key = this.EvaluationResult_Key;
            context.Description_KmsKeyId = this.Description_KmsKeyId;
            context.Description_ModelArn = this.Description_ModelArn;
            context.Description_ModelVersion = this.Description_ModelVersion;
            context.S3Location_Bucket = this.S3Location_Bucket;
            context.S3Location_Prefix = this.S3Location_Prefix;
            context.Performance_F1Score = this.Performance_F1Score;
            context.Performance_Precision = this.Performance_Precision;
            context.Performance_Recall = this.Performance_Recall;
            context.Description_Status = this.Description_Status;
            context.Description_StatusMessage = this.Description_StatusMessage;
            context.KmsKeyId = this.KmsKeyId;
            context.Output_S3Location_Bucket = this.Output_S3Location_Bucket;
            #if MODULAR
            if (this.Output_S3Location_Bucket == null && ParameterWasBound(nameof(this.Output_S3Location_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter Output_S3Location_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Output_S3Location_Prefix = this.Output_S3Location_Prefix;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LookoutforVision.Model.CreateModelRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Description
            var requestDescriptionIsNull = true;
            request.Description = new Amazon.LookoutforVision.Model.ModelDescription();
            System.DateTime? requestDescription_description_CreationTimestamp = null;
            if (cmdletContext.Description_CreationTimestamp != null)
            {
                requestDescription_description_CreationTimestamp = cmdletContext.Description_CreationTimestamp.Value;
            }
            if (requestDescription_description_CreationTimestamp != null)
            {
                request.Description.CreationTimestamp = requestDescription_description_CreationTimestamp.Value;
                requestDescriptionIsNull = false;
            }
            System.String requestDescription_description_Description = null;
            if (cmdletContext.Description_Description != null)
            {
                requestDescription_description_Description = cmdletContext.Description_Description;
            }
            if (requestDescription_description_Description != null)
            {
                request.Description.Description = requestDescription_description_Description;
                requestDescriptionIsNull = false;
            }
            System.DateTime? requestDescription_description_EvaluationEndTimestamp = null;
            if (cmdletContext.Description_EvaluationEndTimestamp != null)
            {
                requestDescription_description_EvaluationEndTimestamp = cmdletContext.Description_EvaluationEndTimestamp.Value;
            }
            if (requestDescription_description_EvaluationEndTimestamp != null)
            {
                request.Description.EvaluationEndTimestamp = requestDescription_description_EvaluationEndTimestamp.Value;
                requestDescriptionIsNull = false;
            }
            System.String requestDescription_description_KmsKeyId = null;
            if (cmdletContext.Description_KmsKeyId != null)
            {
                requestDescription_description_KmsKeyId = cmdletContext.Description_KmsKeyId;
            }
            if (requestDescription_description_KmsKeyId != null)
            {
                request.Description.KmsKeyId = requestDescription_description_KmsKeyId;
                requestDescriptionIsNull = false;
            }
            System.String requestDescription_description_ModelArn = null;
            if (cmdletContext.Description_ModelArn != null)
            {
                requestDescription_description_ModelArn = cmdletContext.Description_ModelArn;
            }
            if (requestDescription_description_ModelArn != null)
            {
                request.Description.ModelArn = requestDescription_description_ModelArn;
                requestDescriptionIsNull = false;
            }
            System.String requestDescription_description_ModelVersion = null;
            if (cmdletContext.Description_ModelVersion != null)
            {
                requestDescription_description_ModelVersion = cmdletContext.Description_ModelVersion;
            }
            if (requestDescription_description_ModelVersion != null)
            {
                request.Description.ModelVersion = requestDescription_description_ModelVersion;
                requestDescriptionIsNull = false;
            }
            Amazon.LookoutforVision.ModelStatus requestDescription_description_Status = null;
            if (cmdletContext.Description_Status != null)
            {
                requestDescription_description_Status = cmdletContext.Description_Status;
            }
            if (requestDescription_description_Status != null)
            {
                request.Description.Status = requestDescription_description_Status;
                requestDescriptionIsNull = false;
            }
            System.String requestDescription_description_StatusMessage = null;
            if (cmdletContext.Description_StatusMessage != null)
            {
                requestDescription_description_StatusMessage = cmdletContext.Description_StatusMessage;
            }
            if (requestDescription_description_StatusMessage != null)
            {
                request.Description.StatusMessage = requestDescription_description_StatusMessage;
                requestDescriptionIsNull = false;
            }
            Amazon.LookoutforVision.Model.OutputConfig requestDescription_description_OutputConfig = null;
            
             // populate OutputConfig
            var requestDescription_description_OutputConfigIsNull = true;
            requestDescription_description_OutputConfig = new Amazon.LookoutforVision.Model.OutputConfig();
            Amazon.LookoutforVision.Model.S3Location requestDescription_description_OutputConfig_description_OutputConfig_S3Location = null;
            
             // populate S3Location
            var requestDescription_description_OutputConfig_description_OutputConfig_S3LocationIsNull = true;
            requestDescription_description_OutputConfig_description_OutputConfig_S3Location = new Amazon.LookoutforVision.Model.S3Location();
            System.String requestDescription_description_OutputConfig_description_OutputConfig_S3Location_s3Location_Bucket = null;
            if (cmdletContext.S3Location_Bucket != null)
            {
                requestDescription_description_OutputConfig_description_OutputConfig_S3Location_s3Location_Bucket = cmdletContext.S3Location_Bucket;
            }
            if (requestDescription_description_OutputConfig_description_OutputConfig_S3Location_s3Location_Bucket != null)
            {
                requestDescription_description_OutputConfig_description_OutputConfig_S3Location.Bucket = requestDescription_description_OutputConfig_description_OutputConfig_S3Location_s3Location_Bucket;
                requestDescription_description_OutputConfig_description_OutputConfig_S3LocationIsNull = false;
            }
            System.String requestDescription_description_OutputConfig_description_OutputConfig_S3Location_s3Location_Prefix = null;
            if (cmdletContext.S3Location_Prefix != null)
            {
                requestDescription_description_OutputConfig_description_OutputConfig_S3Location_s3Location_Prefix = cmdletContext.S3Location_Prefix;
            }
            if (requestDescription_description_OutputConfig_description_OutputConfig_S3Location_s3Location_Prefix != null)
            {
                requestDescription_description_OutputConfig_description_OutputConfig_S3Location.Prefix = requestDescription_description_OutputConfig_description_OutputConfig_S3Location_s3Location_Prefix;
                requestDescription_description_OutputConfig_description_OutputConfig_S3LocationIsNull = false;
            }
             // determine if requestDescription_description_OutputConfig_description_OutputConfig_S3Location should be set to null
            if (requestDescription_description_OutputConfig_description_OutputConfig_S3LocationIsNull)
            {
                requestDescription_description_OutputConfig_description_OutputConfig_S3Location = null;
            }
            if (requestDescription_description_OutputConfig_description_OutputConfig_S3Location != null)
            {
                requestDescription_description_OutputConfig.S3Location = requestDescription_description_OutputConfig_description_OutputConfig_S3Location;
                requestDescription_description_OutputConfigIsNull = false;
            }
             // determine if requestDescription_description_OutputConfig should be set to null
            if (requestDescription_description_OutputConfigIsNull)
            {
                requestDescription_description_OutputConfig = null;
            }
            if (requestDescription_description_OutputConfig != null)
            {
                request.Description.OutputConfig = requestDescription_description_OutputConfig;
                requestDescriptionIsNull = false;
            }
            Amazon.LookoutforVision.Model.OutputS3Object requestDescription_description_EvaluationManifest = null;
            
             // populate EvaluationManifest
            var requestDescription_description_EvaluationManifestIsNull = true;
            requestDescription_description_EvaluationManifest = new Amazon.LookoutforVision.Model.OutputS3Object();
            System.String requestDescription_description_EvaluationManifest_evaluationManifest_Bucket = null;
            if (cmdletContext.EvaluationManifest_Bucket != null)
            {
                requestDescription_description_EvaluationManifest_evaluationManifest_Bucket = cmdletContext.EvaluationManifest_Bucket;
            }
            if (requestDescription_description_EvaluationManifest_evaluationManifest_Bucket != null)
            {
                requestDescription_description_EvaluationManifest.Bucket = requestDescription_description_EvaluationManifest_evaluationManifest_Bucket;
                requestDescription_description_EvaluationManifestIsNull = false;
            }
            System.String requestDescription_description_EvaluationManifest_evaluationManifest_Key = null;
            if (cmdletContext.EvaluationManifest_Key != null)
            {
                requestDescription_description_EvaluationManifest_evaluationManifest_Key = cmdletContext.EvaluationManifest_Key;
            }
            if (requestDescription_description_EvaluationManifest_evaluationManifest_Key != null)
            {
                requestDescription_description_EvaluationManifest.Key = requestDescription_description_EvaluationManifest_evaluationManifest_Key;
                requestDescription_description_EvaluationManifestIsNull = false;
            }
             // determine if requestDescription_description_EvaluationManifest should be set to null
            if (requestDescription_description_EvaluationManifestIsNull)
            {
                requestDescription_description_EvaluationManifest = null;
            }
            if (requestDescription_description_EvaluationManifest != null)
            {
                request.Description.EvaluationManifest = requestDescription_description_EvaluationManifest;
                requestDescriptionIsNull = false;
            }
            Amazon.LookoutforVision.Model.OutputS3Object requestDescription_description_EvaluationResult = null;
            
             // populate EvaluationResult
            var requestDescription_description_EvaluationResultIsNull = true;
            requestDescription_description_EvaluationResult = new Amazon.LookoutforVision.Model.OutputS3Object();
            System.String requestDescription_description_EvaluationResult_evaluationResult_Bucket = null;
            if (cmdletContext.EvaluationResult_Bucket != null)
            {
                requestDescription_description_EvaluationResult_evaluationResult_Bucket = cmdletContext.EvaluationResult_Bucket;
            }
            if (requestDescription_description_EvaluationResult_evaluationResult_Bucket != null)
            {
                requestDescription_description_EvaluationResult.Bucket = requestDescription_description_EvaluationResult_evaluationResult_Bucket;
                requestDescription_description_EvaluationResultIsNull = false;
            }
            System.String requestDescription_description_EvaluationResult_evaluationResult_Key = null;
            if (cmdletContext.EvaluationResult_Key != null)
            {
                requestDescription_description_EvaluationResult_evaluationResult_Key = cmdletContext.EvaluationResult_Key;
            }
            if (requestDescription_description_EvaluationResult_evaluationResult_Key != null)
            {
                requestDescription_description_EvaluationResult.Key = requestDescription_description_EvaluationResult_evaluationResult_Key;
                requestDescription_description_EvaluationResultIsNull = false;
            }
             // determine if requestDescription_description_EvaluationResult should be set to null
            if (requestDescription_description_EvaluationResultIsNull)
            {
                requestDescription_description_EvaluationResult = null;
            }
            if (requestDescription_description_EvaluationResult != null)
            {
                request.Description.EvaluationResult = requestDescription_description_EvaluationResult;
                requestDescriptionIsNull = false;
            }
            Amazon.LookoutforVision.Model.ModelPerformance requestDescription_description_Performance = null;
            
             // populate Performance
            var requestDescription_description_PerformanceIsNull = true;
            requestDescription_description_Performance = new Amazon.LookoutforVision.Model.ModelPerformance();
            System.Single? requestDescription_description_Performance_performance_F1Score = null;
            if (cmdletContext.Performance_F1Score != null)
            {
                requestDescription_description_Performance_performance_F1Score = cmdletContext.Performance_F1Score.Value;
            }
            if (requestDescription_description_Performance_performance_F1Score != null)
            {
                requestDescription_description_Performance.F1Score = requestDescription_description_Performance_performance_F1Score.Value;
                requestDescription_description_PerformanceIsNull = false;
            }
            System.Single? requestDescription_description_Performance_performance_Precision = null;
            if (cmdletContext.Performance_Precision != null)
            {
                requestDescription_description_Performance_performance_Precision = cmdletContext.Performance_Precision.Value;
            }
            if (requestDescription_description_Performance_performance_Precision != null)
            {
                requestDescription_description_Performance.Precision = requestDescription_description_Performance_performance_Precision.Value;
                requestDescription_description_PerformanceIsNull = false;
            }
            System.Single? requestDescription_description_Performance_performance_Recall = null;
            if (cmdletContext.Performance_Recall != null)
            {
                requestDescription_description_Performance_performance_Recall = cmdletContext.Performance_Recall.Value;
            }
            if (requestDescription_description_Performance_performance_Recall != null)
            {
                requestDescription_description_Performance.Recall = requestDescription_description_Performance_performance_Recall.Value;
                requestDescription_description_PerformanceIsNull = false;
            }
             // determine if requestDescription_description_Performance should be set to null
            if (requestDescription_description_PerformanceIsNull)
            {
                requestDescription_description_Performance = null;
            }
            if (requestDescription_description_Performance != null)
            {
                request.Description.Performance = requestDescription_description_Performance;
                requestDescriptionIsNull = false;
            }
             // determine if request.Description should be set to null
            if (requestDescriptionIsNull)
            {
                request.Description = null;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.LookoutforVision.Model.OutputConfig();
            Amazon.LookoutforVision.Model.S3Location requestOutputConfig_outputConfig_S3Location = null;
            
             // populate S3Location
            var requestOutputConfig_outputConfig_S3LocationIsNull = true;
            requestOutputConfig_outputConfig_S3Location = new Amazon.LookoutforVision.Model.S3Location();
            System.String requestOutputConfig_outputConfig_S3Location_output_S3Location_Bucket = null;
            if (cmdletContext.Output_S3Location_Bucket != null)
            {
                requestOutputConfig_outputConfig_S3Location_output_S3Location_Bucket = cmdletContext.Output_S3Location_Bucket;
            }
            if (requestOutputConfig_outputConfig_S3Location_output_S3Location_Bucket != null)
            {
                requestOutputConfig_outputConfig_S3Location.Bucket = requestOutputConfig_outputConfig_S3Location_output_S3Location_Bucket;
                requestOutputConfig_outputConfig_S3LocationIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3Location_output_S3Location_Prefix = null;
            if (cmdletContext.Output_S3Location_Prefix != null)
            {
                requestOutputConfig_outputConfig_S3Location_output_S3Location_Prefix = cmdletContext.Output_S3Location_Prefix;
            }
            if (requestOutputConfig_outputConfig_S3Location_output_S3Location_Prefix != null)
            {
                requestOutputConfig_outputConfig_S3Location.Prefix = requestOutputConfig_outputConfig_S3Location_output_S3Location_Prefix;
                requestOutputConfig_outputConfig_S3LocationIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_S3Location should be set to null
            if (requestOutputConfig_outputConfig_S3LocationIsNull)
            {
                requestOutputConfig_outputConfig_S3Location = null;
            }
            if (requestOutputConfig_outputConfig_S3Location != null)
            {
                request.OutputConfig.S3Location = requestOutputConfig_outputConfig_S3Location;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
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
        
        private Amazon.LookoutforVision.Model.CreateModelResponse CallAWSServiceOperation(IAmazonLookoutforVision client, Amazon.LookoutforVision.Model.CreateModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Vision", "CreateModel");
            try
            {
                #if DESKTOP
                return client.CreateModel(request);
                #elif CORECLR
                return client.CreateModelAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.DateTime? Description_CreationTimestamp { get; set; }
            public System.String Description_Description { get; set; }
            public System.DateTime? Description_EvaluationEndTimestamp { get; set; }
            public System.String EvaluationManifest_Bucket { get; set; }
            public System.String EvaluationManifest_Key { get; set; }
            public System.String EvaluationResult_Bucket { get; set; }
            public System.String EvaluationResult_Key { get; set; }
            public System.String Description_KmsKeyId { get; set; }
            public System.String Description_ModelArn { get; set; }
            public System.String Description_ModelVersion { get; set; }
            public System.String S3Location_Bucket { get; set; }
            public System.String S3Location_Prefix { get; set; }
            public System.Single? Performance_F1Score { get; set; }
            public System.Single? Performance_Precision { get; set; }
            public System.Single? Performance_Recall { get; set; }
            public Amazon.LookoutforVision.ModelStatus Description_Status { get; set; }
            public System.String Description_StatusMessage { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Output_S3Location_Bucket { get; set; }
            public System.String Output_S3Location_Prefix { get; set; }
            public System.String ProjectName { get; set; }
            public System.Func<Amazon.LookoutforVision.Model.CreateModelResponse, NewLFVModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelMetadata;
        }
        
    }
}
