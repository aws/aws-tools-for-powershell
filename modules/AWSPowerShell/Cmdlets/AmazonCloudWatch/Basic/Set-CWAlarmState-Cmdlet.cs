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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Temporarily sets the state of an alarm for testing purposes. When the updated state
    /// differs from the previous value, the action configured for the appropriate state is
    /// invoked. For example, if your alarm is configured to send an Amazon SNS message when
    /// an alarm is triggered, temporarily changing the alarm state to <code>ALARM</code>
    /// sends an Amazon SNS message. The alarm returns to its actual state (often within seconds).
    /// Because the alarm state change happens very quickly, it is typically only visible
    /// in the alarm's <b>History</b> tab in the Amazon CloudWatch console or through <a>DescribeAlarmHistory</a>.
    /// </summary>
    [Cmdlet("Set", "CWAlarmState", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetAlarmState operation against Amazon CloudWatch.", Operation = new[] {"SetAlarmState"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AlarmName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudWatch.Model.SetAlarmStateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCWAlarmStateCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The name for the alarm. This name must be unique within the AWS account. The maximum
        /// length is 255 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AlarmName { get; set; }
        #endregion
        
        #region Parameter StateReason
        /// <summary>
        /// <para>
        /// <para>The reason that this alarm is set to this specific state, in text format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String StateReason { get; set; }
        #endregion
        
        #region Parameter StateReasonData
        /// <summary>
        /// <para>
        /// <para>The reason that this alarm is set to this specific state, in JSON format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String StateReasonData { get; set; }
        #endregion
        
        #region Parameter StateValue
        /// <summary>
        /// <para>
        /// <para>The value of the state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [AWSConstantClassSource("Amazon.CloudWatch.StateValue")]
        public Amazon.CloudWatch.StateValue StateValue { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the AlarmName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AlarmName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CWAlarmState (SetAlarmState)"))
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
            
            context.AlarmName = this.AlarmName;
            context.StateReason = this.StateReason;
            context.StateReasonData = this.StateReasonData;
            context.StateValue = this.StateValue;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.AlarmName;
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
        
        private static Amazon.CloudWatch.Model.SetAlarmStateResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.SetAlarmStateRequest request)
        {
            #if DESKTOP
            return client.SetAlarmState(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SetAlarmStateAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AlarmName { get; set; }
            public System.String StateReason { get; set; }
            public System.String StateReasonData { get; set; }
            public Amazon.CloudWatch.StateValue StateValue { get; set; }
        }
        
    }
}
