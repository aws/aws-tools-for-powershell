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
using Amazon.NetworkMonitor;
using Amazon.NetworkMonitor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWNM
{
    /// <summary>
    /// Create a probe within a monitor. Once you create a probe, and it begins monitoring
    /// your network traffic, you'll incur billing charges for that probe. This action requires
    /// the <c>monitorName</c> parameter. Run <c>ListMonitors</c> to get a list of monitor
    /// names. Note the name of the <c>monitorName</c> you want to create the probe for.
    /// </summary>
    [Cmdlet("New", "CWNMProbe", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkMonitor.Model.CreateProbeResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Network Monitor CreateProbe API operation.", Operation = new[] {"CreateProbe"}, SelectReturnType = typeof(Amazon.NetworkMonitor.Model.CreateProbeResponse))]
    [AWSCmdletOutput("Amazon.NetworkMonitor.Model.CreateProbeResponse",
        "This cmdlet returns an Amazon.NetworkMonitor.Model.CreateProbeResponse object containing multiple properties."
    )]
    public partial class NewCWNMProbeCmdlet : AmazonNetworkMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Probe_Destination
        /// <summary>
        /// <para>
        /// <para>The destination IP address. This must be either <c>IPV4</c> or <c>IPV6</c>.</para>
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
        public System.String Probe_Destination { get; set; }
        #endregion
        
        #region Parameter Probe_DestinationPort
        /// <summary>
        /// <para>
        /// <para>The port associated with the <c>destination</c>. This is required only if the <c>protocol</c>
        /// is <c>TCP</c> and must be a number between <c>1</c> and <c>65536</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Probe_DestinationPort { get; set; }
        #endregion
        
        #region Parameter MonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the monitor to associated with the probe. </para>
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
        public System.String MonitorName { get; set; }
        #endregion
        
        #region Parameter Probe_PacketSize
        /// <summary>
        /// <para>
        /// <para>The size of the packets sent between the source and destination. This must be a number
        /// between <c>56</c> and <c>8500</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Probe_PacketSize { get; set; }
        #endregion
        
        #region Parameter Probe_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol used for the network traffic between the <c>source</c> and <c>destination</c>.
        /// This must be either <c>TCP</c> or <c>ICMP</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NetworkMonitor.Protocol")]
        public Amazon.NetworkMonitor.Protocol Probe_Protocol { get; set; }
        #endregion
        
        #region Parameter Probe_SourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the subnet.</para>
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
        public System.String Probe_SourceArn { get; set; }
        #endregion
        
        #region Parameter Probe_Tag
        /// <summary>
        /// <para>
        /// <para>The list of key-value pairs created and assigned to the monitor.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Probe_Tags")]
        public System.Collections.Hashtable Probe_Tag { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of key-value pairs created and assigned to the probe.</para><para />
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure the idempotency of the request. Only returned
        /// if a client token was provided in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkMonitor.Model.CreateProbeResponse).
        /// Specifying the name of a property of type Amazon.NetworkMonitor.Model.CreateProbeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MonitorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWNMProbe (CreateProbe)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkMonitor.Model.CreateProbeResponse, NewCWNMProbeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.MonitorName = this.MonitorName;
            #if MODULAR
            if (this.MonitorName == null && ParameterWasBound(nameof(this.MonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Probe_Destination = this.Probe_Destination;
            #if MODULAR
            if (this.Probe_Destination == null && ParameterWasBound(nameof(this.Probe_Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Probe_Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Probe_DestinationPort = this.Probe_DestinationPort;
            context.Probe_PacketSize = this.Probe_PacketSize;
            context.Probe_Protocol = this.Probe_Protocol;
            #if MODULAR
            if (this.Probe_Protocol == null && ParameterWasBound(nameof(this.Probe_Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Probe_Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Probe_SourceArn = this.Probe_SourceArn;
            #if MODULAR
            if (this.Probe_SourceArn == null && ParameterWasBound(nameof(this.Probe_SourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter Probe_SourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Probe_Tag != null)
            {
                context.Probe_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Probe_Tag.Keys)
                {
                    context.Probe_Tag.Add((String)hashKey, (System.String)(this.Probe_Tag[hashKey]));
                }
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
            var request = new Amazon.NetworkMonitor.Model.CreateProbeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MonitorName != null)
            {
                request.MonitorName = cmdletContext.MonitorName;
            }
            
             // populate Probe
            var requestProbeIsNull = true;
            request.Probe = new Amazon.NetworkMonitor.Model.ProbeInput();
            System.String requestProbe_probe_Destination = null;
            if (cmdletContext.Probe_Destination != null)
            {
                requestProbe_probe_Destination = cmdletContext.Probe_Destination;
            }
            if (requestProbe_probe_Destination != null)
            {
                request.Probe.Destination = requestProbe_probe_Destination;
                requestProbeIsNull = false;
            }
            System.Int32? requestProbe_probe_DestinationPort = null;
            if (cmdletContext.Probe_DestinationPort != null)
            {
                requestProbe_probe_DestinationPort = cmdletContext.Probe_DestinationPort.Value;
            }
            if (requestProbe_probe_DestinationPort != null)
            {
                request.Probe.DestinationPort = requestProbe_probe_DestinationPort.Value;
                requestProbeIsNull = false;
            }
            System.Int32? requestProbe_probe_PacketSize = null;
            if (cmdletContext.Probe_PacketSize != null)
            {
                requestProbe_probe_PacketSize = cmdletContext.Probe_PacketSize.Value;
            }
            if (requestProbe_probe_PacketSize != null)
            {
                request.Probe.PacketSize = requestProbe_probe_PacketSize.Value;
                requestProbeIsNull = false;
            }
            Amazon.NetworkMonitor.Protocol requestProbe_probe_Protocol = null;
            if (cmdletContext.Probe_Protocol != null)
            {
                requestProbe_probe_Protocol = cmdletContext.Probe_Protocol;
            }
            if (requestProbe_probe_Protocol != null)
            {
                request.Probe.Protocol = requestProbe_probe_Protocol;
                requestProbeIsNull = false;
            }
            System.String requestProbe_probe_SourceArn = null;
            if (cmdletContext.Probe_SourceArn != null)
            {
                requestProbe_probe_SourceArn = cmdletContext.Probe_SourceArn;
            }
            if (requestProbe_probe_SourceArn != null)
            {
                request.Probe.SourceArn = requestProbe_probe_SourceArn;
                requestProbeIsNull = false;
            }
            Dictionary<System.String, System.String> requestProbe_probe_Tag = null;
            if (cmdletContext.Probe_Tag != null)
            {
                requestProbe_probe_Tag = cmdletContext.Probe_Tag;
            }
            if (requestProbe_probe_Tag != null)
            {
                request.Probe.Tags = requestProbe_probe_Tag;
                requestProbeIsNull = false;
            }
             // determine if request.Probe should be set to null
            if (requestProbeIsNull)
            {
                request.Probe = null;
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
        
        private Amazon.NetworkMonitor.Model.CreateProbeResponse CallAWSServiceOperation(IAmazonNetworkMonitor client, Amazon.NetworkMonitor.Model.CreateProbeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Network Monitor", "CreateProbe");
            try
            {
                return client.CreateProbeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String MonitorName { get; set; }
            public System.String Probe_Destination { get; set; }
            public System.Int32? Probe_DestinationPort { get; set; }
            public System.Int32? Probe_PacketSize { get; set; }
            public Amazon.NetworkMonitor.Protocol Probe_Protocol { get; set; }
            public System.String Probe_SourceArn { get; set; }
            public Dictionary<System.String, System.String> Probe_Tag { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.NetworkMonitor.Model.CreateProbeResponse, NewCWNMProbeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
