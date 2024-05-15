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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Creates a compute fleet.
    /// </summary>
    [Cmdlet("New", "CBFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.Fleet")]
    [AWSCmdlet("Calls the AWS CodeBuild CreateFleet API operation.", Operation = new[] {"CreateFleet"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.CreateFleetResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.Fleet or Amazon.CodeBuild.Model.CreateFleetResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.Fleet object.",
        "The service call response (type Amazon.CodeBuild.Model.CreateFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCBFleetCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BaseCapacity
        /// <summary>
        /// <para>
        /// <para>The initial number of machines allocated to the ﬂeet, which deﬁnes the number of builds
        /// that can run in parallel.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? BaseCapacity { get; set; }
        #endregion
        
        #region Parameter ComputeType
        /// <summary>
        /// <para>
        /// <para>Information about the compute resources the compute fleet uses. Available values include:</para><ul><li><para><c>BUILD_GENERAL1_SMALL</c>: Use up to 3 GB memory and 2 vCPUs for builds.</para></li><li><para><c>BUILD_GENERAL1_MEDIUM</c>: Use up to 7 GB memory and 4 vCPUs for builds.</para></li><li><para><c>BUILD_GENERAL1_LARGE</c>: Use up to 16 GB memory and 8 vCPUs for builds, depending
        /// on your environment type.</para></li><li><para><c>BUILD_GENERAL1_XLARGE</c>: Use up to 70 GB memory and 36 vCPUs for builds, depending
        /// on your environment type.</para></li><li><para><c>BUILD_GENERAL1_2XLARGE</c>: Use up to 145 GB memory, 72 vCPUs, and 824 GB of SSD
        /// storage for builds. This compute type supports Docker images up to 100 GB uncompressed.</para></li></ul><para> If you use <c>BUILD_GENERAL1_SMALL</c>: </para><ul><li><para> For environment type <c>LINUX_CONTAINER</c>, you can use up to 3 GB memory and 2
        /// vCPUs for builds. </para></li><li><para> For environment type <c>LINUX_GPU_CONTAINER</c>, you can use up to 16 GB memory,
        /// 4 vCPUs, and 1 NVIDIA A10G Tensor Core GPU for builds.</para></li><li><para> For environment type <c>ARM_CONTAINER</c>, you can use up to 4 GB memory and 2 vCPUs
        /// on ARM-based processors for builds.</para></li></ul><para> If you use <c>BUILD_GENERAL1_LARGE</c>: </para><ul><li><para> For environment type <c>LINUX_CONTAINER</c>, you can use up to 15 GB memory and 8
        /// vCPUs for builds. </para></li><li><para> For environment type <c>LINUX_GPU_CONTAINER</c>, you can use up to 255 GB memory,
        /// 32 vCPUs, and 4 NVIDIA Tesla V100 GPUs for builds.</para></li><li><para> For environment type <c>ARM_CONTAINER</c>, you can use up to 16 GB memory and 8 vCPUs
        /// on ARM-based processors for builds.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/build-env-ref-compute-types.html">Build
        /// environment compute types</a> in the <i>CodeBuild User Guide.</i></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ComputeType")]
        public Amazon.CodeBuild.ComputeType ComputeType { get; set; }
        #endregion
        
        #region Parameter EnvironmentType
        /// <summary>
        /// <para>
        /// <para>The environment type of the compute fleet.</para><ul><li><para>The environment type <c>ARM_CONTAINER</c> is available only in regions US East (N.
        /// Virginia), US East (Ohio), US West (Oregon), EU (Ireland), Asia Pacific (Mumbai),
        /// Asia Pacific (Tokyo), Asia Pacific (Singapore), Asia Pacific (Sydney), EU (Frankfurt),
        /// and South America (São Paulo).</para></li><li><para>The environment type <c>LINUX_CONTAINER</c> is available only in regions US East (N.
        /// Virginia), US East (Ohio), US West (Oregon), EU (Ireland), EU (Frankfurt), Asia Pacific
        /// (Tokyo), Asia Pacific (Singapore), Asia Pacific (Sydney), South America (São Paulo),
        /// and Asia Pacific (Mumbai).</para></li><li><para>The environment type <c>LINUX_GPU_CONTAINER</c> is available only in regions US East
        /// (N. Virginia), US East (Ohio), US West (Oregon), EU (Ireland), EU (Frankfurt), Asia
        /// Pacific (Tokyo), and Asia Pacific (Sydney).</para></li><li><para>The environment type <c>WINDOWS_SERVER_2019_CONTAINER</c> is available only in regions
        /// US East (N. Virginia), US East (Ohio), US West (Oregon), Asia Pacific (Sydney), Asia
        /// Pacific (Tokyo), Asia Pacific (Mumbai) and EU (Ireland).</para></li><li><para>The environment type <c>WINDOWS_SERVER_2022_CONTAINER</c> is available only in regions
        /// US East (N. Virginia), US East (Ohio), US West (Oregon), EU (Ireland), EU (Frankfurt),
        /// Asia Pacific (Sydney), Asia Pacific (Singapore), Asia Pacific (Tokyo), South America
        /// (São Paulo) and Asia Pacific (Mumbai).</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/build-env-ref-compute-types.html">Build
        /// environment compute types</a> in the <i>CodeBuild user guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeBuild.EnvironmentType")]
        public Amazon.CodeBuild.EnvironmentType EnvironmentType { get; set; }
        #endregion
        
        #region Parameter FleetServiceRole
        /// <summary>
        /// <para>
        /// <para>The service role associated with the compute fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FleetServiceRole { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances in the ﬂeet when auto-scaling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfiguration_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the compute fleet.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OverflowBehavior
        /// <summary>
        /// <para>
        /// <para>The compute fleet overflow behavior.</para><ul><li><para>For overflow behavior <c>QUEUE</c>, your overflow builds need to wait on the existing
        /// fleet instance to become available.</para></li><li><para>For overflow behavior <c>ON_DEMAND</c>, your overflow builds run on CodeBuild on-demand.</para><note><para>If you choose to set your overflow behavior to on-demand while creating a VPC-connected
        /// fleet, make sure that you add the required VPC permissions to your project service
        /// role. For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/auth-and-access-control-iam-identity-based-access-control.html#customer-managed-policies-example-create-vpc-network-interface">Example
        /// policy statement to allow CodeBuild access to Amazon Web Services services required
        /// to create a VPC network interface</a>.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.FleetOverflowBehavior")]
        public Amazon.CodeBuild.FleetOverflowBehavior OverflowBehavior { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_ScalingType
        /// <summary>
        /// <para>
        /// <para>The scaling type for a compute fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.FleetScalingType")]
        public Amazon.CodeBuild.FleetScalingType ScalingConfiguration_ScalingType { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of one or more security groups IDs in your Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>A list of one or more subnet IDs in your Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tag key and value pairs associated with this compute fleet.</para><para>These tags are available for use by Amazon Web Services services that support CodeBuild
        /// build project tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CodeBuild.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_TargetTrackingScalingConfig
        /// <summary>
        /// <para>
        /// <para>A list of <c>TargetTrackingScalingConfiguration</c> objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScalingConfiguration_TargetTrackingScalingConfigs")]
        public Amazon.CodeBuild.Model.TargetTrackingScalingConfiguration[] ScalingConfiguration_TargetTrackingScalingConfig { get; set; }
        #endregion
        
        #region Parameter VpcConfig_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcConfig_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Fleet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.CreateFleetResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.CreateFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Fleet";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CBFleet (CreateFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.CreateFleetResponse, NewCBFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BaseCapacity = this.BaseCapacity;
            #if MODULAR
            if (this.BaseCapacity == null && ParameterWasBound(nameof(this.BaseCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter BaseCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeType = this.ComputeType;
            #if MODULAR
            if (this.ComputeType == null && ParameterWasBound(nameof(this.ComputeType)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentType = this.EnvironmentType;
            #if MODULAR
            if (this.EnvironmentType == null && ParameterWasBound(nameof(this.EnvironmentType)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FleetServiceRole = this.FleetServiceRole;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OverflowBehavior = this.OverflowBehavior;
            context.ScalingConfiguration_MaxCapacity = this.ScalingConfiguration_MaxCapacity;
            context.ScalingConfiguration_ScalingType = this.ScalingConfiguration_ScalingType;
            if (this.ScalingConfiguration_TargetTrackingScalingConfig != null)
            {
                context.ScalingConfiguration_TargetTrackingScalingConfig = new List<Amazon.CodeBuild.Model.TargetTrackingScalingConfiguration>(this.ScalingConfiguration_TargetTrackingScalingConfig);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CodeBuild.Model.Tag>(this.Tag);
            }
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            context.VpcConfig_VpcId = this.VpcConfig_VpcId;
            
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
            var request = new Amazon.CodeBuild.Model.CreateFleetRequest();
            
            if (cmdletContext.BaseCapacity != null)
            {
                request.BaseCapacity = cmdletContext.BaseCapacity.Value;
            }
            if (cmdletContext.ComputeType != null)
            {
                request.ComputeType = cmdletContext.ComputeType;
            }
            if (cmdletContext.EnvironmentType != null)
            {
                request.EnvironmentType = cmdletContext.EnvironmentType;
            }
            if (cmdletContext.FleetServiceRole != null)
            {
                request.FleetServiceRole = cmdletContext.FleetServiceRole;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OverflowBehavior != null)
            {
                request.OverflowBehavior = cmdletContext.OverflowBehavior;
            }
            
             // populate ScalingConfiguration
            var requestScalingConfigurationIsNull = true;
            request.ScalingConfiguration = new Amazon.CodeBuild.Model.ScalingConfigurationInput();
            System.Int32? requestScalingConfiguration_scalingConfiguration_MaxCapacity = null;
            if (cmdletContext.ScalingConfiguration_MaxCapacity != null)
            {
                requestScalingConfiguration_scalingConfiguration_MaxCapacity = cmdletContext.ScalingConfiguration_MaxCapacity.Value;
            }
            if (requestScalingConfiguration_scalingConfiguration_MaxCapacity != null)
            {
                request.ScalingConfiguration.MaxCapacity = requestScalingConfiguration_scalingConfiguration_MaxCapacity.Value;
                requestScalingConfigurationIsNull = false;
            }
            Amazon.CodeBuild.FleetScalingType requestScalingConfiguration_scalingConfiguration_ScalingType = null;
            if (cmdletContext.ScalingConfiguration_ScalingType != null)
            {
                requestScalingConfiguration_scalingConfiguration_ScalingType = cmdletContext.ScalingConfiguration_ScalingType;
            }
            if (requestScalingConfiguration_scalingConfiguration_ScalingType != null)
            {
                request.ScalingConfiguration.ScalingType = requestScalingConfiguration_scalingConfiguration_ScalingType;
                requestScalingConfigurationIsNull = false;
            }
            List<Amazon.CodeBuild.Model.TargetTrackingScalingConfiguration> requestScalingConfiguration_scalingConfiguration_TargetTrackingScalingConfig = null;
            if (cmdletContext.ScalingConfiguration_TargetTrackingScalingConfig != null)
            {
                requestScalingConfiguration_scalingConfiguration_TargetTrackingScalingConfig = cmdletContext.ScalingConfiguration_TargetTrackingScalingConfig;
            }
            if (requestScalingConfiguration_scalingConfiguration_TargetTrackingScalingConfig != null)
            {
                request.ScalingConfiguration.TargetTrackingScalingConfigs = requestScalingConfiguration_scalingConfiguration_TargetTrackingScalingConfig;
                requestScalingConfigurationIsNull = false;
            }
             // determine if request.ScalingConfiguration should be set to null
            if (requestScalingConfigurationIsNull)
            {
                request.ScalingConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.CodeBuild.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestVpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestVpcConfig_vpcConfig_Subnet != null)
            {
                request.VpcConfig.Subnets = requestVpcConfig_vpcConfig_Subnet;
                requestVpcConfigIsNull = false;
            }
            System.String requestVpcConfig_vpcConfig_VpcId = null;
            if (cmdletContext.VpcConfig_VpcId != null)
            {
                requestVpcConfig_vpcConfig_VpcId = cmdletContext.VpcConfig_VpcId;
            }
            if (requestVpcConfig_vpcConfig_VpcId != null)
            {
                request.VpcConfig.VpcId = requestVpcConfig_vpcConfig_VpcId;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
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
        
        private Amazon.CodeBuild.Model.CreateFleetResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.CreateFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "CreateFleet");
            try
            {
                #if DESKTOP
                return client.CreateFleet(request);
                #elif CORECLR
                return client.CreateFleetAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? BaseCapacity { get; set; }
            public Amazon.CodeBuild.ComputeType ComputeType { get; set; }
            public Amazon.CodeBuild.EnvironmentType EnvironmentType { get; set; }
            public System.String FleetServiceRole { get; set; }
            public System.String Name { get; set; }
            public Amazon.CodeBuild.FleetOverflowBehavior OverflowBehavior { get; set; }
            public System.Int32? ScalingConfiguration_MaxCapacity { get; set; }
            public Amazon.CodeBuild.FleetScalingType ScalingConfiguration_ScalingType { get; set; }
            public List<Amazon.CodeBuild.Model.TargetTrackingScalingConfiguration> ScalingConfiguration_TargetTrackingScalingConfig { get; set; }
            public List<Amazon.CodeBuild.Model.Tag> Tag { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String VpcConfig_VpcId { get; set; }
            public System.Func<Amazon.CodeBuild.Model.CreateFleetResponse, NewCBFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Fleet;
        }
        
    }
}
