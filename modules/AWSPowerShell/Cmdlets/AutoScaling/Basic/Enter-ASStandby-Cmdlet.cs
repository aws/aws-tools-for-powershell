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
    /// Moves the specified instances into the standby state.
    /// 
    ///  
    /// <para>
    /// If you choose to decrement the desired capacity of the Auto Scaling group, the instances
    /// can enter standby as long as the desired capacity of the Auto Scaling group after
    /// the instances are placed into standby is equal to or greater than the minimum capacity
    /// of the group.
    /// </para><para>
    /// If you choose not to decrement the desired capacity of the Auto Scaling group, the
    /// Auto Scaling group launches new instances to replace the instances on standby.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-enter-exit-standby.html">Temporarily
    /// removing instances from your Auto Scaling group</a> in the <i>Amazon EC2 Auto Scaling
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enter", "ASStandby", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AutoScaling.Model.Activity")]
    [AWSCmdlet("Calls the AWS Auto Scaling EnterStandby API operation.", Operation = new[] {"EnterStandby"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.EnterStandbyResponse))]
    [AWSCmdletOutput("Amazon.AutoScaling.Model.Activity or Amazon.AutoScaling.Model.EnterStandbyResponse",
        "This cmdlet returns a collection of Amazon.AutoScaling.Model.Activity objects.",
        "The service call response (type Amazon.AutoScaling.Model.EnterStandbyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnterASStandbyCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the instances. You can specify up to 20 instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("InstanceIds")]
        public System.String[] InstanceId { get; set; }
        #endregion
        
        #region Parameter ShouldDecrementDesiredCapacity
        /// <summary>
        /// <para>
        /// <para>Indicates whether to decrement the desired capacity of the Auto Scaling group by the
        /// number of instances moved to <c>Standby</c> mode.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? ShouldDecrementDesiredCapacity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Activities'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.EnterStandbyResponse).
        /// Specifying the name of a property of type Amazon.AutoScaling.Model.EnterStandbyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Activities";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enter-ASStandby (EnterStandby)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.EnterStandbyResponse, EnterASStandbyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InstanceId != null)
            {
                context.InstanceId = new List<System.String>(this.InstanceId);
            }
            context.ShouldDecrementDesiredCapacity = this.ShouldDecrementDesiredCapacity;
            #if MODULAR
            if (this.ShouldDecrementDesiredCapacity == null && ParameterWasBound(nameof(this.ShouldDecrementDesiredCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter ShouldDecrementDesiredCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AutoScaling.Model.EnterStandbyRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceIds = cmdletContext.InstanceId;
            }
            if (cmdletContext.ShouldDecrementDesiredCapacity != null)
            {
                request.ShouldDecrementDesiredCapacity = cmdletContext.ShouldDecrementDesiredCapacity.Value;
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
        
        private Amazon.AutoScaling.Model.EnterStandbyResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.EnterStandbyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "EnterStandby");
            try
            {
                #if DESKTOP
                return client.EnterStandby(request);
                #elif CORECLR
                return client.EnterStandbyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> InstanceId { get; set; }
            public System.Boolean? ShouldDecrementDesiredCapacity { get; set; }
            public System.Func<Amazon.AutoScaling.Model.EnterStandbyResponse, EnterASStandbyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Activities;
        }
        
    }
}
