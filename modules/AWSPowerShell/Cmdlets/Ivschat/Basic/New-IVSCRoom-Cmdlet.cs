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
using Amazon.Ivschat;
using Amazon.Ivschat.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IVSC
{
    /// <summary>
    /// Creates a room that allows clients to connect and pass messages.
    /// </summary>
    [Cmdlet("New", "IVSCRoom", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Ivschat.Model.CreateRoomResponse")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service Chat CreateRoom API operation.", Operation = new[] {"CreateRoom"}, SelectReturnType = typeof(Amazon.Ivschat.Model.CreateRoomResponse))]
    [AWSCmdletOutput("Amazon.Ivschat.Model.CreateRoomResponse",
        "This cmdlet returns an Amazon.Ivschat.Model.CreateRoomResponse object containing multiple properties."
    )]
    public partial class NewIVSCRoomCmdlet : AmazonIvschatClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MessageReviewHandler_FallbackResult
        /// <summary>
        /// <para>
        /// <para>Specifies the fallback behavior (whether the message is allowed or denied) if the
        /// handler does not return a valid response, encounters an error, or times out. (For
        /// the timeout period, see <a href="https://docs.aws.amazon.com/ivs/latest/userguide/service-quotas.html">
        /// Service Quotas</a>.) If allowed, the message is delivered with returned content to
        /// all users connected to the room. If denied, the message is not delivered to any user.
        /// Default: <c>ALLOW</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Ivschat.FallbackResult")]
        public Amazon.Ivschat.FallbackResult MessageReviewHandler_FallbackResult { get; set; }
        #endregion
        
        #region Parameter LoggingConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>Array of logging-configuration identifiers attached to the room.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfigurationIdentifiers")]
        public System.String[] LoggingConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter MaximumMessageLength
        /// <summary>
        /// <para>
        /// <para>Maximum number of characters in a single message. Messages are expected to be UTF-8
        /// encoded and this limit applies specifically to rune/code-point count, not number of
        /// bytes. Default: 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaximumMessageLength { get; set; }
        #endregion
        
        #region Parameter MaximumMessageRatePerSecond
        /// <summary>
        /// <para>
        /// <para>Maximum number of messages per second that can be sent to the room (by all clients).
        /// Default: 10. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaximumMessageRatePerSecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Room name. The value does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to attach to the resource. Array of maps, each of the form <c>string:string (key:value)</c>.
        /// See <a href="https://docs.aws.amazon.com/tag-editor/latest/userguide/best-practices-and-strats.html">Best
        /// practices and strategies</a> in <i>Tagging Amazon Web Services Resources and Tag Editor</i>
        /// for details, including restrictions that apply to tags and "Tag naming limits and
        /// requirements"; Amazon IVS Chat has no constraints beyond what is documented there.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter MessageReviewHandler_Uri
        /// <summary>
        /// <para>
        /// <para>Identifier of the message review handler. Currently this must be an ARN of a lambda
        /// function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageReviewHandler_Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Ivschat.Model.CreateRoomResponse).
        /// Specifying the name of a property of type Amazon.Ivschat.Model.CreateRoomResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IVSCRoom (CreateRoom)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Ivschat.Model.CreateRoomResponse, NewIVSCRoomCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.LoggingConfigurationIdentifier != null)
            {
                context.LoggingConfigurationIdentifier = new List<System.String>(this.LoggingConfigurationIdentifier);
            }
            context.MaximumMessageLength = this.MaximumMessageLength;
            context.MaximumMessageRatePerSecond = this.MaximumMessageRatePerSecond;
            context.MessageReviewHandler_FallbackResult = this.MessageReviewHandler_FallbackResult;
            context.MessageReviewHandler_Uri = this.MessageReviewHandler_Uri;
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Ivschat.Model.CreateRoomRequest();
            
            if (cmdletContext.LoggingConfigurationIdentifier != null)
            {
                request.LoggingConfigurationIdentifiers = cmdletContext.LoggingConfigurationIdentifier;
            }
            if (cmdletContext.MaximumMessageLength != null)
            {
                request.MaximumMessageLength = cmdletContext.MaximumMessageLength.Value;
            }
            if (cmdletContext.MaximumMessageRatePerSecond != null)
            {
                request.MaximumMessageRatePerSecond = cmdletContext.MaximumMessageRatePerSecond.Value;
            }
            
             // populate MessageReviewHandler
            var requestMessageReviewHandlerIsNull = true;
            request.MessageReviewHandler = new Amazon.Ivschat.Model.MessageReviewHandler();
            Amazon.Ivschat.FallbackResult requestMessageReviewHandler_messageReviewHandler_FallbackResult = null;
            if (cmdletContext.MessageReviewHandler_FallbackResult != null)
            {
                requestMessageReviewHandler_messageReviewHandler_FallbackResult = cmdletContext.MessageReviewHandler_FallbackResult;
            }
            if (requestMessageReviewHandler_messageReviewHandler_FallbackResult != null)
            {
                request.MessageReviewHandler.FallbackResult = requestMessageReviewHandler_messageReviewHandler_FallbackResult;
                requestMessageReviewHandlerIsNull = false;
            }
            System.String requestMessageReviewHandler_messageReviewHandler_Uri = null;
            if (cmdletContext.MessageReviewHandler_Uri != null)
            {
                requestMessageReviewHandler_messageReviewHandler_Uri = cmdletContext.MessageReviewHandler_Uri;
            }
            if (requestMessageReviewHandler_messageReviewHandler_Uri != null)
            {
                request.MessageReviewHandler.Uri = requestMessageReviewHandler_messageReviewHandler_Uri;
                requestMessageReviewHandlerIsNull = false;
            }
             // determine if request.MessageReviewHandler should be set to null
            if (requestMessageReviewHandlerIsNull)
            {
                request.MessageReviewHandler = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Ivschat.Model.CreateRoomResponse CallAWSServiceOperation(IAmazonIvschat client, Amazon.Ivschat.Model.CreateRoomRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service Chat", "CreateRoom");
            try
            {
                return client.CreateRoomAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> LoggingConfigurationIdentifier { get; set; }
            public System.Int32? MaximumMessageLength { get; set; }
            public System.Int32? MaximumMessageRatePerSecond { get; set; }
            public Amazon.Ivschat.FallbackResult MessageReviewHandler_FallbackResult { get; set; }
            public System.String MessageReviewHandler_Uri { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Ivschat.Model.CreateRoomResponse, NewIVSCRoomCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
