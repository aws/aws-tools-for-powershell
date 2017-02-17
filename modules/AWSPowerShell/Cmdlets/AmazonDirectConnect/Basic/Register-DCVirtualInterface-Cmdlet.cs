/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Associates a virtual interface with a specified link aggregation group (LAG) or connection.
    /// Connectivity to AWS is temporarily interrupted as the virtual interface is being migrated.
    /// If the target connection or LAG has an associated virtual interface with a conflicting
    /// VLAN number or a conflicting IP address, the operation fails. 
    /// 
    ///  
    /// <para>
    /// Virtual interfaces associated with a hosted connection cannot be associated with a
    /// LAG; hosted connections must be migrated along with their virtual interfaces using
    /// <a>AssociateHostedConnection</a>.
    /// </para><para>
    /// Hosted virtual interfaces (an interface for which the owner of the connection is not
    /// the owner of physical connection) can only be reassociated by the owner of the physical
    /// connection.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "DCVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.AssociateVirtualInterfaceResponse")]
    [AWSCmdlet("Invokes the AssociateVirtualInterface operation against AWS Direct Connect.", Operation = new[] {"AssociateVirtualInterface"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.AssociateVirtualInterfaceResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.AssociateVirtualInterfaceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterDCVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the LAG or connection with which to associate the virtual interface.</para><para>Example: dxlag-abc123 or dxcon-abc123</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual interface.</para><para>Example: dxvif-123dfg56</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VirtualInterfaceId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VirtualInterfaceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-DCVirtualInterface (AssociateVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConnectionId = this.ConnectionId;
            context.VirtualInterfaceId = this.VirtualInterfaceId;
            
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
            var request = new Amazon.DirectConnect.Model.AssociateVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            if (cmdletContext.VirtualInterfaceId != null)
            {
                request.VirtualInterfaceId = cmdletContext.VirtualInterfaceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.DirectConnect.Model.AssociateVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.AssociateVirtualInterfaceRequest request)
        {
            #if DESKTOP
            return client.AssociateVirtualInterface(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AssociateVirtualInterfaceAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ConnectionId { get; set; }
            public System.String VirtualInterfaceId { get; set; }
        }
        
    }
}
