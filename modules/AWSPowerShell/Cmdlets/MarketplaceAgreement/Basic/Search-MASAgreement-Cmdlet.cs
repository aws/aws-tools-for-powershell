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
    /// Searches across all agreements that a proposer has in AWS Marketplace. The search
    /// returns a list of agreements with basic agreement information.
    /// 
    ///  
    /// <para>
    /// The following filter combinations are supported when the <c>PartyType</c> is <c>Proposer</c>:
    /// </para><ul><li><para><c>AgreementType</c></para></li><li><para><c>AgreementType</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>ResourceType</c></para></li><li><para><c>AgreementType</c> + <c>ResourceType</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>ResourceType</c> + <c>Status</c></para></li><li><para><c>AgreementType</c> + <c>ResourceType</c> + <c>Status</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>ResourceId</c></para></li><li><para><c>AgreementType</c> + <c>ResourceId</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>ResourceId</c> + <c>Status</c></para></li><li><para><c>AgreementType</c> + <c>ResourceId</c> + <c>Status</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>Status</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>Status</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>OfferId</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>OfferId</c> + <c>Status</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>OfferId</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>OfferId</c> + <c>Status</c>
    /// + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>ResourceId</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>ResourceId</c> + <c>Status</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>ResourceId</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>ResourceId</c> + <c>Status</c>
    /// + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>ResourceType</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>ResourceType</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>ResourceType</c> + <c>Status</c></para></li><li><para><c>AgreementType</c> + <c>AcceptorAccountId</c> + <c>ResourceType</c> + <c>Status</c>
    /// + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>Status</c></para></li><li><para><c>AgreementType</c> + <c>Status</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>OfferId</c></para></li><li><para><c>AgreementType</c> + <c>OfferId</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>OfferId</c> + <c>Status</c></para></li><li><para><c>AgreementType</c> + <c>OfferId</c> + <c>Status</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>OfferSetId</c></para></li><li><para><c>AgreementType</c> + <c>OfferSetId</c> + <c>EndTime</c></para></li><li><para><c>AgreementType</c> + <c>OfferSetId</c> + <c>Status</c></para></li><li><para><c>AgreementType</c> + <c>OfferSetId</c> + <c>Status</c> + <c>EndTime</c></para></li></ul><note><para>
    ///  To filter by <c>EndTime</c>, you can use either <c>BeforeEndTime</c> or <c>AfterEndTime</c>.
    /// Only <c>EndTime</c> is supported for sorting.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Search", "MASAgreement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service SearchAgreements API operation.", Operation = new[] {"SearchAgreements"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse",
        "This cmdlet returns an Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse object containing multiple properties."
    )]
    public partial class SearchMASAgreementCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog in which the agreement was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filter name and value pair used to return a specific list of results.</para><para>The following filters are supported:</para><ul><li><para><c>ResourceIdentifier</c> – The unique identifier of the resource.</para></li><li><para><c>ResourceType</c> – Type of the resource, which is the product (<c>AmiProduct</c>,
        /// <c>ContainerProduct</c>, <c>SaaSProduct</c>, <c>ProfessionalServicesProduct</c>, or
        /// <c>MachineLearningProduct</c>).</para></li><li><para><c>PartyType</c> – The party type of the caller. For agreements where the caller
        /// is the proposer, use the <c>Proposer</c> filter.</para></li><li><para><c>AcceptorAccountId</c> – The AWS account ID of the party accepting the agreement
        /// terms.</para></li><li><para><c>OfferId</c> – The unique identifier of the offer in which the terms are registered
        /// in the agreement token.</para></li><li><para><c>Status</c> – The current status of the agreement. Values include <c>ACTIVE</c>,
        /// <c>ARCHIVED</c>, <c>CANCELLED</c>, <c>EXPIRED</c>, <c>RENEWED</c>, <c>REPLACED</c>,
        /// and <c>TERMINATED</c>.</para></li><li><para><c>BeforeEndTime</c> – A date used to filter agreements with a date before the <c>endTime</c>
        /// of an agreement.</para></li><li><para><c>AfterEndTime</c> – A date used to filter agreements with a date after the <c>endTime</c>
        /// of an agreement.</para></li><li><para><c>AgreementType</c> – The type of agreement. Supported value includes <c>PurchaseAgreement</c>.</para></li><li><para><c>OfferSetId</c> – A unique identifier for the offer set containing this offer.
        /// All agreements created from offers in this set include this identifier as context.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.MarketplaceAgreement.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter Sort_SortBy
        /// <summary>
        /// <para>
        /// <para>The attribute on which the data is grouped, which can be by <c>StartTime</c> and <c>EndTime</c>.
        /// The default value is <c>EndTime</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sort_SortBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sorting order, which can be <c>ASCENDING</c> or <c>DESCENDING</c>. The default
        /// value is <c>DESCENDING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MarketplaceAgreement.SortOrder")]
        public Amazon.MarketplaceAgreement.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of agreements to return in the response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to specify where to start pagination.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse will result in that property being returned.
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Catalog), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-MASAgreement (SearchAgreements)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse, SearchMASAgreementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.MarketplaceAgreement.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Sort_SortBy = this.Sort_SortBy;
            context.Sort_SortOrder = this.Sort_SortOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.MarketplaceAgreement.Model.SearchAgreementsRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.MarketplaceAgreement.Model.Sort();
            System.String requestSort_sort_SortBy = null;
            if (cmdletContext.Sort_SortBy != null)
            {
                requestSort_sort_SortBy = cmdletContext.Sort_SortBy;
            }
            if (requestSort_sort_SortBy != null)
            {
                request.Sort.SortBy = requestSort_sort_SortBy;
                requestSortIsNull = false;
            }
            Amazon.MarketplaceAgreement.SortOrder requestSort_sort_SortOrder = null;
            if (cmdletContext.Sort_SortOrder != null)
            {
                requestSort_sort_SortOrder = cmdletContext.Sort_SortOrder;
            }
            if (requestSort_sort_SortOrder != null)
            {
                request.Sort.SortOrder = requestSort_sort_SortOrder;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.SearchAgreementsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "SearchAgreements");
            try
            {
                return client.SearchAgreementsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.MarketplaceAgreement.Model.Filter> Filter { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Sort_SortBy { get; set; }
            public Amazon.MarketplaceAgreement.SortOrder Sort_SortOrder { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse, SearchMASAgreementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
