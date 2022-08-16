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
    /// Copies the specified source product to the specified target product or a new product.
    /// 
    ///  
    /// <para>
    /// You can copy a product to the same account or another account. You can copy a product
    /// to the same Region or another Region. If you copy a product to another account, you
    /// must first share the product in a portfolio using <a>CreatePortfolioShare</a>.
    /// </para><para>
    /// This operation is performed asynchronously. To track the progress of the operation,
    /// use <a>DescribeCopyProductStatus</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "SCProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Service Catalog CopyProduct API operation.", Operation = new[] {"CopyProduct"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.CopyProductResponse))]
    [AWSCmdletOutput("System.String or Amazon.ServiceCatalog.Model.CopyProductResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ServiceCatalog.Model.CopyProductResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopySCProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><code>en</code> - English (default)</para></li><li><para><code>jp</code> - Japanese</para></li><li><para><code>zh</code> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter CopyOption
        /// <summary>
        /// <para>
        /// <para>The copy options. If the value is <code>CopyTags</code>, the tags from the source
        /// product are copied to the target product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyOptions")]
        public System.String[] CopyOption { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier that you provide to ensure idempotency. If multiple requests
        /// differ only by the idempotency token, the same response is returned for each repeated
        /// request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter SourceProductArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source product.</para>
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
        public System.String SourceProductArn { get; set; }
        #endregion
        
        #region Parameter SourceProvisioningArtifactIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifiers of the provisioning artifacts (also known as versions) of the product
        /// to copy. By default, all provisioning artifacts are copied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceProvisioningArtifactIdentifiers")]
        public System.Collections.Hashtable[] SourceProvisioningArtifactIdentifier { get; set; }
        #endregion
        
        #region Parameter TargetProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the target product. By default, a new product is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetProductId { get; set; }
        #endregion
        
        #region Parameter TargetProductName
        /// <summary>
        /// <para>
        /// <para>A name for the target product. The default is the name of the source product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetProductName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CopyProductToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.CopyProductResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.CopyProductResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CopyProductToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IdempotencyToken parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IdempotencyToken' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IdempotencyToken' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetProductName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-SCProduct (CopyProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.CopyProductResponse, CopySCProductCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IdempotencyToken;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptLanguage = this.AcceptLanguage;
            if (this.CopyOption != null)
            {
                context.CopyOption = new List<System.String>(this.CopyOption);
            }
            context.IdempotencyToken = this.IdempotencyToken;
            context.SourceProductArn = this.SourceProductArn;
            #if MODULAR
            if (this.SourceProductArn == null && ParameterWasBound(nameof(this.SourceProductArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceProductArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SourceProvisioningArtifactIdentifier != null)
            {
                context.SourceProvisioningArtifactIdentifier = new List<Dictionary<System.String, System.String>>();
                foreach (var hashTable in this.SourceProvisioningArtifactIdentifier)
                {
                    var d = new Dictionary<System.String, System.String>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        d.Add((String)hashKey, (String)(hashTable[hashKey]));
                    }
                    context.SourceProvisioningArtifactIdentifier.Add(d);
                }
            }
            context.TargetProductId = this.TargetProductId;
            context.TargetProductName = this.TargetProductName;
            
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
            var request = new Amazon.ServiceCatalog.Model.CopyProductRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.CopyOption != null)
            {
                request.CopyOptions = cmdletContext.CopyOption;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.SourceProductArn != null)
            {
                request.SourceProductArn = cmdletContext.SourceProductArn;
            }
            if (cmdletContext.SourceProvisioningArtifactIdentifier != null)
            {
                request.SourceProvisioningArtifactIdentifiers = cmdletContext.SourceProvisioningArtifactIdentifier;
            }
            if (cmdletContext.TargetProductId != null)
            {
                request.TargetProductId = cmdletContext.TargetProductId;
            }
            if (cmdletContext.TargetProductName != null)
            {
                request.TargetProductName = cmdletContext.TargetProductName;
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
        
        private Amazon.ServiceCatalog.Model.CopyProductResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.CopyProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "CopyProduct");
            try
            {
                #if DESKTOP
                return client.CopyProduct(request);
                #elif CORECLR
                return client.CopyProductAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CopyOption { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String SourceProductArn { get; set; }
            public List<Dictionary<System.String, System.String>> SourceProvisioningArtifactIdentifier { get; set; }
            public System.String TargetProductId { get; set; }
            public System.String TargetProductName { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.CopyProductResponse, CopySCProductCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CopyProductToken;
        }
        
    }
}
