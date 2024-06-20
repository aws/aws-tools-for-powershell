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
using Amazon.CodeArtifact;
using Amazon.CodeArtifact.Model;

namespace Amazon.PowerShell.Cmdlets.CA
{
    /// <summary>
    /// Sets the package origin configuration for a package.
    /// 
    ///  
    /// <para>
    /// The package origin configuration determines how new versions of a package can be added
    /// to a repository. You can allow or block direct publishing of new package versions,
    /// or ingestion and retaining of new package versions from an external connection or
    /// upstream source. For more information about package origin controls and configuration,
    /// see <a href="https://docs.aws.amazon.com/codeartifact/latest/ug/package-origin-controls.html">Editing
    /// package origin controls</a> in the <i>CodeArtifact User Guide</i>.
    /// </para><para><c>PutPackageOriginConfiguration</c> can be called on a package that doesn't yet
    /// exist in the repository. When called on a package that does not exist, a package is
    /// created in the repository with no versions and the requested restrictions are set
    /// on the package. This can be used to preemptively block ingesting or retaining any
    /// versions from external connections or upstream repositories, or to block publishing
    /// any versions of the package into the repository before connecting any package managers
    /// or publishers to the repository.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CAPackageOriginConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeArtifact.Model.PackageOriginConfiguration")]
    [AWSCmdlet("Calls the AWS CodeArtifact PutPackageOriginConfiguration API operation.", Operation = new[] {"PutPackageOriginConfiguration"}, SelectReturnType = typeof(Amazon.CodeArtifact.Model.PutPackageOriginConfigurationResponse))]
    [AWSCmdletOutput("Amazon.CodeArtifact.Model.PackageOriginConfiguration or Amazon.CodeArtifact.Model.PutPackageOriginConfigurationResponse",
        "This cmdlet returns an Amazon.CodeArtifact.Model.PackageOriginConfiguration object.",
        "The service call response (type Amazon.CodeArtifact.Model.PutPackageOriginConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCAPackageOriginConfigurationCmdlet : AmazonCodeArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain that contains the repository that contains the package.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainOwner
        /// <summary>
        /// <para>
        /// <para> The 12-digit account number of the Amazon Web Services account that owns the domain.
        /// It does not include dashes or spaces. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainOwner { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>A format that specifies the type of the package to be updated.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeArtifact.PackageFormat")]
        public Amazon.CodeArtifact.PackageFormat Format { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the package to be updated. The package component that specifies its
        /// namespace depends on its type. For example:</para><ul><li><para> The namespace of a Maven package version is its <c>groupId</c>. </para></li><li><para> The namespace of an npm or Swift package version is its <c>scope</c>. </para></li><li><para>The namespace of a generic package is its <c>namespace</c>.</para></li><li><para> Python, NuGet, Ruby, and Cargo package versions do not contain a corresponding component,
        /// package versions of those formats do not have a namespace. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Package
        /// <summary>
        /// <para>
        /// <para>The name of the package to be updated.</para>
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
        public System.String Package { get; set; }
        #endregion
        
        #region Parameter Restrictions_Publish
        /// <summary>
        /// <para>
        /// <para>The package origin configuration that determines if new versions of the package can
        /// be published directly to the repository.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeArtifact.AllowPublish")]
        public Amazon.CodeArtifact.AllowPublish Restrictions_Publish { get; set; }
        #endregion
        
        #region Parameter Repository
        /// <summary>
        /// <para>
        /// <para>The name of the repository that contains the package.</para>
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
        public System.String Repository { get; set; }
        #endregion
        
        #region Parameter Restrictions_Upstream
        /// <summary>
        /// <para>
        /// <para>The package origin configuration that determines if new versions of the package can
        /// be added to the repository from an external connection or upstream source.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeArtifact.AllowUpstream")]
        public Amazon.CodeArtifact.AllowUpstream Restrictions_Upstream { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OriginConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeArtifact.Model.PutPackageOriginConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CodeArtifact.Model.PutPackageOriginConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OriginConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Package), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CAPackageOriginConfiguration (PutPackageOriginConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeArtifact.Model.PutPackageOriginConfigurationResponse, WriteCAPackageOriginConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainOwner = this.DomainOwner;
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            context.Package = this.Package;
            #if MODULAR
            if (this.Package == null && ParameterWasBound(nameof(this.Package)))
            {
                WriteWarning("You are passing $null as a value for parameter Package which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Repository = this.Repository;
            #if MODULAR
            if (this.Repository == null && ParameterWasBound(nameof(this.Repository)))
            {
                WriteWarning("You are passing $null as a value for parameter Repository which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Restrictions_Publish = this.Restrictions_Publish;
            #if MODULAR
            if (this.Restrictions_Publish == null && ParameterWasBound(nameof(this.Restrictions_Publish)))
            {
                WriteWarning("You are passing $null as a value for parameter Restrictions_Publish which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Restrictions_Upstream = this.Restrictions_Upstream;
            #if MODULAR
            if (this.Restrictions_Upstream == null && ParameterWasBound(nameof(this.Restrictions_Upstream)))
            {
                WriteWarning("You are passing $null as a value for parameter Restrictions_Upstream which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeArtifact.Model.PutPackageOriginConfigurationRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.DomainOwner != null)
            {
                request.DomainOwner = cmdletContext.DomainOwner;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.Package != null)
            {
                request.Package = cmdletContext.Package;
            }
            if (cmdletContext.Repository != null)
            {
                request.Repository = cmdletContext.Repository;
            }
            
             // populate Restrictions
            var requestRestrictionsIsNull = true;
            request.Restrictions = new Amazon.CodeArtifact.Model.PackageOriginRestrictions();
            Amazon.CodeArtifact.AllowPublish requestRestrictions_restrictions_Publish = null;
            if (cmdletContext.Restrictions_Publish != null)
            {
                requestRestrictions_restrictions_Publish = cmdletContext.Restrictions_Publish;
            }
            if (requestRestrictions_restrictions_Publish != null)
            {
                request.Restrictions.Publish = requestRestrictions_restrictions_Publish;
                requestRestrictionsIsNull = false;
            }
            Amazon.CodeArtifact.AllowUpstream requestRestrictions_restrictions_Upstream = null;
            if (cmdletContext.Restrictions_Upstream != null)
            {
                requestRestrictions_restrictions_Upstream = cmdletContext.Restrictions_Upstream;
            }
            if (requestRestrictions_restrictions_Upstream != null)
            {
                request.Restrictions.Upstream = requestRestrictions_restrictions_Upstream;
                requestRestrictionsIsNull = false;
            }
             // determine if request.Restrictions should be set to null
            if (requestRestrictionsIsNull)
            {
                request.Restrictions = null;
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
        
        private Amazon.CodeArtifact.Model.PutPackageOriginConfigurationResponse CallAWSServiceOperation(IAmazonCodeArtifact client, Amazon.CodeArtifact.Model.PutPackageOriginConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeArtifact", "PutPackageOriginConfiguration");
            try
            {
                #if DESKTOP
                return client.PutPackageOriginConfiguration(request);
                #elif CORECLR
                return client.PutPackageOriginConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Domain { get; set; }
            public System.String DomainOwner { get; set; }
            public Amazon.CodeArtifact.PackageFormat Format { get; set; }
            public System.String Namespace { get; set; }
            public System.String Package { get; set; }
            public System.String Repository { get; set; }
            public Amazon.CodeArtifact.AllowPublish Restrictions_Publish { get; set; }
            public Amazon.CodeArtifact.AllowUpstream Restrictions_Upstream { get; set; }
            public System.Func<Amazon.CodeArtifact.Model.PutPackageOriginConfigurationResponse, WriteCAPackageOriginConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OriginConfiguration;
        }
        
    }
}
