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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Updates a channel.
    /// </summary>
    [Cmdlet("Update", "EMLChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Channel")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive UpdateChannel API operation.", Operation = new[] {"UpdateChannel"}, SelectReturnType = typeof(Amazon.MediaLive.Model.UpdateChannelResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Channel or Amazon.MediaLive.Model.UpdateChannelResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.Channel object.",
        "The service call response (type Amazon.MediaLive.Model.UpdateChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEMLChannelCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// channel ID
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
        public System.String ChannelId { get; set; }
        #endregion
        
        #region Parameter InputSpecification_Codec
        /// <summary>
        /// <para>
        /// Input codec
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputCodec")]
        public Amazon.MediaLive.InputCodec InputSpecification_Codec { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// A list of output destinations for this channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destinations")]
        public Amazon.MediaLive.Model.OutputDestination[] Destination { get; set; }
        #endregion
        
        #region Parameter EncoderSetting
        /// <summary>
        /// <para>
        /// The encoder settings for this channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncoderSettings")]
        public Amazon.MediaLive.Model.EncoderSettings EncoderSetting { get; set; }
        #endregion
        
        #region Parameter InputAttachment
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputAttachments")]
        public Amazon.MediaLive.Model.InputAttachment[] InputAttachment { get; set; }
        #endregion
        
        #region Parameter LogLevel
        /// <summary>
        /// <para>
        /// The log level to write to CloudWatch Logs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.LogLevel")]
        public Amazon.MediaLive.LogLevel LogLevel { get; set; }
        #endregion
        
        #region Parameter Maintenance_MaintenanceDay
        /// <summary>
        /// <para>
        /// Choose one day of the week for maintenance.
        /// The chosen day is used for all future maintenance windows.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.MaintenanceDay")]
        public Amazon.MediaLive.MaintenanceDay Maintenance_MaintenanceDay { get; set; }
        #endregion
        
        #region Parameter Maintenance_MaintenanceScheduledDate
        /// <summary>
        /// <para>
        /// Choose a specific date for maintenance
        /// to occur. The chosen date is used for the next maintenance window only.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Maintenance_MaintenanceScheduledDate { get; set; }
        #endregion
        
        #region Parameter Maintenance_MaintenanceStartTime
        /// <summary>
        /// <para>
        /// Choose the hour that maintenance
        /// will start. The chosen time is used for all future maintenance windows.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Maintenance_MaintenanceStartTime { get; set; }
        #endregion
        
        #region Parameter InputSpecification_MaximumBitrate
        /// <summary>
        /// <para>
        /// Maximum input bitrate, categorized coarsely
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputMaximumBitrate")]
        public Amazon.MediaLive.InputMaximumBitrate InputSpecification_MaximumBitrate { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CdiInputSpecification_Resolution
        /// <summary>
        /// <para>
        /// Maximum CDI input resolution
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.CdiInputResolution")]
        public Amazon.MediaLive.CdiInputResolution CdiInputSpecification_Resolution { get; set; }
        #endregion
        
        #region Parameter InputSpecification_Resolution
        /// <summary>
        /// <para>
        /// Input resolution, categorized coarsely
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputResolution")]
        public Amazon.MediaLive.InputResolution InputSpecification_Resolution { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// An optional Amazon Resource Name (ARN) of the
        /// role to assume when running the Channel. If you do not specify this on an update call
        /// but the role was previously set that role will be removed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Channel'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.UpdateChannelResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.UpdateChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Channel";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChannelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChannelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChannelId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMLChannel (UpdateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.UpdateChannelResponse, UpdateEMLChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChannelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CdiInputSpecification_Resolution = this.CdiInputSpecification_Resolution;
            context.ChannelId = this.ChannelId;
            #if MODULAR
            if (this.ChannelId == null && ParameterWasBound(nameof(this.ChannelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.MediaLive.Model.OutputDestination>(this.Destination);
            }
            context.EncoderSetting = this.EncoderSetting;
            if (this.InputAttachment != null)
            {
                context.InputAttachment = new List<Amazon.MediaLive.Model.InputAttachment>(this.InputAttachment);
            }
            context.InputSpecification_Codec = this.InputSpecification_Codec;
            context.InputSpecification_MaximumBitrate = this.InputSpecification_MaximumBitrate;
            context.InputSpecification_Resolution = this.InputSpecification_Resolution;
            context.LogLevel = this.LogLevel;
            context.Maintenance_MaintenanceDay = this.Maintenance_MaintenanceDay;
            context.Maintenance_MaintenanceScheduledDate = this.Maintenance_MaintenanceScheduledDate;
            context.Maintenance_MaintenanceStartTime = this.Maintenance_MaintenanceStartTime;
            context.Name = this.Name;
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.MediaLive.Model.UpdateChannelRequest();
            
            
             // populate CdiInputSpecification
            var requestCdiInputSpecificationIsNull = true;
            request.CdiInputSpecification = new Amazon.MediaLive.Model.CdiInputSpecification();
            Amazon.MediaLive.CdiInputResolution requestCdiInputSpecification_cdiInputSpecification_Resolution = null;
            if (cmdletContext.CdiInputSpecification_Resolution != null)
            {
                requestCdiInputSpecification_cdiInputSpecification_Resolution = cmdletContext.CdiInputSpecification_Resolution;
            }
            if (requestCdiInputSpecification_cdiInputSpecification_Resolution != null)
            {
                request.CdiInputSpecification.Resolution = requestCdiInputSpecification_cdiInputSpecification_Resolution;
                requestCdiInputSpecificationIsNull = false;
            }
             // determine if request.CdiInputSpecification should be set to null
            if (requestCdiInputSpecificationIsNull)
            {
                request.CdiInputSpecification = null;
            }
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelId = cmdletContext.ChannelId;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.EncoderSetting != null)
            {
                request.EncoderSettings = cmdletContext.EncoderSetting;
            }
            if (cmdletContext.InputAttachment != null)
            {
                request.InputAttachments = cmdletContext.InputAttachment;
            }
            
             // populate InputSpecification
            var requestInputSpecificationIsNull = true;
            request.InputSpecification = new Amazon.MediaLive.Model.InputSpecification();
            Amazon.MediaLive.InputCodec requestInputSpecification_inputSpecification_Codec = null;
            if (cmdletContext.InputSpecification_Codec != null)
            {
                requestInputSpecification_inputSpecification_Codec = cmdletContext.InputSpecification_Codec;
            }
            if (requestInputSpecification_inputSpecification_Codec != null)
            {
                request.InputSpecification.Codec = requestInputSpecification_inputSpecification_Codec;
                requestInputSpecificationIsNull = false;
            }
            Amazon.MediaLive.InputMaximumBitrate requestInputSpecification_inputSpecification_MaximumBitrate = null;
            if (cmdletContext.InputSpecification_MaximumBitrate != null)
            {
                requestInputSpecification_inputSpecification_MaximumBitrate = cmdletContext.InputSpecification_MaximumBitrate;
            }
            if (requestInputSpecification_inputSpecification_MaximumBitrate != null)
            {
                request.InputSpecification.MaximumBitrate = requestInputSpecification_inputSpecification_MaximumBitrate;
                requestInputSpecificationIsNull = false;
            }
            Amazon.MediaLive.InputResolution requestInputSpecification_inputSpecification_Resolution = null;
            if (cmdletContext.InputSpecification_Resolution != null)
            {
                requestInputSpecification_inputSpecification_Resolution = cmdletContext.InputSpecification_Resolution;
            }
            if (requestInputSpecification_inputSpecification_Resolution != null)
            {
                request.InputSpecification.Resolution = requestInputSpecification_inputSpecification_Resolution;
                requestInputSpecificationIsNull = false;
            }
             // determine if request.InputSpecification should be set to null
            if (requestInputSpecificationIsNull)
            {
                request.InputSpecification = null;
            }
            if (cmdletContext.LogLevel != null)
            {
                request.LogLevel = cmdletContext.LogLevel;
            }
            
             // populate Maintenance
            var requestMaintenanceIsNull = true;
            request.Maintenance = new Amazon.MediaLive.Model.MaintenanceUpdateSettings();
            Amazon.MediaLive.MaintenanceDay requestMaintenance_maintenance_MaintenanceDay = null;
            if (cmdletContext.Maintenance_MaintenanceDay != null)
            {
                requestMaintenance_maintenance_MaintenanceDay = cmdletContext.Maintenance_MaintenanceDay;
            }
            if (requestMaintenance_maintenance_MaintenanceDay != null)
            {
                request.Maintenance.MaintenanceDay = requestMaintenance_maintenance_MaintenanceDay;
                requestMaintenanceIsNull = false;
            }
            System.String requestMaintenance_maintenance_MaintenanceScheduledDate = null;
            if (cmdletContext.Maintenance_MaintenanceScheduledDate != null)
            {
                requestMaintenance_maintenance_MaintenanceScheduledDate = cmdletContext.Maintenance_MaintenanceScheduledDate;
            }
            if (requestMaintenance_maintenance_MaintenanceScheduledDate != null)
            {
                request.Maintenance.MaintenanceScheduledDate = requestMaintenance_maintenance_MaintenanceScheduledDate;
                requestMaintenanceIsNull = false;
            }
            System.String requestMaintenance_maintenance_MaintenanceStartTime = null;
            if (cmdletContext.Maintenance_MaintenanceStartTime != null)
            {
                requestMaintenance_maintenance_MaintenanceStartTime = cmdletContext.Maintenance_MaintenanceStartTime;
            }
            if (requestMaintenance_maintenance_MaintenanceStartTime != null)
            {
                request.Maintenance.MaintenanceStartTime = requestMaintenance_maintenance_MaintenanceStartTime;
                requestMaintenanceIsNull = false;
            }
             // determine if request.Maintenance should be set to null
            if (requestMaintenanceIsNull)
            {
                request.Maintenance = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.MediaLive.Model.UpdateChannelResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.UpdateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "UpdateChannel");
            try
            {
                #if DESKTOP
                return client.UpdateChannel(request);
                #elif CORECLR
                return client.UpdateChannelAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaLive.CdiInputResolution CdiInputSpecification_Resolution { get; set; }
            public System.String ChannelId { get; set; }
            public List<Amazon.MediaLive.Model.OutputDestination> Destination { get; set; }
            public Amazon.MediaLive.Model.EncoderSettings EncoderSetting { get; set; }
            public List<Amazon.MediaLive.Model.InputAttachment> InputAttachment { get; set; }
            public Amazon.MediaLive.InputCodec InputSpecification_Codec { get; set; }
            public Amazon.MediaLive.InputMaximumBitrate InputSpecification_MaximumBitrate { get; set; }
            public Amazon.MediaLive.InputResolution InputSpecification_Resolution { get; set; }
            public Amazon.MediaLive.LogLevel LogLevel { get; set; }
            public Amazon.MediaLive.MaintenanceDay Maintenance_MaintenanceDay { get; set; }
            public System.String Maintenance_MaintenanceScheduledDate { get; set; }
            public System.String Maintenance_MaintenanceStartTime { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.MediaLive.Model.UpdateChannelResponse, UpdateEMLChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Channel;
        }
        
    }
}
