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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Creates or updates an alarm mute rule.
    /// 
    ///  
    /// <para>
    /// Alarm mute rules automatically mute alarm actions during predefined time windows.
    /// When a mute rule is active, targeted alarms continue to evaluate metrics and transition
    /// between states, but their configured actions (such as Amazon SNS notifications or
    /// Auto Scaling actions) are muted.
    /// </para><para>
    /// You can create mute rules with recurring schedules using <c>cron</c> expressions or
    /// one-time mute windows using <c>at</c> expressions. Each mute rule can target up to
    /// 100 specific alarms by name.
    /// </para><para>
    /// If you specify a rule name that already exists, this operation updates the existing
    /// rule with the new configuration.
    /// </para><para><b>Permissions</b></para><para>
    /// To create or update a mute rule, you must have the <c>cloudwatch:PutAlarmMuteRule</c>
    /// permission on two types of resources: the alarm mute rule resource itself, and each
    /// alarm that the rule targets.
    /// </para><para>
    /// For example, If you want to allow a user to create mute rules that target only specific
    /// alarms named "WebServerCPUAlarm" and "DatabaseConnectionAlarm", you would create an
    /// IAM policy with one statement granting <c>cloudwatch:PutAlarmMuteRule</c> on the alarm
    /// mute rule resource (<c>arn:aws:cloudwatch:[REGION]:123456789012:alarm-mute:*</c>),
    /// and another statement granting <c>cloudwatch:PutAlarmMuteRule</c> on the targeted
    /// alarm resources (<c>arn:aws:cloudwatch:[REGION]:123456789012:alarm:WebServerCPUAlarm</c>
    /// and <c>arn:aws:cloudwatch:[REGION]:123456789012:alarm:DatabaseConnectionAlarm</c>).
    /// </para><para>
    /// You can also use IAM policy conditions to allow targeting alarms based on resource
    /// tags. For example, you can restrict users to create/update mute rules to only target
    /// alarms that have a specific tag key-value pair, such as <c>Team=TeamA</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWAlarmMuteRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutAlarmMuteRule API operation.", Operation = new[] {"PutAlarmMuteRule"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutAlarmMuteRuleResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.PutAlarmMuteRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.PutAlarmMuteRuleResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWAlarmMuteRuleCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MuteTargets_AlarmName
        /// <summary>
        /// <para>
        /// <para>The list of alarm names that this mute rule targets. You can specify up to 100 alarm
        /// names.</para><para>Each alarm name must be between 1 and 255 characters in length. The alarm names must
        /// match existing alarms in your Amazon Web Services account and region.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MuteTargets_AlarmNames")]
        public System.String[] MuteTargets_AlarmName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the alarm mute rule that helps you identify its purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Rule_Schedule_Duration
        /// <summary>
        /// <para>
        /// <para>The length of time that alarms remain muted when the schedule activates. The duration
        /// must be between 1 and 50 characters in length.</para><para>Specify the duration using ISO 8601 duration format with a minimum of 1 minute (<c>PT1M</c>)
        /// and maximum of 15 days (<c>P15D</c>).</para><para>Examples:</para><ul><li><para><c>PT4H</c> - 4 hours for weekly system maintenance</para></li><li><para><c>P2DT12H</c> - 2 days and 12 hours for weekend muting from Friday 6:00 PM to Monday
        /// 6:00 AM</para></li><li><para><c>PT6H</c> - 6 hours for monthly database maintenance</para></li><li><para><c>PT2H</c> - 2 hours for nightly backup operations</para></li><li><para><c>P7D</c> - 7 days for annual company shutdown</para></li></ul><para>The duration begins when the schedule expression time is reached. For recurring schedules,
        /// the duration applies to each occurrence.</para>
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
        public System.String Rule_Schedule_Duration { get; set; }
        #endregion
        
        #region Parameter ExpireDate
        /// <summary>
        /// <para>
        /// <para>The date and time when the mute rule expires and is no longer evaluated. After this
        /// time, the rule status becomes EXPIRED and will no longer mute the targeted alarms.
        /// This date and time is interpreted according to the schedule timezone, or UTC if no
        /// timezone is specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpireDate { get; set; }
        #endregion
        
        #region Parameter Rule_Schedule_Expression
        /// <summary>
        /// <para>
        /// <para>The schedule expression that defines when the mute rule activates. The expression
        /// must be between 1 and 256 characters in length.</para><para>You can use one of two expression formats:</para><ul><li><para><b>Cron expressions</b> - For recurring mute windows. Format: <c>cron(Minutes Hours
        /// Day-of-month Month Day-of-week)</c></para><para>Examples:</para><ul><li><para><c>cron(0 2 * * *)</c> - Activates daily at 2:00 AM</para></li><li><para><c>cron(0 2 * * SUN)</c> - Activates every Sunday at 2:00 AM for weekly system maintenance</para></li><li><para><c>cron(0 1 1 * *)</c> - Activates on the first day of each month at 1:00 AM for
        /// monthly database maintenance</para></li><li><para><c>cron(0 18 * * FRI)</c> - Activates every Friday at 6:00 PM</para></li><li><para><c>cron(0 23 * * *)</c> - Activates every day at 11:00 PM during nightly backup operations</para></li></ul><para>The characters <c>*</c>, <c>-</c>, and <c>,</c> are supported in all fields. English
        /// names can be used for the month (JAN-DEC) and day of week (SUN-SAT) fields.</para></li><li><para><b>At expressions</b> - For one-time mute windows. Format: <c>at(yyyy-MM-ddThh:mm)</c></para><para>Examples:</para><ul><li><para><c>at(2024-05-10T14:00)</c> - Activates once on May 10, 2024 at 2:00 PM during an
        /// active incident response session</para></li><li><para><c>at(2024-12-23T00:00)</c> - Activates once on December 23, 2024 at midnight during
        /// annual company shutdown</para></li></ul></li></ul>
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
        public System.String Rule_Schedule_Expression { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the alarm mute rule. This name must be unique within your Amazon Web Services
        /// account and region.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The date and time after which the mute rule takes effect. If not specified, the mute
        /// rule takes effect immediately upon creation and the mutes are applied as per the schedule
        /// expression. This date and time is interpreted according to the schedule timezone,
        /// or UTC if no timezone is specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartDate { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the alarm mute rule. You can use tags
        /// to categorize and manage your mute rules.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudWatch.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Rule_Schedule_Timezone
        /// <summary>
        /// <para>
        /// <para>The time zone to use when evaluating the schedule expression. The time zone must be
        /// between 1 and 50 characters in length.</para><para>Specify the time zone using standard timezone identifiers (for example, <c>America/New_York</c>,
        /// <c>Europe/London</c>, or <c>Asia/Tokyo</c>).</para><para>If you don't specify a time zone, UTC is used by default. The time zone affects how
        /// cron and at expressions are interpreted, as well as start and expire dates you specify</para><para>Examples:</para><ul><li><para><c>America/New_York</c> - Eastern Time (US)</para></li><li><para><c>America/Los_Angeles</c> - Pacific Time (US)</para></li><li><para><c>Europe/London</c> - British Time</para></li><li><para><c>Asia/Tokyo</c> - Japan Standard Time</para></li><li><para><c>UTC</c> - Coordinated Universal Time</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Rule_Schedule_Timezone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutAlarmMuteRuleResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWAlarmMuteRule (PutAlarmMuteRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutAlarmMuteRuleResponse, WriteCWAlarmMuteRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.ExpireDate = this.ExpireDate;
            if (this.MuteTargets_AlarmName != null)
            {
                context.MuteTargets_AlarmName = new List<System.String>(this.MuteTargets_AlarmName);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rule_Schedule_Duration = this.Rule_Schedule_Duration;
            #if MODULAR
            if (this.Rule_Schedule_Duration == null && ParameterWasBound(nameof(this.Rule_Schedule_Duration)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule_Schedule_Duration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rule_Schedule_Expression = this.Rule_Schedule_Expression;
            #if MODULAR
            if (this.Rule_Schedule_Expression == null && ParameterWasBound(nameof(this.Rule_Schedule_Expression)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule_Schedule_Expression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rule_Schedule_Timezone = this.Rule_Schedule_Timezone;
            context.StartDate = this.StartDate;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudWatch.Model.Tag>(this.Tag);
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
            var request = new Amazon.CloudWatch.Model.PutAlarmMuteRuleRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExpireDate != null)
            {
                request.ExpireDate = cmdletContext.ExpireDate.Value;
            }
            
             // populate MuteTargets
            var requestMuteTargetsIsNull = true;
            request.MuteTargets = new Amazon.CloudWatch.Model.MuteTargets();
            List<System.String> requestMuteTargets_muteTargets_AlarmName = null;
            if (cmdletContext.MuteTargets_AlarmName != null)
            {
                requestMuteTargets_muteTargets_AlarmName = cmdletContext.MuteTargets_AlarmName;
            }
            if (requestMuteTargets_muteTargets_AlarmName != null)
            {
                request.MuteTargets.AlarmNames = requestMuteTargets_muteTargets_AlarmName;
                requestMuteTargetsIsNull = false;
            }
             // determine if request.MuteTargets should be set to null
            if (requestMuteTargetsIsNull)
            {
                request.MuteTargets = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.CloudWatch.Model.Rule();
            Amazon.CloudWatch.Model.Schedule requestRule_rule_Schedule = null;
            
             // populate Schedule
            var requestRule_rule_ScheduleIsNull = true;
            requestRule_rule_Schedule = new Amazon.CloudWatch.Model.Schedule();
            System.String requestRule_rule_Schedule_rule_Schedule_Duration = null;
            if (cmdletContext.Rule_Schedule_Duration != null)
            {
                requestRule_rule_Schedule_rule_Schedule_Duration = cmdletContext.Rule_Schedule_Duration;
            }
            if (requestRule_rule_Schedule_rule_Schedule_Duration != null)
            {
                requestRule_rule_Schedule.Duration = requestRule_rule_Schedule_rule_Schedule_Duration;
                requestRule_rule_ScheduleIsNull = false;
            }
            System.String requestRule_rule_Schedule_rule_Schedule_Expression = null;
            if (cmdletContext.Rule_Schedule_Expression != null)
            {
                requestRule_rule_Schedule_rule_Schedule_Expression = cmdletContext.Rule_Schedule_Expression;
            }
            if (requestRule_rule_Schedule_rule_Schedule_Expression != null)
            {
                requestRule_rule_Schedule.Expression = requestRule_rule_Schedule_rule_Schedule_Expression;
                requestRule_rule_ScheduleIsNull = false;
            }
            System.String requestRule_rule_Schedule_rule_Schedule_Timezone = null;
            if (cmdletContext.Rule_Schedule_Timezone != null)
            {
                requestRule_rule_Schedule_rule_Schedule_Timezone = cmdletContext.Rule_Schedule_Timezone;
            }
            if (requestRule_rule_Schedule_rule_Schedule_Timezone != null)
            {
                requestRule_rule_Schedule.Timezone = requestRule_rule_Schedule_rule_Schedule_Timezone;
                requestRule_rule_ScheduleIsNull = false;
            }
             // determine if requestRule_rule_Schedule should be set to null
            if (requestRule_rule_ScheduleIsNull)
            {
                requestRule_rule_Schedule = null;
            }
            if (requestRule_rule_Schedule != null)
            {
                request.Rule.Schedule = requestRule_rule_Schedule;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CloudWatch.Model.PutAlarmMuteRuleResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutAlarmMuteRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutAlarmMuteRule");
            try
            {
                return client.PutAlarmMuteRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.DateTime? ExpireDate { get; set; }
            public List<System.String> MuteTargets_AlarmName { get; set; }
            public System.String Name { get; set; }
            public System.String Rule_Schedule_Duration { get; set; }
            public System.String Rule_Schedule_Expression { get; set; }
            public System.String Rule_Schedule_Timezone { get; set; }
            public System.DateTime? StartDate { get; set; }
            public List<Amazon.CloudWatch.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CloudWatch.Model.PutAlarmMuteRuleResponse, WriteCWAlarmMuteRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
