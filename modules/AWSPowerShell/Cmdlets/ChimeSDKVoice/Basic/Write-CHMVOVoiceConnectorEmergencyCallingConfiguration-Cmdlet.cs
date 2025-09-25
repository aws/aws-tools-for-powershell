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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Updates a Voice Connector's emergency calling configuration.
    /// </summary>
    [Cmdlet("Write", "CHMVOVoiceConnectorEmergencyCallingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.EmergencyCallingConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice PutVoiceConnectorEmergencyCallingConfiguration API operation.", Operation = new[] {"PutVoiceConnectorEmergencyCallingConfiguration"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.EmergencyCallingConfiguration or Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.EmergencyCallingConfiguration object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCHMVOVoiceConnectorEmergencyCallingConfigurationCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EmergencyCallingConfiguration_DNIS
        /// <summary>
        /// <para>
        /// <para>The Dialed Number Identification Service (DNIS) emergency calling configuration details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ChimeSDKVoice.Model.DNISEmergencyCallingConfiguration[] EmergencyCallingConfiguration_DNIS { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// <para>The Voice Connector ID.</para>
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
        public System.String VoiceConnectorId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EmergencyCallingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EmergencyCallingConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VoiceConnectorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VoiceConnectorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VoiceConnectorId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVOVoiceConnectorEmergencyCallingConfiguration (PutVoiceConnectorEmergencyCallingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse, WriteCHMVOVoiceConnectorEmergencyCallingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VoiceConnectorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.EmergencyCallingConfiguration_DNIS != null)
            {
                context.EmergencyCallingConfiguration_DNIS = new List<Amazon.ChimeSDKVoice.Model.DNISEmergencyCallingConfiguration>(this.EmergencyCallingConfiguration_DNIS);
            }
            context.VoiceConnectorId = this.VoiceConnectorId;
            #if MODULAR
            if (this.VoiceConnectorId == null && ParameterWasBound(nameof(this.VoiceConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationRequest();
            
            
             // populate EmergencyCallingConfiguration
            var requestEmergencyCallingConfigurationIsNull = true;
            request.EmergencyCallingConfiguration = new Amazon.ChimeSDKVoice.Model.EmergencyCallingConfiguration();
            List<Amazon.ChimeSDKVoice.Model.DNISEmergencyCallingConfiguration> requestEmergencyCallingConfiguration_emergencyCallingConfiguration_DNIS = null;
            if (cmdletContext.EmergencyCallingConfiguration_DNIS != null)
            {
                requestEmergencyCallingConfiguration_emergencyCallingConfiguration_DNIS = cmdletContext.EmergencyCallingConfiguration_DNIS;
            }
            if (requestEmergencyCallingConfiguration_emergencyCallingConfiguration_DNIS != null)
            {
                request.EmergencyCallingConfiguration.DNIS = requestEmergencyCallingConfiguration_emergencyCallingConfiguration_DNIS;
                requestEmergencyCallingConfigurationIsNull = false;
            }
             // determine if request.EmergencyCallingConfiguration should be set to null
            if (requestEmergencyCallingConfigurationIsNull)
            {
                request.EmergencyCallingConfiguration = null;
            }
            if (cmdletContext.VoiceConnectorId != null)
            {
                request.VoiceConnectorId = cmdletContext.VoiceConnectorId;
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
        
        private Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "PutVoiceConnectorEmergencyCallingConfiguration");
            try
            {
                #if DESKTOP
                return client.PutVoiceConnectorEmergencyCallingConfiguration(request);
                #elif CORECLR
                return client.PutVoiceConnectorEmergencyCallingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ChimeSDKVoice.Model.DNISEmergencyCallingConfiguration> EmergencyCallingConfiguration_DNIS { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse, WriteCHMVOVoiceConnectorEmergencyCallingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmergencyCallingConfiguration;
        }
        
    }
}
