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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// <b>This operation is used with the Amazon GameLift containers feature, which is currently
    /// in public preview. </b><para>
    /// Creates a <c>ContainerGroupDefinition</c> resource that describes a set of containers
    /// for hosting your game server with Amazon GameLift managed EC2 hosting. An Amazon GameLift
    /// container group is similar to a container "task" and "pod". Each container group can
    /// have one or more containers. 
    /// </para><para>
    /// Use container group definitions when you create a container fleet. Container group
    /// definitions determine how Amazon GameLift deploys your containers to each instance
    /// in a container fleet. 
    /// </para><para>
    /// You can create two types of container groups, based on scheduling strategy:
    /// </para><ul><li><para>
    /// A <b>replica container group</b> manages the containers that run your game server
    /// application and supporting software. Replica container groups might be replicated
    /// multiple times on each fleet instance, depending on instance resources. 
    /// </para></li><li><para>
    /// A <b>daemon container group</b> manages containers that run other software, such as
    /// background services, logging, or test processes. You might use a daemon container
    /// group for processes that need to run only once per fleet instance, or processes that
    /// need to persist independently of the replica container group. 
    /// </para></li></ul><para>
    /// To create a container group definition, specify a group name, a list of container
    /// definitions, and maximum total CPU and memory requirements for the container group.
    /// Specify an operating system and scheduling strategy or use the default values. When
    /// using the Amazon Web Services CLI tool, you can pass in your container definitions
    /// as a JSON file.
    /// </para><note><para>
    /// This operation requires Identity and Access Management (IAM) permissions to access
    /// container images in Amazon ECR repositories. See <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-iam-policy-examples.html">
    /// IAM permissions for Amazon GameLift</a> for help setting the appropriate permissions.
    /// </para></note><para>
    /// If successful, this operation creates a new <c>ContainerGroupDefinition</c> resource
    /// with an ARN value assigned. You can't change the properties of a container group definition.
    /// Instead, create a new one. 
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/containers-create-groups.html">Create
    /// a container group definition</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/containers-design-fleet.html">Container
    /// fleet design guide</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/containers-definitions.html#containers-definitions-create">Create
    /// a container definition as a JSON file</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLContainerGroupDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.ContainerGroupDefinition")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateContainerGroupDefinition API operation.", Operation = new[] {"CreateContainerGroupDefinition"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.ContainerGroupDefinition or Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse",
        "This cmdlet returns an Amazon.GameLift.Model.ContainerGroupDefinition object.",
        "The service call response (type Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLContainerGroupDefinitionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContainerDefinition
        /// <summary>
        /// <para>
        /// <para>Definitions for all containers in this group. Each container definition identifies
        /// the container image and specifies configuration settings for the container. See the
        /// <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/containers-design-fleet.html">
        /// Container fleet design guide</a> for container guidelines.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ContainerDefinitions")]
        public Amazon.GameLift.Model.ContainerDefinitionInput[] ContainerDefinition { get; set; }
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
        /// <para>The platform that is used by containers in the container group definition. All containers
        /// in a group must run on the same operating system.</para><note><para>Amazon Linux 2 (AL2) will reach end of support on 6/30/2025. See more details in the
        /// <a href="https://aws.amazon.com/amazon-linux-2/faqs/">Amazon Linux 2 FAQs</a>. For
        /// game servers that are hosted on AL2 and use Amazon GameLift server SDK 4.x., first
        /// update the game server build to server SDK 5.x, and then deploy to AL2023 instances.
        /// See <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-serversdk5-migration.html">
        /// Migrate to Amazon GameLift server SDK version 5.</a></para></note>
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
        
        #region Parameter SchedulingStrategy
        /// <summary>
        /// <para>
        /// <para>The method for deploying the container group across fleet instances. A replica container
        /// group might have multiple copies on each fleet instance. A daemon container group
        /// has one copy per fleet instance. Default value is <c>REPLICA</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.ContainerSchedulingStrategy")]
        public Amazon.GameLift.ContainerSchedulingStrategy SchedulingStrategy { get; set; }
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
        
        #region Parameter TotalCpuLimit
        /// <summary>
        /// <para>
        /// <para>The maximum amount of CPU units to allocate to the container group. Set this parameter
        /// to an integer value in CPU units (1 vCPU is equal to 1024 CPU units). All containers
        /// in the group share this memory. If you specify CPU limits for individual containers,
        /// set this parameter based on the following guidelines. The value must be equal to or
        /// greater than the sum of the CPU limits for all containers in the group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TotalCpuLimit { get; set; }
        #endregion
        
        #region Parameter TotalMemoryLimit
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory (in MiB) to allocate to the container group. All containers
        /// in the group share this memory. If you specify memory limits for individual containers,
        /// set this parameter based on the following guidelines. The value must be (1) greater
        /// than the sum of the soft memory limits for all containers in the group, and (2) greater
        /// than any individual container's hard memory limit.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TotalMemoryLimit { get; set; }
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
            if (this.ContainerDefinition != null)
            {
                context.ContainerDefinition = new List<Amazon.GameLift.Model.ContainerDefinitionInput>(this.ContainerDefinition);
            }
            #if MODULAR
            if (this.ContainerDefinition == null && ParameterWasBound(nameof(this.ContainerDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.SchedulingStrategy = this.SchedulingStrategy;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.GameLift.Model.Tag>(this.Tag);
            }
            context.TotalCpuLimit = this.TotalCpuLimit;
            #if MODULAR
            if (this.TotalCpuLimit == null && ParameterWasBound(nameof(this.TotalCpuLimit)))
            {
                WriteWarning("You are passing $null as a value for parameter TotalCpuLimit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TotalMemoryLimit = this.TotalMemoryLimit;
            #if MODULAR
            if (this.TotalMemoryLimit == null && ParameterWasBound(nameof(this.TotalMemoryLimit)))
            {
                WriteWarning("You are passing $null as a value for parameter TotalMemoryLimit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLift.Model.CreateContainerGroupDefinitionRequest();
            
            if (cmdletContext.ContainerDefinition != null)
            {
                request.ContainerDefinitions = cmdletContext.ContainerDefinition;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OperatingSystem != null)
            {
                request.OperatingSystem = cmdletContext.OperatingSystem;
            }
            if (cmdletContext.SchedulingStrategy != null)
            {
                request.SchedulingStrategy = cmdletContext.SchedulingStrategy;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TotalCpuLimit != null)
            {
                request.TotalCpuLimit = cmdletContext.TotalCpuLimit.Value;
            }
            if (cmdletContext.TotalMemoryLimit != null)
            {
                request.TotalMemoryLimit = cmdletContext.TotalMemoryLimit.Value;
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
            public List<Amazon.GameLift.Model.ContainerDefinitionInput> ContainerDefinition { get; set; }
            public System.String Name { get; set; }
            public Amazon.GameLift.ContainerOperatingSystem OperatingSystem { get; set; }
            public Amazon.GameLift.ContainerSchedulingStrategy SchedulingStrategy { get; set; }
            public List<Amazon.GameLift.Model.Tag> Tag { get; set; }
            public System.Int32? TotalCpuLimit { get; set; }
            public System.Int32? TotalMemoryLimit { get; set; }
            public System.Func<Amazon.GameLift.Model.CreateContainerGroupDefinitionResponse, NewGMLContainerGroupDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerGroupDefinition;
        }
        
    }
}
