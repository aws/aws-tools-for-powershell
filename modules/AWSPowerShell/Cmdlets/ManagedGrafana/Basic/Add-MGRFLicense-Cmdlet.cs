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
using Amazon.ManagedGrafana;
using Amazon.ManagedGrafana.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGRF
{
    /// <summary>
    /// Assigns a Grafana Enterprise license to a workspace. To upgrade, you must use <c>ENTERPRISE</c>
    /// for the <c>licenseType</c>, and pass in a valid Grafana Labs token for the <c>grafanaToken</c>.
    /// Upgrading to Grafana Enterprise incurs additional fees. For more information, see
    /// <a href="https://docs.aws.amazon.com/grafana/latest/userguide/upgrade-to-Grafana-Enterprise.html">Upgrade
    /// a workspace to Grafana Enterprise</a>.
    /// </summary>
    [Cmdlet("Add", "MGRFLicense", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ManagedGrafana.Model.WorkspaceDescription")]
    [AWSCmdlet("Calls the Amazon Managed Grafana AssociateLicense API operation.", Operation = new[] {"AssociateLicense"}, SelectReturnType = typeof(Amazon.ManagedGrafana.Model.AssociateLicenseResponse))]
    [AWSCmdletOutput("Amazon.ManagedGrafana.Model.WorkspaceDescription or Amazon.ManagedGrafana.Model.AssociateLicenseResponse",
        "This cmdlet returns an Amazon.ManagedGrafana.Model.WorkspaceDescription object.",
        "The service call response (type Amazon.ManagedGrafana.Model.AssociateLicenseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddMGRFLicenseCmdlet : AmazonManagedGrafanaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GrafanaToken
        /// <summary>
        /// <para>
        /// <para>A token from Grafana Labs that ties your Amazon Web Services account with a Grafana
        /// Labs account. For more information, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/upgrade-to-Grafana-Enterprise.html#AMG-workspace-register-enterprise">Link
        /// your account with Grafana Labs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrafanaToken { get; set; }
        #endregion
        
        #region Parameter LicenseType
        /// <summary>
        /// <para>
        /// <para>The type of license to associate with the workspace.</para><note><para>Amazon Managed Grafana workspaces no longer support Grafana Enterprise free trials.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ManagedGrafana.LicenseType")]
        public Amazon.ManagedGrafana.LicenseType LicenseType { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace to associate the license with.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workspace'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedGrafana.Model.AssociateLicenseResponse).
        /// Specifying the name of a property of type Amazon.ManagedGrafana.Model.AssociateLicenseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workspace";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-MGRFLicense (AssociateLicense)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedGrafana.Model.AssociateLicenseResponse, AddMGRFLicenseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GrafanaToken = this.GrafanaToken;
            context.LicenseType = this.LicenseType;
            #if MODULAR
            if (this.LicenseType == null && ParameterWasBound(nameof(this.LicenseType)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ManagedGrafana.Model.AssociateLicenseRequest();
            
            if (cmdletContext.GrafanaToken != null)
            {
                request.GrafanaToken = cmdletContext.GrafanaToken;
            }
            if (cmdletContext.LicenseType != null)
            {
                request.LicenseType = cmdletContext.LicenseType;
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
        
        private Amazon.ManagedGrafana.Model.AssociateLicenseResponse CallAWSServiceOperation(IAmazonManagedGrafana client, Amazon.ManagedGrafana.Model.AssociateLicenseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Grafana", "AssociateLicense");
            try
            {
                return client.AssociateLicenseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GrafanaToken { get; set; }
            public Amazon.ManagedGrafana.LicenseType LicenseType { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.ManagedGrafana.Model.AssociateLicenseResponse, AddMGRFLicenseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workspace;
        }
        
    }
}
