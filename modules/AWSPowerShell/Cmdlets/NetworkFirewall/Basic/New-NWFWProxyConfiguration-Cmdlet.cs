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
    /// Creates an Network Firewall <a>ProxyConfiguration</a><para>
    /// A Proxy Configuration defines the monitoring and protection behavior for a Proxy.
    /// The details of the behavior are defined in the rule groups that you add to your configuration.
    /// 
    /// </para><para>
    /// To manage a proxy configuration's tags, use the standard Amazon Web Services resource
    /// tagging operations, <a>ListTagsForResource</a>, <a>TagResource</a>, and <a>UntagResource</a>.
    /// </para><para>
    /// To retrieve information about proxies, use <a>ListProxyConfigurations</a> and <a>DescribeProxyConfiguration</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NWFWProxyConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.CreateProxyConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall CreateProxyConfiguration API operation.", Operation = new[] {"CreateProxyConfiguration"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.CreateProxyConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.CreateProxyConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.CreateProxyConfigurationResponse object containing multiple properties."
    )]
    public partial class NewNWFWProxyConfigurationCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the proxy configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DefaultRulePhaseActions_PostRESPONSE
        /// <summary>
        /// <para>
        /// <para>After receiving response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.ProxyRulePhaseAction")]
        public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PostRESPONSE { get; set; }
        #endregion
        
        #region Parameter DefaultRulePhaseActions_PreDNS
        /// <summary>
        /// <para>
        /// <para>Before domain resolution. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.ProxyRulePhaseAction")]
        public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PreDNS { get; set; }
        #endregion
        
        #region Parameter DefaultRulePhaseActions_PreREQUEST
        /// <summary>
        /// <para>
        /// <para>After DNS, before request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.ProxyRulePhaseAction")]
        public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PreREQUEST { get; set; }
        #endregion
        
        #region Parameter ProxyConfigurationName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the proxy configuration. You can't change the name of a proxy
        /// configuration after you create it.</para>
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
        public System.String ProxyConfigurationName { get; set; }
        #endregion
        
        #region Parameter RuleGroupArn
        /// <summary>
        /// <para>
        /// <para>The proxy rule group arn(s) to attach to the proxy configuration.</para><para>You must specify the ARNs or the names, and you can specify both. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuleGroupArns")]
        public System.String[] RuleGroupArn { get; set; }
        #endregion
        
        #region Parameter RuleGroupName
        /// <summary>
        /// <para>
        /// <para>The proxy rule group name(s) to attach to the proxy configuration.</para><para>You must specify the ARNs or the names, and you can specify both. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuleGroupNames")]
        public System.String[] RuleGroupName { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.CreateProxyConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.CreateProxyConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProxyConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NWFWProxyConfiguration (CreateProxyConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.CreateProxyConfigurationResponse, NewNWFWProxyConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultRulePhaseActions_PostRESPONSE = this.DefaultRulePhaseActions_PostRESPONSE;
            context.DefaultRulePhaseActions_PreDNS = this.DefaultRulePhaseActions_PreDNS;
            context.DefaultRulePhaseActions_PreREQUEST = this.DefaultRulePhaseActions_PreREQUEST;
            context.Description = this.Description;
            context.ProxyConfigurationName = this.ProxyConfigurationName;
            #if MODULAR
            if (this.ProxyConfigurationName == null && ParameterWasBound(nameof(this.ProxyConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProxyConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RuleGroupArn != null)
            {
                context.RuleGroupArn = new List<System.String>(this.RuleGroupArn);
            }
            if (this.RuleGroupName != null)
            {
                context.RuleGroupName = new List<System.String>(this.RuleGroupName);
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
            var request = new Amazon.NetworkFirewall.Model.CreateProxyConfigurationRequest();
            
            
             // populate DefaultRulePhaseActions
            var requestDefaultRulePhaseActionsIsNull = true;
            request.DefaultRulePhaseActions = new Amazon.NetworkFirewall.Model.ProxyConfigDefaultRulePhaseActionsRequest();
            Amazon.NetworkFirewall.ProxyRulePhaseAction requestDefaultRulePhaseActions_defaultRulePhaseActions_PostRESPONSE = null;
            if (cmdletContext.DefaultRulePhaseActions_PostRESPONSE != null)
            {
                requestDefaultRulePhaseActions_defaultRulePhaseActions_PostRESPONSE = cmdletContext.DefaultRulePhaseActions_PostRESPONSE;
            }
            if (requestDefaultRulePhaseActions_defaultRulePhaseActions_PostRESPONSE != null)
            {
                request.DefaultRulePhaseActions.PostRESPONSE = requestDefaultRulePhaseActions_defaultRulePhaseActions_PostRESPONSE;
                requestDefaultRulePhaseActionsIsNull = false;
            }
            Amazon.NetworkFirewall.ProxyRulePhaseAction requestDefaultRulePhaseActions_defaultRulePhaseActions_PreDNS = null;
            if (cmdletContext.DefaultRulePhaseActions_PreDNS != null)
            {
                requestDefaultRulePhaseActions_defaultRulePhaseActions_PreDNS = cmdletContext.DefaultRulePhaseActions_PreDNS;
            }
            if (requestDefaultRulePhaseActions_defaultRulePhaseActions_PreDNS != null)
            {
                request.DefaultRulePhaseActions.PreDNS = requestDefaultRulePhaseActions_defaultRulePhaseActions_PreDNS;
                requestDefaultRulePhaseActionsIsNull = false;
            }
            Amazon.NetworkFirewall.ProxyRulePhaseAction requestDefaultRulePhaseActions_defaultRulePhaseActions_PreREQUEST = null;
            if (cmdletContext.DefaultRulePhaseActions_PreREQUEST != null)
            {
                requestDefaultRulePhaseActions_defaultRulePhaseActions_PreREQUEST = cmdletContext.DefaultRulePhaseActions_PreREQUEST;
            }
            if (requestDefaultRulePhaseActions_defaultRulePhaseActions_PreREQUEST != null)
            {
                request.DefaultRulePhaseActions.PreREQUEST = requestDefaultRulePhaseActions_defaultRulePhaseActions_PreREQUEST;
                requestDefaultRulePhaseActionsIsNull = false;
            }
             // determine if request.DefaultRulePhaseActions should be set to null
            if (requestDefaultRulePhaseActionsIsNull)
            {
                request.DefaultRulePhaseActions = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ProxyConfigurationName != null)
            {
                request.ProxyConfigurationName = cmdletContext.ProxyConfigurationName;
            }
            if (cmdletContext.RuleGroupArn != null)
            {
                request.RuleGroupArns = cmdletContext.RuleGroupArn;
            }
            if (cmdletContext.RuleGroupName != null)
            {
                request.RuleGroupNames = cmdletContext.RuleGroupName;
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
        
        private Amazon.NetworkFirewall.Model.CreateProxyConfigurationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.CreateProxyConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "CreateProxyConfiguration");
            try
            {
                return client.CreateProxyConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PostRESPONSE { get; set; }
            public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PreDNS { get; set; }
            public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PreREQUEST { get; set; }
            public System.String Description { get; set; }
            public System.String ProxyConfigurationName { get; set; }
            public List<System.String> RuleGroupArn { get; set; }
            public List<System.String> RuleGroupName { get; set; }
            public List<Amazon.NetworkFirewall.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.CreateProxyConfigurationResponse, NewNWFWProxyConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
