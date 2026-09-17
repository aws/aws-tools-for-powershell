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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// Updates the calling settings for a linked WhatsApp business phone number, such as
    /// whether calling is enabled and the hours during which the business accepts calls.
    /// </summary>
    [Cmdlet("Update", "SOCIALLinkedWhatsAppBusinessAccountPhoneNumber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS End User Messaging Social UpdateLinkedWhatsAppBusinessAccountPhoneNumber API operation.", Operation = new[] {"UpdateLinkedWhatsAppBusinessAccountPhoneNumber"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberResponse))]
    [AWSCmdletOutput("System.String or Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSOCIALLinkedWhatsAppBusinessAccountPhoneNumberCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CallSettings_CallbackPermissionStatus
        /// <summary>
        /// <para>
        /// <para>The callback permission status for the phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CallSettings_CallbackPermissionStatus { get; set; }
        #endregion
        
        #region Parameter CallSettings_CallEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether calling is enabled for the phone number.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? CallSettings_CallEnabled { get; set; }
        #endregion
        
        #region Parameter CallSettings_CallIconVisibility
        /// <summary>
        /// <para>
        /// <para>The visibility setting for the call icon shown to end users in WhatsApp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CallSettings_CallIconVisibility { get; set; }
        #endregion
        
        #region Parameter CallSettings_CallHours_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether call hours are enforced. When disabled, the business accepts calls
        /// at any time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CallSettings_CallHours_Enabled { get; set; }
        #endregion
        
        #region Parameter CallSettings_CallHours_HolidaySchedule
        /// <summary>
        /// <para>
        /// <para>Date-specific overrides to the weekly operating hours, such as holidays.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SocialMessaging.Model.WhatsAppHolidayScheduleEntry[] CallSettings_CallHours_HolidaySchedule { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the phone number to update. The phone number identifiers
        /// are formatted as <c>phone-number-id-01234567890123456789012345678901</c>.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter CallSettings_CallHours_Timezone
        /// <summary>
        /// <para>
        /// <para>The IANA time zone in which the operating hours are interpreted, such as <c>America/New_York</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CallSettings_CallHours_Timezone { get; set; }
        #endregion
        
        #region Parameter CallSettings_CallHours_WeeklyOperatingHour
        /// <summary>
        /// <para>
        /// <para>The weekly schedule of hours during which the business accepts calls.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CallSettings_CallHours_WeeklyOperatingHours")]
        public Amazon.SocialMessaging.Model.WhatsAppWeeklyOperatingHoursEntry[] CallSettings_CallHours_WeeklyOperatingHour { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PhoneNumberId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberResponse).
        /// Specifying the name of a property of type Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PhoneNumberId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SOCIALLinkedWhatsAppBusinessAccountPhoneNumber (UpdateLinkedWhatsAppBusinessAccountPhoneNumber)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberResponse, UpdateSOCIALLinkedWhatsAppBusinessAccountPhoneNumberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CallSettings_CallbackPermissionStatus = this.CallSettings_CallbackPermissionStatus;
            context.CallSettings_CallEnabled = this.CallSettings_CallEnabled;
            #if MODULAR
            if (this.CallSettings_CallEnabled == null && ParameterWasBound(nameof(this.CallSettings_CallEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter CallSettings_CallEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CallSettings_CallHours_Enabled = this.CallSettings_CallHours_Enabled;
            if (this.CallSettings_CallHours_HolidaySchedule != null)
            {
                context.CallSettings_CallHours_HolidaySchedule = new List<Amazon.SocialMessaging.Model.WhatsAppHolidayScheduleEntry>(this.CallSettings_CallHours_HolidaySchedule);
            }
            context.CallSettings_CallHours_Timezone = this.CallSettings_CallHours_Timezone;
            if (this.CallSettings_CallHours_WeeklyOperatingHour != null)
            {
                context.CallSettings_CallHours_WeeklyOperatingHour = new List<Amazon.SocialMessaging.Model.WhatsAppWeeklyOperatingHoursEntry>(this.CallSettings_CallHours_WeeklyOperatingHour);
            }
            context.CallSettings_CallIconVisibility = this.CallSettings_CallIconVisibility;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberRequest();
            
            
             // populate CallSettings
            var requestCallSettingsIsNull = true;
            request.CallSettings = new Amazon.SocialMessaging.Model.WhatsAppCallSettings();
            System.String requestCallSettings_callSettings_CallbackPermissionStatus = null;
            if (cmdletContext.CallSettings_CallbackPermissionStatus != null)
            {
                requestCallSettings_callSettings_CallbackPermissionStatus = cmdletContext.CallSettings_CallbackPermissionStatus;
            }
            if (requestCallSettings_callSettings_CallbackPermissionStatus != null)
            {
                request.CallSettings.CallbackPermissionStatus = requestCallSettings_callSettings_CallbackPermissionStatus;
                requestCallSettingsIsNull = false;
            }
            System.Boolean? requestCallSettings_callSettings_CallEnabled = null;
            if (cmdletContext.CallSettings_CallEnabled != null)
            {
                requestCallSettings_callSettings_CallEnabled = cmdletContext.CallSettings_CallEnabled.Value;
            }
            if (requestCallSettings_callSettings_CallEnabled != null)
            {
                request.CallSettings.CallEnabled = requestCallSettings_callSettings_CallEnabled.Value;
                requestCallSettingsIsNull = false;
            }
            System.String requestCallSettings_callSettings_CallIconVisibility = null;
            if (cmdletContext.CallSettings_CallIconVisibility != null)
            {
                requestCallSettings_callSettings_CallIconVisibility = cmdletContext.CallSettings_CallIconVisibility;
            }
            if (requestCallSettings_callSettings_CallIconVisibility != null)
            {
                request.CallSettings.CallIconVisibility = requestCallSettings_callSettings_CallIconVisibility;
                requestCallSettingsIsNull = false;
            }
            Amazon.SocialMessaging.Model.WhatsAppCallHours requestCallSettings_callSettings_CallHours = null;
            
             // populate CallHours
            var requestCallSettings_callSettings_CallHoursIsNull = true;
            requestCallSettings_callSettings_CallHours = new Amazon.SocialMessaging.Model.WhatsAppCallHours();
            System.Boolean? requestCallSettings_callSettings_CallHours_callSettings_CallHours_Enabled = null;
            if (cmdletContext.CallSettings_CallHours_Enabled != null)
            {
                requestCallSettings_callSettings_CallHours_callSettings_CallHours_Enabled = cmdletContext.CallSettings_CallHours_Enabled.Value;
            }
            if (requestCallSettings_callSettings_CallHours_callSettings_CallHours_Enabled != null)
            {
                requestCallSettings_callSettings_CallHours.Enabled = requestCallSettings_callSettings_CallHours_callSettings_CallHours_Enabled.Value;
                requestCallSettings_callSettings_CallHoursIsNull = false;
            }
            List<Amazon.SocialMessaging.Model.WhatsAppHolidayScheduleEntry> requestCallSettings_callSettings_CallHours_callSettings_CallHours_HolidaySchedule = null;
            if (cmdletContext.CallSettings_CallHours_HolidaySchedule != null)
            {
                requestCallSettings_callSettings_CallHours_callSettings_CallHours_HolidaySchedule = cmdletContext.CallSettings_CallHours_HolidaySchedule;
            }
            if (requestCallSettings_callSettings_CallHours_callSettings_CallHours_HolidaySchedule != null)
            {
                requestCallSettings_callSettings_CallHours.HolidaySchedule = requestCallSettings_callSettings_CallHours_callSettings_CallHours_HolidaySchedule;
                requestCallSettings_callSettings_CallHoursIsNull = false;
            }
            System.String requestCallSettings_callSettings_CallHours_callSettings_CallHours_Timezone = null;
            if (cmdletContext.CallSettings_CallHours_Timezone != null)
            {
                requestCallSettings_callSettings_CallHours_callSettings_CallHours_Timezone = cmdletContext.CallSettings_CallHours_Timezone;
            }
            if (requestCallSettings_callSettings_CallHours_callSettings_CallHours_Timezone != null)
            {
                requestCallSettings_callSettings_CallHours.Timezone = requestCallSettings_callSettings_CallHours_callSettings_CallHours_Timezone;
                requestCallSettings_callSettings_CallHoursIsNull = false;
            }
            List<Amazon.SocialMessaging.Model.WhatsAppWeeklyOperatingHoursEntry> requestCallSettings_callSettings_CallHours_callSettings_CallHours_WeeklyOperatingHour = null;
            if (cmdletContext.CallSettings_CallHours_WeeklyOperatingHour != null)
            {
                requestCallSettings_callSettings_CallHours_callSettings_CallHours_WeeklyOperatingHour = cmdletContext.CallSettings_CallHours_WeeklyOperatingHour;
            }
            if (requestCallSettings_callSettings_CallHours_callSettings_CallHours_WeeklyOperatingHour != null)
            {
                requestCallSettings_callSettings_CallHours.WeeklyOperatingHours = requestCallSettings_callSettings_CallHours_callSettings_CallHours_WeeklyOperatingHour;
                requestCallSettings_callSettings_CallHoursIsNull = false;
            }
             // determine if requestCallSettings_callSettings_CallHours should be set to null
            if (requestCallSettings_callSettings_CallHoursIsNull)
            {
                requestCallSettings_callSettings_CallHours = null;
            }
            if (requestCallSettings_callSettings_CallHours != null)
            {
                request.CallSettings.CallHours = requestCallSettings_callSettings_CallHours;
                requestCallSettingsIsNull = false;
            }
             // determine if request.CallSettings should be set to null
            if (requestCallSettingsIsNull)
            {
                request.CallSettings = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "UpdateLinkedWhatsAppBusinessAccountPhoneNumber");
            try
            {
                return client.UpdateLinkedWhatsAppBusinessAccountPhoneNumberAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CallSettings_CallbackPermissionStatus { get; set; }
            public System.Boolean? CallSettings_CallEnabled { get; set; }
            public System.Boolean? CallSettings_CallHours_Enabled { get; set; }
            public List<Amazon.SocialMessaging.Model.WhatsAppHolidayScheduleEntry> CallSettings_CallHours_HolidaySchedule { get; set; }
            public System.String CallSettings_CallHours_Timezone { get; set; }
            public List<Amazon.SocialMessaging.Model.WhatsAppWeeklyOperatingHoursEntry> CallSettings_CallHours_WeeklyOperatingHour { get; set; }
            public System.String CallSettings_CallIconVisibility { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.UpdateLinkedWhatsAppBusinessAccountPhoneNumberResponse, UpdateSOCIALLinkedWhatsAppBusinessAccountPhoneNumberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PhoneNumberId;
        }
        
    }
}
