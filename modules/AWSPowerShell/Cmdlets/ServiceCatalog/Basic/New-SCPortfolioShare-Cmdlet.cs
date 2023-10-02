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
    /// Shares the specified portfolio with the specified account or organization node. Shares
    /// to an organization node can only be created by the management account of an organization
    /// or by a delegated administrator. You can share portfolios to an organization, an organizational
    /// unit, or a specific account.
    /// 
    ///  
    /// <para>
    /// Note that if a delegated admin is de-registered, they can no longer create portfolio
    /// shares.
    /// </para><para><code>AWSOrganizationsAccess</code> must be enabled in order to create a portfolio
    /// share to an organization node.
    /// </para><para>
    /// You can't share a shared resource, including portfolios that contain a shared product.
    /// </para><para>
    /// If the portfolio share with the specified account or organization node already exists,
    /// this action will have no effect and will not return an error. To update an existing
    /// share, you must use the <code> UpdatePortfolioShare</code> API instead. 
    /// </para><note><para>
    /// When you associate a principal with portfolio, a potential privilege escalation path
    /// may occur when that portfolio is then shared with other accounts. For a user in a
    /// recipient account who is <i>not</i> an Service Catalog Admin, but still has the ability
    /// to create Principals (Users/Groups/Roles), that user could create a role that matches
    /// a principal name association for the portfolio. Although this user may not know which
    /// principal names are associated through Service Catalog, they may be able to guess
    /// the user. If this potential escalation path is a concern, then Service Catalog recommends
    /// using <code>PrincipalType</code> as <code>IAM</code>. With this configuration, the
    /// <code>PrincipalARN</code> must already exist in the recipient account before it can
    /// be associated. 
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SCPortfolioShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Service Catalog CreatePortfolioShare API operation.", Operation = new[] {"CreatePortfolioShare"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.CreatePortfolioShareResponse))]
    [AWSCmdletOutput("System.String or Amazon.ServiceCatalog.Model.CreatePortfolioShareResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ServiceCatalog.Model.CreatePortfolioShareResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSCPortfolioShareCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><code>jp</code> - Japanese</para></li><li><para><code>zh</code> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID. For example, <code>123456789012</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter PortfolioId
        /// <summary>
        /// <para>
        /// <para>The portfolio identifier.</para>
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
        public System.String PortfolioId { get; set; }
        #endregion
        
        #region Parameter SharePrincipal
        /// <summary>
        /// <para>
        /// <para>Enables or disables <code>Principal</code> sharing when creating the portfolio share.
        /// If this flag is not provided, principal sharing is disabled. </para><para>When you enable Principal Name Sharing for a portfolio share, the share recipient
        /// account end users with a principal that matches any of the associated IAM patterns
        /// can provision products from the portfolio. Once shared, the share recipient can view
        /// associations of <code>PrincipalType</code>: <code>IAM_PATTERN</code> on their portfolio.
        /// You can create the principals in the recipient account before or after creating the
        /// share. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SharePrincipals")]
        public System.Boolean? SharePrincipal { get; set; }
        #endregion
        
        #region Parameter ShareTagOption
        /// <summary>
        /// <para>
        /// <para>Enables or disables <code>TagOptions </code> sharing when creating the portfolio share.
        /// If this flag is not provided, TagOptions sharing is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ShareTagOptions")]
        public System.Boolean? ShareTagOption { get; set; }
        #endregion
        
        #region Parameter OrganizationNode_Type
        /// <summary>
        /// <para>
        /// <para>The organization node type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceCatalog.OrganizationNodeType")]
        public Amazon.ServiceCatalog.OrganizationNodeType OrganizationNode_Type { get; set; }
        #endregion
        
        #region Parameter OrganizationNode_Value
        /// <summary>
        /// <para>
        /// <para>The identifier of the organization node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationNode_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PortfolioShareToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.CreatePortfolioShareResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.CreatePortfolioShareResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PortfolioShareToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SCPortfolioShare (CreatePortfolioShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.CreatePortfolioShareResponse, NewSCPortfolioShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptLanguage = this.AcceptLanguage;
            context.AccountId = this.AccountId;
            context.OrganizationNode_Type = this.OrganizationNode_Type;
            context.OrganizationNode_Value = this.OrganizationNode_Value;
            context.PortfolioId = this.PortfolioId;
            #if MODULAR
            if (this.PortfolioId == null && ParameterWasBound(nameof(this.PortfolioId)))
            {
                WriteWarning("You are passing $null as a value for parameter PortfolioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SharePrincipal = this.SharePrincipal;
            context.ShareTagOption = this.ShareTagOption;
            
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
            var request = new Amazon.ServiceCatalog.Model.CreatePortfolioShareRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate OrganizationNode
            var requestOrganizationNodeIsNull = true;
            request.OrganizationNode = new Amazon.ServiceCatalog.Model.OrganizationNode();
            Amazon.ServiceCatalog.OrganizationNodeType requestOrganizationNode_organizationNode_Type = null;
            if (cmdletContext.OrganizationNode_Type != null)
            {
                requestOrganizationNode_organizationNode_Type = cmdletContext.OrganizationNode_Type;
            }
            if (requestOrganizationNode_organizationNode_Type != null)
            {
                request.OrganizationNode.Type = requestOrganizationNode_organizationNode_Type;
                requestOrganizationNodeIsNull = false;
            }
            System.String requestOrganizationNode_organizationNode_Value = null;
            if (cmdletContext.OrganizationNode_Value != null)
            {
                requestOrganizationNode_organizationNode_Value = cmdletContext.OrganizationNode_Value;
            }
            if (requestOrganizationNode_organizationNode_Value != null)
            {
                request.OrganizationNode.Value = requestOrganizationNode_organizationNode_Value;
                requestOrganizationNodeIsNull = false;
            }
             // determine if request.OrganizationNode should be set to null
            if (requestOrganizationNodeIsNull)
            {
                request.OrganizationNode = null;
            }
            if (cmdletContext.PortfolioId != null)
            {
                request.PortfolioId = cmdletContext.PortfolioId;
            }
            if (cmdletContext.SharePrincipal != null)
            {
                request.SharePrincipals = cmdletContext.SharePrincipal.Value;
            }
            if (cmdletContext.ShareTagOption != null)
            {
                request.ShareTagOptions = cmdletContext.ShareTagOption.Value;
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
        
        private Amazon.ServiceCatalog.Model.CreatePortfolioShareResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.CreatePortfolioShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "CreatePortfolioShare");
            try
            {
                #if DESKTOP
                return client.CreatePortfolioShare(request);
                #elif CORECLR
                return client.CreatePortfolioShareAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public Amazon.ServiceCatalog.OrganizationNodeType OrganizationNode_Type { get; set; }
            public System.String OrganizationNode_Value { get; set; }
            public System.String PortfolioId { get; set; }
            public System.Boolean? SharePrincipal { get; set; }
            public System.Boolean? ShareTagOption { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.CreatePortfolioShareResponse, NewSCPortfolioShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PortfolioShareToken;
        }
        
    }
}
