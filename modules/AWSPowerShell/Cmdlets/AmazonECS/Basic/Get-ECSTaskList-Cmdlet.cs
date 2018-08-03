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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Returns a list of tasks for a specified cluster. You can filter the results by family
    /// name, by a particular container instance, or by the desired status of the task with
    /// the <code>family</code>, <code>containerInstance</code>, and <code>desiredStatus</code>
    /// parameters.
    /// 
    ///  
    /// <para>
    /// Recently stopped tasks might appear in the returned results. Currently, stopped tasks
    /// appear in the returned results for at least one hour. 
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "ECSTaskList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service ListTasks API operation.", Operation = new[] {"ListTasks"}, LegacyAlias="Get-ECSTasks")]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.ECS.Model.ListTasksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetECSTaskListCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that hosts the tasks
        /// to list. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter ContainerInstance
        /// <summary>
        /// <para>
        /// <para>The container instance ID or full ARN of the container instance with which to filter
        /// the <code>ListTasks</code> results. Specifying a <code>containerInstance</code> limits
        /// the results to tasks that belong to that container instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContainerInstance { get; set; }
        #endregion
        
        #region Parameter DesiredStatus
        /// <summary>
        /// <para>
        /// <para>The task desired status with which to filter the <code>ListTasks</code> results. Specifying
        /// a <code>desiredStatus</code> of <code>STOPPED</code> limits the results to tasks that
        /// Amazon ECS has set the desired status to <code>STOPPED</code>, which can be useful
        /// for debugging tasks that are not starting properly or have died or finished. The default
        /// status filter is <code>RUNNING</code>, which shows tasks that Amazon ECS has set the
        /// desired status to <code>RUNNING</code>.</para><note><para>Although you can filter results based on a desired status of <code>PENDING</code>,
        /// this does not return any results because Amazon ECS never sets the desired status
        /// of a task to that value (only a task's <code>lastStatus</code> may have a value of
        /// <code>PENDING</code>).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECS.DesiredStatus")]
        public Amazon.ECS.DesiredStatus DesiredStatus { get; set; }
        #endregion
        
        #region Parameter Family
        /// <summary>
        /// <para>
        /// <para>The name of the family with which to filter the <code>ListTasks</code> results. Specifying
        /// a <code>family</code> limits the results to tasks that belong to that family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Family { get; set; }
        #endregion
        
        #region Parameter LaunchType
        /// <summary>
        /// <para>
        /// <para>The launch type for services to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECS.LaunchType")]
        public Amazon.ECS.LaunchType LaunchType { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the service with which to filter the <code>ListTasks</code> results. Specifying
        /// a <code>serviceName</code> limits the results to tasks that belong to that service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter StartedBy
        /// <summary>
        /// <para>
        /// <para>The <code>startedBy</code> value with which to filter the task results. Specifying
        /// a <code>startedBy</code> value limits the results to tasks that were started with
        /// that value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartedBy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of task results returned by <code>ListTasks</code> in paginated
        /// output. When this parameter is used, <code>ListTasks</code> only returns <code>maxResults</code>
        /// results in a single page along with a <code>nextToken</code> response element. The
        /// remaining results of the initial request can be seen by sending another <code>ListTasks</code>
        /// request with the returned <code>nextToken</code> value. This value can be between
        /// 1 and 100. If this parameter is not used, then <code>ListTasks</code> returns up to
        /// 100 results and a <code>nextToken</code> value if applicable.</para>
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
        /// <para>The <code>nextToken</code> value returned from a previous paginated <code>ListTasks</code>
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
            context.ContainerInstance = this.ContainerInstance;
            context.DesiredStatus = this.DesiredStatus;
            context.Family = this.Family;
            context.LaunchType = this.LaunchType;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ServiceName = this.ServiceName;
            context.StartedBy = this.StartedBy;
            
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
            var request = new Amazon.ECS.Model.ListTasksRequest();
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.ContainerInstance != null)
            {
                request.ContainerInstance = cmdletContext.ContainerInstance;
            }
            if (cmdletContext.DesiredStatus != null)
            {
                request.DesiredStatus = cmdletContext.DesiredStatus;
            }
            if (cmdletContext.Family != null)
            {
                request.Family = cmdletContext.Family;
            }
            if (cmdletContext.LaunchType != null)
            {
                request.LaunchType = cmdletContext.LaunchType;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.StartedBy != null)
            {
                request.StartedBy = cmdletContext.StartedBy;
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
                        object pipelineOutput = response.TaskArns;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.TaskArns.Count;
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
        
        private Amazon.ECS.Model.ListTasksResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.ListTasksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "ListTasks");
            try
            {
                #if DESKTOP
                return client.ListTasks(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListTasksAsync(request);
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
            public System.String ContainerInstance { get; set; }
            public Amazon.ECS.DesiredStatus DesiredStatus { get; set; }
            public System.String Family { get; set; }
            public Amazon.ECS.LaunchType LaunchType { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String ServiceName { get; set; }
            public System.String StartedBy { get; set; }
        }
        
    }
}
