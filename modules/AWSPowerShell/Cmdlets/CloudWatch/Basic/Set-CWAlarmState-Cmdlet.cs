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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Temporarily sets the state of an alarm for testing purposes. When the updated state
    /// differs from the previous value, the action configured for the appropriate state is
    /// invoked. For example, if your alarm is configured to send an Amazon SNS message when
    /// an alarm is triggered, temporarily changing the alarm state to <c>ALARM</c> sends
    /// an SNS message.
    /// 
    ///  
    /// <para>
    /// Metric alarms returns to their actual state quickly, often within seconds. Because
    /// the metric alarm state change happens quickly, it is typically only visible in the
    /// alarm's <b>History</b> tab in the Amazon CloudWatch console or through <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_DescribeAlarmHistory.html">DescribeAlarmHistory</a>.
    /// </para><para>
    /// If you use <c>SetAlarmState</c> on a composite alarm, the composite alarm is not guaranteed
    /// to return to its actual state. It returns to its actual state only once any of its
    /// children alarms change state. It is also reevaluated if you update its configuration.
    /// </para><para>
    /// If an alarm triggers EC2 Auto Scaling policies or application Auto Scaling policies,
    /// you must include information in the <c>StateReasonData</c> parameter to enable the
    /// policy to take the correct action.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "CWAlarmState", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch SetAlarmState API operation.", Operation = new[] {"SetAlarmState"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.SetAlarmStateResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.SetAlarmStateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.SetAlarmStateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCWAlarmStateCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The name of the alarm.</para>
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
        public System.String AlarmName { get; set; }
        #endregion
        
        #region Parameter StateReason
        /// <summary>
        /// <para>
        /// <para>The reason that this alarm is set to this specific state, in text format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String StateReason { get; set; }
        #endregion
        
        #region Parameter StateReasonData
        /// <summary>
        /// <para>
        /// <para>The reason that this alarm is set to this specific state, in JSON format.</para><para>For SNS or EC2 alarm actions, this is just informational. But for EC2 Auto Scaling
        /// or application Auto Scaling alarm actions, the Auto Scaling policy uses the information
        /// in this field to take the correct action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String StateReasonData { get; set; }
        #endregion
        
        #region Parameter StateValue
        /// <summary>
        /// <para>
        /// <para>The value of the state.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatch.StateValue")]
        public Amazon.CloudWatch.StateValue StateValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.SetAlarmStateResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AlarmName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CWAlarmState (SetAlarmState)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.SetAlarmStateResponse, SetCWAlarmStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AlarmName = this.AlarmName;
            #if MODULAR
            if (this.AlarmName == null && ParameterWasBound(nameof(this.AlarmName)))
            {
                WriteWarning("You are passing $null as a value for parameter AlarmName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StateReason = this.StateReason;
            #if MODULAR
            if (this.StateReason == null && ParameterWasBound(nameof(this.StateReason)))
            {
                WriteWarning("You are passing $null as a value for parameter StateReason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StateReasonData = this.StateReasonData;
            context.StateValue = this.StateValue;
            #if MODULAR
            if (this.StateValue == null && ParameterWasBound(nameof(this.StateValue)))
            {
                WriteWarning("You are passing $null as a value for parameter StateValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatch.Model.SetAlarmStateRequest();
            
            if (cmdletContext.AlarmName != null)
            {
                request.AlarmName = cmdletContext.AlarmName;
            }
            if (cmdletContext.StateReason != null)
            {
                request.StateReason = cmdletContext.StateReason;
            }
            if (cmdletContext.StateReasonData != null)
            {
                request.StateReasonData = cmdletContext.StateReasonData;
            }
            if (cmdletContext.StateValue != null)
            {
                request.StateValue = cmdletContext.StateValue;
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
        
        private Amazon.CloudWatch.Model.SetAlarmStateResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.SetAlarmStateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "SetAlarmState");
            try
            {
                #if DESKTOP
                return client.SetAlarmState(request);
                #elif CORECLR
                return client.SetAlarmStateAsync(request).GetAwaiter().GetResult();
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
            public System.String AlarmName { get; set; }
            public System.String StateReason { get; set; }
            public System.String StateReasonData { get; set; }
            public Amazon.CloudWatch.StateValue StateValue { get; set; }
            public System.Func<Amazon.CloudWatch.Model.SetAlarmStateResponse, SetCWAlarmStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
