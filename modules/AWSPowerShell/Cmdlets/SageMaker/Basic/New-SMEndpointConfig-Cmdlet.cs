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
    /// Creates an endpoint configuration that SageMaker hosting services uses to deploy models.
    /// In the configuration, you identify one or more models, created using the <code>CreateModel</code>
    /// API, to deploy and the resources that you want SageMaker to provision. Then you call
    /// the <a>CreateEndpoint</a> API.
    /// 
    ///  <note><para>
    ///  Use this API if you want to use SageMaker hosting services to deploy models into
    /// production. 
    /// </para></note><para>
    /// In the request, you define a <code>ProductionVariant</code>, for each model that you
    /// want to deploy. Each <code>ProductionVariant</code> parameter also describes the resources
    /// that you want SageMaker to provision. This includes the number and type of ML compute
    /// instances to deploy. 
    /// </para><para>
    /// If you are hosting multiple models, you also assign a <code>VariantWeight</code> to
    /// specify how much traffic you want to allocate to each model. For example, suppose
    /// that you want to host two models, A and B, and you assign traffic weight 2 for model
    /// A and 1 for model B. SageMaker distributes two-thirds of the traffic to Model A, and
    /// one-third to model B. 
    /// </para><note><para>
    /// When you call <a>CreateEndpoint</a>, a load call is made to DynamoDB to verify that
    /// your endpoint configuration exists. When you read data from a DynamoDB table supporting
    /// <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadConsistency.html"><code>Eventually Consistent Reads</code></a>, the response might not reflect the
    /// results of a recently completed write operation. The response might include some stale
    /// data. If the dependent entities are not yet in DynamoDB, this causes a validation
    /// error. If you repeat your read request after a short time, the response should return
    /// the latest data. So retry logic is recommended to handle these possible issues. We
    /// also recommend that customers call <a>DescribeEndpointConfig</a> before calling <a>CreateEndpoint</a>
    /// to minimize the potential impact of a DynamoDB eventually consistent read.
    /// </para></note>
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
        
        #region Parameter DataCaptureConfig_CaptureOption
        /// <summary>
        /// <para>
        /// <para>Specifies data Model Monitor will capture. You can configure whether to collect only
        /// input, only output, or both</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataCaptureConfig_CaptureOptions")]
        public Amazon.SageMaker.Model.CaptureOption[] DataCaptureConfig_CaptureOption { get; set; }
        #endregion
        
        #region Parameter CaptureContentTypeHeader_CsvContentType
        /// <summary>
        /// <para>
        /// <para>The list of all content type headers that SageMaker will treat as CSV and capture
        /// accordingly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataCaptureConfig_CaptureContentTypeHeader_CsvContentTypes")]
        public System.String[] CaptureContentTypeHeader_CsvContentType { get; set; }
        #endregion
        
        #region Parameter DataCaptureConfig_DestinationS3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location used to capture the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataCaptureConfig_DestinationS3Uri { get; set; }
        #endregion
        
        #region Parameter DataCaptureConfig_EnableCapture
        /// <summary>
        /// <para>
        /// <para>Whether data capture should be enabled or disabled (defaults to enabled).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataCaptureConfig_EnableCapture { get; set; }
        #endregion
        
        #region Parameter EndpointConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint configuration. You specify this name in a <a>CreateEndpoint</a>
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
        
        #region Parameter NotificationConfig_ErrorTopic
        /// <summary>
        /// <para>
        /// <para>Amazon SNS topic to post a notification to when inference fails. If no topic is provided,
        /// no notification is sent on failure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AsyncInferenceConfig_OutputConfig_NotificationConfig_ErrorTopic")]
        public System.String NotificationConfig_ErrorTopic { get; set; }
        #endregion
        
        #region Parameter DataCaptureConfig_InitialSamplingPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of requests SageMaker will capture. A lower value is recommended for
        /// Endpoints with high traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DataCaptureConfig_InitialSamplingPercentage { get; set; }
        #endregion
        
        #region Parameter CaptureContentTypeHeader_JsonContentType
        /// <summary>
        /// <para>
        /// <para>The list of all content type headers that SageMaker will treat as JSON and capture
        /// accordingly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataCaptureConfig_CaptureContentTypeHeader_JsonContentTypes")]
        public System.String[] CaptureContentTypeHeader_JsonContentType { get; set; }
        #endregion
        
        #region Parameter OutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// SageMaker uses to encrypt the asynchronous inference output in Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AsyncInferenceConfig_OutputConfig_KmsKeyId")]
        public System.String OutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter DataCaptureConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Amazon Web Services Key Management Service key
        /// that SageMaker uses to encrypt data on the storage volume attached to the ML compute
        /// instance that hosts the endpoint.</para><para>The KmsKeyId can be any of the following formats: </para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias name ARN: <code>arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataCaptureConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Amazon Web Services Key Management Service key
        /// that SageMaker uses to encrypt data on the storage volume attached to the ML compute
        /// instance that hosts the endpoint.</para><para>The KmsKeyId can be any of the following formats: </para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias name ARN: <code>arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias</code></para></li></ul><para>The KMS key policy must grant permission to the IAM role that you specify in your
        /// <code>CreateEndpoint</code>, <code>UpdateEndpoint</code> requests. For more information,
        /// refer to the Amazon Web Services Key Management Service section<a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">
        /// Using Key Policies in Amazon Web Services KMS </a></para><note><para>Certain Nitro-based instances include local storage, dependent on the instance type.
        /// Local storage volumes are encrypted using a hardware module on the instance. You can't
        /// request a <code>KmsKeyId</code> when using an instance type with local storage. If
        /// any of the models that you specify in the <code>ProductionVariants</code> parameter
        /// use nitro-based instances with local storage, do not specify a value for the <code>KmsKeyId</code>
        /// parameter. If you specify a value for <code>KmsKeyId</code> when using any nitro-based
        /// instances with local storage, the call to <code>CreateEndpointConfig</code> fails.</para><para>For a list of instance types that support local instance storage, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/InstanceStorage.html#instance-store-volumes">Instance
        /// Store Volumes</a>.</para><para>For more information about local instance storage encryption, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ssd-instance-store.html">SSD
        /// Instance Store Volumes</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ClientConfig_MaxConcurrentInvocationsPerInstance
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent requests sent by the SageMaker client to the model
        /// container. If no value is provided, SageMaker chooses an optimal value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AsyncInferenceConfig_ClientConfig_MaxConcurrentInvocationsPerInstance")]
        public System.Int32? ClientConfig_MaxConcurrentInvocationsPerInstance { get; set; }
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
        
        #region Parameter OutputConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location to upload inference responses to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AsyncInferenceConfig_OutputConfig_S3OutputPath")]
        public System.String OutputConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_SuccessTopic
        /// <summary>
        /// <para>
        /// <para>Amazon SNS topic to post a notification to when inference completes successfully.
        /// If no topic is provided, no notification is sent on success.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AsyncInferenceConfig_OutputConfig_NotificationConfig_SuccessTopic")]
        public System.String NotificationConfig_SuccessTopic { get; set; }
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
            context.ClientConfig_MaxConcurrentInvocationsPerInstance = this.ClientConfig_MaxConcurrentInvocationsPerInstance;
            context.OutputConfig_KmsKeyId = this.OutputConfig_KmsKeyId;
            context.NotificationConfig_ErrorTopic = this.NotificationConfig_ErrorTopic;
            context.NotificationConfig_SuccessTopic = this.NotificationConfig_SuccessTopic;
            context.OutputConfig_S3OutputPath = this.OutputConfig_S3OutputPath;
            if (this.CaptureContentTypeHeader_CsvContentType != null)
            {
                context.CaptureContentTypeHeader_CsvContentType = new List<System.String>(this.CaptureContentTypeHeader_CsvContentType);
            }
            if (this.CaptureContentTypeHeader_JsonContentType != null)
            {
                context.CaptureContentTypeHeader_JsonContentType = new List<System.String>(this.CaptureContentTypeHeader_JsonContentType);
            }
            if (this.DataCaptureConfig_CaptureOption != null)
            {
                context.DataCaptureConfig_CaptureOption = new List<Amazon.SageMaker.Model.CaptureOption>(this.DataCaptureConfig_CaptureOption);
            }
            context.DataCaptureConfig_DestinationS3Uri = this.DataCaptureConfig_DestinationS3Uri;
            context.DataCaptureConfig_EnableCapture = this.DataCaptureConfig_EnableCapture;
            context.DataCaptureConfig_InitialSamplingPercentage = this.DataCaptureConfig_InitialSamplingPercentage;
            context.DataCaptureConfig_KmsKeyId = this.DataCaptureConfig_KmsKeyId;
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
            
            
             // populate AsyncInferenceConfig
            var requestAsyncInferenceConfigIsNull = true;
            request.AsyncInferenceConfig = new Amazon.SageMaker.Model.AsyncInferenceConfig();
            Amazon.SageMaker.Model.AsyncInferenceClientConfig requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig = null;
            
             // populate ClientConfig
            var requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfigIsNull = true;
            requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig = new Amazon.SageMaker.Model.AsyncInferenceClientConfig();
            System.Int32? requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig_clientConfig_MaxConcurrentInvocationsPerInstance = null;
            if (cmdletContext.ClientConfig_MaxConcurrentInvocationsPerInstance != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig_clientConfig_MaxConcurrentInvocationsPerInstance = cmdletContext.ClientConfig_MaxConcurrentInvocationsPerInstance.Value;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig_clientConfig_MaxConcurrentInvocationsPerInstance != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig.MaxConcurrentInvocationsPerInstance = requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig_clientConfig_MaxConcurrentInvocationsPerInstance.Value;
                requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfigIsNull = false;
            }
             // determine if requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig should be set to null
            if (requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfigIsNull)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig = null;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig != null)
            {
                request.AsyncInferenceConfig.ClientConfig = requestAsyncInferenceConfig_asyncInferenceConfig_ClientConfig;
                requestAsyncInferenceConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AsyncInferenceOutputConfig requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig = null;
            
             // populate OutputConfig
            var requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfigIsNull = true;
            requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig = new Amazon.SageMaker.Model.AsyncInferenceOutputConfig();
            System.String requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_KmsKeyId = null;
            if (cmdletContext.OutputConfig_KmsKeyId != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_KmsKeyId = cmdletContext.OutputConfig_KmsKeyId;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_KmsKeyId != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig.KmsKeyId = requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_KmsKeyId;
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfigIsNull = false;
            }
            System.String requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_S3OutputPath = null;
            if (cmdletContext.OutputConfig_S3OutputPath != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_S3OutputPath = cmdletContext.OutputConfig_S3OutputPath;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_S3OutputPath != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig.S3OutputPath = requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_S3OutputPath;
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AsyncInferenceNotificationConfig requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig = null;
            
             // populate NotificationConfig
            var requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfigIsNull = true;
            requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig = new Amazon.SageMaker.Model.AsyncInferenceNotificationConfig();
            System.String requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_ErrorTopic = null;
            if (cmdletContext.NotificationConfig_ErrorTopic != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_ErrorTopic = cmdletContext.NotificationConfig_ErrorTopic;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_ErrorTopic != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig.ErrorTopic = requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_ErrorTopic;
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfigIsNull = false;
            }
            System.String requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_SuccessTopic = null;
            if (cmdletContext.NotificationConfig_SuccessTopic != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_SuccessTopic = cmdletContext.NotificationConfig_SuccessTopic;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_SuccessTopic != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig.SuccessTopic = requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_SuccessTopic;
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfigIsNull = false;
            }
             // determine if requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig should be set to null
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfigIsNull)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig = null;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig.NotificationConfig = requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig;
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfigIsNull = false;
            }
             // determine if requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig should be set to null
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfigIsNull)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig = null;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig != null)
            {
                request.AsyncInferenceConfig.OutputConfig = requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig;
                requestAsyncInferenceConfigIsNull = false;
            }
             // determine if request.AsyncInferenceConfig should be set to null
            if (requestAsyncInferenceConfigIsNull)
            {
                request.AsyncInferenceConfig = null;
            }
            
             // populate DataCaptureConfig
            var requestDataCaptureConfigIsNull = true;
            request.DataCaptureConfig = new Amazon.SageMaker.Model.DataCaptureConfig();
            List<Amazon.SageMaker.Model.CaptureOption> requestDataCaptureConfig_dataCaptureConfig_CaptureOption = null;
            if (cmdletContext.DataCaptureConfig_CaptureOption != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_CaptureOption = cmdletContext.DataCaptureConfig_CaptureOption;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_CaptureOption != null)
            {
                request.DataCaptureConfig.CaptureOptions = requestDataCaptureConfig_dataCaptureConfig_CaptureOption;
                requestDataCaptureConfigIsNull = false;
            }
            System.String requestDataCaptureConfig_dataCaptureConfig_DestinationS3Uri = null;
            if (cmdletContext.DataCaptureConfig_DestinationS3Uri != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_DestinationS3Uri = cmdletContext.DataCaptureConfig_DestinationS3Uri;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_DestinationS3Uri != null)
            {
                request.DataCaptureConfig.DestinationS3Uri = requestDataCaptureConfig_dataCaptureConfig_DestinationS3Uri;
                requestDataCaptureConfigIsNull = false;
            }
            System.Boolean? requestDataCaptureConfig_dataCaptureConfig_EnableCapture = null;
            if (cmdletContext.DataCaptureConfig_EnableCapture != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_EnableCapture = cmdletContext.DataCaptureConfig_EnableCapture.Value;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_EnableCapture != null)
            {
                request.DataCaptureConfig.EnableCapture = requestDataCaptureConfig_dataCaptureConfig_EnableCapture.Value;
                requestDataCaptureConfigIsNull = false;
            }
            System.Int32? requestDataCaptureConfig_dataCaptureConfig_InitialSamplingPercentage = null;
            if (cmdletContext.DataCaptureConfig_InitialSamplingPercentage != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_InitialSamplingPercentage = cmdletContext.DataCaptureConfig_InitialSamplingPercentage.Value;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_InitialSamplingPercentage != null)
            {
                request.DataCaptureConfig.InitialSamplingPercentage = requestDataCaptureConfig_dataCaptureConfig_InitialSamplingPercentage.Value;
                requestDataCaptureConfigIsNull = false;
            }
            System.String requestDataCaptureConfig_dataCaptureConfig_KmsKeyId = null;
            if (cmdletContext.DataCaptureConfig_KmsKeyId != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_KmsKeyId = cmdletContext.DataCaptureConfig_KmsKeyId;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_KmsKeyId != null)
            {
                request.DataCaptureConfig.KmsKeyId = requestDataCaptureConfig_dataCaptureConfig_KmsKeyId;
                requestDataCaptureConfigIsNull = false;
            }
            Amazon.SageMaker.Model.CaptureContentTypeHeader requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader = null;
            
             // populate CaptureContentTypeHeader
            var requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeaderIsNull = true;
            requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader = new Amazon.SageMaker.Model.CaptureContentTypeHeader();
            List<System.String> requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader_captureContentTypeHeader_CsvContentType = null;
            if (cmdletContext.CaptureContentTypeHeader_CsvContentType != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader_captureContentTypeHeader_CsvContentType = cmdletContext.CaptureContentTypeHeader_CsvContentType;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader_captureContentTypeHeader_CsvContentType != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader.CsvContentTypes = requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader_captureContentTypeHeader_CsvContentType;
                requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeaderIsNull = false;
            }
            List<System.String> requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader_captureContentTypeHeader_JsonContentType = null;
            if (cmdletContext.CaptureContentTypeHeader_JsonContentType != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader_captureContentTypeHeader_JsonContentType = cmdletContext.CaptureContentTypeHeader_JsonContentType;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader_captureContentTypeHeader_JsonContentType != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader.JsonContentTypes = requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader_captureContentTypeHeader_JsonContentType;
                requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeaderIsNull = false;
            }
             // determine if requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader should be set to null
            if (requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeaderIsNull)
            {
                requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader = null;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader != null)
            {
                request.DataCaptureConfig.CaptureContentTypeHeader = requestDataCaptureConfig_dataCaptureConfig_CaptureContentTypeHeader;
                requestDataCaptureConfigIsNull = false;
            }
             // determine if request.DataCaptureConfig should be set to null
            if (requestDataCaptureConfigIsNull)
            {
                request.DataCaptureConfig = null;
            }
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
            public System.Int32? ClientConfig_MaxConcurrentInvocationsPerInstance { get; set; }
            public System.String OutputConfig_KmsKeyId { get; set; }
            public System.String NotificationConfig_ErrorTopic { get; set; }
            public System.String NotificationConfig_SuccessTopic { get; set; }
            public System.String OutputConfig_S3OutputPath { get; set; }
            public List<System.String> CaptureContentTypeHeader_CsvContentType { get; set; }
            public List<System.String> CaptureContentTypeHeader_JsonContentType { get; set; }
            public List<Amazon.SageMaker.Model.CaptureOption> DataCaptureConfig_CaptureOption { get; set; }
            public System.String DataCaptureConfig_DestinationS3Uri { get; set; }
            public System.Boolean? DataCaptureConfig_EnableCapture { get; set; }
            public System.Int32? DataCaptureConfig_InitialSamplingPercentage { get; set; }
            public System.String DataCaptureConfig_KmsKeyId { get; set; }
            public System.String EndpointConfigName { get; set; }
            public System.String KmsKeyId { get; set; }
            public List<Amazon.SageMaker.Model.ProductionVariant> ProductionVariant { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateEndpointConfigResponse, NewSMEndpointConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointConfigArn;
        }
        
    }
}
