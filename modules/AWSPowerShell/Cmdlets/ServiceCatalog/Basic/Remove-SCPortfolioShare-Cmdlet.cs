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
    /// Stops sharing the specified portfolio with the specified account or organization node.
    /// Shares to an organization node can only be deleted by the management account of an
    /// organization or by a delegated administrator.
    /// 
    ///  
    /// <para>
    /// Note that if a delegated admin is de-registered, portfolio shares created from that
    /// account are removed.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "SCPortfolioShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Service Catalog DeletePortfolioShare API operation.", Operation = new[] {"DeletePortfolioShare"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.DeletePortfolioShareResponse))]
    [AWSCmdletOutput("System.String or Amazon.ServiceCatalog.Model.DeletePortfolioShareResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ServiceCatalog.Model.DeletePortfolioShareResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveSCPortfolioShareCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
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
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.DeletePortfolioShareResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.DeletePortfolioShareResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PortfolioShareToken";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortfolioId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SCPortfolioShare (DeletePortfolioShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.DeletePortfolioShareResponse, RemoveSCPortfolioShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.ServiceCatalog.Model.DeletePortfolioShareRequest();
            
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
        
        private Amazon.ServiceCatalog.Model.DeletePortfolioShareResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.DeletePortfolioShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "DeletePortfolioShare");
            try
            {
                return client.DeletePortfolioShareAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ServiceCatalog.Model.DeletePortfolioShareResponse, RemoveSCPortfolioShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PortfolioShareToken;
        }
        
    }
}
