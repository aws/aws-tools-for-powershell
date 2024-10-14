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
using Amazon.NimbleStudio;
using Amazon.NimbleStudio.Model;

namespace Amazon.PowerShell.Cmdlets.NS
{
    /// <summary>
    /// Transitions sessions from the <c>READY</c> state into the <c>STOPPED</c> state. The
    /// <c>STOP_IN_PROGRESS</c> state is the intermediate state between the <c>READY</c> and
    /// <c>STOPPED</c> states.
    /// </summary>
    [Cmdlet("Stop", "NSStreamingSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NimbleStudio.Model.StreamingSession")]
    [AWSCmdlet("Calls the Amazon Nimble Studio StopStreamingSession API operation.", Operation = new[] {"StopStreamingSession"}, SelectReturnType = typeof(Amazon.NimbleStudio.Model.StopStreamingSessionResponse))]
    [AWSCmdletOutput("Amazon.NimbleStudio.Model.StreamingSession or Amazon.NimbleStudio.Model.StopStreamingSessionResponse",
        "This cmdlet returns an Amazon.NimbleStudio.Model.StreamingSession object.",
        "The service call response (type Amazon.NimbleStudio.Model.StopStreamingSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopNSStreamingSessionCmdlet : AmazonNimbleStudioClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The streaming session ID for the <c>StopStreamingSessionRequest</c>.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter StudioId
        /// <summary>
        /// <para>
        /// <para>The studioId for the StopStreamingSessionRequest.</para>
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
        public System.String StudioId { get; set; }
        #endregion
        
        #region Parameter VolumeRetentionMode
        /// <summary>
        /// <para>
        /// <para>Adds additional instructions to a streaming session stop action to either retain the
        /// EBS volumes or delete the EBS volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NimbleStudio.VolumeRetentionMode")]
        public Amazon.NimbleStudio.VolumeRetentionMode VolumeRetentionMode { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. If you don’t specify a client token, the Amazon Web Services SDK automatically
        /// generates a client token and uses it for the request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Session'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NimbleStudio.Model.StopStreamingSessionResponse).
        /// Specifying the name of a property of type Amazon.NimbleStudio.Model.StopStreamingSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Session";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SessionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SessionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SessionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-NSStreamingSession (StopStreamingSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NimbleStudio.Model.StopStreamingSessionResponse, StopNSStreamingSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SessionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StudioId = this.StudioId;
            #if MODULAR
            if (this.StudioId == null && ParameterWasBound(nameof(this.StudioId)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VolumeRetentionMode = this.VolumeRetentionMode;
            
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
            var request = new Amazon.NimbleStudio.Model.StopStreamingSessionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.StudioId != null)
            {
                request.StudioId = cmdletContext.StudioId;
            }
            if (cmdletContext.VolumeRetentionMode != null)
            {
                request.VolumeRetentionMode = cmdletContext.VolumeRetentionMode;
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
        
        private Amazon.NimbleStudio.Model.StopStreamingSessionResponse CallAWSServiceOperation(IAmazonNimbleStudio client, Amazon.NimbleStudio.Model.StopStreamingSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nimble Studio", "StopStreamingSession");
            try
            {
                #if DESKTOP
                return client.StopStreamingSession(request);
                #elif CORECLR
                return client.StopStreamingSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String SessionId { get; set; }
            public System.String StudioId { get; set; }
            public Amazon.NimbleStudio.VolumeRetentionMode VolumeRetentionMode { get; set; }
            public System.Func<Amazon.NimbleStudio.Model.StopStreamingSessionResponse, StopNSStreamingSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Session;
        }
        
    }
}
