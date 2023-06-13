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
    /// Retrieves a list of details for automation rules based on rule Amazon Resource Names
    /// (ARNs).
    /// </summary>
    [Cmdlet("Get", "SHUBGetAutomationRule")]
    [OutputType("Amazon.SecurityHub.Model.BatchGetAutomationRulesResponse")]
    [AWSCmdlet("Calls the AWS Security Hub BatchGetAutomationRules API operation.", Operation = new[] {"BatchGetAutomationRules"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.BatchGetAutomationRulesResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.BatchGetAutomationRulesResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.BatchGetAutomationRulesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSHUBGetAutomationRuleCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        #region Parameter AutomationRulesArn
        /// <summary>
        /// <para>
        /// <para> A list of rule ARNs to get details for. </para>
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
        [Alias("AutomationRulesArns")]
        public System.String[] AutomationRulesArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.BatchGetAutomationRulesResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.BatchGetAutomationRulesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.BatchGetAutomationRulesResponse, GetSHUBGetAutomationRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AutomationRulesArn != null)
            {
                context.AutomationRulesArn = new List<System.String>(this.AutomationRulesArn);
            }
            #if MODULAR
            if (this.AutomationRulesArn == null && ParameterWasBound(nameof(this.AutomationRulesArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AutomationRulesArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.BatchGetAutomationRulesRequest();
            
            if (cmdletContext.AutomationRulesArn != null)
            {
                request.AutomationRulesArns = cmdletContext.AutomationRulesArn;
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
        
        private Amazon.SecurityHub.Model.BatchGetAutomationRulesResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.BatchGetAutomationRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "BatchGetAutomationRules");
            try
            {
                #if DESKTOP
                return client.BatchGetAutomationRules(request);
                #elif CORECLR
                return client.BatchGetAutomationRulesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AutomationRulesArn { get; set; }
            public System.Func<Amazon.SecurityHub.Model.BatchGetAutomationRulesResponse, GetSHUBGetAutomationRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
