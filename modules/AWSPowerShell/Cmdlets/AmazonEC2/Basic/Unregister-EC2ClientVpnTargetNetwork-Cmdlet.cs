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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Disassociates a target network from the specified Client VPN endpoint. When you disassociate
    /// the last target network from a Client VPN, the following happens:
    /// 
    ///  <ul><li><para>
    /// The route that was automatically added for the VPC is deleted
    /// </para></li><li><para>
    /// All active client connections are terminated
    /// </para></li><li><para>
    /// New client connections are disallowed
    /// </para></li><li><para>
    /// The Client VPN endpoint's status changes to <code>pending-associate</code></para></li></ul>
    /// </summary>
    [Cmdlet("Unregister", "EC2ClientVpnTargetNetwork", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DisassociateClientVpnTargetNetwork API operation.", Operation = new[] {"DisassociateClientVpnTargetNetwork"})]
    [AWSCmdletOutput("Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse",
        "This cmdlet returns a Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UnregisterEC2ClientVpnTargetNetworkCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the target network association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter ClientVpnEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Client VPN endpoint from which to disassociate the target network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientVpnEndpointId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AssociationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-EC2ClientVpnTargetNetwork (DisassociateClientVpnTargetNetwork)"))
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
            
            context.AssociationId = this.AssociationId;
            context.ClientVpnEndpointId = this.ClientVpnEndpointId;
            
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
            var request = new Amazon.EC2.Model.DisassociateClientVpnTargetNetworkRequest();
            
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            if (cmdletContext.ClientVpnEndpointId != null)
            {
                request.ClientVpnEndpointId = cmdletContext.ClientVpnEndpointId;
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
        
        private Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DisassociateClientVpnTargetNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DisassociateClientVpnTargetNetwork");
            try
            {
                #if DESKTOP
                return client.DisassociateClientVpnTargetNetwork(request);
                #elif CORECLR
                return client.DisassociateClientVpnTargetNetworkAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociationId { get; set; }
            public System.String ClientVpnEndpointId { get; set; }
        }
        
    }
}
