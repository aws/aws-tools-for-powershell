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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Migrates a WorkSpace from one operating system or bundle type to another, while retaining
    /// the data on the user volume.
    /// 
    ///  
    /// <para>
    /// The migration process recreates the WorkSpace by using a new root volume from the
    /// target bundle image and the user volume from the last available snapshot of the original
    /// WorkSpace. During migration, the original <c>D:\Users\%USERNAME%</c> user profile
    /// folder is renamed to <c>D:\Users\%USERNAME%MMddyyTHHmmss%.NotMigrated</c>. A new <c>D:\Users\%USERNAME%\</c>
    /// folder is generated by the new OS. Certain files in the old user profile are moved
    /// to the new user profile.
    /// </para><para>
    /// For available migration scenarios, details about what happens during migration, and
    /// best practices, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/migrate-workspaces.html">Migrate
    /// a WorkSpace</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "WKSWorkspaceMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpaces.Model.MigrateWorkspaceResponse")]
    [AWSCmdlet("Calls the Amazon WorkSpaces MigrateWorkspace API operation.", Operation = new[] {"MigrateWorkspace"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.MigrateWorkspaceResponse))]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.MigrateWorkspaceResponse",
        "This cmdlet returns an Amazon.WorkSpaces.Model.MigrateWorkspaceResponse object containing multiple properties."
    )]
    public partial class StartWKSWorkspaceMigrationCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the target bundle type to migrate the WorkSpace to.</para>
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
        public System.String BundleId { get; set; }
        #endregion
        
        #region Parameter SourceWorkspaceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the WorkSpace to migrate from.</para>
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
        public System.String SourceWorkspaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.MigrateWorkspaceResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.MigrateWorkspaceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceWorkspaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-WKSWorkspaceMigration (MigrateWorkspace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.MigrateWorkspaceResponse, StartWKSWorkspaceMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BundleId = this.BundleId;
            #if MODULAR
            if (this.BundleId == null && ParameterWasBound(nameof(this.BundleId)))
            {
                WriteWarning("You are passing $null as a value for parameter BundleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceWorkspaceId = this.SourceWorkspaceId;
            #if MODULAR
            if (this.SourceWorkspaceId == null && ParameterWasBound(nameof(this.SourceWorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceWorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpaces.Model.MigrateWorkspaceRequest();
            
            if (cmdletContext.BundleId != null)
            {
                request.BundleId = cmdletContext.BundleId;
            }
            if (cmdletContext.SourceWorkspaceId != null)
            {
                request.SourceWorkspaceId = cmdletContext.SourceWorkspaceId;
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
        
        private Amazon.WorkSpaces.Model.MigrateWorkspaceResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.MigrateWorkspaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "MigrateWorkspace");
            try
            {
                return client.MigrateWorkspaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BundleId { get; set; }
            public System.String SourceWorkspaceId { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.MigrateWorkspaceResponse, StartWKSWorkspaceMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
