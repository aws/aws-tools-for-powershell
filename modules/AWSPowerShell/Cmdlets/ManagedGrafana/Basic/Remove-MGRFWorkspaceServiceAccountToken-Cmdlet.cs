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
using Amazon.ManagedGrafana;
using Amazon.ManagedGrafana.Model;

namespace Amazon.PowerShell.Cmdlets.MGRF
{
    /// <summary>
    /// Deletes a token for the workspace service account.
    /// 
    ///  
    /// <para>
    /// This will disable the key associated with the token. If any automation is currently
    /// using the key, it will no longer be authenticated or authorized to perform actions
    /// with the Grafana HTTP APIs.
    /// </para><para>
    /// Service accounts are only available for workspaces that are compatible with Grafana
    /// version 9 and above.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "MGRFWorkspaceServiceAccountToken", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenResponse")]
    [AWSCmdlet("Calls the Amazon Managed Grafana DeleteWorkspaceServiceAccountToken API operation.", Operation = new[] {"DeleteWorkspaceServiceAccountToken"}, SelectReturnType = typeof(Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenResponse))]
    [AWSCmdletOutput("Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenResponse",
        "This cmdlet returns an Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenResponse object containing multiple properties."
    )]
    public partial class RemoveMGRFWorkspaceServiceAccountTokenCmdlet : AmazonManagedGrafanaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ServiceAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the service account from which to delete the token.</para>
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
        public System.String ServiceAccountId { get; set; }
        #endregion
        
        #region Parameter TokenId
        /// <summary>
        /// <para>
        /// <para>The ID of the token to delete.</para>
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
        public System.String TokenId { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace from which to delete the token.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenResponse).
        /// Specifying the name of a property of type Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-MGRFWorkspaceServiceAccountToken (DeleteWorkspaceServiceAccountToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenResponse, RemoveMGRFWorkspaceServiceAccountTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ServiceAccountId = this.ServiceAccountId;
            #if MODULAR
            if (this.ServiceAccountId == null && ParameterWasBound(nameof(this.ServiceAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TokenId = this.TokenId;
            #if MODULAR
            if (this.TokenId == null && ParameterWasBound(nameof(this.TokenId)))
            {
                WriteWarning("You are passing $null as a value for parameter TokenId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenRequest();
            
            if (cmdletContext.ServiceAccountId != null)
            {
                request.ServiceAccountId = cmdletContext.ServiceAccountId;
            }
            if (cmdletContext.TokenId != null)
            {
                request.TokenId = cmdletContext.TokenId;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
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
        
        private Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenResponse CallAWSServiceOperation(IAmazonManagedGrafana client, Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Grafana", "DeleteWorkspaceServiceAccountToken");
            try
            {
                #if DESKTOP
                return client.DeleteWorkspaceServiceAccountToken(request);
                #elif CORECLR
                return client.DeleteWorkspaceServiceAccountTokenAsync(request).GetAwaiter().GetResult();
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
            public System.String ServiceAccountId { get; set; }
            public System.String TokenId { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.ManagedGrafana.Model.DeleteWorkspaceServiceAccountTokenResponse, RemoveMGRFWorkspaceServiceAccountTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
