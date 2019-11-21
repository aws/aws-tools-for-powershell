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
    /// Creates a model package that you can use to create Amazon SageMaker models or list
    /// on AWS Marketplace. Buyers can subscribe to model packages listed on AWS Marketplace
    /// to create models in Amazon SageMaker.
    /// 
    ///  
    /// <para>
    /// To create a model package by specifying a Docker container that contains your inference
    /// code and the Amazon S3 location of your model artifacts, provide values for <code>InferenceSpecification</code>.
    /// To create a model from an algorithm resource that you created or subscribed to in
    /// AWS Marketplace, provide a value for <code>SourceAlgorithmSpecification</code>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMModelPackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateModelPackage API operation.", Operation = new[] {"CreateModelPackage"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateModelPackageResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateModelPackageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateModelPackageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMModelPackageCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter CertifyForMarketplace
        /// <summary>
        /// <para>
        /// <para>Whether to certify the model package for listing on AWS Marketplace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CertifyForMarketplace { get; set; }
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
        
        #region Parameter ModelPackageDescription
        /// <summary>
        /// <para>
        /// <para>A description of the model package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelPackageDescription { get; set; }
        #endregion
        
        #region Parameter ModelPackageName
        /// <summary>
        /// <para>
        /// <para>The name of the model package. The name must have 1 to 63 characters. Valid characters
        /// are a-z, A-Z, 0-9, and - (hyphen).</para>
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
        public System.String ModelPackageName { get; set; }
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
        /// <para>A list of the instance types that are used to generate inferences in real-time.</para>
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
        /// an endpoint can be deployed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_SupportedTransformInstanceTypes")]
        public System.String[] InferenceSpecification_SupportedTransformInstanceType { get; set; }
        #endregion
        
        #region Parameter ValidationSpecification_ValidationProfile
        /// <summary>
        /// <para>
        /// <para>An array of <code>ModelPackageValidationProfile</code> objects, each of which specifies
        /// a batch transform job that Amazon SageMaker runs to validate your model package.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ModelPackageName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ModelPackageName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ModelPackageName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelPackageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMModelPackage (CreateModelPackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateModelPackageResponse, NewSMModelPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ModelPackageName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertifyForMarketplace = this.CertifyForMarketplace;
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
            context.ModelPackageDescription = this.ModelPackageDescription;
            context.ModelPackageName = this.ModelPackageName;
            #if MODULAR
            if (this.ModelPackageName == null && ParameterWasBound(nameof(this.ModelPackageName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelPackageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SourceAlgorithmSpecification_SourceAlgorithm != null)
            {
                context.SourceAlgorithmSpecification_SourceAlgorithm = new List<Amazon.SageMaker.Model.SourceAlgorithm>(this.SourceAlgorithmSpecification_SourceAlgorithm);
            }
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
            
            if (cmdletContext.CertifyForMarketplace != null)
            {
                request.CertifyForMarketplace = cmdletContext.CertifyForMarketplace.Value;
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
            if (cmdletContext.ModelPackageDescription != null)
            {
                request.ModelPackageDescription = cmdletContext.ModelPackageDescription;
            }
            if (cmdletContext.ModelPackageName != null)
            {
                request.ModelPackageName = cmdletContext.ModelPackageName;
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
            public System.Boolean? CertifyForMarketplace { get; set; }
            public List<Amazon.SageMaker.Model.ModelPackageContainerDefinition> InferenceSpecification_Container { get; set; }
            public List<System.String> InferenceSpecification_SupportedContentType { get; set; }
            public List<System.String> InferenceSpecification_SupportedRealtimeInferenceInstanceType { get; set; }
            public List<System.String> InferenceSpecification_SupportedResponseMIMEType { get; set; }
            public List<System.String> InferenceSpecification_SupportedTransformInstanceType { get; set; }
            public System.String ModelPackageDescription { get; set; }
            public System.String ModelPackageName { get; set; }
            public List<Amazon.SageMaker.Model.SourceAlgorithm> SourceAlgorithmSpecification_SourceAlgorithm { get; set; }
            public List<Amazon.SageMaker.Model.ModelPackageValidationProfile> ValidationSpecification_ValidationProfile { get; set; }
            public System.String ValidationSpecification_ValidationRole { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateModelPackageResponse, NewSMModelPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelPackageArn;
        }
        
    }
}
