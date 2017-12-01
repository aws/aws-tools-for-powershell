/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Returns a list of container instances in a specified cluster. You can filter the results
    /// of a <code>ListContainerInstances</code> operation with cluster query language statements
    /// inside the <code>filter</code> parameter. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/cluster-query-language.html">Cluster
    /// Query Language</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "ECSContainerInstanceList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service ListContainerInstances API operation.", Operation = new[] {"ListContainerInstances"}, LegacyAlias="Get-ECSContainerInstances")]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.ECS.Model.ListContainerInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetECSContainerInstanceListCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that hosts the container
        /// instances to list. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>You can filter the results of a <code>ListContainerInstances</code> operation with
        /// cluster query language statements. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/cluster-query-language.html">Cluster
        /// Query Language</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filter { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Filters the container instances by status. For example, if you specify the <code>DRAINING</code>
        /// status, the results include only container instances that have been set to <code>DRAINING</code>
        /// using <a>UpdateContainerInstancesState</a>. If you do not specify this parameter,
        /// the default is to include container instances set to <code>ACTIVE</code> and <code>DRAINING</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECS.ContainerInstanceStatus")]
        public Amazon.ECS.ContainerInstanceStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of container instance results returned by <code>ListContainerInstances</code>
        /// in paginated output. When this parameter is used, <code>ListContainerInstances</code>
        /// only returns <code>maxResults</code> results in a single page along with a <code>nextToken</code>
        /// response element. The remaining results of the initial request can be seen by sending
        /// another <code>ListContainerInstances</code> request with the returned <code>nextToken</code>
        /// value. This value can be between 1 and 100. If this parameter is not used, then <code>ListContainerInstances</code>
        /// returns up to 100 results and a <code>nextToken</code> value if applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> value returned from a previous paginated <code>ListContainerInstances</code>
        /// request where <code>maxResults</code> was used and the results exceeded the value
        /// of that parameter. Pagination continues from the end of the previous results that
        /// returned the <code>nextToken</code> value.</para><note><para>This token should be treated as an opaque identifier that is only used to retrieve
        /// the next items in a list and not for other programmatic purposes.</para></note>
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
            
            context.Cluster = this.Cluster;
            context.Filter = this.Filter;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Status = this.Status;
            
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
            var request = new Amazon.ECS.Model.ListContainerInstancesRequest();
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
                        object pipelineOutput = response.ContainerInstanceArns;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ContainerInstanceArns.Count;
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
        
        private Amazon.ECS.Model.ListContainerInstancesResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.ListContainerInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "ListContainerInstances");
            try
            {
                #if DESKTOP
                return client.ListContainerInstances(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListContainerInstancesAsync(request);
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
            public System.String Cluster { get; set; }
            public System.String Filter { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ECS.ContainerInstanceStatus Status { get; set; }
        }
        
    }
}
