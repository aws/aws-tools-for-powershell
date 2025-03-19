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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Updates an existing bridge source.
    /// </summary>
    [Cmdlet("Update", "EMCNBridgeSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.UpdateBridgeSourceResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateBridgeSource API operation.", Operation = new[] {"UpdateBridgeSource"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateBridgeSourceResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.UpdateBridgeSourceResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.UpdateBridgeSourceResponse object containing multiple properties."
    )]
    public partial class UpdateEMCNBridgeSourceCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BridgeArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the bridge that you want to update.</para>
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
        public System.String BridgeArn { get; set; }
        #endregion
        
        #region Parameter FlowSource_FlowArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) that identifies the MediaConnect resource from which
        /// to delete tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowSource_FlowArn { get; set; }
        #endregion
        
        #region Parameter NetworkSource_MulticastIp
        /// <summary>
        /// <para>
        /// <para> The network source multicast IP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkSource_MulticastIp { get; set; }
        #endregion
        
        #region Parameter MulticastSourceSettings_MulticastSourceIp
        /// <summary>
        /// <para>
        /// <para> The IP address of the source for source-specific multicast (SSM).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkSource_MulticastSourceSettings_MulticastSourceIp")]
        public System.String MulticastSourceSettings_MulticastSourceIp { get; set; }
        #endregion
        
        #region Parameter NetworkSource_NetworkName
        /// <summary>
        /// <para>
        /// <para>The network source's gateway network name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkSource_NetworkName { get; set; }
        #endregion
        
        #region Parameter NetworkSource_Port
        /// <summary>
        /// <para>
        /// <para>The network source port. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NetworkSource_Port { get; set; }
        #endregion
        
        #region Parameter NetworkSource_Protocol
        /// <summary>
        /// <para>
        /// <para>The network source protocol. </para><note><para>Elemental MediaConnect no longer supports the Fujitsu QoS protocol. This reference
        /// is maintained for legacy purposes only.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.Protocol")]
        public Amazon.MediaConnect.Protocol NetworkSource_Protocol { get; set; }
        #endregion
        
        #region Parameter SourceName
        /// <summary>
        /// <para>
        /// <para> The name of the source that you want to update. </para>
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
        public System.String SourceName { get; set; }
        #endregion
        
        #region Parameter FlowVpcInterfaceAttachment_VpcInterfaceName
        /// <summary>
        /// <para>
        /// <para> The name of the VPC interface to use for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowSource_FlowVpcInterfaceAttachment_VpcInterfaceName")]
        public System.String FlowVpcInterfaceAttachment_VpcInterfaceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateBridgeSourceResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateBridgeSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BridgeArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BridgeArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BridgeArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNBridgeSource (UpdateBridgeSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateBridgeSourceResponse, UpdateEMCNBridgeSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BridgeArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BridgeArn = this.BridgeArn;
            #if MODULAR
            if (this.BridgeArn == null && ParameterWasBound(nameof(this.BridgeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BridgeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FlowSource_FlowArn = this.FlowSource_FlowArn;
            context.FlowVpcInterfaceAttachment_VpcInterfaceName = this.FlowVpcInterfaceAttachment_VpcInterfaceName;
            context.NetworkSource_MulticastIp = this.NetworkSource_MulticastIp;
            context.MulticastSourceSettings_MulticastSourceIp = this.MulticastSourceSettings_MulticastSourceIp;
            context.NetworkSource_NetworkName = this.NetworkSource_NetworkName;
            context.NetworkSource_Port = this.NetworkSource_Port;
            context.NetworkSource_Protocol = this.NetworkSource_Protocol;
            context.SourceName = this.SourceName;
            #if MODULAR
            if (this.SourceName == null && ParameterWasBound(nameof(this.SourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaConnect.Model.UpdateBridgeSourceRequest();
            
            if (cmdletContext.BridgeArn != null)
            {
                request.BridgeArn = cmdletContext.BridgeArn;
            }
            
             // populate FlowSource
            var requestFlowSourceIsNull = true;
            request.FlowSource = new Amazon.MediaConnect.Model.UpdateBridgeFlowSourceRequest();
            System.String requestFlowSource_flowSource_FlowArn = null;
            if (cmdletContext.FlowSource_FlowArn != null)
            {
                requestFlowSource_flowSource_FlowArn = cmdletContext.FlowSource_FlowArn;
            }
            if (requestFlowSource_flowSource_FlowArn != null)
            {
                request.FlowSource.FlowArn = requestFlowSource_flowSource_FlowArn;
                requestFlowSourceIsNull = false;
            }
            Amazon.MediaConnect.Model.VpcInterfaceAttachment requestFlowSource_flowSource_FlowVpcInterfaceAttachment = null;
            
             // populate FlowVpcInterfaceAttachment
            var requestFlowSource_flowSource_FlowVpcInterfaceAttachmentIsNull = true;
            requestFlowSource_flowSource_FlowVpcInterfaceAttachment = new Amazon.MediaConnect.Model.VpcInterfaceAttachment();
            System.String requestFlowSource_flowSource_FlowVpcInterfaceAttachment_flowVpcInterfaceAttachment_VpcInterfaceName = null;
            if (cmdletContext.FlowVpcInterfaceAttachment_VpcInterfaceName != null)
            {
                requestFlowSource_flowSource_FlowVpcInterfaceAttachment_flowVpcInterfaceAttachment_VpcInterfaceName = cmdletContext.FlowVpcInterfaceAttachment_VpcInterfaceName;
            }
            if (requestFlowSource_flowSource_FlowVpcInterfaceAttachment_flowVpcInterfaceAttachment_VpcInterfaceName != null)
            {
                requestFlowSource_flowSource_FlowVpcInterfaceAttachment.VpcInterfaceName = requestFlowSource_flowSource_FlowVpcInterfaceAttachment_flowVpcInterfaceAttachment_VpcInterfaceName;
                requestFlowSource_flowSource_FlowVpcInterfaceAttachmentIsNull = false;
            }
             // determine if requestFlowSource_flowSource_FlowVpcInterfaceAttachment should be set to null
            if (requestFlowSource_flowSource_FlowVpcInterfaceAttachmentIsNull)
            {
                requestFlowSource_flowSource_FlowVpcInterfaceAttachment = null;
            }
            if (requestFlowSource_flowSource_FlowVpcInterfaceAttachment != null)
            {
                request.FlowSource.FlowVpcInterfaceAttachment = requestFlowSource_flowSource_FlowVpcInterfaceAttachment;
                requestFlowSourceIsNull = false;
            }
             // determine if request.FlowSource should be set to null
            if (requestFlowSourceIsNull)
            {
                request.FlowSource = null;
            }
            
             // populate NetworkSource
            var requestNetworkSourceIsNull = true;
            request.NetworkSource = new Amazon.MediaConnect.Model.UpdateBridgeNetworkSourceRequest();
            System.String requestNetworkSource_networkSource_MulticastIp = null;
            if (cmdletContext.NetworkSource_MulticastIp != null)
            {
                requestNetworkSource_networkSource_MulticastIp = cmdletContext.NetworkSource_MulticastIp;
            }
            if (requestNetworkSource_networkSource_MulticastIp != null)
            {
                request.NetworkSource.MulticastIp = requestNetworkSource_networkSource_MulticastIp;
                requestNetworkSourceIsNull = false;
            }
            System.String requestNetworkSource_networkSource_NetworkName = null;
            if (cmdletContext.NetworkSource_NetworkName != null)
            {
                requestNetworkSource_networkSource_NetworkName = cmdletContext.NetworkSource_NetworkName;
            }
            if (requestNetworkSource_networkSource_NetworkName != null)
            {
                request.NetworkSource.NetworkName = requestNetworkSource_networkSource_NetworkName;
                requestNetworkSourceIsNull = false;
            }
            System.Int32? requestNetworkSource_networkSource_Port = null;
            if (cmdletContext.NetworkSource_Port != null)
            {
                requestNetworkSource_networkSource_Port = cmdletContext.NetworkSource_Port.Value;
            }
            if (requestNetworkSource_networkSource_Port != null)
            {
                request.NetworkSource.Port = requestNetworkSource_networkSource_Port.Value;
                requestNetworkSourceIsNull = false;
            }
            Amazon.MediaConnect.Protocol requestNetworkSource_networkSource_Protocol = null;
            if (cmdletContext.NetworkSource_Protocol != null)
            {
                requestNetworkSource_networkSource_Protocol = cmdletContext.NetworkSource_Protocol;
            }
            if (requestNetworkSource_networkSource_Protocol != null)
            {
                request.NetworkSource.Protocol = requestNetworkSource_networkSource_Protocol;
                requestNetworkSourceIsNull = false;
            }
            Amazon.MediaConnect.Model.MulticastSourceSettings requestNetworkSource_networkSource_MulticastSourceSettings = null;
            
             // populate MulticastSourceSettings
            var requestNetworkSource_networkSource_MulticastSourceSettingsIsNull = true;
            requestNetworkSource_networkSource_MulticastSourceSettings = new Amazon.MediaConnect.Model.MulticastSourceSettings();
            System.String requestNetworkSource_networkSource_MulticastSourceSettings_multicastSourceSettings_MulticastSourceIp = null;
            if (cmdletContext.MulticastSourceSettings_MulticastSourceIp != null)
            {
                requestNetworkSource_networkSource_MulticastSourceSettings_multicastSourceSettings_MulticastSourceIp = cmdletContext.MulticastSourceSettings_MulticastSourceIp;
            }
            if (requestNetworkSource_networkSource_MulticastSourceSettings_multicastSourceSettings_MulticastSourceIp != null)
            {
                requestNetworkSource_networkSource_MulticastSourceSettings.MulticastSourceIp = requestNetworkSource_networkSource_MulticastSourceSettings_multicastSourceSettings_MulticastSourceIp;
                requestNetworkSource_networkSource_MulticastSourceSettingsIsNull = false;
            }
             // determine if requestNetworkSource_networkSource_MulticastSourceSettings should be set to null
            if (requestNetworkSource_networkSource_MulticastSourceSettingsIsNull)
            {
                requestNetworkSource_networkSource_MulticastSourceSettings = null;
            }
            if (requestNetworkSource_networkSource_MulticastSourceSettings != null)
            {
                request.NetworkSource.MulticastSourceSettings = requestNetworkSource_networkSource_MulticastSourceSettings;
                requestNetworkSourceIsNull = false;
            }
             // determine if request.NetworkSource should be set to null
            if (requestNetworkSourceIsNull)
            {
                request.NetworkSource = null;
            }
            if (cmdletContext.SourceName != null)
            {
                request.SourceName = cmdletContext.SourceName;
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
        
        private Amazon.MediaConnect.Model.UpdateBridgeSourceResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateBridgeSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateBridgeSource");
            try
            {
                #if DESKTOP
                return client.UpdateBridgeSource(request);
                #elif CORECLR
                return client.UpdateBridgeSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String BridgeArn { get; set; }
            public System.String FlowSource_FlowArn { get; set; }
            public System.String FlowVpcInterfaceAttachment_VpcInterfaceName { get; set; }
            public System.String NetworkSource_MulticastIp { get; set; }
            public System.String MulticastSourceSettings_MulticastSourceIp { get; set; }
            public System.String NetworkSource_NetworkName { get; set; }
            public System.Int32? NetworkSource_Port { get; set; }
            public Amazon.MediaConnect.Protocol NetworkSource_Protocol { get; set; }
            public System.String SourceName { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateBridgeSourceResponse, UpdateEMCNBridgeSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
