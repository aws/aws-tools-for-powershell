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
    /// Updates an existing provisioning artifact's information. This operation does not work
    /// on a provisioning artifact associated with a product that has been shared with you.
    /// </summary>
    [Cmdlet("Update", "SCProvisioningArtifact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse")]
    [AWSCmdlet("Invokes the UpdateProvisioningArtifact operation against AWS Service Catalog.", Operation = new[] {"UpdateProvisioningArtifact"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse",
        "This cmdlet returns a Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSCProvisioningArtifactCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
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
        /// <para>The updated text description of the provisioning artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name of the provisioning artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The product identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the provisioning artifact for the update request. This is sometimes
        /// referred to as the product version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProvisioningArtifactId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProvisioningArtifactId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCProvisioningArtifact (UpdateProvisioningArtifact)"))
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
            context.Name = this.Name;
            context.ProductId = this.ProductId;
            context.ProvisioningArtifactId = this.ProvisioningArtifactId;
            
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
            var request = new Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
            }
            if (cmdletContext.ProvisioningArtifactId != null)
            {
                request.ProvisioningArtifactId = cmdletContext.ProvisioningArtifactId;
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
        
        private Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "UpdateProvisioningArtifact");
            #if DESKTOP
            return client.UpdateProvisioningArtifact(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateProvisioningArtifactAsync(request);
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
            public System.String Name { get; set; }
            public System.String ProductId { get; set; }
            public System.String ProvisioningArtifactId { get; set; }
        }
        
    }
}
