/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// Inserts or deletes <a>Predicate</a> objects in a rule and updates the <code>RateLimit</code>
    /// in the rule. 
    /// 
    ///  
    /// <para>
    /// Each <code>Predicate</code> object identifies a predicate, such as a <a>ByteMatchSet</a>
    /// or an <a>IPSet</a>, that specifies the web requests that you want to block or count.
    /// The <code>RateLimit</code> specifies the number of requests every five minutes that
    /// triggers the rule.
    /// </para><para>
    /// If you add more than one predicate to a <code>RateBasedRule</code>, a request must
    /// match all the predicates and exceed the <code>RateLimit</code> to be counted or blocked.
    /// For example, suppose you add the following to a <code>RateBasedRule</code>:
    /// </para><ul><li><para>
    /// An <code>IPSet</code> that matches the IP address <code>192.0.2.44/32</code></para></li><li><para>
    /// A <code>ByteMatchSet</code> that matches <code>BadBot</code> in the <code>User-Agent</code>
    /// header
    /// </para></li></ul><para>
    /// Further, you specify a <code>RateLimit</code> of 15,000.
    /// </para><para>
    /// You then add the <code>RateBasedRule</code> to a <code>WebACL</code> and specify that
    /// you want to block requests that satisfy the rule. For a request to be blocked, it
    /// must come from the IP address 192.0.2.44 <i>and</i> the <code>User-Agent</code> header
    /// in the request must contain the value <code>BadBot</code>. Further, requests that
    /// match these two conditions much be received at a rate of more than 15,000 every five
    /// minutes. If the rate drops below this limit, AWS WAF no longer blocks the requests.
    /// </para><para>
    /// As a second example, suppose you want to limit requests to a particular page on your
    /// site. To do this, you could add the following to a <code>RateBasedRule</code>:
    /// </para><ul><li><para>
    /// A <code>ByteMatchSet</code> with <code>FieldToMatch</code> of <code>URI</code></para></li><li><para>
    /// A <code>PositionalConstraint</code> of <code>STARTS_WITH</code></para></li><li><para>
    /// A <code>TargetString</code> of <code>login</code></para></li></ul><para>
    /// Further, you specify a <code>RateLimit</code> of 15,000.
    /// </para><para>
    /// By adding this <code>RateBasedRule</code> to a <code>WebACL</code>, you could limit
    /// requests to your login page without affecting the rest of your site.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFRateBasedRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF UpdateRateBasedRule API operation.", Operation = new[] {"UpdateRateBasedRule"}, SelectReturnType = typeof(Amazon.WAF.Model.UpdateRateBasedRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAF.Model.UpdateRateBasedRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAF.Model.UpdateRateBasedRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWAFRateBasedRuleCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
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
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter RateLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of requests, which have an identical value in the field specified
        /// by the <code>RateKey</code>, allowed in a five-minute period. If the number of requests
        /// exceeds the <code>RateLimit</code> and the other predicates specified in the rule
        /// are also met, AWS WAF triggers the action that is specified for this rule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? RateLimit { get; set; }
        #endregion
        
        #region Parameter RuleId
        /// <summary>
        /// <para>
        /// <para>The <code>RuleId</code> of the <code>RateBasedRule</code> that you want to update.
        /// <code>RuleId</code> is returned by <code>CreateRateBasedRule</code> and by <a>ListRateBasedRules</a>.</para>
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
        public System.String RuleId { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <code>RuleUpdate</code> objects that you want to insert into or delete
        /// from a <a>RateBasedRule</a>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Updates")]
        public Amazon.WAF.Model.RuleUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.UpdateRateBasedRuleResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.UpdateRateBasedRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFRateBasedRule (UpdateRateBasedRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.UpdateRateBasedRuleResponse, UpdateWAFRateBasedRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RateLimit = this.RateLimit;
            #if MODULAR
            if (this.RateLimit == null && ParameterWasBound(nameof(this.RateLimit)))
            {
                WriteWarning("You are passing $null as a value for parameter RateLimit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleId = this.RuleId;
            #if MODULAR
            if (this.RuleId == null && ParameterWasBound(nameof(this.RuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Update != null)
            {
                context.Update = new List<Amazon.WAF.Model.RuleUpdate>(this.Update);
            }
            #if MODULAR
            if (this.Update == null && ParameterWasBound(nameof(this.Update)))
            {
                WriteWarning("You are passing $null as a value for parameter Update which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAF.Model.UpdateRateBasedRuleRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.RateLimit != null)
            {
                request.RateLimit = cmdletContext.RateLimit.Value;
            }
            if (cmdletContext.RuleId != null)
            {
                request.RuleId = cmdletContext.RuleId;
            }
            if (cmdletContext.Update != null)
            {
                request.Updates = cmdletContext.Update;
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
        
        private Amazon.WAF.Model.UpdateRateBasedRuleResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.UpdateRateBasedRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "UpdateRateBasedRule");
            try
            {
                #if DESKTOP
                return client.UpdateRateBasedRule(request);
                #elif CORECLR
                return client.UpdateRateBasedRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String ChangeToken { get; set; }
            public System.Int64? RateLimit { get; set; }
            public System.String RuleId { get; set; }
            public List<Amazon.WAF.Model.RuleUpdate> Update { get; set; }
            public System.Func<Amazon.WAF.Model.UpdateRateBasedRuleResponse, UpdateWAFRateBasedRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
