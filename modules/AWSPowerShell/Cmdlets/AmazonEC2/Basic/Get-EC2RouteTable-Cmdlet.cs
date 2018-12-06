/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes one or more of your route tables.
    /// 
    ///  
    /// <para>
    /// Each subnet in your VPC must be associated with a route table. If a subnet is not
    /// explicitly associated with any route table, it is implicitly associated with the main
    /// route table. This command does not return the subnet ID for implicit associations.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_Route_Tables.html">Route
    /// Tables</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EC2RouteTable")]
    [OutputType("Amazon.EC2.Model.RouteTable")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeRouteTables API operation.", Operation = new[] {"DescribeRouteTables"})]
    [AWSCmdletOutput("Amazon.EC2.Model.RouteTable",
        "This cmdlet returns a collection of RouteTable objects.",
        "The service call response (type Amazon.EC2.Model.DescribeRouteTablesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetEC2RouteTableCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>association.route-table-association-id</code> - The ID of an association ID
        /// for the route table.</para></li><li><para><code>association.route-table-id</code> - The ID of the route table involved in the
        /// association.</para></li><li><para><code>association.subnet-id</code> - The ID of the subnet involved in the association.</para></li><li><para><code>association.main</code> - Indicates whether the route table is the main route
        /// table for the VPC (<code>true</code> | <code>false</code>). Route tables that do not
        /// have an association ID are not returned in the response.</para></li><li><para><code>owner-id</code> - The ID of the AWS account that owns the route table.</para></li><li><para><code>route-table-id</code> - The ID of the route table.</para></li><li><para><code>route.destination-cidr-block</code> - The IPv4 CIDR range specified in a route
        /// in the table.</para></li><li><para><code>route.destination-ipv6-cidr-block</code> - The IPv6 CIDR range specified in
        /// a route in the route table.</para></li><li><para><code>route.destination-prefix-list-id</code> - The ID (prefix) of the AWS service
        /// specified in a route in the table.</para></li><li><para><code>route.egress-only-internet-gateway-id</code> - The ID of an egress-only Internet
        /// gateway specified in a route in the route table.</para></li><li><para><code>route.gateway-id</code> - The ID of a gateway specified in a route in the table.</para></li><li><para><code>route.instance-id</code> - The ID of an instance specified in a route in the
        /// table.</para></li><li><para><code>route.nat-gateway-id</code> - The ID of a NAT gateway.</para></li><li><para><code>route.transit-gateway-id</code> - The ID of a transit gateway.</para></li><li><para><code>route.origin</code> - Describes how the route was created. <code>CreateRouteTable</code>
        /// indicates that the route was automatically created when the route table was created;
        /// <code>CreateRoute</code> indicates that the route was manually added to the route
        /// table; <code>EnableVgwRoutePropagation</code> indicates that the route was propagated
        /// by route propagation.</para></li><li><para><code>route.state</code> - The state of a route in the route table (<code>active</code>
        /// | <code>blackhole</code>). The blackhole state indicates that the route's target isn't
        /// available (for example, the specified gateway isn't attached to the VPC, the specified
        /// NAT instance has been terminated, and so on).</para></li><li><para><code>route.vpc-peering-connection-id</code> - The ID of a VPC peering connection
        /// specified in a route in the table.</para></li><li><para><code>tag</code>:&lt;key&gt; - The key/value combination of a tag assigned to the
        /// resource. Use the tag key in the filter name and the tag value as the filter value.
        /// For example, to find all resources that have a tag with the key <code>Owner</code>
        /// and the value <code>TeamA</code>, specify <code>tag:Owner</code> for the filter name
        /// and <code>TeamA</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. Use this filter
        /// to find all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><code>transit-gateway-id</code> - The ID of a transit gateway.</para></li><li><para><code>vpc-id</code> - The ID of the VPC for the route table.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter RouteTableId
        /// <summary>
        /// <para>
        /// <para>One or more route table IDs.</para><para>Default: Describes all your route tables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("RouteTableIds")]
        public System.String[] RouteTableId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. To retrieve the remaining
        /// results, make another call with the returned <b>NextToken</b> value. This value can
        /// be between 5 and 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.RouteTableId != null)
            {
                context.RouteTableIds = new List<System.String>(this.RouteTableId);
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
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeRouteTablesRequest();
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.RouteTableIds != null)
            {
                request.RouteTableIds = cmdletContext.RouteTableIds;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.RouteTables;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.RouteTables.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.DescribeRouteTablesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeRouteTablesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeRouteTables");
            try
            {
                #if DESKTOP
                return client.DescribeRouteTables(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeRouteTablesAsync(request);
                return task.Result;
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
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> RouteTableIds { get; set; }
        }
        
    }
}
