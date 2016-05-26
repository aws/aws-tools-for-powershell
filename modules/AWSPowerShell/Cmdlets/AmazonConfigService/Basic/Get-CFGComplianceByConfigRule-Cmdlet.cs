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
    /// Indicates whether the specified AWS Config rules are compliant. If a rule is noncompliant,
    /// this action returns the number of AWS resources that do not comply with the rule.
    /// 
    ///  
    /// <para>
    /// A rule is compliant if all of the evaluated resources comply with it, and it is noncompliant
    /// if any of these resources do not comply. 
    /// </para><para>
    /// If AWS Config has no current evaluation results for the rule, it returns <code>INSUFFICIENT_DATA</code>.
    /// This result might indicate one of the following conditions: <ul><li>AWS Config has
    /// never invoked an evaluation for the rule. To check whether it has, use the <code>DescribeConfigRuleEvaluationStatus</code>
    /// action to get the <code>LastSuccessfulInvocationTime</code> and <code>LastFailedInvocationTime</code>.</li><li>The rule's AWS Lambda function is failing to send evaluation results to AWS Config.
    /// Verify that the role that you assigned to your configuration recorder includes the
    /// <code>config:PutEvaluations</code> permission. If the rule is a customer managed rule,
    /// verify that the AWS Lambda execution role includes the <code>config:PutEvaluations</code>
    /// permission.</li><li>The rule's AWS Lambda function has returned <code>NOT_APPLICABLE</code>
    /// for all evaluation results. This can occur if the resources were deleted or removed
    /// from the rule's scope.</li></ul></para>
    /// </summary>
    [Cmdlet("Get", "CFGComplianceByConfigRule")]
    [OutputType("Amazon.ConfigService.Model.ComplianceByConfigRule")]
    [AWSCmdlet("Invokes the DescribeComplianceByConfigRule operation against AWS Config.", Operation = new[] {"DescribeComplianceByConfigRule"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ComplianceByConfigRule",
        "This cmdlet returns a collection of ComplianceByConfigRule objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetCFGComplianceByConfigRuleCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ComplianceType
        /// <summary>
        /// <para>
        /// <para>Filters the results by compliance.</para><para>The allowed values are <code>COMPLIANT</code>, <code>NON_COMPLIANT</code>, and <code>INSUFFICIENT_DATA</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComplianceTypes")]
        public System.String[] ComplianceType { get; set; }
        #endregion
        
        #region Parameter ConfigRuleName
        /// <summary>
        /// <para>
        /// <para>Specify one or more AWS Config rule names to filter the results by rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConfigRuleNames")]
        public System.String[] ConfigRuleName { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ComplianceType != null)
            {
                context.ComplianceTypes = new List<System.String>(this.ComplianceType);
            }
            if (this.ConfigRuleName != null)
            {
                context.ConfigRuleNames = new List<System.String>(this.ConfigRuleName);
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
            var request = new Amazon.ConfigService.Model.DescribeComplianceByConfigRuleRequest();
            
            if (cmdletContext.ComplianceTypes != null)
            {
                request.ComplianceTypes = cmdletContext.ComplianceTypes;
            }
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
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ComplianceByConfigRules;
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
        
        #region AWS Service Operation Call
        
        private static Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DescribeComplianceByConfigRuleRequest request)
        {
            return client.DescribeComplianceByConfigRule(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> ComplianceTypes { get; set; }
            public List<System.String> ConfigRuleNames { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
