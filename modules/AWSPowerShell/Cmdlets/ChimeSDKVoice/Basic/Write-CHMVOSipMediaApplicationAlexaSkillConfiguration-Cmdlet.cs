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
    /// Updates the Alexa Skill configuration for the SIP media application.
    /// 
    ///  <important><para>
    /// Due to changes made by the Amazon Alexa service, this API is no longer available for
    /// use. For more information, refer to the <a href="https://developer.amazon.com/en-US/alexa/alexasmartproperties">Alexa
    /// Smart Properties</a> page.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Write", "CHMVOSipMediaApplicationAlexaSkillConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.SipMediaApplicationAlexaSkillConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice PutSipMediaApplicationAlexaSkillConfiguration API operation.", Operation = new[] {"PutSipMediaApplicationAlexaSkillConfiguration"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.SipMediaApplicationAlexaSkillConfiguration or Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.SipMediaApplicationAlexaSkillConfiguration object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Due to changes made by the Amazon Alexa service, this API is no longer available for use. For more information, refer to the Alexa Smart Properties page(https://developer.amazon.com/en-US/alexa/alexasmartproperties).")]
    public partial class WriteCHMVOSipMediaApplicationAlexaSkillConfigurationCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SipMediaApplicationAlexaSkillConfiguration_AlexaSkillId
        /// <summary>
        /// <para>
        /// <para>The ID of the Alexa Skill configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SipMediaApplicationAlexaSkillConfiguration_AlexaSkillIds")]
        public System.String[] SipMediaApplicationAlexaSkillConfiguration_AlexaSkillId { get; set; }
        #endregion
        
        #region Parameter SipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus
        /// <summary>
        /// <para>
        /// <para>The status of the Alexa Skill configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.AlexaSkillStatus")]
        public Amazon.ChimeSDKVoice.AlexaSkillStatus SipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus { get; set; }
        #endregion
        
        #region Parameter SipMediaApplicationId
        /// <summary>
        /// <para>
        /// <para>The SIP media application ID.</para>
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
        public System.String SipMediaApplicationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SipMediaApplicationAlexaSkillConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SipMediaApplicationAlexaSkillConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SipMediaApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SipMediaApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SipMediaApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SipMediaApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVOSipMediaApplicationAlexaSkillConfiguration (PutSipMediaApplicationAlexaSkillConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationResponse, WriteCHMVOSipMediaApplicationAlexaSkillConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SipMediaApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.SipMediaApplicationAlexaSkillConfiguration_AlexaSkillId != null)
            {
                context.SipMediaApplicationAlexaSkillConfiguration_AlexaSkillId = new List<System.String>(this.SipMediaApplicationAlexaSkillConfiguration_AlexaSkillId);
            }
            context.SipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus = this.SipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus;
            context.SipMediaApplicationId = this.SipMediaApplicationId;
            #if MODULAR
            if (this.SipMediaApplicationId == null && ParameterWasBound(nameof(this.SipMediaApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter SipMediaApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationRequest();
            
            
             // populate SipMediaApplicationAlexaSkillConfiguration
            var requestSipMediaApplicationAlexaSkillConfigurationIsNull = true;
            request.SipMediaApplicationAlexaSkillConfiguration = new Amazon.ChimeSDKVoice.Model.SipMediaApplicationAlexaSkillConfiguration();
            List<System.String> requestSipMediaApplicationAlexaSkillConfiguration_sipMediaApplicationAlexaSkillConfiguration_AlexaSkillId = null;
            if (cmdletContext.SipMediaApplicationAlexaSkillConfiguration_AlexaSkillId != null)
            {
                requestSipMediaApplicationAlexaSkillConfiguration_sipMediaApplicationAlexaSkillConfiguration_AlexaSkillId = cmdletContext.SipMediaApplicationAlexaSkillConfiguration_AlexaSkillId;
            }
            if (requestSipMediaApplicationAlexaSkillConfiguration_sipMediaApplicationAlexaSkillConfiguration_AlexaSkillId != null)
            {
                request.SipMediaApplicationAlexaSkillConfiguration.AlexaSkillIds = requestSipMediaApplicationAlexaSkillConfiguration_sipMediaApplicationAlexaSkillConfiguration_AlexaSkillId;
                requestSipMediaApplicationAlexaSkillConfigurationIsNull = false;
            }
            Amazon.ChimeSDKVoice.AlexaSkillStatus requestSipMediaApplicationAlexaSkillConfiguration_sipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus = null;
            if (cmdletContext.SipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus != null)
            {
                requestSipMediaApplicationAlexaSkillConfiguration_sipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus = cmdletContext.SipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus;
            }
            if (requestSipMediaApplicationAlexaSkillConfiguration_sipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus != null)
            {
                request.SipMediaApplicationAlexaSkillConfiguration.AlexaSkillStatus = requestSipMediaApplicationAlexaSkillConfiguration_sipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus;
                requestSipMediaApplicationAlexaSkillConfigurationIsNull = false;
            }
             // determine if request.SipMediaApplicationAlexaSkillConfiguration should be set to null
            if (requestSipMediaApplicationAlexaSkillConfigurationIsNull)
            {
                request.SipMediaApplicationAlexaSkillConfiguration = null;
            }
            if (cmdletContext.SipMediaApplicationId != null)
            {
                request.SipMediaApplicationId = cmdletContext.SipMediaApplicationId;
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
        
        private Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "PutSipMediaApplicationAlexaSkillConfiguration");
            try
            {
                #if DESKTOP
                return client.PutSipMediaApplicationAlexaSkillConfiguration(request);
                #elif CORECLR
                return client.PutSipMediaApplicationAlexaSkillConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SipMediaApplicationAlexaSkillConfiguration_AlexaSkillId { get; set; }
            public Amazon.ChimeSDKVoice.AlexaSkillStatus SipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus { get; set; }
            public System.String SipMediaApplicationId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.PutSipMediaApplicationAlexaSkillConfigurationResponse, WriteCHMVOSipMediaApplicationAlexaSkillConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SipMediaApplicationAlexaSkillConfiguration;
        }
        
    }
}
