/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Deprecated. Use <a>AllocateHostedConnection</a> instead.
    /// 
    ///  
    /// <para>
    /// Creates a hosted connection on an interconnect.
    /// </para><para>
    /// Allocates a VLAN number and a specified amount of bandwidth for use by a hosted connection
    /// on the specified interconnect.
    /// </para><note><para>
    /// Intended for use by AWS Direct Connect partners only.
    /// </para></note><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Enable", "DCConnectionOnInterconnect", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect AllocateConnectionOnInterconnect API operation.", Operation = new[] {"AllocateConnectionOnInterconnect"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("Deprecated in favor of AllocateHostedConnection.")]
    public partial class EnableDCConnectionOnInterconnectCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Bandwidth
        /// <summary>
        /// <para>
        /// <para>The bandwidth of the connection, in Mbps. The possible values are 50Mbps, 100Mbps,
        /// 200Mbps, 300Mbps, 400Mbps, and 500Mbps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String Bandwidth { get; set; }
        #endregion
        
        #region Parameter ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the provisioned connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String ConnectionName { get; set; }
        #endregion
        
        #region Parameter InterconnectId
        /// <summary>
        /// <para>
        /// <para>The ID of the interconnect on which the connection will be provisioned. For example,
        /// dxcon-456abc78.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InterconnectId { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS account of the customer for whom the connection will be provisioned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter Vlan
        /// <summary>
        /// <para>
        /// <para>The dedicated VLAN provisioned to the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public System.Int32 Vlan { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InterconnectId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DCConnectionOnInterconnect (AllocateConnectionOnInterconnect)"))
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
            
            context.Bandwidth = this.Bandwidth;
            context.ConnectionName = this.ConnectionName;
            context.InterconnectId = this.InterconnectId;
            context.OwnerAccount = this.OwnerAccount;
            if (ParameterWasBound("Vlan"))
                context.Vlan = this.Vlan;
            
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
            var request = new Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectRequest();
            
            if (cmdletContext.Bandwidth != null)
            {
                request.Bandwidth = cmdletContext.Bandwidth;
            }
            if (cmdletContext.ConnectionName != null)
            {
                request.ConnectionName = cmdletContext.ConnectionName;
            }
            if (cmdletContext.InterconnectId != null)
            {
                request.InterconnectId = cmdletContext.InterconnectId;
            }
            if (cmdletContext.OwnerAccount != null)
            {
                request.OwnerAccount = cmdletContext.OwnerAccount;
            }
            if (cmdletContext.Vlan != null)
            {
                request.Vlan = cmdletContext.Vlan.Value;
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
        
        private Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "AllocateConnectionOnInterconnect");
            try
            {
                #if DESKTOP
                return client.AllocateConnectionOnInterconnect(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AllocateConnectionOnInterconnectAsync(request);
                return task.Result;
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
            public System.String Bandwidth { get; set; }
            public System.String ConnectionName { get; set; }
            public System.String InterconnectId { get; set; }
            public System.String OwnerAccount { get; set; }
            public System.Int32? Vlan { get; set; }
        }
        
    }
}
