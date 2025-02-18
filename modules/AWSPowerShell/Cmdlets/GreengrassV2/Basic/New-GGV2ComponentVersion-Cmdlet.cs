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
using System.Threading;
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Creates a component. Components are software that run on Greengrass core devices.
    /// After you develop and test a component on your core device, you can use this operation
    /// to upload your component to IoT Greengrass. Then, you can deploy the component to
    /// other core devices.
    /// 
    ///  
    /// <para>
    /// You can use this operation to do the following:
    /// </para><ul><li><para><b>Create components from recipes</b></para><para>
    /// Create a component from a recipe, which is a file that defines the component's metadata,
    /// parameters, dependencies, lifecycle, artifacts, and platform capability. For more
    /// information, see <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/component-recipe-reference.html">IoT
    /// Greengrass component recipe reference</a> in the <i>IoT Greengrass V2 Developer Guide</i>.
    /// </para><para>
    /// To create a component from a recipe, specify <c>inlineRecipe</c> when you call this
    /// operation.
    /// </para></li><li><para><b>Create components from Lambda functions</b></para><para>
    /// Create a component from an Lambda function that runs on IoT Greengrass. This creates
    /// a recipe and artifacts from the Lambda function's deployment package. You can use
    /// this operation to migrate Lambda functions from IoT Greengrass V1 to IoT Greengrass
    /// V2.
    /// </para><para>
    /// This function accepts Lambda functions in all supported versions of Python, Node.js,
    /// and Java runtimes. IoT Greengrass doesn't apply any additional restrictions on deprecated
    /// Lambda runtime versions.
    /// </para><para>
    /// To create a component from a Lambda function, specify <c>lambdaFunction</c> when you
    /// call this operation.
    /// </para><note><para>
    /// IoT Greengrass currently supports Lambda functions on only Linux core devices.
    /// </para></note></li></ul>
    /// </summary>
    [Cmdlet("New", "GGV2ComponentVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GreengrassV2.Model.CreateComponentVersionResponse")]
    [AWSCmdlet("Calls the AWS GreengrassV2 CreateComponentVersion API operation.", Operation = new[] {"CreateComponentVersion"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.CreateComponentVersionResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.CreateComponentVersionResponse",
        "This cmdlet returns an Amazon.GreengrassV2.Model.CreateComponentVersionResponse object containing multiple properties."
    )]
    public partial class NewGGV2ComponentVersionCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LambdaFunction_ComponentDependency
        /// <summary>
        /// <para>
        /// <para>The component versions on which this Lambda function component depends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentDependencies")]
        public System.Collections.Hashtable LambdaFunction_ComponentDependency { get; set; }
        #endregion
        
        #region Parameter LambdaFunction_ComponentName
        /// <summary>
        /// <para>
        /// <para>The name of the component.</para><para>Defaults to the name of the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaFunction_ComponentName { get; set; }
        #endregion
        
        #region Parameter LambdaFunction_ComponentPlatform
        /// <summary>
        /// <para>
        /// <para>The platforms that the component version supports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentPlatforms")]
        public Amazon.GreengrassV2.Model.ComponentPlatform[] LambdaFunction_ComponentPlatform { get; set; }
        #endregion
        
        #region Parameter LambdaFunction_ComponentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the component.</para><para>Defaults to the version of the Lambda function as a semantic version. For example,
        /// if your function version is <c>3</c>, the component version becomes <c>3.0.0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaFunction_ComponentVersion { get; set; }
        #endregion
        
        #region Parameter ContainerParams_Device
        /// <summary>
        /// <para>
        /// <para>The list of system devices that the container can access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_Devices")]
        public Amazon.GreengrassV2.Model.LambdaDeviceMount[] ContainerParams_Device { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>The map of environment variables that are available to the Lambda function when it
        /// runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_EnvironmentVariables")]
        public System.Collections.Hashtable ComponentLambdaParameters_EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_EventSource
        /// <summary>
        /// <para>
        /// <para>The list of event sources to which to subscribe to receive work messages. The Lambda
        /// function runs when it receives a message from an event source. You can subscribe this
        /// function to local publish/subscribe messages and Amazon Web Services IoT Core MQTT
        /// messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_EventSources")]
        public Amazon.GreengrassV2.Model.LambdaEventSource[] ComponentLambdaParameters_EventSource { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_ExecArg
        /// <summary>
        /// <para>
        /// <para>The list of arguments to pass to the Lambda function when it runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_ExecArgs")]
        public System.String[] ComponentLambdaParameters_ExecArg { get; set; }
        #endregion
        
        #region Parameter InlineRecipe
        /// <summary>
        /// <para>
        /// <para>The recipe to use to create the component. The recipe defines the component's metadata,
        /// parameters, dependencies, lifecycle, artifacts, and platform compatibility.</para><para>You must specify either <c>inlineRecipe</c> or <c>lambdaFunction</c>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] InlineRecipe { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_InputPayloadEncodingType
        /// <summary>
        /// <para>
        /// <para>The encoding type that the Lambda function supports.</para><para>Default: <c>json</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_InputPayloadEncodingType")]
        [AWSConstantClassSource("Amazon.GreengrassV2.LambdaInputPayloadEncodingType")]
        public Amazon.GreengrassV2.LambdaInputPayloadEncodingType ComponentLambdaParameters_InputPayloadEncodingType { get; set; }
        #endregion
        
        #region Parameter LinuxProcessParams_IsolationMode
        /// <summary>
        /// <para>
        /// <para>The isolation mode for the process that contains the Lambda function. The process
        /// can run in an isolated runtime environment inside the IoT Greengrass container, or
        /// as a regular process outside any container.</para><para>Default: <c>GreengrassContainer</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_LinuxProcessParams_IsolationMode")]
        [AWSConstantClassSource("Amazon.GreengrassV2.LambdaIsolationMode")]
        public Amazon.GreengrassV2.LambdaIsolationMode LinuxProcessParams_IsolationMode { get; set; }
        #endregion
        
        #region Parameter LambdaFunction_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the Lambda function. The ARN must include the version of the function to import.
        /// You can't use version aliases like <c>$LATEST</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaFunction_LambdaArn { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_MaxIdleTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time in seconds that a non-pinned Lambda function can idle before
        /// the IoT Greengrass Core software stops its process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_MaxIdleTimeInSeconds")]
        public System.Int32? ComponentLambdaParameters_MaxIdleTimeInSecond { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_MaxInstancesCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances that a non-pinned Lambda function can run at the same
        /// time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_MaxInstancesCount")]
        public System.Int32? ComponentLambdaParameters_MaxInstancesCount { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_MaxQueueSize
        /// <summary>
        /// <para>
        /// <para>The maximum size of the message queue for the Lambda function component. The IoT Greengrass
        /// core stores messages in a FIFO (first-in-first-out) queue until it can run the Lambda
        /// function to consume each message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_MaxQueueSize")]
        public System.Int32? ComponentLambdaParameters_MaxQueueSize { get; set; }
        #endregion
        
        #region Parameter ContainerParams_MemorySizeInKB
        /// <summary>
        /// <para>
        /// <para>The memory size of the container, expressed in kilobytes.</para><para>Default: <c>16384</c> (16 MB)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_MemorySizeInKB")]
        public System.Int32? ContainerParams_MemorySizeInKB { get; set; }
        #endregion
        
        #region Parameter ContainerParams_MountROSysf
        /// <summary>
        /// <para>
        /// <para>Whether or not the container can read information from the device's <c>/sys</c> folder.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_MountROSysfs")]
        public System.Boolean? ContainerParams_MountROSysf { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_Pinned
        /// <summary>
        /// <para>
        /// <para>Whether or not the Lambda function is pinned, or long-lived.</para><ul><li><para>A pinned Lambda function starts when IoT Greengrass starts and keeps running in its
        /// own container.</para></li><li><para>A non-pinned Lambda function starts only when it receives a work item and exists after
        /// it idles for <c>maxIdleTimeInSeconds</c>. If the function has multiple work items,
        /// the IoT Greengrass Core software creates multiple instances of the function.</para></li></ul><para>Default: <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_Pinned")]
        public System.Boolean? ComponentLambdaParameters_Pinned { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_StatusTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The interval in seconds at which a pinned (also known as long-lived) Lambda function
        /// component sends status updates to the Lambda manager component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_StatusTimeoutInSeconds")]
        public System.Int32? ComponentLambdaParameters_StatusTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that contain metadata for the resource. For more information,
        /// see <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/tag-resources.html">Tag
        /// your resources</a> in the <i>IoT Greengrass V2 Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ComponentLambdaParameters_TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time in seconds that the Lambda function can process a work
        /// item.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_TimeoutInSeconds")]
        public System.Int32? ComponentLambdaParameters_TimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter ContainerParams_Volume
        /// <summary>
        /// <para>
        /// <para>The list of volumes that the container can access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_Volumes")]
        public Amazon.GreengrassV2.Model.LambdaVolumeMount[] ContainerParams_Volume { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you can provide to ensure that the request
        /// is idempotent. Idempotency means that the request is successfully processed only once,
        /// even if you send the request multiple times. When a request succeeds, and you specify
        /// the same client token for subsequent successful requests, the IoT Greengrass V2 service
        /// returns the successful response that it caches from the previous request. IoT Greengrass
        /// V2 caches successful responses for idempotent requests for up to 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.CreateComponentVersionResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.CreateComponentVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGV2ComponentVersion (CreateComponentVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.CreateComponentVersionResponse, NewGGV2ComponentVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.InlineRecipe = this.InlineRecipe;
            if (this.LambdaFunction_ComponentDependency != null)
            {
                context.LambdaFunction_ComponentDependency = new Dictionary<System.String, Amazon.GreengrassV2.Model.ComponentDependencyRequirement>(StringComparer.Ordinal);
                foreach (var hashKey in this.LambdaFunction_ComponentDependency.Keys)
                {
                    context.LambdaFunction_ComponentDependency.Add((String)hashKey, (Amazon.GreengrassV2.Model.ComponentDependencyRequirement)(this.LambdaFunction_ComponentDependency[hashKey]));
                }
            }
            if (this.ComponentLambdaParameters_EnvironmentVariable != null)
            {
                context.ComponentLambdaParameters_EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComponentLambdaParameters_EnvironmentVariable.Keys)
                {
                    context.ComponentLambdaParameters_EnvironmentVariable.Add((String)hashKey, (System.String)(this.ComponentLambdaParameters_EnvironmentVariable[hashKey]));
                }
            }
            if (this.ComponentLambdaParameters_EventSource != null)
            {
                context.ComponentLambdaParameters_EventSource = new List<Amazon.GreengrassV2.Model.LambdaEventSource>(this.ComponentLambdaParameters_EventSource);
            }
            if (this.ComponentLambdaParameters_ExecArg != null)
            {
                context.ComponentLambdaParameters_ExecArg = new List<System.String>(this.ComponentLambdaParameters_ExecArg);
            }
            context.ComponentLambdaParameters_InputPayloadEncodingType = this.ComponentLambdaParameters_InputPayloadEncodingType;
            if (this.ContainerParams_Device != null)
            {
                context.ContainerParams_Device = new List<Amazon.GreengrassV2.Model.LambdaDeviceMount>(this.ContainerParams_Device);
            }
            context.ContainerParams_MemorySizeInKB = this.ContainerParams_MemorySizeInKB;
            context.ContainerParams_MountROSysf = this.ContainerParams_MountROSysf;
            if (this.ContainerParams_Volume != null)
            {
                context.ContainerParams_Volume = new List<Amazon.GreengrassV2.Model.LambdaVolumeMount>(this.ContainerParams_Volume);
            }
            context.LinuxProcessParams_IsolationMode = this.LinuxProcessParams_IsolationMode;
            context.ComponentLambdaParameters_MaxIdleTimeInSecond = this.ComponentLambdaParameters_MaxIdleTimeInSecond;
            context.ComponentLambdaParameters_MaxInstancesCount = this.ComponentLambdaParameters_MaxInstancesCount;
            context.ComponentLambdaParameters_MaxQueueSize = this.ComponentLambdaParameters_MaxQueueSize;
            context.ComponentLambdaParameters_Pinned = this.ComponentLambdaParameters_Pinned;
            context.ComponentLambdaParameters_StatusTimeoutInSecond = this.ComponentLambdaParameters_StatusTimeoutInSecond;
            context.ComponentLambdaParameters_TimeoutInSecond = this.ComponentLambdaParameters_TimeoutInSecond;
            context.LambdaFunction_ComponentName = this.LambdaFunction_ComponentName;
            if (this.LambdaFunction_ComponentPlatform != null)
            {
                context.LambdaFunction_ComponentPlatform = new List<Amazon.GreengrassV2.Model.ComponentPlatform>(this.LambdaFunction_ComponentPlatform);
            }
            context.LambdaFunction_ComponentVersion = this.LambdaFunction_ComponentVersion;
            context.LambdaFunction_LambdaArn = this.LambdaFunction_LambdaArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _InlineRecipeStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.GreengrassV2.Model.CreateComponentVersionRequest();
                
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                if (cmdletContext.InlineRecipe != null)
                {
                    _InlineRecipeStream = new System.IO.MemoryStream(cmdletContext.InlineRecipe);
                    request.InlineRecipe = _InlineRecipeStream;
                }
                
                 // populate LambdaFunction
                var requestLambdaFunctionIsNull = true;
                request.LambdaFunction = new Amazon.GreengrassV2.Model.LambdaFunctionRecipeSource();
                Dictionary<System.String, Amazon.GreengrassV2.Model.ComponentDependencyRequirement> requestLambdaFunction_lambdaFunction_ComponentDependency = null;
                if (cmdletContext.LambdaFunction_ComponentDependency != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentDependency = cmdletContext.LambdaFunction_ComponentDependency;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentDependency != null)
                {
                    request.LambdaFunction.ComponentDependencies = requestLambdaFunction_lambdaFunction_ComponentDependency;
                    requestLambdaFunctionIsNull = false;
                }
                System.String requestLambdaFunction_lambdaFunction_ComponentName = null;
                if (cmdletContext.LambdaFunction_ComponentName != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentName = cmdletContext.LambdaFunction_ComponentName;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentName != null)
                {
                    request.LambdaFunction.ComponentName = requestLambdaFunction_lambdaFunction_ComponentName;
                    requestLambdaFunctionIsNull = false;
                }
                List<Amazon.GreengrassV2.Model.ComponentPlatform> requestLambdaFunction_lambdaFunction_ComponentPlatform = null;
                if (cmdletContext.LambdaFunction_ComponentPlatform != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentPlatform = cmdletContext.LambdaFunction_ComponentPlatform;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentPlatform != null)
                {
                    request.LambdaFunction.ComponentPlatforms = requestLambdaFunction_lambdaFunction_ComponentPlatform;
                    requestLambdaFunctionIsNull = false;
                }
                System.String requestLambdaFunction_lambdaFunction_ComponentVersion = null;
                if (cmdletContext.LambdaFunction_ComponentVersion != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentVersion = cmdletContext.LambdaFunction_ComponentVersion;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentVersion != null)
                {
                    request.LambdaFunction.ComponentVersion = requestLambdaFunction_lambdaFunction_ComponentVersion;
                    requestLambdaFunctionIsNull = false;
                }
                System.String requestLambdaFunction_lambdaFunction_LambdaArn = null;
                if (cmdletContext.LambdaFunction_LambdaArn != null)
                {
                    requestLambdaFunction_lambdaFunction_LambdaArn = cmdletContext.LambdaFunction_LambdaArn;
                }
                if (requestLambdaFunction_lambdaFunction_LambdaArn != null)
                {
                    request.LambdaFunction.LambdaArn = requestLambdaFunction_lambdaFunction_LambdaArn;
                    requestLambdaFunctionIsNull = false;
                }
                Amazon.GreengrassV2.Model.LambdaExecutionParameters requestLambdaFunction_lambdaFunction_ComponentLambdaParameters = null;
                
                 // populate ComponentLambdaParameters
                var requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = true;
                requestLambdaFunction_lambdaFunction_ComponentLambdaParameters = new Amazon.GreengrassV2.Model.LambdaExecutionParameters();
                Dictionary<System.String, System.String> requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_EnvironmentVariable = null;
                if (cmdletContext.ComponentLambdaParameters_EnvironmentVariable != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_EnvironmentVariable = cmdletContext.ComponentLambdaParameters_EnvironmentVariable;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_EnvironmentVariable != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.EnvironmentVariables = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_EnvironmentVariable;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                List<Amazon.GreengrassV2.Model.LambdaEventSource> requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_EventSource = null;
                if (cmdletContext.ComponentLambdaParameters_EventSource != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_EventSource = cmdletContext.ComponentLambdaParameters_EventSource;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_EventSource != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.EventSources = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_EventSource;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                List<System.String> requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_ExecArg = null;
                if (cmdletContext.ComponentLambdaParameters_ExecArg != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_ExecArg = cmdletContext.ComponentLambdaParameters_ExecArg;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_ExecArg != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.ExecArgs = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_ExecArg;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                Amazon.GreengrassV2.LambdaInputPayloadEncodingType requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_InputPayloadEncodingType = null;
                if (cmdletContext.ComponentLambdaParameters_InputPayloadEncodingType != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_InputPayloadEncodingType = cmdletContext.ComponentLambdaParameters_InputPayloadEncodingType;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_InputPayloadEncodingType != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.InputPayloadEncodingType = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_InputPayloadEncodingType;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                System.Int32? requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxIdleTimeInSecond = null;
                if (cmdletContext.ComponentLambdaParameters_MaxIdleTimeInSecond != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxIdleTimeInSecond = cmdletContext.ComponentLambdaParameters_MaxIdleTimeInSecond.Value;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxIdleTimeInSecond != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.MaxIdleTimeInSeconds = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxIdleTimeInSecond.Value;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                System.Int32? requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxInstancesCount = null;
                if (cmdletContext.ComponentLambdaParameters_MaxInstancesCount != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxInstancesCount = cmdletContext.ComponentLambdaParameters_MaxInstancesCount.Value;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxInstancesCount != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.MaxInstancesCount = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxInstancesCount.Value;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                System.Int32? requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxQueueSize = null;
                if (cmdletContext.ComponentLambdaParameters_MaxQueueSize != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxQueueSize = cmdletContext.ComponentLambdaParameters_MaxQueueSize.Value;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxQueueSize != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.MaxQueueSize = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_MaxQueueSize.Value;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                System.Boolean? requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_Pinned = null;
                if (cmdletContext.ComponentLambdaParameters_Pinned != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_Pinned = cmdletContext.ComponentLambdaParameters_Pinned.Value;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_Pinned != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.Pinned = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_Pinned.Value;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                System.Int32? requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_StatusTimeoutInSecond = null;
                if (cmdletContext.ComponentLambdaParameters_StatusTimeoutInSecond != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_StatusTimeoutInSecond = cmdletContext.ComponentLambdaParameters_StatusTimeoutInSecond.Value;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_StatusTimeoutInSecond != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.StatusTimeoutInSeconds = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_StatusTimeoutInSecond.Value;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                System.Int32? requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_TimeoutInSecond = null;
                if (cmdletContext.ComponentLambdaParameters_TimeoutInSecond != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_TimeoutInSecond = cmdletContext.ComponentLambdaParameters_TimeoutInSecond.Value;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_TimeoutInSecond != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.TimeoutInSeconds = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_componentLambdaParameters_TimeoutInSecond.Value;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                Amazon.GreengrassV2.Model.LambdaLinuxProcessParams requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams = null;
                
                 // populate LinuxProcessParams
                var requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParamsIsNull = true;
                requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams = new Amazon.GreengrassV2.Model.LambdaLinuxProcessParams();
                Amazon.GreengrassV2.LambdaIsolationMode requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_linuxProcessParams_IsolationMode = null;
                if (cmdletContext.LinuxProcessParams_IsolationMode != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_linuxProcessParams_IsolationMode = cmdletContext.LinuxProcessParams_IsolationMode;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_linuxProcessParams_IsolationMode != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams.IsolationMode = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_linuxProcessParams_IsolationMode;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParamsIsNull = false;
                }
                Amazon.GreengrassV2.Model.LambdaContainerParams requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams = null;
                
                 // populate ContainerParams
                var requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParamsIsNull = true;
                requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams = new Amazon.GreengrassV2.Model.LambdaContainerParams();
                List<Amazon.GreengrassV2.Model.LambdaDeviceMount> requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_Device = null;
                if (cmdletContext.ContainerParams_Device != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_Device = cmdletContext.ContainerParams_Device;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_Device != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams.Devices = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_Device;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParamsIsNull = false;
                }
                System.Int32? requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_MemorySizeInKB = null;
                if (cmdletContext.ContainerParams_MemorySizeInKB != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_MemorySizeInKB = cmdletContext.ContainerParams_MemorySizeInKB.Value;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_MemorySizeInKB != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams.MemorySizeInKB = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_MemorySizeInKB.Value;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParamsIsNull = false;
                }
                System.Boolean? requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_MountROSysf = null;
                if (cmdletContext.ContainerParams_MountROSysf != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_MountROSysf = cmdletContext.ContainerParams_MountROSysf.Value;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_MountROSysf != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams.MountROSysfs = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_MountROSysf.Value;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParamsIsNull = false;
                }
                List<Amazon.GreengrassV2.Model.LambdaVolumeMount> requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_Volume = null;
                if (cmdletContext.ContainerParams_Volume != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_Volume = cmdletContext.ContainerParams_Volume;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_Volume != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams.Volumes = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams_containerParams_Volume;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParamsIsNull = false;
                }
                 // determine if requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams should be set to null
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParamsIsNull)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams = null;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams.ContainerParams = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams_ContainerParams;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParamsIsNull = false;
                }
                 // determine if requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams should be set to null
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParamsIsNull)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams = null;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams != null)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters.LinuxProcessParams = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters_lambdaFunction_ComponentLambdaParameters_LinuxProcessParams;
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull = false;
                }
                 // determine if requestLambdaFunction_lambdaFunction_ComponentLambdaParameters should be set to null
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParametersIsNull)
                {
                    requestLambdaFunction_lambdaFunction_ComponentLambdaParameters = null;
                }
                if (requestLambdaFunction_lambdaFunction_ComponentLambdaParameters != null)
                {
                    request.LambdaFunction.ComponentLambdaParameters = requestLambdaFunction_lambdaFunction_ComponentLambdaParameters;
                    requestLambdaFunctionIsNull = false;
                }
                 // determine if request.LambdaFunction should be set to null
                if (requestLambdaFunctionIsNull)
                {
                    request.LambdaFunction = null;
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
            finally
            {
                if( _InlineRecipeStream != null)
                {
                    _InlineRecipeStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.GreengrassV2.Model.CreateComponentVersionResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.CreateComponentVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "CreateComponentVersion");
            try
            {
                return client.CreateComponentVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] InlineRecipe { get; set; }
            public Dictionary<System.String, Amazon.GreengrassV2.Model.ComponentDependencyRequirement> LambdaFunction_ComponentDependency { get; set; }
            public Dictionary<System.String, System.String> ComponentLambdaParameters_EnvironmentVariable { get; set; }
            public List<Amazon.GreengrassV2.Model.LambdaEventSource> ComponentLambdaParameters_EventSource { get; set; }
            public List<System.String> ComponentLambdaParameters_ExecArg { get; set; }
            public Amazon.GreengrassV2.LambdaInputPayloadEncodingType ComponentLambdaParameters_InputPayloadEncodingType { get; set; }
            public List<Amazon.GreengrassV2.Model.LambdaDeviceMount> ContainerParams_Device { get; set; }
            public System.Int32? ContainerParams_MemorySizeInKB { get; set; }
            public System.Boolean? ContainerParams_MountROSysf { get; set; }
            public List<Amazon.GreengrassV2.Model.LambdaVolumeMount> ContainerParams_Volume { get; set; }
            public Amazon.GreengrassV2.LambdaIsolationMode LinuxProcessParams_IsolationMode { get; set; }
            public System.Int32? ComponentLambdaParameters_MaxIdleTimeInSecond { get; set; }
            public System.Int32? ComponentLambdaParameters_MaxInstancesCount { get; set; }
            public System.Int32? ComponentLambdaParameters_MaxQueueSize { get; set; }
            public System.Boolean? ComponentLambdaParameters_Pinned { get; set; }
            public System.Int32? ComponentLambdaParameters_StatusTimeoutInSecond { get; set; }
            public System.Int32? ComponentLambdaParameters_TimeoutInSecond { get; set; }
            public System.String LambdaFunction_ComponentName { get; set; }
            public List<Amazon.GreengrassV2.Model.ComponentPlatform> LambdaFunction_ComponentPlatform { get; set; }
            public System.String LambdaFunction_ComponentVersion { get; set; }
            public System.String LambdaFunction_LambdaArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.CreateComponentVersionResponse, NewGGV2ComponentVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
