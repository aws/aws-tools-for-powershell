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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Inserts or deletes <a>Predicate</a> objects in a rule and updates the <c>RateLimit</c>
    /// in the rule. 
    /// </para><para>
    /// Each <c>Predicate</c> object identifies a predicate, such as a <a>ByteMatchSet</a>
    /// or an <a>IPSet</a>, that specifies the web requests that you want to block or count.
    /// The <c>RateLimit</c> specifies the number of requests every five minutes that triggers
    /// the rule.
    /// </para><para>
    /// If you add more than one predicate to a <c>RateBasedRule</c>, a request must match
    /// all the predicates and exceed the <c>RateLimit</c> to be counted or blocked. For example,
    /// suppose you add the following to a <c>RateBasedRule</c>:
    /// </para><ul><li><para>
    /// An <c>IPSet</c> that matches the IP address <c>192.0.2.44/32</c></para></li><li><para>
    /// A <c>ByteMatchSet</c> that matches <c>BadBot</c> in the <c>User-Agent</c> header
    /// </para></li></ul><para>
    /// Further, you specify a <c>RateLimit</c> of 1,000.
    /// </para><para>
    /// You then add the <c>RateBasedRule</c> to a <c>WebACL</c> and specify that you want
    /// to block requests that satisfy the rule. For a request to be blocked, it must come
    /// from the IP address 192.0.2.44 <i>and</i> the <c>User-Agent</c> header in the request
    /// must contain the value <c>BadBot</c>. Further, requests that match these two conditions
    /// much be received at a rate of more than 1,000 every five minutes. If the rate drops
    /// below this limit, AWS WAF no longer blocks the requests.
    /// </para><para>
    /// As a second example, suppose you want to limit requests to a particular page on your
    /// site. To do this, you could add the following to a <c>RateBasedRule</c>:
    /// </para><ul><li><para>
    /// A <c>ByteMatchSet</c> with <c>FieldToMatch</c> of <c>URI</c></para></li><li><para>
    /// A <c>PositionalConstraint</c> of <c>STARTS_WITH</c></para></li><li><para>
    /// A <c>TargetString</c> of <c>login</c></para></li></ul><para>
    /// Further, you specify a <c>RateLimit</c> of 1,000.
    /// </para><para>
    /// By adding this <c>RateBasedRule</c> to a <c>WebACL</c>, you could limit requests to
    /// your login page without affecting the rest of your site.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFRRateBasedRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF Regional UpdateRateBasedRule API operation.", Operation = new[] {"UpdateRateBasedRule"}, SelectReturnType = typeof(Amazon.WAFRegional.Model.UpdateRateBasedRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFRegional.Model.UpdateRateBasedRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAFRegional.Model.UpdateRateBasedRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWAFRRateBasedRuleCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// by the <c>RateKey</c>, allowed in a five-minute period. If the number of requests
        /// exceeds the <c>RateLimit</c> and the other predicates specified in the rule are also
        /// met, AWS WAF triggers the action that is specified for this rule.</para>
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
        /// <para>The <c>RuleId</c> of the <c>RateBasedRule</c> that you want to update. <c>RuleId</c>
        /// is returned by <c>CreateRateBasedRule</c> and by <a>ListRateBasedRules</a>.</para>
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
        /// <para>An array of <c>RuleUpdate</c> objects that you want to insert into or delete from
        /// a <a>RateBasedRule</a>. </para>
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
        public Amazon.WAFRegional.Model.RuleUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFRegional.Model.UpdateRateBasedRuleResponse).
        /// Specifying the name of a property of type Amazon.WAFRegional.Model.UpdateRateBasedRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeToken";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFRRateBasedRule (UpdateRateBasedRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFRegional.Model.UpdateRateBasedRuleResponse, UpdateWAFRRateBasedRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
                context.Update = new List<Amazon.WAFRegional.Model.RuleUpdate>(this.Update);
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
            var request = new Amazon.WAFRegional.Model.UpdateRateBasedRuleRequest();
            
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
        
        private Amazon.WAFRegional.Model.UpdateRateBasedRuleResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.UpdateRateBasedRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "UpdateRateBasedRule");
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
            public List<Amazon.WAFRegional.Model.RuleUpdate> Update { get; set; }
            public System.Func<Amazon.WAFRegional.Model.UpdateRateBasedRuleResponse, UpdateWAFRRateBasedRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
