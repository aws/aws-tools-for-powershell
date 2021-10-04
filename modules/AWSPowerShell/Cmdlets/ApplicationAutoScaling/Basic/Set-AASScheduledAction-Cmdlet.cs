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
using Amazon.ApplicationAutoScaling;
using Amazon.ApplicationAutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AAS
{
    /// <summary>
    /// Creates or updates a scheduled action for an Application Auto Scaling scalable target.
    /// 
    /// 
    ///  
    /// <para>
    /// Each scalable target is identified by a service namespace, resource ID, and scalable
    /// dimension. A scheduled action applies to the scalable target identified by those three
    /// attributes. You cannot create a scheduled action until you have registered the resource
    /// as a scalable target.
    /// </para><para>
    /// When start and end times are specified with a recurring schedule using a cron expression
    /// or rates, they form the boundaries for when the recurring action starts and stops.
    /// </para><para>
    /// To update a scheduled action, specify the parameters that you want to change. If you
    /// don't specify start and end times, the old values are deleted.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/application-auto-scaling-scheduled-scaling.html">Scheduled
    /// scaling</a> in the <i>Application Auto Scaling User Guide</i>.
    /// </para><note><para>
    /// If a scalable target is deregistered, the scalable target is no longer available to
    /// run scheduled actions. Any scheduled actions that were specified for the scalable
    /// target are deleted.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "AASScheduledAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Application Auto Scaling PutScheduledAction API operation.", Operation = new[] {"PutScheduledAction"}, SelectReturnType = typeof(Amazon.ApplicationAutoScaling.Model.PutScheduledActionResponse))]
    [AWSCmdletOutput("None or Amazon.ApplicationAutoScaling.Model.PutScheduledActionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ApplicationAutoScaling.Model.PutScheduledActionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetAASScheduledActionCmdlet : AmazonApplicationAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The date and time for the recurring schedule to end, in UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter ScalableTargetAction_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum capacity.</para><para>Although you can specify a large maximum capacity, note that service quotas may impose
        /// lower limits. Each service has its own default quotas for the maximum capacity of
        /// the resource. If you want to specify a higher limit, you can request an increase.
        /// For more information, consult the documentation for that service. For information
        /// about the default quotas for each service, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-service-information.html">Service
        /// Endpoints and Quotas</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalableTargetAction_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter ScalableTargetAction_MinCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum capacity.</para><para>For certain resources, the minimum value allowed is 0. This includes Lambda provisioned
        /// concurrency, Spot Fleet, ECS services, Aurora DB clusters, EMR clusters, and custom
        /// resources. For all other resources, the minimum value allowed is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalableTargetAction_MinCapacity { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource associated with the scheduled action. This string consists
        /// of the resource type and unique identifier.</para><ul><li><para>ECS service - The resource type is <code>service</code> and the unique identifier
        /// is the cluster name and service name. Example: <code>service/default/sample-webapp</code>.</para></li><li><para>Spot Fleet - The resource type is <code>spot-fleet-request</code> and the unique identifier
        /// is the Spot Fleet request ID. Example: <code>spot-fleet-request/sfr-73fbd2ce-aa30-494c-8788-1cee4EXAMPLE</code>.</para></li><li><para>EMR cluster - The resource type is <code>instancegroup</code> and the unique identifier
        /// is the cluster ID and instance group ID. Example: <code>instancegroup/j-2EEZNYKUA1NTV/ig-1791Y4E1L8YI0</code>.</para></li><li><para>AppStream 2.0 fleet - The resource type is <code>fleet</code> and the unique identifier
        /// is the fleet name. Example: <code>fleet/sample-fleet</code>.</para></li><li><para>DynamoDB table - The resource type is <code>table</code> and the unique identifier
        /// is the table name. Example: <code>table/my-table</code>.</para></li><li><para>DynamoDB global secondary index - The resource type is <code>index</code> and the
        /// unique identifier is the index name. Example: <code>table/my-table/index/my-table-index</code>.</para></li><li><para>Aurora DB cluster - The resource type is <code>cluster</code> and the unique identifier
        /// is the cluster name. Example: <code>cluster:my-db-cluster</code>.</para></li><li><para>SageMaker endpoint variant - The resource type is <code>variant</code> and the unique
        /// identifier is the resource ID. Example: <code>endpoint/my-end-point/variant/KMeansClustering</code>.</para></li><li><para>Custom resources are not supported with a resource type. This parameter must specify
        /// the <code>OutputValue</code> from the CloudFormation template stack used to access
        /// the resources. The unique identifier is defined by the service provider. More information
        /// is available in our <a href="https://github.com/aws/aws-auto-scaling-custom-resource">GitHub
        /// repository</a>.</para></li><li><para>Amazon Comprehend document classification endpoint - The resource type and unique
        /// identifier are specified using the endpoint ARN. Example: <code>arn:aws:comprehend:us-west-2:123456789012:document-classifier-endpoint/EXAMPLE</code>.</para></li><li><para>Amazon Comprehend entity recognizer endpoint - The resource type and unique identifier
        /// are specified using the endpoint ARN. Example: <code>arn:aws:comprehend:us-west-2:123456789012:entity-recognizer-endpoint/EXAMPLE</code>.</para></li><li><para>Lambda provisioned concurrency - The resource type is <code>function</code> and the
        /// unique identifier is the function name with a function version or alias name suffix
        /// that is not <code>$LATEST</code>. Example: <code>function:my-function:prod</code>
        /// or <code>function:my-function:1</code>.</para></li><li><para>Amazon Keyspaces table - The resource type is <code>table</code> and the unique identifier
        /// is the table name. Example: <code>keyspace/mykeyspace/table/mytable</code>.</para></li><li><para>Amazon MSK cluster - The resource type and unique identifier are specified using the
        /// cluster ARN. Example: <code>arn:aws:kafka:us-east-1:123456789012:cluster/demo-cluster-1/6357e0b2-0e6a-4b86-a0b4-70df934c2e31-5</code>.</para></li><li><para>Amazon ElastiCache replication group - The resource type is <code>replication-group</code>
        /// and the unique identifier is the replication group name. Example: <code>replication-group/mycluster</code>.</para></li><li><para>Neptune cluster - The resource type is <code>cluster</code> and the unique identifier
        /// is the cluster name. Example: <code>cluster:mycluster</code>.</para></li></ul>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ScalableDimension
        /// <summary>
        /// <para>
        /// <para>The scalable dimension. This string consists of the service namespace, resource type,
        /// and scaling property.</para><ul><li><para><code>ecs:service:DesiredCount</code> - The desired task count of an ECS service.</para></li><li><para><code>elasticmapreduce:instancegroup:InstanceCount</code> - The instance count of
        /// an EMR Instance Group.</para></li><li><para><code>ec2:spot-fleet-request:TargetCapacity</code> - The target capacity of a Spot
        /// Fleet.</para></li><li><para><code>appstream:fleet:DesiredCapacity</code> - The desired capacity of an AppStream
        /// 2.0 fleet.</para></li><li><para><code>dynamodb:table:ReadCapacityUnits</code> - The provisioned read capacity for
        /// a DynamoDB table.</para></li><li><para><code>dynamodb:table:WriteCapacityUnits</code> - The provisioned write capacity for
        /// a DynamoDB table.</para></li><li><para><code>dynamodb:index:ReadCapacityUnits</code> - The provisioned read capacity for
        /// a DynamoDB global secondary index.</para></li><li><para><code>dynamodb:index:WriteCapacityUnits</code> - The provisioned write capacity for
        /// a DynamoDB global secondary index.</para></li><li><para><code>rds:cluster:ReadReplicaCount</code> - The count of Aurora Replicas in an Aurora
        /// DB cluster. Available for Aurora MySQL-compatible edition and Aurora PostgreSQL-compatible
        /// edition.</para></li><li><para><code>sagemaker:variant:DesiredInstanceCount</code> - The number of EC2 instances
        /// for an SageMaker model endpoint variant.</para></li><li><para><code>custom-resource:ResourceType:Property</code> - The scalable dimension for a
        /// custom resource provided by your own application or service.</para></li><li><para><code>comprehend:document-classifier-endpoint:DesiredInferenceUnits</code> - The
        /// number of inference units for an Amazon Comprehend document classification endpoint.</para></li><li><para><code>comprehend:entity-recognizer-endpoint:DesiredInferenceUnits</code> - The number
        /// of inference units for an Amazon Comprehend entity recognizer endpoint.</para></li><li><para><code>lambda:function:ProvisionedConcurrency</code> - The provisioned concurrency
        /// for a Lambda function.</para></li><li><para><code>cassandra:table:ReadCapacityUnits</code> - The provisioned read capacity for
        /// an Amazon Keyspaces table.</para></li><li><para><code>cassandra:table:WriteCapacityUnits</code> - The provisioned write capacity
        /// for an Amazon Keyspaces table.</para></li><li><para><code>kafka:broker-storage:VolumeSize</code> - The provisioned volume size (in GiB)
        /// for brokers in an Amazon MSK cluster.</para></li><li><para><code>elasticache:replication-group:NodeGroups</code> - The number of node groups
        /// for an Amazon ElastiCache replication group.</para></li><li><para><code>elasticache:replication-group:Replicas</code> - The number of replicas per
        /// node group for an Amazon ElastiCache replication group.</para></li><li><para><code>neptune:cluster:ReadReplicaCount</code> - The count of read replicas in an
        /// Amazon Neptune DB cluster.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ScalableDimension")]
        public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
        #endregion
        
        #region Parameter Schedule
        /// <summary>
        /// <para>
        /// <para>The schedule for this action. The following formats are supported:</para><ul><li><para>At expressions - "<code>at(<i>yyyy</i>-<i>mm</i>-<i>dd</i>T<i>hh</i>:<i>mm</i>:<i>ss</i>)</code>"</para></li><li><para>Rate expressions - "<code>rate(<i>value</i><i>unit</i>)</code>"</para></li><li><para>Cron expressions - "<code>cron(<i>fields</i>)</code>"</para></li></ul><para>At expressions are useful for one-time schedules. Cron expressions are useful for
        /// scheduled actions that run periodically at a specified date and time, and rate expressions
        /// are useful for scheduled actions that run at a regular interval.</para><para>At and cron expressions use Universal Coordinated Time (UTC) by default.</para><para>The cron format consists of six fields separated by white spaces: [Minutes] [Hours]
        /// [Day_of_Month] [Month] [Day_of_Week] [Year].</para><para>For rate expressions, <i>value</i> is a positive integer and <i>unit</i> is <code>minute</code>
        /// | <code>minutes</code> | <code>hour</code> | <code>hours</code> | <code>day</code>
        /// | <code>days</code>.</para><para>For more information and examples, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/examples-scheduled-actions.html">Example
        /// scheduled actions for Application Auto Scaling</a> in the <i>Application Auto Scaling
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule { get; set; }
        #endregion
        
        #region Parameter ScheduledActionName
        /// <summary>
        /// <para>
        /// <para>The name of the scheduled action. This name must be unique among all other scheduled
        /// actions on the specified scalable target. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ScheduledActionName { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the Amazon Web Services service that provides the resource. For a
        /// resource provided by your own application or service, use <code>custom-resource</code>
        /// instead.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ServiceNamespace")]
        public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time for this scheduled action to start, in UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Timezone
        /// <summary>
        /// <para>
        /// <para>Specifies the time zone used when setting a scheduled action by using an at or cron
        /// expression. If a time zone is not provided, UTC is used by default.</para><para>Valid values are the canonical names of the IANA time zones supported by Joda-Time
        /// (such as <code>Etc/GMT+9</code> or <code>Pacific/Tahiti</code>). For more information,
        /// see <a href="https://www.joda.org/joda-time/timezones.html">https://www.joda.org/joda-time/timezones.html</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Timezone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationAutoScaling.Model.PutScheduledActionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-AASScheduledAction (PutScheduledAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationAutoScaling.Model.PutScheduledActionResponse, SetAASScheduledActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalableDimension = this.ScalableDimension;
            #if MODULAR
            if (this.ScalableDimension == null && ParameterWasBound(nameof(this.ScalableDimension)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalableDimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalableTargetAction_MaxCapacity = this.ScalableTargetAction_MaxCapacity;
            context.ScalableTargetAction_MinCapacity = this.ScalableTargetAction_MinCapacity;
            context.Schedule = this.Schedule;
            context.ScheduledActionName = this.ScheduledActionName;
            #if MODULAR
            if (this.ScheduledActionName == null && ParameterWasBound(nameof(this.ScheduledActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceNamespace = this.ServiceNamespace;
            #if MODULAR
            if (this.ServiceNamespace == null && ParameterWasBound(nameof(this.ServiceNamespace)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNamespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            context.Timezone = this.Timezone;
            
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
            var request = new Amazon.ApplicationAutoScaling.Model.PutScheduledActionRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ScalableDimension != null)
            {
                request.ScalableDimension = cmdletContext.ScalableDimension;
            }
            
             // populate ScalableTargetAction
            var requestScalableTargetActionIsNull = true;
            request.ScalableTargetAction = new Amazon.ApplicationAutoScaling.Model.ScalableTargetAction();
            System.Int32? requestScalableTargetAction_scalableTargetAction_MaxCapacity = null;
            if (cmdletContext.ScalableTargetAction_MaxCapacity != null)
            {
                requestScalableTargetAction_scalableTargetAction_MaxCapacity = cmdletContext.ScalableTargetAction_MaxCapacity.Value;
            }
            if (requestScalableTargetAction_scalableTargetAction_MaxCapacity != null)
            {
                request.ScalableTargetAction.MaxCapacity = requestScalableTargetAction_scalableTargetAction_MaxCapacity.Value;
                requestScalableTargetActionIsNull = false;
            }
            System.Int32? requestScalableTargetAction_scalableTargetAction_MinCapacity = null;
            if (cmdletContext.ScalableTargetAction_MinCapacity != null)
            {
                requestScalableTargetAction_scalableTargetAction_MinCapacity = cmdletContext.ScalableTargetAction_MinCapacity.Value;
            }
            if (requestScalableTargetAction_scalableTargetAction_MinCapacity != null)
            {
                request.ScalableTargetAction.MinCapacity = requestScalableTargetAction_scalableTargetAction_MinCapacity.Value;
                requestScalableTargetActionIsNull = false;
            }
             // determine if request.ScalableTargetAction should be set to null
            if (requestScalableTargetActionIsNull)
            {
                request.ScalableTargetAction = null;
            }
            if (cmdletContext.Schedule != null)
            {
                request.Schedule = cmdletContext.Schedule;
            }
            if (cmdletContext.ScheduledActionName != null)
            {
                request.ScheduledActionName = cmdletContext.ScheduledActionName;
            }
            if (cmdletContext.ServiceNamespace != null)
            {
                request.ServiceNamespace = cmdletContext.ServiceNamespace;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Timezone != null)
            {
                request.Timezone = cmdletContext.Timezone;
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
        
        private Amazon.ApplicationAutoScaling.Model.PutScheduledActionResponse CallAWSServiceOperation(IAmazonApplicationAutoScaling client, Amazon.ApplicationAutoScaling.Model.PutScheduledActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Auto Scaling", "PutScheduledAction");
            try
            {
                #if DESKTOP
                return client.PutScheduledAction(request);
                #elif CORECLR
                return client.PutScheduledActionAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String ResourceId { get; set; }
            public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
            public System.Int32? ScalableTargetAction_MaxCapacity { get; set; }
            public System.Int32? ScalableTargetAction_MinCapacity { get; set; }
            public System.String Schedule { get; set; }
            public System.String ScheduledActionName { get; set; }
            public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.String Timezone { get; set; }
            public System.Func<Amazon.ApplicationAutoScaling.Model.PutScheduledActionResponse, SetAASScheduledActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
