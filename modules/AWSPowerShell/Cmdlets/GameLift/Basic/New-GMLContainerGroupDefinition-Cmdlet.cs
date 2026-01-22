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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// <b>This API works with the following fleet types:</b> Container
    /// 
    ///  
    /// <para>
    /// Creates a <c>ContainerGroupDefinition</c> that describes a set of containers for hosting
    /// your game server with Amazon GameLift Servers managed containers hosting. An Amazon
    /// GameLift Servers container group is similar to a container task or pod. Use container
    /// group definitions when you create a container fleet with <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_CreateContainerFleet.html">CreateContainerFleet</a>.
    /// 
    /// </para><para>
    /// A container group definition determines how Amazon GameLift Servers deploys your containers
    /// to each instance in a container fleet. You can maintain multiple versions of a container
    /// group definition.
    /// </para><para>
    /// There are two types of container groups:
    /// </para><ul><li><para>
    /// A <b>game server container group</b> has the containers that run your game server
    /// application and supporting software. A game server container group can have these
    /// container types:
    /// </para><ul><li><para>
    /// Game server container. This container runs your game server. You can define one game
    /// server container in a game server container group.
    /// </para></li><li><para>
    /// Support container. This container runs software in parallel with your game server.
    /// You can define up to 8 support containers in a game server group.
    /// </para></li></ul><para>
    /// When building a game server container group definition, you can choose to bundle your
    /// game server executable and all dependent software into a single game server container.
    /// Alternatively, you can separate the software into one game server container and one
    /// or more support containers.
    /// </para><para>
    /// On a container fleet instance, a game server container group can be deployed multiple
    /// times (depending on the compute resources of the instance). This means that all containers
    /// in the container group are replicated together.
    /// </para></li><li><para>
    /// A <b>per-instance container group</b> has containers for processes that aren't replicated
    /// on a container fleet instance. This might include background services, logging, test
    /// processes, or processes that need to persist independently of the game server container
    /// group. When building a per-instance container group, you can define up to 10 support
    /// containers.
    /// </para></li></ul><note><para>
    /// This operation requires Identity and Access Management (IAM) permissions to access
    /// container images in Amazon ECR repositories. See <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-iam-policy-examples.html">
    /// IAM permissions for Amazon GameLift Servers</a> for help setting the appropriate permissions.
    /// </para></note><para><b>Request options</b></para><para>
    /// Use this operation to make the following types of requests. You can specify values
    /// for the minimum required parameters and customize optional values later.
    /// </para><ul><li><para>
    /// Create a game server container group definition. Provide the following required parameter
    /// values:
    /// </para><ul><li><para><c>Name</c></para></li><li><para><c>ContainerGroupType</c> (<c>GAME_SERVER</c>)
    /// </para></li><li><para><c>OperatingSystem</c> (omit to use default value)
    /// </para></li><li><para><c>TotalMemoryLimitMebibytes</c> (omit to use default value)
    /// </para></li><li><para><c>TotalVcpuLimit </c>(omit to use default value)
    /// </para></li><li><para>
    /// At least one <c>GameServerContainerDefinition</c></para><ul><li><para><c>ContainerName</c></para></li><li><para><c>ImageUrl</c></para></li><li><para><c>PortConfiguration</c></para></li><li><para><c>ServerSdkVersion</c> (omit to use default value)
    /// </para></li></ul></li></ul></li><li><para>
    /// Create a per-instance container group definition. Provide the following required parameter
    /// values:
    /// </para><ul><li><para><c>Name</c></para></li><li><para><c>ContainerGroupType</c> (<c>PER_INSTANCE</c>)
    /// </para></li><li><para><c>OperatingSystem</c> (omit to use default value)
    /// </para></li><li><para><c>TotalMemoryLimitMebibytes</c> (omit to use default value)
    /// </para></li><li><para><c>TotalVcpuLimit </c>(omit to use default value)
    /// </para></li><li><para>
    /// At least one <c>SupportContainerDefinition</c></para><ul><li><para><c>ContainerName</c></para></li><li><para><c>ImageUrl</c></para></li></ul></li></ul></li></ul><para><b>Results</b></para><para>
    /// If successful, this request creates a <c>ContainerGroupDefinition</c> resource and
    /// assigns a unique ARN value. You can update most properties of a container group definition
    /// by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_UpdateContainerGroupDefinition.html">UpdateContainerGroupDefinition</a>,
    /// and optionally save the update as a new version.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GMLContainerGroupDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.ContainerGroupDefinition")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateContainerGroupDefinition API operation.", Operation = new[] {"CreateContainerGroupDefinition"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.ContainerGroupDefinition or Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse",
        "This cmdlet returns an Amazon.GameLift.Model.ContainerGroupDefinition object.",
        "The service call response (type Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGMLContainerGroupDefinitionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContainerGroupType
        /// <summary>
        /// <para>
        /// <para>The type of container group being defined. Container group type determines how Amazon
        /// GameLift Servers deploys the container group on each fleet instance.</para><para>Default value: <c>GAME_SERVER</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.ContainerGroupType")]
        public Amazon.GameLift.ContainerGroupType ContainerGroupType { get; set; }
        #endregion
        
        #region Parameter GameServerContainerDefinition_ContainerName
        /// <summary>
        /// <para>
        /// <para>A string that uniquely identifies the container definition within a container group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameServerContainerDefinition_ContainerName { get; set; }
        #endregion
        
        #region Parameter PortConfiguration_ContainerPortRange
        /// <summary>
        /// <para>
        /// <para>A set of one or more container port number ranges. The ranges can't overlap if the
        /// ranges' network protocols are the same. Overlapping ranges with different protocols
        /// is allowed but not recommended. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GameServerContainerDefinition_PortConfiguration_ContainerPortRanges")]
        public Amazon.GameLift.Model.ContainerPortRange[] PortConfiguration_ContainerPortRange { get; set; }
        #endregion
        
        #region Parameter GameServerContainerDefinition_DependsOn
        /// <summary>
        /// <para>
        /// <para>Establishes dependencies between this container and the status of other containers
        /// in the same container group. A container can have dependencies on multiple different
        /// containers. </para><para>You can use dependencies to establish a startup/shutdown sequence across the container
        /// group. For example, you might specify that <i>ContainerB</i> has a <c>START</c> dependency
        /// on <i>ContainerA</i>. This dependency means that <i>ContainerB</i> can't start until
        /// after <i>ContainerA</i> has started. This dependency is reversed on shutdown, which
        /// means that <i>ContainerB</i> must shut down before <i>ContainerA</i> can shut down.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GameLift.Model.ContainerDependency[] GameServerContainerDefinition_DependsOn { get; set; }
        #endregion
        
        #region Parameter GameServerContainerDefinition_EnvironmentOverride
        /// <summary>
        /// <para>
        /// <para>A set of environment variables to pass to the container on startup. See the <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_ContainerDefinition.html#ECS-Type-ContainerDefinition-environment">ContainerDefinition::environment</a>
        /// parameter in the <i>Amazon Elastic Container Service API Reference</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GameLift.Model.ContainerEnvironment[] GameServerContainerDefinition_EnvironmentOverride { get; set; }
        #endregion
        
        #region Parameter GameServerContainerDefinition_ImageUri
        /// <summary>
        /// <para>
        /// <para>The location of the container image to deploy to a container fleet. Provide an image
        /// in an Amazon Elastic Container Registry public or private repository. The repository
        /// must be in the same Amazon Web Services account and Amazon Web Services Region where
        /// you're creating the container group definition. For limits on image size, see <a href="https://docs.aws.amazon.com/general/latest/gr/gamelift.html">Amazon
        /// GameLift Servers endpoints and quotas</a>. You can use any of the following image
        /// URI formats: </para><ul><li><para>Image ID only: <c>[AWS account].dkr.ecr.[AWS region].amazonaws.com/[repository ID]</c></para></li><li><para>Image ID and digest: <c>[AWS account].dkr.ecr.[AWS region].amazonaws.com/[repository
        /// ID]@[digest]</c></para></li><li><para>Image ID and tag: <c>[AWS account].dkr.ecr.[AWS region].amazonaws.com/[repository
        /// ID]:[tag]</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameServerContainerDefinition_ImageUri { get; set; }
        #endregion
        
        #region Parameter GameServerContainerDefinition_MountPoint
        /// <summary>
        /// <para>
        /// <para>A mount point that binds a path inside the container to a file or directory on the
        /// host system and lets it access the file or directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GameServerContainerDefinition_MountPoints")]
        public Amazon.GameLift.Model.ContainerMountPoint[] GameServerContainerDefinition_MountPoint { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive identifier for the container group definition. The name value must be
        /// unique in an Amazon Web Services Region.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OperatingSystem
        /// <summary>
        /// <para>
        /// <para>The platform that all containers in the group use. Containers in a group must run
        /// on the same operating system.</para><para>Default value: <c>AMAZON_LINUX_2023</c></para><note><para>Amazon Linux 2 (AL2) will reach end of support on 6/30/2026. See more details in the
        /// <a href="http://aws.amazon.com/amazon-linux-2/faqs/">Amazon Linux 2 FAQs</a>. For
        /// game servers that are hosted on AL2 and use server SDK version 4.x for Amazon GameLift
        /// Servers, first update the game server build to server SDK 5.x, and then deploy to
        /// AL2023 instances. See <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-serversdk5-migration.html">
        /// Migrate to server SDK version 5.</a></para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GameLift.ContainerOperatingSystem")]
        public Amazon.GameLift.ContainerOperatingSystem OperatingSystem { get; set; }
        #endregion
        
        #region Parameter GameServerContainerDefinition_ServerSdkVersion
        /// <summary>
        /// <para>
        /// <para>The Amazon GameLift Servers server SDK version that the game server is integrated
        /// with. Only game servers using 5.2.0 or higher are compatible with container fleets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameServerContainerDefinition_ServerSdkVersion { get; set; }
        #endregion
        
        #region Parameter SupportContainerDefinition
        /// <summary>
        /// <para>
        /// <para>One or more definition for support containers in this group. You can define a support
        /// container in any type of container group. You can pass in your container definitions
        /// as a JSON file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportContainerDefinitions")]
        public Amazon.GameLift.Model.SupportContainerDefinitionInput[] SupportContainerDefinition { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of labels to assign to the container group definition resource. Tags are developer-defined
        /// key-value pairs. Tagging Amazon Web Services resources are useful for resource management,
        /// access management and cost allocation. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">
        /// Tagging Amazon Web Services Resources</a> in the <i>Amazon Web Services General Reference</i>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.GameLift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TotalMemoryLimitMebibyte
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory (in MiB) to allocate to the container group. All containers
        /// in the group share this memory. If you specify memory limits for an individual container,
        /// the total value must be greater than any individual container's memory limit.</para><para>Default value: 1024</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TotalMemoryLimitMebibytes")]
        public System.Int32? TotalMemoryLimitMebibyte { get; set; }
        #endregion
        
        #region Parameter TotalVcpuLimit
        /// <summary>
        /// <para>
        /// <para>The maximum amount of vCPU units to allocate to the container group (1 vCPU is equal
        /// to 1024 CPU units). All containers in the group share this memory. If you specify
        /// vCPU limits for individual containers, the total value must be equal to or greater
        /// than the sum of the CPU limits for all containers in the group.</para><para>Default value: 1</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? TotalVcpuLimit { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>A description for the initial version of this container group definition. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContainerGroupDefinition'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContainerGroupDefinition";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLContainerGroupDefinition (CreateContainerGroupDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse, NewGMLContainerGroupDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContainerGroupType = this.ContainerGroupType;
            context.GameServerContainerDefinition_ContainerName = this.GameServerContainerDefinition_ContainerName;
            if (this.GameServerContainerDefinition_DependsOn != null)
            {
                context.GameServerContainerDefinition_DependsOn = new List<Amazon.GameLift.Model.ContainerDependency>(this.GameServerContainerDefinition_DependsOn);
            }
            if (this.GameServerContainerDefinition_EnvironmentOverride != null)
            {
                context.GameServerContainerDefinition_EnvironmentOverride = new List<Amazon.GameLift.Model.ContainerEnvironment>(this.GameServerContainerDefinition_EnvironmentOverride);
            }
            context.GameServerContainerDefinition_ImageUri = this.GameServerContainerDefinition_ImageUri;
            if (this.GameServerContainerDefinition_MountPoint != null)
            {
                context.GameServerContainerDefinition_MountPoint = new List<Amazon.GameLift.Model.ContainerMountPoint>(this.GameServerContainerDefinition_MountPoint);
            }
            if (this.PortConfiguration_ContainerPortRange != null)
            {
                context.PortConfiguration_ContainerPortRange = new List<Amazon.GameLift.Model.ContainerPortRange>(this.PortConfiguration_ContainerPortRange);
            }
            context.GameServerContainerDefinition_ServerSdkVersion = this.GameServerContainerDefinition_ServerSdkVersion;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OperatingSystem = this.OperatingSystem;
            #if MODULAR
            if (this.OperatingSystem == null && ParameterWasBound(nameof(this.OperatingSystem)))
            {
                WriteWarning("You are passing $null as a value for parameter OperatingSystem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SupportContainerDefinition != null)
            {
                context.SupportContainerDefinition = new List<Amazon.GameLift.Model.SupportContainerDefinitionInput>(this.SupportContainerDefinition);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.GameLift.Model.Tag>(this.Tag);
            }
            context.TotalMemoryLimitMebibyte = this.TotalMemoryLimitMebibyte;
            #if MODULAR
            if (this.TotalMemoryLimitMebibyte == null && ParameterWasBound(nameof(this.TotalMemoryLimitMebibyte)))
            {
                WriteWarning("You are passing $null as a value for parameter TotalMemoryLimitMebibyte which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TotalVcpuLimit = this.TotalVcpuLimit;
            #if MODULAR
            if (this.TotalVcpuLimit == null && ParameterWasBound(nameof(this.TotalVcpuLimit)))
            {
                WriteWarning("You are passing $null as a value for parameter TotalVcpuLimit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VersionDescription = this.VersionDescription;
            
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
            var request = new Amazon.GameLift.Model.CreateContainerGroupDefinitionRequest();
            
            if (cmdletContext.ContainerGroupType != null)
            {
                request.ContainerGroupType = cmdletContext.ContainerGroupType;
            }
            
             // populate GameServerContainerDefinition
            var requestGameServerContainerDefinitionIsNull = true;
            request.GameServerContainerDefinition = new Amazon.GameLift.Model.GameServerContainerDefinitionInput();
            System.String requestGameServerContainerDefinition_gameServerContainerDefinition_ContainerName = null;
            if (cmdletContext.GameServerContainerDefinition_ContainerName != null)
            {
                requestGameServerContainerDefinition_gameServerContainerDefinition_ContainerName = cmdletContext.GameServerContainerDefinition_ContainerName;
            }
            if (requestGameServerContainerDefinition_gameServerContainerDefinition_ContainerName != null)
            {
                request.GameServerContainerDefinition.ContainerName = requestGameServerContainerDefinition_gameServerContainerDefinition_ContainerName;
                requestGameServerContainerDefinitionIsNull = false;
            }
            List<Amazon.GameLift.Model.ContainerDependency> requestGameServerContainerDefinition_gameServerContainerDefinition_DependsOn = null;
            if (cmdletContext.GameServerContainerDefinition_DependsOn != null)
            {
                requestGameServerContainerDefinition_gameServerContainerDefinition_DependsOn = cmdletContext.GameServerContainerDefinition_DependsOn;
            }
            if (requestGameServerContainerDefinition_gameServerContainerDefinition_DependsOn != null)
            {
                request.GameServerContainerDefinition.DependsOn = requestGameServerContainerDefinition_gameServerContainerDefinition_DependsOn;
                requestGameServerContainerDefinitionIsNull = false;
            }
            List<Amazon.GameLift.Model.ContainerEnvironment> requestGameServerContainerDefinition_gameServerContainerDefinition_EnvironmentOverride = null;
            if (cmdletContext.GameServerContainerDefinition_EnvironmentOverride != null)
            {
                requestGameServerContainerDefinition_gameServerContainerDefinition_EnvironmentOverride = cmdletContext.GameServerContainerDefinition_EnvironmentOverride;
            }
            if (requestGameServerContainerDefinition_gameServerContainerDefinition_EnvironmentOverride != null)
            {
                request.GameServerContainerDefinition.EnvironmentOverride = requestGameServerContainerDefinition_gameServerContainerDefinition_EnvironmentOverride;
                requestGameServerContainerDefinitionIsNull = false;
            }
            System.String requestGameServerContainerDefinition_gameServerContainerDefinition_ImageUri = null;
            if (cmdletContext.GameServerContainerDefinition_ImageUri != null)
            {
                requestGameServerContainerDefinition_gameServerContainerDefinition_ImageUri = cmdletContext.GameServerContainerDefinition_ImageUri;
            }
            if (requestGameServerContainerDefinition_gameServerContainerDefinition_ImageUri != null)
            {
                request.GameServerContainerDefinition.ImageUri = requestGameServerContainerDefinition_gameServerContainerDefinition_ImageUri;
                requestGameServerContainerDefinitionIsNull = false;
            }
            List<Amazon.GameLift.Model.ContainerMountPoint> requestGameServerContainerDefinition_gameServerContainerDefinition_MountPoint = null;
            if (cmdletContext.GameServerContainerDefinition_MountPoint != null)
            {
                requestGameServerContainerDefinition_gameServerContainerDefinition_MountPoint = cmdletContext.GameServerContainerDefinition_MountPoint;
            }
            if (requestGameServerContainerDefinition_gameServerContainerDefinition_MountPoint != null)
            {
                request.GameServerContainerDefinition.MountPoints = requestGameServerContainerDefinition_gameServerContainerDefinition_MountPoint;
                requestGameServerContainerDefinitionIsNull = false;
            }
            System.String requestGameServerContainerDefinition_gameServerContainerDefinition_ServerSdkVersion = null;
            if (cmdletContext.GameServerContainerDefinition_ServerSdkVersion != null)
            {
                requestGameServerContainerDefinition_gameServerContainerDefinition_ServerSdkVersion = cmdletContext.GameServerContainerDefinition_ServerSdkVersion;
            }
            if (requestGameServerContainerDefinition_gameServerContainerDefinition_ServerSdkVersion != null)
            {
                request.GameServerContainerDefinition.ServerSdkVersion = requestGameServerContainerDefinition_gameServerContainerDefinition_ServerSdkVersion;
                requestGameServerContainerDefinitionIsNull = false;
            }
            Amazon.GameLift.Model.ContainerPortConfiguration requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration = null;
            
             // populate PortConfiguration
            var requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfigurationIsNull = true;
            requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration = new Amazon.GameLift.Model.ContainerPortConfiguration();
            List<Amazon.GameLift.Model.ContainerPortRange> requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration_portConfiguration_ContainerPortRange = null;
            if (cmdletContext.PortConfiguration_ContainerPortRange != null)
            {
                requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration_portConfiguration_ContainerPortRange = cmdletContext.PortConfiguration_ContainerPortRange;
            }
            if (requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration_portConfiguration_ContainerPortRange != null)
            {
                requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration.ContainerPortRanges = requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration_portConfiguration_ContainerPortRange;
                requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfigurationIsNull = false;
            }
             // determine if requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration should be set to null
            if (requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfigurationIsNull)
            {
                requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration = null;
            }
            if (requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration != null)
            {
                request.GameServerContainerDefinition.PortConfiguration = requestGameServerContainerDefinition_gameServerContainerDefinition_PortConfiguration;
                requestGameServerContainerDefinitionIsNull = false;
            }
             // determine if request.GameServerContainerDefinition should be set to null
            if (requestGameServerContainerDefinitionIsNull)
            {
                request.GameServerContainerDefinition = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OperatingSystem != null)
            {
                request.OperatingSystem = cmdletContext.OperatingSystem;
            }
            if (cmdletContext.SupportContainerDefinition != null)
            {
                request.SupportContainerDefinitions = cmdletContext.SupportContainerDefinition;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TotalMemoryLimitMebibyte != null)
            {
                request.TotalMemoryLimitMebibytes = cmdletContext.TotalMemoryLimitMebibyte.Value;
            }
            if (cmdletContext.TotalVcpuLimit != null)
            {
                request.TotalVcpuLimit = cmdletContext.TotalVcpuLimit.Value;
            }
            if (cmdletContext.VersionDescription != null)
            {
                request.VersionDescription = cmdletContext.VersionDescription;
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
        
        private Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateContainerGroupDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateContainerGroupDefinition");
            try
            {
                #if DESKTOP
                return client.CreateContainerGroupDefinition(request);
                #elif CORECLR
                return client.CreateContainerGroupDefinitionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.GameLift.ContainerGroupType ContainerGroupType { get; set; }
            public System.String GameServerContainerDefinition_ContainerName { get; set; }
            public List<Amazon.GameLift.Model.ContainerDependency> GameServerContainerDefinition_DependsOn { get; set; }
            public List<Amazon.GameLift.Model.ContainerEnvironment> GameServerContainerDefinition_EnvironmentOverride { get; set; }
            public System.String GameServerContainerDefinition_ImageUri { get; set; }
            public List<Amazon.GameLift.Model.ContainerMountPoint> GameServerContainerDefinition_MountPoint { get; set; }
            public List<Amazon.GameLift.Model.ContainerPortRange> PortConfiguration_ContainerPortRange { get; set; }
            public System.String GameServerContainerDefinition_ServerSdkVersion { get; set; }
            public System.String Name { get; set; }
            public Amazon.GameLift.ContainerOperatingSystem OperatingSystem { get; set; }
            public List<Amazon.GameLift.Model.SupportContainerDefinitionInput> SupportContainerDefinition { get; set; }
            public List<Amazon.GameLift.Model.Tag> Tag { get; set; }
            public System.Int32? TotalMemoryLimitMebibyte { get; set; }
            public System.Double? TotalVcpuLimit { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse, NewGMLContainerGroupDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerGroupDefinition;
        }
        
    }
}
