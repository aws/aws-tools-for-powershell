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
using Amazon.IoTManagedIntegrations;
using Amazon.IoTManagedIntegrations.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTMI
{
    /// <summary>
    /// Creates a managed thing. A managed thing contains the device identifier, protocol
    /// supported, and capabilities of the device in a data model format defined by Managed
    /// integrations.
    /// </summary>
    [Cmdlet("New", "IOTMIManagedThing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTManagedIntegrations.Model.CreateManagedThingResponse")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management CreateManagedThing API operation.", Operation = new[] {"CreateManagedThing"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.CreateManagedThingResponse))]
    [AWSCmdletOutput("Amazon.IoTManagedIntegrations.Model.CreateManagedThingResponse",
        "This cmdlet returns an Amazon.IoTManagedIntegrations.Model.CreateManagedThingResponse object containing multiple properties."
    )]
    public partial class NewIOTMIManagedThingCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthenticationMaterial
        /// <summary>
        /// <para>
        /// <para>The authentication material defining the device connectivity setup requests. The authentication
        /// materials used are the device bar code.</para>
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
        public System.String AuthenticationMaterial { get; set; }
        #endregion
        
        #region Parameter AuthenticationMaterialType
        /// <summary>
        /// <para>
        /// <para>The type of authentication material used for device connectivity setup requests.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.AuthMaterialType")]
        public Amazon.IoTManagedIntegrations.AuthMaterialType AuthenticationMaterialType { get; set; }
        #endregion
        
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
        /// <para>The capability schemas that define the functionality and features supported by the
        /// managed thing, including device capabilities and their associated properties.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>The endpoints used in the capability report.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityReport_Endpoints")]
        public Amazon.IoTManagedIntegrations.Model.CapabilityReportEndpoint[] CapabilityReport_Endpoint { get; set; }
        #endregion
        
        #region Parameter MetaData
        /// <summary>
        /// <para>
        /// <para>The metadata for the managed thing.</para><note><para>The <c>managedThing</c><c>metadata</c> parameter is used for associating attributes
        /// with a <c>managedThing</c> that can be used for grouping over-the-air (OTA) tasks.
        /// Name value pairs in <c>metadata</c> can be used in the <c>OtaTargetQueryString</c>
        /// parameter for the <c>CreateOtaTask</c> API operation.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The type of device used. This will be the hub controller, cloud device, or AWS IoT
        /// device.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.Role")]
        public Amazon.IoTManagedIntegrations.Role Role { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of key/value pairs that are used to manage the managed thing.</para><para />
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token. If you retry a request that completed successfully initially
        /// using the same client token and parameters, then the retry attempt will succeed without
        /// performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.CreateManagedThingResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.CreateManagedThingResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTMIManagedThing (CreateManagedThing)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.CreateManagedThingResponse, NewIOTMIManagedThingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthenticationMaterial = this.AuthenticationMaterial;
            #if MODULAR
            if (this.AuthenticationMaterial == null && ParameterWasBound(nameof(this.AuthenticationMaterial)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationMaterial which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthenticationMaterialType = this.AuthenticationMaterialType;
            #if MODULAR
            if (this.AuthenticationMaterialType == null && ParameterWasBound(nameof(this.AuthenticationMaterialType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationMaterialType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.ClientToken = this.ClientToken;
            context.CredentialLockerId = this.CredentialLockerId;
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
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SerialNumber = this.SerialNumber;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.IoTManagedIntegrations.Model.CreateManagedThingRequest();
            
            if (cmdletContext.AuthenticationMaterial != null)
            {
                request.AuthenticationMaterial = cmdletContext.AuthenticationMaterial;
            }
            if (cmdletContext.AuthenticationMaterialType != null)
            {
                request.AuthenticationMaterialType = cmdletContext.AuthenticationMaterialType;
            }
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
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CredentialLockerId != null)
            {
                request.CredentialLockerId = cmdletContext.CredentialLockerId;
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
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.SerialNumber != null)
            {
                request.SerialNumber = cmdletContext.SerialNumber;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IoTManagedIntegrations.Model.CreateManagedThingResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.CreateManagedThingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "CreateManagedThing");
            try
            {
                return client.CreateManagedThingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AuthenticationMaterial { get; set; }
            public Amazon.IoTManagedIntegrations.AuthMaterialType AuthenticationMaterialType { get; set; }
            public System.String Brand { get; set; }
            public System.String Capability { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.CapabilityReportEndpoint> CapabilityReport_Endpoint { get; set; }
            public System.String CapabilityReport_NodeId { get; set; }
            public System.String CapabilityReport_Version { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.CapabilitySchemaItem> CapabilitySchema { get; set; }
            public System.String Classification { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CredentialLockerId { get; set; }
            public Dictionary<System.String, System.String> MetaData { get; set; }
            public System.String Model { get; set; }
            public System.String Name { get; set; }
            public System.String Owner { get; set; }
            public Amazon.IoTManagedIntegrations.Role Role { get; set; }
            public System.String SerialNumber { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Boolean? WiFiSimpleSetupConfiguration_EnableAsProvisionee { get; set; }
            public System.Boolean? WiFiSimpleSetupConfiguration_EnableAsProvisioner { get; set; }
            public System.Int32? WiFiSimpleSetupConfiguration_TimeoutInMinute { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.CreateManagedThingResponse, NewIOTMIManagedThingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
