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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Updates an existing access policy that specifies an identity's access to an IoT SiteWise
    /// Monitor portal or project resource.
    /// </summary>
    [Cmdlet("Update", "IOTSWAccessPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT SiteWise UpdateAccessPolicy API operation.", Operation = new[] {"UpdateAccessPolicy"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.UpdateAccessPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.IoTSiteWise.Model.UpdateAccessPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTSiteWise.Model.UpdateAccessPolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTSWAccessPolicyCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the access policy.</para>
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
        public System.String AccessPolicyId { get; set; }
        #endregion
        
        #region Parameter AccessPolicyPermission
        /// <summary>
        /// <para>
        /// <para>The permission level for this access policy. Note that a project <c>ADMINISTRATOR</c>
        /// is also known as a project owner.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTSiteWise.Permission")]
        public Amazon.IoTSiteWise.Permission AccessPolicyPermission { get; set; }
        #endregion
        
        #region Parameter IamRole_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html">IAM
        /// ARNs</a> in the <i>IAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessPolicyIdentity_IamRole_Arn")]
        public System.String IamRole_Arn { get; set; }
        #endregion
        
        #region Parameter IamUser_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM user. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html">IAM
        /// ARNs</a> in the <i>IAM User Guide</i>.</para><note><para>If you delete the IAM user, access policies that contain this identity include an
        /// empty <c>arn</c>. You can delete the access policy for the IAM user that no longer
        /// exists.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessPolicyIdentity_IamUser_Arn")]
        public System.String IamUser_Arn { get; set; }
        #endregion
        
        #region Parameter Group_Id
        /// <summary>
        /// <para>
        /// <para>The IAM Identity Center ID of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessPolicyIdentity_Group_Id")]
        public System.String Group_Id { get; set; }
        #endregion
        
        #region Parameter User_Id
        /// <summary>
        /// <para>
        /// <para>The IAM Identity Center ID of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessPolicyIdentity_User_Id")]
        public System.String User_Id { get; set; }
        #endregion
        
        #region Parameter Portal_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessPolicyResource_Portal_Id")]
        public System.String Portal_Id { get; set; }
        #endregion
        
        #region Parameter Project_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessPolicyResource_Project_Id")]
        public System.String Project_Id { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.UpdateAccessPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccessPolicyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccessPolicyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccessPolicyId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccessPolicyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWAccessPolicy (UpdateAccessPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdateAccessPolicyResponse, UpdateIOTSWAccessPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccessPolicyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessPolicyId = this.AccessPolicyId;
            #if MODULAR
            if (this.AccessPolicyId == null && ParameterWasBound(nameof(this.AccessPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Group_Id = this.Group_Id;
            context.IamRole_Arn = this.IamRole_Arn;
            context.IamUser_Arn = this.IamUser_Arn;
            context.User_Id = this.User_Id;
            context.AccessPolicyPermission = this.AccessPolicyPermission;
            #if MODULAR
            if (this.AccessPolicyPermission == null && ParameterWasBound(nameof(this.AccessPolicyPermission)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessPolicyPermission which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Portal_Id = this.Portal_Id;
            context.Project_Id = this.Project_Id;
            context.ClientToken = this.ClientToken;
            
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
            var request = new Amazon.IoTSiteWise.Model.UpdateAccessPolicyRequest();
            
            if (cmdletContext.AccessPolicyId != null)
            {
                request.AccessPolicyId = cmdletContext.AccessPolicyId;
            }
            
             // populate AccessPolicyIdentity
            var requestAccessPolicyIdentityIsNull = true;
            request.AccessPolicyIdentity = new Amazon.IoTSiteWise.Model.Identity();
            Amazon.IoTSiteWise.Model.GroupIdentity requestAccessPolicyIdentity_accessPolicyIdentity_Group = null;
            
             // populate Group
            var requestAccessPolicyIdentity_accessPolicyIdentity_GroupIsNull = true;
            requestAccessPolicyIdentity_accessPolicyIdentity_Group = new Amazon.IoTSiteWise.Model.GroupIdentity();
            System.String requestAccessPolicyIdentity_accessPolicyIdentity_Group_group_Id = null;
            if (cmdletContext.Group_Id != null)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_Group_group_Id = cmdletContext.Group_Id;
            }
            if (requestAccessPolicyIdentity_accessPolicyIdentity_Group_group_Id != null)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_Group.Id = requestAccessPolicyIdentity_accessPolicyIdentity_Group_group_Id;
                requestAccessPolicyIdentity_accessPolicyIdentity_GroupIsNull = false;
            }
             // determine if requestAccessPolicyIdentity_accessPolicyIdentity_Group should be set to null
            if (requestAccessPolicyIdentity_accessPolicyIdentity_GroupIsNull)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_Group = null;
            }
            if (requestAccessPolicyIdentity_accessPolicyIdentity_Group != null)
            {
                request.AccessPolicyIdentity.Group = requestAccessPolicyIdentity_accessPolicyIdentity_Group;
                requestAccessPolicyIdentityIsNull = false;
            }
            Amazon.IoTSiteWise.Model.IAMRoleIdentity requestAccessPolicyIdentity_accessPolicyIdentity_IamRole = null;
            
             // populate IamRole
            var requestAccessPolicyIdentity_accessPolicyIdentity_IamRoleIsNull = true;
            requestAccessPolicyIdentity_accessPolicyIdentity_IamRole = new Amazon.IoTSiteWise.Model.IAMRoleIdentity();
            System.String requestAccessPolicyIdentity_accessPolicyIdentity_IamRole_iamRole_Arn = null;
            if (cmdletContext.IamRole_Arn != null)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_IamRole_iamRole_Arn = cmdletContext.IamRole_Arn;
            }
            if (requestAccessPolicyIdentity_accessPolicyIdentity_IamRole_iamRole_Arn != null)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_IamRole.Arn = requestAccessPolicyIdentity_accessPolicyIdentity_IamRole_iamRole_Arn;
                requestAccessPolicyIdentity_accessPolicyIdentity_IamRoleIsNull = false;
            }
             // determine if requestAccessPolicyIdentity_accessPolicyIdentity_IamRole should be set to null
            if (requestAccessPolicyIdentity_accessPolicyIdentity_IamRoleIsNull)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_IamRole = null;
            }
            if (requestAccessPolicyIdentity_accessPolicyIdentity_IamRole != null)
            {
                request.AccessPolicyIdentity.IamRole = requestAccessPolicyIdentity_accessPolicyIdentity_IamRole;
                requestAccessPolicyIdentityIsNull = false;
            }
            Amazon.IoTSiteWise.Model.IAMUserIdentity requestAccessPolicyIdentity_accessPolicyIdentity_IamUser = null;
            
             // populate IamUser
            var requestAccessPolicyIdentity_accessPolicyIdentity_IamUserIsNull = true;
            requestAccessPolicyIdentity_accessPolicyIdentity_IamUser = new Amazon.IoTSiteWise.Model.IAMUserIdentity();
            System.String requestAccessPolicyIdentity_accessPolicyIdentity_IamUser_iamUser_Arn = null;
            if (cmdletContext.IamUser_Arn != null)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_IamUser_iamUser_Arn = cmdletContext.IamUser_Arn;
            }
            if (requestAccessPolicyIdentity_accessPolicyIdentity_IamUser_iamUser_Arn != null)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_IamUser.Arn = requestAccessPolicyIdentity_accessPolicyIdentity_IamUser_iamUser_Arn;
                requestAccessPolicyIdentity_accessPolicyIdentity_IamUserIsNull = false;
            }
             // determine if requestAccessPolicyIdentity_accessPolicyIdentity_IamUser should be set to null
            if (requestAccessPolicyIdentity_accessPolicyIdentity_IamUserIsNull)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_IamUser = null;
            }
            if (requestAccessPolicyIdentity_accessPolicyIdentity_IamUser != null)
            {
                request.AccessPolicyIdentity.IamUser = requestAccessPolicyIdentity_accessPolicyIdentity_IamUser;
                requestAccessPolicyIdentityIsNull = false;
            }
            Amazon.IoTSiteWise.Model.UserIdentity requestAccessPolicyIdentity_accessPolicyIdentity_User = null;
            
             // populate User
            var requestAccessPolicyIdentity_accessPolicyIdentity_UserIsNull = true;
            requestAccessPolicyIdentity_accessPolicyIdentity_User = new Amazon.IoTSiteWise.Model.UserIdentity();
            System.String requestAccessPolicyIdentity_accessPolicyIdentity_User_user_Id = null;
            if (cmdletContext.User_Id != null)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_User_user_Id = cmdletContext.User_Id;
            }
            if (requestAccessPolicyIdentity_accessPolicyIdentity_User_user_Id != null)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_User.Id = requestAccessPolicyIdentity_accessPolicyIdentity_User_user_Id;
                requestAccessPolicyIdentity_accessPolicyIdentity_UserIsNull = false;
            }
             // determine if requestAccessPolicyIdentity_accessPolicyIdentity_User should be set to null
            if (requestAccessPolicyIdentity_accessPolicyIdentity_UserIsNull)
            {
                requestAccessPolicyIdentity_accessPolicyIdentity_User = null;
            }
            if (requestAccessPolicyIdentity_accessPolicyIdentity_User != null)
            {
                request.AccessPolicyIdentity.User = requestAccessPolicyIdentity_accessPolicyIdentity_User;
                requestAccessPolicyIdentityIsNull = false;
            }
             // determine if request.AccessPolicyIdentity should be set to null
            if (requestAccessPolicyIdentityIsNull)
            {
                request.AccessPolicyIdentity = null;
            }
            if (cmdletContext.AccessPolicyPermission != null)
            {
                request.AccessPolicyPermission = cmdletContext.AccessPolicyPermission;
            }
            
             // populate AccessPolicyResource
            var requestAccessPolicyResourceIsNull = true;
            request.AccessPolicyResource = new Amazon.IoTSiteWise.Model.Resource();
            Amazon.IoTSiteWise.Model.PortalResource requestAccessPolicyResource_accessPolicyResource_Portal = null;
            
             // populate Portal
            var requestAccessPolicyResource_accessPolicyResource_PortalIsNull = true;
            requestAccessPolicyResource_accessPolicyResource_Portal = new Amazon.IoTSiteWise.Model.PortalResource();
            System.String requestAccessPolicyResource_accessPolicyResource_Portal_portal_Id = null;
            if (cmdletContext.Portal_Id != null)
            {
                requestAccessPolicyResource_accessPolicyResource_Portal_portal_Id = cmdletContext.Portal_Id;
            }
            if (requestAccessPolicyResource_accessPolicyResource_Portal_portal_Id != null)
            {
                requestAccessPolicyResource_accessPolicyResource_Portal.Id = requestAccessPolicyResource_accessPolicyResource_Portal_portal_Id;
                requestAccessPolicyResource_accessPolicyResource_PortalIsNull = false;
            }
             // determine if requestAccessPolicyResource_accessPolicyResource_Portal should be set to null
            if (requestAccessPolicyResource_accessPolicyResource_PortalIsNull)
            {
                requestAccessPolicyResource_accessPolicyResource_Portal = null;
            }
            if (requestAccessPolicyResource_accessPolicyResource_Portal != null)
            {
                request.AccessPolicyResource.Portal = requestAccessPolicyResource_accessPolicyResource_Portal;
                requestAccessPolicyResourceIsNull = false;
            }
            Amazon.IoTSiteWise.Model.ProjectResource requestAccessPolicyResource_accessPolicyResource_Project = null;
            
             // populate Project
            var requestAccessPolicyResource_accessPolicyResource_ProjectIsNull = true;
            requestAccessPolicyResource_accessPolicyResource_Project = new Amazon.IoTSiteWise.Model.ProjectResource();
            System.String requestAccessPolicyResource_accessPolicyResource_Project_project_Id = null;
            if (cmdletContext.Project_Id != null)
            {
                requestAccessPolicyResource_accessPolicyResource_Project_project_Id = cmdletContext.Project_Id;
            }
            if (requestAccessPolicyResource_accessPolicyResource_Project_project_Id != null)
            {
                requestAccessPolicyResource_accessPolicyResource_Project.Id = requestAccessPolicyResource_accessPolicyResource_Project_project_Id;
                requestAccessPolicyResource_accessPolicyResource_ProjectIsNull = false;
            }
             // determine if requestAccessPolicyResource_accessPolicyResource_Project should be set to null
            if (requestAccessPolicyResource_accessPolicyResource_ProjectIsNull)
            {
                requestAccessPolicyResource_accessPolicyResource_Project = null;
            }
            if (requestAccessPolicyResource_accessPolicyResource_Project != null)
            {
                request.AccessPolicyResource.Project = requestAccessPolicyResource_accessPolicyResource_Project;
                requestAccessPolicyResourceIsNull = false;
            }
             // determine if request.AccessPolicyResource should be set to null
            if (requestAccessPolicyResourceIsNull)
            {
                request.AccessPolicyResource = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
        
        private Amazon.IoTSiteWise.Model.UpdateAccessPolicyResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.UpdateAccessPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "UpdateAccessPolicy");
            try
            {
                #if DESKTOP
                return client.UpdateAccessPolicy(request);
                #elif CORECLR
                return client.UpdateAccessPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessPolicyId { get; set; }
            public System.String Group_Id { get; set; }
            public System.String IamRole_Arn { get; set; }
            public System.String IamUser_Arn { get; set; }
            public System.String User_Id { get; set; }
            public Amazon.IoTSiteWise.Permission AccessPolicyPermission { get; set; }
            public System.String Portal_Id { get; set; }
            public System.String Project_Id { get; set; }
            public System.String ClientToken { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdateAccessPolicyResponse, UpdateIOTSWAccessPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
