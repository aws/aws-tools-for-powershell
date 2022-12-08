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
    /// Updates the parameters for the input device.
    /// </summary>
    [Cmdlet("Update", "EMLInputDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.UpdateInputDeviceResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive UpdateInputDevice API operation.", Operation = new[] {"UpdateInputDevice"}, SelectReturnType = typeof(Amazon.MediaLive.Model.UpdateInputDeviceResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.UpdateInputDeviceResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.UpdateInputDeviceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEMLInputDeviceCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        #region Parameter HdDeviceSettings_ConfiguredInput
        /// <summary>
        /// <para>
        /// The input source that you want to use.
        /// If the device has a source connected to only one of its input ports, or if you don't
        /// care which source the device sends, specify Auto. If the device has sources connected
        /// to both its input ports, and you want to use a specific source, specify the source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputDeviceConfiguredInput")]
        public Amazon.MediaLive.InputDeviceConfiguredInput HdDeviceSettings_ConfiguredInput { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_ConfiguredInput
        /// <summary>
        /// <para>
        /// The input source that you want to use.
        /// If the device has a source connected to only one of its input ports, or if you don't
        /// care which source the device sends, specify Auto. If the device has sources connected
        /// to both its input ports, and you want to use a specific source, specify the source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputDeviceConfiguredInput")]
        public Amazon.MediaLive.InputDeviceConfiguredInput UhdDeviceSettings_ConfiguredInput { get; set; }
        #endregion
        
        #region Parameter InputDeviceId
        /// <summary>
        /// <para>
        /// The unique ID of the input device. For example,
        /// hd-123456789abcdef.
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
        public System.String InputDeviceId { get; set; }
        #endregion
        
        #region Parameter HdDeviceSettings_MaxBitrate
        /// <summary>
        /// <para>
        /// The maximum bitrate in bits per second. Set
        /// a value here to throttle the bitrate of the source video.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HdDeviceSettings_MaxBitrate { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_MaxBitrate
        /// <summary>
        /// <para>
        /// The maximum bitrate in bits per second. Set
        /// a value here to throttle the bitrate of the source video.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UhdDeviceSettings_MaxBitrate { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name that you assigned to this input device (not
        /// the unique ID).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.UpdateInputDeviceResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.UpdateInputDeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InputDeviceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InputDeviceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InputDeviceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InputDeviceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMLInputDevice (UpdateInputDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.UpdateInputDeviceResponse, UpdateEMLInputDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InputDeviceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HdDeviceSettings_ConfiguredInput = this.HdDeviceSettings_ConfiguredInput;
            context.HdDeviceSettings_MaxBitrate = this.HdDeviceSettings_MaxBitrate;
            context.InputDeviceId = this.InputDeviceId;
            #if MODULAR
            if (this.InputDeviceId == null && ParameterWasBound(nameof(this.InputDeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.UhdDeviceSettings_ConfiguredInput = this.UhdDeviceSettings_ConfiguredInput;
            context.UhdDeviceSettings_MaxBitrate = this.UhdDeviceSettings_MaxBitrate;
            
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
            var request = new Amazon.MediaLive.Model.UpdateInputDeviceRequest();
            
            
             // populate HdDeviceSettings
            var requestHdDeviceSettingsIsNull = true;
            request.HdDeviceSettings = new Amazon.MediaLive.Model.InputDeviceConfigurableSettings();
            Amazon.MediaLive.InputDeviceConfiguredInput requestHdDeviceSettings_hdDeviceSettings_ConfiguredInput = null;
            if (cmdletContext.HdDeviceSettings_ConfiguredInput != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_ConfiguredInput = cmdletContext.HdDeviceSettings_ConfiguredInput;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_ConfiguredInput != null)
            {
                request.HdDeviceSettings.ConfiguredInput = requestHdDeviceSettings_hdDeviceSettings_ConfiguredInput;
                requestHdDeviceSettingsIsNull = false;
            }
            System.Int32? requestHdDeviceSettings_hdDeviceSettings_MaxBitrate = null;
            if (cmdletContext.HdDeviceSettings_MaxBitrate != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MaxBitrate = cmdletContext.HdDeviceSettings_MaxBitrate.Value;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_MaxBitrate != null)
            {
                request.HdDeviceSettings.MaxBitrate = requestHdDeviceSettings_hdDeviceSettings_MaxBitrate.Value;
                requestHdDeviceSettingsIsNull = false;
            }
             // determine if request.HdDeviceSettings should be set to null
            if (requestHdDeviceSettingsIsNull)
            {
                request.HdDeviceSettings = null;
            }
            if (cmdletContext.InputDeviceId != null)
            {
                request.InputDeviceId = cmdletContext.InputDeviceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate UhdDeviceSettings
            var requestUhdDeviceSettingsIsNull = true;
            request.UhdDeviceSettings = new Amazon.MediaLive.Model.InputDeviceConfigurableSettings();
            Amazon.MediaLive.InputDeviceConfiguredInput requestUhdDeviceSettings_uhdDeviceSettings_ConfiguredInput = null;
            if (cmdletContext.UhdDeviceSettings_ConfiguredInput != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_ConfiguredInput = cmdletContext.UhdDeviceSettings_ConfiguredInput;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_ConfiguredInput != null)
            {
                request.UhdDeviceSettings.ConfiguredInput = requestUhdDeviceSettings_uhdDeviceSettings_ConfiguredInput;
                requestUhdDeviceSettingsIsNull = false;
            }
            System.Int32? requestUhdDeviceSettings_uhdDeviceSettings_MaxBitrate = null;
            if (cmdletContext.UhdDeviceSettings_MaxBitrate != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MaxBitrate = cmdletContext.UhdDeviceSettings_MaxBitrate.Value;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_MaxBitrate != null)
            {
                request.UhdDeviceSettings.MaxBitrate = requestUhdDeviceSettings_uhdDeviceSettings_MaxBitrate.Value;
                requestUhdDeviceSettingsIsNull = false;
            }
             // determine if request.UhdDeviceSettings should be set to null
            if (requestUhdDeviceSettingsIsNull)
            {
                request.UhdDeviceSettings = null;
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
        
        private Amazon.MediaLive.Model.UpdateInputDeviceResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.UpdateInputDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "UpdateInputDevice");
            try
            {
                #if DESKTOP
                return client.UpdateInputDevice(request);
                #elif CORECLR
                return client.UpdateInputDeviceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaLive.InputDeviceConfiguredInput HdDeviceSettings_ConfiguredInput { get; set; }
            public System.Int32? HdDeviceSettings_MaxBitrate { get; set; }
            public System.String InputDeviceId { get; set; }
            public System.String Name { get; set; }
            public Amazon.MediaLive.InputDeviceConfiguredInput UhdDeviceSettings_ConfiguredInput { get; set; }
            public System.Int32? UhdDeviceSettings_MaxBitrate { get; set; }
            public System.Func<Amazon.MediaLive.Model.UpdateInputDeviceResponse, UpdateEMLInputDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
