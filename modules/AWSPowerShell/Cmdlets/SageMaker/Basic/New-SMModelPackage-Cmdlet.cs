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
    /// Creates a model package that you can use to create SageMaker models or list on Amazon
    /// Web Services Marketplace, or a versioned model that is part of a model group. Buyers
    /// can subscribe to model packages listed on Amazon Web Services Marketplace to create
    /// models in SageMaker.
    /// 
    ///  
    /// <para>
    /// To create a model package by specifying a Docker container that contains your inference
    /// code and the Amazon S3 location of your model artifacts, provide values for <c>InferenceSpecification</c>.
    /// To create a model from an algorithm resource that you created or subscribed to in
    /// Amazon Web Services Marketplace, provide a value for <c>SourceAlgorithmSpecification</c>.
    /// </para><note><para>
    /// There are two types of model packages:
    /// </para><ul><li><para>
    /// Versioned - a model that is part of a model group in the model registry.
    /// </para></li><li><para>
    /// Unversioned - a model package that is not part of a model group.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("New", "SMModelPackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateModelPackage API operation.", Operation = new[] {"CreateModelPackage"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateModelPackageResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateModelPackageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateModelPackageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMModelPackageCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalInferenceSpecification
        /// <summary>
        /// <para>
        /// <para>An array of additional Inference Specification objects. Each additional Inference
        /// Specification specifies artifacts based on this model package that can be used on
        /// inference endpoints. Generally used with SageMaker Neo to store the compiled artifacts.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalInferenceSpecifications")]
        public Amazon.SageMaker.Model.AdditionalInferenceSpecificationDefinition[] AdditionalInferenceSpecification { get; set; }
        #endregion
        
        #region Parameter CertifyForMarketplace
        /// <summary>
        /// <para>
        /// <para>Whether to certify the model package for listing on Amazon Web Services Marketplace.</para><para>This parameter is optional for unversioned models, and does not apply to versioned
        /// models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CertifyForMarketplace { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_CommitId
        /// <summary>
        /// <para>
        /// <para>The commit ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_CommitId { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_Container
        /// <summary>
        /// <para>
        /// <para>The Amazon ECR registry path of the Docker image that contains the inference code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_Containers")]
        public Amazon.SageMaker.Model.ModelPackageContainerDefinition[] InferenceSpecification_Container { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_Bias_ConfigFile_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The digest of the file source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigFile_ContentDigest")]
        public System.String DriftCheckBaselines_Bias_ConfigFile_ContentDigest { get; set; }
        #endregion
        
        #region Parameter PostTrainingConstraints_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DriftCheckBaselines_Bias_PostTrainingConstraints_ContentDigest")]
        public System.String PostTrainingConstraints_ContentDigest { get; set; }
        #endregion
        
        #region Parameter PreTrainingConstraints_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DriftCheckBaselines_Bias_PreTrainingConstraints_ContentDigest")]
        public System.String PreTrainingConstraints_ContentDigest { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_Explainability_ConfigFile_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The digest of the file source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_Explainability_ConfigFile_ContentDigest { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_Explainability_Constraints_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Constraints_ContentDigest")]
        public System.String DriftCheckBaselines_Explainability_Constraints_ContentDigest { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelDataQuality_Constraints_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_ModelDataQuality_Constraints_ContentDigest { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelDataQuality_Statistics_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Statistics_ContentDigest")]
        public System.String DriftCheckBaselines_ModelDataQuality_Statistics_ContentDigest { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelQuality_Constraints_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_ModelQuality_Constraints_ContentDigest { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelQuality_Statistics_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_ModelQuality_Statistics_ContentDigest { get; set; }
        #endregion
        
        #region Parameter PostTrainingReport_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelMetrics_Bias_PostTrainingReport_ContentDigest")]
        public System.String PostTrainingReport_ContentDigest { get; set; }
        #endregion
        
        #region Parameter PreTrainingReport_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelMetrics_Bias_PreTrainingReport_ContentDigest")]
        public System.String PreTrainingReport_ContentDigest { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_Bias_Report_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Bias_Report_ContentDigest")]
        public System.String ModelMetrics_Bias_Report_ContentDigest { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_Explainability_Report_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelMetrics_Explainability_Report_ContentDigest { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelDataQuality_Constraints_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelDataQuality_Constraints_ContentDigest")]
        public System.String ModelMetrics_ModelDataQuality_Constraints_ContentDigest { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelDataQuality_Statistics_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelDataQuality_Statistics_ContentDigest")]
        public System.String ModelMetrics_ModelDataQuality_Statistics_ContentDigest { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelQuality_Constraints_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelMetrics_ModelQuality_Constraints_ContentDigest { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelQuality_Statistics_ContentDigest
        /// <summary>
        /// <para>
        /// <para>The hash key used for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelMetrics_ModelQuality_Statistics_ContentDigest { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_Bias_ConfigFile_ContentType
        /// <summary>
        /// <para>
        /// <para>The type of content stored in the file source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigFile_ContentType")]
        public System.String DriftCheckBaselines_Bias_ConfigFile_ContentType { get; set; }
        #endregion
        
        #region Parameter PostTrainingConstraints_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DriftCheckBaselines_Bias_PostTrainingConstraints_ContentType")]
        public System.String PostTrainingConstraints_ContentType { get; set; }
        #endregion
        
        #region Parameter PreTrainingConstraints_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DriftCheckBaselines_Bias_PreTrainingConstraints_ContentType")]
        public System.String PreTrainingConstraints_ContentType { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_Explainability_ConfigFile_ContentType
        /// <summary>
        /// <para>
        /// <para>The type of content stored in the file source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_Explainability_ConfigFile_ContentType { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_Explainability_Constraints_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Constraints_ContentType")]
        public System.String DriftCheckBaselines_Explainability_Constraints_ContentType { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelDataQuality_Constraints_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_ModelDataQuality_Constraints_ContentType { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelDataQuality_Statistics_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Statistics_ContentType")]
        public System.String DriftCheckBaselines_ModelDataQuality_Statistics_ContentType { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelQuality_Constraints_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_ModelQuality_Constraints_ContentType { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelQuality_Statistics_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_ModelQuality_Statistics_ContentType { get; set; }
        #endregion
        
        #region Parameter PostTrainingReport_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelMetrics_Bias_PostTrainingReport_ContentType")]
        public System.String PostTrainingReport_ContentType { get; set; }
        #endregion
        
        #region Parameter PreTrainingReport_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelMetrics_Bias_PreTrainingReport_ContentType")]
        public System.String PreTrainingReport_ContentType { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_Bias_Report_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Bias_Report_ContentType")]
        public System.String ModelMetrics_Bias_Report_ContentType { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_Explainability_Report_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelMetrics_Explainability_Report_ContentType { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelDataQuality_Constraints_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelDataQuality_Constraints_ContentType")]
        public System.String ModelMetrics_ModelDataQuality_Constraints_ContentType { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelDataQuality_Statistics_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelDataQuality_Statistics_ContentType")]
        public System.String ModelMetrics_ModelDataQuality_Statistics_ContentType { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelQuality_Constraints_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelMetrics_ModelQuality_Constraints_ContentType { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelQuality_Statistics_ContentType
        /// <summary>
        /// <para>
        /// <para>The metric source content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelMetrics_ModelQuality_Statistics_ContentType { get; set; }
        #endregion
        
        #region Parameter CustomerMetadataProperty
        /// <summary>
        /// <para>
        /// <para>The metadata properties associated with the model package versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomerMetadataProperties")]
        public System.Collections.Hashtable CustomerMetadataProperty { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The machine learning domain of your model package and its components. Common machine
        /// learning domains include computer vision and natural language processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_GeneratedBy
        /// <summary>
        /// <para>
        /// <para>The entity this entity was generated by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_GeneratedBy { get; set; }
        #endregion
        
        #region Parameter SecurityConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS Key ID (<c>KMSKeyId</c>) used for encryption of model package information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ModelApprovalStatus
        /// <summary>
        /// <para>
        /// <para>Whether the model is approved for deployment.</para><para>This parameter is optional for versioned models, and does not apply to unversioned
        /// models.</para><para>For versioned models, the value of this parameter must be set to <c>Approved</c> to
        /// deploy the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ModelApprovalStatus")]
        public Amazon.SageMaker.ModelApprovalStatus ModelApprovalStatus { get; set; }
        #endregion
        
        #region Parameter ModelCard_ModelCardContent
        /// <summary>
        /// <para>
        /// <para>The content of the model card. The content must follow the schema described in <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-registry-details.html#model-card-schema">Model
        /// Package Model Card Schema</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelCard_ModelCardContent { get; set; }
        #endregion
        
        #region Parameter ModelCard_ModelCardStatus
        /// <summary>
        /// <para>
        /// <para>The approval status of the model card within your organization. Different organizations
        /// might have different criteria for model card review and approval.</para><ul><li><para><c>Draft</c>: The model card is a work in progress.</para></li><li><para><c>PendingReview</c>: The model card is pending review.</para></li><li><para><c>Approved</c>: The model card is approved.</para></li><li><para><c>Archived</c>: The model card is archived. No more updates can be made to the model
        /// card content. If you try to update the model card content, you will receive the message
        /// <c>Model Card is in Archived state</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ModelCardStatus")]
        public Amazon.SageMaker.ModelCardStatus ModelCard_ModelCardStatus { get; set; }
        #endregion
        
        #region Parameter ModelPackageDescription
        /// <summary>
        /// <para>
        /// <para>A description of the model package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelPackageDescription { get; set; }
        #endregion
        
        #region Parameter ModelPackageGroupName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the model package group that this model
        /// version belongs to.</para><para>This parameter is required for versioned models, and does not apply to unversioned
        /// models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelPackageGroupName { get; set; }
        #endregion
        
        #region Parameter ModelPackageName
        /// <summary>
        /// <para>
        /// <para>The name of the model package. The name must have 1 to 63 characters. Valid characters
        /// are a-z, A-Z, 0-9, and - (hyphen).</para><para>This parameter is required for unversioned models. It is not applicable to versioned
        /// models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ModelPackageName { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_ProjectId
        /// <summary>
        /// <para>
        /// <para>The project ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_ProjectId { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_Repository
        /// <summary>
        /// <para>
        /// <para>The repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_Repository { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_Bias_ConfigFile_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI for the file source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigFile_S3Uri")]
        public System.String DriftCheckBaselines_Bias_ConfigFile_S3Uri { get; set; }
        #endregion
        
        #region Parameter PostTrainingConstraints_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DriftCheckBaselines_Bias_PostTrainingConstraints_S3Uri")]
        public System.String PostTrainingConstraints_S3Uri { get; set; }
        #endregion
        
        #region Parameter PreTrainingConstraints_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DriftCheckBaselines_Bias_PreTrainingConstraints_S3Uri")]
        public System.String PreTrainingConstraints_S3Uri { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_Explainability_ConfigFile_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI for the file source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_Explainability_ConfigFile_S3Uri { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_Explainability_Constraints_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Constraints_S3Uri")]
        public System.String DriftCheckBaselines_Explainability_Constraints_S3Uri { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelDataQuality_Constraints_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_ModelDataQuality_Constraints_S3Uri { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelDataQuality_Statistics_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Statistics_S3Uri")]
        public System.String DriftCheckBaselines_ModelDataQuality_Statistics_S3Uri { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelQuality_Constraints_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_ModelQuality_Constraints_S3Uri { get; set; }
        #endregion
        
        #region Parameter DriftCheckBaselines_ModelQuality_Statistics_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DriftCheckBaselines_ModelQuality_Statistics_S3Uri { get; set; }
        #endregion
        
        #region Parameter PostTrainingReport_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelMetrics_Bias_PostTrainingReport_S3Uri")]
        public System.String PostTrainingReport_S3Uri { get; set; }
        #endregion
        
        #region Parameter PreTrainingReport_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelMetrics_Bias_PreTrainingReport_S3Uri")]
        public System.String PreTrainingReport_S3Uri { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_Bias_Report_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Bias_Report_S3Uri")]
        public System.String ModelMetrics_Bias_Report_S3Uri { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_Explainability_Report_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelMetrics_Explainability_Report_S3Uri { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelDataQuality_Constraints_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelDataQuality_Constraints_S3Uri")]
        public System.String ModelMetrics_ModelDataQuality_Constraints_S3Uri { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelDataQuality_Statistics_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelDataQuality_Statistics_S3Uri")]
        public System.String ModelMetrics_ModelDataQuality_Statistics_S3Uri { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelQuality_Constraints_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelMetrics_ModelQuality_Constraints_S3Uri { get; set; }
        #endregion
        
        #region Parameter ModelMetrics_ModelQuality_Statistics_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for the metrics source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelMetrics_ModelQuality_Statistics_S3Uri { get; set; }
        #endregion
        
        #region Parameter SamplePayloadUrl
        /// <summary>
        /// <para>
        /// <para>The Amazon Simple Storage Service (Amazon S3) path where the sample payload is stored.
        /// This path must point to a single gzip compressed tar archive (.tar.gz suffix). This
        /// archive can hold multiple files that are all equally used in the load test. Each file
        /// in the archive must satisfy the size constraints of the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_runtime_InvokeEndpoint.html#API_runtime_InvokeEndpoint_RequestSyntax">InvokeEndpoint</a>
        /// call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplePayloadUrl { get; set; }
        #endregion
        
        #region Parameter SkipModelValidation
        /// <summary>
        /// <para>
        /// <para>Indicates if you want to skip model validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SkipModelValidation")]
        public Amazon.SageMaker.SkipModelValidation SkipModelValidation { get; set; }
        #endregion
        
        #region Parameter SourceAlgorithmSpecification_SourceAlgorithm
        /// <summary>
        /// <para>
        /// <para>A list of the algorithms that were used to create a model package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceAlgorithmSpecification_SourceAlgorithms")]
        public Amazon.SageMaker.Model.SourceAlgorithm[] SourceAlgorithmSpecification_SourceAlgorithm { get; set; }
        #endregion
        
        #region Parameter SourceUri
        /// <summary>
        /// <para>
        /// <para>The URI of the source for the model package. If you want to clone a model package,
        /// set it to the model package Amazon Resource Name (ARN). If you want to register a
        /// model, set it to the model ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceUri { get; set; }
        #endregion
        
        #region Parameter ModelLifeCycle_Stage
        /// <summary>
        /// <para>
        /// <para> The current stage in the model life cycle. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelLifeCycle_Stage { get; set; }
        #endregion
        
        #region Parameter ModelLifeCycle_StageDescription
        /// <summary>
        /// <para>
        /// <para> Describes the stage related details. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelLifeCycle_StageDescription { get; set; }
        #endregion
        
        #region Parameter ModelLifeCycle_StageStatus
        /// <summary>
        /// <para>
        /// <para> The current status of a stage in model life cycle. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelLifeCycle_StageStatus { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedContentType
        /// <summary>
        /// <para>
        /// <para>The supported MIME types for the input data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_SupportedContentTypes")]
        public System.String[] InferenceSpecification_SupportedContentType { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedRealtimeInferenceInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of the instance types that are used to generate inferences in real-time.</para><para>This parameter is required for unversioned models, and optional for versioned models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_SupportedRealtimeInferenceInstanceTypes")]
        public System.String[] InferenceSpecification_SupportedRealtimeInferenceInstanceType { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedResponseMIMEType
        /// <summary>
        /// <para>
        /// <para>The supported MIME types for the output data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_SupportedResponseMIMETypes")]
        public System.String[] InferenceSpecification_SupportedResponseMIMEType { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedTransformInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of the instance types on which a transformation job can be run or on which
        /// an endpoint can be deployed.</para><para>This parameter is required for unversioned models, and optional for versioned models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_SupportedTransformInstanceTypes")]
        public System.String[] InferenceSpecification_SupportedTransformInstanceType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key value pairs associated with the model. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging Amazon
        /// Web Services resources</a> in the <i>Amazon Web Services General Reference Guide</i>.</para><para>If you supply <c>ModelPackageGroupName</c>, your model package belongs to the model
        /// group you specify and uses the tags associated with the model group. In this case,
        /// you cannot supply a <c>tag</c> argument. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Task
        /// <summary>
        /// <para>
        /// <para>The machine learning task your model package accomplishes. Common machine learning
        /// tasks include object detection and image classification. The following tasks are supported
        /// by Inference Recommender: <c>"IMAGE_CLASSIFICATION"</c> | <c>"OBJECT_DETECTION"</c>
        /// | <c>"TEXT_GENERATION"</c> |<c>"IMAGE_SEGMENTATION"</c> | <c>"FILL_MASK"</c> | <c>"CLASSIFICATION"</c>
        /// | <c>"REGRESSION"</c> | <c>"OTHER"</c>.</para><para>Specify "OTHER" if none of the tasks listed fit your use case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Task { get; set; }
        #endregion
        
        #region Parameter ValidationSpecification_ValidationProfile
        /// <summary>
        /// <para>
        /// <para>An array of <c>ModelPackageValidationProfile</c> objects, each of which specifies
        /// a batch transform job that SageMaker runs to validate your model package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValidationSpecification_ValidationProfiles")]
        public Amazon.SageMaker.Model.ModelPackageValidationProfile[] ValidationSpecification_ValidationProfile { get; set; }
        #endregion
        
        #region Parameter ValidationSpecification_ValidationRole
        /// <summary>
        /// <para>
        /// <para>The IAM roles to be used for the validation of the model package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValidationSpecification_ValidationRole { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that guarantees that the call to this API is idempotent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelPackageArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateModelPackageResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateModelPackageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelPackageArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelPackageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMModelPackage (CreateModelPackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateModelPackageResponse, NewSMModelPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalInferenceSpecification != null)
            {
                context.AdditionalInferenceSpecification = new List<Amazon.SageMaker.Model.AdditionalInferenceSpecificationDefinition>(this.AdditionalInferenceSpecification);
            }
            context.CertifyForMarketplace = this.CertifyForMarketplace;
            context.ClientToken = this.ClientToken;
            if (this.CustomerMetadataProperty != null)
            {
                context.CustomerMetadataProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomerMetadataProperty.Keys)
                {
                    context.CustomerMetadataProperty.Add((String)hashKey, (System.String)(this.CustomerMetadataProperty[hashKey]));
                }
            }
            context.Domain = this.Domain;
            context.DriftCheckBaselines_Bias_ConfigFile_ContentDigest = this.DriftCheckBaselines_Bias_ConfigFile_ContentDigest;
            context.DriftCheckBaselines_Bias_ConfigFile_ContentType = this.DriftCheckBaselines_Bias_ConfigFile_ContentType;
            context.DriftCheckBaselines_Bias_ConfigFile_S3Uri = this.DriftCheckBaselines_Bias_ConfigFile_S3Uri;
            context.PostTrainingConstraints_ContentDigest = this.PostTrainingConstraints_ContentDigest;
            context.PostTrainingConstraints_ContentType = this.PostTrainingConstraints_ContentType;
            context.PostTrainingConstraints_S3Uri = this.PostTrainingConstraints_S3Uri;
            context.PreTrainingConstraints_ContentDigest = this.PreTrainingConstraints_ContentDigest;
            context.PreTrainingConstraints_ContentType = this.PreTrainingConstraints_ContentType;
            context.PreTrainingConstraints_S3Uri = this.PreTrainingConstraints_S3Uri;
            context.DriftCheckBaselines_Explainability_ConfigFile_ContentDigest = this.DriftCheckBaselines_Explainability_ConfigFile_ContentDigest;
            context.DriftCheckBaselines_Explainability_ConfigFile_ContentType = this.DriftCheckBaselines_Explainability_ConfigFile_ContentType;
            context.DriftCheckBaselines_Explainability_ConfigFile_S3Uri = this.DriftCheckBaselines_Explainability_ConfigFile_S3Uri;
            context.DriftCheckBaselines_Explainability_Constraints_ContentDigest = this.DriftCheckBaselines_Explainability_Constraints_ContentDigest;
            context.DriftCheckBaselines_Explainability_Constraints_ContentType = this.DriftCheckBaselines_Explainability_Constraints_ContentType;
            context.DriftCheckBaselines_Explainability_Constraints_S3Uri = this.DriftCheckBaselines_Explainability_Constraints_S3Uri;
            context.DriftCheckBaselines_ModelDataQuality_Constraints_ContentDigest = this.DriftCheckBaselines_ModelDataQuality_Constraints_ContentDigest;
            context.DriftCheckBaselines_ModelDataQuality_Constraints_ContentType = this.DriftCheckBaselines_ModelDataQuality_Constraints_ContentType;
            context.DriftCheckBaselines_ModelDataQuality_Constraints_S3Uri = this.DriftCheckBaselines_ModelDataQuality_Constraints_S3Uri;
            context.DriftCheckBaselines_ModelDataQuality_Statistics_ContentDigest = this.DriftCheckBaselines_ModelDataQuality_Statistics_ContentDigest;
            context.DriftCheckBaselines_ModelDataQuality_Statistics_ContentType = this.DriftCheckBaselines_ModelDataQuality_Statistics_ContentType;
            context.DriftCheckBaselines_ModelDataQuality_Statistics_S3Uri = this.DriftCheckBaselines_ModelDataQuality_Statistics_S3Uri;
            context.DriftCheckBaselines_ModelQuality_Constraints_ContentDigest = this.DriftCheckBaselines_ModelQuality_Constraints_ContentDigest;
            context.DriftCheckBaselines_ModelQuality_Constraints_ContentType = this.DriftCheckBaselines_ModelQuality_Constraints_ContentType;
            context.DriftCheckBaselines_ModelQuality_Constraints_S3Uri = this.DriftCheckBaselines_ModelQuality_Constraints_S3Uri;
            context.DriftCheckBaselines_ModelQuality_Statistics_ContentDigest = this.DriftCheckBaselines_ModelQuality_Statistics_ContentDigest;
            context.DriftCheckBaselines_ModelQuality_Statistics_ContentType = this.DriftCheckBaselines_ModelQuality_Statistics_ContentType;
            context.DriftCheckBaselines_ModelQuality_Statistics_S3Uri = this.DriftCheckBaselines_ModelQuality_Statistics_S3Uri;
            if (this.InferenceSpecification_Container != null)
            {
                context.InferenceSpecification_Container = new List<Amazon.SageMaker.Model.ModelPackageContainerDefinition>(this.InferenceSpecification_Container);
            }
            if (this.InferenceSpecification_SupportedContentType != null)
            {
                context.InferenceSpecification_SupportedContentType = new List<System.String>(this.InferenceSpecification_SupportedContentType);
            }
            if (this.InferenceSpecification_SupportedRealtimeInferenceInstanceType != null)
            {
                context.InferenceSpecification_SupportedRealtimeInferenceInstanceType = new List<System.String>(this.InferenceSpecification_SupportedRealtimeInferenceInstanceType);
            }
            if (this.InferenceSpecification_SupportedResponseMIMEType != null)
            {
                context.InferenceSpecification_SupportedResponseMIMEType = new List<System.String>(this.InferenceSpecification_SupportedResponseMIMEType);
            }
            if (this.InferenceSpecification_SupportedTransformInstanceType != null)
            {
                context.InferenceSpecification_SupportedTransformInstanceType = new List<System.String>(this.InferenceSpecification_SupportedTransformInstanceType);
            }
            context.MetadataProperties_CommitId = this.MetadataProperties_CommitId;
            context.MetadataProperties_GeneratedBy = this.MetadataProperties_GeneratedBy;
            context.MetadataProperties_ProjectId = this.MetadataProperties_ProjectId;
            context.MetadataProperties_Repository = this.MetadataProperties_Repository;
            context.ModelApprovalStatus = this.ModelApprovalStatus;
            context.ModelCard_ModelCardContent = this.ModelCard_ModelCardContent;
            context.ModelCard_ModelCardStatus = this.ModelCard_ModelCardStatus;
            context.ModelLifeCycle_Stage = this.ModelLifeCycle_Stage;
            context.ModelLifeCycle_StageDescription = this.ModelLifeCycle_StageDescription;
            context.ModelLifeCycle_StageStatus = this.ModelLifeCycle_StageStatus;
            context.PostTrainingReport_ContentDigest = this.PostTrainingReport_ContentDigest;
            context.PostTrainingReport_ContentType = this.PostTrainingReport_ContentType;
            context.PostTrainingReport_S3Uri = this.PostTrainingReport_S3Uri;
            context.PreTrainingReport_ContentDigest = this.PreTrainingReport_ContentDigest;
            context.PreTrainingReport_ContentType = this.PreTrainingReport_ContentType;
            context.PreTrainingReport_S3Uri = this.PreTrainingReport_S3Uri;
            context.ModelMetrics_Bias_Report_ContentDigest = this.ModelMetrics_Bias_Report_ContentDigest;
            context.ModelMetrics_Bias_Report_ContentType = this.ModelMetrics_Bias_Report_ContentType;
            context.ModelMetrics_Bias_Report_S3Uri = this.ModelMetrics_Bias_Report_S3Uri;
            context.ModelMetrics_Explainability_Report_ContentDigest = this.ModelMetrics_Explainability_Report_ContentDigest;
            context.ModelMetrics_Explainability_Report_ContentType = this.ModelMetrics_Explainability_Report_ContentType;
            context.ModelMetrics_Explainability_Report_S3Uri = this.ModelMetrics_Explainability_Report_S3Uri;
            context.ModelMetrics_ModelDataQuality_Constraints_ContentDigest = this.ModelMetrics_ModelDataQuality_Constraints_ContentDigest;
            context.ModelMetrics_ModelDataQuality_Constraints_ContentType = this.ModelMetrics_ModelDataQuality_Constraints_ContentType;
            context.ModelMetrics_ModelDataQuality_Constraints_S3Uri = this.ModelMetrics_ModelDataQuality_Constraints_S3Uri;
            context.ModelMetrics_ModelDataQuality_Statistics_ContentDigest = this.ModelMetrics_ModelDataQuality_Statistics_ContentDigest;
            context.ModelMetrics_ModelDataQuality_Statistics_ContentType = this.ModelMetrics_ModelDataQuality_Statistics_ContentType;
            context.ModelMetrics_ModelDataQuality_Statistics_S3Uri = this.ModelMetrics_ModelDataQuality_Statistics_S3Uri;
            context.ModelMetrics_ModelQuality_Constraints_ContentDigest = this.ModelMetrics_ModelQuality_Constraints_ContentDigest;
            context.ModelMetrics_ModelQuality_Constraints_ContentType = this.ModelMetrics_ModelQuality_Constraints_ContentType;
            context.ModelMetrics_ModelQuality_Constraints_S3Uri = this.ModelMetrics_ModelQuality_Constraints_S3Uri;
            context.ModelMetrics_ModelQuality_Statistics_ContentDigest = this.ModelMetrics_ModelQuality_Statistics_ContentDigest;
            context.ModelMetrics_ModelQuality_Statistics_ContentType = this.ModelMetrics_ModelQuality_Statistics_ContentType;
            context.ModelMetrics_ModelQuality_Statistics_S3Uri = this.ModelMetrics_ModelQuality_Statistics_S3Uri;
            context.ModelPackageDescription = this.ModelPackageDescription;
            context.ModelPackageGroupName = this.ModelPackageGroupName;
            context.ModelPackageName = this.ModelPackageName;
            context.SamplePayloadUrl = this.SamplePayloadUrl;
            context.SecurityConfig_KmsKeyId = this.SecurityConfig_KmsKeyId;
            context.SkipModelValidation = this.SkipModelValidation;
            if (this.SourceAlgorithmSpecification_SourceAlgorithm != null)
            {
                context.SourceAlgorithmSpecification_SourceAlgorithm = new List<Amazon.SageMaker.Model.SourceAlgorithm>(this.SourceAlgorithmSpecification_SourceAlgorithm);
            }
            context.SourceUri = this.SourceUri;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.Task = this.Task;
            if (this.ValidationSpecification_ValidationProfile != null)
            {
                context.ValidationSpecification_ValidationProfile = new List<Amazon.SageMaker.Model.ModelPackageValidationProfile>(this.ValidationSpecification_ValidationProfile);
            }
            context.ValidationSpecification_ValidationRole = this.ValidationSpecification_ValidationRole;
            
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
            var request = new Amazon.SageMaker.Model.CreateModelPackageRequest();
            
            if (cmdletContext.AdditionalInferenceSpecification != null)
            {
                request.AdditionalInferenceSpecifications = cmdletContext.AdditionalInferenceSpecification;
            }
            if (cmdletContext.CertifyForMarketplace != null)
            {
                request.CertifyForMarketplace = cmdletContext.CertifyForMarketplace.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomerMetadataProperty != null)
            {
                request.CustomerMetadataProperties = cmdletContext.CustomerMetadataProperty;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate DriftCheckBaselines
            var requestDriftCheckBaselinesIsNull = true;
            request.DriftCheckBaselines = new Amazon.SageMaker.Model.DriftCheckBaselines();
            Amazon.SageMaker.Model.DriftCheckExplainability requestDriftCheckBaselines_driftCheckBaselines_Explainability = null;
            
             // populate Explainability
            var requestDriftCheckBaselines_driftCheckBaselines_ExplainabilityIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_Explainability = new Amazon.SageMaker.Model.DriftCheckExplainability();
            Amazon.SageMaker.Model.FileSource requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile = null;
            
             // populate ConfigFile
            var requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFileIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile = new Amazon.SageMaker.Model.FileSource();
            System.String requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_ContentDigest = null;
            if (cmdletContext.DriftCheckBaselines_Explainability_ConfigFile_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_ContentDigest = cmdletContext.DriftCheckBaselines_Explainability_ConfigFile_ContentDigest;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile.ContentDigest = requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_ContentDigest;
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFileIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_ContentType = null;
            if (cmdletContext.DriftCheckBaselines_Explainability_ConfigFile_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_ContentType = cmdletContext.DriftCheckBaselines_Explainability_ConfigFile_ContentType;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile.ContentType = requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_ContentType;
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFileIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_S3Uri = null;
            if (cmdletContext.DriftCheckBaselines_Explainability_ConfigFile_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_S3Uri = cmdletContext.DriftCheckBaselines_Explainability_ConfigFile_S3Uri;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile.S3Uri = requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile_driftCheckBaselines_Explainability_ConfigFile_S3Uri;
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFileIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFileIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability.ConfigFile = requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConfigFile;
                requestDriftCheckBaselines_driftCheckBaselines_ExplainabilityIsNull = false;
            }
            Amazon.SageMaker.Model.MetricsSource requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints = null;
            
             // populate Constraints
            var requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConstraintsIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_ContentDigest = null;
            if (cmdletContext.DriftCheckBaselines_Explainability_Constraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_ContentDigest = cmdletContext.DriftCheckBaselines_Explainability_Constraints_ContentDigest;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints.ContentDigest = requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_ContentDigest;
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_ContentType = null;
            if (cmdletContext.DriftCheckBaselines_Explainability_Constraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_ContentType = cmdletContext.DriftCheckBaselines_Explainability_Constraints_ContentType;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints.ContentType = requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_ContentType;
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_S3Uri = null;
            if (cmdletContext.DriftCheckBaselines_Explainability_Constraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_S3Uri = cmdletContext.DriftCheckBaselines_Explainability_Constraints_S3Uri;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints.S3Uri = requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints_driftCheckBaselines_Explainability_Constraints_S3Uri;
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConstraintsIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_ConstraintsIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability.Constraints = requestDriftCheckBaselines_driftCheckBaselines_Explainability_driftCheckBaselines_Explainability_Constraints;
                requestDriftCheckBaselines_driftCheckBaselines_ExplainabilityIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_Explainability should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_ExplainabilityIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Explainability = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Explainability != null)
            {
                request.DriftCheckBaselines.Explainability = requestDriftCheckBaselines_driftCheckBaselines_Explainability;
                requestDriftCheckBaselinesIsNull = false;
            }
            Amazon.SageMaker.Model.DriftCheckModelDataQuality requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality = null;
            
             // populate ModelDataQuality
            var requestDriftCheckBaselines_driftCheckBaselines_ModelDataQualityIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality = new Amazon.SageMaker.Model.DriftCheckModelDataQuality();
            Amazon.SageMaker.Model.MetricsSource requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints = null;
            
             // populate Constraints
            var requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_ConstraintsIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_ContentDigest = null;
            if (cmdletContext.DriftCheckBaselines_ModelDataQuality_Constraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_ContentDigest = cmdletContext.DriftCheckBaselines_ModelDataQuality_Constraints_ContentDigest;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints.ContentDigest = requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_ContentDigest;
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_ConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_ContentType = null;
            if (cmdletContext.DriftCheckBaselines_ModelDataQuality_Constraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_ContentType = cmdletContext.DriftCheckBaselines_ModelDataQuality_Constraints_ContentType;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints.ContentType = requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_ContentType;
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_ConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_S3Uri = null;
            if (cmdletContext.DriftCheckBaselines_ModelDataQuality_Constraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_S3Uri = cmdletContext.DriftCheckBaselines_ModelDataQuality_Constraints_S3Uri;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints.S3Uri = requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints_driftCheckBaselines_ModelDataQuality_Constraints_S3Uri;
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_ConstraintsIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_ConstraintsIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality.Constraints = requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Constraints;
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQualityIsNull = false;
            }
            Amazon.SageMaker.Model.MetricsSource requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics = null;
            
             // populate Statistics
            var requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_StatisticsIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_ContentDigest = null;
            if (cmdletContext.DriftCheckBaselines_ModelDataQuality_Statistics_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_ContentDigest = cmdletContext.DriftCheckBaselines_ModelDataQuality_Statistics_ContentDigest;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics.ContentDigest = requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_ContentDigest;
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_StatisticsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_ContentType = null;
            if (cmdletContext.DriftCheckBaselines_ModelDataQuality_Statistics_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_ContentType = cmdletContext.DriftCheckBaselines_ModelDataQuality_Statistics_ContentType;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics.ContentType = requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_ContentType;
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_StatisticsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_S3Uri = null;
            if (cmdletContext.DriftCheckBaselines_ModelDataQuality_Statistics_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_S3Uri = cmdletContext.DriftCheckBaselines_ModelDataQuality_Statistics_S3Uri;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics.S3Uri = requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics_driftCheckBaselines_ModelDataQuality_Statistics_S3Uri;
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_StatisticsIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_StatisticsIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality.Statistics = requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality_driftCheckBaselines_ModelDataQuality_Statistics;
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQualityIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQualityIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality != null)
            {
                request.DriftCheckBaselines.ModelDataQuality = requestDriftCheckBaselines_driftCheckBaselines_ModelDataQuality;
                requestDriftCheckBaselinesIsNull = false;
            }
            Amazon.SageMaker.Model.DriftCheckModelQuality requestDriftCheckBaselines_driftCheckBaselines_ModelQuality = null;
            
             // populate ModelQuality
            var requestDriftCheckBaselines_driftCheckBaselines_ModelQualityIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_ModelQuality = new Amazon.SageMaker.Model.DriftCheckModelQuality();
            Amazon.SageMaker.Model.MetricsSource requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints = null;
            
             // populate Constraints
            var requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_ConstraintsIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_ContentDigest = null;
            if (cmdletContext.DriftCheckBaselines_ModelQuality_Constraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_ContentDigest = cmdletContext.DriftCheckBaselines_ModelQuality_Constraints_ContentDigest;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints.ContentDigest = requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_ContentDigest;
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_ConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_ContentType = null;
            if (cmdletContext.DriftCheckBaselines_ModelQuality_Constraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_ContentType = cmdletContext.DriftCheckBaselines_ModelQuality_Constraints_ContentType;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints.ContentType = requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_ContentType;
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_ConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_S3Uri = null;
            if (cmdletContext.DriftCheckBaselines_ModelQuality_Constraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_S3Uri = cmdletContext.DriftCheckBaselines_ModelQuality_Constraints_S3Uri;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints.S3Uri = requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints_driftCheckBaselines_ModelQuality_Constraints_S3Uri;
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_ConstraintsIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_ConstraintsIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality.Constraints = requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Constraints;
                requestDriftCheckBaselines_driftCheckBaselines_ModelQualityIsNull = false;
            }
            Amazon.SageMaker.Model.MetricsSource requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics = null;
            
             // populate Statistics
            var requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_StatisticsIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_ContentDigest = null;
            if (cmdletContext.DriftCheckBaselines_ModelQuality_Statistics_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_ContentDigest = cmdletContext.DriftCheckBaselines_ModelQuality_Statistics_ContentDigest;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics.ContentDigest = requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_ContentDigest;
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_StatisticsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_ContentType = null;
            if (cmdletContext.DriftCheckBaselines_ModelQuality_Statistics_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_ContentType = cmdletContext.DriftCheckBaselines_ModelQuality_Statistics_ContentType;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics.ContentType = requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_ContentType;
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_StatisticsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_S3Uri = null;
            if (cmdletContext.DriftCheckBaselines_ModelQuality_Statistics_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_S3Uri = cmdletContext.DriftCheckBaselines_ModelQuality_Statistics_S3Uri;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics.S3Uri = requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics_driftCheckBaselines_ModelQuality_Statistics_S3Uri;
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_StatisticsIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_StatisticsIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality.Statistics = requestDriftCheckBaselines_driftCheckBaselines_ModelQuality_driftCheckBaselines_ModelQuality_Statistics;
                requestDriftCheckBaselines_driftCheckBaselines_ModelQualityIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_ModelQuality should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQualityIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_ModelQuality = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_ModelQuality != null)
            {
                request.DriftCheckBaselines.ModelQuality = requestDriftCheckBaselines_driftCheckBaselines_ModelQuality;
                requestDriftCheckBaselinesIsNull = false;
            }
            Amazon.SageMaker.Model.DriftCheckBias requestDriftCheckBaselines_driftCheckBaselines_Bias = null;
            
             // populate Bias
            var requestDriftCheckBaselines_driftCheckBaselines_BiasIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_Bias = new Amazon.SageMaker.Model.DriftCheckBias();
            Amazon.SageMaker.Model.FileSource requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile = null;
            
             // populate ConfigFile
            var requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFileIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile = new Amazon.SageMaker.Model.FileSource();
            System.String requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_ContentDigest = null;
            if (cmdletContext.DriftCheckBaselines_Bias_ConfigFile_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_ContentDigest = cmdletContext.DriftCheckBaselines_Bias_ConfigFile_ContentDigest;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile.ContentDigest = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_ContentDigest;
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFileIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_ContentType = null;
            if (cmdletContext.DriftCheckBaselines_Bias_ConfigFile_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_ContentType = cmdletContext.DriftCheckBaselines_Bias_ConfigFile_ContentType;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile.ContentType = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_ContentType;
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFileIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_S3Uri = null;
            if (cmdletContext.DriftCheckBaselines_Bias_ConfigFile_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_S3Uri = cmdletContext.DriftCheckBaselines_Bias_ConfigFile_S3Uri;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile.S3Uri = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile_driftCheckBaselines_Bias_ConfigFile_S3Uri;
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFileIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFileIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias.ConfigFile = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_ConfigFile;
                requestDriftCheckBaselines_driftCheckBaselines_BiasIsNull = false;
            }
            Amazon.SageMaker.Model.MetricsSource requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints = null;
            
             // populate PostTrainingConstraints
            var requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraintsIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_ContentDigest = null;
            if (cmdletContext.PostTrainingConstraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_ContentDigest = cmdletContext.PostTrainingConstraints_ContentDigest;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints.ContentDigest = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_ContentDigest;
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_ContentType = null;
            if (cmdletContext.PostTrainingConstraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_ContentType = cmdletContext.PostTrainingConstraints_ContentType;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints.ContentType = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_ContentType;
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_S3Uri = null;
            if (cmdletContext.PostTrainingConstraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_S3Uri = cmdletContext.PostTrainingConstraints_S3Uri;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints.S3Uri = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints_postTrainingConstraints_S3Uri;
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraintsIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraintsIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias.PostTrainingConstraints = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PostTrainingConstraints;
                requestDriftCheckBaselines_driftCheckBaselines_BiasIsNull = false;
            }
            Amazon.SageMaker.Model.MetricsSource requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints = null;
            
             // populate PreTrainingConstraints
            var requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraintsIsNull = true;
            requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_ContentDigest = null;
            if (cmdletContext.PreTrainingConstraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_ContentDigest = cmdletContext.PreTrainingConstraints_ContentDigest;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_ContentDigest != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints.ContentDigest = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_ContentDigest;
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_ContentType = null;
            if (cmdletContext.PreTrainingConstraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_ContentType = cmdletContext.PreTrainingConstraints_ContentType;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_ContentType != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints.ContentType = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_ContentType;
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraintsIsNull = false;
            }
            System.String requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_S3Uri = null;
            if (cmdletContext.PreTrainingConstraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_S3Uri = cmdletContext.PreTrainingConstraints_S3Uri;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_S3Uri != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints.S3Uri = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints_preTrainingConstraints_S3Uri;
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraintsIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraintsIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints != null)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias.PreTrainingConstraints = requestDriftCheckBaselines_driftCheckBaselines_Bias_driftCheckBaselines_Bias_PreTrainingConstraints;
                requestDriftCheckBaselines_driftCheckBaselines_BiasIsNull = false;
            }
             // determine if requestDriftCheckBaselines_driftCheckBaselines_Bias should be set to null
            if (requestDriftCheckBaselines_driftCheckBaselines_BiasIsNull)
            {
                requestDriftCheckBaselines_driftCheckBaselines_Bias = null;
            }
            if (requestDriftCheckBaselines_driftCheckBaselines_Bias != null)
            {
                request.DriftCheckBaselines.Bias = requestDriftCheckBaselines_driftCheckBaselines_Bias;
                requestDriftCheckBaselinesIsNull = false;
            }
             // determine if request.DriftCheckBaselines should be set to null
            if (requestDriftCheckBaselinesIsNull)
            {
                request.DriftCheckBaselines = null;
            }
            
             // populate InferenceSpecification
            var requestInferenceSpecificationIsNull = true;
            request.InferenceSpecification = new Amazon.SageMaker.Model.InferenceSpecification();
            List<Amazon.SageMaker.Model.ModelPackageContainerDefinition> requestInferenceSpecification_inferenceSpecification_Container = null;
            if (cmdletContext.InferenceSpecification_Container != null)
            {
                requestInferenceSpecification_inferenceSpecification_Container = cmdletContext.InferenceSpecification_Container;
            }
            if (requestInferenceSpecification_inferenceSpecification_Container != null)
            {
                request.InferenceSpecification.Containers = requestInferenceSpecification_inferenceSpecification_Container;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedContentType = null;
            if (cmdletContext.InferenceSpecification_SupportedContentType != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedContentType = cmdletContext.InferenceSpecification_SupportedContentType;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedContentType != null)
            {
                request.InferenceSpecification.SupportedContentTypes = requestInferenceSpecification_inferenceSpecification_SupportedContentType;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType = null;
            if (cmdletContext.InferenceSpecification_SupportedRealtimeInferenceInstanceType != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType = cmdletContext.InferenceSpecification_SupportedRealtimeInferenceInstanceType;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType != null)
            {
                request.InferenceSpecification.SupportedRealtimeInferenceInstanceTypes = requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType = null;
            if (cmdletContext.InferenceSpecification_SupportedResponseMIMEType != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType = cmdletContext.InferenceSpecification_SupportedResponseMIMEType;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType != null)
            {
                request.InferenceSpecification.SupportedResponseMIMETypes = requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType = null;
            if (cmdletContext.InferenceSpecification_SupportedTransformInstanceType != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType = cmdletContext.InferenceSpecification_SupportedTransformInstanceType;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType != null)
            {
                request.InferenceSpecification.SupportedTransformInstanceTypes = requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType;
                requestInferenceSpecificationIsNull = false;
            }
             // determine if request.InferenceSpecification should be set to null
            if (requestInferenceSpecificationIsNull)
            {
                request.InferenceSpecification = null;
            }
            
             // populate MetadataProperties
            var requestMetadataPropertiesIsNull = true;
            request.MetadataProperties = new Amazon.SageMaker.Model.MetadataProperties();
            System.String requestMetadataProperties_metadataProperties_CommitId = null;
            if (cmdletContext.MetadataProperties_CommitId != null)
            {
                requestMetadataProperties_metadataProperties_CommitId = cmdletContext.MetadataProperties_CommitId;
            }
            if (requestMetadataProperties_metadataProperties_CommitId != null)
            {
                request.MetadataProperties.CommitId = requestMetadataProperties_metadataProperties_CommitId;
                requestMetadataPropertiesIsNull = false;
            }
            System.String requestMetadataProperties_metadataProperties_GeneratedBy = null;
            if (cmdletContext.MetadataProperties_GeneratedBy != null)
            {
                requestMetadataProperties_metadataProperties_GeneratedBy = cmdletContext.MetadataProperties_GeneratedBy;
            }
            if (requestMetadataProperties_metadataProperties_GeneratedBy != null)
            {
                request.MetadataProperties.GeneratedBy = requestMetadataProperties_metadataProperties_GeneratedBy;
                requestMetadataPropertiesIsNull = false;
            }
            System.String requestMetadataProperties_metadataProperties_ProjectId = null;
            if (cmdletContext.MetadataProperties_ProjectId != null)
            {
                requestMetadataProperties_metadataProperties_ProjectId = cmdletContext.MetadataProperties_ProjectId;
            }
            if (requestMetadataProperties_metadataProperties_ProjectId != null)
            {
                request.MetadataProperties.ProjectId = requestMetadataProperties_metadataProperties_ProjectId;
                requestMetadataPropertiesIsNull = false;
            }
            System.String requestMetadataProperties_metadataProperties_Repository = null;
            if (cmdletContext.MetadataProperties_Repository != null)
            {
                requestMetadataProperties_metadataProperties_Repository = cmdletContext.MetadataProperties_Repository;
            }
            if (requestMetadataProperties_metadataProperties_Repository != null)
            {
                request.MetadataProperties.Repository = requestMetadataProperties_metadataProperties_Repository;
                requestMetadataPropertiesIsNull = false;
            }
             // determine if request.MetadataProperties should be set to null
            if (requestMetadataPropertiesIsNull)
            {
                request.MetadataProperties = null;
            }
            if (cmdletContext.ModelApprovalStatus != null)
            {
                request.ModelApprovalStatus = cmdletContext.ModelApprovalStatus;
            }
            
             // populate ModelCard
            var requestModelCardIsNull = true;
            request.ModelCard = new Amazon.SageMaker.Model.ModelPackageModelCard();
            System.String requestModelCard_modelCard_ModelCardContent = null;
            if (cmdletContext.ModelCard_ModelCardContent != null)
            {
                requestModelCard_modelCard_ModelCardContent = cmdletContext.ModelCard_ModelCardContent;
            }
            if (requestModelCard_modelCard_ModelCardContent != null)
            {
                request.ModelCard.ModelCardContent = requestModelCard_modelCard_ModelCardContent;
                requestModelCardIsNull = false;
            }
            Amazon.SageMaker.ModelCardStatus requestModelCard_modelCard_ModelCardStatus = null;
            if (cmdletContext.ModelCard_ModelCardStatus != null)
            {
                requestModelCard_modelCard_ModelCardStatus = cmdletContext.ModelCard_ModelCardStatus;
            }
            if (requestModelCard_modelCard_ModelCardStatus != null)
            {
                request.ModelCard.ModelCardStatus = requestModelCard_modelCard_ModelCardStatus;
                requestModelCardIsNull = false;
            }
             // determine if request.ModelCard should be set to null
            if (requestModelCardIsNull)
            {
                request.ModelCard = null;
            }
            
             // populate ModelLifeCycle
            var requestModelLifeCycleIsNull = true;
            request.ModelLifeCycle = new Amazon.SageMaker.Model.ModelLifeCycle();
            System.String requestModelLifeCycle_modelLifeCycle_Stage = null;
            if (cmdletContext.ModelLifeCycle_Stage != null)
            {
                requestModelLifeCycle_modelLifeCycle_Stage = cmdletContext.ModelLifeCycle_Stage;
            }
            if (requestModelLifeCycle_modelLifeCycle_Stage != null)
            {
                request.ModelLifeCycle.Stage = requestModelLifeCycle_modelLifeCycle_Stage;
                requestModelLifeCycleIsNull = false;
            }
            System.String requestModelLifeCycle_modelLifeCycle_StageDescription = null;
            if (cmdletContext.ModelLifeCycle_StageDescription != null)
            {
                requestModelLifeCycle_modelLifeCycle_StageDescription = cmdletContext.ModelLifeCycle_StageDescription;
            }
            if (requestModelLifeCycle_modelLifeCycle_StageDescription != null)
            {
                request.ModelLifeCycle.StageDescription = requestModelLifeCycle_modelLifeCycle_StageDescription;
                requestModelLifeCycleIsNull = false;
            }
            System.String requestModelLifeCycle_modelLifeCycle_StageStatus = null;
            if (cmdletContext.ModelLifeCycle_StageStatus != null)
            {
                requestModelLifeCycle_modelLifeCycle_StageStatus = cmdletContext.ModelLifeCycle_StageStatus;
            }
            if (requestModelLifeCycle_modelLifeCycle_StageStatus != null)
            {
                request.ModelLifeCycle.StageStatus = requestModelLifeCycle_modelLifeCycle_StageStatus;
                requestModelLifeCycleIsNull = false;
            }
             // determine if request.ModelLifeCycle should be set to null
            if (requestModelLifeCycleIsNull)
            {
                request.ModelLifeCycle = null;
            }
            
             // populate ModelMetrics
            var requestModelMetricsIsNull = true;
            request.ModelMetrics = new Amazon.SageMaker.Model.ModelMetrics();
            Amazon.SageMaker.Model.Explainability requestModelMetrics_modelMetrics_Explainability = null;
            
             // populate Explainability
            var requestModelMetrics_modelMetrics_ExplainabilityIsNull = true;
            requestModelMetrics_modelMetrics_Explainability = new Amazon.SageMaker.Model.Explainability();
            Amazon.SageMaker.Model.MetricsSource requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report = null;
            
             // populate Report
            var requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_ReportIsNull = true;
            requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_ContentDigest = null;
            if (cmdletContext.ModelMetrics_Explainability_Report_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_ContentDigest = cmdletContext.ModelMetrics_Explainability_Report_ContentDigest;
            }
            if (requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report.ContentDigest = requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_ContentDigest;
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_ReportIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_ContentType = null;
            if (cmdletContext.ModelMetrics_Explainability_Report_ContentType != null)
            {
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_ContentType = cmdletContext.ModelMetrics_Explainability_Report_ContentType;
            }
            if (requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_ContentType != null)
            {
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report.ContentType = requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_ContentType;
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_ReportIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_S3Uri = null;
            if (cmdletContext.ModelMetrics_Explainability_Report_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_S3Uri = cmdletContext.ModelMetrics_Explainability_Report_S3Uri;
            }
            if (requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report.S3Uri = requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report_modelMetrics_Explainability_Report_S3Uri;
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_ReportIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report should be set to null
            if (requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_ReportIsNull)
            {
                requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report = null;
            }
            if (requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report != null)
            {
                requestModelMetrics_modelMetrics_Explainability.Report = requestModelMetrics_modelMetrics_Explainability_modelMetrics_Explainability_Report;
                requestModelMetrics_modelMetrics_ExplainabilityIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_Explainability should be set to null
            if (requestModelMetrics_modelMetrics_ExplainabilityIsNull)
            {
                requestModelMetrics_modelMetrics_Explainability = null;
            }
            if (requestModelMetrics_modelMetrics_Explainability != null)
            {
                request.ModelMetrics.Explainability = requestModelMetrics_modelMetrics_Explainability;
                requestModelMetricsIsNull = false;
            }
            Amazon.SageMaker.Model.ModelDataQuality requestModelMetrics_modelMetrics_ModelDataQuality = null;
            
             // populate ModelDataQuality
            var requestModelMetrics_modelMetrics_ModelDataQualityIsNull = true;
            requestModelMetrics_modelMetrics_ModelDataQuality = new Amazon.SageMaker.Model.ModelDataQuality();
            Amazon.SageMaker.Model.MetricsSource requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints = null;
            
             // populate Constraints
            var requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_ConstraintsIsNull = true;
            requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_ContentDigest = null;
            if (cmdletContext.ModelMetrics_ModelDataQuality_Constraints_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_ContentDigest = cmdletContext.ModelMetrics_ModelDataQuality_Constraints_ContentDigest;
            }
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints.ContentDigest = requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_ContentDigest;
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_ConstraintsIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_ContentType = null;
            if (cmdletContext.ModelMetrics_ModelDataQuality_Constraints_ContentType != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_ContentType = cmdletContext.ModelMetrics_ModelDataQuality_Constraints_ContentType;
            }
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_ContentType != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints.ContentType = requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_ContentType;
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_ConstraintsIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_S3Uri = null;
            if (cmdletContext.ModelMetrics_ModelDataQuality_Constraints_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_S3Uri = cmdletContext.ModelMetrics_ModelDataQuality_Constraints_S3Uri;
            }
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints.S3Uri = requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints_modelMetrics_ModelDataQuality_Constraints_S3Uri;
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_ConstraintsIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints should be set to null
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_ConstraintsIsNull)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints = null;
            }
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality.Constraints = requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Constraints;
                requestModelMetrics_modelMetrics_ModelDataQualityIsNull = false;
            }
            Amazon.SageMaker.Model.MetricsSource requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics = null;
            
             // populate Statistics
            var requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_StatisticsIsNull = true;
            requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_ContentDigest = null;
            if (cmdletContext.ModelMetrics_ModelDataQuality_Statistics_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_ContentDigest = cmdletContext.ModelMetrics_ModelDataQuality_Statistics_ContentDigest;
            }
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics.ContentDigest = requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_ContentDigest;
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_StatisticsIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_ContentType = null;
            if (cmdletContext.ModelMetrics_ModelDataQuality_Statistics_ContentType != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_ContentType = cmdletContext.ModelMetrics_ModelDataQuality_Statistics_ContentType;
            }
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_ContentType != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics.ContentType = requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_ContentType;
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_StatisticsIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_S3Uri = null;
            if (cmdletContext.ModelMetrics_ModelDataQuality_Statistics_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_S3Uri = cmdletContext.ModelMetrics_ModelDataQuality_Statistics_S3Uri;
            }
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics.S3Uri = requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics_modelMetrics_ModelDataQuality_Statistics_S3Uri;
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_StatisticsIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics should be set to null
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_StatisticsIsNull)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics = null;
            }
            if (requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics != null)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality.Statistics = requestModelMetrics_modelMetrics_ModelDataQuality_modelMetrics_ModelDataQuality_Statistics;
                requestModelMetrics_modelMetrics_ModelDataQualityIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_ModelDataQuality should be set to null
            if (requestModelMetrics_modelMetrics_ModelDataQualityIsNull)
            {
                requestModelMetrics_modelMetrics_ModelDataQuality = null;
            }
            if (requestModelMetrics_modelMetrics_ModelDataQuality != null)
            {
                request.ModelMetrics.ModelDataQuality = requestModelMetrics_modelMetrics_ModelDataQuality;
                requestModelMetricsIsNull = false;
            }
            Amazon.SageMaker.Model.ModelQuality requestModelMetrics_modelMetrics_ModelQuality = null;
            
             // populate ModelQuality
            var requestModelMetrics_modelMetrics_ModelQualityIsNull = true;
            requestModelMetrics_modelMetrics_ModelQuality = new Amazon.SageMaker.Model.ModelQuality();
            Amazon.SageMaker.Model.MetricsSource requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints = null;
            
             // populate Constraints
            var requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_ConstraintsIsNull = true;
            requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_ContentDigest = null;
            if (cmdletContext.ModelMetrics_ModelQuality_Constraints_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_ContentDigest = cmdletContext.ModelMetrics_ModelQuality_Constraints_ContentDigest;
            }
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints.ContentDigest = requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_ContentDigest;
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_ConstraintsIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_ContentType = null;
            if (cmdletContext.ModelMetrics_ModelQuality_Constraints_ContentType != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_ContentType = cmdletContext.ModelMetrics_ModelQuality_Constraints_ContentType;
            }
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_ContentType != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints.ContentType = requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_ContentType;
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_ConstraintsIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_S3Uri = null;
            if (cmdletContext.ModelMetrics_ModelQuality_Constraints_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_S3Uri = cmdletContext.ModelMetrics_ModelQuality_Constraints_S3Uri;
            }
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints.S3Uri = requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints_modelMetrics_ModelQuality_Constraints_S3Uri;
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_ConstraintsIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints should be set to null
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_ConstraintsIsNull)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints = null;
            }
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality.Constraints = requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Constraints;
                requestModelMetrics_modelMetrics_ModelQualityIsNull = false;
            }
            Amazon.SageMaker.Model.MetricsSource requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics = null;
            
             // populate Statistics
            var requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_StatisticsIsNull = true;
            requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_ContentDigest = null;
            if (cmdletContext.ModelMetrics_ModelQuality_Statistics_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_ContentDigest = cmdletContext.ModelMetrics_ModelQuality_Statistics_ContentDigest;
            }
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics.ContentDigest = requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_ContentDigest;
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_StatisticsIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_ContentType = null;
            if (cmdletContext.ModelMetrics_ModelQuality_Statistics_ContentType != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_ContentType = cmdletContext.ModelMetrics_ModelQuality_Statistics_ContentType;
            }
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_ContentType != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics.ContentType = requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_ContentType;
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_StatisticsIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_S3Uri = null;
            if (cmdletContext.ModelMetrics_ModelQuality_Statistics_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_S3Uri = cmdletContext.ModelMetrics_ModelQuality_Statistics_S3Uri;
            }
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics.S3Uri = requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics_modelMetrics_ModelQuality_Statistics_S3Uri;
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_StatisticsIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics should be set to null
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_StatisticsIsNull)
            {
                requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics = null;
            }
            if (requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics != null)
            {
                requestModelMetrics_modelMetrics_ModelQuality.Statistics = requestModelMetrics_modelMetrics_ModelQuality_modelMetrics_ModelQuality_Statistics;
                requestModelMetrics_modelMetrics_ModelQualityIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_ModelQuality should be set to null
            if (requestModelMetrics_modelMetrics_ModelQualityIsNull)
            {
                requestModelMetrics_modelMetrics_ModelQuality = null;
            }
            if (requestModelMetrics_modelMetrics_ModelQuality != null)
            {
                request.ModelMetrics.ModelQuality = requestModelMetrics_modelMetrics_ModelQuality;
                requestModelMetricsIsNull = false;
            }
            Amazon.SageMaker.Model.Bias requestModelMetrics_modelMetrics_Bias = null;
            
             // populate Bias
            var requestModelMetrics_modelMetrics_BiasIsNull = true;
            requestModelMetrics_modelMetrics_Bias = new Amazon.SageMaker.Model.Bias();
            Amazon.SageMaker.Model.MetricsSource requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport = null;
            
             // populate PostTrainingReport
            var requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReportIsNull = true;
            requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_ContentDigest = null;
            if (cmdletContext.PostTrainingReport_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_ContentDigest = cmdletContext.PostTrainingReport_ContentDigest;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport.ContentDigest = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_ContentDigest;
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReportIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_ContentType = null;
            if (cmdletContext.PostTrainingReport_ContentType != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_ContentType = cmdletContext.PostTrainingReport_ContentType;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_ContentType != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport.ContentType = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_ContentType;
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReportIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_S3Uri = null;
            if (cmdletContext.PostTrainingReport_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_S3Uri = cmdletContext.PostTrainingReport_S3Uri;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport.S3Uri = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport_postTrainingReport_S3Uri;
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReportIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport should be set to null
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReportIsNull)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport = null;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport != null)
            {
                requestModelMetrics_modelMetrics_Bias.PostTrainingReport = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PostTrainingReport;
                requestModelMetrics_modelMetrics_BiasIsNull = false;
            }
            Amazon.SageMaker.Model.MetricsSource requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport = null;
            
             // populate PreTrainingReport
            var requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReportIsNull = true;
            requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_ContentDigest = null;
            if (cmdletContext.PreTrainingReport_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_ContentDigest = cmdletContext.PreTrainingReport_ContentDigest;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport.ContentDigest = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_ContentDigest;
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReportIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_ContentType = null;
            if (cmdletContext.PreTrainingReport_ContentType != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_ContentType = cmdletContext.PreTrainingReport_ContentType;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_ContentType != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport.ContentType = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_ContentType;
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReportIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_S3Uri = null;
            if (cmdletContext.PreTrainingReport_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_S3Uri = cmdletContext.PreTrainingReport_S3Uri;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport.S3Uri = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport_preTrainingReport_S3Uri;
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReportIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport should be set to null
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReportIsNull)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport = null;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport != null)
            {
                requestModelMetrics_modelMetrics_Bias.PreTrainingReport = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_PreTrainingReport;
                requestModelMetrics_modelMetrics_BiasIsNull = false;
            }
            Amazon.SageMaker.Model.MetricsSource requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report = null;
            
             // populate Report
            var requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_ReportIsNull = true;
            requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report = new Amazon.SageMaker.Model.MetricsSource();
            System.String requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_ContentDigest = null;
            if (cmdletContext.ModelMetrics_Bias_Report_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_ContentDigest = cmdletContext.ModelMetrics_Bias_Report_ContentDigest;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_ContentDigest != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report.ContentDigest = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_ContentDigest;
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_ReportIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_ContentType = null;
            if (cmdletContext.ModelMetrics_Bias_Report_ContentType != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_ContentType = cmdletContext.ModelMetrics_Bias_Report_ContentType;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_ContentType != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report.ContentType = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_ContentType;
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_ReportIsNull = false;
            }
            System.String requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_S3Uri = null;
            if (cmdletContext.ModelMetrics_Bias_Report_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_S3Uri = cmdletContext.ModelMetrics_Bias_Report_S3Uri;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_S3Uri != null)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report.S3Uri = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report_modelMetrics_Bias_Report_S3Uri;
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_ReportIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report should be set to null
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_ReportIsNull)
            {
                requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report = null;
            }
            if (requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report != null)
            {
                requestModelMetrics_modelMetrics_Bias.Report = requestModelMetrics_modelMetrics_Bias_modelMetrics_Bias_Report;
                requestModelMetrics_modelMetrics_BiasIsNull = false;
            }
             // determine if requestModelMetrics_modelMetrics_Bias should be set to null
            if (requestModelMetrics_modelMetrics_BiasIsNull)
            {
                requestModelMetrics_modelMetrics_Bias = null;
            }
            if (requestModelMetrics_modelMetrics_Bias != null)
            {
                request.ModelMetrics.Bias = requestModelMetrics_modelMetrics_Bias;
                requestModelMetricsIsNull = false;
            }
             // determine if request.ModelMetrics should be set to null
            if (requestModelMetricsIsNull)
            {
                request.ModelMetrics = null;
            }
            if (cmdletContext.ModelPackageDescription != null)
            {
                request.ModelPackageDescription = cmdletContext.ModelPackageDescription;
            }
            if (cmdletContext.ModelPackageGroupName != null)
            {
                request.ModelPackageGroupName = cmdletContext.ModelPackageGroupName;
            }
            if (cmdletContext.ModelPackageName != null)
            {
                request.ModelPackageName = cmdletContext.ModelPackageName;
            }
            if (cmdletContext.SamplePayloadUrl != null)
            {
                request.SamplePayloadUrl = cmdletContext.SamplePayloadUrl;
            }
            
             // populate SecurityConfig
            var requestSecurityConfigIsNull = true;
            request.SecurityConfig = new Amazon.SageMaker.Model.ModelPackageSecurityConfig();
            System.String requestSecurityConfig_securityConfig_KmsKeyId = null;
            if (cmdletContext.SecurityConfig_KmsKeyId != null)
            {
                requestSecurityConfig_securityConfig_KmsKeyId = cmdletContext.SecurityConfig_KmsKeyId;
            }
            if (requestSecurityConfig_securityConfig_KmsKeyId != null)
            {
                request.SecurityConfig.KmsKeyId = requestSecurityConfig_securityConfig_KmsKeyId;
                requestSecurityConfigIsNull = false;
            }
             // determine if request.SecurityConfig should be set to null
            if (requestSecurityConfigIsNull)
            {
                request.SecurityConfig = null;
            }
            if (cmdletContext.SkipModelValidation != null)
            {
                request.SkipModelValidation = cmdletContext.SkipModelValidation;
            }
            
             // populate SourceAlgorithmSpecification
            var requestSourceAlgorithmSpecificationIsNull = true;
            request.SourceAlgorithmSpecification = new Amazon.SageMaker.Model.SourceAlgorithmSpecification();
            List<Amazon.SageMaker.Model.SourceAlgorithm> requestSourceAlgorithmSpecification_sourceAlgorithmSpecification_SourceAlgorithm = null;
            if (cmdletContext.SourceAlgorithmSpecification_SourceAlgorithm != null)
            {
                requestSourceAlgorithmSpecification_sourceAlgorithmSpecification_SourceAlgorithm = cmdletContext.SourceAlgorithmSpecification_SourceAlgorithm;
            }
            if (requestSourceAlgorithmSpecification_sourceAlgorithmSpecification_SourceAlgorithm != null)
            {
                request.SourceAlgorithmSpecification.SourceAlgorithms = requestSourceAlgorithmSpecification_sourceAlgorithmSpecification_SourceAlgorithm;
                requestSourceAlgorithmSpecificationIsNull = false;
            }
             // determine if request.SourceAlgorithmSpecification should be set to null
            if (requestSourceAlgorithmSpecificationIsNull)
            {
                request.SourceAlgorithmSpecification = null;
            }
            if (cmdletContext.SourceUri != null)
            {
                request.SourceUri = cmdletContext.SourceUri;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Task != null)
            {
                request.Task = cmdletContext.Task;
            }
            
             // populate ValidationSpecification
            var requestValidationSpecificationIsNull = true;
            request.ValidationSpecification = new Amazon.SageMaker.Model.ModelPackageValidationSpecification();
            List<Amazon.SageMaker.Model.ModelPackageValidationProfile> requestValidationSpecification_validationSpecification_ValidationProfile = null;
            if (cmdletContext.ValidationSpecification_ValidationProfile != null)
            {
                requestValidationSpecification_validationSpecification_ValidationProfile = cmdletContext.ValidationSpecification_ValidationProfile;
            }
            if (requestValidationSpecification_validationSpecification_ValidationProfile != null)
            {
                request.ValidationSpecification.ValidationProfiles = requestValidationSpecification_validationSpecification_ValidationProfile;
                requestValidationSpecificationIsNull = false;
            }
            System.String requestValidationSpecification_validationSpecification_ValidationRole = null;
            if (cmdletContext.ValidationSpecification_ValidationRole != null)
            {
                requestValidationSpecification_validationSpecification_ValidationRole = cmdletContext.ValidationSpecification_ValidationRole;
            }
            if (requestValidationSpecification_validationSpecification_ValidationRole != null)
            {
                request.ValidationSpecification.ValidationRole = requestValidationSpecification_validationSpecification_ValidationRole;
                requestValidationSpecificationIsNull = false;
            }
             // determine if request.ValidationSpecification should be set to null
            if (requestValidationSpecificationIsNull)
            {
                request.ValidationSpecification = null;
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
        
        private Amazon.SageMaker.Model.CreateModelPackageResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateModelPackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateModelPackage");
            try
            {
                #if DESKTOP
                return client.CreateModelPackage(request);
                #elif CORECLR
                return client.CreateModelPackageAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.AdditionalInferenceSpecificationDefinition> AdditionalInferenceSpecification { get; set; }
            public System.Boolean? CertifyForMarketplace { get; set; }
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, System.String> CustomerMetadataProperty { get; set; }
            public System.String Domain { get; set; }
            public System.String DriftCheckBaselines_Bias_ConfigFile_ContentDigest { get; set; }
            public System.String DriftCheckBaselines_Bias_ConfigFile_ContentType { get; set; }
            public System.String DriftCheckBaselines_Bias_ConfigFile_S3Uri { get; set; }
            public System.String PostTrainingConstraints_ContentDigest { get; set; }
            public System.String PostTrainingConstraints_ContentType { get; set; }
            public System.String PostTrainingConstraints_S3Uri { get; set; }
            public System.String PreTrainingConstraints_ContentDigest { get; set; }
            public System.String PreTrainingConstraints_ContentType { get; set; }
            public System.String PreTrainingConstraints_S3Uri { get; set; }
            public System.String DriftCheckBaselines_Explainability_ConfigFile_ContentDigest { get; set; }
            public System.String DriftCheckBaselines_Explainability_ConfigFile_ContentType { get; set; }
            public System.String DriftCheckBaselines_Explainability_ConfigFile_S3Uri { get; set; }
            public System.String DriftCheckBaselines_Explainability_Constraints_ContentDigest { get; set; }
            public System.String DriftCheckBaselines_Explainability_Constraints_ContentType { get; set; }
            public System.String DriftCheckBaselines_Explainability_Constraints_S3Uri { get; set; }
            public System.String DriftCheckBaselines_ModelDataQuality_Constraints_ContentDigest { get; set; }
            public System.String DriftCheckBaselines_ModelDataQuality_Constraints_ContentType { get; set; }
            public System.String DriftCheckBaselines_ModelDataQuality_Constraints_S3Uri { get; set; }
            public System.String DriftCheckBaselines_ModelDataQuality_Statistics_ContentDigest { get; set; }
            public System.String DriftCheckBaselines_ModelDataQuality_Statistics_ContentType { get; set; }
            public System.String DriftCheckBaselines_ModelDataQuality_Statistics_S3Uri { get; set; }
            public System.String DriftCheckBaselines_ModelQuality_Constraints_ContentDigest { get; set; }
            public System.String DriftCheckBaselines_ModelQuality_Constraints_ContentType { get; set; }
            public System.String DriftCheckBaselines_ModelQuality_Constraints_S3Uri { get; set; }
            public System.String DriftCheckBaselines_ModelQuality_Statistics_ContentDigest { get; set; }
            public System.String DriftCheckBaselines_ModelQuality_Statistics_ContentType { get; set; }
            public System.String DriftCheckBaselines_ModelQuality_Statistics_S3Uri { get; set; }
            public List<Amazon.SageMaker.Model.ModelPackageContainerDefinition> InferenceSpecification_Container { get; set; }
            public List<System.String> InferenceSpecification_SupportedContentType { get; set; }
            public List<System.String> InferenceSpecification_SupportedRealtimeInferenceInstanceType { get; set; }
            public List<System.String> InferenceSpecification_SupportedResponseMIMEType { get; set; }
            public List<System.String> InferenceSpecification_SupportedTransformInstanceType { get; set; }
            public System.String MetadataProperties_CommitId { get; set; }
            public System.String MetadataProperties_GeneratedBy { get; set; }
            public System.String MetadataProperties_ProjectId { get; set; }
            public System.String MetadataProperties_Repository { get; set; }
            public Amazon.SageMaker.ModelApprovalStatus ModelApprovalStatus { get; set; }
            public System.String ModelCard_ModelCardContent { get; set; }
            public Amazon.SageMaker.ModelCardStatus ModelCard_ModelCardStatus { get; set; }
            public System.String ModelLifeCycle_Stage { get; set; }
            public System.String ModelLifeCycle_StageDescription { get; set; }
            public System.String ModelLifeCycle_StageStatus { get; set; }
            public System.String PostTrainingReport_ContentDigest { get; set; }
            public System.String PostTrainingReport_ContentType { get; set; }
            public System.String PostTrainingReport_S3Uri { get; set; }
            public System.String PreTrainingReport_ContentDigest { get; set; }
            public System.String PreTrainingReport_ContentType { get; set; }
            public System.String PreTrainingReport_S3Uri { get; set; }
            public System.String ModelMetrics_Bias_Report_ContentDigest { get; set; }
            public System.String ModelMetrics_Bias_Report_ContentType { get; set; }
            public System.String ModelMetrics_Bias_Report_S3Uri { get; set; }
            public System.String ModelMetrics_Explainability_Report_ContentDigest { get; set; }
            public System.String ModelMetrics_Explainability_Report_ContentType { get; set; }
            public System.String ModelMetrics_Explainability_Report_S3Uri { get; set; }
            public System.String ModelMetrics_ModelDataQuality_Constraints_ContentDigest { get; set; }
            public System.String ModelMetrics_ModelDataQuality_Constraints_ContentType { get; set; }
            public System.String ModelMetrics_ModelDataQuality_Constraints_S3Uri { get; set; }
            public System.String ModelMetrics_ModelDataQuality_Statistics_ContentDigest { get; set; }
            public System.String ModelMetrics_ModelDataQuality_Statistics_ContentType { get; set; }
            public System.String ModelMetrics_ModelDataQuality_Statistics_S3Uri { get; set; }
            public System.String ModelMetrics_ModelQuality_Constraints_ContentDigest { get; set; }
            public System.String ModelMetrics_ModelQuality_Constraints_ContentType { get; set; }
            public System.String ModelMetrics_ModelQuality_Constraints_S3Uri { get; set; }
            public System.String ModelMetrics_ModelQuality_Statistics_ContentDigest { get; set; }
            public System.String ModelMetrics_ModelQuality_Statistics_ContentType { get; set; }
            public System.String ModelMetrics_ModelQuality_Statistics_S3Uri { get; set; }
            public System.String ModelPackageDescription { get; set; }
            public System.String ModelPackageGroupName { get; set; }
            public System.String ModelPackageName { get; set; }
            public System.String SamplePayloadUrl { get; set; }
            public System.String SecurityConfig_KmsKeyId { get; set; }
            public Amazon.SageMaker.SkipModelValidation SkipModelValidation { get; set; }
            public List<Amazon.SageMaker.Model.SourceAlgorithm> SourceAlgorithmSpecification_SourceAlgorithm { get; set; }
            public System.String SourceUri { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String Task { get; set; }
            public List<Amazon.SageMaker.Model.ModelPackageValidationProfile> ValidationSpecification_ValidationProfile { get; set; }
            public System.String ValidationSpecification_ValidationRole { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateModelPackageResponse, NewSMModelPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelPackageArn;
        }
        
    }
}
