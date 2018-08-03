/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Lists the consumers registered to receive data from a stream using enhanced fan-out,
    /// and provides information about each consumer.
    /// 
    ///  
    /// <para>
    /// This operation has a limit of 10 transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINStreamConsumerList")]
    [OutputType("Amazon.Kinesis.Model.Consumer")]
    [AWSCmdlet("Calls the Amazon Kinesis ListStreamConsumers API operation.", Operation = new[] {"ListStreamConsumers"})]
    [AWSCmdletOutput("Amazon.Kinesis.Model.Consumer",
        "This cmdlet returns a collection of Consumer objects.",
        "The service call response (type Amazon.Kinesis.Model.ListStreamConsumersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetKINStreamConsumerListCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Kinesis data stream for which you want to list the registered consumers.
        /// For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-kinesis-streams">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamCreationTimestamp
        /// <summary>
        /// <para>
        /// <para>Specify this input parameter to distinguish data streams that have the same name.
        /// For example, if you create a data stream and then delete it, and you later create
        /// another data stream with the same name, you can use this input parameter to specify
        /// which of the two streams you want to list the consumers for. </para><para>You can't specify this parameter if you specify the NextToken parameter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StreamCreationTimestamp { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of consumers that you want a single call of <code>ListStreamConsumers</code>
        /// to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>When the number of consumers that are registered with the data stream is greater than
        /// the default value for the <code>MaxResults</code> parameter, or if you explicitly
        /// specify a value for <code>MaxResults</code> that is less than the number of consumers
        /// that are registered with the data stream, the response includes a pagination token
        /// named <code>NextToken</code>. You can specify this <code>NextToken</code> value in
        /// a subsequent call to <code>ListStreamConsumers</code> to list the next set of registered
        /// consumers.</para><para>Don't specify <code>StreamName</code> or <code>StreamCreationTimestamp</code> if you
        /// specify <code>NextToken</code> because the latter unambiguously identifies the stream.</para><para>You can optionally specify a value for the <code>MaxResults</code> parameter when
        /// you specify <code>NextToken</code>. If you specify a <code>MaxResults</code> value
        /// that is less than the number of consumers that the operation returns if you don't
        /// specify <code>MaxResults</code>, the response will contain a new <code>NextToken</code>
        /// value. You can use the new <code>NextToken</code> value in a subsequent call to the
        /// <code>ListStreamConsumers</code> operation to list the next set of consumers.</para><important><para>Tokens expire after 300 seconds. When you obtain a value for <code>NextToken</code>
        /// in the response to a call to <code>ListStreamConsumers</code>, you have 300 seconds
        /// to use that value. If you specify an expired token in a call to <code>ListStreamConsumers</code>,
        /// you get <code>ExpiredNextTokenException</code>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StreamARN = this.StreamARN;
            if (ParameterWasBound("StreamCreationTimestamp"))
                context.StreamCreationTimestamp = this.StreamCreationTimestamp;
            
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
            var request = new Amazon.Kinesis.Model.ListStreamConsumersRequest();
            
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamCreationTimestamp != null)
            {
                request.StreamCreationTimestamp = cmdletContext.StreamCreationTimestamp.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Consumers;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Kinesis.Model.ListStreamConsumersResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.ListStreamConsumersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "ListStreamConsumers");
            try
            {
                #if DESKTOP
                return client.ListStreamConsumers(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListStreamConsumersAsync(request);
                return task.Result;
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
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String StreamARN { get; set; }
            public System.DateTime? StreamCreationTimestamp { get; set; }
        }
        
    }
}
