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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Creates or updates a warm pool for the specified Auto Scaling group. A warm pool is
    /// a pool of pre-initialized EC2 instances that sits alongside the Auto Scaling group.
    /// Whenever your application needs to scale out, the Auto Scaling group can draw on the
    /// warm pool to meet its new desired capacity. For more information and example configurations,
    /// see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-warm-pools.html">Warm
    /// pools for Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// 
    ///  
    /// <para>
    /// This operation must be called from the Region in which the Auto Scaling group was
    /// created. This operation cannot be called on an Auto Scaling group that has a mixed
    /// instances policy or a launch template or launch configuration that requests Spot Instances.
    /// </para><para>
    /// You can view the instances in the warm pool using the <a>DescribeWarmPool</a> API
    /// call. If you are no longer using a warm pool, you can delete it by calling the <a>DeleteWarmPool</a>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASWarmPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling PutWarmPool API operation.", Operation = new[] {"PutWarmPool"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.PutWarmPoolResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.PutWarmPoolResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.PutWarmPoolResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteASWarmPoolCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
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
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter MaxGroupPreparedCapacity
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of instances that are allowed to be in the warm pool
        /// or in any state except <code>Terminated</code> for the Auto Scaling group. This is
        /// an optional property. Specify it only if you do not want the warm pool size to be
        /// determined by the difference between the group's maximum capacity and its desired
        /// capacity. </para><important><para>If a value for <code>MaxGroupPreparedCapacity</code> is not specified, Amazon EC2
        /// Auto Scaling launches and maintains the difference between the group's maximum capacity
        /// and its desired capacity. If you specify a value for <code>MaxGroupPreparedCapacity</code>,
        /// Amazon EC2 Auto Scaling uses the difference between the <code>MaxGroupPreparedCapacity</code>
        /// and the desired capacity instead. </para><para>The size of the warm pool is dynamic. Only when <code>MaxGroupPreparedCapacity</code>
        /// and <code>MinSize</code> are set to the same value does the warm pool have an absolute
        /// size.</para></important><para>If the desired capacity of the Auto Scaling group is higher than the <code>MaxGroupPreparedCapacity</code>,
        /// the capacity of the warm pool is 0, unless you specify a value for <code>MinSize</code>.
        /// To remove a value that you previously set, include the property but specify -1 for
        /// the value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxGroupPreparedCapacity { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum number of instances to maintain in the warm pool. This helps
        /// you to ensure that there is always a certain number of warmed instances available
        /// to handle traffic spikes. Defaults to 0 if not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinSize { get; set; }
        #endregion
        
        #region Parameter PoolState
        /// <summary>
        /// <para>
        /// <para>Sets the instance state to transition to after the lifecycle actions are complete.
        /// Default is <code>Stopped</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.WarmPoolState")]
        public Amazon.AutoScaling.WarmPoolState PoolState { get; set; }
        #endregion
        
        #region Parameter InstanceReusePolicy_ReuseOnScaleIn
        /// <summary>
        /// <para>
        /// <para>Specifies whether instances in the Auto Scaling group can be returned to the warm
        /// pool on scale in. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstanceReusePolicy_ReuseOnScaleIn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.PutWarmPoolResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoScalingGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASWarmPool (PutWarmPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.PutWarmPoolResponse, WriteASWarmPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoScalingGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceReusePolicy_ReuseOnScaleIn = this.InstanceReusePolicy_ReuseOnScaleIn;
            context.MaxGroupPreparedCapacity = this.MaxGroupPreparedCapacity;
            context.MinSize = this.MinSize;
            context.PoolState = this.PoolState;
            
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
            var request = new Amazon.AutoScaling.Model.PutWarmPoolRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            
             // populate InstanceReusePolicy
            var requestInstanceReusePolicyIsNull = true;
            request.InstanceReusePolicy = new Amazon.AutoScaling.Model.InstanceReusePolicy();
            System.Boolean? requestInstanceReusePolicy_instanceReusePolicy_ReuseOnScaleIn = null;
            if (cmdletContext.InstanceReusePolicy_ReuseOnScaleIn != null)
            {
                requestInstanceReusePolicy_instanceReusePolicy_ReuseOnScaleIn = cmdletContext.InstanceReusePolicy_ReuseOnScaleIn.Value;
            }
            if (requestInstanceReusePolicy_instanceReusePolicy_ReuseOnScaleIn != null)
            {
                request.InstanceReusePolicy.ReuseOnScaleIn = requestInstanceReusePolicy_instanceReusePolicy_ReuseOnScaleIn.Value;
                requestInstanceReusePolicyIsNull = false;
            }
             // determine if request.InstanceReusePolicy should be set to null
            if (requestInstanceReusePolicyIsNull)
            {
                request.InstanceReusePolicy = null;
            }
            if (cmdletContext.MaxGroupPreparedCapacity != null)
            {
                request.MaxGroupPreparedCapacity = cmdletContext.MaxGroupPreparedCapacity.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
            }
            if (cmdletContext.PoolState != null)
            {
                request.PoolState = cmdletContext.PoolState;
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
        
        private Amazon.AutoScaling.Model.PutWarmPoolResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.PutWarmPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "PutWarmPool");
            try
            {
                #if DESKTOP
                return client.PutWarmPool(request);
                #elif CORECLR
                return client.PutWarmPoolAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingGroupName { get; set; }
            public System.Boolean? InstanceReusePolicy_ReuseOnScaleIn { get; set; }
            public System.Int32? MaxGroupPreparedCapacity { get; set; }
            public System.Int32? MinSize { get; set; }
            public Amazon.AutoScaling.WarmPoolState PoolState { get; set; }
            public System.Func<Amazon.AutoScaling.Model.PutWarmPoolResponse, WriteASWarmPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
