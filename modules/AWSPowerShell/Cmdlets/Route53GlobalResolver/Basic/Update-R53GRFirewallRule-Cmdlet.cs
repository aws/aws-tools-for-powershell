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
    /// Updates the configuration of a DNS firewall rule.
    /// </summary>
    [Cmdlet("Update", "R53GRFirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 Global Resolver UpdateFirewallRule API operation.", Operation = new[] {"UpdateFirewallRule"}, SelectReturnType = typeof(Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleResponse))]
    [AWSCmdletOutput("Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleResponse",
        "This cmdlet returns an Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleResponse object containing multiple properties."
    )]
    public partial class UpdateR53GRFirewallRuleCmdlet : AmazonRoute53GlobalResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action that DNS Firewall should take on a DNS query when it matches one of the
        /// domains in the rule's domain list, or a threat in a DNS Firewall Advanced rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53GlobalResolver.FirewallRuleAction")]
        public Amazon.Route53GlobalResolver.FirewallRuleAction Action { get; set; }
        #endregion
        
        #region Parameter BlockOverrideDnsType
        /// <summary>
        /// <para>
        /// <para>The DNS record's type. This determines the format of the record value that you provided
        /// in <c>BlockOverrideDomain</c>. Used for the rule action <c>BLOCK</c> with a <c>BlockResponse</c>
        /// setting of <c>OVERRIDE</c>.</para>
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
        /// <c>BLOCK</c> with a <c>BlockResponse</c> setting of <c>OVERRIDE</c>.</para>
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
        /// setting of <c>OVERRIDE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BlockOverrideTtl { get; set; }
        #endregion
        
        #region Parameter BlockResponse
        /// <summary>
        /// <para>
        /// <para>The way that you want DNS Firewall to block the request. Used for the rule action
        /// setting <c>BLOCK</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53GlobalResolver.FirewallBlockResponse")]
        public Amazon.Route53GlobalResolver.FirewallBlockResponse BlockResponse { get; set; }
        #endregion
        
        #region Parameter ConfidenceThreshold
        /// <summary>
        /// <para>
        /// <para>The confidence threshold for DNS Firewall Advanced. You must provide this value when
        /// you create a DNS Firewall Advanced rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53GlobalResolver.ConfidenceThreshold")]
        public Amazon.Route53GlobalResolver.ConfidenceThreshold ConfidenceThreshold { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for the Firewall rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DnsAdvancedProtection
        /// <summary>
        /// <para>
        /// <para>The type of the DNS Firewall Advanced rule. Valid values are DGA and DNS_TUNNELING.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53GlobalResolver.DnsAdvancedProtection")]
        public Amazon.Route53GlobalResolver.DnsAdvancedProtection DnsAdvancedProtection { get; set; }
        #endregion
        
        #region Parameter FirewallRuleId
        /// <summary>
        /// <para>
        /// <para>The ID of the DNS Firewall rule.</para>
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
        public System.String FirewallRuleId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the DNS Firewall rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The setting that determines the processing order of the rule in the rule group. DNS
        /// Firewall processes the rules in a rule group by order of priority, starting from the
        /// lowest setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Priority { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleResponse).
        /// Specifying the name of a property of type Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FirewallRuleId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FirewallRuleId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FirewallRuleId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallRuleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53GRFirewallRule (UpdateFirewallRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleResponse, UpdateR53GRFirewallRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FirewallRuleId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Action = this.Action;
            context.BlockOverrideDnsType = this.BlockOverrideDnsType;
            context.BlockOverrideDomain = this.BlockOverrideDomain;
            context.BlockOverrideTtl = this.BlockOverrideTtl;
            context.BlockResponse = this.BlockResponse;
            context.ClientToken = this.ClientToken;
            context.ConfidenceThreshold = this.ConfidenceThreshold;
            context.Description = this.Description;
            context.DnsAdvancedProtection = this.DnsAdvancedProtection;
            context.FirewallRuleId = this.FirewallRuleId;
            #if MODULAR
            if (this.FirewallRuleId == null && ParameterWasBound(nameof(this.FirewallRuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallRuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.Priority = this.Priority;
            
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
            var request = new Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleRequest();
            
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
            if (cmdletContext.FirewallRuleId != null)
            {
                request.FirewallRuleId = cmdletContext.FirewallRuleId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
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
        
        private Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleResponse CallAWSServiceOperation(IAmazonRoute53GlobalResolver client, Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Global Resolver", "UpdateFirewallRule");
            try
            {
                #if DESKTOP
                return client.UpdateFirewallRule(request);
                #elif CORECLR
                return client.UpdateFirewallRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String FirewallRuleId { get; set; }
            public System.String Name { get; set; }
            public System.Int64? Priority { get; set; }
            public System.Func<Amazon.Route53GlobalResolver.Model.UpdateFirewallRuleResponse, UpdateR53GRFirewallRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
