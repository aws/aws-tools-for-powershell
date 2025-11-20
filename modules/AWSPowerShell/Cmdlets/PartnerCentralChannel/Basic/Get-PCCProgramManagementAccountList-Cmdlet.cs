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
using Amazon.PartnerCentralChannel;
using Amazon.PartnerCentralChannel.Model;

namespace Amazon.PowerShell.Cmdlets.PCC
{
    /// <summary>
    /// Lists program management accounts based on specified criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "PCCProgramManagementAccountList")]
    [OutputType("Amazon.PartnerCentralChannel.Model.ProgramManagementAccountSummary")]
    [AWSCmdlet("Calls the Partner Central Channel API ListProgramManagementAccounts API operation.", Operation = new[] {"ListProgramManagementAccounts"}, SelectReturnType = typeof(Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralChannel.Model.ProgramManagementAccountSummary or Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsResponse",
        "This cmdlet returns a collection of Amazon.PartnerCentralChannel.Model.ProgramManagementAccountSummary objects.",
        "The service call response (type Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCCProgramManagementAccountListCmdlet : AmazonPartnerCentralChannelClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>Filter by AWS account IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier to filter accounts.</para>
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
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>Filter by display names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisplayNames")]
        public System.String[] DisplayName { get; set; }
        #endregion
        
        #region Parameter Program
        /// <summary>
        /// <para>
        /// <para>Filter by program types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Programs")]
        public System.String[] Program { get; set; }
        #endregion
        
        #region Parameter Sort_SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.ListProgramManagementAccountsSortName")]
        public Amazon.PartnerCentralChannel.ListProgramManagementAccountsSortName Sort_SortBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order (ascending or descending).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.SortOrder")]
        public Amazon.PartnerCentralChannel.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Filter by program management account statuses.</para>
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
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Catalog parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsResponse, GetPCCProgramManagementAccountListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Catalog;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DisplayName != null)
            {
                context.DisplayName = new List<System.String>(this.DisplayName);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.Program != null)
            {
                context.Program = new List<System.String>(this.Program);
            }
            context.Sort_SortBy = this.Sort_SortBy;
            context.Sort_SortOrder = this.Sort_SortOrder;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayNames = cmdletContext.DisplayName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Program != null)
            {
                request.Programs = cmdletContext.Program;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsSortBase();
            Amazon.PartnerCentralChannel.ListProgramManagementAccountsSortName requestSort_sort_SortBy = null;
            if (cmdletContext.Sort_SortBy != null)
            {
                requestSort_sort_SortBy = cmdletContext.Sort_SortBy;
            }
            if (requestSort_sort_SortBy != null)
            {
                request.Sort.SortBy = requestSort_sort_SortBy;
                requestSortIsNull = false;
            }
            Amazon.PartnerCentralChannel.SortOrder requestSort_sort_SortOrder = null;
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
        
        private Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsResponse CallAWSServiceOperation(IAmazonPartnerCentralChannel client, Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Channel API", "ListProgramManagementAccounts");
            try
            {
                #if DESKTOP
                return client.ListProgramManagementAccounts(request);
                #elif CORECLR
                return client.ListProgramManagementAccountsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public System.String Catalog { get; set; }
            public List<System.String> DisplayName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Program { get; set; }
            public Amazon.PartnerCentralChannel.ListProgramManagementAccountsSortName Sort_SortBy { get; set; }
            public Amazon.PartnerCentralChannel.SortOrder Sort_SortOrder { get; set; }
            public List<System.String> Status { get; set; }
            public System.Func<Amazon.PartnerCentralChannel.Model.ListProgramManagementAccountsResponse, GetPCCProgramManagementAccountListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
