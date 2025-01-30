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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// The <c>CreateEngagement</c> action allows you to create an <c>Engagement</c>, which
    /// serves as a collaborative space between different parties such as AWS Partners and
    /// AWS Sellers. This action automatically adds the caller's AWS account as an active
    /// member of the newly created <c>Engagement</c>.
    /// </summary>
    [Cmdlet("Invoke", "PCCreateEngagement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralSelling.Model.CreateEngagementResponse")]
    [AWSCmdlet("Calls the Partner Central Selling API CreateEngagement API operation.", Operation = new[] {"CreateEngagement"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.CreateEngagementResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.CreateEngagementResponse",
        "This cmdlet returns an Amazon.PartnerCentralSelling.Model.CreateEngagementResponse object containing multiple properties."
    )]
    public partial class InvokePCCreateEngagementCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The <c>CreateEngagementRequest$Catalog</c> parameter specifies the catalog related
        /// to the engagement. Accepted values are <c>AWS</c> and <c>Sandbox</c>, which determine
        /// the environment in which the engagement is managed.</para>
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
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>The <c>Contexts</c> field is a required array of objects, with a maximum of 5 contexts
        /// allowed, specifying detailed information about customer projects associated with the
        /// Engagement. Each context object contains a <c>Type</c> field indicating the context
        /// type, which must be <c>CustomerProject</c> in this version, and a <c>Payload</c> field
        /// containing the <c>CustomerProject</c> details. The <c>CustomerProject</c> object is
        /// composed of two main components: <c>Customer</c> and <c>Project</c>. The <c>Customer</c>
        /// object includes information such as <c>CompanyName</c>, <c>WebsiteUrl</c>, <c>Industry</c>,
        /// and <c>CountryCode</c>, providing essential details about the customer. The <c>Project</c>
        /// object contains <c>Title</c>, <c>BusinessProblem</c>, and <c>TargetCompletionDate</c>,
        /// offering insights into the specific project associated with the customer. This structure
        /// allows comprehensive context to be included within the Engagement, facilitating effective
        /// collaboration between parties by providing relevant customer and project information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Contexts")]
        public Amazon.PartnerCentralSelling.Model.EngagementContextDetails[] Context { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Provides a description of the <c>Engagement</c>.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>Specifies the title of the <c>Engagement</c>.</para>
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
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The <c>CreateEngagementRequest$ClientToken</c> parameter specifies a unique, case-sensitive
        /// identifier to ensure that the request is handled exactly once. The value must not
        /// exceed sixty-four alphanumeric characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.CreateEngagementResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.CreateEngagementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Title parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Title' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Title' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Title), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-PCCreateEngagement (CreateEngagement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.CreateEngagementResponse, InvokePCCreateEngagementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Title;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.Context != null)
            {
                context.Context = new List<Amazon.PartnerCentralSelling.Model.EngagementContextDetails>(this.Context);
            }
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PartnerCentralSelling.Model.CreateEngagementRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Context != null)
            {
                request.Contexts = cmdletContext.Context;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.PartnerCentralSelling.Model.CreateEngagementResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.CreateEngagementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "CreateEngagement");
            try
            {
                #if DESKTOP
                return client.CreateEngagement(request);
                #elif CORECLR
                return client.CreateEngagementAsync(request).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.PartnerCentralSelling.Model.EngagementContextDetails> Context { get; set; }
            public System.String Description { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.CreateEngagementResponse, InvokePCCreateEngagementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
