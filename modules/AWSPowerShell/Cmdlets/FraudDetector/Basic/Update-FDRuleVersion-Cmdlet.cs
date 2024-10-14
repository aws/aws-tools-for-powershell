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
    /// Updates a rule version resulting in a new rule version. Updates a rule version resulting
    /// in a new rule version (version 1, 2, 3 ...).
    /// </summary>
    [Cmdlet("Update", "FDRuleVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FraudDetector.Model.Rule")]
    [AWSCmdlet("Calls the Amazon Fraud Detector UpdateRuleVersion API operation.", Operation = new[] {"UpdateRuleVersion"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.UpdateRuleVersionResponse))]
    [AWSCmdletOutput("Amazon.FraudDetector.Model.Rule or Amazon.FraudDetector.Model.UpdateRuleVersionResponse",
        "This cmdlet returns an Amazon.FraudDetector.Model.Rule object.",
        "The service call response (type Amazon.FraudDetector.Model.UpdateRuleVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateFDRuleVersionCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
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
        
        #region Parameter Expression
        /// <summary>
        /// <para>
        /// <para>The rule expression.</para>
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
        public System.String Expression { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The language.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FraudDetector.Language")]
        public Amazon.FraudDetector.Language Language { get; set; }
        #endregion
        
        #region Parameter Outcome
        /// <summary>
        /// <para>
        /// <para>The outcomes.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Outcomes")]
        public System.String[] Outcome { get; set; }
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Rule_RuleVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the rule version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FraudDetector.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Rule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.UpdateRuleVersionResponse).
        /// Specifying the name of a property of type Amazon.FraudDetector.Model.UpdateRuleVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Rule";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Rule_RuleVersion parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Rule_RuleVersion' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Rule_RuleVersion' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Rule_RuleVersion), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FDRuleVersion (UpdateRuleVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.UpdateRuleVersionResponse, UpdateFDRuleVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Rule_RuleVersion;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.Expression = this.Expression;
            #if MODULAR
            if (this.Expression == null && ParameterWasBound(nameof(this.Expression)))
            {
                WriteWarning("You are passing $null as a value for parameter Expression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Language = this.Language;
            #if MODULAR
            if (this.Language == null && ParameterWasBound(nameof(this.Language)))
            {
                WriteWarning("You are passing $null as a value for parameter Language which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Outcome != null)
            {
                context.Outcome = new List<System.String>(this.Outcome);
            }
            #if MODULAR
            if (this.Outcome == null && ParameterWasBound(nameof(this.Outcome)))
            {
                WriteWarning("You are passing $null as a value for parameter Outcome which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FraudDetector.Model.Tag>(this.Tag);
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
            var request = new Amazon.FraudDetector.Model.UpdateRuleVersionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Expression != null)
            {
                request.Expression = cmdletContext.Expression;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.Outcome != null)
            {
                request.Outcomes = cmdletContext.Outcome;
            }
            
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
        
        private Amazon.FraudDetector.Model.UpdateRuleVersionResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.UpdateRuleVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "UpdateRuleVersion");
            try
            {
                #if DESKTOP
                return client.UpdateRuleVersion(request);
                #elif CORECLR
                return client.UpdateRuleVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Expression { get; set; }
            public Amazon.FraudDetector.Language Language { get; set; }
            public List<System.String> Outcome { get; set; }
            public System.String Rule_DetectorId { get; set; }
            public System.String Rule_RuleId { get; set; }
            public System.String Rule_RuleVersion { get; set; }
            public List<Amazon.FraudDetector.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FraudDetector.Model.UpdateRuleVersionResponse, UpdateFDRuleVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Rule;
        }
        
    }
}
