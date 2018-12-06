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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Creates an AWS Batch compute environment. You can create <code>MANAGED</code> or <code>UNMANAGED</code>
    /// compute environments.
    /// 
    ///  
    /// <para>
    /// In a managed compute environment, AWS Batch manages the capacity and instance types
    /// of the compute resources within the environment. This is based on the compute resource
    /// specification that you define or the <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html">launch
    /// template</a> that you specify when you create the compute environment. You can choose
    /// to use Amazon EC2 On-Demand Instances or Spot Instances in your managed compute environment.
    /// You can optionally set a maximum price so that Spot Instances only launch when the
    /// Spot Instance price is below a specified percentage of the On-Demand price.
    /// </para><note><para>
    /// Multi-node parallel jobs are not supported on Spot Instances.
    /// </para></note><para>
    /// In an unmanaged compute environment, you can manage your own compute resources. This
    /// provides more compute resource configuration options, such as using a custom AMI,
    /// but you must ensure that your AMI meets the Amazon ECS container instance AMI specification.
    /// For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/container_instance_AMIs.html">Container
    /// Instance AMIs</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// After you have created your unmanaged compute environment, you can use the <a>DescribeComputeEnvironments</a>
    /// operation to find the Amazon ECS cluster that is associated with it. Then, manually
    /// launch your container instances into that Amazon ECS cluster. For more information,
    /// see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/launch_container_instance.html">Launching
    /// an Amazon ECS Container Instance</a> in the <i>Amazon Elastic Container Service Developer
    /// Guide</i>.
    /// </para><note><para>
    /// AWS Batch does not upgrade the AMIs in a compute environment after it is created (for
    /// example, when a newer version of the Amazon ECS-optimized AMI is available). You are
    /// responsible for the management of the guest operating system (including updates and
    /// security patches) and any additional application software or utilities that you install
    /// on the compute resources. To use a new AMI for your AWS Batch jobs:
    /// </para><ol><li><para>
    /// Create a new compute environment with the new AMI.
    /// </para></li><li><para>
    /// Add the compute environment to an existing job queue.
    /// </para></li><li><para>
    /// Remove the old compute environment from your job queue.
    /// </para></li><li><para>
    /// Delete the old compute environment.
    /// </para></li></ol></note>
    /// </summary>
    [Cmdlet("New", "BATComputeEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.CreateComputeEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Batch CreateComputeEnvironment API operation.", Operation = new[] {"CreateComputeEnvironment"})]
    [AWSCmdletOutput("Amazon.Batch.Model.CreateComputeEnvironmentResponse",
        "This cmdlet returns a Amazon.Batch.Model.CreateComputeEnvironmentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBATComputeEnvironmentCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        #region Parameter ComputeResources_BidPercentage
        /// <summary>
        /// <para>
        /// <para>The maximum percentage that a Spot Instance price can be when compared with the On-Demand
        /// price for that instance type before instances are launched. For example, if your maximum
        /// percentage is 20%, then the Spot price must be below 20% of the current On-Demand
        /// price for that EC2 instance. You always pay the lowest (market) price and never more
        /// than your maximum percentage. If you leave this field empty, the default value is
        /// 100% of the On-Demand price.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ComputeResources_BidPercentage { get; set; }
        #endregion
        
        #region Parameter ComputeEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name for your compute environment. Up to 128 letters (uppercase and lowercase),
        /// numbers, hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ComputeEnvironmentName { get; set; }
        #endregion
        
        #region Parameter ComputeResources_DesiredvCpu
        /// <summary>
        /// <para>
        /// <para>The desired number of EC2 vCPUS in the compute environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_DesiredvCpus")]
        public System.Int32 ComputeResources_DesiredvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Ec2KeyPair
        /// <summary>
        /// <para>
        /// <para>The EC2 key pair that is used for instances launched in the compute environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ComputeResources_Ec2KeyPair { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ImageId
        /// <summary>
        /// <para>
        /// <para>The Amazon Machine Image (AMI) ID used for instances launched in the compute environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ComputeResources_ImageId { get; set; }
        #endregion
        
        #region Parameter ComputeResources_InstanceRole
        /// <summary>
        /// <para>
        /// <para>The Amazon ECS instance profile applied to Amazon EC2 instances in a compute environment.
        /// You can specify the short name or full Amazon Resource Name (ARN) of an instance profile.
        /// For example, <code>ecsInstanceRole</code> or <code>arn:aws:iam::&lt;aws_account_id&gt;:instance-profile/ecsInstanceRole</code>.
        /// For more information, see <a href="http://docs.aws.amazon.com/batch/latest/userguide/instance_IAM_role.html">Amazon
        /// ECS Instance Role</a> in the <i>AWS Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ComputeResources_InstanceRole { get; set; }
        #endregion
        
        #region Parameter ComputeResources_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instances types that may be launched. You can specify instance families to launch
        /// any instance type within those families (for example, <code>c4</code> or <code>p3</code>),
        /// or you can specify specific sizes within a family (such as <code>c4.8xlarge</code>).
        /// You can also choose <code>optimal</code> to pick instance types (from the latest C,
        /// M, and R instance families) on the fly that match the demand of your job queues.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_InstanceTypes")]
        public System.String[] ComputeResources_InstanceType { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_LaunchTemplate_LaunchTemplateId")]
        public System.String LaunchTemplate_LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_LaunchTemplate_LaunchTemplateName")]
        public System.String LaunchTemplate_LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter ComputeResources_MaxvCpu
        /// <summary>
        /// <para>
        /// <para>The maximum number of EC2 vCPUs that an environment can reach. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_MaxvCpus")]
        public System.Int32 ComputeResources_MaxvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_MinvCpu
        /// <summary>
        /// <para>
        /// <para>The minimum number of EC2 vCPUs that an environment should maintain (even if the compute
        /// environment is <code>DISABLED</code>). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_MinvCpus")]
        public System.Int32 ComputeResources_MinvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_PlacementGroup
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 placement group to associate with your compute resources. If you intend
        /// to submit multi-node parallel jobs to your compute environment, you should consider
        /// creating a cluster placement group and associate it with your compute resources. This
        /// keeps your multi-node parallel job on a logical grouping of instances within a single
        /// Availability Zone with high network flow potential. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">Placement
        /// Groups</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ComputeResources_PlacementGroup { get; set; }
        #endregion
        
        #region Parameter ComputeResources_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The EC2 security group that is associated with instances launched in the compute environment.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_SecurityGroupIds")]
        public System.String[] ComputeResources_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The full Amazon Resource Name (ARN) of the IAM role that allows AWS Batch to make
        /// calls to other AWS services on your behalf.</para><para>If your specified role has a path other than <code>/</code>, then you must either
        /// specify the full role ARN (this is recommended) or prefix the role name with the path.</para><note><para>Depending on how you created your AWS Batch service role, its ARN may contain the
        /// <code>service-role</code> path prefix. When you only specify the name of the service
        /// role, AWS Batch assumes that your ARN does not use the <code>service-role</code> path
        /// prefix. Because of this, we recommend that you specify the full ARN of your service
        /// role when you create compute environments.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter ComputeResources_SpotIamFleetRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon EC2 Spot Fleet IAM role applied to a
        /// <code>SPOT</code> compute environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ComputeResources_SpotIamFleetRole { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the compute environment. If the state is <code>ENABLED</code>, then the
        /// compute environment accepts jobs from a queue and can scale out automatically based
        /// on queues.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Batch.CEState")]
        public Amazon.Batch.CEState State { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Subnet
        /// <summary>
        /// <para>
        /// <para>The VPC subnets into which the compute resources are launched. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_Subnets")]
        public System.String[] ComputeResources_Subnet { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pair tags to be applied to resources that are launched in the compute environment.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_Tags")]
        public System.Collections.Hashtable ComputeResources_Tag { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Type
        /// <summary>
        /// <para>
        /// <para>The type of compute environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Batch.CRType")]
        public Amazon.Batch.CRType ComputeResources_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the compute environment. For more information, see <a href="http://docs.aws.amazon.com/batch/latest/userguide/compute_environments.html">Compute
        /// Environments</a> in the <i>AWS Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Batch.CEType")]
        public Amazon.Batch.CEType Type { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number of the launch template.</para><para>Default: The default version of the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_LaunchTemplate_Version")]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ComputeEnvironmentName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BATComputeEnvironment (CreateComputeEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ComputeEnvironmentName = this.ComputeEnvironmentName;
            if (ParameterWasBound("ComputeResources_BidPercentage"))
                context.ComputeResources_BidPercentage = this.ComputeResources_BidPercentage;
            if (ParameterWasBound("ComputeResources_DesiredvCpu"))
                context.ComputeResources_DesiredvCpus = this.ComputeResources_DesiredvCpu;
            context.ComputeResources_Ec2KeyPair = this.ComputeResources_Ec2KeyPair;
            context.ComputeResources_ImageId = this.ComputeResources_ImageId;
            context.ComputeResources_InstanceRole = this.ComputeResources_InstanceRole;
            if (this.ComputeResources_InstanceType != null)
            {
                context.ComputeResources_InstanceTypes = new List<System.String>(this.ComputeResources_InstanceType);
            }
            context.ComputeResources_LaunchTemplate_LaunchTemplateId = this.LaunchTemplate_LaunchTemplateId;
            context.ComputeResources_LaunchTemplate_LaunchTemplateName = this.LaunchTemplate_LaunchTemplateName;
            context.ComputeResources_LaunchTemplate_Version = this.LaunchTemplate_Version;
            if (ParameterWasBound("ComputeResources_MaxvCpu"))
                context.ComputeResources_MaxvCpus = this.ComputeResources_MaxvCpu;
            if (ParameterWasBound("ComputeResources_MinvCpu"))
                context.ComputeResources_MinvCpus = this.ComputeResources_MinvCpu;
            context.ComputeResources_PlacementGroup = this.ComputeResources_PlacementGroup;
            if (this.ComputeResources_SecurityGroupId != null)
            {
                context.ComputeResources_SecurityGroupIds = new List<System.String>(this.ComputeResources_SecurityGroupId);
            }
            context.ComputeResources_SpotIamFleetRole = this.ComputeResources_SpotIamFleetRole;
            if (this.ComputeResources_Subnet != null)
            {
                context.ComputeResources_Subnets = new List<System.String>(this.ComputeResources_Subnet);
            }
            if (this.ComputeResources_Tag != null)
            {
                context.ComputeResources_Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComputeResources_Tag.Keys)
                {
                    context.ComputeResources_Tags.Add((String)hashKey, (String)(this.ComputeResources_Tag[hashKey]));
                }
            }
            context.ComputeResources_Type = this.ComputeResources_Type;
            context.ServiceRole = this.ServiceRole;
            context.State = this.State;
            context.Type = this.Type;
            
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
            var request = new Amazon.Batch.Model.CreateComputeEnvironmentRequest();
            
            if (cmdletContext.ComputeEnvironmentName != null)
            {
                request.ComputeEnvironmentName = cmdletContext.ComputeEnvironmentName;
            }
            
             // populate ComputeResources
            bool requestComputeResourcesIsNull = true;
            request.ComputeResources = new Amazon.Batch.Model.ComputeResource();
            System.Int32? requestComputeResources_computeResources_BidPercentage = null;
            if (cmdletContext.ComputeResources_BidPercentage != null)
            {
                requestComputeResources_computeResources_BidPercentage = cmdletContext.ComputeResources_BidPercentage.Value;
            }
            if (requestComputeResources_computeResources_BidPercentage != null)
            {
                request.ComputeResources.BidPercentage = requestComputeResources_computeResources_BidPercentage.Value;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_DesiredvCpu = null;
            if (cmdletContext.ComputeResources_DesiredvCpus != null)
            {
                requestComputeResources_computeResources_DesiredvCpu = cmdletContext.ComputeResources_DesiredvCpus.Value;
            }
            if (requestComputeResources_computeResources_DesiredvCpu != null)
            {
                request.ComputeResources.DesiredvCpus = requestComputeResources_computeResources_DesiredvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_Ec2KeyPair = null;
            if (cmdletContext.ComputeResources_Ec2KeyPair != null)
            {
                requestComputeResources_computeResources_Ec2KeyPair = cmdletContext.ComputeResources_Ec2KeyPair;
            }
            if (requestComputeResources_computeResources_Ec2KeyPair != null)
            {
                request.ComputeResources.Ec2KeyPair = requestComputeResources_computeResources_Ec2KeyPair;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_ImageId = null;
            if (cmdletContext.ComputeResources_ImageId != null)
            {
                requestComputeResources_computeResources_ImageId = cmdletContext.ComputeResources_ImageId;
            }
            if (requestComputeResources_computeResources_ImageId != null)
            {
                request.ComputeResources.ImageId = requestComputeResources_computeResources_ImageId;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_InstanceRole = null;
            if (cmdletContext.ComputeResources_InstanceRole != null)
            {
                requestComputeResources_computeResources_InstanceRole = cmdletContext.ComputeResources_InstanceRole;
            }
            if (requestComputeResources_computeResources_InstanceRole != null)
            {
                request.ComputeResources.InstanceRole = requestComputeResources_computeResources_InstanceRole;
                requestComputeResourcesIsNull = false;
            }
            List<System.String> requestComputeResources_computeResources_InstanceType = null;
            if (cmdletContext.ComputeResources_InstanceTypes != null)
            {
                requestComputeResources_computeResources_InstanceType = cmdletContext.ComputeResources_InstanceTypes;
            }
            if (requestComputeResources_computeResources_InstanceType != null)
            {
                request.ComputeResources.InstanceTypes = requestComputeResources_computeResources_InstanceType;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_MaxvCpu = null;
            if (cmdletContext.ComputeResources_MaxvCpus != null)
            {
                requestComputeResources_computeResources_MaxvCpu = cmdletContext.ComputeResources_MaxvCpus.Value;
            }
            if (requestComputeResources_computeResources_MaxvCpu != null)
            {
                request.ComputeResources.MaxvCpus = requestComputeResources_computeResources_MaxvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_MinvCpu = null;
            if (cmdletContext.ComputeResources_MinvCpus != null)
            {
                requestComputeResources_computeResources_MinvCpu = cmdletContext.ComputeResources_MinvCpus.Value;
            }
            if (requestComputeResources_computeResources_MinvCpu != null)
            {
                request.ComputeResources.MinvCpus = requestComputeResources_computeResources_MinvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_PlacementGroup = null;
            if (cmdletContext.ComputeResources_PlacementGroup != null)
            {
                requestComputeResources_computeResources_PlacementGroup = cmdletContext.ComputeResources_PlacementGroup;
            }
            if (requestComputeResources_computeResources_PlacementGroup != null)
            {
                request.ComputeResources.PlacementGroup = requestComputeResources_computeResources_PlacementGroup;
                requestComputeResourcesIsNull = false;
            }
            List<System.String> requestComputeResources_computeResources_SecurityGroupId = null;
            if (cmdletContext.ComputeResources_SecurityGroupIds != null)
            {
                requestComputeResources_computeResources_SecurityGroupId = cmdletContext.ComputeResources_SecurityGroupIds;
            }
            if (requestComputeResources_computeResources_SecurityGroupId != null)
            {
                request.ComputeResources.SecurityGroupIds = requestComputeResources_computeResources_SecurityGroupId;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_SpotIamFleetRole = null;
            if (cmdletContext.ComputeResources_SpotIamFleetRole != null)
            {
                requestComputeResources_computeResources_SpotIamFleetRole = cmdletContext.ComputeResources_SpotIamFleetRole;
            }
            if (requestComputeResources_computeResources_SpotIamFleetRole != null)
            {
                request.ComputeResources.SpotIamFleetRole = requestComputeResources_computeResources_SpotIamFleetRole;
                requestComputeResourcesIsNull = false;
            }
            List<System.String> requestComputeResources_computeResources_Subnet = null;
            if (cmdletContext.ComputeResources_Subnets != null)
            {
                requestComputeResources_computeResources_Subnet = cmdletContext.ComputeResources_Subnets;
            }
            if (requestComputeResources_computeResources_Subnet != null)
            {
                request.ComputeResources.Subnets = requestComputeResources_computeResources_Subnet;
                requestComputeResourcesIsNull = false;
            }
            Dictionary<System.String, System.String> requestComputeResources_computeResources_Tag = null;
            if (cmdletContext.ComputeResources_Tags != null)
            {
                requestComputeResources_computeResources_Tag = cmdletContext.ComputeResources_Tags;
            }
            if (requestComputeResources_computeResources_Tag != null)
            {
                request.ComputeResources.Tags = requestComputeResources_computeResources_Tag;
                requestComputeResourcesIsNull = false;
            }
            Amazon.Batch.CRType requestComputeResources_computeResources_Type = null;
            if (cmdletContext.ComputeResources_Type != null)
            {
                requestComputeResources_computeResources_Type = cmdletContext.ComputeResources_Type;
            }
            if (requestComputeResources_computeResources_Type != null)
            {
                request.ComputeResources.Type = requestComputeResources_computeResources_Type;
                requestComputeResourcesIsNull = false;
            }
            Amazon.Batch.Model.LaunchTemplateSpecification requestComputeResources_computeResources_LaunchTemplate = null;
            
             // populate LaunchTemplate
            bool requestComputeResources_computeResources_LaunchTemplateIsNull = true;
            requestComputeResources_computeResources_LaunchTemplate = new Amazon.Batch.Model.LaunchTemplateSpecification();
            System.String requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateId = null;
            if (cmdletContext.ComputeResources_LaunchTemplate_LaunchTemplateId != null)
            {
                requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateId = cmdletContext.ComputeResources_LaunchTemplate_LaunchTemplateId;
            }
            if (requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateId != null)
            {
                requestComputeResources_computeResources_LaunchTemplate.LaunchTemplateId = requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateId;
                requestComputeResources_computeResources_LaunchTemplateIsNull = false;
            }
            System.String requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateName = null;
            if (cmdletContext.ComputeResources_LaunchTemplate_LaunchTemplateName != null)
            {
                requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateName = cmdletContext.ComputeResources_LaunchTemplate_LaunchTemplateName;
            }
            if (requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateName != null)
            {
                requestComputeResources_computeResources_LaunchTemplate.LaunchTemplateName = requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateName;
                requestComputeResources_computeResources_LaunchTemplateIsNull = false;
            }
            System.String requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Version = null;
            if (cmdletContext.ComputeResources_LaunchTemplate_Version != null)
            {
                requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Version = cmdletContext.ComputeResources_LaunchTemplate_Version;
            }
            if (requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Version != null)
            {
                requestComputeResources_computeResources_LaunchTemplate.Version = requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Version;
                requestComputeResources_computeResources_LaunchTemplateIsNull = false;
            }
             // determine if requestComputeResources_computeResources_LaunchTemplate should be set to null
            if (requestComputeResources_computeResources_LaunchTemplateIsNull)
            {
                requestComputeResources_computeResources_LaunchTemplate = null;
            }
            if (requestComputeResources_computeResources_LaunchTemplate != null)
            {
                request.ComputeResources.LaunchTemplate = requestComputeResources_computeResources_LaunchTemplate;
                requestComputeResourcesIsNull = false;
            }
             // determine if request.ComputeResources should be set to null
            if (requestComputeResourcesIsNull)
            {
                request.ComputeResources = null;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Batch.Model.CreateComputeEnvironmentResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.CreateComputeEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "CreateComputeEnvironment");
            try
            {
                #if DESKTOP
                return client.CreateComputeEnvironment(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateComputeEnvironmentAsync(request);
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
            public System.String ComputeEnvironmentName { get; set; }
            public System.Int32? ComputeResources_BidPercentage { get; set; }
            public System.Int32? ComputeResources_DesiredvCpus { get; set; }
            public System.String ComputeResources_Ec2KeyPair { get; set; }
            public System.String ComputeResources_ImageId { get; set; }
            public System.String ComputeResources_InstanceRole { get; set; }
            public List<System.String> ComputeResources_InstanceTypes { get; set; }
            public System.String ComputeResources_LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String ComputeResources_LaunchTemplate_LaunchTemplateName { get; set; }
            public System.String ComputeResources_LaunchTemplate_Version { get; set; }
            public System.Int32? ComputeResources_MaxvCpus { get; set; }
            public System.Int32? ComputeResources_MinvCpus { get; set; }
            public System.String ComputeResources_PlacementGroup { get; set; }
            public List<System.String> ComputeResources_SecurityGroupIds { get; set; }
            public System.String ComputeResources_SpotIamFleetRole { get; set; }
            public List<System.String> ComputeResources_Subnets { get; set; }
            public Dictionary<System.String, System.String> ComputeResources_Tags { get; set; }
            public Amazon.Batch.CRType ComputeResources_Type { get; set; }
            public System.String ServiceRole { get; set; }
            public Amazon.Batch.CEState State { get; set; }
            public Amazon.Batch.CEType Type { get; set; }
        }
        
    }
}
