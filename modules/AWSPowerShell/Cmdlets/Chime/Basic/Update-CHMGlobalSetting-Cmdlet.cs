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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Updates global settings for the administrator's AWS account, such as Amazon Chime
    /// Business Calling and Amazon Chime Voice Connector settings.
    /// </summary>
    [Cmdlet("Update", "CHMGlobalSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Chime UpdateGlobalSettings API operation.", Operation = new[] {"UpdateGlobalSettings"}, SelectReturnType = typeof(Amazon.Chime.Model.UpdateGlobalSettingsResponse))]
    [AWSCmdletOutput("None or Amazon.Chime.Model.UpdateGlobalSettingsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Chime.Model.UpdateGlobalSettingsResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHMGlobalSettingCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BusinessCalling_CdrBucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket designated for call detail record storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BusinessCalling_CdrBucket { get; set; }
        #endregion
        
        #region Parameter VoiceConnector_CdrBucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket designated for call detail record storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VoiceConnector_CdrBucket { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.UpdateGlobalSettingsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMGlobalSetting (UpdateGlobalSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.UpdateGlobalSettingsResponse, UpdateCHMGlobalSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BusinessCalling_CdrBucket = this.BusinessCalling_CdrBucket;
            context.VoiceConnector_CdrBucket = this.VoiceConnector_CdrBucket;
            
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
            var request = new Amazon.Chime.Model.UpdateGlobalSettingsRequest();
            
            
             // populate BusinessCalling
            var requestBusinessCallingIsNull = true;
            request.BusinessCalling = new Amazon.Chime.Model.BusinessCallingSettings();
            System.String requestBusinessCalling_businessCalling_CdrBucket = null;
            if (cmdletContext.BusinessCalling_CdrBucket != null)
            {
                requestBusinessCalling_businessCalling_CdrBucket = cmdletContext.BusinessCalling_CdrBucket;
            }
            if (requestBusinessCalling_businessCalling_CdrBucket != null)
            {
                request.BusinessCalling.CdrBucket = requestBusinessCalling_businessCalling_CdrBucket;
                requestBusinessCallingIsNull = false;
            }
             // determine if request.BusinessCalling should be set to null
            if (requestBusinessCallingIsNull)
            {
                request.BusinessCalling = null;
            }
            
             // populate VoiceConnector
            var requestVoiceConnectorIsNull = true;
            request.VoiceConnector = new Amazon.Chime.Model.VoiceConnectorSettings();
            System.String requestVoiceConnector_voiceConnector_CdrBucket = null;
            if (cmdletContext.VoiceConnector_CdrBucket != null)
            {
                requestVoiceConnector_voiceConnector_CdrBucket = cmdletContext.VoiceConnector_CdrBucket;
            }
            if (requestVoiceConnector_voiceConnector_CdrBucket != null)
            {
                request.VoiceConnector.CdrBucket = requestVoiceConnector_voiceConnector_CdrBucket;
                requestVoiceConnectorIsNull = false;
            }
             // determine if request.VoiceConnector should be set to null
            if (requestVoiceConnectorIsNull)
            {
                request.VoiceConnector = null;
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
        
        private Amazon.Chime.Model.UpdateGlobalSettingsResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.UpdateGlobalSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "UpdateGlobalSettings");
            try
            {
                return client.UpdateGlobalSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BusinessCalling_CdrBucket { get; set; }
            public System.String VoiceConnector_CdrBucket { get; set; }
            public System.Func<Amazon.Chime.Model.UpdateGlobalSettingsResponse, UpdateCHMGlobalSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
