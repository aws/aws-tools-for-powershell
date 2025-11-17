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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Specifies and starts a remote access session.
    /// </summary>
    [Cmdlet("New", "DFRemoteAccessSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.RemoteAccessSession")]
    [AWSCmdlet("Calls the AWS Device Farm CreateRemoteAccessSession API operation.", Operation = new[] {"CreateRemoteAccessSession"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.RemoteAccessSession or Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse",
        "This cmdlet returns an Amazon.DeviceFarm.Model.RemoteAccessSession object.",
        "The service call response (type Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDFRemoteAccessSessionCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the app to create the remote access session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter Configuration_AuxiliaryApp
        /// <summary>
        /// <para>
        /// <para>A list of upload ARNs for app packages to be installed onto your device. (Maximum
        /// 3)</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AuxiliaryApps")]
        public System.String[] Configuration_AuxiliaryApp { get; set; }
        #endregion
        
        #region Parameter Configuration_BillingMethod
        /// <summary>
        /// <para>
        /// <para>The billing method for the remote access session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DeviceFarm.BillingMethod")]
        public Amazon.DeviceFarm.BillingMethod Configuration_BillingMethod { get; set; }
        #endregion
        
        #region Parameter DeviceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the device for which you want to create a remote access session.</para>
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
        public System.String DeviceArn { get; set; }
        #endregion
        
        #region Parameter DeviceProxy_Host
        /// <summary>
        /// <para>
        /// <para>Hostname or IPv4 address of the proxy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_DeviceProxy_Host")]
        public System.String DeviceProxy_Host { get; set; }
        #endregion
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the device instance for which you want to create
        /// a remote access session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the remote access session to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter DeviceProxy_Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the http/s proxy is listening.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_DeviceProxy_Port")]
        public System.Int32? DeviceProxy_Port { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the project for which you want to create a remote
        /// access session.</para>
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
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter SkipAppResign
        /// <summary>
        /// <para>
        /// <para>When set to <c>true</c>, for private devices, Device Farm does not sign your app again.
        /// For public devices, Device Farm always signs your apps again.</para><para>For more information on how Device Farm modifies your uploads during tests, see <a href="http://aws.amazon.com/device-farm/faqs/">Do you modify my app?</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipAppResign { get; set; }
        #endregion
        
        #region Parameter Configuration_VpceConfigurationArn
        /// <summary>
        /// <para>
        /// <para>An array of ARNs included in the VPC endpoint configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_VpceConfigurationArns")]
        public System.String[] Configuration_VpceConfigurationArn { get; set; }
        #endregion
        
        #region Parameter InteractionMode
        /// <summary>
        /// <para>
        /// <para>The interaction mode of the remote access session. Changing the interactive mode of
        /// remote access sessions is no longer available.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Changing the interactive mode of Remote Access sessions is no longer available.")]
        [AWSConstantClassSource("Amazon.DeviceFarm.InteractionMode")]
        public Amazon.DeviceFarm.InteractionMode InteractionMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RemoteAccessSession'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RemoteAccessSession";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeviceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DFRemoteAccessSession (CreateRemoteAccessSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse, NewDFRemoteAccessSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppArn = this.AppArn;
            if (this.Configuration_AuxiliaryApp != null)
            {
                context.Configuration_AuxiliaryApp = new List<System.String>(this.Configuration_AuxiliaryApp);
            }
            context.Configuration_BillingMethod = this.Configuration_BillingMethod;
            context.DeviceProxy_Host = this.DeviceProxy_Host;
            context.DeviceProxy_Port = this.DeviceProxy_Port;
            if (this.Configuration_VpceConfigurationArn != null)
            {
                context.Configuration_VpceConfigurationArn = new List<System.String>(this.Configuration_VpceConfigurationArn);
            }
            context.DeviceArn = this.DeviceArn;
            #if MODULAR
            if (this.DeviceArn == null && ParameterWasBound(nameof(this.DeviceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceArn = this.InstanceArn;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InteractionMode = this.InteractionMode;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SkipAppResign = this.SkipAppResign;
            
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
            var request = new Amazon.DeviceFarm.Model.CreateRemoteAccessSessionRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.DeviceFarm.Model.CreateRemoteAccessSessionConfiguration();
            List<System.String> requestConfiguration_configuration_AuxiliaryApp = null;
            if (cmdletContext.Configuration_AuxiliaryApp != null)
            {
                requestConfiguration_configuration_AuxiliaryApp = cmdletContext.Configuration_AuxiliaryApp;
            }
            if (requestConfiguration_configuration_AuxiliaryApp != null)
            {
                request.Configuration.AuxiliaryApps = requestConfiguration_configuration_AuxiliaryApp;
                requestConfigurationIsNull = false;
            }
            Amazon.DeviceFarm.BillingMethod requestConfiguration_configuration_BillingMethod = null;
            if (cmdletContext.Configuration_BillingMethod != null)
            {
                requestConfiguration_configuration_BillingMethod = cmdletContext.Configuration_BillingMethod;
            }
            if (requestConfiguration_configuration_BillingMethod != null)
            {
                request.Configuration.BillingMethod = requestConfiguration_configuration_BillingMethod;
                requestConfigurationIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_VpceConfigurationArn = null;
            if (cmdletContext.Configuration_VpceConfigurationArn != null)
            {
                requestConfiguration_configuration_VpceConfigurationArn = cmdletContext.Configuration_VpceConfigurationArn;
            }
            if (requestConfiguration_configuration_VpceConfigurationArn != null)
            {
                request.Configuration.VpceConfigurationArns = requestConfiguration_configuration_VpceConfigurationArn;
                requestConfigurationIsNull = false;
            }
            Amazon.DeviceFarm.Model.DeviceProxy requestConfiguration_configuration_DeviceProxy = null;
            
             // populate DeviceProxy
            var requestConfiguration_configuration_DeviceProxyIsNull = true;
            requestConfiguration_configuration_DeviceProxy = new Amazon.DeviceFarm.Model.DeviceProxy();
            System.String requestConfiguration_configuration_DeviceProxy_deviceProxy_Host = null;
            if (cmdletContext.DeviceProxy_Host != null)
            {
                requestConfiguration_configuration_DeviceProxy_deviceProxy_Host = cmdletContext.DeviceProxy_Host;
            }
            if (requestConfiguration_configuration_DeviceProxy_deviceProxy_Host != null)
            {
                requestConfiguration_configuration_DeviceProxy.Host = requestConfiguration_configuration_DeviceProxy_deviceProxy_Host;
                requestConfiguration_configuration_DeviceProxyIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_DeviceProxy_deviceProxy_Port = null;
            if (cmdletContext.DeviceProxy_Port != null)
            {
                requestConfiguration_configuration_DeviceProxy_deviceProxy_Port = cmdletContext.DeviceProxy_Port.Value;
            }
            if (requestConfiguration_configuration_DeviceProxy_deviceProxy_Port != null)
            {
                requestConfiguration_configuration_DeviceProxy.Port = requestConfiguration_configuration_DeviceProxy_deviceProxy_Port.Value;
                requestConfiguration_configuration_DeviceProxyIsNull = false;
            }
             // determine if requestConfiguration_configuration_DeviceProxy should be set to null
            if (requestConfiguration_configuration_DeviceProxyIsNull)
            {
                requestConfiguration_configuration_DeviceProxy = null;
            }
            if (requestConfiguration_configuration_DeviceProxy != null)
            {
                request.Configuration.DeviceProxy = requestConfiguration_configuration_DeviceProxy;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.DeviceArn != null)
            {
                request.DeviceArn = cmdletContext.DeviceArn;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.InteractionMode != null)
            {
                request.InteractionMode = cmdletContext.InteractionMode;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            if (cmdletContext.SkipAppResign != null)
            {
                request.SkipAppResign = cmdletContext.SkipAppResign.Value;
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
        
        private Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.CreateRemoteAccessSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "CreateRemoteAccessSession");
            try
            {
                return client.CreateRemoteAccessSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppArn { get; set; }
            public List<System.String> Configuration_AuxiliaryApp { get; set; }
            public Amazon.DeviceFarm.BillingMethod Configuration_BillingMethod { get; set; }
            public System.String DeviceProxy_Host { get; set; }
            public System.Int32? DeviceProxy_Port { get; set; }
            public List<System.String> Configuration_VpceConfigurationArn { get; set; }
            public System.String DeviceArn { get; set; }
            public System.String InstanceArn { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.DeviceFarm.InteractionMode InteractionMode { get; set; }
            public System.String Name { get; set; }
            public System.String ProjectArn { get; set; }
            public System.Boolean? SkipAppResign { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse, NewDFRemoteAccessSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RemoteAccessSession;
        }
        
    }
}
