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
using Amazon.MarketplaceAgreement;
using Amazon.MarketplaceAgreement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MAS
{
    /// <summary>
    /// Creates an agreement request that acts as a quote for the terms you want to accept.
    /// The agreement request captures the requested terms, calculates charges, and returns
    /// a summary. Use <c>AcceptAgreementRequest</c> with the returned <c>agreementRequestId</c>
    /// to finalize the agreement.
    /// </summary>
    [Cmdlet("New", "MASAgreementRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MarketplaceAgreement.Model.CreateAgreementRequestResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service CreateAgreementRequest API operation.", Operation = new[] {"CreateAgreementRequest"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.CreateAgreementRequestResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceAgreement.Model.CreateAgreementRequestResponse",
        "This cmdlet returns an Amazon.MarketplaceAgreement.Model.CreateAgreementRequestResponse object containing multiple properties."
    )]
    public partial class NewMASAgreementRequestCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgreementProposalIdentifier
        /// <summary>
        /// <para>
        /// <para>The agreement proposal signed by the proposer. The proposal includes the requested
        /// resources and the terms that outline an agreement outcome.</para><important><para> This parameter is required if the intent is not <c>AMEND</c>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgreementProposalIdentifier { get; set; }
        #endregion
        
        #region Parameter Intent
        /// <summary>
        /// <para>
        /// <para>The purpose and desired outcome of the agreement request. This is a required parameter
        /// that determines how the agreement request is processed.</para><ul><li><para><c>NEW</c> – Creates a new agreement for terms in the request.</para></li><li><para><c>AMEND</c> – Modifies an existing agreement with terms that are accepted in the
        /// request.</para></li><li><para><c>REPLACE</c> – Creates a new agreement with accepted terms and replaces the existing
        /// agreement.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MarketplaceAgreement.Intent")]
        public Amazon.MarketplaceAgreement.Intent Intent { get; set; }
        #endregion
        
        #region Parameter RequestedTerm
        /// <summary>
        /// <para>
        /// <para>A list of terms that define what is being accepted as part of the agreement. Some
        /// terms require configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("RequestedTerms")]
        public Amazon.MarketplaceAgreement.Model.RequestedTerm[] RequestedTerm { get; set; }
        #endregion
        
        #region Parameter SourceAgreementIdentifier
        /// <summary>
        /// <para>
        /// <para>The agreement's identifier that the request acts upon.</para><important><para> This parameter is required for all non-<c>NEW</c> intents (i.e., <c>AMEND</c> or
        /// <c>REPLACE</c>). Don't provide this parameter if the intent is <c>NEW</c>. </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceAgreementIdentifier { get; set; }
        #endregion
        
        #region Parameter TaxConfiguration_TaxEstimation
        /// <summary>
        /// <para>
        /// <para>Toggle to estimate tax as part of the response. Values include <c>ENABLED</c> and
        /// <c>DISABLED</c>. Default is <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MarketplaceAgreement.TaxEstimation")]
        public Amazon.MarketplaceAgreement.TaxEstimation TaxConfiguration_TaxEstimation { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.CreateAgreementRequestResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceAgreement.Model.CreateAgreementRequestResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Intent), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MASAgreementRequest (CreateAgreementRequest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.CreateAgreementRequestResponse, NewMASAgreementRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgreementProposalIdentifier = this.AgreementProposalIdentifier;
            context.ClientToken = this.ClientToken;
            context.Intent = this.Intent;
            #if MODULAR
            if (this.Intent == null && ParameterWasBound(nameof(this.Intent)))
            {
                WriteWarning("You are passing $null as a value for parameter Intent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RequestedTerm != null)
            {
                context.RequestedTerm = new List<Amazon.MarketplaceAgreement.Model.RequestedTerm>(this.RequestedTerm);
            }
            #if MODULAR
            if (this.RequestedTerm == null && ParameterWasBound(nameof(this.RequestedTerm)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestedTerm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceAgreementIdentifier = this.SourceAgreementIdentifier;
            context.TaxConfiguration_TaxEstimation = this.TaxConfiguration_TaxEstimation;
            
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
            var request = new Amazon.MarketplaceAgreement.Model.CreateAgreementRequestRequest();
            
            if (cmdletContext.AgreementProposalIdentifier != null)
            {
                request.AgreementProposalIdentifier = cmdletContext.AgreementProposalIdentifier;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Intent != null)
            {
                request.Intent = cmdletContext.Intent;
            }
            if (cmdletContext.RequestedTerm != null)
            {
                request.RequestedTerms = cmdletContext.RequestedTerm;
            }
            if (cmdletContext.SourceAgreementIdentifier != null)
            {
                request.SourceAgreementIdentifier = cmdletContext.SourceAgreementIdentifier;
            }
            
             // populate TaxConfiguration
            var requestTaxConfigurationIsNull = true;
            request.TaxConfiguration = new Amazon.MarketplaceAgreement.Model.TaxConfiguration();
            Amazon.MarketplaceAgreement.TaxEstimation requestTaxConfiguration_taxConfiguration_TaxEstimation = null;
            if (cmdletContext.TaxConfiguration_TaxEstimation != null)
            {
                requestTaxConfiguration_taxConfiguration_TaxEstimation = cmdletContext.TaxConfiguration_TaxEstimation;
            }
            if (requestTaxConfiguration_taxConfiguration_TaxEstimation != null)
            {
                request.TaxConfiguration.TaxEstimation = requestTaxConfiguration_taxConfiguration_TaxEstimation;
                requestTaxConfigurationIsNull = false;
            }
             // determine if request.TaxConfiguration should be set to null
            if (requestTaxConfigurationIsNull)
            {
                request.TaxConfiguration = null;
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
        
        private Amazon.MarketplaceAgreement.Model.CreateAgreementRequestResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.CreateAgreementRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "CreateAgreementRequest");
            try
            {
                return client.CreateAgreementRequestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgreementProposalIdentifier { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.MarketplaceAgreement.Intent Intent { get; set; }
            public List<Amazon.MarketplaceAgreement.Model.RequestedTerm> RequestedTerm { get; set; }
            public System.String SourceAgreementIdentifier { get; set; }
            public Amazon.MarketplaceAgreement.TaxEstimation TaxConfiguration_TaxEstimation { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.CreateAgreementRequestResponse, NewMASAgreementRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
