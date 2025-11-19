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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the allocation rules in an IPAM policy.
    /// 
    ///  
    /// <para>
    /// An IPAM policy is a set of rules that define how public IPv4 addresses from IPAM pools
    /// are allocated to Amazon Web Services resources. Each rule maps an Amazon Web Services
    /// service to IPAM pools that the service will use to get IP addresses. A single policy
    /// can have multiple rules and be applied to multiple Amazon Web Services Regions. If
    /// the IPAM pool run out of addresses then the services fallback to Amazon-provided IP
    /// addresses. A policy can be applied to an individual Amazon Web Services account or
    /// an entity within Amazon Web Services Organizations.
    /// </para><para>
    /// Allocation rules are optional configurations within an IPAM policy that map Amazon
    /// Web Services resource types to specific IPAM pools. If no rules are defined, the resource
    /// types default to using Amazon-provided IP addresses.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2IpamPolicyAllocationRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamPolicyDocument")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyIpamPolicyAllocationRules API operation.", Operation = new[] {"ModifyIpamPolicyAllocationRules"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamPolicyDocument or Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamPolicyDocument object.",
        "The service call response (type Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2IpamPolicyAllocationRuleCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllocationRule
        /// <summary>
        /// <para>
        /// <para>The new allocation rules to apply to the IPAM policy.</para><para>Allocation rules are optional configurations within an IPAM policy that map Amazon
        /// Web Services resource types to specific IPAM pools. If no rules are defined, the resource
        /// types default to using Amazon-provided IP addresses.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllocationRules")]
        public Amazon.EC2.Model.IpamPolicyAllocationRuleRequest[] AllocationRule { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>A check for whether you have the required permissions for the action without actually
        /// making the request and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter IpamPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM policy whose allocation rules you want to modify.</para>
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
        public System.String IpamPolicyId { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale for which to modify the allocation rules.</para>
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
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type for which to modify the allocation rules.</para><para>The Amazon Web Services service or resource type that can use IP addresses through
        /// IPAM policies. Supported services and resource types include:</para><ul><li><para>Elastic IP addresses</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.IpamPolicyResourceType")]
        public Amazon.EC2.IpamPolicyResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamPolicyDocument'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamPolicyDocument";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2IpamPolicyAllocationRule (ModifyIpamPolicyAllocationRules)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesResponse, EditEC2IpamPolicyAllocationRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllocationRule != null)
            {
                context.AllocationRule = new List<Amazon.EC2.Model.IpamPolicyAllocationRuleRequest>(this.AllocationRule);
            }
            context.DryRun = this.DryRun;
            context.IpamPolicyId = this.IpamPolicyId;
            #if MODULAR
            if (this.IpamPolicyId == null && ParameterWasBound(nameof(this.IpamPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Locale = this.Locale;
            #if MODULAR
            if (this.Locale == null && ParameterWasBound(nameof(this.Locale)))
            {
                WriteWarning("You are passing $null as a value for parameter Locale which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesRequest();
            
            if (cmdletContext.AllocationRule != null)
            {
                request.AllocationRules = cmdletContext.AllocationRule;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.IpamPolicyId != null)
            {
                request.IpamPolicyId = cmdletContext.IpamPolicyId;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyIpamPolicyAllocationRules");
            try
            {
                return client.ModifyIpamPolicyAllocationRulesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.IpamPolicyAllocationRuleRequest> AllocationRule { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String IpamPolicyId { get; set; }
            public System.String Locale { get; set; }
            public Amazon.EC2.IpamPolicyResourceType ResourceType { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyIpamPolicyAllocationRulesResponse, EditEC2IpamPolicyAllocationRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPolicyDocument;
        }
        
    }
}
