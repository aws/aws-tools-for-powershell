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
    /// Updates the specified provisioning artifact (also known as a version) for the specified
    /// product.
    /// 
    ///  
    /// <para>
    /// You cannot update a provisioning artifact for a product that was shared with you.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SCProvisioningArtifact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse")]
    [AWSCmdlet("Calls the AWS Service Catalog UpdateProvisioningArtifact API operation.", Operation = new[] {"UpdateProvisioningArtifact"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse object containing multiple properties."
    )]
    public partial class UpdateSCProvisioningArtifactCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><c>jp</c> - Japanese</para></li><li><para><c>zh</c> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter Active
        /// <summary>
        /// <para>
        /// <para>Indicates whether the product version is active.</para><para>Inactive provisioning artifacts are invisible to end users. End users cannot launch
        /// or update a provisioned product from an inactive provisioning artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Active { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of the provisioning artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Guidance
        /// <summary>
        /// <para>
        /// <para>Information set by the administrator to provide guidance to end users about which
        /// provisioning artifacts to use.</para><para>The <c>DEFAULT</c> value indicates that the product version is active.</para><para>The administrator can set the guidance to <c>DEPRECATED</c> to inform users that the
        /// product version is deprecated. Users are able to make updates to a provisioned product
        /// of a deprecated version but cannot launch new provisioned products using a deprecated
        /// version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ProvisioningArtifactGuidance")]
        public Amazon.ServiceCatalog.ProvisioningArtifactGuidance Guidance { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name of the provisioning artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The product identifier.</para>
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
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the provisioning artifact.</para>
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
        public System.String ProvisioningArtifactId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProvisioningArtifactId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProvisioningArtifactId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProvisioningArtifactId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProvisioningArtifactId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCProvisioningArtifact (UpdateProvisioningArtifact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse, UpdateSCProvisioningArtifactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProvisioningArtifactId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptLanguage = this.AcceptLanguage;
            context.Active = this.Active;
            context.Description = this.Description;
            context.Guidance = this.Guidance;
            context.Name = this.Name;
            context.ProductId = this.ProductId;
            #if MODULAR
            if (this.ProductId == null && ParameterWasBound(nameof(this.ProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvisioningArtifactId = this.ProvisioningArtifactId;
            #if MODULAR
            if (this.ProvisioningArtifactId == null && ParameterWasBound(nameof(this.ProvisioningArtifactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProvisioningArtifactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.Active != null)
            {
                request.Active = cmdletContext.Active.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Guidance != null)
            {
                request.Guidance = cmdletContext.Guidance;
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
        
        private Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "UpdateProvisioningArtifact");
            try
            {
                #if DESKTOP
                return client.UpdateProvisioningArtifact(request);
                #elif CORECLR
                return client.UpdateProvisioningArtifactAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Active { get; set; }
            public System.String Description { get; set; }
            public Amazon.ServiceCatalog.ProvisioningArtifactGuidance Guidance { get; set; }
            public System.String Name { get; set; }
            public System.String ProductId { get; set; }
            public System.String ProvisioningArtifactId { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.UpdateProvisioningArtifactResponse, UpdateSCProvisioningArtifactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
