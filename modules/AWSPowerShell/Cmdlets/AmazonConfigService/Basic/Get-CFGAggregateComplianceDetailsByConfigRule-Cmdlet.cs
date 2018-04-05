/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns the evaluation results for the specified AWS Config rule for a specific resource
    /// in a rule. The results indicate which AWS resources were evaluated by the rule, when
    /// each resource was last evaluated, and whether each resource complies with the rule.
    /// 
    /// 
    ///  <note><para>
    /// The results can return an empty result page. But if you have a nextToken, the results
    /// are displayed on the next page.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGAggregateComplianceDetailsByConfigRule")]
    [OutputType("Amazon.ConfigService.Model.AggregateEvaluationResult")]
    [AWSCmdlet("Calls the AWS Config GetAggregateComplianceDetailsByConfigRule API operation.", Operation = new[] {"GetAggregateComplianceDetailsByConfigRule"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.AggregateEvaluationResult",
        "This cmdlet returns a collection of AggregateEvaluationResult objects.",
        "The service call response (type Amazon.ConfigService.Model.GetAggregateComplianceDetailsByConfigRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCFGAggregateComplianceDetailsByConfigRuleCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit account ID of the source account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AwsRegion
        /// <summary>
        /// <para>
        /// <para>The source region from where the data is aggregated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AwsRegion { get; set; }
        #endregion
        
        #region Parameter ComplianceType
        /// <summary>
        /// <para>
        /// <para>The resource compliance status.</para><note><para>For the <code>GetAggregateComplianceDetailsByConfigRuleRequest</code> data type, AWS
        /// Config supports only the <code>COMPLIANT</code> and <code>NON_COMPLIANT</code>. AWS
        /// Config does not support the <code>NOT_APPLICABLE</code> and <code>INSUFFICIENT_DATA</code>
        /// values.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ConfigService.ComplianceType")]
        public Amazon.ConfigService.ComplianceType ComplianceType { get; set; }
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
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of evaluation results returned on each page. The default is 50.
        /// You cannot specify a number greater than 100. If you specify 0, AWS Config uses the
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The nextToken string returned on a previous page that you use to get the next page
        /// of results in a paginated response.</para>
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
            
            context.AccountId = this.AccountId;
            context.AwsRegion = this.AwsRegion;
            context.ComplianceType = this.ComplianceType;
            context.ConfigRuleName = this.ConfigRuleName;
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
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
            var request = new Amazon.ConfigService.Model.GetAggregateComplianceDetailsByConfigRuleRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.AwsRegion != null)
            {
                request.AwsRegion = cmdletContext.AwsRegion;
            }
            if (cmdletContext.ComplianceType != null)
            {
                request.ComplianceType = cmdletContext.ComplianceType;
            }
            if (cmdletContext.ConfigRuleName != null)
            {
                request.ConfigRuleName = cmdletContext.ConfigRuleName;
            }
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
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
                object pipelineOutput = response.AggregateEvaluationResults;
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
        
        private Amazon.ConfigService.Model.GetAggregateComplianceDetailsByConfigRuleResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetAggregateComplianceDetailsByConfigRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetAggregateComplianceDetailsByConfigRule");
            try
            {
                #if DESKTOP
                return client.GetAggregateComplianceDetailsByConfigRule(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetAggregateComplianceDetailsByConfigRuleAsync(request);
                return task.Result;
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
            public System.String AccountId { get; set; }
            public System.String AwsRegion { get; set; }
            public Amazon.ConfigService.ComplianceType ComplianceType { get; set; }
            public System.String ConfigRuleName { get; set; }
            public System.String ConfigurationAggregatorName { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
