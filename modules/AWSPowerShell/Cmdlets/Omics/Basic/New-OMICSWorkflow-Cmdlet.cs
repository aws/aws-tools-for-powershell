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
    /// Creates a private workflow. Before you create a private workflow, you must create
    /// and configure these required resources:
    /// 
    ///  <ul><li><para><i>Workflow definition files</i>: Define your workflow in one or more workflow definition
    /// files, written in WDL, Nextflow, or CWL. The workflow definition specifies the inputs
    /// and outputs for runs that use the workflow. It also includes specifications for the
    /// runs and run tasks for your workflow, including compute and memory requirements. The
    /// workflow definition file must be in .zip format.
    /// </para></li><li><para>
    /// (Optional) <i>Parameter template</i>: You can create a parameter template file that
    /// defines the run parameters, or Amazon Web Services HealthOmics can generate the parameter
    /// template for you.
    /// </para></li><li><para><i>ECR container images</i>: Create container images for the workflow in a private
    /// ECR repository, or synchronize images from a supported upstream registry with your
    /// Amazon ECR private repository.
    /// </para></li><li><para>
    /// (Optional) <i>Sentieon licenses</i>: Request a Sentieon license if using the Sentieon
    /// software in a private workflow.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/omics/latest/dev/creating-private-workflows.html">Creating
    /// or updating a private workflow in Amazon Web Services HealthOmics</a> in the <i>Amazon
    /// Web Services HealthOmics User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OMICSWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.CreateWorkflowResponse")]
    [AWSCmdlet("Calls the Amazon Omics CreateWorkflow API operation.", Operation = new[] {"CreateWorkflow"}, SelectReturnType = typeof(Amazon.Omics.Model.CreateWorkflowResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.CreateWorkflowResponse",
        "This cmdlet returns an Amazon.Omics.Model.CreateWorkflowResponse object containing multiple properties."
    )]
    public partial class NewOMICSWorkflowCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Accelerator
        /// <summary>
        /// <para>
        /// <para>The computational accelerator specified to run the workflow.</para>
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
        
        #region Parameter ContainerRegistryMapUri
        /// <summary>
        /// <para>
        /// <para>(Optional) URI of the S3 location for the registry mapping file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerRegistryMapUri { get; set; }
        #endregion
        
        #region Parameter DefinitionUri
        /// <summary>
        /// <para>
        /// <para>The S3 URI of a definition for the workflow. The S3 bucket must be in the same region
        /// as the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefinitionUri { get; set; }
        #endregion
        
        #region Parameter DefinitionZip
        /// <summary>
        /// <para>
        /// <para>A ZIP archive containing the main workflow definition file and dependencies that it
        /// imports for the workflow. You can use a file with a ://fileb prefix instead of the
        /// Base64 string. For more information, see <a href="https://docs.aws.amazon.com/omics/latest/dev/workflow-defn-requirements.html">Workflow
        /// definition requirements</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
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
        /// <para>A description for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The workflow engine for the workflow. This is only required if you have workflow definition
        /// files from more than one engine in your zip file. Otherwise, the service can detect
        /// the engine automatically from your workflow definition.</para>
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
        
        #region Parameter ContainerRegistryMap_ImageMapping
        /// <summary>
        /// <para>
        /// <para>Image mappings specify path mappings between the ECR private repository and their
        /// corresponding external repositories.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerRegistryMap_ImageMappings")]
        public Amazon.Omics.Model.ImageMapping[] ContainerRegistryMap_ImageMapping { get; set; }
        #endregion
        
        #region Parameter Main
        /// <summary>
        /// <para>
        /// <para>The path of the main definition file for the workflow. This parameter is not required
        /// if the ZIP archive contains only one workflow definition file, or if the main definition
        /// file is named “main”. An example path is: <c>workflow-definition/main-file.wdl</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Main { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name (optional but highly recommended) for the workflow to locate relevant information
        /// in the CloudWatch logs and Amazon Web Services HealthOmics console. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParameterTemplate
        /// <summary>
        /// <para>
        /// <para>A parameter template for the workflow. If this field is blank, Amazon Web Services
        /// HealthOmics will automatically parse the parameter template values from your workflow
        /// definition file. To override these service generated default values, provide a parameter
        /// template. To view an example of a parameter template, see <a href="https://docs.aws.amazon.com/omics/latest/dev/parameter-templates.html">Parameter
        /// template files</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ParameterTemplate { get; set; }
        #endregion
        
        #region Parameter ParameterTemplatePath
        /// <summary>
        /// <para>
        /// <para>The path to the workflow parameter template JSON file within the repository. This
        /// file defines the input parameters for runs that use this workflow. If not specified,
        /// the workflow will be created without a parameter template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParameterTemplatePath { get; set; }
        #endregion
        
        #region Parameter ReadmeMarkdown
        /// <summary>
        /// <para>
        /// <para>The markdown content for the workflow's README file. This provides documentation and
        /// usage information for users of the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmeMarkdown { get; set; }
        #endregion
        
        #region Parameter ReadmePath
        /// <summary>
        /// <para>
        /// <para>The path to the workflow README markdown file within the repository. This file provides
        /// documentation and usage information for the workflow. If not specified, the <c>README.md</c>
        /// file from the root directory of the repository will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmePath { get; set; }
        #endregion
        
        #region Parameter ReadmeUri
        /// <summary>
        /// <para>
        /// <para>The S3 URI of the README file for the workflow. This file provides documentation and
        /// usage information for the workflow. Requirements include:</para><ul><li><para>The S3 URI must begin with <c>s3://USER-OWNED-BUCKET/</c></para></li><li><para>The requester must have access to the S3 bucket and object.</para></li><li><para>The max README content length is 500 KiB.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmeUri { get; set; }
        #endregion
        
        #region Parameter ContainerRegistryMap_RegistryMapping
        /// <summary>
        /// <para>
        /// <para>Mapping that provides the ECR repository path where upstream container images are
        /// pulled and synchronized.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerRegistryMap_RegistryMappings")]
        public Amazon.Omics.Model.RegistryMapping[] ContainerRegistryMap_RegistryMapping { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// <para>An idempotency token to ensure that duplicate workflows are not created when Amazon
        /// Web Services HealthOmics submits retry requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>The default static storage capacity (in gibibytes) for runs that use this workflow
        /// or workflow version. The <c>storageCapacity</c> can be overwritten at run time. The
        /// storage capacity is not required for runs with a <c>DYNAMIC</c> storage type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>The default storage type for runs that use this workflow. The <c>storageType</c> can
        /// be overridden at run time. <c>DYNAMIC</c> storage dynamically scales the storage up
        /// or down, based on file system utilization. <c>STATIC</c> storage allocates a fixed
        /// amount of storage. For more information about dynamic and static storage types, see
        /// <a href="https://docs.aws.amazon.com/omics/latest/dev/workflows-run-types.html">Run
        /// storage types</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.StorageType")]
        public Amazon.Omics.StorageType StorageType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the workflow. You can define up to 50 tags for the workflow. For more information,
        /// see <a href="https://docs.aws.amazon.com/omics/latest/dev/add-a-tag.html">Adding a
        /// tag</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
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
        
        #region Parameter WorkflowBucketOwnerId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the expected owner of the S3 bucket that contains
        /// the workflow definition. If not specified, the service skips the validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkflowBucketOwnerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CreateWorkflowResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CreateWorkflowResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OMICSWorkflow (CreateWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CreateWorkflowResponse, NewOMICSWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accelerator = this.Accelerator;
            if (this.ContainerRegistryMap_ImageMapping != null)
            {
                context.ContainerRegistryMap_ImageMapping = new List<Amazon.Omics.Model.ImageMapping>(this.ContainerRegistryMap_ImageMapping);
            }
            if (this.ContainerRegistryMap_RegistryMapping != null)
            {
                context.ContainerRegistryMap_RegistryMapping = new List<Amazon.Omics.Model.RegistryMapping>(this.ContainerRegistryMap_RegistryMapping);
            }
            context.ContainerRegistryMapUri = this.ContainerRegistryMapUri;
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
            context.Name = this.Name;
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
            context.WorkflowBucketOwnerId = this.WorkflowBucketOwnerId;
            
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
                var request = new Amazon.Omics.Model.CreateWorkflowRequest();
                
                if (cmdletContext.Accelerator != null)
                {
                    request.Accelerators = cmdletContext.Accelerator;
                }
                
                 // populate ContainerRegistryMap
                var requestContainerRegistryMapIsNull = true;
                request.ContainerRegistryMap = new Amazon.Omics.Model.ContainerRegistryMap();
                List<Amazon.Omics.Model.ImageMapping> requestContainerRegistryMap_containerRegistryMap_ImageMapping = null;
                if (cmdletContext.ContainerRegistryMap_ImageMapping != null)
                {
                    requestContainerRegistryMap_containerRegistryMap_ImageMapping = cmdletContext.ContainerRegistryMap_ImageMapping;
                }
                if (requestContainerRegistryMap_containerRegistryMap_ImageMapping != null)
                {
                    request.ContainerRegistryMap.ImageMappings = requestContainerRegistryMap_containerRegistryMap_ImageMapping;
                    requestContainerRegistryMapIsNull = false;
                }
                List<Amazon.Omics.Model.RegistryMapping> requestContainerRegistryMap_containerRegistryMap_RegistryMapping = null;
                if (cmdletContext.ContainerRegistryMap_RegistryMapping != null)
                {
                    requestContainerRegistryMap_containerRegistryMap_RegistryMapping = cmdletContext.ContainerRegistryMap_RegistryMapping;
                }
                if (requestContainerRegistryMap_containerRegistryMap_RegistryMapping != null)
                {
                    request.ContainerRegistryMap.RegistryMappings = requestContainerRegistryMap_containerRegistryMap_RegistryMapping;
                    requestContainerRegistryMapIsNull = false;
                }
                 // determine if request.ContainerRegistryMap should be set to null
                if (requestContainerRegistryMapIsNull)
                {
                    request.ContainerRegistryMap = null;
                }
                if (cmdletContext.ContainerRegistryMapUri != null)
                {
                    request.ContainerRegistryMapUri = cmdletContext.ContainerRegistryMapUri;
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
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
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
                if (cmdletContext.WorkflowBucketOwnerId != null)
                {
                    request.WorkflowBucketOwnerId = cmdletContext.WorkflowBucketOwnerId;
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
        
        private Amazon.Omics.Model.CreateWorkflowResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CreateWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CreateWorkflow");
            try
            {
                #if DESKTOP
                return client.CreateWorkflow(request);
                #elif CORECLR
                return client.CreateWorkflowAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Omics.Model.ImageMapping> ContainerRegistryMap_ImageMapping { get; set; }
            public List<Amazon.Omics.Model.RegistryMapping> ContainerRegistryMap_RegistryMapping { get; set; }
            public System.String ContainerRegistryMapUri { get; set; }
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
            public System.String Name { get; set; }
            public Dictionary<System.String, Amazon.Omics.Model.WorkflowParameter> ParameterTemplate { get; set; }
            public System.String ParameterTemplatePath { get; set; }
            public System.String ReadmeMarkdown { get; set; }
            public System.String ReadmePath { get; set; }
            public System.String ReadmeUri { get; set; }
            public System.String RequestId { get; set; }
            public System.Int32? StorageCapacity { get; set; }
            public Amazon.Omics.StorageType StorageType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkflowBucketOwnerId { get; set; }
            public System.Func<Amazon.Omics.Model.CreateWorkflowResponse, NewOMICSWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
