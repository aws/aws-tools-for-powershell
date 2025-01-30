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
    /// Puts the specified proxy configuration to the specified Amazon Chime SDK Voice Connector.
    /// </summary>
    [Cmdlet("Write", "CHMVOVoiceConnectorProxy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.Proxy")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice PutVoiceConnectorProxy API operation.", Operation = new[] {"PutVoiceConnectorProxy"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.Proxy or Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.Proxy object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCHMVOVoiceConnectorProxyCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultSessionExpiryMinute
        /// <summary>
        /// <para>
        /// <para>The default number of minutes allowed for proxy session.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DefaultSessionExpiryMinutes")]
        public System.Int32? DefaultSessionExpiryMinute { get; set; }
        #endregion
        
        #region Parameter Disabled
        /// <summary>
        /// <para>
        /// <para>When true, stops proxy sessions from being created on the specified Amazon Chime SDK
        /// Voice Connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Disabled { get; set; }
        #endregion
        
        #region Parameter FallBackPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number to route calls to after a proxy session expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FallBackPhoneNumber { get; set; }
        #endregion
        
        #region Parameter PhoneNumberPoolCountry
        /// <summary>
        /// <para>
        /// <para>The countries for proxy phone numbers to be selected from.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("PhoneNumberPoolCountries")]
        public System.String[] PhoneNumberPoolCountry { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// <para>The Voice Connector ID.</para>
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
        public System.String VoiceConnectorId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Proxy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Proxy";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVOVoiceConnectorProxy (PutVoiceConnectorProxy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyResponse, WriteCHMVOVoiceConnectorProxyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultSessionExpiryMinute = this.DefaultSessionExpiryMinute;
            #if MODULAR
            if (this.DefaultSessionExpiryMinute == null && ParameterWasBound(nameof(this.DefaultSessionExpiryMinute)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultSessionExpiryMinute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Disabled = this.Disabled;
            context.FallBackPhoneNumber = this.FallBackPhoneNumber;
            if (this.PhoneNumberPoolCountry != null)
            {
                context.PhoneNumberPoolCountry = new List<System.String>(this.PhoneNumberPoolCountry);
            }
            #if MODULAR
            if (this.PhoneNumberPoolCountry == null && ParameterWasBound(nameof(this.PhoneNumberPoolCountry)))
            {
                WriteWarning("You are passing $null as a value for parameter PhoneNumberPoolCountry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyRequest();
            
            if (cmdletContext.DefaultSessionExpiryMinute != null)
            {
                request.DefaultSessionExpiryMinutes = cmdletContext.DefaultSessionExpiryMinute.Value;
            }
            if (cmdletContext.Disabled != null)
            {
                request.Disabled = cmdletContext.Disabled.Value;
            }
            if (cmdletContext.FallBackPhoneNumber != null)
            {
                request.FallBackPhoneNumber = cmdletContext.FallBackPhoneNumber;
            }
            if (cmdletContext.PhoneNumberPoolCountry != null)
            {
                request.PhoneNumberPoolCountries = cmdletContext.PhoneNumberPoolCountry;
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
        
        private Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "PutVoiceConnectorProxy");
            try
            {
                #if DESKTOP
                return client.PutVoiceConnectorProxy(request);
                #elif CORECLR
                return client.PutVoiceConnectorProxyAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DefaultSessionExpiryMinute { get; set; }
            public System.Boolean? Disabled { get; set; }
            public System.String FallBackPhoneNumber { get; set; }
            public List<System.String> PhoneNumberPoolCountry { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorProxyResponse, WriteCHMVOVoiceConnectorProxyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Proxy;
        }
        
    }
}
