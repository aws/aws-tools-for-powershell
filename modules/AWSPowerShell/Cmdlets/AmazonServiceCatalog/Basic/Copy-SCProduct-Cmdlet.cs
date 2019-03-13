/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// to the same region or another region.
    /// </para><para>
    /// This operation is performed asynchronously. To track the progress of the operation,
    /// use <a>DescribeCopyProductStatus</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "SCProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Service Catalog CopyProduct API operation.", Operation = new[] {"CopyProduct"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
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
        [System.Management.Automation.Parameter]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter CopyOption
        /// <summary>
        /// <para>
        /// <para>The copy options. If the value is <code>CopyTags</code>, the tags from the source
        /// product are copied to the target product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter SourceProductArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceProductArn { get; set; }
        #endregion
        
        #region Parameter SourceProvisioningArtifactIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifiers of the provisioning artifacts (also known as versions) of the product
        /// to copy. By default, all provisioning artifacts are copied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SourceProvisioningArtifactIdentifiers")]
        public System.Collections.Hashtable[] SourceProvisioningArtifactIdentifier { get; set; }
        #endregion
        
        #region Parameter TargetProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the target product. By default, a new product is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetProductId { get; set; }
        #endregion
        
        #region Parameter TargetProductName
        /// <summary>
        /// <para>
        /// <para>A name for the target product. The default is the name of the source product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetProductName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TargetProductName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-SCProduct (CopyProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AcceptLanguage = this.AcceptLanguage;
            if (this.CopyOption != null)
            {
                context.CopyOptions = new List<System.String>(this.CopyOption);
            }
            context.IdempotencyToken = this.IdempotencyToken;
            context.SourceProductArn = this.SourceProductArn;
            if (this.SourceProvisioningArtifactIdentifier != null)
            {
                context.SourceProvisioningArtifactIdentifiers = new List<Dictionary<System.String, System.String>>();
                foreach (var hashTable in this.SourceProvisioningArtifactIdentifier)
                {
                    var d = new Dictionary<System.String, System.String>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        d.Add((String)hashKey, (String)(hashTable[hashKey]));
                    }
                    context.SourceProvisioningArtifactIdentifiers.Add(d);
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
            if (cmdletContext.CopyOptions != null)
            {
                request.CopyOptions = cmdletContext.CopyOptions;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.SourceProductArn != null)
            {
                request.SourceProductArn = cmdletContext.SourceProductArn;
            }
            if (cmdletContext.SourceProvisioningArtifactIdentifiers != null)
            {
                request.SourceProvisioningArtifactIdentifiers = cmdletContext.SourceProvisioningArtifactIdentifiers;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CopyProductToken;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            public List<System.String> CopyOptions { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String SourceProductArn { get; set; }
            public List<Dictionary<System.String, System.String>> SourceProvisioningArtifactIdentifiers { get; set; }
            public System.String TargetProductId { get; set; }
            public System.String TargetProductName { get; set; }
        }
        
    }
}
