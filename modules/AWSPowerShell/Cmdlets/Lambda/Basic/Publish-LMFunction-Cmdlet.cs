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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Creates a Lambda function. To create a function, you need a <a href="https://docs.aws.amazon.com/lambda/latest/dg/gettingstarted-package.html">deployment
    /// package</a> and an <a href="https://docs.aws.amazon.com/lambda/latest/dg/intro-permission-model.html#lambda-intro-execution-role">execution
    /// role</a>. The deployment package is a .zip file archive or container image that contains
    /// your function code. The execution role grants the function permission to use Amazon
    /// Web Services, such as Amazon CloudWatch Logs for log streaming and X-Ray for request
    /// tracing.
    /// 
    ///  
    /// <para>
    /// If the deployment package is a <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-images.html">container
    /// image</a>, then you set the package type to <c>Image</c>. For a container image, the
    /// code property must include the URI of a container image in the Amazon ECR registry.
    /// You do not need to specify the handler and runtime properties.
    /// </para><para>
    /// If the deployment package is a <a href="https://docs.aws.amazon.com/lambda/latest/dg/gettingstarted-package.html#gettingstarted-package-zip">.zip
    /// file archive</a>, then you set the package type to <c>Zip</c>. For a .zip file archive,
    /// the code property specifies the location of the .zip file. You must also specify the
    /// handler and runtime properties. The code in the deployment package must be compatible
    /// with the target instruction set architecture of the function (<c>x86-64</c> or <c>arm64</c>).
    /// If you do not specify the architecture, then the default value is <c>x86-64</c>.
    /// </para><para>
    /// When you create a function, Lambda provisions an instance of the function and its
    /// supporting resources. If your function connects to a VPC, this process can take a
    /// minute or so. During this time, you can't invoke or modify the function. The <c>State</c>,
    /// <c>StateReason</c>, and <c>StateReasonCode</c> fields in the response from <a>GetFunctionConfiguration</a>
    /// indicate when the function is ready to invoke. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/functions-states.html">Lambda
    /// function states</a>.
    /// </para><para>
    /// A function has an unpublished version, and can have published versions and aliases.
    /// The unpublished version changes when you update your function's code and configuration.
    /// A published version is a snapshot of your function code and configuration that can't
    /// be changed. An alias is a named resource that maps to a version, and can be changed
    /// to map to a different version. Use the <c>Publish</c> parameter to create version
    /// <c>1</c> of your function from its initial configuration.
    /// </para><para>
    /// The other parameters let you configure version-specific and function-level settings.
    /// You can modify version-specific settings later with <a>UpdateFunctionConfiguration</a>.
    /// Function-level settings apply to both the unpublished and published versions of the
    /// function, and include tags (<a>TagResource</a>) and per-function concurrency limits
    /// (<a>PutFunctionConcurrency</a>).
    /// </para><para>
    /// You can use code signing if your deployment package is a .zip file archive. To enable
    /// code signing for this function, specify the ARN of a code-signing configuration. When
    /// a user attempts to deploy a code package with <a>UpdateFunctionCode</a>, Lambda checks
    /// that the code package has a valid signature from a trusted publisher. The code-signing
    /// configuration includes set of signing profiles, which define the trusted publishers
    /// for this function.
    /// </para><para>
    /// If another Amazon Web Services account or an Amazon Web Service invokes your function,
    /// use <a>AddPermission</a> to grant permission by creating a resource-based Identity
    /// and Access Management (IAM) policy. You can grant permissions at the function level,
    /// on a version, or on an alias.
    /// </para><para>
    /// To invoke your function directly, use <a>Invoke</a>. To invoke your function in response
    /// to events in other Amazon Web Services, create an event source mapping (<a>CreateEventSourceMapping</a>),
    /// or configure a function trigger in the other service. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-invocation.html">Invoking
    /// Lambda functions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Publish", "LMFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName="FromMemoryStream")]
    [OutputType("Amazon.Lambda.Model.CreateFunctionResponse")]
    [AWSCmdlet("Calls the AWS Lambda CreateFunction API operation.", Operation = new[] {"CreateFunction"}, SelectReturnType = typeof(Amazon.Lambda.Model.CreateFunctionResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.CreateFunctionResponse",
        "This cmdlet returns an Amazon.Lambda.Model.CreateFunctionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class PublishLMFunctionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoggingConfig_ApplicationLogLevel
        /// <summary>
        /// <para>
        /// <para>Set this property to filter the application logs for your function that Lambda sends
        /// to CloudWatch. Lambda only sends application logs at the selected level and lower.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.ApplicationLogLevel")]
        public Amazon.Lambda.ApplicationLogLevel LoggingConfig_ApplicationLogLevel { get; set; }
        #endregion
        
        #region Parameter SnapStart_ApplyOn
        /// <summary>
        /// <para>
        /// <para>Set to <c>PublishedVersions</c> to create a snapshot of the initialized execution
        /// environment when you publish a function version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.SnapStartApplyOn")]
        public Amazon.Lambda.SnapStartApplyOn SnapStart_ApplyOn { get; set; }
        #endregion
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The instruction set architecture that the function supports. Enter a string array
        /// with one of the valid values (arm64 or x86_64). The default value is <c>x86_64</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Architectures")]
        public System.String[] Architecture { get; set; }
        #endregion
        
        #region Parameter CodeSigningConfigArn
        /// <summary>
        /// <para>
        /// <para>To enable code signing for this function, specify the ARN of a code-signing configuration.
        /// A code-signing configuration includes a set of signing profiles, which define the
        /// trusted publishers for this function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CodeSigningConfigArn { get; set; }
        #endregion
        
        #region Parameter ImageConfig_Command
        /// <summary>
        /// <para>
        /// <para>Specifies parameters that you want to pass in with ENTRYPOINT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ImageConfig_Command { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ImageConfig_EntryPoint
        /// <summary>
        /// <para>
        /// <para>Specifies the entry point to their application, which is typically the location of
        /// the runtime executable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ImageConfig_EntryPoint { get; set; }
        #endregion
        
        #region Parameter FileSystemConfig
        /// <summary>
        /// <para>
        /// <para>Connection settings for an Amazon EFS file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FileSystemConfigs")]
        public Amazon.Lambda.Model.FileSystemConfig[] FileSystemConfig { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name of the Lambda function.</para><para><b>Name formats</b></para><ul><li><para><b>Function name</b> – <c>my-function</c>.</para></li><li><para><b>Function ARN</b> – <c>arn:aws:lambda:us-west-2:123456789012:function:my-function</c>.</para></li><li><para><b>Partial ARN</b> – <c>123456789012:function:my-function</c>.</para></li></ul><para>The length constraint applies only to the full ARN. If you specify only the function
        /// name, it is limited to 64 characters in length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Handler
        /// <summary>
        /// <para>
        /// <para>The name of the method within your code that Lambda calls to run your function. Handler
        /// is required if the deployment package is a .zip file archive. The format includes
        /// the file name. It can also include namespaces and other qualifiers, depending on the
        /// runtime. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/foundation-progmodel.html">Lambda
        /// programming model</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromS3Object")]
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromMemoryStream")]
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromZipFile")]
        public System.String Handler { get; set; }
        #endregion
        
        #region Parameter Code_ImageUri
        /// <summary>
        /// <para>
        /// <para>URI of a <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-images.html">container
        /// image</a> in the Amazon ECR registry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromImage")]
        public System.String Code_ImageUri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Ipv6AllowedForDualStack
        /// <summary>
        /// <para>
        /// <para>Allows outbound IPv6 traffic on VPC functions that are connected to dual-stack subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? VpcConfig_Ipv6AllowedForDualStack { get; set; }
        #endregion
        
        #region Parameter ImageConfig_IsCommandSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.Lambda.Model.ImageConfig.Command" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ImageConfig_IsCommandSet { get; set; }
        #endregion
        
        #region Parameter ImageConfig_IsEntryPointSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.Lambda.Model.ImageConfig.EntryPoint" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ImageConfig_IsEntryPointSet { get; set; }
        #endregion
        
        #region Parameter VpcConfig_IsSecurityGroupIdsSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.Lambda.Model.VpcConfig.SecurityGroupIds" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? VpcConfig_IsSecurityGroupIdsSet { get; set; }
        #endregion
        
        #region Parameter VpcConfig_IsSubnetIdsSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.Lambda.Model.VpcConfig.SubnetIds" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? VpcConfig_IsSubnetIdsSet { get; set; }
        #endregion
        
        #region Parameter Environment_IsVariablesSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.Lambda.Model.Environment.Variables" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Environment_IsVariablesSet { get; set; }
        #endregion
        
        #region Parameter KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Key Management Service (KMS) customer managed key that's used to encrypt
        /// your function's <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-envvars.html#configuration-envvars-encryption">environment
        /// variables</a>. When <a href="https://docs.aws.amazon.com/lambda/latest/dg/snapstart-security.html">Lambda
        /// SnapStart</a> is activated, Lambda also uses this key is to encrypt your function's
        /// snapshot. If you deploy your function using a container image, Lambda also uses this
        /// key to encrypt your function when it's deployed. Note that this is not the same key
        /// that's used to protect your container image in the Amazon Elastic Container Registry
        /// (Amazon ECR). If you don't provide a customer managed key, Lambda uses a default service
        /// key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKeyArn { get; set; }
        #endregion
        
        #region Parameter Layer
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-layers.html">function
        /// layers</a> to add to the function's execution environment. Specify each layer by its
        /// ARN, including the version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layers")]
        public System.String[] Layer { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_LogFormat
        /// <summary>
        /// <para>
        /// <para>The format in which Lambda sends your function's application and system logs to CloudWatch.
        /// Select between plain text and structured JSON.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.LogFormat")]
        public Amazon.Lambda.LogFormat LoggingConfig_LogFormat { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon CloudWatch log group the function sends logs to. By default,
        /// Lambda functions send logs to a default log group named <c>/aws/lambda/&lt;function
        /// name&gt;</c>. To use a different log group, enter an existing log group or enter a
        /// new log group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfig_LogGroup { get; set; }
        #endregion
        
        #region Parameter MemorySize
        /// <summary>
        /// <para>
        /// <para>The amount of <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-function-common.html#configuration-memory-console">memory
        /// available to the function</a> at runtime. Increasing the function memory also increases
        /// its CPU allocation. The default value is 128 MB. The value can be any multiple of
        /// 1 MB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MemorySize { get; set; }
        #endregion
        
        #region Parameter TracingConfig_Mode
        /// <summary>
        /// <para>
        /// <para>The tracing mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.TracingMode")]
        public Amazon.Lambda.TracingMode TracingConfig_Mode { get; set; }
        #endregion
        
        #region Parameter PackageType
        /// <summary>
        /// <para>
        /// <para>The type of deployment package. Set to <c>Image</c> for container image and set to
        /// <c>Zip</c> for .zip file archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.PackageType")]
        public Amazon.Lambda.PackageType PackageType { get; set; }
        #endregion
        
        #region Parameter PublishVersion
        /// <summary>
        /// <para>
        /// <para>Set to true to publish the first version of the function during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublishVersion { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the function's execution role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Runtime
        /// <summary>
        /// <para>
        /// <para>The identifier of the function's <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-runtimes.html">runtime</a>.
        /// Runtime is required if the deployment package is a .zip file archive.</para><para>The following list includes deprecated runtimes. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-runtimes.html#runtime-support-policy">Runtime
        /// deprecation policy</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.Runtime")]
        public Amazon.Lambda.Runtime Runtime { get; set; }
        #endregion
        
        #region Parameter Code_S3Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 bucket in the same Amazon Web Services Region as your function. The bucket
        /// can be in a different Amazon Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromS3Object")]
        [Alias("BucketName","FunctionCode_S3Bucket","S3Bucket")]
        public System.String Code_S3Bucket { get; set; }
        #endregion
        
        #region Parameter Code_S3Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key of the deployment package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromS3Object")]
        [Alias("FunctionCode_S3Key","Key","S3Key")]
        public System.String Code_S3Key { get; set; }
        #endregion
        
        #region Parameter Code_S3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>For versioned objects, the version of the deployment package object to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "FromS3Object")]
        [Alias("FunctionCode_S3ObjectVersion","S3ObjectVersion","VersionId")]
        public System.String Code_S3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security group IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter EphemeralStorage_Size
        /// <summary>
        /// <para>
        /// <para>The size of the function's <c>/tmp</c> directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EphemeralStorage_Size { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of VPC subnet IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_SystemLogLevel
        /// <summary>
        /// <para>
        /// <para>Set this property to filter the system logs for your function that Lambda sends to
        /// CloudWatch. Lambda only sends system logs at the selected level and lower.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.SystemLogLevel")]
        public Amazon.Lambda.SystemLogLevel LoggingConfig_SystemLogLevel { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/lambda/latest/dg/tagging.html">tags</a>
        /// to apply to the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter DeadLetterConfig_TargetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon SQS queue or Amazon SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeadLetterConfig_TargetArn { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The amount of time (in seconds) that Lambda allows a function to run before stopping
        /// it. The default is 3 seconds. The maximum allowed value is 900 seconds. For more information,
        /// see <a href="https://docs.aws.amazon.com/lambda/latest/dg/runtimes-context.html">Lambda
        /// execution environment</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter Environment_Variable
        /// <summary>
        /// <para>
        /// <para>Environment variable key-value pairs. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-envvars.html">Using
        /// Lambda environment variables</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_Variables")]
        public System.Collections.Hashtable Environment_Variable { get; set; }
        #endregion
        
        #region Parameter ImageConfig_WorkingDirectory
        /// <summary>
        /// <para>
        /// <para>Specifies the working directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageConfig_WorkingDirectory { get; set; }
        #endregion
        
        #region Parameter Code_ZipFile
        /// <summary>
        /// <para>
        /// <para>The base64-encoded contents of the deployment package. Amazon Web Services SDK and
        /// CLI clients handle the encoding for you.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromMemoryStream")]
        [Alias("ZipContent","ZipFileContent")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Code_ZipFile { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.CreateFunctionResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.CreateFunctionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FunctionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-LMFunction (CreateFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.CreateFunctionResponse, PublishLMFunctionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FunctionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Architecture != null)
            {
                context.Architecture = new List<System.String>(this.Architecture);
            }
            context.Code_ImageUri = this.Code_ImageUri;
            context.Code_S3Bucket = this.Code_S3Bucket;
            context.Code_S3Key = this.Code_S3Key;
            context.Code_S3ObjectVersion = this.Code_S3ObjectVersion;
            context.Code_ZipFile = this.Code_ZipFile;
            context.CodeSigningConfigArn = this.CodeSigningConfigArn;
            context.DeadLetterConfig_TargetArn = this.DeadLetterConfig_TargetArn;
            context.Description = this.Description;
            if (this.Environment_Variable != null)
            {
                context.Environment_Variable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Environment_Variable.Keys)
                {
                    context.Environment_Variable.Add((String)hashKey, (String)(this.Environment_Variable[hashKey]));
                }
            }
            context.Environment_IsVariablesSet = this.Environment_IsVariablesSet;
            if (!ParameterWasBound(nameof(this.Environment_IsVariablesSet)) && this.Environment_Variable != null)
            {
                context.Environment_IsVariablesSet = true;
            }
            context.EphemeralStorage_Size = this.EphemeralStorage_Size;
            if (this.FileSystemConfig != null)
            {
                context.FileSystemConfig = new List<Amazon.Lambda.Model.FileSystemConfig>(this.FileSystemConfig);
            }
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Handler = this.Handler;
            if (this.ImageConfig_Command != null)
            {
                context.ImageConfig_Command = new List<System.String>(this.ImageConfig_Command);
            }
            context.ImageConfig_IsCommandSet = this.ImageConfig_IsCommandSet;
            if (!ParameterWasBound(nameof(this.ImageConfig_IsCommandSet)) && this.ImageConfig_Command != null)
            {
                context.ImageConfig_IsCommandSet = true;
            }
            if (this.ImageConfig_EntryPoint != null)
            {
                context.ImageConfig_EntryPoint = new List<System.String>(this.ImageConfig_EntryPoint);
            }
            context.ImageConfig_IsEntryPointSet = this.ImageConfig_IsEntryPointSet;
            if (!ParameterWasBound(nameof(this.ImageConfig_IsEntryPointSet)) && this.ImageConfig_EntryPoint != null)
            {
                context.ImageConfig_IsEntryPointSet = true;
            }
            context.ImageConfig_WorkingDirectory = this.ImageConfig_WorkingDirectory;
            context.KMSKeyArn = this.KMSKeyArn;
            if (this.Layer != null)
            {
                context.Layer = new List<System.String>(this.Layer);
            }
            context.LoggingConfig_ApplicationLogLevel = this.LoggingConfig_ApplicationLogLevel;
            context.LoggingConfig_LogFormat = this.LoggingConfig_LogFormat;
            context.LoggingConfig_LogGroup = this.LoggingConfig_LogGroup;
            context.LoggingConfig_SystemLogLevel = this.LoggingConfig_SystemLogLevel;
            context.MemorySize = this.MemorySize;
            context.PackageType = this.PackageType;
            context.PublishVersion = this.PublishVersion;
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Runtime = this.Runtime;
            context.SnapStart_ApplyOn = this.SnapStart_ApplyOn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.Timeout = this.Timeout;
            context.TracingConfig_Mode = this.TracingConfig_Mode;
            context.VpcConfig_Ipv6AllowedForDualStack = this.VpcConfig_Ipv6AllowedForDualStack;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            context.VpcConfig_IsSecurityGroupIdsSet = this.VpcConfig_IsSecurityGroupIdsSet;
            if (!ParameterWasBound(nameof(this.VpcConfig_IsSecurityGroupIdsSet)) && this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_IsSecurityGroupIdsSet = true;
            }
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetId = new List<System.String>(this.VpcConfig_SubnetId);
            }
            context.VpcConfig_IsSubnetIdsSet = this.VpcConfig_IsSubnetIdsSet;
            if (!ParameterWasBound(nameof(this.VpcConfig_IsSubnetIdsSet)) && this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_IsSubnetIdsSet = true;
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Code_ZipFileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Lambda.Model.CreateFunctionRequest();
                
                if (cmdletContext.Architecture != null)
                {
                    request.Architectures = cmdletContext.Architecture;
                }
                
                 // populate Code
                var requestCodeIsNull = true;
                request.Code = new Amazon.Lambda.Model.FunctionCode();
                System.String requestCode_code_ImageUri = null;
                if (cmdletContext.Code_ImageUri != null)
                {
                    requestCode_code_ImageUri = cmdletContext.Code_ImageUri;
                }
                if (requestCode_code_ImageUri != null)
                {
                    request.Code.ImageUri = requestCode_code_ImageUri;
                    requestCodeIsNull = false;
                }
                System.String requestCode_code_S3Bucket = null;
                if (cmdletContext.Code_S3Bucket != null)
                {
                    requestCode_code_S3Bucket = cmdletContext.Code_S3Bucket;
                }
                if (requestCode_code_S3Bucket != null)
                {
                    request.Code.S3Bucket = requestCode_code_S3Bucket;
                    requestCodeIsNull = false;
                }
                System.String requestCode_code_S3Key = null;
                if (cmdletContext.Code_S3Key != null)
                {
                    requestCode_code_S3Key = cmdletContext.Code_S3Key;
                }
                if (requestCode_code_S3Key != null)
                {
                    request.Code.S3Key = requestCode_code_S3Key;
                    requestCodeIsNull = false;
                }
                System.String requestCode_code_S3ObjectVersion = null;
                if (cmdletContext.Code_S3ObjectVersion != null)
                {
                    requestCode_code_S3ObjectVersion = cmdletContext.Code_S3ObjectVersion;
                }
                if (requestCode_code_S3ObjectVersion != null)
                {
                    request.Code.S3ObjectVersion = requestCode_code_S3ObjectVersion;
                    requestCodeIsNull = false;
                }
                System.IO.MemoryStream requestCode_code_ZipFile = null;
                if (cmdletContext.Code_ZipFile != null)
                {
                    _Code_ZipFileStream = new System.IO.MemoryStream(cmdletContext.Code_ZipFile);
                    requestCode_code_ZipFile = _Code_ZipFileStream;
                }
                if (requestCode_code_ZipFile != null)
                {
                    request.Code.ZipFile = requestCode_code_ZipFile;
                    requestCodeIsNull = false;
                }
                 // determine if request.Code should be set to null
                if (requestCodeIsNull)
                {
                    request.Code = null;
                }
                if (cmdletContext.CodeSigningConfigArn != null)
                {
                    request.CodeSigningConfigArn = cmdletContext.CodeSigningConfigArn;
                }
                
                 // populate DeadLetterConfig
                var requestDeadLetterConfigIsNull = true;
                request.DeadLetterConfig = new Amazon.Lambda.Model.DeadLetterConfig();
                System.String requestDeadLetterConfig_deadLetterConfig_TargetArn = null;
                if (cmdletContext.DeadLetterConfig_TargetArn != null)
                {
                    requestDeadLetterConfig_deadLetterConfig_TargetArn = cmdletContext.DeadLetterConfig_TargetArn;
                }
                if (requestDeadLetterConfig_deadLetterConfig_TargetArn != null)
                {
                    request.DeadLetterConfig.TargetArn = requestDeadLetterConfig_deadLetterConfig_TargetArn;
                    requestDeadLetterConfigIsNull = false;
                }
                 // determine if request.DeadLetterConfig should be set to null
                if (requestDeadLetterConfigIsNull)
                {
                    request.DeadLetterConfig = null;
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                
                 // populate Environment
                var requestEnvironmentIsNull = true;
                request.Environment = new Amazon.Lambda.Model.Environment();
                Dictionary<System.String, System.String> requestEnvironment_environment_Variable = null;
                if (cmdletContext.Environment_Variable != null)
                {
                    requestEnvironment_environment_Variable = cmdletContext.Environment_Variable;
                }
                if (requestEnvironment_environment_Variable != null)
                {
                    request.Environment.Variables = requestEnvironment_environment_Variable;
                    requestEnvironmentIsNull = false;
                }
                System.Boolean? requestEnvironment_environment_IsVariablesSet = null;
                if (cmdletContext.Environment_IsVariablesSet != null)
                {
                    requestEnvironment_environment_IsVariablesSet = cmdletContext.Environment_IsVariablesSet.Value;
                }
                if (requestEnvironment_environment_IsVariablesSet != null)
                {
                    request.Environment.IsVariablesSet = requestEnvironment_environment_IsVariablesSet.Value;
                    requestEnvironmentIsNull = false;
                }
                 // determine if request.Environment should be set to null
                if (requestEnvironmentIsNull)
                {
                    request.Environment = null;
                }
                
                 // populate EphemeralStorage
                var requestEphemeralStorageIsNull = true;
                request.EphemeralStorage = new Amazon.Lambda.Model.EphemeralStorage();
                System.Int32? requestEphemeralStorage_ephemeralStorage_Size = null;
                if (cmdletContext.EphemeralStorage_Size != null)
                {
                    requestEphemeralStorage_ephemeralStorage_Size = cmdletContext.EphemeralStorage_Size.Value;
                }
                if (requestEphemeralStorage_ephemeralStorage_Size != null)
                {
                    request.EphemeralStorage.Size = requestEphemeralStorage_ephemeralStorage_Size.Value;
                    requestEphemeralStorageIsNull = false;
                }
                 // determine if request.EphemeralStorage should be set to null
                if (requestEphemeralStorageIsNull)
                {
                    request.EphemeralStorage = null;
                }
                if (cmdletContext.FileSystemConfig != null)
                {
                    request.FileSystemConfigs = cmdletContext.FileSystemConfig;
                }
                if (cmdletContext.FunctionName != null)
                {
                    request.FunctionName = cmdletContext.FunctionName;
                }
                if (cmdletContext.Handler != null)
                {
                    request.Handler = cmdletContext.Handler;
                }
                
                 // populate ImageConfig
                var requestImageConfigIsNull = true;
                request.ImageConfig = new Amazon.Lambda.Model.ImageConfig();
                List<System.String> requestImageConfig_imageConfig_Command = null;
                if (cmdletContext.ImageConfig_Command != null)
                {
                    requestImageConfig_imageConfig_Command = cmdletContext.ImageConfig_Command;
                }
                if (requestImageConfig_imageConfig_Command != null)
                {
                    request.ImageConfig.Command = requestImageConfig_imageConfig_Command;
                    requestImageConfigIsNull = false;
                }
                System.Boolean? requestImageConfig_imageConfig_IsCommandSet = null;
                if (cmdletContext.ImageConfig_IsCommandSet != null)
                {
                    requestImageConfig_imageConfig_IsCommandSet = cmdletContext.ImageConfig_IsCommandSet.Value;
                }
                if (requestImageConfig_imageConfig_IsCommandSet != null)
                {
                    request.ImageConfig.IsCommandSet = requestImageConfig_imageConfig_IsCommandSet.Value;
                    requestImageConfigIsNull = false;
                }
                List<System.String> requestImageConfig_imageConfig_EntryPoint = null;
                if (cmdletContext.ImageConfig_EntryPoint != null)
                {
                    requestImageConfig_imageConfig_EntryPoint = cmdletContext.ImageConfig_EntryPoint;
                }
                if (requestImageConfig_imageConfig_EntryPoint != null)
                {
                    request.ImageConfig.EntryPoint = requestImageConfig_imageConfig_EntryPoint;
                    requestImageConfigIsNull = false;
                }
                System.Boolean? requestImageConfig_imageConfig_IsEntryPointSet = null;
                if (cmdletContext.ImageConfig_IsEntryPointSet != null)
                {
                    requestImageConfig_imageConfig_IsEntryPointSet = cmdletContext.ImageConfig_IsEntryPointSet.Value;
                }
                if (requestImageConfig_imageConfig_IsEntryPointSet != null)
                {
                    request.ImageConfig.IsEntryPointSet = requestImageConfig_imageConfig_IsEntryPointSet.Value;
                    requestImageConfigIsNull = false;
                }
                System.String requestImageConfig_imageConfig_WorkingDirectory = null;
                if (cmdletContext.ImageConfig_WorkingDirectory != null)
                {
                    requestImageConfig_imageConfig_WorkingDirectory = cmdletContext.ImageConfig_WorkingDirectory;
                }
                if (requestImageConfig_imageConfig_WorkingDirectory != null)
                {
                    request.ImageConfig.WorkingDirectory = requestImageConfig_imageConfig_WorkingDirectory;
                    requestImageConfigIsNull = false;
                }
                 // determine if request.ImageConfig should be set to null
                if (requestImageConfigIsNull)
                {
                    request.ImageConfig = null;
                }
                if (cmdletContext.KMSKeyArn != null)
                {
                    request.KMSKeyArn = cmdletContext.KMSKeyArn;
                }
                if (cmdletContext.Layer != null)
                {
                    request.Layers = cmdletContext.Layer;
                }
                
                 // populate LoggingConfig
                var requestLoggingConfigIsNull = true;
                request.LoggingConfig = new Amazon.Lambda.Model.LoggingConfig();
                Amazon.Lambda.ApplicationLogLevel requestLoggingConfig_loggingConfig_ApplicationLogLevel = null;
                if (cmdletContext.LoggingConfig_ApplicationLogLevel != null)
                {
                    requestLoggingConfig_loggingConfig_ApplicationLogLevel = cmdletContext.LoggingConfig_ApplicationLogLevel;
                }
                if (requestLoggingConfig_loggingConfig_ApplicationLogLevel != null)
                {
                    request.LoggingConfig.ApplicationLogLevel = requestLoggingConfig_loggingConfig_ApplicationLogLevel;
                    requestLoggingConfigIsNull = false;
                }
                Amazon.Lambda.LogFormat requestLoggingConfig_loggingConfig_LogFormat = null;
                if (cmdletContext.LoggingConfig_LogFormat != null)
                {
                    requestLoggingConfig_loggingConfig_LogFormat = cmdletContext.LoggingConfig_LogFormat;
                }
                if (requestLoggingConfig_loggingConfig_LogFormat != null)
                {
                    request.LoggingConfig.LogFormat = requestLoggingConfig_loggingConfig_LogFormat;
                    requestLoggingConfigIsNull = false;
                }
                System.String requestLoggingConfig_loggingConfig_LogGroup = null;
                if (cmdletContext.LoggingConfig_LogGroup != null)
                {
                    requestLoggingConfig_loggingConfig_LogGroup = cmdletContext.LoggingConfig_LogGroup;
                }
                if (requestLoggingConfig_loggingConfig_LogGroup != null)
                {
                    request.LoggingConfig.LogGroup = requestLoggingConfig_loggingConfig_LogGroup;
                    requestLoggingConfigIsNull = false;
                }
                Amazon.Lambda.SystemLogLevel requestLoggingConfig_loggingConfig_SystemLogLevel = null;
                if (cmdletContext.LoggingConfig_SystemLogLevel != null)
                {
                    requestLoggingConfig_loggingConfig_SystemLogLevel = cmdletContext.LoggingConfig_SystemLogLevel;
                }
                if (requestLoggingConfig_loggingConfig_SystemLogLevel != null)
                {
                    request.LoggingConfig.SystemLogLevel = requestLoggingConfig_loggingConfig_SystemLogLevel;
                    requestLoggingConfigIsNull = false;
                }
                 // determine if request.LoggingConfig should be set to null
                if (requestLoggingConfigIsNull)
                {
                    request.LoggingConfig = null;
                }
                if (cmdletContext.MemorySize != null)
                {
                    request.MemorySize = cmdletContext.MemorySize.Value;
                }
                if (cmdletContext.PackageType != null)
                {
                    request.PackageType = cmdletContext.PackageType;
                }
                if (cmdletContext.PublishVersion != null)
                {
                    request.Publish = cmdletContext.PublishVersion.Value;
                }
                if (cmdletContext.Role != null)
                {
                    request.Role = cmdletContext.Role;
                }
                if (cmdletContext.Runtime != null)
                {
                    request.Runtime = cmdletContext.Runtime;
                }
                
                 // populate SnapStart
                var requestSnapStartIsNull = true;
                request.SnapStart = new Amazon.Lambda.Model.SnapStart();
                Amazon.Lambda.SnapStartApplyOn requestSnapStart_snapStart_ApplyOn = null;
                if (cmdletContext.SnapStart_ApplyOn != null)
                {
                    requestSnapStart_snapStart_ApplyOn = cmdletContext.SnapStart_ApplyOn;
                }
                if (requestSnapStart_snapStart_ApplyOn != null)
                {
                    request.SnapStart.ApplyOn = requestSnapStart_snapStart_ApplyOn;
                    requestSnapStartIsNull = false;
                }
                 // determine if request.SnapStart should be set to null
                if (requestSnapStartIsNull)
                {
                    request.SnapStart = null;
                }
                if (cmdletContext.Tag != null)
                {
                    request.Tags = cmdletContext.Tag;
                }
                if (cmdletContext.Timeout != null)
                {
                    request.Timeout = cmdletContext.Timeout.Value;
                }
                
                 // populate TracingConfig
                var requestTracingConfigIsNull = true;
                request.TracingConfig = new Amazon.Lambda.Model.TracingConfig();
                Amazon.Lambda.TracingMode requestTracingConfig_tracingConfig_Mode = null;
                if (cmdletContext.TracingConfig_Mode != null)
                {
                    requestTracingConfig_tracingConfig_Mode = cmdletContext.TracingConfig_Mode;
                }
                if (requestTracingConfig_tracingConfig_Mode != null)
                {
                    request.TracingConfig.Mode = requestTracingConfig_tracingConfig_Mode;
                    requestTracingConfigIsNull = false;
                }
                 // determine if request.TracingConfig should be set to null
                if (requestTracingConfigIsNull)
                {
                    request.TracingConfig = null;
                }
                
                 // populate VpcConfig
                var requestVpcConfigIsNull = true;
                request.VpcConfig = new Amazon.Lambda.Model.VpcConfig();
                System.Boolean? requestVpcConfig_vpcConfig_Ipv6AllowedForDualStack = null;
                if (cmdletContext.VpcConfig_Ipv6AllowedForDualStack != null)
                {
                    requestVpcConfig_vpcConfig_Ipv6AllowedForDualStack = cmdletContext.VpcConfig_Ipv6AllowedForDualStack.Value;
                }
                if (requestVpcConfig_vpcConfig_Ipv6AllowedForDualStack != null)
                {
                    request.VpcConfig.Ipv6AllowedForDualStack = requestVpcConfig_vpcConfig_Ipv6AllowedForDualStack.Value;
                    requestVpcConfigIsNull = false;
                }
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
                System.Boolean? requestVpcConfig_vpcConfig_IsSecurityGroupIdsSet = null;
                if (cmdletContext.VpcConfig_IsSecurityGroupIdsSet != null)
                {
                    requestVpcConfig_vpcConfig_IsSecurityGroupIdsSet = cmdletContext.VpcConfig_IsSecurityGroupIdsSet.Value;
                }
                if (requestVpcConfig_vpcConfig_IsSecurityGroupIdsSet != null)
                {
                    request.VpcConfig.IsSecurityGroupIdsSet = requestVpcConfig_vpcConfig_IsSecurityGroupIdsSet.Value;
                    requestVpcConfigIsNull = false;
                }
                List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
                if (cmdletContext.VpcConfig_SubnetId != null)
                {
                    requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetId;
                }
                if (requestVpcConfig_vpcConfig_SubnetId != null)
                {
                    request.VpcConfig.SubnetIds = requestVpcConfig_vpcConfig_SubnetId;
                    requestVpcConfigIsNull = false;
                }
                System.Boolean? requestVpcConfig_vpcConfig_IsSubnetIdsSet = null;
                if (cmdletContext.VpcConfig_IsSubnetIdsSet != null)
                {
                    requestVpcConfig_vpcConfig_IsSubnetIdsSet = cmdletContext.VpcConfig_IsSubnetIdsSet.Value;
                }
                if (requestVpcConfig_vpcConfig_IsSubnetIdsSet != null)
                {
                    request.VpcConfig.IsSubnetIdsSet = requestVpcConfig_vpcConfig_IsSubnetIdsSet.Value;
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
            finally
            {
                if( _Code_ZipFileStream != null)
                {
                    _Code_ZipFileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lambda.Model.CreateFunctionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.CreateFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "CreateFunction");
            try
            {
                #if DESKTOP
                return client.CreateFunction(request);
                #elif CORECLR
                return client.CreateFunctionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Architecture { get; set; }
            public System.String Code_ImageUri { get; set; }
            public System.String Code_S3Bucket { get; set; }
            public System.String Code_S3Key { get; set; }
            public System.String Code_S3ObjectVersion { get; set; }
            public byte[] Code_ZipFile { get; set; }
            public System.String CodeSigningConfigArn { get; set; }
            public System.String DeadLetterConfig_TargetArn { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> Environment_Variable { get; set; }
            public System.Boolean? Environment_IsVariablesSet { get; set; }
            public System.Int32? EphemeralStorage_Size { get; set; }
            public List<Amazon.Lambda.Model.FileSystemConfig> FileSystemConfig { get; set; }
            public System.String FunctionName { get; set; }
            public System.String Handler { get; set; }
            public List<System.String> ImageConfig_Command { get; set; }
            public System.Boolean? ImageConfig_IsCommandSet { get; set; }
            public List<System.String> ImageConfig_EntryPoint { get; set; }
            public System.Boolean? ImageConfig_IsEntryPointSet { get; set; }
            public System.String ImageConfig_WorkingDirectory { get; set; }
            public System.String KMSKeyArn { get; set; }
            public List<System.String> Layer { get; set; }
            public Amazon.Lambda.ApplicationLogLevel LoggingConfig_ApplicationLogLevel { get; set; }
            public Amazon.Lambda.LogFormat LoggingConfig_LogFormat { get; set; }
            public System.String LoggingConfig_LogGroup { get; set; }
            public Amazon.Lambda.SystemLogLevel LoggingConfig_SystemLogLevel { get; set; }
            public System.Int32? MemorySize { get; set; }
            public Amazon.Lambda.PackageType PackageType { get; set; }
            public System.Boolean? PublishVersion { get; set; }
            public System.String Role { get; set; }
            public Amazon.Lambda.Runtime Runtime { get; set; }
            public Amazon.Lambda.SnapStartApplyOn SnapStart_ApplyOn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? Timeout { get; set; }
            public Amazon.Lambda.TracingMode TracingConfig_Mode { get; set; }
            public System.Boolean? VpcConfig_Ipv6AllowedForDualStack { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public System.Boolean? VpcConfig_IsSecurityGroupIdsSet { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Boolean? VpcConfig_IsSubnetIdsSet { get; set; }
            public System.Func<Amazon.Lambda.Model.CreateFunctionResponse, PublishLMFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
