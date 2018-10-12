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
    /// Associates a self-service action with a provisioning artifact.
    /// </summary>
    [Cmdlet("Add", "SCServiceActionAssociationWithProvisioningArtifact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Service Catalog AssociateServiceActionWithProvisioningArtifact API operation.", Operation = new[] {"AssociateServiceActionWithProvisioningArtifact"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.ServiceCatalog.Model.AssociateServiceActionWithProvisioningArtifactResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddSCServiceActionAssociationWithProvisioningArtifactCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
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
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The product identifier. For example, <code>prod-abcdzk7xy33qa</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the provisioning artifact. For example, <code>pa-4abcdjnxjj6ne</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProvisioningArtifactId { get; set; }
        #endregion
        
        #region Parameter ServiceActionId
        /// <summary>
        /// <para>
        /// <para>The self-service action identifier. For example, <code>act-fs7abcd89wxyz</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceActionId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ServiceActionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-SCServiceActionAssociationWithProvisioningArtifact (AssociateServiceActionWithProvisioningArtifact)"))
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
            context.ProductId = this.ProductId;
            context.ProvisioningArtifactId = this.ProvisioningArtifactId;
            context.ServiceActionId = this.ServiceActionId;
            
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
            var request = new Amazon.ServiceCatalog.Model.AssociateServiceActionWithProvisioningArtifactRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
            }
            if (cmdletContext.ProvisioningArtifactId != null)
            {
                request.ProvisioningArtifactId = cmdletContext.ProvisioningArtifactId;
            }
            if (cmdletContext.ServiceActionId != null)
            {
                request.ServiceActionId = cmdletContext.ServiceActionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.ServiceCatalog.Model.AssociateServiceActionWithProvisioningArtifactResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.AssociateServiceActionWithProvisioningArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "AssociateServiceActionWithProvisioningArtifact");
            try
            {
                #if DESKTOP
                return client.AssociateServiceActionWithProvisioningArtifact(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AssociateServiceActionWithProvisioningArtifactAsync(request);
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
            public System.String ProductId { get; set; }
            public System.String ProvisioningArtifactId { get; set; }
            public System.String ServiceActionId { get; set; }
        }
        
    }
}
