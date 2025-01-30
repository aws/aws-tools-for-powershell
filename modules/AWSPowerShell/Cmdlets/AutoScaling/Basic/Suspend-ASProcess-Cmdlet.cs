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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Suspends the specified auto scaling processes, or all processes, for the specified
    /// Auto Scaling group.
    /// 
    ///  
    /// <para>
    /// If you suspend either the <c>Launch</c> or <c>Terminate</c> process types, it can
    /// prevent other process types from functioning properly. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-suspend-resume-processes.html">Suspend
    /// and resume Amazon EC2 Auto Scaling processes</a> in the <i>Amazon EC2 Auto Scaling
    /// User Guide</i>.
    /// </para><para>
    /// To resume processes that have been suspended, call the <a href="https://docs.aws.amazon.com/autoscaling/ec2/APIReference/API_ResumeProcesses.html">ResumeProcesses</a>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("Suspend", "ASProcess", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling SuspendProcesses API operation.", Operation = new[] {"SuspendProcesses"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.SuspendProcessesResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.SuspendProcessesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.SuspendProcessesResponse) be returned by specifying '-Select *'."
    )]
    public partial class SuspendASProcessCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter ScalingProcess
        /// <summary>
        /// <para>
        /// <para>One or more of the following processes:</para><ul><li><para><c>Launch</c></para></li><li><para><c>Terminate</c></para></li><li><para><c>AddToLoadBalancer</c></para></li><li><para><c>AlarmNotification</c></para></li><li><para><c>AZRebalance</c></para></li><li><para><c>HealthCheck</c></para></li><li><para><c>InstanceRefresh</c></para></li><li><para><c>ReplaceUnhealthy</c></para></li><li><para><c>ScheduledActions</c></para></li></ul><para>If you omit this property, all processes are specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("ScalingProcesses")]
        public System.String[] ScalingProcess { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.SuspendProcessesResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Suspend-ASProcess (SuspendProcesses)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.SuspendProcessesResponse, SuspendASProcessCmdlet>(Select) ??
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
            if (this.ScalingProcess != null)
            {
                context.ScalingProcess = new List<System.String>(this.ScalingProcess);
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
            var request = new Amazon.AutoScaling.Model.SuspendProcessesRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.ScalingProcess != null)
            {
                request.ScalingProcesses = cmdletContext.ScalingProcess;
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
        
        private Amazon.AutoScaling.Model.SuspendProcessesResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.SuspendProcessesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "SuspendProcesses");
            try
            {
                #if DESKTOP
                return client.SuspendProcesses(request);
                #elif CORECLR
                return client.SuspendProcessesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ScalingProcess { get; set; }
            public System.Func<Amazon.AutoScaling.Model.SuspendProcessesResponse, SuspendASProcessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
