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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Creates an Network Firewall <a>ProxyRuleGroup</a><para>
    /// Collections of related proxy filtering rules. Rule groups help you manage and reuse
    /// sets of rules across multiple proxy configurations. 
    /// </para><para>
    /// To manage a proxy rule group's tags, use the standard Amazon Web Services resource
    /// tagging operations, <a>ListTagsForResource</a>, <a>TagResource</a>, and <a>UntagResource</a>.
    /// </para><para>
    /// To retrieve information about proxy rule groups, use <a>ListProxyRuleGroups</a> and
    /// <a>DescribeProxyRuleGroup</a>.
    /// </para><para>
    /// To retrieve information about individual proxy rules, use <a>DescribeProxyRuleGroup</a>
    /// and <a>DescribeProxyRule</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NWFWProxyRuleGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.CreateProxyRuleGroupResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall CreateProxyRuleGroup API operation.", Operation = new[] {"CreateProxyRuleGroup"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.CreateProxyRuleGroupResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.CreateProxyRuleGroupResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.CreateProxyRuleGroupResponse object containing multiple properties."
    )]
    public partial class NewNWFWProxyRuleGroupCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the proxy rule group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Rules_PostRESPONSE
        /// <summary>
        /// <para>
        /// <para>After receiving response.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkFirewall.Model.ProxyRule[] Rules_PostRESPONSE { get; set; }
        #endregion
        
        #region Parameter Rules_PreDNS
        /// <summary>
        /// <para>
        /// <para>Before domain resolution. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkFirewall.Model.ProxyRule[] Rules_PreDNS { get; set; }
        #endregion
        
        #region Parameter Rules_PreREQUEST
        /// <summary>
        /// <para>
        /// <para>After DNS, before request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkFirewall.Model.ProxyRule[] Rules_PreREQUEST { get; set; }
        #endregion
        
        #region Parameter ProxyRuleGroupName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the proxy rule group. You can't change the name of a proxy
        /// rule group after you create it.</para>
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
        public System.String ProxyRuleGroupName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key:value pairs to associate with the resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkFirewall.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.CreateProxyRuleGroupResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.CreateProxyRuleGroupResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProxyRuleGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NWFWProxyRuleGroup (CreateProxyRuleGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.CreateProxyRuleGroupResponse, NewNWFWProxyRuleGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.ProxyRuleGroupName = this.ProxyRuleGroupName;
            #if MODULAR
            if (this.ProxyRuleGroupName == null && ParameterWasBound(nameof(this.ProxyRuleGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProxyRuleGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Rules_PostRESPONSE != null)
            {
                context.Rules_PostRESPONSE = new List<Amazon.NetworkFirewall.Model.ProxyRule>(this.Rules_PostRESPONSE);
            }
            if (this.Rules_PreDNS != null)
            {
                context.Rules_PreDNS = new List<Amazon.NetworkFirewall.Model.ProxyRule>(this.Rules_PreDNS);
            }
            if (this.Rules_PreREQUEST != null)
            {
                context.Rules_PreREQUEST = new List<Amazon.NetworkFirewall.Model.ProxyRule>(this.Rules_PreREQUEST);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkFirewall.Model.Tag>(this.Tag);
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
            var request = new Amazon.NetworkFirewall.Model.CreateProxyRuleGroupRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ProxyRuleGroupName != null)
            {
                request.ProxyRuleGroupName = cmdletContext.ProxyRuleGroupName;
            }
            
             // populate Rules
            var requestRulesIsNull = true;
            request.Rules = new Amazon.NetworkFirewall.Model.ProxyRulesByRequestPhase();
            List<Amazon.NetworkFirewall.Model.ProxyRule> requestRules_rules_PostRESPONSE = null;
            if (cmdletContext.Rules_PostRESPONSE != null)
            {
                requestRules_rules_PostRESPONSE = cmdletContext.Rules_PostRESPONSE;
            }
            if (requestRules_rules_PostRESPONSE != null)
            {
                request.Rules.PostRESPONSE = requestRules_rules_PostRESPONSE;
                requestRulesIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.ProxyRule> requestRules_rules_PreDNS = null;
            if (cmdletContext.Rules_PreDNS != null)
            {
                requestRules_rules_PreDNS = cmdletContext.Rules_PreDNS;
            }
            if (requestRules_rules_PreDNS != null)
            {
                request.Rules.PreDNS = requestRules_rules_PreDNS;
                requestRulesIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.ProxyRule> requestRules_rules_PreREQUEST = null;
            if (cmdletContext.Rules_PreREQUEST != null)
            {
                requestRules_rules_PreREQUEST = cmdletContext.Rules_PreREQUEST;
            }
            if (requestRules_rules_PreREQUEST != null)
            {
                request.Rules.PreREQUEST = requestRules_rules_PreREQUEST;
                requestRulesIsNull = false;
            }
             // determine if request.Rules should be set to null
            if (requestRulesIsNull)
            {
                request.Rules = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.NetworkFirewall.Model.CreateProxyRuleGroupResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.CreateProxyRuleGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "CreateProxyRuleGroup");
            try
            {
                return client.CreateProxyRuleGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String ProxyRuleGroupName { get; set; }
            public List<Amazon.NetworkFirewall.Model.ProxyRule> Rules_PostRESPONSE { get; set; }
            public List<Amazon.NetworkFirewall.Model.ProxyRule> Rules_PreDNS { get; set; }
            public List<Amazon.NetworkFirewall.Model.ProxyRule> Rules_PreREQUEST { get; set; }
            public List<Amazon.NetworkFirewall.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.CreateProxyRuleGroupResponse, NewNWFWProxyRuleGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
