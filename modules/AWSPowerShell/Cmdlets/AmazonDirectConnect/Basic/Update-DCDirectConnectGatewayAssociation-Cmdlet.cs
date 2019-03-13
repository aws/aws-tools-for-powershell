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
    /// Updates the specified attributes of the Direct Connect gateway association.
    /// 
    ///  
    /// <para>
    /// Add or remove prefixes from the association.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DCDirectConnectGatewayAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.DirectConnectGatewayAssociation")]
    [AWSCmdlet("Calls the AWS Direct Connect UpdateDirectConnectGatewayAssociation API operation.", Operation = new[] {"UpdateDirectConnectGatewayAssociation"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DirectConnectGatewayAssociation",
        "This cmdlet returns a DirectConnectGatewayAssociation object.",
        "The service call response (type Amazon.DirectConnect.Model.UpdateDirectConnectGatewayAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDCDirectConnectGatewayAssociationCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter AddAllowedPrefixesToDirectConnectGateway
        /// <summary>
        /// <para>
        /// <para>The Amazon VPC prefixes to advertise to the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] AddAllowedPrefixesToDirectConnectGateway { get; set; }
        #endregion
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Direct Connect gateway association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter RemoveAllowedPrefixesToDirectConnectGateway
        /// <summary>
        /// <para>
        /// <para>The Amazon VPC prefixes to no longer advertise to the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] RemoveAllowedPrefixesToDirectConnectGateway { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DCDirectConnectGatewayAssociation (UpdateDirectConnectGatewayAssociation)"))
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
            
            if (this.AddAllowedPrefixesToDirectConnectGateway != null)
            {
                context.AddAllowedPrefixesToDirectConnectGateway = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.AddAllowedPrefixesToDirectConnectGateway);
            }
            context.AssociationId = this.AssociationId;
            if (this.RemoveAllowedPrefixesToDirectConnectGateway != null)
            {
                context.RemoveAllowedPrefixesToDirectConnectGateway = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.RemoveAllowedPrefixesToDirectConnectGateway);
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
            var request = new Amazon.DirectConnect.Model.UpdateDirectConnectGatewayAssociationRequest();
            
            if (cmdletContext.AddAllowedPrefixesToDirectConnectGateway != null)
            {
                request.AddAllowedPrefixesToDirectConnectGateway = cmdletContext.AddAllowedPrefixesToDirectConnectGateway;
            }
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            if (cmdletContext.RemoveAllowedPrefixesToDirectConnectGateway != null)
            {
                request.RemoveAllowedPrefixesToDirectConnectGateway = cmdletContext.RemoveAllowedPrefixesToDirectConnectGateway;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DirectConnectGatewayAssociation;
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
        
        private Amazon.DirectConnect.Model.UpdateDirectConnectGatewayAssociationResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.UpdateDirectConnectGatewayAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "UpdateDirectConnectGatewayAssociation");
            try
            {
                #if DESKTOP
                return client.UpdateDirectConnectGatewayAssociation(request);
                #elif CORECLR
                return client.UpdateDirectConnectGatewayAssociationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DirectConnect.Model.RouteFilterPrefix> AddAllowedPrefixesToDirectConnectGateway { get; set; }
            public System.String AssociationId { get; set; }
            public List<Amazon.DirectConnect.Model.RouteFilterPrefix> RemoveAllowedPrefixesToDirectConnectGateway { get; set; }
        }
        
    }
}
