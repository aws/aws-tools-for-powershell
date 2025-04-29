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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Creates a single DNS Firewall rule in the specified rule group, using the specified
    /// domain list.
    /// </summary>
    [Cmdlet("New", "R53RFirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Resolver.Model.FirewallRule")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver CreateFirewallRule API operation.", Operation = new[] {"CreateFirewallRule"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.CreateFirewallRuleResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.FirewallRule or Amazon.Route53Resolver.Model.CreateFirewallRuleResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.FirewallRule object.",
        "The service call response (type Amazon.Route53Resolver.Model.CreateFirewallRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewR53RFirewallRuleCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action that DNS Firewall should take on a DNS query when it matches one of the
        /// domains in the rule's domain list, or a threat in a DNS Firewall Advanced rule:</para><ul><li><para><c>ALLOW</c> - Permit the request to go through. Not available for DNS Firewall Advanced
        /// rules.</para></li><li><para><c>ALERT</c> - Permit the request and send metrics and logs to Cloud Watch.</para></li><li><para><c>BLOCK</c> - Disallow the request. This option requires additional details in the
        /// rule's <c>BlockResponse</c>. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53Resolver.Action")]
        public Amazon.Route53Resolver.Action Action { get; set; }
        #endregion
        
        #region Parameter BlockOverrideDnsType
        /// <summary>
        /// <para>
        /// <para>The DNS record's type. This determines the format of the record value that you provided
        /// in <c>BlockOverrideDomain</c>. Used for the rule action <c>BLOCK</c> with a <c>BlockResponse</c>
        /// setting of <c>OVERRIDE</c>.</para><para>This setting is required if the <c>BlockResponse</c> setting is <c>OVERRIDE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.BlockOverrideDnsType")]
        public Amazon.Route53Resolver.BlockOverrideDnsType BlockOverrideDnsType { get; set; }
        #endregion
        
        #region Parameter BlockOverrideDomain
        /// <summary>
        /// <para>
        /// <para>The custom DNS record to send back in response to the query. Used for the rule action
        /// <c>BLOCK</c> with a <c>BlockResponse</c> setting of <c>OVERRIDE</c>.</para><para>This setting is required if the <c>BlockResponse</c> setting is <c>OVERRIDE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BlockOverrideDomain { get; set; }
        #endregion
        
        #region Parameter BlockOverrideTtl
        /// <summary>
        /// <para>
        /// <para>The recommended amount of time, in seconds, for the DNS resolver or web browser to
        /// cache the provided override record. Used for the rule action <c>BLOCK</c> with a <c>BlockResponse</c>
        /// setting of <c>OVERRIDE</c>.</para><para>This setting is required if the <c>BlockResponse</c> setting is <c>OVERRIDE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BlockOverrideTtl { get; set; }
        #endregion
        
        #region Parameter BlockResponse
        /// <summary>
        /// <para>
        /// <para>The way that you want DNS Firewall to block the request, used with the rule action
        /// setting <c>BLOCK</c>. </para><ul><li><para><c>NODATA</c> - Respond indicating that the query was successful, but no response
        /// is available for it.</para></li><li><para><c>NXDOMAIN</c> - Respond indicating that the domain name that's in the query doesn't
        /// exist.</para></li><li><para><c>OVERRIDE</c> - Provide a custom override in the response. This option requires
        /// custom handling details in the rule's <c>BlockOverride*</c> settings. </para></li></ul><para>This setting is required if the rule action setting is <c>BLOCK</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.BlockResponse")]
        public Amazon.Route53Resolver.BlockResponse BlockResponse { get; set; }
        #endregion
        
        #region Parameter ConfidenceThreshold
        /// <summary>
        /// <para>
        /// <para> The confidence threshold for DNS Firewall Advanced. You must provide this value when
        /// you create a DNS Firewall Advanced rule. The confidence level values mean: </para><ul><li><para><c>LOW</c>: Provides the highest detection rate for threats, but also increases false
        /// positives.</para></li><li><para><c>MEDIUM</c>: Provides a balance between detecting threats and false positives.</para></li><li><para><c>HIGH</c>: Detects only the most well corroborated threats with a low rate of false
        /// positives. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.ConfidenceThreshold")]
        public Amazon.Route53Resolver.ConfidenceThreshold ConfidenceThreshold { get; set; }
        #endregion
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows you to retry failed requests
        /// without the risk of running the operation twice. <c>CreatorRequestId</c> can be any
        /// unique string, for example, a date/time stamp. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter DnsThreatProtection
        /// <summary>
        /// <para>
        /// <para> Use to create a DNS Firewall Advanced rule. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.DnsThreatProtection")]
        public Amazon.Route53Resolver.DnsThreatProtection DnsThreatProtection { get; set; }
        #endregion
        
        #region Parameter FirewallDomainListId
        /// <summary>
        /// <para>
        /// <para>The ID of the domain list that you want to use in the rule. Can't be used together
        /// with <c>DnsThreatProtecton</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallDomainListId { get; set; }
        #endregion
        
        #region Parameter FirewallDomainRedirectionAction
        /// <summary>
        /// <para>
        /// <para> How you want the the rule to evaluate DNS redirection in the DNS redirection chain,
        /// such as CNAME or DNAME. </para><para><c>INSPECT_REDIRECTION_DOMAIN</c>: (Default) inspects all domains in the redirection
        /// chain. The individual domains in the redirection chain must be added to the domain
        /// list.</para><para><c>TRUST_REDIRECTION_DOMAIN</c>: Inspects only the first domain in the redirection
        /// chain. You don't need to add the subsequent domains in the domain in the redirection
        /// list to the domain list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.FirewallDomainRedirectionAction")]
        public Amazon.Route53Resolver.FirewallDomainRedirectionAction FirewallDomainRedirectionAction { get; set; }
        #endregion
        
        #region Parameter FirewallRuleGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the firewall rule group where you want to create the rule.
        /// </para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name that lets you identify the rule in the rule group.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The setting that determines the processing order of the rule in the rule group. DNS
        /// Firewall processes the rules in a rule group by order of priority, starting from the
        /// lowest setting.</para><para>You must specify a unique priority for each rule in a rule group. To make it easier
        /// to insert rules later, leave space between the numbers, for example, use 100, 200,
        /// and so on. You can change the priority setting for the rules in a rule group at any
        /// time.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter Qtype
        /// <summary>
        /// <para>
        /// <para> The DNS query type you want the rule to evaluate. Allowed values are; </para><ul><li><para> A: Returns an IPv4 address.</para></li><li><para>AAAA: Returns an Ipv6 address.</para></li><li><para>CAA: Restricts CAs that can create SSL/TLS certifications for the domain.</para></li><li><para>CNAME: Returns another domain name.</para></li><li><para>DS: Record that identifies the DNSSEC signing key of a delegated zone.</para></li><li><para>MX: Specifies mail servers.</para></li><li><para>NAPTR: Regular-expression-based rewriting of domain names.</para></li><li><para>NS: Authoritative name servers.</para></li><li><para>PTR: Maps an IP address to a domain name.</para></li><li><para>SOA: Start of authority record for the zone.</para></li><li><para>SPF: Lists the servers authorized to send emails from a domain.</para></li><li><para>SRV: Application specific values that identify servers.</para></li><li><para>TXT: Verifies email senders and application-specific values.</para></li><li><para>A query type you define by using the DNS type ID, for example 28 for AAAA. The values
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.CreateFirewallRuleResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.CreateFirewallRuleResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallRuleGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53RFirewallRule (CreateFirewallRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.CreateFirewallRuleResponse, NewR53RFirewallRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BlockOverrideDnsType = this.BlockOverrideDnsType;
            context.BlockOverrideDomain = this.BlockOverrideDomain;
            context.BlockOverrideTtl = this.BlockOverrideTtl;
            context.BlockResponse = this.BlockResponse;
            context.ConfidenceThreshold = this.ConfidenceThreshold;
            context.CreatorRequestId = this.CreatorRequestId;
            context.DnsThreatProtection = this.DnsThreatProtection;
            context.FirewallDomainListId = this.FirewallDomainListId;
            context.FirewallDomainRedirectionAction = this.FirewallDomainRedirectionAction;
            context.FirewallRuleGroupId = this.FirewallRuleGroupId;
            #if MODULAR
            if (this.FirewallRuleGroupId == null && ParameterWasBound(nameof(this.FirewallRuleGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallRuleGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Route53Resolver.Model.CreateFirewallRuleRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.BlockOverrideDnsType != null)
            {
                request.BlockOverrideDnsType = cmdletContext.BlockOverrideDnsType;
            }
            if (cmdletContext.BlockOverrideDomain != null)
            {
                request.BlockOverrideDomain = cmdletContext.BlockOverrideDomain;
            }
            if (cmdletContext.BlockOverrideTtl != null)
            {
                request.BlockOverrideTtl = cmdletContext.BlockOverrideTtl.Value;
            }
            if (cmdletContext.BlockResponse != null)
            {
                request.BlockResponse = cmdletContext.BlockResponse;
            }
            if (cmdletContext.ConfidenceThreshold != null)
            {
                request.ConfidenceThreshold = cmdletContext.ConfidenceThreshold;
            }
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            if (cmdletContext.DnsThreatProtection != null)
            {
                request.DnsThreatProtection = cmdletContext.DnsThreatProtection;
            }
            if (cmdletContext.FirewallDomainListId != null)
            {
                request.FirewallDomainListId = cmdletContext.FirewallDomainListId;
            }
            if (cmdletContext.FirewallDomainRedirectionAction != null)
            {
                request.FirewallDomainRedirectionAction = cmdletContext.FirewallDomainRedirectionAction;
            }
            if (cmdletContext.FirewallRuleGroupId != null)
            {
                request.FirewallRuleGroupId = cmdletContext.FirewallRuleGroupId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
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
        
        private Amazon.Route53Resolver.Model.CreateFirewallRuleResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.CreateFirewallRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "CreateFirewallRule");
            try
            {
                return client.CreateFirewallRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Route53Resolver.Action Action { get; set; }
            public Amazon.Route53Resolver.BlockOverrideDnsType BlockOverrideDnsType { get; set; }
            public System.String BlockOverrideDomain { get; set; }
            public System.Int32? BlockOverrideTtl { get; set; }
            public Amazon.Route53Resolver.BlockResponse BlockResponse { get; set; }
            public Amazon.Route53Resolver.ConfidenceThreshold ConfidenceThreshold { get; set; }
            public System.String CreatorRequestId { get; set; }
            public Amazon.Route53Resolver.DnsThreatProtection DnsThreatProtection { get; set; }
            public System.String FirewallDomainListId { get; set; }
            public Amazon.Route53Resolver.FirewallDomainRedirectionAction FirewallDomainRedirectionAction { get; set; }
            public System.String FirewallRuleGroupId { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String Qtype { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.CreateFirewallRuleResponse, NewR53RFirewallRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FirewallRule;
        }
        
    }
}
