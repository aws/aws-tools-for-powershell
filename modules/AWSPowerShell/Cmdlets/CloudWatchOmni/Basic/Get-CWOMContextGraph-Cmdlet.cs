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
using Amazon.CloudWatchOmni;
using Amazon.CloudWatchOmni.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOM
{
    /// <summary>
    /// Queries the context graph with filtering, traversal, and pagination support.
    /// 
    ///  
    /// <para>
    /// Pagination note: nodes and edges are returned together as a coherent subgraph. Pagination
    /// cursors advance over nodes (the primary collection); each page includes all edges
    /// connecting nodes within that page. Callers should treat nodes as the paginated collection
    /// and edges as supplementary relationship data attached to those nodes.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWOMContextGraph")]
    [OutputType("Amazon.CloudWatchOmni.Model.Node")]
    [AWSCmdlet("Calls the CloudWatch Omni GetContextGraph API operation.", Operation = new[] {"GetContextGraph"}, SelectReturnType = typeof(Amazon.CloudWatchOmni.Model.GetContextGraphResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchOmni.Model.Node or Amazon.CloudWatchOmni.Model.GetContextGraphResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchOmni.Model.Node objects.",
        "The service call response (type Amazon.CloudWatchOmni.Model.GetContextGraphResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWOMContextGraphCmdlet : AmazonCloudWatchOmniClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NodeFilters_Category
        /// <summary>
        /// <para>
        /// <para>Match nodes of any of these categories.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NodeFilters_Category { get; set; }
        #endregion
        
        #region Parameter NodeFilters_CloudProvider
        /// <summary>
        /// <para>
        /// <para>Match nodes on any of these cloud providers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NodeFilters_CloudProvider { get; set; }
        #endregion
        
        #region Parameter Depth
        /// <summary>
        /// <para>
        /// <para>How many hops to traverse out from the nodes matched by nodeFilters. 0 returns only
        /// the matched nodes themselves.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Depth { get; set; }
        #endregion
        
        #region Parameter EdgeFilters_EdgeId
        /// <summary>
        /// <para>
        /// <para>Match only the edge with this identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EdgeFilters_EdgeId { get; set; }
        #endregion
        
        #region Parameter EdgeFilters_EdgeType
        /// <summary>
        /// <para>
        /// <para>Match only edges of this relationship kind.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.EdgeType")]
        public Amazon.CloudWatchOmni.EdgeType EdgeFilters_EdgeType { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>End of the time range (UTC), inclusive.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter EdgeFilters_From
        /// <summary>
        /// <para>
        /// <para>Match only edges originating from this node identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EdgeFilters_From { get; set; }
        #endregion
        
        #region Parameter IncludeMetadata
        /// <summary>
        /// <para>
        /// <para>Whether to return the metadata block, semantics included, on each node and edge. Off
        /// by default because it costs an extra lookup per returned node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeMetadata { get; set; }
        #endregion
        
        #region Parameter MaxEdgesPerNode
        /// <summary>
        /// <para>
        /// <para>The maximum number of edges to return per node, bounding the fan-out of a densely
        /// connected node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxEdgesPerNode { get; set; }
        #endregion
        
        #region Parameter NodeFilters_Name
        /// <summary>
        /// <para>
        /// <para>Match only nodes with this name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NodeFilters_Name { get; set; }
        #endregion
        
        #region Parameter NodeFilters_Namespace
        /// <summary>
        /// <para>
        /// <para>Match nodes in any of these logical service groupings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NodeFilters_Namespace { get; set; }
        #endregion
        
        #region Parameter NodeFilters_NodeId
        /// <summary>
        /// <para>
        /// <para>Match only the node with this identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NodeFilters_NodeId { get; set; }
        #endregion
        
        #region Parameter NodeFilters_NodeType
        /// <summary>
        /// <para>
        /// <para>Match only nodes of this type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.NodeType")]
        public Amazon.CloudWatchOmni.NodeType NodeFilters_NodeType { get; set; }
        #endregion
        
        #region Parameter EdgeFilters_Operation
        /// <summary>
        /// <para>
        /// <para>Match edges carrying any of these operations.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdgeFilters_Operations")]
        public System.String[] EdgeFilters_Operation { get; set; }
        #endregion
        
        #region Parameter NodeFilters_Region
        /// <summary>
        /// <para>
        /// <para>Match nodes in any of these regions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NodeFilters_Region { get; set; }
        #endregion
        
        #region Parameter NodeFilters_SourceAccountId
        /// <summary>
        /// <para>
        /// <para>Match nodes discovered from telemetry produced by any of these accounts.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NodeFilters_SourceAccountId { get; set; }
        #endregion
        
        #region Parameter EdgeFilters_Source
        /// <summary>
        /// <para>
        /// <para>Match edges contributed by any of these discovery sources.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdgeFilters_Sources")]
        public System.String[] EdgeFilters_Source { get; set; }
        #endregion
        
        #region Parameter NodeFilters_Source
        /// <summary>
        /// <para>
        /// <para>Match nodes contributed by any of these discovery sources.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeFilters_Sources")]
        public System.String[] NodeFilters_Source { get; set; }
        #endregion
        
        #region Parameter NodeFilters_Stage
        /// <summary>
        /// <para>
        /// <para>Match nodes observed in any of these deployment environments.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NodeFilters_Stage { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>Start of the time range (UTC), inclusive.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter NodeFilters_Tag
        /// <summary>
        /// <para>
        /// <para>Match nodes by the tags on the underlying resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeFilters_Tags")]
        public Amazon.CloudWatchOmni.Model.KeyFilter[] NodeFilters_Tag { get; set; }
        #endregion
        
        #region Parameter EdgeFilters_TelemetryAttribute
        /// <summary>
        /// <para>
        /// <para>Match edges by their OpenTelemetry (OTel) telemetry attributes. Not yet enforced:
        /// currently accepted but ignored (does not filter), matching nodeFilters.telemetryAttributes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdgeFilters_TelemetryAttributes")]
        public Amazon.CloudWatchOmni.Model.KeyFilter[] EdgeFilters_TelemetryAttribute { get; set; }
        #endregion
        
        #region Parameter NodeFilters_TelemetryAttribute
        /// <summary>
        /// <para>
        /// <para>Match nodes by their OpenTelemetry (OTel) telemetry attributes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeFilters_TelemetryAttributes")]
        public Amazon.CloudWatchOmni.Model.KeyFilter[] NodeFilters_TelemetryAttribute { get; set; }
        #endregion
        
        #region Parameter EdgeFilters_To
        /// <summary>
        /// <para>
        /// <para>Match only edges pointing to this node identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EdgeFilters_To { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of nodes to return in a single page.</para>
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
        /// <para>Pagination token from a previous response, to retrieve the next page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Nodes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchOmni.Model.GetContextGraphResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchOmni.Model.GetContextGraphResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Nodes";
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchOmni.Model.GetContextGraphResponse, GetCWOMContextGraphCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Depth = this.Depth;
            context.EdgeFilters_EdgeId = this.EdgeFilters_EdgeId;
            context.EdgeFilters_EdgeType = this.EdgeFilters_EdgeType;
            context.EdgeFilters_From = this.EdgeFilters_From;
            if (this.EdgeFilters_Operation != null)
            {
                context.EdgeFilters_Operation = new List<System.String>(this.EdgeFilters_Operation);
            }
            if (this.EdgeFilters_Source != null)
            {
                context.EdgeFilters_Source = new List<System.String>(this.EdgeFilters_Source);
            }
            if (this.EdgeFilters_TelemetryAttribute != null)
            {
                context.EdgeFilters_TelemetryAttribute = new List<Amazon.CloudWatchOmni.Model.KeyFilter>(this.EdgeFilters_TelemetryAttribute);
            }
            context.EdgeFilters_To = this.EdgeFilters_To;
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncludeMetadata = this.IncludeMetadata;
            context.MaxEdgesPerNode = this.MaxEdgesPerNode;
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
            if (this.NodeFilters_Category != null)
            {
                context.NodeFilters_Category = new List<System.String>(this.NodeFilters_Category);
            }
            if (this.NodeFilters_CloudProvider != null)
            {
                context.NodeFilters_CloudProvider = new List<System.String>(this.NodeFilters_CloudProvider);
            }
            context.NodeFilters_Name = this.NodeFilters_Name;
            if (this.NodeFilters_Namespace != null)
            {
                context.NodeFilters_Namespace = new List<System.String>(this.NodeFilters_Namespace);
            }
            context.NodeFilters_NodeId = this.NodeFilters_NodeId;
            context.NodeFilters_NodeType = this.NodeFilters_NodeType;
            if (this.NodeFilters_Region != null)
            {
                context.NodeFilters_Region = new List<System.String>(this.NodeFilters_Region);
            }
            if (this.NodeFilters_SourceAccountId != null)
            {
                context.NodeFilters_SourceAccountId = new List<System.String>(this.NodeFilters_SourceAccountId);
            }
            if (this.NodeFilters_Source != null)
            {
                context.NodeFilters_Source = new List<System.String>(this.NodeFilters_Source);
            }
            if (this.NodeFilters_Stage != null)
            {
                context.NodeFilters_Stage = new List<System.String>(this.NodeFilters_Stage);
            }
            if (this.NodeFilters_Tag != null)
            {
                context.NodeFilters_Tag = new List<Amazon.CloudWatchOmni.Model.KeyFilter>(this.NodeFilters_Tag);
            }
            if (this.NodeFilters_TelemetryAttribute != null)
            {
                context.NodeFilters_TelemetryAttribute = new List<Amazon.CloudWatchOmni.Model.KeyFilter>(this.NodeFilters_TelemetryAttribute);
            }
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CloudWatchOmni.Model.GetContextGraphRequest();
            
            if (cmdletContext.Depth != null)
            {
                request.Depth = cmdletContext.Depth.Value;
            }
            
             // populate EdgeFilters
            var requestEdgeFiltersIsNull = true;
            request.EdgeFilters = new Amazon.CloudWatchOmni.Model.EdgeFilters();
            System.String requestEdgeFilters_edgeFilters_EdgeId = null;
            if (cmdletContext.EdgeFilters_EdgeId != null)
            {
                requestEdgeFilters_edgeFilters_EdgeId = cmdletContext.EdgeFilters_EdgeId;
            }
            if (requestEdgeFilters_edgeFilters_EdgeId != null)
            {
                request.EdgeFilters.EdgeId = requestEdgeFilters_edgeFilters_EdgeId;
                requestEdgeFiltersIsNull = false;
            }
            Amazon.CloudWatchOmni.EdgeType requestEdgeFilters_edgeFilters_EdgeType = null;
            if (cmdletContext.EdgeFilters_EdgeType != null)
            {
                requestEdgeFilters_edgeFilters_EdgeType = cmdletContext.EdgeFilters_EdgeType;
            }
            if (requestEdgeFilters_edgeFilters_EdgeType != null)
            {
                request.EdgeFilters.EdgeType = requestEdgeFilters_edgeFilters_EdgeType;
                requestEdgeFiltersIsNull = false;
            }
            System.String requestEdgeFilters_edgeFilters_From = null;
            if (cmdletContext.EdgeFilters_From != null)
            {
                requestEdgeFilters_edgeFilters_From = cmdletContext.EdgeFilters_From;
            }
            if (requestEdgeFilters_edgeFilters_From != null)
            {
                request.EdgeFilters.From = requestEdgeFilters_edgeFilters_From;
                requestEdgeFiltersIsNull = false;
            }
            List<System.String> requestEdgeFilters_edgeFilters_Operation = null;
            if (cmdletContext.EdgeFilters_Operation != null)
            {
                requestEdgeFilters_edgeFilters_Operation = cmdletContext.EdgeFilters_Operation;
            }
            if (requestEdgeFilters_edgeFilters_Operation != null)
            {
                request.EdgeFilters.Operations = requestEdgeFilters_edgeFilters_Operation;
                requestEdgeFiltersIsNull = false;
            }
            List<System.String> requestEdgeFilters_edgeFilters_Source = null;
            if (cmdletContext.EdgeFilters_Source != null)
            {
                requestEdgeFilters_edgeFilters_Source = cmdletContext.EdgeFilters_Source;
            }
            if (requestEdgeFilters_edgeFilters_Source != null)
            {
                request.EdgeFilters.Sources = requestEdgeFilters_edgeFilters_Source;
                requestEdgeFiltersIsNull = false;
            }
            List<Amazon.CloudWatchOmni.Model.KeyFilter> requestEdgeFilters_edgeFilters_TelemetryAttribute = null;
            if (cmdletContext.EdgeFilters_TelemetryAttribute != null)
            {
                requestEdgeFilters_edgeFilters_TelemetryAttribute = cmdletContext.EdgeFilters_TelemetryAttribute;
            }
            if (requestEdgeFilters_edgeFilters_TelemetryAttribute != null)
            {
                request.EdgeFilters.TelemetryAttributes = requestEdgeFilters_edgeFilters_TelemetryAttribute;
                requestEdgeFiltersIsNull = false;
            }
            System.String requestEdgeFilters_edgeFilters_To = null;
            if (cmdletContext.EdgeFilters_To != null)
            {
                requestEdgeFilters_edgeFilters_To = cmdletContext.EdgeFilters_To;
            }
            if (requestEdgeFilters_edgeFilters_To != null)
            {
                request.EdgeFilters.To = requestEdgeFilters_edgeFilters_To;
                requestEdgeFiltersIsNull = false;
            }
             // determine if request.EdgeFilters should be set to null
            if (requestEdgeFiltersIsNull)
            {
                request.EdgeFilters = null;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.IncludeMetadata != null)
            {
                request.IncludeMetadata = cmdletContext.IncludeMetadata.Value;
            }
            if (cmdletContext.MaxEdgesPerNode != null)
            {
                request.MaxEdgesPerNode = cmdletContext.MaxEdgesPerNode.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate NodeFilters
            var requestNodeFiltersIsNull = true;
            request.NodeFilters = new Amazon.CloudWatchOmni.Model.NodeFilters();
            List<System.String> requestNodeFilters_nodeFilters_Category = null;
            if (cmdletContext.NodeFilters_Category != null)
            {
                requestNodeFilters_nodeFilters_Category = cmdletContext.NodeFilters_Category;
            }
            if (requestNodeFilters_nodeFilters_Category != null)
            {
                request.NodeFilters.Category = requestNodeFilters_nodeFilters_Category;
                requestNodeFiltersIsNull = false;
            }
            List<System.String> requestNodeFilters_nodeFilters_CloudProvider = null;
            if (cmdletContext.NodeFilters_CloudProvider != null)
            {
                requestNodeFilters_nodeFilters_CloudProvider = cmdletContext.NodeFilters_CloudProvider;
            }
            if (requestNodeFilters_nodeFilters_CloudProvider != null)
            {
                request.NodeFilters.CloudProvider = requestNodeFilters_nodeFilters_CloudProvider;
                requestNodeFiltersIsNull = false;
            }
            System.String requestNodeFilters_nodeFilters_Name = null;
            if (cmdletContext.NodeFilters_Name != null)
            {
                requestNodeFilters_nodeFilters_Name = cmdletContext.NodeFilters_Name;
            }
            if (requestNodeFilters_nodeFilters_Name != null)
            {
                request.NodeFilters.Name = requestNodeFilters_nodeFilters_Name;
                requestNodeFiltersIsNull = false;
            }
            List<System.String> requestNodeFilters_nodeFilters_Namespace = null;
            if (cmdletContext.NodeFilters_Namespace != null)
            {
                requestNodeFilters_nodeFilters_Namespace = cmdletContext.NodeFilters_Namespace;
            }
            if (requestNodeFilters_nodeFilters_Namespace != null)
            {
                request.NodeFilters.Namespace = requestNodeFilters_nodeFilters_Namespace;
                requestNodeFiltersIsNull = false;
            }
            System.String requestNodeFilters_nodeFilters_NodeId = null;
            if (cmdletContext.NodeFilters_NodeId != null)
            {
                requestNodeFilters_nodeFilters_NodeId = cmdletContext.NodeFilters_NodeId;
            }
            if (requestNodeFilters_nodeFilters_NodeId != null)
            {
                request.NodeFilters.NodeId = requestNodeFilters_nodeFilters_NodeId;
                requestNodeFiltersIsNull = false;
            }
            Amazon.CloudWatchOmni.NodeType requestNodeFilters_nodeFilters_NodeType = null;
            if (cmdletContext.NodeFilters_NodeType != null)
            {
                requestNodeFilters_nodeFilters_NodeType = cmdletContext.NodeFilters_NodeType;
            }
            if (requestNodeFilters_nodeFilters_NodeType != null)
            {
                request.NodeFilters.NodeType = requestNodeFilters_nodeFilters_NodeType;
                requestNodeFiltersIsNull = false;
            }
            List<System.String> requestNodeFilters_nodeFilters_Region = null;
            if (cmdletContext.NodeFilters_Region != null)
            {
                requestNodeFilters_nodeFilters_Region = cmdletContext.NodeFilters_Region;
            }
            if (requestNodeFilters_nodeFilters_Region != null)
            {
                request.NodeFilters.Region = requestNodeFilters_nodeFilters_Region;
                requestNodeFiltersIsNull = false;
            }
            List<System.String> requestNodeFilters_nodeFilters_SourceAccountId = null;
            if (cmdletContext.NodeFilters_SourceAccountId != null)
            {
                requestNodeFilters_nodeFilters_SourceAccountId = cmdletContext.NodeFilters_SourceAccountId;
            }
            if (requestNodeFilters_nodeFilters_SourceAccountId != null)
            {
                request.NodeFilters.SourceAccountId = requestNodeFilters_nodeFilters_SourceAccountId;
                requestNodeFiltersIsNull = false;
            }
            List<System.String> requestNodeFilters_nodeFilters_Source = null;
            if (cmdletContext.NodeFilters_Source != null)
            {
                requestNodeFilters_nodeFilters_Source = cmdletContext.NodeFilters_Source;
            }
            if (requestNodeFilters_nodeFilters_Source != null)
            {
                request.NodeFilters.Sources = requestNodeFilters_nodeFilters_Source;
                requestNodeFiltersIsNull = false;
            }
            List<System.String> requestNodeFilters_nodeFilters_Stage = null;
            if (cmdletContext.NodeFilters_Stage != null)
            {
                requestNodeFilters_nodeFilters_Stage = cmdletContext.NodeFilters_Stage;
            }
            if (requestNodeFilters_nodeFilters_Stage != null)
            {
                request.NodeFilters.Stage = requestNodeFilters_nodeFilters_Stage;
                requestNodeFiltersIsNull = false;
            }
            List<Amazon.CloudWatchOmni.Model.KeyFilter> requestNodeFilters_nodeFilters_Tag = null;
            if (cmdletContext.NodeFilters_Tag != null)
            {
                requestNodeFilters_nodeFilters_Tag = cmdletContext.NodeFilters_Tag;
            }
            if (requestNodeFilters_nodeFilters_Tag != null)
            {
                request.NodeFilters.Tags = requestNodeFilters_nodeFilters_Tag;
                requestNodeFiltersIsNull = false;
            }
            List<Amazon.CloudWatchOmni.Model.KeyFilter> requestNodeFilters_nodeFilters_TelemetryAttribute = null;
            if (cmdletContext.NodeFilters_TelemetryAttribute != null)
            {
                requestNodeFilters_nodeFilters_TelemetryAttribute = cmdletContext.NodeFilters_TelemetryAttribute;
            }
            if (requestNodeFilters_nodeFilters_TelemetryAttribute != null)
            {
                request.NodeFilters.TelemetryAttributes = requestNodeFilters_nodeFilters_TelemetryAttribute;
                requestNodeFiltersIsNull = false;
            }
             // determine if request.NodeFilters should be set to null
            if (requestNodeFiltersIsNull)
            {
                request.NodeFilters = null;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.CloudWatchOmni.Model.GetContextGraphResponse CallAWSServiceOperation(IAmazonCloudWatchOmni client, Amazon.CloudWatchOmni.Model.GetContextGraphRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Omni", "GetContextGraph");
            try
            {
                return client.GetContextGraphAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Depth { get; set; }
            public System.String EdgeFilters_EdgeId { get; set; }
            public Amazon.CloudWatchOmni.EdgeType EdgeFilters_EdgeType { get; set; }
            public System.String EdgeFilters_From { get; set; }
            public List<System.String> EdgeFilters_Operation { get; set; }
            public List<System.String> EdgeFilters_Source { get; set; }
            public List<Amazon.CloudWatchOmni.Model.KeyFilter> EdgeFilters_TelemetryAttribute { get; set; }
            public System.String EdgeFilters_To { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.Boolean? IncludeMetadata { get; set; }
            public System.Int32? MaxEdgesPerNode { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> NodeFilters_Category { get; set; }
            public List<System.String> NodeFilters_CloudProvider { get; set; }
            public System.String NodeFilters_Name { get; set; }
            public List<System.String> NodeFilters_Namespace { get; set; }
            public System.String NodeFilters_NodeId { get; set; }
            public Amazon.CloudWatchOmni.NodeType NodeFilters_NodeType { get; set; }
            public List<System.String> NodeFilters_Region { get; set; }
            public List<System.String> NodeFilters_SourceAccountId { get; set; }
            public List<System.String> NodeFilters_Source { get; set; }
            public List<System.String> NodeFilters_Stage { get; set; }
            public List<Amazon.CloudWatchOmni.Model.KeyFilter> NodeFilters_Tag { get; set; }
            public List<Amazon.CloudWatchOmni.Model.KeyFilter> NodeFilters_TelemetryAttribute { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.CloudWatchOmni.Model.GetContextGraphResponse, GetCWOMContextGraphCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Nodes;
        }
        
    }
}
