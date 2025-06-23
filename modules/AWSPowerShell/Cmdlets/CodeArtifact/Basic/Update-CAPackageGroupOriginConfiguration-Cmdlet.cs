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
using Amazon.CodeArtifact;
using Amazon.CodeArtifact.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CA
{
    /// <summary>
    /// Updates the package origin configuration for a package group.
    /// 
    ///  
    /// <para>
    /// The package origin configuration determines how new versions of a package can be added
    /// to a repository. You can allow or block direct publishing of new package versions,
    /// or ingestion and retaining of new package versions from an external connection or
    /// upstream source. For more information about package group origin controls and configuration,
    /// see <a href="https://docs.aws.amazon.com/codeartifact/latest/ug/package-group-origin-controls.html">Package
    /// group origin controls</a> in the <i>CodeArtifact User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CAPackageGroupOriginConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationResponse")]
    [AWSCmdlet("Calls the AWS CodeArtifact UpdatePackageGroupOriginConfiguration API operation.", Operation = new[] {"UpdatePackageGroupOriginConfiguration"}, SelectReturnType = typeof(Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationResponse))]
    [AWSCmdletOutput("Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationResponse",
        "This cmdlet returns an Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateCAPackageGroupOriginConfigurationCmdlet : AmazonCodeArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddAllowedRepository
        /// <summary>
        /// <para>
        /// <para>The repository name and restrictions to add to the allowed repository list of the
        /// specified package group.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddAllowedRepositories")]
        public Amazon.CodeArtifact.Model.PackageGroupAllowedRepository[] AddAllowedRepository { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para> The name of the domain which contains the package group for which to update the origin
        /// configuration. </para>
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
        
        #region Parameter PackageGroup
        /// <summary>
        /// <para>
        /// <para> The pattern of the package group for which to update the origin configuration. </para>
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
        public System.String PackageGroup { get; set; }
        #endregion
        
        #region Parameter RemoveAllowedRepository
        /// <summary>
        /// <para>
        /// <para>The repository name and restrictions to remove from the allowed repository list of
        /// the specified package group.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveAllowedRepositories")]
        public Amazon.CodeArtifact.Model.PackageGroupAllowedRepository[] RemoveAllowedRepository { get; set; }
        #endregion
        
        #region Parameter Restriction
        /// <summary>
        /// <para>
        /// <para> The origin configuration settings that determine how package versions can enter repositories.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Restrictions")]
        public System.Collections.Hashtable Restriction { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PackageGroup), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CAPackageGroupOriginConfiguration (UpdatePackageGroupOriginConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationResponse, UpdateCAPackageGroupOriginConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddAllowedRepository != null)
            {
                context.AddAllowedRepository = new List<Amazon.CodeArtifact.Model.PackageGroupAllowedRepository>(this.AddAllowedRepository);
            }
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainOwner = this.DomainOwner;
            context.PackageGroup = this.PackageGroup;
            #if MODULAR
            if (this.PackageGroup == null && ParameterWasBound(nameof(this.PackageGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemoveAllowedRepository != null)
            {
                context.RemoveAllowedRepository = new List<Amazon.CodeArtifact.Model.PackageGroupAllowedRepository>(this.RemoveAllowedRepository);
            }
            if (this.Restriction != null)
            {
                context.Restriction = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Restriction.Keys)
                {
                    context.Restriction.Add((String)hashKey, (System.String)(this.Restriction[hashKey]));
                }
            }
            
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
            var request = new Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationRequest();
            
            if (cmdletContext.AddAllowedRepository != null)
            {
                request.AddAllowedRepositories = cmdletContext.AddAllowedRepository;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.DomainOwner != null)
            {
                request.DomainOwner = cmdletContext.DomainOwner;
            }
            if (cmdletContext.PackageGroup != null)
            {
                request.PackageGroup = cmdletContext.PackageGroup;
            }
            if (cmdletContext.RemoveAllowedRepository != null)
            {
                request.RemoveAllowedRepositories = cmdletContext.RemoveAllowedRepository;
            }
            if (cmdletContext.Restriction != null)
            {
                request.Restrictions = cmdletContext.Restriction;
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
        
        private Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationResponse CallAWSServiceOperation(IAmazonCodeArtifact client, Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeArtifact", "UpdatePackageGroupOriginConfiguration");
            try
            {
                return client.UpdatePackageGroupOriginConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CodeArtifact.Model.PackageGroupAllowedRepository> AddAllowedRepository { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainOwner { get; set; }
            public System.String PackageGroup { get; set; }
            public List<Amazon.CodeArtifact.Model.PackageGroupAllowedRepository> RemoveAllowedRepository { get; set; }
            public Dictionary<System.String, System.String> Restriction { get; set; }
            public System.Func<Amazon.CodeArtifact.Model.UpdatePackageGroupOriginConfigurationResponse, UpdateCAPackageGroupOriginConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
