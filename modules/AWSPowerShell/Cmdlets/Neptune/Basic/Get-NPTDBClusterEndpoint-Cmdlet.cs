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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Returns information about endpoints for an Amazon Neptune DB cluster.
    /// 
    ///  <note><para>
    /// This operation can also return information for Amazon RDS clusters and Amazon DocDB
    /// clusters.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "NPTDBClusterEndpoint")]
    [OutputType("Amazon.Neptune.Model.DBClusterEndpoint")]
    [AWSCmdlet("Calls the Amazon Neptune DescribeDBClusterEndpoints API operation.", Operation = new[] {"DescribeDBClusterEndpoints"}, SelectReturnType = typeof(Amazon.Neptune.Model.DescribeDBClusterEndpointsResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.DBClusterEndpoint or Amazon.Neptune.Model.DescribeDBClusterEndpointsResponse",
        "This cmdlet returns a collection of Amazon.Neptune.Model.DBClusterEndpoint objects.",
        "The service call response (type Amazon.Neptune.Model.DescribeDBClusterEndpointsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetNPTDBClusterEndpointCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBClusterEndpointIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the endpoint to describe. This parameter is stored as a lowercase
        /// string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBClusterEndpointIdentifier { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier of the DB cluster associated with the endpoint. This parameter
        /// is stored as a lowercase string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A set of name-value pairs that define which endpoints to include in the output. The
        /// filters are specified as name-value pairs, in the format <c>Name=<i>endpoint_type</i>,Values=<i>endpoint_type1</i>,<i>endpoint_type2</i>,...</c>.
        /// <c>Name</c> can be one of: <c>db-cluster-endpoint-type</c>, <c>db-cluster-endpoint-custom-type</c>,
        /// <c>db-cluster-endpoint-id</c>, <c>db-cluster-endpoint-status</c>. <c>Values</c> for
        /// the <c> db-cluster-endpoint-type</c> filter can be one or more of: <c>reader</c>,
        /// <c>writer</c>, <c>custom</c>. <c>Values</c> for the <c>db-cluster-endpoint-custom-type</c>
        /// filter can be one or more of: <c>reader</c>, <c>any</c>. <c>Values</c> for the <c>db-cluster-endpoint-status</c>
        /// filter can be one or more of: <c>available</c>, <c>creating</c>, <c>deleting</c>,
        /// <c>inactive</c>, <c>modifying</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.Neptune.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para> An optional pagination token provided by a previous <c>DescribeDBClusterEndpoints</c>
        /// request. If this parameter is specified, the response includes only records beyond
        /// the marker, up to the value specified by <c>MaxRecords</c>. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in the response. If more records exist than
        /// the specified <c>MaxRecords</c> value, a pagination token called a marker is included
        /// in the response so you can retrieve the remaining results. </para><para>Default: 100</para><para>Constraints: Minimum 20, maximum 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterEndpoints'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.DescribeDBClusterEndpointsResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.DescribeDBClusterEndpointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterEndpoints";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.DescribeDBClusterEndpointsResponse, GetNPTDBClusterEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBClusterEndpointIdentifier = this.DBClusterEndpointIdentifier;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.Neptune.Model.Filter>(this.Filter);
            }
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            
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
            var request = new Amazon.Neptune.Model.DescribeDBClusterEndpointsRequest();
            
            if (cmdletContext.DBClusterEndpointIdentifier != null)
            {
                request.DBClusterEndpointIdentifier = cmdletContext.DBClusterEndpointIdentifier;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.Neptune.Model.DescribeDBClusterEndpointsResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.DescribeDBClusterEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "DescribeDBClusterEndpoints");
            try
            {
                return client.DescribeDBClusterEndpointsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBClusterEndpointIdentifier { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public List<Amazon.Neptune.Model.Filter> Filter { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.Func<Amazon.Neptune.Model.DescribeDBClusterEndpointsResponse, GetNPTDBClusterEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterEndpoints;
        }
        
    }
}
