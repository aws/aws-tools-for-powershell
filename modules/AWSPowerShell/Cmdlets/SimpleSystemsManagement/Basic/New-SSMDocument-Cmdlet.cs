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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Creates a Amazon Web Services Systems Manager (SSM document). An SSM document defines
    /// the actions that Systems Manager performs on your managed nodes. For more information
    /// about SSM documents, including information about supported schemas, features, and
    /// syntax, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/documents.html">Amazon
    /// Web Services Systems Manager Documents</a> in the <i>Amazon Web Services Systems Manager
    /// User Guide</i>.
    /// </summary>
    [Cmdlet("New", "SSMDocument", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.DocumentDescription")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateDocument API operation.", Operation = new[] {"CreateDocument"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.DocumentDescription or Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.DocumentDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSSMDocumentCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attachment
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that describe attachments to a version of a document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attachments")]
        public Amazon.SimpleSystemsManagement.Model.AttachmentsSource[] Attachment { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The content for the new SSM document in JSON or YAML format. The content of the document
        /// must not exceed 64KB. This quota also includes the content specified for input parameters
        /// at runtime. We recommend storing the contents for your new document in an external
        /// JSON or YAML file and referencing the file in a command.</para><para>For examples, see the following topics in the <i>Amazon Web Services Systems Manager
        /// User Guide</i>.</para><ul><li><para><a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/documents-using.html#create-ssm-console">Create
        /// an SSM document (console)</a></para></li><li><para><a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/documents-using.html#create-ssm-document-cli">Create
        /// an SSM document (command line)</a></para></li><li><para><a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/documents-using.html#create-ssm-document-api">Create
        /// an SSM document (API)</a></para></li></ul>
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
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>An optional field where you can specify a friendly name for the SSM document. This
        /// value can differ for each version of the document. You can update this value at a
        /// later time using the <a>UpdateDocument</a> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter DocumentFormat
        /// <summary>
        /// <para>
        /// <para>Specify the document format for the request. The document format can be JSON, YAML,
        /// or TEXT. JSON is the default format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentFormat")]
        public Amazon.SimpleSystemsManagement.DocumentFormat DocumentFormat { get; set; }
        #endregion
        
        #region Parameter DocumentType
        /// <summary>
        /// <para>
        /// <para>The type of document to create.</para><note><para>The <c>DeploymentStrategy</c> document type is an internal-use-only document type
        /// reserved for AppConfig.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentType")]
        public Amazon.SimpleSystemsManagement.DocumentType DocumentType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the SSM document.</para><important><para>You can't use the following strings as document name prefixes. These are reserved
        /// by Amazon Web Services for use as document name prefixes:</para><ul><li><para><c>aws</c></para></li><li><para><c>amazon</c></para></li><li><para><c>amzn</c></para></li><li><para><c>AWSEC2</c></para></li><li><para><c>AWSConfigRemediation</c></para></li><li><para><c>AWSSupport</c></para></li></ul></important>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Require
        /// <summary>
        /// <para>
        /// <para>A list of SSM documents required by a document. This parameter is used exclusively
        /// by AppConfig. When a user creates an AppConfig configuration in an SSM document, the
        /// user must also specify a required document for validation purposes. In this case,
        /// an <c>ApplicationConfiguration</c> document requires an <c>ApplicationConfigurationSchema</c>
        /// document for validation purposes. For more information, see <a href="https://docs.aws.amazon.com/appconfig/latest/userguide/what-is-appconfig.html">What
        /// is AppConfig?</a> in the <i>AppConfig User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Requires")]
        public Amazon.SimpleSystemsManagement.Model.DocumentRequires[] Require { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you assign to a resource. Tags enable you to categorize a resource
        /// in different ways, such as by purpose, owner, or environment. For example, you might
        /// want to tag an SSM document to identify the types of targets or the environment where
        /// it will run. In this case, you could specify the following key-value pairs:</para><ul><li><para><c>Key=OS,Value=Windows</c></para></li><li><para><c>Key=Environment,Value=Production</c></para></li></ul><note><para>To add tags to an existing SSM document, use the <a>AddTagsToResource</a> operation.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetType
        /// <summary>
        /// <para>
        /// <para>Specify a target type to define the kinds of resources the document can run on. For
        /// example, to run a document on EC2 instances, specify the following value: <c>/AWS::EC2::Instance</c>.
        /// If you specify a value of '/' the document can run on all types of resources. If you
        /// don't specify a value, the document can't run on any resources. For a list of valid
        /// resource types, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-template-resource-type-ref.html">Amazon
        /// Web Services resource and property types reference</a> in the <i>CloudFormation User
        /// Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetType { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para>An optional field specifying the version of the artifact you are creating with the
        /// document. For example, <c>Release12.1</c>. This value is unique across all versions
        /// of a document, and can't be changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DocumentDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DocumentDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Content parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Content' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Content' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMDocument (CreateDocument)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse, NewSSMDocumentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Content;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Attachment != null)
            {
                context.Attachment = new List<Amazon.SimpleSystemsManagement.Model.AttachmentsSource>(this.Attachment);
            }
            context.Content = this.Content;
            #if MODULAR
            if (this.Content == null && ParameterWasBound(nameof(this.Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DisplayName = this.DisplayName;
            context.DocumentFormat = this.DocumentFormat;
            context.DocumentType = this.DocumentType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Require != null)
            {
                context.Require = new List<Amazon.SimpleSystemsManagement.Model.DocumentRequires>(this.Require);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
            }
            context.TargetType = this.TargetType;
            context.VersionName = this.VersionName;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateDocumentRequest();
            
            if (cmdletContext.Attachment != null)
            {
                request.Attachments = cmdletContext.Attachment;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.DocumentFormat != null)
            {
                request.DocumentFormat = cmdletContext.DocumentFormat;
            }
            if (cmdletContext.DocumentType != null)
            {
                request.DocumentType = cmdletContext.DocumentType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Require != null)
            {
                request.Requires = cmdletContext.Require;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetType != null)
            {
                request.TargetType = cmdletContext.TargetType;
            }
            if (cmdletContext.VersionName != null)
            {
                request.VersionName = cmdletContext.VersionName;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateDocumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreateDocument");
            try
            {
                #if DESKTOP
                return client.CreateDocument(request);
                #elif CORECLR
                return client.CreateDocumentAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleSystemsManagement.Model.AttachmentsSource> Attachment { get; set; }
            public System.String Content { get; set; }
            public System.String DisplayName { get; set; }
            public Amazon.SimpleSystemsManagement.DocumentFormat DocumentFormat { get; set; }
            public Amazon.SimpleSystemsManagement.DocumentType DocumentType { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.DocumentRequires> Require { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tag { get; set; }
            public System.String TargetType { get; set; }
            public System.String VersionName { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse, NewSSMDocumentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DocumentDescription;
        }
        
    }
}
