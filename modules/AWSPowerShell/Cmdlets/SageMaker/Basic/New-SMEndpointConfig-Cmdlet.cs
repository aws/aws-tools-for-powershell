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
    /// Creates an endpoint configuration that Amazon SageMaker hosting services uses to deploy
    /// models. In the configuration, you identify one or more models, created using the <code>CreateModel</code>
    /// API, to deploy and the resources that you want Amazon SageMaker to provision. Then
    /// you call the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/API_CreateEndpoint.html">CreateEndpoint</a>
    /// API.
    /// 
    ///  <note><para>
    ///  Use this API only if you want to use Amazon SageMaker hosting services to deploy
    /// models into production. 
    /// </para></note><para>
    /// In the request, you define one or more <code>ProductionVariant</code>s, each of which
    /// identifies a model. Each <code>ProductionVariant</code> parameter also describes the
    /// resources that you want Amazon SageMaker to provision. This includes the number and
    /// type of ML compute instances to deploy. 
    /// </para><para>
    /// If you are hosting multiple models, you also assign a <code>VariantWeight</code> to
    /// specify how much traffic you want to allocate to each model. For example, suppose
    /// that you want to host two models, A and B, and you assign traffic weight 2 for model
    /// A and 1 for model B. Amazon SageMaker distributes two-thirds of the traffic to Model
    /// A, and one-third to model B. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMEndpointConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateEndpointConfig API operation.", Operation = new[] {"CreateEndpointConfig"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateEndpointConfigResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateEndpointConfigResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateEndpointConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMEndpointConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter EndpointConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint configuration. You specify this name in a <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/API_CreateEndpoint.html">CreateEndpoint</a>
        /// request. </para>
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
        public System.String EndpointConfigName { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a AWS Key Management Service key that Amazon SageMaker
        /// uses to encrypt data on the storage volume attached to the ML compute instance that
        /// hosts the endpoint.</para><note><para>Nitro-based instances do not support encryption with AWS KMS. If any of the models
        /// that you specify in the <code>ProductionVariants</code> parameter use nitro-based
        /// instances, do not specify a value for the <code>KmsKeyId</code> parameter. If you
        /// specify a value for <code>KmsKeyId</code> when using any nitro-based instances, the
        /// call to <code>CreateEndpointConfig</code> fails.</para><para>For a list of nitro-based instances, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html#ec2-nitro-instances">Nitro-based
        /// Instances</a> in the <i>Amazon Elastic Compute Cloud User Guide for Linux Instances</i>.</para><para>For more information about storage volumes on nitro-based instances, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/nvme-ebs-volumes.html">Amazon
        /// EBS and NVMe on Linux Instances</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ProductionVariant
        /// <summary>
        /// <para>
        /// <para>An list of <code>ProductionVariant</code> objects, one for each model that you want
        /// to host at this endpoint.</para>
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
        [Alias("ProductionVariants")]
        public Amazon.SageMaker.Model.ProductionVariant[] ProductionVariant { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs. For more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html#allocation-what">Using
        /// Cost Allocation Tags</a> in the <i> AWS Billing and Cost Management User Guide</i>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointConfigArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateEndpointConfigResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateEndpointConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointConfigArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EndpointConfigName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EndpointConfigName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EndpointConfigName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointConfigName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMEndpointConfig (CreateEndpointConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateEndpointConfigResponse, NewSMEndpointConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EndpointConfigName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndpointConfigName = this.EndpointConfigName;
            #if MODULAR
            if (this.EndpointConfigName == null && ParameterWasBound(nameof(this.EndpointConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            if (this.ProductionVariant != null)
            {
                context.ProductionVariant = new List<Amazon.SageMaker.Model.ProductionVariant>(this.ProductionVariant);
            }
            #if MODULAR
            if (this.ProductionVariant == null && ParameterWasBound(nameof(this.ProductionVariant)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductionVariant which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateEndpointConfigRequest();
            
            if (cmdletContext.EndpointConfigName != null)
            {
                request.EndpointConfigName = cmdletContext.EndpointConfigName;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.ProductionVariant != null)
            {
                request.ProductionVariants = cmdletContext.ProductionVariant;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateEndpointConfigResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateEndpointConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateEndpointConfig");
            try
            {
                #if DESKTOP
                return client.CreateEndpointConfig(request);
                #elif CORECLR
                return client.CreateEndpointConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String EndpointConfigName { get; set; }
            public System.String KmsKeyId { get; set; }
            public List<Amazon.SageMaker.Model.ProductionVariant> ProductionVariant { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateEndpointConfigResponse, NewSMEndpointConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointConfigArn;
        }
        
    }
}
