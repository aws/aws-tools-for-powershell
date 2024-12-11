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
using Amazon.Proton;
using Amazon.Proton.Model;

namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// Update an environment.
    /// 
    ///  
    /// <para>
    /// If the environment is associated with an environment account connection, <i>don't</i>
    /// update or include the <c>protonServiceRoleArn</c> and <c>provisioningRepository</c>
    /// parameter to update or connect to an environment account connection.
    /// </para><para>
    /// You can only update to a new environment account connection if that connection was
    /// created in the same environment account that the current environment account connection
    /// was created in. The account connection must also be associated with the current environment.
    /// </para><para>
    /// If the environment <i>isn't</i> associated with an environment account connection,
    /// <i>don't</i> update or include the <c>environmentAccountConnectionId</c> parameter.
    /// You <i>can't</i> update or connect the environment to an environment account connection
    /// if it <i>isn't</i> already associated with an environment connection.
    /// </para><para>
    /// You can update either the <c>environmentAccountConnectionId</c> or <c>protonServiceRoleArn</c>
    /// parameter and value. You can’t update both.
    /// </para><para>
    /// If the environment was configured for Amazon Web Services-managed provisioning, omit
    /// the <c>provisioningRepository</c> parameter.
    /// </para><para>
    /// If the environment was configured for self-managed provisioning, specify the <c>provisioningRepository</c>
    /// parameter and omit the <c>protonServiceRoleArn</c> and <c>environmentAccountConnectionId</c>
    /// parameters.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-environments.html">Environments</a>
    /// and <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-works-prov-methods.html">Provisioning
    /// methods</a> in the <i>Proton User Guide</i>.
    /// </para><para>
    /// There are four modes for updating an environment. The <c>deploymentType</c> field
    /// defines the mode.
    /// </para><dl><dt /><dd><para><c>NONE</c></para><para>
    /// In this mode, a deployment <i>doesn't</i> occur. Only the requested metadata parameters
    /// are updated.
    /// </para></dd><dt /><dd><para><c>CURRENT_VERSION</c></para><para>
    /// In this mode, the environment is deployed and updated with the new spec that you provide.
    /// Only requested parameters are updated. <i>Don’t</i> include minor or major version
    /// parameters when you use this <c>deployment-type</c>.
    /// </para></dd><dt /><dd><para><c>MINOR_VERSION</c></para><para>
    /// In this mode, the environment is deployed and updated with the published, recommended
    /// (latest) minor version of the current major version in use, by default. You can also
    /// specify a different minor version of the current major version in use.
    /// </para></dd><dt /><dd><para><c>MAJOR_VERSION</c></para><para>
    /// In this mode, the environment is deployed and updated with the published, recommended
    /// (latest) major and minor version of the current template, by default. You can also
    /// specify a different major version that's higher than the major version in use and
    /// a minor version.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Update", "PROEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.Environment")]
    [AWSCmdlet("Calls the AWS Proton UpdateEnvironment API operation.", Operation = new[] {"UpdateEnvironment"}, SelectReturnType = typeof(Amazon.Proton.Model.UpdateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.Environment or Amazon.Proton.Model.UpdateEnvironmentResponse",
        "This cmdlet returns an Amazon.Proton.Model.Environment object.",
        "The service call response (type Amazon.Proton.Model.UpdateEnvironmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePROEnvironmentCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProvisioningRepository_Branch
        /// <summary>
        /// <para>
        /// <para>The repository branch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningRepository_Branch { get; set; }
        #endregion
        
        #region Parameter CodebuildRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role that allows Proton to provision
        /// infrastructure using CodeBuild-based provisioning on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CodebuildRoleArn { get; set; }
        #endregion
        
        #region Parameter ComponentRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role that Proton uses when provisioning
        /// directly defined components in this environment. It determines the scope of infrastructure
        /// that a component can provision.</para><para>The environment must have a <c>componentRoleArn</c> to allow directly defined components
        /// to be associated with the environment.</para><para>For more information about components, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-components.html">Proton
        /// components</a> in the <i>Proton User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentRoleArn { get; set; }
        #endregion
        
        #region Parameter DeploymentType
        /// <summary>
        /// <para>
        /// <para>There are four modes for updating an environment. The <c>deploymentType</c> field
        /// defines the mode.</para><dl><dt /><dd><para><c>NONE</c></para><para>In this mode, a deployment <i>doesn't</i> occur. Only the requested metadata parameters
        /// are updated.</para></dd><dt /><dd><para><c>CURRENT_VERSION</c></para><para>In this mode, the environment is deployed and updated with the new spec that you provide.
        /// Only requested parameters are updated. <i>Don’t</i> include major or minor version
        /// parameters when you use this <c>deployment-type</c>.</para></dd><dt /><dd><para><c>MINOR_VERSION</c></para><para>In this mode, the environment is deployed and updated with the published, recommended
        /// (latest) minor version of the current major version in use, by default. You can also
        /// specify a different minor version of the current major version in use.</para></dd><dt /><dd><para><c>MAJOR_VERSION</c></para><para>In this mode, the environment is deployed and updated with the published, recommended
        /// (latest) major and minor version of the current template, by default. You can also
        /// specify a different major version that is higher than the major version in use and
        /// a minor version (optional).</para></dd></dl>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Proton.DeploymentUpdateType")]
        public Amazon.Proton.DeploymentUpdateType DeploymentType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the environment update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnvironmentAccountConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the environment account connection.</para><para>You can only update to a new environment account connection if it was created in the
        /// same environment account that the current environment account connection was created
        /// in and is associated with the current environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentAccountConnectionId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the environment to update.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProvisioningRepository_Name
        /// <summary>
        /// <para>
        /// <para>The repository name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningRepository_Name { get; set; }
        #endregion
        
        #region Parameter ProtonServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Proton service role that allows Proton to make
        /// API calls to other services your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProtonServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter ProvisioningRepository_Provider
        /// <summary>
        /// <para>
        /// <para>The repository provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Proton.RepositoryProvider")]
        public Amazon.Proton.RepositoryProvider ProvisioningRepository_Provider { get; set; }
        #endregion
        
        #region Parameter Spec
        /// <summary>
        /// <para>
        /// <para>The formatted specification that defines the update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec { get; set; }
        #endregion
        
        #region Parameter TemplateMajorVersion
        /// <summary>
        /// <para>
        /// <para>The major version of the environment to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateMajorVersion { get; set; }
        #endregion
        
        #region Parameter TemplateMinorVersion
        /// <summary>
        /// <para>
        /// <para>The minor version of the environment to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateMinorVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Environment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.UpdateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.UpdateEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Environment";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROEnvironment (UpdateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.UpdateEnvironmentResponse, UpdatePROEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CodebuildRoleArn = this.CodebuildRoleArn;
            context.ComponentRoleArn = this.ComponentRoleArn;
            context.DeploymentType = this.DeploymentType;
            #if MODULAR
            if (this.DeploymentType == null && ParameterWasBound(nameof(this.DeploymentType)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.EnvironmentAccountConnectionId = this.EnvironmentAccountConnectionId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProtonServiceRoleArn = this.ProtonServiceRoleArn;
            context.ProvisioningRepository_Branch = this.ProvisioningRepository_Branch;
            context.ProvisioningRepository_Name = this.ProvisioningRepository_Name;
            context.ProvisioningRepository_Provider = this.ProvisioningRepository_Provider;
            context.Spec = this.Spec;
            context.TemplateMajorVersion = this.TemplateMajorVersion;
            context.TemplateMinorVersion = this.TemplateMinorVersion;
            
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
            var request = new Amazon.Proton.Model.UpdateEnvironmentRequest();
            
            if (cmdletContext.CodebuildRoleArn != null)
            {
                request.CodebuildRoleArn = cmdletContext.CodebuildRoleArn;
            }
            if (cmdletContext.ComponentRoleArn != null)
            {
                request.ComponentRoleArn = cmdletContext.ComponentRoleArn;
            }
            if (cmdletContext.DeploymentType != null)
            {
                request.DeploymentType = cmdletContext.DeploymentType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentAccountConnectionId != null)
            {
                request.EnvironmentAccountConnectionId = cmdletContext.EnvironmentAccountConnectionId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProtonServiceRoleArn != null)
            {
                request.ProtonServiceRoleArn = cmdletContext.ProtonServiceRoleArn;
            }
            
             // populate ProvisioningRepository
            var requestProvisioningRepositoryIsNull = true;
            request.ProvisioningRepository = new Amazon.Proton.Model.RepositoryBranchInput();
            System.String requestProvisioningRepository_provisioningRepository_Branch = null;
            if (cmdletContext.ProvisioningRepository_Branch != null)
            {
                requestProvisioningRepository_provisioningRepository_Branch = cmdletContext.ProvisioningRepository_Branch;
            }
            if (requestProvisioningRepository_provisioningRepository_Branch != null)
            {
                request.ProvisioningRepository.Branch = requestProvisioningRepository_provisioningRepository_Branch;
                requestProvisioningRepositoryIsNull = false;
            }
            System.String requestProvisioningRepository_provisioningRepository_Name = null;
            if (cmdletContext.ProvisioningRepository_Name != null)
            {
                requestProvisioningRepository_provisioningRepository_Name = cmdletContext.ProvisioningRepository_Name;
            }
            if (requestProvisioningRepository_provisioningRepository_Name != null)
            {
                request.ProvisioningRepository.Name = requestProvisioningRepository_provisioningRepository_Name;
                requestProvisioningRepositoryIsNull = false;
            }
            Amazon.Proton.RepositoryProvider requestProvisioningRepository_provisioningRepository_Provider = null;
            if (cmdletContext.ProvisioningRepository_Provider != null)
            {
                requestProvisioningRepository_provisioningRepository_Provider = cmdletContext.ProvisioningRepository_Provider;
            }
            if (requestProvisioningRepository_provisioningRepository_Provider != null)
            {
                request.ProvisioningRepository.Provider = requestProvisioningRepository_provisioningRepository_Provider;
                requestProvisioningRepositoryIsNull = false;
            }
             // determine if request.ProvisioningRepository should be set to null
            if (requestProvisioningRepositoryIsNull)
            {
                request.ProvisioningRepository = null;
            }
            if (cmdletContext.Spec != null)
            {
                request.Spec = cmdletContext.Spec;
            }
            if (cmdletContext.TemplateMajorVersion != null)
            {
                request.TemplateMajorVersion = cmdletContext.TemplateMajorVersion;
            }
            if (cmdletContext.TemplateMinorVersion != null)
            {
                request.TemplateMinorVersion = cmdletContext.TemplateMinorVersion;
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
        
        private Amazon.Proton.Model.UpdateEnvironmentResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.UpdateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "UpdateEnvironment");
            try
            {
                #if DESKTOP
                return client.UpdateEnvironment(request);
                #elif CORECLR
                return client.UpdateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.String CodebuildRoleArn { get; set; }
            public System.String ComponentRoleArn { get; set; }
            public Amazon.Proton.DeploymentUpdateType DeploymentType { get; set; }
            public System.String Description { get; set; }
            public System.String EnvironmentAccountConnectionId { get; set; }
            public System.String Name { get; set; }
            public System.String ProtonServiceRoleArn { get; set; }
            public System.String ProvisioningRepository_Branch { get; set; }
            public System.String ProvisioningRepository_Name { get; set; }
            public Amazon.Proton.RepositoryProvider ProvisioningRepository_Provider { get; set; }
            public System.String Spec { get; set; }
            public System.String TemplateMajorVersion { get; set; }
            public System.String TemplateMinorVersion { get; set; }
            public System.Func<Amazon.Proton.Model.UpdateEnvironmentResponse, UpdatePROEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Environment;
        }
        
    }
}
