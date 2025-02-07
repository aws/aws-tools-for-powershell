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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Use this action to inspect your lineage and discover relationships between entities.
    /// For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/querying-lineage-entities.html">
    /// Querying Lineage Entities</a> in the <i>Amazon SageMaker Developer Guide</i>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Find", "SMLineage")]
    [OutputType("Amazon.SageMaker.Model.QueryLineageResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service QueryLineage API operation.", Operation = new[] {"QueryLineage"}, SelectReturnType = typeof(Amazon.SageMaker.Model.QueryLineageResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.QueryLineageResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.QueryLineageResponse object containing multiple properties."
    )]
    public partial class FindSMLineageCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_CreatedAfter
        /// <summary>
        /// <para>
        /// <para>Filter the lineage entities connected to the <c>StartArn</c>(s) after the create date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_CreatedAfter { get; set; }
        #endregion
        
        #region Parameter Filters_CreatedBefore
        /// <summary>
        /// <para>
        /// <para>Filter the lineage entities connected to the <c>StartArn</c>(s) by created date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_CreatedBefore { get; set; }
        #endregion
        
        #region Parameter Direction
        /// <summary>
        /// <para>
        /// <para>Associations between lineage entities have a direction. This parameter determines
        /// the direction from the StartArn(s) that the query traverses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.Direction")]
        public Amazon.SageMaker.Direction Direction { get; set; }
        #endregion
        
        #region Parameter IncludeEdge
        /// <summary>
        /// <para>
        /// <para> Setting this value to <c>True</c> retrieves not only the entities of interest but
        /// also the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/lineage-tracking-entities.html">Associations</a>
        /// and lineage entities on the path. Set to <c>False</c> to only return lineage entities
        /// that match your query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeEdges")]
        public System.Boolean? IncludeEdge { get; set; }
        #endregion
        
        #region Parameter Filters_LineageType
        /// <summary>
        /// <para>
        /// <para>Filter the lineage entities connected to the <c>StartArn</c>(s) by the type of the
        /// lineage entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_LineageTypes")]
        public System.String[] Filters_LineageType { get; set; }
        #endregion
        
        #region Parameter MaxDepth
        /// <summary>
        /// <para>
        /// <para>The maximum depth in lineage relationships from the <c>StartArns</c> that are traversed.
        /// Depth is a measure of the number of <c>Associations</c> from the <c>StartArn</c> entity
        /// to the matched results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxDepth { get; set; }
        #endregion
        
        #region Parameter Filters_ModifiedAfter
        /// <summary>
        /// <para>
        /// <para>Filter the lineage entities connected to the <c>StartArn</c>(s) after the last modified
        /// date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_ModifiedAfter { get; set; }
        #endregion
        
        #region Parameter Filters_ModifiedBefore
        /// <summary>
        /// <para>
        /// <para>Filter the lineage entities connected to the <c>StartArn</c>(s) before the last modified
        /// date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_ModifiedBefore { get; set; }
        #endregion
        
        #region Parameter Filters_Property
        /// <summary>
        /// <para>
        /// <para>Filter the lineage entities connected to the <c>StartArn</c>(s) by a set if property
        /// key value pairs. If multiple pairs are provided, an entity is included in the results
        /// if it matches any of the provided pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Properties")]
        public System.Collections.Hashtable Filters_Property { get; set; }
        #endregion
        
        #region Parameter StartArn
        /// <summary>
        /// <para>
        /// <para>A list of resource Amazon Resource Name (ARN) that represent the starting point for
        /// your lineage query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StartArns")]
        public System.String[] StartArn { get; set; }
        #endregion
        
        #region Parameter Filters_Type
        /// <summary>
        /// <para>
        /// <para>Filter the lineage entities connected to the <c>StartArn</c> by type. For example:
        /// <c>DataSet</c>, <c>Model</c>, <c>Endpoint</c>, or <c>ModelDeployment</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Types")]
        public System.String[] Filters_Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Limits the number of vertices in the results. Use the <c>NextToken</c> in a response
        /// to to retrieve the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Limits the number of vertices in the request. Use the <c>NextToken</c> in a response
        /// to to retrieve the next page of results.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.QueryLineageResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.QueryLineageResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.QueryLineageResponse, FindSMLineageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Direction = this.Direction;
            context.Filters_CreatedAfter = this.Filters_CreatedAfter;
            context.Filters_CreatedBefore = this.Filters_CreatedBefore;
            if (this.Filters_LineageType != null)
            {
                context.Filters_LineageType = new List<System.String>(this.Filters_LineageType);
            }
            context.Filters_ModifiedAfter = this.Filters_ModifiedAfter;
            context.Filters_ModifiedBefore = this.Filters_ModifiedBefore;
            if (this.Filters_Property != null)
            {
                context.Filters_Property = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filters_Property.Keys)
                {
                    context.Filters_Property.Add((String)hashKey, (System.String)(this.Filters_Property[hashKey]));
                }
            }
            if (this.Filters_Type != null)
            {
                context.Filters_Type = new List<System.String>(this.Filters_Type);
            }
            context.IncludeEdge = this.IncludeEdge;
            context.MaxDepth = this.MaxDepth;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.StartArn != null)
            {
                context.StartArn = new List<System.String>(this.StartArn);
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
            var request = new Amazon.SageMaker.Model.QueryLineageRequest();
            
            if (cmdletContext.Direction != null)
            {
                request.Direction = cmdletContext.Direction;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.SageMaker.Model.QueryFilters();
            System.DateTime? requestFilters_filters_CreatedAfter = null;
            if (cmdletContext.Filters_CreatedAfter != null)
            {
                requestFilters_filters_CreatedAfter = cmdletContext.Filters_CreatedAfter.Value;
            }
            if (requestFilters_filters_CreatedAfter != null)
            {
                request.Filters.CreatedAfter = requestFilters_filters_CreatedAfter.Value;
                requestFiltersIsNull = false;
            }
            System.DateTime? requestFilters_filters_CreatedBefore = null;
            if (cmdletContext.Filters_CreatedBefore != null)
            {
                requestFilters_filters_CreatedBefore = cmdletContext.Filters_CreatedBefore.Value;
            }
            if (requestFilters_filters_CreatedBefore != null)
            {
                request.Filters.CreatedBefore = requestFilters_filters_CreatedBefore.Value;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_LineageType = null;
            if (cmdletContext.Filters_LineageType != null)
            {
                requestFilters_filters_LineageType = cmdletContext.Filters_LineageType;
            }
            if (requestFilters_filters_LineageType != null)
            {
                request.Filters.LineageTypes = requestFilters_filters_LineageType;
                requestFiltersIsNull = false;
            }
            System.DateTime? requestFilters_filters_ModifiedAfter = null;
            if (cmdletContext.Filters_ModifiedAfter != null)
            {
                requestFilters_filters_ModifiedAfter = cmdletContext.Filters_ModifiedAfter.Value;
            }
            if (requestFilters_filters_ModifiedAfter != null)
            {
                request.Filters.ModifiedAfter = requestFilters_filters_ModifiedAfter.Value;
                requestFiltersIsNull = false;
            }
            System.DateTime? requestFilters_filters_ModifiedBefore = null;
            if (cmdletContext.Filters_ModifiedBefore != null)
            {
                requestFilters_filters_ModifiedBefore = cmdletContext.Filters_ModifiedBefore.Value;
            }
            if (requestFilters_filters_ModifiedBefore != null)
            {
                request.Filters.ModifiedBefore = requestFilters_filters_ModifiedBefore.Value;
                requestFiltersIsNull = false;
            }
            Dictionary<System.String, System.String> requestFilters_filters_Property = null;
            if (cmdletContext.Filters_Property != null)
            {
                requestFilters_filters_Property = cmdletContext.Filters_Property;
            }
            if (requestFilters_filters_Property != null)
            {
                request.Filters.Properties = requestFilters_filters_Property;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Type = null;
            if (cmdletContext.Filters_Type != null)
            {
                requestFilters_filters_Type = cmdletContext.Filters_Type;
            }
            if (requestFilters_filters_Type != null)
            {
                request.Filters.Types = requestFilters_filters_Type;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.IncludeEdge != null)
            {
                request.IncludeEdges = cmdletContext.IncludeEdge.Value;
            }
            if (cmdletContext.MaxDepth != null)
            {
                request.MaxDepth = cmdletContext.MaxDepth.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.StartArn != null)
            {
                request.StartArns = cmdletContext.StartArn;
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
        
        private Amazon.SageMaker.Model.QueryLineageResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.QueryLineageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "QueryLineage");
            try
            {
                #if DESKTOP
                return client.QueryLineage(request);
                #elif CORECLR
                return client.QueryLineageAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.Direction Direction { get; set; }
            public System.DateTime? Filters_CreatedAfter { get; set; }
            public System.DateTime? Filters_CreatedBefore { get; set; }
            public List<System.String> Filters_LineageType { get; set; }
            public System.DateTime? Filters_ModifiedAfter { get; set; }
            public System.DateTime? Filters_ModifiedBefore { get; set; }
            public Dictionary<System.String, System.String> Filters_Property { get; set; }
            public List<System.String> Filters_Type { get; set; }
            public System.Boolean? IncludeEdge { get; set; }
            public System.Int32? MaxDepth { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> StartArn { get; set; }
            public System.Func<Amazon.SageMaker.Model.QueryLineageResponse, FindSMLineageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
