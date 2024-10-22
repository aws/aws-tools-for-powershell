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
    /// Deletes the specified alarms. You can delete up to 100 alarms in one operation. However,
    /// this total can include no more than one composite alarm. For example, you could delete
    /// 99 metric alarms and one composite alarms with one operation, but you can't delete
    /// two composite alarms with one operation.
    /// 
    ///  
    /// <para>
    ///  If you specify an incorrect alarm name or make any other error in the operation,
    /// no alarms are deleted. To confirm that alarms were deleted successfully, you can use
    /// the <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_DescribeAlarms.html">DescribeAlarms</a>
    /// operation after using <c>DeleteAlarms</c>.
    /// </para><note><para>
    /// It is possible to create a loop or cycle of composite alarms, where composite alarm
    /// A depends on composite alarm B, and composite alarm B also depends on composite alarm
    /// A. In this scenario, you can't delete any composite alarm that is part of the cycle
    /// because there is always still a composite alarm that depends on that alarm that you
    /// want to delete.
    /// </para><para>
    /// To get out of such a situation, you must break the cycle by changing the rule of one
    /// of the composite alarms in the cycle to remove a dependency that creates the cycle.
    /// The simplest change to make to break a cycle is to change the <c>AlarmRule</c> of
    /// one of the alarms to <c>false</c>. 
    /// </para><para>
    /// Additionally, the evaluation of composite alarms stops if CloudWatch detects a cycle
    /// in the evaluation path. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "CWAlarm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch DeleteAlarms API operation.", Operation = new[] {"DeleteAlarms"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.DeleteAlarmsResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.DeleteAlarmsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.DeleteAlarmsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCWAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The alarms to be deleted. Do not enclose the alarm names in quote marks.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AlarmNames")]
        public System.String[] AlarmName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.DeleteAlarmsResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CWAlarm (DeleteAlarms)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.DeleteAlarmsResponse, RemoveCWAlarmCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AlarmName != null)
            {
                context.AlarmName = new List<System.String>(this.AlarmName);
            }
            #if MODULAR
            if (this.AlarmName == null && ParameterWasBound(nameof(this.AlarmName)))
            {
                WriteWarning("You are passing $null as a value for parameter AlarmName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatch.Model.DeleteAlarmsRequest();
            
            if (cmdletContext.AlarmName != null)
            {
                request.AlarmNames = cmdletContext.AlarmName;
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
        
        private Amazon.CloudWatch.Model.DeleteAlarmsResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.DeleteAlarmsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "DeleteAlarms");
            try
            {
                #if DESKTOP
                return client.DeleteAlarms(request);
                #elif CORECLR
                return client.DeleteAlarmsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AlarmName { get; set; }
            public System.Func<Amazon.CloudWatch.Model.DeleteAlarmsResponse, RemoveCWAlarmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
