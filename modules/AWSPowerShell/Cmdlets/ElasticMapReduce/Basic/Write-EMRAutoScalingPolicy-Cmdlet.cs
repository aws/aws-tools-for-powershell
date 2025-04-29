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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Creates or updates an automatic scaling policy for a core instance group or task instance
    /// group in an Amazon EMR cluster. The automatic scaling policy defines how an instance
    /// group dynamically adds and terminates Amazon EC2 instances in response to the value
    /// of a CloudWatch metric.
    /// </summary>
    [Cmdlet("Write", "EMRAutoScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce PutAutoScalingPolicy API operation.", Operation = new[] {"PutAutoScalingPolicy"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse))]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse",
        "This cmdlet returns an Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse object containing multiple properties."
    )]
    public partial class WriteEMRAutoScalingPolicyCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of a cluster. The instance group to which the automatic scaling policy
        /// is applied is within this cluster.</para>
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter InstanceGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the instance group to which the automatic scaling policy is applied.</para>
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
        public System.String InstanceGroupId { get; set; }
        #endregion
        
        #region Parameter Constraints_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The upper boundary of Amazon EC2 instances in an instance group beyond which scaling
        /// activities are not allowed to grow. Scale-out activities will not add instances beyond
        /// this boundary.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AutoScalingPolicy_Constraints_MaxCapacity")]
        public System.Int32? Constraints_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter Constraints_MinCapacity
        /// <summary>
        /// <para>
        /// <para>The lower boundary of Amazon EC2 instances in an instance group below which scaling
        /// activities are not allowed to shrink. Scale-in activities will not terminate instances
        /// below this boundary.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AutoScalingPolicy_Constraints_MinCapacity")]
        public System.Int32? Constraints_MinCapacity { get; set; }
        #endregion
        
        #region Parameter AutoScalingPolicy_Rule
        /// <summary>
        /// <para>
        /// <para>The scale-in and scale-out rules that comprise the automatic scaling policy.</para>
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
        [Alias("AutoScalingPolicy_Rules")]
        public Amazon.ElasticMapReduce.Model.ScalingRule[] AutoScalingPolicy_Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMRAutoScalingPolicy (PutAutoScalingPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse, WriteEMRAutoScalingPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Constraints_MaxCapacity = this.Constraints_MaxCapacity;
            #if MODULAR
            if (this.Constraints_MaxCapacity == null && ParameterWasBound(nameof(this.Constraints_MaxCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter Constraints_MaxCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Constraints_MinCapacity = this.Constraints_MinCapacity;
            #if MODULAR
            if (this.Constraints_MinCapacity == null && ParameterWasBound(nameof(this.Constraints_MinCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter Constraints_MinCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AutoScalingPolicy_Rule != null)
            {
                context.AutoScalingPolicy_Rule = new List<Amazon.ElasticMapReduce.Model.ScalingRule>(this.AutoScalingPolicy_Rule);
            }
            #if MODULAR
            if (this.AutoScalingPolicy_Rule == null && ParameterWasBound(nameof(this.AutoScalingPolicy_Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingPolicy_Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceGroupId = this.InstanceGroupId;
            #if MODULAR
            if (this.InstanceGroupId == null && ParameterWasBound(nameof(this.InstanceGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyRequest();
            
            
             // populate AutoScalingPolicy
            var requestAutoScalingPolicyIsNull = true;
            request.AutoScalingPolicy = new Amazon.ElasticMapReduce.Model.AutoScalingPolicy();
            List<Amazon.ElasticMapReduce.Model.ScalingRule> requestAutoScalingPolicy_autoScalingPolicy_Rule = null;
            if (cmdletContext.AutoScalingPolicy_Rule != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Rule = cmdletContext.AutoScalingPolicy_Rule;
            }
            if (requestAutoScalingPolicy_autoScalingPolicy_Rule != null)
            {
                request.AutoScalingPolicy.Rules = requestAutoScalingPolicy_autoScalingPolicy_Rule;
                requestAutoScalingPolicyIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.ScalingConstraints requestAutoScalingPolicy_autoScalingPolicy_Constraints = null;
            
             // populate Constraints
            var requestAutoScalingPolicy_autoScalingPolicy_ConstraintsIsNull = true;
            requestAutoScalingPolicy_autoScalingPolicy_Constraints = new Amazon.ElasticMapReduce.Model.ScalingConstraints();
            System.Int32? requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MaxCapacity = null;
            if (cmdletContext.Constraints_MaxCapacity != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MaxCapacity = cmdletContext.Constraints_MaxCapacity.Value;
            }
            if (requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MaxCapacity != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Constraints.MaxCapacity = requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MaxCapacity.Value;
                requestAutoScalingPolicy_autoScalingPolicy_ConstraintsIsNull = false;
            }
            System.Int32? requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MinCapacity = null;
            if (cmdletContext.Constraints_MinCapacity != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_Constraints_constraints_MinCapacity = cmdletContext.Constraints_MinCapacity.Value;
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
        
        private Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "PutAutoScalingPolicy");
            try
            {
                return client.PutAutoScalingPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Constraints_MaxCapacity { get; set; }
            public System.Int32? Constraints_MinCapacity { get; set; }
            public List<Amazon.ElasticMapReduce.Model.ScalingRule> AutoScalingPolicy_Rule { get; set; }
            public System.String ClusterId { get; set; }
            public System.String InstanceGroupId { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.PutAutoScalingPolicyResponse, WriteEMRAutoScalingPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
