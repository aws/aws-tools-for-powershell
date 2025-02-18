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
using Amazon.MarketplaceReporting;
using Amazon.MarketplaceReporting.Model;

namespace Amazon.PowerShell.Cmdlets.MR
{
    /// <summary>
    /// Generates an embedding URL for an Amazon QuickSight dashboard for an anonymous user.
    /// 
    ///  <note><para>
    /// This API is available only to Amazon Web Services Organization management accounts
    /// or delegated administrators registered for the procurement insights (<c>procurement-insights.marketplace.amazonaws.com</c>)
    /// feature.
    /// </para></note><para>
    /// The following rules apply to a generated URL:
    /// </para><ul><li><para>
    /// It contains a temporary bearer token, valid for 5 minutes after it is generated. Once
    /// redeemed within that period, it cannot be re-used again.
    /// </para></li><li><para>
    /// It has a session lifetime of one hour. The 5-minute validity period runs separately
    /// from the session lifetime.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "MRBuyerDashboard")]
    [OutputType("Amazon.MarketplaceReporting.Model.GetBuyerDashboardResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Reporting Service GetBuyerDashboard API operation.", Operation = new[] {"GetBuyerDashboard"}, SelectReturnType = typeof(Amazon.MarketplaceReporting.Model.GetBuyerDashboardResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceReporting.Model.GetBuyerDashboardResponse",
        "This cmdlet returns an Amazon.MarketplaceReporting.Model.GetBuyerDashboardResponse object containing multiple properties."
    )]
    public partial class GetMRBuyerDashboardCmdlet : AmazonMarketplaceReportingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DashboardIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the requested dashboard.</para>
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
        public System.String DashboardIdentifier { get; set; }
        #endregion
        
        #region Parameter EmbeddingDomain
        /// <summary>
        /// <para>
        /// <para>Fully qualified domains that you add to the allow list for access to the generated
        /// URL that is then embedded. You can list up to two domains or subdomains in each API
        /// call. To include all subdomains under a specific domain, use <c>*</c>. For example,
        /// <c>https://*.amazon.com</c> includes all subdomains under <c>https://aws.amazon.com</c>.</para>
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
        [Alias("EmbeddingDomains")]
        public System.String[] EmbeddingDomain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceReporting.Model.GetBuyerDashboardResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceReporting.Model.GetBuyerDashboardResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceReporting.Model.GetBuyerDashboardResponse, GetMRBuyerDashboardCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DashboardIdentifier = this.DashboardIdentifier;
            #if MODULAR
            if (this.DashboardIdentifier == null && ParameterWasBound(nameof(this.DashboardIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EmbeddingDomain != null)
            {
                context.EmbeddingDomain = new List<System.String>(this.EmbeddingDomain);
            }
            #if MODULAR
            if (this.EmbeddingDomain == null && ParameterWasBound(nameof(this.EmbeddingDomain)))
            {
                WriteWarning("You are passing $null as a value for parameter EmbeddingDomain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MarketplaceReporting.Model.GetBuyerDashboardRequest();
            
            if (cmdletContext.DashboardIdentifier != null)
            {
                request.DashboardIdentifier = cmdletContext.DashboardIdentifier;
            }
            if (cmdletContext.EmbeddingDomain != null)
            {
                request.EmbeddingDomains = cmdletContext.EmbeddingDomain;
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
        
        private Amazon.MarketplaceReporting.Model.GetBuyerDashboardResponse CallAWSServiceOperation(IAmazonMarketplaceReporting client, Amazon.MarketplaceReporting.Model.GetBuyerDashboardRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Reporting Service", "GetBuyerDashboard");
            try
            {
                return client.GetBuyerDashboardAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DashboardIdentifier { get; set; }
            public List<System.String> EmbeddingDomain { get; set; }
            public System.Func<Amazon.MarketplaceReporting.Model.GetBuyerDashboardResponse, GetMRBuyerDashboardCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
