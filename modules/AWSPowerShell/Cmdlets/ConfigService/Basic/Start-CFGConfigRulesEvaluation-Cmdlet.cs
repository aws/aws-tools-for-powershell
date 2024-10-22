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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Runs an on-demand evaluation for the specified Config rules against the last known
    /// configuration state of the resources. Use <c>StartConfigRulesEvaluation</c> when you
    /// want to test that a rule you updated is working as expected. <c>StartConfigRulesEvaluation</c>
    /// does not re-record the latest configuration state for your resources. It re-runs an
    /// evaluation against the last known state of your resources. 
    /// 
    ///  
    /// <para>
    /// You can specify up to 25 Config rules per request. 
    /// </para><para>
    /// An existing <c>StartConfigRulesEvaluation</c> call for the specified rules must complete
    /// before you can call the API again. If you chose to have Config stream to an Amazon
    /// SNS topic, you will receive a <c>ConfigRuleEvaluationStarted</c> notification when
    /// the evaluation starts.
    /// </para><note><para>
    /// You don't need to call the <c>StartConfigRulesEvaluation</c> API to run an evaluation
    /// for a new rule. When you create a rule, Config evaluates your resources against the
    /// rule automatically. 
    /// </para></note><para>
    /// The <c>StartConfigRulesEvaluation</c> API is useful if you want to run on-demand evaluations,
    /// such as the following example:
    /// </para><ol><li><para>
    /// You have a custom rule that evaluates your IAM resources every 24 hours.
    /// </para></li><li><para>
    /// You update your Lambda function to add additional conditions to your rule.
    /// </para></li><li><para>
    /// Instead of waiting for the next periodic evaluation, you call the <c>StartConfigRulesEvaluation</c>
    /// API.
    /// </para></li><li><para>
    /// Config invokes your Lambda function and evaluates your IAM resources.
    /// </para></li><li><para>
    /// Your custom rule will still run periodic evaluations every 24 hours.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Start", "CFGConfigRulesEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Config StartConfigRulesEvaluation API operation.", Operation = new[] {"StartConfigRulesEvaluation"}, SelectReturnType = typeof(Amazon.ConfigService.Model.StartConfigRulesEvaluationResponse))]
    [AWSCmdletOutput("None or Amazon.ConfigService.Model.StartConfigRulesEvaluationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConfigService.Model.StartConfigRulesEvaluationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCFGConfigRulesEvaluationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigRuleName
        /// <summary>
        /// <para>
        /// <para>The list of names of Config rules that you want to run evaluations for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ConfigRuleNames")]
        public System.String[] ConfigRuleName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.StartConfigRulesEvaluationResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigRuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CFGConfigRulesEvaluation (StartConfigRulesEvaluation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.StartConfigRulesEvaluationResponse, StartCFGConfigRulesEvaluationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ConfigRuleName != null)
            {
                context.ConfigRuleName = new List<System.String>(this.ConfigRuleName);
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
            
            if (cmdletContext.ConfigRuleName != null)
            {
                request.ConfigRuleNames = cmdletContext.ConfigRuleName;
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
            public List<System.String> ConfigRuleName { get; set; }
            public System.Func<Amazon.ConfigService.Model.StartConfigRulesEvaluationResponse, StartCFGConfigRulesEvaluationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
