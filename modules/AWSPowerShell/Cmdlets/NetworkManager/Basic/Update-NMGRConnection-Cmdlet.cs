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
    /// Updates the information for an existing connection. To remove information for any
    /// of the parameters, specify an empty string.
    /// </summary>
    [Cmdlet("Update", "NMGRConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.Connection")]
    [AWSCmdlet("Calls the AWS Network Manager UpdateConnection API operation.", Operation = new[] {"UpdateConnection"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.UpdateConnectionResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.Connection or Amazon.NetworkManager.Model.UpdateConnectionResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.Connection object.",
        "The service call response (type Amazon.NetworkManager.Model.UpdateConnectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateNMGRConnectionCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectedLinkId
        /// <summary>
        /// <para>
        /// <para>The ID of the link for the second device in the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectedLinkId { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the connection.</para>
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
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the connection.</para><para>Length Constraints: Maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter GlobalNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the global network.</para>
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
        public System.String GlobalNetworkId { get; set; }
        #endregion
        
        #region Parameter LinkId
        /// <summary>
        /// <para>
        /// <para>The ID of the link for the first device in the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LinkId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Connection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.UpdateConnectionResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.UpdateConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Connection";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NMGRConnection (UpdateConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.UpdateConnectionResponse, UpdateNMGRConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectedLinkId = this.ConnectedLinkId;
            context.ConnectionId = this.ConnectionId;
            #if MODULAR
            if (this.ConnectionId == null && ParameterWasBound(nameof(this.ConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.GlobalNetworkId = this.GlobalNetworkId;
            #if MODULAR
            if (this.GlobalNetworkId == null && ParameterWasBound(nameof(this.GlobalNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LinkId = this.LinkId;
            
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
            var request = new Amazon.NetworkManager.Model.UpdateConnectionRequest();
            
            if (cmdletContext.ConnectedLinkId != null)
            {
                request.ConnectedLinkId = cmdletContext.ConnectedLinkId;
            }
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.GlobalNetworkId != null)
            {
                request.GlobalNetworkId = cmdletContext.GlobalNetworkId;
            }
            if (cmdletContext.LinkId != null)
            {
                request.LinkId = cmdletContext.LinkId;
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
        
        private Amazon.NetworkManager.Model.UpdateConnectionResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.UpdateConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "UpdateConnection");
            try
            {
                #if DESKTOP
                return client.UpdateConnection(request);
                #elif CORECLR
                return client.UpdateConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectedLinkId { get; set; }
            public System.String ConnectionId { get; set; }
            public System.String Description { get; set; }
            public System.String GlobalNetworkId { get; set; }
            public System.String LinkId { get; set; }
            public System.Func<Amazon.NetworkManager.Model.UpdateConnectionResponse, UpdateNMGRConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Connection;
        }
        
    }
}
