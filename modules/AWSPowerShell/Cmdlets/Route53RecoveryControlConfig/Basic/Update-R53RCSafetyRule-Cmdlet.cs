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
using Amazon.Route53RecoveryControlConfig;
using Amazon.Route53RecoveryControlConfig.Model;

namespace Amazon.PowerShell.Cmdlets.R53RC
{
    /// <summary>
    /// Update a safety rule (an assertion rule or gating rule). You can only update the name
    /// and the waiting period for a safety rule. To make other updates, delete the safety
    /// rule and create a new one.
    /// </summary>
    [Cmdlet("Update", "R53RCSafetyRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleResponse")]
    [AWSCmdlet("Calls the AWS Route53 Recovery Control Config UpdateSafetyRule API operation.", Operation = new[] {"UpdateSafetyRule"}, SelectReturnType = typeof(Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleResponse",
        "This cmdlet returns an Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateR53RCSafetyRuleCmdlet : AmazonRoute53RecoveryControlConfigClientCmdlet, IExecutor
    {
        
        #region Parameter AssertionRuleUpdate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the assertion rule. You can use any non-white space character in the name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssertionRuleUpdate_Name { get; set; }
        #endregion
        
        #region Parameter GatingRuleUpdate_Name
        /// <summary>
        /// <para>
        /// <para>The name for the gating rule. You can use any non-white space character in the name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GatingRuleUpdate_Name { get; set; }
        #endregion
        
        #region Parameter AssertionRuleUpdate_SafetyRuleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the assertion rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssertionRuleUpdate_SafetyRuleArn { get; set; }
        #endregion
        
        #region Parameter GatingRuleUpdate_SafetyRuleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the gating rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GatingRuleUpdate_SafetyRuleArn { get; set; }
        #endregion
        
        #region Parameter AssertionRuleUpdate_WaitPeriodMs
        /// <summary>
        /// <para>
        /// <para>An evaluation period, in milliseconds (ms), during which any request against the target
        /// routing controls will fail. This helps prevent "flapping" of state. The wait period
        /// is 5000 ms by default, but you can choose a custom value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AssertionRuleUpdate_WaitPeriodMs { get; set; }
        #endregion
        
        #region Parameter GatingRuleUpdate_WaitPeriodMs
        /// <summary>
        /// <para>
        /// <para>An evaluation period, in milliseconds (ms), during which any request against the target
        /// routing controls will fail. This helps prevent "flapping" of state. The wait period
        /// is 5000 ms by default, but you can choose a custom value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GatingRuleUpdate_WaitPeriodMs { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53RCSafetyRule (UpdateSafetyRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleResponse, UpdateR53RCSafetyRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssertionRuleUpdate_Name = this.AssertionRuleUpdate_Name;
            context.AssertionRuleUpdate_SafetyRuleArn = this.AssertionRuleUpdate_SafetyRuleArn;
            context.AssertionRuleUpdate_WaitPeriodMs = this.AssertionRuleUpdate_WaitPeriodMs;
            context.GatingRuleUpdate_Name = this.GatingRuleUpdate_Name;
            context.GatingRuleUpdate_SafetyRuleArn = this.GatingRuleUpdate_SafetyRuleArn;
            context.GatingRuleUpdate_WaitPeriodMs = this.GatingRuleUpdate_WaitPeriodMs;
            
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
            var request = new Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleRequest();
            
            
             // populate AssertionRuleUpdate
            var requestAssertionRuleUpdateIsNull = true;
            request.AssertionRuleUpdate = new Amazon.Route53RecoveryControlConfig.Model.AssertionRuleUpdate();
            System.String requestAssertionRuleUpdate_assertionRuleUpdate_Name = null;
            if (cmdletContext.AssertionRuleUpdate_Name != null)
            {
                requestAssertionRuleUpdate_assertionRuleUpdate_Name = cmdletContext.AssertionRuleUpdate_Name;
            }
            if (requestAssertionRuleUpdate_assertionRuleUpdate_Name != null)
            {
                request.AssertionRuleUpdate.Name = requestAssertionRuleUpdate_assertionRuleUpdate_Name;
                requestAssertionRuleUpdateIsNull = false;
            }
            System.String requestAssertionRuleUpdate_assertionRuleUpdate_SafetyRuleArn = null;
            if (cmdletContext.AssertionRuleUpdate_SafetyRuleArn != null)
            {
                requestAssertionRuleUpdate_assertionRuleUpdate_SafetyRuleArn = cmdletContext.AssertionRuleUpdate_SafetyRuleArn;
            }
            if (requestAssertionRuleUpdate_assertionRuleUpdate_SafetyRuleArn != null)
            {
                request.AssertionRuleUpdate.SafetyRuleArn = requestAssertionRuleUpdate_assertionRuleUpdate_SafetyRuleArn;
                requestAssertionRuleUpdateIsNull = false;
            }
            System.Int32? requestAssertionRuleUpdate_assertionRuleUpdate_WaitPeriodMs = null;
            if (cmdletContext.AssertionRuleUpdate_WaitPeriodMs != null)
            {
                requestAssertionRuleUpdate_assertionRuleUpdate_WaitPeriodMs = cmdletContext.AssertionRuleUpdate_WaitPeriodMs.Value;
            }
            if (requestAssertionRuleUpdate_assertionRuleUpdate_WaitPeriodMs != null)
            {
                request.AssertionRuleUpdate.WaitPeriodMs = requestAssertionRuleUpdate_assertionRuleUpdate_WaitPeriodMs.Value;
                requestAssertionRuleUpdateIsNull = false;
            }
             // determine if request.AssertionRuleUpdate should be set to null
            if (requestAssertionRuleUpdateIsNull)
            {
                request.AssertionRuleUpdate = null;
            }
            
             // populate GatingRuleUpdate
            var requestGatingRuleUpdateIsNull = true;
            request.GatingRuleUpdate = new Amazon.Route53RecoveryControlConfig.Model.GatingRuleUpdate();
            System.String requestGatingRuleUpdate_gatingRuleUpdate_Name = null;
            if (cmdletContext.GatingRuleUpdate_Name != null)
            {
                requestGatingRuleUpdate_gatingRuleUpdate_Name = cmdletContext.GatingRuleUpdate_Name;
            }
            if (requestGatingRuleUpdate_gatingRuleUpdate_Name != null)
            {
                request.GatingRuleUpdate.Name = requestGatingRuleUpdate_gatingRuleUpdate_Name;
                requestGatingRuleUpdateIsNull = false;
            }
            System.String requestGatingRuleUpdate_gatingRuleUpdate_SafetyRuleArn = null;
            if (cmdletContext.GatingRuleUpdate_SafetyRuleArn != null)
            {
                requestGatingRuleUpdate_gatingRuleUpdate_SafetyRuleArn = cmdletContext.GatingRuleUpdate_SafetyRuleArn;
            }
            if (requestGatingRuleUpdate_gatingRuleUpdate_SafetyRuleArn != null)
            {
                request.GatingRuleUpdate.SafetyRuleArn = requestGatingRuleUpdate_gatingRuleUpdate_SafetyRuleArn;
                requestGatingRuleUpdateIsNull = false;
            }
            System.Int32? requestGatingRuleUpdate_gatingRuleUpdate_WaitPeriodMs = null;
            if (cmdletContext.GatingRuleUpdate_WaitPeriodMs != null)
            {
                requestGatingRuleUpdate_gatingRuleUpdate_WaitPeriodMs = cmdletContext.GatingRuleUpdate_WaitPeriodMs.Value;
            }
            if (requestGatingRuleUpdate_gatingRuleUpdate_WaitPeriodMs != null)
            {
                request.GatingRuleUpdate.WaitPeriodMs = requestGatingRuleUpdate_gatingRuleUpdate_WaitPeriodMs.Value;
                requestGatingRuleUpdateIsNull = false;
            }
             // determine if request.GatingRuleUpdate should be set to null
            if (requestGatingRuleUpdateIsNull)
            {
                request.GatingRuleUpdate = null;
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
        
        private Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleResponse CallAWSServiceOperation(IAmazonRoute53RecoveryControlConfig client, Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route53 Recovery Control Config", "UpdateSafetyRule");
            try
            {
                #if DESKTOP
                return client.UpdateSafetyRule(request);
                #elif CORECLR
                return client.UpdateSafetyRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String AssertionRuleUpdate_Name { get; set; }
            public System.String AssertionRuleUpdate_SafetyRuleArn { get; set; }
            public System.Int32? AssertionRuleUpdate_WaitPeriodMs { get; set; }
            public System.String GatingRuleUpdate_Name { get; set; }
            public System.String GatingRuleUpdate_SafetyRuleArn { get; set; }
            public System.Int32? GatingRuleUpdate_WaitPeriodMs { get; set; }
            public System.Func<Amazon.Route53RecoveryControlConfig.Model.UpdateSafetyRuleResponse, UpdateR53RCSafetyRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
