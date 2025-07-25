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
using Amazon.DynamoDBStreams;
using Amazon.DynamoDBStreams.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DDBS
{
    /// <summary>
    /// Returns an array of stream ARNs associated with the current account and endpoint.
    /// If the <c>TableName</c> parameter is present, then <c>ListStreams</c> will return
    /// only the streams ARNs for that table.
    /// 
    ///  <note><para>
    /// You can call <c>ListStreams</c> at a maximum rate of 5 times per second.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "DDBSStreamList")]
    [OutputType("Amazon.DynamoDBStreams.Model.ListStreamsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB Streams ListStreams API operation.", Operation = new[] {"ListStreams"}, SelectReturnType = typeof(Amazon.DynamoDBStreams.Model.ListStreamsResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBStreams.Model.ListStreamsResponse",
        "This cmdlet returns an Amazon.DynamoDBStreams.Model.ListStreamsResponse object containing multiple properties."
    )]
    public partial class GetDDBSStreamListCmdlet : AmazonDynamoDBStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExclusiveStartStreamArn
        /// <summary>
        /// <para>
        /// <para>The ARN (Amazon Resource Name) of the first item that this operation will evaluate.
        /// Use the value that was returned for <c>LastEvaluatedStreamArn</c> in the previous
        /// operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExclusiveStartStreamArn { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>If this parameter is provided, then only the streams associated with this table name
        /// are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of streams to return. The upper limit is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBStreams.Model.ListStreamsResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBStreams.Model.ListStreamsResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBStreams.Model.ListStreamsResponse, GetDDBSStreamListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExclusiveStartStreamArn = this.ExclusiveStartStreamArn;
            context.Limit = this.Limit;
            context.TableName = this.TableName;
            
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
            var request = new Amazon.DynamoDBStreams.Model.ListStreamsRequest();
            
            if (cmdletContext.ExclusiveStartStreamArn != null)
            {
                request.ExclusiveStartStreamArn = cmdletContext.ExclusiveStartStreamArn;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.DynamoDBStreams.Model.ListStreamsResponse CallAWSServiceOperation(IAmazonDynamoDBStreams client, Amazon.DynamoDBStreams.Model.ListStreamsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB Streams", "ListStreams");
            try
            {
                return client.ListStreamsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ExclusiveStartStreamArn { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.DynamoDBStreams.Model.ListStreamsResponse, GetDDBSStreamListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
