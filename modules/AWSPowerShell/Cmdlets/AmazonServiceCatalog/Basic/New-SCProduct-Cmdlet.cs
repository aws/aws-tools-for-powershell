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
    /// Creates a new product.
    /// </summary>
    [Cmdlet("New", "SCProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.CreateProductResponse")]
    [AWSCmdlet("Invokes the CreateProduct operation against AWS Service Catalog.", Operation = new[] {"CreateProduct"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.CreateProductResponse",
        "This cmdlet returns a Amazon.ServiceCatalog.Model.CreateProductResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSCProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The text description of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactParameters_Description
        /// <summary>
        /// <para>
        /// <para>The text description of the provisioning artifact properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProvisioningArtifactParameters_Description { get; set; }
        #endregion
        
        #region Parameter Distributor
        /// <summary>
        /// <para>
        /// <para>The distributor of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Distributor { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A token to disambiguate duplicate requests. You can create multiple resources using
        /// the same input in multiple requests, provided that you also specify a different idempotency
        /// token for each request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactParameters_Info
        /// <summary>
        /// <para>
        /// <para>Additional information about the provisioning artifact properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable ProvisioningArtifactParameters_Info { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactParameters_Name
        /// <summary>
        /// <para>
        /// <para>The name assigned to the provisioning artifact properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProvisioningArtifactParameters_Name { get; set; }
        #endregion
        
        #region Parameter ProductType
        /// <summary>
        /// <para>
        /// <para>The type of the product to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ProductType")]
        public Amazon.ServiceCatalog.ProductType ProductType { get; set; }
        #endregion
        
        #region Parameter SupportDescription
        /// <summary>
        /// <para>
        /// <para>Support information about the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SupportDescription { get; set; }
        #endregion
        
        #region Parameter SupportEmail
        /// <summary>
        /// <para>
        /// <para>Contact email for product support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SupportEmail { get; set; }
        #endregion
        
        #region Parameter SupportUrl
        /// <summary>
        /// <para>
        /// <para>Contact URL for product support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SupportUrl { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associate with the new product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ServiceCatalog.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactParameters_Type
        /// <summary>
        /// <para>
        /// <para>The type of the provisioning artifact properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ProvisioningArtifactType")]
        public Amazon.ServiceCatalog.ProvisioningArtifactType ProvisioningArtifactParameters_Type { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>The owner of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Owner { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SCProduct (CreateProduct)"))
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
            context.Description = this.Description;
            context.Distributor = this.Distributor;
            context.IdempotencyToken = this.IdempotencyToken;
            context.Name = this.Name;
            context.Owner = this.Owner;
            context.ProductType = this.ProductType;
            context.ProvisioningArtifactParameters_Description = this.ProvisioningArtifactParameters_Description;
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
            context.SupportDescription = this.SupportDescription;
            context.SupportEmail = this.SupportEmail;
            context.SupportUrl = this.SupportUrl;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ServiceCatalog.Model.Tag>(this.Tag);
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
            bool requestProvisioningArtifactParametersIsNull = true;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.ServiceCatalog.Model.CreateProductResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.CreateProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "CreateProduct");
            #if DESKTOP
            return client.CreateProduct(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateProductAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AcceptLanguage { get; set; }
            public System.String Description { get; set; }
            public System.String Distributor { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String Name { get; set; }
            public System.String Owner { get; set; }
            public Amazon.ServiceCatalog.ProductType ProductType { get; set; }
            public System.String ProvisioningArtifactParameters_Description { get; set; }
            public Dictionary<System.String, System.String> ProvisioningArtifactParameters_Info { get; set; }
            public System.String ProvisioningArtifactParameters_Name { get; set; }
            public Amazon.ServiceCatalog.ProvisioningArtifactType ProvisioningArtifactParameters_Type { get; set; }
            public System.String SupportDescription { get; set; }
            public System.String SupportEmail { get; set; }
            public System.String SupportUrl { get; set; }
            public List<Amazon.ServiceCatalog.Model.Tag> Tags { get; set; }
        }
        
    }
}
