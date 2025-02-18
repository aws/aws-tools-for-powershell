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

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Disassociates a previously associated principal ARN from a specified portfolio.
    /// 
    ///  
    /// <para>
    /// The <c>PrincipalType</c> and <c>PrincipalARN</c> must match the <c>AssociatePrincipalWithPortfolio</c>
    /// call request details. For example, to disassociate an association created with a <c>PrincipalARN</c>
    /// of <c>PrincipalType</c> IAM you must use the <c>PrincipalType</c> IAM when calling
    /// <c>DisassociatePrincipalFromPortfolio</c>. 
    /// </para><para>
    /// For portfolios that have been shared with principal name sharing enabled: after disassociating
    /// a principal, share recipient accounts will no longer be able to provision products
    /// in this portfolio using a role matching the name of the associated principal. 
    /// </para><para>
    /// For more information, review <a href="https://docs.aws.amazon.com/cli/latest/reference/servicecatalog/associate-principal-with-portfolio.html#options">associate-principal-with-portfolio</a>
    /// in the Amazon Web Services CLI Command Reference. 
    /// </para><note><para>
    /// If you disassociate a principal from a portfolio, with PrincipalType as <c>IAM</c>,
    /// the same principal will still have access to the portfolio if it matches one of the
    /// associated principals of type <c>IAM_PATTERN</c>. To fully remove access for a principal,
    /// verify all the associated Principals of type <c>IAM_PATTERN</c>, and then ensure you
    /// disassociate any <c>IAM_PATTERN</c> principals that match the principal whose access
    /// you are removing.
    /// </para></note>
    /// </summary>
    [Cmdlet("Unregister", "SCPrincipalFromPortfolio", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Service Catalog DisassociatePrincipalFromPortfolio API operation.", Operation = new[] {"DisassociatePrincipalFromPortfolio"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.DisassociatePrincipalFromPortfolioResponse))]
    [AWSCmdletOutput("None or Amazon.ServiceCatalog.Model.DisassociatePrincipalFromPortfolioResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServiceCatalog.Model.DisassociatePrincipalFromPortfolioResponse) be returned by specifying '-Select *'."
    )]
    public partial class UnregisterSCPrincipalFromPortfolioCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
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
        
        #region Parameter PrincipalARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the principal (user, role, or group). This field allows an ARN with no
        /// <c>accountID</c> with or without wildcard characters if <c>PrincipalType</c> is <c>IAM_PATTERN</c>.</para>
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
        public System.String PrincipalARN { get; set; }
        #endregion
        
        #region Parameter PrincipalType
        /// <summary>
        /// <para>
        /// <para>The supported value is <c>IAM</c> if you use a fully defined ARN, or <c>IAM_PATTERN</c>
        /// if you specify an <c>IAM</c> ARN with no AccountId, with or without wildcard characters.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceCatalog.PrincipalType")]
        public Amazon.ServiceCatalog.PrincipalType PrincipalType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.DisassociatePrincipalFromPortfolioResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortfolioId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-SCPrincipalFromPortfolio (DisassociatePrincipalFromPortfolio)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.DisassociatePrincipalFromPortfolioResponse, UnregisterSCPrincipalFromPortfolioCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptLanguage = this.AcceptLanguage;
            context.PortfolioId = this.PortfolioId;
            #if MODULAR
            if (this.PortfolioId == null && ParameterWasBound(nameof(this.PortfolioId)))
            {
                WriteWarning("You are passing $null as a value for parameter PortfolioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalARN = this.PrincipalARN;
            #if MODULAR
            if (this.PrincipalARN == null && ParameterWasBound(nameof(this.PrincipalARN)))
            {
                WriteWarning("You are passing $null as a value for parameter PrincipalARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalType = this.PrincipalType;
            
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
            var request = new Amazon.ServiceCatalog.Model.DisassociatePrincipalFromPortfolioRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.PortfolioId != null)
            {
                request.PortfolioId = cmdletContext.PortfolioId;
            }
            if (cmdletContext.PrincipalARN != null)
            {
                request.PrincipalARN = cmdletContext.PrincipalARN;
            }
            if (cmdletContext.PrincipalType != null)
            {
                request.PrincipalType = cmdletContext.PrincipalType;
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
        
        private Amazon.ServiceCatalog.Model.DisassociatePrincipalFromPortfolioResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.DisassociatePrincipalFromPortfolioRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "DisassociatePrincipalFromPortfolio");
            try
            {
                return client.DisassociatePrincipalFromPortfolioAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PortfolioId { get; set; }
            public System.String PrincipalARN { get; set; }
            public Amazon.ServiceCatalog.PrincipalType PrincipalType { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.DisassociatePrincipalFromPortfolioResponse, UnregisterSCPrincipalFromPortfolioCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
