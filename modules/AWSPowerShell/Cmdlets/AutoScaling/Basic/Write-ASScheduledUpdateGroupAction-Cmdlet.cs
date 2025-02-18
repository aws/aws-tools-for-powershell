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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Creates or updates a scheduled scaling action for an Auto Scaling group.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-scheduled-scaling.html">Scheduled
    /// scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// You can view the scheduled actions for an Auto Scaling group using the <a href="https://docs.aws.amazon.com/autoscaling/ec2/APIReference/API_DescribeScheduledActions.html">DescribeScheduledActions</a>
    /// API call. If you are no longer using a scheduled action, you can delete it by calling
    /// the <a href="https://docs.aws.amazon.com/autoscaling/ec2/APIReference/API_DeleteScheduledAction.html">DeleteScheduledAction</a>
    /// API.
    /// </para><para>
    /// If you try to schedule your action in the past, Amazon EC2 Auto Scaling returns an
    /// error message.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASScheduledUpdateGroupAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling PutScheduledUpdateGroupAction API operation.", Operation = new[] {"PutScheduledUpdateGroupAction"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.PutScheduledUpdateGroupActionResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.PutScheduledUpdateGroupActionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.PutScheduledUpdateGroupActionResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteASScheduledUpdateGroupActionCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter DesiredCapacity
        /// <summary>
        /// <para>
        /// <para>The desired capacity is the initial capacity of the Auto Scaling group after the scheduled
        /// action runs and the capacity it attempts to maintain. It can scale beyond this capacity
        /// if you add more scaling conditions. </para><note><para>You must specify at least one of the following properties: <c>MaxSize</c>, <c>MinSize</c>,
        /// or <c>DesiredCapacity</c>. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DesiredCapacity { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The date and time for the recurring schedule to end, in UTC. For example, <c>"2021-06-01T00:00:00Z"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum size of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxSize { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum size of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinSize { get; set; }
        #endregion
        
        #region Parameter Recurrence
        /// <summary>
        /// <para>
        /// <para>The recurring schedule for this action. This format consists of five fields separated
        /// by white spaces: [Minute] [Hour] [Day_of_Month] [Month_of_Year] [Day_of_Week]. The
        /// value must be in quotes (for example, <c>"30 0 1 1,6,12 *"</c>). For more information
        /// about this format, see <a href="http://crontab.org">Crontab</a>.</para><para>When <c>StartTime</c> and <c>EndTime</c> are specified with <c>Recurrence</c>, they
        /// form the boundaries of when the recurring action starts and stops.</para><para>Cron expressions use Universal Coordinated Time (UTC) by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Recurrence { get; set; }
        #endregion
        
        #region Parameter ScheduledActionName
        /// <summary>
        /// <para>
        /// <para>The name of this scaling action.</para>
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
        public System.String ScheduledActionName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time for this action to start, in YYYY-MM-DDThh:mm:ssZ format in UTC/GMT
        /// only and in quotes (for example, <c>"2021-06-01T00:00:00Z"</c>).</para><para>If you specify <c>Recurrence</c> and <c>StartTime</c>, Amazon EC2 Auto Scaling performs
        /// the action at this time, and then performs the action based on the specified recurrence.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Time
        /// <summary>
        /// <para>
        /// <para>This property is no longer used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Time { get; set; }
        #endregion
        
        #region Parameter TimeZone
        /// <summary>
        /// <para>
        /// <para>Specifies the time zone for a cron expression. If a time zone is not provided, UTC
        /// is used by default. </para><para>Valid values are the canonical names of the IANA time zones, derived from the IANA
        /// Time Zone Database (such as <c>Etc/GMT+9</c> or <c>Pacific/Tahiti</c>). For more information,
        /// see <a href="https://en.wikipedia.org/wiki/List_of_tz_database_time_zones">https://en.wikipedia.org/wiki/List_of_tz_database_time_zones</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimeZone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.PutScheduledUpdateGroupActionResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASScheduledUpdateGroupAction (PutScheduledUpdateGroupAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.PutScheduledUpdateGroupActionResponse, WriteASScheduledUpdateGroupActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DesiredCapacity = this.DesiredCapacity;
            context.EndTime = this.EndTime;
            context.MaxSize = this.MaxSize;
            context.MinSize = this.MinSize;
            context.Recurrence = this.Recurrence;
            context.ScheduledActionName = this.ScheduledActionName;
            #if MODULAR
            if (this.ScheduledActionName == null && ParameterWasBound(nameof(this.ScheduledActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            context.Time = this.Time;
            context.TimeZone = this.TimeZone;
            
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
            var request = new Amazon.AutoScaling.Model.PutScheduledUpdateGroupActionRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.DesiredCapacity != null)
            {
                request.DesiredCapacity = cmdletContext.DesiredCapacity.Value;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MaxSize != null)
            {
                request.MaxSize = cmdletContext.MaxSize.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
            }
            if (cmdletContext.Recurrence != null)
            {
                request.Recurrence = cmdletContext.Recurrence;
            }
            if (cmdletContext.ScheduledActionName != null)
            {
                request.ScheduledActionName = cmdletContext.ScheduledActionName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Time != null)
            {
                request.Time = cmdletContext.Time.Value;
            }
            if (cmdletContext.TimeZone != null)
            {
                request.TimeZone = cmdletContext.TimeZone;
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
        
        private Amazon.AutoScaling.Model.PutScheduledUpdateGroupActionResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.PutScheduledUpdateGroupActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "PutScheduledUpdateGroupAction");
            try
            {
                return client.PutScheduledUpdateGroupActionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? DesiredCapacity { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.Int32? MaxSize { get; set; }
            public System.Int32? MinSize { get; set; }
            public System.String Recurrence { get; set; }
            public System.String ScheduledActionName { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.DateTime? Time { get; set; }
            public System.String TimeZone { get; set; }
            public System.Func<Amazon.AutoScaling.Model.PutScheduledUpdateGroupActionResponse, WriteASScheduledUpdateGroupActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
