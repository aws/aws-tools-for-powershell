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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Creates an Express service that simplifies deploying containerized web applications
    /// on Amazon ECS with managed Amazon Web Services infrastructure. This operation provisions
    /// and configures Application Load Balancers, target groups, security groups, and auto-scaling
    /// policies automatically.
    /// 
    ///  
    /// <para>
    /// Specify a primary container configuration with your application image and basic settings.
    /// Amazon ECS creates the necessary Amazon Web Services resources for traffic distribution,
    /// health monitoring, network access control, and capacity management.
    /// </para><para>
    /// Provide an execution role for task operations and an infrastructure role for managing
    /// Amazon Web Services resources on your behalf.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ECSExpressGatewayService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.ECSExpressGatewayService")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service CreateExpressGatewayService API operation.", Operation = new[] {"CreateExpressGatewayService"}, SelectReturnType = typeof(Amazon.ECS.Model.CreateExpressGatewayServiceResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.ECSExpressGatewayService or Amazon.ECS.Model.CreateExpressGatewayServiceResponse",
        "This cmdlet returns an Amazon.ECS.Model.ECSExpressGatewayService object.",
        "The service call response (type Amazon.ECS.Model.CreateExpressGatewayServiceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewECSExpressGatewayServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ScalingTarget_AutoScalingMetric
        /// <summary>
        /// <para>
        /// <para>The metric used for auto-scaling decisions. The default metric used for an Express
        /// service is <c>CPUUtilization</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.ExpressGatewayServiceScalingMetric")]
        public Amazon.ECS.ExpressGatewayServiceScalingMetric ScalingTarget_AutoScalingMetric { get; set; }
        #endregion
        
        #region Parameter ScalingTarget_AutoScalingTargetValue
        /// <summary>
        /// <para>
        /// <para>The target value for the auto-scaling metric. The default value for an Express service
        /// is 60.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingTarget_AutoScalingTargetValue { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster on which to create
        /// the Express service. If you do not specify a cluster, the <c>default</c> cluster is
        /// assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter PrimaryContainer_Command
        /// <summary>
        /// <para>
        /// <para>The command that is passed to the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PrimaryContainer_Command { get; set; }
        #endregion
        
        #region Parameter PrimaryContainer_ContainerPort
        /// <summary>
        /// <para>
        /// <para>The port number on the container that receives traffic from the load balancer. Default
        /// is 80.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PrimaryContainer_ContainerPort { get; set; }
        #endregion
        
        #region Parameter Cpu
        /// <summary>
        /// <para>
        /// <para>The number of CPU units used by the task. This parameter determines the CPU allocation
        /// for each task in the Express service. The default value for an Express service is
        /// 256 (.25 vCPU).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cpu { get; set; }
        #endregion
        
        #region Parameter RepositoryCredentials_CredentialsParameter
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the secret containing the private repository credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrimaryContainer_RepositoryCredentials_CredentialsParameter")]
        public System.String RepositoryCredentials_CredentialsParameter { get; set; }
        #endregion
        
        #region Parameter PrimaryContainer_Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to pass to the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.KeyValuePair[] PrimaryContainer_Environment { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the task execution role that grants the Amazon ECS
        /// container agent permission to make Amazon Web Services API calls on your behalf. This
        /// role is required for Amazon ECS to pull container images from Amazon ECR, send container
        /// logs to Amazon CloudWatch Logs, and retrieve sensitive data from Amazon Web Services
        /// Systems Manager Parameter Store or Amazon Web Services Secrets Manager.</para><para>The execution role must include the <c>AmazonECSTaskExecutionRolePolicy</c> managed
        /// policy or equivalent permissions. For Express services, this role is used during task
        /// startup and runtime for container management operations.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter HealthCheckPath
        /// <summary>
        /// <para>
        /// <para>The path on the container that the Application Load Balancer uses for health checks.
        /// This should be a valid HTTP endpoint that returns a successful response (HTTP 200)
        /// when the application is healthy.</para><para>If not specified, the default health check path is <c>/ping</c>. The health check
        /// path must start with a forward slash and can include query parameters. Examples: <c>/health</c>,
        /// <c>/api/status</c>, <c>/ping?format=json</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckPath { get; set; }
        #endregion
        
        #region Parameter PrimaryContainer_Image
        /// <summary>
        /// <para>
        /// <para>The image used to start a container. This string is passed directly to the Docker
        /// daemon. Images in the Docker Hub registry are available by default. Other repositories
        /// are specified with either <c>repository-url/image:tag</c> or <c>repository-url/image@digest</c>.</para><para>For Express services, the image typically contains a web application that listens
        /// on the specified container port. The image can be stored in Amazon ECR, Docker Hub,
        /// or any other container registry accessible to your execution role.</para>
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
        public System.String PrimaryContainer_Image { get; set; }
        #endregion
        
        #region Parameter InfrastructureRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the infrastructure role that grants Amazon ECS permission
        /// to create and manage Amazon Web Services resources on your behalf for the Express
        /// service. This role is used to provision and manage Application Load Balancers, target
        /// groups, security groups, auto-scaling policies, and other Amazon Web Services infrastructure
        /// components.</para><para>The infrastructure role must include permissions for Elastic Load Balancing, Application
        /// Auto Scaling, Amazon EC2 (for security groups), and other services required for managed
        /// infrastructure. This role is only used during Express service creation, updates, and
        /// deletion operations.</para>
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
        public System.String InfrastructureRoleArn { get; set; }
        #endregion
        
        #region Parameter AwsLogsConfiguration_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log group to send container logs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrimaryContainer_AwsLogsConfiguration_LogGroup")]
        public System.String AwsLogsConfiguration_LogGroup { get; set; }
        #endregion
        
        #region Parameter AwsLogsConfiguration_LogStreamPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix for the CloudWatch Logs log stream names. The default for an Express service
        /// is <c>ecs</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrimaryContainer_AwsLogsConfiguration_LogStreamPrefix")]
        public System.String AwsLogsConfiguration_LogStreamPrefix { get; set; }
        #endregion
        
        #region Parameter ScalingTarget_MaxTaskCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of tasks to run in the Express service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingTarget_MaxTaskCount { get; set; }
        #endregion
        
        #region Parameter Memory
        /// <summary>
        /// <para>
        /// <para>The amount of memory (in MiB) used by the task. This parameter determines the memory
        /// allocation for each task in the Express service. The default value for an express
        /// service is 512 MiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Memory { get; set; }
        #endregion
        
        #region Parameter ScalingTarget_MinTaskCount
        /// <summary>
        /// <para>
        /// <para>The minimum number of tasks to run in the Express service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingTarget_MinTaskCount { get; set; }
        #endregion
        
        #region Parameter PrimaryContainer_Secret
        /// <summary>
        /// <para>
        /// <para>The secrets to pass to the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrimaryContainer_Secrets")]
        public Amazon.ECS.Model.Secret[] PrimaryContainer_Secret { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups associated with the Express service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SecurityGroups")]
        public System.String[] NetworkConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the Express service. This name must be unique within the specified cluster
        /// and can contain up to 255 letters (uppercase and lowercase), numbers, underscores,
        /// and hyphens. The name is used to identify the service in the Amazon ECS console and
        /// API operations.</para><para>If you don't specify a service name, Amazon ECS generates a unique name for the service.
        /// The service name becomes part of the service ARN and cannot be changed after the service
        /// is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets associated with the Express service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_Subnets")]
        public System.String[] NetworkConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the Express service to help categorize and organize
        /// it. Each tag consists of a key and an optional value. You can apply up to 50 tags
        /// to a service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ECS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TaskRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that containers in this task can assume.
        /// This role allows your application code to access other Amazon Web Services services
        /// securely.</para><para>The task role is different from the execution role. While the execution role is used
        /// by the Amazon ECS agent to set up the task, the task role is used by your application
        /// code running inside the container to make Amazon Web Services API calls. If your application
        /// doesn't need to access Amazon Web Services services, you can omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Service'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.CreateExpressGatewayServiceResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.CreateExpressGatewayServiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Service";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ExecutionRoleArn),
                nameof(this.InfrastructureRoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSExpressGatewayService (CreateExpressGatewayService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.CreateExpressGatewayServiceResponse, NewECSExpressGatewayServiceCmdlet>(Select) ??
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
            context.Cpu = this.Cpu;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthCheckPath = this.HealthCheckPath;
            context.InfrastructureRoleArn = this.InfrastructureRoleArn;
            #if MODULAR
            if (this.InfrastructureRoleArn == null && ParameterWasBound(nameof(this.InfrastructureRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InfrastructureRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Memory = this.Memory;
            if (this.NetworkConfiguration_SecurityGroup != null)
            {
                context.NetworkConfiguration_SecurityGroup = new List<System.String>(this.NetworkConfiguration_SecurityGroup);
            }
            if (this.NetworkConfiguration_Subnet != null)
            {
                context.NetworkConfiguration_Subnet = new List<System.String>(this.NetworkConfiguration_Subnet);
            }
            context.AwsLogsConfiguration_LogGroup = this.AwsLogsConfiguration_LogGroup;
            context.AwsLogsConfiguration_LogStreamPrefix = this.AwsLogsConfiguration_LogStreamPrefix;
            if (this.PrimaryContainer_Command != null)
            {
                context.PrimaryContainer_Command = new List<System.String>(this.PrimaryContainer_Command);
            }
            context.PrimaryContainer_ContainerPort = this.PrimaryContainer_ContainerPort;
            if (this.PrimaryContainer_Environment != null)
            {
                context.PrimaryContainer_Environment = new List<Amazon.ECS.Model.KeyValuePair>(this.PrimaryContainer_Environment);
            }
            context.PrimaryContainer_Image = this.PrimaryContainer_Image;
            #if MODULAR
            if (this.PrimaryContainer_Image == null && ParameterWasBound(nameof(this.PrimaryContainer_Image)))
            {
                WriteWarning("You are passing $null as a value for parameter PrimaryContainer_Image which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RepositoryCredentials_CredentialsParameter = this.RepositoryCredentials_CredentialsParameter;
            if (this.PrimaryContainer_Secret != null)
            {
                context.PrimaryContainer_Secret = new List<Amazon.ECS.Model.Secret>(this.PrimaryContainer_Secret);
            }
            context.ScalingTarget_AutoScalingMetric = this.ScalingTarget_AutoScalingMetric;
            context.ScalingTarget_AutoScalingTargetValue = this.ScalingTarget_AutoScalingTargetValue;
            context.ScalingTarget_MaxTaskCount = this.ScalingTarget_MaxTaskCount;
            context.ScalingTarget_MinTaskCount = this.ScalingTarget_MinTaskCount;
            context.ServiceName = this.ServiceName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ECS.Model.Tag>(this.Tag);
            }
            context.TaskRoleArn = this.TaskRoleArn;
            
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
            var request = new Amazon.ECS.Model.CreateExpressGatewayServiceRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.Cpu != null)
            {
                request.Cpu = cmdletContext.Cpu;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.HealthCheckPath != null)
            {
                request.HealthCheckPath = cmdletContext.HealthCheckPath;
            }
            if (cmdletContext.InfrastructureRoleArn != null)
            {
                request.InfrastructureRoleArn = cmdletContext.InfrastructureRoleArn;
            }
            if (cmdletContext.Memory != null)
            {
                request.Memory = cmdletContext.Memory;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.ECS.Model.ExpressGatewayServiceNetworkConfiguration();
            List<System.String> requestNetworkConfiguration_networkConfiguration_SecurityGroup = null;
            if (cmdletContext.NetworkConfiguration_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_SecurityGroup = cmdletContext.NetworkConfiguration_SecurityGroup;
            }
            if (requestNetworkConfiguration_networkConfiguration_SecurityGroup != null)
            {
                request.NetworkConfiguration.SecurityGroups = requestNetworkConfiguration_networkConfiguration_SecurityGroup;
                requestNetworkConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_Subnet = null;
            if (cmdletContext.NetworkConfiguration_Subnet != null)
            {
                requestNetworkConfiguration_networkConfiguration_Subnet = cmdletContext.NetworkConfiguration_Subnet;
            }
            if (requestNetworkConfiguration_networkConfiguration_Subnet != null)
            {
                request.NetworkConfiguration.Subnets = requestNetworkConfiguration_networkConfiguration_Subnet;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            
             // populate PrimaryContainer
            var requestPrimaryContainerIsNull = true;
            request.PrimaryContainer = new Amazon.ECS.Model.ExpressGatewayContainer();
            List<System.String> requestPrimaryContainer_primaryContainer_Command = null;
            if (cmdletContext.PrimaryContainer_Command != null)
            {
                requestPrimaryContainer_primaryContainer_Command = cmdletContext.PrimaryContainer_Command;
            }
            if (requestPrimaryContainer_primaryContainer_Command != null)
            {
                request.PrimaryContainer.Command = requestPrimaryContainer_primaryContainer_Command;
                requestPrimaryContainerIsNull = false;
            }
            System.Int32? requestPrimaryContainer_primaryContainer_ContainerPort = null;
            if (cmdletContext.PrimaryContainer_ContainerPort != null)
            {
                requestPrimaryContainer_primaryContainer_ContainerPort = cmdletContext.PrimaryContainer_ContainerPort.Value;
            }
            if (requestPrimaryContainer_primaryContainer_ContainerPort != null)
            {
                request.PrimaryContainer.ContainerPort = requestPrimaryContainer_primaryContainer_ContainerPort.Value;
                requestPrimaryContainerIsNull = false;
            }
            List<Amazon.ECS.Model.KeyValuePair> requestPrimaryContainer_primaryContainer_Environment = null;
            if (cmdletContext.PrimaryContainer_Environment != null)
            {
                requestPrimaryContainer_primaryContainer_Environment = cmdletContext.PrimaryContainer_Environment;
            }
            if (requestPrimaryContainer_primaryContainer_Environment != null)
            {
                request.PrimaryContainer.Environment = requestPrimaryContainer_primaryContainer_Environment;
                requestPrimaryContainerIsNull = false;
            }
            System.String requestPrimaryContainer_primaryContainer_Image = null;
            if (cmdletContext.PrimaryContainer_Image != null)
            {
                requestPrimaryContainer_primaryContainer_Image = cmdletContext.PrimaryContainer_Image;
            }
            if (requestPrimaryContainer_primaryContainer_Image != null)
            {
                request.PrimaryContainer.Image = requestPrimaryContainer_primaryContainer_Image;
                requestPrimaryContainerIsNull = false;
            }
            List<Amazon.ECS.Model.Secret> requestPrimaryContainer_primaryContainer_Secret = null;
            if (cmdletContext.PrimaryContainer_Secret != null)
            {
                requestPrimaryContainer_primaryContainer_Secret = cmdletContext.PrimaryContainer_Secret;
            }
            if (requestPrimaryContainer_primaryContainer_Secret != null)
            {
                request.PrimaryContainer.Secrets = requestPrimaryContainer_primaryContainer_Secret;
                requestPrimaryContainerIsNull = false;
            }
            Amazon.ECS.Model.ExpressGatewayRepositoryCredentials requestPrimaryContainer_primaryContainer_RepositoryCredentials = null;
            
             // populate RepositoryCredentials
            var requestPrimaryContainer_primaryContainer_RepositoryCredentialsIsNull = true;
            requestPrimaryContainer_primaryContainer_RepositoryCredentials = new Amazon.ECS.Model.ExpressGatewayRepositoryCredentials();
            System.String requestPrimaryContainer_primaryContainer_RepositoryCredentials_repositoryCredentials_CredentialsParameter = null;
            if (cmdletContext.RepositoryCredentials_CredentialsParameter != null)
            {
                requestPrimaryContainer_primaryContainer_RepositoryCredentials_repositoryCredentials_CredentialsParameter = cmdletContext.RepositoryCredentials_CredentialsParameter;
            }
            if (requestPrimaryContainer_primaryContainer_RepositoryCredentials_repositoryCredentials_CredentialsParameter != null)
            {
                requestPrimaryContainer_primaryContainer_RepositoryCredentials.CredentialsParameter = requestPrimaryContainer_primaryContainer_RepositoryCredentials_repositoryCredentials_CredentialsParameter;
                requestPrimaryContainer_primaryContainer_RepositoryCredentialsIsNull = false;
            }
             // determine if requestPrimaryContainer_primaryContainer_RepositoryCredentials should be set to null
            if (requestPrimaryContainer_primaryContainer_RepositoryCredentialsIsNull)
            {
                requestPrimaryContainer_primaryContainer_RepositoryCredentials = null;
            }
            if (requestPrimaryContainer_primaryContainer_RepositoryCredentials != null)
            {
                request.PrimaryContainer.RepositoryCredentials = requestPrimaryContainer_primaryContainer_RepositoryCredentials;
                requestPrimaryContainerIsNull = false;
            }
            Amazon.ECS.Model.ExpressGatewayServiceAwsLogsConfiguration requestPrimaryContainer_primaryContainer_AwsLogsConfiguration = null;
            
             // populate AwsLogsConfiguration
            var requestPrimaryContainer_primaryContainer_AwsLogsConfigurationIsNull = true;
            requestPrimaryContainer_primaryContainer_AwsLogsConfiguration = new Amazon.ECS.Model.ExpressGatewayServiceAwsLogsConfiguration();
            System.String requestPrimaryContainer_primaryContainer_AwsLogsConfiguration_awsLogsConfiguration_LogGroup = null;
            if (cmdletContext.AwsLogsConfiguration_LogGroup != null)
            {
                requestPrimaryContainer_primaryContainer_AwsLogsConfiguration_awsLogsConfiguration_LogGroup = cmdletContext.AwsLogsConfiguration_LogGroup;
            }
            if (requestPrimaryContainer_primaryContainer_AwsLogsConfiguration_awsLogsConfiguration_LogGroup != null)
            {
                requestPrimaryContainer_primaryContainer_AwsLogsConfiguration.LogGroup = requestPrimaryContainer_primaryContainer_AwsLogsConfiguration_awsLogsConfiguration_LogGroup;
                requestPrimaryContainer_primaryContainer_AwsLogsConfigurationIsNull = false;
            }
            System.String requestPrimaryContainer_primaryContainer_AwsLogsConfiguration_awsLogsConfiguration_LogStreamPrefix = null;
            if (cmdletContext.AwsLogsConfiguration_LogStreamPrefix != null)
            {
                requestPrimaryContainer_primaryContainer_AwsLogsConfiguration_awsLogsConfiguration_LogStreamPrefix = cmdletContext.AwsLogsConfiguration_LogStreamPrefix;
            }
            if (requestPrimaryContainer_primaryContainer_AwsLogsConfiguration_awsLogsConfiguration_LogStreamPrefix != null)
            {
                requestPrimaryContainer_primaryContainer_AwsLogsConfiguration.LogStreamPrefix = requestPrimaryContainer_primaryContainer_AwsLogsConfiguration_awsLogsConfiguration_LogStreamPrefix;
                requestPrimaryContainer_primaryContainer_AwsLogsConfigurationIsNull = false;
            }
             // determine if requestPrimaryContainer_primaryContainer_AwsLogsConfiguration should be set to null
            if (requestPrimaryContainer_primaryContainer_AwsLogsConfigurationIsNull)
            {
                requestPrimaryContainer_primaryContainer_AwsLogsConfiguration = null;
            }
            if (requestPrimaryContainer_primaryContainer_AwsLogsConfiguration != null)
            {
                request.PrimaryContainer.AwsLogsConfiguration = requestPrimaryContainer_primaryContainer_AwsLogsConfiguration;
                requestPrimaryContainerIsNull = false;
            }
             // determine if request.PrimaryContainer should be set to null
            if (requestPrimaryContainerIsNull)
            {
                request.PrimaryContainer = null;
            }
            
             // populate ScalingTarget
            var requestScalingTargetIsNull = true;
            request.ScalingTarget = new Amazon.ECS.Model.ExpressGatewayScalingTarget();
            Amazon.ECS.ExpressGatewayServiceScalingMetric requestScalingTarget_scalingTarget_AutoScalingMetric = null;
            if (cmdletContext.ScalingTarget_AutoScalingMetric != null)
            {
                requestScalingTarget_scalingTarget_AutoScalingMetric = cmdletContext.ScalingTarget_AutoScalingMetric;
            }
            if (requestScalingTarget_scalingTarget_AutoScalingMetric != null)
            {
                request.ScalingTarget.AutoScalingMetric = requestScalingTarget_scalingTarget_AutoScalingMetric;
                requestScalingTargetIsNull = false;
            }
            System.Int32? requestScalingTarget_scalingTarget_AutoScalingTargetValue = null;
            if (cmdletContext.ScalingTarget_AutoScalingTargetValue != null)
            {
                requestScalingTarget_scalingTarget_AutoScalingTargetValue = cmdletContext.ScalingTarget_AutoScalingTargetValue.Value;
            }
            if (requestScalingTarget_scalingTarget_AutoScalingTargetValue != null)
            {
                request.ScalingTarget.AutoScalingTargetValue = requestScalingTarget_scalingTarget_AutoScalingTargetValue.Value;
                requestScalingTargetIsNull = false;
            }
            System.Int32? requestScalingTarget_scalingTarget_MaxTaskCount = null;
            if (cmdletContext.ScalingTarget_MaxTaskCount != null)
            {
                requestScalingTarget_scalingTarget_MaxTaskCount = cmdletContext.ScalingTarget_MaxTaskCount.Value;
            }
            if (requestScalingTarget_scalingTarget_MaxTaskCount != null)
            {
                request.ScalingTarget.MaxTaskCount = requestScalingTarget_scalingTarget_MaxTaskCount.Value;
                requestScalingTargetIsNull = false;
            }
            System.Int32? requestScalingTarget_scalingTarget_MinTaskCount = null;
            if (cmdletContext.ScalingTarget_MinTaskCount != null)
            {
                requestScalingTarget_scalingTarget_MinTaskCount = cmdletContext.ScalingTarget_MinTaskCount.Value;
            }
            if (requestScalingTarget_scalingTarget_MinTaskCount != null)
            {
                request.ScalingTarget.MinTaskCount = requestScalingTarget_scalingTarget_MinTaskCount.Value;
                requestScalingTargetIsNull = false;
            }
             // determine if request.ScalingTarget should be set to null
            if (requestScalingTargetIsNull)
            {
                request.ScalingTarget = null;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TaskRoleArn != null)
            {
                request.TaskRoleArn = cmdletContext.TaskRoleArn;
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
        
        private Amazon.ECS.Model.CreateExpressGatewayServiceResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.CreateExpressGatewayServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "CreateExpressGatewayService");
            try
            {
                #if DESKTOP
                return client.CreateExpressGatewayService(request);
                #elif CORECLR
                return client.CreateExpressGatewayServiceAsync(request).GetAwaiter().GetResult();
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
            public System.String Cpu { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String HealthCheckPath { get; set; }
            public System.String InfrastructureRoleArn { get; set; }
            public System.String Memory { get; set; }
            public List<System.String> NetworkConfiguration_SecurityGroup { get; set; }
            public List<System.String> NetworkConfiguration_Subnet { get; set; }
            public System.String AwsLogsConfiguration_LogGroup { get; set; }
            public System.String AwsLogsConfiguration_LogStreamPrefix { get; set; }
            public List<System.String> PrimaryContainer_Command { get; set; }
            public System.Int32? PrimaryContainer_ContainerPort { get; set; }
            public List<Amazon.ECS.Model.KeyValuePair> PrimaryContainer_Environment { get; set; }
            public System.String PrimaryContainer_Image { get; set; }
            public System.String RepositoryCredentials_CredentialsParameter { get; set; }
            public List<Amazon.ECS.Model.Secret> PrimaryContainer_Secret { get; set; }
            public Amazon.ECS.ExpressGatewayServiceScalingMetric ScalingTarget_AutoScalingMetric { get; set; }
            public System.Int32? ScalingTarget_AutoScalingTargetValue { get; set; }
            public System.Int32? ScalingTarget_MaxTaskCount { get; set; }
            public System.Int32? ScalingTarget_MinTaskCount { get; set; }
            public System.String ServiceName { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.String TaskRoleArn { get; set; }
            public System.Func<Amazon.ECS.Model.CreateExpressGatewayServiceResponse, NewECSExpressGatewayServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Service;
        }
        
    }
}
