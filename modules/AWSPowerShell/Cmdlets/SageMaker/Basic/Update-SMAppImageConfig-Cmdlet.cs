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
    /// Updates the properties of an AppImageConfig.
    /// </summary>
    [Cmdlet("Update", "SMAppImageConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateAppImageConfig API operation.", Operation = new[] {"UpdateAppImageConfig"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateAppImageConfigResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateAppImageConfigResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateAppImageConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMAppImageConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppImageConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the AppImageConfig to update.</para>
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
        public System.String AppImageConfigName { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_ContainerArgument
        /// <summary>
        /// <para>
        /// <para>The arguments for the container when you're running the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterLabAppImageConfig_ContainerConfig_ContainerArguments")]
        public System.String[] ContainerConfig_ContainerArgument { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_ContainerEntrypoint
        /// <summary>
        /// <para>
        /// <para>The entrypoint used to run the application in the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterLabAppImageConfig_ContainerConfig_ContainerEntrypoint")]
        public System.String[] ContainerConfig_ContainerEntrypoint { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_ContainerEnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>The environment variables to set in the container</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterLabAppImageConfig_ContainerConfig_ContainerEnvironmentVariables")]
        public System.Collections.Hashtable ContainerConfig_ContainerEnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter JupyterLabAppImageConfig_FileSystemConfig_DefaultGid
        /// <summary>
        /// <para>
        /// <para>The default POSIX group ID (GID). If not specified, defaults to <code>100</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? JupyterLabAppImageConfig_FileSystemConfig_DefaultGid { get; set; }
        #endregion
        
        #region Parameter FileSystemConfig_DefaultGid
        /// <summary>
        /// <para>
        /// <para>The default POSIX group ID (GID). If not specified, defaults to <code>100</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayImageConfig_FileSystemConfig_DefaultGid")]
        public System.Int32? FileSystemConfig_DefaultGid { get; set; }
        #endregion
        
        #region Parameter JupyterLabAppImageConfig_FileSystemConfig_DefaultUid
        /// <summary>
        /// <para>
        /// <para>The default POSIX user ID (UID). If not specified, defaults to <code>1000</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? JupyterLabAppImageConfig_FileSystemConfig_DefaultUid { get; set; }
        #endregion
        
        #region Parameter FileSystemConfig_DefaultUid
        /// <summary>
        /// <para>
        /// <para>The default POSIX user ID (UID). If not specified, defaults to <code>1000</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayImageConfig_FileSystemConfig_DefaultUid")]
        public System.Int32? FileSystemConfig_DefaultUid { get; set; }
        #endregion
        
        #region Parameter KernelGatewayImageConfig_KernelSpec
        /// <summary>
        /// <para>
        /// <para>The specification of the Jupyter kernels in the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayImageConfig_KernelSpecs")]
        public Amazon.SageMaker.Model.KernelSpec[] KernelGatewayImageConfig_KernelSpec { get; set; }
        #endregion
        
        #region Parameter JupyterLabAppImageConfig_FileSystemConfig_MountPath
        /// <summary>
        /// <para>
        /// <para>The path within the image to mount the user's EFS home directory. The directory should
        /// be empty. If not specified, defaults to <i>/home/sagemaker-user</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JupyterLabAppImageConfig_FileSystemConfig_MountPath { get; set; }
        #endregion
        
        #region Parameter FileSystemConfig_MountPath
        /// <summary>
        /// <para>
        /// <para>The path within the image to mount the user's EFS home directory. The directory should
        /// be empty. If not specified, defaults to <i>/home/sagemaker-user</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayImageConfig_FileSystemConfig_MountPath")]
        public System.String FileSystemConfig_MountPath { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppImageConfigArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateAppImageConfigResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateAppImageConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppImageConfigArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppImageConfigName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppImageConfigName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppImageConfigName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppImageConfigName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMAppImageConfig (UpdateAppImageConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateAppImageConfigResponse, UpdateSMAppImageConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppImageConfigName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppImageConfigName = this.AppImageConfigName;
            #if MODULAR
            if (this.AppImageConfigName == null && ParameterWasBound(nameof(this.AppImageConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter AppImageConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ContainerConfig_ContainerArgument != null)
            {
                context.ContainerConfig_ContainerArgument = new List<System.String>(this.ContainerConfig_ContainerArgument);
            }
            if (this.ContainerConfig_ContainerEntrypoint != null)
            {
                context.ContainerConfig_ContainerEntrypoint = new List<System.String>(this.ContainerConfig_ContainerEntrypoint);
            }
            if (this.ContainerConfig_ContainerEnvironmentVariable != null)
            {
                context.ContainerConfig_ContainerEnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ContainerConfig_ContainerEnvironmentVariable.Keys)
                {
                    context.ContainerConfig_ContainerEnvironmentVariable.Add((String)hashKey, (String)(this.ContainerConfig_ContainerEnvironmentVariable[hashKey]));
                }
            }
            context.JupyterLabAppImageConfig_FileSystemConfig_DefaultGid = this.JupyterLabAppImageConfig_FileSystemConfig_DefaultGid;
            context.JupyterLabAppImageConfig_FileSystemConfig_DefaultUid = this.JupyterLabAppImageConfig_FileSystemConfig_DefaultUid;
            context.JupyterLabAppImageConfig_FileSystemConfig_MountPath = this.JupyterLabAppImageConfig_FileSystemConfig_MountPath;
            context.FileSystemConfig_DefaultGid = this.FileSystemConfig_DefaultGid;
            context.FileSystemConfig_DefaultUid = this.FileSystemConfig_DefaultUid;
            context.FileSystemConfig_MountPath = this.FileSystemConfig_MountPath;
            if (this.KernelGatewayImageConfig_KernelSpec != null)
            {
                context.KernelGatewayImageConfig_KernelSpec = new List<Amazon.SageMaker.Model.KernelSpec>(this.KernelGatewayImageConfig_KernelSpec);
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
            var request = new Amazon.SageMaker.Model.UpdateAppImageConfigRequest();
            
            if (cmdletContext.AppImageConfigName != null)
            {
                request.AppImageConfigName = cmdletContext.AppImageConfigName;
            }
            
             // populate JupyterLabAppImageConfig
            var requestJupyterLabAppImageConfigIsNull = true;
            request.JupyterLabAppImageConfig = new Amazon.SageMaker.Model.JupyterLabAppImageConfig();
            Amazon.SageMaker.Model.ContainerConfig requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig = null;
            
             // populate ContainerConfig
            var requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfigIsNull = true;
            requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig = new Amazon.SageMaker.Model.ContainerConfig();
            List<System.String> requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerArgument = null;
            if (cmdletContext.ContainerConfig_ContainerArgument != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerArgument = cmdletContext.ContainerConfig_ContainerArgument;
            }
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerArgument != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig.ContainerArguments = requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerArgument;
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfigIsNull = false;
            }
            List<System.String> requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerEntrypoint = null;
            if (cmdletContext.ContainerConfig_ContainerEntrypoint != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerEntrypoint = cmdletContext.ContainerConfig_ContainerEntrypoint;
            }
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerEntrypoint != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig.ContainerEntrypoint = requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerEntrypoint;
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfigIsNull = false;
            }
            Dictionary<System.String, System.String> requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerEnvironmentVariable = null;
            if (cmdletContext.ContainerConfig_ContainerEnvironmentVariable != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerEnvironmentVariable = cmdletContext.ContainerConfig_ContainerEnvironmentVariable;
            }
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerEnvironmentVariable != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig.ContainerEnvironmentVariables = requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig_containerConfig_ContainerEnvironmentVariable;
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfigIsNull = false;
            }
             // determine if requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig should be set to null
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfigIsNull)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig = null;
            }
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig != null)
            {
                request.JupyterLabAppImageConfig.ContainerConfig = requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_ContainerConfig;
                requestJupyterLabAppImageConfigIsNull = false;
            }
            Amazon.SageMaker.Model.FileSystemConfig requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig = null;
            
             // populate FileSystemConfig
            var requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfigIsNull = true;
            requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig = new Amazon.SageMaker.Model.FileSystemConfig();
            System.Int32? requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_DefaultGid = null;
            if (cmdletContext.JupyterLabAppImageConfig_FileSystemConfig_DefaultGid != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_DefaultGid = cmdletContext.JupyterLabAppImageConfig_FileSystemConfig_DefaultGid.Value;
            }
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_DefaultGid != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig.DefaultGid = requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_DefaultGid.Value;
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfigIsNull = false;
            }
            System.Int32? requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_DefaultUid = null;
            if (cmdletContext.JupyterLabAppImageConfig_FileSystemConfig_DefaultUid != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_DefaultUid = cmdletContext.JupyterLabAppImageConfig_FileSystemConfig_DefaultUid.Value;
            }
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_DefaultUid != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig.DefaultUid = requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_DefaultUid.Value;
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfigIsNull = false;
            }
            System.String requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_MountPath = null;
            if (cmdletContext.JupyterLabAppImageConfig_FileSystemConfig_MountPath != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_MountPath = cmdletContext.JupyterLabAppImageConfig_FileSystemConfig_MountPath;
            }
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_MountPath != null)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig.MountPath = requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig_jupyterLabAppImageConfig_FileSystemConfig_MountPath;
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfigIsNull = false;
            }
             // determine if requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig should be set to null
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfigIsNull)
            {
                requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig = null;
            }
            if (requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig != null)
            {
                request.JupyterLabAppImageConfig.FileSystemConfig = requestJupyterLabAppImageConfig_jupyterLabAppImageConfig_FileSystemConfig;
                requestJupyterLabAppImageConfigIsNull = false;
            }
             // determine if request.JupyterLabAppImageConfig should be set to null
            if (requestJupyterLabAppImageConfigIsNull)
            {
                request.JupyterLabAppImageConfig = null;
            }
            
             // populate KernelGatewayImageConfig
            var requestKernelGatewayImageConfigIsNull = true;
            request.KernelGatewayImageConfig = new Amazon.SageMaker.Model.KernelGatewayImageConfig();
            List<Amazon.SageMaker.Model.KernelSpec> requestKernelGatewayImageConfig_kernelGatewayImageConfig_KernelSpec = null;
            if (cmdletContext.KernelGatewayImageConfig_KernelSpec != null)
            {
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_KernelSpec = cmdletContext.KernelGatewayImageConfig_KernelSpec;
            }
            if (requestKernelGatewayImageConfig_kernelGatewayImageConfig_KernelSpec != null)
            {
                request.KernelGatewayImageConfig.KernelSpecs = requestKernelGatewayImageConfig_kernelGatewayImageConfig_KernelSpec;
                requestKernelGatewayImageConfigIsNull = false;
            }
            Amazon.SageMaker.Model.FileSystemConfig requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig = null;
            
             // populate FileSystemConfig
            var requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfigIsNull = true;
            requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig = new Amazon.SageMaker.Model.FileSystemConfig();
            System.Int32? requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_DefaultGid = null;
            if (cmdletContext.FileSystemConfig_DefaultGid != null)
            {
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_DefaultGid = cmdletContext.FileSystemConfig_DefaultGid.Value;
            }
            if (requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_DefaultGid != null)
            {
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig.DefaultGid = requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_DefaultGid.Value;
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfigIsNull = false;
            }
            System.Int32? requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_DefaultUid = null;
            if (cmdletContext.FileSystemConfig_DefaultUid != null)
            {
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_DefaultUid = cmdletContext.FileSystemConfig_DefaultUid.Value;
            }
            if (requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_DefaultUid != null)
            {
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig.DefaultUid = requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_DefaultUid.Value;
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfigIsNull = false;
            }
            System.String requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_MountPath = null;
            if (cmdletContext.FileSystemConfig_MountPath != null)
            {
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_MountPath = cmdletContext.FileSystemConfig_MountPath;
            }
            if (requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_MountPath != null)
            {
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig.MountPath = requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig_fileSystemConfig_MountPath;
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfigIsNull = false;
            }
             // determine if requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig should be set to null
            if (requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfigIsNull)
            {
                requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig = null;
            }
            if (requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig != null)
            {
                request.KernelGatewayImageConfig.FileSystemConfig = requestKernelGatewayImageConfig_kernelGatewayImageConfig_FileSystemConfig;
                requestKernelGatewayImageConfigIsNull = false;
            }
             // determine if request.KernelGatewayImageConfig should be set to null
            if (requestKernelGatewayImageConfigIsNull)
            {
                request.KernelGatewayImageConfig = null;
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
        
        private Amazon.SageMaker.Model.UpdateAppImageConfigResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateAppImageConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateAppImageConfig");
            try
            {
                #if DESKTOP
                return client.UpdateAppImageConfig(request);
                #elif CORECLR
                return client.UpdateAppImageConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String AppImageConfigName { get; set; }
            public List<System.String> ContainerConfig_ContainerArgument { get; set; }
            public List<System.String> ContainerConfig_ContainerEntrypoint { get; set; }
            public Dictionary<System.String, System.String> ContainerConfig_ContainerEnvironmentVariable { get; set; }
            public System.Int32? JupyterLabAppImageConfig_FileSystemConfig_DefaultGid { get; set; }
            public System.Int32? JupyterLabAppImageConfig_FileSystemConfig_DefaultUid { get; set; }
            public System.String JupyterLabAppImageConfig_FileSystemConfig_MountPath { get; set; }
            public System.Int32? FileSystemConfig_DefaultGid { get; set; }
            public System.Int32? FileSystemConfig_DefaultUid { get; set; }
            public System.String FileSystemConfig_MountPath { get; set; }
            public List<Amazon.SageMaker.Model.KernelSpec> KernelGatewayImageConfig_KernelSpec { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateAppImageConfigResponse, UpdateSMAppImageConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppImageConfigArn;
        }
        
    }
}
