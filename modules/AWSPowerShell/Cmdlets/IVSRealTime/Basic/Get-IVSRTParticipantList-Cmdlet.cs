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
using Amazon.IVSRealTime;
using Amazon.IVSRealTime.Model;

namespace Amazon.PowerShell.Cmdlets.IVSRT
{
    /// <summary>
    /// Lists all participants in a specified stage session.
    /// </summary>
    [Cmdlet("Get", "IVSRTParticipantList")]
    [OutputType("Amazon.IVSRealTime.Model.ParticipantSummary")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service RealTime ListParticipants API operation.", Operation = new[] {"ListParticipants"}, SelectReturnType = typeof(Amazon.IVSRealTime.Model.ListParticipantsResponse))]
    [AWSCmdletOutput("Amazon.IVSRealTime.Model.ParticipantSummary or Amazon.IVSRealTime.Model.ListParticipantsResponse",
        "This cmdlet returns a collection of Amazon.IVSRealTime.Model.ParticipantSummary objects.",
        "The service call response (type Amazon.IVSRealTime.Model.ListParticipantsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIVSRTParticipantListCmdlet : AmazonIVSRealTimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterByPublished
        /// <summary>
        /// <para>
        /// <para>Filters the response list to only show participants who published during the stage
        /// session. Only one of <c>filterByUserId</c>, <c>filterByPublished</c>, <c>filterByState</c>,
        /// or <c>filterByRecordingState</c> can be provided per request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FilterByPublished { get; set; }
        #endregion
        
        #region Parameter FilterByRecordingState
        /// <summary>
        /// <para>
        /// <para>Filters the response list to only show participants with the specified recording state.
        /// Only one of <c>filterByUserId</c>, <c>filterByPublished</c>, <c>filterByState</c>,
        /// or <c>filterByRecordingState</c> can be provided per request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVSRealTime.ParticipantRecordingFilterByRecordingState")]
        public Amazon.IVSRealTime.ParticipantRecordingFilterByRecordingState FilterByRecordingState { get; set; }
        #endregion
        
        #region Parameter FilterByState
        /// <summary>
        /// <para>
        /// <para>Filters the response list to only show participants in the specified state. Only one
        /// of <c>filterByUserId</c>, <c>filterByPublished</c>, <c>filterByState</c>, or <c>filterByRecordingState</c>
        /// can be provided per request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVSRealTime.ParticipantState")]
        public Amazon.IVSRealTime.ParticipantState FilterByState { get; set; }
        #endregion
        
        #region Parameter FilterByUserId
        /// <summary>
        /// <para>
        /// <para>Filters the response list to match the specified user ID. Only one of <c>filterByUserId</c>,
        /// <c>filterByPublished</c>, <c>filterByState</c>, or <c>filterByRecordingState</c> can
        /// be provided per request. A <c>userId</c> is a customer-assigned name to help identify
        /// the token; this can be used to link a participant to a user in the customer’s own
        /// systems.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterByUserId { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>ID of the session within the stage.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter StageArn
        /// <summary>
        /// <para>
        /// <para>Stage ARN.</para>
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
        public System.String StageArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return. Default: 50.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The first participant to retrieve. This is used for pagination; see the <c>nextToken</c>
        /// response field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Participants'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVSRealTime.Model.ListParticipantsResponse).
        /// Specifying the name of a property of type Amazon.IVSRealTime.Model.ListParticipantsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Participants";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVSRealTime.Model.ListParticipantsResponse, GetIVSRTParticipantListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FilterByPublished = this.FilterByPublished;
            context.FilterByRecordingState = this.FilterByRecordingState;
            context.FilterByState = this.FilterByState;
            context.FilterByUserId = this.FilterByUserId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StageArn = this.StageArn;
            #if MODULAR
            if (this.StageArn == null && ParameterWasBound(nameof(this.StageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IVSRealTime.Model.ListParticipantsRequest();
            
            if (cmdletContext.FilterByPublished != null)
            {
                request.FilterByPublished = cmdletContext.FilterByPublished.Value;
            }
            if (cmdletContext.FilterByRecordingState != null)
            {
                request.FilterByRecordingState = cmdletContext.FilterByRecordingState;
            }
            if (cmdletContext.FilterByState != null)
            {
                request.FilterByState = cmdletContext.FilterByState;
            }
            if (cmdletContext.FilterByUserId != null)
            {
                request.FilterByUserId = cmdletContext.FilterByUserId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.StageArn != null)
            {
                request.StageArn = cmdletContext.StageArn;
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
        
        private Amazon.IVSRealTime.Model.ListParticipantsResponse CallAWSServiceOperation(IAmazonIVSRealTime client, Amazon.IVSRealTime.Model.ListParticipantsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service RealTime", "ListParticipants");
            try
            {
                return client.ListParticipantsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? FilterByPublished { get; set; }
            public Amazon.IVSRealTime.ParticipantRecordingFilterByRecordingState FilterByRecordingState { get; set; }
            public Amazon.IVSRealTime.ParticipantState FilterByState { get; set; }
            public System.String FilterByUserId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SessionId { get; set; }
            public System.String StageArn { get; set; }
            public System.Func<Amazon.IVSRealTime.Model.ListParticipantsResponse, GetIVSRTParticipantListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Participants;
        }
        
    }
}
