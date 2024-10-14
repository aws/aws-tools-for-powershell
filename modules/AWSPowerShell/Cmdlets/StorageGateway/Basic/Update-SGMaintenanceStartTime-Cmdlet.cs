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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Updates a gateway's maintenance window schedule, with settings for monthly or weekly
    /// cadence, specific day and time to begin maintenance, and which types of updates to
    /// apply. Time configuration uses the gateway's time zone. You can pass values for a
    /// complete maintenance schedule, or update policy, or both. Previous values will persist
    /// for whichever setting you choose not to modify. If an incomplete or invalid maintenance
    /// schedule is passed, the entire request will be rejected with an error and no changes
    /// will occur.
    /// 
    ///  
    /// <para>
    /// A complete maintenance schedule must include values for <i>both</i><c>MinuteOfHour</c>
    /// and <c>HourOfDay</c>, and <i>either</i><c>DayOfMonth</c><i>or</i><c>DayOfWeek</c>.
    /// </para><note><para>
    /// We recommend keeping maintenance updates turned on, except in specific use cases where
    /// the brief disruptions caused by updating the gateway could critically impact your
    /// deployment.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SGMaintenanceStartTime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway UpdateMaintenanceStartTime API operation.", Operation = new[] {"UpdateMaintenanceStartTime"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSGMaintenanceStartTimeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SoftwareUpdatePreferences_AutomaticUpdatePolicy
        /// <summary>
        /// <para>
        /// <para>Indicates the automatic update policy for a gateway.</para><para><c>ALL_VERSIONS</c> - Enables regular gateway maintenance updates.</para><para><c>EMERGENCY_VERSIONS_ONLY</c> - Disables regular gateway maintenance updates. The
        /// gateway will still receive emergency version updates on rare occasions if necessary
        /// to remedy highly critical security or durability issues. You will be notified before
        /// an emergency version update is applied. These updates are applied during your gateway's
        /// scheduled maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StorageGateway.AutomaticUpdatePolicy")]
        public Amazon.StorageGateway.AutomaticUpdatePolicy SoftwareUpdatePreferences_AutomaticUpdatePolicy { get; set; }
        #endregion
        
        #region Parameter DayOfMonth
        /// <summary>
        /// <para>
        /// <para>The day of the month component of the maintenance start time represented as an ordinal
        /// number from 1 to 28, where 1 represents the first day of the month. It is not possible
        /// to set the maintenance schedule to start on days 29 through 31.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DayOfMonth { get; set; }
        #endregion
        
        #region Parameter DayOfWeek
        /// <summary>
        /// <para>
        /// <para>The day of the week component of the maintenance start time week represented as an
        /// ordinal number from 0 to 6, where 0 represents Sunday and 6 represents Saturday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.Int32? DayOfWeek { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter HourOfDay
        /// <summary>
        /// <para>
        /// <para>The hour component of the maintenance start time represented as <i>hh</i>, where <i>hh</i>
        /// is the hour (00 to 23). The hour of the day is in the time zone of the gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Int32? HourOfDay { get; set; }
        #endregion
        
        #region Parameter MinuteOfHour
        /// <summary>
        /// <para>
        /// <para>The minute component of the maintenance start time represented as <i>mm</i>, where
        /// <i>mm</i> is the minute (00 to 59). The minute of the hour is in the time zone of
        /// the gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinuteOfHour { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayARN";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GatewayARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGMaintenanceStartTime (UpdateMaintenanceStartTime)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse, UpdateSGMaintenanceStartTimeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GatewayARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DayOfMonth = this.DayOfMonth;
            context.DayOfWeek = this.DayOfWeek;
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HourOfDay = this.HourOfDay;
            context.MinuteOfHour = this.MinuteOfHour;
            context.SoftwareUpdatePreferences_AutomaticUpdatePolicy = this.SoftwareUpdatePreferences_AutomaticUpdatePolicy;
            
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
            var request = new Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeRequest();
            
            if (cmdletContext.DayOfMonth != null)
            {
                request.DayOfMonth = cmdletContext.DayOfMonth.Value;
            }
            if (cmdletContext.DayOfWeek != null)
            {
                request.DayOfWeek = cmdletContext.DayOfWeek.Value;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.HourOfDay != null)
            {
                request.HourOfDay = cmdletContext.HourOfDay.Value;
            }
            if (cmdletContext.MinuteOfHour != null)
            {
                request.MinuteOfHour = cmdletContext.MinuteOfHour.Value;
            }
            
             // populate SoftwareUpdatePreferences
            var requestSoftwareUpdatePreferencesIsNull = true;
            request.SoftwareUpdatePreferences = new Amazon.StorageGateway.Model.SoftwareUpdatePreferences();
            Amazon.StorageGateway.AutomaticUpdatePolicy requestSoftwareUpdatePreferences_softwareUpdatePreferences_AutomaticUpdatePolicy = null;
            if (cmdletContext.SoftwareUpdatePreferences_AutomaticUpdatePolicy != null)
            {
                requestSoftwareUpdatePreferences_softwareUpdatePreferences_AutomaticUpdatePolicy = cmdletContext.SoftwareUpdatePreferences_AutomaticUpdatePolicy;
            }
            if (requestSoftwareUpdatePreferences_softwareUpdatePreferences_AutomaticUpdatePolicy != null)
            {
                request.SoftwareUpdatePreferences.AutomaticUpdatePolicy = requestSoftwareUpdatePreferences_softwareUpdatePreferences_AutomaticUpdatePolicy;
                requestSoftwareUpdatePreferencesIsNull = false;
            }
             // determine if request.SoftwareUpdatePreferences should be set to null
            if (requestSoftwareUpdatePreferencesIsNull)
            {
                request.SoftwareUpdatePreferences = null;
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
        
        private Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateMaintenanceStartTime");
            try
            {
                #if DESKTOP
                return client.UpdateMaintenanceStartTime(request);
                #elif CORECLR
                return client.UpdateMaintenanceStartTimeAsync(request).GetAwaiter().GetResult();
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
            public System.String GatewayARN { get; set; }
            public System.Int32? HourOfDay { get; set; }
            public System.Int32? MinuteOfHour { get; set; }
            public Amazon.StorageGateway.AutomaticUpdatePolicy SoftwareUpdatePreferences_AutomaticUpdatePolicy { get; set; }
            public System.Func<Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse, UpdateSGMaintenanceStartTimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayARN;
        }
        
    }
}
