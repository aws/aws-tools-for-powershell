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
    /// Lists channel handshakes based on specified criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "PCCChannelHandshakeList")]
    [OutputType("Amazon.PartnerCentralChannel.Model.ChannelHandshakeSummary")]
    [AWSCmdlet("Calls the Partner Central Channel API ListChannelHandshakes API operation.", Operation = new[] {"ListChannelHandshakes"}, SelectReturnType = typeof(Amazon.PartnerCentralChannel.Model.ListChannelHandshakesResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralChannel.Model.ChannelHandshakeSummary or Amazon.PartnerCentralChannel.Model.ListChannelHandshakesResponse",
        "This cmdlet returns a collection of Amazon.PartnerCentralChannel.Model.ChannelHandshakeSummary objects.",
        "The service call response (type Amazon.PartnerCentralChannel.Model.ListChannelHandshakesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCCChannelHandshakeListCmdlet : AmazonPartnerCentralChannelClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociatedResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>Filter by associated resource identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociatedResourceIdentifiers")]
        public System.String[] AssociatedResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier to filter handshakes.</para>
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
        
        #region Parameter HandshakeType
        /// <summary>
        /// <para>
        /// <para>Filter results by handshake type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.HandshakeType")]
        public Amazon.PartnerCentralChannel.HandshakeType HandshakeType { get; set; }
        #endregion
        
        #region Parameter ParticipantType
        /// <summary>
        /// <para>
        /// <para>Filter by participant type (sender or receiver).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.ParticipantType")]
        public Amazon.PartnerCentralChannel.ParticipantType ParticipantType { get; set; }
        #endregion
        
        #region Parameter ProgramManagementAccountTypeFilters_Program
        /// <summary>
        /// <para>
        /// <para>Filter by program types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandshakeTypeFilters_ProgramManagementAccountTypeFilters_Programs")]
        public System.String[] ProgramManagementAccountTypeFilters_Program { get; set; }
        #endregion
        
        #region Parameter RevokeServicePeriodTypeFilters_ServicePeriodType
        /// <summary>
        /// <para>
        /// <para>Filter by service period types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandshakeTypeFilters_RevokeServicePeriodTypeFilters_ServicePeriodTypes")]
        public System.String[] RevokeServicePeriodTypeFilters_ServicePeriodType { get; set; }
        #endregion
        
        #region Parameter StartServicePeriodTypeFilters_ServicePeriodType
        /// <summary>
        /// <para>
        /// <para>Filter by service period types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandshakeTypeFilters_StartServicePeriodTypeFilters_ServicePeriodTypes")]
        public System.String[] StartServicePeriodTypeFilters_ServicePeriodType { get; set; }
        #endregion
        
        #region Parameter ProgramManagementAccountTypeSort_SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandshakeTypeSort_ProgramManagementAccountTypeSort_SortBy")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.ProgramManagementAccountTypeSortName")]
        public Amazon.PartnerCentralChannel.ProgramManagementAccountTypeSortName ProgramManagementAccountTypeSort_SortBy { get; set; }
        #endregion
        
        #region Parameter RevokeServicePeriodTypeSort_SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandshakeTypeSort_RevokeServicePeriodTypeSort_SortBy")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.RevokeServicePeriodTypeSortName")]
        public Amazon.PartnerCentralChannel.RevokeServicePeriodTypeSortName RevokeServicePeriodTypeSort_SortBy { get; set; }
        #endregion
        
        #region Parameter StartServicePeriodTypeSort_SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandshakeTypeSort_StartServicePeriodTypeSort_SortBy")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.StartServicePeriodTypeSortName")]
        public Amazon.PartnerCentralChannel.StartServicePeriodTypeSortName StartServicePeriodTypeSort_SortBy { get; set; }
        #endregion
        
        #region Parameter ProgramManagementAccountTypeSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order (ascending or descending).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandshakeTypeSort_ProgramManagementAccountTypeSort_SortOrder")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.SortOrder")]
        public Amazon.PartnerCentralChannel.SortOrder ProgramManagementAccountTypeSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter RevokeServicePeriodTypeSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order (ascending or descending).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandshakeTypeSort_RevokeServicePeriodTypeSort_SortOrder")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.SortOrder")]
        public Amazon.PartnerCentralChannel.SortOrder RevokeServicePeriodTypeSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter StartServicePeriodTypeSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order (ascending or descending).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandshakeTypeSort_StartServicePeriodTypeSort_SortOrder")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.SortOrder")]
        public Amazon.PartnerCentralChannel.SortOrder StartServicePeriodTypeSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Filter results by handshake status.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralChannel.Model.ListChannelHandshakesResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralChannel.Model.ListChannelHandshakesResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralChannel.Model.ListChannelHandshakesResponse, GetPCCChannelHandshakeListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssociatedResourceIdentifier != null)
            {
                context.AssociatedResourceIdentifier = new List<System.String>(this.AssociatedResourceIdentifier);
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HandshakeType = this.HandshakeType;
            #if MODULAR
            if (this.HandshakeType == null && ParameterWasBound(nameof(this.HandshakeType)))
            {
                WriteWarning("You are passing $null as a value for parameter HandshakeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ProgramManagementAccountTypeFilters_Program != null)
            {
                context.ProgramManagementAccountTypeFilters_Program = new List<System.String>(this.ProgramManagementAccountTypeFilters_Program);
            }
            if (this.RevokeServicePeriodTypeFilters_ServicePeriodType != null)
            {
                context.RevokeServicePeriodTypeFilters_ServicePeriodType = new List<System.String>(this.RevokeServicePeriodTypeFilters_ServicePeriodType);
            }
            if (this.StartServicePeriodTypeFilters_ServicePeriodType != null)
            {
                context.StartServicePeriodTypeFilters_ServicePeriodType = new List<System.String>(this.StartServicePeriodTypeFilters_ServicePeriodType);
            }
            context.ProgramManagementAccountTypeSort_SortBy = this.ProgramManagementAccountTypeSort_SortBy;
            context.ProgramManagementAccountTypeSort_SortOrder = this.ProgramManagementAccountTypeSort_SortOrder;
            context.RevokeServicePeriodTypeSort_SortBy = this.RevokeServicePeriodTypeSort_SortBy;
            context.RevokeServicePeriodTypeSort_SortOrder = this.RevokeServicePeriodTypeSort_SortOrder;
            context.StartServicePeriodTypeSort_SortBy = this.StartServicePeriodTypeSort_SortBy;
            context.StartServicePeriodTypeSort_SortOrder = this.StartServicePeriodTypeSort_SortOrder;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ParticipantType = this.ParticipantType;
            #if MODULAR
            if (this.ParticipantType == null && ParameterWasBound(nameof(this.ParticipantType)))
            {
                WriteWarning("You are passing $null as a value for parameter ParticipantType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.PartnerCentralChannel.Model.ListChannelHandshakesRequest();
            
            if (cmdletContext.AssociatedResourceIdentifier != null)
            {
                request.AssociatedResourceIdentifiers = cmdletContext.AssociatedResourceIdentifier;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.HandshakeType != null)
            {
                request.HandshakeType = cmdletContext.HandshakeType;
            }
            
             // populate HandshakeTypeFilters
            var requestHandshakeTypeFiltersIsNull = true;
            request.HandshakeTypeFilters = new Amazon.PartnerCentralChannel.Model.ListChannelHandshakesTypeFilters();
            Amazon.PartnerCentralChannel.Model.ProgramManagementAccountTypeFilters requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters = null;
            
             // populate ProgramManagementAccountTypeFilters
            var requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFiltersIsNull = true;
            requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters = new Amazon.PartnerCentralChannel.Model.ProgramManagementAccountTypeFilters();
            List<System.String> requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters_programManagementAccountTypeFilters_Program = null;
            if (cmdletContext.ProgramManagementAccountTypeFilters_Program != null)
            {
                requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters_programManagementAccountTypeFilters_Program = cmdletContext.ProgramManagementAccountTypeFilters_Program;
            }
            if (requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters_programManagementAccountTypeFilters_Program != null)
            {
                requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters.Programs = requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters_programManagementAccountTypeFilters_Program;
                requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFiltersIsNull = false;
            }
             // determine if requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters should be set to null
            if (requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFiltersIsNull)
            {
                requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters = null;
            }
            if (requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters != null)
            {
                request.HandshakeTypeFilters.ProgramManagementAccountTypeFilters = requestHandshakeTypeFilters_handshakeTypeFilters_ProgramManagementAccountTypeFilters;
                requestHandshakeTypeFiltersIsNull = false;
            }
            Amazon.PartnerCentralChannel.Model.RevokeServicePeriodTypeFilters requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters = null;
            
             // populate RevokeServicePeriodTypeFilters
            var requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFiltersIsNull = true;
            requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters = new Amazon.PartnerCentralChannel.Model.RevokeServicePeriodTypeFilters();
            List<System.String> requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters_revokeServicePeriodTypeFilters_ServicePeriodType = null;
            if (cmdletContext.RevokeServicePeriodTypeFilters_ServicePeriodType != null)
            {
                requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters_revokeServicePeriodTypeFilters_ServicePeriodType = cmdletContext.RevokeServicePeriodTypeFilters_ServicePeriodType;
            }
            if (requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters_revokeServicePeriodTypeFilters_ServicePeriodType != null)
            {
                requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters.ServicePeriodTypes = requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters_revokeServicePeriodTypeFilters_ServicePeriodType;
                requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFiltersIsNull = false;
            }
             // determine if requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters should be set to null
            if (requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFiltersIsNull)
            {
                requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters = null;
            }
            if (requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters != null)
            {
                request.HandshakeTypeFilters.RevokeServicePeriodTypeFilters = requestHandshakeTypeFilters_handshakeTypeFilters_RevokeServicePeriodTypeFilters;
                requestHandshakeTypeFiltersIsNull = false;
            }
            Amazon.PartnerCentralChannel.Model.StartServicePeriodTypeFilters requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters = null;
            
             // populate StartServicePeriodTypeFilters
            var requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFiltersIsNull = true;
            requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters = new Amazon.PartnerCentralChannel.Model.StartServicePeriodTypeFilters();
            List<System.String> requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters_startServicePeriodTypeFilters_ServicePeriodType = null;
            if (cmdletContext.StartServicePeriodTypeFilters_ServicePeriodType != null)
            {
                requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters_startServicePeriodTypeFilters_ServicePeriodType = cmdletContext.StartServicePeriodTypeFilters_ServicePeriodType;
            }
            if (requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters_startServicePeriodTypeFilters_ServicePeriodType != null)
            {
                requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters.ServicePeriodTypes = requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters_startServicePeriodTypeFilters_ServicePeriodType;
                requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFiltersIsNull = false;
            }
             // determine if requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters should be set to null
            if (requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFiltersIsNull)
            {
                requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters = null;
            }
            if (requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters != null)
            {
                request.HandshakeTypeFilters.StartServicePeriodTypeFilters = requestHandshakeTypeFilters_handshakeTypeFilters_StartServicePeriodTypeFilters;
                requestHandshakeTypeFiltersIsNull = false;
            }
             // determine if request.HandshakeTypeFilters should be set to null
            if (requestHandshakeTypeFiltersIsNull)
            {
                request.HandshakeTypeFilters = null;
            }
            
             // populate HandshakeTypeSort
            var requestHandshakeTypeSortIsNull = true;
            request.HandshakeTypeSort = new Amazon.PartnerCentralChannel.Model.ListChannelHandshakesTypeSort();
            Amazon.PartnerCentralChannel.Model.ProgramManagementAccountTypeSort requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort = null;
            
             // populate ProgramManagementAccountTypeSort
            var requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSortIsNull = true;
            requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort = new Amazon.PartnerCentralChannel.Model.ProgramManagementAccountTypeSort();
            Amazon.PartnerCentralChannel.ProgramManagementAccountTypeSortName requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort_programManagementAccountTypeSort_SortBy = null;
            if (cmdletContext.ProgramManagementAccountTypeSort_SortBy != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort_programManagementAccountTypeSort_SortBy = cmdletContext.ProgramManagementAccountTypeSort_SortBy;
            }
            if (requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort_programManagementAccountTypeSort_SortBy != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort.SortBy = requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort_programManagementAccountTypeSort_SortBy;
                requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSortIsNull = false;
            }
            Amazon.PartnerCentralChannel.SortOrder requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort_programManagementAccountTypeSort_SortOrder = null;
            if (cmdletContext.ProgramManagementAccountTypeSort_SortOrder != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort_programManagementAccountTypeSort_SortOrder = cmdletContext.ProgramManagementAccountTypeSort_SortOrder;
            }
            if (requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort_programManagementAccountTypeSort_SortOrder != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort.SortOrder = requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort_programManagementAccountTypeSort_SortOrder;
                requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSortIsNull = false;
            }
             // determine if requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort should be set to null
            if (requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSortIsNull)
            {
                requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort = null;
            }
            if (requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort != null)
            {
                request.HandshakeTypeSort.ProgramManagementAccountTypeSort = requestHandshakeTypeSort_handshakeTypeSort_ProgramManagementAccountTypeSort;
                requestHandshakeTypeSortIsNull = false;
            }
            Amazon.PartnerCentralChannel.Model.RevokeServicePeriodTypeSort requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort = null;
            
             // populate RevokeServicePeriodTypeSort
            var requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSortIsNull = true;
            requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort = new Amazon.PartnerCentralChannel.Model.RevokeServicePeriodTypeSort();
            Amazon.PartnerCentralChannel.RevokeServicePeriodTypeSortName requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort_revokeServicePeriodTypeSort_SortBy = null;
            if (cmdletContext.RevokeServicePeriodTypeSort_SortBy != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort_revokeServicePeriodTypeSort_SortBy = cmdletContext.RevokeServicePeriodTypeSort_SortBy;
            }
            if (requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort_revokeServicePeriodTypeSort_SortBy != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort.SortBy = requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort_revokeServicePeriodTypeSort_SortBy;
                requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSortIsNull = false;
            }
            Amazon.PartnerCentralChannel.SortOrder requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort_revokeServicePeriodTypeSort_SortOrder = null;
            if (cmdletContext.RevokeServicePeriodTypeSort_SortOrder != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort_revokeServicePeriodTypeSort_SortOrder = cmdletContext.RevokeServicePeriodTypeSort_SortOrder;
            }
            if (requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort_revokeServicePeriodTypeSort_SortOrder != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort.SortOrder = requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort_revokeServicePeriodTypeSort_SortOrder;
                requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSortIsNull = false;
            }
             // determine if requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort should be set to null
            if (requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSortIsNull)
            {
                requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort = null;
            }
            if (requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort != null)
            {
                request.HandshakeTypeSort.RevokeServicePeriodTypeSort = requestHandshakeTypeSort_handshakeTypeSort_RevokeServicePeriodTypeSort;
                requestHandshakeTypeSortIsNull = false;
            }
            Amazon.PartnerCentralChannel.Model.StartServicePeriodTypeSort requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort = null;
            
             // populate StartServicePeriodTypeSort
            var requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSortIsNull = true;
            requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort = new Amazon.PartnerCentralChannel.Model.StartServicePeriodTypeSort();
            Amazon.PartnerCentralChannel.StartServicePeriodTypeSortName requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort_startServicePeriodTypeSort_SortBy = null;
            if (cmdletContext.StartServicePeriodTypeSort_SortBy != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort_startServicePeriodTypeSort_SortBy = cmdletContext.StartServicePeriodTypeSort_SortBy;
            }
            if (requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort_startServicePeriodTypeSort_SortBy != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort.SortBy = requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort_startServicePeriodTypeSort_SortBy;
                requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSortIsNull = false;
            }
            Amazon.PartnerCentralChannel.SortOrder requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort_startServicePeriodTypeSort_SortOrder = null;
            if (cmdletContext.StartServicePeriodTypeSort_SortOrder != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort_startServicePeriodTypeSort_SortOrder = cmdletContext.StartServicePeriodTypeSort_SortOrder;
            }
            if (requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort_startServicePeriodTypeSort_SortOrder != null)
            {
                requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort.SortOrder = requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort_startServicePeriodTypeSort_SortOrder;
                requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSortIsNull = false;
            }
             // determine if requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort should be set to null
            if (requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSortIsNull)
            {
                requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort = null;
            }
            if (requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort != null)
            {
                request.HandshakeTypeSort.StartServicePeriodTypeSort = requestHandshakeTypeSort_handshakeTypeSort_StartServicePeriodTypeSort;
                requestHandshakeTypeSortIsNull = false;
            }
             // determine if request.HandshakeTypeSort should be set to null
            if (requestHandshakeTypeSortIsNull)
            {
                request.HandshakeTypeSort = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ParticipantType != null)
            {
                request.ParticipantType = cmdletContext.ParticipantType;
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
        
        private Amazon.PartnerCentralChannel.Model.ListChannelHandshakesResponse CallAWSServiceOperation(IAmazonPartnerCentralChannel client, Amazon.PartnerCentralChannel.Model.ListChannelHandshakesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Channel API", "ListChannelHandshakes");
            try
            {
                #if DESKTOP
                return client.ListChannelHandshakes(request);
                #elif CORECLR
                return client.ListChannelHandshakesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AssociatedResourceIdentifier { get; set; }
            public System.String Catalog { get; set; }
            public Amazon.PartnerCentralChannel.HandshakeType HandshakeType { get; set; }
            public List<System.String> ProgramManagementAccountTypeFilters_Program { get; set; }
            public List<System.String> RevokeServicePeriodTypeFilters_ServicePeriodType { get; set; }
            public List<System.String> StartServicePeriodTypeFilters_ServicePeriodType { get; set; }
            public Amazon.PartnerCentralChannel.ProgramManagementAccountTypeSortName ProgramManagementAccountTypeSort_SortBy { get; set; }
            public Amazon.PartnerCentralChannel.SortOrder ProgramManagementAccountTypeSort_SortOrder { get; set; }
            public Amazon.PartnerCentralChannel.RevokeServicePeriodTypeSortName RevokeServicePeriodTypeSort_SortBy { get; set; }
            public Amazon.PartnerCentralChannel.SortOrder RevokeServicePeriodTypeSort_SortOrder { get; set; }
            public Amazon.PartnerCentralChannel.StartServicePeriodTypeSortName StartServicePeriodTypeSort_SortBy { get; set; }
            public Amazon.PartnerCentralChannel.SortOrder StartServicePeriodTypeSort_SortOrder { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.PartnerCentralChannel.ParticipantType ParticipantType { get; set; }
            public List<System.String> Status { get; set; }
            public System.Func<Amazon.PartnerCentralChannel.Model.ListChannelHandshakesResponse, GetPCCChannelHandshakeListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
