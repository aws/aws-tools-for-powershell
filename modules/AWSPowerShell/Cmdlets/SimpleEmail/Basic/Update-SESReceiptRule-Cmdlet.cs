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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Updates a receipt rule.
    /// 
    ///  
    /// <para>
    /// For information about managing receipt rules, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/receiving-email-receipt-rules-console-walkthrough.html">Amazon
    /// SES Developer Guide</a>.
    /// </para><para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SESReceiptRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) UpdateReceiptRule API operation.", Operation = new[] {"UpdateReceiptRule"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.UpdateReceiptRuleResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmail.Model.UpdateReceiptRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmail.Model.UpdateReceiptRuleResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSESReceiptRuleCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Rule_Action
        /// <summary>
        /// <para>
        /// <para>An ordered list of actions to perform on messages that match at least one of the recipient
        /// email addresses or domains specified in the receipt rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Actions")]
        public Amazon.SimpleEmail.Model.ReceiptAction[] Rule_Action { get; set; }
        #endregion
        
        #region Parameter Rule_Enabled
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, the receipt rule is active. The default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Rule_Enabled { get; set; }
        #endregion
        
        #region Parameter Rule_Name
        /// <summary>
        /// <para>
        /// <para>The name of the receipt rule. The name must meet the following requirements:</para><ul><li><para>Contain only ASCII letters (a-z, A-Z), numbers (0-9), underscores (_), dashes (-),
        /// or periods (.). </para></li><li><para>Start and end with a letter or number.</para></li><li><para>Contain 64 characters or fewer.</para></li></ul>
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
        public System.String Rule_Name { get; set; }
        #endregion
        
        #region Parameter Rule_Recipient
        /// <summary>
        /// <para>
        /// <para>The recipient domains and email addresses that the receipt rule applies to. If this
        /// field is not specified, this rule matches all recipients on all verified domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Recipients")]
        public System.String[] Rule_Recipient { get; set; }
        #endregion
        
        #region Parameter RuleSetName
        /// <summary>
        /// <para>
        /// <para>The name of the receipt rule set that the receipt rule belongs to.</para>
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
        public System.String RuleSetName { get; set; }
        #endregion
        
        #region Parameter Rule_ScanEnabled
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, then messages that this receipt rule applies to are scanned
        /// for spam and viruses. The default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Rule_ScanEnabled { get; set; }
        #endregion
        
        #region Parameter Rule_TlsPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon SES should require that incoming email is delivered over
        /// a connection encrypted with Transport Layer Security (TLS). If this parameter is set
        /// to <code>Require</code>, Amazon SES bounces emails that are not received over TLS.
        /// The default is <code>Optional</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmail.TlsPolicy")]
        public Amazon.SimpleEmail.TlsPolicy Rule_TlsPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.UpdateReceiptRuleResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Rule_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SESReceiptRule (UpdateReceiptRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.UpdateReceiptRuleResponse, UpdateSESReceiptRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Rule_Action != null)
            {
                context.Rule_Action = new List<Amazon.SimpleEmail.Model.ReceiptAction>(this.Rule_Action);
            }
            context.Rule_Enabled = this.Rule_Enabled;
            context.Rule_Name = this.Rule_Name;
            #if MODULAR
            if (this.Rule_Name == null && ParameterWasBound(nameof(this.Rule_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Rule_Recipient != null)
            {
                context.Rule_Recipient = new List<System.String>(this.Rule_Recipient);
            }
            context.Rule_ScanEnabled = this.Rule_ScanEnabled;
            context.Rule_TlsPolicy = this.Rule_TlsPolicy;
            context.RuleSetName = this.RuleSetName;
            #if MODULAR
            if (this.RuleSetName == null && ParameterWasBound(nameof(this.RuleSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SimpleEmail.Model.UpdateReceiptRuleRequest();
            
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.SimpleEmail.Model.ReceiptRule();
            List<Amazon.SimpleEmail.Model.ReceiptAction> requestRule_rule_Action = null;
            if (cmdletContext.Rule_Action != null)
            {
                requestRule_rule_Action = cmdletContext.Rule_Action;
            }
            if (requestRule_rule_Action != null)
            {
                request.Rule.Actions = requestRule_rule_Action;
                requestRuleIsNull = false;
            }
            System.Boolean? requestRule_rule_Enabled = null;
            if (cmdletContext.Rule_Enabled != null)
            {
                requestRule_rule_Enabled = cmdletContext.Rule_Enabled.Value;
            }
            if (requestRule_rule_Enabled != null)
            {
                request.Rule.Enabled = requestRule_rule_Enabled.Value;
                requestRuleIsNull = false;
            }
            System.String requestRule_rule_Name = null;
            if (cmdletContext.Rule_Name != null)
            {
                requestRule_rule_Name = cmdletContext.Rule_Name;
            }
            if (requestRule_rule_Name != null)
            {
                request.Rule.Name = requestRule_rule_Name;
                requestRuleIsNull = false;
            }
            List<System.String> requestRule_rule_Recipient = null;
            if (cmdletContext.Rule_Recipient != null)
            {
                requestRule_rule_Recipient = cmdletContext.Rule_Recipient;
            }
            if (requestRule_rule_Recipient != null)
            {
                request.Rule.Recipients = requestRule_rule_Recipient;
                requestRuleIsNull = false;
            }
            System.Boolean? requestRule_rule_ScanEnabled = null;
            if (cmdletContext.Rule_ScanEnabled != null)
            {
                requestRule_rule_ScanEnabled = cmdletContext.Rule_ScanEnabled.Value;
            }
            if (requestRule_rule_ScanEnabled != null)
            {
                request.Rule.ScanEnabled = requestRule_rule_ScanEnabled.Value;
                requestRuleIsNull = false;
            }
            Amazon.SimpleEmail.TlsPolicy requestRule_rule_TlsPolicy = null;
            if (cmdletContext.Rule_TlsPolicy != null)
            {
                requestRule_rule_TlsPolicy = cmdletContext.Rule_TlsPolicy;
            }
            if (requestRule_rule_TlsPolicy != null)
            {
                request.Rule.TlsPolicy = requestRule_rule_TlsPolicy;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
            }
            if (cmdletContext.RuleSetName != null)
            {
                request.RuleSetName = cmdletContext.RuleSetName;
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
        
        private Amazon.SimpleEmail.Model.UpdateReceiptRuleResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.UpdateReceiptRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "UpdateReceiptRule");
            try
            {
                #if DESKTOP
                return client.UpdateReceiptRule(request);
                #elif CORECLR
                return client.UpdateReceiptRuleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleEmail.Model.ReceiptAction> Rule_Action { get; set; }
            public System.Boolean? Rule_Enabled { get; set; }
            public System.String Rule_Name { get; set; }
            public List<System.String> Rule_Recipient { get; set; }
            public System.Boolean? Rule_ScanEnabled { get; set; }
            public Amazon.SimpleEmail.TlsPolicy Rule_TlsPolicy { get; set; }
            public System.String RuleSetName { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.UpdateReceiptRuleResponse, UpdateSESReceiptRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
