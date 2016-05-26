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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// Creates a <code>Rule</code>, which contains the <code>IPSet</code> objects, <code>ByteMatchSet</code>
    /// objects, and other predicates that identify the requests that you want to block. If
    /// you add more than one predicate to a <code>Rule</code>, a request must match all of
    /// the specifications to be allowed or blocked. For example, suppose you add the following
    /// to a <code>Rule</code>:
    /// 
    ///  <ul><li>An <code>IPSet</code> that matches the IP address <code>192.0.2.44/32</code></li><li>A <code>ByteMatchSet</code> that matches <code>BadBot</code> in the <code>User-Agent</code>
    /// header</li></ul><para>
    /// You then add the <code>Rule</code> to a <code>WebACL</code> and specify that you want
    /// to blocks requests that satisfy the <code>Rule</code>. For a request to be blocked,
    /// it must come from the IP address 192.0.2.44 <i>and</i> the <code>User-Agent</code>
    /// header in the request must contain the value <code>BadBot</code>.
    /// </para><para>
    /// To create and configure a <code>Rule</code>, perform the following steps:
    /// </para><ol><li>Create and update the predicates that you want to include in the <code>Rule</code>.
    /// For more information, see <a>CreateByteMatchSet</a>, <a>CreateIPSet</a>, and <a>CreateSqlInjectionMatchSet</a>.</li><li>Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of a <code>CreateRule</code> request.</li><li>Submit a <code>CreateRule</code>
    /// request.</li><li>Use <code>GetChangeToken</code> to get the change token that you
    /// provide in the <code>ChangeToken</code> parameter of an <a>UpdateRule</a> request.</li><li>Submit an <code>UpdateRule</code> request to specify the predicates that you want
    /// to include in the <code>Rule</code>.</li><li>Create and update a <code>WebACL</code>
    /// that contains the <code>Rule</code>. For more information, see <a>CreateWebACL</a>.</li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAFRule")]
    [OutputType("Amazon.WAF.Model.CreateRuleResponse")]
    [AWSCmdlet("Invokes the CreateRule operation against AWS WAF.", Operation = new[] {"CreateRule"})]
    [AWSCmdletOutput("Amazon.WAF.Model.CreateRuleResponse",
        "This cmdlet returns a Amazon.WAF.Model.CreateRuleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewWAFRuleCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>A friendly name or description for the metrics for this <code>Rule</code>. The name
        /// can contain only alphanumeric characters (A-Z, a-z, 0-9); the name can't contain whitespace.
        /// You can't change the name of the metric after you create the <code>Rule</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name or description of the <a>Rule</a>. You can't change the name of a
        /// <code>Rule</code> after you create it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ChangeToken = this.ChangeToken;
            context.MetricName = this.MetricName;
            context.Name = this.Name;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.WAF.Model.CreateRuleRequest();
            
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
        
        private static Amazon.WAF.Model.CreateRuleResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.CreateRuleRequest request)
        {
            return client.CreateRule(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ChangeToken { get; set; }
            public System.String MetricName { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
