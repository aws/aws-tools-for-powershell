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
using Amazon.ConnectParticipant;
using Amazon.ConnectParticipant.Model;

namespace Amazon.PowerShell.Cmdlets.CONNP
{
    /// <summary>
    /// <note><para>
    /// The <c>application/vnd.amazonaws.connect.event.connection.acknowledged</c> ContentType
    /// is no longer maintained since December 31, 2024. This event has been migrated to the
    /// <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_CreateParticipantConnection.html">CreateParticipantConnection</a>
    /// API using the <c>ConnectParticipant</c> field.
    /// </para></note><para>
    /// Sends an event. Message receipts are not supported when there are more than two active
    /// participants in the chat. Using the SendEvent API for message receipts when a supervisor
    /// is barged-in will result in a conflict exception.
    /// </para><para>
    /// For security recommendations, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/security-best-practices.html#bp-security-chat">Amazon
    /// Connect Chat security best practices</a>. 
    /// </para><note><para><c>ConnectionToken</c> is used for invoking this API instead of <c>ParticipantToken</c>.
    /// </para></note><para>
    /// The Amazon Connect Participant Service APIs do not use <a href="https://docs.aws.amazon.com/general/latest/gr/signature-version-4.html">Signature
    /// Version 4 authentication</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "CONNPEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectParticipant.Model.SendEventResponse")]
    [AWSCmdlet("Calls the Amazon Connect Participant Service SendEvent API operation.", Operation = new[] {"SendEvent"}, SelectReturnType = typeof(Amazon.ConnectParticipant.Model.SendEventResponse))]
    [AWSCmdletOutput("Amazon.ConnectParticipant.Model.SendEventResponse",
        "This cmdlet returns an Amazon.ConnectParticipant.Model.SendEventResponse object containing multiple properties."
    )]
    public partial class SendCONNPEventCmdlet : AmazonConnectParticipantClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectionToken
        /// <summary>
        /// <para>
        /// <para>The authentication token associated with the participant's connection.</para>
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
        public System.String ConnectionToken { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The content of the event to be sent (for example, message text). For content related
        /// to message receipts, this is supported in the form of a JSON string.</para><para>Sample Content: "{\"messageId\":\"11111111-aaaa-bbbb-cccc-EXAMPLE01234\"}"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The content type of the request. Supported types are:</para><ul><li><para>application/vnd.amazonaws.connect.event.typing</para></li><li><para>application/vnd.amazonaws.connect.event.connection.acknowledged (is no longer maintained
        /// since December 31, 2024) </para></li><li><para>application/vnd.amazonaws.connect.event.message.delivered</para></li><li><para>application/vnd.amazonaws.connect.event.message.read</para></li></ul>
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
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectParticipant.Model.SendEventResponse).
        /// Specifying the name of a property of type Amazon.ConnectParticipant.Model.SendEventResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectionToken parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectionToken' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectionToken' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CONNPEvent (SendEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectParticipant.Model.SendEventResponse, SendCONNPEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectionToken;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ConnectionToken = this.ConnectionToken;
            #if MODULAR
            if (this.ConnectionToken == null && ParameterWasBound(nameof(this.ConnectionToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Content = this.Content;
            context.ContentType = this.ContentType;
            #if MODULAR
            if (this.ContentType == null && ParameterWasBound(nameof(this.ContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectParticipant.Model.SendEventRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectionToken != null)
            {
                request.ConnectionToken = cmdletContext.ConnectionToken;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
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
        
        private Amazon.ConnectParticipant.Model.SendEventResponse CallAWSServiceOperation(IAmazonConnectParticipant client, Amazon.ConnectParticipant.Model.SendEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Participant Service", "SendEvent");
            try
            {
                #if DESKTOP
                return client.SendEvent(request);
                #elif CORECLR
                return client.SendEventAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectionToken { get; set; }
            public System.String Content { get; set; }
            public System.String ContentType { get; set; }
            public System.Func<Amazon.ConnectParticipant.Model.SendEventResponse, SendCONNPEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
