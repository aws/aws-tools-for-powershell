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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Updates the edge locations associated with an Amazon Web Services Direct Connect gateway
    /// attachment.
    /// </summary>
    [Cmdlet("Update", "NMGRDirectConnectGatewayAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.DirectConnectGatewayAttachment")]
    [AWSCmdlet("Calls the AWS Network Manager UpdateDirectConnectGatewayAttachment API operation.", Operation = new[] {"UpdateDirectConnectGatewayAttachment"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.DirectConnectGatewayAttachment or Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.DirectConnectGatewayAttachment object.",
        "The service call response (type Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateNMGRDirectConnectGatewayAttachmentCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the Direct Connect gateway attachment for the updated edge locations. </para>
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
        public System.String AttachmentId { get; set; }
        #endregion
        
        #region Parameter EdgeLocation
        /// <summary>
        /// <para>
        /// <para>One or more edge locations to update for the Direct Connect gateway attachment. The
        /// updated array of edge locations overwrites the previous array of locations. <c>EdgeLocations</c>
        /// is only used for Direct Connect gateway attachments. Do</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdgeLocations")]
        public System.String[] EdgeLocation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DirectConnectGatewayAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DirectConnectGatewayAttachment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AttachmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AttachmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AttachmentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AttachmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NMGRDirectConnectGatewayAttachment (UpdateDirectConnectGatewayAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentResponse, UpdateNMGRDirectConnectGatewayAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AttachmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AttachmentId = this.AttachmentId;
            #if MODULAR
            if (this.AttachmentId == null && ParameterWasBound(nameof(this.AttachmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AttachmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EdgeLocation != null)
            {
                context.EdgeLocation = new List<System.String>(this.EdgeLocation);
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
            var request = new Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentRequest();
            
            if (cmdletContext.AttachmentId != null)
            {
                request.AttachmentId = cmdletContext.AttachmentId;
            }
            if (cmdletContext.EdgeLocation != null)
            {
                request.EdgeLocations = cmdletContext.EdgeLocation;
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
        
        private Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "UpdateDirectConnectGatewayAttachment");
            try
            {
                #if DESKTOP
                return client.UpdateDirectConnectGatewayAttachment(request);
                #elif CORECLR
                return client.UpdateDirectConnectGatewayAttachmentAsync(request).GetAwaiter().GetResult();
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
            public System.String AttachmentId { get; set; }
            public List<System.String> EdgeLocation { get; set; }
            public System.Func<Amazon.NetworkManager.Model.UpdateDirectConnectGatewayAttachmentResponse, UpdateNMGRDirectConnectGatewayAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DirectConnectGatewayAttachment;
        }
        
    }
}
