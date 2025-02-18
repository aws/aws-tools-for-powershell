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
using System.Threading;
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Update attributes of an already provisioned rule set.
    /// </summary>
    [Cmdlet("Update", "MMGRRuleSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager UpdateRuleSet API operation.", Operation = new[] {"UpdateRuleSet"}, SelectReturnType = typeof(Amazon.MailManager.Model.UpdateRuleSetResponse))]
    [AWSCmdletOutput("None or Amazon.MailManager.Model.UpdateRuleSetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MailManager.Model.UpdateRuleSetResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateMMGRRuleSetCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>A new set of rules to replace the current rules of the rule set—these rules will override
        /// all the rules of the rule set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rules")]
        public Amazon.MailManager.Model.Rule[] Rule { get; set; }
        #endregion
        
        #region Parameter RuleSetId
        /// <summary>
        /// <para>
        /// <para>The identifier of a rule set you want to update.</para>
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
        public System.String RuleSetId { get; set; }
        #endregion
        
        #region Parameter RuleSetName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the rule set resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleSetName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.UpdateRuleSetResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MMGRRuleSet (UpdateRuleSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.UpdateRuleSetResponse, UpdateMMGRRuleSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Rule != null)
            {
                context.Rule = new List<Amazon.MailManager.Model.Rule>(this.Rule);
            }
            context.RuleSetId = this.RuleSetId;
            #if MODULAR
            if (this.RuleSetId == null && ParameterWasBound(nameof(this.RuleSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleSetName = this.RuleSetName;
            
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
            var request = new Amazon.MailManager.Model.UpdateRuleSetRequest();
            
            if (cmdletContext.Rule != null)
            {
                request.Rules = cmdletContext.Rule;
            }
            if (cmdletContext.RuleSetId != null)
            {
                request.RuleSetId = cmdletContext.RuleSetId;
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
        
        private Amazon.MailManager.Model.UpdateRuleSetResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.UpdateRuleSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "UpdateRuleSet");
            try
            {
                return client.UpdateRuleSetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.MailManager.Model.Rule> Rule { get; set; }
            public System.String RuleSetId { get; set; }
            public System.String RuleSetName { get; set; }
            public System.Func<Amazon.MailManager.Model.UpdateRuleSetResponse, UpdateMMGRRuleSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
