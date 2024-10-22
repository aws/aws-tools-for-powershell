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
    /// Creates a model in SageMaker. In the request, you name the model and describe a primary
    /// container. For the primary container, you specify the Docker image that contains inference
    /// code, artifacts (from prior training), and a custom environment map that the inference
    /// code uses when you deploy the model for predictions.
    /// 
    ///  
    /// <para>
    /// Use this API to create a model if you want to use SageMaker hosting services or run
    /// a batch transform job.
    /// </para><para>
    /// To host your model, you create an endpoint configuration with the <c>CreateEndpointConfig</c>
    /// API, and then create an endpoint with the <c>CreateEndpoint</c> API. SageMaker then
    /// deploys all of the containers that you defined for the model in the hosting environment.
    /// 
    /// </para><para>
    /// To run a batch transform using your model, you start a job with the <c>CreateTransformJob</c>
    /// API. SageMaker uses your model and your dataset to get inferences which are then saved
    /// to a specified S3 location.
    /// </para><para>
    /// In the request, you also provide an IAM role that SageMaker can assume to access model
    /// artifacts and docker image for deployment on ML compute hosting instances or for batch
    /// transform jobs. In addition, you also use the IAM role to manage permissions the inference
    /// code needs. For example, if the inference code access any other Amazon Web Services
    /// resources, you grant necessary permissions via this role.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateModel API operation.", Operation = new[] {"CreateModel"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateModelResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateModelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateModelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMModelCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Container
        /// <summary>
        /// <para>
        /// <para>Specifies the containers in the inference pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Containers")]
        public Amazon.SageMaker.Model.ContainerDefinition[] Container { get; set; }
        #endregion
        
        #region Parameter EnableNetworkIsolation
        /// <summary>
        /// <para>
        /// <para>Isolates the model container. No inbound or outbound network calls can be made to
        /// or from the model container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableNetworkIsolation { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that SageMaker can assume to access
        /// model artifacts and docker image for deployment on ML compute instances or for batch
        /// transform jobs. Deploying on ML compute instances is part of model hosting. For more
        /// information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">SageMaker
        /// Roles</a>. </para><note><para>To be able to pass this role to SageMaker, the caller of this API must have the <c>iam:PassRole</c>
        /// permission.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter InferenceExecutionConfig_Mode
        /// <summary>
        /// <para>
        /// <para>How containers in a multi-container are run. The following values are valid.</para><ul><li><para><c>SERIAL</c> - Containers run as a serial pipeline.</para></li><li><para><c>DIRECT</c> - Only the individual container that you specify is run.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.InferenceExecutionMode")]
        public Amazon.SageMaker.InferenceExecutionMode InferenceExecutionConfig_Mode { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the new model.</para>
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
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter PrimaryContainer
        /// <summary>
        /// <para>
        /// <para>The location of the primary docker image containing inference code, associated artifacts,
        /// and custom environment map that the inference code uses when the model is deployed
        /// for predictions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public Amazon.SageMaker.Model.ContainerDefinition PrimaryContainer { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form <c>sg-xxxxxxxx</c>. Specify the security groups
        /// for the VPC that is specified in the <c>Subnets</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC to which you want to connect your training job or
        /// model. For information about the availability of specific instance types, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/instance-types-az.html">Supported
        /// Instance Types and Availability Zones</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateModelResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMModel (CreateModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateModelResponse, NewSMModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Container != null)
            {
                context.Container = new List<Amazon.SageMaker.Model.ContainerDefinition>(this.Container);
            }
            context.EnableNetworkIsolation = this.EnableNetworkIsolation;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.InferenceExecutionConfig_Mode = this.InferenceExecutionConfig_Mode;
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrimaryContainer = this.PrimaryContainer;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            
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
            var request = new Amazon.SageMaker.Model.CreateModelRequest();
            
            if (cmdletContext.Container != null)
            {
                request.Containers = cmdletContext.Container;
            }
            if (cmdletContext.EnableNetworkIsolation != null)
            {
                request.EnableNetworkIsolation = cmdletContext.EnableNetworkIsolation.Value;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate InferenceExecutionConfig
            var requestInferenceExecutionConfigIsNull = true;
            request.InferenceExecutionConfig = new Amazon.SageMaker.Model.InferenceExecutionConfig();
            Amazon.SageMaker.InferenceExecutionMode requestInferenceExecutionConfig_inferenceExecutionConfig_Mode = null;
            if (cmdletContext.InferenceExecutionConfig_Mode != null)
            {
                requestInferenceExecutionConfig_inferenceExecutionConfig_Mode = cmdletContext.InferenceExecutionConfig_Mode;
            }
            if (requestInferenceExecutionConfig_inferenceExecutionConfig_Mode != null)
            {
                request.InferenceExecutionConfig.Mode = requestInferenceExecutionConfig_inferenceExecutionConfig_Mode;
                requestInferenceExecutionConfigIsNull = false;
            }
             // determine if request.InferenceExecutionConfig should be set to null
            if (requestInferenceExecutionConfigIsNull)
            {
                request.InferenceExecutionConfig = null;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
            }
            if (cmdletContext.PrimaryContainer != null)
            {
                request.PrimaryContainer = cmdletContext.PrimaryContainer;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestVpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestVpcConfig_vpcConfig_Subnet != null)
            {
                request.VpcConfig.Subnets = requestVpcConfig_vpcConfig_Subnet;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
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
        
        private Amazon.SageMaker.Model.CreateModelResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateModel");
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
            public List<Amazon.SageMaker.Model.ContainerDefinition> Container { get; set; }
            public System.Boolean? EnableNetworkIsolation { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public Amazon.SageMaker.InferenceExecutionMode InferenceExecutionConfig_Mode { get; set; }
            public System.String ModelName { get; set; }
            public Amazon.SageMaker.Model.ContainerDefinition PrimaryContainer { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateModelResponse, NewSMModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelArn;
        }
        
    }
}
