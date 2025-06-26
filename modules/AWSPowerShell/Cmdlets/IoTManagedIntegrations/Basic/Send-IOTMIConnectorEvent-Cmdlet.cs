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
    /// Relays third-party device events for a connector such as a new device or a device
    /// state change event.
    /// </summary>
    [Cmdlet("Send", "IOTMIConnectorEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management SendConnectorEvent API operation.", Operation = new[] {"SendConnectorEvent"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.SendConnectorEventResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTManagedIntegrations.Model.SendConnectorEventResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTManagedIntegrations.Model.SendConnectorEventResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendIOTMIConnectorEventCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MatterEndpoint_Cluster
        /// <summary>
        /// <para>
        /// <para>A list of Matter clusters for a managed thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MatterEndpoint_Clusters")]
        public Amazon.IoTManagedIntegrations.Model.MatterCluster[] MatterEndpoint_Cluster { get; set; }
        #endregion
        
        #region Parameter ConnectorDeviceId
        /// <summary>
        /// <para>
        /// <para>The third-party device id as defined by the connector. This device id must not contain
        /// personal identifiable information (PII).</para><note><para>This parameter is used for cloud-to-cloud devices only.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorDeviceId { get; set; }
        #endregion
        
        #region Parameter ConnectorId
        /// <summary>
        /// <para>
        /// <para>The id of the connector between the third-party cloud provider and IoT managed integrations.</para>
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
        public System.String ConnectorId { get; set; }
        #endregion
        
        #region Parameter DeviceDiscoveryId
        /// <summary>
        /// <para>
        /// <para>The id for the device discovery job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceDiscoveryId { get; set; }
        #endregion
        
        #region Parameter Device
        /// <summary>
        /// <para>
        /// <para>The list of devices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Devices")]
        public Amazon.IoTManagedIntegrations.Model.Device[] Device { get; set; }
        #endregion
        
        #region Parameter MatterEndpoint_Id
        /// <summary>
        /// <para>
        /// <para>The Matter endpoint id.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MatterEndpoint_Id { get; set; }
        #endregion
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The device state change event payload.</para><para>This parameter will include the following three fields:</para><ul><li><para><c>uri</c>: <c>schema auc://&lt;PARTNER-DEVICE-ID&gt;/ResourcePath</c> (The <c>Resourcepath</c>
        /// corresponds to an OCF resource.)</para></li><li><para><c>op</c>: For device state changes, this field must populate as <c>n+d</c>.</para></li><li><para><c>cn</c>: The content depends on the OCF resource referenced in <c>ResourcePath</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Message { get; set; }
        #endregion
        
        #region Parameter Operation
        /// <summary>
        /// <para>
        /// <para>The Open Connectivity Foundation (OCF) operation requested to be performed on the
        /// managed thing.</para><note><para>The field op can have a value of "I" or "U". The field "cn" will contain the capability
        /// types.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.ConnectorEventOperation")]
        public Amazon.IoTManagedIntegrations.ConnectorEventOperation Operation { get; set; }
        #endregion
        
        #region Parameter OperationVersion
        /// <summary>
        /// <para>
        /// <para>The Open Connectivity Foundation (OCF) security specification version for the operation
        /// being requested on the managed thing. For more information, see <a href="https://openconnectivity.org/specs/OCF_Security_Specification_v1.0.0.pdf">OCF
        /// Security Specification</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationVersion { get; set; }
        #endregion
        
        #region Parameter StatusCode
        /// <summary>
        /// <para>
        /// <para>The status code of the Open Connectivity Foundation (OCF) operation being performed
        /// on the managed thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StatusCode { get; set; }
        #endregion
        
        #region Parameter TraceId
        /// <summary>
        /// <para>
        /// <para>The trace request identifier used to correlate a command request and response. This
        /// is specified by the device owner, but will be generated by IoT managed integrations
        /// if not provided by the device owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TraceId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The id of the third-party cloud provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.SendConnectorEventResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.SendConnectorEventResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectorId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-IOTMIConnectorEvent (SendConnectorEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.SendConnectorEventResponse, SendIOTMIConnectorEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectorDeviceId = this.ConnectorDeviceId;
            context.ConnectorId = this.ConnectorId;
            #if MODULAR
            if (this.ConnectorId == null && ParameterWasBound(nameof(this.ConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceDiscoveryId = this.DeviceDiscoveryId;
            if (this.Device != null)
            {
                context.Device = new List<Amazon.IoTManagedIntegrations.Model.Device>(this.Device);
            }
            if (this.MatterEndpoint_Cluster != null)
            {
                context.MatterEndpoint_Cluster = new List<Amazon.IoTManagedIntegrations.Model.MatterCluster>(this.MatterEndpoint_Cluster);
            }
            context.MatterEndpoint_Id = this.MatterEndpoint_Id;
            context.Message = this.Message;
            context.Operation = this.Operation;
            #if MODULAR
            if (this.Operation == null && ParameterWasBound(nameof(this.Operation)))
            {
                WriteWarning("You are passing $null as a value for parameter Operation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OperationVersion = this.OperationVersion;
            context.StatusCode = this.StatusCode;
            context.TraceId = this.TraceId;
            context.UserId = this.UserId;
            
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
            var request = new Amazon.IoTManagedIntegrations.Model.SendConnectorEventRequest();
            
            if (cmdletContext.ConnectorDeviceId != null)
            {
                request.ConnectorDeviceId = cmdletContext.ConnectorDeviceId;
            }
            if (cmdletContext.ConnectorId != null)
            {
                request.ConnectorId = cmdletContext.ConnectorId;
            }
            if (cmdletContext.DeviceDiscoveryId != null)
            {
                request.DeviceDiscoveryId = cmdletContext.DeviceDiscoveryId;
            }
            if (cmdletContext.Device != null)
            {
                request.Devices = cmdletContext.Device;
            }
            
             // populate MatterEndpoint
            var requestMatterEndpointIsNull = true;
            request.MatterEndpoint = new Amazon.IoTManagedIntegrations.Model.MatterEndpoint();
            List<Amazon.IoTManagedIntegrations.Model.MatterCluster> requestMatterEndpoint_matterEndpoint_Cluster = null;
            if (cmdletContext.MatterEndpoint_Cluster != null)
            {
                requestMatterEndpoint_matterEndpoint_Cluster = cmdletContext.MatterEndpoint_Cluster;
            }
            if (requestMatterEndpoint_matterEndpoint_Cluster != null)
            {
                request.MatterEndpoint.Clusters = requestMatterEndpoint_matterEndpoint_Cluster;
                requestMatterEndpointIsNull = false;
            }
            System.String requestMatterEndpoint_matterEndpoint_Id = null;
            if (cmdletContext.MatterEndpoint_Id != null)
            {
                requestMatterEndpoint_matterEndpoint_Id = cmdletContext.MatterEndpoint_Id;
            }
            if (requestMatterEndpoint_matterEndpoint_Id != null)
            {
                request.MatterEndpoint.Id = requestMatterEndpoint_matterEndpoint_Id;
                requestMatterEndpointIsNull = false;
            }
             // determine if request.MatterEndpoint should be set to null
            if (requestMatterEndpointIsNull)
            {
                request.MatterEndpoint = null;
            }
            if (cmdletContext.Message != null)
            {
                request.Message = cmdletContext.Message;
            }
            if (cmdletContext.Operation != null)
            {
                request.Operation = cmdletContext.Operation;
            }
            if (cmdletContext.OperationVersion != null)
            {
                request.OperationVersion = cmdletContext.OperationVersion;
            }
            if (cmdletContext.StatusCode != null)
            {
                request.StatusCode = cmdletContext.StatusCode.Value;
            }
            if (cmdletContext.TraceId != null)
            {
                request.TraceId = cmdletContext.TraceId;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.IoTManagedIntegrations.Model.SendConnectorEventResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.SendConnectorEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "SendConnectorEvent");
            try
            {
                #if DESKTOP
                return client.SendConnectorEvent(request);
                #elif CORECLR
                return client.SendConnectorEventAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectorDeviceId { get; set; }
            public System.String ConnectorId { get; set; }
            public System.String DeviceDiscoveryId { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.Device> Device { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.MatterCluster> MatterEndpoint_Cluster { get; set; }
            public System.String MatterEndpoint_Id { get; set; }
            public System.String Message { get; set; }
            public Amazon.IoTManagedIntegrations.ConnectorEventOperation Operation { get; set; }
            public System.String OperationVersion { get; set; }
            public System.Int32? StatusCode { get; set; }
            public System.String TraceId { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.SendConnectorEventResponse, SendIOTMIConnectorEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorId;
        }
        
    }
}
