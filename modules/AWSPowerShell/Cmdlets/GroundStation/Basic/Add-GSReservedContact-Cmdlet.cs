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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// Reserves a contact using specified parameters.
    /// </summary>
    [Cmdlet("Add", "GSReservedContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Ground Station ReserveContact API operation.", Operation = new[] {"ReserveContact"}, SelectReturnType = typeof(Amazon.GroundStation.Model.ReserveContactResponse))]
    [AWSCmdletOutput("System.String or Amazon.GroundStation.Model.ReserveContactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GroundStation.Model.ReserveContactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddGSReservedContactCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>End time of a contact in UTC.</para>
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
        
        #region Parameter AzEl_EphemerisId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of the azimuth elevation ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrackingOverrides_ProgramTrackSettings_AzEl_EphemerisId")]
        public System.String AzEl_EphemerisId { get; set; }
        #endregion
        
        #region Parameter GroundStation
        /// <summary>
        /// <para>
        /// <para>Name of a ground station.</para>
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
        public System.String GroundStation { get; set; }
        #endregion
        
        #region Parameter MissionProfileArn
        /// <summary>
        /// <para>
        /// <para>ARN of a mission profile.</para>
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
        public System.String MissionProfileArn { get; set; }
        #endregion
        
        #region Parameter SatelliteArn
        /// <summary>
        /// <para>
        /// <para>ARN of a satellite</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SatelliteArn { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>Start time of a contact in UTC.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags assigned to a contact.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContactId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.ReserveContactResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.ReserveContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContactId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MissionProfileArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-GSReservedContact (ReserveContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.ReserveContactResponse, AddGSReservedContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GroundStation = this.GroundStation;
            #if MODULAR
            if (this.GroundStation == null && ParameterWasBound(nameof(this.GroundStation)))
            {
                WriteWarning("You are passing $null as a value for parameter GroundStation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MissionProfileArn = this.MissionProfileArn;
            #if MODULAR
            if (this.MissionProfileArn == null && ParameterWasBound(nameof(this.MissionProfileArn)))
            {
                WriteWarning("You are passing $null as a value for parameter MissionProfileArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SatelliteArn = this.SatelliteArn;
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.AzEl_EphemerisId = this.AzEl_EphemerisId;
            
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
            var request = new Amazon.GroundStation.Model.ReserveContactRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.GroundStation != null)
            {
                request.GroundStation = cmdletContext.GroundStation;
            }
            if (cmdletContext.MissionProfileArn != null)
            {
                request.MissionProfileArn = cmdletContext.MissionProfileArn;
            }
            if (cmdletContext.SatelliteArn != null)
            {
                request.SatelliteArn = cmdletContext.SatelliteArn;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TrackingOverrides
            var requestTrackingOverridesIsNull = true;
            request.TrackingOverrides = new Amazon.GroundStation.Model.TrackingOverrides();
            Amazon.GroundStation.Model.ProgramTrackSettings requestTrackingOverrides_trackingOverrides_ProgramTrackSettings = null;
            
             // populate ProgramTrackSettings
            var requestTrackingOverrides_trackingOverrides_ProgramTrackSettingsIsNull = true;
            requestTrackingOverrides_trackingOverrides_ProgramTrackSettings = new Amazon.GroundStation.Model.ProgramTrackSettings();
            Amazon.GroundStation.Model.AzElProgramTrackSettings requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl = null;
            
             // populate AzEl
            var requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzElIsNull = true;
            requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl = new Amazon.GroundStation.Model.AzElProgramTrackSettings();
            System.String requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl_azEl_EphemerisId = null;
            if (cmdletContext.AzEl_EphemerisId != null)
            {
                requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl_azEl_EphemerisId = cmdletContext.AzEl_EphemerisId;
            }
            if (requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl_azEl_EphemerisId != null)
            {
                requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl.EphemerisId = requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl_azEl_EphemerisId;
                requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzElIsNull = false;
            }
             // determine if requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl should be set to null
            if (requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzElIsNull)
            {
                requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl = null;
            }
            if (requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl != null)
            {
                requestTrackingOverrides_trackingOverrides_ProgramTrackSettings.AzEl = requestTrackingOverrides_trackingOverrides_ProgramTrackSettings_trackingOverrides_ProgramTrackSettings_AzEl;
                requestTrackingOverrides_trackingOverrides_ProgramTrackSettingsIsNull = false;
            }
             // determine if requestTrackingOverrides_trackingOverrides_ProgramTrackSettings should be set to null
            if (requestTrackingOverrides_trackingOverrides_ProgramTrackSettingsIsNull)
            {
                requestTrackingOverrides_trackingOverrides_ProgramTrackSettings = null;
            }
            if (requestTrackingOverrides_trackingOverrides_ProgramTrackSettings != null)
            {
                request.TrackingOverrides.ProgramTrackSettings = requestTrackingOverrides_trackingOverrides_ProgramTrackSettings;
                requestTrackingOverridesIsNull = false;
            }
             // determine if request.TrackingOverrides should be set to null
            if (requestTrackingOverridesIsNull)
            {
                request.TrackingOverrides = null;
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
        
        private Amazon.GroundStation.Model.ReserveContactResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.ReserveContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "ReserveContact");
            try
            {
                return client.ReserveContactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GroundStation { get; set; }
            public System.String MissionProfileArn { get; set; }
            public System.String SatelliteArn { get; set; }
            public System.DateTime? StartTime { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String AzEl_EphemerisId { get; set; }
            public System.Func<Amazon.GroundStation.Model.ReserveContactResponse, AddGSReservedContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContactId;
        }
        
    }
}
