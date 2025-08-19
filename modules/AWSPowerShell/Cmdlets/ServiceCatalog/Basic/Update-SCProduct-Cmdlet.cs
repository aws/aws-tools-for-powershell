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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Updates the specified product.
    /// </summary>
    [Cmdlet("Update", "SCProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.UpdateProductResponse")]
    [AWSCmdlet("Calls the AWS Service Catalog UpdateProduct API operation.", Operation = new[] {"UpdateProduct"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.UpdateProductResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.UpdateProductResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.Model.UpdateProductResponse object containing multiple properties."
    )]
    public partial class UpdateSCProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><c>jp</c> - Japanese</para></li><li><para><c>zh</c> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter AddTag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the product.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddTags")]
        public Amazon.ServiceCatalog.Model.Tag[] AddTag { get; set; }
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
        /// <para>The updated description of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Distributor
        /// <summary>
        /// <para>
        /// <para>The updated distributor of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Distributor { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The product identifier.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated product name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RemoveTag
        /// <summary>
        /// <para>
        /// <para>The tags to remove from the product.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveTags")]
        public System.String[] RemoveTag { get; set; }
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
        /// <para>The updated support description for the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SupportDescription { get; set; }
        #endregion
        
        #region Parameter SupportEmail
        /// <summary>
        /// <para>
        /// <para>The updated support email for the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SupportEmail { get; set; }
        #endregion
        
        #region Parameter SupportUrl
        /// <summary>
        /// <para>
        /// <para>The updated support URL for the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SupportUrl { get; set; }
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
        /// <para>The updated owner of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Owner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.UpdateProductResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.UpdateProductResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCProduct (UpdateProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.UpdateProductResponse, UpdateSCProductCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptLanguage = this.AcceptLanguage;
            if (this.AddTag != null)
            {
                context.AddTag = new List<Amazon.ServiceCatalog.Model.Tag>(this.AddTag);
            }
            context.Description = this.Description;
            context.Distributor = this.Distributor;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.Owner = this.Owner;
            if (this.RemoveTag != null)
            {
                context.RemoveTag = new List<System.String>(this.RemoveTag);
            }
            context.CodeStar_ArtifactPath = this.CodeStar_ArtifactPath;
            context.CodeStar_Branch = this.CodeStar_Branch;
            context.CodeStar_ConnectionArn = this.CodeStar_ConnectionArn;
            context.CodeStar_Repository = this.CodeStar_Repository;
            context.SourceConnection_Type = this.SourceConnection_Type;
            context.SupportDescription = this.SupportDescription;
            context.SupportEmail = this.SupportEmail;
            context.SupportUrl = this.SupportUrl;
            
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
            var request = new Amazon.ServiceCatalog.Model.UpdateProductRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.AddTag != null)
            {
                request.AddTags = cmdletContext.AddTag;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Distributor != null)
            {
                request.Distributor = cmdletContext.Distributor;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owner = cmdletContext.Owner;
            }
            if (cmdletContext.RemoveTag != null)
            {
                request.RemoveTags = cmdletContext.RemoveTag;
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
        
        private Amazon.ServiceCatalog.Model.UpdateProductResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.UpdateProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "UpdateProduct");
            try
            {
                return client.UpdateProductAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ServiceCatalog.Model.Tag> AddTag { get; set; }
            public System.String Description { get; set; }
            public System.String Distributor { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.String Owner { get; set; }
            public List<System.String> RemoveTag { get; set; }
            public System.String CodeStar_ArtifactPath { get; set; }
            public System.String CodeStar_Branch { get; set; }
            public System.String CodeStar_ConnectionArn { get; set; }
            public System.String CodeStar_Repository { get; set; }
            public Amazon.ServiceCatalog.SourceType SourceConnection_Type { get; set; }
            public System.String SupportDescription { get; set; }
            public System.String SupportEmail { get; set; }
            public System.String SupportUrl { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.UpdateProductResponse, UpdateSCProductCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
