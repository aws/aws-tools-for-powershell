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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Creates a new workflow version for the workflow that you specify with the <c>workflowId</c>
    /// parameter.
    /// 
    ///  
    /// <para>
    /// When you create a new version of a workflow, you need to specify the configuration
    /// for the new version. It doesn't inherit any configuration values from the workflow.
    /// </para><para>
    /// Provide a version name that is unique for this workflow. You cannot change the name
    /// after HealthOmics creates the version.
    /// </para><note><para>
    /// Don’t include any personally identifiable information (PII) in the version name. Version
    /// names appear in the workflow version ARN.
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/omics/latest/dev/workflow-versions.html">Workflow
    /// versioning in Amazon Web Services HealthOmics</a> in the <i>Amazon Web Services HealthOmics
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OMICSWorkflowVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.CreateWorkflowVersionResponse")]
    [AWSCmdlet("Calls the Amazon Omics CreateWorkflowVersion API operation.", Operation = new[] {"CreateWorkflowVersion"}, SelectReturnType = typeof(Amazon.Omics.Model.CreateWorkflowVersionResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.CreateWorkflowVersionResponse",
        "This cmdlet returns an Amazon.Omics.Model.CreateWorkflowVersionResponse object containing multiple properties."
    )]
    public partial class NewOMICSWorkflowVersionCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Accelerator
        /// <summary>
        /// <para>
        /// <para>The computational accelerator for this workflow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Accelerators")]
        [AWSConstantClassSource("Amazon.Omics.Accelerators")]
        public Amazon.Omics.Accelerators Accelerator { get; set; }
        #endregion
        
        #region Parameter DefinitionRepository_ConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the connection to the source code repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefinitionRepository_ConnectionArn { get; set; }
        #endregion
        
        #region Parameter DefinitionUri
        /// <summary>
        /// <para>
        /// <para>The URI specifies the location of the workflow definition for this workflow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefinitionUri { get; set; }
        #endregion
        
        #region Parameter DefinitionZip
        /// <summary>
        /// <para>
        /// <para>A zip archive containing the workflow definition for this workflow version.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DefinitionZip { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for this workflow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The workflow engine for this workflow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.WorkflowEngine")]
        public Amazon.Omics.WorkflowEngine Engine { get; set; }
        #endregion
        
        #region Parameter DefinitionRepository_ExcludeFilePattern
        /// <summary>
        /// <para>
        /// <para>A list of file patterns to exclude when retrieving the workflow definition from the
        /// repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefinitionRepository_ExcludeFilePatterns")]
        public System.String[] DefinitionRepository_ExcludeFilePattern { get; set; }
        #endregion
        
        #region Parameter DefinitionRepository_FullRepositoryId
        /// <summary>
        /// <para>
        /// <para>The full repository identifier, including the repository owner and name. For example,
        /// 'repository-owner/repository-name'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefinitionRepository_FullRepositoryId { get; set; }
        #endregion
        
        #region Parameter Main
        /// <summary>
        /// <para>
        /// <para>The path of the main definition file for this workflow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Main { get; set; }
        #endregion
        
        #region Parameter ParameterTemplate
        /// <summary>
        /// <para>
        /// <para>The parameter template defines the input parameters for runs that use this workflow
        /// version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ParameterTemplate { get; set; }
        #endregion
        
        #region Parameter ParameterTemplatePath
        /// <summary>
        /// <para>
        /// <para>The path to the workflow version parameter template JSON file within the repository.
        /// This file defines the input parameters for runs that use this workflow version. If
        /// not specified, the workflow version will be created without a parameter template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParameterTemplatePath { get; set; }
        #endregion
        
        #region Parameter ReadmeMarkdown
        /// <summary>
        /// <para>
        /// <para>The markdown content for the workflow version's README file. This provides documentation
        /// and usage information for users of this specific workflow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmeMarkdown { get; set; }
        #endregion
        
        #region Parameter ReadmePath
        /// <summary>
        /// <para>
        /// <para>The path to the workflow version README markdown file within the repository. This
        /// file provides documentation and usage information for the workflow. If not specified,
        /// the <c>README.md</c> file from the root directory of the repository will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmePath { get; set; }
        #endregion
        
        #region Parameter ReadmeUri
        /// <summary>
        /// <para>
        /// <para>The S3 URI of the README file for the workflow version. This file provides documentation
        /// and usage information for the workflow version. Requirements include:</para><ul><li><para>The S3 URI must begin with <c>s3://USER-OWNED-BUCKET/</c></para></li><li><para>The requester must have access to the S3 bucket and object.</para></li><li><para>The max README content length is 500 KiB.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmeUri { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// <para>To ensure that requests don't run multiple times, specify a unique ID for each request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>The default static storage capacity (in gibibytes) for runs that use this workflow
        /// or workflow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>The default storage type for runs that use this workflow. STATIC storage allocates
        /// a fixed amount of storage. DYNAMIC storage dynamically scales the storage up or down,
        /// based on file system utilization. For more information about static and dynamic storage,
        /// see <a href="https://docs.aws.amazon.com/omics/latest/dev/Using-workflows.html">Running
        /// workflows</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.StorageType")]
        public Amazon.Omics.StorageType StorageType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional tags to associate with this workflow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter SourceReference_Type
        /// <summary>
        /// <para>
        /// <para>The type of source reference, such as branch, tag, or commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefinitionRepository_SourceReference_Type")]
        [AWSConstantClassSource("Amazon.Omics.SourceReferenceType")]
        public Amazon.Omics.SourceReferenceType SourceReference_Type { get; set; }
        #endregion
        
        #region Parameter SourceReference_Value
        /// <summary>
        /// <para>
        /// <para>The value of the source reference, such as the branch name, tag name, or commit ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefinitionRepository_SourceReference_Value")]
        public System.String SourceReference_Value { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para>A name for the workflow version. Provide a version name that is unique for this workflow.
        /// You cannot change the name after HealthOmics creates the version. </para><para>The version name must start with a letter or number and it can include upper-case
        /// and lower-case letters, numbers, hyphens, periods and underscores. The maximum length
        /// is 64 characters. You can use a simple naming scheme, such as version1, version2,
        /// version3. You can also match your workflow versions with your own internal versioning
        /// conventions, such as 2.7.0, 2.7.1, 2.7.2.</para>
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
        public System.String VersionName { get; set; }
        #endregion
        
        #region Parameter WorkflowBucketOwnerId
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services Id of the owner of the S3 bucket that contains the workflow definition.
        /// You need to specify this parameter if your account is not the bucket owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkflowBucketOwnerId { get; set; }
        #endregion
        
        #region Parameter WorkflowId
        /// <summary>
        /// <para>
        /// <para>The ID of the workflow where you are creating the new version.</para>
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
        public System.String WorkflowId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CreateWorkflowVersionResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CreateWorkflowVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkflowId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkflowId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkflowId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VersionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OMICSWorkflowVersion (CreateWorkflowVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CreateWorkflowVersionResponse, NewOMICSWorkflowVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkflowId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Accelerator = this.Accelerator;
            context.DefinitionRepository_ConnectionArn = this.DefinitionRepository_ConnectionArn;
            if (this.DefinitionRepository_ExcludeFilePattern != null)
            {
                context.DefinitionRepository_ExcludeFilePattern = new List<System.String>(this.DefinitionRepository_ExcludeFilePattern);
            }
            context.DefinitionRepository_FullRepositoryId = this.DefinitionRepository_FullRepositoryId;
            context.SourceReference_Type = this.SourceReference_Type;
            context.SourceReference_Value = this.SourceReference_Value;
            context.DefinitionUri = this.DefinitionUri;
            context.DefinitionZip = this.DefinitionZip;
            context.Description = this.Description;
            context.Engine = this.Engine;
            context.Main = this.Main;
            if (this.ParameterTemplate != null)
            {
                context.ParameterTemplate = new Dictionary<System.String, Amazon.Omics.Model.WorkflowParameter>(StringComparer.Ordinal);
                foreach (var hashKey in this.ParameterTemplate.Keys)
                {
                    context.ParameterTemplate.Add((String)hashKey, (Amazon.Omics.Model.WorkflowParameter)(this.ParameterTemplate[hashKey]));
                }
            }
            context.ParameterTemplatePath = this.ParameterTemplatePath;
            context.ReadmeMarkdown = this.ReadmeMarkdown;
            context.ReadmePath = this.ReadmePath;
            context.ReadmeUri = this.ReadmeUri;
            context.RequestId = this.RequestId;
            context.StorageCapacity = this.StorageCapacity;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.VersionName = this.VersionName;
            #if MODULAR
            if (this.VersionName == null && ParameterWasBound(nameof(this.VersionName)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowBucketOwnerId = this.WorkflowBucketOwnerId;
            context.WorkflowId = this.WorkflowId;
            #if MODULAR
            if (this.WorkflowId == null && ParameterWasBound(nameof(this.WorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _DefinitionZipStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Omics.Model.CreateWorkflowVersionRequest();
                
                if (cmdletContext.Accelerator != null)
                {
                    request.Accelerators = cmdletContext.Accelerator;
                }
                
                 // populate DefinitionRepository
                var requestDefinitionRepositoryIsNull = true;
                request.DefinitionRepository = new Amazon.Omics.Model.DefinitionRepository();
                System.String requestDefinitionRepository_definitionRepository_ConnectionArn = null;
                if (cmdletContext.DefinitionRepository_ConnectionArn != null)
                {
                    requestDefinitionRepository_definitionRepository_ConnectionArn = cmdletContext.DefinitionRepository_ConnectionArn;
                }
                if (requestDefinitionRepository_definitionRepository_ConnectionArn != null)
                {
                    request.DefinitionRepository.ConnectionArn = requestDefinitionRepository_definitionRepository_ConnectionArn;
                    requestDefinitionRepositoryIsNull = false;
                }
                List<System.String> requestDefinitionRepository_definitionRepository_ExcludeFilePattern = null;
                if (cmdletContext.DefinitionRepository_ExcludeFilePattern != null)
                {
                    requestDefinitionRepository_definitionRepository_ExcludeFilePattern = cmdletContext.DefinitionRepository_ExcludeFilePattern;
                }
                if (requestDefinitionRepository_definitionRepository_ExcludeFilePattern != null)
                {
                    request.DefinitionRepository.ExcludeFilePatterns = requestDefinitionRepository_definitionRepository_ExcludeFilePattern;
                    requestDefinitionRepositoryIsNull = false;
                }
                System.String requestDefinitionRepository_definitionRepository_FullRepositoryId = null;
                if (cmdletContext.DefinitionRepository_FullRepositoryId != null)
                {
                    requestDefinitionRepository_definitionRepository_FullRepositoryId = cmdletContext.DefinitionRepository_FullRepositoryId;
                }
                if (requestDefinitionRepository_definitionRepository_FullRepositoryId != null)
                {
                    request.DefinitionRepository.FullRepositoryId = requestDefinitionRepository_definitionRepository_FullRepositoryId;
                    requestDefinitionRepositoryIsNull = false;
                }
                Amazon.Omics.Model.SourceReference requestDefinitionRepository_definitionRepository_SourceReference = null;
                
                 // populate SourceReference
                var requestDefinitionRepository_definitionRepository_SourceReferenceIsNull = true;
                requestDefinitionRepository_definitionRepository_SourceReference = new Amazon.Omics.Model.SourceReference();
                Amazon.Omics.SourceReferenceType requestDefinitionRepository_definitionRepository_SourceReference_sourceReference_Type = null;
                if (cmdletContext.SourceReference_Type != null)
                {
                    requestDefinitionRepository_definitionRepository_SourceReference_sourceReference_Type = cmdletContext.SourceReference_Type;
                }
                if (requestDefinitionRepository_definitionRepository_SourceReference_sourceReference_Type != null)
                {
                    requestDefinitionRepository_definitionRepository_SourceReference.Type = requestDefinitionRepository_definitionRepository_SourceReference_sourceReference_Type;
                    requestDefinitionRepository_definitionRepository_SourceReferenceIsNull = false;
                }
                System.String requestDefinitionRepository_definitionRepository_SourceReference_sourceReference_Value = null;
                if (cmdletContext.SourceReference_Value != null)
                {
                    requestDefinitionRepository_definitionRepository_SourceReference_sourceReference_Value = cmdletContext.SourceReference_Value;
                }
                if (requestDefinitionRepository_definitionRepository_SourceReference_sourceReference_Value != null)
                {
                    requestDefinitionRepository_definitionRepository_SourceReference.Value = requestDefinitionRepository_definitionRepository_SourceReference_sourceReference_Value;
                    requestDefinitionRepository_definitionRepository_SourceReferenceIsNull = false;
                }
                 // determine if requestDefinitionRepository_definitionRepository_SourceReference should be set to null
                if (requestDefinitionRepository_definitionRepository_SourceReferenceIsNull)
                {
                    requestDefinitionRepository_definitionRepository_SourceReference = null;
                }
                if (requestDefinitionRepository_definitionRepository_SourceReference != null)
                {
                    request.DefinitionRepository.SourceReference = requestDefinitionRepository_definitionRepository_SourceReference;
                    requestDefinitionRepositoryIsNull = false;
                }
                 // determine if request.DefinitionRepository should be set to null
                if (requestDefinitionRepositoryIsNull)
                {
                    request.DefinitionRepository = null;
                }
                if (cmdletContext.DefinitionUri != null)
                {
                    request.DefinitionUri = cmdletContext.DefinitionUri;
                }
                if (cmdletContext.DefinitionZip != null)
                {
                    _DefinitionZipStream = new System.IO.MemoryStream(cmdletContext.DefinitionZip);
                    request.DefinitionZip = _DefinitionZipStream;
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                if (cmdletContext.Engine != null)
                {
                    request.Engine = cmdletContext.Engine;
                }
                if (cmdletContext.Main != null)
                {
                    request.Main = cmdletContext.Main;
                }
                if (cmdletContext.ParameterTemplate != null)
                {
                    request.ParameterTemplate = cmdletContext.ParameterTemplate;
                }
                if (cmdletContext.ParameterTemplatePath != null)
                {
                    request.ParameterTemplatePath = cmdletContext.ParameterTemplatePath;
                }
                if (cmdletContext.ReadmeMarkdown != null)
                {
                    request.ReadmeMarkdown = cmdletContext.ReadmeMarkdown;
                }
                if (cmdletContext.ReadmePath != null)
                {
                    request.ReadmePath = cmdletContext.ReadmePath;
                }
                if (cmdletContext.ReadmeUri != null)
                {
                    request.ReadmeUri = cmdletContext.ReadmeUri;
                }
                if (cmdletContext.RequestId != null)
                {
                    request.RequestId = cmdletContext.RequestId;
                }
                if (cmdletContext.StorageCapacity != null)
                {
                    request.StorageCapacity = cmdletContext.StorageCapacity.Value;
                }
                if (cmdletContext.StorageType != null)
                {
                    request.StorageType = cmdletContext.StorageType;
                }
                if (cmdletContext.Tag != null)
                {
                    request.Tags = cmdletContext.Tag;
                }
                if (cmdletContext.VersionName != null)
                {
                    request.VersionName = cmdletContext.VersionName;
                }
                if (cmdletContext.WorkflowBucketOwnerId != null)
                {
                    request.WorkflowBucketOwnerId = cmdletContext.WorkflowBucketOwnerId;
                }
                if (cmdletContext.WorkflowId != null)
                {
                    request.WorkflowId = cmdletContext.WorkflowId;
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
            finally
            {
                if( _DefinitionZipStream != null)
                {
                    _DefinitionZipStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Omics.Model.CreateWorkflowVersionResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CreateWorkflowVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CreateWorkflowVersion");
            try
            {
                #if DESKTOP
                return client.CreateWorkflowVersion(request);
                #elif CORECLR
                return client.CreateWorkflowVersionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Omics.Accelerators Accelerator { get; set; }
            public System.String DefinitionRepository_ConnectionArn { get; set; }
            public List<System.String> DefinitionRepository_ExcludeFilePattern { get; set; }
            public System.String DefinitionRepository_FullRepositoryId { get; set; }
            public Amazon.Omics.SourceReferenceType SourceReference_Type { get; set; }
            public System.String SourceReference_Value { get; set; }
            public System.String DefinitionUri { get; set; }
            public byte[] DefinitionZip { get; set; }
            public System.String Description { get; set; }
            public Amazon.Omics.WorkflowEngine Engine { get; set; }
            public System.String Main { get; set; }
            public Dictionary<System.String, Amazon.Omics.Model.WorkflowParameter> ParameterTemplate { get; set; }
            public System.String ParameterTemplatePath { get; set; }
            public System.String ReadmeMarkdown { get; set; }
            public System.String ReadmePath { get; set; }
            public System.String ReadmeUri { get; set; }
            public System.String RequestId { get; set; }
            public System.Int32? StorageCapacity { get; set; }
            public Amazon.Omics.StorageType StorageType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String VersionName { get; set; }
            public System.String WorkflowBucketOwnerId { get; set; }
            public System.String WorkflowId { get; set; }
            public System.Func<Amazon.Omics.Model.CreateWorkflowVersionResponse, NewOMICSWorkflowVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
