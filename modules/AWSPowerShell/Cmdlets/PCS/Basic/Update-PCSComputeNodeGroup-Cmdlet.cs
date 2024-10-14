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
using Amazon.PCS;
using Amazon.PCS.Model;

namespace Amazon.PowerShell.Cmdlets.PCS
{
    /// <summary>
    /// Updates a compute node group. You can update many of the fields related to your compute
    /// node group including the configurations for networking, compute nodes, and settings
    /// specific to your scheduler (such as Slurm).
    /// </summary>
    [Cmdlet("Update", "PCSComputeNodeGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PCS.Model.ComputeNodeGroup")]
    [AWSCmdlet("Calls the AWS Parallel Computing Service UpdateComputeNodeGroup API operation.", Operation = new[] {"UpdateComputeNodeGroup"}, SelectReturnType = typeof(Amazon.PCS.Model.UpdateComputeNodeGroupResponse))]
    [AWSCmdletOutput("Amazon.PCS.Model.ComputeNodeGroup or Amazon.PCS.Model.UpdateComputeNodeGroupResponse",
        "This cmdlet returns an Amazon.PCS.Model.ComputeNodeGroup object.",
        "The service call response (type Amazon.PCS.Model.UpdateComputeNodeGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePCSComputeNodeGroupCmdlet : AmazonPCSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SpotOptions_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 allocation strategy Amazon Web Services PCS uses to provision EC2 instances.
        /// Amazon Web Services PCS supports <b>lowest price</b>, <b>capacity optimized</b>, and
        /// <b>price capacity optimized</b>. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-fleet-allocation-strategy.html">Use
        /// allocation strategies to determine how EC2 Fleet or Spot Fleet fulfills Spot and On-Demand
        /// capacity</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>. If you don't provide
        /// this option, it defaults to <b>price capacity optimized</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PCS.SpotAllocationStrategy")]
        public Amazon.PCS.SpotAllocationStrategy SpotOptions_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter AmiId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Machine Image (AMI) that Amazon Web Services PCS uses to launch
        /// instances. If not provided, Amazon Web Services PCS uses the AMI ID specified in the
        /// custom launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmiId { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The name or ID of the cluster of the compute node group.</para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ComputeNodeGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The name or ID of the compute node group.</para>
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
        public System.String ComputeNodeGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM instance profile used to pass an IAM role
        /// when launching EC2 instances. The role contained in your instance profile must have
        /// the <c>pcs:RegisterComputeNodeGroupInstance</c> permission. The resource identifier
        /// of the ARN must start with <c>AWSPCS</c> or it must have <c>/aws-pcs/</c> in its path.</para><para><b>Examples</b></para><ul><li><para><c>arn:aws:iam::111122223333:instance-profile/AWSPCS-example-role-1</c></para></li><li><para><c>arn:aws:iam::111122223333:instance-profile/aws-pcs/example-role-2</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamInstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter CustomLaunchTemplate_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the EC2 launch template to use to provision instances.</para><para> Example: <c>lt-xxxx</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomLaunchTemplate_Id { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MaxInstanceCount
        /// <summary>
        /// <para>
        /// <para>The upper bound of the number of instances allowed in the compute fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfiguration_MaxInstanceCount { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MinInstanceCount
        /// <summary>
        /// <para>
        /// <para>The lower bound of the number of instances allowed in the compute fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfiguration_MinInstanceCount { get; set; }
        #endregion
        
        #region Parameter PurchaseOption
        /// <summary>
        /// <para>
        /// <para>Specifies how EC2 instances are purchased on your behalf. Amazon Web Services PCS
        /// supports On-Demand and Spot instances. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-purchasing-options.html">Instance
        /// purchasing options</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>. If you
        /// don't provide this option, it defaults to On-Demand.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PCS.PurchaseOption")]
        public Amazon.PCS.PurchaseOption PurchaseOption { get; set; }
        #endregion
        
        #region Parameter SlurmConfiguration_SlurmCustomSetting
        /// <summary>
        /// <para>
        /// <para>Additional Slurm-specific configuration that directly maps to Slurm settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlurmConfiguration_SlurmCustomSettings")]
        public Amazon.PCS.Model.SlurmCustomSetting[] SlurmConfiguration_SlurmCustomSetting { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The list of subnet IDs where the compute node group provisions instances. The subnets
        /// must be in the same VPC as the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter CustomLaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version of the EC2 launch template to use to provision instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomLaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, the subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect. If you don't specify a client token, the
        /// CLI and SDK automatically generate 1 for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComputeNodeGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PCS.Model.UpdateComputeNodeGroupResponse).
        /// Specifying the name of a property of type Amazon.PCS.Model.UpdateComputeNodeGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComputeNodeGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ComputeNodeGroupIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ComputeNodeGroupIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ComputeNodeGroupIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ComputeNodeGroupIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PCSComputeNodeGroup (UpdateComputeNodeGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PCS.Model.UpdateComputeNodeGroupResponse, UpdatePCSComputeNodeGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ComputeNodeGroupIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AmiId = this.AmiId;
            context.ClientToken = this.ClientToken;
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeNodeGroupIdentifier = this.ComputeNodeGroupIdentifier;
            #if MODULAR
            if (this.ComputeNodeGroupIdentifier == null && ParameterWasBound(nameof(this.ComputeNodeGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeNodeGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomLaunchTemplate_Id = this.CustomLaunchTemplate_Id;
            context.CustomLaunchTemplate_Version = this.CustomLaunchTemplate_Version;
            context.IamInstanceProfileArn = this.IamInstanceProfileArn;
            context.PurchaseOption = this.PurchaseOption;
            context.ScalingConfiguration_MaxInstanceCount = this.ScalingConfiguration_MaxInstanceCount;
            context.ScalingConfiguration_MinInstanceCount = this.ScalingConfiguration_MinInstanceCount;
            if (this.SlurmConfiguration_SlurmCustomSetting != null)
            {
                context.SlurmConfiguration_SlurmCustomSetting = new List<Amazon.PCS.Model.SlurmCustomSetting>(this.SlurmConfiguration_SlurmCustomSetting);
            }
            context.SpotOptions_AllocationStrategy = this.SpotOptions_AllocationStrategy;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            
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
            var request = new Amazon.PCS.Model.UpdateComputeNodeGroupRequest();
            
            if (cmdletContext.AmiId != null)
            {
                request.AmiId = cmdletContext.AmiId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.ComputeNodeGroupIdentifier != null)
            {
                request.ComputeNodeGroupIdentifier = cmdletContext.ComputeNodeGroupIdentifier;
            }
            
             // populate CustomLaunchTemplate
            var requestCustomLaunchTemplateIsNull = true;
            request.CustomLaunchTemplate = new Amazon.PCS.Model.CustomLaunchTemplate();
            System.String requestCustomLaunchTemplate_customLaunchTemplate_Id = null;
            if (cmdletContext.CustomLaunchTemplate_Id != null)
            {
                requestCustomLaunchTemplate_customLaunchTemplate_Id = cmdletContext.CustomLaunchTemplate_Id;
            }
            if (requestCustomLaunchTemplate_customLaunchTemplate_Id != null)
            {
                request.CustomLaunchTemplate.Id = requestCustomLaunchTemplate_customLaunchTemplate_Id;
                requestCustomLaunchTemplateIsNull = false;
            }
            System.String requestCustomLaunchTemplate_customLaunchTemplate_Version = null;
            if (cmdletContext.CustomLaunchTemplate_Version != null)
            {
                requestCustomLaunchTemplate_customLaunchTemplate_Version = cmdletContext.CustomLaunchTemplate_Version;
            }
            if (requestCustomLaunchTemplate_customLaunchTemplate_Version != null)
            {
                request.CustomLaunchTemplate.Version = requestCustomLaunchTemplate_customLaunchTemplate_Version;
                requestCustomLaunchTemplateIsNull = false;
            }
             // determine if request.CustomLaunchTemplate should be set to null
            if (requestCustomLaunchTemplateIsNull)
            {
                request.CustomLaunchTemplate = null;
            }
            if (cmdletContext.IamInstanceProfileArn != null)
            {
                request.IamInstanceProfileArn = cmdletContext.IamInstanceProfileArn;
            }
            if (cmdletContext.PurchaseOption != null)
            {
                request.PurchaseOption = cmdletContext.PurchaseOption;
            }
            
             // populate ScalingConfiguration
            var requestScalingConfigurationIsNull = true;
            request.ScalingConfiguration = new Amazon.PCS.Model.ScalingConfigurationRequest();
            System.Int32? requestScalingConfiguration_scalingConfiguration_MaxInstanceCount = null;
            if (cmdletContext.ScalingConfiguration_MaxInstanceCount != null)
            {
                requestScalingConfiguration_scalingConfiguration_MaxInstanceCount = cmdletContext.ScalingConfiguration_MaxInstanceCount.Value;
            }
            if (requestScalingConfiguration_scalingConfiguration_MaxInstanceCount != null)
            {
                request.ScalingConfiguration.MaxInstanceCount = requestScalingConfiguration_scalingConfiguration_MaxInstanceCount.Value;
                requestScalingConfigurationIsNull = false;
            }
            System.Int32? requestScalingConfiguration_scalingConfiguration_MinInstanceCount = null;
            if (cmdletContext.ScalingConfiguration_MinInstanceCount != null)
            {
                requestScalingConfiguration_scalingConfiguration_MinInstanceCount = cmdletContext.ScalingConfiguration_MinInstanceCount.Value;
            }
            if (requestScalingConfiguration_scalingConfiguration_MinInstanceCount != null)
            {
                request.ScalingConfiguration.MinInstanceCount = requestScalingConfiguration_scalingConfiguration_MinInstanceCount.Value;
                requestScalingConfigurationIsNull = false;
            }
             // determine if request.ScalingConfiguration should be set to null
            if (requestScalingConfigurationIsNull)
            {
                request.ScalingConfiguration = null;
            }
            
             // populate SlurmConfiguration
            var requestSlurmConfigurationIsNull = true;
            request.SlurmConfiguration = new Amazon.PCS.Model.UpdateComputeNodeGroupSlurmConfigurationRequest();
            List<Amazon.PCS.Model.SlurmCustomSetting> requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting = null;
            if (cmdletContext.SlurmConfiguration_SlurmCustomSetting != null)
            {
                requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting = cmdletContext.SlurmConfiguration_SlurmCustomSetting;
            }
            if (requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting != null)
            {
                request.SlurmConfiguration.SlurmCustomSettings = requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting;
                requestSlurmConfigurationIsNull = false;
            }
             // determine if request.SlurmConfiguration should be set to null
            if (requestSlurmConfigurationIsNull)
            {
                request.SlurmConfiguration = null;
            }
            
             // populate SpotOptions
            var requestSpotOptionsIsNull = true;
            request.SpotOptions = new Amazon.PCS.Model.SpotOptions();
            Amazon.PCS.SpotAllocationStrategy requestSpotOptions_spotOptions_AllocationStrategy = null;
            if (cmdletContext.SpotOptions_AllocationStrategy != null)
            {
                requestSpotOptions_spotOptions_AllocationStrategy = cmdletContext.SpotOptions_AllocationStrategy;
            }
            if (requestSpotOptions_spotOptions_AllocationStrategy != null)
            {
                request.SpotOptions.AllocationStrategy = requestSpotOptions_spotOptions_AllocationStrategy;
                requestSpotOptionsIsNull = false;
            }
             // determine if request.SpotOptions should be set to null
            if (requestSpotOptionsIsNull)
            {
                request.SpotOptions = null;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
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
        
        private Amazon.PCS.Model.UpdateComputeNodeGroupResponse CallAWSServiceOperation(IAmazonPCS client, Amazon.PCS.Model.UpdateComputeNodeGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Parallel Computing Service", "UpdateComputeNodeGroup");
            try
            {
                #if DESKTOP
                return client.UpdateComputeNodeGroup(request);
                #elif CORECLR
                return client.UpdateComputeNodeGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String AmiId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.String ComputeNodeGroupIdentifier { get; set; }
            public System.String CustomLaunchTemplate_Id { get; set; }
            public System.String CustomLaunchTemplate_Version { get; set; }
            public System.String IamInstanceProfileArn { get; set; }
            public Amazon.PCS.PurchaseOption PurchaseOption { get; set; }
            public System.Int32? ScalingConfiguration_MaxInstanceCount { get; set; }
            public System.Int32? ScalingConfiguration_MinInstanceCount { get; set; }
            public List<Amazon.PCS.Model.SlurmCustomSetting> SlurmConfiguration_SlurmCustomSetting { get; set; }
            public Amazon.PCS.SpotAllocationStrategy SpotOptions_AllocationStrategy { get; set; }
            public List<System.String> SubnetId { get; set; }
            public System.Func<Amazon.PCS.Model.UpdateComputeNodeGroupResponse, UpdatePCSComputeNodeGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComputeNodeGroup;
        }
        
    }
}
