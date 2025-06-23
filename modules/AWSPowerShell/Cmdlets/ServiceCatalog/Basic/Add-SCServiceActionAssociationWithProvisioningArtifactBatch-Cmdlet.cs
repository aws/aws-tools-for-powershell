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
    /// Associates multiple self-service actions with provisioning artifacts.
    /// </summary>
    [Cmdlet("Add", "SCServiceActionAssociationWithProvisioningArtifactBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.FailedServiceActionAssociation")]
    [AWSCmdlet("Calls the AWS Service Catalog BatchAssociateServiceActionWithProvisioningArtifact API operation.", Operation = new[] {"BatchAssociateServiceActionWithProvisioningArtifact"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.FailedServiceActionAssociation or Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactResponse",
        "This cmdlet returns a collection of Amazon.ServiceCatalog.Model.FailedServiceActionAssociation objects.",
        "The service call response (type Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddSCServiceActionAssociationWithProvisioningArtifactBatchCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
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
        
        #region Parameter ServiceActionAssociation
        /// <summary>
        /// <para>
        /// <para>One or more associations, each consisting of the Action ID, the Product ID, and the
        /// Provisioning Artifact ID.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ServiceActionAssociations")]
        public Amazon.ServiceCatalog.Model.ServiceActionAssociation[] ServiceActionAssociation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedServiceActionAssociations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedServiceActionAssociations";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-SCServiceActionAssociationWithProvisioningArtifactBatch (BatchAssociateServiceActionWithProvisioningArtifact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactResponse, AddSCServiceActionAssociationWithProvisioningArtifactBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptLanguage = this.AcceptLanguage;
            if (this.ServiceActionAssociation != null)
            {
                context.ServiceActionAssociation = new List<Amazon.ServiceCatalog.Model.ServiceActionAssociation>(this.ServiceActionAssociation);
            }
            #if MODULAR
            if (this.ServiceActionAssociation == null && ParameterWasBound(nameof(this.ServiceActionAssociation)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceActionAssociation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.ServiceActionAssociation != null)
            {
                request.ServiceActionAssociations = cmdletContext.ServiceActionAssociation;
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
        
        private Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "BatchAssociateServiceActionWithProvisioningArtifact");
            try
            {
                return client.BatchAssociateServiceActionWithProvisioningArtifactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ServiceCatalog.Model.ServiceActionAssociation> ServiceActionAssociation { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.BatchAssociateServiceActionWithProvisioningArtifactResponse, AddSCServiceActionAssociationWithProvisioningArtifactBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedServiceActionAssociations;
        }
        
    }
}
