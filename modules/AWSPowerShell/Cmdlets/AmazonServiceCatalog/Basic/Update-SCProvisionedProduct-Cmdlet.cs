/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Requests updates to the configuration of an existing ProvisionedProduct object. If
    /// there are tags associated with the object, they cannot be updated or added with this
    /// operation. Depending on the specific updates requested, this operation may update
    /// with no interruption, with some interruption, or replace the ProvisionedProduct object
    /// entirely. 
    /// 
    ///  
    /// <para>
    /// You can check the status of this request using the <a>DescribeRecord</a> operation.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SCProvisionedProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.RecordDetail")]
    [AWSCmdlet("Invokes the UpdateProvisionedProduct operation against AWS Service Catalog.", Operation = new[] {"UpdateProvisionedProduct"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.RecordDetail",
        "This cmdlet returns a RecordDetail object.",
        "The service call response (type Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSCProvisionedProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code to use for this operation. Supported language codes are as follows:</para><para>"en" (English)</para><para>"jp" (Japanese)</para><para>"zh" (Chinese)</para><para>If no code is specified, "en" is used as the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter PathId
        /// <summary>
        /// <para>
        /// <para>The identifier of the path to use in the updated ProvisionedProduct object. This value
        /// is optional if the product has a default path, and is required if there is more than
        /// one path for the specified product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PathId { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the ProvisionedProduct object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the ProvisionedProduct object to update. Specify either <code>ProvisionedProductName</code>
        /// or <code>ProvisionedProductId</code>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProvisionedProductId { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductName
        /// <summary>
        /// <para>
        /// <para>The updated name of the ProvisionedProduct object. Specify either <code>ProvisionedProductName</code>
        /// or <code>ProvisionedProductId</code>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProvisionedProductName { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The provisioning artifact identifier for this product. This is sometimes referred
        /// to as the product version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProvisioningArtifactId { get; set; }
        #endregion
        
        #region Parameter ProvisioningParameter
        /// <summary>
        /// <para>
        /// <para>A list of <code>ProvisioningParameter</code> objects used to update the ProvisionedProduct
        /// object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProvisioningParameters")]
        public Amazon.ServiceCatalog.Model.UpdateProvisioningParameter[] ProvisioningParameter { get; set; }
        #endregion
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token that uniquely identifies the provisioning update request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UpdateToken { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProvisionedProductId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCProvisionedProduct (UpdateProvisionedProduct)"))
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
            context.PathId = this.PathId;
            context.ProductId = this.ProductId;
            context.ProvisionedProductId = this.ProvisionedProductId;
            context.ProvisionedProductName = this.ProvisionedProductName;
            context.ProvisioningArtifactId = this.ProvisioningArtifactId;
            if (this.ProvisioningParameter != null)
            {
                context.ProvisioningParameters = new List<Amazon.ServiceCatalog.Model.UpdateProvisioningParameter>(this.ProvisioningParameter);
            }
            context.UpdateToken = this.UpdateToken;
            
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
            var request = new Amazon.ServiceCatalog.Model.UpdateProvisionedProductRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.PathId != null)
            {
                request.PathId = cmdletContext.PathId;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
            }
            if (cmdletContext.ProvisionedProductId != null)
            {
                request.ProvisionedProductId = cmdletContext.ProvisionedProductId;
            }
            if (cmdletContext.ProvisionedProductName != null)
            {
                request.ProvisionedProductName = cmdletContext.ProvisionedProductName;
            }
            if (cmdletContext.ProvisioningArtifactId != null)
            {
                request.ProvisioningArtifactId = cmdletContext.ProvisioningArtifactId;
            }
            if (cmdletContext.ProvisioningParameters != null)
            {
                request.ProvisioningParameters = cmdletContext.ProvisioningParameters;
            }
            if (cmdletContext.UpdateToken != null)
            {
                request.UpdateToken = cmdletContext.UpdateToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RecordDetail;
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
        
        private Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.UpdateProvisionedProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "UpdateProvisionedProduct");
            try
            {
                #if DESKTOP
                return client.UpdateProvisionedProduct(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateProvisionedProductAsync(request);
                return task.Result;
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
            public System.String PathId { get; set; }
            public System.String ProductId { get; set; }
            public System.String ProvisionedProductId { get; set; }
            public System.String ProvisionedProductName { get; set; }
            public System.String ProvisioningArtifactId { get; set; }
            public List<Amazon.ServiceCatalog.Model.UpdateProvisioningParameter> ProvisioningParameters { get; set; }
            public System.String UpdateToken { get; set; }
        }
        
    }
}
