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
    /// During user-guided setup, this is used to start device discovery. The authentication
    /// material (install code) is passed as a message to the controller telling it to start
    /// the discovery.
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
        
        #region Parameter ConnectorAssociationIdentifier
        /// <summary>
        /// <para>
        /// <para>The id of the connector association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAssociationIdentifier { get; set; }
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
        
        #region Parameter DiscoveryType
        /// <summary>
        /// <para>
        /// <para>The discovery type supporting the type of device to be discovered in the device discovery
        /// job request.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of key/value pairs that are used to manage the device discovery request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
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
            context.AuthenticationMaterial = this.AuthenticationMaterial;
            context.AuthenticationMaterialType = this.AuthenticationMaterialType;
            context.ClientToken = this.ClientToken;
            context.ConnectorAssociationIdentifier = this.ConnectorAssociationIdentifier;
            context.ControllerIdentifier = this.ControllerIdentifier;
            context.DiscoveryType = this.DiscoveryType;
            #if MODULAR
            if (this.DiscoveryType == null && ParameterWasBound(nameof(this.DiscoveryType)))
            {
                WriteWarning("You are passing $null as a value for parameter DiscoveryType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryRequest();
            
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
            if (cmdletContext.ConnectorAssociationIdentifier != null)
            {
                request.ConnectorAssociationIdentifier = cmdletContext.ConnectorAssociationIdentifier;
            }
            if (cmdletContext.ControllerIdentifier != null)
            {
                request.ControllerIdentifier = cmdletContext.ControllerIdentifier;
            }
            if (cmdletContext.DiscoveryType != null)
            {
                request.DiscoveryType = cmdletContext.DiscoveryType;
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
            public System.String AuthenticationMaterial { get; set; }
            public Amazon.IoTManagedIntegrations.DiscoveryAuthMaterialType AuthenticationMaterialType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ConnectorAssociationIdentifier { get; set; }
            public System.String ControllerIdentifier { get; set; }
            public Amazon.IoTManagedIntegrations.DiscoveryType DiscoveryType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.StartDeviceDiscoveryResponse, StartIOTMIDeviceDiscoveryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
