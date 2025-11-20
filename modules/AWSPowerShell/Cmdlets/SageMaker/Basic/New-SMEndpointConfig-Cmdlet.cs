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
    /// Creates an endpoint configuration that SageMaker hosting services uses to deploy models.
    /// In the configuration, you identify one or more models, created using the <c>CreateModel</c>
    /// API, to deploy and the resources that you want SageMaker to provision. Then you call
    /// the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpoint.html">CreateEndpoint</a>
    /// API.
    /// 
    ///  <note><para>
    ///  Use this API if you want to use SageMaker hosting services to deploy models into
    /// production. 
    /// </para></note><para>
    /// In the request, you define a <c>ProductionVariant</c>, for each model that you want
    /// to deploy. Each <c>ProductionVariant</c> parameter also describes the resources that
    /// you want SageMaker to provision. This includes the number and type of ML compute instances
    /// to deploy. 
    /// </para><para>
    /// If you are hosting multiple models, you also assign a <c>VariantWeight</c> to specify
    /// how much traffic you want to allocate to each model. For example, suppose that you
    /// want to host two models, A and B, and you assign traffic weight 2 for model A and
    /// 1 for model B. SageMaker distributes two-thirds of the traffic to Model A, and one-third
    /// to model B. 
    /// </para><note><para>
    /// When you call <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpoint.html">CreateEndpoint</a>,
    /// a load call is made to DynamoDB to verify that your endpoint configuration exists.
    /// When you read data from a DynamoDB table supporting <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadConsistency.html"><c>Eventually Consistent Reads</c></a>, the response might not reflect the results
    /// of a recently completed write operation. The response might include some stale data.
    /// If the dependent entities are not yet in DynamoDB, this causes a validation error.
    /// If you repeat your read request after a short time, the response should return the
    /// latest data. So retry logic is recommended to handle these possible issues. We also
    /// recommend that customers call <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeEndpointConfig.html">DescribeEndpointConfig</a>
    /// before calling <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpoint.html">CreateEndpoint</a>
    /// to minimize the potential impact of a DynamoDB eventually consistent read.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SMEndpointConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateEndpointConfig API operation.", Operation = new[] {"CreateEndpointConfig"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateEndpointConfigResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateEndpointConfigResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateEndpointConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMEndpointConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter InferenceConfig_ContentTemplate
        /// <summary>
        /// <para>
        /// <para>A template string used to format a JSON record into an acceptable model container
        /// input. For example, a <c>ContentTemplate</c> string <c>'{"myfeatures":$features}'</c>
        /// will format a list of features <c>[1,2,3]</c> into the record string <c>'{"myfeatures":[1,2,3]}'</c>.
        /// Required only when the model container input is in JSON Lines format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_ContentTemplate")]
        public System.String InferenceConfig_ContentTemplate { get; set; }
        #endregion
        
        #region Parameter CaptureContentTypeHeader_CsvContentType
        /// <summary>
        /// <para>
        /// <para>The list of all content type headers that Amazon SageMaker AI will treat as CSV and
        /// capture accordingly.</para>
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
        
        #region Parameter MetricsConfig_EnableEnhancedMetric
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable enhanced metrics for the endpoint. Enhanced metrics provide
        /// utilization data at instance and container granularity. Container granularity is supported
        /// for Inference Components. The default is <c>False</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricsConfig_EnableEnhancedMetrics")]
        public System.Boolean? MetricsConfig_EnableEnhancedMetric { get; set; }
        #endregion
        
        #region Parameter ClarifyExplainerConfig_EnableExplanation
        /// <summary>
        /// <para>
        /// <para>A JMESPath boolean expression used to filter which records to explain. Explanations
        /// are activated by default. See <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/clarify-online-explainability-create-endpoint.html#clarify-online-explainability-create-endpoint-enable"><c>EnableExplanations</c></a>for additional information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_EnableExplanations")]
        public System.String ClarifyExplainerConfig_EnableExplanation { get; set; }
        #endregion
        
        #region Parameter EnableNetworkIsolation
        /// <summary>
        /// <para>
        /// <para>Sets whether all model containers deployed to the endpoint are isolated. If they are,
        /// no inbound or outbound network calls can be made to or from the model containers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableNetworkIsolation { get; set; }
        #endregion
        
        #region Parameter EndpointConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint configuration. You specify this name in a <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpoint.html">CreateEndpoint</a>
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
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that Amazon SageMaker AI can assume
        /// to perform actions on your behalf. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">SageMaker
        /// AI Roles</a>. </para><note><para>To be able to pass this role to Amazon SageMaker AI, the caller of this action must
        /// have the <c>iam:PassRole</c> permission.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_FeatureHeader
        /// <summary>
        /// <para>
        /// <para>The names of the features. If provided, these are included in the endpoint response
        /// payload to help readability of the <c>InvokeEndpoint</c> output. See the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/clarify-online-explainability-invoke-endpoint.html#clarify-online-explainability-response">Response</a>
        /// section under <b>Invoke the endpoint</b> in the Developer Guide for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_FeatureHeaders")]
        public System.String[] InferenceConfig_FeatureHeader { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_FeaturesAttribute
        /// <summary>
        /// <para>
        /// <para>Provides the JMESPath expression to extract the features from a model container input
        /// in JSON Lines format. For example, if <c>FeaturesAttribute</c> is the JMESPath expression
        /// <c>'myfeatures'</c>, it extracts a list of features <c>[1,2,3]</c> from request data
        /// <c>'{"myfeatures":[1,2,3]}'</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_FeaturesAttribute")]
        public System.String InferenceConfig_FeaturesAttribute { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_FeatureType
        /// <summary>
        /// <para>
        /// <para>A list of data types of the features (optional). Applicable only to NLP explainability.
        /// If provided, <c>FeatureTypes</c> must have at least one <c>'text'</c> string (for
        /// example, <c>['text']</c>). If <c>FeatureTypes</c> is not provided, the explainer infers
        /// the feature types based on the baseline data. The feature types are included in the
        /// endpoint response payload. For additional information see the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/clarify-online-explainability-invoke-endpoint.html#clarify-online-explainability-response">response</a>
        /// section under <b>Invoke the endpoint</b> in the Developer Guide for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_FeatureTypes")]
        public System.String[] InferenceConfig_FeatureType { get; set; }
        #endregion
        
        #region Parameter TextConfig_Granularity
        /// <summary>
        /// <para>
        /// <para>The unit of granularity for the analysis of text features. For example, if the unit
        /// is <c>'token'</c>, then each token (like a word in English) of the text is treated
        /// as a feature. SHAP values are computed for each unit/feature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_Granularity")]
        [AWSConstantClassSource("Amazon.SageMaker.ClarifyTextGranularity")]
        public Amazon.SageMaker.ClarifyTextGranularity TextConfig_Granularity { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_IncludeInferenceResponseIn
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS topics where you want the inference response to be included.</para><note><para>The inference response is included only if the response size is less than or equal
        /// to 128 KB.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AsyncInferenceConfig_OutputConfig_NotificationConfig_IncludeInferenceResponseIn")]
        public System.String[] NotificationConfig_IncludeInferenceResponseIn { get; set; }
        #endregion
        
        #region Parameter DataCaptureConfig_InitialSamplingPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of requests SageMaker AI will capture. A lower value is recommended
        /// for Endpoints with high traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DataCaptureConfig_InitialSamplingPercentage { get; set; }
        #endregion
        
        #region Parameter CaptureContentTypeHeader_JsonContentType
        /// <summary>
        /// <para>
        /// <para>The list of all content type headers that SageMaker AI will treat as JSON and capture
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
        /// <para>The Amazon Resource Name (ARN) of an Key Management Service key that SageMaker AI
        /// uses to encrypt the captured data at rest using Amazon S3 server-side encryption.</para><para>The KmsKeyId can be any of the following formats: </para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias name ARN: <c>arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias</c></para></li></ul>
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
        /// instance that hosts the endpoint.</para><para>The KmsKeyId can be any of the following formats: </para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias name ARN: <c>arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias</c></para></li></ul><para>The KMS key policy must grant permission to the IAM role that you specify in your
        /// <c>CreateEndpoint</c>, <c>UpdateEndpoint</c> requests. For more information, refer
        /// to the Amazon Web Services Key Management Service section<a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">
        /// Using Key Policies in Amazon Web Services KMS </a></para><note><para>Certain Nitro-based instances include local storage, dependent on the instance type.
        /// Local storage volumes are encrypted using a hardware module on the instance. You can't
        /// request a <c>KmsKeyId</c> when using an instance type with local storage. If any of
        /// the models that you specify in the <c>ProductionVariants</c> parameter use nitro-based
        /// instances with local storage, do not specify a value for the <c>KmsKeyId</c> parameter.
        /// If you specify a value for <c>KmsKeyId</c> when using any nitro-based instances with
        /// local storage, the call to <c>CreateEndpointConfig</c> fails.</para><para>For a list of instance types that support local instance storage, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/InstanceStorage.html#instance-store-volumes">Instance
        /// Store Volumes</a>.</para><para>For more information about local instance storage encryption, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ssd-instance-store.html">SSD
        /// Instance Store Volumes</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_LabelAttribute
        /// <summary>
        /// <para>
        /// <para>A JMESPath expression used to locate the list of label headers in the model container
        /// output.</para><para><b>Example</b>: If the model container output of a batch request is <c>'{"labels":["cat","dog","fish"],"probability":[0.6,0.3,0.1]}'</c>,
        /// then set <c>LabelAttribute</c> to <c>'labels'</c> to extract the list of label headers
        /// <c>["cat","dog","fish"]</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_LabelAttribute")]
        public System.String InferenceConfig_LabelAttribute { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_LabelHeader
        /// <summary>
        /// <para>
        /// <para>For multiclass classification problems, the label headers are the names of the classes.
        /// Otherwise, the label header is the name of the predicted label. These are used to
        /// help readability for the output of the <c>InvokeEndpoint</c> API. See the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/clarify-online-explainability-invoke-endpoint.html#clarify-online-explainability-response">response</a>
        /// section under <b>Invoke the endpoint</b> in the Developer Guide for more information.
        /// If there are no label headers in the model container output, provide them manually
        /// using this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_LabelHeaders")]
        public System.String[] InferenceConfig_LabelHeader { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_LabelIndex
        /// <summary>
        /// <para>
        /// <para>A zero-based index used to extract a label header or list of label headers from model
        /// container output in CSV format.</para><para><b>Example for a multiclass model:</b> If the model container output consists of
        /// label headers followed by probabilities: <c>'"[\'cat\',\'dog\',\'fish\']","[0.1,0.6,0.3]"'</c>,
        /// set <c>LabelIndex</c> to <c>0</c> to select the label headers <c>['cat','dog','fish']</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_LabelIndex")]
        public System.Int32? InferenceConfig_LabelIndex { get; set; }
        #endregion
        
        #region Parameter TextConfig_Language
        /// <summary>
        /// <para>
        /// <para>Specifies the language of the text features in <a href=" https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes">ISO
        /// 639-1</a> or <a href="https://en.wikipedia.org/wiki/ISO_639-3">ISO 639-3</a> code
        /// of a supported language. </para><note><para>For a mix of multiple languages, use code <c>'xx'</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_Language")]
        [AWSConstantClassSource("Amazon.SageMaker.ClarifyTextLanguage")]
        public Amazon.SageMaker.ClarifyTextLanguage TextConfig_Language { get; set; }
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
        
        #region Parameter InferenceConfig_MaxPayloadInMB
        /// <summary>
        /// <para>
        /// <para>The maximum payload size (MB) allowed of a request from the explainer to the model
        /// container. Defaults to <c>6</c> MB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_MaxPayloadInMB")]
        public System.Int32? InferenceConfig_MaxPayloadInMB { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_MaxRecordCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of records in a request that the model container can process when
        /// querying the model container for the predictions of a <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/clarify-online-explainability-create-endpoint.html#clarify-online-explainability-create-endpoint-synthetic">synthetic
        /// dataset</a>. A record is a unit of input data that inference can be made on, for example,
        /// a single line in CSV data. If <c>MaxRecordCount</c> is <c>1</c>, the model container
        /// expects one record per request. A value of 2 or greater means that the model expects
        /// batch requests, which can reduce overhead and speed up the inferencing process. If
        /// this parameter is not provided, the explainer will tune the record count per request
        /// according to the model container's capacity at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_MaxRecordCount")]
        public System.Int32? InferenceConfig_MaxRecordCount { get; set; }
        #endregion
        
        #region Parameter MetricsConfig_MetricPublishFrequencyInSecond
        /// <summary>
        /// <para>
        /// <para>The frequency, in seconds, at which utilization metrics are published to Amazon CloudWatch.
        /// The default is <c>60</c> seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricsConfig_MetricPublishFrequencyInSeconds")]
        public System.Int32? MetricsConfig_MetricPublishFrequencyInSecond { get; set; }
        #endregion
        
        #region Parameter ShapBaselineConfig_MimeType
        /// <summary>
        /// <para>
        /// <para>The MIME type of the baseline data. Choose from <c>'text/csv'</c> or <c>'application/jsonlines'</c>.
        /// Defaults to <c>'text/csv'</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_MimeType")]
        public System.String ShapBaselineConfig_MimeType { get; set; }
        #endregion
        
        #region Parameter ShapConfig_NumberOfSample
        /// <summary>
        /// <para>
        /// <para>The number of samples to be used for analysis by the Kernal SHAP algorithm. </para><note><para>The number of samples determines the size of the synthetic dataset, which has an impact
        /// on latency of explainability requests. For more information, see the <b>Synthetic
        /// data</b> of <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/clarify-online-explainability-create-endpoint.html">Configure
        /// and create an endpoint</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_ShapConfig_NumberOfSamples")]
        public System.Int32? ShapConfig_NumberOfSample { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_ProbabilityAttribute
        /// <summary>
        /// <para>
        /// <para>A JMESPath expression used to extract the probability (or score) from the model container
        /// output if the model container is in JSON Lines format.</para><para><b>Example</b>: If the model container output of a single request is <c>'{"predicted_label":1,"probability":0.6}'</c>,
        /// then set <c>ProbabilityAttribute</c> to <c>'probability'</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_ProbabilityAttribute")]
        public System.String InferenceConfig_ProbabilityAttribute { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_ProbabilityIndex
        /// <summary>
        /// <para>
        /// <para>A zero-based index used to extract a probability value (score) or list from model
        /// container output in CSV format. If this value is not provided, the entire model container
        /// output will be treated as a probability value (score) or list.</para><para><b>Example for a single class model:</b> If the model container output consists of
        /// a string-formatted prediction label followed by its probability: <c>'1,0.6'</c>, set
        /// <c>ProbabilityIndex</c> to <c>1</c> to select the probability value <c>0.6</c>.</para><para><b>Example for a multiclass model:</b> If the model container output consists of
        /// a string-formatted prediction label followed by its probability: <c>'"[\'cat\',\'dog\',\'fish\']","[0.1,0.6,0.3]"'</c>,
        /// set <c>ProbabilityIndex</c> to <c>1</c> to select the probability values <c>[0.1,0.6,0.3]</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_InferenceConfig_ProbabilityIndex")]
        public System.Int32? InferenceConfig_ProbabilityIndex { get; set; }
        #endregion
        
        #region Parameter ProductionVariant
        /// <summary>
        /// <para>
        /// <para>An array of <c>ProductionVariant</c> objects, one for each model that you want to
        /// host at this endpoint.</para>
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
        
        #region Parameter OutputConfig_S3FailurePath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location to upload failure inference responses to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AsyncInferenceConfig_OutputConfig_S3FailurePath")]
        public System.String OutputConfig_S3FailurePath { get; set; }
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
        
        #region Parameter ShapConfig_Seed
        /// <summary>
        /// <para>
        /// <para>The starting value used to initialize the random number generator in the explainer.
        /// Provide a value for this parameter to obtain a deterministic SHAP result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_ShapConfig_Seed")]
        public System.Int32? ShapConfig_Seed { get; set; }
        #endregion
        
        #region Parameter ShadowProductionVariant
        /// <summary>
        /// <para>
        /// <para>An array of <c>ProductionVariant</c> objects, one for each model that you want to
        /// host at this endpoint in shadow mode with production traffic replicated from the model
        /// specified on <c>ProductionVariants</c>. If you use this field, you can only specify
        /// one variant for <c>ProductionVariants</c> and one variant for <c>ShadowProductionVariants</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ShadowProductionVariants")]
        public Amazon.SageMaker.Model.ProductionVariant[] ShadowProductionVariant { get; set; }
        #endregion
        
        #region Parameter ShapBaselineConfig_ShapBaseline
        /// <summary>
        /// <para>
        /// <para>The inline SHAP baseline data in string format. <c>ShapBaseline</c> can have one or
        /// multiple records to be used as the baseline dataset. The format of the SHAP baseline
        /// file should be the same format as the training dataset. For example, if the training
        /// dataset is in CSV format and each record contains four features, and all features
        /// are numerical, then the format of the baseline data should also share these characteristics.
        /// For natural language processing (NLP) of text columns, the baseline value should be
        /// the value used to replace the unit of text specified by the <c>Granularity</c> of
        /// the <c>TextConfig</c> parameter. The size limit for <c>ShapBasline</c> is 4 KB. Use
        /// the <c>ShapBaselineUri</c> parameter if you want to provide more than 4 KB of baseline
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_ShapBaseline")]
        public System.String ShapBaselineConfig_ShapBaseline { get; set; }
        #endregion
        
        #region Parameter ShapBaselineConfig_ShapBaselineUri
        /// <summary>
        /// <para>
        /// <para>The uniform resource identifier (URI) of the S3 bucket where the SHAP baseline file
        /// is stored. The format of the SHAP baseline file should be the same format as the format
        /// of the training dataset. For example, if the training dataset is in CSV format, and
        /// each record in the training dataset has four features, and all features are numerical,
        /// then the baseline file should also have this same format. Each record should contain
        /// only the features. If you are using a virtual private cloud (VPC), the <c>ShapBaselineUri</c>
        /// should be accessible to the VPC. For more information about setting up endpoints with
        /// Amazon Virtual Private Cloud, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/infrastructure-give-access.html">Give
        /// SageMaker access to Resources in your Amazon Virtual Private Cloud</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_ShapBaselineUri")]
        public System.String ShapBaselineConfig_ShapBaselineUri { get; set; }
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
        
        #region Parameter ShapConfig_UseLogit
        /// <summary>
        /// <para>
        /// <para>A Boolean toggle to indicate if you want to use the logit function (true) or log-odds
        /// units (false) for model predictions. Defaults to false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplainerConfig_ClarifyExplainerConfig_ShapConfig_UseLogit")]
        public System.Boolean? ShapConfig_UseLogit { get; set; }
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
            this._AWSSignerType = "v4";
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
            if (this.NotificationConfig_IncludeInferenceResponseIn != null)
            {
                context.NotificationConfig_IncludeInferenceResponseIn = new List<System.String>(this.NotificationConfig_IncludeInferenceResponseIn);
            }
            context.NotificationConfig_SuccessTopic = this.NotificationConfig_SuccessTopic;
            context.OutputConfig_S3FailurePath = this.OutputConfig_S3FailurePath;
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
            context.EnableNetworkIsolation = this.EnableNetworkIsolation;
            context.EndpointConfigName = this.EndpointConfigName;
            #if MODULAR
            if (this.EndpointConfigName == null && ParameterWasBound(nameof(this.EndpointConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.ClarifyExplainerConfig_EnableExplanation = this.ClarifyExplainerConfig_EnableExplanation;
            context.InferenceConfig_ContentTemplate = this.InferenceConfig_ContentTemplate;
            if (this.InferenceConfig_FeatureHeader != null)
            {
                context.InferenceConfig_FeatureHeader = new List<System.String>(this.InferenceConfig_FeatureHeader);
            }
            context.InferenceConfig_FeaturesAttribute = this.InferenceConfig_FeaturesAttribute;
            if (this.InferenceConfig_FeatureType != null)
            {
                context.InferenceConfig_FeatureType = new List<System.String>(this.InferenceConfig_FeatureType);
            }
            context.InferenceConfig_LabelAttribute = this.InferenceConfig_LabelAttribute;
            if (this.InferenceConfig_LabelHeader != null)
            {
                context.InferenceConfig_LabelHeader = new List<System.String>(this.InferenceConfig_LabelHeader);
            }
            context.InferenceConfig_LabelIndex = this.InferenceConfig_LabelIndex;
            context.InferenceConfig_MaxPayloadInMB = this.InferenceConfig_MaxPayloadInMB;
            context.InferenceConfig_MaxRecordCount = this.InferenceConfig_MaxRecordCount;
            context.InferenceConfig_ProbabilityAttribute = this.InferenceConfig_ProbabilityAttribute;
            context.InferenceConfig_ProbabilityIndex = this.InferenceConfig_ProbabilityIndex;
            context.ShapConfig_NumberOfSample = this.ShapConfig_NumberOfSample;
            context.ShapConfig_Seed = this.ShapConfig_Seed;
            context.ShapBaselineConfig_MimeType = this.ShapBaselineConfig_MimeType;
            context.ShapBaselineConfig_ShapBaseline = this.ShapBaselineConfig_ShapBaseline;
            context.ShapBaselineConfig_ShapBaselineUri = this.ShapBaselineConfig_ShapBaselineUri;
            context.TextConfig_Granularity = this.TextConfig_Granularity;
            context.TextConfig_Language = this.TextConfig_Language;
            context.ShapConfig_UseLogit = this.ShapConfig_UseLogit;
            context.KmsKeyId = this.KmsKeyId;
            context.MetricsConfig_EnableEnhancedMetric = this.MetricsConfig_EnableEnhancedMetric;
            context.MetricsConfig_MetricPublishFrequencyInSecond = this.MetricsConfig_MetricPublishFrequencyInSecond;
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
            if (this.ShadowProductionVariant != null)
            {
                context.ShadowProductionVariant = new List<Amazon.SageMaker.Model.ProductionVariant>(this.ShadowProductionVariant);
            }
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
            System.String requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_S3FailurePath = null;
            if (cmdletContext.OutputConfig_S3FailurePath != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_S3FailurePath = cmdletContext.OutputConfig_S3FailurePath;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_S3FailurePath != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig.S3FailurePath = requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_outputConfig_S3FailurePath;
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
            List<System.String> requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_IncludeInferenceResponseIn = null;
            if (cmdletContext.NotificationConfig_IncludeInferenceResponseIn != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_IncludeInferenceResponseIn = cmdletContext.NotificationConfig_IncludeInferenceResponseIn;
            }
            if (requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_IncludeInferenceResponseIn != null)
            {
                requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig.IncludeInferenceResponseIn = requestAsyncInferenceConfig_asyncInferenceConfig_OutputConfig_asyncInferenceConfig_OutputConfig_NotificationConfig_notificationConfig_IncludeInferenceResponseIn;
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
            if (cmdletContext.EnableNetworkIsolation != null)
            {
                request.EnableNetworkIsolation = cmdletContext.EnableNetworkIsolation.Value;
            }
            if (cmdletContext.EndpointConfigName != null)
            {
                request.EndpointConfigName = cmdletContext.EndpointConfigName;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate ExplainerConfig
            var requestExplainerConfigIsNull = true;
            request.ExplainerConfig = new Amazon.SageMaker.Model.ExplainerConfig();
            Amazon.SageMaker.Model.ClarifyExplainerConfig requestExplainerConfig_explainerConfig_ClarifyExplainerConfig = null;
            
             // populate ClarifyExplainerConfig
            var requestExplainerConfig_explainerConfig_ClarifyExplainerConfigIsNull = true;
            requestExplainerConfig_explainerConfig_ClarifyExplainerConfig = new Amazon.SageMaker.Model.ClarifyExplainerConfig();
            System.String requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_clarifyExplainerConfig_EnableExplanation = null;
            if (cmdletContext.ClarifyExplainerConfig_EnableExplanation != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_clarifyExplainerConfig_EnableExplanation = cmdletContext.ClarifyExplainerConfig_EnableExplanation;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_clarifyExplainerConfig_EnableExplanation != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig.EnableExplanations = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_clarifyExplainerConfig_EnableExplanation;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfigIsNull = false;
            }
            Amazon.SageMaker.Model.ClarifyShapConfig requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig = null;
            
             // populate ShapConfig
            var requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfigIsNull = true;
            requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig = new Amazon.SageMaker.Model.ClarifyShapConfig();
            System.Int32? requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_NumberOfSample = null;
            if (cmdletContext.ShapConfig_NumberOfSample != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_NumberOfSample = cmdletContext.ShapConfig_NumberOfSample.Value;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_NumberOfSample != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig.NumberOfSamples = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_NumberOfSample.Value;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfigIsNull = false;
            }
            System.Int32? requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_Seed = null;
            if (cmdletContext.ShapConfig_Seed != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_Seed = cmdletContext.ShapConfig_Seed.Value;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_Seed != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig.Seed = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_Seed.Value;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfigIsNull = false;
            }
            System.Boolean? requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_UseLogit = null;
            if (cmdletContext.ShapConfig_UseLogit != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_UseLogit = cmdletContext.ShapConfig_UseLogit.Value;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_UseLogit != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig.UseLogit = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_shapConfig_UseLogit.Value;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfigIsNull = false;
            }
            Amazon.SageMaker.Model.ClarifyTextConfig requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig = null;
            
             // populate TextConfig
            var requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfigIsNull = true;
            requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig = new Amazon.SageMaker.Model.ClarifyTextConfig();
            Amazon.SageMaker.ClarifyTextGranularity requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_textConfig_Granularity = null;
            if (cmdletContext.TextConfig_Granularity != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_textConfig_Granularity = cmdletContext.TextConfig_Granularity;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_textConfig_Granularity != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig.Granularity = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_textConfig_Granularity;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfigIsNull = false;
            }
            Amazon.SageMaker.ClarifyTextLanguage requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_textConfig_Language = null;
            if (cmdletContext.TextConfig_Language != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_textConfig_Language = cmdletContext.TextConfig_Language;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_textConfig_Language != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig.Language = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig_textConfig_Language;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfigIsNull = false;
            }
             // determine if requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig should be set to null
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfigIsNull)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig = null;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig.TextConfig = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_TextConfig;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfigIsNull = false;
            }
            Amazon.SageMaker.Model.ClarifyShapBaselineConfig requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig = null;
            
             // populate ShapBaselineConfig
            var requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfigIsNull = true;
            requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig = new Amazon.SageMaker.Model.ClarifyShapBaselineConfig();
            System.String requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_MimeType = null;
            if (cmdletContext.ShapBaselineConfig_MimeType != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_MimeType = cmdletContext.ShapBaselineConfig_MimeType;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_MimeType != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig.MimeType = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_MimeType;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfigIsNull = false;
            }
            System.String requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_ShapBaseline = null;
            if (cmdletContext.ShapBaselineConfig_ShapBaseline != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_ShapBaseline = cmdletContext.ShapBaselineConfig_ShapBaseline;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_ShapBaseline != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig.ShapBaseline = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_ShapBaseline;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfigIsNull = false;
            }
            System.String requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_ShapBaselineUri = null;
            if (cmdletContext.ShapBaselineConfig_ShapBaselineUri != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_ShapBaselineUri = cmdletContext.ShapBaselineConfig_ShapBaselineUri;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_ShapBaselineUri != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig.ShapBaselineUri = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig_shapBaselineConfig_ShapBaselineUri;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfigIsNull = false;
            }
             // determine if requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig should be set to null
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfigIsNull)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig = null;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig.ShapBaselineConfig = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig_ShapBaselineConfig;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfigIsNull = false;
            }
             // determine if requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig should be set to null
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfigIsNull)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig = null;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig.ShapConfig = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_ShapConfig;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfigIsNull = false;
            }
            Amazon.SageMaker.Model.ClarifyInferenceConfig requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig = null;
            
             // populate InferenceConfig
            var requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = true;
            requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig = new Amazon.SageMaker.Model.ClarifyInferenceConfig();
            System.String requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ContentTemplate = null;
            if (cmdletContext.InferenceConfig_ContentTemplate != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ContentTemplate = cmdletContext.InferenceConfig_ContentTemplate;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ContentTemplate != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.ContentTemplate = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ContentTemplate;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            List<System.String> requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeatureHeader = null;
            if (cmdletContext.InferenceConfig_FeatureHeader != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeatureHeader = cmdletContext.InferenceConfig_FeatureHeader;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeatureHeader != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.FeatureHeaders = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeatureHeader;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            System.String requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeaturesAttribute = null;
            if (cmdletContext.InferenceConfig_FeaturesAttribute != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeaturesAttribute = cmdletContext.InferenceConfig_FeaturesAttribute;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeaturesAttribute != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.FeaturesAttribute = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeaturesAttribute;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            List<System.String> requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeatureType = null;
            if (cmdletContext.InferenceConfig_FeatureType != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeatureType = cmdletContext.InferenceConfig_FeatureType;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeatureType != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.FeatureTypes = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_FeatureType;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            System.String requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelAttribute = null;
            if (cmdletContext.InferenceConfig_LabelAttribute != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelAttribute = cmdletContext.InferenceConfig_LabelAttribute;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelAttribute != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.LabelAttribute = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelAttribute;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            List<System.String> requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelHeader = null;
            if (cmdletContext.InferenceConfig_LabelHeader != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelHeader = cmdletContext.InferenceConfig_LabelHeader;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelHeader != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.LabelHeaders = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelHeader;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            System.Int32? requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelIndex = null;
            if (cmdletContext.InferenceConfig_LabelIndex != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelIndex = cmdletContext.InferenceConfig_LabelIndex.Value;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelIndex != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.LabelIndex = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_LabelIndex.Value;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            System.Int32? requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_MaxPayloadInMB = null;
            if (cmdletContext.InferenceConfig_MaxPayloadInMB != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_MaxPayloadInMB = cmdletContext.InferenceConfig_MaxPayloadInMB.Value;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_MaxPayloadInMB != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.MaxPayloadInMB = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_MaxPayloadInMB.Value;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            System.Int32? requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_MaxRecordCount = null;
            if (cmdletContext.InferenceConfig_MaxRecordCount != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_MaxRecordCount = cmdletContext.InferenceConfig_MaxRecordCount.Value;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_MaxRecordCount != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.MaxRecordCount = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_MaxRecordCount.Value;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            System.String requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ProbabilityAttribute = null;
            if (cmdletContext.InferenceConfig_ProbabilityAttribute != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ProbabilityAttribute = cmdletContext.InferenceConfig_ProbabilityAttribute;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ProbabilityAttribute != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.ProbabilityAttribute = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ProbabilityAttribute;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
            System.Int32? requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ProbabilityIndex = null;
            if (cmdletContext.InferenceConfig_ProbabilityIndex != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ProbabilityIndex = cmdletContext.InferenceConfig_ProbabilityIndex.Value;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ProbabilityIndex != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig.ProbabilityIndex = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig_inferenceConfig_ProbabilityIndex.Value;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull = false;
            }
             // determine if requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig should be set to null
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfigIsNull)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig = null;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig != null)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig.InferenceConfig = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig_explainerConfig_ClarifyExplainerConfig_InferenceConfig;
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfigIsNull = false;
            }
             // determine if requestExplainerConfig_explainerConfig_ClarifyExplainerConfig should be set to null
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfigIsNull)
            {
                requestExplainerConfig_explainerConfig_ClarifyExplainerConfig = null;
            }
            if (requestExplainerConfig_explainerConfig_ClarifyExplainerConfig != null)
            {
                request.ExplainerConfig.ClarifyExplainerConfig = requestExplainerConfig_explainerConfig_ClarifyExplainerConfig;
                requestExplainerConfigIsNull = false;
            }
             // determine if request.ExplainerConfig should be set to null
            if (requestExplainerConfigIsNull)
            {
                request.ExplainerConfig = null;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate MetricsConfig
            var requestMetricsConfigIsNull = true;
            request.MetricsConfig = new Amazon.SageMaker.Model.MetricsConfig();
            System.Boolean? requestMetricsConfig_metricsConfig_EnableEnhancedMetric = null;
            if (cmdletContext.MetricsConfig_EnableEnhancedMetric != null)
            {
                requestMetricsConfig_metricsConfig_EnableEnhancedMetric = cmdletContext.MetricsConfig_EnableEnhancedMetric.Value;
            }
            if (requestMetricsConfig_metricsConfig_EnableEnhancedMetric != null)
            {
                request.MetricsConfig.EnableEnhancedMetrics = requestMetricsConfig_metricsConfig_EnableEnhancedMetric.Value;
                requestMetricsConfigIsNull = false;
            }
            System.Int32? requestMetricsConfig_metricsConfig_MetricPublishFrequencyInSecond = null;
            if (cmdletContext.MetricsConfig_MetricPublishFrequencyInSecond != null)
            {
                requestMetricsConfig_metricsConfig_MetricPublishFrequencyInSecond = cmdletContext.MetricsConfig_MetricPublishFrequencyInSecond.Value;
            }
            if (requestMetricsConfig_metricsConfig_MetricPublishFrequencyInSecond != null)
            {
                request.MetricsConfig.MetricPublishFrequencyInSeconds = requestMetricsConfig_metricsConfig_MetricPublishFrequencyInSecond.Value;
                requestMetricsConfigIsNull = false;
            }
             // determine if request.MetricsConfig should be set to null
            if (requestMetricsConfigIsNull)
            {
                request.MetricsConfig = null;
            }
            if (cmdletContext.ProductionVariant != null)
            {
                request.ProductionVariants = cmdletContext.ProductionVariant;
            }
            if (cmdletContext.ShadowProductionVariant != null)
            {
                request.ShadowProductionVariants = cmdletContext.ShadowProductionVariant;
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
            public List<System.String> NotificationConfig_IncludeInferenceResponseIn { get; set; }
            public System.String NotificationConfig_SuccessTopic { get; set; }
            public System.String OutputConfig_S3FailurePath { get; set; }
            public System.String OutputConfig_S3OutputPath { get; set; }
            public List<System.String> CaptureContentTypeHeader_CsvContentType { get; set; }
            public List<System.String> CaptureContentTypeHeader_JsonContentType { get; set; }
            public List<Amazon.SageMaker.Model.CaptureOption> DataCaptureConfig_CaptureOption { get; set; }
            public System.String DataCaptureConfig_DestinationS3Uri { get; set; }
            public System.Boolean? DataCaptureConfig_EnableCapture { get; set; }
            public System.Int32? DataCaptureConfig_InitialSamplingPercentage { get; set; }
            public System.String DataCaptureConfig_KmsKeyId { get; set; }
            public System.Boolean? EnableNetworkIsolation { get; set; }
            public System.String EndpointConfigName { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String ClarifyExplainerConfig_EnableExplanation { get; set; }
            public System.String InferenceConfig_ContentTemplate { get; set; }
            public List<System.String> InferenceConfig_FeatureHeader { get; set; }
            public System.String InferenceConfig_FeaturesAttribute { get; set; }
            public List<System.String> InferenceConfig_FeatureType { get; set; }
            public System.String InferenceConfig_LabelAttribute { get; set; }
            public List<System.String> InferenceConfig_LabelHeader { get; set; }
            public System.Int32? InferenceConfig_LabelIndex { get; set; }
            public System.Int32? InferenceConfig_MaxPayloadInMB { get; set; }
            public System.Int32? InferenceConfig_MaxRecordCount { get; set; }
            public System.String InferenceConfig_ProbabilityAttribute { get; set; }
            public System.Int32? InferenceConfig_ProbabilityIndex { get; set; }
            public System.Int32? ShapConfig_NumberOfSample { get; set; }
            public System.Int32? ShapConfig_Seed { get; set; }
            public System.String ShapBaselineConfig_MimeType { get; set; }
            public System.String ShapBaselineConfig_ShapBaseline { get; set; }
            public System.String ShapBaselineConfig_ShapBaselineUri { get; set; }
            public Amazon.SageMaker.ClarifyTextGranularity TextConfig_Granularity { get; set; }
            public Amazon.SageMaker.ClarifyTextLanguage TextConfig_Language { get; set; }
            public System.Boolean? ShapConfig_UseLogit { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Boolean? MetricsConfig_EnableEnhancedMetric { get; set; }
            public System.Int32? MetricsConfig_MetricPublishFrequencyInSecond { get; set; }
            public List<Amazon.SageMaker.Model.ProductionVariant> ProductionVariant { get; set; }
            public List<Amazon.SageMaker.Model.ProductionVariant> ShadowProductionVariant { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateEndpointConfigResponse, NewSMEndpointConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointConfigArn;
        }
        
    }
}
