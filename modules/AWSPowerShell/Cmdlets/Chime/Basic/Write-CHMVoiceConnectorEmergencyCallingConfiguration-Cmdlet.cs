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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Puts emergency calling configuration details to the specified Amazon Chime Voice Connector,
    /// such as emergency phone numbers and calling countries. Origination and termination
    /// settings must be enabled for the Amazon Chime Voice Connector before emergency calling
    /// can be configured.
    /// 
    ///  <important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_voice-chime_PutVoiceConnectorEmergencyCallingConfiguration.html">PutVoiceConnectorEmergencyCallingConfiguration</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Write", "CHMVoiceConnectorEmergencyCallingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.EmergencyCallingConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime PutVoiceConnectorEmergencyCallingConfiguration API operation.", Operation = new[] {"PutVoiceConnectorEmergencyCallingConfiguration"}, SelectReturnType = typeof(Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.EmergencyCallingConfiguration or Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse",
        "This cmdlet returns an Amazon.Chime.Model.EmergencyCallingConfiguration object.",
        "The service call response (type Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by PutVoiceConnectorEmergencyCallingConfiguration in the Amazon Chime SDK Voice Namespace")]
    public partial class WriteCHMVoiceConnectorEmergencyCallingConfigurationCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EmergencyCallingConfiguration_DNIS
        /// <summary>
        /// <para>
        /// <para>The Dialed Number Identification Service (DNIS) emergency calling configuration details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Chime.Model.DNISEmergencyCallingConfiguration[] EmergencyCallingConfiguration_DNIS { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime Voice Connector ID.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EmergencyCallingConfiguration";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVoiceConnectorEmergencyCallingConfiguration (PutVoiceConnectorEmergencyCallingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse, WriteCHMVoiceConnectorEmergencyCallingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.EmergencyCallingConfiguration_DNIS != null)
            {
                context.EmergencyCallingConfiguration_DNIS = new List<Amazon.Chime.Model.DNISEmergencyCallingConfiguration>(this.EmergencyCallingConfiguration_DNIS);
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
            var request = new Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationRequest();
            
            
             // populate EmergencyCallingConfiguration
            var requestEmergencyCallingConfigurationIsNull = true;
            request.EmergencyCallingConfiguration = new Amazon.Chime.Model.EmergencyCallingConfiguration();
            List<Amazon.Chime.Model.DNISEmergencyCallingConfiguration> requestEmergencyCallingConfiguration_emergencyCallingConfiguration_DNIS = null;
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
        
        private Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "PutVoiceConnectorEmergencyCallingConfiguration");
            try
            {
                return client.PutVoiceConnectorEmergencyCallingConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Chime.Model.DNISEmergencyCallingConfiguration> EmergencyCallingConfiguration_DNIS { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.Chime.Model.PutVoiceConnectorEmergencyCallingConfigurationResponse, WriteCHMVoiceConnectorEmergencyCallingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmergencyCallingConfiguration;
        }
        
    }
}
