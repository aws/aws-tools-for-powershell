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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Deletes the specified firewall rule.
    /// </summary>
    [Cmdlet("Remove", "R53RFirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Route53Resolver.Model.FirewallRule")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver DeleteFirewallRule API operation.", Operation = new[] {"DeleteFirewallRule"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.DeleteFirewallRuleResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.FirewallRule or Amazon.Route53Resolver.Model.DeleteFirewallRuleResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.FirewallRule object.",
        "The service call response (type Amazon.Route53Resolver.Model.DeleteFirewallRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveR53RFirewallRuleCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FirewallDomainListId
        /// <summary>
        /// <para>
        /// <para>The ID of the domain list that's used in the rule. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallDomainListId { get; set; }
        #endregion
        
        #region Parameter FirewallRuleGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the firewall rule group that you want to delete the rule
        /// from. </para>
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
        public System.String FirewallRuleGroupId { get; set; }
        #endregion
        
        #region Parameter FirewallThreatProtectionId
        /// <summary>
        /// <para>
        /// <para> The ID that is created for a DNS Firewall Advanced rule. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallThreatProtectionId { get; set; }
        #endregion
        
        #region Parameter Qtype
        /// <summary>
        /// <para>
        /// <para> The DNS query type that the rule you are deleting evaluates. Allowed values are;
        /// </para><ul><li><para> A: Returns an IPv4 address.</para></li><li><para>AAAA: Returns an Ipv6 address.</para></li><li><para>CAA: Restricts CAs that can create SSL/TLS certifications for the domain.</para></li><li><para>CNAME: Returns another domain name.</para></li><li><para>DS: Record that identifies the DNSSEC signing key of a delegated zone.</para></li><li><para>MX: Specifies mail servers.</para></li><li><para>NAPTR: Regular-expression-based rewriting of domain names.</para></li><li><para>NS: Authoritative name servers.</para></li><li><para>PTR: Maps an IP address to a domain name.</para></li><li><para>SOA: Start of authority record for the zone.</para></li><li><para>SPF: Lists the servers authorized to send emails from a domain.</para></li><li><para>SRV: Application specific values that identify servers.</para></li><li><para>TXT: Verifies email senders and application-specific values.</para></li><li><para>A query type you define by using the DNS type ID, for example 28 for AAAA. The values
        /// must be defined as TYPENUMBER, where the NUMBER can be 1-65334, for example, TYPE28.
        /// For more information, see <a href="https://en.wikipedia.org/wiki/List_of_DNS_record_types">List
        /// of DNS record types</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Qtype { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FirewallRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.DeleteFirewallRuleResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.DeleteFirewallRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FirewallRule";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallRuleGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53RFirewallRule (DeleteFirewallRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.DeleteFirewallRuleResponse, RemoveR53RFirewallRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FirewallDomainListId = this.FirewallDomainListId;
            context.FirewallRuleGroupId = this.FirewallRuleGroupId;
            #if MODULAR
            if (this.FirewallRuleGroupId == null && ParameterWasBound(nameof(this.FirewallRuleGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallRuleGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirewallThreatProtectionId = this.FirewallThreatProtectionId;
            context.Qtype = this.Qtype;
            
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
            var request = new Amazon.Route53Resolver.Model.DeleteFirewallRuleRequest();
            
            if (cmdletContext.FirewallDomainListId != null)
            {
                request.FirewallDomainListId = cmdletContext.FirewallDomainListId;
            }
            if (cmdletContext.FirewallRuleGroupId != null)
            {
                request.FirewallRuleGroupId = cmdletContext.FirewallRuleGroupId;
            }
            if (cmdletContext.FirewallThreatProtectionId != null)
            {
                request.FirewallThreatProtectionId = cmdletContext.FirewallThreatProtectionId;
            }
            if (cmdletContext.Qtype != null)
            {
                request.Qtype = cmdletContext.Qtype;
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
        
        private Amazon.Route53Resolver.Model.DeleteFirewallRuleResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.DeleteFirewallRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "DeleteFirewallRule");
            try
            {
                return client.DeleteFirewallRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FirewallDomainListId { get; set; }
            public System.String FirewallRuleGroupId { get; set; }
            public System.String FirewallThreatProtectionId { get; set; }
            public System.String Qtype { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.DeleteFirewallRuleResponse, RemoveR53RFirewallRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FirewallRule;
        }
        
    }
}
