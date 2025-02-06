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
using Amazon.BackupGateway;
using Amazon.BackupGateway.Model;

namespace Amazon.PowerShell.Cmdlets.BUGW
{
    /// <summary>
    /// Set the maintenance start time for a gateway.
    /// </summary>
    [Cmdlet("Write", "BUGWMaintenanceStartTime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Backup Gateway PutMaintenanceStartTime API operation.", Operation = new[] {"PutMaintenanceStartTime"}, SelectReturnType = typeof(Amazon.BackupGateway.Model.PutMaintenanceStartTimeResponse))]
    [AWSCmdletOutput("System.String or Amazon.BackupGateway.Model.PutMaintenanceStartTimeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BackupGateway.Model.PutMaintenanceStartTimeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteBUGWMaintenanceStartTimeCmdlet : AmazonBackupGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DayOfMonth
        /// <summary>
        /// <para>
        /// <para>The day of the month start maintenance on a gateway.</para><para>Valid values range from <c>Sunday</c> to <c>Saturday</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DayOfMonth { get; set; }
        #endregion
        
        #region Parameter DayOfWeek
        /// <summary>
        /// <para>
        /// <para>The day of the week to start maintenance on a gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DayOfWeek { get; set; }
        #endregion
        
        #region Parameter GatewayArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the gateway, used to specify its maintenance start
        /// time.</para>
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
        public System.String GatewayArn { get; set; }
        #endregion
        
        #region Parameter HourOfDay
        /// <summary>
        /// <para>
        /// <para>The hour of the day to start maintenance on a gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? HourOfDay { get; set; }
        #endregion
        
        #region Parameter MinuteOfHour
        /// <summary>
        /// <para>
        /// <para>The minute of the hour to start maintenance on a gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? MinuteOfHour { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupGateway.Model.PutMaintenanceStartTimeResponse).
        /// Specifying the name of a property of type Amazon.BackupGateway.Model.PutMaintenanceStartTimeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BUGWMaintenanceStartTime (PutMaintenanceStartTime)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupGateway.Model.PutMaintenanceStartTimeResponse, WriteBUGWMaintenanceStartTimeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DayOfMonth = this.DayOfMonth;
            context.DayOfWeek = this.DayOfWeek;
            context.GatewayArn = this.GatewayArn;
            #if MODULAR
            if (this.GatewayArn == null && ParameterWasBound(nameof(this.GatewayArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HourOfDay = this.HourOfDay;
            #if MODULAR
            if (this.HourOfDay == null && ParameterWasBound(nameof(this.HourOfDay)))
            {
                WriteWarning("You are passing $null as a value for parameter HourOfDay which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinuteOfHour = this.MinuteOfHour;
            #if MODULAR
            if (this.MinuteOfHour == null && ParameterWasBound(nameof(this.MinuteOfHour)))
            {
                WriteWarning("You are passing $null as a value for parameter MinuteOfHour which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BackupGateway.Model.PutMaintenanceStartTimeRequest();
            
            if (cmdletContext.DayOfMonth != null)
            {
                request.DayOfMonth = cmdletContext.DayOfMonth.Value;
            }
            if (cmdletContext.DayOfWeek != null)
            {
                request.DayOfWeek = cmdletContext.DayOfWeek.Value;
            }
            if (cmdletContext.GatewayArn != null)
            {
                request.GatewayArn = cmdletContext.GatewayArn;
            }
            if (cmdletContext.HourOfDay != null)
            {
                request.HourOfDay = cmdletContext.HourOfDay.Value;
            }
            if (cmdletContext.MinuteOfHour != null)
            {
                request.MinuteOfHour = cmdletContext.MinuteOfHour.Value;
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
        
        private Amazon.BackupGateway.Model.PutMaintenanceStartTimeResponse CallAWSServiceOperation(IAmazonBackupGateway client, Amazon.BackupGateway.Model.PutMaintenanceStartTimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Gateway", "PutMaintenanceStartTime");
            try
            {
                #if DESKTOP
                return client.PutMaintenanceStartTime(request);
                #elif CORECLR
                return client.PutMaintenanceStartTimeAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DayOfMonth { get; set; }
            public System.Int32? DayOfWeek { get; set; }
            public System.String GatewayArn { get; set; }
            public System.Int32? HourOfDay { get; set; }
            public System.Int32? MinuteOfHour { get; set; }
            public System.Func<Amazon.BackupGateway.Model.PutMaintenanceStartTimeResponse, WriteBUGWMaintenanceStartTimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayArn;
        }
        
    }
}
