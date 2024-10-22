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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Creates a knowledge base.
    /// 
    ///  <note><para>
    /// When using this API, you cannot reuse <a href="https://docs.aws.amazon.com/appintegrations/latest/APIReference/Welcome.html">Amazon
    /// AppIntegrations</a> DataIntegrations with external knowledge bases such as Salesforce
    /// and ServiceNow. If you do, you'll get an <c>InvalidRequestException</c> error. 
    /// </para><para>
    /// For example, you're programmatically managing your external knowledge base, and you
    /// want to add or remove one of the fields that is being ingested from Salesforce. Do
    /// the following:
    /// </para><ol><li><para>
    /// Call <a href="https://docs.aws.amazon.com/amazon-q-connect/latest/APIReference/API_DeleteKnowledgeBase.html">DeleteKnowledgeBase</a>.
    /// </para></li><li><para>
    /// Call <a href="https://docs.aws.amazon.com/appintegrations/latest/APIReference/API_DeleteDataIntegration.html">DeleteDataIntegration</a>.
    /// </para></li><li><para>
    /// Call <a href="https://docs.aws.amazon.com/appintegrations/latest/APIReference/API_CreateDataIntegration.html">CreateDataIntegration</a>
    /// to recreate the DataIntegration or a create different one.
    /// </para></li><li><para>
    /// Call CreateKnowledgeBase.
    /// </para></li></ol></note>
    /// </summary>
    [Cmdlet("New", "QCKnowledgeBase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.KnowledgeBaseData")]
    [AWSCmdlet("Calls the Amazon Q Connect CreateKnowledgeBase API operation.", Operation = new[] {"CreateKnowledgeBase"}, SelectReturnType = typeof(Amazon.QConnect.Model.CreateKnowledgeBaseResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.KnowledgeBaseData or Amazon.QConnect.Model.CreateKnowledgeBaseResponse",
        "This cmdlet returns an Amazon.QConnect.Model.KnowledgeBaseData object.",
        "The service call response (type Amazon.QConnect.Model.CreateKnowledgeBaseResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQCKnowledgeBaseCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppIntegrations_AppIntegrationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AppIntegrations DataIntegration to use for ingesting
        /// content.</para><ul><li><para> For <a href="https://developer.salesforce.com/docs/atlas.en-us.knowledge_dev.meta/knowledge_dev/sforce_api_objects_knowledge__kav.htm">
        /// Salesforce</a>, your AppIntegrations DataIntegration must have an ObjectConfiguration
        /// if objectFields is not provided, including at least <c>Id</c>, <c>ArticleNumber</c>,
        /// <c>VersionNumber</c>, <c>Title</c>, <c>PublishStatus</c>, and <c>IsDeleted</c> as
        /// source fields. </para></li><li><para> For <a href="https://developer.servicenow.com/dev.do#!/reference/api/rome/rest/knowledge-management-api">
        /// ServiceNow</a>, your AppIntegrations DataIntegration must have an ObjectConfiguration
        /// if objectFields is not provided, including at least <c>number</c>, <c>short_description</c>,
        /// <c>sys_mod_count</c>, <c>workflow_state</c>, and <c>active</c> as source fields. </para></li><li><para> For <a href="https://developer.zendesk.com/api-reference/help_center/help-center-api/articles/">
        /// Zendesk</a>, your AppIntegrations DataIntegration must have an ObjectConfiguration
        /// if <c>objectFields</c> is not provided, including at least <c>id</c>, <c>title</c>,
        /// <c>updated_at</c>, and <c>draft</c> as source fields. </para></li><li><para> For <a href="https://learn.microsoft.com/en-us/sharepoint/dev/sp-add-ins/sharepoint-net-server-csom-jsom-and-rest-api-index">SharePoint</a>,
        /// your AppIntegrations DataIntegration must have a FileConfiguration, including only
        /// file extensions that are among <c>docx</c>, <c>pdf</c>, <c>html</c>, <c>htm</c>, and
        /// <c>txt</c>. </para></li><li><para> For <a href="https://aws.amazon.com/s3/">Amazon S3</a>, the ObjectConfiguration and
        /// FileConfiguration of your AppIntegrations DataIntegration must be null. The <c>SourceURI</c>
        /// of your DataIntegration must use the following format: <c>s3://your_s3_bucket_name</c>.</para><important><para>The bucket policy of the corresponding S3 bucket must allow the Amazon Web Services
        /// principal <c>app-integrations.amazonaws.com</c> to perform <c>s3:ListBucket</c>, <c>s3:GetObject</c>,
        /// and <c>s3:GetBucketLocation</c> against the bucket.</para></important></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_AppIntegrations_AppIntegrationArn")]
        public System.String AppIntegrations_AppIntegrationArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The customer managed key used for encryption. For more information about setting up
        /// a customer managed key for Amazon Q in Connect, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/enable-q.html">Enable
        /// Amazon Q in Connect for your instance</a>. For information about valid ID values,
        /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id">Key
        /// identifiers (KeyId)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseType
        /// <summary>
        /// <para>
        /// <para>The type of knowledge base. Only CUSTOM knowledge bases allow you to upload your own
        /// content. EXTERNAL knowledge bases support integrations with third-party systems whose
        /// content is synchronized automatically. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.KnowledgeBaseType")]
        public Amazon.QConnect.KnowledgeBaseType KnowledgeBaseType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the knowledge base.</para>
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
        
        #region Parameter AppIntegrations_ObjectField
        /// <summary>
        /// <para>
        /// <para>The fields from the source that are made available to your agents in Amazon Q in Connect.
        /// Optional if ObjectConfiguration is included in the provided DataIntegration. </para><ul><li><para> For <a href="https://developer.salesforce.com/docs/atlas.en-us.knowledge_dev.meta/knowledge_dev/sforce_api_objects_knowledge__kav.htm">
        /// Salesforce</a>, you must include at least <c>Id</c>, <c>ArticleNumber</c>, <c>VersionNumber</c>,
        /// <c>Title</c>, <c>PublishStatus</c>, and <c>IsDeleted</c>. </para></li><li><para>For <a href="https://developer.servicenow.com/dev.do#!/reference/api/rome/rest/knowledge-management-api">
        /// ServiceNow</a>, you must include at least <c>number</c>, <c>short_description</c>,
        /// <c>sys_mod_count</c>, <c>workflow_state</c>, and <c>active</c>. </para></li><li><para>For <a href="https://developer.zendesk.com/api-reference/help_center/help-center-api/articles/">
        /// Zendesk</a>, you must include at least <c>id</c>, <c>title</c>, <c>updated_at</c>,
        /// and <c>draft</c>. </para></li></ul><para>Make sure to include additional fields. These fields are indexed and used to source
        /// recommendations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_AppIntegrations_ObjectFields")]
        public System.String[] AppIntegrations_ObjectField { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter RenderingConfiguration_TemplateUri
        /// <summary>
        /// <para>
        /// <para>A URI template containing exactly one variable in <c>${variableName} </c>format. This
        /// can only be set for <c>EXTERNAL</c> knowledge bases. For Salesforce, ServiceNow, and
        /// Zendesk, the variable must be one of the following:</para><ul><li><para>Salesforce: <c>Id</c>, <c>ArticleNumber</c>, <c>VersionNumber</c>, <c>Title</c>, <c>PublishStatus</c>,
        /// or <c>IsDeleted</c></para></li><li><para>ServiceNow: <c>number</c>, <c>short_description</c>, <c>sys_mod_count</c>, <c>workflow_state</c>,
        /// or <c>active</c></para></li><li><para>Zendesk: <c>id</c>, <c>title</c>, <c>updated_at</c>, or <c>draft</c></para></li></ul><para>The variable is replaced with the actual value for a piece of content when calling
        /// <a href="https://docs.aws.amazon.com/amazon-q-connect/latest/APIReference/API_GetContent.html">GetContent</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RenderingConfiguration_TemplateUri { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KnowledgeBase'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.CreateKnowledgeBaseResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.CreateKnowledgeBaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KnowledgeBase";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QCKnowledgeBase (CreateKnowledgeBase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.CreateKnowledgeBaseResponse, NewQCKnowledgeBaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.KnowledgeBaseType = this.KnowledgeBaseType;
            #if MODULAR
            if (this.KnowledgeBaseType == null && ParameterWasBound(nameof(this.KnowledgeBaseType)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RenderingConfiguration_TemplateUri = this.RenderingConfiguration_TemplateUri;
            context.ServerSideEncryptionConfiguration_KmsKeyId = this.ServerSideEncryptionConfiguration_KmsKeyId;
            context.AppIntegrations_AppIntegrationArn = this.AppIntegrations_AppIntegrationArn;
            if (this.AppIntegrations_ObjectField != null)
            {
                context.AppIntegrations_ObjectField = new List<System.String>(this.AppIntegrations_ObjectField);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.QConnect.Model.CreateKnowledgeBaseRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KnowledgeBaseType != null)
            {
                request.KnowledgeBaseType = cmdletContext.KnowledgeBaseType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RenderingConfiguration
            var requestRenderingConfigurationIsNull = true;
            request.RenderingConfiguration = new Amazon.QConnect.Model.RenderingConfiguration();
            System.String requestRenderingConfiguration_renderingConfiguration_TemplateUri = null;
            if (cmdletContext.RenderingConfiguration_TemplateUri != null)
            {
                requestRenderingConfiguration_renderingConfiguration_TemplateUri = cmdletContext.RenderingConfiguration_TemplateUri;
            }
            if (requestRenderingConfiguration_renderingConfiguration_TemplateUri != null)
            {
                request.RenderingConfiguration.TemplateUri = requestRenderingConfiguration_renderingConfiguration_TemplateUri;
                requestRenderingConfigurationIsNull = false;
            }
             // determine if request.RenderingConfiguration should be set to null
            if (requestRenderingConfigurationIsNull)
            {
                request.RenderingConfiguration = null;
            }
            
             // populate ServerSideEncryptionConfiguration
            var requestServerSideEncryptionConfigurationIsNull = true;
            request.ServerSideEncryptionConfiguration = new Amazon.QConnect.Model.ServerSideEncryptionConfiguration();
            System.String requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.ServerSideEncryptionConfiguration_KmsKeyId != null)
            {
                requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyId = cmdletContext.ServerSideEncryptionConfiguration_KmsKeyId;
            }
            if (requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyId != null)
            {
                request.ServerSideEncryptionConfiguration.KmsKeyId = requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyId;
                requestServerSideEncryptionConfigurationIsNull = false;
            }
             // determine if request.ServerSideEncryptionConfiguration should be set to null
            if (requestServerSideEncryptionConfigurationIsNull)
            {
                request.ServerSideEncryptionConfiguration = null;
            }
            
             // populate SourceConfiguration
            var requestSourceConfigurationIsNull = true;
            request.SourceConfiguration = new Amazon.QConnect.Model.SourceConfiguration();
            Amazon.QConnect.Model.AppIntegrationsConfiguration requestSourceConfiguration_sourceConfiguration_AppIntegrations = null;
            
             // populate AppIntegrations
            var requestSourceConfiguration_sourceConfiguration_AppIntegrationsIsNull = true;
            requestSourceConfiguration_sourceConfiguration_AppIntegrations = new Amazon.QConnect.Model.AppIntegrationsConfiguration();
            System.String requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_AppIntegrationArn = null;
            if (cmdletContext.AppIntegrations_AppIntegrationArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_AppIntegrationArn = cmdletContext.AppIntegrations_AppIntegrationArn;
            }
            if (requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_AppIntegrationArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations.AppIntegrationArn = requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_AppIntegrationArn;
                requestSourceConfiguration_sourceConfiguration_AppIntegrationsIsNull = false;
            }
            List<System.String> requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_ObjectField = null;
            if (cmdletContext.AppIntegrations_ObjectField != null)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_ObjectField = cmdletContext.AppIntegrations_ObjectField;
            }
            if (requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_ObjectField != null)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations.ObjectFields = requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_ObjectField;
                requestSourceConfiguration_sourceConfiguration_AppIntegrationsIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_AppIntegrations should be set to null
            if (requestSourceConfiguration_sourceConfiguration_AppIntegrationsIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_AppIntegrations != null)
            {
                request.SourceConfiguration.AppIntegrations = requestSourceConfiguration_sourceConfiguration_AppIntegrations;
                requestSourceConfigurationIsNull = false;
            }
             // determine if request.SourceConfiguration should be set to null
            if (requestSourceConfigurationIsNull)
            {
                request.SourceConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.QConnect.Model.CreateKnowledgeBaseResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.CreateKnowledgeBaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "CreateKnowledgeBase");
            try
            {
                #if DESKTOP
                return client.CreateKnowledgeBase(request);
                #elif CORECLR
                return client.CreateKnowledgeBaseAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Amazon.QConnect.KnowledgeBaseType KnowledgeBaseType { get; set; }
            public System.String Name { get; set; }
            public System.String RenderingConfiguration_TemplateUri { get; set; }
            public System.String ServerSideEncryptionConfiguration_KmsKeyId { get; set; }
            public System.String AppIntegrations_AppIntegrationArn { get; set; }
            public List<System.String> AppIntegrations_ObjectField { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.QConnect.Model.CreateKnowledgeBaseResponse, NewQCKnowledgeBaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KnowledgeBase;
        }
        
    }
}
