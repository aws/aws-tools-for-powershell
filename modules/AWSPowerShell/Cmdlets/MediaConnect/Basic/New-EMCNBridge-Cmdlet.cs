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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Creates a new bridge. The request must include one source.
    /// </summary>
    [Cmdlet("New", "EMCNBridge", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Bridge")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect CreateBridge API operation.", Operation = new[] {"CreateBridge"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.CreateBridgeResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Bridge or Amazon.MediaConnect.Model.CreateBridgeResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.Bridge object.",
        "The service call response (type Amazon.MediaConnect.Model.CreateBridgeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEMCNBridgeCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SourceFailoverConfig_FailoverMode
        /// <summary>
        /// <para>
        /// The type of failover you choose for this
        /// flow. MERGE combines the source streams into a single stream, allowing graceful recovery
        /// from any single-source loss. FAILOVER allows switching between different streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.FailoverMode")]
        public Amazon.MediaConnect.FailoverMode SourceFailoverConfig_FailoverMode { get; set; }
        #endregion
        
        #region Parameter EgressGatewayBridge_MaxBitrate
        /// <summary>
        /// <para>
        /// The maximum expected bitrate (in bps).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EgressGatewayBridge_MaxBitrate { get; set; }
        #endregion
        
        #region Parameter IngressGatewayBridge_MaxBitrate
        /// <summary>
        /// <para>
        /// The maximum expected bitrate (in bps).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IngressGatewayBridge_MaxBitrate { get; set; }
        #endregion
        
        #region Parameter IngressGatewayBridge_MaxOutput
        /// <summary>
        /// <para>
        /// The maximum number of expected outputs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IngressGatewayBridge_MaxOutputs")]
        public System.Int32? IngressGatewayBridge_MaxOutput { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the bridge. This name can not be modified
        /// after the bridge is created.
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// The outputs that you want to add to this bridge.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Outputs")]
        public Amazon.MediaConnect.Model.AddBridgeOutputRequest[] Output { get; set; }
        #endregion
        
        #region Parameter PlacementArn
        /// <summary>
        /// <para>
        /// The bridge placement Amazon Resource Number
        /// (ARN).
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
        public System.String PlacementArn { get; set; }
        #endregion
        
        #region Parameter SourcePriority_PrimarySource
        /// <summary>
        /// <para>
        /// The name of the source you choose as the
        /// primary source for this flow.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFailoverConfig_SourcePriority_PrimarySource")]
        public System.String SourcePriority_PrimarySource { get; set; }
        #endregion
        
        #region Parameter SourceFailoverConfig_RecoveryWindow
        /// <summary>
        /// <para>
        /// Search window time to look for dash-7 packets
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SourceFailoverConfig_RecoveryWindow { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// The sources that you want to add to this bridge.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Sources")]
        public Amazon.MediaConnect.Model.AddBridgeSourceRequest[] Source { get; set; }
        #endregion
        
        #region Parameter SourceFailoverConfig_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.State")]
        public Amazon.MediaConnect.State SourceFailoverConfig_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Bridge'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.CreateBridgeResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.CreateBridgeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Bridge";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PlacementArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PlacementArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PlacementArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMCNBridge (CreateBridge)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.CreateBridgeResponse, NewEMCNBridgeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PlacementArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EgressGatewayBridge_MaxBitrate = this.EgressGatewayBridge_MaxBitrate;
            context.IngressGatewayBridge_MaxBitrate = this.IngressGatewayBridge_MaxBitrate;
            context.IngressGatewayBridge_MaxOutput = this.IngressGatewayBridge_MaxOutput;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Output != null)
            {
                context.Output = new List<Amazon.MediaConnect.Model.AddBridgeOutputRequest>(this.Output);
            }
            context.PlacementArn = this.PlacementArn;
            #if MODULAR
            if (this.PlacementArn == null && ParameterWasBound(nameof(this.PlacementArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PlacementArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceFailoverConfig_FailoverMode = this.SourceFailoverConfig_FailoverMode;
            context.SourceFailoverConfig_RecoveryWindow = this.SourceFailoverConfig_RecoveryWindow;
            context.SourcePriority_PrimarySource = this.SourcePriority_PrimarySource;
            context.SourceFailoverConfig_State = this.SourceFailoverConfig_State;
            if (this.Source != null)
            {
                context.Source = new List<Amazon.MediaConnect.Model.AddBridgeSourceRequest>(this.Source);
            }
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.MediaConnect.Model.CreateBridgeRequest();
            
            
             // populate EgressGatewayBridge
            var requestEgressGatewayBridgeIsNull = true;
            request.EgressGatewayBridge = new Amazon.MediaConnect.Model.AddEgressGatewayBridgeRequest();
            System.Int32? requestEgressGatewayBridge_egressGatewayBridge_MaxBitrate = null;
            if (cmdletContext.EgressGatewayBridge_MaxBitrate != null)
            {
                requestEgressGatewayBridge_egressGatewayBridge_MaxBitrate = cmdletContext.EgressGatewayBridge_MaxBitrate.Value;
            }
            if (requestEgressGatewayBridge_egressGatewayBridge_MaxBitrate != null)
            {
                request.EgressGatewayBridge.MaxBitrate = requestEgressGatewayBridge_egressGatewayBridge_MaxBitrate.Value;
                requestEgressGatewayBridgeIsNull = false;
            }
             // determine if request.EgressGatewayBridge should be set to null
            if (requestEgressGatewayBridgeIsNull)
            {
                request.EgressGatewayBridge = null;
            }
            
             // populate IngressGatewayBridge
            var requestIngressGatewayBridgeIsNull = true;
            request.IngressGatewayBridge = new Amazon.MediaConnect.Model.AddIngressGatewayBridgeRequest();
            System.Int32? requestIngressGatewayBridge_ingressGatewayBridge_MaxBitrate = null;
            if (cmdletContext.IngressGatewayBridge_MaxBitrate != null)
            {
                requestIngressGatewayBridge_ingressGatewayBridge_MaxBitrate = cmdletContext.IngressGatewayBridge_MaxBitrate.Value;
            }
            if (requestIngressGatewayBridge_ingressGatewayBridge_MaxBitrate != null)
            {
                request.IngressGatewayBridge.MaxBitrate = requestIngressGatewayBridge_ingressGatewayBridge_MaxBitrate.Value;
                requestIngressGatewayBridgeIsNull = false;
            }
            System.Int32? requestIngressGatewayBridge_ingressGatewayBridge_MaxOutput = null;
            if (cmdletContext.IngressGatewayBridge_MaxOutput != null)
            {
                requestIngressGatewayBridge_ingressGatewayBridge_MaxOutput = cmdletContext.IngressGatewayBridge_MaxOutput.Value;
            }
            if (requestIngressGatewayBridge_ingressGatewayBridge_MaxOutput != null)
            {
                request.IngressGatewayBridge.MaxOutputs = requestIngressGatewayBridge_ingressGatewayBridge_MaxOutput.Value;
                requestIngressGatewayBridgeIsNull = false;
            }
             // determine if request.IngressGatewayBridge should be set to null
            if (requestIngressGatewayBridgeIsNull)
            {
                request.IngressGatewayBridge = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Output != null)
            {
                request.Outputs = cmdletContext.Output;
            }
            if (cmdletContext.PlacementArn != null)
            {
                request.PlacementArn = cmdletContext.PlacementArn;
            }
            
             // populate SourceFailoverConfig
            var requestSourceFailoverConfigIsNull = true;
            request.SourceFailoverConfig = new Amazon.MediaConnect.Model.FailoverConfig();
            Amazon.MediaConnect.FailoverMode requestSourceFailoverConfig_sourceFailoverConfig_FailoverMode = null;
            if (cmdletContext.SourceFailoverConfig_FailoverMode != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_FailoverMode = cmdletContext.SourceFailoverConfig_FailoverMode;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_FailoverMode != null)
            {
                request.SourceFailoverConfig.FailoverMode = requestSourceFailoverConfig_sourceFailoverConfig_FailoverMode;
                requestSourceFailoverConfigIsNull = false;
            }
            System.Int32? requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow = null;
            if (cmdletContext.SourceFailoverConfig_RecoveryWindow != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow = cmdletContext.SourceFailoverConfig_RecoveryWindow.Value;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow != null)
            {
                request.SourceFailoverConfig.RecoveryWindow = requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow.Value;
                requestSourceFailoverConfigIsNull = false;
            }
            Amazon.MediaConnect.State requestSourceFailoverConfig_sourceFailoverConfig_State = null;
            if (cmdletContext.SourceFailoverConfig_State != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_State = cmdletContext.SourceFailoverConfig_State;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_State != null)
            {
                request.SourceFailoverConfig.State = requestSourceFailoverConfig_sourceFailoverConfig_State;
                requestSourceFailoverConfigIsNull = false;
            }
            Amazon.MediaConnect.Model.SourcePriority requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority = null;
            
             // populate SourcePriority
            var requestSourceFailoverConfig_sourceFailoverConfig_SourcePriorityIsNull = true;
            requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority = new Amazon.MediaConnect.Model.SourcePriority();
            System.String requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority_sourcePriority_PrimarySource = null;
            if (cmdletContext.SourcePriority_PrimarySource != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority_sourcePriority_PrimarySource = cmdletContext.SourcePriority_PrimarySource;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority_sourcePriority_PrimarySource != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority.PrimarySource = requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority_sourcePriority_PrimarySource;
                requestSourceFailoverConfig_sourceFailoverConfig_SourcePriorityIsNull = false;
            }
             // determine if requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority should be set to null
            if (requestSourceFailoverConfig_sourceFailoverConfig_SourcePriorityIsNull)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority = null;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority != null)
            {
                request.SourceFailoverConfig.SourcePriority = requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority;
                requestSourceFailoverConfigIsNull = false;
            }
             // determine if request.SourceFailoverConfig should be set to null
            if (requestSourceFailoverConfigIsNull)
            {
                request.SourceFailoverConfig = null;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
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
        
        private Amazon.MediaConnect.Model.CreateBridgeResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.CreateBridgeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "CreateBridge");
            try
            {
                #if DESKTOP
                return client.CreateBridge(request);
                #elif CORECLR
                return client.CreateBridgeAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? EgressGatewayBridge_MaxBitrate { get; set; }
            public System.Int32? IngressGatewayBridge_MaxBitrate { get; set; }
            public System.Int32? IngressGatewayBridge_MaxOutput { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.MediaConnect.Model.AddBridgeOutputRequest> Output { get; set; }
            public System.String PlacementArn { get; set; }
            public Amazon.MediaConnect.FailoverMode SourceFailoverConfig_FailoverMode { get; set; }
            public System.Int32? SourceFailoverConfig_RecoveryWindow { get; set; }
            public System.String SourcePriority_PrimarySource { get; set; }
            public Amazon.MediaConnect.State SourceFailoverConfig_State { get; set; }
            public List<Amazon.MediaConnect.Model.AddBridgeSourceRequest> Source { get; set; }
            public System.Func<Amazon.MediaConnect.Model.CreateBridgeResponse, NewEMCNBridgeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Bridge;
        }
        
    }
}
