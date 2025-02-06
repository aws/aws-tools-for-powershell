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
    /// Updates the configuration string for the given workspace
    /// </summary>
    [Cmdlet("Update", "MGRFWorkspaceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Managed Grafana UpdateWorkspaceConfiguration API operation.", Operation = new[] {"UpdateWorkspaceConfiguration"}, SelectReturnType = typeof(Amazon.ManagedGrafana.Model.UpdateWorkspaceConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.ManagedGrafana.Model.UpdateWorkspaceConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ManagedGrafana.Model.UpdateWorkspaceConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateMGRFWorkspaceConfigurationCmdlet : AmazonManagedGrafanaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>The new configuration string for the workspace. For more information about the format
        /// and configuration options available, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/AMG-configure-workspace.html">Working
        /// in your Grafana workspace</a>.</para>
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
        public System.String Configuration { get; set; }
        #endregion
        
        #region Parameter GrafanaVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the version of Grafana to support in the workspace. If not specified, keeps
        /// the current version of the workspace.</para><para>Can only be used to upgrade (for example, from 8.4 to 9.4), not downgrade (for example,
        /// from 9.4 to 8.4).</para><para>To know what versions are available to upgrade to for a specific workspace, see the
        /// <a href="https://docs.aws.amazon.com/grafana/latest/APIReference/API_ListVersions.html">ListVersions</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrafanaVersion { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace to update.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedGrafana.Model.UpdateWorkspaceConfigurationResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGRFWorkspaceConfiguration (UpdateWorkspaceConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedGrafana.Model.UpdateWorkspaceConfigurationResponse, UpdateMGRFWorkspaceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration = this.Configuration;
            #if MODULAR
            if (this.Configuration == null && ParameterWasBound(nameof(this.Configuration)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GrafanaVersion = this.GrafanaVersion;
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
            var request = new Amazon.ManagedGrafana.Model.UpdateWorkspaceConfigurationRequest();
            
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            if (cmdletContext.GrafanaVersion != null)
            {
                request.GrafanaVersion = cmdletContext.GrafanaVersion;
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
        
        private Amazon.ManagedGrafana.Model.UpdateWorkspaceConfigurationResponse CallAWSServiceOperation(IAmazonManagedGrafana client, Amazon.ManagedGrafana.Model.UpdateWorkspaceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Grafana", "UpdateWorkspaceConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateWorkspaceConfiguration(request);
                #elif CORECLR
                return client.UpdateWorkspaceConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Configuration { get; set; }
            public System.String GrafanaVersion { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.ManagedGrafana.Model.UpdateWorkspaceConfigurationResponse, UpdateMGRFWorkspaceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
