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
using Amazon.WorkSpacesThinClient;
using Amazon.WorkSpacesThinClient.Model;

namespace Amazon.PowerShell.Cmdlets.WSTC
{
    /// <summary>
    /// Updates an environment.
    /// </summary>
    [Cmdlet("Update", "WSTCEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpacesThinClient.Model.EnvironmentSummary")]
    [AWSCmdlet("Calls the Amazon WorkSpaces Thin Client UpdateEnvironment API operation.", Operation = new[] {"UpdateEnvironment"}, SelectReturnType = typeof(Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.WorkSpacesThinClient.Model.EnvironmentSummary or Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentResponse",
        "This cmdlet returns an Amazon.WorkSpacesThinClient.Model.EnvironmentSummary object.",
        "The service call response (type Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWSTCEnvironmentCmdlet : AmazonWorkSpacesThinClientClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaintenanceWindow_ApplyTimeOf
        /// <summary>
        /// <para>
        /// <para>The option to set the maintenance window during the device local time or Universal
        /// Coordinated Time (UTC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesThinClient.ApplyTimeOf")]
        public Amazon.WorkSpacesThinClient.ApplyTimeOf MaintenanceWindow_ApplyTimeOf { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_DaysOfTheWeek
        /// <summary>
        /// <para>
        /// <para>The days of the week during which the maintenance window is open.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] MaintenanceWindow_DaysOfTheWeek { get; set; }
        #endregion
        
        #region Parameter DesiredSoftwareSetId
        /// <summary>
        /// <para>
        /// <para>The ID of the software set to apply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DesiredSoftwareSetId { get; set; }
        #endregion
        
        #region Parameter DesktopArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the desktop to stream from Amazon WorkSpaces, WorkSpaces
        /// Secure Browser, or AppStream 2.0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DesktopArn { get; set; }
        #endregion
        
        #region Parameter DesktopEndpoint
        /// <summary>
        /// <para>
        /// <para>The URL for the identity provider login (only for environments that use AppStream
        /// 2.0).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DesktopEndpoint { get; set; }
        #endregion
        
        #region Parameter DeviceCreationTag
        /// <summary>
        /// <para>
        /// <para>A map of the key-value pairs of the tag or tags to assign to the newly created devices
        /// for this environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceCreationTags")]
        public System.Collections.Hashtable DeviceCreationTag { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_EndTimeHour
        /// <summary>
        /// <para>
        /// <para>The hour for the maintenance window end (<c>00</c>-<c>23</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaintenanceWindow_EndTimeHour { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_EndTimeMinute
        /// <summary>
        /// <para>
        /// <para>The minutes for the maintenance window end (<c>00</c>-<c>59</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaintenanceWindow_EndTimeMinute { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the environment to update.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the environment to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SoftwareSetUpdateMode
        /// <summary>
        /// <para>
        /// <para>An option to define which software updates to apply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesThinClient.SoftwareSetUpdateMode")]
        public Amazon.WorkSpacesThinClient.SoftwareSetUpdateMode SoftwareSetUpdateMode { get; set; }
        #endregion
        
        #region Parameter SoftwareSetUpdateSchedule
        /// <summary>
        /// <para>
        /// <para>An option to define if software updates should be applied within a maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesThinClient.SoftwareSetUpdateSchedule")]
        public Amazon.WorkSpacesThinClient.SoftwareSetUpdateSchedule SoftwareSetUpdateSchedule { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_StartTimeHour
        /// <summary>
        /// <para>
        /// <para>The hour for the maintenance window start (<c>00</c>-<c>23</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaintenanceWindow_StartTimeHour { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_StartTimeMinute
        /// <summary>
        /// <para>
        /// <para>The minutes past the hour for the maintenance window start (<c>00</c>-<c>59</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaintenanceWindow_StartTimeMinute { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_Type
        /// <summary>
        /// <para>
        /// <para>An option to select the default or custom maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesThinClient.MaintenanceWindowType")]
        public Amazon.WorkSpacesThinClient.MaintenanceWindowType MaintenanceWindow_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Environment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Environment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WSTCEnvironment (UpdateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentResponse, UpdateWSTCEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DesiredSoftwareSetId = this.DesiredSoftwareSetId;
            context.DesktopArn = this.DesktopArn;
            context.DesktopEndpoint = this.DesktopEndpoint;
            if (this.DeviceCreationTag != null)
            {
                context.DeviceCreationTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DeviceCreationTag.Keys)
                {
                    context.DeviceCreationTag.Add((String)hashKey, (System.String)(this.DeviceCreationTag[hashKey]));
                }
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaintenanceWindow_ApplyTimeOf = this.MaintenanceWindow_ApplyTimeOf;
            if (this.MaintenanceWindow_DaysOfTheWeek != null)
            {
                context.MaintenanceWindow_DaysOfTheWeek = new List<System.String>(this.MaintenanceWindow_DaysOfTheWeek);
            }
            context.MaintenanceWindow_EndTimeHour = this.MaintenanceWindow_EndTimeHour;
            context.MaintenanceWindow_EndTimeMinute = this.MaintenanceWindow_EndTimeMinute;
            context.MaintenanceWindow_StartTimeHour = this.MaintenanceWindow_StartTimeHour;
            context.MaintenanceWindow_StartTimeMinute = this.MaintenanceWindow_StartTimeMinute;
            context.MaintenanceWindow_Type = this.MaintenanceWindow_Type;
            context.Name = this.Name;
            context.SoftwareSetUpdateMode = this.SoftwareSetUpdateMode;
            context.SoftwareSetUpdateSchedule = this.SoftwareSetUpdateSchedule;
            
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
            var request = new Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentRequest();
            
            if (cmdletContext.DesiredSoftwareSetId != null)
            {
                request.DesiredSoftwareSetId = cmdletContext.DesiredSoftwareSetId;
            }
            if (cmdletContext.DesktopArn != null)
            {
                request.DesktopArn = cmdletContext.DesktopArn;
            }
            if (cmdletContext.DesktopEndpoint != null)
            {
                request.DesktopEndpoint = cmdletContext.DesktopEndpoint;
            }
            if (cmdletContext.DeviceCreationTag != null)
            {
                request.DeviceCreationTags = cmdletContext.DeviceCreationTag;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate MaintenanceWindow
            var requestMaintenanceWindowIsNull = true;
            request.MaintenanceWindow = new Amazon.WorkSpacesThinClient.Model.MaintenanceWindow();
            Amazon.WorkSpacesThinClient.ApplyTimeOf requestMaintenanceWindow_maintenanceWindow_ApplyTimeOf = null;
            if (cmdletContext.MaintenanceWindow_ApplyTimeOf != null)
            {
                requestMaintenanceWindow_maintenanceWindow_ApplyTimeOf = cmdletContext.MaintenanceWindow_ApplyTimeOf;
            }
            if (requestMaintenanceWindow_maintenanceWindow_ApplyTimeOf != null)
            {
                request.MaintenanceWindow.ApplyTimeOf = requestMaintenanceWindow_maintenanceWindow_ApplyTimeOf;
                requestMaintenanceWindowIsNull = false;
            }
            List<System.String> requestMaintenanceWindow_maintenanceWindow_DaysOfTheWeek = null;
            if (cmdletContext.MaintenanceWindow_DaysOfTheWeek != null)
            {
                requestMaintenanceWindow_maintenanceWindow_DaysOfTheWeek = cmdletContext.MaintenanceWindow_DaysOfTheWeek;
            }
            if (requestMaintenanceWindow_maintenanceWindow_DaysOfTheWeek != null)
            {
                request.MaintenanceWindow.DaysOfTheWeek = requestMaintenanceWindow_maintenanceWindow_DaysOfTheWeek;
                requestMaintenanceWindowIsNull = false;
            }
            System.Int32? requestMaintenanceWindow_maintenanceWindow_EndTimeHour = null;
            if (cmdletContext.MaintenanceWindow_EndTimeHour != null)
            {
                requestMaintenanceWindow_maintenanceWindow_EndTimeHour = cmdletContext.MaintenanceWindow_EndTimeHour.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_EndTimeHour != null)
            {
                request.MaintenanceWindow.EndTimeHour = requestMaintenanceWindow_maintenanceWindow_EndTimeHour.Value;
                requestMaintenanceWindowIsNull = false;
            }
            System.Int32? requestMaintenanceWindow_maintenanceWindow_EndTimeMinute = null;
            if (cmdletContext.MaintenanceWindow_EndTimeMinute != null)
            {
                requestMaintenanceWindow_maintenanceWindow_EndTimeMinute = cmdletContext.MaintenanceWindow_EndTimeMinute.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_EndTimeMinute != null)
            {
                request.MaintenanceWindow.EndTimeMinute = requestMaintenanceWindow_maintenanceWindow_EndTimeMinute.Value;
                requestMaintenanceWindowIsNull = false;
            }
            System.Int32? requestMaintenanceWindow_maintenanceWindow_StartTimeHour = null;
            if (cmdletContext.MaintenanceWindow_StartTimeHour != null)
            {
                requestMaintenanceWindow_maintenanceWindow_StartTimeHour = cmdletContext.MaintenanceWindow_StartTimeHour.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_StartTimeHour != null)
            {
                request.MaintenanceWindow.StartTimeHour = requestMaintenanceWindow_maintenanceWindow_StartTimeHour.Value;
                requestMaintenanceWindowIsNull = false;
            }
            System.Int32? requestMaintenanceWindow_maintenanceWindow_StartTimeMinute = null;
            if (cmdletContext.MaintenanceWindow_StartTimeMinute != null)
            {
                requestMaintenanceWindow_maintenanceWindow_StartTimeMinute = cmdletContext.MaintenanceWindow_StartTimeMinute.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_StartTimeMinute != null)
            {
                request.MaintenanceWindow.StartTimeMinute = requestMaintenanceWindow_maintenanceWindow_StartTimeMinute.Value;
                requestMaintenanceWindowIsNull = false;
            }
            Amazon.WorkSpacesThinClient.MaintenanceWindowType requestMaintenanceWindow_maintenanceWindow_Type = null;
            if (cmdletContext.MaintenanceWindow_Type != null)
            {
                requestMaintenanceWindow_maintenanceWindow_Type = cmdletContext.MaintenanceWindow_Type;
            }
            if (requestMaintenanceWindow_maintenanceWindow_Type != null)
            {
                request.MaintenanceWindow.Type = requestMaintenanceWindow_maintenanceWindow_Type;
                requestMaintenanceWindowIsNull = false;
            }
             // determine if request.MaintenanceWindow should be set to null
            if (requestMaintenanceWindowIsNull)
            {
                request.MaintenanceWindow = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SoftwareSetUpdateMode != null)
            {
                request.SoftwareSetUpdateMode = cmdletContext.SoftwareSetUpdateMode;
            }
            if (cmdletContext.SoftwareSetUpdateSchedule != null)
            {
                request.SoftwareSetUpdateSchedule = cmdletContext.SoftwareSetUpdateSchedule;
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
        
        private Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentResponse CallAWSServiceOperation(IAmazonWorkSpacesThinClient client, Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces Thin Client", "UpdateEnvironment");
            try
            {
                #if DESKTOP
                return client.UpdateEnvironment(request);
                #elif CORECLR
                return client.UpdateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.String DesiredSoftwareSetId { get; set; }
            public System.String DesktopArn { get; set; }
            public System.String DesktopEndpoint { get; set; }
            public Dictionary<System.String, System.String> DeviceCreationTag { get; set; }
            public System.String Id { get; set; }
            public Amazon.WorkSpacesThinClient.ApplyTimeOf MaintenanceWindow_ApplyTimeOf { get; set; }
            public List<System.String> MaintenanceWindow_DaysOfTheWeek { get; set; }
            public System.Int32? MaintenanceWindow_EndTimeHour { get; set; }
            public System.Int32? MaintenanceWindow_EndTimeMinute { get; set; }
            public System.Int32? MaintenanceWindow_StartTimeHour { get; set; }
            public System.Int32? MaintenanceWindow_StartTimeMinute { get; set; }
            public Amazon.WorkSpacesThinClient.MaintenanceWindowType MaintenanceWindow_Type { get; set; }
            public System.String Name { get; set; }
            public Amazon.WorkSpacesThinClient.SoftwareSetUpdateMode SoftwareSetUpdateMode { get; set; }
            public Amazon.WorkSpacesThinClient.SoftwareSetUpdateSchedule SoftwareSetUpdateSchedule { get; set; }
            public System.Func<Amazon.WorkSpacesThinClient.Model.UpdateEnvironmentResponse, UpdateWSTCEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Environment;
        }
        
    }
}
