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
using Amazon.FraudDetector;
using Amazon.FraudDetector.Model;

namespace Amazon.PowerShell.Cmdlets.FD
{
    /// <summary>
    /// Deletes the rule. You cannot delete a rule if it is used by an <code>ACTIVE</code>
    /// or <code>INACTIVE</code> detector version.
    /// </summary>
    [Cmdlet("Remove", "FDRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Fraud Detector DeleteRule API operation.", Operation = new[] {"DeleteRule"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.DeleteRuleResponse))]
    [AWSCmdletOutput("None or Amazon.FraudDetector.Model.DeleteRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.FraudDetector.Model.DeleteRuleResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveFDRuleCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        #region Parameter Rule_DetectorId
        /// <summary>
        /// <para>
        /// <para>The detector for which the rule is associated.</para>
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
        public System.String Rule_DetectorId { get; set; }
        #endregion
        
        #region Parameter Rule_RuleId
        /// <summary>
        /// <para>
        /// <para>The rule ID.</para>
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
        public System.String Rule_RuleId { get; set; }
        #endregion
        
        #region Parameter Rule_RuleVersion
        /// <summary>
        /// <para>
        /// <para>The rule version.</para>
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
        public System.String Rule_RuleVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.DeleteRuleResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Rule_RuleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-FDRule (DeleteRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.DeleteRuleResponse, RemoveFDRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Rule_DetectorId = this.Rule_DetectorId;
            #if MODULAR
            if (this.Rule_DetectorId == null && ParameterWasBound(nameof(this.Rule_DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule_DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rule_RuleId = this.Rule_RuleId;
            #if MODULAR
            if (this.Rule_RuleId == null && ParameterWasBound(nameof(this.Rule_RuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule_RuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rule_RuleVersion = this.Rule_RuleVersion;
            #if MODULAR
            if (this.Rule_RuleVersion == null && ParameterWasBound(nameof(this.Rule_RuleVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule_RuleVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FraudDetector.Model.DeleteRuleRequest();
            
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.FraudDetector.Model.Rule();
            System.String requestRule_rule_DetectorId = null;
            if (cmdletContext.Rule_DetectorId != null)
            {
                requestRule_rule_DetectorId = cmdletContext.Rule_DetectorId;
            }
            if (requestRule_rule_DetectorId != null)
            {
                request.Rule.DetectorId = requestRule_rule_DetectorId;
                requestRuleIsNull = false;
            }
            System.String requestRule_rule_RuleId = null;
            if (cmdletContext.Rule_RuleId != null)
            {
                requestRule_rule_RuleId = cmdletContext.Rule_RuleId;
            }
            if (requestRule_rule_RuleId != null)
            {
                request.Rule.RuleId = requestRule_rule_RuleId;
                requestRuleIsNull = false;
            }
            System.String requestRule_rule_RuleVersion = null;
            if (cmdletContext.Rule_RuleVersion != null)
            {
                requestRule_rule_RuleVersion = cmdletContext.Rule_RuleVersion;
            }
            if (requestRule_rule_RuleVersion != null)
            {
                request.Rule.RuleVersion = requestRule_rule_RuleVersion;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
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
        
        private Amazon.FraudDetector.Model.DeleteRuleResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.DeleteRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "DeleteRule");
            try
            {
                #if DESKTOP
                return client.DeleteRule(request);
                #elif CORECLR
                return client.DeleteRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String Rule_DetectorId { get; set; }
            public System.String Rule_RuleId { get; set; }
            public System.String Rule_RuleVersion { get; set; }
            public System.Func<Amazon.FraudDetector.Model.DeleteRuleResponse, RemoveFDRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
