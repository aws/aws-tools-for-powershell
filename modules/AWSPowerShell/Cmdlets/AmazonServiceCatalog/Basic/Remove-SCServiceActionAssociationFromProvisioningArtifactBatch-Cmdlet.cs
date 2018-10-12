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
    /// Disassociates a batch of self-service actions from the specified provisioning artifact.
    /// </summary>
    [Cmdlet("Remove", "SCServiceActionAssociationFromProvisioningArtifactBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ServiceCatalog.Model.FailedServiceActionAssociation")]
    [AWSCmdlet("Calls the AWS Service Catalog BatchDisassociateServiceActionFromProvisioningArtifact API operation.", Operation = new[] {"BatchDisassociateServiceActionFromProvisioningArtifact"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.FailedServiceActionAssociation",
        "This cmdlet returns a collection of FailedServiceActionAssociation objects.",
        "The service call response (type Amazon.ServiceCatalog.Model.BatchDisassociateServiceActionFromProvisioningArtifactResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSCServiceActionAssociationFromProvisioningArtifactBatchCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
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
        
        #region Parameter ServiceActionAssociation
        /// <summary>
        /// <para>
        /// <para>One or more associations, each consisting of the Action ID, the Product ID, and the
        /// Provisioning Artifact ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ServiceActionAssociations")]
        public Amazon.ServiceCatalog.Model.ServiceActionAssociation[] ServiceActionAssociation { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SCServiceActionAssociationFromProvisioningArtifactBatch (BatchDisassociateServiceActionFromProvisioningArtifact)"))
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
            if (this.ServiceActionAssociation != null)
            {
                context.ServiceActionAssociations = new List<Amazon.ServiceCatalog.Model.ServiceActionAssociation>(this.ServiceActionAssociation);
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
            var request = new Amazon.ServiceCatalog.Model.BatchDisassociateServiceActionFromProvisioningArtifactRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.ServiceActionAssociations != null)
            {
                request.ServiceActionAssociations = cmdletContext.ServiceActionAssociations;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FailedServiceActionAssociations;
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
        
        private Amazon.ServiceCatalog.Model.BatchDisassociateServiceActionFromProvisioningArtifactResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.BatchDisassociateServiceActionFromProvisioningArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "BatchDisassociateServiceActionFromProvisioningArtifact");
            try
            {
                #if DESKTOP
                return client.BatchDisassociateServiceActionFromProvisioningArtifact(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.BatchDisassociateServiceActionFromProvisioningArtifactAsync(request);
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
            public List<Amazon.ServiceCatalog.Model.ServiceActionAssociation> ServiceActionAssociations { get; set; }
        }
        
    }
}
