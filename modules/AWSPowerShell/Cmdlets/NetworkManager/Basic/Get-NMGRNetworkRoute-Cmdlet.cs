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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Gets the network routes of the specified global network.
    /// </summary>
    [Cmdlet("Get", "NMGRNetworkRoute")]
    [OutputType("Amazon.NetworkManager.Model.GetNetworkRoutesResponse")]
    [AWSCmdlet("Calls the AWS Network Manager GetNetworkRoutes API operation.", Operation = new[] {"GetNetworkRoutes"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.GetNetworkRoutesResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.GetNetworkRoutesResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.GetNetworkRoutesResponse object containing multiple properties."
    )]
    public partial class GetNMGRNetworkRouteCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CoreNetworkNetworkFunctionGroup_CoreNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the core network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouteTableIdentifier_CoreNetworkNetworkFunctionGroup_CoreNetworkId")]
        public System.String CoreNetworkNetworkFunctionGroup_CoreNetworkId { get; set; }
        #endregion
        
        #region Parameter CoreNetworkSegmentEdge_CoreNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of a core network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouteTableIdentifier_CoreNetworkSegmentEdge_CoreNetworkId")]
        public System.String CoreNetworkSegmentEdge_CoreNetworkId { get; set; }
        #endregion
        
        #region Parameter DestinationFilter
        /// <summary>
        /// <para>
        /// <para>Filter by route table destination. Possible Values: TRANSIT_GATEWAY_ATTACHMENT_ID,
        /// RESOURCE_ID, or RESOURCE_TYPE.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationFilters")]
        public System.Collections.Hashtable DestinationFilter { get; set; }
        #endregion
        
        #region Parameter CoreNetworkNetworkFunctionGroup_EdgeLocation
        /// <summary>
        /// <para>
        /// <para>The location for the core network edge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouteTableIdentifier_CoreNetworkNetworkFunctionGroup_EdgeLocation")]
        public System.String CoreNetworkNetworkFunctionGroup_EdgeLocation { get; set; }
        #endregion
        
        #region Parameter CoreNetworkSegmentEdge_EdgeLocation
        /// <summary>
        /// <para>
        /// <para>The Region where the segment edge is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouteTableIdentifier_CoreNetworkSegmentEdge_EdgeLocation")]
        public System.String CoreNetworkSegmentEdge_EdgeLocation { get; set; }
        #endregion
        
        #region Parameter ExactCidrMatch
        /// <summary>
        /// <para>
        /// <para>An exact CIDR block.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExactCidrMatches")]
        public System.String[] ExactCidrMatch { get; set; }
        #endregion
        
        #region Parameter GlobalNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the global network.</para>
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
        public System.String GlobalNetworkId { get; set; }
        #endregion
        
        #region Parameter LongestPrefixMatch
        /// <summary>
        /// <para>
        /// <para>The most specific route that matches the traffic (longest prefix match).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LongestPrefixMatches")]
        public System.String[] LongestPrefixMatch { get; set; }
        #endregion
        
        #region Parameter CoreNetworkNetworkFunctionGroup_NetworkFunctionGroupName
        /// <summary>
        /// <para>
        /// <para>The network function group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouteTableIdentifier_CoreNetworkNetworkFunctionGroup_NetworkFunctionGroupName")]
        public System.String CoreNetworkNetworkFunctionGroup_NetworkFunctionGroupName { get; set; }
        #endregion
        
        #region Parameter PrefixListId
        /// <summary>
        /// <para>
        /// <para>The IDs of the prefix lists.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrefixListIds")]
        public System.String[] PrefixListId { get; set; }
        #endregion
        
        #region Parameter CoreNetworkSegmentEdge_SegmentName
        /// <summary>
        /// <para>
        /// <para>The name of the segment edge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouteTableIdentifier_CoreNetworkSegmentEdge_SegmentName")]
        public System.String CoreNetworkSegmentEdge_SegmentName { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The route states.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("States")]
        public System.String[] State { get; set; }
        #endregion
        
        #region Parameter SubnetOfMatch
        /// <summary>
        /// <para>
        /// <para>The routes with a subnet that match the specified CIDR filter.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetOfMatches")]
        public System.String[] SubnetOfMatch { get; set; }
        #endregion
        
        #region Parameter SupernetOfMatch
        /// <summary>
        /// <para>
        /// <para>The routes with a CIDR that encompasses the CIDR filter. Example: If you specify 10.0.1.0/30,
        /// then the result returns 10.0.1.0/29.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupernetOfMatches")]
        public System.String[] SupernetOfMatch { get; set; }
        #endregion
        
        #region Parameter RouteTableIdentifier_TransitGatewayRouteTableArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the transit gateway route table for the attachment request. For example,
        /// <c>"TransitGatewayRouteTableArn": "arn:aws:ec2:us-west-2:123456789012:transit-gateway-route-table/tgw-rtb-9876543210123456"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RouteTableIdentifier_TransitGatewayRouteTableArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The route types.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Types")]
        public System.String[] Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.GetNetworkRoutesResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.GetNetworkRoutesResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.GetNetworkRoutesResponse, GetNMGRNetworkRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DestinationFilter != null)
            {
                context.DestinationFilter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationFilter.Keys)
                {
                    object hashValue = this.DestinationFilter[hashKey];
                    if (hashValue == null)
                    {
                        context.DestinationFilter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.DestinationFilter.Add((String)hashKey, valueSet);
                }
            }
            if (this.ExactCidrMatch != null)
            {
                context.ExactCidrMatch = new List<System.String>(this.ExactCidrMatch);
            }
            context.GlobalNetworkId = this.GlobalNetworkId;
            #if MODULAR
            if (this.GlobalNetworkId == null && ParameterWasBound(nameof(this.GlobalNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LongestPrefixMatch != null)
            {
                context.LongestPrefixMatch = new List<System.String>(this.LongestPrefixMatch);
            }
            if (this.PrefixListId != null)
            {
                context.PrefixListId = new List<System.String>(this.PrefixListId);
            }
            context.CoreNetworkNetworkFunctionGroup_CoreNetworkId = this.CoreNetworkNetworkFunctionGroup_CoreNetworkId;
            context.CoreNetworkNetworkFunctionGroup_EdgeLocation = this.CoreNetworkNetworkFunctionGroup_EdgeLocation;
            context.CoreNetworkNetworkFunctionGroup_NetworkFunctionGroupName = this.CoreNetworkNetworkFunctionGroup_NetworkFunctionGroupName;
            context.CoreNetworkSegmentEdge_CoreNetworkId = this.CoreNetworkSegmentEdge_CoreNetworkId;
            context.CoreNetworkSegmentEdge_EdgeLocation = this.CoreNetworkSegmentEdge_EdgeLocation;
            context.CoreNetworkSegmentEdge_SegmentName = this.CoreNetworkSegmentEdge_SegmentName;
            context.RouteTableIdentifier_TransitGatewayRouteTableArn = this.RouteTableIdentifier_TransitGatewayRouteTableArn;
            if (this.State != null)
            {
                context.State = new List<System.String>(this.State);
            }
            if (this.SubnetOfMatch != null)
            {
                context.SubnetOfMatch = new List<System.String>(this.SubnetOfMatch);
            }
            if (this.SupernetOfMatch != null)
            {
                context.SupernetOfMatch = new List<System.String>(this.SupernetOfMatch);
            }
            if (this.Type != null)
            {
                context.Type = new List<System.String>(this.Type);
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
            // create request
            var request = new Amazon.NetworkManager.Model.GetNetworkRoutesRequest();
            
            if (cmdletContext.DestinationFilter != null)
            {
                request.DestinationFilters = cmdletContext.DestinationFilter;
            }
            if (cmdletContext.ExactCidrMatch != null)
            {
                request.ExactCidrMatches = cmdletContext.ExactCidrMatch;
            }
            if (cmdletContext.GlobalNetworkId != null)
            {
                request.GlobalNetworkId = cmdletContext.GlobalNetworkId;
            }
            if (cmdletContext.LongestPrefixMatch != null)
            {
                request.LongestPrefixMatches = cmdletContext.LongestPrefixMatch;
            }
            if (cmdletContext.PrefixListId != null)
            {
                request.PrefixListIds = cmdletContext.PrefixListId;
            }
            
             // populate RouteTableIdentifier
            request.RouteTableIdentifier = new Amazon.NetworkManager.Model.RouteTableIdentifier();
            System.String requestRouteTableIdentifier_routeTableIdentifier_TransitGatewayRouteTableArn = null;
            if (cmdletContext.RouteTableIdentifier_TransitGatewayRouteTableArn != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_TransitGatewayRouteTableArn = cmdletContext.RouteTableIdentifier_TransitGatewayRouteTableArn;
            }
            if (requestRouteTableIdentifier_routeTableIdentifier_TransitGatewayRouteTableArn != null)
            {
                request.RouteTableIdentifier.TransitGatewayRouteTableArn = requestRouteTableIdentifier_routeTableIdentifier_TransitGatewayRouteTableArn;
            }
            Amazon.NetworkManager.Model.CoreNetworkNetworkFunctionGroupIdentifier requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup = null;
            
             // populate CoreNetworkNetworkFunctionGroup
            var requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroupIsNull = true;
            requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup = new Amazon.NetworkManager.Model.CoreNetworkNetworkFunctionGroupIdentifier();
            System.String requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_CoreNetworkId = null;
            if (cmdletContext.CoreNetworkNetworkFunctionGroup_CoreNetworkId != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_CoreNetworkId = cmdletContext.CoreNetworkNetworkFunctionGroup_CoreNetworkId;
            }
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_CoreNetworkId != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup.CoreNetworkId = requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_CoreNetworkId;
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroupIsNull = false;
            }
            System.String requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_EdgeLocation = null;
            if (cmdletContext.CoreNetworkNetworkFunctionGroup_EdgeLocation != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_EdgeLocation = cmdletContext.CoreNetworkNetworkFunctionGroup_EdgeLocation;
            }
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_EdgeLocation != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup.EdgeLocation = requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_EdgeLocation;
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroupIsNull = false;
            }
            System.String requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_NetworkFunctionGroupName = null;
            if (cmdletContext.CoreNetworkNetworkFunctionGroup_NetworkFunctionGroupName != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_NetworkFunctionGroupName = cmdletContext.CoreNetworkNetworkFunctionGroup_NetworkFunctionGroupName;
            }
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_NetworkFunctionGroupName != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup.NetworkFunctionGroupName = requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup_coreNetworkNetworkFunctionGroup_NetworkFunctionGroupName;
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroupIsNull = false;
            }
             // determine if requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup should be set to null
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroupIsNull)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup = null;
            }
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup != null)
            {
                request.RouteTableIdentifier.CoreNetworkNetworkFunctionGroup = requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkNetworkFunctionGroup;
            }
            Amazon.NetworkManager.Model.CoreNetworkSegmentEdgeIdentifier requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge = null;
            
             // populate CoreNetworkSegmentEdge
            var requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdgeIsNull = true;
            requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge = new Amazon.NetworkManager.Model.CoreNetworkSegmentEdgeIdentifier();
            System.String requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_CoreNetworkId = null;
            if (cmdletContext.CoreNetworkSegmentEdge_CoreNetworkId != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_CoreNetworkId = cmdletContext.CoreNetworkSegmentEdge_CoreNetworkId;
            }
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_CoreNetworkId != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge.CoreNetworkId = requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_CoreNetworkId;
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdgeIsNull = false;
            }
            System.String requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_EdgeLocation = null;
            if (cmdletContext.CoreNetworkSegmentEdge_EdgeLocation != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_EdgeLocation = cmdletContext.CoreNetworkSegmentEdge_EdgeLocation;
            }
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_EdgeLocation != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge.EdgeLocation = requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_EdgeLocation;
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdgeIsNull = false;
            }
            System.String requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_SegmentName = null;
            if (cmdletContext.CoreNetworkSegmentEdge_SegmentName != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_SegmentName = cmdletContext.CoreNetworkSegmentEdge_SegmentName;
            }
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_SegmentName != null)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge.SegmentName = requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge_coreNetworkSegmentEdge_SegmentName;
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdgeIsNull = false;
            }
             // determine if requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge should be set to null
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdgeIsNull)
            {
                requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge = null;
            }
            if (requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge != null)
            {
                request.RouteTableIdentifier.CoreNetworkSegmentEdge = requestRouteTableIdentifier_routeTableIdentifier_CoreNetworkSegmentEdge;
            }
            if (cmdletContext.State != null)
            {
                request.States = cmdletContext.State;
            }
            if (cmdletContext.SubnetOfMatch != null)
            {
                request.SubnetOfMatches = cmdletContext.SubnetOfMatch;
            }
            if (cmdletContext.SupernetOfMatch != null)
            {
                request.SupernetOfMatches = cmdletContext.SupernetOfMatch;
            }
            if (cmdletContext.Type != null)
            {
                request.Types = cmdletContext.Type;
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
        
        private Amazon.NetworkManager.Model.GetNetworkRoutesResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.GetNetworkRoutesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "GetNetworkRoutes");
            try
            {
                return client.GetNetworkRoutesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, List<System.String>> DestinationFilter { get; set; }
            public List<System.String> ExactCidrMatch { get; set; }
            public System.String GlobalNetworkId { get; set; }
            public List<System.String> LongestPrefixMatch { get; set; }
            public List<System.String> PrefixListId { get; set; }
            public System.String CoreNetworkNetworkFunctionGroup_CoreNetworkId { get; set; }
            public System.String CoreNetworkNetworkFunctionGroup_EdgeLocation { get; set; }
            public System.String CoreNetworkNetworkFunctionGroup_NetworkFunctionGroupName { get; set; }
            public System.String CoreNetworkSegmentEdge_CoreNetworkId { get; set; }
            public System.String CoreNetworkSegmentEdge_EdgeLocation { get; set; }
            public System.String CoreNetworkSegmentEdge_SegmentName { get; set; }
            public System.String RouteTableIdentifier_TransitGatewayRouteTableArn { get; set; }
            public List<System.String> State { get; set; }
            public List<System.String> SubnetOfMatch { get; set; }
            public List<System.String> SupernetOfMatch { get; set; }
            public List<System.String> Type { get; set; }
            public System.Func<Amazon.NetworkManager.Model.GetNetworkRoutesResponse, GetNMGRNetworkRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
