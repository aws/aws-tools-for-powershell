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
using Amazon.ConnectParticipant;
using Amazon.ConnectParticipant.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONNP
{
    /// <summary>
    /// Retrieves a transcript of the session, including details about any attachments. For
    /// information about accessing past chat contact transcripts for a persistent chat, see
    /// <a href="https://docs.aws.amazon.com/connect/latest/adminguide/chat-persistence.html">Enable
    /// persistent chat</a>. 
    /// 
    ///  
    /// <para>
    /// For security recommendations, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/security-best-practices.html#bp-security-chat">Amazon
    /// Connect Chat security best practices</a>. 
    /// </para><para>
    /// If you have a process that consumes events in the transcript of an chat that has ended,
    /// note that chat transcripts contain the following event content types if the event
    /// has occurred during the chat session:
    /// </para><ul><li><para><c>application/vnd.amazonaws.connect.event.participant.invited</c></para></li><li><para><c>application/vnd.amazonaws.connect.event.participant.joined</c></para></li><li><para><c>application/vnd.amazonaws.connect.event.participant.left</c></para></li><li><para><c>application/vnd.amazonaws.connect.event.chat.ended</c></para></li><li><para><c>application/vnd.amazonaws.connect.event.transfer.succeeded</c></para></li><li><para><c>application/vnd.amazonaws.connect.event.transfer.failed</c></para></li></ul><note><para><c>ConnectionToken</c> is used for invoking this API instead of <c>ParticipantToken</c>.
    /// </para></note><para>
    /// The Amazon Connect Participant Service APIs do not use <a href="https://docs.aws.amazon.com/general/latest/gr/signature-version-4.html">Signature
    /// Version 4 authentication</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CONNPTranscript")]
    [OutputType("Amazon.ConnectParticipant.Model.GetTranscriptResponse")]
    [AWSCmdlet("Calls the Amazon Connect Participant Service GetTranscript API operation.", Operation = new[] {"GetTranscript"}, SelectReturnType = typeof(Amazon.ConnectParticipant.Model.GetTranscriptResponse))]
    [AWSCmdletOutput("Amazon.ConnectParticipant.Model.GetTranscriptResponse",
        "This cmdlet returns an Amazon.ConnectParticipant.Model.GetTranscriptResponse object containing multiple properties."
    )]
    public partial class GetCONNPTranscriptCmdlet : AmazonConnectParticipantClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter StartPosition_AbsoluteTime
        /// <summary>
        /// <para>
        /// <para>The time in ISO format where to start.</para><para>It's specified in ISO 8601 format: yyyy-MM-ddThh:mm:ss.SSSZ. For example, 2019-11-08T02:41:28.172Z.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartPosition_AbsoluteTime { get; set; }
        #endregion
        
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
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The contactId from the current contact chain for which transcript is needed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactId { get; set; }
        #endregion
        
        #region Parameter StartPosition_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the message or event where to start. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartPosition_Id { get; set; }
        #endregion
        
        #region Parameter StartPosition_MostRecent
        /// <summary>
        /// <para>
        /// <para>The start position of the most recent message where you want to start. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StartPosition_MostRecent { get; set; }
        #endregion
        
        #region Parameter ScanDirection
        /// <summary>
        /// <para>
        /// <para>The direction from StartPosition from which to retrieve message. Default: BACKWARD
        /// when no StartPosition is provided, FORWARD with StartPosition. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectParticipant.ScanDirection")]
        public Amazon.ConnectParticipant.ScanDirection ScanDirection { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order for the records. Default: DESCENDING.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectParticipant.SortKey")]
        public Amazon.ConnectParticipant.SortKey SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in the page. Default: 10. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token. Use the value returned previously in the next subsequent request
        /// to retrieve the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectParticipant.Model.GetTranscriptResponse).
        /// Specifying the name of a property of type Amazon.ConnectParticipant.Model.GetTranscriptResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectParticipant.Model.GetTranscriptResponse, GetCONNPTranscriptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionToken = this.ConnectionToken;
            #if MODULAR
            if (this.ConnectionToken == null && ParameterWasBound(nameof(this.ConnectionToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactId = this.ContactId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ScanDirection = this.ScanDirection;
            context.SortOrder = this.SortOrder;
            context.StartPosition_AbsoluteTime = this.StartPosition_AbsoluteTime;
            context.StartPosition_Id = this.StartPosition_Id;
            context.StartPosition_MostRecent = this.StartPosition_MostRecent;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ConnectParticipant.Model.GetTranscriptRequest();
            
            if (cmdletContext.ConnectionToken != null)
            {
                request.ConnectionToken = cmdletContext.ConnectionToken;
            }
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ScanDirection != null)
            {
                request.ScanDirection = cmdletContext.ScanDirection;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
             // populate StartPosition
            var requestStartPositionIsNull = true;
            request.StartPosition = new Amazon.ConnectParticipant.Model.StartPosition();
            System.String requestStartPosition_startPosition_AbsoluteTime = null;
            if (cmdletContext.StartPosition_AbsoluteTime != null)
            {
                requestStartPosition_startPosition_AbsoluteTime = cmdletContext.StartPosition_AbsoluteTime;
            }
            if (requestStartPosition_startPosition_AbsoluteTime != null)
            {
                request.StartPosition.AbsoluteTime = requestStartPosition_startPosition_AbsoluteTime;
                requestStartPositionIsNull = false;
            }
            System.String requestStartPosition_startPosition_Id = null;
            if (cmdletContext.StartPosition_Id != null)
            {
                requestStartPosition_startPosition_Id = cmdletContext.StartPosition_Id;
            }
            if (requestStartPosition_startPosition_Id != null)
            {
                request.StartPosition.Id = requestStartPosition_startPosition_Id;
                requestStartPositionIsNull = false;
            }
            System.Int32? requestStartPosition_startPosition_MostRecent = null;
            if (cmdletContext.StartPosition_MostRecent != null)
            {
                requestStartPosition_startPosition_MostRecent = cmdletContext.StartPosition_MostRecent.Value;
            }
            if (requestStartPosition_startPosition_MostRecent != null)
            {
                request.StartPosition.MostRecent = requestStartPosition_startPosition_MostRecent.Value;
                requestStartPositionIsNull = false;
            }
             // determine if request.StartPosition should be set to null
            if (requestStartPositionIsNull)
            {
                request.StartPosition = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ConnectParticipant.Model.GetTranscriptResponse CallAWSServiceOperation(IAmazonConnectParticipant client, Amazon.ConnectParticipant.Model.GetTranscriptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Participant Service", "GetTranscript");
            try
            {
                return client.GetTranscriptAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectionToken { get; set; }
            public System.String ContactId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ConnectParticipant.ScanDirection ScanDirection { get; set; }
            public Amazon.ConnectParticipant.SortKey SortOrder { get; set; }
            public System.String StartPosition_AbsoluteTime { get; set; }
            public System.String StartPosition_Id { get; set; }
            public System.Int32? StartPosition_MostRecent { get; set; }
            public System.Func<Amazon.ConnectParticipant.Model.GetTranscriptResponse, GetCONNPTranscriptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
