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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Starts an asynchronous search over the data in a workspace. The search runs in the
    /// background; the response returns immediately with a <c>searchId</c> and an initial
    /// status of <c>QUEUED</c>. Use <c>DescribeSearch</c> to poll for completion and <c>GetSearchResults</c>
    /// to retrieve the results once the search reaches <c>SUCCEEDED</c>. The request is idempotent
    /// on <c>clientToken</c>: repeating a call with the same token returns the original search
    /// instead of starting a new one.
    /// </summary>
    [Cmdlet("Start", "IOTSWSearch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.StartSearchResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise StartSearch API operation.", Operation = new[] {"StartSearch"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.StartSearchResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.StartSearchResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.StartSearchResponse object containing multiple properties."
    )]
    public partial class StartIOTSWSearchCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SearchFilters_DatasetId
        /// <summary>
        /// <para>
        /// <para>Restricts the search to these datasets.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilters_DatasetIds")]
        public System.String[] SearchFilters_DatasetId { get; set; }
        #endregion
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>An optional caller-supplied identifier used to group related searches together.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter QueryStatement
        /// <summary>
        /// <para>
        /// <para>The natural-language query describing the data to search for.</para>
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
        public System.String QueryStatement { get; set; }
        #endregion
        
        #region Parameter SearchType
        /// <summary>
        /// <para>
        /// <para>The search strategy to use. Defaults to <c>QUICK</c> when omitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.SearchType")]
        public Amazon.IoTSiteWise.SearchType SearchType { get; set; }
        #endregion
        
        #region Parameter SearchFilters_TimeInterval
        /// <summary>
        /// <para>
        /// <para>Restricts the search to these time intervals.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilters_TimeIntervals")]
        public Amazon.IoTSiteWise.Model.TimeInterval[] SearchFilters_TimeInterval { get; set; }
        #endregion
        
        #region Parameter SearchFilters_TimeSeriesId
        /// <summary>
        /// <para>
        /// <para>Restricts the search to these time series.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilters_TimeSeriesIds")]
        public System.String[] SearchFilters_TimeSeriesId { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the workspace whose data is searched.</para>
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
        public System.String WorkspaceName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier you provide to ensure the request is idempotent.
        /// Repeating a StartSearch call with the same <c>clientToken</c> returns the original
        /// search rather than starting a new one. If omitted, the SDK autogenerates one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.StartSearchResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.StartSearchResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTSWSearch (StartSearch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.StartSearchResponse, StartIOTSWSearchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.GroupId = this.GroupId;
            context.QueryStatement = this.QueryStatement;
            #if MODULAR
            if (this.QueryStatement == null && ParameterWasBound(nameof(this.QueryStatement)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryStatement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SearchFilters_DatasetId != null)
            {
                context.SearchFilters_DatasetId = new List<System.String>(this.SearchFilters_DatasetId);
            }
            if (this.SearchFilters_TimeInterval != null)
            {
                context.SearchFilters_TimeInterval = new List<Amazon.IoTSiteWise.Model.TimeInterval>(this.SearchFilters_TimeInterval);
            }
            if (this.SearchFilters_TimeSeriesId != null)
            {
                context.SearchFilters_TimeSeriesId = new List<System.String>(this.SearchFilters_TimeSeriesId);
            }
            context.SearchType = this.SearchType;
            context.WorkspaceName = this.WorkspaceName;
            #if MODULAR
            if (this.WorkspaceName == null && ParameterWasBound(nameof(this.WorkspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.StartSearchRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            if (cmdletContext.QueryStatement != null)
            {
                request.QueryStatement = cmdletContext.QueryStatement;
            }
            
             // populate SearchFilters
            var requestSearchFiltersIsNull = true;
            request.SearchFilters = new Amazon.IoTSiteWise.Model.SearchFilters();
            List<System.String> requestSearchFilters_searchFilters_DatasetId = null;
            if (cmdletContext.SearchFilters_DatasetId != null)
            {
                requestSearchFilters_searchFilters_DatasetId = cmdletContext.SearchFilters_DatasetId;
            }
            if (requestSearchFilters_searchFilters_DatasetId != null)
            {
                request.SearchFilters.DatasetIds = requestSearchFilters_searchFilters_DatasetId;
                requestSearchFiltersIsNull = false;
            }
            List<Amazon.IoTSiteWise.Model.TimeInterval> requestSearchFilters_searchFilters_TimeInterval = null;
            if (cmdletContext.SearchFilters_TimeInterval != null)
            {
                requestSearchFilters_searchFilters_TimeInterval = cmdletContext.SearchFilters_TimeInterval;
            }
            if (requestSearchFilters_searchFilters_TimeInterval != null)
            {
                request.SearchFilters.TimeIntervals = requestSearchFilters_searchFilters_TimeInterval;
                requestSearchFiltersIsNull = false;
            }
            List<System.String> requestSearchFilters_searchFilters_TimeSeriesId = null;
            if (cmdletContext.SearchFilters_TimeSeriesId != null)
            {
                requestSearchFilters_searchFilters_TimeSeriesId = cmdletContext.SearchFilters_TimeSeriesId;
            }
            if (requestSearchFilters_searchFilters_TimeSeriesId != null)
            {
                request.SearchFilters.TimeSeriesIds = requestSearchFilters_searchFilters_TimeSeriesId;
                requestSearchFiltersIsNull = false;
            }
             // determine if request.SearchFilters should be set to null
            if (requestSearchFiltersIsNull)
            {
                request.SearchFilters = null;
            }
            if (cmdletContext.SearchType != null)
            {
                request.SearchType = cmdletContext.SearchType;
            }
            if (cmdletContext.WorkspaceName != null)
            {
                request.WorkspaceName = cmdletContext.WorkspaceName;
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
        
        private Amazon.IoTSiteWise.Model.StartSearchResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.StartSearchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "StartSearch");
            try
            {
                return client.StartSearchAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String GroupId { get; set; }
            public System.String QueryStatement { get; set; }
            public List<System.String> SearchFilters_DatasetId { get; set; }
            public List<Amazon.IoTSiteWise.Model.TimeInterval> SearchFilters_TimeInterval { get; set; }
            public List<System.String> SearchFilters_TimeSeriesId { get; set; }
            public Amazon.IoTSiteWise.SearchType SearchType { get; set; }
            public System.String WorkspaceName { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.StartSearchResponse, StartIOTSWSearchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
