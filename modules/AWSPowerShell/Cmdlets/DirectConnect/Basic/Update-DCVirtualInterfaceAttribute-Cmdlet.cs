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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Updates the specified attributes of the specified virtual private interface.
    /// 
    ///  
    /// <para>
    /// Setting the MTU of a virtual interface to 8500 (jumbo frames) can cause an update
    /// to the underlying physical connection if it wasn't updated to support jumbo frames.
    /// Updating the connection disrupts network connectivity for all virtual interfaces associated
    /// with the connection for up to 30 seconds. To check whether your connection supports
    /// jumbo frames, call <a>DescribeConnections</a>. To check whether your virtual interface
    /// supports jumbo frames, call <a>DescribeVirtualInterfaces</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DCVirtualInterfaceAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect UpdateVirtualInterfaceAttributes API operation.", Operation = new[] {"UpdateVirtualInterfaceAttributes"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesResponse object containing multiple properties."
    )]
    public partial class UpdateDCVirtualInterfaceAttributeCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EnableSiteLink
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable or disable SiteLink.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableSiteLink { get; set; }
        #endregion
        
        #region Parameter Mtu
        /// <summary>
        /// <para>
        /// <para>The maximum transmission unit (MTU), in bytes. The supported values are 1500 and 8500.
        /// The default value is 1500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Mtu { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private interface.</para>
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
        public System.String VirtualInterfaceId { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual private interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VirtualInterfaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DCVirtualInterfaceAttribute (UpdateVirtualInterfaceAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesResponse, UpdateDCVirtualInterfaceAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnableSiteLink = this.EnableSiteLink;
            context.Mtu = this.Mtu;
            context.VirtualInterfaceId = this.VirtualInterfaceId;
            #if MODULAR
            if (this.VirtualInterfaceId == null && ParameterWasBound(nameof(this.VirtualInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VirtualInterfaceName = this.VirtualInterfaceName;
            
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
            var request = new Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesRequest();
            
            if (cmdletContext.EnableSiteLink != null)
            {
                request.EnableSiteLink = cmdletContext.EnableSiteLink.Value;
            }
            if (cmdletContext.Mtu != null)
            {
                request.Mtu = cmdletContext.Mtu.Value;
            }
            if (cmdletContext.VirtualInterfaceId != null)
            {
                request.VirtualInterfaceId = cmdletContext.VirtualInterfaceId;
            }
            if (cmdletContext.VirtualInterfaceName != null)
            {
                request.VirtualInterfaceName = cmdletContext.VirtualInterfaceName;
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
        
        private Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "UpdateVirtualInterfaceAttributes");
            try
            {
                #if DESKTOP
                return client.UpdateVirtualInterfaceAttributes(request);
                #elif CORECLR
                return client.UpdateVirtualInterfaceAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? EnableSiteLink { get; set; }
            public System.Int32? Mtu { get; set; }
            public System.String VirtualInterfaceId { get; set; }
            public System.String VirtualInterfaceName { get; set; }
            public System.Func<Amazon.DirectConnect.Model.UpdateVirtualInterfaceAttributesResponse, UpdateDCVirtualInterfaceAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
