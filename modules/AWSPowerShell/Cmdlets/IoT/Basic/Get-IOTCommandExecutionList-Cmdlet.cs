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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// List all command executions.
    /// 
    ///  <important><ul><li><para>
    /// You must provide only the <c>startedTimeFilter</c> or the <c>completedTimeFilter</c>
    /// information. If you provide both time filters, the API will generate an error. You
    /// can use this information to retrieve a list of command executions within a specific
    /// timeframe.
    /// </para></li><li><para>
    /// You must provide only the <c>commandArn</c> or the <c>thingArn</c> information depending
    /// on whether you want to list executions for a specific command or an IoT thing. If
    /// you provide both fields, the API will generate an error.
    /// </para></li></ul><para>
    /// For more information about considerations for using this API, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-remote-command-execution-start-monitor.html#iot-remote-command-execution-list-cli">List
    /// command executions in your account (CLI)</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "IOTCommandExecutionList")]
    [OutputType("Amazon.IoT.Model.CommandExecutionSummary")]
    [AWSCmdlet("Calls the AWS IoT ListCommandExecutions API operation.", Operation = new[] {"ListCommandExecutions"}, SelectReturnType = typeof(Amazon.IoT.Model.ListCommandExecutionsResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CommandExecutionSummary or Amazon.IoT.Model.ListCommandExecutionsResponse",
        "This cmdlet returns a collection of Amazon.IoT.Model.CommandExecutionSummary objects.",
        "The service call response (type Amazon.IoT.Model.ListCommandExecutionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTCommandExecutionListCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CompletedTimeFilter_After
        /// <summary>
        /// <para>
        /// <para>Filter to display command executions that started or completed only after a particular
        /// date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CompletedTimeFilter_After { get; set; }
        #endregion
        
        #region Parameter StartedTimeFilter_After
        /// <summary>
        /// <para>
        /// <para>Filter to display command executions that started or completed only after a particular
        /// date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartedTimeFilter_After { get; set; }
        #endregion
        
        #region Parameter CompletedTimeFilter_Before
        /// <summary>
        /// <para>
        /// <para>Filter to display command executions that started or completed only before a particular
        /// date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CompletedTimeFilter_Before { get; set; }
        #endregion
        
        #region Parameter StartedTimeFilter_Before
        /// <summary>
        /// <para>
        /// <para>Filter to display command executions that started or completed only before a particular
        /// date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartedTimeFilter_Before { get; set; }
        #endregion
        
        #region Parameter CommandArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the command. You can use this information to list
        /// all command executions for a particular command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommandArn { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.CommandNamespace")]
        public Amazon.IoT.CommandNamespace Namespace { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Specify whether to list the command executions that were created in the ascending
        /// or descending order. By default, the API returns all commands in the descending order
        /// based on the start time or completion time of the executions, that are determined
        /// by the <c>startTimeFilter</c> and <c>completeTimeFilter</c> parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.SortOrder")]
        public Amazon.IoT.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>List all command executions for the device that have a particular status. For example,
        /// you can filter the list to display only command executions that have failed or timed
        /// out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.CommandExecutionStatus")]
        public Amazon.IoT.CommandExecutionStatus Status { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the target device. You can use this information
        /// to list all command executions for a particular device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in this operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>To retrieve the next set of results, the <c>nextToken</c> value from a previous response;
        /// otherwise <c>null</c> to receive the first set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CommandExecutions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.ListCommandExecutionsResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.ListCommandExecutionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CommandExecutions";
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
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.ListCommandExecutionsResponse, GetIOTCommandExecutionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CommandArn = this.CommandArn;
            context.CompletedTimeFilter_After = this.CompletedTimeFilter_After;
            context.CompletedTimeFilter_Before = this.CompletedTimeFilter_Before;
            context.MaxResult = this.MaxResult;
            context.Namespace = this.Namespace;
            context.NextToken = this.NextToken;
            context.SortOrder = this.SortOrder;
            context.StartedTimeFilter_After = this.StartedTimeFilter_After;
            context.StartedTimeFilter_Before = this.StartedTimeFilter_Before;
            context.Status = this.Status;
            context.TargetArn = this.TargetArn;
            
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
            var request = new Amazon.IoT.Model.ListCommandExecutionsRequest();
            
            if (cmdletContext.CommandArn != null)
            {
                request.CommandArn = cmdletContext.CommandArn;
            }
            
             // populate CompletedTimeFilter
            var requestCompletedTimeFilterIsNull = true;
            request.CompletedTimeFilter = new Amazon.IoT.Model.TimeFilter();
            System.String requestCompletedTimeFilter_completedTimeFilter_After = null;
            if (cmdletContext.CompletedTimeFilter_After != null)
            {
                requestCompletedTimeFilter_completedTimeFilter_After = cmdletContext.CompletedTimeFilter_After;
            }
            if (requestCompletedTimeFilter_completedTimeFilter_After != null)
            {
                request.CompletedTimeFilter.After = requestCompletedTimeFilter_completedTimeFilter_After;
                requestCompletedTimeFilterIsNull = false;
            }
            System.String requestCompletedTimeFilter_completedTimeFilter_Before = null;
            if (cmdletContext.CompletedTimeFilter_Before != null)
            {
                requestCompletedTimeFilter_completedTimeFilter_Before = cmdletContext.CompletedTimeFilter_Before;
            }
            if (requestCompletedTimeFilter_completedTimeFilter_Before != null)
            {
                request.CompletedTimeFilter.Before = requestCompletedTimeFilter_completedTimeFilter_Before;
                requestCompletedTimeFilterIsNull = false;
            }
             // determine if request.CompletedTimeFilter should be set to null
            if (requestCompletedTimeFilterIsNull)
            {
                request.CompletedTimeFilter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
             // populate StartedTimeFilter
            var requestStartedTimeFilterIsNull = true;
            request.StartedTimeFilter = new Amazon.IoT.Model.TimeFilter();
            System.String requestStartedTimeFilter_startedTimeFilter_After = null;
            if (cmdletContext.StartedTimeFilter_After != null)
            {
                requestStartedTimeFilter_startedTimeFilter_After = cmdletContext.StartedTimeFilter_After;
            }
            if (requestStartedTimeFilter_startedTimeFilter_After != null)
            {
                request.StartedTimeFilter.After = requestStartedTimeFilter_startedTimeFilter_After;
                requestStartedTimeFilterIsNull = false;
            }
            System.String requestStartedTimeFilter_startedTimeFilter_Before = null;
            if (cmdletContext.StartedTimeFilter_Before != null)
            {
                requestStartedTimeFilter_startedTimeFilter_Before = cmdletContext.StartedTimeFilter_Before;
            }
            if (requestStartedTimeFilter_startedTimeFilter_Before != null)
            {
                request.StartedTimeFilter.Before = requestStartedTimeFilter_startedTimeFilter_Before;
                requestStartedTimeFilterIsNull = false;
            }
             // determine if request.StartedTimeFilter should be set to null
            if (requestStartedTimeFilterIsNull)
            {
                request.StartedTimeFilter = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
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
        
        private Amazon.IoT.Model.ListCommandExecutionsResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.ListCommandExecutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "ListCommandExecutions");
            try
            {
                return client.ListCommandExecutionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CommandArn { get; set; }
            public System.String CompletedTimeFilter_After { get; set; }
            public System.String CompletedTimeFilter_Before { get; set; }
            public System.Int32? MaxResult { get; set; }
            public Amazon.IoT.CommandNamespace Namespace { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.IoT.SortOrder SortOrder { get; set; }
            public System.String StartedTimeFilter_After { get; set; }
            public System.String StartedTimeFilter_Before { get; set; }
            public Amazon.IoT.CommandExecutionStatus Status { get; set; }
            public System.String TargetArn { get; set; }
            public System.Func<Amazon.IoT.Model.ListCommandExecutionsResponse, GetIOTCommandExecutionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CommandExecutions;
        }
        
    }
}
