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
using Amazon.FinSpaceData;
using Amazon.FinSpaceData.Model;

namespace Amazon.PowerShell.Cmdlets.FNSP
{
    /// <summary>
    /// Modifies the details of a permission group. You cannot modify a <c>permissionGroupID</c>.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Update", "FNSPPermissionGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the FinSpace Public API UpdatePermissionGroup API operation.", Operation = new[] {"UpdatePermissionGroup"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.UpdatePermissionGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.FinSpaceData.Model.UpdatePermissionGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.FinSpaceData.Model.UpdatePermissionGroupResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This method will be discontinued.")]
    public partial class UpdateFNSPPermissionGroupCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationPermission
        /// <summary>
        /// <para>
        /// <para>The permissions that are granted to a specific group for accessing the FinSpace application.</para><important><para>When assigning application permissions, be aware that the permission <c>ManageUsersAndGroups</c>
        /// allows users to grant themselves or others access to any functionality in their FinSpace
        /// environment's application. It should only be granted to trusted users.</para></important><ul><li><para><c>CreateDataset</c> – Group members can create new datasets.</para></li><li><para><c>ManageClusters</c> – Group members can manage Apache Spark clusters from FinSpace
        /// notebooks.</para></li><li><para><c>ManageUsersAndGroups</c> – Group members can manage users and permission groups.
        /// This is a privileged permission that allows users to grant themselves or others access
        /// to any functionality in the application. It should only be granted to trusted users.</para></li><li><para><c>ManageAttributeSets</c> – Group members can manage attribute sets.</para></li><li><para><c>ViewAuditData</c> – Group members can view audit data.</para></li><li><para><c>AccessNotebooks</c> – Group members will have access to FinSpace notebooks.</para></li><li><para><c>GetTemporaryCredentials</c> – Group members can get temporary API credentials.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationPermissions")]
        public System.String[] ApplicationPermission { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description for the permission group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the permission group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PermissionGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the permission group to update.</para>
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
        public System.String PermissionGroupId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PermissionGroupId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.UpdatePermissionGroupResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.UpdatePermissionGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PermissionGroupId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PermissionGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FNSPPermissionGroup (UpdatePermissionGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.UpdatePermissionGroupResponse, UpdateFNSPPermissionGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ApplicationPermission != null)
            {
                context.ApplicationPermission = new List<System.String>(this.ApplicationPermission);
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            context.PermissionGroupId = this.PermissionGroupId;
            #if MODULAR
            if (this.PermissionGroupId == null && ParameterWasBound(nameof(this.PermissionGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FinSpaceData.Model.UpdatePermissionGroupRequest();
            
            if (cmdletContext.ApplicationPermission != null)
            {
                request.ApplicationPermissions = cmdletContext.ApplicationPermission;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PermissionGroupId != null)
            {
                request.PermissionGroupId = cmdletContext.PermissionGroupId;
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
        
        private Amazon.FinSpaceData.Model.UpdatePermissionGroupResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.UpdatePermissionGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "UpdatePermissionGroup");
            try
            {
                #if DESKTOP
                return client.UpdatePermissionGroup(request);
                #elif CORECLR
                return client.UpdatePermissionGroupAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ApplicationPermission { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String PermissionGroupId { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.UpdatePermissionGroupResponse, UpdateFNSPPermissionGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PermissionGroupId;
        }
        
    }
}
