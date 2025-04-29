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
using System.Threading;
using Amazon.FMS;
using Amazon.FMS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Creates an Firewall Manager policy.
    /// 
    ///  
    /// <para>
    /// A Firewall Manager policy is specific to the individual policy type. If you want to
    /// enforce multiple policy types across accounts, you can create multiple policies. You
    /// can create more than one policy for each type. 
    /// </para><para>
    /// If you add a new account to an organization that you created with Organizations, Firewall
    /// Manager automatically applies the policy to the resources in that account that are
    /// within scope of the policy. 
    /// </para><para>
    /// Firewall Manager provides the following types of policies: 
    /// </para><ul><li><para><b>WAF policy</b> - This policy applies WAF web ACL protections to specified accounts
    /// and resources. 
    /// </para></li><li><para><b>Shield Advanced policy</b> - This policy applies Shield Advanced protection to
    /// specified accounts and resources. 
    /// </para></li><li><para><b>Security Groups policy</b> - This type of policy gives you control over security
    /// groups that are in use throughout your organization in Organizations and lets you
    /// enforce a baseline set of rules across your organization. 
    /// </para></li><li><para><b>Network ACL policy</b> - This type of policy gives you control over the network
    /// ACLs that are in use throughout your organization in Organizations and lets you enforce
    /// a baseline set of first and last network ACL rules across your organization. 
    /// </para></li><li><para><b>Network Firewall policy</b> - This policy applies Network Firewall protection
    /// to your organization's VPCs. 
    /// </para></li><li><para><b>DNS Firewall policy</b> - This policy applies Amazon Route 53 Resolver DNS Firewall
    /// protections to your organization's VPCs. 
    /// </para></li><li><para><b>Third-party firewall policy</b> - This policy applies third-party firewall protections.
    /// Third-party firewalls are available by subscription through the Amazon Web Services
    /// Marketplace console at <a href="http://aws.amazon.com/marketplace">Amazon Web Services
    /// Marketplace</a>.
    /// </para><ul><li><para><b>Palo Alto Networks Cloud NGFW policy</b> - This policy applies Palo Alto Networks
    /// Cloud Next Generation Firewall (NGFW) protections and Palo Alto Networks Cloud NGFW
    /// rulestacks to your organization's VPCs.
    /// </para></li><li><para><b>Fortigate CNF policy</b> - This policy applies Fortigate Cloud Native Firewall
    /// (CNF) protections. Fortigate CNF is a cloud-centered solution that blocks Zero-Day
    /// threats and secures cloud infrastructures with industry-leading advanced threat prevention,
    /// smart web application firewalls (WAF), and API protection.
    /// </para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("Set", "FMSPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FMS.Model.PutPolicyResponse")]
    [AWSCmdlet("Calls the Firewall Management Service PutPolicy API operation.", Operation = new[] {"PutPolicy"}, SelectReturnType = typeof(Amazon.FMS.Model.PutPolicyResponse))]
    [AWSCmdletOutput("Amazon.FMS.Model.PutPolicyResponse",
        "This cmdlet returns an Amazon.FMS.Model.PutPolicyResponse object containing multiple properties."
    )]
    public partial class SetFMSPolicyCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The details of the Firewall Manager policy to be created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.FMS.Model.Policy Policy { get; set; }
        #endregion
        
        #region Parameter TagList
        /// <summary>
        /// <para>
        /// <para>The tags to add to the Amazon Web Services resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.FMS.Model.Tag[] TagList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.PutPolicyResponse).
        /// Specifying the name of a property of type Amazon.FMS.Model.PutPolicyResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Policy), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-FMSPolicy (PutPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.PutPolicyResponse, SetFMSPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Policy = this.Policy;
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagList != null)
            {
                context.TagList = new List<Amazon.FMS.Model.Tag>(this.TagList);
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
            var request = new Amazon.FMS.Model.PutPolicyRequest();
            
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.TagList != null)
            {
                request.TagList = cmdletContext.TagList;
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
        
        private Amazon.FMS.Model.PutPolicyResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.PutPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "PutPolicy");
            try
            {
                return client.PutPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.FMS.Model.Policy Policy { get; set; }
            public List<Amazon.FMS.Model.Tag> TagList { get; set; }
            public System.Func<Amazon.FMS.Model.PutPolicyResponse, SetFMSPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
