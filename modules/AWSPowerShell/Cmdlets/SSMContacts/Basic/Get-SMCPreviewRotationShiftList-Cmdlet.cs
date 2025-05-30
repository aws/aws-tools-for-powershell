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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Returns a list of shifts based on rotation configuration parameters.
    /// 
    ///  <note><para>
    /// The Incident Manager primarily uses this operation to populate the <b>Preview</b>
    /// calendar. It is not typically run by end users.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "SMCPreviewRotationShiftList")]
    [OutputType("Amazon.SSMContacts.Model.RotationShift")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager Contacts ListPreviewRotationShifts API operation.", Operation = new[] {"ListPreviewRotationShifts"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.ListPreviewRotationShiftsResponse))]
    [AWSCmdletOutput("Amazon.SSMContacts.Model.RotationShift or Amazon.SSMContacts.Model.ListPreviewRotationShiftsResponse",
        "This cmdlet returns a collection of Amazon.SSMContacts.Model.RotationShift objects.",
        "The service call response (type Amazon.SSMContacts.Model.ListPreviewRotationShiftsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMCPreviewRotationShiftListCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The date and time a rotation shift would end.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter Member
        /// <summary>
        /// <para>
        /// <para>The contacts that would be assigned to a rotation.</para>
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
        [Alias("Members")]
        public System.String[] Member { get; set; }
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
        
        #region Parameter Recurrence_NumberOfOnCall
        /// <summary>
        /// <para>
        /// <para>The number of contacts, or shift team members designated to be on call concurrently
        /// during a shift. For example, in an on-call schedule containing ten contacts, a value
        /// of <c>2</c> designates that two of them are on call at any given time.</para>
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
        
        #region Parameter Override
        /// <summary>
        /// <para>
        /// <para>Information about changes that would be made in a rotation override.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Overrides")]
        public Amazon.SSMContacts.Model.PreviewOverride[] Override { get; set; }
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
        
        #region Parameter RotationStartTime
        /// <summary>
        /// <para>
        /// <para>The date and time a rotation would begin. The first shift is calculated from this
        /// date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RotationStartTime { get; set; }
        #endregion
        
        #region Parameter Recurrence_ShiftCoverage
        /// <summary>
        /// <para>
        /// <para>Information about the days of the week included in on-call rotation coverage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Recurrence_ShiftCoverages")]
        public System.Collections.Hashtable Recurrence_ShiftCoverage { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>Used to filter the range of calculated shifts before sending the response back to
        /// the user. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter TimeZoneId
        /// <summary>
        /// <para>
        /// <para>The time zone the rotation’s activity would be based on, in Internet Assigned Numbers
        /// Authority (IANA) format. For example: "America/Los_Angeles", "UTC", or "Asia/Seoul".
        /// </para>
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this call. The call also returns a token
        /// that can be specified in a subsequent call to get the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to start the list. This token is used to get the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RotationShifts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.ListPreviewRotationShiftsResponse).
        /// Specifying the name of a property of type Amazon.SSMContacts.Model.ListPreviewRotationShiftsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RotationShifts";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.ListPreviewRotationShiftsResponse, GetSMCPreviewRotationShiftListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            if (this.Member != null)
            {
                context.Member = new List<System.String>(this.Member);
            }
            #if MODULAR
            if (this.Member == null && ParameterWasBound(nameof(this.Member)))
            {
                WriteWarning("You are passing $null as a value for parameter Member which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            if (this.Override != null)
            {
                context.Override = new List<Amazon.SSMContacts.Model.PreviewOverride>(this.Override);
            }
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
            context.RotationStartTime = this.RotationStartTime;
            context.StartTime = this.StartTime;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SSMContacts.Model.ListPreviewRotationShiftsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Member != null)
            {
                request.Members = cmdletContext.Member;
            }
            if (cmdletContext.Override != null)
            {
                request.Overrides = cmdletContext.Override;
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
            if (cmdletContext.RotationStartTime != null)
            {
                request.RotationStartTime = cmdletContext.RotationStartTime.Value;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.TimeZoneId != null)
            {
                request.TimeZoneId = cmdletContext.TimeZoneId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SSMContacts.Model.ListPreviewRotationShiftsResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.ListPreviewRotationShiftsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager Contacts", "ListPreviewRotationShifts");
            try
            {
                return client.ListPreviewRotationShiftsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public int? MaxResult { get; set; }
            public List<System.String> Member { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.SSMContacts.Model.PreviewOverride> Override { get; set; }
            public List<Amazon.SSMContacts.Model.HandOffTime> Recurrence_DailySetting { get; set; }
            public List<Amazon.SSMContacts.Model.MonthlySetting> Recurrence_MonthlySetting { get; set; }
            public System.Int32? Recurrence_NumberOfOnCall { get; set; }
            public System.Int32? Recurrence_RecurrenceMultiplier { get; set; }
            public Dictionary<System.String, List<Amazon.SSMContacts.Model.CoverageTime>> Recurrence_ShiftCoverage { get; set; }
            public List<Amazon.SSMContacts.Model.WeeklySetting> Recurrence_WeeklySetting { get; set; }
            public System.DateTime? RotationStartTime { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.String TimeZoneId { get; set; }
            public System.Func<Amazon.SSMContacts.Model.ListPreviewRotationShiftsResponse, GetSMCPreviewRotationShiftListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RotationShifts;
        }
        
    }
}
