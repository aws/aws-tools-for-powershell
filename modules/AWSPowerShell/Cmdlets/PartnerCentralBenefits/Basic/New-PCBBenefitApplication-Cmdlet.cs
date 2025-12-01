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
using Amazon.PartnerCentralBenefits;
using Amazon.PartnerCentralBenefits.Model;

namespace Amazon.PowerShell.Cmdlets.PCB
{
    /// <summary>
    /// Creates a new benefit application for a partner to request access to AWS benefits
    /// and programs.
    /// </summary>
    [Cmdlet("New", "PCBBenefitApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationResponse")]
    [AWSCmdlet("Calls the Amazon PartnerCentral Benefits Service CreateBenefitApplication API operation.", Operation = new[] {"CreateBenefitApplication"}, SelectReturnType = typeof(Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationResponse",
        "This cmdlet returns an Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationResponse object containing multiple properties."
    )]
    public partial class NewPCBBenefitApplicationCmdlet : AmazonPartnerCentralBenefitsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociatedResource
        /// <summary>
        /// <para>
        /// <para>AWS resources that are associated with this benefit application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociatedResources")]
        public System.String[] AssociatedResource { get; set; }
        #endregion
        
        #region Parameter BenefitApplicationDetail
        /// <summary>
        /// <para>
        /// <para>Detailed information and requirements specific to the benefit being requested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BenefitApplicationDetails")]
        public System.Management.Automation.PSObject BenefitApplicationDetail { get; set; }
        #endregion
        
        #region Parameter BenefitIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the benefit being requested in this application.</para>
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
        public System.String BenefitIdentifier { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier that specifies which benefit catalog to create the application
        /// in.</para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A detailed description of the benefit application and its intended use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FileDetail
        /// <summary>
        /// <para>
        /// <para>Supporting documents and files attached to the benefit application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FileDetails")]
        public Amazon.PartnerCentralBenefits.Model.FileInput[] FileDetail { get; set; }
        #endregion
        
        #region Parameter FulfillmentType
        /// <summary>
        /// <para>
        /// <para>The types of fulfillment requested for this benefit application (e.g., credits, access,
        /// disbursement).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentTypes")]
        public System.String[] FulfillmentType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A human-readable name for the benefit application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PartnerContact
        /// <summary>
        /// <para>
        /// <para>Contact information for partner representatives responsible for this benefit application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PartnerContacts")]
        public Amazon.PartnerCentralBenefits.Model.Contact[] PartnerContact { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to categorize and organize the benefit application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PartnerCentralBenefits.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotent processing of the creation
        /// request.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BenefitIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCBBenefitApplication (CreateBenefitApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationResponse, NewPCBBenefitApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssociatedResource != null)
            {
                context.AssociatedResource = new List<System.String>(this.AssociatedResource);
            }
            context.BenefitApplicationDetail = this.BenefitApplicationDetail;
            context.BenefitIdentifier = this.BenefitIdentifier;
            #if MODULAR
            if (this.BenefitIdentifier == null && ParameterWasBound(nameof(this.BenefitIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter BenefitIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            if (this.FileDetail != null)
            {
                context.FileDetail = new List<Amazon.PartnerCentralBenefits.Model.FileInput>(this.FileDetail);
            }
            if (this.FulfillmentType != null)
            {
                context.FulfillmentType = new List<System.String>(this.FulfillmentType);
            }
            context.Name = this.Name;
            if (this.PartnerContact != null)
            {
                context.PartnerContact = new List<Amazon.PartnerCentralBenefits.Model.Contact>(this.PartnerContact);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PartnerCentralBenefits.Model.Tag>(this.Tag);
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
            var request = new Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationRequest();
            
            if (cmdletContext.AssociatedResource != null)
            {
                request.AssociatedResources = cmdletContext.AssociatedResource;
            }
            if (cmdletContext.BenefitApplicationDetail != null)
            {
                request.BenefitApplicationDetails = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.BenefitApplicationDetail);
            }
            if (cmdletContext.BenefitIdentifier != null)
            {
                request.BenefitIdentifier = cmdletContext.BenefitIdentifier;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FileDetail != null)
            {
                request.FileDetails = cmdletContext.FileDetail;
            }
            if (cmdletContext.FulfillmentType != null)
            {
                request.FulfillmentTypes = cmdletContext.FulfillmentType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PartnerContact != null)
            {
                request.PartnerContacts = cmdletContext.PartnerContact;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationResponse CallAWSServiceOperation(IAmazonPartnerCentralBenefits client, Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon PartnerCentral Benefits Service", "CreateBenefitApplication");
            try
            {
                #if DESKTOP
                return client.CreateBenefitApplication(request);
                #elif CORECLR
                return client.CreateBenefitApplicationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AssociatedResource { get; set; }
            public System.Management.Automation.PSObject BenefitApplicationDetail { get; set; }
            public System.String BenefitIdentifier { get; set; }
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.PartnerCentralBenefits.Model.FileInput> FileDetail { get; set; }
            public List<System.String> FulfillmentType { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.PartnerCentralBenefits.Model.Contact> PartnerContact { get; set; }
            public List<Amazon.PartnerCentralBenefits.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PartnerCentralBenefits.Model.CreateBenefitApplicationResponse, NewPCBBenefitApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
