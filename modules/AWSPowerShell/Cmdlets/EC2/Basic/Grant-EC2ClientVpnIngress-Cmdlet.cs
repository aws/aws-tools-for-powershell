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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Adds an ingress authorization rule to a Client VPN endpoint. Ingress authorization
    /// rules act as firewall rules that grant access to networks. You must configure ingress
    /// authorization rules to enable clients to access resources in Amazon Web Services or
    /// on-premises networks.
    /// </summary>
    [Cmdlet("Grant", "EC2ClientVpnIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ClientVpnAuthorizationRuleStatus")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AuthorizeClientVpnIngress API operation.", Operation = new[] {"AuthorizeClientVpnIngress"}, SelectReturnType = typeof(Amazon.EC2.Model.AuthorizeClientVpnIngressResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ClientVpnAuthorizationRuleStatus or Amazon.EC2.Model.AuthorizeClientVpnIngressResponse",
        "This cmdlet returns an Amazon.EC2.Model.ClientVpnAuthorizationRuleStatus object.",
        "The service call response (type Amazon.EC2.Model.AuthorizeClientVpnIngressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GrantEC2ClientVpnIngressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the group to grant access to, for example, the Active Directory group or
        /// identity provider (IdP) group. Required if <c>AuthorizeAllGroups</c> is <c>false</c>
        /// or not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessGroupId { get; set; }
        #endregion
        
        #region Parameter AuthorizeAllGroup
        /// <summary>
        /// <para>
        /// <para>Indicates whether to grant access to all clients. Specify <c>true</c> to grant all
        /// clients who successfully establish a VPN connection access to the network. Must be
        /// set to <c>true</c> if <c>AccessGroupId</c> is not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizeAllGroups")]
        public System.Boolean? AuthorizeAllGroup { get; set; }
        #endregion
        
        #region Parameter ClientVpnEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Client VPN endpoint.</para>
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
        public System.String ClientVpnEndpointId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of the authorization rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TargetNetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv4 address range, in CIDR notation, of the network for which access is being
        /// authorized.</para>
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
        public System.String TargetNetworkCidr { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AuthorizeClientVpnIngressResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AuthorizeClientVpnIngressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClientVpnEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Grant-EC2ClientVpnIngress (AuthorizeClientVpnIngress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AuthorizeClientVpnIngressResponse, GrantEC2ClientVpnIngressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessGroupId = this.AccessGroupId;
            context.AuthorizeAllGroup = this.AuthorizeAllGroup;
            context.ClientToken = this.ClientToken;
            context.ClientVpnEndpointId = this.ClientVpnEndpointId;
            #if MODULAR
            if (this.ClientVpnEndpointId == null && ParameterWasBound(nameof(this.ClientVpnEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientVpnEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.TargetNetworkCidr = this.TargetNetworkCidr;
            #if MODULAR
            if (this.TargetNetworkCidr == null && ParameterWasBound(nameof(this.TargetNetworkCidr)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetNetworkCidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.AuthorizeClientVpnIngressRequest();
            
            if (cmdletContext.AccessGroupId != null)
            {
                request.AccessGroupId = cmdletContext.AccessGroupId;
            }
            if (cmdletContext.AuthorizeAllGroup != null)
            {
                request.AuthorizeAllGroups = cmdletContext.AuthorizeAllGroup.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
        
        private Amazon.EC2.Model.AuthorizeClientVpnIngressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AuthorizeClientVpnIngressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AuthorizeClientVpnIngress");
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
            public System.Boolean? AuthorizeAllGroup { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ClientVpnEndpointId { get; set; }
            public System.String Description { get; set; }
            public System.String TargetNetworkCidr { get; set; }
            public System.Func<Amazon.EC2.Model.AuthorizeClientVpnIngressResponse, GrantEC2ClientVpnIngressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
