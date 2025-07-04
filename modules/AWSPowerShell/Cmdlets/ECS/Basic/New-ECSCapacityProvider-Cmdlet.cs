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
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Creates a new capacity provider. Capacity providers are associated with an Amazon
    /// ECS cluster and are used in capacity provider strategies to facilitate cluster auto
    /// scaling.
    /// 
    ///  
    /// <para>
    /// Only capacity providers that use an Auto Scaling group can be created. Amazon ECS
    /// tasks on Fargate use the <c>FARGATE</c> and <c>FARGATE_SPOT</c> capacity providers.
    /// These providers are available to all accounts in the Amazon Web Services Regions that
    /// Fargate supports.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ECSCapacityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.CapacityProvider")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service CreateCapacityProvider API operation.", Operation = new[] {"CreateCapacityProvider"}, SelectReturnType = typeof(Amazon.ECS.Model.CreateCapacityProviderResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.CapacityProvider or Amazon.ECS.Model.CreateCapacityProviderResponse",
        "This cmdlet returns an Amazon.ECS.Model.CapacityProvider object.",
        "The service call response (type Amazon.ECS.Model.CreateCapacityProviderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewECSCapacityProviderCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoScalingGroupProvider_AutoScalingGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that identifies the Auto Scaling group, or the Auto
        /// Scaling group name.</para>
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
        public System.String AutoScalingGroupProvider_AutoScalingGroupArn { get; set; }
        #endregion
        
        #region Parameter ManagedScaling_InstanceWarmupPeriod
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, after a newly launched Amazon EC2 instance can contribute
        /// to CloudWatch metrics for Auto Scaling group. If this parameter is omitted, the default
        /// value of <c>300</c> seconds is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_InstanceWarmupPeriod")]
        public System.Int32? ManagedScaling_InstanceWarmupPeriod { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroupProvider_ManagedDraining
        /// <summary>
        /// <para>
        /// <para>The managed draining option for the Auto Scaling group capacity provider. When you
        /// enable this, Amazon ECS manages and gracefully drains the EC2 container instances
        /// that are in the Auto Scaling group capacity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.ManagedDraining")]
        public Amazon.ECS.ManagedDraining AutoScalingGroupProvider_ManagedDraining { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroupProvider_ManagedTerminationProtection
        /// <summary>
        /// <para>
        /// <para>The managed termination protection setting to use for the Auto Scaling group capacity
        /// provider. This determines whether the Auto Scaling group has managed termination protection.
        /// The default is off.</para><important><para>When using managed termination protection, managed scaling must also be used otherwise
        /// managed termination protection doesn't work.</para></important><para>When managed termination protection is on, Amazon ECS prevents the Amazon EC2 instances
        /// in an Auto Scaling group that contain tasks from being terminated during a scale-in
        /// action. The Auto Scaling group and each instance in the Auto Scaling group must have
        /// instance protection from scale-in actions on as well. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-instance-termination.html#instance-protection">Instance
        /// Protection</a> in the <i>Auto Scaling User Guide</i>.</para><para>When managed termination protection is off, your Amazon EC2 instances aren't protected
        /// from termination when the Auto Scaling group scales in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.ManagedTerminationProtection")]
        public Amazon.ECS.ManagedTerminationProtection AutoScalingGroupProvider_ManagedTerminationProtection { get; set; }
        #endregion
        
        #region Parameter ManagedScaling_MaximumScalingStepSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of Amazon EC2 instances that Amazon ECS will scale out at one time.
        /// If this parameter is omitted, the default value of <c>10000</c> is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_MaximumScalingStepSize")]
        public System.Int32? ManagedScaling_MaximumScalingStepSize { get; set; }
        #endregion
        
        #region Parameter ManagedScaling_MinimumScalingStepSize
        /// <summary>
        /// <para>
        /// <para>The minimum number of Amazon EC2 instances that Amazon ECS will scale out at one time.
        /// The scale in process is not affected by this parameter If this parameter is omitted,
        /// the default value of <c>1</c> is used.</para><para>When additional capacity is required, Amazon ECS will scale up the minimum scaling
        /// step size even if the actual demand is less than the minimum scaling step size.</para><para>If you use a capacity provider with an Auto Scaling group configured with more than
        /// one Amazon EC2 instance type or Availability Zone, Amazon ECS will scale up by the
        /// exact minimum scaling step size value and will ignore both the maximum scaling step
        /// size as well as the capacity demand.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_MinimumScalingStepSize")]
        public System.Int32? ManagedScaling_MinimumScalingStepSize { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the capacity provider. Up to 255 characters are allowed. They include
        /// letters (both upper and lowercase letters), numbers, underscores (_), and hyphens
        /// (-). The name can't be prefixed with "<c>aws</c>", "<c>ecs</c>", or "<c>fargate</c>".</para>
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
        
        #region Parameter ManagedScaling_Status
        /// <summary>
        /// <para>
        /// <para>Determines whether to use managed scaling for the capacity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_Status")]
        [AWSConstantClassSource("Amazon.ECS.ManagedScalingStatus")]
        public Amazon.ECS.ManagedScalingStatus ManagedScaling_Status { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the capacity provider to categorize and organize them
        /// more conveniently. Each tag consists of a key and an optional value. You define both
        /// of them.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case-sensitive.</para></li><li><para>Do not use <c>aws:</c>, <c>AWS:</c>, or any upper or lowercase combination of such
        /// as a prefix for either keys or values as it is reserved for Amazon Web Services use.
        /// You cannot edit or delete tag keys or values with this prefix. Tags with this prefix
        /// do not count against your tags per resource limit.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ECS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ManagedScaling_TargetCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity utilization as a percentage for the capacity provider. The specified
        /// value must be greater than <c>0</c> and less than or equal to <c>100</c>. For example,
        /// if you want the capacity provider to maintain 10% spare capacity, then that means
        /// the utilization is 90%, so use a <c>targetCapacity</c> of <c>90</c>. The default value
        /// of <c>100</c> percent results in the Amazon EC2 instances in your Auto Scaling group
        /// being completely used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_TargetCapacity")]
        public System.Int32? ManagedScaling_TargetCapacity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.CreateCapacityProviderResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.CreateCapacityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityProvider";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSCapacityProvider (CreateCapacityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.CreateCapacityProviderResponse, NewECSCapacityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingGroupProvider_AutoScalingGroupArn = this.AutoScalingGroupProvider_AutoScalingGroupArn;
            #if MODULAR
            if (this.AutoScalingGroupProvider_AutoScalingGroupArn == null && ParameterWasBound(nameof(this.AutoScalingGroupProvider_AutoScalingGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupProvider_AutoScalingGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoScalingGroupProvider_ManagedDraining = this.AutoScalingGroupProvider_ManagedDraining;
            context.ManagedScaling_InstanceWarmupPeriod = this.ManagedScaling_InstanceWarmupPeriod;
            context.ManagedScaling_MaximumScalingStepSize = this.ManagedScaling_MaximumScalingStepSize;
            context.ManagedScaling_MinimumScalingStepSize = this.ManagedScaling_MinimumScalingStepSize;
            context.ManagedScaling_Status = this.ManagedScaling_Status;
            context.ManagedScaling_TargetCapacity = this.ManagedScaling_TargetCapacity;
            context.AutoScalingGroupProvider_ManagedTerminationProtection = this.AutoScalingGroupProvider_ManagedTerminationProtection;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ECS.Model.Tag>(this.Tag);
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
            var request = new Amazon.ECS.Model.CreateCapacityProviderRequest();
            
            
             // populate AutoScalingGroupProvider
            var requestAutoScalingGroupProviderIsNull = true;
            request.AutoScalingGroupProvider = new Amazon.ECS.Model.AutoScalingGroupProvider();
            System.String requestAutoScalingGroupProvider_autoScalingGroupProvider_AutoScalingGroupArn = null;
            if (cmdletContext.AutoScalingGroupProvider_AutoScalingGroupArn != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_AutoScalingGroupArn = cmdletContext.AutoScalingGroupProvider_AutoScalingGroupArn;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_AutoScalingGroupArn != null)
            {
                request.AutoScalingGroupProvider.AutoScalingGroupArn = requestAutoScalingGroupProvider_autoScalingGroupProvider_AutoScalingGroupArn;
                requestAutoScalingGroupProviderIsNull = false;
            }
            Amazon.ECS.ManagedDraining requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedDraining = null;
            if (cmdletContext.AutoScalingGroupProvider_ManagedDraining != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedDraining = cmdletContext.AutoScalingGroupProvider_ManagedDraining;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedDraining != null)
            {
                request.AutoScalingGroupProvider.ManagedDraining = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedDraining;
                requestAutoScalingGroupProviderIsNull = false;
            }
            Amazon.ECS.ManagedTerminationProtection requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedTerminationProtection = null;
            if (cmdletContext.AutoScalingGroupProvider_ManagedTerminationProtection != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedTerminationProtection = cmdletContext.AutoScalingGroupProvider_ManagedTerminationProtection;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedTerminationProtection != null)
            {
                request.AutoScalingGroupProvider.ManagedTerminationProtection = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedTerminationProtection;
                requestAutoScalingGroupProviderIsNull = false;
            }
            Amazon.ECS.Model.ManagedScaling requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling = null;
            
             // populate ManagedScaling
            var requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = true;
            requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling = new Amazon.ECS.Model.ManagedScaling();
            System.Int32? requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_InstanceWarmupPeriod = null;
            if (cmdletContext.ManagedScaling_InstanceWarmupPeriod != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_InstanceWarmupPeriod = cmdletContext.ManagedScaling_InstanceWarmupPeriod.Value;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_InstanceWarmupPeriod != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.InstanceWarmupPeriod = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_InstanceWarmupPeriod.Value;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
            System.Int32? requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MaximumScalingStepSize = null;
            if (cmdletContext.ManagedScaling_MaximumScalingStepSize != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MaximumScalingStepSize = cmdletContext.ManagedScaling_MaximumScalingStepSize.Value;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MaximumScalingStepSize != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.MaximumScalingStepSize = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MaximumScalingStepSize.Value;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
            System.Int32? requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MinimumScalingStepSize = null;
            if (cmdletContext.ManagedScaling_MinimumScalingStepSize != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MinimumScalingStepSize = cmdletContext.ManagedScaling_MinimumScalingStepSize.Value;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MinimumScalingStepSize != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.MinimumScalingStepSize = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MinimumScalingStepSize.Value;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
            Amazon.ECS.ManagedScalingStatus requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_Status = null;
            if (cmdletContext.ManagedScaling_Status != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_Status = cmdletContext.ManagedScaling_Status;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_Status != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.Status = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_Status;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
            System.Int32? requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_TargetCapacity = null;
            if (cmdletContext.ManagedScaling_TargetCapacity != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_TargetCapacity = cmdletContext.ManagedScaling_TargetCapacity.Value;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_TargetCapacity != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.TargetCapacity = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_TargetCapacity.Value;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
             // determine if requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling should be set to null
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling = null;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling != null)
            {
                request.AutoScalingGroupProvider.ManagedScaling = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling;
                requestAutoScalingGroupProviderIsNull = false;
            }
             // determine if request.AutoScalingGroupProvider should be set to null
            if (requestAutoScalingGroupProviderIsNull)
            {
                request.AutoScalingGroupProvider = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ECS.Model.CreateCapacityProviderResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.CreateCapacityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "CreateCapacityProvider");
            try
            {
                return client.CreateCapacityProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AutoScalingGroupProvider_AutoScalingGroupArn { get; set; }
            public Amazon.ECS.ManagedDraining AutoScalingGroupProvider_ManagedDraining { get; set; }
            public System.Int32? ManagedScaling_InstanceWarmupPeriod { get; set; }
            public System.Int32? ManagedScaling_MaximumScalingStepSize { get; set; }
            public System.Int32? ManagedScaling_MinimumScalingStepSize { get; set; }
            public Amazon.ECS.ManagedScalingStatus ManagedScaling_Status { get; set; }
            public System.Int32? ManagedScaling_TargetCapacity { get; set; }
            public Amazon.ECS.ManagedTerminationProtection AutoScalingGroupProvider_ManagedTerminationProtection { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ECS.Model.CreateCapacityProviderResponse, NewECSCapacityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityProvider;
        }
        
    }
}
