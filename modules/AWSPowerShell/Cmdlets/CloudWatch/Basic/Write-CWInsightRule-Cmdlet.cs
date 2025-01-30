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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Creates a Contributor Insights rule. Rules evaluate log events in a CloudWatch Logs
    /// log group, enabling you to find contributor data for the log events in that log group.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/ContributorInsights.html">Using
    /// Contributor Insights to Analyze High-Cardinality Data</a>.
    /// 
    ///  
    /// <para>
    /// If you create a rule, delete it, and then re-create it with the same name, historical
    /// data from the first time the rule was created might not be available.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWInsightRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutInsightRule API operation.", Operation = new[] {"PutInsightRule"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutInsightRuleResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.PutInsightRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.PutInsightRuleResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWInsightRuleCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RuleDefinition
        /// <summary>
        /// <para>
        /// <para>The definition of the rule, as a JSON object. For details on the valid syntax, see
        /// <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/ContributorInsights-RuleSyntax.html">Contributor
        /// Insights Rule Syntax</a>.</para>
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
        public System.String RuleDefinition { get; set; }
        #endregion
        
        #region Parameter RuleName
        /// <summary>
        /// <para>
        /// <para>A unique name for the rule.</para>
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
        public System.String RuleName { get; set; }
        #endregion
        
        #region Parameter RuleState
        /// <summary>
        /// <para>
        /// <para>The state of the rule. Valid values are ENABLED and DISABLED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleState { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the Contributor Insights rule. You can
        /// associate as many as 50 tags with a rule.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions, by granting a user permission to access or change only the
        /// resources that have certain tag values.</para><para>To be able to associate tags with a rule, you must have the <c>cloudwatch:TagResource</c>
        /// permission in addition to the <c>cloudwatch:PutInsightRule</c> permission.</para><para>If you are using this operation to update an existing Contributor Insights rule, any
        /// tags you specify in this parameter are ignored. To change the tags of an existing
        /// rule, use <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_TagResource.html">TagResource</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudWatch.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutInsightRuleResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWInsightRule (PutInsightRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutInsightRuleResponse, WriteCWInsightRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RuleDefinition = this.RuleDefinition;
            #if MODULAR
            if (this.RuleDefinition == null && ParameterWasBound(nameof(this.RuleDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleName = this.RuleName;
            #if MODULAR
            if (this.RuleName == null && ParameterWasBound(nameof(this.RuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleState = this.RuleState;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudWatch.Model.Tag>(this.Tag);
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
            var request = new Amazon.CloudWatch.Model.PutInsightRuleRequest();
            
            if (cmdletContext.RuleDefinition != null)
            {
                request.RuleDefinition = cmdletContext.RuleDefinition;
            }
            if (cmdletContext.RuleName != null)
            {
                request.RuleName = cmdletContext.RuleName;
            }
            if (cmdletContext.RuleState != null)
            {
                request.RuleState = cmdletContext.RuleState;
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
        
        private Amazon.CloudWatch.Model.PutInsightRuleResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutInsightRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutInsightRule");
            try
            {
                #if DESKTOP
                return client.PutInsightRule(request);
                #elif CORECLR
                return client.PutInsightRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String RuleDefinition { get; set; }
            public System.String RuleName { get; set; }
            public System.String RuleState { get; set; }
            public List<Amazon.CloudWatch.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CloudWatch.Model.PutInsightRuleResponse, WriteCWInsightRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
