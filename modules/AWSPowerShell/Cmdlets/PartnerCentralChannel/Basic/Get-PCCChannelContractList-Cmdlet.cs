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
using Amazon.PartnerCentralChannel;
using Amazon.PartnerCentralChannel.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCC
{
    /// <summary>
    /// Lists channel contracts based on specified criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "PCCChannelContractList")]
    [OutputType("Amazon.PartnerCentralChannel.Model.ChannelContractSummary")]
    [AWSCmdlet("Calls the Partner Central Channel API ListChannelContracts API operation.", Operation = new[] {"ListChannelContracts"}, SelectReturnType = typeof(Amazon.PartnerCentralChannel.Model.ListChannelContractsResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralChannel.Model.ChannelContractSummary or Amazon.PartnerCentralChannel.Model.ListChannelContractsResponse",
        "This cmdlet returns a collection of Amazon.PartnerCentralChannel.Model.ChannelContractSummary objects.",
        "The service call response (type Amazon.PartnerCentralChannel.Model.ListChannelContractsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCCChannelContractListCmdlet : AmazonPartnerCentralChannelClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier to filter channel contracts.</para>
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
        
        #region Parameter ContractType
        /// <summary>
        /// <para>
        /// <para>Filter results by contract type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.ChannelContractType")]
        public Amazon.PartnerCentralChannel.ChannelContractType ContractType { get; set; }
        #endregion
        
        #region Parameter ContractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName
        /// <summary>
        /// <para>
        /// <para>Filter by legal entity names.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityNames")]
        public System.String[] ContractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName { get; set; }
        #endregion
        
        #region Parameter ContractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier
        /// <summary>
        /// <para>
        /// <para>Filter by relationship identifiers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifiers")]
        public System.String[] ContractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier { get; set; }
        #endregion
        
        #region Parameter ContractTypeSort_ManagedServicesAttestationTypeSort_SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.ManagedServicesAttestationTypeSortName")]
        public Amazon.PartnerCentralChannel.ManagedServicesAttestationTypeSortName ContractTypeSort_ManagedServicesAttestationTypeSort_SortBy { get; set; }
        #endregion
        
        #region Parameter ContractTypeSort_ManagedServicesAttestationTypeSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order (ascending or descending).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.SortOrder")]
        public Amazon.PartnerCentralChannel.SortOrder ContractTypeSort_ManagedServicesAttestationTypeSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Filter results by channel contract status.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Statuses")]
        public System.String[] Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call.</para>
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
        /// <para>Token for retrieving the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralChannel.Model.ListChannelContractsResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralChannel.Model.ListChannelContractsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralChannel.Model.ListChannelContractsResponse, GetPCCChannelContractListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContractType = this.ContractType;
            #if MODULAR
            if (this.ContractType == null && ParameterWasBound(nameof(this.ContractType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContractType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ContractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName != null)
            {
                context.ContractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName = new List<System.String>(this.ContractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName);
            }
            if (this.ContractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier != null)
            {
                context.ContractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier = new List<System.String>(this.ContractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier);
            }
            context.ContractTypeSort_ManagedServicesAttestationTypeSort_SortBy = this.ContractTypeSort_ManagedServicesAttestationTypeSort_SortBy;
            context.ContractTypeSort_ManagedServicesAttestationTypeSort_SortOrder = this.ContractTypeSort_ManagedServicesAttestationTypeSort_SortOrder;
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
            if (this.Status != null)
            {
                context.Status = new List<System.String>(this.Status);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.PartnerCentralChannel.Model.ListChannelContractsRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ContractType != null)
            {
                request.ContractType = cmdletContext.ContractType;
            }
            
             // populate ContractTypeFilters
            var requestContractTypeFiltersIsNull = true;
            request.ContractTypeFilters = new Amazon.PartnerCentralChannel.Model.ListChannelContractsTypeFilters();
            Amazon.PartnerCentralChannel.Model.ManagedServicesAttestationTypeFilters requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters = null;
            
             // populate ManagedServicesAttestationTypeFilters
            var requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFiltersIsNull = true;
            requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters = new Amazon.PartnerCentralChannel.Model.ManagedServicesAttestationTypeFilters();
            List<System.String> requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName = null;
            if (cmdletContext.ContractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName != null)
            {
                requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName = cmdletContext.ContractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName;
            }
            if (requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName != null)
            {
                requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters.LegalEntityNames = requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName;
                requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFiltersIsNull = false;
            }
            List<System.String> requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier = null;
            if (cmdletContext.ContractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier != null)
            {
                requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier = cmdletContext.ContractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier;
            }
            if (requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier != null)
            {
                requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters.RelationshipIdentifiers = requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier;
                requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFiltersIsNull = false;
            }
             // determine if requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters should be set to null
            if (requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFiltersIsNull)
            {
                requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters = null;
            }
            if (requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters != null)
            {
                request.ContractTypeFilters.ManagedServicesAttestationTypeFilters = requestContractTypeFilters_contractTypeFilters_ManagedServicesAttestationTypeFilters;
                requestContractTypeFiltersIsNull = false;
            }
             // determine if request.ContractTypeFilters should be set to null
            if (requestContractTypeFiltersIsNull)
            {
                request.ContractTypeFilters = null;
            }
            
             // populate ContractTypeSort
            var requestContractTypeSortIsNull = true;
            request.ContractTypeSort = new Amazon.PartnerCentralChannel.Model.ListChannelContractsTypeSort();
            Amazon.PartnerCentralChannel.Model.ManagedServicesAttestationTypeSort requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort = null;
            
             // populate ManagedServicesAttestationTypeSort
            var requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSortIsNull = true;
            requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort = new Amazon.PartnerCentralChannel.Model.ManagedServicesAttestationTypeSort();
            Amazon.PartnerCentralChannel.ManagedServicesAttestationTypeSortName requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_SortBy = null;
            if (cmdletContext.ContractTypeSort_ManagedServicesAttestationTypeSort_SortBy != null)
            {
                requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_SortBy = cmdletContext.ContractTypeSort_ManagedServicesAttestationTypeSort_SortBy;
            }
            if (requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_SortBy != null)
            {
                requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort.SortBy = requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_SortBy;
                requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSortIsNull = false;
            }
            Amazon.PartnerCentralChannel.SortOrder requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_SortOrder = null;
            if (cmdletContext.ContractTypeSort_ManagedServicesAttestationTypeSort_SortOrder != null)
            {
                requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_SortOrder = cmdletContext.ContractTypeSort_ManagedServicesAttestationTypeSort_SortOrder;
            }
            if (requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_SortOrder != null)
            {
                requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort.SortOrder = requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort_SortOrder;
                requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSortIsNull = false;
            }
             // determine if requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort should be set to null
            if (requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSortIsNull)
            {
                requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort = null;
            }
            if (requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort != null)
            {
                request.ContractTypeSort.ManagedServicesAttestationTypeSort = requestContractTypeSort_contractTypeSort_ManagedServicesAttestationTypeSort;
                requestContractTypeSortIsNull = false;
            }
             // determine if request.ContractTypeSort should be set to null
            if (requestContractTypeSortIsNull)
            {
                request.ContractTypeSort = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Status != null)
            {
                request.Statuses = cmdletContext.Status;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
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
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.PartnerCentralChannel.Model.ListChannelContractsResponse CallAWSServiceOperation(IAmazonPartnerCentralChannel client, Amazon.PartnerCentralChannel.Model.ListChannelContractsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Channel API", "ListChannelContracts");
            try
            {
                return client.ListChannelContractsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PartnerCentralChannel.ChannelContractType ContractType { get; set; }
            public List<System.String> ContractTypeFilters_ManagedServicesAttestationTypeFilters_LegalEntityName { get; set; }
            public List<System.String> ContractTypeFilters_ManagedServicesAttestationTypeFilters_RelationshipIdentifier { get; set; }
            public Amazon.PartnerCentralChannel.ManagedServicesAttestationTypeSortName ContractTypeSort_ManagedServicesAttestationTypeSort_SortBy { get; set; }
            public Amazon.PartnerCentralChannel.SortOrder ContractTypeSort_ManagedServicesAttestationTypeSort_SortOrder { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Status { get; set; }
            public System.Func<Amazon.PartnerCentralChannel.Model.ListChannelContractsResponse, GetPCCChannelContractListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
