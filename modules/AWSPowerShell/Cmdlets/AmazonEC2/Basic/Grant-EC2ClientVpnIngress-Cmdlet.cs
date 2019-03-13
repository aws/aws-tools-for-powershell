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
    /// Adds an ingress authorization rule to a Client VPN endpoint. Ingress authorization
    /// rules act as firewall rules that grant access to networks. You must configure ingress
    /// authorization rules to enable clients to access resources in AWS or on-premises networks.
    /// </summary>
    [Cmdlet("Grant", "EC2ClientVpnIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ClientVpnAuthorizationRuleStatus")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud AuthorizeClientVpnIngress API operation.", Operation = new[] {"AuthorizeClientVpnIngress"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ClientVpnAuthorizationRuleStatus",
        "This cmdlet returns a ClientVpnAuthorizationRuleStatus object.",
        "The service call response (type Amazon.EC2.Model.AuthorizeClientVpnIngressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GrantEC2ClientVpnIngressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AccessGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the Active Directory group to grant access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AccessGroupId { get; set; }
        #endregion
        
        #region Parameter AuthorizeAllGroup
        /// <summary>
        /// <para>
        /// <para>Indicates whether to grant access to all clients. Use <code>true</code> to grant all
        /// clients who successfully establish a VPN connection access to the network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuthorizeAllGroups")]
        public System.Boolean AuthorizeAllGroup { get; set; }
        #endregion
        
        #region Parameter ClientVpnEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Client VPN endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClientVpnEndpointId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of the authorization rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TargetNetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv4 address range, in CIDR notation, of the network for which access is being
        /// authorized.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetNetworkCidr { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClientVpnEndpointId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Grant-EC2ClientVpnIngress (AuthorizeClientVpnIngress)"))
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
            
            context.AccessGroupId = this.AccessGroupId;
            if (ParameterWasBound("AuthorizeAllGroup"))
                context.AuthorizeAllGroups = this.AuthorizeAllGroup;
            context.ClientVpnEndpointId = this.ClientVpnEndpointId;
            context.Description = this.Description;
            context.TargetNetworkCidr = this.TargetNetworkCidr;
            
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
            var request = new Amazon.EC2.Model.AuthorizeClientVpnIngressRequest();
            
            if (cmdletContext.AccessGroupId != null)
            {
                request.AccessGroupId = cmdletContext.AccessGroupId;
            }
            if (cmdletContext.AuthorizeAllGroups != null)
            {
                request.AuthorizeAllGroups = cmdletContext.AuthorizeAllGroups.Value;
            }
            if (cmdletContext.ClientVpnEndpointId != null)
            {
                request.ClientVpnEndpointId = cmdletContext.ClientVpnEndpointId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.TargetNetworkCidr != null)
            {
                request.TargetNetworkCidr = cmdletContext.TargetNetworkCidr;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Status;
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
        
        private Amazon.EC2.Model.AuthorizeClientVpnIngressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AuthorizeClientVpnIngressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "AuthorizeClientVpnIngress");
            try
            {
                #if DESKTOP
                return client.AuthorizeClientVpnIngress(request);
                #elif CORECLR
                return client.AuthorizeClientVpnIngressAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessGroupId { get; set; }
            public System.Boolean? AuthorizeAllGroups { get; set; }
            public System.String ClientVpnEndpointId { get; set; }
            public System.String Description { get; set; }
            public System.String TargetNetworkCidr { get; set; }
        }
        
    }
}
