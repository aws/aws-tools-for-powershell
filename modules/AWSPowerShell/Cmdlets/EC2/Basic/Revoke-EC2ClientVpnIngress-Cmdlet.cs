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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Removes an ingress authorization rule from a Client VPN endpoint.
    /// </summary>
    [Cmdlet("Revoke", "EC2ClientVpnIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ClientVpnAuthorizationRuleStatus")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) RevokeClientVpnIngress API operation.", Operation = new[] {"RevokeClientVpnIngress"}, SelectReturnType = typeof(Amazon.EC2.Model.RevokeClientVpnIngressResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ClientVpnAuthorizationRuleStatus or Amazon.EC2.Model.RevokeClientVpnIngressResponse",
        "This cmdlet returns an Amazon.EC2.Model.ClientVpnAuthorizationRuleStatus object.",
        "The service call response (type Amazon.EC2.Model.RevokeClientVpnIngressResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RevokeEC2ClientVpnIngressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the Active Directory group for which to revoke access. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessGroupId { get; set; }
        #endregion
        
        #region Parameter ClientVpnEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Client VPN endpoint with which the authorization rule is associated.</para>
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
        
        #region Parameter RevokeAllGroup
        /// <summary>
        /// <para>
        /// <para>Indicates whether access should be revoked for all groups for a single <c>TargetNetworkCidr</c>
        /// that earlier authorized ingress for all groups using <c>AuthorizeAllGroups</c>. This
        /// does not impact other authorization rules that allowed ingress to the same <c>TargetNetworkCidr</c>
        /// with a specific <c>AccessGroupId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RevokeAllGroups")]
        public System.Boolean? RevokeAllGroup { get; set; }
        #endregion
        
        #region Parameter TargetNetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv4 address range, in CIDR notation, of the network for which access is being
        /// removed.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.RevokeClientVpnIngressResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.RevokeClientVpnIngressResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Revoke-EC2ClientVpnIngress (RevokeClientVpnIngress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.RevokeClientVpnIngressResponse, RevokeEC2ClientVpnIngressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessGroupId = this.AccessGroupId;
            context.ClientVpnEndpointId = this.ClientVpnEndpointId;
            #if MODULAR
            if (this.ClientVpnEndpointId == null && ParameterWasBound(nameof(this.ClientVpnEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientVpnEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevokeAllGroup = this.RevokeAllGroup;
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
            var request = new Amazon.EC2.Model.RevokeClientVpnIngressRequest();
            
            if (cmdletContext.AccessGroupId != null)
            {
                request.AccessGroupId = cmdletContext.AccessGroupId;
            }
            if (cmdletContext.ClientVpnEndpointId != null)
            {
                request.ClientVpnEndpointId = cmdletContext.ClientVpnEndpointId;
            }
            if (cmdletContext.RevokeAllGroup != null)
            {
                request.RevokeAllGroups = cmdletContext.RevokeAllGroup.Value;
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
        
        private Amazon.EC2.Model.RevokeClientVpnIngressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RevokeClientVpnIngressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "RevokeClientVpnIngress");
            try
            {
                #if DESKTOP
                return client.RevokeClientVpnIngress(request);
                #elif CORECLR
                return client.RevokeClientVpnIngressAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientVpnEndpointId { get; set; }
            public System.Boolean? RevokeAllGroup { get; set; }
            public System.String TargetNetworkCidr { get; set; }
            public System.Func<Amazon.EC2.Model.RevokeClientVpnIngressResponse, RevokeEC2ClientVpnIngressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
