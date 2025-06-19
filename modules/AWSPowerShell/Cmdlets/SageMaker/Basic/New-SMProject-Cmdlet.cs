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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a machine learning (ML) project that can contain one or more templates that
    /// set up an ML pipeline from training to deploying an approved model.
    /// </summary>
    [Cmdlet("New", "SMProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.CreateProjectResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateProject API operation.", Operation = new[] {"CreateProject"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateProjectResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.CreateProjectResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.CreateProjectResponse object containing multiple properties."
    )]
    public partial class NewSMProjectCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ServiceCatalogProvisioningDetails_PathId
        /// <summary>
        /// <para>
        /// <para>The path identifier of the product. This value is optional if the product has a default
        /// path, and required if the product has more than one path. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceCatalogProvisioningDetails_PathId { get; set; }
        #endregion
        
        #region Parameter ServiceCatalogProvisioningDetails_ProductId
        /// <summary>
        /// <para>
        /// <para>The ID of the product to provision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceCatalogProvisioningDetails_ProductId { get; set; }
        #endregion
        
        #region Parameter ProjectDescription
        /// <summary>
        /// <para>
        /// <para>A description for the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectDescription { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter ServiceCatalogProvisioningDetails_ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The ID of the provisioning artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceCatalogProvisioningDetails_ProvisioningArtifactId { get; set; }
        #endregion
        
        #region Parameter ServiceCatalogProvisioningDetails_ProvisioningParameter
        /// <summary>
        /// <para>
        /// <para>A list of key value pairs that you specify when you provision a product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceCatalogProvisioningDetails_ProvisioningParameters")]
        public Amazon.SageMaker.Model.ProvisioningParameter[] ServiceCatalogProvisioningDetails_ProvisioningParameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs that you want to use to organize and track your Amazon
        /// Web Services resource costs. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a> in the <i>Amazon Web Services General Reference
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateProvider
        /// <summary>
        /// <para>
        /// <para> An array of template provider configurations for creating infrastructure resources
        /// for the project. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TemplateProviders")]
        public Amazon.SageMaker.Model.CreateTemplateProvider[] TemplateProvider { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateProjectResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateProjectResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMProject (CreateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateProjectResponse, NewSMProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProjectDescription = this.ProjectDescription;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceCatalogProvisioningDetails_PathId = this.ServiceCatalogProvisioningDetails_PathId;
            context.ServiceCatalogProvisioningDetails_ProductId = this.ServiceCatalogProvisioningDetails_ProductId;
            context.ServiceCatalogProvisioningDetails_ProvisioningArtifactId = this.ServiceCatalogProvisioningDetails_ProvisioningArtifactId;
            if (this.ServiceCatalogProvisioningDetails_ProvisioningParameter != null)
            {
                context.ServiceCatalogProvisioningDetails_ProvisioningParameter = new List<Amazon.SageMaker.Model.ProvisioningParameter>(this.ServiceCatalogProvisioningDetails_ProvisioningParameter);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            if (this.TemplateProvider != null)
            {
                context.TemplateProvider = new List<Amazon.SageMaker.Model.CreateTemplateProvider>(this.TemplateProvider);
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
            var request = new Amazon.SageMaker.Model.CreateProjectRequest();
            
            if (cmdletContext.ProjectDescription != null)
            {
                request.ProjectDescription = cmdletContext.ProjectDescription;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            
             // populate ServiceCatalogProvisioningDetails
            var requestServiceCatalogProvisioningDetailsIsNull = true;
            request.ServiceCatalogProvisioningDetails = new Amazon.SageMaker.Model.ServiceCatalogProvisioningDetails();
            System.String requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_PathId = null;
            if (cmdletContext.ServiceCatalogProvisioningDetails_PathId != null)
            {
                requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_PathId = cmdletContext.ServiceCatalogProvisioningDetails_PathId;
            }
            if (requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_PathId != null)
            {
                request.ServiceCatalogProvisioningDetails.PathId = requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_PathId;
                requestServiceCatalogProvisioningDetailsIsNull = false;
            }
            System.String requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProductId = null;
            if (cmdletContext.ServiceCatalogProvisioningDetails_ProductId != null)
            {
                requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProductId = cmdletContext.ServiceCatalogProvisioningDetails_ProductId;
            }
            if (requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProductId != null)
            {
                request.ServiceCatalogProvisioningDetails.ProductId = requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProductId;
                requestServiceCatalogProvisioningDetailsIsNull = false;
            }
            System.String requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProvisioningArtifactId = null;
            if (cmdletContext.ServiceCatalogProvisioningDetails_ProvisioningArtifactId != null)
            {
                requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProvisioningArtifactId = cmdletContext.ServiceCatalogProvisioningDetails_ProvisioningArtifactId;
            }
            if (requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProvisioningArtifactId != null)
            {
                request.ServiceCatalogProvisioningDetails.ProvisioningArtifactId = requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProvisioningArtifactId;
                requestServiceCatalogProvisioningDetailsIsNull = false;
            }
            List<Amazon.SageMaker.Model.ProvisioningParameter> requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProvisioningParameter = null;
            if (cmdletContext.ServiceCatalogProvisioningDetails_ProvisioningParameter != null)
            {
                requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProvisioningParameter = cmdletContext.ServiceCatalogProvisioningDetails_ProvisioningParameter;
            }
            if (requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProvisioningParameter != null)
            {
                request.ServiceCatalogProvisioningDetails.ProvisioningParameters = requestServiceCatalogProvisioningDetails_serviceCatalogProvisioningDetails_ProvisioningParameter;
                requestServiceCatalogProvisioningDetailsIsNull = false;
            }
             // determine if request.ServiceCatalogProvisioningDetails should be set to null
            if (requestServiceCatalogProvisioningDetailsIsNull)
            {
                request.ServiceCatalogProvisioningDetails = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemplateProvider != null)
            {
                request.TemplateProviders = cmdletContext.TemplateProvider;
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
        
        private Amazon.SageMaker.Model.CreateProjectResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateProject");
            try
            {
                return client.CreateProjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ProjectDescription { get; set; }
            public System.String ProjectName { get; set; }
            public System.String ServiceCatalogProvisioningDetails_PathId { get; set; }
            public System.String ServiceCatalogProvisioningDetails_ProductId { get; set; }
            public System.String ServiceCatalogProvisioningDetails_ProvisioningArtifactId { get; set; }
            public List<Amazon.SageMaker.Model.ProvisioningParameter> ServiceCatalogProvisioningDetails_ProvisioningParameter { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public List<Amazon.SageMaker.Model.CreateTemplateProvider> TemplateProvider { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateProjectResponse, NewSMProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
