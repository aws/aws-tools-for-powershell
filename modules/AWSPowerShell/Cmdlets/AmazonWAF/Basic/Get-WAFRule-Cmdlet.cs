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
    /// Returns the <a>Rule</a> that is specified by the <code>RuleId</code> that you included
    /// in the <code>GetRule</code> request.
    /// </summary>
    [Cmdlet("Get", "WAFRule")]
    [OutputType("Amazon.WAF.Model.Rule")]
    [AWSCmdlet("Invokes the GetRule operation against AWS WAF.", Operation = new[] {"GetRule"})]
    [AWSCmdletOutput("Amazon.WAF.Model.Rule",
        "This cmdlet returns a Rule object.",
        "The service call response (type Amazon.WAF.Model.GetRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetWAFRuleCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        #region Parameter RuleId
        /// <summary>
        /// <para>
        /// <para>The <code>RuleId</code> of the <a>Rule</a> that you want to get. <code>RuleId</code>
        /// is returned by <a>CreateRule</a> and by <a>ListRules</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RuleId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.RuleId = this.RuleId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.WAF.Model.GetRuleRequest();
            
            if (cmdletContext.RuleId != null)
            {
                request.RuleId = cmdletContext.RuleId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetRule(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Rule;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String RuleId { get; set; }
        }
        
    }
}
