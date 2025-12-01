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
using Amazon.Route53GlobalResolver;
using Amazon.Route53GlobalResolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53GR
{
    /// <summary>
    /// Creates a DNS firewall rule. Firewall rules define actions (ALLOW, BLOCK, or ALERT)
    /// to take on DNS queries that match specified domain lists, managed domain lists, or
    /// advanced threat protections.
    /// </summary>
    [Cmdlet("New", "R53GRFirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53GlobalResolver.Model.CreateFirewallRuleResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 Global Resolver CreateFirewallRule API operation.", Operation = new[] {"CreateFirewallRule"}, SelectReturnType = typeof(Amazon.Route53GlobalResolver.Model.CreateFirewallRuleResponse))]
    [AWSCmdletOutput("Amazon.Route53GlobalResolver.Model.CreateFirewallRuleResponse",
        "This cmdlet returns an Amazon.Route53GlobalResolver.Model.CreateFirewallRuleResponse object containing multiple properties."
    )]
    public partial class NewR53GRFirewallRuleCmdlet : AmazonRoute53GlobalResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action that DNS Firewall should take on a DNS query when it matches one of the
        /// domains in the rule's domain list:</para><ul><li><para><c>ALLOW</c> - Permit the request to go through.</para></li><li><para><c>ALERT</c> - Permit the request and send metrics and logs to CloudWatch.</para></li><li><para><c>BLOCK</c> - Disallow the request. This option requires additional details in the
        /// rule's <c>BlockResponse</c>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53GlobalResolver.FirewallRuleAction")]
        public Amazon.Route53GlobalResolver.FirewallRuleAction Action { get; set; }
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
        [AWSConstantClassSource("Amazon.Route53GlobalResolver.BlockOverrideDnsQueryType")]
        public Amazon.Route53GlobalResolver.BlockOverrideDnsQueryType BlockOverrideDnsType { get; set; }
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
        /// <para>The response to return when the action is BLOCK. Valid values are NXDOMAIN (domain
        /// does not exist), NODATA (domain exists but no records), or OVERRIDE (return custom
        /// response).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53GlobalResolver.FirewallBlockResponse")]
        public Amazon.Route53GlobalResolver.FirewallBlockResponse BlockResponse { get; set; }
        #endregion
        
        #region Parameter ConfidenceThreshold
        /// <summary>
        /// <para>
        /// <para>The confidence threshold for advanced threat detection. Valid values are HIGH, MEDIUM,
        /// or LOW, indicating the accuracy level required for threat detection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53GlobalResolver.ConfidenceThreshold")]
        public Amazon.Route53GlobalResolver.ConfidenceThreshold ConfidenceThreshold { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the firewall rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DnsAdvancedProtection
        /// <summary>
        /// <para>
        /// <para>Whether to enable advanced DNS threat protection for this rule. Advanced protection
        /// can detect and block DNS tunneling and Domain Generation Algorithm (DGA) threats.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53GlobalResolver.DnsAdvancedProtection")]
        public Amazon.Route53GlobalResolver.DnsAdvancedProtection DnsAdvancedProtection { get; set; }
        #endregion
        
        #region Parameter DnsViewId
        /// <summary>
        /// <para>
        /// <para>The ID of the DNS view to associate with this firewall rule.</para>
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
        public System.String DnsViewId { get; set; }
        #endregion
        
        #region Parameter FirewallDomainListId
        /// <summary>
        /// <para>
        /// <para>The ID of the firewall domain list to use in this rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallDomainListId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive name for the firewall rule.</para>
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
        /// <para>The priority of this rule. Rules are evaluated in priority order, with lower numbers
        /// having higher priority. When a DNS query matches multiple rules, the rule with the
        /// highest priority (lowest number) is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Priority { get; set; }
        #endregion
        
        #region Parameter QType
        /// <summary>
        /// <para>
        /// <para>The DNS query type to match for this rule. Examples include A (IPv4 address), AAAA
        /// (IPv6 address), MX (mail exchange), or TXT (text record).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency. This means that making
        /// the same request multiple times with the same <c>clientToken</c> has the same result
        /// every time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53GlobalResolver.Model.CreateFirewallRuleResponse).
        /// Specifying the name of a property of type Amazon.Route53GlobalResolver.Model.CreateFirewallRuleResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.DnsViewId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53GRFirewallRule (CreateFirewallRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53GlobalResolver.Model.CreateFirewallRuleResponse, NewR53GRFirewallRuleCmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            context.ConfidenceThreshold = this.ConfidenceThreshold;
            context.Description = this.Description;
            context.DnsAdvancedProtection = this.DnsAdvancedProtection;
            context.DnsViewId = this.DnsViewId;
            #if MODULAR
            if (this.DnsViewId == null && ParameterWasBound(nameof(this.DnsViewId)))
            {
                WriteWarning("You are passing $null as a value for parameter DnsViewId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirewallDomainListId = this.FirewallDomainListId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Priority = this.Priority;
            context.QType = this.QType;
            
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
            var request = new Amazon.Route53GlobalResolver.Model.CreateFirewallRuleRequest();
            
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
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConfidenceThreshold != null)
            {
                request.ConfidenceThreshold = cmdletContext.ConfidenceThreshold;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DnsAdvancedProtection != null)
            {
                request.DnsAdvancedProtection = cmdletContext.DnsAdvancedProtection;
            }
            if (cmdletContext.DnsViewId != null)
            {
                request.DnsViewId = cmdletContext.DnsViewId;
            }
            if (cmdletContext.FirewallDomainListId != null)
            {
                request.FirewallDomainListId = cmdletContext.FirewallDomainListId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.QType != null)
            {
                request.QType = cmdletContext.QType;
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
        
        private Amazon.Route53GlobalResolver.Model.CreateFirewallRuleResponse CallAWSServiceOperation(IAmazonRoute53GlobalResolver client, Amazon.Route53GlobalResolver.Model.CreateFirewallRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Global Resolver", "CreateFirewallRule");
            try
            {
                #if DESKTOP
                return client.CreateFirewallRule(request);
                #elif CORECLR
                return client.CreateFirewallRuleAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Route53GlobalResolver.FirewallRuleAction Action { get; set; }
            public Amazon.Route53GlobalResolver.BlockOverrideDnsQueryType BlockOverrideDnsType { get; set; }
            public System.String BlockOverrideDomain { get; set; }
            public System.Int32? BlockOverrideTtl { get; set; }
            public Amazon.Route53GlobalResolver.FirewallBlockResponse BlockResponse { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.Route53GlobalResolver.ConfidenceThreshold ConfidenceThreshold { get; set; }
            public System.String Description { get; set; }
            public Amazon.Route53GlobalResolver.DnsAdvancedProtection DnsAdvancedProtection { get; set; }
            public System.String DnsViewId { get; set; }
            public System.String FirewallDomainListId { get; set; }
            public System.String Name { get; set; }
            public System.Int64? Priority { get; set; }
            public System.String QType { get; set; }
            public System.Func<Amazon.Route53GlobalResolver.Model.CreateFirewallRuleResponse, NewR53GRFirewallRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
