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
    /// Creates or updates an automatic scaling policy for a core instance group or task instance
    /// group in an Amazon EMR cluster. The automatic scaling policy defines how an instance
    /// group dynamically adds and terminates EC2 instances in response to the value of a
    /// CloudWatch metric.
    /// </summary>
    [Cmdlet("Write", "EMRAutoScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse")]
    [AWSCmdlet("Invokes the PutAutoScalingPolicy operation against Amazon Elastic MapReduce.", Operation = new[] {"PutAutoScalingPolicy"})]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse",
        "This cmdlet returns a Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteEMRAutoScalingPolicyCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of a cluster. The instance group to which the automatic scaling policy
        /// is applied is within this cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter InstanceGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the instance group to which the automatic scaling policy is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceGroupId { get; set; }
        #endregion
        
        #region Parameter Constraints_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The upper boundary of EC2 instances in an instance group beyond which scaling activities
        /// are not allowed to grow. Scale-out activities will not add instances beyond this boundary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoScalingPolicy_Constraints_MaxCapacity")]
        public System.Int32 Constraints_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter Constraints_MinCapacity
        /// <summary>
        /// <para>
        /// <para>The lower boundary of EC2 instances in an instance group below which scaling activities
        /// are not allowed to shrink. Scale-in activities will not terminate instances below
        /// this boundary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoScalingPolicy_Constraints_MinCapacity")]
        public System.Int32 Constraints_MinCapacity { get; set; }
        #endregion
        
        #region Parameter AutoScalingPolicy_Rule
        /// <summary>
        /// <para>
        /// <para>The scale-in and scale-out rules that comprise the automatic scaling policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoScalingPolicy_Rules")]
        public Amazon.ElasticMapReduce.Model.ScalingRule[] AutoScalingPolicy_Rule { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMRAutoScalingPolicy (PutAutoScalingPolicy)"))
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
            
            if (ParameterWasBound("Constraints_MaxCapacity"))
                context.AutoScalingPolicy_Constraints_MaxCapacity = this.Constraints_MaxCapacity;
            if (ParameterWasBound("Constraints_MinCapacity"))
                context.AutoScalingPolicy_Constraints_MinCapacity = this.Constraints_MinCapacity;
            if (this.AutoScalingPolicy_Rule != null)
            {
                context.AutoScalingPolicy_Rules = new List<Amazon.ElasticMapReduce.Model.ScalingRule>(this.AutoScalingPolicy_Rule);
            }
            context.ClusterId = this.ClusterId;
            context.InstanceGroupId = this.InstanceGroupId;
            
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
            var request = new Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyRequest();
            
            
             // populate AutoScalingPolicy
            bool requestAutoScalingPolicyIsNull = true;
            request.AutoScalingPolicy = new Amazon.ElasticMapReduce.Model.AutoScalingPolicy();
            List<Amazon.ElasticMapReduce.Model.ScalingRule> requestAutoScalingPolicy_autoScalingPolicy_Rule = null;
            if (cmdletContext.AutoScalingPolicy_Rules != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Rule = cmdletContext.AutoScalingPolicy_Rules;
            }
            if (requestAutoScalingPolicy_autoScalingPolicy_Rule != null)
            {
                request.AutoScalingPolicy.Rules = requestAutoScalingPolicy_autoScalingPolicy_Rule;
                requestAutoScalingPolicyIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.ScalingConstraints requestAutoScalingPolicy_autoScalingPolicy_Constraints = null;
            
             // populate Constraints
            bool requestAutoScalingPolicy_autoScalingPolicy_ConstraintsIsNull = true;
            requestAutoScalingPolicy_autoScalingPolicy_Constraints = new Amazon.ElasticMapReduce.Model.ScalingConstraints();
            System.Int32? requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MaxCapacity = null;
            if (cmdletContext.AutoScalingPolicy_Constraints_MaxCapacity != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MaxCapacity = cmdletContext.AutoScalingPolicy_Constraints_MaxCapacity.Value;
            }
            if (requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MaxCapacity != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Constraints.MaxCapacity = requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MaxCapacity.Value;
                requestAutoScalingPolicy_autoScalingPolicy_ConstraintsIsNull = false;
            }
            System.Int32? requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MinCapacity = null;
            if (cmdletContext.AutoScalingPolicy_Constraints_MinCapacity != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MinCapacity = cmdletContext.AutoScalingPolicy_Constraints_MinCapacity.Value;
            }
            if (requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MinCapacity != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Constraints.MinCapacity = requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MinCapacity.Value;
                requestAutoScalingPolicy_autoScalingPolicy_ConstraintsIsNull = false;
            }
             // determine if requestAutoScalingPolicy_autoScalingPolicy_Constraints should be set to null
            if (requestAutoScalingPolicy_autoScalingPolicy_ConstraintsIsNull)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Constraints = null;
            }
            if (requestAutoScalingPolicy_autoScalingPolicy_Constraints != null)
            {
                request.AutoScalingPolicy.Constraints = requestAutoScalingPolicy_autoScalingPolicy_Constraints;
                requestAutoScalingPolicyIsNull = false;
            }
             // determine if request.AutoScalingPolicy should be set to null
            if (requestAutoScalingPolicyIsNull)
            {
                request.AutoScalingPolicy = null;
            }
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.InstanceGroupId != null)
            {
                request.InstanceGroupId = cmdletContext.InstanceGroupId;
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
        
        private Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "PutAutoScalingPolicy");
            #if DESKTOP
            return client.PutAutoScalingPolicy(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutAutoScalingPolicyAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? AutoScalingPolicy_Constraints_MaxCapacity { get; set; }
            public System.Int32? AutoScalingPolicy_Constraints_MinCapacity { get; set; }
            public List<Amazon.ElasticMapReduce.Model.ScalingRule> AutoScalingPolicy_Rules { get; set; }
            public System.String ClusterId { get; set; }
            public System.String InstanceGroupId { get; set; }
        }
        
    }
}
