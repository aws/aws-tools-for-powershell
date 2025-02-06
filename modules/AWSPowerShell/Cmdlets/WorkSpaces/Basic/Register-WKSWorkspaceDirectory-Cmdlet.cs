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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Registers the specified directory. This operation is asynchronous and returns before
    /// the WorkSpace directory is registered. If this is the first time you are registering
    /// a directory, you will need to create the workspaces_DefaultRole role before you can
    /// register a directory. For more information, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/workspaces-access-control.html#create-default-role">
    /// Creating the workspaces_DefaultRole Role</a>.
    /// </summary>
    [Cmdlet("Register", "WKSWorkspaceDirectory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryResponse")]
    [AWSCmdlet("Calls the Amazon WorkSpaces RegisterWorkspaceDirectory API operation.", Operation = new[] {"RegisterWorkspaceDirectory"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryResponse))]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryResponse",
        "This cmdlet returns an Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryResponse object containing multiple properties."
    )]
    public partial class RegisterWKSWorkspaceDirectoryCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MicrosoftEntraConfig_ApplicationConfigSecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the application config.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MicrosoftEntraConfig_ApplicationConfigSecretArn { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory. You cannot register a directory if it does not have
        /// a status of Active. If the directory does not have a status of Active, you will receive
        /// an InvalidResourceStateException error. If you have already registered the maximum
        /// number of directories that you can register with Amazon WorkSpaces, you will receive
        /// a ResourceLimitExceededException error. Deregister directories that you are not using
        /// for WorkSpaces, and try again.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter ActiveDirectoryConfig_DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActiveDirectoryConfig_DomainName { get; set; }
        #endregion
        
        #region Parameter EnableSelfService
        /// <summary>
        /// <para>
        /// <para>Indicates whether self-service capabilities are enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableSelfService { get; set; }
        #endregion
        
        #region Parameter EnableWorkDoc
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon WorkDocs is enabled or disabled. If you have enabled this
        /// parameter and WorkDocs is not available in the Region, you will receive an OperationNotSupportedException
        /// error. Set <c>EnableWorkDocs</c> to disabled, and try again.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableWorkDocs")]
        public System.Boolean? EnableWorkDoc { get; set; }
        #endregion
        
        #region Parameter IdcInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the identity center instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdcInstanceArn { get; set; }
        #endregion
        
        #region Parameter ActiveDirectoryConfig_ServiceAccountSecretArn
        /// <summary>
        /// <para>
        /// <para>Indicates the secret ARN on the service account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActiveDirectoryConfig_ServiceAccountSecretArn { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets for your virtual private cloud (VPC). Make sure that
        /// the subnets are in supported Availability Zones. The subnets must also be in separate
        /// Availability Zones. If these conditions are not met, you will receive an OperationNotSupportedException
        /// error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WorkSpaces.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Tenancy
        /// <summary>
        /// <para>
        /// <para>Indicates whether your WorkSpace directory is dedicated or shared. To use Bring Your
        /// Own License (BYOL) images, this value must be set to <c>DEDICATED</c> and your Amazon
        /// Web Services account must be enabled for BYOL. If your account has not been enabled
        /// for BYOL, you will receive an InvalidParameterValuesException error. For more information
        /// about BYOL images, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/byol-windows-images.html">Bring
        /// Your Own Windows Desktop Images</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.Tenancy")]
        public Amazon.WorkSpaces.Tenancy Tenancy { get; set; }
        #endregion
        
        #region Parameter MicrosoftEntraConfig_TenantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the tenant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MicrosoftEntraConfig_TenantId { get; set; }
        #endregion
        
        #region Parameter UserIdentityType
        /// <summary>
        /// <para>
        /// <para>The type of identity management the user is using.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.UserIdentityType")]
        public Amazon.WorkSpaces.UserIdentityType UserIdentityType { get; set; }
        #endregion
        
        #region Parameter WorkspaceDirectoryDescription
        /// <summary>
        /// <para>
        /// <para>Description of the directory to register.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceDirectoryDescription { get; set; }
        #endregion
        
        #region Parameter WorkspaceDirectoryName
        /// <summary>
        /// <para>
        /// <para>The name of the directory to register.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceDirectoryName { get; set; }
        #endregion
        
        #region Parameter WorkspaceType
        /// <summary>
        /// <para>
        /// <para>Indicates whether the directory's WorkSpace type is personal or pools.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.WorkspaceType")]
        public Amazon.WorkSpaces.WorkspaceType WorkspaceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-WKSWorkspaceDirectory (RegisterWorkspaceDirectory)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryResponse, RegisterWKSWorkspaceDirectoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActiveDirectoryConfig_DomainName = this.ActiveDirectoryConfig_DomainName;
            context.ActiveDirectoryConfig_ServiceAccountSecretArn = this.ActiveDirectoryConfig_ServiceAccountSecretArn;
            context.DirectoryId = this.DirectoryId;
            context.EnableSelfService = this.EnableSelfService;
            context.EnableWorkDoc = this.EnableWorkDoc;
            context.IdcInstanceArn = this.IdcInstanceArn;
            context.MicrosoftEntraConfig_ApplicationConfigSecretArn = this.MicrosoftEntraConfig_ApplicationConfigSecretArn;
            context.MicrosoftEntraConfig_TenantId = this.MicrosoftEntraConfig_TenantId;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WorkSpaces.Model.Tag>(this.Tag);
            }
            context.Tenancy = this.Tenancy;
            context.UserIdentityType = this.UserIdentityType;
            context.WorkspaceDirectoryDescription = this.WorkspaceDirectoryDescription;
            context.WorkspaceDirectoryName = this.WorkspaceDirectoryName;
            context.WorkspaceType = this.WorkspaceType;
            
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
            var request = new Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryRequest();
            
            
             // populate ActiveDirectoryConfig
            var requestActiveDirectoryConfigIsNull = true;
            request.ActiveDirectoryConfig = new Amazon.WorkSpaces.Model.ActiveDirectoryConfig();
            System.String requestActiveDirectoryConfig_activeDirectoryConfig_DomainName = null;
            if (cmdletContext.ActiveDirectoryConfig_DomainName != null)
            {
                requestActiveDirectoryConfig_activeDirectoryConfig_DomainName = cmdletContext.ActiveDirectoryConfig_DomainName;
            }
            if (requestActiveDirectoryConfig_activeDirectoryConfig_DomainName != null)
            {
                request.ActiveDirectoryConfig.DomainName = requestActiveDirectoryConfig_activeDirectoryConfig_DomainName;
                requestActiveDirectoryConfigIsNull = false;
            }
            System.String requestActiveDirectoryConfig_activeDirectoryConfig_ServiceAccountSecretArn = null;
            if (cmdletContext.ActiveDirectoryConfig_ServiceAccountSecretArn != null)
            {
                requestActiveDirectoryConfig_activeDirectoryConfig_ServiceAccountSecretArn = cmdletContext.ActiveDirectoryConfig_ServiceAccountSecretArn;
            }
            if (requestActiveDirectoryConfig_activeDirectoryConfig_ServiceAccountSecretArn != null)
            {
                request.ActiveDirectoryConfig.ServiceAccountSecretArn = requestActiveDirectoryConfig_activeDirectoryConfig_ServiceAccountSecretArn;
                requestActiveDirectoryConfigIsNull = false;
            }
             // determine if request.ActiveDirectoryConfig should be set to null
            if (requestActiveDirectoryConfigIsNull)
            {
                request.ActiveDirectoryConfig = null;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.EnableSelfService != null)
            {
                request.EnableSelfService = cmdletContext.EnableSelfService.Value;
            }
            if (cmdletContext.EnableWorkDoc != null)
            {
                request.EnableWorkDocs = cmdletContext.EnableWorkDoc.Value;
            }
            if (cmdletContext.IdcInstanceArn != null)
            {
                request.IdcInstanceArn = cmdletContext.IdcInstanceArn;
            }
            
             // populate MicrosoftEntraConfig
            var requestMicrosoftEntraConfigIsNull = true;
            request.MicrosoftEntraConfig = new Amazon.WorkSpaces.Model.MicrosoftEntraConfig();
            System.String requestMicrosoftEntraConfig_microsoftEntraConfig_ApplicationConfigSecretArn = null;
            if (cmdletContext.MicrosoftEntraConfig_ApplicationConfigSecretArn != null)
            {
                requestMicrosoftEntraConfig_microsoftEntraConfig_ApplicationConfigSecretArn = cmdletContext.MicrosoftEntraConfig_ApplicationConfigSecretArn;
            }
            if (requestMicrosoftEntraConfig_microsoftEntraConfig_ApplicationConfigSecretArn != null)
            {
                request.MicrosoftEntraConfig.ApplicationConfigSecretArn = requestMicrosoftEntraConfig_microsoftEntraConfig_ApplicationConfigSecretArn;
                requestMicrosoftEntraConfigIsNull = false;
            }
            System.String requestMicrosoftEntraConfig_microsoftEntraConfig_TenantId = null;
            if (cmdletContext.MicrosoftEntraConfig_TenantId != null)
            {
                requestMicrosoftEntraConfig_microsoftEntraConfig_TenantId = cmdletContext.MicrosoftEntraConfig_TenantId;
            }
            if (requestMicrosoftEntraConfig_microsoftEntraConfig_TenantId != null)
            {
                request.MicrosoftEntraConfig.TenantId = requestMicrosoftEntraConfig_microsoftEntraConfig_TenantId;
                requestMicrosoftEntraConfigIsNull = false;
            }
             // determine if request.MicrosoftEntraConfig should be set to null
            if (requestMicrosoftEntraConfigIsNull)
            {
                request.MicrosoftEntraConfig = null;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Tenancy != null)
            {
                request.Tenancy = cmdletContext.Tenancy;
            }
            if (cmdletContext.UserIdentityType != null)
            {
                request.UserIdentityType = cmdletContext.UserIdentityType;
            }
            if (cmdletContext.WorkspaceDirectoryDescription != null)
            {
                request.WorkspaceDirectoryDescription = cmdletContext.WorkspaceDirectoryDescription;
            }
            if (cmdletContext.WorkspaceDirectoryName != null)
            {
                request.WorkspaceDirectoryName = cmdletContext.WorkspaceDirectoryName;
            }
            if (cmdletContext.WorkspaceType != null)
            {
                request.WorkspaceType = cmdletContext.WorkspaceType;
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
        
        private Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "RegisterWorkspaceDirectory");
            try
            {
                #if DESKTOP
                return client.RegisterWorkspaceDirectory(request);
                #elif CORECLR
                return client.RegisterWorkspaceDirectoryAsync(request).GetAwaiter().GetResult();
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
            public System.String ActiveDirectoryConfig_DomainName { get; set; }
            public System.String ActiveDirectoryConfig_ServiceAccountSecretArn { get; set; }
            public System.String DirectoryId { get; set; }
            public System.Boolean? EnableSelfService { get; set; }
            public System.Boolean? EnableWorkDoc { get; set; }
            public System.String IdcInstanceArn { get; set; }
            public System.String MicrosoftEntraConfig_ApplicationConfigSecretArn { get; set; }
            public System.String MicrosoftEntraConfig_TenantId { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.WorkSpaces.Model.Tag> Tag { get; set; }
            public Amazon.WorkSpaces.Tenancy Tenancy { get; set; }
            public Amazon.WorkSpaces.UserIdentityType UserIdentityType { get; set; }
            public System.String WorkspaceDirectoryDescription { get; set; }
            public System.String WorkspaceDirectoryName { get; set; }
            public Amazon.WorkSpaces.WorkspaceType WorkspaceType { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.RegisterWorkspaceDirectoryResponse, RegisterWKSWorkspaceDirectoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
