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
    /// Runs an on-demand evaluation for the specified AWS Config rules against the last known
    /// configuration state of the resources. Use <code>StartConfigRulesEvaluation</code>
    /// when you want to test that a rule you updated is working as expected. <code>StartConfigRulesEvaluation</code>
    /// does not re-record the latest configuration state for your resources. It re-runs an
    /// evaluation against the last known state of your resources. 
    /// 
    ///  
    /// <para>
    /// You can specify up to 25 AWS Config rules per request. 
    /// </para><para>
    /// An existing <code>StartConfigRulesEvaluation</code> call for the specified rules must
    /// complete before you can call the API again. If you chose to have AWS Config stream
    /// to an Amazon SNS topic, you will receive a <code>ConfigRuleEvaluationStarted</code>
    /// notification when the evaluation starts.
    /// </para><note><para>
    /// You don't need to call the <code>StartConfigRulesEvaluation</code> API to run an evaluation
    /// for a new rule. When you create a rule, AWS Config evaluates your resources against
    /// the rule automatically. 
    /// </para></note><para>
    /// The <code>StartConfigRulesEvaluation</code> API is useful if you want to run on-demand
    /// evaluations, such as the following example:
    /// </para><ol><li><para>
    /// You have a custom rule that evaluates your IAM resources every 24 hours.
    /// </para></li><li><para>
    /// You update your Lambda function to add additional conditions to your rule.
    /// </para></li><li><para>
    /// Instead of waiting for the next periodic evaluation, you call the <code>StartConfigRulesEvaluation</code>
    /// API.
    /// </para></li><li><para>
    /// AWS Config invokes your Lambda function and evaluates your IAM resources.
    /// </para></li><li><para>
    /// Your custom rule will still run periodic evaluations every 24 hours.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Start", "CFGConfigRulesEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Config StartConfigRulesEvaluation API operation.", Operation = new[] {"StartConfigRulesEvaluation"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ConfigRuleName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ConfigService.Model.StartConfigRulesEvaluationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCFGConfigRulesEvaluationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigRuleName
        /// <summary>
        /// <para>
        /// <para>The list of names of AWS Config rules that you want to run evaluations for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ConfigRuleNames")]
        public System.String[] ConfigRuleName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ConfigRuleName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConfigRuleName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CFGConfigRulesEvaluation (StartConfigRulesEvaluation)"))
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
            
            if (this.ConfigRuleName != null)
            {
                context.ConfigRuleNames = new List<System.String>(this.ConfigRuleName);
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
            var request = new Amazon.ConfigService.Model.StartConfigRulesEvaluationRequest();
            
            if (cmdletContext.ConfigRuleNames != null)
            {
                request.ConfigRuleNames = cmdletContext.ConfigRuleNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ConfigRuleName;
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
        
        private Amazon.ConfigService.Model.StartConfigRulesEvaluationResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.StartConfigRulesEvaluationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "StartConfigRulesEvaluation");
            try
            {
                #if DESKTOP
                return client.StartConfigRulesEvaluation(request);
                #elif CORECLR
                return client.StartConfigRulesEvaluationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ConfigRuleNames { get; set; }
        }
        
    }
}
