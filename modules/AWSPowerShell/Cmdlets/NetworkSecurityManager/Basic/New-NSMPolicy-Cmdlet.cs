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
using Amazon.NetworkSecurityManager;
using Amazon.NetworkSecurityManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NSM
{
    /// <summary>
    /// Creates a policy. A policy combines templates and rules with enforcement settings
    /// for a firewall type, such as AWS WAF or AWS Shield Advanced. Use <c>isPublished</c>
    /// to create the policy in published (<c>ACTIVE</c>) or draft (<c>DRAFT</c>) state.
    /// </summary>
    [Cmdlet("New", "NSMPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkSecurityManager.Model.CreatePolicyResponse")]
    [AWSCmdlet("Calls the AWS Network Security Manager Customer API CreatePolicy API operation.", Operation = new[] {"CreatePolicy"}, SelectReturnType = typeof(Amazon.NetworkSecurityManager.Model.CreatePolicyResponse))]
    [AWSCmdletOutput("Amazon.NetworkSecurityManager.Model.CreatePolicyResponse",
        "This cmdlet returns an Amazon.NetworkSecurityManager.Model.CreatePolicyResponse object containing multiple properties."
    )]
    public partial class NewNSMPolicyCmdlet : AmazonNetworkSecurityManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociatedTemplateAndRuleList
        /// <summary>
        /// <para>
        /// <para>The templates and rules to associate with the policy. For AWS WAF policies, specify
        /// 1 to 100 templates or rules, of which at most 2 can be templates. For AWS Shield Advanced
        /// policies, this list must be empty.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkSecurityManager.Model.TemplateOrRuleReference[] AssociatedTemplateAndRuleList { get; set; }
        #endregion
        
        #region Parameter PolicyConfiguration_WafConfig_ConflictResolution
        /// <summary>
        /// <para>
        /// <para>The conflict-resolution strategy for AWS WAF policies. Required for AWS WAF policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkSecurityManager.WAFConflictResolutionOptions")]
        public Amazon.NetworkSecurityManager.WAFConflictResolutionOptions PolicyConfiguration_WafConfig_ConflictResolution { get; set; }
        #endregion
        
        #region Parameter PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution
        /// <summary>
        /// <para>
        /// <para>Determines how AWS Network Security Manager handles remediation when a resource already
        /// has a customer-created web ACL. Required for AWS WAF policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkSecurityManager.ExistingCustomerWebACLResolution")]
        public Amazon.NetworkSecurityManager.ExistingCustomerWebACLResolution PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution { get; set; }
        #endregion
        
        #region Parameter FirewallType
        /// <summary>
        /// <para>
        /// <para>The firewall type associated with the resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NetworkSecurityManager.PolicyFirewallType")]
        public Amazon.NetworkSecurityManager.PolicyFirewallType FirewallType { get; set; }
        #endregion
        
        #region Parameter IsPublished
        /// <summary>
        /// <para>
        /// <para>Specifies whether to publish the resource. When <c>true</c>, the resource is saved
        /// in published (<c>ACTIVE</c>) state. When <c>false</c>, it is saved as a draft (<c>DRAFT</c>).
        /// Default: <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsPublished { get; set; }
        #endregion
        
        #region Parameter PolicyDescription
        /// <summary>
        /// <para>
        /// <para>A description of the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyDescription { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
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
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The priority of the resource. A lower number indicates a higher priority.</para>
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
        
        #region Parameter PolicyConfiguration_RemediationEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether AWS Network Security Manager automatically remediates noncompliant
        /// resources. Default: <c>false</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? PolicyConfiguration_RemediationEnabled { get; set; }
        #endregion
        
        #region Parameter PolicyConfiguration_ResourcesCleanUp
        /// <summary>
        /// <para>
        /// <para>Specifies whether AWS Network Security Manager automatically removes the resources
        /// it created when they are no longer needed. Default: <c>false</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? PolicyConfiguration_ResourcesCleanUp { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the resource when it is created.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure that the operation completes
        /// no more than one time. If you retry a request with the same client token and the same
        /// parameters, the service returns the result of the original successful request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkSecurityManager.Model.CreatePolicyResponse).
        /// Specifying the name of a property of type Amazon.NetworkSecurityManager.Model.CreatePolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NSMPolicy (CreatePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkSecurityManager.Model.CreatePolicyResponse, NewNSMPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssociatedTemplateAndRuleList != null)
            {
                context.AssociatedTemplateAndRuleList = new List<Amazon.NetworkSecurityManager.Model.TemplateOrRuleReference>(this.AssociatedTemplateAndRuleList);
            }
            context.ClientToken = this.ClientToken;
            context.FirewallType = this.FirewallType;
            #if MODULAR
            if (this.FirewallType == null && ParameterWasBound(nameof(this.FirewallType)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IsPublished = this.IsPublished;
            context.PolicyConfiguration_RemediationEnabled = this.PolicyConfiguration_RemediationEnabled;
            #if MODULAR
            if (this.PolicyConfiguration_RemediationEnabled == null && ParameterWasBound(nameof(this.PolicyConfiguration_RemediationEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyConfiguration_RemediationEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyConfiguration_ResourcesCleanUp = this.PolicyConfiguration_ResourcesCleanUp;
            #if MODULAR
            if (this.PolicyConfiguration_ResourcesCleanUp == null && ParameterWasBound(nameof(this.PolicyConfiguration_ResourcesCleanUp)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyConfiguration_ResourcesCleanUp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyConfiguration_WafConfig_ConflictResolution = this.PolicyConfiguration_WafConfig_ConflictResolution;
            context.PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution = this.PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution;
            context.PolicyDescription = this.PolicyDescription;
            context.PolicyName = this.PolicyName;
            #if MODULAR
            if (this.PolicyName == null && ParameterWasBound(nameof(this.PolicyName)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.NetworkSecurityManager.Model.CreatePolicyRequest();
            
            if (cmdletContext.AssociatedTemplateAndRuleList != null)
            {
                request.AssociatedTemplateAndRuleList = cmdletContext.AssociatedTemplateAndRuleList;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.FirewallType != null)
            {
                request.FirewallType = cmdletContext.FirewallType;
            }
            if (cmdletContext.IsPublished != null)
            {
                request.IsPublished = cmdletContext.IsPublished.Value;
            }
            
             // populate PolicyConfiguration
            var requestPolicyConfigurationIsNull = true;
            request.PolicyConfiguration = new Amazon.NetworkSecurityManager.Model.PolicyConfiguration();
            System.Boolean? requestPolicyConfiguration_policyConfiguration_RemediationEnabled = null;
            if (cmdletContext.PolicyConfiguration_RemediationEnabled != null)
            {
                requestPolicyConfiguration_policyConfiguration_RemediationEnabled = cmdletContext.PolicyConfiguration_RemediationEnabled.Value;
            }
            if (requestPolicyConfiguration_policyConfiguration_RemediationEnabled != null)
            {
                request.PolicyConfiguration.RemediationEnabled = requestPolicyConfiguration_policyConfiguration_RemediationEnabled.Value;
                requestPolicyConfigurationIsNull = false;
            }
            System.Boolean? requestPolicyConfiguration_policyConfiguration_ResourcesCleanUp = null;
            if (cmdletContext.PolicyConfiguration_ResourcesCleanUp != null)
            {
                requestPolicyConfiguration_policyConfiguration_ResourcesCleanUp = cmdletContext.PolicyConfiguration_ResourcesCleanUp.Value;
            }
            if (requestPolicyConfiguration_policyConfiguration_ResourcesCleanUp != null)
            {
                request.PolicyConfiguration.ResourcesCleanUp = requestPolicyConfiguration_policyConfiguration_ResourcesCleanUp.Value;
                requestPolicyConfigurationIsNull = false;
            }
            Amazon.NetworkSecurityManager.Model.WafConfig requestPolicyConfiguration_policyConfiguration_WafConfig = null;
            
             // populate WafConfig
            var requestPolicyConfiguration_policyConfiguration_WafConfigIsNull = true;
            requestPolicyConfiguration_policyConfiguration_WafConfig = new Amazon.NetworkSecurityManager.Model.WafConfig();
            Amazon.NetworkSecurityManager.WAFConflictResolutionOptions requestPolicyConfiguration_policyConfiguration_WafConfig_policyConfiguration_WafConfig_ConflictResolution = null;
            if (cmdletContext.PolicyConfiguration_WafConfig_ConflictResolution != null)
            {
                requestPolicyConfiguration_policyConfiguration_WafConfig_policyConfiguration_WafConfig_ConflictResolution = cmdletContext.PolicyConfiguration_WafConfig_ConflictResolution;
            }
            if (requestPolicyConfiguration_policyConfiguration_WafConfig_policyConfiguration_WafConfig_ConflictResolution != null)
            {
                requestPolicyConfiguration_policyConfiguration_WafConfig.ConflictResolution = requestPolicyConfiguration_policyConfiguration_WafConfig_policyConfiguration_WafConfig_ConflictResolution;
                requestPolicyConfiguration_policyConfiguration_WafConfigIsNull = false;
            }
            Amazon.NetworkSecurityManager.ExistingCustomerWebACLResolution requestPolicyConfiguration_policyConfiguration_WafConfig_policyConfiguration_WafConfig_ExistingCustomerWebACLResolution = null;
            if (cmdletContext.PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution != null)
            {
                requestPolicyConfiguration_policyConfiguration_WafConfig_policyConfiguration_WafConfig_ExistingCustomerWebACLResolution = cmdletContext.PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution;
            }
            if (requestPolicyConfiguration_policyConfiguration_WafConfig_policyConfiguration_WafConfig_ExistingCustomerWebACLResolution != null)
            {
                requestPolicyConfiguration_policyConfiguration_WafConfig.ExistingCustomerWebACLResolution = requestPolicyConfiguration_policyConfiguration_WafConfig_policyConfiguration_WafConfig_ExistingCustomerWebACLResolution;
                requestPolicyConfiguration_policyConfiguration_WafConfigIsNull = false;
            }
             // determine if requestPolicyConfiguration_policyConfiguration_WafConfig should be set to null
            if (requestPolicyConfiguration_policyConfiguration_WafConfigIsNull)
            {
                requestPolicyConfiguration_policyConfiguration_WafConfig = null;
            }
            if (requestPolicyConfiguration_policyConfiguration_WafConfig != null)
            {
                request.PolicyConfiguration.WafConfig = requestPolicyConfiguration_policyConfiguration_WafConfig;
                requestPolicyConfigurationIsNull = false;
            }
             // determine if request.PolicyConfiguration should be set to null
            if (requestPolicyConfigurationIsNull)
            {
                request.PolicyConfiguration = null;
            }
            if (cmdletContext.PolicyDescription != null)
            {
                request.PolicyDescription = cmdletContext.PolicyDescription;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
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
        
        private Amazon.NetworkSecurityManager.Model.CreatePolicyResponse CallAWSServiceOperation(IAmazonNetworkSecurityManager client, Amazon.NetworkSecurityManager.Model.CreatePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Security Manager Customer API", "CreatePolicy");
            try
            {
                return client.CreatePolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.NetworkSecurityManager.Model.TemplateOrRuleReference> AssociatedTemplateAndRuleList { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.NetworkSecurityManager.PolicyFirewallType FirewallType { get; set; }
            public System.Boolean? IsPublished { get; set; }
            public System.Boolean? PolicyConfiguration_RemediationEnabled { get; set; }
            public System.Boolean? PolicyConfiguration_ResourcesCleanUp { get; set; }
            public Amazon.NetworkSecurityManager.WAFConflictResolutionOptions PolicyConfiguration_WafConfig_ConflictResolution { get; set; }
            public Amazon.NetworkSecurityManager.ExistingCustomerWebACLResolution PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution { get; set; }
            public System.String PolicyDescription { get; set; }
            public System.String PolicyName { get; set; }
            public System.Int32? Priority { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.NetworkSecurityManager.Model.CreatePolicyResponse, NewNSMPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
