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
using Amazon.Neptunedata;
using Amazon.Neptunedata.Model;

namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// Gets a stream for a property graph.
    /// 
    ///  
    /// <para>
    /// With the Neptune Streams feature, you can generate a complete sequence of change-log
    /// entries that record every change made to your graph data as it happens. <c>GetPropertygraphStream</c>
    /// lets you collect these change-log entries for a property graph.
    /// </para><para>
    /// The Neptune streams feature needs to be enabled on your Neptune DBcluster. To enable
    /// streams, set the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/parameters.html#parameters-db-cluster-parameters-neptune_streams">neptune_streams</a>
    /// DB cluster parameter to <c>1</c>.
    /// </para><para>
    /// See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/streams.html">Capturing
    /// graph changes in real time using Neptune streams</a>.
    /// </para><para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#getstreamrecords">neptune-db:GetStreamRecords</a>
    /// IAM action in that cluster.
    /// </para><para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that enables one
    /// of the following IAM actions, depending on the query:
    /// </para><para>
    /// Note that you can restrict property-graph queries using the following IAM context
    /// keys:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-data-condition-keys.html#iam-neptune-condition-keys">neptune-db:QueryLanguage:Gremlin</a></para></li><li><para><a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-data-condition-keys.html#iam-neptune-condition-keys">neptune-db:QueryLanguage:OpenCypher</a></para></li></ul><para>
    /// See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-data-condition-keys.html">Condition
    /// keys available in Neptune IAM data-access policy statements</a>).
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NEPTPropertygraphStream")]
    [OutputType("Amazon.Neptunedata.Model.GetPropertygraphStreamResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData GetPropertygraphStream API operation.", Operation = new[] {"GetPropertygraphStream"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.GetPropertygraphStreamResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.GetPropertygraphStreamResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.GetPropertygraphStreamResponse object containing multiple properties."
    )]
    public partial class GetNEPTPropertygraphStreamCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CommitNum
        /// <summary>
        /// <para>
        /// <para>The commit number of the starting record to read from the change-log stream. This
        /// parameter is required when <c>iteratorType</c> is<c>AT_SEQUENCE_NUMBER</c> or <c>AFTER_SEQUENCE_NUMBER</c>,
        /// and ignored when <c>iteratorType</c> is <c>TRIM_HORIZON</c> or <c>LATEST</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CommitNum { get; set; }
        #endregion
        
        #region Parameter Encoding
        /// <summary>
        /// <para>
        /// <para>If set to TRUE, Neptune compresses the response using gzip encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Neptunedata.Encoding")]
        public Amazon.Neptunedata.Encoding Encoding { get; set; }
        #endregion
        
        #region Parameter IteratorType
        /// <summary>
        /// <para>
        /// <para>Can be one of:</para><ul><li><para><c>AT_SEQUENCE_NUMBER</c>   –   Indicates that reading should start from the event
        /// sequence number specified jointly by the <c>commitNum</c> and <c>opNum</c> parameters.</para></li><li><para><c>AFTER_SEQUENCE_NUMBER</c>   –   Indicates that reading should start right after
        /// the event sequence number specified jointly by the <c>commitNum</c> and <c>opNum</c>
        /// parameters.</para></li><li><para><c>TRIM_HORIZON</c>   –   Indicates that reading should start at the last untrimmed
        /// record in the system, which is the oldest unexpired (not yet deleted) record in the
        /// change-log stream.</para></li><li><para><c>LATEST</c>   –   Indicates that reading should start at the most recent record
        /// in the system, which is the latest unexpired (not yet deleted) record in the change-log
        /// stream.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Neptunedata.IteratorType")]
        public Amazon.Neptunedata.IteratorType IteratorType { get; set; }
        #endregion
        
        #region Parameter OpNum
        /// <summary>
        /// <para>
        /// <para>The operation sequence number within the specified commit to start reading from in
        /// the change-log stream data. The default is <c>1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OpNum { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of records to return. There is also a size limit of 10
        /// MB on the response that can't be modified and that takes precedence over the number
        /// of records specified in the <c>limit</c> parameter. The response does include a threshold-breaching
        /// record if the 10 MB limit was reached.</para><para>The range for <c>limit</c> is 1 to 100,000, with a default of 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.GetPropertygraphStreamResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.GetPropertygraphStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.GetPropertygraphStreamResponse, GetNEPTPropertygraphStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CommitNum = this.CommitNum;
            context.Encoding = this.Encoding;
            context.IteratorType = this.IteratorType;
            context.Limit = this.Limit;
            context.OpNum = this.OpNum;
            
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
            var request = new Amazon.Neptunedata.Model.GetPropertygraphStreamRequest();
            
            if (cmdletContext.CommitNum != null)
            {
                request.CommitNum = cmdletContext.CommitNum.Value;
            }
            if (cmdletContext.Encoding != null)
            {
                request.Encoding = cmdletContext.Encoding;
            }
            if (cmdletContext.IteratorType != null)
            {
                request.IteratorType = cmdletContext.IteratorType;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.OpNum != null)
            {
                request.OpNum = cmdletContext.OpNum.Value;
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
        
        private Amazon.Neptunedata.Model.GetPropertygraphStreamResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.GetPropertygraphStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "GetPropertygraphStream");
            try
            {
                return client.GetPropertygraphStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? CommitNum { get; set; }
            public Amazon.Neptunedata.Encoding Encoding { get; set; }
            public Amazon.Neptunedata.IteratorType IteratorType { get; set; }
            public System.Int64? Limit { get; set; }
            public System.Int64? OpNum { get; set; }
            public System.Func<Amazon.Neptunedata.Model.GetPropertygraphStreamResponse, GetNEPTPropertygraphStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
