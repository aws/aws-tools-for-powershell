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
    /// Deletes the BGP peer on the specified virtual interface with the specified customer
    /// address and ASN.
    /// 
    ///  
    /// <para>
    /// You cannot delete the last BGP peer from a virtual interface.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "DCBGPPeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.DirectConnect.Model.VirtualInterface")]
    [AWSCmdlet("Calls the AWS Direct Connect DeleteBGPPeer API operation.", Operation = new[] {"DeleteBGPPeer"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.VirtualInterface",
        "This cmdlet returns a VirtualInterface object.",
        "The service call response (type Amazon.DirectConnect.Model.DeleteBGPPeerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveDCBGPPeerCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Asn
        /// <summary>
        /// <para>
        /// <para>The autonomous system (AS) number for Border Gateway Protocol (BGP) configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Asn { get; set; }
        #endregion
        
        #region Parameter CustomerAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the customer interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomerAddress { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual interface.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DCBGPPeer (DeleteBGPPeer)"))
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
            
            if (ParameterWasBound("Asn"))
                context.Asn = this.Asn;
            context.CustomerAddress = this.CustomerAddress;
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
            var request = new Amazon.DirectConnect.Model.DeleteBGPPeerRequest();
            
            if (cmdletContext.Asn != null)
            {
                request.Asn = cmdletContext.Asn.Value;
            }
            if (cmdletContext.CustomerAddress != null)
            {
                request.CustomerAddress = cmdletContext.CustomerAddress;
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
                object pipelineOutput = response.VirtualInterface;
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
        
        private Amazon.DirectConnect.Model.DeleteBGPPeerResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DeleteBGPPeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "DeleteBGPPeer");
            try
            {
                #if DESKTOP
                return client.DeleteBGPPeer(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteBGPPeerAsync(request);
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
            public System.Int32? Asn { get; set; }
            public System.String CustomerAddress { get; set; }
            public System.String VirtualInterfaceId { get; set; }
        }
        
    }
}
