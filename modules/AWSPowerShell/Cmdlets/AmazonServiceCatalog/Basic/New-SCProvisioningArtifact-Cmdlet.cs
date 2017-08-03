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
    /// Create a new provisioning artifact for the specified product. This operation does
    /// not work with a product that has been shared with you.
    /// 
    ///  
    /// <para>
    /// See the bottom of this topic for an example JSON request.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SCProvisioningArtifact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.CreateProvisioningArtifactResponse")]
    [AWSCmdlet("Invokes the CreateProvisioningArtifact operation against AWS Service Catalog.", Operation = new[] {"CreateProvisioningArtifact"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.CreateProvisioningArtifactResponse",
        "This cmdlet returns a Amazon.ServiceCatalog.Model.CreateProvisioningArtifactResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSCProvisioningArtifactCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
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
        
        #region Parameter Parameters_Description
        /// <summary>
        /// <para>
        /// <para>The text description of the provisioning artifact properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Parameters_Description { get; set; }
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
        
        #region Parameter Parameters_Info
        /// <summary>
        /// <para>
        /// <para>Additional information about the provisioning artifact properties. When using this
        /// element in a request, you must specify <code>LoadTemplateFromURL</code>. For more
        /// information, see <a>CreateProvisioningArtifact</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable Parameters_Info { get; set; }
        #endregion
        
        #region Parameter Parameters_Name
        /// <summary>
        /// <para>
        /// <para>The name assigned to the provisioning artifact properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Parameters_Name { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The product identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter Parameters_Type
        /// <summary>
        /// <para>
        /// <para>The type of the provisioning artifact properties. The following provisioning artifact
        /// property types are used by AWS Marketplace products:</para><para><code>MARKETPLACE_AMI</code> - AMI products.</para><para><code>MARKETPLACE_CAR</code> - CAR (Cluster and AWS Resources) products.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ProvisioningArtifactType")]
        public Amazon.ServiceCatalog.ProvisioningArtifactType Parameters_Type { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProductId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SCProvisioningArtifact (CreateProvisioningArtifact)"))
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
            context.IdempotencyToken = this.IdempotencyToken;
            context.Parameters_Description = this.Parameters_Description;
            if (this.Parameters_Info != null)
            {
                context.Parameters_Info = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameters_Info.Keys)
                {
                    context.Parameters_Info.Add((String)hashKey, (String)(this.Parameters_Info[hashKey]));
                }
            }
            context.Parameters_Name = this.Parameters_Name;
            context.Parameters_Type = this.Parameters_Type;
            context.ProductId = this.ProductId;
            
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
            var request = new Amazon.ServiceCatalog.Model.CreateProvisioningArtifactRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            
             // populate Parameters
            bool requestParametersIsNull = true;
            request.Parameters = new Amazon.ServiceCatalog.Model.ProvisioningArtifactProperties();
            System.String requestParameters_parameters_Description = null;
            if (cmdletContext.Parameters_Description != null)
            {
                requestParameters_parameters_Description = cmdletContext.Parameters_Description;
            }
            if (requestParameters_parameters_Description != null)
            {
                request.Parameters.Description = requestParameters_parameters_Description;
                requestParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestParameters_parameters_Info = null;
            if (cmdletContext.Parameters_Info != null)
            {
                requestParameters_parameters_Info = cmdletContext.Parameters_Info;
            }
            if (requestParameters_parameters_Info != null)
            {
                request.Parameters.Info = requestParameters_parameters_Info;
                requestParametersIsNull = false;
            }
            System.String requestParameters_parameters_Name = null;
            if (cmdletContext.Parameters_Name != null)
            {
                requestParameters_parameters_Name = cmdletContext.Parameters_Name;
            }
            if (requestParameters_parameters_Name != null)
            {
                request.Parameters.Name = requestParameters_parameters_Name;
                requestParametersIsNull = false;
            }
            Amazon.ServiceCatalog.ProvisioningArtifactType requestParameters_parameters_Type = null;
            if (cmdletContext.Parameters_Type != null)
            {
                requestParameters_parameters_Type = cmdletContext.Parameters_Type;
            }
            if (requestParameters_parameters_Type != null)
            {
                request.Parameters.Type = requestParameters_parameters_Type;
                requestParametersIsNull = false;
            }
             // determine if request.Parameters should be set to null
            if (requestParametersIsNull)
            {
                request.Parameters = null;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
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
        
        private Amazon.ServiceCatalog.Model.CreateProvisioningArtifactResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.CreateProvisioningArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "CreateProvisioningArtifact");
            #if DESKTOP
            return client.CreateProvisioningArtifact(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateProvisioningArtifactAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AcceptLanguage { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String Parameters_Description { get; set; }
            public Dictionary<System.String, System.String> Parameters_Info { get; set; }
            public System.String Parameters_Name { get; set; }
            public Amazon.ServiceCatalog.ProvisioningArtifactType Parameters_Type { get; set; }
            public System.String ProductId { get; set; }
        }
        
    }
}
