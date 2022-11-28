/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns a list of tasks. You can filter the results by cluster, task definition family,
    /// container instance, launch type, what IAM principal started the task, or by the desired
    /// status of the task.
    /// 
    ///  
    /// <para>
    /// Recently stopped tasks might appear in the returned results. Currently, stopped tasks
    /// appear in the returned results for at least one hour.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ECSTaskList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service ListTasks API operation.", Operation = new[] {"ListTasks"}, SelectReturnType = typeof(Amazon.ECS.Model.ListTasksResponse), LegacyAlias="Get-ECSTasks")]
    [AWSCmdletOutput("System.String or Amazon.ECS.Model.ListTasksResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ECS.Model.ListTasksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetECSTaskListCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster to use when filtering
        /// the <code>ListTasks</code> results. If you do not specify a cluster, the default cluster
        /// is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter ContainerInstance
        /// <summary>
        /// <para>
        /// <para>The container instance ID or full ARN of the container instance to use when filtering
        /// the <code>ListTasks</code> results. Specifying a <code>containerInstance</code> limits
        /// the results to tasks that belong to that container instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerInstance { get; set; }
        #endregion
        
        #region Parameter DesiredStatus
        /// <summary>
        /// <para>
        /// <para>The task desired status to use when filtering the <code>ListTasks</code> results.
        /// Specifying a <code>desiredStatus</code> of <code>STOPPED</code> limits the results
        /// to tasks that Amazon ECS has set the desired status to <code>STOPPED</code>. This
        /// can be useful for debugging tasks that aren't starting properly or have died or finished.
        /// The default status filter is <code>RUNNING</code>, which shows tasks that Amazon ECS
        /// has set the desired status to <code>RUNNING</code>.</para><note><para>Although you can filter results based on a desired status of <code>PENDING</code>,
        /// this doesn't return any results. Amazon ECS never sets the desired status of a task
        /// to that value (only a task's <code>lastStatus</code> may have a value of <code>PENDING</code>).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.DesiredStatus")]
        public Amazon.ECS.DesiredStatus DesiredStatus { get; set; }
        #endregion
        
        #region Parameter Family
        /// <summary>
        /// <para>
        /// <para>The name of the task definition family to use when filtering the <code>ListTasks</code>
        /// results. Specifying a <code>family</code> limits the results to tasks that belong
        /// to that family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Family { get; set; }
        #endregion
        
        #region Parameter LaunchType
        /// <summary>
        /// <para>
        /// <para>The launch type to use when filtering the <code>ListTasks</code> results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.LaunchType")]
        public Amazon.ECS.LaunchType LaunchType { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the service to use when filtering the <code>ListTasks</code> results.
        /// Specifying a <code>serviceName</code> limits the results to tasks that belong to that
        /// service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter StartedBy
        /// <summary>
        /// <para>
        /// <para>The <code>startedBy</code> value to filter the task results with. Specifying a <code>startedBy</code>
        /// value limits the results to tasks that were started with that value.</para><para>When you specify <code>startedBy</code> as the filter, it must be the only filter
        /// that you use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartedBy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of task results that <code>ListTasks</code> returned in paginated
        /// output. When this parameter is used, <code>ListTasks</code> only returns <code>maxResults</code>
        /// results in a single page along with a <code>nextToken</code> response element. The
        /// remaining results of the initial request can be seen by sending another <code>ListTasks</code>
        /// request with the returned <code>nextToken</code> value. This value can be between
        /// 1 and 100. If this parameter isn't used, then <code>ListTasks</code> returns up to
        /// 100 results and a <code>nextToken</code> value if applicable.</para>
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
        /// <para>The <code>nextToken</code> value returned from a <code>ListTasks</code> request indicating
        /// that more results are available to fulfill the request and further calls will be needed.
        /// If <code>maxResults</code> was provided, it's possible the number of results to be
        /// fewer than <code>maxResults</code>.</para><note><para>This token should be treated as an opaque identifier that is only used to retrieve
        /// the next items in a list and not for other programmatic purposes.</para></note>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskArns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.ListTasksResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.ListTasksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskArns";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Cluster parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Cluster' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Cluster' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.ListTasksResponse, GetECSTaskListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Cluster;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Cluster = this.Cluster;
            context.ContainerInstance = this.ContainerInstance;
            context.DesiredStatus = this.DesiredStatus;
            context.Family = this.Family;
            context.LaunchType = this.LaunchType;
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
            context.ServiceName = this.ServiceName;
            context.StartedBy = this.StartedBy;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.StartedBy != null)
            {
                request.StartedBy = cmdletContext.StartedBy;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
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
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                }
                
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
                    int _receivedThisCall = response.TaskArns.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
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
                return client.ListTasksAsync(request).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ServiceName { get; set; }
            public System.String StartedBy { get; set; }
            public System.Func<Amazon.ECS.Model.ListTasksResponse, GetECSTaskListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskArns;
        }
        
    }
}
