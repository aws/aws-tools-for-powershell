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
    /// This API is used to start device discovery for hub-connected and third-party-connected
    /// devices. The authentication material (install code) is delivered as a message to the
    /// controller instructing it to start the discovery.
    /// </summary>
    [Cmdlet("Start", "IOTMIDeviceDiscovery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management StartDeviceDiscovery API operation.", Operation = new[] {"StartDeviceDiscovery"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse))]
    [AWSCmdletOutput("Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse",
        "This cmdlet returns an Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse object containing multiple properties."
    )]
    public partial class StartIOTMIDeviceDiscoveryCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountAssociationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the cloud-to-cloud account association to use for discovery of third-party
        /// devices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountAssociationId { get; set; }
        #endregion
        
        #region Parameter AuthenticationMaterial
        /// <summary>
        /// <para>
        /// <para>The authentication material required to start the local device discovery job request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthenticationMaterial { get; set; }
        #endregion
        
        #region Parameter AuthenticationMaterialType
        /// <summary>
        /// <para>
        /// <para>The type of authentication material used for device discovery jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.DiscoveryAuthMaterialType")]
        public Amazon.IoTManagedIntegrations.DiscoveryAuthMaterialType AuthenticationMaterialType { get; set; }
        #endregion
        
        #region Parameter ControllerIdentifier
        /// <summary>
        /// <para>
        /// <para>The id of the end-user's IoT hub.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ControllerIdentifier { get; set; }
        #endregion
        
        #region Parameter CustomProtocolDetail
        /// <summary>
        /// <para>
        /// <para>Additional protocol-specific details required for device discovery, which vary based
        /// on the discovery type.</para><note><para>For a <c>DiscoveryType</c> of <c>CUSTOM</c>, the string-to-string map must have a
        /// key value of <c>Name</c> set to a non-empty-string.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable CustomProtocolDetail { get; set; }
        #endregion
        
        #region Parameter DiscoveryType
        /// <summary>
        /// <para>
        /// <para>The discovery type supporting the type of device to be discovered in the device discovery
        /// task request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.DiscoveryType")]
        public Amazon.IoTManagedIntegrations.DiscoveryType DiscoveryType { get; set; }
        #endregion
        
        #region Parameter EndDeviceIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique id of the end device for capability rediscovery.</para><note><para>This parameter is only available when the discovery type is CONTROLLER_CAPABILITY_REDISCOVERY.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndDeviceIdentifier { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol type for capability rediscovery (ZWAVE, ZIGBEE, or CUSTOM).</para><note><para>This parameter is only available when the discovery type is CONTROLLER_CAPABILITY_REDISCOVERY.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.ProtocolType")]
        public Amazon.IoTManagedIntegrations.ProtocolType Protocol { get; set; }
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
        
        #region Parameter ConnectorAssociationIdentifier
        /// <summary>
        /// <para>
        /// <para>The id of the connector association.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("ConnectorAssociationIdentifier is deprecated")]
        public System.String ConnectorAssociationIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of key/value pairs that are used to manage the device discovery request.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Tags have been deprecated from this api")]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DiscoveryType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DiscoveryType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DiscoveryType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DiscoveryType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTMIDeviceDiscovery (StartDeviceDiscovery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse, StartIOTMIDeviceDiscoveryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DiscoveryType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountAssociationId = this.AccountAssociationId;
            context.AuthenticationMaterial = this.AuthenticationMaterial;
            context.AuthenticationMaterialType = this.AuthenticationMaterialType;
            context.ClientToken = this.ClientToken;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectorAssociationIdentifier = this.ConnectorAssociationIdentifier;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ControllerIdentifier = this.ControllerIdentifier;
            if (this.CustomProtocolDetail != null)
            {
                context.CustomProtocolDetail = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomProtocolDetail.Keys)
                {
                    context.CustomProtocolDetail.Add((String)hashKey, (System.String)(this.CustomProtocolDetail[hashKey]));
                }
            }
            context.DiscoveryType = this.DiscoveryType;
            #if MODULAR
            if (this.DiscoveryType == null && ParameterWasBound(nameof(this.DiscoveryType)))
            {
                WriteWarning("You are passing $null as a value for parameter DiscoveryType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndDeviceIdentifier = this.EndDeviceIdentifier;
            context.Protocol = this.Protocol;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryRequest();
            
            if (cmdletContext.AccountAssociationId != null)
            {
                request.AccountAssociationId = cmdletContext.AccountAssociationId;
            }
            if (cmdletContext.AuthenticationMaterial != null)
            {
                request.AuthenticationMaterial = cmdletContext.AuthenticationMaterial;
            }
            if (cmdletContext.AuthenticationMaterialType != null)
            {
                request.AuthenticationMaterialType = cmdletContext.AuthenticationMaterialType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ConnectorAssociationIdentifier != null)
            {
                request.ConnectorAssociationIdentifier = cmdletContext.ConnectorAssociationIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ControllerIdentifier != null)
            {
                request.ControllerIdentifier = cmdletContext.ControllerIdentifier;
            }
            if (cmdletContext.CustomProtocolDetail != null)
            {
                request.CustomProtocolDetail = cmdletContext.CustomProtocolDetail;
            }
            if (cmdletContext.DiscoveryType != null)
            {
                request.DiscoveryType = cmdletContext.DiscoveryType;
            }
            if (cmdletContext.EndDeviceIdentifier != null)
            {
                request.EndDeviceIdentifier = cmdletContext.EndDeviceIdentifier;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "StartDeviceDiscovery");
            try
            {
                #if DESKTOP
                return client.StartDeviceDiscovery(request);
                #elif CORECLR
                return client.StartDeviceDiscoveryAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountAssociationId { get; set; }
            public System.String AuthenticationMaterial { get; set; }
            public Amazon.IoTManagedIntegrations.DiscoveryAuthMaterialType AuthenticationMaterialType { get; set; }
            public System.String ClientToken { get; set; }
            [System.ObsoleteAttribute]
            public System.String ConnectorAssociationIdentifier { get; set; }
            public System.String ControllerIdentifier { get; set; }
            public Dictionary<System.String, System.String> CustomProtocolDetail { get; set; }
            public Amazon.IoTManagedIntegrations.DiscoveryType DiscoveryType { get; set; }
            public System.String EndDeviceIdentifier { get; set; }
            public Amazon.IoTManagedIntegrations.ProtocolType Protocol { get; set; }
            [System.ObsoleteAttribute]
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse, StartIOTMIDeviceDiscoveryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
