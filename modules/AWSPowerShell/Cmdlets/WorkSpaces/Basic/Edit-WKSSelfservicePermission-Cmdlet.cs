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
    /// Modifies the self-service WorkSpace management capabilities for your users. For more
    /// information, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/enable-user-self-service-workspace-management.html">Enable
    /// Self-Service WorkSpace Management Capabilities for Your Users</a>.
    /// </summary>
    [Cmdlet("Edit", "WKSSelfservicePermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ModifySelfservicePermissions API operation.", Operation = new[] {"ModifySelfservicePermissions"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ModifySelfservicePermissionsResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.ModifySelfservicePermissionsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.ModifySelfservicePermissionsResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditWKSSelfservicePermissionCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SelfservicePermissions_ChangeComputeType
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can change the compute type (bundle) for their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.ReconnectEnum")]
        public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_ChangeComputeType { get; set; }
        #endregion
        
        #region Parameter SelfservicePermissions_IncreaseVolumeSize
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can increase the volume size of the drives on their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.ReconnectEnum")]
        public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_IncreaseVolumeSize { get; set; }
        #endregion
        
        #region Parameter SelfservicePermissions_RebuildWorkspace
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can rebuild the operating system of a WorkSpace to its original
        /// state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.ReconnectEnum")]
        public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_RebuildWorkspace { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter SelfservicePermissions_RestartWorkspace
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can restart their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.ReconnectEnum")]
        public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_RestartWorkspace { get; set; }
        #endregion
        
        #region Parameter SelfservicePermissions_SwitchRunningMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can switch the running mode of their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.ReconnectEnum")]
        public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_SwitchRunningMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ModifySelfservicePermissionsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSSelfservicePermission (ModifySelfservicePermissions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ModifySelfservicePermissionsResponse, EditWKSSelfservicePermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SelfservicePermissions_ChangeComputeType = this.SelfservicePermissions_ChangeComputeType;
            context.SelfservicePermissions_IncreaseVolumeSize = this.SelfservicePermissions_IncreaseVolumeSize;
            context.SelfservicePermissions_RebuildWorkspace = this.SelfservicePermissions_RebuildWorkspace;
            context.SelfservicePermissions_RestartWorkspace = this.SelfservicePermissions_RestartWorkspace;
            context.SelfservicePermissions_SwitchRunningMode = this.SelfservicePermissions_SwitchRunningMode;
            
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
            var request = new Amazon.WorkSpaces.Model.ModifySelfservicePermissionsRequest();
            
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            
             // populate SelfservicePermissions
            var requestSelfservicePermissionsIsNull = true;
            request.SelfservicePermissions = new Amazon.WorkSpaces.Model.SelfservicePermissions();
            Amazon.WorkSpaces.ReconnectEnum requestSelfservicePermissions_selfservicePermissions_ChangeComputeType = null;
            if (cmdletContext.SelfservicePermissions_ChangeComputeType != null)
            {
                requestSelfservicePermissions_selfservicePermissions_ChangeComputeType = cmdletContext.SelfservicePermissions_ChangeComputeType;
            }
            if (requestSelfservicePermissions_selfservicePermissions_ChangeComputeType != null)
            {
                request.SelfservicePermissions.ChangeComputeType = requestSelfservicePermissions_selfservicePermissions_ChangeComputeType;
                requestSelfservicePermissionsIsNull = false;
            }
            Amazon.WorkSpaces.ReconnectEnum requestSelfservicePermissions_selfservicePermissions_IncreaseVolumeSize = null;
            if (cmdletContext.SelfservicePermissions_IncreaseVolumeSize != null)
            {
                requestSelfservicePermissions_selfservicePermissions_IncreaseVolumeSize = cmdletContext.SelfservicePermissions_IncreaseVolumeSize;
            }
            if (requestSelfservicePermissions_selfservicePermissions_IncreaseVolumeSize != null)
            {
                request.SelfservicePermissions.IncreaseVolumeSize = requestSelfservicePermissions_selfservicePermissions_IncreaseVolumeSize;
                requestSelfservicePermissionsIsNull = false;
            }
            Amazon.WorkSpaces.ReconnectEnum requestSelfservicePermissions_selfservicePermissions_RebuildWorkspace = null;
            if (cmdletContext.SelfservicePermissions_RebuildWorkspace != null)
            {
                requestSelfservicePermissions_selfservicePermissions_RebuildWorkspace = cmdletContext.SelfservicePermissions_RebuildWorkspace;
            }
            if (requestSelfservicePermissions_selfservicePermissions_RebuildWorkspace != null)
            {
                request.SelfservicePermissions.RebuildWorkspace = requestSelfservicePermissions_selfservicePermissions_RebuildWorkspace;
                requestSelfservicePermissionsIsNull = false;
            }
            Amazon.WorkSpaces.ReconnectEnum requestSelfservicePermissions_selfservicePermissions_RestartWorkspace = null;
            if (cmdletContext.SelfservicePermissions_RestartWorkspace != null)
            {
                requestSelfservicePermissions_selfservicePermissions_RestartWorkspace = cmdletContext.SelfservicePermissions_RestartWorkspace;
            }
            if (requestSelfservicePermissions_selfservicePermissions_RestartWorkspace != null)
            {
                request.SelfservicePermissions.RestartWorkspace = requestSelfservicePermissions_selfservicePermissions_RestartWorkspace;
                requestSelfservicePermissionsIsNull = false;
            }
            Amazon.WorkSpaces.ReconnectEnum requestSelfservicePermissions_selfservicePermissions_SwitchRunningMode = null;
            if (cmdletContext.SelfservicePermissions_SwitchRunningMode != null)
            {
                requestSelfservicePermissions_selfservicePermissions_SwitchRunningMode = cmdletContext.SelfservicePermissions_SwitchRunningMode;
            }
            if (requestSelfservicePermissions_selfservicePermissions_SwitchRunningMode != null)
            {
                request.SelfservicePermissions.SwitchRunningMode = requestSelfservicePermissions_selfservicePermissions_SwitchRunningMode;
                requestSelfservicePermissionsIsNull = false;
            }
             // determine if request.SelfservicePermissions should be set to null
            if (requestSelfservicePermissionsIsNull)
            {
                request.SelfservicePermissions = null;
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
        
        private Amazon.WorkSpaces.Model.ModifySelfservicePermissionsResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifySelfservicePermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifySelfservicePermissions");
            try
            {
                return client.ModifySelfservicePermissionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResourceId { get; set; }
            public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_ChangeComputeType { get; set; }
            public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_IncreaseVolumeSize { get; set; }
            public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_RebuildWorkspace { get; set; }
            public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_RestartWorkspace { get; set; }
            public Amazon.WorkSpaces.ReconnectEnum SelfservicePermissions_SwitchRunningMode { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ModifySelfservicePermissionsResponse, EditWKSSelfservicePermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
