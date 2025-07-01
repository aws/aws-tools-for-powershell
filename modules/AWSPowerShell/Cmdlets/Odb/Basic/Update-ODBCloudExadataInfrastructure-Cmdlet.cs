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
using Amazon.Odb;
using Amazon.Odb.Model;

namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Updates the properties of an Exadata infrastructure resource.
    /// </summary>
    [Cmdlet("Update", "ODBCloudExadataInfrastructure", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.UpdateCloudExadataInfrastructureResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services UpdateCloudExadataInfrastructure API operation.", Operation = new[] {"UpdateCloudExadataInfrastructure"}, SelectReturnType = typeof(Amazon.Odb.Model.UpdateCloudExadataInfrastructureResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.UpdateCloudExadataInfrastructureResponse",
        "This cmdlet returns an Amazon.Odb.Model.UpdateCloudExadataInfrastructureResponse object containing multiple properties."
    )]
    public partial class UpdateODBCloudExadataInfrastructureCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudExadataInfrastructureId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Exadata infrastructure to update.</para>
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
        public System.String CloudExadataInfrastructureId { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_CustomActionTimeoutInMin
        /// <summary>
        /// <para>
        /// <para>The custom action timeout in minutes for the maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaintenanceWindow_CustomActionTimeoutInMins")]
        public System.Int32? MaintenanceWindow_CustomActionTimeoutInMin { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_DaysOfWeek
        /// <summary>
        /// <para>
        /// <para>The days of the week when maintenance can be performed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Odb.Model.DayOfWeek[] MaintenanceWindow_DaysOfWeek { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_HoursOfDay
        /// <summary>
        /// <para>
        /// <para>The hours of the day when maintenance can be performed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] MaintenanceWindow_HoursOfDay { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_IsCustomActionTimeoutEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether custom action timeout is enabled for the maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MaintenanceWindow_IsCustomActionTimeoutEnabled { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_LeadTimeInWeek
        /// <summary>
        /// <para>
        /// <para>The lead time in weeks before the maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaintenanceWindow_LeadTimeInWeeks")]
        public System.Int32? MaintenanceWindow_LeadTimeInWeek { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_Month
        /// <summary>
        /// <para>
        /// <para>The months when maintenance can be performed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaintenanceWindow_Months")]
        public Amazon.Odb.Model.Month[] MaintenanceWindow_Month { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_PatchingMode
        /// <summary>
        /// <para>
        /// <para>The patching mode for the maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.PatchingModeType")]
        public Amazon.Odb.PatchingModeType MaintenanceWindow_PatchingMode { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_Preference
        /// <summary>
        /// <para>
        /// <para>The preference for the maintenance window scheduling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.PreferenceType")]
        public Amazon.Odb.PreferenceType MaintenanceWindow_Preference { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_SkipRu
        /// <summary>
        /// <para>
        /// <para>Indicates whether to skip release updates during maintenance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MaintenanceWindow_SkipRu { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_WeeksOfMonth
        /// <summary>
        /// <para>
        /// <para>The weeks of the month when maintenance can be performed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] MaintenanceWindow_WeeksOfMonth { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.UpdateCloudExadataInfrastructureResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.UpdateCloudExadataInfrastructureResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CloudExadataInfrastructureId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CloudExadataInfrastructureId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CloudExadataInfrastructureId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CloudExadataInfrastructureId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ODBCloudExadataInfrastructure (UpdateCloudExadataInfrastructure)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.UpdateCloudExadataInfrastructureResponse, UpdateODBCloudExadataInfrastructureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CloudExadataInfrastructureId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudExadataInfrastructureId = this.CloudExadataInfrastructureId;
            #if MODULAR
            if (this.CloudExadataInfrastructureId == null && ParameterWasBound(nameof(this.CloudExadataInfrastructureId)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudExadataInfrastructureId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaintenanceWindow_CustomActionTimeoutInMin = this.MaintenanceWindow_CustomActionTimeoutInMin;
            if (this.MaintenanceWindow_DaysOfWeek != null)
            {
                context.MaintenanceWindow_DaysOfWeek = new List<Amazon.Odb.Model.DayOfWeek>(this.MaintenanceWindow_DaysOfWeek);
            }
            if (this.MaintenanceWindow_HoursOfDay != null)
            {
                context.MaintenanceWindow_HoursOfDay = new List<System.Int32>(this.MaintenanceWindow_HoursOfDay);
            }
            context.MaintenanceWindow_IsCustomActionTimeoutEnabled = this.MaintenanceWindow_IsCustomActionTimeoutEnabled;
            context.MaintenanceWindow_LeadTimeInWeek = this.MaintenanceWindow_LeadTimeInWeek;
            if (this.MaintenanceWindow_Month != null)
            {
                context.MaintenanceWindow_Month = new List<Amazon.Odb.Model.Month>(this.MaintenanceWindow_Month);
            }
            context.MaintenanceWindow_PatchingMode = this.MaintenanceWindow_PatchingMode;
            context.MaintenanceWindow_Preference = this.MaintenanceWindow_Preference;
            context.MaintenanceWindow_SkipRu = this.MaintenanceWindow_SkipRu;
            if (this.MaintenanceWindow_WeeksOfMonth != null)
            {
                context.MaintenanceWindow_WeeksOfMonth = new List<System.Int32>(this.MaintenanceWindow_WeeksOfMonth);
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
            var request = new Amazon.Odb.Model.UpdateCloudExadataInfrastructureRequest();
            
            if (cmdletContext.CloudExadataInfrastructureId != null)
            {
                request.CloudExadataInfrastructureId = cmdletContext.CloudExadataInfrastructureId;
            }
            
             // populate MaintenanceWindow
            var requestMaintenanceWindowIsNull = true;
            request.MaintenanceWindow = new Amazon.Odb.Model.MaintenanceWindow();
            System.Int32? requestMaintenanceWindow_maintenanceWindow_CustomActionTimeoutInMin = null;
            if (cmdletContext.MaintenanceWindow_CustomActionTimeoutInMin != null)
            {
                requestMaintenanceWindow_maintenanceWindow_CustomActionTimeoutInMin = cmdletContext.MaintenanceWindow_CustomActionTimeoutInMin.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_CustomActionTimeoutInMin != null)
            {
                request.MaintenanceWindow.CustomActionTimeoutInMins = requestMaintenanceWindow_maintenanceWindow_CustomActionTimeoutInMin.Value;
                requestMaintenanceWindowIsNull = false;
            }
            List<Amazon.Odb.Model.DayOfWeek> requestMaintenanceWindow_maintenanceWindow_DaysOfWeek = null;
            if (cmdletContext.MaintenanceWindow_DaysOfWeek != null)
            {
                requestMaintenanceWindow_maintenanceWindow_DaysOfWeek = cmdletContext.MaintenanceWindow_DaysOfWeek;
            }
            if (requestMaintenanceWindow_maintenanceWindow_DaysOfWeek != null)
            {
                request.MaintenanceWindow.DaysOfWeek = requestMaintenanceWindow_maintenanceWindow_DaysOfWeek;
                requestMaintenanceWindowIsNull = false;
            }
            List<System.Int32> requestMaintenanceWindow_maintenanceWindow_HoursOfDay = null;
            if (cmdletContext.MaintenanceWindow_HoursOfDay != null)
            {
                requestMaintenanceWindow_maintenanceWindow_HoursOfDay = cmdletContext.MaintenanceWindow_HoursOfDay;
            }
            if (requestMaintenanceWindow_maintenanceWindow_HoursOfDay != null)
            {
                request.MaintenanceWindow.HoursOfDay = requestMaintenanceWindow_maintenanceWindow_HoursOfDay;
                requestMaintenanceWindowIsNull = false;
            }
            System.Boolean? requestMaintenanceWindow_maintenanceWindow_IsCustomActionTimeoutEnabled = null;
            if (cmdletContext.MaintenanceWindow_IsCustomActionTimeoutEnabled != null)
            {
                requestMaintenanceWindow_maintenanceWindow_IsCustomActionTimeoutEnabled = cmdletContext.MaintenanceWindow_IsCustomActionTimeoutEnabled.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_IsCustomActionTimeoutEnabled != null)
            {
                request.MaintenanceWindow.IsCustomActionTimeoutEnabled = requestMaintenanceWindow_maintenanceWindow_IsCustomActionTimeoutEnabled.Value;
                requestMaintenanceWindowIsNull = false;
            }
            System.Int32? requestMaintenanceWindow_maintenanceWindow_LeadTimeInWeek = null;
            if (cmdletContext.MaintenanceWindow_LeadTimeInWeek != null)
            {
                requestMaintenanceWindow_maintenanceWindow_LeadTimeInWeek = cmdletContext.MaintenanceWindow_LeadTimeInWeek.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_LeadTimeInWeek != null)
            {
                request.MaintenanceWindow.LeadTimeInWeeks = requestMaintenanceWindow_maintenanceWindow_LeadTimeInWeek.Value;
                requestMaintenanceWindowIsNull = false;
            }
            List<Amazon.Odb.Model.Month> requestMaintenanceWindow_maintenanceWindow_Month = null;
            if (cmdletContext.MaintenanceWindow_Month != null)
            {
                requestMaintenanceWindow_maintenanceWindow_Month = cmdletContext.MaintenanceWindow_Month;
            }
            if (requestMaintenanceWindow_maintenanceWindow_Month != null)
            {
                request.MaintenanceWindow.Months = requestMaintenanceWindow_maintenanceWindow_Month;
                requestMaintenanceWindowIsNull = false;
            }
            Amazon.Odb.PatchingModeType requestMaintenanceWindow_maintenanceWindow_PatchingMode = null;
            if (cmdletContext.MaintenanceWindow_PatchingMode != null)
            {
                requestMaintenanceWindow_maintenanceWindow_PatchingMode = cmdletContext.MaintenanceWindow_PatchingMode;
            }
            if (requestMaintenanceWindow_maintenanceWindow_PatchingMode != null)
            {
                request.MaintenanceWindow.PatchingMode = requestMaintenanceWindow_maintenanceWindow_PatchingMode;
                requestMaintenanceWindowIsNull = false;
            }
            Amazon.Odb.PreferenceType requestMaintenanceWindow_maintenanceWindow_Preference = null;
            if (cmdletContext.MaintenanceWindow_Preference != null)
            {
                requestMaintenanceWindow_maintenanceWindow_Preference = cmdletContext.MaintenanceWindow_Preference;
            }
            if (requestMaintenanceWindow_maintenanceWindow_Preference != null)
            {
                request.MaintenanceWindow.Preference = requestMaintenanceWindow_maintenanceWindow_Preference;
                requestMaintenanceWindowIsNull = false;
            }
            System.Boolean? requestMaintenanceWindow_maintenanceWindow_SkipRu = null;
            if (cmdletContext.MaintenanceWindow_SkipRu != null)
            {
                requestMaintenanceWindow_maintenanceWindow_SkipRu = cmdletContext.MaintenanceWindow_SkipRu.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_SkipRu != null)
            {
                request.MaintenanceWindow.SkipRu = requestMaintenanceWindow_maintenanceWindow_SkipRu.Value;
                requestMaintenanceWindowIsNull = false;
            }
            List<System.Int32> requestMaintenanceWindow_maintenanceWindow_WeeksOfMonth = null;
            if (cmdletContext.MaintenanceWindow_WeeksOfMonth != null)
            {
                requestMaintenanceWindow_maintenanceWindow_WeeksOfMonth = cmdletContext.MaintenanceWindow_WeeksOfMonth;
            }
            if (requestMaintenanceWindow_maintenanceWindow_WeeksOfMonth != null)
            {
                request.MaintenanceWindow.WeeksOfMonth = requestMaintenanceWindow_maintenanceWindow_WeeksOfMonth;
                requestMaintenanceWindowIsNull = false;
            }
             // determine if request.MaintenanceWindow should be set to null
            if (requestMaintenanceWindowIsNull)
            {
                request.MaintenanceWindow = null;
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
        
        private Amazon.Odb.Model.UpdateCloudExadataInfrastructureResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.UpdateCloudExadataInfrastructureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "UpdateCloudExadataInfrastructure");
            try
            {
                #if DESKTOP
                return client.UpdateCloudExadataInfrastructure(request);
                #elif CORECLR
                return client.UpdateCloudExadataInfrastructureAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudExadataInfrastructureId { get; set; }
            public System.Int32? MaintenanceWindow_CustomActionTimeoutInMin { get; set; }
            public List<Amazon.Odb.Model.DayOfWeek> MaintenanceWindow_DaysOfWeek { get; set; }
            public List<System.Int32> MaintenanceWindow_HoursOfDay { get; set; }
            public System.Boolean? MaintenanceWindow_IsCustomActionTimeoutEnabled { get; set; }
            public System.Int32? MaintenanceWindow_LeadTimeInWeek { get; set; }
            public List<Amazon.Odb.Model.Month> MaintenanceWindow_Month { get; set; }
            public Amazon.Odb.PatchingModeType MaintenanceWindow_PatchingMode { get; set; }
            public Amazon.Odb.PreferenceType MaintenanceWindow_Preference { get; set; }
            public System.Boolean? MaintenanceWindow_SkipRu { get; set; }
            public List<System.Int32> MaintenanceWindow_WeeksOfMonth { get; set; }
            public System.Func<Amazon.Odb.Model.UpdateCloudExadataInfrastructureResponse, UpdateODBCloudExadataInfrastructureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
