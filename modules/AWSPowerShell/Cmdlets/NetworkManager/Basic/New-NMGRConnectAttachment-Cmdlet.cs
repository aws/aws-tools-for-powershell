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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Creates a core network Connect attachment from a specified core network attachment.
    /// 
    /// 
    ///  
    /// <para>
    /// A core network Connect attachment is a GRE-based tunnel attachment that you can use
    /// to establish a connection between a core network and an appliance. A core network
    /// Connect attachment uses an existing VPC attachment as the underlying transport mechanism.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NMGRConnectAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.ConnectAttachment")]
    [AWSCmdlet("Calls the AWS Network Manager CreateConnectAttachment API operation.", Operation = new[] {"CreateConnectAttachment"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.CreateConnectAttachmentResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.ConnectAttachment or Amazon.NetworkManager.Model.CreateConnectAttachmentResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.ConnectAttachment object.",
        "The service call response (type Amazon.NetworkManager.Model.CreateConnectAttachmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewNMGRConnectAttachmentCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CoreNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of a core network where you want to create the attachment. </para>
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
        public System.String CoreNetworkId { get; set; }
        #endregion
        
        #region Parameter EdgeLocation
        /// <summary>
        /// <para>
        /// <para>The Region where the edge is located.</para>
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
        public System.String EdgeLocation { get; set; }
        #endregion
        
        #region Parameter Options_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol used for the attachment connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkManager.TunnelProtocol")]
        public Amazon.NetworkManager.TunnelProtocol Options_Protocol { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of key-value tags associated with the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TransportAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the attachment between the two connections.</para>
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
        public System.String TransportAttachmentId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token associated with the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.CreateConnectAttachmentResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.CreateConnectAttachmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectAttachment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CoreNetworkId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CoreNetworkId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CoreNetworkId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CoreNetworkId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NMGRConnectAttachment (CreateConnectAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.CreateConnectAttachmentResponse, NewNMGRConnectAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CoreNetworkId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.CoreNetworkId = this.CoreNetworkId;
            #if MODULAR
            if (this.CoreNetworkId == null && ParameterWasBound(nameof(this.CoreNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter CoreNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EdgeLocation = this.EdgeLocation;
            #if MODULAR
            if (this.EdgeLocation == null && ParameterWasBound(nameof(this.EdgeLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter EdgeLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Options_Protocol = this.Options_Protocol;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkManager.Model.Tag>(this.Tag);
            }
            context.TransportAttachmentId = this.TransportAttachmentId;
            #if MODULAR
            if (this.TransportAttachmentId == null && ParameterWasBound(nameof(this.TransportAttachmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransportAttachmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkManager.Model.CreateConnectAttachmentRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CoreNetworkId != null)
            {
                request.CoreNetworkId = cmdletContext.CoreNetworkId;
            }
            if (cmdletContext.EdgeLocation != null)
            {
                request.EdgeLocation = cmdletContext.EdgeLocation;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.NetworkManager.Model.ConnectAttachmentOptions();
            Amazon.NetworkManager.TunnelProtocol requestOptions_options_Protocol = null;
            if (cmdletContext.Options_Protocol != null)
            {
                requestOptions_options_Protocol = cmdletContext.Options_Protocol;
            }
            if (requestOptions_options_Protocol != null)
            {
                request.Options.Protocol = requestOptions_options_Protocol;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TransportAttachmentId != null)
            {
                request.TransportAttachmentId = cmdletContext.TransportAttachmentId;
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
        
        private Amazon.NetworkManager.Model.CreateConnectAttachmentResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.CreateConnectAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "CreateConnectAttachment");
            try
            {
                #if DESKTOP
                return client.CreateConnectAttachment(request);
                #elif CORECLR
                return client.CreateConnectAttachmentAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String CoreNetworkId { get; set; }
            public System.String EdgeLocation { get; set; }
            public Amazon.NetworkManager.TunnelProtocol Options_Protocol { get; set; }
            public List<Amazon.NetworkManager.Model.Tag> Tag { get; set; }
            public System.String TransportAttachmentId { get; set; }
            public System.Func<Amazon.NetworkManager.Model.CreateConnectAttachmentResponse, NewNMGRConnectAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectAttachment;
        }
        
    }
}
