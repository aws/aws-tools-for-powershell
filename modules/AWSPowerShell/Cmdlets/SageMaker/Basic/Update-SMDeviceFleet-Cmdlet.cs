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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates a fleet of devices.
    /// </summary>
    [Cmdlet("Update", "SMDeviceFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateDeviceFleet API operation.", Operation = new[] {"UpdateDeviceFleet"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateDeviceFleetResponse))]
    [AWSCmdletOutput("None or Amazon.SageMaker.Model.UpdateDeviceFleetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SageMaker.Model.UpdateDeviceFleetResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMDeviceFleetCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DeviceFleetName
        /// <summary>
        /// <para>
        /// <para>The name of the fleet.</para>
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
        public System.String DeviceFleetName { get; set; }
        #endregion
        
        #region Parameter EnableIotRoleAlias
        /// <summary>
        /// <para>
        /// <para>Whether to create an Amazon Web Services IoT Role Alias during device fleet creation.
        /// The name of the role alias generated will match this pattern: "SageMakerEdge-{DeviceFleetName}".</para><para>For example, if your device fleet is called "demo-fleet", the name of the role alias
        /// will be "SageMakerEdge-demo-fleet".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIotRoleAlias { get; set; }
        #endregion
        
        #region Parameter OutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// Amazon SageMaker uses to encrypt data on the storage volume after compilation job.
        /// If you don't provide a KMS key ID, Amazon SageMaker uses the default KMS key for Amazon
        /// S3 for your role's account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter OutputConfig_PresetDeploymentConfig
        /// <summary>
        /// <para>
        /// <para>The configuration used to create deployment artifacts. Specify configuration options
        /// with a JSON string. The available configuration options for each type are:</para><ul><li><para><c>ComponentName</c> (optional) - Name of the GreenGrass V2 component. If not specified,
        /// the default name generated consists of "SagemakerEdgeManager" and the name of your
        /// SageMaker Edge Manager packaging job.</para></li><li><para><c>ComponentDescription</c> (optional) - Description of the component.</para></li><li><para><c>ComponentVersion</c> (optional) - The version of the component.</para><note><para>Amazon Web Services IoT Greengrass uses semantic versions for components. Semantic
        /// versions follow a<i> major.minor.patch</i> number system. For example, version 1.0.0
        /// represents the first major release for a component. For more information, see the
        /// <a href="https://semver.org/">semantic version specification</a>.</para></note></li><li><para><c>PlatformOS</c> (optional) - The name of the operating system for the platform.
        /// Supported platforms include Windows and Linux.</para></li><li><para><c>PlatformArchitecture</c> (optional) - The processor architecture for the platform.
        /// </para><para>Supported architectures Windows include: Windows32_x86, Windows64_x64.</para><para>Supported architectures for Linux include: Linux x86_64, Linux ARMV8.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_PresetDeploymentConfig { get; set; }
        #endregion
        
        #region Parameter OutputConfig_PresetDeploymentType
        /// <summary>
        /// <para>
        /// <para>The deployment type SageMaker Edge Manager will create. Currently only supports Amazon
        /// Web Services IoT Greengrass Version 2 components.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.EdgePresetDeploymentType")]
        public Amazon.SageMaker.EdgePresetDeploymentType OutputConfig_PresetDeploymentType { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3OutputLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon Simple Storage (S3) bucker URI.</para>
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
        public System.String OutputConfig_S3OutputLocation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateDeviceFleetResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeviceFleetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMDeviceFleet (UpdateDeviceFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateDeviceFleetResponse, UpdateSMDeviceFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DeviceFleetName = this.DeviceFleetName;
            #if MODULAR
            if (this.DeviceFleetName == null && ParameterWasBound(nameof(this.DeviceFleetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceFleetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnableIotRoleAlias = this.EnableIotRoleAlias;
            context.OutputConfig_KmsKeyId = this.OutputConfig_KmsKeyId;
            context.OutputConfig_PresetDeploymentConfig = this.OutputConfig_PresetDeploymentConfig;
            context.OutputConfig_PresetDeploymentType = this.OutputConfig_PresetDeploymentType;
            context.OutputConfig_S3OutputLocation = this.OutputConfig_S3OutputLocation;
            #if MODULAR
            if (this.OutputConfig_S3OutputLocation == null && ParameterWasBound(nameof(this.OutputConfig_S3OutputLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3OutputLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.SageMaker.Model.UpdateDeviceFleetRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DeviceFleetName != null)
            {
                request.DeviceFleetName = cmdletContext.DeviceFleetName;
            }
            if (cmdletContext.EnableIotRoleAlias != null)
            {
                request.EnableIotRoleAlias = cmdletContext.EnableIotRoleAlias.Value;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.EdgeOutputConfig();
            System.String requestOutputConfig_outputConfig_KmsKeyId = null;
            if (cmdletContext.OutputConfig_KmsKeyId != null)
            {
                requestOutputConfig_outputConfig_KmsKeyId = cmdletContext.OutputConfig_KmsKeyId;
            }
            if (requestOutputConfig_outputConfig_KmsKeyId != null)
            {
                request.OutputConfig.KmsKeyId = requestOutputConfig_outputConfig_KmsKeyId;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_PresetDeploymentConfig = null;
            if (cmdletContext.OutputConfig_PresetDeploymentConfig != null)
            {
                requestOutputConfig_outputConfig_PresetDeploymentConfig = cmdletContext.OutputConfig_PresetDeploymentConfig;
            }
            if (requestOutputConfig_outputConfig_PresetDeploymentConfig != null)
            {
                request.OutputConfig.PresetDeploymentConfig = requestOutputConfig_outputConfig_PresetDeploymentConfig;
                requestOutputConfigIsNull = false;
            }
            Amazon.SageMaker.EdgePresetDeploymentType requestOutputConfig_outputConfig_PresetDeploymentType = null;
            if (cmdletContext.OutputConfig_PresetDeploymentType != null)
            {
                requestOutputConfig_outputConfig_PresetDeploymentType = cmdletContext.OutputConfig_PresetDeploymentType;
            }
            if (requestOutputConfig_outputConfig_PresetDeploymentType != null)
            {
                request.OutputConfig.PresetDeploymentType = requestOutputConfig_outputConfig_PresetDeploymentType;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3OutputLocation = null;
            if (cmdletContext.OutputConfig_S3OutputLocation != null)
            {
                requestOutputConfig_outputConfig_S3OutputLocation = cmdletContext.OutputConfig_S3OutputLocation;
            }
            if (requestOutputConfig_outputConfig_S3OutputLocation != null)
            {
                request.OutputConfig.S3OutputLocation = requestOutputConfig_outputConfig_S3OutputLocation;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.SageMaker.Model.UpdateDeviceFleetResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateDeviceFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateDeviceFleet");
            try
            {
                return client.UpdateDeviceFleetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DeviceFleetName { get; set; }
            public System.Boolean? EnableIotRoleAlias { get; set; }
            public System.String OutputConfig_KmsKeyId { get; set; }
            public System.String OutputConfig_PresetDeploymentConfig { get; set; }
            public Amazon.SageMaker.EdgePresetDeploymentType OutputConfig_PresetDeploymentType { get; set; }
            public System.String OutputConfig_S3OutputLocation { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateDeviceFleetResponse, UpdateSMDeviceFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
