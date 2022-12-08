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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Modify the default properties used to create WorkSpaces.
    /// </summary>
    [Cmdlet("Edit", "WKSWorkspaceCreationProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ModifyWorkspaceCreationProperties API operation.", Operation = new[] {"ModifyWorkspaceCreationProperties"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ModifyWorkspaceCreationPropertiesResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.ModifyWorkspaceCreationPropertiesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.ModifyWorkspaceCreationPropertiesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditWKSWorkspaceCreationPropertyCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter WorkspaceCreationProperties_CustomSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier of your custom security group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceCreationProperties_CustomSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter WorkspaceCreationProperties_DefaultOu
        /// <summary>
        /// <para>
        /// <para>The default organizational unit (OU) for your WorkSpaces directories. This string
        /// must be the full Lightweight Directory Access Protocol (LDAP) distinguished name for
        /// the target domain and OU. It must be in the form <code>"OU=<i>value</i>,DC=<i>value</i>,DC=<i>value</i>"</code>,
        /// where <i>value</i> is any string of characters, and the number of domain components
        /// (DCs) is two or more. For example, <code>OU=WorkSpaces_machines,DC=machines,DC=example,DC=com</code>.
        /// </para><important><ul><li><para>To avoid errors, certain characters in the distinguished name must be escaped. For
        /// more information, see <a href="https://docs.microsoft.com/previous-versions/windows/desktop/ldap/distinguished-names">
        /// Distinguished Names</a> in the Microsoft documentation.</para></li><li><para>The API doesn't validate whether the OU exists.</para></li></ul></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceCreationProperties_DefaultOu { get; set; }
        #endregion
        
        #region Parameter WorkspaceCreationProperties_EnableInternetAccess
        /// <summary>
        /// <para>
        /// <para>Indicates whether internet access is enabled for your WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WorkspaceCreationProperties_EnableInternetAccess { get; set; }
        #endregion
        
        #region Parameter WorkspaceCreationProperties_EnableMaintenanceMode
        /// <summary>
        /// <para>
        /// <para>Indicates whether maintenance mode is enabled for your WorkSpaces. For more information,
        /// see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/workspace-maintenance.html">WorkSpace
        /// Maintenance</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WorkspaceCreationProperties_EnableMaintenanceMode { get; set; }
        #endregion
        
        #region Parameter WorkspaceCreationProperties_EnableWorkDoc
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon WorkDocs is enabled for your WorkSpaces.</para><note><para>If WorkDocs is already enabled for a WorkSpaces directory and you disable it, new
        /// WorkSpaces launched in the directory will not have WorkDocs enabled. However, WorkDocs
        /// remains enabled for any existing WorkSpaces, unless you either disable users' access
        /// to WorkDocs or you delete the WorkDocs site. To disable users' access to WorkDocs,
        /// see <a href="https://docs.aws.amazon.com/workdocs/latest/adminguide/inactive-user.html">Disabling
        /// Users</a> in the <i>Amazon WorkDocs Administration Guide</i>. To delete a WorkDocs
        /// site, see <a href="https://docs.aws.amazon.com/workdocs/latest/adminguide/manage-sites.html">Deleting
        /// a Site</a> in the <i>Amazon WorkDocs Administration Guide</i>.</para><para>If you enable WorkDocs on a directory that already has existing WorkSpaces, the existing
        /// WorkSpaces and any new WorkSpaces that are launched in the directory will have WorkDocs
        /// enabled.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceCreationProperties_EnableWorkDocs")]
        public System.Boolean? WorkspaceCreationProperties_EnableWorkDoc { get; set; }
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
        
        #region Parameter WorkspaceCreationProperties_UserEnabledAsLocalAdministrator
        /// <summary>
        /// <para>
        /// <para>Indicates whether users are local administrators of their WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WorkspaceCreationProperties_UserEnabledAsLocalAdministrator { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ModifyWorkspaceCreationPropertiesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSWorkspaceCreationProperty (ModifyWorkspaceCreationProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ModifyWorkspaceCreationPropertiesResponse, EditWKSWorkspaceCreationPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkspaceCreationProperties_CustomSecurityGroupId = this.WorkspaceCreationProperties_CustomSecurityGroupId;
            context.WorkspaceCreationProperties_DefaultOu = this.WorkspaceCreationProperties_DefaultOu;
            context.WorkspaceCreationProperties_EnableInternetAccess = this.WorkspaceCreationProperties_EnableInternetAccess;
            context.WorkspaceCreationProperties_EnableMaintenanceMode = this.WorkspaceCreationProperties_EnableMaintenanceMode;
            context.WorkspaceCreationProperties_EnableWorkDoc = this.WorkspaceCreationProperties_EnableWorkDoc;
            context.WorkspaceCreationProperties_UserEnabledAsLocalAdministrator = this.WorkspaceCreationProperties_UserEnabledAsLocalAdministrator;
            
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
            var request = new Amazon.WorkSpaces.Model.ModifyWorkspaceCreationPropertiesRequest();
            
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            
             // populate WorkspaceCreationProperties
            var requestWorkspaceCreationPropertiesIsNull = true;
            request.WorkspaceCreationProperties = new Amazon.WorkSpaces.Model.WorkspaceCreationProperties();
            System.String requestWorkspaceCreationProperties_workspaceCreationProperties_CustomSecurityGroupId = null;
            if (cmdletContext.WorkspaceCreationProperties_CustomSecurityGroupId != null)
            {
                requestWorkspaceCreationProperties_workspaceCreationProperties_CustomSecurityGroupId = cmdletContext.WorkspaceCreationProperties_CustomSecurityGroupId;
            }
            if (requestWorkspaceCreationProperties_workspaceCreationProperties_CustomSecurityGroupId != null)
            {
                request.WorkspaceCreationProperties.CustomSecurityGroupId = requestWorkspaceCreationProperties_workspaceCreationProperties_CustomSecurityGroupId;
                requestWorkspaceCreationPropertiesIsNull = false;
            }
            System.String requestWorkspaceCreationProperties_workspaceCreationProperties_DefaultOu = null;
            if (cmdletContext.WorkspaceCreationProperties_DefaultOu != null)
            {
                requestWorkspaceCreationProperties_workspaceCreationProperties_DefaultOu = cmdletContext.WorkspaceCreationProperties_DefaultOu;
            }
            if (requestWorkspaceCreationProperties_workspaceCreationProperties_DefaultOu != null)
            {
                request.WorkspaceCreationProperties.DefaultOu = requestWorkspaceCreationProperties_workspaceCreationProperties_DefaultOu;
                requestWorkspaceCreationPropertiesIsNull = false;
            }
            System.Boolean? requestWorkspaceCreationProperties_workspaceCreationProperties_EnableInternetAccess = null;
            if (cmdletContext.WorkspaceCreationProperties_EnableInternetAccess != null)
            {
                requestWorkspaceCreationProperties_workspaceCreationProperties_EnableInternetAccess = cmdletContext.WorkspaceCreationProperties_EnableInternetAccess.Value;
            }
            if (requestWorkspaceCreationProperties_workspaceCreationProperties_EnableInternetAccess != null)
            {
                request.WorkspaceCreationProperties.EnableInternetAccess = requestWorkspaceCreationProperties_workspaceCreationProperties_EnableInternetAccess.Value;
                requestWorkspaceCreationPropertiesIsNull = false;
            }
            System.Boolean? requestWorkspaceCreationProperties_workspaceCreationProperties_EnableMaintenanceMode = null;
            if (cmdletContext.WorkspaceCreationProperties_EnableMaintenanceMode != null)
            {
                requestWorkspaceCreationProperties_workspaceCreationProperties_EnableMaintenanceMode = cmdletContext.WorkspaceCreationProperties_EnableMaintenanceMode.Value;
            }
            if (requestWorkspaceCreationProperties_workspaceCreationProperties_EnableMaintenanceMode != null)
            {
                request.WorkspaceCreationProperties.EnableMaintenanceMode = requestWorkspaceCreationProperties_workspaceCreationProperties_EnableMaintenanceMode.Value;
                requestWorkspaceCreationPropertiesIsNull = false;
            }
            System.Boolean? requestWorkspaceCreationProperties_workspaceCreationProperties_EnableWorkDoc = null;
            if (cmdletContext.WorkspaceCreationProperties_EnableWorkDoc != null)
            {
                requestWorkspaceCreationProperties_workspaceCreationProperties_EnableWorkDoc = cmdletContext.WorkspaceCreationProperties_EnableWorkDoc.Value;
            }
            if (requestWorkspaceCreationProperties_workspaceCreationProperties_EnableWorkDoc != null)
            {
                request.WorkspaceCreationProperties.EnableWorkDocs = requestWorkspaceCreationProperties_workspaceCreationProperties_EnableWorkDoc.Value;
                requestWorkspaceCreationPropertiesIsNull = false;
            }
            System.Boolean? requestWorkspaceCreationProperties_workspaceCreationProperties_UserEnabledAsLocalAdministrator = null;
            if (cmdletContext.WorkspaceCreationProperties_UserEnabledAsLocalAdministrator != null)
            {
                requestWorkspaceCreationProperties_workspaceCreationProperties_UserEnabledAsLocalAdministrator = cmdletContext.WorkspaceCreationProperties_UserEnabledAsLocalAdministrator.Value;
            }
            if (requestWorkspaceCreationProperties_workspaceCreationProperties_UserEnabledAsLocalAdministrator != null)
            {
                request.WorkspaceCreationProperties.UserEnabledAsLocalAdministrator = requestWorkspaceCreationProperties_workspaceCreationProperties_UserEnabledAsLocalAdministrator.Value;
                requestWorkspaceCreationPropertiesIsNull = false;
            }
             // determine if request.WorkspaceCreationProperties should be set to null
            if (requestWorkspaceCreationPropertiesIsNull)
            {
                request.WorkspaceCreationProperties = null;
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
        
        private Amazon.WorkSpaces.Model.ModifyWorkspaceCreationPropertiesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifyWorkspaceCreationPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifyWorkspaceCreationProperties");
            try
            {
                #if DESKTOP
                return client.ModifyWorkspaceCreationProperties(request);
                #elif CORECLR
                return client.ModifyWorkspaceCreationPropertiesAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceId { get; set; }
            public System.String WorkspaceCreationProperties_CustomSecurityGroupId { get; set; }
            public System.String WorkspaceCreationProperties_DefaultOu { get; set; }
            public System.Boolean? WorkspaceCreationProperties_EnableInternetAccess { get; set; }
            public System.Boolean? WorkspaceCreationProperties_EnableMaintenanceMode { get; set; }
            public System.Boolean? WorkspaceCreationProperties_EnableWorkDoc { get; set; }
            public System.Boolean? WorkspaceCreationProperties_UserEnabledAsLocalAdministrator { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ModifyWorkspaceCreationPropertiesResponse, EditWKSWorkspaceCreationPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
