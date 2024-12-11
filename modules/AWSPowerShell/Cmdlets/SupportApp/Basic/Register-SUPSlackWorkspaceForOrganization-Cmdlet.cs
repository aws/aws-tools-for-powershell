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
using Amazon.SupportApp;
using Amazon.SupportApp.Model;

namespace Amazon.PowerShell.Cmdlets.SUP
{
    /// <summary>
    /// Registers a Slack workspace for your Amazon Web Services account. To call this API,
    /// your account must be part of an organization in Organizations.
    /// 
    ///  
    /// <para>
    /// If you're the <i>management account</i> and you want to register Slack workspaces
    /// for your organization, you must complete the following tasks:
    /// </para><ol><li><para>
    /// Sign in to the <a href="https://console.aws.amazon.com/support/app">Amazon Web Services
    /// Support Center</a> and authorize the Slack workspaces where you want your organization
    /// to have access to. See <a href="https://docs.aws.amazon.com/awssupport/latest/user/authorize-slack-workspace.html">Authorize
    /// a Slack workspace</a> in the <i>Amazon Web Services Support User Guide</i>.
    /// </para></li><li><para>
    /// Call the <c>RegisterSlackWorkspaceForOrganization</c> API to authorize each Slack
    /// workspace for the organization.
    /// </para></li></ol><para>
    /// After the management account authorizes the Slack workspace, member accounts can call
    /// this API to authorize the same Slack workspace for their individual accounts. Member
    /// accounts don't need to authorize the Slack workspace manually through the <a href="https://console.aws.amazon.com/support/app">Amazon
    /// Web Services Support Center</a>.
    /// </para><para>
    /// To use the Amazon Web Services Support App, each account must then complete the following
    /// tasks:
    /// </para><ul><li><para>
    /// Create an Identity and Access Management (IAM) role with the required permission.
    /// For more information, see <a href="https://docs.aws.amazon.com/awssupport/latest/user/support-app-permissions.html">Managing
    /// access to the Amazon Web Services Support App</a>.
    /// </para></li><li><para>
    /// Configure a Slack channel to use the Amazon Web Services Support App for support cases
    /// for that account. For more information, see <a href="https://docs.aws.amazon.com/awssupport/latest/user/add-your-slack-channel.html">Configuring
    /// a Slack channel</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Register", "SUPSlackWorkspaceForOrganization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationResponse")]
    [AWSCmdlet("Calls the AWS Support App RegisterSlackWorkspaceForOrganization API operation.", Operation = new[] {"RegisterSlackWorkspaceForOrganization"}, SelectReturnType = typeof(Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationResponse",
        "This cmdlet returns an Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationResponse object containing multiple properties."
    )]
    public partial class RegisterSUPSlackWorkspaceForOrganizationCmdlet : AmazonSupportAppClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TeamId
        /// <summary>
        /// <para>
        /// <para>The team ID in Slack. This ID uniquely identifies a Slack workspace, such as <c>T012ABCDEFG</c>.
        /// Specify the Slack workspace that you want to use for your organization.</para>
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
        public System.String TeamId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TeamId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-SUPSlackWorkspaceForOrganization (RegisterSlackWorkspaceForOrganization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationResponse, RegisterSUPSlackWorkspaceForOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TeamId = this.TeamId;
            #if MODULAR
            if (this.TeamId == null && ParameterWasBound(nameof(this.TeamId)))
            {
                WriteWarning("You are passing $null as a value for parameter TeamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationRequest();
            
            if (cmdletContext.TeamId != null)
            {
                request.TeamId = cmdletContext.TeamId;
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
        
        private Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationResponse CallAWSServiceOperation(IAmazonSupportApp client, Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support App", "RegisterSlackWorkspaceForOrganization");
            try
            {
                #if DESKTOP
                return client.RegisterSlackWorkspaceForOrganization(request);
                #elif CORECLR
                return client.RegisterSlackWorkspaceForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.String TeamId { get; set; }
            public System.Func<Amazon.SupportApp.Model.RegisterSlackWorkspaceForOrganizationResponse, RegisterSUPSlackWorkspaceForOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
