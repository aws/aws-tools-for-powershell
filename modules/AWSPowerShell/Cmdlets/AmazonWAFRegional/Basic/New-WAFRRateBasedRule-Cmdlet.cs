/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a <a>RateBasedRule</a>. The <code>RateBasedRule</code> contains a <code>RateLimit</code>,
    /// which specifies the maximum number of requests that AWS WAF allows from a specified
    /// IP address in a five-minute period. The <code>RateBasedRule</code> also contains the
    /// <code>IPSet</code> objects, <code>ByteMatchSet</code> objects, and other predicates
    /// that identify the requests that you want to count or block if these requests exceed
    /// the <code>RateLimit</code>.
    /// 
    ///  
    /// <para>
    /// If you add more than one predicate to a <code>RateBasedRule</code>, a request not
    /// only must exceed the <code>RateLimit</code>, but it also must match all the specifications
    /// to be counted or blocked. For example, suppose you add the following to a <code>RateBasedRule</code>:
    /// </para><ul><li><para>
    /// An <code>IPSet</code> that matches the IP address <code>192.0.2.44/32</code></para></li><li><para>
    /// A <code>ByteMatchSet</code> that matches <code>BadBot</code> in the <code>User-Agent</code>
    /// header
    /// </para></li></ul><para>
    /// Further, you specify a <code>RateLimit</code> of 15,000.
    /// </para><para>
    /// You then add the <code>RateBasedRule</code> to a <code>WebACL</code> and specify that
    /// you want to block requests that meet the conditions in the rule. For a request to
    /// be blocked, it must come from the IP address 192.0.2.44 <i>and</i> the <code>User-Agent</code>
    /// header in the request must contain the value <code>BadBot</code>. Further, requests
    /// that match these two conditions must be received at a rate of more than 15,000 requests
    /// every five minutes. If both conditions are met and the rate is exceeded, AWS WAF blocks
    /// the requests. If the rate drops below 15,000 for a five-minute period, AWS WAF no
    /// longer blocks the requests.
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
    /// </para><para>
    /// To create and configure a <code>RateBasedRule</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Create and update the predicates that you want to include in the rule. For more information,
    /// see <a>CreateByteMatchSet</a>, <a>CreateIPSet</a>, and <a>CreateSqlInjectionMatchSet</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of a <code>CreateRule</code> request.
    /// </para></li><li><para>
    /// Submit a <code>CreateRateBasedRule</code> request.
    /// </para></li><li><para>
    /// Use <code>GetChangeToken</code> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <a>UpdateRule</a> request.
    /// </para></li><li><para>
    /// Submit an <code>UpdateRateBasedRule</code> request to specify the predicates that
    /// you want to include in the rule.
    /// </para></li><li><para>
    /// Create and update a <code>WebACL</code> that contains the <code>RateBasedRule</code>.
    /// For more information, see <a>CreateWebACL</a>.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAFRRateBasedRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAFRegional.Model.CreateRateBasedRuleResponse")]
    [AWSCmdlet("Invokes the CreateRateBasedRule operation against AWS WAF Regional.", Operation = new[] {"CreateRateBasedRule"})]
    [AWSCmdletOutput("Amazon.WAFRegional.Model.CreateRateBasedRuleResponse",
        "This cmdlet returns a Amazon.WAFRegional.Model.CreateRateBasedRuleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWAFRRateBasedRuleCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The <code>ChangeToken</code> that you used to submit the <code>CreateRateBasedRule</code>
        /// request. You can also use this value to query the status of the request. For more
        /// information, see <a>GetChangeTokenStatus</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>A friendly name or description for the metrics for this <code>RateBasedRule</code>.
        /// The name can contain only alphanumeric characters (A-Z, a-z, 0-9); the name can't
        /// contain whitespace. You can't change the name of the metric after you create the <code>RateBasedRule</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name or description of the <a>RateBasedRule</a>. You can't change the name
        /// of a <code>RateBasedRule</code> after you create it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RateKey
        /// <summary>
        /// <para>
        /// <para>The field that AWS WAF uses to determine if requests are likely arriving from a single
        /// source and thus subject to rate monitoring. The only valid value for <code>RateKey</code>
        /// is <code>IP</code>. <code>IP</code> indicates that requests that arrive from the same
        /// IP address are subject to the <code>RateLimit</code> that is specified in the <code>RateBasedRule</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WAFRegional.RateKey")]
        public Amazon.WAFRegional.RateKey RateKey { get; set; }
        #endregion
        
        #region Parameter RateLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of requests, which have an identical value in the field that is
        /// specified by <code>RateKey</code>, allowed in a five-minute period. If the number
        /// of requests exceeds the <code>RateLimit</code> and the other predicates specified
        /// in the rule are also met, AWS WAF triggers the action that is specified for this rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 RateLimit { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WAFRRateBasedRule (CreateRateBasedRule)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ChangeToken = this.ChangeToken;
            context.MetricName = this.MetricName;
            context.Name = this.Name;
            context.RateKey = this.RateKey;
            if (ParameterWasBound("RateLimit"))
                context.RateLimit = this.RateLimit;
            
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
            var request = new Amazon.WAFRegional.Model.CreateRateBasedRuleRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RateKey != null)
            {
                request.RateKey = cmdletContext.RateKey;
            }
            if (cmdletContext.RateLimit != null)
            {
                request.RateLimit = cmdletContext.RateLimit.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.WAFRegional.Model.CreateRateBasedRuleResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.CreateRateBasedRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "CreateRateBasedRule");
            #if DESKTOP
            return client.CreateRateBasedRule(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateRateBasedRuleAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ChangeToken { get; set; }
            public System.String MetricName { get; set; }
            public System.String Name { get; set; }
            public Amazon.WAFRegional.RateKey RateKey { get; set; }
            public System.Int64? RateLimit { get; set; }
        }
        
    }
}
