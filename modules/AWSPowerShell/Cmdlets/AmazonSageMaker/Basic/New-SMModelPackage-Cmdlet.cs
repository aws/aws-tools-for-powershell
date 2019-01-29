/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateModelPackage API operation.", Operation = new[] {"CreateModelPackage"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
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
        [System.Management.Automation.Parameter]
        public System.Boolean CertifyForMarketplace { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_Container
        /// <summary>
        /// <para>
        /// <para>The Amazon ECR registry path of the Docker image that contains the inference code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InferenceSpecification_Containers")]
        public Amazon.SageMaker.Model.ModelPackageContainerDefinition[] InferenceSpecification_Container { get; set; }
        #endregion
        
        #region Parameter ModelPackageDescription
        /// <summary>
        /// <para>
        /// <para>A description of the model package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ModelPackageDescription { get; set; }
        #endregion
        
        #region Parameter ModelPackageName
        /// <summary>
        /// <para>
        /// <para>The name of the model package. The name must have 1 to 63 characters. Valid characters
        /// are a-z, A-Z, 0-9, and - (hyphen).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ModelPackageName { get; set; }
        #endregion
        
        #region Parameter SourceAlgorithmSpecification_SourceAlgorithm
        /// <summary>
        /// <para>
        /// <para>A list of the algorithms that were used to create a model package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SourceAlgorithmSpecification_SourceAlgorithms")]
        public Amazon.SageMaker.Model.SourceAlgorithm[] SourceAlgorithmSpecification_SourceAlgorithm { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedContentType
        /// <summary>
        /// <para>
        /// <para>The supported MIME types for the input data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InferenceSpecification_SupportedContentTypes")]
        public System.String[] InferenceSpecification_SupportedContentType { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedRealtimeInferenceInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of the instance types that are used to generate inferences in real-time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InferenceSpecification_SupportedRealtimeInferenceInstanceTypes")]
        public System.String[] InferenceSpecification_SupportedRealtimeInferenceInstanceType { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedResponseMIMEType
        /// <summary>
        /// <para>
        /// <para>The supported MIME types for the output data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("ValidationSpecification_ValidationProfiles")]
        public Amazon.SageMaker.Model.ModelPackageValidationProfile[] ValidationSpecification_ValidationProfile { get; set; }
        #endregion
        
        #region Parameter ValidationSpecification_ValidationRole
        /// <summary>
        /// <para>
        /// <para>The IAM roles to be used for the validation of the model package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ValidationSpecification_ValidationRole { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ModelPackageName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMModelPackage (CreateModelPackage)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("CertifyForMarketplace"))
                context.CertifyForMarketplace = this.CertifyForMarketplace;
            if (this.InferenceSpecification_Container != null)
            {
                context.InferenceSpecification_Containers = new List<Amazon.SageMaker.Model.ModelPackageContainerDefinition>(this.InferenceSpecification_Container);
            }
            if (this.InferenceSpecification_SupportedContentType != null)
            {
                context.InferenceSpecification_SupportedContentTypes = new List<System.String>(this.InferenceSpecification_SupportedContentType);
            }
            if (this.InferenceSpecification_SupportedRealtimeInferenceInstanceType != null)
            {
                context.InferenceSpecification_SupportedRealtimeInferenceInstanceTypes = new List<System.String>(this.InferenceSpecification_SupportedRealtimeInferenceInstanceType);
            }
            if (this.InferenceSpecification_SupportedResponseMIMEType != null)
            {
                context.InferenceSpecification_SupportedResponseMIMETypes = new List<System.String>(this.InferenceSpecification_SupportedResponseMIMEType);
            }
            if (this.InferenceSpecification_SupportedTransformInstanceType != null)
            {
                context.InferenceSpecification_SupportedTransformInstanceTypes = new List<System.String>(this.InferenceSpecification_SupportedTransformInstanceType);
            }
            context.ModelPackageDescription = this.ModelPackageDescription;
            context.ModelPackageName = this.ModelPackageName;
            if (this.SourceAlgorithmSpecification_SourceAlgorithm != null)
            {
                context.SourceAlgorithmSpecification_SourceAlgorithms = new List<Amazon.SageMaker.Model.SourceAlgorithm>(this.SourceAlgorithmSpecification_SourceAlgorithm);
            }
            if (this.ValidationSpecification_ValidationProfile != null)
            {
                context.ValidationSpecification_ValidationProfiles = new List<Amazon.SageMaker.Model.ModelPackageValidationProfile>(this.ValidationSpecification_ValidationProfile);
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
            bool requestInferenceSpecificationIsNull = true;
            request.InferenceSpecification = new Amazon.SageMaker.Model.InferenceSpecification();
            List<Amazon.SageMaker.Model.ModelPackageContainerDefinition> requestInferenceSpecification_inferenceSpecification_Container = null;
            if (cmdletContext.InferenceSpecification_Containers != null)
            {
                requestInferenceSpecification_inferenceSpecification_Container = cmdletContext.InferenceSpecification_Containers;
            }
            if (requestInferenceSpecification_inferenceSpecification_Container != null)
            {
                request.InferenceSpecification.Containers = requestInferenceSpecification_inferenceSpecification_Container;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedContentType = null;
            if (cmdletContext.InferenceSpecification_SupportedContentTypes != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedContentType = cmdletContext.InferenceSpecification_SupportedContentTypes;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedContentType != null)
            {
                request.InferenceSpecification.SupportedContentTypes = requestInferenceSpecification_inferenceSpecification_SupportedContentType;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType = null;
            if (cmdletContext.InferenceSpecification_SupportedRealtimeInferenceInstanceTypes != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType = cmdletContext.InferenceSpecification_SupportedRealtimeInferenceInstanceTypes;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType != null)
            {
                request.InferenceSpecification.SupportedRealtimeInferenceInstanceTypes = requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType = null;
            if (cmdletContext.InferenceSpecification_SupportedResponseMIMETypes != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType = cmdletContext.InferenceSpecification_SupportedResponseMIMETypes;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType != null)
            {
                request.InferenceSpecification.SupportedResponseMIMETypes = requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType = null;
            if (cmdletContext.InferenceSpecification_SupportedTransformInstanceTypes != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType = cmdletContext.InferenceSpecification_SupportedTransformInstanceTypes;
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
            bool requestSourceAlgorithmSpecificationIsNull = true;
            request.SourceAlgorithmSpecification = new Amazon.SageMaker.Model.SourceAlgorithmSpecification();
            List<Amazon.SageMaker.Model.SourceAlgorithm> requestSourceAlgorithmSpecification_sourceAlgorithmSpecification_SourceAlgorithm = null;
            if (cmdletContext.SourceAlgorithmSpecification_SourceAlgorithms != null)
            {
                requestSourceAlgorithmSpecification_sourceAlgorithmSpecification_SourceAlgorithm = cmdletContext.SourceAlgorithmSpecification_SourceAlgorithms;
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
            bool requestValidationSpecificationIsNull = true;
            request.ValidationSpecification = new Amazon.SageMaker.Model.ModelPackageValidationSpecification();
            List<Amazon.SageMaker.Model.ModelPackageValidationProfile> requestValidationSpecification_validationSpecification_ValidationProfile = null;
            if (cmdletContext.ValidationSpecification_ValidationProfiles != null)
            {
                requestValidationSpecification_validationSpecification_ValidationProfile = cmdletContext.ValidationSpecification_ValidationProfiles;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ModelPackageArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateModelPackageAsync(request);
                return task.Result;
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
            public List<Amazon.SageMaker.Model.ModelPackageContainerDefinition> InferenceSpecification_Containers { get; set; }
            public List<System.String> InferenceSpecification_SupportedContentTypes { get; set; }
            public List<System.String> InferenceSpecification_SupportedRealtimeInferenceInstanceTypes { get; set; }
            public List<System.String> InferenceSpecification_SupportedResponseMIMETypes { get; set; }
            public List<System.String> InferenceSpecification_SupportedTransformInstanceTypes { get; set; }
            public System.String ModelPackageDescription { get; set; }
            public System.String ModelPackageName { get; set; }
            public List<Amazon.SageMaker.Model.SourceAlgorithm> SourceAlgorithmSpecification_SourceAlgorithms { get; set; }
            public List<Amazon.SageMaker.Model.ModelPackageValidationProfile> ValidationSpecification_ValidationProfiles { get; set; }
            public System.String ValidationSpecification_ValidationRole { get; set; }
        }
        
    }
}
