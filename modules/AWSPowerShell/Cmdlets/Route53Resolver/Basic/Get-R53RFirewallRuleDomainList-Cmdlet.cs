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
    /// Retrieves the domains of an AutoAllowlist firewall rule. Only the owner of the rule
    /// group can call this operation. Results are paginated. Use <c>MaxResults</c> and <c>NextToken</c>
    /// to retrieve additional domains.
    /// 
    ///  
    /// <para>
    /// Identify the rule by <c>FirewallThreatProtectionId</c> to get the domains that DNS
    /// Firewall observed in the VPCs that use the rule group, through a rule group association
    /// or through a Route 53 Profile that includes the rule group, including VPCs in other
    /// accounts. Each domain is returned with its <c>DomainStatus</c> and request counts.
    /// Use <c>QueryOptions</c> to filter and sort the results.
    /// </para><para>
    /// Identify the rule's managed domain list by <c>FirewallDomainListId</c> to get the
    /// domains that the rule currently allows. For any other domain list, use <a>ListFirewallDomains</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "R53RFirewallRuleDomainList")]
    [OutputType("Amazon.Route53Resolver.Model.FirewallRuleDomain")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver ListFirewallRuleDomains API operation.", Operation = new[] {"ListFirewallRuleDomains"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.ListFirewallRuleDomainsResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.FirewallRuleDomain or Amazon.Route53Resolver.Model.ListFirewallRuleDomainsResponse",
        "This cmdlet returns a collection of Amazon.Route53Resolver.Model.FirewallRuleDomain objects.",
        "The service call response (type Amazon.Route53Resolver.Model.ListFirewallRuleDomainsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53RFirewallRuleDomainListCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter QueryOptions_DomainNameFilter
        /// <summary>
        /// <para>
        /// <para>Returns only the domains whose name contains this substring.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryOptions_DomainNameFilter { get; set; }
        #endregion
        
        #region Parameter QueryOptions_DomainStatus
        /// <summary>
        /// <para>
        /// <para>Filters the returned domains by review status. Valid values:</para><ul><li><para><c>OBSERVED</c> - Domains that DNS Firewall saw in the VPCs' DNS traffic and that
        /// you haven't allowed or denied. After the look-back window, a domain is observed when
        /// any DNS Firewall rule blocks a query for it from a VPC that uses the rule group, including
        /// rules in other rule groups, or when you remove it from the managed domain list. Domains
        /// from the look-back period that keep being queried and aren't blocked move to <c>ALLOWED</c>
        /// within about a day after the rule is created.</para></li><li><para><c>ALLOWED</c> - Domains that DNS Firewall allowed queries for, whether or not they're
        /// in the rule's managed domain list.</para></li><li><para><c>DENIED</c> - Domains that were denied with the <c>DENY</c> operation. A denied
        /// domain that is still queried and not blocked can move to <c>ALLOWED</c>.</para></li></ul><para>If you don't specify a value, the operation returns <c>OBSERVED</c> domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.FirewallDomainStatusFilter")]
        public Amazon.Route53Resolver.FirewallDomainStatusFilter QueryOptions_DomainStatus { get; set; }
        #endregion
        
        #region Parameter FirewallDomainListId
        /// <summary>
        /// <para>
        /// <para>The ID of the AutoAllowlist rule's managed domain list. Provide this to list the domains
        /// that the rule currently allows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallDomainListId { get; set; }
        #endregion
        
        #region Parameter FirewallRuleGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the firewall rule group that contains the rule.</para>
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
        public System.String FirewallRuleGroupId { get; set; }
        #endregion
        
        #region Parameter FirewallThreatProtectionId
        /// <summary>
        /// <para>
        /// <para>The threat protection ID that identifies an AutoAllowlist rule. Provide this to list
        /// an AutoAllowlist rule's domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallThreatProtectionId { get; set; }
        #endregion
        
        #region Parameter QueryOptions_SortBy
        /// <summary>
        /// <para>
        /// <para>The attribute to sort the returned domains by. Valid values:</para><ul><li><para><c>TIME_ADDED</c> - The <c>AddedTime</c> of the domain.</para></li><li><para><c>DAILY_TOTAL</c> - The <c>Last24HourRequests</c> count.</para></li><li><para><c>TOTAL_REQUESTS</c> - The <c>TotalRequests</c> count.</para></li></ul><para>If you don't specify a value, the operation sorts by <c>TIME_ADDED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.FirewallRuleDomainSortBy")]
        public Amazon.Route53Resolver.FirewallRuleDomainSortBy QueryOptions_SortBy { get; set; }
        #endregion
        
        #region Parameter QueryOptions_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort direction: <c>ASC</c> for ascending or <c>DESC</c> for descending. If you
        /// don't specify a value, the operation sorts in descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.FirewallRuleDomainSortOrder")]
        public Amazon.Route53Resolver.FirewallRuleDomainSortOrder QueryOptions_SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of domains that you want to return in a single call. If more domains
        /// remain than can be returned, the response includes a <c>NextToken</c> value that you
        /// can use in a subsequent call to get the next batch. The default is 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>For the first call to this operation, omit this value. If more domains remain than
        /// can be returned in a single call, the response includes a <c>NextToken</c> value.
        /// In your next call, specify that value to get the next batch of domains.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Domains'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.ListFirewallRuleDomainsResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.ListFirewallRuleDomainsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Domains";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.ListFirewallRuleDomainsResponse, GetR53RFirewallRuleDomainListCmdlet>(Select) ??
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
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.QueryOptions_DomainNameFilter = this.QueryOptions_DomainNameFilter;
            context.QueryOptions_DomainStatus = this.QueryOptions_DomainStatus;
            context.QueryOptions_SortBy = this.QueryOptions_SortBy;
            context.QueryOptions_SortOrder = this.QueryOptions_SortOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Route53Resolver.Model.ListFirewallRuleDomainsRequest();
            
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
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate QueryOptions
            var requestQueryOptionsIsNull = true;
            request.QueryOptions = new Amazon.Route53Resolver.Model.ListFirewallRuleDomainsQueryOptions();
            System.String requestQueryOptions_queryOptions_DomainNameFilter = null;
            if (cmdletContext.QueryOptions_DomainNameFilter != null)
            {
                requestQueryOptions_queryOptions_DomainNameFilter = cmdletContext.QueryOptions_DomainNameFilter;
            }
            if (requestQueryOptions_queryOptions_DomainNameFilter != null)
            {
                request.QueryOptions.DomainNameFilter = requestQueryOptions_queryOptions_DomainNameFilter;
                requestQueryOptionsIsNull = false;
            }
            Amazon.Route53Resolver.FirewallDomainStatusFilter requestQueryOptions_queryOptions_DomainStatus = null;
            if (cmdletContext.QueryOptions_DomainStatus != null)
            {
                requestQueryOptions_queryOptions_DomainStatus = cmdletContext.QueryOptions_DomainStatus;
            }
            if (requestQueryOptions_queryOptions_DomainStatus != null)
            {
                request.QueryOptions.DomainStatus = requestQueryOptions_queryOptions_DomainStatus;
                requestQueryOptionsIsNull = false;
            }
            Amazon.Route53Resolver.FirewallRuleDomainSortBy requestQueryOptions_queryOptions_SortBy = null;
            if (cmdletContext.QueryOptions_SortBy != null)
            {
                requestQueryOptions_queryOptions_SortBy = cmdletContext.QueryOptions_SortBy;
            }
            if (requestQueryOptions_queryOptions_SortBy != null)
            {
                request.QueryOptions.SortBy = requestQueryOptions_queryOptions_SortBy;
                requestQueryOptionsIsNull = false;
            }
            Amazon.Route53Resolver.FirewallRuleDomainSortOrder requestQueryOptions_queryOptions_SortOrder = null;
            if (cmdletContext.QueryOptions_SortOrder != null)
            {
                requestQueryOptions_queryOptions_SortOrder = cmdletContext.QueryOptions_SortOrder;
            }
            if (requestQueryOptions_queryOptions_SortOrder != null)
            {
                request.QueryOptions.SortOrder = requestQueryOptions_queryOptions_SortOrder;
                requestQueryOptionsIsNull = false;
            }
             // determine if request.QueryOptions should be set to null
            if (requestQueryOptionsIsNull)
            {
                request.QueryOptions = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Route53Resolver.Model.ListFirewallRuleDomainsResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.ListFirewallRuleDomainsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "ListFirewallRuleDomains");
            try
            {
                return client.ListFirewallRuleDomainsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String QueryOptions_DomainNameFilter { get; set; }
            public Amazon.Route53Resolver.FirewallDomainStatusFilter QueryOptions_DomainStatus { get; set; }
            public Amazon.Route53Resolver.FirewallRuleDomainSortBy QueryOptions_SortBy { get; set; }
            public Amazon.Route53Resolver.FirewallRuleDomainSortOrder QueryOptions_SortOrder { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.ListFirewallRuleDomainsResponse, GetR53RFirewallRuleDomainListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Domains;
        }
        
    }
}
