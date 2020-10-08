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
    /// Creates a configuration for running an Amazon SageMaker image as a KernelGateway app.
    /// </summary>
    [Cmdlet("New", "SMAppImageConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateAppImageConfig API operation.", Operation = new[] {"CreateAppImageConfig"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateAppImageConfigResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateAppImageConfigResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateAppImageConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMAppImageConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter AppImageConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the AppImageConfig. Must be unique to your account.</para>
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
        
        #region Parameter FileSystemConfig_DefaultGid
        /// <summary>
        /// <para>
        /// <para>The default POSIX group ID. If not specified, defaults to <code>100</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayImageConfig_FileSystemConfig_DefaultGid")]
        public System.Int32? FileSystemConfig_DefaultGid { get; set; }
        #endregion
        
        #region Parameter FileSystemConfig_DefaultUid
        /// <summary>
        /// <para>
        /// <para>The default POSIX user ID. If not specified, defaults to <code>1000</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayImageConfig_FileSystemConfig_DefaultUid")]
        public System.Int32? FileSystemConfig_DefaultUid { get; set; }
        #endregion
        
        #region Parameter KernelGatewayImageConfig_KernelSpec
        /// <summary>
        /// <para>
        /// <para>Defines how a kernel is started and the arguments, environment variables, and metadata
        /// that are available to the kernel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayImageConfig_KernelSpecs")]
        public Amazon.SageMaker.Model.KernelSpec[] KernelGatewayImageConfig_KernelSpec { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to apply to the AppImageConfig.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppImageConfigArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateAppImageConfigResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateAppImageConfigResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppImageConfigName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMAppImageConfig (CreateAppImageConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateAppImageConfigResponse, NewSMAppImageConfigCmdlet>(Select) ??
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
            context.FileSystemConfig_DefaultGid = this.FileSystemConfig_DefaultGid;
            context.FileSystemConfig_DefaultUid = this.FileSystemConfig_DefaultUid;
            context.FileSystemConfig_MountPath = this.FileSystemConfig_MountPath;
            if (this.KernelGatewayImageConfig_KernelSpec != null)
            {
                context.KernelGatewayImageConfig_KernelSpec = new List<Amazon.SageMaker.Model.KernelSpec>(this.KernelGatewayImageConfig_KernelSpec);
            }
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
            var request = new Amazon.SageMaker.Model.CreateAppImageConfigRequest();
            
            if (cmdletContext.AppImageConfigName != null)
            {
                request.AppImageConfigName = cmdletContext.AppImageConfigName;
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
        
        private Amazon.SageMaker.Model.CreateAppImageConfigResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateAppImageConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateAppImageConfig");
            try
            {
                #if DESKTOP
                return client.CreateAppImageConfig(request);
                #elif CORECLR
                return client.CreateAppImageConfigAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? FileSystemConfig_DefaultGid { get; set; }
            public System.Int32? FileSystemConfig_DefaultUid { get; set; }
            public System.String FileSystemConfig_MountPath { get; set; }
            public List<Amazon.SageMaker.Model.KernelSpec> KernelGatewayImageConfig_KernelSpec { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateAppImageConfigResponse, NewSMAppImageConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppImageConfigArn;
        }
        
    }
}
