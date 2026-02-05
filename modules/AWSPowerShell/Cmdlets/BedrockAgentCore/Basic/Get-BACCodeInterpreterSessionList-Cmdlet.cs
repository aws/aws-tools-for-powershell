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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Retrieves a list of code interpreter sessions in Amazon Bedrock AgentCore that match
    /// the specified criteria. This operation returns summary information about each session,
    /// including identifiers, status, and timestamps.
    /// 
    ///  
    /// <para>
    /// You can filter the results by code interpreter identifier and session status. The
    /// operation supports pagination to handle large result sets efficiently.
    /// </para><para>
    /// We recommend using pagination to ensure that the operation returns quickly and successfully
    /// when retrieving large numbers of sessions.
    /// </para><para>
    /// The following operations are related to <c>ListCodeInterpreterSessions</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_StartCodeInterpreterSession.html">StartCodeInterpreterSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_GetCodeInterpreterSession.html">GetCodeInterpreterSession</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "BACCodeInterpreterSessionList")]
    [OutputType("Amazon.BedrockAgentCore.Model.CodeInterpreterSessionSummary")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer ListCodeInterpreterSessions API operation.", Operation = new[] {"ListCodeInterpreterSessions"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.CodeInterpreterSessionSummary or Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsResponse",
        "This cmdlet returns a collection of Amazon.BedrockAgentCore.Model.CodeInterpreterSessionSummary objects.",
        "The service call response (type Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBACCodeInterpreterSessionListCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CodeInterpreterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the code interpreter to list sessions for. If specified,
        /// only sessions for this code interpreter are returned. If not specified, sessions for
        /// all code interpreters are returned.</para>
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
        public System.String CodeInterpreterIdentifier { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the code interpreter sessions to list. Valid values include ACTIVE,
        /// STOPPING, and STOPPED. If not specified, sessions with any status are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.CodeInterpreterSessionStatus")]
        public Amazon.BedrockAgentCore.CodeInterpreterSessionStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. The default value is 10.
        /// Valid values range from 1 to 100. To retrieve the remaining results, make another
        /// call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results. If not specified, Amazon
        /// Bedrock AgentCore returns the first page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsResponse, GetBACCodeInterpreterSessionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CodeInterpreterIdentifier = this.CodeInterpreterIdentifier;
            #if MODULAR
            if (this.CodeInterpreterIdentifier == null && ParameterWasBound(nameof(this.CodeInterpreterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CodeInterpreterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Status = this.Status;
            
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
            var request = new Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsRequest();
            
            if (cmdletContext.CodeInterpreterIdentifier != null)
            {
                request.CodeInterpreterIdentifier = cmdletContext.CodeInterpreterIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "ListCodeInterpreterSessions");
            try
            {
                return client.ListCodeInterpreterSessionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CodeInterpreterIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.BedrockAgentCore.CodeInterpreterSessionStatus Status { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.ListCodeInterpreterSessionsResponse, GetBACCodeInterpreterSessionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
