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
    /// Amazon.Proton.IAmazonProton.CreateEnvironment
    /// </summary>
    [Cmdlet("New", "PROEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.Environment")]
    [AWSCmdlet("Calls the AWS Proton CreateEnvironment API operation.", Operation = new[] {"CreateEnvironment"}, SelectReturnType = typeof(Amazon.Proton.Model.CreateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.Environment or Amazon.Proton.Model.CreateEnvironmentResponse",
        "This cmdlet returns an Amazon.Proton.Model.Environment object.",
        "The service call response (type Amazon.Proton.Model.CreateEnvironmentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPROEnvironmentCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
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
        /// infrastructure using CodeBuild-based provisioning on your behalf.</para><para>To use CodeBuild-based provisioning for the environment or for any service instance
        /// running in the environment, specify either the <code>environmentAccountConnectionId</code>
        /// or <code>codebuildRoleArn</code> parameter.</para>
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
        /// that a component can provision.</para><para>You must specify <code>componentRoleArn</code> to allow directly defined components
        /// to be associated with this environment.</para><para>For more information about components, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-components.html">Proton
        /// components</a> in the <i>Proton User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentRoleArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the environment that's being created and deployed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnvironmentAccountConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the environment account connection that you provide if you're provisioning
        /// your environment infrastructure resources to an environment account. For more information,
        /// see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-env-account-connections.html">Environment
        /// account connections</a> in the <i>Proton User guide</i>.</para><para>To use Amazon Web Services-managed provisioning for the environment, specify either
        /// the <code>environmentAccountConnectionId</code> or <code>protonServiceRoleArn</code>
        /// parameter and omit the <code>provisioningRepository</code> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentAccountConnectionId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the environment.</para>
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
        /// calls to other services on your behalf.</para><para>To use Amazon Web Services-managed provisioning for the environment, specify either
        /// the <code>environmentAccountConnectionId</code> or <code>protonServiceRoleArn</code>
        /// parameter and omit the <code>provisioningRepository</code> parameter.</para>
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
        /// <para>A YAML formatted string that provides inputs as defined in the environment template
        /// bundle schema file. For more information, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-environments.html">Environments</a>
        /// in the <i>Proton User Guide</i>.</para>
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
        public System.String Spec { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of metadata items that you can associate with the Proton environment.
        /// A tag is a key-value pair.</para><para>For more information, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/resources.html">Proton
        /// resources and tagging</a> in the <i>Proton User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Proton.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateMajorVersion
        /// <summary>
        /// <para>
        /// <para>The major version of the environment template.</para>
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
        public System.String TemplateMajorVersion { get; set; }
        #endregion
        
        #region Parameter TemplateMinorVersion
        /// <summary>
        /// <para>
        /// <para>The minor version of the environment template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateMinorVersion { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the environment template. For more information, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-templates.html">Environment
        /// Templates</a> in the <i>Proton User Guide</i>.</para>
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
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Environment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.CreateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.CreateEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Environment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PROEnvironment (CreateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.CreateEnvironmentResponse, NewPROEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CodebuildRoleArn = this.CodebuildRoleArn;
            context.ComponentRoleArn = this.ComponentRoleArn;
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
            #if MODULAR
            if (this.Spec == null && ParameterWasBound(nameof(this.Spec)))
            {
                WriteWarning("You are passing $null as a value for parameter Spec which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Proton.Model.Tag>(this.Tag);
            }
            context.TemplateMajorVersion = this.TemplateMajorVersion;
            #if MODULAR
            if (this.TemplateMajorVersion == null && ParameterWasBound(nameof(this.TemplateMajorVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateMajorVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateMinorVersion = this.TemplateMinorVersion;
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Proton.Model.CreateEnvironmentRequest();
            
            if (cmdletContext.CodebuildRoleArn != null)
            {
                request.CodebuildRoleArn = cmdletContext.CodebuildRoleArn;
            }
            if (cmdletContext.ComponentRoleArn != null)
            {
                request.ComponentRoleArn = cmdletContext.ComponentRoleArn;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemplateMajorVersion != null)
            {
                request.TemplateMajorVersion = cmdletContext.TemplateMajorVersion;
            }
            if (cmdletContext.TemplateMinorVersion != null)
            {
                request.TemplateMinorVersion = cmdletContext.TemplateMinorVersion;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
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
        
        private Amazon.Proton.Model.CreateEnvironmentResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.CreateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "CreateEnvironment");
            try
            {
                #if DESKTOP
                return client.CreateEnvironment(request);
                #elif CORECLR
                return client.CreateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String EnvironmentAccountConnectionId { get; set; }
            public System.String Name { get; set; }
            public System.String ProtonServiceRoleArn { get; set; }
            public System.String ProvisioningRepository_Branch { get; set; }
            public System.String ProvisioningRepository_Name { get; set; }
            public Amazon.Proton.RepositoryProvider ProvisioningRepository_Provider { get; set; }
            public System.String Spec { get; set; }
            public List<Amazon.Proton.Model.Tag> Tag { get; set; }
            public System.String TemplateMajorVersion { get; set; }
            public System.String TemplateMinorVersion { get; set; }
            public System.String TemplateName { get; set; }
            public System.Func<Amazon.Proton.Model.CreateEnvironmentResponse, NewPROEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Environment;
        }
        
    }
}
