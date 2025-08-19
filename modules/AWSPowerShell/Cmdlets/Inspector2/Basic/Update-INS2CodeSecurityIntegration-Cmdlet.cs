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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Updates an existing code security integration.
    /// 
    ///  
    /// <para>
    /// After calling the <c>CreateCodeSecurityIntegration</c> operation, you complete authentication
    /// and authorization with your provider. Next you call the <c>UpdateCodeSecurityIntegration</c>
    /// operation to provide the <c>details</c> to complete the integration setup
    /// </para>
    /// </summary>
    [Cmdlet("Update", "INS2CodeSecurityIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationResponse")]
    [AWSCmdlet("Calls the Inspector2 UpdateCodeSecurityIntegration API operation.", Operation = new[] {"UpdateCodeSecurityIntegration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationResponse object containing multiple properties."
    )]
    public partial class UpdateINS2CodeSecurityIntegrationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GitlabSelfManaged_AuthCode
        /// <summary>
        /// <para>
        /// <para>The authorization code received from the self-managed GitLab instance to update the
        /// integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_GitlabSelfManaged_AuthCode")]
        public System.String GitlabSelfManaged_AuthCode { get; set; }
        #endregion
        
        #region Parameter Github_Code
        /// <summary>
        /// <para>
        /// <para>The authorization code received from GitHub to update the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_Github_Code")]
        public System.String Github_Code { get; set; }
        #endregion
        
        #region Parameter Github_InstallationId
        /// <summary>
        /// <para>
        /// <para>The installation ID of the GitHub App associated with the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_Github_InstallationId")]
        public System.String Github_InstallationId { get; set; }
        #endregion
        
        #region Parameter IntegrationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the code security integration to update.</para>
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
        public System.String IntegrationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntegrationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INS2CodeSecurityIntegration (UpdateCodeSecurityIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationResponse, UpdateINS2CodeSecurityIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Github_Code = this.Github_Code;
            context.Github_InstallationId = this.Github_InstallationId;
            context.GitlabSelfManaged_AuthCode = this.GitlabSelfManaged_AuthCode;
            context.IntegrationArn = this.IntegrationArn;
            #if MODULAR
            if (this.IntegrationArn == null && ParameterWasBound(nameof(this.IntegrationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationRequest();
            
            
             // populate Details
            request.Details = new Amazon.Inspector2.Model.UpdateIntegrationDetails();
            Amazon.Inspector2.Model.UpdateGitLabSelfManagedIntegrationDetail requestDetails_details_GitlabSelfManaged = null;
            
             // populate GitlabSelfManaged
            var requestDetails_details_GitlabSelfManagedIsNull = true;
            requestDetails_details_GitlabSelfManaged = new Amazon.Inspector2.Model.UpdateGitLabSelfManagedIntegrationDetail();
            System.String requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_AuthCode = null;
            if (cmdletContext.GitlabSelfManaged_AuthCode != null)
            {
                requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_AuthCode = cmdletContext.GitlabSelfManaged_AuthCode;
            }
            if (requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_AuthCode != null)
            {
                requestDetails_details_GitlabSelfManaged.AuthCode = requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_AuthCode;
                requestDetails_details_GitlabSelfManagedIsNull = false;
            }
             // determine if requestDetails_details_GitlabSelfManaged should be set to null
            if (requestDetails_details_GitlabSelfManagedIsNull)
            {
                requestDetails_details_GitlabSelfManaged = null;
            }
            if (requestDetails_details_GitlabSelfManaged != null)
            {
                request.Details.GitlabSelfManaged = requestDetails_details_GitlabSelfManaged;
            }
            Amazon.Inspector2.Model.UpdateGitHubIntegrationDetail requestDetails_details_Github = null;
            
             // populate Github
            var requestDetails_details_GithubIsNull = true;
            requestDetails_details_Github = new Amazon.Inspector2.Model.UpdateGitHubIntegrationDetail();
            System.String requestDetails_details_Github_github_Code = null;
            if (cmdletContext.Github_Code != null)
            {
                requestDetails_details_Github_github_Code = cmdletContext.Github_Code;
            }
            if (requestDetails_details_Github_github_Code != null)
            {
                requestDetails_details_Github.Code = requestDetails_details_Github_github_Code;
                requestDetails_details_GithubIsNull = false;
            }
            System.String requestDetails_details_Github_github_InstallationId = null;
            if (cmdletContext.Github_InstallationId != null)
            {
                requestDetails_details_Github_github_InstallationId = cmdletContext.Github_InstallationId;
            }
            if (requestDetails_details_Github_github_InstallationId != null)
            {
                requestDetails_details_Github.InstallationId = requestDetails_details_Github_github_InstallationId;
                requestDetails_details_GithubIsNull = false;
            }
             // determine if requestDetails_details_Github should be set to null
            if (requestDetails_details_GithubIsNull)
            {
                requestDetails_details_Github = null;
            }
            if (requestDetails_details_Github != null)
            {
                request.Details.Github = requestDetails_details_Github;
            }
            if (cmdletContext.IntegrationArn != null)
            {
                request.IntegrationArn = cmdletContext.IntegrationArn;
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
        
        private Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "UpdateCodeSecurityIntegration");
            try
            {
                return client.UpdateCodeSecurityIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Github_Code { get; set; }
            public System.String Github_InstallationId { get; set; }
            public System.String GitlabSelfManaged_AuthCode { get; set; }
            public System.String IntegrationArn { get; set; }
            public System.Func<Amazon.Inspector2.Model.UpdateCodeSecurityIntegrationResponse, UpdateINS2CodeSecurityIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
