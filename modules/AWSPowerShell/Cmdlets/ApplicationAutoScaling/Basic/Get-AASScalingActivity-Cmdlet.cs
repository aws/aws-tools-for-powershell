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
using Amazon.ApplicationAutoScaling;
using Amazon.ApplicationAutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AAS
{
    /// <summary>
    /// Provides descriptive information about the scaling activities in the specified namespace
    /// from the previous six weeks.
    /// 
    ///  
    /// <para>
    /// You can filter the results using <c>ResourceId</c> and <c>ScalableDimension</c>.
    /// </para><para>
    /// For information about viewing scaling activities using the Amazon Web Services CLI,
    /// see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/application-auto-scaling-scaling-activities.html">Scaling
    /// activities for Application Auto Scaling</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "AASScalingActivity")]
    [OutputType("Amazon.ApplicationAutoScaling.Model.ScalingActivity")]
    [AWSCmdlet("Calls the Application Auto Scaling DescribeScalingActivities API operation.", Operation = new[] {"DescribeScalingActivities"}, SelectReturnType = typeof(Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesResponse))]
    [AWSCmdletOutput("Amazon.ApplicationAutoScaling.Model.ScalingActivity or Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesResponse",
        "This cmdlet returns a collection of Amazon.ApplicationAutoScaling.Model.ScalingActivity objects.",
        "The service call response (type Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAASScalingActivityCmdlet : AmazonApplicationAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IncludeNotScaledActivity
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include activities that aren't scaled (<i>not scaled activities</i>)
        /// in the response. Not scaled activities are activities that aren't completed or started
        /// for various reasons, such as preventing infinite scaling loops. For help interpreting
        /// the not scaled reason details in the response, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/application-auto-scaling-scaling-activities.html">Scaling
        /// activities for Application Auto Scaling</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeNotScaledActivities")]
        public System.Boolean? IncludeNotScaledActivity { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource associated with the scaling activity. This string consists
        /// of the resource type and unique identifier.</para><ul><li><para>ECS service - The resource type is <c>service</c> and the unique identifier is the
        /// cluster name and service name. Example: <c>service/my-cluster/my-service</c>.</para></li><li><para>Spot Fleet - The resource type is <c>spot-fleet-request</c> and the unique identifier
        /// is the Spot Fleet request ID. Example: <c>spot-fleet-request/sfr-73fbd2ce-aa30-494c-8788-1cee4EXAMPLE</c>.</para></li><li><para>EMR cluster - The resource type is <c>instancegroup</c> and the unique identifier
        /// is the cluster ID and instance group ID. Example: <c>instancegroup/j-2EEZNYKUA1NTV/ig-1791Y4E1L8YI0</c>.</para></li><li><para>AppStream 2.0 fleet - The resource type is <c>fleet</c> and the unique identifier
        /// is the fleet name. Example: <c>fleet/sample-fleet</c>.</para></li><li><para>DynamoDB table - The resource type is <c>table</c> and the unique identifier is the
        /// table name. Example: <c>table/my-table</c>.</para></li><li><para>DynamoDB global secondary index - The resource type is <c>index</c> and the unique
        /// identifier is the index name. Example: <c>table/my-table/index/my-table-index</c>.</para></li><li><para>Aurora DB cluster - The resource type is <c>cluster</c> and the unique identifier
        /// is the cluster name. Example: <c>cluster:my-db-cluster</c>.</para></li><li><para>SageMaker endpoint variant - The resource type is <c>variant</c> and the unique identifier
        /// is the resource ID. Example: <c>endpoint/my-end-point/variant/KMeansClustering</c>.</para></li><li><para>Custom resources are not supported with a resource type. This parameter must specify
        /// the <c>OutputValue</c> from the CloudFormation template stack used to access the resources.
        /// The unique identifier is defined by the service provider. More information is available
        /// in our <a href="https://github.com/aws/aws-auto-scaling-custom-resource">GitHub repository</a>.</para></li><li><para>Amazon Comprehend document classification endpoint - The resource type and unique
        /// identifier are specified using the endpoint ARN. Example: <c>arn:aws:comprehend:us-west-2:123456789012:document-classifier-endpoint/EXAMPLE</c>.</para></li><li><para>Amazon Comprehend entity recognizer endpoint - The resource type and unique identifier
        /// are specified using the endpoint ARN. Example: <c>arn:aws:comprehend:us-west-2:123456789012:entity-recognizer-endpoint/EXAMPLE</c>.</para></li><li><para>Lambda provisioned concurrency - The resource type is <c>function</c> and the unique
        /// identifier is the function name with a function version or alias name suffix that
        /// is not <c>$LATEST</c>. Example: <c>function:my-function:prod</c> or <c>function:my-function:1</c>.</para></li><li><para>Amazon Keyspaces table - The resource type is <c>table</c> and the unique identifier
        /// is the table name. Example: <c>keyspace/mykeyspace/table/mytable</c>.</para></li><li><para>Amazon MSK cluster - The resource type and unique identifier are specified using the
        /// cluster ARN. Example: <c>arn:aws:kafka:us-east-1:123456789012:cluster/demo-cluster-1/6357e0b2-0e6a-4b86-a0b4-70df934c2e31-5</c>.</para></li><li><para>Amazon ElastiCache replication group - The resource type is <c>replication-group</c>
        /// and the unique identifier is the replication group name. Example: <c>replication-group/mycluster</c>.</para></li><li><para>Amazon ElastiCache cache cluster - The resource type is <c>cache-cluster</c> and the
        /// unique identifier is the cache cluster name. Example: <c>cache-cluster/mycluster</c>.</para></li><li><para>Neptune cluster - The resource type is <c>cluster</c> and the unique identifier is
        /// the cluster name. Example: <c>cluster:mycluster</c>.</para></li><li><para>SageMaker serverless endpoint - The resource type is <c>variant</c> and the unique
        /// identifier is the resource ID. Example: <c>endpoint/my-end-point/variant/KMeansClustering</c>.</para></li><li><para>SageMaker inference component - The resource type is <c>inference-component</c> and
        /// the unique identifier is the resource ID. Example: <c>inference-component/my-inference-component</c>.</para></li><li><para>Pool of WorkSpaces - The resource type is <c>workspacespool</c> and the unique identifier
        /// is the pool ID. Example: <c>workspacespool/wspool-123456</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ScalableDimension
        /// <summary>
        /// <para>
        /// <para>The scalable dimension. This string consists of the service namespace, resource type,
        /// and scaling property. If you specify a scalable dimension, you must also specify a
        /// resource ID.</para><ul><li><para><c>ecs:service:DesiredCount</c> - The task count of an ECS service.</para></li><li><para><c>elasticmapreduce:instancegroup:InstanceCount</c> - The instance count of an EMR
        /// Instance Group.</para></li><li><para><c>ec2:spot-fleet-request:TargetCapacity</c> - The target capacity of a Spot Fleet.</para></li><li><para><c>appstream:fleet:DesiredCapacity</c> - The capacity of an AppStream 2.0 fleet.</para></li><li><para><c>dynamodb:table:ReadCapacityUnits</c> - The provisioned read capacity for a DynamoDB
        /// table.</para></li><li><para><c>dynamodb:table:WriteCapacityUnits</c> - The provisioned write capacity for a DynamoDB
        /// table.</para></li><li><para><c>dynamodb:index:ReadCapacityUnits</c> - The provisioned read capacity for a DynamoDB
        /// global secondary index.</para></li><li><para><c>dynamodb:index:WriteCapacityUnits</c> - The provisioned write capacity for a DynamoDB
        /// global secondary index.</para></li><li><para><c>rds:cluster:ReadReplicaCount</c> - The count of Aurora Replicas in an Aurora DB
        /// cluster. Available for Aurora MySQL-compatible edition and Aurora PostgreSQL-compatible
        /// edition.</para></li><li><para><c>sagemaker:variant:DesiredInstanceCount</c> - The number of EC2 instances for a
        /// SageMaker model endpoint variant.</para></li><li><para><c>custom-resource:ResourceType:Property</c> - The scalable dimension for a custom
        /// resource provided by your own application or service.</para></li><li><para><c>comprehend:document-classifier-endpoint:DesiredInferenceUnits</c> - The number
        /// of inference units for an Amazon Comprehend document classification endpoint.</para></li><li><para><c>comprehend:entity-recognizer-endpoint:DesiredInferenceUnits</c> - The number of
        /// inference units for an Amazon Comprehend entity recognizer endpoint.</para></li><li><para><c>lambda:function:ProvisionedConcurrency</c> - The provisioned concurrency for a
        /// Lambda function.</para></li><li><para><c>cassandra:table:ReadCapacityUnits</c> - The provisioned read capacity for an Amazon
        /// Keyspaces table.</para></li><li><para><c>cassandra:table:WriteCapacityUnits</c> - The provisioned write capacity for an
        /// Amazon Keyspaces table.</para></li><li><para><c>kafka:broker-storage:VolumeSize</c> - The provisioned volume size (in GiB) for
        /// brokers in an Amazon MSK cluster.</para></li><li><para><c>elasticache:cache-cluster:Nodes</c> - The number of nodes for an Amazon ElastiCache
        /// cache cluster.</para></li><li><para><c>elasticache:replication-group:NodeGroups</c> - The number of node groups for an
        /// Amazon ElastiCache replication group.</para></li><li><para><c>elasticache:replication-group:Replicas</c> - The number of replicas per node group
        /// for an Amazon ElastiCache replication group.</para></li><li><para><c>neptune:cluster:ReadReplicaCount</c> - The count of read replicas in an Amazon
        /// Neptune DB cluster.</para></li><li><para><c>sagemaker:variant:DesiredProvisionedConcurrency</c> - The provisioned concurrency
        /// for a SageMaker serverless endpoint.</para></li><li><para><c>sagemaker:inference-component:DesiredCopyCount</c> - The number of copies across
        /// an endpoint for a SageMaker inference component.</para></li><li><para><c>workspaces:workspacespool:DesiredUserSessions</c> - The number of user sessions
        /// for the WorkSpaces in the pool.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ScalableDimension")]
        public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the Amazon Web Services service that provides the resource. For a
        /// resource provided by your own application or service, use <c>custom-resource</c> instead.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ServiceNamespace")]
        public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of scalable targets. This value can be between 1 and 50. The default
        /// value is 50.</para><para>If this parameter is used, the operation returns up to <c>MaxResults</c> results at
        /// a time, along with a <c>NextToken</c> value. To get the next set of results, include
        /// the <c>NextToken</c> value in a subsequent call. If this parameter is not used, the
        /// operation returns up to 50 results and a <c>NextToken</c> value, if applicable.</para>
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
        /// <para>The token for the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScalingActivities'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesResponse).
        /// Specifying the name of a property of type Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScalingActivities";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceNamespace parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceNamespace' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceNamespace' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesResponse, GetAASScalingActivityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceNamespace;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IncludeNotScaledActivity = this.IncludeNotScaledActivity;
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
            context.ResourceId = this.ResourceId;
            context.ScalableDimension = this.ScalableDimension;
            context.ServiceNamespace = this.ServiceNamespace;
            #if MODULAR
            if (this.ServiceNamespace == null && ParameterWasBound(nameof(this.ServiceNamespace)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNamespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesRequest();
            
            if (cmdletContext.IncludeNotScaledActivity != null)
            {
                request.IncludeNotScaledActivities = cmdletContext.IncludeNotScaledActivity.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ScalableDimension != null)
            {
                request.ScalableDimension = cmdletContext.ScalableDimension;
            }
            if (cmdletContext.ServiceNamespace != null)
            {
                request.ServiceNamespace = cmdletContext.ServiceNamespace;
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
            var request = new Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesRequest();
            if (cmdletContext.IncludeNotScaledActivity != null)
            {
                request.IncludeNotScaledActivities = cmdletContext.IncludeNotScaledActivity.Value;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ScalableDimension != null)
            {
                request.ScalableDimension = cmdletContext.ScalableDimension;
            }
            if (cmdletContext.ServiceNamespace != null)
            {
                request.ServiceNamespace = cmdletContext.ServiceNamespace;
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
                    int _receivedThisCall = response.ScalingActivities.Count;
                    
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
        
        private Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesResponse CallAWSServiceOperation(IAmazonApplicationAutoScaling client, Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Auto Scaling", "DescribeScalingActivities");
            try
            {
                #if DESKTOP
                return client.DescribeScalingActivities(request);
                #elif CORECLR
                return client.DescribeScalingActivitiesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeNotScaledActivity { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceId { get; set; }
            public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
            public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
            public System.Func<Amazon.ApplicationAutoScaling.Model.DescribeScalingActivitiesResponse, GetAASScalingActivityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScalingActivities;
        }
        
    }
}
