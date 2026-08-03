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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Lists the routes for the specified virtual interface.
    /// 
    ///  
    /// <para>
    /// Use the <c>routeDirection</c> filter to control which routes are returned:
    /// </para><ul><li><para><c>accepted</c>: routes received from the customer network over the virtual interface.
    /// </para></li><li><para><c>advertised</c>: routes advertised to the customer network over the virtual interface.
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DCVirtualInterfaceRouteList")]
    [OutputType("Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect ListVirtualInterfaceRoutes API operation.", Operation = new[] {"ListVirtualInterfaceRoutes"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesResponse object containing multiple properties."
    )]
    public partial class GetDCVirtualInterfaceRouteListCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_AddressFamily
        /// <summary>
        /// <para>
        /// <para>The address family of the routes to return.</para><para>The valid values are <c>ipv4</c> and <c>ipv6</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily Filters_AddressFamily { get; set; }
        #endregion
        
        #region Parameter Filters_AsPath
        /// <summary>
        /// <para>
        /// <para>The autonomous system (AS) numbers used to filter the routes by their AS path.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64[] Filters_AsPath { get; set; }
        #endregion
        
        #region Parameter Filters_Cidr
        /// <summary>
        /// <para>
        /// <para>The CIDRs (prefixes) used to filter the routes. You can specify up to 10 CIDRs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Cidrs")]
        public System.String[] Filters_Cidr { get; set; }
        #endregion
        
        #region Parameter Filters_Community
        /// <summary>
        /// <para>
        /// <para>The BGP communities used to filter the routes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Communities")]
        public System.String[] Filters_Community { get; set; }
        #endregion
        
        #region Parameter Filters_RouteDirection
        /// <summary>
        /// <para>
        /// <para>The direction of the routes to return.</para><para>The valid values are <c>accepted</c> (routes received from the customer network) and
        /// <c>advertised</c> (routes advertised to the customer network).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.RouteDirection")]
        public Amazon.DirectConnect.RouteDirection Filters_RouteDirection { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VirtualInterfaceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para><para>If <c>MaxResults</c> is given a value larger than 100, only 100 results are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesResponse, GetDCVirtualInterfaceRouteListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filters_AddressFamily = this.Filters_AddressFamily;
            if (this.Filters_AsPath != null)
            {
                context.Filters_AsPath = new List<System.Int64>(this.Filters_AsPath);
            }
            if (this.Filters_Cidr != null)
            {
                context.Filters_Cidr = new List<System.String>(this.Filters_Cidr);
            }
            if (this.Filters_Community != null)
            {
                context.Filters_Community = new List<System.String>(this.Filters_Community);
            }
            context.Filters_RouteDirection = this.Filters_RouteDirection;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.VirtualInterfaceId = this.VirtualInterfaceId;
            
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
            var request = new Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.DirectConnect.Model.RouteFilters();
            Amazon.DirectConnect.AddressFamily requestFilters_filters_AddressFamily = null;
            if (cmdletContext.Filters_AddressFamily != null)
            {
                requestFilters_filters_AddressFamily = cmdletContext.Filters_AddressFamily;
            }
            if (requestFilters_filters_AddressFamily != null)
            {
                request.Filters.AddressFamily = requestFilters_filters_AddressFamily;
                requestFiltersIsNull = false;
            }
            List<System.Int64> requestFilters_filters_AsPath = null;
            if (cmdletContext.Filters_AsPath != null)
            {
                requestFilters_filters_AsPath = cmdletContext.Filters_AsPath;
            }
            if (requestFilters_filters_AsPath != null)
            {
                request.Filters.AsPath = requestFilters_filters_AsPath;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Cidr = null;
            if (cmdletContext.Filters_Cidr != null)
            {
                requestFilters_filters_Cidr = cmdletContext.Filters_Cidr;
            }
            if (requestFilters_filters_Cidr != null)
            {
                request.Filters.Cidrs = requestFilters_filters_Cidr;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Community = null;
            if (cmdletContext.Filters_Community != null)
            {
                requestFilters_filters_Community = cmdletContext.Filters_Community;
            }
            if (requestFilters_filters_Community != null)
            {
                request.Filters.Communities = requestFilters_filters_Community;
                requestFiltersIsNull = false;
            }
            Amazon.DirectConnect.RouteDirection requestFilters_filters_RouteDirection = null;
            if (cmdletContext.Filters_RouteDirection != null)
            {
                requestFilters_filters_RouteDirection = cmdletContext.Filters_RouteDirection;
            }
            if (requestFilters_filters_RouteDirection != null)
            {
                request.Filters.RouteDirection = requestFilters_filters_RouteDirection;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.VirtualInterfaceId != null)
            {
                request.VirtualInterfaceId = cmdletContext.VirtualInterfaceId;
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
        
        private Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "ListVirtualInterfaceRoutes");
            try
            {
                return client.ListVirtualInterfaceRoutesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.DirectConnect.AddressFamily Filters_AddressFamily { get; set; }
            public List<System.Int64> Filters_AsPath { get; set; }
            public List<System.String> Filters_Cidr { get; set; }
            public List<System.String> Filters_Community { get; set; }
            public Amazon.DirectConnect.RouteDirection Filters_RouteDirection { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String VirtualInterfaceId { get; set; }
            public System.Func<Amazon.DirectConnect.Model.ListVirtualInterfaceRoutesResponse, GetDCVirtualInterfaceRouteListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
