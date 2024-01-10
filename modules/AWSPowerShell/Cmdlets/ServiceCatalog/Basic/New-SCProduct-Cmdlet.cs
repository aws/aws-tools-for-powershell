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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Creates a product.
    /// 
    ///  
    /// <para>
    /// A delegated admin is authorized to invoke this command.
    /// </para><para>
    /// The user or role that performs this operation must have the <c>cloudformation:GetTemplate</c>
    /// IAM policy permission. This policy permission is required when using the <c>ImportFromPhysicalId</c>
    /// template source in the information data section.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SCProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.CreateProductResponse")]
    [AWSCmdlet("Calls the AWS Service Catalog CreateProduct API operation.", Operation = new[] {"CreateProduct"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.CreateProductResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.CreateProductResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.Model.CreateProductResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSCProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><c>jp</c> - Japanese</para></li><li><para><c>zh</c> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter CodeStar_ArtifactPath
        /// <summary>
        /// <para>
        /// <para>The absolute path wehre the artifact resides within the repo and branch, formatted
        /// as "folder/file.json." </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConnection_ConnectionParameters_CodeStar_ArtifactPath")]
        public System.String CodeStar_ArtifactPath { get; set; }
        #endregion
        
        #region Parameter CodeStar_Branch
        /// <summary>
        /// <para>
        /// <para>The specific branch where the artifact resides. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConnection_ConnectionParameters_CodeStar_Branch")]
        public System.String CodeStar_Branch { get; set; }
        #endregion
        
        #region Parameter CodeStar_ConnectionArn
        /// <summary>
        /// <para>
        /// <para>The CodeStar ARN, which is the connection between Service Catalog and the external
        /// repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConnection_ConnectionParameters_CodeStar_ConnectionArn")]
        public System.String CodeStar_ConnectionArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactParameters_Description
        /// <summary>
        /// <para>
        /// <para>The description of the provisioning artifact, including how it differs from the previous
        /// provisioning artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningArtifactParameters_Description { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactParameters_DisableTemplateValidation
        /// <summary>
        /// <para>
        /// <para>If set to true, Service Catalog stops validating the specified provisioning artifact
        /// even if it is invalid. </para><para>Service Catalog does not support template validation for the <c>TERRAFORM_OS</c> product
        /// type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ProvisioningArtifactParameters_DisableTemplateValidation { get; set; }
        #endregion
        
        #region Parameter Distributor
        /// <summary>
        /// <para>
        /// <para>The distributor of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Distributor { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier that you provide to ensure idempotency. If multiple requests differ
        /// only by the idempotency token, the same response is returned for each repeated request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactParameters_Info
        /// <summary>
        /// <para>
        /// <para>Specify the template source with one of the following options, but not both. Keys
        /// accepted: [ <c>LoadTemplateFromURL</c>, <c>ImportFromPhysicalId</c> ]</para><para>The URL of the CloudFormation template in Amazon S3 or GitHub in JSON format. Specify
        /// the URL in JSON format as follows:</para><para><c>"LoadTemplateFromURL": "https://s3.amazonaws.com/cf-templates-ozkq9d3hgiq2-us-east-1/..."</c></para><para><c>ImportFromPhysicalId</c>: The physical id of the resource that contains the template.
        /// Currently only supports CloudFormation stack arn. Specify the physical id in JSON
        /// format as follows: <c>ImportFromPhysicalId: “arn:aws:cloudformation:[us-east-1]:[accountId]:stack/[StackName]/[resourceId]</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ProvisioningArtifactParameters_Info { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the product.</para>
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
        
        #region Parameter ProvisioningArtifactParameters_Name
        /// <summary>
        /// <para>
        /// <para>The name of the provisioning artifact (for example, v1 v2beta). No spaces are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningArtifactParameters_Name { get; set; }
        #endregion
        
        #region Parameter ProductType
        /// <summary>
        /// <para>
        /// <para>The type of product.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ProductType")]
        public Amazon.ServiceCatalog.ProductType ProductType { get; set; }
        #endregion
        
        #region Parameter CodeStar_Repository
        /// <summary>
        /// <para>
        /// <para>The specific repository where the product’s artifact-to-be-synced resides, formatted
        /// as "Account/Repo." </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConnection_ConnectionParameters_CodeStar_Repository")]
        public System.String CodeStar_Repository { get; set; }
        #endregion
        
        #region Parameter SupportDescription
        /// <summary>
        /// <para>
        /// <para>The support information about the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SupportDescription { get; set; }
        #endregion
        
        #region Parameter SupportEmail
        /// <summary>
        /// <para>
        /// <para>The contact email for product support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SupportEmail { get; set; }
        #endregion
        
        #region Parameter SupportUrl
        /// <summary>
        /// <para>
        /// <para>The contact URL for product support.</para><para><c>^https?:\/\// </c>/ is the pattern used to validate SupportUrl.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SupportUrl { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ServiceCatalog.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactParameters_Type
        /// <summary>
        /// <para>
        /// <para>The type of provisioning artifact.</para><ul><li><para><c>CLOUD_FORMATION_TEMPLATE</c> - CloudFormation template</para></li><li><para><c>TERRAFORM_OPEN_SOURCE</c> - Terraform Open Source configuration file</para></li><li><para><c>TERRAFORM_CLOUD</c> - Terraform Cloud configuration file</para></li><li><para><c>EXTERNAL</c> - External configuration file</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ProvisioningArtifactType")]
        public Amazon.ServiceCatalog.ProvisioningArtifactType ProvisioningArtifactParameters_Type { get; set; }
        #endregion
        
        #region Parameter SourceConnection_Type
        /// <summary>
        /// <para>
        /// <para>The only supported <c>SourceConnection</c> type is Codestar. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceCatalog.SourceType")]
        public Amazon.ServiceCatalog.SourceType SourceConnection_Type { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>The owner of the product.</para>
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
        public System.String Owner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.CreateProductResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.CreateProductResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SCProduct (CreateProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.CreateProductResponse, NewSCProductCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptLanguage = this.AcceptLanguage;
            context.Description = this.Description;
            context.Distributor = this.Distributor;
            context.IdempotencyToken = this.IdempotencyToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Owner = this.Owner;
            #if MODULAR
            if (this.Owner == null && ParameterWasBound(nameof(this.Owner)))
            {
                WriteWarning("You are passing $null as a value for parameter Owner which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProductType = this.ProductType;
            #if MODULAR
            if (this.ProductType == null && ParameterWasBound(nameof(this.ProductType)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvisioningArtifactParameters_Description = this.ProvisioningArtifactParameters_Description;
            context.ProvisioningArtifactParameters_DisableTemplateValidation = this.ProvisioningArtifactParameters_DisableTemplateValidation;
            if (this.ProvisioningArtifactParameters_Info != null)
            {
                context.ProvisioningArtifactParameters_Info = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ProvisioningArtifactParameters_Info.Keys)
                {
                    context.ProvisioningArtifactParameters_Info.Add((String)hashKey, (String)(this.ProvisioningArtifactParameters_Info[hashKey]));
                }
            }
            context.ProvisioningArtifactParameters_Name = this.ProvisioningArtifactParameters_Name;
            context.ProvisioningArtifactParameters_Type = this.ProvisioningArtifactParameters_Type;
            context.CodeStar_ArtifactPath = this.CodeStar_ArtifactPath;
            context.CodeStar_Branch = this.CodeStar_Branch;
            context.CodeStar_ConnectionArn = this.CodeStar_ConnectionArn;
            context.CodeStar_Repository = this.CodeStar_Repository;
            context.SourceConnection_Type = this.SourceConnection_Type;
            context.SupportDescription = this.SupportDescription;
            context.SupportEmail = this.SupportEmail;
            context.SupportUrl = this.SupportUrl;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ServiceCatalog.Model.Tag>(this.Tag);
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
            var request = new Amazon.ServiceCatalog.Model.CreateProductRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Distributor != null)
            {
                request.Distributor = cmdletContext.Distributor;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owner = cmdletContext.Owner;
            }
            if (cmdletContext.ProductType != null)
            {
                request.ProductType = cmdletContext.ProductType;
            }
            
             // populate ProvisioningArtifactParameters
            var requestProvisioningArtifactParametersIsNull = true;
            request.ProvisioningArtifactParameters = new Amazon.ServiceCatalog.Model.ProvisioningArtifactProperties();
            System.String requestProvisioningArtifactParameters_provisioningArtifactParameters_Description = null;
            if (cmdletContext.ProvisioningArtifactParameters_Description != null)
            {
                requestProvisioningArtifactParameters_provisioningArtifactParameters_Description = cmdletContext.ProvisioningArtifactParameters_Description;
            }
            if (requestProvisioningArtifactParameters_provisioningArtifactParameters_Description != null)
            {
                request.ProvisioningArtifactParameters.Description = requestProvisioningArtifactParameters_provisioningArtifactParameters_Description;
                requestProvisioningArtifactParametersIsNull = false;
            }
            System.Boolean? requestProvisioningArtifactParameters_provisioningArtifactParameters_DisableTemplateValidation = null;
            if (cmdletContext.ProvisioningArtifactParameters_DisableTemplateValidation != null)
            {
                requestProvisioningArtifactParameters_provisioningArtifactParameters_DisableTemplateValidation = cmdletContext.ProvisioningArtifactParameters_DisableTemplateValidation.Value;
            }
            if (requestProvisioningArtifactParameters_provisioningArtifactParameters_DisableTemplateValidation != null)
            {
                request.ProvisioningArtifactParameters.DisableTemplateValidation = requestProvisioningArtifactParameters_provisioningArtifactParameters_DisableTemplateValidation.Value;
                requestProvisioningArtifactParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestProvisioningArtifactParameters_provisioningArtifactParameters_Info = null;
            if (cmdletContext.ProvisioningArtifactParameters_Info != null)
            {
                requestProvisioningArtifactParameters_provisioningArtifactParameters_Info = cmdletContext.ProvisioningArtifactParameters_Info;
            }
            if (requestProvisioningArtifactParameters_provisioningArtifactParameters_Info != null)
            {
                request.ProvisioningArtifactParameters.Info = requestProvisioningArtifactParameters_provisioningArtifactParameters_Info;
                requestProvisioningArtifactParametersIsNull = false;
            }
            System.String requestProvisioningArtifactParameters_provisioningArtifactParameters_Name = null;
            if (cmdletContext.ProvisioningArtifactParameters_Name != null)
            {
                requestProvisioningArtifactParameters_provisioningArtifactParameters_Name = cmdletContext.ProvisioningArtifactParameters_Name;
            }
            if (requestProvisioningArtifactParameters_provisioningArtifactParameters_Name != null)
            {
                request.ProvisioningArtifactParameters.Name = requestProvisioningArtifactParameters_provisioningArtifactParameters_Name;
                requestProvisioningArtifactParametersIsNull = false;
            }
            Amazon.ServiceCatalog.ProvisioningArtifactType requestProvisioningArtifactParameters_provisioningArtifactParameters_Type = null;
            if (cmdletContext.ProvisioningArtifactParameters_Type != null)
            {
                requestProvisioningArtifactParameters_provisioningArtifactParameters_Type = cmdletContext.ProvisioningArtifactParameters_Type;
            }
            if (requestProvisioningArtifactParameters_provisioningArtifactParameters_Type != null)
            {
                request.ProvisioningArtifactParameters.Type = requestProvisioningArtifactParameters_provisioningArtifactParameters_Type;
                requestProvisioningArtifactParametersIsNull = false;
            }
             // determine if request.ProvisioningArtifactParameters should be set to null
            if (requestProvisioningArtifactParametersIsNull)
            {
                request.ProvisioningArtifactParameters = null;
            }
            
             // populate SourceConnection
            var requestSourceConnectionIsNull = true;
            request.SourceConnection = new Amazon.ServiceCatalog.Model.SourceConnection();
            Amazon.ServiceCatalog.SourceType requestSourceConnection_sourceConnection_Type = null;
            if (cmdletContext.SourceConnection_Type != null)
            {
                requestSourceConnection_sourceConnection_Type = cmdletContext.SourceConnection_Type;
            }
            if (requestSourceConnection_sourceConnection_Type != null)
            {
                request.SourceConnection.Type = requestSourceConnection_sourceConnection_Type;
                requestSourceConnectionIsNull = false;
            }
            Amazon.ServiceCatalog.Model.SourceConnectionParameters requestSourceConnection_sourceConnection_ConnectionParameters = null;
            
             // populate ConnectionParameters
            var requestSourceConnection_sourceConnection_ConnectionParametersIsNull = true;
            requestSourceConnection_sourceConnection_ConnectionParameters = new Amazon.ServiceCatalog.Model.SourceConnectionParameters();
            Amazon.ServiceCatalog.Model.CodeStarParameters requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar = null;
            
             // populate CodeStar
            var requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStarIsNull = true;
            requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar = new Amazon.ServiceCatalog.Model.CodeStarParameters();
            System.String requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_ArtifactPath = null;
            if (cmdletContext.CodeStar_ArtifactPath != null)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_ArtifactPath = cmdletContext.CodeStar_ArtifactPath;
            }
            if (requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_ArtifactPath != null)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar.ArtifactPath = requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_ArtifactPath;
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStarIsNull = false;
            }
            System.String requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_Branch = null;
            if (cmdletContext.CodeStar_Branch != null)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_Branch = cmdletContext.CodeStar_Branch;
            }
            if (requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_Branch != null)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar.Branch = requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_Branch;
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStarIsNull = false;
            }
            System.String requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_ConnectionArn = null;
            if (cmdletContext.CodeStar_ConnectionArn != null)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_ConnectionArn = cmdletContext.CodeStar_ConnectionArn;
            }
            if (requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_ConnectionArn != null)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar.ConnectionArn = requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_ConnectionArn;
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStarIsNull = false;
            }
            System.String requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_Repository = null;
            if (cmdletContext.CodeStar_Repository != null)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_Repository = cmdletContext.CodeStar_Repository;
            }
            if (requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_Repository != null)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar.Repository = requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar_codeStar_Repository;
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStarIsNull = false;
            }
             // determine if requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar should be set to null
            if (requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStarIsNull)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar = null;
            }
            if (requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar != null)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters.CodeStar = requestSourceConnection_sourceConnection_ConnectionParameters_sourceConnection_ConnectionParameters_CodeStar;
                requestSourceConnection_sourceConnection_ConnectionParametersIsNull = false;
            }
             // determine if requestSourceConnection_sourceConnection_ConnectionParameters should be set to null
            if (requestSourceConnection_sourceConnection_ConnectionParametersIsNull)
            {
                requestSourceConnection_sourceConnection_ConnectionParameters = null;
            }
            if (requestSourceConnection_sourceConnection_ConnectionParameters != null)
            {
                request.SourceConnection.ConnectionParameters = requestSourceConnection_sourceConnection_ConnectionParameters;
                requestSourceConnectionIsNull = false;
            }
             // determine if request.SourceConnection should be set to null
            if (requestSourceConnectionIsNull)
            {
                request.SourceConnection = null;
            }
            if (cmdletContext.SupportDescription != null)
            {
                request.SupportDescription = cmdletContext.SupportDescription;
            }
            if (cmdletContext.SupportEmail != null)
            {
                request.SupportEmail = cmdletContext.SupportEmail;
            }
            if (cmdletContext.SupportUrl != null)
            {
                request.SupportUrl = cmdletContext.SupportUrl;
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
        
        private Amazon.ServiceCatalog.Model.CreateProductResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.CreateProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "CreateProduct");
            try
            {
                #if DESKTOP
                return client.CreateProduct(request);
                #elif CORECLR
                return client.CreateProductAsync(request).GetAwaiter().GetResult();
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
            public System.String AcceptLanguage { get; set; }
            public System.String Description { get; set; }
            public System.String Distributor { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String Name { get; set; }
            public System.String Owner { get; set; }
            public Amazon.ServiceCatalog.ProductType ProductType { get; set; }
            public System.String ProvisioningArtifactParameters_Description { get; set; }
            public System.Boolean? ProvisioningArtifactParameters_DisableTemplateValidation { get; set; }
            public Dictionary<System.String, System.String> ProvisioningArtifactParameters_Info { get; set; }
            public System.String ProvisioningArtifactParameters_Name { get; set; }
            public Amazon.ServiceCatalog.ProvisioningArtifactType ProvisioningArtifactParameters_Type { get; set; }
            public System.String CodeStar_ArtifactPath { get; set; }
            public System.String CodeStar_Branch { get; set; }
            public System.String CodeStar_ConnectionArn { get; set; }
            public System.String CodeStar_Repository { get; set; }
            public Amazon.ServiceCatalog.SourceType SourceConnection_Type { get; set; }
            public System.String SupportDescription { get; set; }
            public System.String SupportEmail { get; set; }
            public System.String SupportUrl { get; set; }
            public List<Amazon.ServiceCatalog.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.CreateProductResponse, NewSCProductCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
