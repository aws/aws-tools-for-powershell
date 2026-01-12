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
using Amazon.IoTManagedIntegrations;
using Amazon.IoTManagedIntegrations.Model;

namespace Amazon.PowerShell.Cmdlets.IOTMI
{
    /// <summary>
    /// Update the attributes and capabilities associated with a managed thing.
    /// </summary>
    [Cmdlet("Update", "IOTMIManagedThing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management UpdateManagedThing API operation.", Operation = new[] {"UpdateManagedThing"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.UpdateManagedThingResponse))]
    [AWSCmdletOutput("None or Amazon.IoTManagedIntegrations.Model.UpdateManagedThingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTManagedIntegrations.Model.UpdateManagedThingResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTMIManagedThingCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Brand
        /// <summary>
        /// <para>
        /// <para>The brand of the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Brand { get; set; }
        #endregion
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>The capabilities of the device such as light bulb.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String Capability { get; set; }
        #endregion
        
        #region Parameter CapabilitySchema
        /// <summary>
        /// <para>
        /// <para>The updated capability schemas that define the functionality and features supported
        /// by the managed thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilitySchemas")]
        public Amazon.IoTManagedIntegrations.Model.CapabilitySchemaItem[] CapabilitySchema { get; set; }
        #endregion
        
        #region Parameter Classification
        /// <summary>
        /// <para>
        /// <para>The classification of the managed thing such as light bulb or thermostat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Classification { get; set; }
        #endregion
        
        #region Parameter CredentialLockerId
        /// <summary>
        /// <para>
        /// <para>The identifier of the credential for the managed thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CredentialLockerId { get; set; }
        #endregion
        
        #region Parameter WiFiSimpleSetupConfiguration_EnableAsProvisionee
        /// <summary>
        /// <para>
        /// <para>Indicates whether the device can act as a provisionee in Wi-Fi Simple Setup, allowing
        /// it to be configured by other devices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WiFiSimpleSetupConfiguration_EnableAsProvisionee { get; set; }
        #endregion
        
        #region Parameter WiFiSimpleSetupConfiguration_EnableAsProvisioner
        /// <summary>
        /// <para>
        /// <para>Indicates whether the device can act as a provisioner in Wi-Fi Simple Setup, allowing
        /// it to configure other devices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WiFiSimpleSetupConfiguration_EnableAsProvisioner { get; set; }
        #endregion
        
        #region Parameter CapabilityReport_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoints used in the capability report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityReport_Endpoints")]
        public Amazon.IoTManagedIntegrations.Model.CapabilityReportEndpoint[] CapabilityReport_Endpoint { get; set; }
        #endregion
        
        #region Parameter HubNetworkMode
        /// <summary>
        /// <para>
        /// <para>The network mode for the hub-connected device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.HubNetworkMode")]
        public Amazon.IoTManagedIntegrations.HubNetworkMode HubNetworkMode { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The id of the managed thing.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter MetaData
        /// <summary>
        /// <para>
        /// <para>The metadata for the managed thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable MetaData { get; set; }
        #endregion
        
        #region Parameter Model
        /// <summary>
        /// <para>
        /// <para>The model of the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the managed thing representing the physical device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CapabilityReport_NodeId
        /// <summary>
        /// <para>
        /// <para>The numeric identifier of the node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CapabilityReport_NodeId { get; set; }
        #endregion
        
        #region Parameter SerialNumber
        /// <summary>
        /// <para>
        /// <para>The serial number of the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SerialNumber { get; set; }
        #endregion
        
        #region Parameter WiFiSimpleSetupConfiguration_TimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The timeout duration in minutes for Wi-Fi Simple Setup. Valid range is 5 to 15 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WiFiSimpleSetupConfiguration_TimeoutInMinutes")]
        public System.Int32? WiFiSimpleSetupConfiguration_TimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter CapabilityReport_Version
        /// <summary>
        /// <para>
        /// <para>The version of the capability report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CapabilityReport_Version { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>Owner of the device, usually an indication of whom the device belongs to. This value
        /// should not contain personal identifiable information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Owner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.UpdateManagedThingResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTMIManagedThing (UpdateManagedThing)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.UpdateManagedThingResponse, UpdateIOTMIManagedThingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Brand = this.Brand;
            context.Capability = this.Capability;
            if (this.CapabilityReport_Endpoint != null)
            {
                context.CapabilityReport_Endpoint = new List<Amazon.IoTManagedIntegrations.Model.CapabilityReportEndpoint>(this.CapabilityReport_Endpoint);
            }
            context.CapabilityReport_NodeId = this.CapabilityReport_NodeId;
            context.CapabilityReport_Version = this.CapabilityReport_Version;
            if (this.CapabilitySchema != null)
            {
                context.CapabilitySchema = new List<Amazon.IoTManagedIntegrations.Model.CapabilitySchemaItem>(this.CapabilitySchema);
            }
            context.Classification = this.Classification;
            context.CredentialLockerId = this.CredentialLockerId;
            context.HubNetworkMode = this.HubNetworkMode;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetaData != null)
            {
                context.MetaData = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.MetaData.Keys)
                {
                    context.MetaData.Add((String)hashKey, (System.String)(this.MetaData[hashKey]));
                }
            }
            context.Model = this.Model;
            context.Name = this.Name;
            context.Owner = this.Owner;
            context.SerialNumber = this.SerialNumber;
            context.WiFiSimpleSetupConfiguration_EnableAsProvisionee = this.WiFiSimpleSetupConfiguration_EnableAsProvisionee;
            context.WiFiSimpleSetupConfiguration_EnableAsProvisioner = this.WiFiSimpleSetupConfiguration_EnableAsProvisioner;
            context.WiFiSimpleSetupConfiguration_TimeoutInMinute = this.WiFiSimpleSetupConfiguration_TimeoutInMinute;
            
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
            var request = new Amazon.IoTManagedIntegrations.Model.UpdateManagedThingRequest();
            
            if (cmdletContext.Brand != null)
            {
                request.Brand = cmdletContext.Brand;
            }
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            
             // populate CapabilityReport
            var requestCapabilityReportIsNull = true;
            request.CapabilityReport = new Amazon.IoTManagedIntegrations.Model.CapabilityReport();
            List<Amazon.IoTManagedIntegrations.Model.CapabilityReportEndpoint> requestCapabilityReport_capabilityReport_Endpoint = null;
            if (cmdletContext.CapabilityReport_Endpoint != null)
            {
                requestCapabilityReport_capabilityReport_Endpoint = cmdletContext.CapabilityReport_Endpoint;
            }
            if (requestCapabilityReport_capabilityReport_Endpoint != null)
            {
                request.CapabilityReport.Endpoints = requestCapabilityReport_capabilityReport_Endpoint;
                requestCapabilityReportIsNull = false;
            }
            System.String requestCapabilityReport_capabilityReport_NodeId = null;
            if (cmdletContext.CapabilityReport_NodeId != null)
            {
                requestCapabilityReport_capabilityReport_NodeId = cmdletContext.CapabilityReport_NodeId;
            }
            if (requestCapabilityReport_capabilityReport_NodeId != null)
            {
                request.CapabilityReport.NodeId = requestCapabilityReport_capabilityReport_NodeId;
                requestCapabilityReportIsNull = false;
            }
            System.String requestCapabilityReport_capabilityReport_Version = null;
            if (cmdletContext.CapabilityReport_Version != null)
            {
                requestCapabilityReport_capabilityReport_Version = cmdletContext.CapabilityReport_Version;
            }
            if (requestCapabilityReport_capabilityReport_Version != null)
            {
                request.CapabilityReport.Version = requestCapabilityReport_capabilityReport_Version;
                requestCapabilityReportIsNull = false;
            }
             // determine if request.CapabilityReport should be set to null
            if (requestCapabilityReportIsNull)
            {
                request.CapabilityReport = null;
            }
            if (cmdletContext.CapabilitySchema != null)
            {
                request.CapabilitySchemas = cmdletContext.CapabilitySchema;
            }
            if (cmdletContext.Classification != null)
            {
                request.Classification = cmdletContext.Classification;
            }
            if (cmdletContext.CredentialLockerId != null)
            {
                request.CredentialLockerId = cmdletContext.CredentialLockerId;
            }
            if (cmdletContext.HubNetworkMode != null)
            {
                request.HubNetworkMode = cmdletContext.HubNetworkMode;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.MetaData != null)
            {
                request.MetaData = cmdletContext.MetaData;
            }
            if (cmdletContext.Model != null)
            {
                request.Model = cmdletContext.Model;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owner = cmdletContext.Owner;
            }
            if (cmdletContext.SerialNumber != null)
            {
                request.SerialNumber = cmdletContext.SerialNumber;
            }
            
             // populate WiFiSimpleSetupConfiguration
            var requestWiFiSimpleSetupConfigurationIsNull = true;
            request.WiFiSimpleSetupConfiguration = new Amazon.IoTManagedIntegrations.Model.WiFiSimpleSetupConfiguration();
            System.Boolean? requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_EnableAsProvisionee = null;
            if (cmdletContext.WiFiSimpleSetupConfiguration_EnableAsProvisionee != null)
            {
                requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_EnableAsProvisionee = cmdletContext.WiFiSimpleSetupConfiguration_EnableAsProvisionee.Value;
            }
            if (requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_EnableAsProvisionee != null)
            {
                request.WiFiSimpleSetupConfiguration.EnableAsProvisionee = requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_EnableAsProvisionee.Value;
                requestWiFiSimpleSetupConfigurationIsNull = false;
            }
            System.Boolean? requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_EnableAsProvisioner = null;
            if (cmdletContext.WiFiSimpleSetupConfiguration_EnableAsProvisioner != null)
            {
                requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_EnableAsProvisioner = cmdletContext.WiFiSimpleSetupConfiguration_EnableAsProvisioner.Value;
            }
            if (requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_EnableAsProvisioner != null)
            {
                request.WiFiSimpleSetupConfiguration.EnableAsProvisioner = requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_EnableAsProvisioner.Value;
                requestWiFiSimpleSetupConfigurationIsNull = false;
            }
            System.Int32? requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_TimeoutInMinute = null;
            if (cmdletContext.WiFiSimpleSetupConfiguration_TimeoutInMinute != null)
            {
                requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_TimeoutInMinute = cmdletContext.WiFiSimpleSetupConfiguration_TimeoutInMinute.Value;
            }
            if (requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_TimeoutInMinute != null)
            {
                request.WiFiSimpleSetupConfiguration.TimeoutInMinutes = requestWiFiSimpleSetupConfiguration_wiFiSimpleSetupConfiguration_TimeoutInMinute.Value;
                requestWiFiSimpleSetupConfigurationIsNull = false;
            }
             // determine if request.WiFiSimpleSetupConfiguration should be set to null
            if (requestWiFiSimpleSetupConfigurationIsNull)
            {
                request.WiFiSimpleSetupConfiguration = null;
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
        
        private Amazon.IoTManagedIntegrations.Model.UpdateManagedThingResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.UpdateManagedThingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "UpdateManagedThing");
            try
            {
                #if DESKTOP
                return client.UpdateManagedThing(request);
                #elif CORECLR
                return client.UpdateManagedThingAsync(request).GetAwaiter().GetResult();
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
            public System.String Brand { get; set; }
            public System.String Capability { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.CapabilityReportEndpoint> CapabilityReport_Endpoint { get; set; }
            public System.String CapabilityReport_NodeId { get; set; }
            public System.String CapabilityReport_Version { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.CapabilitySchemaItem> CapabilitySchema { get; set; }
            public System.String Classification { get; set; }
            public System.String CredentialLockerId { get; set; }
            public Amazon.IoTManagedIntegrations.HubNetworkMode HubNetworkMode { get; set; }
            public System.String Identifier { get; set; }
            public Dictionary<System.String, System.String> MetaData { get; set; }
            public System.String Model { get; set; }
            public System.String Name { get; set; }
            public System.String Owner { get; set; }
            public System.String SerialNumber { get; set; }
            public System.Boolean? WiFiSimpleSetupConfiguration_EnableAsProvisionee { get; set; }
            public System.Boolean? WiFiSimpleSetupConfiguration_EnableAsProvisioner { get; set; }
            public System.Int32? WiFiSimpleSetupConfiguration_TimeoutInMinute { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.UpdateManagedThingResponse, UpdateIOTMIManagedThingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
