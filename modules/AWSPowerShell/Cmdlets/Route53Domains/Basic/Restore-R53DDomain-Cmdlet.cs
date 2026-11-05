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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// Restores a domain that has expired, or was deleted, before it becomes available for
    /// others to register. The cost of restoring your domain is billed to your Amazon Web
    /// Services account.
    /// 
    ///  
    /// <para>
    /// Not every TLD registry supports restoring domains, and the period during which a domain
    /// can be restored varies by TLD. To find out whether your domain can be restored and
    /// the period during which you can restore it, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
    /// that you can register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
    /// Guide</i>.
    /// </para><important><para>
    /// Restoring a domain typically costs more, and sometimes much more, than registering
    /// or renewing a domain. To get the restoration price for a domain before you restore
    /// it, use <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_domains_GetDomainPrices.html">GetDomainPrices</a>.
    /// </para></important><para>
    /// Restoration is asynchronous. The response includes an operation ID that you can use
    /// with <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_domains_GetOperationDetail.html">GetOperationDetail</a>
    /// to track the progress of the request. When the restoration succeeds, the domain reappears
    /// in the response to <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_domains_ListDomains.html">ListDomains</a>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/domain-restore-expired.html">Restoring
    /// an expired or deleted domain</a> in the <i>Amazon Route 53 Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "R53DDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains RestoreDomain API operation.", Operation = new[] {"RestoreDomain"}, SelectReturnType = typeof(Amazon.Route53Domains.Model.RestoreDomainResponse))]
    [AWSCmdletOutput("System.String or Amazon.Route53Domains.Model.RestoreDomainResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Route53Domains.Model.RestoreDomainResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RestoreR53DDomainCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Consent_Currency
        /// <summary>
        /// <para>
        /// <para> The currency for the <c>MaxPrice</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Consent_Currency { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to restore. The domain must have been registered
        /// to the Amazon Web Services account that submits the request.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter Consent_MaxPrice
        /// <summary>
        /// <para>
        /// <para> The maximum amount that you agree to accept. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Consent_MaxPrice { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Domains.Model.RestoreDomainResponse).
        /// Specifying the name of a property of type Amazon.Route53Domains.Model.RestoreDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-R53DDomain (RestoreDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Domains.Model.RestoreDomainResponse, RestoreR53DDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Consent_Currency = this.Consent_Currency;
            context.Consent_MaxPrice = this.Consent_MaxPrice;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53Domains.Model.RestoreDomainRequest();
            
            
             // populate Consent
            var requestConsentIsNull = true;
            request.Consent = new Amazon.Route53Domains.Model.Consent();
            System.String requestConsent_consent_Currency = null;
            if (cmdletContext.Consent_Currency != null)
            {
                requestConsent_consent_Currency = cmdletContext.Consent_Currency;
            }
            if (requestConsent_consent_Currency != null)
            {
                request.Consent.Currency = requestConsent_consent_Currency;
                requestConsentIsNull = false;
            }
            System.Double? requestConsent_consent_MaxPrice = null;
            if (cmdletContext.Consent_MaxPrice != null)
            {
                requestConsent_consent_MaxPrice = cmdletContext.Consent_MaxPrice.Value;
            }
            if (requestConsent_consent_MaxPrice != null)
            {
                request.Consent.MaxPrice = requestConsent_consent_MaxPrice.Value;
                requestConsentIsNull = false;
            }
             // determine if request.Consent should be set to null
            if (requestConsentIsNull)
            {
                request.Consent = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
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
        
        private Amazon.Route53Domains.Model.RestoreDomainResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.RestoreDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "RestoreDomain");
            try
            {
                return client.RestoreDomainAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Consent_Currency { get; set; }
            public System.Double? Consent_MaxPrice { get; set; }
            public System.String DomainName { get; set; }
            public System.Func<Amazon.Route53Domains.Model.RestoreDomainResponse, RestoreR53DDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
