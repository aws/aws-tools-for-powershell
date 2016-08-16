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
    /// Returns the evaluation results for the specified AWS Config rule. The results indicate
    /// which AWS resources were evaluated by the rule, when each resource was last evaluated,
    /// and whether each resource complies with the rule.
    /// </summary>
    [Cmdlet("Get", "CFGComplianceDetailsByConfigRule")]
    [OutputType("Amazon.ConfigService.Model.EvaluationResult")]
    [AWSCmdlet("Invokes the GetComplianceDetailsByConfigRule operation against AWS Config.", Operation = new[] {"GetComplianceDetailsByConfigRule"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.EvaluationResult",
        "This cmdlet returns a collection of EvaluationResult objects.",
        "The service call response (type Amazon.ConfigService.Model.GetComplianceDetailsByConfigRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCFGComplianceDetailsByConfigRuleCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ComplianceType
        /// <summary>
        /// <para>
        /// <para>Filters the results by compliance.</para><para>The allowed values are <code>COMPLIANT</code>, <code>NON_COMPLIANT</code>, and <code>NOT_APPLICABLE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComplianceTypes")]
        public System.String[] ComplianceType { get; set; }
        #endregion
        
        #region Parameter ConfigRuleName
        /// <summary>
        /// <para>
        /// <para>The name of the AWS Config rule for which you want compliance information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigRuleName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of evaluation results returned on each page. The default is 10.
        /// You cannot specify a limit greater than 100. If you specify 0, AWS Config uses the
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.ComplianceType != null)
            {
                context.ComplianceTypes = new List<System.String>(this.ComplianceType);
            }
            context.ConfigRuleName = this.ConfigRuleName;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.ConfigService.Model.GetComplianceDetailsByConfigRuleRequest();
            
            if (cmdletContext.ComplianceTypes != null)
            {
                request.ComplianceTypes = cmdletContext.ComplianceTypes;
            }
            if (cmdletContext.ConfigRuleName != null)
            {
                request.ConfigRuleName = cmdletContext.ConfigRuleName;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
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
                object pipelineOutput = response.EvaluationResults;
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
        
        private static Amazon.ConfigService.Model.GetComplianceDetailsByConfigRuleResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetComplianceDetailsByConfigRuleRequest request)
        {
            #if DESKTOP
            return client.GetComplianceDetailsByConfigRule(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetComplianceDetailsByConfigRuleAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> ComplianceTypes { get; set; }
            public System.String ConfigRuleName { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
