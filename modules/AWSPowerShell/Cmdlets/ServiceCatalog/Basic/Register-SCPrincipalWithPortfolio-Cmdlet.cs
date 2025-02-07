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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Associates the specified principal ARN with the specified portfolio.
    /// 
    ///  
    /// <para>
    /// If you share the portfolio with principal name sharing enabled, the <c>PrincipalARN</c>
    /// association is included in the share. 
    /// </para><para>
    /// The <c>PortfolioID</c>, <c>PrincipalARN</c>, and <c>PrincipalType</c> parameters are
    /// required. 
    /// </para><para>
    /// You can associate a maximum of 10 Principals with a portfolio using <c>PrincipalType</c>
    /// as <c>IAM_PATTERN</c>. 
    /// </para><note><para>
    /// When you associate a principal with portfolio, a potential privilege escalation path
    /// may occur when that portfolio is then shared with other accounts. For a user in a
    /// recipient account who is <i>not</i> an Service Catalog Admin, but still has the ability
    /// to create Principals (Users/Groups/Roles), that user could create a role that matches
    /// a principal name association for the portfolio. Although this user may not know which
    /// principal names are associated through Service Catalog, they may be able to guess
    /// the user. If this potential escalation path is a concern, then Service Catalog recommends
    /// using <c>PrincipalType</c> as <c>IAM</c>. With this configuration, the <c>PrincipalARN</c>
    /// must already exist in the recipient account before it can be associated. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Register", "SCPrincipalWithPortfolio", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Service Catalog AssociatePrincipalWithPortfolio API operation.", Operation = new[] {"AssociatePrincipalWithPortfolio"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.AssociatePrincipalWithPortfolioResponse))]
    [AWSCmdletOutput("None or Amazon.ServiceCatalog.Model.AssociatePrincipalWithPortfolioResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServiceCatalog.Model.AssociatePrincipalWithPortfolioResponse) be returned by specifying '-Select *'."
    )]
    public partial class RegisterSCPrincipalWithPortfolioCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
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
        /// <para>The ARN of the principal (user, role, or group). If the <c>PrincipalType</c> is <c>IAM</c>,
        /// the supported value is a fully defined <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-arns">IAM
        /// Amazon Resource Name (ARN)</a>. If the <c>PrincipalType</c> is <c>IAM_PATTERN</c>,
        /// the supported value is an <c>IAM</c> ARN <i>without an AccountID</i> in the following
        /// format:</para><para><i>arn:partition:iam:::resource-type/resource-id</i></para><para>The ARN resource-id can be either:</para><ul><li><para>A fully formed resource-id. For example, <i>arn:aws:iam:::role/resource-name</i> or
        /// <i>arn:aws:iam:::role/resource-path/resource-name</i></para></li><li><para>A wildcard ARN. The wildcard ARN accepts <c>IAM_PATTERN</c> values with a "*" or "?"
        /// in the resource-id segment of the ARN. For example <i>arn:partition:service:::resource-type/resource-path/resource-name</i>.
        /// The new symbols are exclusive to the <b>resource-path</b> and <b>resource-name</b>
        /// and cannot replace the <b>resource-type</b> or other ARN values. </para><para>The ARN path and principal name allow unlimited wildcard characters.</para></li></ul><para>Examples of an <b>acceptable</b> wildcard ARN:</para><ul><li><para>arn:aws:iam:::role/ResourceName_*</para></li><li><para>arn:aws:iam:::role/*/ResourceName_?</para></li></ul><para>Examples of an <b>unacceptable</b> wildcard ARN:</para><ul><li><para>arn:aws:iam:::*/ResourceName</para></li></ul><para>You can associate multiple <c>IAM_PATTERN</c>s even if the account has no principal
        /// with that name. </para><para>The "?" wildcard character matches zero or one of any character. This is similar to
        /// ".?" in regular regex context. The "*" wildcard character matches any number of any
        /// characters. This is similar to ".*" in regular regex context.</para><para>In the IAM Principal ARN format (<i>arn:partition:iam:::resource-type/resource-path/resource-name</i>),
        /// valid resource-type values include <b>user/</b>, <b>group/</b>, or <b>role/</b>. The
        /// "?" and "*" characters are allowed only after the resource-type in the resource-id
        /// segment. You can use special characters anywhere within the resource-id. </para><para>The "*" character also matches the "/" character, allowing paths to be formed <i>within</i>
        /// the resource-id. For example, <i>arn:aws:iam:::role/<b>*</b>/ResourceName_?</i> matches
        /// both <i>arn:aws:iam:::role/pathA/pathB/ResourceName_1</i> and <i>arn:aws:iam:::role/pathA/ResourceName_1</i>.
        /// </para>
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
        /// <para>The principal type. The supported value is <c>IAM</c> if you use a fully defined Amazon
        /// Resource Name (ARN), or <c>IAM_PATTERN</c> if you use an ARN with no <c>accountID</c>,
        /// with or without wildcard characters. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.PrincipalType")]
        public Amazon.ServiceCatalog.PrincipalType PrincipalType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.AssociatePrincipalWithPortfolioResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortfolioId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-SCPrincipalWithPortfolio (AssociatePrincipalWithPortfolio)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.AssociatePrincipalWithPortfolioResponse, RegisterSCPrincipalWithPortfolioCmdlet>(Select) ??
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
            #if MODULAR
            if (this.PrincipalType == null && ParameterWasBound(nameof(this.PrincipalType)))
            {
                WriteWarning("You are passing $null as a value for parameter PrincipalType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceCatalog.Model.AssociatePrincipalWithPortfolioRequest();
            
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
        
        private Amazon.ServiceCatalog.Model.AssociatePrincipalWithPortfolioResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.AssociatePrincipalWithPortfolioRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "AssociatePrincipalWithPortfolio");
            try
            {
                #if DESKTOP
                return client.AssociatePrincipalWithPortfolio(request);
                #elif CORECLR
                return client.AssociatePrincipalWithPortfolioAsync(request).GetAwaiter().GetResult();
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
            public System.String PortfolioId { get; set; }
            public System.String PrincipalARN { get; set; }
            public Amazon.ServiceCatalog.PrincipalType PrincipalType { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.AssociatePrincipalWithPortfolioResponse, RegisterSCPrincipalWithPortfolioCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
