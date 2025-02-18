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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Deletes all rule groups that are managed by Firewall Manager from the specified <a>WebACL</a>.
    /// 
    /// 
    ///  
    /// <para>
    /// You can only use this if <c>ManagedByFirewallManager</c> and <c>RetrofittedByFirewallManager</c>
    /// are both false in the web ACL. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "WAF2FirewallManagerRuleGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF V2 DeleteFirewallManagerRuleGroups API operation.", Operation = new[] {"DeleteFirewallManagerRuleGroups"}, SelectReturnType = typeof(Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveWAF2FirewallManagerRuleGroupCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter WebACLArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the web ACL.</para>
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
        public System.String WebACLArn { get; set; }
        #endregion
        
        #region Parameter WebACLLockToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. WAF returns a token to your <c>get</c> and <c>list</c>
        /// requests, to mark the state of the entity at the time of the request. To make changes
        /// to the entity associated with the token, you provide the token to operations like
        /// <c>update</c> and <c>delete</c>. WAF uses the token to ensure that no changes have
        /// been made to the entity since you last retrieved it. If a change has been made, the
        /// update fails with a <c>WAFOptimisticLockException</c>. If this happens, perform another
        /// <c>get</c>, and use the new token returned by that operation. </para>
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
        public System.String WebACLLockToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NextWebACLLockToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NextWebACLLockToken";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WebACLArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-WAF2FirewallManagerRuleGroup (DeleteFirewallManagerRuleGroups)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsResponse, RemoveWAF2FirewallManagerRuleGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.WebACLArn = this.WebACLArn;
            #if MODULAR
            if (this.WebACLArn == null && ParameterWasBound(nameof(this.WebACLArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WebACLArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WebACLLockToken = this.WebACLLockToken;
            #if MODULAR
            if (this.WebACLLockToken == null && ParameterWasBound(nameof(this.WebACLLockToken)))
            {
                WriteWarning("You are passing $null as a value for parameter WebACLLockToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsRequest();
            
            if (cmdletContext.WebACLArn != null)
            {
                request.WebACLArn = cmdletContext.WebACLArn;
            }
            if (cmdletContext.WebACLLockToken != null)
            {
                request.WebACLLockToken = cmdletContext.WebACLLockToken;
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
        
        private Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "DeleteFirewallManagerRuleGroups");
            try
            {
                return client.DeleteFirewallManagerRuleGroupsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String WebACLArn { get; set; }
            public System.String WebACLLockToken { get; set; }
            public System.Func<Amazon.WAFV2.Model.DeleteFirewallManagerRuleGroupsResponse, RemoveWAF2FirewallManagerRuleGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NextWebACLLockToken;
        }
        
    }
}
