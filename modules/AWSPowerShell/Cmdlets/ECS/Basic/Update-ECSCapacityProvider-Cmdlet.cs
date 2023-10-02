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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Modifies the parameters for a capacity provider.
    /// </summary>
    [Cmdlet("Update", "ECSCapacityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.CapacityProvider")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateCapacityProvider API operation.", Operation = new[] {"UpdateCapacityProvider"}, SelectReturnType = typeof(Amazon.ECS.Model.UpdateCapacityProviderResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.CapacityProvider or Amazon.ECS.Model.UpdateCapacityProviderResponse",
        "This cmdlet returns an Amazon.ECS.Model.CapacityProvider object.",
        "The service call response (type Amazon.ECS.Model.UpdateCapacityProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateECSCapacityProviderCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ManagedScaling_InstanceWarmupPeriod
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, after a newly launched Amazon EC2 instance can contribute
        /// to CloudWatch metrics for Auto Scaling group. If this parameter is omitted, the default
        /// value of <code>300</code> seconds is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_InstanceWarmupPeriod")]
        public System.Int32? ManagedScaling_InstanceWarmupPeriod { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroupProvider_ManagedTerminationProtection
        /// <summary>
        /// <para>
        /// <para>The managed termination protection setting to use for the Auto Scaling group capacity
        /// provider. This determines whether the Auto Scaling group has managed termination protection.</para><important><para>When using managed termination protection, managed scaling must also be used otherwise
        /// managed termination protection doesn't work.</para></important><para>When managed termination protection is on, Amazon ECS prevents the Amazon EC2 instances
        /// in an Auto Scaling group that contain tasks from being terminated during a scale-in
        /// action. The Auto Scaling group and each instance in the Auto Scaling group must have
        /// instance protection from scale-in actions on. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-instance-termination.html#instance-protection">Instance
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
        /// The scale in process is not affected by this parameter. If this parameter is omitted,
        /// the default value of <code>10000</code> is used.</para>
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
        /// the default value of <code>1</code> is used.</para><para>When additional capacity is required, Amazon ECS will scale up the minimum scaling
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
        /// <para>The name of the capacity provider to update.</para>
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
        
        #region Parameter ManagedScaling_TargetCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity utilization as a percentage for the capacity provider. The specified
        /// value must be greater than <code>0</code> and less than or equal to <code>100</code>.
        /// For example, if you want the capacity provider to maintain 10% spare capacity, then
        /// that means the utilization is 90%, so use a <code>targetCapacity</code> of <code>90</code>.
        /// The default value of <code>100</code> percent results in the Amazon EC2 instances
        /// in your Auto Scaling group being completely used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_TargetCapacity")]
        public System.Int32? ManagedScaling_TargetCapacity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.UpdateCapacityProviderResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.UpdateCapacityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityProvider";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSCapacityProvider (UpdateCapacityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.UpdateCapacityProviderResponse, UpdateECSCapacityProviderCmdlet>(Select) ??
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
            var request = new Amazon.ECS.Model.UpdateCapacityProviderRequest();
            
            
             // populate AutoScalingGroupProvider
            var requestAutoScalingGroupProviderIsNull = true;
            request.AutoScalingGroupProvider = new Amazon.ECS.Model.AutoScalingGroupProviderUpdate();
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
        
        private Amazon.ECS.Model.UpdateCapacityProviderResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateCapacityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateCapacityProvider");
            try
            {
                #if DESKTOP
                return client.UpdateCapacityProvider(request);
                #elif CORECLR
                return client.UpdateCapacityProviderAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ManagedScaling_InstanceWarmupPeriod { get; set; }
            public System.Int32? ManagedScaling_MaximumScalingStepSize { get; set; }
            public System.Int32? ManagedScaling_MinimumScalingStepSize { get; set; }
            public Amazon.ECS.ManagedScalingStatus ManagedScaling_Status { get; set; }
            public System.Int32? ManagedScaling_TargetCapacity { get; set; }
            public Amazon.ECS.ManagedTerminationProtection AutoScalingGroupProvider_ManagedTerminationProtection { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.ECS.Model.UpdateCapacityProviderResponse, UpdateECSCapacityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityProvider;
        }
        
    }
}
