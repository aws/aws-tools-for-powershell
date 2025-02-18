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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Creates a <a>RateBasedRule</a>. The <c>RateBasedRule</c> contains a <c>RateLimit</c>,
    /// which specifies the maximum number of requests that AWS WAF allows from a specified
    /// IP address in a five-minute period. The <c>RateBasedRule</c> also contains the <c>IPSet</c>
    /// objects, <c>ByteMatchSet</c> objects, and other predicates that identify the requests
    /// that you want to count or block if these requests exceed the <c>RateLimit</c>.
    /// </para><para>
    /// If you add more than one predicate to a <c>RateBasedRule</c>, a request not only must
    /// exceed the <c>RateLimit</c>, but it also must match all the conditions to be counted
    /// or blocked. For example, suppose you add the following to a <c>RateBasedRule</c>:
    /// </para><ul><li><para>
    /// An <c>IPSet</c> that matches the IP address <c>192.0.2.44/32</c></para></li><li><para>
    /// A <c>ByteMatchSet</c> that matches <c>BadBot</c> in the <c>User-Agent</c> header
    /// </para></li></ul><para>
    /// Further, you specify a <c>RateLimit</c> of 1,000.
    /// </para><para>
    /// You then add the <c>RateBasedRule</c> to a <c>WebACL</c> and specify that you want
    /// to block requests that meet the conditions in the rule. For a request to be blocked,
    /// it must come from the IP address 192.0.2.44 <i>and</i> the <c>User-Agent</c> header
    /// in the request must contain the value <c>BadBot</c>. Further, requests that match
    /// these two conditions must be received at a rate of more than 1,000 requests every
    /// five minutes. If both conditions are met and the rate is exceeded, AWS WAF blocks
    /// the requests. If the rate drops below 1,000 for a five-minute period, AWS WAF no longer
    /// blocks the requests.
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
    /// </para><para>
    /// To create and configure a <c>RateBasedRule</c>, perform the following steps:
    /// </para><ol><li><para>
    /// Create and update the predicates that you want to include in the rule. For more information,
    /// see <a>CreateByteMatchSet</a>, <a>CreateIPSet</a>, and <a>CreateSqlInjectionMatchSet</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <c>ChangeToken</c>
    /// parameter of a <c>CreateRule</c> request.
    /// </para></li><li><para>
    /// Submit a <c>CreateRateBasedRule</c> request.
    /// </para></li><li><para>
    /// Use <c>GetChangeToken</c> to get the change token that you provide in the <c>ChangeToken</c>
    /// parameter of an <a>UpdateRule</a> request.
    /// </para></li><li><para>
    /// Submit an <c>UpdateRateBasedRule</c> request to specify the predicates that you want
    /// to include in the rule.
    /// </para></li><li><para>
    /// Create and update a <c>WebACL</c> that contains the <c>RateBasedRule</c>. For more
    /// information, see <a>CreateWebACL</a>.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAFRateBasedRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAF.Model.CreateRateBasedRuleResponse")]
    [AWSCmdlet("Calls the AWS WAF CreateRateBasedRule API operation.", Operation = new[] {"CreateRateBasedRule"}, SelectReturnType = typeof(Amazon.WAF.Model.CreateRateBasedRuleResponse))]
    [AWSCmdletOutput("Amazon.WAF.Model.CreateRateBasedRuleResponse",
        "This cmdlet returns an Amazon.WAF.Model.CreateRateBasedRuleResponse object containing multiple properties."
    )]
    public partial class NewWAFRateBasedRuleCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The <c>ChangeToken</c> that you used to submit the <c>CreateRateBasedRule</c> request.
        /// You can also use this value to query the status of the request. For more information,
        /// see <a>GetChangeTokenStatus</a>.</para>
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
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>A friendly name or description for the metrics for this <c>RateBasedRule</c>. The
        /// name can contain only alphanumeric characters (A-Z, a-z, 0-9), with maximum length
        /// 128 and minimum length one. It can't contain whitespace or metric names reserved for
        /// AWS WAF, including "All" and "Default_Action." You can't change the name of the metric
        /// after you create the <c>RateBasedRule</c>.</para>
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
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name or description of the <a>RateBasedRule</a>. You can't change the name
        /// of a <c>RateBasedRule</c> after you create it.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RateKey
        /// <summary>
        /// <para>
        /// <para>The field that AWS WAF uses to determine if requests are likely arriving from a single
        /// source and thus subject to rate monitoring. The only valid value for <c>RateKey</c>
        /// is <c>IP</c>. <c>IP</c> indicates that requests that arrive from the same IP address
        /// are subject to the <c>RateLimit</c> that is specified in the <c>RateBasedRule</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAF.RateKey")]
        public Amazon.WAF.RateKey RateKey { get; set; }
        #endregion
        
        #region Parameter RateLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of requests, which have an identical value in the field that is
        /// specified by <c>RateKey</c>, allowed in a five-minute period. If the number of requests
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WAF.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.CreateRateBasedRuleResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.CreateRateBasedRuleResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WAFRateBasedRule (CreateRateBasedRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.CreateRateBasedRuleResponse, NewWAFRateBasedRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricName = this.MetricName;
            #if MODULAR
            if (this.MetricName == null && ParameterWasBound(nameof(this.MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RateKey = this.RateKey;
            #if MODULAR
            if (this.RateKey == null && ParameterWasBound(nameof(this.RateKey)))
            {
                WriteWarning("You are passing $null as a value for parameter RateKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RateLimit = this.RateLimit;
            #if MODULAR
            if (this.RateLimit == null && ParameterWasBound(nameof(this.RateLimit)))
            {
                WriteWarning("You are passing $null as a value for parameter RateLimit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WAF.Model.Tag>(this.Tag);
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
            var request = new Amazon.WAF.Model.CreateRateBasedRuleRequest();
            
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
        
        private Amazon.WAF.Model.CreateRateBasedRuleResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.CreateRateBasedRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "CreateRateBasedRule");
            try
            {
                return client.CreateRateBasedRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MetricName { get; set; }
            public System.String Name { get; set; }
            public Amazon.WAF.RateKey RateKey { get; set; }
            public System.Int64? RateLimit { get; set; }
            public List<Amazon.WAF.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.WAF.Model.CreateRateBasedRuleResponse, NewWAFRateBasedRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
