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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Creates a repository creation template. This template is used to define the settings
    /// for repositories created by Amazon ECR on your behalf. For example, repositories created
    /// through pull through cache actions. For more information, see <a href="https://docs.aws.amazon.com/AmazonECR/latest/userguide/repository-creation-templates.html">Private
    /// repository creation templates</a> in the <i>Amazon Elastic Container Registry User
    /// Guide</i>.
    /// </summary>
    [Cmdlet("New", "ECRRepositoryCreationTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.CreateRepositoryCreationTemplateResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry CreateRepositoryCreationTemplate API operation.", Operation = new[] {"CreateRepositoryCreationTemplate"}, SelectReturnType = typeof(Amazon.ECR.Model.CreateRepositoryCreationTemplateResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.CreateRepositoryCreationTemplateResponse",
        "This cmdlet returns an Amazon.ECR.Model.CreateRepositoryCreationTemplateResponse object containing multiple properties."
    )]
    public partial class NewECRRepositoryCreationTemplateCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppliedFor
        /// <summary>
        /// <para>
        /// <para>A list of enumerable strings representing the Amazon ECR repository creation scenarios
        /// that this template will apply towards. The two supported scenarios are <c>PULL_THROUGH_CACHE</c>
        /// and <c>REPLICATION</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] AppliedFor { get; set; }
        #endregion
        
        #region Parameter CustomRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role to be assumed by Amazon ECR. This role must be in the same account
        /// as the registry that you are configuring. Amazon ECR will assume your supplied role
        /// when the customRoleArn is specified. When this field isn't specified, Amazon ECR will
        /// use the service-linked role for the repository creation template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomRoleArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the repository creation template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_EncryptionType
        /// <summary>
        /// <para>
        /// <para>The encryption type to use.</para><para>If you use the <c>KMS</c> encryption type, the contents of the repository will be
        /// encrypted using server-side encryption with Key Management Service key stored in KMS.
        /// When you use KMS to encrypt your data, you can either use the default Amazon Web Services
        /// managed KMS key for Amazon ECR, or specify your own KMS key, which you already created.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingKMSEncryption.html">Protecting
        /// data using server-side encryption with an KMS key stored in Key Management Service
        /// (SSE-KMS)</a> in the <i>Amazon Simple Storage Service Console Developer Guide</i>.</para><para>If you use the <c>AES256</c> encryption type, Amazon ECR uses server-side encryption
        /// with Amazon S3-managed encryption keys which encrypts the images in the repository
        /// using an AES256 encryption algorithm. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingServerSideEncryption.html">Protecting
        /// data using server-side encryption with Amazon S3-managed encryption keys (SSE-S3)</a>
        /// in the <i>Amazon Simple Storage Service Console Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECR.EncryptionType")]
        public Amazon.ECR.EncryptionType EncryptionConfiguration_EncryptionType { get; set; }
        #endregion
        
        #region Parameter ImageTagMutability
        /// <summary>
        /// <para>
        /// <para>The tag mutability setting for the repository. If this parameter is omitted, the default
        /// setting of <c>MUTABLE</c> will be used which will allow image tags to be overwritten.
        /// If <c>IMMUTABLE</c> is specified, all image tags within the repository will be immutable
        /// which will prevent them from being overwritten.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECR.ImageTagMutability")]
        public Amazon.ECR.ImageTagMutability ImageTagMutability { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>If you use the <c>KMS</c> encryption type, specify the KMS key to use for encryption.
        /// The full ARN of the KMS key must be specified. The key must exist in the same Region
        /// as the repository. If no key is specified, the default Amazon Web Services managed
        /// KMS key for Amazon ECR will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter LifecyclePolicy
        /// <summary>
        /// <para>
        /// <para>The lifecycle policy to use for repositories created using the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LifecyclePolicy { get; set; }
        #endregion
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// <para>The repository namespace prefix to associate with the template. All repositories created
        /// using this namespace prefix will have the settings defined in this template applied.
        /// For example, a prefix of <c>prod</c> would apply to all repositories beginning with
        /// <c>prod/</c>. Similarly, a prefix of <c>prod/team</c> would apply to all repositories
        /// beginning with <c>prod/team/</c>.</para><para>To apply a template to all repositories in your registry that don't have an associated
        /// creation template, you can use <c>ROOT</c> as the prefix.</para><important><para>There is always an assumed <c>/</c> applied to the end of the prefix. If you specify
        /// <c>ecr-public</c> as the prefix, Amazon ECR treats that as <c>ecr-public/</c>. When
        /// using a pull through cache rule, the repository prefix you specify during rule creation
        /// is what you should specify as your repository creation template prefix as well.</para></important>
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
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter RepositoryPolicy
        /// <summary>
        /// <para>
        /// <para>The repository policy to apply to repositories created using the template. A repository
        /// policy is a permissions policy associated with a repository to control access permissions.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RepositoryPolicy { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>The metadata to apply to the repository to help you categorize and organize. Each
        /// tag consists of a key and an optional value, both of which you define. Tag keys can
        /// have a maximum character length of 128 characters, and tag values can have a maximum
        /// length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.ECR.Model.Tag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.CreateRepositoryCreationTemplateResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.CreateRepositoryCreationTemplateResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECRRepositoryCreationTemplate (CreateRepositoryCreationTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.CreateRepositoryCreationTemplateResponse, NewECRRepositoryCreationTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AppliedFor != null)
            {
                context.AppliedFor = new List<System.String>(this.AppliedFor);
            }
            #if MODULAR
            if (this.AppliedFor == null && ParameterWasBound(nameof(this.AppliedFor)))
            {
                WriteWarning("You are passing $null as a value for parameter AppliedFor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomRoleArn = this.CustomRoleArn;
            context.Description = this.Description;
            context.EncryptionConfiguration_EncryptionType = this.EncryptionConfiguration_EncryptionType;
            context.EncryptionConfiguration_KmsKey = this.EncryptionConfiguration_KmsKey;
            context.ImageTagMutability = this.ImageTagMutability;
            context.LifecyclePolicy = this.LifecyclePolicy;
            context.Prefix = this.Prefix;
            #if MODULAR
            if (this.Prefix == null && ParameterWasBound(nameof(this.Prefix)))
            {
                WriteWarning("You are passing $null as a value for parameter Prefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RepositoryPolicy = this.RepositoryPolicy;
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.ECR.Model.Tag>(this.ResourceTag);
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
            var request = new Amazon.ECR.Model.CreateRepositoryCreationTemplateRequest();
            
            if (cmdletContext.AppliedFor != null)
            {
                request.AppliedFor = cmdletContext.AppliedFor;
            }
            if (cmdletContext.CustomRoleArn != null)
            {
                request.CustomRoleArn = cmdletContext.CustomRoleArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.ECR.Model.EncryptionConfigurationForRepositoryCreationTemplate();
            Amazon.ECR.EncryptionType requestEncryptionConfiguration_encryptionConfiguration_EncryptionType = null;
            if (cmdletContext.EncryptionConfiguration_EncryptionType != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_EncryptionType = cmdletContext.EncryptionConfiguration_EncryptionType;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_EncryptionType != null)
            {
                request.EncryptionConfiguration.EncryptionType = requestEncryptionConfiguration_encryptionConfiguration_EncryptionType;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKey = null;
            if (cmdletContext.EncryptionConfiguration_KmsKey != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKey = cmdletContext.EncryptionConfiguration_KmsKey;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKey != null)
            {
                request.EncryptionConfiguration.KmsKey = requestEncryptionConfiguration_encryptionConfiguration_KmsKey;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.ImageTagMutability != null)
            {
                request.ImageTagMutability = cmdletContext.ImageTagMutability;
            }
            if (cmdletContext.LifecyclePolicy != null)
            {
                request.LifecyclePolicy = cmdletContext.LifecyclePolicy;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.RepositoryPolicy != null)
            {
                request.RepositoryPolicy = cmdletContext.RepositoryPolicy;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
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
        
        private Amazon.ECR.Model.CreateRepositoryCreationTemplateResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.CreateRepositoryCreationTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "CreateRepositoryCreationTemplate");
            try
            {
                #if DESKTOP
                return client.CreateRepositoryCreationTemplate(request);
                #elif CORECLR
                return client.CreateRepositoryCreationTemplateAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AppliedFor { get; set; }
            public System.String CustomRoleArn { get; set; }
            public System.String Description { get; set; }
            public Amazon.ECR.EncryptionType EncryptionConfiguration_EncryptionType { get; set; }
            public System.String EncryptionConfiguration_KmsKey { get; set; }
            public Amazon.ECR.ImageTagMutability ImageTagMutability { get; set; }
            public System.String LifecyclePolicy { get; set; }
            public System.String Prefix { get; set; }
            public System.String RepositoryPolicy { get; set; }
            public List<Amazon.ECR.Model.Tag> ResourceTag { get; set; }
            public System.Func<Amazon.ECR.Model.CreateRepositoryCreationTemplateResponse, NewECRRepositoryCreationTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
