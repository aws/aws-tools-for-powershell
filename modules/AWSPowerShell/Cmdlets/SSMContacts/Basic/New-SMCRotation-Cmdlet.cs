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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Creates a rotation in an on-call schedule.
    /// </summary>
    [Cmdlet("New", "SMCRotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager Contacts CreateRotation API operation.", Operation = new[] {"CreateRotation"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.CreateRotationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SSMContacts.Model.CreateRotationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SSMContacts.Model.CreateRotationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMCRotationCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the contacts to add to the rotation.</para><note><para>Only the <c>PERSONAL</c> contact type is supported. The contact types <c>ESCALATION</c>
        /// and <c>ONCALL_SCHEDULE</c> are not supported for this operation. </para></note><para>The order that you list the contacts in is their shift order in the rotation schedule.
        /// To change the order of the contact's shifts, use the <a>UpdateRotation</a> operation.</para>
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
        [Alias("ContactIds")]
        public System.String[] ContactId { get; set; }
        #endregion
        
        #region Parameter Recurrence_DailySetting
        /// <summary>
        /// <para>
        /// <para>Information about on-call rotations that recur daily.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Recurrence_DailySettings")]
        public Amazon.SSMContacts.Model.HandOffTime[] Recurrence_DailySetting { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures that the operation is called only once with the specified details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Recurrence_MonthlySetting
        /// <summary>
        /// <para>
        /// <para>Information about on-call rotations that recur monthly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Recurrence_MonthlySettings")]
        public Amazon.SSMContacts.Model.MonthlySetting[] Recurrence_MonthlySetting { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the rotation.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Recurrence_NumberOfOnCall
        /// <summary>
        /// <para>
        /// <para>The number of contacts, or shift team members designated to be on call concurrently
        /// during a shift. For example, in an on-call schedule that contains ten contacts, a
        /// value of <c>2</c> designates that two of them are on call at any given time.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Recurrence_NumberOfOnCalls")]
        public System.Int32? Recurrence_NumberOfOnCall { get; set; }
        #endregion
        
        #region Parameter Recurrence_RecurrenceMultiplier
        /// <summary>
        /// <para>
        /// <para>The number of days, weeks, or months a single rotation lasts.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Recurrence_RecurrenceMultiplier { get; set; }
        #endregion
        
        #region Parameter Recurrence_ShiftCoverage
        /// <summary>
        /// <para>
        /// <para>Information about the days of the week that the on-call rotation coverage includes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Recurrence_ShiftCoverages")]
        public System.Collections.Hashtable Recurrence_ShiftCoverage { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time that the rotation goes into effect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata to assign to the rotation. Tags enable you to categorize a resource
        /// in different ways, such as by purpose, owner, or environment. For more information,
        /// see <a href="https://docs.aws.amazon.com/incident-manager/latest/userguide/tagging.html">Tagging
        /// Incident Manager resources</a> in the <i>Incident Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SSMContacts.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TimeZoneId
        /// <summary>
        /// <para>
        /// <para>The time zone to base the rotation’s activity on in Internet Assigned Numbers Authority
        /// (IANA) format. For example: "America/Los_Angeles", "UTC", or "Asia/Seoul". For more
        /// information, see the <a href="https://www.iana.org/time-zones">Time Zone Database</a>
        /// on the IANA website.</para><note><para>Designators for time zones that don’t support Daylight Savings Time rules, such as
        /// Pacific Standard Time (PST), are not supported.</para></note>
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
        public System.String TimeZoneId { get; set; }
        #endregion
        
        #region Parameter Recurrence_WeeklySetting
        /// <summary>
        /// <para>
        /// <para>Information about on-call rotations that recur weekly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Recurrence_WeeklySettings")]
        public Amazon.SSMContacts.Model.WeeklySetting[] Recurrence_WeeklySetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RotationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.CreateRotationResponse).
        /// Specifying the name of a property of type Amazon.SSMContacts.Model.CreateRotationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RotationArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMCRotation (CreateRotation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.CreateRotationResponse, NewSMCRotationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ContactId != null)
            {
                context.ContactId = new List<System.String>(this.ContactId);
            }
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Recurrence_DailySetting != null)
            {
                context.Recurrence_DailySetting = new List<Amazon.SSMContacts.Model.HandOffTime>(this.Recurrence_DailySetting);
            }
            if (this.Recurrence_MonthlySetting != null)
            {
                context.Recurrence_MonthlySetting = new List<Amazon.SSMContacts.Model.MonthlySetting>(this.Recurrence_MonthlySetting);
            }
            context.Recurrence_NumberOfOnCall = this.Recurrence_NumberOfOnCall;
            #if MODULAR
            if (this.Recurrence_NumberOfOnCall == null && ParameterWasBound(nameof(this.Recurrence_NumberOfOnCall)))
            {
                WriteWarning("You are passing $null as a value for parameter Recurrence_NumberOfOnCall which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Recurrence_RecurrenceMultiplier = this.Recurrence_RecurrenceMultiplier;
            #if MODULAR
            if (this.Recurrence_RecurrenceMultiplier == null && ParameterWasBound(nameof(this.Recurrence_RecurrenceMultiplier)))
            {
                WriteWarning("You are passing $null as a value for parameter Recurrence_RecurrenceMultiplier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Recurrence_ShiftCoverage != null)
            {
                context.Recurrence_ShiftCoverage = new Dictionary<System.String, List<Amazon.SSMContacts.Model.CoverageTime>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Recurrence_ShiftCoverage.Keys)
                {
                    object hashValue = this.Recurrence_ShiftCoverage[hashKey];
                    if (hashValue == null)
                    {
                        context.Recurrence_ShiftCoverage.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.SSMContacts.Model.CoverageTime>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.SSMContacts.Model.CoverageTime)s);
                    }
                    context.Recurrence_ShiftCoverage.Add((String)hashKey, valueSet);
                }
            }
            if (this.Recurrence_WeeklySetting != null)
            {
                context.Recurrence_WeeklySetting = new List<Amazon.SSMContacts.Model.WeeklySetting>(this.Recurrence_WeeklySetting);
            }
            context.StartTime = this.StartTime;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SSMContacts.Model.Tag>(this.Tag);
            }
            context.TimeZoneId = this.TimeZoneId;
            #if MODULAR
            if (this.TimeZoneId == null && ParameterWasBound(nameof(this.TimeZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSMContacts.Model.CreateRotationRequest();
            
            if (cmdletContext.ContactId != null)
            {
                request.ContactIds = cmdletContext.ContactId;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Recurrence
            var requestRecurrenceIsNull = true;
            request.Recurrence = new Amazon.SSMContacts.Model.RecurrenceSettings();
            List<Amazon.SSMContacts.Model.HandOffTime> requestRecurrence_recurrence_DailySetting = null;
            if (cmdletContext.Recurrence_DailySetting != null)
            {
                requestRecurrence_recurrence_DailySetting = cmdletContext.Recurrence_DailySetting;
            }
            if (requestRecurrence_recurrence_DailySetting != null)
            {
                request.Recurrence.DailySettings = requestRecurrence_recurrence_DailySetting;
                requestRecurrenceIsNull = false;
            }
            List<Amazon.SSMContacts.Model.MonthlySetting> requestRecurrence_recurrence_MonthlySetting = null;
            if (cmdletContext.Recurrence_MonthlySetting != null)
            {
                requestRecurrence_recurrence_MonthlySetting = cmdletContext.Recurrence_MonthlySetting;
            }
            if (requestRecurrence_recurrence_MonthlySetting != null)
            {
                request.Recurrence.MonthlySettings = requestRecurrence_recurrence_MonthlySetting;
                requestRecurrenceIsNull = false;
            }
            System.Int32? requestRecurrence_recurrence_NumberOfOnCall = null;
            if (cmdletContext.Recurrence_NumberOfOnCall != null)
            {
                requestRecurrence_recurrence_NumberOfOnCall = cmdletContext.Recurrence_NumberOfOnCall.Value;
            }
            if (requestRecurrence_recurrence_NumberOfOnCall != null)
            {
                request.Recurrence.NumberOfOnCalls = requestRecurrence_recurrence_NumberOfOnCall.Value;
                requestRecurrenceIsNull = false;
            }
            System.Int32? requestRecurrence_recurrence_RecurrenceMultiplier = null;
            if (cmdletContext.Recurrence_RecurrenceMultiplier != null)
            {
                requestRecurrence_recurrence_RecurrenceMultiplier = cmdletContext.Recurrence_RecurrenceMultiplier.Value;
            }
            if (requestRecurrence_recurrence_RecurrenceMultiplier != null)
            {
                request.Recurrence.RecurrenceMultiplier = requestRecurrence_recurrence_RecurrenceMultiplier.Value;
                requestRecurrenceIsNull = false;
            }
            Dictionary<System.String, List<Amazon.SSMContacts.Model.CoverageTime>> requestRecurrence_recurrence_ShiftCoverage = null;
            if (cmdletContext.Recurrence_ShiftCoverage != null)
            {
                requestRecurrence_recurrence_ShiftCoverage = cmdletContext.Recurrence_ShiftCoverage;
            }
            if (requestRecurrence_recurrence_ShiftCoverage != null)
            {
                request.Recurrence.ShiftCoverages = requestRecurrence_recurrence_ShiftCoverage;
                requestRecurrenceIsNull = false;
            }
            List<Amazon.SSMContacts.Model.WeeklySetting> requestRecurrence_recurrence_WeeklySetting = null;
            if (cmdletContext.Recurrence_WeeklySetting != null)
            {
                requestRecurrence_recurrence_WeeklySetting = cmdletContext.Recurrence_WeeklySetting;
            }
            if (requestRecurrence_recurrence_WeeklySetting != null)
            {
                request.Recurrence.WeeklySettings = requestRecurrence_recurrence_WeeklySetting;
                requestRecurrenceIsNull = false;
            }
             // determine if request.Recurrence should be set to null
            if (requestRecurrenceIsNull)
            {
                request.Recurrence = null;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TimeZoneId != null)
            {
                request.TimeZoneId = cmdletContext.TimeZoneId;
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
        
        private Amazon.SSMContacts.Model.CreateRotationResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.CreateRotationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager Contacts", "CreateRotation");
            try
            {
                #if DESKTOP
                return client.CreateRotation(request);
                #elif CORECLR
                return client.CreateRotationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ContactId { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.SSMContacts.Model.HandOffTime> Recurrence_DailySetting { get; set; }
            public List<Amazon.SSMContacts.Model.MonthlySetting> Recurrence_MonthlySetting { get; set; }
            public System.Int32? Recurrence_NumberOfOnCall { get; set; }
            public System.Int32? Recurrence_RecurrenceMultiplier { get; set; }
            public Dictionary<System.String, List<Amazon.SSMContacts.Model.CoverageTime>> Recurrence_ShiftCoverage { get; set; }
            public List<Amazon.SSMContacts.Model.WeeklySetting> Recurrence_WeeklySetting { get; set; }
            public System.DateTime? StartTime { get; set; }
            public List<Amazon.SSMContacts.Model.Tag> Tag { get; set; }
            public System.String TimeZoneId { get; set; }
            public System.Func<Amazon.SSMContacts.Model.CreateRotationResponse, NewSMCRotationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RotationArn;
        }
        
    }
}
