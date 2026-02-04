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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Updates an input.
    /// </summary>
    [Cmdlet("Update", "EMLInput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Input")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive UpdateInput API operation.", Operation = new[] {"UpdateInput"}, SelectReturnType = typeof(Amazon.MediaLive.Model.UpdateInputResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Input or Amazon.MediaLive.Model.UpdateInputResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.Input object.",
        "The service call response (type Amazon.MediaLive.Model.UpdateInputResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMLInputCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SrtSettings_SrtListenerSettings_Decryption_Algorithm
        /// <summary>
        /// <para>
        /// Required. The decryption algorithm.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.Algorithm")]
        public Amazon.MediaLive.Algorithm SrtSettings_SrtListenerSettings_Decryption_Algorithm { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// Destination settings for PUSH type inputs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destinations")]
        public Amazon.MediaLive.Model.InputDestinationRequest[] Destination { get; set; }
        #endregion
        
        #region Parameter InputDevice
        /// <summary>
        /// <para>
        /// Settings for the devices.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDevices")]
        public Amazon.MediaLive.Model.InputDeviceRequest[] InputDevice { get; set; }
        #endregion
        
        #region Parameter InputId
        /// <summary>
        /// <para>
        /// Unique ID of the input.
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
        public System.String InputId { get; set; }
        #endregion
        
        #region Parameter InputSecurityGroup
        /// <summary>
        /// <para>
        /// A list of security groups referenced
        /// by IDs to attach to the input.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputSecurityGroups")]
        public System.String[] InputSecurityGroup { get; set; }
        #endregion
        
        #region Parameter MediaConnectFlow
        /// <summary>
        /// <para>
        /// A list of the MediaConnect Flow ARNs
        /// that you want to use as the source of the input. You can specify as few as oneFlow
        /// and presently, as many as two. The only requirement is when you have more than one
        /// is that each Flow is in aseparate Availability Zone as this ensures your EML input
        /// is redundant to AZ issues.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MediaConnectFlows")]
        public Amazon.MediaLive.Model.MediaConnectFlowRequest[] MediaConnectFlow { get; set; }
        #endregion
        
        #region Parameter SrtSettings_SrtListenerSettings_MinimumLatency
        /// <summary>
        /// <para>
        /// Required. The preferred latency in milliseconds
        /// for packet loss and recovery. Range 120-15000.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SrtSettings_SrtListenerSettings_MinimumLatency { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Name of the input.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SrtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn
        /// <summary>
        /// <para>
        /// Required. The ARN for the secret in
        /// Secrets Manager that holds the passphrase.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SrtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the role this
        /// input assumes during and after creation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SpecialRouterSettings_RouterArn
        /// <summary>
        /// <para>
        /// This is the arn of the MediaConnect Router resource
        /// being associated with the MediaLive Input.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SpecialRouterSettings_RouterArn { get; set; }
        #endregion
        
        #region Parameter SdiSource
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SdiSources")]
        public System.String[] SdiSource { get; set; }
        #endregion
        
        #region Parameter Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroups")]
        public Amazon.MediaLive.Model.Smpte2110ReceiverGroup[] Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup { get; set; }
        #endregion
        
        #region Parameter MulticastSettings_Source
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MulticastSettings_Sources")]
        public Amazon.MediaLive.Model.MulticastSourceUpdateRequest[] MulticastSettings_Source { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// The source URLs for a PULL-type input. Every PULL
        /// type input needsexactly two source URLs for redundancy.Only specify sources for PULL
        /// type Inputs. Leave Destinations empty.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sources")]
        public Amazon.MediaLive.Model.InputSourceRequest[] Source { get; set; }
        #endregion
        
        #region Parameter SrtSettings_SrtCallerSource
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SrtSettings_SrtCallerSources")]
        public Amazon.MediaLive.Model.SrtCallerSourceRequest[] SrtSettings_SrtCallerSource { get; set; }
        #endregion
        
        #region Parameter SrtSettings_SrtListenerSettings_StreamId
        /// <summary>
        /// <para>
        /// Optional. The stream ID if the upstream system
        /// uses this identifier.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SrtSettings_SrtListenerSettings_StreamId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Input'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.UpdateInputResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.UpdateInputResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Input";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InputId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InputId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InputId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InputId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMLInput (UpdateInput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.UpdateInputResponse, UpdateEMLInputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InputId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.MediaLive.Model.InputDestinationRequest>(this.Destination);
            }
            if (this.InputDevice != null)
            {
                context.InputDevice = new List<Amazon.MediaLive.Model.InputDeviceRequest>(this.InputDevice);
            }
            context.InputId = this.InputId;
            #if MODULAR
            if (this.InputId == null && ParameterWasBound(nameof(this.InputId)))
            {
                WriteWarning("You are passing $null as a value for parameter InputId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InputSecurityGroup != null)
            {
                context.InputSecurityGroup = new List<System.String>(this.InputSecurityGroup);
            }
            if (this.MediaConnectFlow != null)
            {
                context.MediaConnectFlow = new List<Amazon.MediaLive.Model.MediaConnectFlowRequest>(this.MediaConnectFlow);
            }
            if (this.MulticastSettings_Source != null)
            {
                context.MulticastSettings_Source = new List<Amazon.MediaLive.Model.MulticastSourceUpdateRequest>(this.MulticastSettings_Source);
            }
            context.Name = this.Name;
            context.RoleArn = this.RoleArn;
            if (this.SdiSource != null)
            {
                context.SdiSource = new List<System.String>(this.SdiSource);
            }
            if (this.Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup != null)
            {
                context.Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup = new List<Amazon.MediaLive.Model.Smpte2110ReceiverGroup>(this.Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup);
            }
            if (this.Source != null)
            {
                context.Source = new List<Amazon.MediaLive.Model.InputSourceRequest>(this.Source);
            }
            context.SpecialRouterSettings_RouterArn = this.SpecialRouterSettings_RouterArn;
            if (this.SrtSettings_SrtCallerSource != null)
            {
                context.SrtSettings_SrtCallerSource = new List<Amazon.MediaLive.Model.SrtCallerSourceRequest>(this.SrtSettings_SrtCallerSource);
            }
            context.SrtSettings_SrtListenerSettings_Decryption_Algorithm = this.SrtSettings_SrtListenerSettings_Decryption_Algorithm;
            context.SrtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn = this.SrtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn;
            context.SrtSettings_SrtListenerSettings_MinimumLatency = this.SrtSettings_SrtListenerSettings_MinimumLatency;
            context.SrtSettings_SrtListenerSettings_StreamId = this.SrtSettings_SrtListenerSettings_StreamId;
            
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
            var request = new Amazon.MediaLive.Model.UpdateInputRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.InputDevice != null)
            {
                request.InputDevices = cmdletContext.InputDevice;
            }
            if (cmdletContext.InputId != null)
            {
                request.InputId = cmdletContext.InputId;
            }
            if (cmdletContext.InputSecurityGroup != null)
            {
                request.InputSecurityGroups = cmdletContext.InputSecurityGroup;
            }
            if (cmdletContext.MediaConnectFlow != null)
            {
                request.MediaConnectFlows = cmdletContext.MediaConnectFlow;
            }
            
             // populate MulticastSettings
            var requestMulticastSettingsIsNull = true;
            request.MulticastSettings = new Amazon.MediaLive.Model.MulticastSettingsUpdateRequest();
            List<Amazon.MediaLive.Model.MulticastSourceUpdateRequest> requestMulticastSettings_multicastSettings_Source = null;
            if (cmdletContext.MulticastSettings_Source != null)
            {
                requestMulticastSettings_multicastSettings_Source = cmdletContext.MulticastSettings_Source;
            }
            if (requestMulticastSettings_multicastSettings_Source != null)
            {
                request.MulticastSettings.Sources = requestMulticastSettings_multicastSettings_Source;
                requestMulticastSettingsIsNull = false;
            }
             // determine if request.MulticastSettings should be set to null
            if (requestMulticastSettingsIsNull)
            {
                request.MulticastSettings = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SdiSource != null)
            {
                request.SdiSources = cmdletContext.SdiSource;
            }
            
             // populate Smpte2110ReceiverGroupSettings
            var requestSmpte2110ReceiverGroupSettingsIsNull = true;
            request.Smpte2110ReceiverGroupSettings = new Amazon.MediaLive.Model.Smpte2110ReceiverGroupSettings();
            List<Amazon.MediaLive.Model.Smpte2110ReceiverGroup> requestSmpte2110ReceiverGroupSettings_smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup = null;
            if (cmdletContext.Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup != null)
            {
                requestSmpte2110ReceiverGroupSettings_smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup = cmdletContext.Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup;
            }
            if (requestSmpte2110ReceiverGroupSettings_smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup != null)
            {
                request.Smpte2110ReceiverGroupSettings.Smpte2110ReceiverGroups = requestSmpte2110ReceiverGroupSettings_smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup;
                requestSmpte2110ReceiverGroupSettingsIsNull = false;
            }
             // determine if request.Smpte2110ReceiverGroupSettings should be set to null
            if (requestSmpte2110ReceiverGroupSettingsIsNull)
            {
                request.Smpte2110ReceiverGroupSettings = null;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
            }
            
             // populate SpecialRouterSettings
            var requestSpecialRouterSettingsIsNull = true;
            request.SpecialRouterSettings = new Amazon.MediaLive.Model.SpecialRouterSettings();
            System.String requestSpecialRouterSettings_specialRouterSettings_RouterArn = null;
            if (cmdletContext.SpecialRouterSettings_RouterArn != null)
            {
                requestSpecialRouterSettings_specialRouterSettings_RouterArn = cmdletContext.SpecialRouterSettings_RouterArn;
            }
            if (requestSpecialRouterSettings_specialRouterSettings_RouterArn != null)
            {
                request.SpecialRouterSettings.RouterArn = requestSpecialRouterSettings_specialRouterSettings_RouterArn;
                requestSpecialRouterSettingsIsNull = false;
            }
             // determine if request.SpecialRouterSettings should be set to null
            if (requestSpecialRouterSettingsIsNull)
            {
                request.SpecialRouterSettings = null;
            }
            
             // populate SrtSettings
            var requestSrtSettingsIsNull = true;
            request.SrtSettings = new Amazon.MediaLive.Model.SrtSettingsRequest();
            List<Amazon.MediaLive.Model.SrtCallerSourceRequest> requestSrtSettings_srtSettings_SrtCallerSource = null;
            if (cmdletContext.SrtSettings_SrtCallerSource != null)
            {
                requestSrtSettings_srtSettings_SrtCallerSource = cmdletContext.SrtSettings_SrtCallerSource;
            }
            if (requestSrtSettings_srtSettings_SrtCallerSource != null)
            {
                request.SrtSettings.SrtCallerSources = requestSrtSettings_srtSettings_SrtCallerSource;
                requestSrtSettingsIsNull = false;
            }
            Amazon.MediaLive.Model.SrtListenerSettingsRequest requestSrtSettings_srtSettings_SrtListenerSettings = null;
            
             // populate SrtListenerSettings
            var requestSrtSettings_srtSettings_SrtListenerSettingsIsNull = true;
            requestSrtSettings_srtSettings_SrtListenerSettings = new Amazon.MediaLive.Model.SrtListenerSettingsRequest();
            System.Int32? requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_MinimumLatency = null;
            if (cmdletContext.SrtSettings_SrtListenerSettings_MinimumLatency != null)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_MinimumLatency = cmdletContext.SrtSettings_SrtListenerSettings_MinimumLatency.Value;
            }
            if (requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_MinimumLatency != null)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings.MinimumLatency = requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_MinimumLatency.Value;
                requestSrtSettings_srtSettings_SrtListenerSettingsIsNull = false;
            }
            System.String requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_StreamId = null;
            if (cmdletContext.SrtSettings_SrtListenerSettings_StreamId != null)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_StreamId = cmdletContext.SrtSettings_SrtListenerSettings_StreamId;
            }
            if (requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_StreamId != null)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings.StreamId = requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_StreamId;
                requestSrtSettings_srtSettings_SrtListenerSettingsIsNull = false;
            }
            Amazon.MediaLive.Model.SrtListenerDecryptionRequest requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption = null;
            
             // populate Decryption
            var requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_DecryptionIsNull = true;
            requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption = new Amazon.MediaLive.Model.SrtListenerDecryptionRequest();
            Amazon.MediaLive.Algorithm requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption_srtSettings_SrtListenerSettings_Decryption_Algorithm = null;
            if (cmdletContext.SrtSettings_SrtListenerSettings_Decryption_Algorithm != null)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption_srtSettings_SrtListenerSettings_Decryption_Algorithm = cmdletContext.SrtSettings_SrtListenerSettings_Decryption_Algorithm;
            }
            if (requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption_srtSettings_SrtListenerSettings_Decryption_Algorithm != null)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption.Algorithm = requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption_srtSettings_SrtListenerSettings_Decryption_Algorithm;
                requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_DecryptionIsNull = false;
            }
            System.String requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption_srtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn = null;
            if (cmdletContext.SrtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn != null)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption_srtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn = cmdletContext.SrtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn;
            }
            if (requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption_srtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn != null)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption.PassphraseSecretArn = requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption_srtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn;
                requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_DecryptionIsNull = false;
            }
             // determine if requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption should be set to null
            if (requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_DecryptionIsNull)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption = null;
            }
            if (requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption != null)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings.Decryption = requestSrtSettings_srtSettings_SrtListenerSettings_srtSettings_SrtListenerSettings_Decryption;
                requestSrtSettings_srtSettings_SrtListenerSettingsIsNull = false;
            }
             // determine if requestSrtSettings_srtSettings_SrtListenerSettings should be set to null
            if (requestSrtSettings_srtSettings_SrtListenerSettingsIsNull)
            {
                requestSrtSettings_srtSettings_SrtListenerSettings = null;
            }
            if (requestSrtSettings_srtSettings_SrtListenerSettings != null)
            {
                request.SrtSettings.SrtListenerSettings = requestSrtSettings_srtSettings_SrtListenerSettings;
                requestSrtSettingsIsNull = false;
            }
             // determine if request.SrtSettings should be set to null
            if (requestSrtSettingsIsNull)
            {
                request.SrtSettings = null;
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
        
        private Amazon.MediaLive.Model.UpdateInputResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.UpdateInputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "UpdateInput");
            try
            {
                #if DESKTOP
                return client.UpdateInput(request);
                #elif CORECLR
                return client.UpdateInputAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.MediaLive.Model.InputDestinationRequest> Destination { get; set; }
            public List<Amazon.MediaLive.Model.InputDeviceRequest> InputDevice { get; set; }
            public System.String InputId { get; set; }
            public List<System.String> InputSecurityGroup { get; set; }
            public List<Amazon.MediaLive.Model.MediaConnectFlowRequest> MediaConnectFlow { get; set; }
            public List<Amazon.MediaLive.Model.MulticastSourceUpdateRequest> MulticastSettings_Source { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public List<System.String> SdiSource { get; set; }
            public List<Amazon.MediaLive.Model.Smpte2110ReceiverGroup> Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup { get; set; }
            public List<Amazon.MediaLive.Model.InputSourceRequest> Source { get; set; }
            public System.String SpecialRouterSettings_RouterArn { get; set; }
            public List<Amazon.MediaLive.Model.SrtCallerSourceRequest> SrtSettings_SrtCallerSource { get; set; }
            public Amazon.MediaLive.Algorithm SrtSettings_SrtListenerSettings_Decryption_Algorithm { get; set; }
            public System.String SrtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn { get; set; }
            public System.Int32? SrtSettings_SrtListenerSettings_MinimumLatency { get; set; }
            public System.String SrtSettings_SrtListenerSettings_StreamId { get; set; }
            public System.Func<Amazon.MediaLive.Model.UpdateInputResponse, UpdateEMLInputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Input;
        }
        
    }
}
