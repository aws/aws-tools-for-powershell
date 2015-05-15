/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// RunJobFlow creates and starts running a new job flow. The job flow will run the steps
    /// specified. Once the job flow completes, the cluster is stopped and the HDFS partition
    /// is lost. To prevent loss of data, configure the last step of the job flow to store
    /// results in Amazon S3. If the <a>JobFlowInstancesConfig</a><code>KeepJobFlowAliveWhenNoSteps</code>
    /// parameter is set to <code>TRUE</code>, the job flow will transition to the WAITING
    /// state rather than shutting down once the steps have completed. 
    /// 
    ///  
    /// <para>
    /// For additional protection, you can set the <a>JobFlowInstancesConfig</a><code>TerminationProtected</code>
    /// parameter to <code>TRUE</code> to lock the job flow and prevent it from being terminated
    /// by API call, user intervention, or in the event of a job flow error.
    /// </para><para>
    /// A maximum of 256 steps are allowed in each job flow.
    /// </para><para>
    /// If your job flow is long-running (such as a Hive data warehouse) or complex, you may
    /// require more than 256 steps to process your data. You can bypass the 256-step limitation
    /// in various ways, including using the SSH shell to connect to the master node and submitting
    /// queries directly to the software running on the master node, such as Hive and Hadoop.
    /// For more information on how to do this, go to <a href="http://docs.aws.amazon.com/ElasticMapReduce/latest/DeveloperGuide/AddMoreThan256Steps.html">Add
    /// More than 256 Steps to a Job Flow</a> in the <i>Amazon Elastic MapReduce Developer's
    /// Guide</i>.
    /// </para><para>
    /// For long running job flows, we recommend that you periodically store your results.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "EMRJobFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RunJobFlow operation against Amazon Elastic MapReduce.", Operation = new[] {"RunJobFlow"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type RunJobFlowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class StartEMRJobFlowCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A JSON string for selecting additional features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AdditionalInfo { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of additional Amazon EC2 security group IDs for the master node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Instances_AdditionalMasterSecurityGroups")]
        public System.String[] Instances_AdditionalMasterSecurityGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of additional Amazon EC2 security group IDs for the slave nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Instances_AdditionalSlaveSecurityGroups")]
        public System.String[] Instances_AdditionalSlaveSecurityGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The version of the Amazon Machine Image (AMI) to use when launching Amazon EC2 instances
        /// in the job flow. The following values are valid: </para><ul><li>"latest" (uses the latest AMI)</li><li>The version number of the AMI to
        /// use, for example, "2.0"</li></ul><para>If the AMI supports multiple versions of Hadoop (for example, AMI 1.0 supports both
        /// Hadoop 0.18 and 0.20) you can use the <a>JobFlowInstancesConfig</a><code>HadoopVersion</code>
        /// parameter to modify the version of Hadoop from the defaults shown above.</para><para>For details about the AMI versions currently supported by Amazon Elastic MapReduce,
        /// go to <a href="http://docs.aws.amazon.com/ElasticMapReduce/latest/DeveloperGuide/EnvironmentConfig_AMIVersion.html#ami-versions-supported">AMI
        /// Versions Supported in Elastic MapReduce</a> in the <i>Amazon Elastic MapReduce Developer's
        /// Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AmiVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 Availability Zone for the job flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Instances_Placement_AvailabilityZone")]
        public String Placement_AvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A list of bootstrap actions that will be run before Hadoop is started on the cluster
        /// nodes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BootstrapActions")]
        public Amazon.ElasticMapReduce.Model.BootstrapActionConfig[] BootstrapAction { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon EC2 key pair that can be used to ssh to the master node as
        /// the user called "hadoop."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Instances_Ec2KeyName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> To launch the job flow in Amazon Virtual Private Cloud (Amazon VPC), set this parameter
        /// to the identifier of the Amazon VPC subnet where you want the job flow to launch.
        /// If you do not specify this value, the job flow is launched in the normal Amazon Web
        /// Services cloud, outside of an Amazon VPC. </para><para> Amazon VPC currently does not support cluster compute quadruple extra large (cc1.4xlarge)
        /// instances. Thus you cannot specify the cc1.4xlarge instance type for nodes of a job
        /// flow launched in a Amazon VPC. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Instances_Ec2SubnetId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon EC2 security group (managed by Amazon ElasticMapReduce)
        /// for the master node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Instances_EmrManagedMasterSecurityGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon EC2 security group (managed by Amazon ElasticMapReduce)
        /// for the slave nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Instances_EmrManagedSlaveSecurityGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Hadoop version for the job flow. Valid inputs are "0.18", "0.20", "0.20.205",
        /// "1.0.3", "2.2.0", or "2.4.0". If you do not set this value, the default of 0.18 is
        /// used, unless the AmiVersion parameter is set in the RunJobFlow call, in which case
        /// the default version of Hadoop for that AMI version is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Instances_HadoopVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of Amazon EC2 instances used to execute the job flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Instances_InstanceCount { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Configuration for the job flow's instance groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Instances_InstanceGroups")]
        public Amazon.ElasticMapReduce.Model.InstanceGroupConfig[] Instances_InstanceGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An IAM role for the job flow. The EC2 instances of the job flow assume this role.
        /// The default role is <code>EMRJobflowDefault</code>. In order to use the default role,
        /// you must have already created it using the CLI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String JobFlowRole { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies whether the job flow should terminate after completing all steps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean Instances_KeepJobFlowAliveWhenNoSteps { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 to write the log files of the job flow. If a value is not
        /// provided, logs are not created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String LogUri { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The EC2 instance type of the master node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Instances_MasterInstanceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the job flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of strings that indicates third-party software to use with the job flow that
        /// accepts a user argument list. EMR accepts and forwards the argument list to the corresponding
        /// installation script as bootstrap action arguments. For more information, see <a href="http://docs.aws.amazon.com/ElasticMapReduce/latest/DeveloperGuide/emr-mapr.html">Launch
        /// a Job Flow on the MapR Distribution for Hadoop</a>. Currently supported values are:</para><ul><li>"mapr-m3" - launch the job flow using MapR M3 Edition.</li><li>"mapr-m5"
        /// - launch the job flow using MapR M5 Edition.</li><li>"mapr" with the user arguments
        /// specifying "--edition,m3" or "--edition,m5" - launch the job flow using MapR M3 or
        /// M5 Edition respectively.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewSupportedProducts")]
        public Amazon.ElasticMapReduce.Model.SupportedProductConfig[] NewSupportedProduct { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The IAM role that will be assumed by the Amazon EMR service to access AWS resources
        /// on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ServiceRole { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The EC2 instance type of the slave nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Instances_SlaveInstanceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of steps to be executed by the job flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Steps")]
        public Amazon.ElasticMapReduce.Model.StepConfig[] Step { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of strings that indicates third-party software to use with the job flow. For
        /// more information, go to <a href="http://docs.aws.amazon.com/ElasticMapReduce/latest/DeveloperGuide/emr-supported-products.html">Use
        /// Third Party Applications with Amazon EMR</a>. Currently supported values are:</para><ul><li>"mapr-m3" - launch the job flow using MapR M3 Edition.</li><li>"mapr-m5"
        /// - launch the job flow using MapR M5 Edition.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SupportedProducts")]
        public System.String[] SupportedProduct { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with a cluster and propagate to Amazon EC2 instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ElasticMapReduce.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies whether to lock the job flow to prevent the Amazon EC2 instances from being
        /// terminated by API call, user intervention, or in the event of a job flow error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean Instances_TerminationProtected { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether the job flow is visible to all IAM users of the AWS account associated with
        /// the job flow. If this value is set to <code>true</code>, all IAM users of that AWS
        /// account can view and (if they have the proper policy permissions set) manage the job
        /// flow. If it is set to <code>false</code>, only the IAM user that created the job flow
        /// can view and manage it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean VisibleToAllUsers { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EMRJobFlow (RunJobFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AdditionalInfo = this.AdditionalInfo;
            context.AmiVersion = this.AmiVersion;
            if (this.BootstrapAction != null)
            {
                context.BootstrapActions = new List<BootstrapActionConfig>(this.BootstrapAction);
            }
            if (this.Instances_AdditionalMasterSecurityGroup != null)
            {
                context.Instances_AdditionalMasterSecurityGroups = new List<String>(this.Instances_AdditionalMasterSecurityGroup);
            }
            if (this.Instances_AdditionalSlaveSecurityGroup != null)
            {
                context.Instances_AdditionalSlaveSecurityGroups = new List<String>(this.Instances_AdditionalSlaveSecurityGroup);
            }
            context.Instances_Ec2KeyName = this.Instances_Ec2KeyName;
            context.Instances_Ec2SubnetId = this.Instances_Ec2SubnetId;
            context.Instances_EmrManagedMasterSecurityGroup = this.Instances_EmrManagedMasterSecurityGroup;
            context.Instances_EmrManagedSlaveSecurityGroup = this.Instances_EmrManagedSlaveSecurityGroup;
            context.Instances_HadoopVersion = this.Instances_HadoopVersion;
            if (ParameterWasBound("Instances_InstanceCount"))
                context.Instances_InstanceCount = this.Instances_InstanceCount;
            if (this.Instances_InstanceGroup != null)
            {
                context.Instances_InstanceGroups = new List<InstanceGroupConfig>(this.Instances_InstanceGroup);
            }
            if (ParameterWasBound("Instances_KeepJobFlowAliveWhenNoSteps"))
                context.Instances_KeepJobFlowAliveWhenNoSteps = this.Instances_KeepJobFlowAliveWhenNoSteps;
            context.Instances_MasterInstanceType = this.Instances_MasterInstanceType;
            context.Instances_Placement_AvailabilityZone = this.Placement_AvailabilityZone;
            context.Instances_SlaveInstanceType = this.Instances_SlaveInstanceType;
            if (ParameterWasBound("Instances_TerminationProtected"))
                context.Instances_TerminationProtected = this.Instances_TerminationProtected;
            context.JobFlowRole = this.JobFlowRole;
            context.LogUri = this.LogUri;
            context.Name = this.Name;
            if (this.NewSupportedProduct != null)
            {
                context.NewSupportedProducts = new List<SupportedProductConfig>(this.NewSupportedProduct);
            }
            context.ServiceRole = this.ServiceRole;
            if (this.Step != null)
            {
                context.Steps = new List<StepConfig>(this.Step);
            }
            if (this.SupportedProduct != null)
            {
                context.SupportedProducts = new List<String>(this.SupportedProduct);
            }
            if (this.Tag != null)
            {
                context.Tags = new List<Tag>(this.Tag);
            }
            if (ParameterWasBound("VisibleToAllUsers"))
                context.VisibleToAllUsers = this.VisibleToAllUsers;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RunJobFlowRequest();
            
            if (cmdletContext.AdditionalInfo != null)
            {
                request.AdditionalInfo = cmdletContext.AdditionalInfo;
            }
            if (cmdletContext.AmiVersion != null)
            {
                request.AmiVersion = cmdletContext.AmiVersion;
            }
            if (cmdletContext.BootstrapActions != null)
            {
                request.BootstrapActions = cmdletContext.BootstrapActions;
            }
            
             // populate Instances
            bool requestInstancesIsNull = true;
            request.Instances = new JobFlowInstancesConfig();
            List<String> requestInstances_instances_AdditionalMasterSecurityGroup = null;
            if (cmdletContext.Instances_AdditionalMasterSecurityGroups != null)
            {
                requestInstances_instances_AdditionalMasterSecurityGroup = cmdletContext.Instances_AdditionalMasterSecurityGroups;
            }
            if (requestInstances_instances_AdditionalMasterSecurityGroup != null)
            {
                request.Instances.AdditionalMasterSecurityGroups = requestInstances_instances_AdditionalMasterSecurityGroup;
                requestInstancesIsNull = false;
            }
            List<String> requestInstances_instances_AdditionalSlaveSecurityGroup = null;
            if (cmdletContext.Instances_AdditionalSlaveSecurityGroups != null)
            {
                requestInstances_instances_AdditionalSlaveSecurityGroup = cmdletContext.Instances_AdditionalSlaveSecurityGroups;
            }
            if (requestInstances_instances_AdditionalSlaveSecurityGroup != null)
            {
                request.Instances.AdditionalSlaveSecurityGroups = requestInstances_instances_AdditionalSlaveSecurityGroup;
                requestInstancesIsNull = false;
            }
            String requestInstances_instances_Ec2KeyName = null;
            if (cmdletContext.Instances_Ec2KeyName != null)
            {
                requestInstances_instances_Ec2KeyName = cmdletContext.Instances_Ec2KeyName;
            }
            if (requestInstances_instances_Ec2KeyName != null)
            {
                request.Instances.Ec2KeyName = requestInstances_instances_Ec2KeyName;
                requestInstancesIsNull = false;
            }
            String requestInstances_instances_Ec2SubnetId = null;
            if (cmdletContext.Instances_Ec2SubnetId != null)
            {
                requestInstances_instances_Ec2SubnetId = cmdletContext.Instances_Ec2SubnetId;
            }
            if (requestInstances_instances_Ec2SubnetId != null)
            {
                request.Instances.Ec2SubnetId = requestInstances_instances_Ec2SubnetId;
                requestInstancesIsNull = false;
            }
            String requestInstances_instances_EmrManagedMasterSecurityGroup = null;
            if (cmdletContext.Instances_EmrManagedMasterSecurityGroup != null)
            {
                requestInstances_instances_EmrManagedMasterSecurityGroup = cmdletContext.Instances_EmrManagedMasterSecurityGroup;
            }
            if (requestInstances_instances_EmrManagedMasterSecurityGroup != null)
            {
                request.Instances.EmrManagedMasterSecurityGroup = requestInstances_instances_EmrManagedMasterSecurityGroup;
                requestInstancesIsNull = false;
            }
            String requestInstances_instances_EmrManagedSlaveSecurityGroup = null;
            if (cmdletContext.Instances_EmrManagedSlaveSecurityGroup != null)
            {
                requestInstances_instances_EmrManagedSlaveSecurityGroup = cmdletContext.Instances_EmrManagedSlaveSecurityGroup;
            }
            if (requestInstances_instances_EmrManagedSlaveSecurityGroup != null)
            {
                request.Instances.EmrManagedSlaveSecurityGroup = requestInstances_instances_EmrManagedSlaveSecurityGroup;
                requestInstancesIsNull = false;
            }
            String requestInstances_instances_HadoopVersion = null;
            if (cmdletContext.Instances_HadoopVersion != null)
            {
                requestInstances_instances_HadoopVersion = cmdletContext.Instances_HadoopVersion;
            }
            if (requestInstances_instances_HadoopVersion != null)
            {
                request.Instances.HadoopVersion = requestInstances_instances_HadoopVersion;
                requestInstancesIsNull = false;
            }
            Int32? requestInstances_instances_InstanceCount = null;
            if (cmdletContext.Instances_InstanceCount != null)
            {
                requestInstances_instances_InstanceCount = cmdletContext.Instances_InstanceCount.Value;
            }
            if (requestInstances_instances_InstanceCount != null)
            {
                request.Instances.InstanceCount = requestInstances_instances_InstanceCount.Value;
                requestInstancesIsNull = false;
            }
            List<InstanceGroupConfig> requestInstances_instances_InstanceGroup = null;
            if (cmdletContext.Instances_InstanceGroups != null)
            {
                requestInstances_instances_InstanceGroup = cmdletContext.Instances_InstanceGroups;
            }
            if (requestInstances_instances_InstanceGroup != null)
            {
                request.Instances.InstanceGroups = requestInstances_instances_InstanceGroup;
                requestInstancesIsNull = false;
            }
            Boolean? requestInstances_instances_KeepJobFlowAliveWhenNoSteps = null;
            if (cmdletContext.Instances_KeepJobFlowAliveWhenNoSteps != null)
            {
                requestInstances_instances_KeepJobFlowAliveWhenNoSteps = cmdletContext.Instances_KeepJobFlowAliveWhenNoSteps.Value;
            }
            if (requestInstances_instances_KeepJobFlowAliveWhenNoSteps != null)
            {
                request.Instances.KeepJobFlowAliveWhenNoSteps = requestInstances_instances_KeepJobFlowAliveWhenNoSteps.Value;
                requestInstancesIsNull = false;
            }
            String requestInstances_instances_MasterInstanceType = null;
            if (cmdletContext.Instances_MasterInstanceType != null)
            {
                requestInstances_instances_MasterInstanceType = cmdletContext.Instances_MasterInstanceType;
            }
            if (requestInstances_instances_MasterInstanceType != null)
            {
                request.Instances.MasterInstanceType = requestInstances_instances_MasterInstanceType;
                requestInstancesIsNull = false;
            }
            String requestInstances_instances_SlaveInstanceType = null;
            if (cmdletContext.Instances_SlaveInstanceType != null)
            {
                requestInstances_instances_SlaveInstanceType = cmdletContext.Instances_SlaveInstanceType;
            }
            if (requestInstances_instances_SlaveInstanceType != null)
            {
                request.Instances.SlaveInstanceType = requestInstances_instances_SlaveInstanceType;
                requestInstancesIsNull = false;
            }
            Boolean? requestInstances_instances_TerminationProtected = null;
            if (cmdletContext.Instances_TerminationProtected != null)
            {
                requestInstances_instances_TerminationProtected = cmdletContext.Instances_TerminationProtected.Value;
            }
            if (requestInstances_instances_TerminationProtected != null)
            {
                request.Instances.TerminationProtected = requestInstances_instances_TerminationProtected.Value;
                requestInstancesIsNull = false;
            }
            PlacementType requestInstances_instances_Placement = null;
            
             // populate Placement
            bool requestInstances_instances_PlacementIsNull = true;
            requestInstances_instances_Placement = new PlacementType();
            String requestInstances_instances_Placement_placement_AvailabilityZone = null;
            if (cmdletContext.Instances_Placement_AvailabilityZone != null)
            {
                requestInstances_instances_Placement_placement_AvailabilityZone = cmdletContext.Instances_Placement_AvailabilityZone;
            }
            if (requestInstances_instances_Placement_placement_AvailabilityZone != null)
            {
                requestInstances_instances_Placement.AvailabilityZone = requestInstances_instances_Placement_placement_AvailabilityZone;
                requestInstances_instances_PlacementIsNull = false;
            }
             // determine if requestInstances_instances_Placement should be set to null
            if (requestInstances_instances_PlacementIsNull)
            {
                requestInstances_instances_Placement = null;
            }
            if (requestInstances_instances_Placement != null)
            {
                request.Instances.Placement = requestInstances_instances_Placement;
                requestInstancesIsNull = false;
            }
             // determine if request.Instances should be set to null
            if (requestInstancesIsNull)
            {
                request.Instances = null;
            }
            if (cmdletContext.JobFlowRole != null)
            {
                request.JobFlowRole = cmdletContext.JobFlowRole;
            }
            if (cmdletContext.LogUri != null)
            {
                request.LogUri = cmdletContext.LogUri;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NewSupportedProducts != null)
            {
                request.NewSupportedProducts = cmdletContext.NewSupportedProducts;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
            }
            if (cmdletContext.Steps != null)
            {
                request.Steps = cmdletContext.Steps;
            }
            if (cmdletContext.SupportedProducts != null)
            {
                request.SupportedProducts = cmdletContext.SupportedProducts;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.VisibleToAllUsers != null)
            {
                request.VisibleToAllUsers = cmdletContext.VisibleToAllUsers.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RunJobFlow(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.JobFlowId;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String AdditionalInfo { get; set; }
            public String AmiVersion { get; set; }
            public List<BootstrapActionConfig> BootstrapActions { get; set; }
            public List<String> Instances_AdditionalMasterSecurityGroups { get; set; }
            public List<String> Instances_AdditionalSlaveSecurityGroups { get; set; }
            public String Instances_Ec2KeyName { get; set; }
            public String Instances_Ec2SubnetId { get; set; }
            public String Instances_EmrManagedMasterSecurityGroup { get; set; }
            public String Instances_EmrManagedSlaveSecurityGroup { get; set; }
            public String Instances_HadoopVersion { get; set; }
            public Int32? Instances_InstanceCount { get; set; }
            public List<InstanceGroupConfig> Instances_InstanceGroups { get; set; }
            public Boolean? Instances_KeepJobFlowAliveWhenNoSteps { get; set; }
            public String Instances_MasterInstanceType { get; set; }
            public String Instances_Placement_AvailabilityZone { get; set; }
            public String Instances_SlaveInstanceType { get; set; }
            public Boolean? Instances_TerminationProtected { get; set; }
            public String JobFlowRole { get; set; }
            public String LogUri { get; set; }
            public String Name { get; set; }
            public List<SupportedProductConfig> NewSupportedProducts { get; set; }
            public String ServiceRole { get; set; }
            public List<StepConfig> Steps { get; set; }
            public List<String> SupportedProducts { get; set; }
            public List<Tag> Tags { get; set; }
            public Boolean? VisibleToAllUsers { get; set; }
        }
        
    }
}
