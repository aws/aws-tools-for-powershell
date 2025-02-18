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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// This action allows users to retrieve a list of Engagement records from Partner Central.
    /// This action can be used to manage and track various engagements across different stages
    /// of the partner selling process.
    /// </summary>
    [Cmdlet("Get", "PCEngagementList")]
    [OutputType("Amazon.PartnerCentralSelling.Model.EngagementSummary")]
    [AWSCmdlet("Calls the Partner Central Selling API ListEngagements API operation.", Operation = new[] {"ListEngagements"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.ListEngagementsResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.EngagementSummary or Amazon.PartnerCentralSelling.Model.ListEngagementsResponse",
        "This cmdlet returns a collection of Amazon.PartnerCentralSelling.Model.EngagementSummary objects.",
        "The service call response (type Amazon.PartnerCentralSelling.Model.ListEngagementsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCEngagementListCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para> Specifies the catalog related to the request. </para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter CreatedBy
        /// <summary>
        /// <para>
        /// <para> A list of AWS account IDs. When specified, the response includes engagements created
        /// by these accounts. This filter is useful for finding engagements created by specific
        /// team members. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CreatedBy { get; set; }
        #endregion
        
        #region Parameter EngagementIdentifier
        /// <summary>
        /// <para>
        /// <para>An array of strings representing engagement identifiers to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EngagementIdentifier { get; set; }
        #endregion
        
        #region Parameter ExcludeCreatedBy
        /// <summary>
        /// <para>
        /// <para>An array of strings representing AWS Account IDs. Use this to exclude engagements
        /// created by specific users. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ExcludeCreatedBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortBy
        /// <summary>
        /// <para>
        /// <para>The field by which to sort the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.EngagementSortName")]
        public Amazon.PartnerCentralSelling.EngagementSortName Sort_SortBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order in which to sort the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.SortOrder")]
        public Amazon.PartnerCentralSelling.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. This value is returned from a previous call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EngagementSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.ListEngagementsResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.ListEngagementsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EngagementSummaryList";
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
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.ListEngagementsResponse, GetPCEngagementListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CreatedBy != null)
            {
                context.CreatedBy = new List<System.String>(this.CreatedBy);
            }
            if (this.EngagementIdentifier != null)
            {
                context.EngagementIdentifier = new List<System.String>(this.EngagementIdentifier);
            }
            if (this.ExcludeCreatedBy != null)
            {
                context.ExcludeCreatedBy = new List<System.String>(this.ExcludeCreatedBy);
            }
            context.MaxResult = this.MaxResult;
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
            // create request
            var request = new Amazon.PartnerCentralSelling.Model.ListEngagementsRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.CreatedBy != null)
            {
                request.CreatedBy = cmdletContext.CreatedBy;
            }
            if (cmdletContext.EngagementIdentifier != null)
            {
                request.EngagementIdentifier = cmdletContext.EngagementIdentifier;
            }
            if (cmdletContext.ExcludeCreatedBy != null)
            {
                request.ExcludeCreatedBy = cmdletContext.ExcludeCreatedBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.PartnerCentralSelling.Model.EngagementSort();
            Amazon.PartnerCentralSelling.EngagementSortName requestSort_sort_SortBy = null;
            if (cmdletContext.Sort_SortBy != null)
            {
                requestSort_sort_SortBy = cmdletContext.Sort_SortBy;
            }
            if (requestSort_sort_SortBy != null)
            {
                request.Sort.SortBy = requestSort_sort_SortBy;
                requestSortIsNull = false;
            }
            Amazon.PartnerCentralSelling.SortOrder requestSort_sort_SortOrder = null;
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
        
        private Amazon.PartnerCentralSelling.Model.ListEngagementsResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.ListEngagementsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "ListEngagements");
            try
            {
                return client.ListEngagementsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CreatedBy { get; set; }
            public List<System.String> EngagementIdentifier { get; set; }
            public List<System.String> ExcludeCreatedBy { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.PartnerCentralSelling.EngagementSortName Sort_SortBy { get; set; }
            public Amazon.PartnerCentralSelling.SortOrder Sort_SortOrder { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.ListEngagementsResponse, GetPCEngagementListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EngagementSummaryList;
        }
        
    }
}
