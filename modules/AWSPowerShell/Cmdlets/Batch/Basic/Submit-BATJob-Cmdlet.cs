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
using Amazon.Batch;
using Amazon.Batch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Submits an Batch job from a job definition. Parameters that are specified during <a>SubmitJob</a>
    /// override parameters defined in the job definition. vCPU and memory requirements that
    /// are specified in the <c>resourceRequirements</c> objects in the job definition are
    /// the exception. They can't be overridden this way using the <c>memory</c> and <c>vcpus</c>
    /// parameters. Rather, you must specify updates to job definition parameters in a <c>resourceRequirements</c>
    /// object that's included in the <c>containerOverrides</c> parameter.
    /// 
    ///  <note><para>
    /// Job queues with a scheduling policy are limited to 500 active share identifiers at
    /// a time. 
    /// </para></note><important><para>
    /// Jobs that run on Fargate resources can't be guaranteed to run for more than 14 days.
    /// This is because, after 14 days, Fargate resources might become unavailable and job
    /// might be terminated.
    /// </para></important>
    /// </summary>
    [Cmdlet("Submit", "BATJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.SubmitJobResponse")]
    [AWSCmdlet("Calls the AWS Batch SubmitJob API operation.", Operation = new[] {"SubmitJob"}, SelectReturnType = typeof(Amazon.Batch.Model.SubmitJobResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.SubmitJobResponse",
        "This cmdlet returns an Amazon.Batch.Model.SubmitJobResponse object containing multiple properties."
    )]
    public partial class SubmitBATJobCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Metadata_Annotation
        /// <summary>
        /// <para>
        /// <para>Key-value pairs used to attach arbitrary, non-identifying metadata to Kubernetes objects.
        /// Valid annotation keys have two segments: an optional prefix and a name, separated
        /// by a slash (/). </para><ul><li><para>The prefix is optional and must be 253 characters or less. If specified, the prefix
        /// must be a DNS subdomain− a series of DNS labels separated by dots (.), and it must
        /// end with a slash (/).</para></li><li><para>The name segment is required and must be 63 characters or less. It can include alphanumeric
        /// characters ([a-z0-9A-Z]), dashes (-), underscores (_), and dots (.), but must begin
        /// and end with an alphanumeric character.</para></li></ul><note><para>Annotation values must be 255 characters or less.</para></note><para>Annotations can be added or modified at any time. Each resource can have multiple
        /// annotations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksPropertiesOverride_PodProperties_Metadata_Annotations")]
        public System.Collections.Hashtable Metadata_Annotation { get; set; }
        #endregion
        
        #region Parameter RetryStrategy_Attempt
        /// <summary>
        /// <para>
        /// <para>The number of times to move a job to the <c>RUNNABLE</c> status. You can specify between
        /// 1 and 10 attempts. If the value of <c>attempts</c> is greater than one, the job is
        /// retried on failure the same number of attempts as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryStrategy_Attempts")]
        public System.Int32? RetryStrategy_Attempt { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Command
        /// <summary>
        /// <para>
        /// <para>The command to send to the container that overrides the default command from the Docker
        /// image or the job definition.</para><note><para>This parameter can't contain an empty string.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ContainerOverrides_Command { get; set; }
        #endregion
        
        #region Parameter ConsumableResourcePropertiesOverride_ConsumableResourceList
        /// <summary>
        /// <para>
        /// <para>The list of consumable resources required by a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.ConsumableResourceRequirement[] ConsumableResourcePropertiesOverride_ConsumableResourceList { get; set; }
        #endregion
        
        #region Parameter PodProperties_Container
        /// <summary>
        /// <para>
        /// <para>The overrides for the container that's used on the Amazon EKS pod.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksPropertiesOverride_PodProperties_Containers")]
        public Amazon.Batch.Model.EksContainerOverride[] PodProperties_Container { get; set; }
        #endregion
        
        #region Parameter DependsOn
        /// <summary>
        /// <para>
        /// <para>A list of dependencies for the job. A job can depend upon a maximum of 20 jobs. You
        /// can specify a <c>SEQUENTIAL</c> type dependency without specifying a job ID for array
        /// jobs so that each child array job completes sequentially, starting at index 0. You
        /// can also specify an <c>N_TO_N</c> type dependency with a job ID for array jobs. In
        /// that case, each index child of this job must wait for the corresponding index child
        /// of each dependency to complete before it can begin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.JobDependency[] DependsOn { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to send to the container. You can add new environment variables,
        /// which are added to the container at launch, or you can override the existing environment
        /// variables from the Docker image or the job definition.</para><note><para>Environment variables cannot start with "<c>AWS_BATCH</c>". This naming convention
        /// is reserved for variables that Batch sets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.KeyValuePair[] ContainerOverrides_Environment { get; set; }
        #endregion
        
        #region Parameter RetryStrategy_EvaluateOnExit
        /// <summary>
        /// <para>
        /// <para>Array of up to 5 objects that specify the conditions where jobs are retried or failed.
        /// If this parameter is specified, then the <c>attempts</c> parameter must also be specified.
        /// If none of the listed conditions match, then the job is retried.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.EvaluateOnExit[] RetryStrategy_EvaluateOnExit { get; set; }
        #endregion
        
        #region Parameter PodProperties_InitContainer
        /// <summary>
        /// <para>
        /// <para>The overrides for the <c>initContainers</c> defined in the Amazon EKS pod. These containers
        /// run before application containers, always run to completion, and must complete successfully
        /// before the next container starts. These containers are registered with the Amazon
        /// EKS Connector agent and persists the registration information in the Kubernetes backend
        /// data store. For more information, see <a href="https://kubernetes.io/docs/concepts/workloads/pods/init-containers/">Init
        /// Containers</a> in the <i>Kubernetes documentation</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksPropertiesOverride_PodProperties_InitContainers")]
        public Amazon.Batch.Model.EksContainerOverride[] PodProperties_InitContainer { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use for a multi-node parallel job.</para><note><para>This parameter isn't applicable to single-node container jobs or jobs that run on
        /// Fargate resources, and shouldn't be provided.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerOverrides_InstanceType { get; set; }
        #endregion
        
        #region Parameter JobDefinition
        /// <summary>
        /// <para>
        /// <para>The job definition used by this job. This value can be one of <c>definition-name</c>,
        /// <c>definition-name:revision</c>, or the Amazon Resource Name (ARN) for the job definition,
        /// with or without the revision (<c>arn:aws:batch:<i>region</i>:<i>account</i>:job-definition/<i>definition-name</i>:<i>revision</i></c>, or <c>arn:aws:batch:<i>region</i>:<i>account</i>:job-definition/<i>definition-name</i></c>).</para><para>If the revision is not specified, then the latest active revision is used.</para>
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
        public System.String JobDefinition { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the job. It can be up to 128 letters long. The first character must be
        /// alphanumeric, can contain uppercase and lowercase letters, numbers, hyphens (-), and
        /// underscores (_).</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobQueue
        /// <summary>
        /// <para>
        /// <para>The job queue where the job is submitted. You can specify either the name or the Amazon
        /// Resource Name (ARN) of the queue.</para>
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
        public System.String JobQueue { get; set; }
        #endregion
        
        #region Parameter Metadata_Label
        /// <summary>
        /// <para>
        /// <para>Key-value pairs used to identify, sort, and organize cube resources. Can contain up
        /// to 63 uppercase letters, lowercase letters, numbers, hyphens (-), and underscores
        /// (_). Labels can be added or modified at any time. Each resource can have multiple
        /// labels, but each key must be unique for a given object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksPropertiesOverride_PodProperties_Metadata_Labels")]
        public System.Collections.Hashtable Metadata_Label { get; set; }
        #endregion
        
        #region Parameter Metadata_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the Amazon EKS cluster. In Kubernetes, namespaces provide a mechanism
        /// for isolating groups of resources within a single cluster. Names of resources need
        /// to be unique within a namespace, but not across namespaces. Batch places Batch Job
        /// pods in this namespace. If this field is provided, the value can't be empty or null.
        /// It must meet the following requirements:</para><ul><li><para>1-63 characters long</para></li><li><para>Can't be set to default</para></li><li><para>Can't start with <c>kube</c></para></li><li><para>Must match the following regular expression: <c>^[a-z0-9]([-a-z0-9]*[a-z0-9])?$</c></para></li></ul><para> For more information, see <a href="https://kubernetes.io/docs/concepts/overview/working-with-objects/namespaces/">Namespaces</a>
        /// in the <i>Kubernetes documentation</i>. This namespace can be different from the <c>kubernetesNamespace</c>
        /// set in the compute environment's <c>EksConfiguration</c>, but must have identical
        /// role-based access control (RBAC) roles as the compute environment's <c>kubernetesNamespace</c>.
        /// For multi-node parallel jobs, the same value must be provided across all the node
        /// ranges.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksPropertiesOverride_PodProperties_Metadata_Namespace")]
        public System.String Metadata_Namespace { get; set; }
        #endregion
        
        #region Parameter NodeOverrides_NodePropertyOverride
        /// <summary>
        /// <para>
        /// <para>The node property overrides for the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeOverrides_NodePropertyOverrides")]
        public Amazon.Batch.Model.NodePropertyOverride[] NodeOverrides_NodePropertyOverride { get; set; }
        #endregion
        
        #region Parameter NodeOverrides_NumNode
        /// <summary>
        /// <para>
        /// <para>The number of nodes to use with a multi-node parallel job. This value overrides the
        /// number of nodes that are specified in the job definition. To use this override, you
        /// must meet the following conditions:</para><ul><li><para>There must be at least one node range in your job definition that has an open upper
        /// boundary, such as <c>:</c> or <c>n:</c>.</para></li><li><para>The lower boundary of the node range that's specified in the job definition must be
        /// fewer than the number of nodes specified in the override.</para></li><li><para>The main node index that's specified in the job definition must be fewer than the
        /// number of nodes specified in the override.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeOverrides_NumNodes")]
        public System.Int32? NodeOverrides_NumNode { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>Additional parameters passed to the job that replace parameter substitution placeholders
        /// that are set in the job definition. Parameters are specified as a key and value pair
        /// mapping. Parameters in a <c>SubmitJob</c> request override any corresponding parameter
        /// defaults from the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the job or job definition to the corresponding
        /// Amazon ECS task. If no value is specified, the tags aren't propagated. Tags can only
        /// be propagated to the tasks during task creation. For tags with the same name, job
        /// tags are given priority over job definitions tags. If the total number of combined
        /// tags from the job and job definition is over 50, the job is moved to the <c>FAILED</c>
        /// state. When specified, this overrides the tag propagation setting in the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagateTags")]
        public System.Boolean? PropagateTag { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_ResourceRequirement
        /// <summary>
        /// <para>
        /// <para>The type and amount of resources to assign to a container. This overrides the settings
        /// in the job definition. The supported resources include <c>GPU</c>, <c>MEMORY</c>,
        /// and <c>VCPU</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerOverrides_ResourceRequirements")]
        public Amazon.Batch.Model.ResourceRequirement[] ContainerOverrides_ResourceRequirement { get; set; }
        #endregion
        
        #region Parameter SchedulingPriorityOverride
        /// <summary>
        /// <para>
        /// <para>The scheduling priority for the job. This only affects jobs in job queues with a fair-share
        /// policy. Jobs with a higher scheduling priority are scheduled before jobs with a lower
        /// scheduling priority. This overrides any scheduling priority in the job definition
        /// and works only within a single share identifier.</para><para>The minimum supported value is 0 and the maximum supported value is 9999.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SchedulingPriorityOverride { get; set; }
        #endregion
        
        #region Parameter ShareIdentifier
        /// <summary>
        /// <para>
        /// <para>The share identifier for the job. Don't specify this parameter if the job queue doesn't
        /// have a fair-share scheduling policy. If the job queue has a fair-share scheduling
        /// policy, then this parameter must be specified.</para><para>This string is limited to 255 alphanumeric characters, and can be followed by an asterisk
        /// (*).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShareIdentifier { get; set; }
        #endregion
        
        #region Parameter ArrayProperties_Size
        /// <summary>
        /// <para>
        /// <para>The size of the array job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ArrayProperties_Size { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you apply to the job request to help you categorize and organize your
        /// resources. Each tag consists of a key and an optional value. For more information,
        /// see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a> in <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter EcsPropertiesOverride_TaskProperty
        /// <summary>
        /// <para>
        /// <para>The overrides for the Amazon ECS task definition of a job.</para><note><para>This object is currently limited to one element.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EcsPropertiesOverride_TaskProperties")]
        public Amazon.Batch.Model.TaskPropertiesOverride[] EcsPropertiesOverride_TaskProperty { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The timeout configuration for this <a>SubmitJob</a> operation. You can specify a timeout
        /// duration after which Batch terminates your jobs if they haven't finished. If a job
        /// is terminated due to a timeout, it isn't retried. The minimum value for the timeout
        /// is 60 seconds. This configuration overrides any timeout configuration specified in
        /// the job definition. For array jobs, child jobs have the same timeout configuration
        /// as the parent job. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/job_timeouts.html">Job
        /// Timeouts</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.JobTimeout Timeout { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Memory
        /// <summary>
        /// <para>
        /// <para>This parameter is deprecated, use <c>resourceRequirements</c> to override the memory
        /// requirements specified in the job definition. It's not supported for jobs running
        /// on Fargate resources. For jobs that run on Amazon EC2 resources, it overrides the
        /// <c>memory</c> parameter set in the job definition, but doesn't override any memory
        /// requirement that's specified in the <c>resourceRequirements</c> structure in the job
        /// definition. To override memory requirements that are specified in the <c>resourceRequirements</c>
        /// structure in the job definition, <c>resourceRequirements</c> must be specified in
        /// the <c>SubmitJob</c> request, with <c>type</c> set to <c>MEMORY</c> and <c>value</c>
        /// set to the new value. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/troubleshooting.html#override-resource-requirements">Can't
        /// override job definition resource requirements</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated, use resourceRequirements instead.")]
        public System.Int32? ContainerOverrides_Memory { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Vcpus
        /// <summary>
        /// <para>
        /// <para>This parameter is deprecated, use <c>resourceRequirements</c> to override the <c>vcpus</c>
        /// parameter that's set in the job definition. It's not supported for jobs running on
        /// Fargate resources. For jobs that run on Amazon EC2 resources, it overrides the <c>vcpus</c>
        /// parameter set in the job definition, but doesn't override any vCPU requirement specified
        /// in the <c>resourceRequirements</c> structure in the job definition. To override vCPU
        /// requirements that are specified in the <c>resourceRequirements</c> structure in the
        /// job definition, <c>resourceRequirements</c> must be specified in the <c>SubmitJob</c>
        /// request, with <c>type</c> set to <c>VCPU</c> and <c>value</c> set to the new value.
        /// For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/troubleshooting.html#override-resource-requirements">Can't
        /// override job definition resource requirements</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated, use resourceRequirements instead.")]
        public System.Int32? ContainerOverrides_Vcpus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.SubmitJobResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.SubmitJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-BATJob (SubmitJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.SubmitJobResponse, SubmitBATJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArrayProperties_Size = this.ArrayProperties_Size;
            if (this.ConsumableResourcePropertiesOverride_ConsumableResourceList != null)
            {
                context.ConsumableResourcePropertiesOverride_ConsumableResourceList = new List<Amazon.Batch.Model.ConsumableResourceRequirement>(this.ConsumableResourcePropertiesOverride_ConsumableResourceList);
            }
            if (this.ContainerOverrides_Command != null)
            {
                context.ContainerOverrides_Command = new List<System.String>(this.ContainerOverrides_Command);
            }
            if (this.ContainerOverrides_Environment != null)
            {
                context.ContainerOverrides_Environment = new List<Amazon.Batch.Model.KeyValuePair>(this.ContainerOverrides_Environment);
            }
            context.ContainerOverrides_InstanceType = this.ContainerOverrides_InstanceType;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContainerOverrides_Memory = this.ContainerOverrides_Memory;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ContainerOverrides_ResourceRequirement != null)
            {
                context.ContainerOverrides_ResourceRequirement = new List<Amazon.Batch.Model.ResourceRequirement>(this.ContainerOverrides_ResourceRequirement);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContainerOverrides_Vcpus = this.ContainerOverrides_Vcpus;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DependsOn != null)
            {
                context.DependsOn = new List<Amazon.Batch.Model.JobDependency>(this.DependsOn);
            }
            if (this.EcsPropertiesOverride_TaskProperty != null)
            {
                context.EcsPropertiesOverride_TaskProperty = new List<Amazon.Batch.Model.TaskPropertiesOverride>(this.EcsPropertiesOverride_TaskProperty);
            }
            if (this.PodProperties_Container != null)
            {
                context.PodProperties_Container = new List<Amazon.Batch.Model.EksContainerOverride>(this.PodProperties_Container);
            }
            if (this.PodProperties_InitContainer != null)
            {
                context.PodProperties_InitContainer = new List<Amazon.Batch.Model.EksContainerOverride>(this.PodProperties_InitContainer);
            }
            if (this.Metadata_Annotation != null)
            {
                context.Metadata_Annotation = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata_Annotation.Keys)
                {
                    context.Metadata_Annotation.Add((String)hashKey, (System.String)(this.Metadata_Annotation[hashKey]));
                }
            }
            if (this.Metadata_Label != null)
            {
                context.Metadata_Label = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata_Label.Keys)
                {
                    context.Metadata_Label.Add((String)hashKey, (System.String)(this.Metadata_Label[hashKey]));
                }
            }
            context.Metadata_Namespace = this.Metadata_Namespace;
            context.JobDefinition = this.JobDefinition;
            #if MODULAR
            if (this.JobDefinition == null && ParameterWasBound(nameof(this.JobDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter JobDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobQueue = this.JobQueue;
            #if MODULAR
            if (this.JobQueue == null && ParameterWasBound(nameof(this.JobQueue)))
            {
                WriteWarning("You are passing $null as a value for parameter JobQueue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NodeOverrides_NodePropertyOverride != null)
            {
                context.NodeOverrides_NodePropertyOverride = new List<Amazon.Batch.Model.NodePropertyOverride>(this.NodeOverrides_NodePropertyOverride);
            }
            context.NodeOverrides_NumNode = this.NodeOverrides_NumNode;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (System.String)(this.Parameter[hashKey]));
                }
            }
            context.PropagateTag = this.PropagateTag;
            context.RetryStrategy_Attempt = this.RetryStrategy_Attempt;
            if (this.RetryStrategy_EvaluateOnExit != null)
            {
                context.RetryStrategy_EvaluateOnExit = new List<Amazon.Batch.Model.EvaluateOnExit>(this.RetryStrategy_EvaluateOnExit);
            }
            context.SchedulingPriorityOverride = this.SchedulingPriorityOverride;
            context.ShareIdentifier = this.ShareIdentifier;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Timeout = this.Timeout;
            
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
            var request = new Amazon.Batch.Model.SubmitJobRequest();
            
            
             // populate ArrayProperties
            var requestArrayPropertiesIsNull = true;
            request.ArrayProperties = new Amazon.Batch.Model.ArrayProperties();
            System.Int32? requestArrayProperties_arrayProperties_Size = null;
            if (cmdletContext.ArrayProperties_Size != null)
            {
                requestArrayProperties_arrayProperties_Size = cmdletContext.ArrayProperties_Size.Value;
            }
            if (requestArrayProperties_arrayProperties_Size != null)
            {
                request.ArrayProperties.Size = requestArrayProperties_arrayProperties_Size.Value;
                requestArrayPropertiesIsNull = false;
            }
             // determine if request.ArrayProperties should be set to null
            if (requestArrayPropertiesIsNull)
            {
                request.ArrayProperties = null;
            }
            
             // populate ConsumableResourcePropertiesOverride
            var requestConsumableResourcePropertiesOverrideIsNull = true;
            request.ConsumableResourcePropertiesOverride = new Amazon.Batch.Model.ConsumableResourceProperties();
            List<Amazon.Batch.Model.ConsumableResourceRequirement> requestConsumableResourcePropertiesOverride_consumableResourcePropertiesOverride_ConsumableResourceList = null;
            if (cmdletContext.ConsumableResourcePropertiesOverride_ConsumableResourceList != null)
            {
                requestConsumableResourcePropertiesOverride_consumableResourcePropertiesOverride_ConsumableResourceList = cmdletContext.ConsumableResourcePropertiesOverride_ConsumableResourceList;
            }
            if (requestConsumableResourcePropertiesOverride_consumableResourcePropertiesOverride_ConsumableResourceList != null)
            {
                request.ConsumableResourcePropertiesOverride.ConsumableResourceList = requestConsumableResourcePropertiesOverride_consumableResourcePropertiesOverride_ConsumableResourceList;
                requestConsumableResourcePropertiesOverrideIsNull = false;
            }
             // determine if request.ConsumableResourcePropertiesOverride should be set to null
            if (requestConsumableResourcePropertiesOverrideIsNull)
            {
                request.ConsumableResourcePropertiesOverride = null;
            }
            
             // populate ContainerOverrides
            var requestContainerOverridesIsNull = true;
            request.ContainerOverrides = new Amazon.Batch.Model.ContainerOverrides();
            List<System.String> requestContainerOverrides_containerOverrides_Command = null;
            if (cmdletContext.ContainerOverrides_Command != null)
            {
                requestContainerOverrides_containerOverrides_Command = cmdletContext.ContainerOverrides_Command;
            }
            if (requestContainerOverrides_containerOverrides_Command != null)
            {
                request.ContainerOverrides.Command = requestContainerOverrides_containerOverrides_Command;
                requestContainerOverridesIsNull = false;
            }
            List<Amazon.Batch.Model.KeyValuePair> requestContainerOverrides_containerOverrides_Environment = null;
            if (cmdletContext.ContainerOverrides_Environment != null)
            {
                requestContainerOverrides_containerOverrides_Environment = cmdletContext.ContainerOverrides_Environment;
            }
            if (requestContainerOverrides_containerOverrides_Environment != null)
            {
                request.ContainerOverrides.Environment = requestContainerOverrides_containerOverrides_Environment;
                requestContainerOverridesIsNull = false;
            }
            System.String requestContainerOverrides_containerOverrides_InstanceType = null;
            if (cmdletContext.ContainerOverrides_InstanceType != null)
            {
                requestContainerOverrides_containerOverrides_InstanceType = cmdletContext.ContainerOverrides_InstanceType;
            }
            if (requestContainerOverrides_containerOverrides_InstanceType != null)
            {
                request.ContainerOverrides.InstanceType = requestContainerOverrides_containerOverrides_InstanceType;
                requestContainerOverridesIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int32? requestContainerOverrides_containerOverrides_Memory = null;
            if (cmdletContext.ContainerOverrides_Memory != null)
            {
                requestContainerOverrides_containerOverrides_Memory = cmdletContext.ContainerOverrides_Memory.Value;
            }
            if (requestContainerOverrides_containerOverrides_Memory != null)
            {
                request.ContainerOverrides.Memory = requestContainerOverrides_containerOverrides_Memory.Value;
                requestContainerOverridesIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            List<Amazon.Batch.Model.ResourceRequirement> requestContainerOverrides_containerOverrides_ResourceRequirement = null;
            if (cmdletContext.ContainerOverrides_ResourceRequirement != null)
            {
                requestContainerOverrides_containerOverrides_ResourceRequirement = cmdletContext.ContainerOverrides_ResourceRequirement;
            }
            if (requestContainerOverrides_containerOverrides_ResourceRequirement != null)
            {
                request.ContainerOverrides.ResourceRequirements = requestContainerOverrides_containerOverrides_ResourceRequirement;
                requestContainerOverridesIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int32? requestContainerOverrides_containerOverrides_Vcpus = null;
            if (cmdletContext.ContainerOverrides_Vcpus != null)
            {
                requestContainerOverrides_containerOverrides_Vcpus = cmdletContext.ContainerOverrides_Vcpus.Value;
            }
            if (requestContainerOverrides_containerOverrides_Vcpus != null)
            {
                request.ContainerOverrides.Vcpus = requestContainerOverrides_containerOverrides_Vcpus.Value;
                requestContainerOverridesIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.ContainerOverrides should be set to null
            if (requestContainerOverridesIsNull)
            {
                request.ContainerOverrides = null;
            }
            if (cmdletContext.DependsOn != null)
            {
                request.DependsOn = cmdletContext.DependsOn;
            }
            
             // populate EcsPropertiesOverride
            var requestEcsPropertiesOverrideIsNull = true;
            request.EcsPropertiesOverride = new Amazon.Batch.Model.EcsPropertiesOverride();
            List<Amazon.Batch.Model.TaskPropertiesOverride> requestEcsPropertiesOverride_ecsPropertiesOverride_TaskProperty = null;
            if (cmdletContext.EcsPropertiesOverride_TaskProperty != null)
            {
                requestEcsPropertiesOverride_ecsPropertiesOverride_TaskProperty = cmdletContext.EcsPropertiesOverride_TaskProperty;
            }
            if (requestEcsPropertiesOverride_ecsPropertiesOverride_TaskProperty != null)
            {
                request.EcsPropertiesOverride.TaskProperties = requestEcsPropertiesOverride_ecsPropertiesOverride_TaskProperty;
                requestEcsPropertiesOverrideIsNull = false;
            }
             // determine if request.EcsPropertiesOverride should be set to null
            if (requestEcsPropertiesOverrideIsNull)
            {
                request.EcsPropertiesOverride = null;
            }
            
             // populate EksPropertiesOverride
            var requestEksPropertiesOverrideIsNull = true;
            request.EksPropertiesOverride = new Amazon.Batch.Model.EksPropertiesOverride();
            Amazon.Batch.Model.EksPodPropertiesOverride requestEksPropertiesOverride_eksPropertiesOverride_PodProperties = null;
            
             // populate PodProperties
            var requestEksPropertiesOverride_eksPropertiesOverride_PodPropertiesIsNull = true;
            requestEksPropertiesOverride_eksPropertiesOverride_PodProperties = new Amazon.Batch.Model.EksPodPropertiesOverride();
            List<Amazon.Batch.Model.EksContainerOverride> requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_podProperties_Container = null;
            if (cmdletContext.PodProperties_Container != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_podProperties_Container = cmdletContext.PodProperties_Container;
            }
            if (requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_podProperties_Container != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties.Containers = requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_podProperties_Container;
                requestEksPropertiesOverride_eksPropertiesOverride_PodPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.EksContainerOverride> requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_podProperties_InitContainer = null;
            if (cmdletContext.PodProperties_InitContainer != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_podProperties_InitContainer = cmdletContext.PodProperties_InitContainer;
            }
            if (requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_podProperties_InitContainer != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties.InitContainers = requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_podProperties_InitContainer;
                requestEksPropertiesOverride_eksPropertiesOverride_PodPropertiesIsNull = false;
            }
            Amazon.Batch.Model.EksMetadata requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata = null;
            
             // populate Metadata
            var requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_MetadataIsNull = true;
            requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata = new Amazon.Batch.Model.EksMetadata();
            Dictionary<System.String, System.String> requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Annotation = null;
            if (cmdletContext.Metadata_Annotation != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Annotation = cmdletContext.Metadata_Annotation;
            }
            if (requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Annotation != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata.Annotations = requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Annotation;
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_MetadataIsNull = false;
            }
            Dictionary<System.String, System.String> requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Label = null;
            if (cmdletContext.Metadata_Label != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Label = cmdletContext.Metadata_Label;
            }
            if (requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Label != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata.Labels = requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Label;
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_MetadataIsNull = false;
            }
            System.String requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Namespace = null;
            if (cmdletContext.Metadata_Namespace != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Namespace = cmdletContext.Metadata_Namespace;
            }
            if (requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Namespace != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata.Namespace = requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata_metadata_Namespace;
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_MetadataIsNull = false;
            }
             // determine if requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata should be set to null
            if (requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_MetadataIsNull)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata = null;
            }
            if (requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata != null)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties.Metadata = requestEksPropertiesOverride_eksPropertiesOverride_PodProperties_eksPropertiesOverride_PodProperties_Metadata;
                requestEksPropertiesOverride_eksPropertiesOverride_PodPropertiesIsNull = false;
            }
             // determine if requestEksPropertiesOverride_eksPropertiesOverride_PodProperties should be set to null
            if (requestEksPropertiesOverride_eksPropertiesOverride_PodPropertiesIsNull)
            {
                requestEksPropertiesOverride_eksPropertiesOverride_PodProperties = null;
            }
            if (requestEksPropertiesOverride_eksPropertiesOverride_PodProperties != null)
            {
                request.EksPropertiesOverride.PodProperties = requestEksPropertiesOverride_eksPropertiesOverride_PodProperties;
                requestEksPropertiesOverrideIsNull = false;
            }
             // determine if request.EksPropertiesOverride should be set to null
            if (requestEksPropertiesOverrideIsNull)
            {
                request.EksPropertiesOverride = null;
            }
            if (cmdletContext.JobDefinition != null)
            {
                request.JobDefinition = cmdletContext.JobDefinition;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobQueue != null)
            {
                request.JobQueue = cmdletContext.JobQueue;
            }
            
             // populate NodeOverrides
            var requestNodeOverridesIsNull = true;
            request.NodeOverrides = new Amazon.Batch.Model.NodeOverrides();
            List<Amazon.Batch.Model.NodePropertyOverride> requestNodeOverrides_nodeOverrides_NodePropertyOverride = null;
            if (cmdletContext.NodeOverrides_NodePropertyOverride != null)
            {
                requestNodeOverrides_nodeOverrides_NodePropertyOverride = cmdletContext.NodeOverrides_NodePropertyOverride;
            }
            if (requestNodeOverrides_nodeOverrides_NodePropertyOverride != null)
            {
                request.NodeOverrides.NodePropertyOverrides = requestNodeOverrides_nodeOverrides_NodePropertyOverride;
                requestNodeOverridesIsNull = false;
            }
            System.Int32? requestNodeOverrides_nodeOverrides_NumNode = null;
            if (cmdletContext.NodeOverrides_NumNode != null)
            {
                requestNodeOverrides_nodeOverrides_NumNode = cmdletContext.NodeOverrides_NumNode.Value;
            }
            if (requestNodeOverrides_nodeOverrides_NumNode != null)
            {
                request.NodeOverrides.NumNodes = requestNodeOverrides_nodeOverrides_NumNode.Value;
                requestNodeOverridesIsNull = false;
            }
             // determine if request.NodeOverrides should be set to null
            if (requestNodeOverridesIsNull)
            {
                request.NodeOverrides = null;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.PropagateTag != null)
            {
                request.PropagateTags = cmdletContext.PropagateTag.Value;
            }
            
             // populate RetryStrategy
            var requestRetryStrategyIsNull = true;
            request.RetryStrategy = new Amazon.Batch.Model.RetryStrategy();
            System.Int32? requestRetryStrategy_retryStrategy_Attempt = null;
            if (cmdletContext.RetryStrategy_Attempt != null)
            {
                requestRetryStrategy_retryStrategy_Attempt = cmdletContext.RetryStrategy_Attempt.Value;
            }
            if (requestRetryStrategy_retryStrategy_Attempt != null)
            {
                request.RetryStrategy.Attempts = requestRetryStrategy_retryStrategy_Attempt.Value;
                requestRetryStrategyIsNull = false;
            }
            List<Amazon.Batch.Model.EvaluateOnExit> requestRetryStrategy_retryStrategy_EvaluateOnExit = null;
            if (cmdletContext.RetryStrategy_EvaluateOnExit != null)
            {
                requestRetryStrategy_retryStrategy_EvaluateOnExit = cmdletContext.RetryStrategy_EvaluateOnExit;
            }
            if (requestRetryStrategy_retryStrategy_EvaluateOnExit != null)
            {
                request.RetryStrategy.EvaluateOnExit = requestRetryStrategy_retryStrategy_EvaluateOnExit;
                requestRetryStrategyIsNull = false;
            }
             // determine if request.RetryStrategy should be set to null
            if (requestRetryStrategyIsNull)
            {
                request.RetryStrategy = null;
            }
            if (cmdletContext.SchedulingPriorityOverride != null)
            {
                request.SchedulingPriorityOverride = cmdletContext.SchedulingPriorityOverride.Value;
            }
            if (cmdletContext.ShareIdentifier != null)
            {
                request.ShareIdentifier = cmdletContext.ShareIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout;
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
        
        private Amazon.Batch.Model.SubmitJobResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.SubmitJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "SubmitJob");
            try
            {
                return client.SubmitJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ArrayProperties_Size { get; set; }
            public List<Amazon.Batch.Model.ConsumableResourceRequirement> ConsumableResourcePropertiesOverride_ConsumableResourceList { get; set; }
            public List<System.String> ContainerOverrides_Command { get; set; }
            public List<Amazon.Batch.Model.KeyValuePair> ContainerOverrides_Environment { get; set; }
            public System.String ContainerOverrides_InstanceType { get; set; }
            [System.ObsoleteAttribute]
            public System.Int32? ContainerOverrides_Memory { get; set; }
            public List<Amazon.Batch.Model.ResourceRequirement> ContainerOverrides_ResourceRequirement { get; set; }
            [System.ObsoleteAttribute]
            public System.Int32? ContainerOverrides_Vcpus { get; set; }
            public List<Amazon.Batch.Model.JobDependency> DependsOn { get; set; }
            public List<Amazon.Batch.Model.TaskPropertiesOverride> EcsPropertiesOverride_TaskProperty { get; set; }
            public List<Amazon.Batch.Model.EksContainerOverride> PodProperties_Container { get; set; }
            public List<Amazon.Batch.Model.EksContainerOverride> PodProperties_InitContainer { get; set; }
            public Dictionary<System.String, System.String> Metadata_Annotation { get; set; }
            public Dictionary<System.String, System.String> Metadata_Label { get; set; }
            public System.String Metadata_Namespace { get; set; }
            public System.String JobDefinition { get; set; }
            public System.String JobName { get; set; }
            public System.String JobQueue { get; set; }
            public List<Amazon.Batch.Model.NodePropertyOverride> NodeOverrides_NodePropertyOverride { get; set; }
            public System.Int32? NodeOverrides_NumNode { get; set; }
            public Dictionary<System.String, System.String> Parameter { get; set; }
            public System.Boolean? PropagateTag { get; set; }
            public System.Int32? RetryStrategy_Attempt { get; set; }
            public List<Amazon.Batch.Model.EvaluateOnExit> RetryStrategy_EvaluateOnExit { get; set; }
            public System.Int32? SchedulingPriorityOverride { get; set; }
            public System.String ShareIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Batch.Model.JobTimeout Timeout { get; set; }
            public System.Func<Amazon.Batch.Model.SubmitJobResponse, SubmitBATJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
