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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Removes one or more instances from the specified Auto Scaling group.
    /// 
    ///  
    /// <para>
    /// After the instances are detached, you can manage them independent of the Auto Scaling
    /// group.
    /// </para><para>
    /// If you do not specify the option to decrement the desired capacity, Auto Scaling launches
    /// instances to replace the ones that are detached.
    /// </para><para>
    /// If there is a Classic Load Balancer attached to the Auto Scaling group, the instances
    /// are deregistered from the load balancer. If there are target groups attached to the
    /// Auto Scaling group, the instances are deregistered from the target groups.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/autoscaling/latest/userguide/detach-instance-asg.html">Detach
    /// EC2 Instances from Your Auto Scaling Group</a> in the <i>Auto Scaling User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Dismount", "ASInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AutoScaling.Model.Activity")]
    [AWSCmdlet("Invokes the DetachInstances operation against Auto Scaling.", Operation = new[] {"DetachInstances"}, LegacyAlias="Dismount-ASInstances")]
    [AWSCmdletOutput("Amazon.AutoScaling.Model.Activity",
        "This cmdlet returns a collection of Activity objects.",
        "The service call response (type Amazon.AutoScaling.Model.DetachInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DismountASInstanceCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>One or more instance IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("InstanceIds")]
        public System.String[] InstanceId { get; set; }
        #endregion
        
        #region Parameter ShouldDecrementDesiredCapacity
        /// <summary>
        /// <para>
        /// <para>If <code>True</code>, the Auto Scaling group decrements the desired capacity value
        /// by the number of instances detached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ShouldDecrementDesiredCapacity { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Dismount-ASInstance (DetachInstances)"))
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
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            if (this.InstanceId != null)
            {
                context.InstanceIds = new List<System.String>(this.InstanceId);
            }
            if (ParameterWasBound("ShouldDecrementDesiredCapacity"))
                context.ShouldDecrementDesiredCapacity = this.ShouldDecrementDesiredCapacity;
            
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
            var request = new Amazon.AutoScaling.Model.DetachInstancesRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.InstanceIds != null)
            {
                request.InstanceIds = cmdletContext.InstanceIds;
            }
            if (cmdletContext.ShouldDecrementDesiredCapacity != null)
            {
                request.ShouldDecrementDesiredCapacity = cmdletContext.ShouldDecrementDesiredCapacity.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Activities;
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
        
        private Amazon.AutoScaling.Model.DetachInstancesResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.DetachInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Auto Scaling", "DetachInstances");
            try
            {
                #if DESKTOP
                return client.DetachInstances(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DetachInstancesAsync(request);
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
            public System.String AutoScalingGroupName { get; set; }
            public List<System.String> InstanceIds { get; set; }
            public System.Boolean? ShouldDecrementDesiredCapacity { get; set; }
        }
        
    }
}
