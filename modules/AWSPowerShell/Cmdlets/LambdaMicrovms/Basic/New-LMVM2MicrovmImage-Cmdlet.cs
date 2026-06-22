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
using Amazon.LambdaMicrovms;
using Amazon.LambdaMicrovms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMVM2
{
    /// <summary>
    /// Creates a MicroVM image from the specified code artifact and base image. The build
    /// is asynchronous — the image transitions from CREATING to CREATED on success, or CREATE_FAILED
    /// on failure. Use GetMicrovmImage to poll for completion.
    /// </summary>
    [Cmdlet("New", "LMVM2MicrovmImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LambdaMicrovms.Model.CreateMicrovmImageResponse")]
    [AWSCmdlet("Calls the Lambda MicroVMs CreateMicrovmImage API operation.", Operation = new[] {"CreateMicrovmImage"}, SelectReturnType = typeof(Amazon.LambdaMicrovms.Model.CreateMicrovmImageResponse))]
    [AWSCmdletOutput("Amazon.LambdaMicrovms.Model.CreateMicrovmImageResponse",
        "This cmdlet returns an Amazon.LambdaMicrovms.Model.CreateMicrovmImageResponse object containing multiple properties."
    )]
    public partial class NewLMVM2MicrovmImageCmdlet : AmazonLambdaMicrovmsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalOsCapability
        /// <summary>
        /// <para>
        /// <para>Additional OS capabilities granted to the MicroVM runtime environment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalOsCapabilities")]
        public System.String[] AdditionalOsCapability { get; set; }
        #endregion
        
        #region Parameter BaseImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda-managed base MicroVM image to build upon. Use ListManagedMicrovmImages
        /// to discover available base images.</para>
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
        public System.String BaseImageArn { get; set; }
        #endregion
        
        #region Parameter BaseImageVersion
        /// <summary>
        /// <para>
        /// <para>The specific version of the base MicroVM image to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BaseImageVersion { get; set; }
        #endregion
        
        #region Parameter BuildRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed during the image build process. This role must have
        /// permissions to access the code artifact and any required resources.</para>
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
        public System.String BuildRoleArn { get; set; }
        #endregion
        
        #region Parameter CpuConfiguration
        /// <summary>
        /// <para>
        /// <para>The list of supported CPU configurations for the MicroVM.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CpuConfigurations")]
        public Amazon.LambdaMicrovms.Model.CpuConfiguration[] CpuConfiguration { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the MicroVM image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Logging_Disabled
        /// <summary>
        /// <para>
        /// <para>Specifies that logging is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LambdaMicrovms.Model.LoggingDisabled Logging_Disabled { get; set; }
        #endregion
        
        #region Parameter EgressNetworkConnector
        /// <summary>
        /// <para>
        /// <para>The list of egress network connectors available to the MicroVM at runtime.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EgressNetworkConnectors")]
        public System.String[] EgressNetworkConnector { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>Environment variables set in the MicroVM runtime environment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter Logging_CloudWatch_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log group to send logs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Logging_CloudWatch_LogGroup { get; set; }
        #endregion
        
        #region Parameter Logging_CloudWatch_LogStream
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log stream within the log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Logging_CloudWatch_LogStream { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the MicroVM image. Must be unique within the AWS account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Hooks_Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the hooks listener runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Hooks_Port { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmImageHooks_Ready
        /// <summary>
        /// <para>
        /// <para>The path of the hook invoked when the MicroVM image build is ready.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaMicrovms.HookState")]
        public Amazon.LambdaMicrovms.HookState Hooks_MicrovmImageHooks_Ready { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmImageHooks_ReadyTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds for the ready hook to complete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Hooks_MicrovmImageHooks_ReadyTimeoutInSeconds")]
        public System.Int32? Hooks_MicrovmImageHooks_ReadyTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The resource requirements for the MicroVM.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resources")]
        public Amazon.LambdaMicrovms.Model.Resources[] Resource { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmHooks_Resume
        /// <summary>
        /// <para>
        /// <para>The path of the hook invoked when the MicroVM resumes from a suspended state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaMicrovms.HookState")]
        public Amazon.LambdaMicrovms.HookState Hooks_MicrovmHooks_Resume { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmHooks_ResumeTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds for the resume hook to complete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Hooks_MicrovmHooks_ResumeTimeoutInSeconds")]
        public System.Int32? Hooks_MicrovmHooks_ResumeTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmHooks_Run
        /// <summary>
        /// <para>
        /// <para>The path of the hook invoked when the MicroVM starts running.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaMicrovms.HookState")]
        public Amazon.LambdaMicrovms.HookState Hooks_MicrovmHooks_Run { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmHooks_RunTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds for the run hook to complete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Hooks_MicrovmHooks_RunTimeoutInSeconds")]
        public System.Int32? Hooks_MicrovmHooks_RunTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmHooks_Suspend
        /// <summary>
        /// <para>
        /// <para>The path of the hook invoked when the MicroVM is suspended.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaMicrovms.HookState")]
        public Amazon.LambdaMicrovms.HookState Hooks_MicrovmHooks_Suspend { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmHooks_SuspendTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds for the suspend hook to complete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Hooks_MicrovmHooks_SuspendTimeoutInSeconds")]
        public System.Int32? Hooks_MicrovmHooks_SuspendTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs that you can attach to the resource. Use tags to categorize
        /// resources for cost allocation, access control (ABAC), and organization.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmHooks_Terminate
        /// <summary>
        /// <para>
        /// <para>The path of the hook invoked when the MicroVM is terminated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaMicrovms.HookState")]
        public Amazon.LambdaMicrovms.HookState Hooks_MicrovmHooks_Terminate { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmHooks_TerminateTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds for the terminate hook to complete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Hooks_MicrovmHooks_TerminateTimeoutInSeconds")]
        public System.Int32? Hooks_MicrovmHooks_TerminateTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter CodeArtifact_Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the code artifact, such as an Amazon S3 path or Amazon ECR image URI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CodeArtifact_Uri { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmImageHooks_Validate
        /// <summary>
        /// <para>
        /// <para>The path of the hook invoked to validate the MicroVM image build.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaMicrovms.HookState")]
        public Amazon.LambdaMicrovms.HookState Hooks_MicrovmImageHooks_Validate { get; set; }
        #endregion
        
        #region Parameter Hooks_MicrovmImageHooks_ValidateTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds for the validate hook to complete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Hooks_MicrovmImageHooks_ValidateTimeoutInSeconds")]
        public System.Int32? Hooks_MicrovmImageHooks_ValidateTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// If you retry a request that completed successfully using the same client token, the
        /// operation returns the successful response without performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaMicrovms.Model.CreateMicrovmImageResponse).
        /// Specifying the name of a property of type Amazon.LambdaMicrovms.Model.CreateMicrovmImageResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.BaseImageArn),
                nameof(this.BuildRoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMVM2MicrovmImage (CreateMicrovmImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaMicrovms.Model.CreateMicrovmImageResponse, NewLMVM2MicrovmImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalOsCapability != null)
            {
                context.AdditionalOsCapability = new List<System.String>(this.AdditionalOsCapability);
            }
            context.BaseImageArn = this.BaseImageArn;
            #if MODULAR
            if (this.BaseImageArn == null && ParameterWasBound(nameof(this.BaseImageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BaseImageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BaseImageVersion = this.BaseImageVersion;
            context.BuildRoleArn = this.BuildRoleArn;
            #if MODULAR
            if (this.BuildRoleArn == null && ParameterWasBound(nameof(this.BuildRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BuildRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.CodeArtifact_Uri = this.CodeArtifact_Uri;
            if (this.CpuConfiguration != null)
            {
                context.CpuConfiguration = new List<Amazon.LambdaMicrovms.Model.CpuConfiguration>(this.CpuConfiguration);
            }
            context.Description = this.Description;
            if (this.EgressNetworkConnector != null)
            {
                context.EgressNetworkConnector = new List<System.String>(this.EgressNetworkConnector);
            }
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariable.Add((String)hashKey, (System.String)(this.EnvironmentVariable[hashKey]));
                }
            }
            context.Hooks_MicrovmHooks_Resume = this.Hooks_MicrovmHooks_Resume;
            context.Hooks_MicrovmHooks_ResumeTimeoutInSecond = this.Hooks_MicrovmHooks_ResumeTimeoutInSecond;
            context.Hooks_MicrovmHooks_Run = this.Hooks_MicrovmHooks_Run;
            context.Hooks_MicrovmHooks_RunTimeoutInSecond = this.Hooks_MicrovmHooks_RunTimeoutInSecond;
            context.Hooks_MicrovmHooks_Suspend = this.Hooks_MicrovmHooks_Suspend;
            context.Hooks_MicrovmHooks_SuspendTimeoutInSecond = this.Hooks_MicrovmHooks_SuspendTimeoutInSecond;
            context.Hooks_MicrovmHooks_Terminate = this.Hooks_MicrovmHooks_Terminate;
            context.Hooks_MicrovmHooks_TerminateTimeoutInSecond = this.Hooks_MicrovmHooks_TerminateTimeoutInSecond;
            context.Hooks_MicrovmImageHooks_Ready = this.Hooks_MicrovmImageHooks_Ready;
            context.Hooks_MicrovmImageHooks_ReadyTimeoutInSecond = this.Hooks_MicrovmImageHooks_ReadyTimeoutInSecond;
            context.Hooks_MicrovmImageHooks_Validate = this.Hooks_MicrovmImageHooks_Validate;
            context.Hooks_MicrovmImageHooks_ValidateTimeoutInSecond = this.Hooks_MicrovmImageHooks_ValidateTimeoutInSecond;
            context.Hooks_Port = this.Hooks_Port;
            context.Logging_CloudWatch_LogGroup = this.Logging_CloudWatch_LogGroup;
            context.Logging_CloudWatch_LogStream = this.Logging_CloudWatch_LogStream;
            context.Logging_Disabled = this.Logging_Disabled;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Resource != null)
            {
                context.Resource = new List<Amazon.LambdaMicrovms.Model.Resources>(this.Resource);
            }
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.LambdaMicrovms.Model.CreateMicrovmImageRequest();
            
            if (cmdletContext.AdditionalOsCapability != null)
            {
                request.AdditionalOsCapabilities = cmdletContext.AdditionalOsCapability;
            }
            if (cmdletContext.BaseImageArn != null)
            {
                request.BaseImageArn = cmdletContext.BaseImageArn;
            }
            if (cmdletContext.BaseImageVersion != null)
            {
                request.BaseImageVersion = cmdletContext.BaseImageVersion;
            }
            if (cmdletContext.BuildRoleArn != null)
            {
                request.BuildRoleArn = cmdletContext.BuildRoleArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CodeArtifact
            var requestCodeArtifactIsNull = true;
            request.CodeArtifact = new Amazon.LambdaMicrovms.Model.CodeArtifact();
            System.String requestCodeArtifact_codeArtifact_Uri = null;
            if (cmdletContext.CodeArtifact_Uri != null)
            {
                requestCodeArtifact_codeArtifact_Uri = cmdletContext.CodeArtifact_Uri;
            }
            if (requestCodeArtifact_codeArtifact_Uri != null)
            {
                request.CodeArtifact.Uri = requestCodeArtifact_codeArtifact_Uri;
                requestCodeArtifactIsNull = false;
            }
             // determine if request.CodeArtifact should be set to null
            if (requestCodeArtifactIsNull)
            {
                request.CodeArtifact = null;
            }
            if (cmdletContext.CpuConfiguration != null)
            {
                request.CpuConfigurations = cmdletContext.CpuConfiguration;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EgressNetworkConnector != null)
            {
                request.EgressNetworkConnectors = cmdletContext.EgressNetworkConnector;
            }
            if (cmdletContext.EnvironmentVariable != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariable;
            }
            
             // populate Hooks
            var requestHooksIsNull = true;
            request.Hooks = new Amazon.LambdaMicrovms.Model.Hooks();
            System.Int32? requestHooks_hooks_Port = null;
            if (cmdletContext.Hooks_Port != null)
            {
                requestHooks_hooks_Port = cmdletContext.Hooks_Port.Value;
            }
            if (requestHooks_hooks_Port != null)
            {
                request.Hooks.Port = requestHooks_hooks_Port.Value;
                requestHooksIsNull = false;
            }
            Amazon.LambdaMicrovms.Model.MicrovmImageHooks requestHooks_hooks_MicrovmImageHooks = null;
            
             // populate MicrovmImageHooks
            var requestHooks_hooks_MicrovmImageHooksIsNull = true;
            requestHooks_hooks_MicrovmImageHooks = new Amazon.LambdaMicrovms.Model.MicrovmImageHooks();
            Amazon.LambdaMicrovms.HookState requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_Ready = null;
            if (cmdletContext.Hooks_MicrovmImageHooks_Ready != null)
            {
                requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_Ready = cmdletContext.Hooks_MicrovmImageHooks_Ready;
            }
            if (requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_Ready != null)
            {
                requestHooks_hooks_MicrovmImageHooks.Ready = requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_Ready;
                requestHooks_hooks_MicrovmImageHooksIsNull = false;
            }
            System.Int32? requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_ReadyTimeoutInSecond = null;
            if (cmdletContext.Hooks_MicrovmImageHooks_ReadyTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_ReadyTimeoutInSecond = cmdletContext.Hooks_MicrovmImageHooks_ReadyTimeoutInSecond.Value;
            }
            if (requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_ReadyTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmImageHooks.ReadyTimeoutInSeconds = requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_ReadyTimeoutInSecond.Value;
                requestHooks_hooks_MicrovmImageHooksIsNull = false;
            }
            Amazon.LambdaMicrovms.HookState requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_Validate = null;
            if (cmdletContext.Hooks_MicrovmImageHooks_Validate != null)
            {
                requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_Validate = cmdletContext.Hooks_MicrovmImageHooks_Validate;
            }
            if (requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_Validate != null)
            {
                requestHooks_hooks_MicrovmImageHooks.Validate = requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_Validate;
                requestHooks_hooks_MicrovmImageHooksIsNull = false;
            }
            System.Int32? requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_ValidateTimeoutInSecond = null;
            if (cmdletContext.Hooks_MicrovmImageHooks_ValidateTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_ValidateTimeoutInSecond = cmdletContext.Hooks_MicrovmImageHooks_ValidateTimeoutInSecond.Value;
            }
            if (requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_ValidateTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmImageHooks.ValidateTimeoutInSeconds = requestHooks_hooks_MicrovmImageHooks_hooks_MicrovmImageHooks_ValidateTimeoutInSecond.Value;
                requestHooks_hooks_MicrovmImageHooksIsNull = false;
            }
             // determine if requestHooks_hooks_MicrovmImageHooks should be set to null
            if (requestHooks_hooks_MicrovmImageHooksIsNull)
            {
                requestHooks_hooks_MicrovmImageHooks = null;
            }
            if (requestHooks_hooks_MicrovmImageHooks != null)
            {
                request.Hooks.MicrovmImageHooks = requestHooks_hooks_MicrovmImageHooks;
                requestHooksIsNull = false;
            }
            Amazon.LambdaMicrovms.Model.MicrovmHooks requestHooks_hooks_MicrovmHooks = null;
            
             // populate MicrovmHooks
            var requestHooks_hooks_MicrovmHooksIsNull = true;
            requestHooks_hooks_MicrovmHooks = new Amazon.LambdaMicrovms.Model.MicrovmHooks();
            Amazon.LambdaMicrovms.HookState requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Resume = null;
            if (cmdletContext.Hooks_MicrovmHooks_Resume != null)
            {
                requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Resume = cmdletContext.Hooks_MicrovmHooks_Resume;
            }
            if (requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Resume != null)
            {
                requestHooks_hooks_MicrovmHooks.Resume = requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Resume;
                requestHooks_hooks_MicrovmHooksIsNull = false;
            }
            System.Int32? requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_ResumeTimeoutInSecond = null;
            if (cmdletContext.Hooks_MicrovmHooks_ResumeTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_ResumeTimeoutInSecond = cmdletContext.Hooks_MicrovmHooks_ResumeTimeoutInSecond.Value;
            }
            if (requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_ResumeTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmHooks.ResumeTimeoutInSeconds = requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_ResumeTimeoutInSecond.Value;
                requestHooks_hooks_MicrovmHooksIsNull = false;
            }
            Amazon.LambdaMicrovms.HookState requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Run = null;
            if (cmdletContext.Hooks_MicrovmHooks_Run != null)
            {
                requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Run = cmdletContext.Hooks_MicrovmHooks_Run;
            }
            if (requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Run != null)
            {
                requestHooks_hooks_MicrovmHooks.Run = requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Run;
                requestHooks_hooks_MicrovmHooksIsNull = false;
            }
            System.Int32? requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_RunTimeoutInSecond = null;
            if (cmdletContext.Hooks_MicrovmHooks_RunTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_RunTimeoutInSecond = cmdletContext.Hooks_MicrovmHooks_RunTimeoutInSecond.Value;
            }
            if (requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_RunTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmHooks.RunTimeoutInSeconds = requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_RunTimeoutInSecond.Value;
                requestHooks_hooks_MicrovmHooksIsNull = false;
            }
            Amazon.LambdaMicrovms.HookState requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Suspend = null;
            if (cmdletContext.Hooks_MicrovmHooks_Suspend != null)
            {
                requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Suspend = cmdletContext.Hooks_MicrovmHooks_Suspend;
            }
            if (requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Suspend != null)
            {
                requestHooks_hooks_MicrovmHooks.Suspend = requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Suspend;
                requestHooks_hooks_MicrovmHooksIsNull = false;
            }
            System.Int32? requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_SuspendTimeoutInSecond = null;
            if (cmdletContext.Hooks_MicrovmHooks_SuspendTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_SuspendTimeoutInSecond = cmdletContext.Hooks_MicrovmHooks_SuspendTimeoutInSecond.Value;
            }
            if (requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_SuspendTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmHooks.SuspendTimeoutInSeconds = requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_SuspendTimeoutInSecond.Value;
                requestHooks_hooks_MicrovmHooksIsNull = false;
            }
            Amazon.LambdaMicrovms.HookState requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Terminate = null;
            if (cmdletContext.Hooks_MicrovmHooks_Terminate != null)
            {
                requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Terminate = cmdletContext.Hooks_MicrovmHooks_Terminate;
            }
            if (requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Terminate != null)
            {
                requestHooks_hooks_MicrovmHooks.Terminate = requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_Terminate;
                requestHooks_hooks_MicrovmHooksIsNull = false;
            }
            System.Int32? requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_TerminateTimeoutInSecond = null;
            if (cmdletContext.Hooks_MicrovmHooks_TerminateTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_TerminateTimeoutInSecond = cmdletContext.Hooks_MicrovmHooks_TerminateTimeoutInSecond.Value;
            }
            if (requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_TerminateTimeoutInSecond != null)
            {
                requestHooks_hooks_MicrovmHooks.TerminateTimeoutInSeconds = requestHooks_hooks_MicrovmHooks_hooks_MicrovmHooks_TerminateTimeoutInSecond.Value;
                requestHooks_hooks_MicrovmHooksIsNull = false;
            }
             // determine if requestHooks_hooks_MicrovmHooks should be set to null
            if (requestHooks_hooks_MicrovmHooksIsNull)
            {
                requestHooks_hooks_MicrovmHooks = null;
            }
            if (requestHooks_hooks_MicrovmHooks != null)
            {
                request.Hooks.MicrovmHooks = requestHooks_hooks_MicrovmHooks;
                requestHooksIsNull = false;
            }
             // determine if request.Hooks should be set to null
            if (requestHooksIsNull)
            {
                request.Hooks = null;
            }
            
             // populate Logging
            var requestLoggingIsNull = true;
            request.Logging = new Amazon.LambdaMicrovms.Model.Logging();
            Amazon.LambdaMicrovms.Model.LoggingDisabled requestLogging_logging_Disabled = null;
            if (cmdletContext.Logging_Disabled != null)
            {
                requestLogging_logging_Disabled = cmdletContext.Logging_Disabled;
            }
            if (requestLogging_logging_Disabled != null)
            {
                request.Logging.Disabled = requestLogging_logging_Disabled;
                requestLoggingIsNull = false;
            }
            Amazon.LambdaMicrovms.Model.CloudWatchLogging requestLogging_logging_CloudWatch = null;
            
             // populate CloudWatch
            var requestLogging_logging_CloudWatchIsNull = true;
            requestLogging_logging_CloudWatch = new Amazon.LambdaMicrovms.Model.CloudWatchLogging();
            System.String requestLogging_logging_CloudWatch_logging_CloudWatch_LogGroup = null;
            if (cmdletContext.Logging_CloudWatch_LogGroup != null)
            {
                requestLogging_logging_CloudWatch_logging_CloudWatch_LogGroup = cmdletContext.Logging_CloudWatch_LogGroup;
            }
            if (requestLogging_logging_CloudWatch_logging_CloudWatch_LogGroup != null)
            {
                requestLogging_logging_CloudWatch.LogGroup = requestLogging_logging_CloudWatch_logging_CloudWatch_LogGroup;
                requestLogging_logging_CloudWatchIsNull = false;
            }
            System.String requestLogging_logging_CloudWatch_logging_CloudWatch_LogStream = null;
            if (cmdletContext.Logging_CloudWatch_LogStream != null)
            {
                requestLogging_logging_CloudWatch_logging_CloudWatch_LogStream = cmdletContext.Logging_CloudWatch_LogStream;
            }
            if (requestLogging_logging_CloudWatch_logging_CloudWatch_LogStream != null)
            {
                requestLogging_logging_CloudWatch.LogStream = requestLogging_logging_CloudWatch_logging_CloudWatch_LogStream;
                requestLogging_logging_CloudWatchIsNull = false;
            }
             // determine if requestLogging_logging_CloudWatch should be set to null
            if (requestLogging_logging_CloudWatchIsNull)
            {
                requestLogging_logging_CloudWatch = null;
            }
            if (requestLogging_logging_CloudWatch != null)
            {
                request.Logging.CloudWatch = requestLogging_logging_CloudWatch;
                requestLoggingIsNull = false;
            }
             // determine if request.Logging should be set to null
            if (requestLoggingIsNull)
            {
                request.Logging = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resources = cmdletContext.Resource;
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
        
        private Amazon.LambdaMicrovms.Model.CreateMicrovmImageResponse CallAWSServiceOperation(IAmazonLambdaMicrovms client, Amazon.LambdaMicrovms.Model.CreateMicrovmImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Lambda MicroVMs", "CreateMicrovmImage");
            try
            {
                return client.CreateMicrovmImageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AdditionalOsCapability { get; set; }
            public System.String BaseImageArn { get; set; }
            public System.String BaseImageVersion { get; set; }
            public System.String BuildRoleArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CodeArtifact_Uri { get; set; }
            public List<Amazon.LambdaMicrovms.Model.CpuConfiguration> CpuConfiguration { get; set; }
            public System.String Description { get; set; }
            public List<System.String> EgressNetworkConnector { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public Amazon.LambdaMicrovms.HookState Hooks_MicrovmHooks_Resume { get; set; }
            public System.Int32? Hooks_MicrovmHooks_ResumeTimeoutInSecond { get; set; }
            public Amazon.LambdaMicrovms.HookState Hooks_MicrovmHooks_Run { get; set; }
            public System.Int32? Hooks_MicrovmHooks_RunTimeoutInSecond { get; set; }
            public Amazon.LambdaMicrovms.HookState Hooks_MicrovmHooks_Suspend { get; set; }
            public System.Int32? Hooks_MicrovmHooks_SuspendTimeoutInSecond { get; set; }
            public Amazon.LambdaMicrovms.HookState Hooks_MicrovmHooks_Terminate { get; set; }
            public System.Int32? Hooks_MicrovmHooks_TerminateTimeoutInSecond { get; set; }
            public Amazon.LambdaMicrovms.HookState Hooks_MicrovmImageHooks_Ready { get; set; }
            public System.Int32? Hooks_MicrovmImageHooks_ReadyTimeoutInSecond { get; set; }
            public Amazon.LambdaMicrovms.HookState Hooks_MicrovmImageHooks_Validate { get; set; }
            public System.Int32? Hooks_MicrovmImageHooks_ValidateTimeoutInSecond { get; set; }
            public System.Int32? Hooks_Port { get; set; }
            public System.String Logging_CloudWatch_LogGroup { get; set; }
            public System.String Logging_CloudWatch_LogStream { get; set; }
            public Amazon.LambdaMicrovms.Model.LoggingDisabled Logging_Disabled { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.LambdaMicrovms.Model.Resources> Resource { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LambdaMicrovms.Model.CreateMicrovmImageResponse, NewLMVM2MicrovmImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
