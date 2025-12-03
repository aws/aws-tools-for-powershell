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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates a versioned model.
    /// </summary>
    [Cmdlet("Update", "SMModelPackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateModelPackage API operation.", Operation = new[] {"UpdateModelPackage"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateModelPackageResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateModelPackageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateModelPackageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMModelPackageCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalInferenceSpecificationsToAdd
        /// <summary>
        /// <para>
        /// <para>An array of additional Inference Specification objects to be added to the existing
        /// array additional Inference Specification. Total number of additional Inference Specifications
        /// can not exceed 15. Each additional Inference Specification specifies artifacts based
        /// on this model package that can be used on inference endpoints. Generally used with
        /// SageMaker Neo to store the compiled artifacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.AdditionalInferenceSpecificationDefinition[] AdditionalInferenceSpecificationsToAdd { get; set; }
        #endregion
        
        #region Parameter ApprovalDescription
        /// <summary>
        /// <para>
        /// <para>A description for the approval status of the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApprovalDescription { get; set; }
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
        
        #region Parameter CustomerMetadataPropertiesToRemove
        /// <summary>
        /// <para>
        /// <para>The metadata properties associated with the model package versions to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CustomerMetadataPropertiesToRemove { get; set; }
        #endregion
        
        #region Parameter ModelApprovalStatus
        /// <summary>
        /// <para>
        /// <para>The approval status of the model.</para>
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
        
        #region Parameter ModelPackageArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the model package.</para>
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
        public System.String ModelPackageArn { get; set; }
        #endregion
        
        #region Parameter ModelPackageRegistrationType
        /// <summary>
        /// <para>
        /// <para> The package registration type of the model package input. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ModelPackageRegistrationType")]
        public Amazon.SageMaker.ModelPackageRegistrationType ModelPackageRegistrationType { get; set; }
        #endregion
        
        #region Parameter SourceUri
        /// <summary>
        /// <para>
        /// <para>The URI of the source for the model package.</para>
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique token that guarantees that the call to this API is idempotent. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelPackageArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateModelPackageResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateModelPackageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelPackageArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ModelPackageArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ModelPackageArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ModelPackageArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelPackageArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMModelPackage (UpdateModelPackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateModelPackageResponse, UpdateSMModelPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ModelPackageArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalInferenceSpecificationsToAdd != null)
            {
                context.AdditionalInferenceSpecificationsToAdd = new List<Amazon.SageMaker.Model.AdditionalInferenceSpecificationDefinition>(this.AdditionalInferenceSpecificationsToAdd);
            }
            context.ApprovalDescription = this.ApprovalDescription;
            context.ClientToken = this.ClientToken;
            if (this.CustomerMetadataProperty != null)
            {
                context.CustomerMetadataProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomerMetadataProperty.Keys)
                {
                    context.CustomerMetadataProperty.Add((String)hashKey, (System.String)(this.CustomerMetadataProperty[hashKey]));
                }
            }
            if (this.CustomerMetadataPropertiesToRemove != null)
            {
                context.CustomerMetadataPropertiesToRemove = new List<System.String>(this.CustomerMetadataPropertiesToRemove);
            }
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
            context.ModelApprovalStatus = this.ModelApprovalStatus;
            context.ModelCard_ModelCardContent = this.ModelCard_ModelCardContent;
            context.ModelCard_ModelCardStatus = this.ModelCard_ModelCardStatus;
            context.ModelLifeCycle_Stage = this.ModelLifeCycle_Stage;
            context.ModelLifeCycle_StageDescription = this.ModelLifeCycle_StageDescription;
            context.ModelLifeCycle_StageStatus = this.ModelLifeCycle_StageStatus;
            context.ModelPackageArn = this.ModelPackageArn;
            #if MODULAR
            if (this.ModelPackageArn == null && ParameterWasBound(nameof(this.ModelPackageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelPackageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelPackageRegistrationType = this.ModelPackageRegistrationType;
            context.SourceUri = this.SourceUri;
            
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
            var request = new Amazon.SageMaker.Model.UpdateModelPackageRequest();
            
            if (cmdletContext.AdditionalInferenceSpecificationsToAdd != null)
            {
                request.AdditionalInferenceSpecificationsToAdd = cmdletContext.AdditionalInferenceSpecificationsToAdd;
            }
            if (cmdletContext.ApprovalDescription != null)
            {
                request.ApprovalDescription = cmdletContext.ApprovalDescription;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomerMetadataProperty != null)
            {
                request.CustomerMetadataProperties = cmdletContext.CustomerMetadataProperty;
            }
            if (cmdletContext.CustomerMetadataPropertiesToRemove != null)
            {
                request.CustomerMetadataPropertiesToRemove = cmdletContext.CustomerMetadataPropertiesToRemove;
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
            if (cmdletContext.ModelPackageArn != null)
            {
                request.ModelPackageArn = cmdletContext.ModelPackageArn;
            }
            if (cmdletContext.ModelPackageRegistrationType != null)
            {
                request.ModelPackageRegistrationType = cmdletContext.ModelPackageRegistrationType;
            }
            if (cmdletContext.SourceUri != null)
            {
                request.SourceUri = cmdletContext.SourceUri;
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
        
        private Amazon.SageMaker.Model.UpdateModelPackageResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateModelPackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateModelPackage");
            try
            {
                #if DESKTOP
                return client.UpdateModelPackage(request);
                #elif CORECLR
                return client.UpdateModelPackageAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.AdditionalInferenceSpecificationDefinition> AdditionalInferenceSpecificationsToAdd { get; set; }
            public System.String ApprovalDescription { get; set; }
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, System.String> CustomerMetadataProperty { get; set; }
            public List<System.String> CustomerMetadataPropertiesToRemove { get; set; }
            public List<Amazon.SageMaker.Model.ModelPackageContainerDefinition> InferenceSpecification_Container { get; set; }
            public List<System.String> InferenceSpecification_SupportedContentType { get; set; }
            public List<System.String> InferenceSpecification_SupportedRealtimeInferenceInstanceType { get; set; }
            public List<System.String> InferenceSpecification_SupportedResponseMIMEType { get; set; }
            public List<System.String> InferenceSpecification_SupportedTransformInstanceType { get; set; }
            public Amazon.SageMaker.ModelApprovalStatus ModelApprovalStatus { get; set; }
            public System.String ModelCard_ModelCardContent { get; set; }
            public Amazon.SageMaker.ModelCardStatus ModelCard_ModelCardStatus { get; set; }
            public System.String ModelLifeCycle_Stage { get; set; }
            public System.String ModelLifeCycle_StageDescription { get; set; }
            public System.String ModelLifeCycle_StageStatus { get; set; }
            public System.String ModelPackageArn { get; set; }
            public Amazon.SageMaker.ModelPackageRegistrationType ModelPackageRegistrationType { get; set; }
            public System.String SourceUri { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateModelPackageResponse, UpdateSMModelPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelPackageArn;
        }
        
    }
}
