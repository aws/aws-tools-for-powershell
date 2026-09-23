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
    /// Updates the specified rule. To prevent conflicting concurrent updates, provide the
    /// current <c>updateToken</c>. Use <c>isPublished</c> to publish the update or keep the
    /// rule as a draft.
    /// </summary>
    [Cmdlet("Update", "NSMRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkSecurityManager.Model.UpdateRuleResponse")]
    [AWSCmdlet("Calls the AWS Network Security Manager Customer API UpdateRule API operation.", Operation = new[] {"UpdateRule"}, SelectReturnType = typeof(Amazon.NetworkSecurityManager.Model.UpdateRuleResponse))]
    [AWSCmdletOutput("Amazon.NetworkSecurityManager.Model.UpdateRuleResponse",
        "This cmdlet returns an Amazon.NetworkSecurityManager.Model.UpdateRuleResponse object containing multiple properties."
    )]
    public partial class UpdateNSMRuleCmdlet : AmazonNetworkSecurityManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>The firewall configuration for the rule, as a JSON document. The structure depends
        /// on the rule's firewall type and rule type. For an AWS WAF <c>INSPECTION</c> rule,
        /// provide an AWS WAF rule group. For an AWS WAF <c>CONFIGURATION</c> rule, provide a
        /// single web ACL setting, such as <c>DefaultAction</c> or <c>VisibilityConfig</c>; use
        /// <c>wafConfigDataType</c> to declare which setting the document contains. For the schema
        /// of each setting and complete examples, see <a href="https://docs.aws.amazon.com/network-security-manager/latest/devguide/what-is.html">Writing
        /// rule configurations</a> in the <i>AWS Network Security Manager Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject Configuration { get; set; }
        #endregion
        
        #region Parameter IsPublished
        /// <summary>
        /// <para>
        /// <para>Specifies whether to publish the resource. When <c>true</c>, the resource is saved
        /// in published (<c>ACTIVE</c>) state. When <c>false</c>, it is saved as a draft (<c>DRAFT</c>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? IsPublished { get; set; }
        #endregion
        
        #region Parameter RuleDescription
        /// <summary>
        /// <para>
        /// <para>A description of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleDescription { get; set; }
        #endregion
        
        #region Parameter RuleIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the rule. This is the rule's Amazon Resource Name (ARN).</para>
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
        public System.String RuleIdentifier { get; set; }
        #endregion
        
        #region Parameter RuleType
        /// <summary>
        /// <para>
        /// <para>The type of the rule. <c>CONFIGURATION</c> rules contain firewall settings, and <c>INSPECTION</c>
        /// rules contain rule groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkSecurityManager.RuleType")]
        public Amazon.NetworkSecurityManager.RuleType RuleType { get; set; }
        #endregion
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic concurrency control. Each read and write returns an <c>updateToken</c>.
        /// Provide the most recent value on your next update to detect and prevent conflicting
        /// concurrent modifications.</para>
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
        public System.String UpdateToken { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkSecurityManager.Model.UpdateRuleResponse).
        /// Specifying the name of a property of type Amazon.NetworkSecurityManager.Model.UpdateRuleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NSMRule (UpdateRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkSecurityManager.Model.UpdateRuleResponse, UpdateNSMRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Configuration = this.Configuration;
            context.IsPublished = this.IsPublished;
            #if MODULAR
            if (this.IsPublished == null && ParameterWasBound(nameof(this.IsPublished)))
            {
                WriteWarning("You are passing $null as a value for parameter IsPublished which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleDescription = this.RuleDescription;
            context.RuleIdentifier = this.RuleIdentifier;
            #if MODULAR
            if (this.RuleIdentifier == null && ParameterWasBound(nameof(this.RuleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleType = this.RuleType;
            context.UpdateToken = this.UpdateToken;
            #if MODULAR
            if (this.UpdateToken == null && ParameterWasBound(nameof(this.UpdateToken)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkSecurityManager.Model.UpdateRuleRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Configuration);
            }
            if (cmdletContext.IsPublished != null)
            {
                request.IsPublished = cmdletContext.IsPublished.Value;
            }
            if (cmdletContext.RuleDescription != null)
            {
                request.RuleDescription = cmdletContext.RuleDescription;
            }
            if (cmdletContext.RuleIdentifier != null)
            {
                request.RuleIdentifier = cmdletContext.RuleIdentifier;
            }
            if (cmdletContext.RuleType != null)
            {
                request.RuleType = cmdletContext.RuleType;
            }
            if (cmdletContext.UpdateToken != null)
            {
                request.UpdateToken = cmdletContext.UpdateToken;
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
        
        private Amazon.NetworkSecurityManager.Model.UpdateRuleResponse CallAWSServiceOperation(IAmazonNetworkSecurityManager client, Amazon.NetworkSecurityManager.Model.UpdateRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Security Manager Customer API", "UpdateRule");
            try
            {
                return client.UpdateRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Management.Automation.PSObject Configuration { get; set; }
            public System.Boolean? IsPublished { get; set; }
            public System.String RuleDescription { get; set; }
            public System.String RuleIdentifier { get; set; }
            public Amazon.NetworkSecurityManager.RuleType RuleType { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkSecurityManager.Model.UpdateRuleResponse, UpdateNSMRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
