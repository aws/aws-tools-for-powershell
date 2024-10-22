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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Retrieves the details of a voice tone analysis task.
    /// </summary>
    [Cmdlet("Get", "CHMVOVoiceToneAnalysisTask")]
    [OutputType("Amazon.ChimeSDKVoice.Model.VoiceToneAnalysisTask")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice GetVoiceToneAnalysisTask API operation.", Operation = new[] {"GetVoiceToneAnalysisTask"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.VoiceToneAnalysisTask or Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.VoiceToneAnalysisTask object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCHMVOVoiceToneAnalysisTaskCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IsCaller
        /// <summary>
        /// <para>
        /// <para>Specifies whether the voice being analyzed is the caller (originator) or the callee
        /// (responder).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? IsCaller { get; set; }
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
        
        #region Parameter VoiceToneAnalysisTaskId
        /// <summary>
        /// <para>
        /// <para>The ID of the voice tone analysis task.</para>
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
        public System.String VoiceToneAnalysisTaskId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VoiceToneAnalysisTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VoiceToneAnalysisTask";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskResponse, GetCHMVOVoiceToneAnalysisTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IsCaller = this.IsCaller;
            #if MODULAR
            if (this.IsCaller == null && ParameterWasBound(nameof(this.IsCaller)))
            {
                WriteWarning("You are passing $null as a value for parameter IsCaller which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VoiceConnectorId = this.VoiceConnectorId;
            #if MODULAR
            if (this.VoiceConnectorId == null && ParameterWasBound(nameof(this.VoiceConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VoiceToneAnalysisTaskId = this.VoiceToneAnalysisTaskId;
            #if MODULAR
            if (this.VoiceToneAnalysisTaskId == null && ParameterWasBound(nameof(this.VoiceToneAnalysisTaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceToneAnalysisTaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskRequest();
            
            if (cmdletContext.IsCaller != null)
            {
                request.IsCaller = cmdletContext.IsCaller.Value;
            }
            if (cmdletContext.VoiceConnectorId != null)
            {
                request.VoiceConnectorId = cmdletContext.VoiceConnectorId;
            }
            if (cmdletContext.VoiceToneAnalysisTaskId != null)
            {
                request.VoiceToneAnalysisTaskId = cmdletContext.VoiceToneAnalysisTaskId;
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
        
        private Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "GetVoiceToneAnalysisTask");
            try
            {
                #if DESKTOP
                return client.GetVoiceToneAnalysisTask(request);
                #elif CORECLR
                return client.GetVoiceToneAnalysisTaskAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IsCaller { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.String VoiceToneAnalysisTaskId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.GetVoiceToneAnalysisTaskResponse, GetCHMVOVoiceToneAnalysisTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VoiceToneAnalysisTask;
        }
        
    }
}
