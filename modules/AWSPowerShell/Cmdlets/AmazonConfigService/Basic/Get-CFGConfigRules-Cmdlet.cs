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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns details about your AWS Config rules.
    /// </summary>
    [Cmdlet("Get", "CFGConfigRules")]
    [OutputType("Amazon.ConfigService.Model.ConfigRule")]
    [AWSCmdlet("Invokes the DescribeConfigRules operation against Amazon Config.", Operation = new[] {"DescribeConfigRules"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigRule",
        "This cmdlet returns a collection of ConfigRule objects.",
        "The service call response (type DescribeConfigRulesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetCFGConfigRulesCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The names of the AWS Config rules for which you want details. If you do not specify
        /// any names, AWS Config returns details for all your rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConfigRuleNames")]
        public System.String[] ConfigRuleName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ConfigRuleName != null)
            {
                context.ConfigRuleNames = new List<String>(this.ConfigRuleName);
            }
            context.NextToken = this.NextToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeConfigRulesRequest();
            
            if (cmdletContext.ConfigRuleNames != null)
            {
                request.ConfigRuleNames = cmdletContext.ConfigRuleNames;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeConfigRules(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ConfigRules;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
            public List<String> ConfigRuleNames { get; set; }
            public String NextToken { get; set; }
        }
        
    }
}
