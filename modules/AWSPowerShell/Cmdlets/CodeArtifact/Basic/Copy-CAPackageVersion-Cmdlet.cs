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
using Amazon.CodeArtifact;
using Amazon.CodeArtifact.Model;

namespace Amazon.PowerShell.Cmdlets.CA
{
    /// <summary>
    /// Copies package versions from one repository to another repository in the same domain.
    /// 
    /// 
    ///  <note><para>
    ///  You must specify <c>versions</c> or <c>versionRevisions</c>. You cannot specify both.
    /// 
    /// </para></note>
    /// </summary>
    [Cmdlet("Copy", "CAPackageVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeArtifact.Model.CopyPackageVersionsResponse")]
    [AWSCmdlet("Calls the AWS CodeArtifact CopyPackageVersions API operation.", Operation = new[] {"CopyPackageVersions"}, SelectReturnType = typeof(Amazon.CodeArtifact.Model.CopyPackageVersionsResponse))]
    [AWSCmdletOutput("Amazon.CodeArtifact.Model.CopyPackageVersionsResponse",
        "This cmdlet returns an Amazon.CodeArtifact.Model.CopyPackageVersionsResponse object containing multiple properties."
    )]
    public partial class CopyCAPackageVersionCmdlet : AmazonCodeArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowOverwrite
        /// <summary>
        /// <para>
        /// <para> Set to true to overwrite a package version that already exists in the destination
        /// repository. If set to false and the package version already exists in the destination
        /// repository, the package version is returned in the <c>failedVersions</c> field of
        /// the response with an <c>ALREADY_EXISTS</c> error code. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowOverwrite { get; set; }
        #endregion
        
        #region Parameter DestinationRepository
        /// <summary>
        /// <para>
        /// <para> The name of the repository into which package versions are copied. </para>
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
        public System.String DestinationRepository { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para> The name of the domain that contains the source and destination repositories. </para>
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
        /// <para> The format of the package versions to be copied. </para>
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
        
        #region Parameter IncludeFromUpstream
        /// <summary>
        /// <para>
        /// <para> Set to true to copy packages from repositories that are upstream from the source
        /// repository to the destination repository. The default setting is false. For more information,
        /// see <a href="https://docs.aws.amazon.com/codeartifact/latest/ug/repos-upstream.html">Working
        /// with upstream repositories</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeFromUpstream { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the package versions to be copied. The package component that specifies
        /// its namespace depends on its type. For example:</para><note><para>The namespace is required when copying package versions of the following formats:</para><ul><li><para>Maven</para></li><li><para>Swift</para></li><li><para>generic</para></li></ul></note><ul><li><para> The namespace of a Maven package version is its <c>groupId</c>. </para></li><li><para> The namespace of an npm or Swift package version is its <c>scope</c>. </para></li><li><para>The namespace of a generic package is its <c>namespace</c>.</para></li><li><para> Python, NuGet, Ruby, and Cargo package versions do not contain a corresponding component,
        /// package versions of those formats do not have a namespace. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Package
        /// <summary>
        /// <para>
        /// <para> The name of the package that contains the versions to be copied. </para>
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
        
        #region Parameter SourceRepository
        /// <summary>
        /// <para>
        /// <para> The name of the repository that contains the package versions to be copied. </para>
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
        public System.String SourceRepository { get; set; }
        #endregion
        
        #region Parameter VersionRevision
        /// <summary>
        /// <para>
        /// <para> A list of key-value pairs. The keys are package versions and the values are package
        /// version revisions. A <c>CopyPackageVersion</c> operation succeeds if the specified
        /// versions in the source repository match the specified package version revision. </para><note><para> You must specify <c>versions</c> or <c>versionRevisions</c>. You cannot specify both.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VersionRevisions")]
        public System.Collections.Hashtable VersionRevision { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para> The versions of the package to be copied. </para><note><para> You must specify <c>versions</c> or <c>versionRevisions</c>. You cannot specify both.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Versions")]
        public System.String[] Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeArtifact.Model.CopyPackageVersionsResponse).
        /// Specifying the name of a property of type Amazon.CodeArtifact.Model.CopyPackageVersionsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Package), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-CAPackageVersion (CopyPackageVersions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeArtifact.Model.CopyPackageVersionsResponse, CopyCAPackageVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowOverwrite = this.AllowOverwrite;
            context.DestinationRepository = this.DestinationRepository;
            #if MODULAR
            if (this.DestinationRepository == null && ParameterWasBound(nameof(this.DestinationRepository)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationRepository which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.IncludeFromUpstream = this.IncludeFromUpstream;
            context.Namespace = this.Namespace;
            context.Package = this.Package;
            #if MODULAR
            if (this.Package == null && ParameterWasBound(nameof(this.Package)))
            {
                WriteWarning("You are passing $null as a value for parameter Package which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceRepository = this.SourceRepository;
            #if MODULAR
            if (this.SourceRepository == null && ParameterWasBound(nameof(this.SourceRepository)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceRepository which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VersionRevision != null)
            {
                context.VersionRevision = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.VersionRevision.Keys)
                {
                    context.VersionRevision.Add((String)hashKey, (System.String)(this.VersionRevision[hashKey]));
                }
            }
            if (this.Version != null)
            {
                context.Version = new List<System.String>(this.Version);
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
            var request = new Amazon.CodeArtifact.Model.CopyPackageVersionsRequest();
            
            if (cmdletContext.AllowOverwrite != null)
            {
                request.AllowOverwrite = cmdletContext.AllowOverwrite.Value;
            }
            if (cmdletContext.DestinationRepository != null)
            {
                request.DestinationRepository = cmdletContext.DestinationRepository;
            }
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
            if (cmdletContext.IncludeFromUpstream != null)
            {
                request.IncludeFromUpstream = cmdletContext.IncludeFromUpstream.Value;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.Package != null)
            {
                request.Package = cmdletContext.Package;
            }
            if (cmdletContext.SourceRepository != null)
            {
                request.SourceRepository = cmdletContext.SourceRepository;
            }
            if (cmdletContext.VersionRevision != null)
            {
                request.VersionRevisions = cmdletContext.VersionRevision;
            }
            if (cmdletContext.Version != null)
            {
                request.Versions = cmdletContext.Version;
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
        
        private Amazon.CodeArtifact.Model.CopyPackageVersionsResponse CallAWSServiceOperation(IAmazonCodeArtifact client, Amazon.CodeArtifact.Model.CopyPackageVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeArtifact", "CopyPackageVersions");
            try
            {
                #if DESKTOP
                return client.CopyPackageVersions(request);
                #elif CORECLR
                return client.CopyPackageVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowOverwrite { get; set; }
            public System.String DestinationRepository { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainOwner { get; set; }
            public Amazon.CodeArtifact.PackageFormat Format { get; set; }
            public System.Boolean? IncludeFromUpstream { get; set; }
            public System.String Namespace { get; set; }
            public System.String Package { get; set; }
            public System.String SourceRepository { get; set; }
            public Dictionary<System.String, System.String> VersionRevision { get; set; }
            public List<System.String> Version { get; set; }
            public System.Func<Amazon.CodeArtifact.Model.CopyPackageVersionsResponse, CopyCAPackageVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
