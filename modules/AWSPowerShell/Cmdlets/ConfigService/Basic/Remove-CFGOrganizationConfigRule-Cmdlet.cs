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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Deletes the specified organization Config rule and all of its evaluation results from
    /// all member accounts in that organization. 
    /// 
    ///  
    /// <para>
    /// Only a management account and a delegated administrator account can delete an organization
    /// Config rule. When calling this API with a delegated administrator, you must ensure
    /// Organizations <c>ListDelegatedAdministrator</c> permissions are added.
    /// </para><para>
    /// Config sets the state of a rule to DELETE_IN_PROGRESS until the deletion is complete.
    /// You cannot update a rule while it is in this state.
    /// </para><note><para><b>Recommendation: Consider excluding the <c>AWS::Config::ResourceCompliance</c>
    /// resource type from recording before deleting rules</b></para><para>
    /// Deleting rules creates configuration items (CIs) for <c>AWS::Config::ResourceCompliance</c>
    /// that can affect your costs for the configuration recorder. If you are deleting rules
    /// which evaluate a large number of resource types, this can lead to a spike in the number
    /// of CIs recorded.
    /// </para><para>
    /// To avoid the associated costs, you can opt to disable recording for the <c>AWS::Config::ResourceCompliance</c>
    /// resource type before deleting rules, and re-enable recording after the rules have
    /// been deleted.
    /// </para><para>
    /// However, since deleting rules is an asynchronous process, it might take an hour or
    /// more to complete. During the time when recording is disabled for <c>AWS::Config::ResourceCompliance</c>,
    /// rule evaluations will not be recorded in the associated resource’s history.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "CFGOrganizationConfigRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Config DeleteOrganizationConfigRule API operation.", Operation = new[] {"DeleteOrganizationConfigRule"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DeleteOrganizationConfigRuleResponse))]
    [AWSCmdletOutput("None or Amazon.ConfigService.Model.DeleteOrganizationConfigRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConfigService.Model.DeleteOrganizationConfigRuleResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCFGOrganizationConfigRuleCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OrganizationConfigRuleName
        /// <summary>
        /// <para>
        /// <para>The name of organization Config rule that you want to delete.</para>
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
        public System.String OrganizationConfigRuleName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.DeleteOrganizationConfigRuleResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OrganizationConfigRuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CFGOrganizationConfigRule (DeleteOrganizationConfigRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.DeleteOrganizationConfigRuleResponse, RemoveCFGOrganizationConfigRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OrganizationConfigRuleName = this.OrganizationConfigRuleName;
            #if MODULAR
            if (this.OrganizationConfigRuleName == null && ParameterWasBound(nameof(this.OrganizationConfigRuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationConfigRuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.DeleteOrganizationConfigRuleRequest();
            
            if (cmdletContext.OrganizationConfigRuleName != null)
            {
                request.OrganizationConfigRuleName = cmdletContext.OrganizationConfigRuleName;
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
        
        private Amazon.ConfigService.Model.DeleteOrganizationConfigRuleResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DeleteOrganizationConfigRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DeleteOrganizationConfigRule");
            try
            {
                return client.DeleteOrganizationConfigRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String OrganizationConfigRuleName { get; set; }
            public System.Func<Amazon.ConfigService.Model.DeleteOrganizationConfigRuleResponse, RemoveCFGOrganizationConfigRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
