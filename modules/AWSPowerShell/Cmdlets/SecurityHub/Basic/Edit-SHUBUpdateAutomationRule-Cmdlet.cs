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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Updates one or more automation rules based on rule Amazon Resource Names (ARNs) and
    /// input parameters.
    /// </summary>
    [Cmdlet("Edit", "SHUBUpdateAutomationRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.BatchUpdateAutomationRulesResponse")]
    [AWSCmdlet("Calls the AWS Security Hub BatchUpdateAutomationRules API operation.", Operation = new[] {"BatchUpdateAutomationRules"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.BatchUpdateAutomationRulesResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.BatchUpdateAutomationRulesResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.BatchUpdateAutomationRulesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditSHUBUpdateAutomationRuleCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        #region Parameter UpdateAutomationRulesRequestItem
        /// <summary>
        /// <para>
        /// <para> An array of ARNs for the rules that are to be updated. Optionally, you can also include
        /// <code>RuleStatus</code> and <code>RuleOrder</code>. </para>
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
        [Alias("UpdateAutomationRulesRequestItems")]
        public Amazon.SecurityHub.Model.UpdateAutomationRulesRequestItem[] UpdateAutomationRulesRequestItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.BatchUpdateAutomationRulesResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.BatchUpdateAutomationRulesResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UpdateAutomationRulesRequestItem), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-SHUBUpdateAutomationRule (BatchUpdateAutomationRules)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.BatchUpdateAutomationRulesResponse, EditSHUBUpdateAutomationRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.UpdateAutomationRulesRequestItem != null)
            {
                context.UpdateAutomationRulesRequestItem = new List<Amazon.SecurityHub.Model.UpdateAutomationRulesRequestItem>(this.UpdateAutomationRulesRequestItem);
            }
            #if MODULAR
            if (this.UpdateAutomationRulesRequestItem == null && ParameterWasBound(nameof(this.UpdateAutomationRulesRequestItem)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateAutomationRulesRequestItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.BatchUpdateAutomationRulesRequest();
            
            if (cmdletContext.UpdateAutomationRulesRequestItem != null)
            {
                request.UpdateAutomationRulesRequestItems = cmdletContext.UpdateAutomationRulesRequestItem;
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
        
        private Amazon.SecurityHub.Model.BatchUpdateAutomationRulesResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.BatchUpdateAutomationRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "BatchUpdateAutomationRules");
            try
            {
                #if DESKTOP
                return client.BatchUpdateAutomationRules(request);
                #elif CORECLR
                return client.BatchUpdateAutomationRulesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.UpdateAutomationRulesRequestItem> UpdateAutomationRulesRequestItem { get; set; }
            public System.Func<Amazon.SecurityHub.Model.BatchUpdateAutomationRulesResponse, EditSHUBUpdateAutomationRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}