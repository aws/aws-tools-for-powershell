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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Registers an Batch job definition.
    /// </summary>
    [Cmdlet("Register", "BATJobDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.RegisterJobDefinitionResponse")]
    [AWSCmdlet("Calls the AWS Batch RegisterJobDefinition API operation.", Operation = new[] {"RegisterJobDefinition"}, SelectReturnType = typeof(Amazon.Batch.Model.RegisterJobDefinitionResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.RegisterJobDefinitionResponse",
        "This cmdlet returns an Amazon.Batch.Model.RegisterJobDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterBATJobDefinitionCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        #region Parameter NetworkConfiguration_AssignPublicIp
        /// <summary>
        /// <para>
        /// <para>Indicates whether the job has a public IP address. For a job that's running on Fargate
        /// resources in a private subnet to send outbound traffic to the internet (for example,
        /// to pull container images), the private subnet requires a NAT gateway be attached to
        /// route requests to the internet. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-networking.html">Amazon
        /// ECS task networking</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
        /// The default value is "<code>DISABLED</code>".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_NetworkConfiguration_AssignPublicIp")]
        [AWSConstantClassSource("Amazon.Batch.AssignPublicIp")]
        public Amazon.Batch.AssignPublicIp NetworkConfiguration_AssignPublicIp { get; set; }
        #endregion
        
        #region Parameter RetryStrategy_Attempt
        /// <summary>
        /// <para>
        /// <para>The number of times to move a job to the <code>RUNNABLE</code> status. You can specify
        /// between 1 and 10 attempts. If the value of <code>attempts</code> is greater than one,
        /// the job is retried on failure the same number of attempts as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryStrategy_Attempts")]
        public System.Int32? RetryStrategy_Attempt { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Command
        /// <summary>
        /// <para>
        /// <para>The command that's passed to the container. This parameter maps to <code>Cmd</code>
        /// in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>COMMAND</code> parameter to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>. For more information, see <a href="https://docs.docker.com/engine/reference/builder/#cmd">https://docs.docker.com/engine/reference/builder/#cmd</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ContainerProperties_Command { get; set; }
        #endregion
        
        #region Parameter PodProperties_Container
        /// <summary>
        /// <para>
        /// <para>The properties of the container that's used on the Amazon EKS pod.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksProperties_PodProperties_Containers")]
        public Amazon.Batch.Model.EksContainer[] PodProperties_Container { get; set; }
        #endregion
        
        #region Parameter LinuxParameters_Device
        /// <summary>
        /// <para>
        /// <para>Any of the host devices to expose to the container. This parameter maps to <code>Devices</code>
        /// in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>--device</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// provide it for these jobs.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_LinuxParameters_Devices")]
        public Amazon.Batch.Model.Device[] LinuxParameters_Device { get; set; }
        #endregion
        
        #region Parameter PodProperties_DnsPolicy
        /// <summary>
        /// <para>
        /// <para>The DNS policy for the pod. The default value is <code>ClusterFirst</code>. If the
        /// <code>hostNetwork</code> parameter is not specified, the default is <code>ClusterFirstWithHostNet</code>.
        /// <code>ClusterFirst</code> indicates that any DNS query that does not match the configured
        /// cluster domain suffix is forwarded to the upstream nameserver inherited from the node.
        /// For more information, see <a href="https://kubernetes.io/docs/concepts/services-networking/dns-pod-service/#pod-s-dns-policy">Pod's
        /// DNS policy</a> in the <i>Kubernetes documentation</i>.</para><para>Valid values: <code>Default</code> | <code>ClusterFirst</code> | <code>ClusterFirstWithHostNet</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksProperties_PodProperties_DnsPolicy")]
        public System.String PodProperties_DnsPolicy { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to pass to a container. This parameter maps to <code>Env</code>
        /// in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>--env</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para><important><para>We don't recommend using plaintext environment variables for sensitive information,
        /// such as credential data.</para></important><note><para>Environment variables cannot start with "<code>AWS_BATCH</code>". This naming convention
        /// is reserved for variables that Batch sets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.KeyValuePair[] ContainerProperties_Environment { get; set; }
        #endregion
        
        #region Parameter RetryStrategy_EvaluateOnExit
        /// <summary>
        /// <para>
        /// <para>Array of up to 5 objects that specify the conditions where jobs are retried or failed.
        /// If this parameter is specified, then the <code>attempts</code> parameter must also
        /// be specified. If none of the listed conditions match, then the job is retried.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.EvaluateOnExit[] RetryStrategy_EvaluateOnExit { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the execution role that Batch can assume. For jobs
        /// that run on Fargate resources, you must provide an execution role. For more information,
        /// see <a href="https://docs.aws.amazon.com/batch/latest/userguide/execution-IAM-role.html">Batch
        /// execution IAM role</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerProperties_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter PodProperties_HostNetwork
        /// <summary>
        /// <para>
        /// <para>Indicates if the pod uses the hosts' network IP address. The default value is <code>true</code>.
        /// Setting this to <code>false</code> enables the Kubernetes pod networking model. Most
        /// Batch workloads are egress-only and don't require the overhead of IP allocation for
        /// each pod for incoming connections. For more information, see <a href="https://kubernetes.io/docs/concepts/security/pod-security-policy/#host-namespaces">Host
        /// namespaces</a> and <a href="https://kubernetes.io/docs/concepts/workloads/pods/#pod-networking">Pod
        /// networking</a> in the <i>Kubernetes documentation</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksProperties_PodProperties_HostNetwork")]
        public System.Boolean? PodProperties_HostNetwork { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Image
        /// <summary>
        /// <para>
        /// <para>The image used to start a container. This string is passed directly to the Docker
        /// daemon. Images in the Docker Hub registry are available by default. Other repositories
        /// are specified with <code><i>repository-url</i>/<i>image</i>:<i>tag</i></code>. It
        /// can be 255 characters long. It can contain uppercase and lowercase letters, numbers,
        /// hyphens (-), underscores (_), colons (:), periods (.), forward slashes (/), and number
        /// signs (#). This parameter maps to <code>Image</code> in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>IMAGE</code> parameter of <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para><note><para>Docker image architecture must match the processor architecture of the compute resources
        /// that they're scheduled on. For example, ARM-based Docker images can only run on ARM-based
        /// compute resources.</para></note><ul><li><para>Images in Amazon ECR Public repositories use the full <code>registry/repository[:tag]</code>
        /// or <code>registry/repository[@digest]</code> naming conventions. For example, <code>public.ecr.aws/<i>registry_alias</i>/<i>my-web-app</i>:<i>latest</i></code>.</para></li><li><para>Images in Amazon ECR repositories use the full registry and repository URI (for example,
        /// <code>123456789012.dkr.ecr.&lt;region-name&gt;.amazonaws.com/&lt;repository-name&gt;</code>).</para></li><li><para>Images in official repositories on Docker Hub use a single name (for example, <code>ubuntu</code>
        /// or <code>mongo</code>).</para></li><li><para>Images in other repositories on Docker Hub are qualified with an organization name
        /// (for example, <code>amazon/amazon-ecs-agent</code>).</para></li><li><para>Images in other online repositories are qualified further by a domain name (for example,
        /// <code>quay.io/assemblyline/ubuntu</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerProperties_Image { get; set; }
        #endregion
        
        #region Parameter LinuxParameters_InitProcessEnabled
        /// <summary>
        /// <para>
        /// <para>If true, run an <code>init</code> process inside the container that forwards signals
        /// and reaps processes. This parameter maps to the <code>--init</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>. This parameter requires version 1.25 of the Docker Remote API or greater
        /// on your container instance. To check the Docker Remote API version on your container
        /// instance, log in to your container instance and run the following command: <code>sudo
        /// docker version | grep "Server API version"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_LinuxParameters_InitProcessEnabled")]
        public System.Boolean? LinuxParameters_InitProcessEnabled { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use for a multi-node parallel job. All node groups in a multi-node
        /// parallel job must use the same instance type.</para><note><para>This parameter isn't applicable to single-node container jobs or jobs that run on
        /// Fargate resources, and shouldn't be provided.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerProperties_InstanceType { get; set; }
        #endregion
        
        #region Parameter JobDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name of the job definition to register. It can be up to 128 letters long. It can
        /// contain uppercase and lowercase letters, numbers, hyphens (-), and underscores (_).</para>
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
        public System.String JobDefinitionName { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_JobRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the container can assume for Amazon
        /// Web Services permissions. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-iam-roles.html">IAM
        /// roles for tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerProperties_JobRoleArn { get; set; }
        #endregion
        
        #region Parameter Metadata_Label
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksProperties_PodProperties_Metadata_Labels")]
        public System.Collections.Hashtable Metadata_Label { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_LogDriver
        /// <summary>
        /// <para>
        /// <para>The log driver to use for the container. The valid values that are listed for this
        /// parameter are log drivers that the Amazon ECS container agent can communicate with
        /// by default.</para><para>The supported log drivers are <code>awslogs</code>, <code>fluentd</code>, <code>gelf</code>,
        /// <code>json-file</code>, <code>journald</code>, <code>logentries</code>, <code>syslog</code>,
        /// and <code>splunk</code>.</para><note><para>Jobs that are running on Fargate resources are restricted to the <code>awslogs</code>
        /// and <code>splunk</code> log drivers.</para></note><dl><dt>awslogs</dt><dd><para>Specifies the Amazon CloudWatch Logs logging driver. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/using_awslogs.html">Using
        /// the awslogs log driver</a> in the <i>Batch User Guide</i> and <a href="https://docs.docker.com/config/containers/logging/awslogs/">Amazon
        /// CloudWatch Logs logging driver</a> in the Docker documentation.</para></dd><dt>fluentd</dt><dd><para>Specifies the Fluentd logging driver. For more information including usage and options,
        /// see <a href="https://docs.docker.com/config/containers/logging/fluentd/">Fluentd logging
        /// driver</a> in the <i>Docker documentation</i>.</para></dd><dt>gelf</dt><dd><para>Specifies the Graylog Extended Format (GELF) logging driver. For more information
        /// including usage and options, see <a href="https://docs.docker.com/config/containers/logging/gelf/">Graylog
        /// Extended Format logging driver</a> in the <i>Docker documentation</i>.</para></dd><dt>journald</dt><dd><para>Specifies the journald logging driver. For more information including usage and options,
        /// see <a href="https://docs.docker.com/config/containers/logging/journald/">Journald
        /// logging driver</a> in the <i>Docker documentation</i>.</para></dd><dt>json-file</dt><dd><para>Specifies the JSON file logging driver. For more information including usage and options,
        /// see <a href="https://docs.docker.com/config/containers/logging/json-file/">JSON File
        /// logging driver</a> in the <i>Docker documentation</i>.</para></dd><dt>splunk</dt><dd><para>Specifies the Splunk logging driver. For more information including usage and options,
        /// see <a href="https://docs.docker.com/config/containers/logging/splunk/">Splunk logging
        /// driver</a> in the <i>Docker documentation</i>.</para></dd><dt>syslog</dt><dd><para>Specifies the syslog logging driver. For more information including usage and options,
        /// see <a href="https://docs.docker.com/config/containers/logging/syslog/">Syslog logging
        /// driver</a> in the <i>Docker documentation</i>.</para></dd></dl><note><para>If you have a custom driver that's not listed earlier that you want to work with the
        /// Amazon ECS container agent, you can fork the Amazon ECS container agent project that's
        /// <a href="https://github.com/aws/amazon-ecs-agent">available on GitHub</a> and customize
        /// it to work with that driver. We encourage you to submit pull requests for changes
        /// that you want to have included. However, Amazon Web Services doesn't currently support
        /// running modified copies of this software.</para></note><para>This parameter requires version 1.18 of the Docker Remote API or greater on your container
        /// instance. To check the Docker Remote API version on your container instance, log in
        /// to your container instance and run the following command: <code>sudo docker version
        /// | grep "Server API version"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_LogConfiguration_LogDriver")]
        [AWSConstantClassSource("Amazon.Batch.LogDriver")]
        public Amazon.Batch.LogDriver LogConfiguration_LogDriver { get; set; }
        #endregion
        
        #region Parameter NodeProperties_MainNode
        /// <summary>
        /// <para>
        /// <para>Specifies the node index for the main node of a multi-node parallel job. This node
        /// index value must be fewer than the number of nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NodeProperties_MainNode { get; set; }
        #endregion
        
        #region Parameter LinuxParameters_MaxSwap
        /// <summary>
        /// <para>
        /// <para>The total amount of swap memory (in MiB) a container can use. This parameter is translated
        /// to the <code>--memory-swap</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a> where the value is the sum of the container memory plus the <code>maxSwap</code>
        /// value. For more information, see <a href="https://docs.docker.com/config/containers/resource_constraints/#--memory-swap-details"><code>--memory-swap</code> details</a> in the Docker documentation.</para><para>If a <code>maxSwap</code> value of <code>0</code> is specified, the container doesn't
        /// use swap. Accepted values are <code>0</code> or any positive integer. If the <code>maxSwap</code>
        /// parameter is omitted, the container doesn't use the swap configuration for the container
        /// instance that it's running on. A <code>maxSwap</code> value must be set for the <code>swappiness</code>
        /// parameter to be used.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// provide it for these jobs.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_LinuxParameters_MaxSwap")]
        public System.Int32? LinuxParameters_MaxSwap { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_MountPoint
        /// <summary>
        /// <para>
        /// <para>The mount points for data volumes in your container. This parameter maps to <code>Volumes</code>
        /// in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>--volume</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_MountPoints")]
        public Amazon.Batch.Model.MountPoint[] ContainerProperties_MountPoint { get; set; }
        #endregion
        
        #region Parameter NodeProperties_NodeRangeProperty
        /// <summary>
        /// <para>
        /// <para>A list of node ranges and their properties that are associated with a multi-node parallel
        /// job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeProperties_NodeRangeProperties")]
        public Amazon.Batch.Model.NodeRangeProperty[] NodeProperties_NodeRangeProperty { get; set; }
        #endregion
        
        #region Parameter NodeProperties_NumNode
        /// <summary>
        /// <para>
        /// <para>The number of nodes that are associated with a multi-node parallel job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeProperties_NumNodes")]
        public System.Int32? NodeProperties_NumNode { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_Option
        /// <summary>
        /// <para>
        /// <para>The configuration options to send to the log driver. This parameter requires version
        /// 1.19 of the Docker Remote API or greater on your container instance. To check the
        /// Docker Remote API version on your container instance, log in to your container instance
        /// and run the following command: <code>sudo docker version | grep "Server API version"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_LogConfiguration_Options")]
        public System.Collections.Hashtable LogConfiguration_Option { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>Default parameter substitution placeholders to set in the job definition. Parameters
        /// are specified as a key-value pair mapping. Parameters in a <code>SubmitJob</code>
        /// request override any corresponding parameter defaults from the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter PlatformCapability
        /// <summary>
        /// <para>
        /// <para>The platform capabilities required by the job definition. If no value is specified,
        /// it defaults to <code>EC2</code>. To run the job on Fargate resources, specify <code>FARGATE</code>.</para><note><para>If the job runs on Amazon EKS resources, then you must not specify <code>platformCapabilities</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlatformCapabilities")]
        public System.String[] PlatformCapability { get; set; }
        #endregion
        
        #region Parameter FargatePlatformConfiguration_PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The Fargate platform version where the jobs are running. A platform version is specified
        /// only for jobs that are running on Fargate resources. If one isn't specified, the <code>LATEST</code>
        /// platform version is used by default. This uses a recent, approved version of the Fargate
        /// platform for compute resources. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/platform_versions.html">Fargate
        /// platform versions</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_FargatePlatformConfiguration_PlatformVersion")]
        public System.String FargatePlatformConfiguration_PlatformVersion { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Privileged
        /// <summary>
        /// <para>
        /// <para>When this parameter is true, the container is given elevated permissions on the host
        /// container instance (similar to the <code>root</code> user). This parameter maps to
        /// <code>Privileged</code> in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>--privileged</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>. The default value is false.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources and
        /// shouldn't be provided, or specified as false.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ContainerProperties_Privileged { get; set; }
        #endregion
        
        #region Parameter PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the job or job definition to the corresponding
        /// Amazon ECS task. If no value is specified, the tags are not propagated. Tags can only
        /// be propagated to the tasks during task creation. For tags with the same name, job
        /// tags are given priority over job definitions tags. If the total number of combined
        /// tags from the job and job definition is over 50, the job is moved to the <code>FAILED</code>
        /// state.</para><note><para>If the job runs on Amazon EKS resources, then you must not specify <code>propagateTags</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagateTags")]
        public System.Boolean? PropagateTag { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_ReadonlyRootFilesystem
        /// <summary>
        /// <para>
        /// <para>When this parameter is true, the container is given read-only access to its root file
        /// system. This parameter maps to <code>ReadonlyRootfs</code> in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>--read-only</code> option to <code>docker run</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ContainerProperties_ReadonlyRootFilesystem { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_ResourceRequirement
        /// <summary>
        /// <para>
        /// <para>The type and amount of resources to assign to a container. The supported resources
        /// include <code>GPU</code>, <code>MEMORY</code>, and <code>VCPU</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_ResourceRequirements")]
        public Amazon.Batch.Model.ResourceRequirement[] ContainerProperties_ResourceRequirement { get; set; }
        #endregion
        
        #region Parameter SchedulingPriority
        /// <summary>
        /// <para>
        /// <para>The scheduling priority for jobs that are submitted with this job definition. This
        /// only affects jobs in job queues with a fair share policy. Jobs with a higher scheduling
        /// priority are scheduled before jobs with a lower scheduling priority.</para><para>The minimum supported value is 0 and the maximum supported value is 9999.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SchedulingPriority { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_SecretOption
        /// <summary>
        /// <para>
        /// <para>The secrets to pass to the log configuration. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/specifying-sensitive-data.html">Specifying
        /// sensitive data</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_LogConfiguration_SecretOptions")]
        public Amazon.Batch.Model.Secret[] LogConfiguration_SecretOption { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Secret
        /// <summary>
        /// <para>
        /// <para>The secrets for the container. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/specifying-sensitive-data.html">Specifying
        /// sensitive data</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_Secrets")]
        public Amazon.Batch.Model.Secret[] ContainerProperties_Secret { get; set; }
        #endregion
        
        #region Parameter PodProperties_ServiceAccountName
        /// <summary>
        /// <para>
        /// <para>The name of the service account that's used to run the pod. For more information,
        /// see <a href="https://docs.aws.amazon.com/eks/latest/userguide/service-accounts.html">Kubernetes
        /// service accounts</a> and <a href="https://docs.aws.amazon.com/eks/latest/userguide/associate-service-account-role.html">Configure
        /// a Kubernetes service account to assume an IAM role</a> in the <i>Amazon EKS User Guide</i>
        /// and <a href="https://kubernetes.io/docs/tasks/configure-pod-container/configure-service-account/">Configure
        /// service accounts for pods</a> in the <i>Kubernetes documentation</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksProperties_PodProperties_ServiceAccountName")]
        public System.String PodProperties_ServiceAccountName { get; set; }
        #endregion
        
        #region Parameter LinuxParameters_SharedMemorySize
        /// <summary>
        /// <para>
        /// <para>The value for the size (in MiB) of the <code>/dev/shm</code> volume. This parameter
        /// maps to the <code>--shm-size</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// provide it for these jobs.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_LinuxParameters_SharedMemorySize")]
        public System.Int32? LinuxParameters_SharedMemorySize { get; set; }
        #endregion
        
        #region Parameter EphemeralStorage_SizeInGiB
        /// <summary>
        /// <para>
        /// <para>The total amount, in GiB, of ephemeral storage to set for the task. The minimum supported
        /// value is <code>21</code> GiB and the maximum supported value is <code>200</code> GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_EphemeralStorage_SizeInGiB")]
        public System.Int32? EphemeralStorage_SizeInGiB { get; set; }
        #endregion
        
        #region Parameter LinuxParameters_Swappiness
        /// <summary>
        /// <para>
        /// <para>You can use this parameter to tune a container's memory swappiness behavior. A <code>swappiness</code>
        /// value of <code>0</code> causes swapping to not occur unless absolutely necessary.
        /// A <code>swappiness</code> value of <code>100</code> causes pages to be swapped aggressively.
        /// Valid values are whole numbers between <code>0</code> and <code>100</code>. If the
        /// <code>swappiness</code> parameter isn't specified, a default value of <code>60</code>
        /// is used. If a value isn't specified for <code>maxSwap</code>, then this parameter
        /// is ignored. If <code>maxSwap</code> is set to 0, the container doesn't use swap. This
        /// parameter maps to the <code>--memory-swappiness</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para><para>Consider the following when you use a per-container swap configuration.</para><ul><li><para>Swap space must be enabled and allocated on the container instance for the containers
        /// to use.</para><note><para>By default, the Amazon ECS optimized AMIs don't have swap enabled. You must enable
        /// swap on the instance to use this feature. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-store-swap-volumes.html">Instance
        /// store swap volumes</a> in the <i>Amazon EC2 User Guide for Linux Instances</i> or
        /// <a href="http://aws.amazon.com/premiumsupport/knowledge-center/ec2-memory-swap-file/">How
        /// do I allocate memory to work as swap space in an Amazon EC2 instance by using a swap
        /// file?</a></para></note></li><li><para>The swap space parameters are only supported for job definitions using EC2 resources.</para></li><li><para>If the <code>maxSwap</code> and <code>swappiness</code> parameters are omitted from
        /// a job definition, each container has a default <code>swappiness</code> value of 60.
        /// Moreover, the total swap usage is limited to two times the memory reservation of the
        /// container.</para></li></ul><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// provide it for these jobs.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_LinuxParameters_Swappiness")]
        public System.Int32? LinuxParameters_Swappiness { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you apply to the job definition to help you categorize and organize
        /// your resources. Each tag consists of a key and an optional value. For more information,
        /// see <a href="https://docs.aws.amazon.com/batch/latest/userguide/using-tags.html">Tagging
        /// Amazon Web Services Resources</a> in <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The timeout configuration for jobs that are submitted with this job definition, after
        /// which Batch terminates your jobs if they have not finished. If a job is terminated
        /// due to a timeout, it isn't retried. The minimum value for the timeout is 60 seconds.
        /// Any timeout configuration that's specified during a <a>SubmitJob</a> operation overrides
        /// the timeout configuration defined here. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/job_timeouts.html">Job
        /// Timeouts</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.JobTimeout Timeout { get; set; }
        #endregion
        
        #region Parameter LinuxParameters_Tmpf
        /// <summary>
        /// <para>
        /// <para>The container path, mount options, and size (in MiB) of the <code>tmpfs</code> mount.
        /// This parameter maps to the <code>--tmpfs</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// provide this parameter for this resource type.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_LinuxParameters_Tmpfs")]
        public Amazon.Batch.Model.Tmpfs[] LinuxParameters_Tmpf { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of job definition. For more information about multi-node parallel jobs, see
        /// <a href="https://docs.aws.amazon.com/batch/latest/userguide/multi-node-job-def.html">Creating
        /// a multi-node parallel job definition</a> in the <i>Batch User Guide</i>.</para><note><para>If the job is run on Fargate resources, then <code>multinode</code> isn't supported.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Batch.JobDefinitionType")]
        public Amazon.Batch.JobDefinitionType Type { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Ulimit
        /// <summary>
        /// <para>
        /// <para>A list of <code>ulimits</code> to set in the container. This parameter maps to <code>Ulimits</code>
        /// in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>--ulimit</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources and
        /// shouldn't be provided.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_Ulimits")]
        public Amazon.Batch.Model.Ulimit[] ContainerProperties_Ulimit { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_User
        /// <summary>
        /// <para>
        /// <para>The user name to use inside the container. This parameter maps to <code>User</code>
        /// in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>--user</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerProperties_User { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Volume
        /// <summary>
        /// <para>
        /// <para>A list of data volumes used in a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProperties_Volumes")]
        public Amazon.Batch.Model.Volume[] ContainerProperties_Volume { get; set; }
        #endregion
        
        #region Parameter PodProperties_Volume
        /// <summary>
        /// <para>
        /// <para>Specifies the volumes for a job definition that uses Amazon EKS resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksProperties_PodProperties_Volumes")]
        public Amazon.Batch.Model.EksVolume[] PodProperties_Volume { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Memory
        /// <summary>
        /// <para>
        /// <para>This parameter is deprecated, use <code>resourceRequirements</code> to specify the
        /// memory requirements for the job definition. It's not supported for jobs running on
        /// Fargate resources. For jobs that run on EC2 resources, it specifies the memory hard
        /// limit (in MiB) for a container. If your container attempts to exceed the specified
        /// number, it's terminated. You must specify at least 4 MiB of memory for a job using
        /// this parameter. The memory hard limit can be specified in several places. It must
        /// be specified for each node at least once.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated, use resourceRequirements instead.")]
        public System.Int32? ContainerProperties_Memory { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Vcpus
        /// <summary>
        /// <para>
        /// <para>This parameter is deprecated, use <code>resourceRequirements</code> to specify the
        /// vCPU requirements for the job definition. It's not supported for jobs running on Fargate
        /// resources. For jobs running on EC2 resources, it specifies the number of vCPUs reserved
        /// for the job.</para><para>Each vCPU is equivalent to 1,024 CPU shares. This parameter maps to <code>CpuShares</code>
        /// in the <a href="https://docs.docker.com/engine/api/v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/api/v1.23/">Docker
        /// Remote API</a> and the <code>--cpu-shares</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>. The number of vCPUs must be specified but can be specified in several places.
        /// You must specify it at least once for each node.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated, use resourceRequirements instead.")]
        public System.Int32? ContainerProperties_Vcpus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.RegisterJobDefinitionResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.RegisterJobDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobDefinitionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobDefinitionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobDefinitionName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobDefinitionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-BATJobDefinition (RegisterJobDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.RegisterJobDefinitionResponse, RegisterBATJobDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobDefinitionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ContainerProperties_Command != null)
            {
                context.ContainerProperties_Command = new List<System.String>(this.ContainerProperties_Command);
            }
            if (this.ContainerProperties_Environment != null)
            {
                context.ContainerProperties_Environment = new List<Amazon.Batch.Model.KeyValuePair>(this.ContainerProperties_Environment);
            }
            context.EphemeralStorage_SizeInGiB = this.EphemeralStorage_SizeInGiB;
            context.ContainerProperties_ExecutionRoleArn = this.ContainerProperties_ExecutionRoleArn;
            context.FargatePlatformConfiguration_PlatformVersion = this.FargatePlatformConfiguration_PlatformVersion;
            context.ContainerProperties_Image = this.ContainerProperties_Image;
            context.ContainerProperties_InstanceType = this.ContainerProperties_InstanceType;
            context.ContainerProperties_JobRoleArn = this.ContainerProperties_JobRoleArn;
            if (this.LinuxParameters_Device != null)
            {
                context.LinuxParameters_Device = new List<Amazon.Batch.Model.Device>(this.LinuxParameters_Device);
            }
            context.LinuxParameters_InitProcessEnabled = this.LinuxParameters_InitProcessEnabled;
            context.LinuxParameters_MaxSwap = this.LinuxParameters_MaxSwap;
            context.LinuxParameters_SharedMemorySize = this.LinuxParameters_SharedMemorySize;
            context.LinuxParameters_Swappiness = this.LinuxParameters_Swappiness;
            if (this.LinuxParameters_Tmpf != null)
            {
                context.LinuxParameters_Tmpf = new List<Amazon.Batch.Model.Tmpfs>(this.LinuxParameters_Tmpf);
            }
            context.LogConfiguration_LogDriver = this.LogConfiguration_LogDriver;
            if (this.LogConfiguration_Option != null)
            {
                context.LogConfiguration_Option = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.LogConfiguration_Option.Keys)
                {
                    context.LogConfiguration_Option.Add((String)hashKey, (String)(this.LogConfiguration_Option[hashKey]));
                }
            }
            if (this.LogConfiguration_SecretOption != null)
            {
                context.LogConfiguration_SecretOption = new List<Amazon.Batch.Model.Secret>(this.LogConfiguration_SecretOption);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContainerProperties_Memory = this.ContainerProperties_Memory;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ContainerProperties_MountPoint != null)
            {
                context.ContainerProperties_MountPoint = new List<Amazon.Batch.Model.MountPoint>(this.ContainerProperties_MountPoint);
            }
            context.NetworkConfiguration_AssignPublicIp = this.NetworkConfiguration_AssignPublicIp;
            context.ContainerProperties_Privileged = this.ContainerProperties_Privileged;
            context.ContainerProperties_ReadonlyRootFilesystem = this.ContainerProperties_ReadonlyRootFilesystem;
            if (this.ContainerProperties_ResourceRequirement != null)
            {
                context.ContainerProperties_ResourceRequirement = new List<Amazon.Batch.Model.ResourceRequirement>(this.ContainerProperties_ResourceRequirement);
            }
            if (this.ContainerProperties_Secret != null)
            {
                context.ContainerProperties_Secret = new List<Amazon.Batch.Model.Secret>(this.ContainerProperties_Secret);
            }
            if (this.ContainerProperties_Ulimit != null)
            {
                context.ContainerProperties_Ulimit = new List<Amazon.Batch.Model.Ulimit>(this.ContainerProperties_Ulimit);
            }
            context.ContainerProperties_User = this.ContainerProperties_User;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContainerProperties_Vcpus = this.ContainerProperties_Vcpus;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ContainerProperties_Volume != null)
            {
                context.ContainerProperties_Volume = new List<Amazon.Batch.Model.Volume>(this.ContainerProperties_Volume);
            }
            if (this.PodProperties_Container != null)
            {
                context.PodProperties_Container = new List<Amazon.Batch.Model.EksContainer>(this.PodProperties_Container);
            }
            context.PodProperties_DnsPolicy = this.PodProperties_DnsPolicy;
            context.PodProperties_HostNetwork = this.PodProperties_HostNetwork;
            if (this.Metadata_Label != null)
            {
                context.Metadata_Label = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata_Label.Keys)
                {
                    context.Metadata_Label.Add((String)hashKey, (String)(this.Metadata_Label[hashKey]));
                }
            }
            context.PodProperties_ServiceAccountName = this.PodProperties_ServiceAccountName;
            if (this.PodProperties_Volume != null)
            {
                context.PodProperties_Volume = new List<Amazon.Batch.Model.EksVolume>(this.PodProperties_Volume);
            }
            context.JobDefinitionName = this.JobDefinitionName;
            #if MODULAR
            if (this.JobDefinitionName == null && ParameterWasBound(nameof(this.JobDefinitionName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobDefinitionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NodeProperties_MainNode = this.NodeProperties_MainNode;
            if (this.NodeProperties_NodeRangeProperty != null)
            {
                context.NodeProperties_NodeRangeProperty = new List<Amazon.Batch.Model.NodeRangeProperty>(this.NodeProperties_NodeRangeProperty);
            }
            context.NodeProperties_NumNode = this.NodeProperties_NumNode;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (String)(this.Parameter[hashKey]));
                }
            }
            if (this.PlatformCapability != null)
            {
                context.PlatformCapability = new List<System.String>(this.PlatformCapability);
            }
            context.PropagateTag = this.PropagateTag;
            context.RetryStrategy_Attempt = this.RetryStrategy_Attempt;
            if (this.RetryStrategy_EvaluateOnExit != null)
            {
                context.RetryStrategy_EvaluateOnExit = new List<Amazon.Batch.Model.EvaluateOnExit>(this.RetryStrategy_EvaluateOnExit);
            }
            context.SchedulingPriority = this.SchedulingPriority;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.Timeout = this.Timeout;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.Batch.Model.RegisterJobDefinitionRequest();
            
            
             // populate ContainerProperties
            var requestContainerPropertiesIsNull = true;
            request.ContainerProperties = new Amazon.Batch.Model.ContainerProperties();
            List<System.String> requestContainerProperties_containerProperties_Command = null;
            if (cmdletContext.ContainerProperties_Command != null)
            {
                requestContainerProperties_containerProperties_Command = cmdletContext.ContainerProperties_Command;
            }
            if (requestContainerProperties_containerProperties_Command != null)
            {
                request.ContainerProperties.Command = requestContainerProperties_containerProperties_Command;
                requestContainerPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.KeyValuePair> requestContainerProperties_containerProperties_Environment = null;
            if (cmdletContext.ContainerProperties_Environment != null)
            {
                requestContainerProperties_containerProperties_Environment = cmdletContext.ContainerProperties_Environment;
            }
            if (requestContainerProperties_containerProperties_Environment != null)
            {
                request.ContainerProperties.Environment = requestContainerProperties_containerProperties_Environment;
                requestContainerPropertiesIsNull = false;
            }
            System.String requestContainerProperties_containerProperties_ExecutionRoleArn = null;
            if (cmdletContext.ContainerProperties_ExecutionRoleArn != null)
            {
                requestContainerProperties_containerProperties_ExecutionRoleArn = cmdletContext.ContainerProperties_ExecutionRoleArn;
            }
            if (requestContainerProperties_containerProperties_ExecutionRoleArn != null)
            {
                request.ContainerProperties.ExecutionRoleArn = requestContainerProperties_containerProperties_ExecutionRoleArn;
                requestContainerPropertiesIsNull = false;
            }
            System.String requestContainerProperties_containerProperties_Image = null;
            if (cmdletContext.ContainerProperties_Image != null)
            {
                requestContainerProperties_containerProperties_Image = cmdletContext.ContainerProperties_Image;
            }
            if (requestContainerProperties_containerProperties_Image != null)
            {
                request.ContainerProperties.Image = requestContainerProperties_containerProperties_Image;
                requestContainerPropertiesIsNull = false;
            }
            System.String requestContainerProperties_containerProperties_InstanceType = null;
            if (cmdletContext.ContainerProperties_InstanceType != null)
            {
                requestContainerProperties_containerProperties_InstanceType = cmdletContext.ContainerProperties_InstanceType;
            }
            if (requestContainerProperties_containerProperties_InstanceType != null)
            {
                request.ContainerProperties.InstanceType = requestContainerProperties_containerProperties_InstanceType;
                requestContainerPropertiesIsNull = false;
            }
            System.String requestContainerProperties_containerProperties_JobRoleArn = null;
            if (cmdletContext.ContainerProperties_JobRoleArn != null)
            {
                requestContainerProperties_containerProperties_JobRoleArn = cmdletContext.ContainerProperties_JobRoleArn;
            }
            if (requestContainerProperties_containerProperties_JobRoleArn != null)
            {
                request.ContainerProperties.JobRoleArn = requestContainerProperties_containerProperties_JobRoleArn;
                requestContainerPropertiesIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int32? requestContainerProperties_containerProperties_Memory = null;
            if (cmdletContext.ContainerProperties_Memory != null)
            {
                requestContainerProperties_containerProperties_Memory = cmdletContext.ContainerProperties_Memory.Value;
            }
            if (requestContainerProperties_containerProperties_Memory != null)
            {
                request.ContainerProperties.Memory = requestContainerProperties_containerProperties_Memory.Value;
                requestContainerPropertiesIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            List<Amazon.Batch.Model.MountPoint> requestContainerProperties_containerProperties_MountPoint = null;
            if (cmdletContext.ContainerProperties_MountPoint != null)
            {
                requestContainerProperties_containerProperties_MountPoint = cmdletContext.ContainerProperties_MountPoint;
            }
            if (requestContainerProperties_containerProperties_MountPoint != null)
            {
                request.ContainerProperties.MountPoints = requestContainerProperties_containerProperties_MountPoint;
                requestContainerPropertiesIsNull = false;
            }
            System.Boolean? requestContainerProperties_containerProperties_Privileged = null;
            if (cmdletContext.ContainerProperties_Privileged != null)
            {
                requestContainerProperties_containerProperties_Privileged = cmdletContext.ContainerProperties_Privileged.Value;
            }
            if (requestContainerProperties_containerProperties_Privileged != null)
            {
                request.ContainerProperties.Privileged = requestContainerProperties_containerProperties_Privileged.Value;
                requestContainerPropertiesIsNull = false;
            }
            System.Boolean? requestContainerProperties_containerProperties_ReadonlyRootFilesystem = null;
            if (cmdletContext.ContainerProperties_ReadonlyRootFilesystem != null)
            {
                requestContainerProperties_containerProperties_ReadonlyRootFilesystem = cmdletContext.ContainerProperties_ReadonlyRootFilesystem.Value;
            }
            if (requestContainerProperties_containerProperties_ReadonlyRootFilesystem != null)
            {
                request.ContainerProperties.ReadonlyRootFilesystem = requestContainerProperties_containerProperties_ReadonlyRootFilesystem.Value;
                requestContainerPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.ResourceRequirement> requestContainerProperties_containerProperties_ResourceRequirement = null;
            if (cmdletContext.ContainerProperties_ResourceRequirement != null)
            {
                requestContainerProperties_containerProperties_ResourceRequirement = cmdletContext.ContainerProperties_ResourceRequirement;
            }
            if (requestContainerProperties_containerProperties_ResourceRequirement != null)
            {
                request.ContainerProperties.ResourceRequirements = requestContainerProperties_containerProperties_ResourceRequirement;
                requestContainerPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.Secret> requestContainerProperties_containerProperties_Secret = null;
            if (cmdletContext.ContainerProperties_Secret != null)
            {
                requestContainerProperties_containerProperties_Secret = cmdletContext.ContainerProperties_Secret;
            }
            if (requestContainerProperties_containerProperties_Secret != null)
            {
                request.ContainerProperties.Secrets = requestContainerProperties_containerProperties_Secret;
                requestContainerPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.Ulimit> requestContainerProperties_containerProperties_Ulimit = null;
            if (cmdletContext.ContainerProperties_Ulimit != null)
            {
                requestContainerProperties_containerProperties_Ulimit = cmdletContext.ContainerProperties_Ulimit;
            }
            if (requestContainerProperties_containerProperties_Ulimit != null)
            {
                request.ContainerProperties.Ulimits = requestContainerProperties_containerProperties_Ulimit;
                requestContainerPropertiesIsNull = false;
            }
            System.String requestContainerProperties_containerProperties_User = null;
            if (cmdletContext.ContainerProperties_User != null)
            {
                requestContainerProperties_containerProperties_User = cmdletContext.ContainerProperties_User;
            }
            if (requestContainerProperties_containerProperties_User != null)
            {
                request.ContainerProperties.User = requestContainerProperties_containerProperties_User;
                requestContainerPropertiesIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int32? requestContainerProperties_containerProperties_Vcpus = null;
            if (cmdletContext.ContainerProperties_Vcpus != null)
            {
                requestContainerProperties_containerProperties_Vcpus = cmdletContext.ContainerProperties_Vcpus.Value;
            }
            if (requestContainerProperties_containerProperties_Vcpus != null)
            {
                request.ContainerProperties.Vcpus = requestContainerProperties_containerProperties_Vcpus.Value;
                requestContainerPropertiesIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            List<Amazon.Batch.Model.Volume> requestContainerProperties_containerProperties_Volume = null;
            if (cmdletContext.ContainerProperties_Volume != null)
            {
                requestContainerProperties_containerProperties_Volume = cmdletContext.ContainerProperties_Volume;
            }
            if (requestContainerProperties_containerProperties_Volume != null)
            {
                request.ContainerProperties.Volumes = requestContainerProperties_containerProperties_Volume;
                requestContainerPropertiesIsNull = false;
            }
            Amazon.Batch.Model.EphemeralStorage requestContainerProperties_containerProperties_EphemeralStorage = null;
            
             // populate EphemeralStorage
            var requestContainerProperties_containerProperties_EphemeralStorageIsNull = true;
            requestContainerProperties_containerProperties_EphemeralStorage = new Amazon.Batch.Model.EphemeralStorage();
            System.Int32? requestContainerProperties_containerProperties_EphemeralStorage_ephemeralStorage_SizeInGiB = null;
            if (cmdletContext.EphemeralStorage_SizeInGiB != null)
            {
                requestContainerProperties_containerProperties_EphemeralStorage_ephemeralStorage_SizeInGiB = cmdletContext.EphemeralStorage_SizeInGiB.Value;
            }
            if (requestContainerProperties_containerProperties_EphemeralStorage_ephemeralStorage_SizeInGiB != null)
            {
                requestContainerProperties_containerProperties_EphemeralStorage.SizeInGiB = requestContainerProperties_containerProperties_EphemeralStorage_ephemeralStorage_SizeInGiB.Value;
                requestContainerProperties_containerProperties_EphemeralStorageIsNull = false;
            }
             // determine if requestContainerProperties_containerProperties_EphemeralStorage should be set to null
            if (requestContainerProperties_containerProperties_EphemeralStorageIsNull)
            {
                requestContainerProperties_containerProperties_EphemeralStorage = null;
            }
            if (requestContainerProperties_containerProperties_EphemeralStorage != null)
            {
                request.ContainerProperties.EphemeralStorage = requestContainerProperties_containerProperties_EphemeralStorage;
                requestContainerPropertiesIsNull = false;
            }
            Amazon.Batch.Model.FargatePlatformConfiguration requestContainerProperties_containerProperties_FargatePlatformConfiguration = null;
            
             // populate FargatePlatformConfiguration
            var requestContainerProperties_containerProperties_FargatePlatformConfigurationIsNull = true;
            requestContainerProperties_containerProperties_FargatePlatformConfiguration = new Amazon.Batch.Model.FargatePlatformConfiguration();
            System.String requestContainerProperties_containerProperties_FargatePlatformConfiguration_fargatePlatformConfiguration_PlatformVersion = null;
            if (cmdletContext.FargatePlatformConfiguration_PlatformVersion != null)
            {
                requestContainerProperties_containerProperties_FargatePlatformConfiguration_fargatePlatformConfiguration_PlatformVersion = cmdletContext.FargatePlatformConfiguration_PlatformVersion;
            }
            if (requestContainerProperties_containerProperties_FargatePlatformConfiguration_fargatePlatformConfiguration_PlatformVersion != null)
            {
                requestContainerProperties_containerProperties_FargatePlatformConfiguration.PlatformVersion = requestContainerProperties_containerProperties_FargatePlatformConfiguration_fargatePlatformConfiguration_PlatformVersion;
                requestContainerProperties_containerProperties_FargatePlatformConfigurationIsNull = false;
            }
             // determine if requestContainerProperties_containerProperties_FargatePlatformConfiguration should be set to null
            if (requestContainerProperties_containerProperties_FargatePlatformConfigurationIsNull)
            {
                requestContainerProperties_containerProperties_FargatePlatformConfiguration = null;
            }
            if (requestContainerProperties_containerProperties_FargatePlatformConfiguration != null)
            {
                request.ContainerProperties.FargatePlatformConfiguration = requestContainerProperties_containerProperties_FargatePlatformConfiguration;
                requestContainerPropertiesIsNull = false;
            }
            Amazon.Batch.Model.NetworkConfiguration requestContainerProperties_containerProperties_NetworkConfiguration = null;
            
             // populate NetworkConfiguration
            var requestContainerProperties_containerProperties_NetworkConfigurationIsNull = true;
            requestContainerProperties_containerProperties_NetworkConfiguration = new Amazon.Batch.Model.NetworkConfiguration();
            Amazon.Batch.AssignPublicIp requestContainerProperties_containerProperties_NetworkConfiguration_networkConfiguration_AssignPublicIp = null;
            if (cmdletContext.NetworkConfiguration_AssignPublicIp != null)
            {
                requestContainerProperties_containerProperties_NetworkConfiguration_networkConfiguration_AssignPublicIp = cmdletContext.NetworkConfiguration_AssignPublicIp;
            }
            if (requestContainerProperties_containerProperties_NetworkConfiguration_networkConfiguration_AssignPublicIp != null)
            {
                requestContainerProperties_containerProperties_NetworkConfiguration.AssignPublicIp = requestContainerProperties_containerProperties_NetworkConfiguration_networkConfiguration_AssignPublicIp;
                requestContainerProperties_containerProperties_NetworkConfigurationIsNull = false;
            }
             // determine if requestContainerProperties_containerProperties_NetworkConfiguration should be set to null
            if (requestContainerProperties_containerProperties_NetworkConfigurationIsNull)
            {
                requestContainerProperties_containerProperties_NetworkConfiguration = null;
            }
            if (requestContainerProperties_containerProperties_NetworkConfiguration != null)
            {
                request.ContainerProperties.NetworkConfiguration = requestContainerProperties_containerProperties_NetworkConfiguration;
                requestContainerPropertiesIsNull = false;
            }
            Amazon.Batch.Model.LogConfiguration requestContainerProperties_containerProperties_LogConfiguration = null;
            
             // populate LogConfiguration
            var requestContainerProperties_containerProperties_LogConfigurationIsNull = true;
            requestContainerProperties_containerProperties_LogConfiguration = new Amazon.Batch.Model.LogConfiguration();
            Amazon.Batch.LogDriver requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_LogDriver = null;
            if (cmdletContext.LogConfiguration_LogDriver != null)
            {
                requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_LogDriver = cmdletContext.LogConfiguration_LogDriver;
            }
            if (requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_LogDriver != null)
            {
                requestContainerProperties_containerProperties_LogConfiguration.LogDriver = requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_LogDriver;
                requestContainerProperties_containerProperties_LogConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_Option = null;
            if (cmdletContext.LogConfiguration_Option != null)
            {
                requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_Option = cmdletContext.LogConfiguration_Option;
            }
            if (requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_Option != null)
            {
                requestContainerProperties_containerProperties_LogConfiguration.Options = requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_Option;
                requestContainerProperties_containerProperties_LogConfigurationIsNull = false;
            }
            List<Amazon.Batch.Model.Secret> requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_SecretOption = null;
            if (cmdletContext.LogConfiguration_SecretOption != null)
            {
                requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_SecretOption = cmdletContext.LogConfiguration_SecretOption;
            }
            if (requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_SecretOption != null)
            {
                requestContainerProperties_containerProperties_LogConfiguration.SecretOptions = requestContainerProperties_containerProperties_LogConfiguration_logConfiguration_SecretOption;
                requestContainerProperties_containerProperties_LogConfigurationIsNull = false;
            }
             // determine if requestContainerProperties_containerProperties_LogConfiguration should be set to null
            if (requestContainerProperties_containerProperties_LogConfigurationIsNull)
            {
                requestContainerProperties_containerProperties_LogConfiguration = null;
            }
            if (requestContainerProperties_containerProperties_LogConfiguration != null)
            {
                request.ContainerProperties.LogConfiguration = requestContainerProperties_containerProperties_LogConfiguration;
                requestContainerPropertiesIsNull = false;
            }
            Amazon.Batch.Model.LinuxParameters requestContainerProperties_containerProperties_LinuxParameters = null;
            
             // populate LinuxParameters
            var requestContainerProperties_containerProperties_LinuxParametersIsNull = true;
            requestContainerProperties_containerProperties_LinuxParameters = new Amazon.Batch.Model.LinuxParameters();
            List<Amazon.Batch.Model.Device> requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Device = null;
            if (cmdletContext.LinuxParameters_Device != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Device = cmdletContext.LinuxParameters_Device;
            }
            if (requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Device != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters.Devices = requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Device;
                requestContainerProperties_containerProperties_LinuxParametersIsNull = false;
            }
            System.Boolean? requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_InitProcessEnabled = null;
            if (cmdletContext.LinuxParameters_InitProcessEnabled != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_InitProcessEnabled = cmdletContext.LinuxParameters_InitProcessEnabled.Value;
            }
            if (requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_InitProcessEnabled != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters.InitProcessEnabled = requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_InitProcessEnabled.Value;
                requestContainerProperties_containerProperties_LinuxParametersIsNull = false;
            }
            System.Int32? requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_MaxSwap = null;
            if (cmdletContext.LinuxParameters_MaxSwap != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_MaxSwap = cmdletContext.LinuxParameters_MaxSwap.Value;
            }
            if (requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_MaxSwap != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters.MaxSwap = requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_MaxSwap.Value;
                requestContainerProperties_containerProperties_LinuxParametersIsNull = false;
            }
            System.Int32? requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_SharedMemorySize = null;
            if (cmdletContext.LinuxParameters_SharedMemorySize != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_SharedMemorySize = cmdletContext.LinuxParameters_SharedMemorySize.Value;
            }
            if (requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_SharedMemorySize != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters.SharedMemorySize = requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_SharedMemorySize.Value;
                requestContainerProperties_containerProperties_LinuxParametersIsNull = false;
            }
            System.Int32? requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Swappiness = null;
            if (cmdletContext.LinuxParameters_Swappiness != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Swappiness = cmdletContext.LinuxParameters_Swappiness.Value;
            }
            if (requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Swappiness != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters.Swappiness = requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Swappiness.Value;
                requestContainerProperties_containerProperties_LinuxParametersIsNull = false;
            }
            List<Amazon.Batch.Model.Tmpfs> requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Tmpf = null;
            if (cmdletContext.LinuxParameters_Tmpf != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Tmpf = cmdletContext.LinuxParameters_Tmpf;
            }
            if (requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Tmpf != null)
            {
                requestContainerProperties_containerProperties_LinuxParameters.Tmpfs = requestContainerProperties_containerProperties_LinuxParameters_linuxParameters_Tmpf;
                requestContainerProperties_containerProperties_LinuxParametersIsNull = false;
            }
             // determine if requestContainerProperties_containerProperties_LinuxParameters should be set to null
            if (requestContainerProperties_containerProperties_LinuxParametersIsNull)
            {
                requestContainerProperties_containerProperties_LinuxParameters = null;
            }
            if (requestContainerProperties_containerProperties_LinuxParameters != null)
            {
                request.ContainerProperties.LinuxParameters = requestContainerProperties_containerProperties_LinuxParameters;
                requestContainerPropertiesIsNull = false;
            }
             // determine if request.ContainerProperties should be set to null
            if (requestContainerPropertiesIsNull)
            {
                request.ContainerProperties = null;
            }
            
             // populate EksProperties
            var requestEksPropertiesIsNull = true;
            request.EksProperties = new Amazon.Batch.Model.EksProperties();
            Amazon.Batch.Model.EksPodProperties requestEksProperties_eksProperties_PodProperties = null;
            
             // populate PodProperties
            var requestEksProperties_eksProperties_PodPropertiesIsNull = true;
            requestEksProperties_eksProperties_PodProperties = new Amazon.Batch.Model.EksPodProperties();
            List<Amazon.Batch.Model.EksContainer> requestEksProperties_eksProperties_PodProperties_podProperties_Container = null;
            if (cmdletContext.PodProperties_Container != null)
            {
                requestEksProperties_eksProperties_PodProperties_podProperties_Container = cmdletContext.PodProperties_Container;
            }
            if (requestEksProperties_eksProperties_PodProperties_podProperties_Container != null)
            {
                requestEksProperties_eksProperties_PodProperties.Containers = requestEksProperties_eksProperties_PodProperties_podProperties_Container;
                requestEksProperties_eksProperties_PodPropertiesIsNull = false;
            }
            System.String requestEksProperties_eksProperties_PodProperties_podProperties_DnsPolicy = null;
            if (cmdletContext.PodProperties_DnsPolicy != null)
            {
                requestEksProperties_eksProperties_PodProperties_podProperties_DnsPolicy = cmdletContext.PodProperties_DnsPolicy;
            }
            if (requestEksProperties_eksProperties_PodProperties_podProperties_DnsPolicy != null)
            {
                requestEksProperties_eksProperties_PodProperties.DnsPolicy = requestEksProperties_eksProperties_PodProperties_podProperties_DnsPolicy;
                requestEksProperties_eksProperties_PodPropertiesIsNull = false;
            }
            System.Boolean? requestEksProperties_eksProperties_PodProperties_podProperties_HostNetwork = null;
            if (cmdletContext.PodProperties_HostNetwork != null)
            {
                requestEksProperties_eksProperties_PodProperties_podProperties_HostNetwork = cmdletContext.PodProperties_HostNetwork.Value;
            }
            if (requestEksProperties_eksProperties_PodProperties_podProperties_HostNetwork != null)
            {
                requestEksProperties_eksProperties_PodProperties.HostNetwork = requestEksProperties_eksProperties_PodProperties_podProperties_HostNetwork.Value;
                requestEksProperties_eksProperties_PodPropertiesIsNull = false;
            }
            System.String requestEksProperties_eksProperties_PodProperties_podProperties_ServiceAccountName = null;
            if (cmdletContext.PodProperties_ServiceAccountName != null)
            {
                requestEksProperties_eksProperties_PodProperties_podProperties_ServiceAccountName = cmdletContext.PodProperties_ServiceAccountName;
            }
            if (requestEksProperties_eksProperties_PodProperties_podProperties_ServiceAccountName != null)
            {
                requestEksProperties_eksProperties_PodProperties.ServiceAccountName = requestEksProperties_eksProperties_PodProperties_podProperties_ServiceAccountName;
                requestEksProperties_eksProperties_PodPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.EksVolume> requestEksProperties_eksProperties_PodProperties_podProperties_Volume = null;
            if (cmdletContext.PodProperties_Volume != null)
            {
                requestEksProperties_eksProperties_PodProperties_podProperties_Volume = cmdletContext.PodProperties_Volume;
            }
            if (requestEksProperties_eksProperties_PodProperties_podProperties_Volume != null)
            {
                requestEksProperties_eksProperties_PodProperties.Volumes = requestEksProperties_eksProperties_PodProperties_podProperties_Volume;
                requestEksProperties_eksProperties_PodPropertiesIsNull = false;
            }
            Amazon.Batch.Model.EksMetadata requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata = null;
            
             // populate Metadata
            var requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_MetadataIsNull = true;
            requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata = new Amazon.Batch.Model.EksMetadata();
            Dictionary<System.String, System.String> requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata_metadata_Label = null;
            if (cmdletContext.Metadata_Label != null)
            {
                requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata_metadata_Label = cmdletContext.Metadata_Label;
            }
            if (requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata_metadata_Label != null)
            {
                requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata.Labels = requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata_metadata_Label;
                requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_MetadataIsNull = false;
            }
             // determine if requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata should be set to null
            if (requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_MetadataIsNull)
            {
                requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata = null;
            }
            if (requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata != null)
            {
                requestEksProperties_eksProperties_PodProperties.Metadata = requestEksProperties_eksProperties_PodProperties_eksProperties_PodProperties_Metadata;
                requestEksProperties_eksProperties_PodPropertiesIsNull = false;
            }
             // determine if requestEksProperties_eksProperties_PodProperties should be set to null
            if (requestEksProperties_eksProperties_PodPropertiesIsNull)
            {
                requestEksProperties_eksProperties_PodProperties = null;
            }
            if (requestEksProperties_eksProperties_PodProperties != null)
            {
                request.EksProperties.PodProperties = requestEksProperties_eksProperties_PodProperties;
                requestEksPropertiesIsNull = false;
            }
             // determine if request.EksProperties should be set to null
            if (requestEksPropertiesIsNull)
            {
                request.EksProperties = null;
            }
            if (cmdletContext.JobDefinitionName != null)
            {
                request.JobDefinitionName = cmdletContext.JobDefinitionName;
            }
            
             // populate NodeProperties
            var requestNodePropertiesIsNull = true;
            request.NodeProperties = new Amazon.Batch.Model.NodeProperties();
            System.Int32? requestNodeProperties_nodeProperties_MainNode = null;
            if (cmdletContext.NodeProperties_MainNode != null)
            {
                requestNodeProperties_nodeProperties_MainNode = cmdletContext.NodeProperties_MainNode.Value;
            }
            if (requestNodeProperties_nodeProperties_MainNode != null)
            {
                request.NodeProperties.MainNode = requestNodeProperties_nodeProperties_MainNode.Value;
                requestNodePropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.NodeRangeProperty> requestNodeProperties_nodeProperties_NodeRangeProperty = null;
            if (cmdletContext.NodeProperties_NodeRangeProperty != null)
            {
                requestNodeProperties_nodeProperties_NodeRangeProperty = cmdletContext.NodeProperties_NodeRangeProperty;
            }
            if (requestNodeProperties_nodeProperties_NodeRangeProperty != null)
            {
                request.NodeProperties.NodeRangeProperties = requestNodeProperties_nodeProperties_NodeRangeProperty;
                requestNodePropertiesIsNull = false;
            }
            System.Int32? requestNodeProperties_nodeProperties_NumNode = null;
            if (cmdletContext.NodeProperties_NumNode != null)
            {
                requestNodeProperties_nodeProperties_NumNode = cmdletContext.NodeProperties_NumNode.Value;
            }
            if (requestNodeProperties_nodeProperties_NumNode != null)
            {
                request.NodeProperties.NumNodes = requestNodeProperties_nodeProperties_NumNode.Value;
                requestNodePropertiesIsNull = false;
            }
             // determine if request.NodeProperties should be set to null
            if (requestNodePropertiesIsNull)
            {
                request.NodeProperties = null;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.PlatformCapability != null)
            {
                request.PlatformCapabilities = cmdletContext.PlatformCapability;
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
            if (cmdletContext.SchedulingPriority != null)
            {
                request.SchedulingPriority = cmdletContext.SchedulingPriority.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.Batch.Model.RegisterJobDefinitionResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.RegisterJobDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "RegisterJobDefinition");
            try
            {
                #if DESKTOP
                return client.RegisterJobDefinition(request);
                #elif CORECLR
                return client.RegisterJobDefinitionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ContainerProperties_Command { get; set; }
            public List<Amazon.Batch.Model.KeyValuePair> ContainerProperties_Environment { get; set; }
            public System.Int32? EphemeralStorage_SizeInGiB { get; set; }
            public System.String ContainerProperties_ExecutionRoleArn { get; set; }
            public System.String FargatePlatformConfiguration_PlatformVersion { get; set; }
            public System.String ContainerProperties_Image { get; set; }
            public System.String ContainerProperties_InstanceType { get; set; }
            public System.String ContainerProperties_JobRoleArn { get; set; }
            public List<Amazon.Batch.Model.Device> LinuxParameters_Device { get; set; }
            public System.Boolean? LinuxParameters_InitProcessEnabled { get; set; }
            public System.Int32? LinuxParameters_MaxSwap { get; set; }
            public System.Int32? LinuxParameters_SharedMemorySize { get; set; }
            public System.Int32? LinuxParameters_Swappiness { get; set; }
            public List<Amazon.Batch.Model.Tmpfs> LinuxParameters_Tmpf { get; set; }
            public Amazon.Batch.LogDriver LogConfiguration_LogDriver { get; set; }
            public Dictionary<System.String, System.String> LogConfiguration_Option { get; set; }
            public List<Amazon.Batch.Model.Secret> LogConfiguration_SecretOption { get; set; }
            [System.ObsoleteAttribute]
            public System.Int32? ContainerProperties_Memory { get; set; }
            public List<Amazon.Batch.Model.MountPoint> ContainerProperties_MountPoint { get; set; }
            public Amazon.Batch.AssignPublicIp NetworkConfiguration_AssignPublicIp { get; set; }
            public System.Boolean? ContainerProperties_Privileged { get; set; }
            public System.Boolean? ContainerProperties_ReadonlyRootFilesystem { get; set; }
            public List<Amazon.Batch.Model.ResourceRequirement> ContainerProperties_ResourceRequirement { get; set; }
            public List<Amazon.Batch.Model.Secret> ContainerProperties_Secret { get; set; }
            public List<Amazon.Batch.Model.Ulimit> ContainerProperties_Ulimit { get; set; }
            public System.String ContainerProperties_User { get; set; }
            [System.ObsoleteAttribute]
            public System.Int32? ContainerProperties_Vcpus { get; set; }
            public List<Amazon.Batch.Model.Volume> ContainerProperties_Volume { get; set; }
            public List<Amazon.Batch.Model.EksContainer> PodProperties_Container { get; set; }
            public System.String PodProperties_DnsPolicy { get; set; }
            public System.Boolean? PodProperties_HostNetwork { get; set; }
            public Dictionary<System.String, System.String> Metadata_Label { get; set; }
            public System.String PodProperties_ServiceAccountName { get; set; }
            public List<Amazon.Batch.Model.EksVolume> PodProperties_Volume { get; set; }
            public System.String JobDefinitionName { get; set; }
            public System.Int32? NodeProperties_MainNode { get; set; }
            public List<Amazon.Batch.Model.NodeRangeProperty> NodeProperties_NodeRangeProperty { get; set; }
            public System.Int32? NodeProperties_NumNode { get; set; }
            public Dictionary<System.String, System.String> Parameter { get; set; }
            public List<System.String> PlatformCapability { get; set; }
            public System.Boolean? PropagateTag { get; set; }
            public System.Int32? RetryStrategy_Attempt { get; set; }
            public List<Amazon.Batch.Model.EvaluateOnExit> RetryStrategy_EvaluateOnExit { get; set; }
            public System.Int32? SchedulingPriority { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Batch.Model.JobTimeout Timeout { get; set; }
            public Amazon.Batch.JobDefinitionType Type { get; set; }
            public System.Func<Amazon.Batch.Model.RegisterJobDefinitionResponse, RegisterBATJobDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
