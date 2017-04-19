/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Identifies a stream as an event source for a Lambda function. It can be either an
    /// Amazon Kinesis stream or an Amazon DynamoDB stream. AWS Lambda invokes the specified
    /// function when records are posted to the stream.
    /// 
    ///  
    /// <para>
    /// This association between a stream source and a Lambda function is called the event
    /// source mapping.
    /// </para><important><para>
    /// This event source mapping is relevant only in the AWS Lambda pull model, where AWS
    /// Lambda invokes the function. For more information, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/lambda-introduction.html">AWS
    /// Lambda: How it Works</a> in the <i>AWS Lambda Developer Guide</i>.
    /// </para></important><para>
    /// You provide mapping information (for example, which stream to read from and which
    /// Lambda function to invoke) in the request body.
    /// </para><para>
    /// Each event source, such as an Amazon Kinesis or a DynamoDB stream, can be associated
    /// with multiple AWS Lambda function. A given Lambda function can be associated with
    /// multiple AWS event sources.
    /// </para><para>
    /// If you are using versioning, you can specify a specific function version or an alias
    /// via the function name parameter. For more information about versioning, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-aliases.html">AWS
    /// Lambda Function Versioning and Aliases</a>. 
    /// </para><para>
    /// This operation requires permission for the <code>lambda:CreateEventSourceMapping</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LMEventSourceMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CreateEventSourceMappingResponse")]
    [AWSCmdlet("Invokes the CreateEventSourceMapping operation against Amazon Lambda.", Operation = new[] {"CreateEventSourceMapping"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.CreateEventSourceMappingResponse",
        "This cmdlet returns a Amazon.Lambda.Model.CreateEventSourceMappingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLMEventSourceMappingCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter BatchSize
        /// <summary>
        /// <para>
        /// <para>The largest number of records that AWS Lambda will retrieve from your event source
        /// at the time of invoking your function. Your function receives an event with all the
        /// retrieved records. The default is 100 records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 BatchSize { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether AWS Lambda should begin polling the event source. By default, <code>Enabled</code>
        /// is true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Enabled { get; set; }
        #endregion
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Kinesis or the Amazon DynamoDB stream
        /// that is the event source. Any record added to this stream could cause AWS Lambda to
        /// invoke your Lambda function, it depends on the <code>BatchSize</code>. AWS Lambda
        /// POSTs the Amazon Kinesis event, containing records, to your Lambda function as JSON.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The Lambda function to invoke when AWS Lambda detects an event on the stream.</para><para> You can specify the function name (for example, <code>Thumbnail</code>) or you can
        /// specify Amazon Resource Name (ARN) of the function (for example, <code>arn:aws:lambda:us-west-2:account-id:function:ThumbNail</code>).
        /// </para><para> If you are using versioning, you can also provide a qualified function ARN (ARN that
        /// is qualified with function version or alias name as suffix). For more information
        /// about versioning, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-aliases.html">AWS
        /// Lambda Function Versioning and Aliases</a></para><para>AWS Lambda also allows you to specify only the function name with the account ID qualifier
        /// (for example, <code>account-id:Thumbnail</code>). </para><para>Note that the length constraint applies only to the ARN. If you specify only the function
        /// name, it is limited to 64 characters in length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter StartingPosition
        /// <summary>
        /// <para>
        /// <para>The position in the stream where AWS Lambda should start reading. Valid only for Kinesis
        /// streams. For more information, see <a href="http://docs.aws.amazon.com/kinesis/latest/APIReference/API_GetShardIterator.html#Kinesis-GetShardIterator-request-ShardIteratorType">ShardIteratorType</a>
        /// in the <i>Amazon Kinesis API Reference</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Lambda.EventSourcePosition")]
        public Amazon.Lambda.EventSourcePosition StartingPosition { get; set; }
        #endregion
        
        #region Parameter StartingPositionTimestamp
        /// <summary>
        /// <para>
        /// <para>The timestamp of the data record from which to start reading. Used with <a href="http://docs.aws.amazon.com/kinesis/latest/APIReference/API_GetShardIterator.html#Kinesis-GetShardIterator-request-ShardIteratorType">shard
        /// iterator type</a> AT_TIMESTAMP. If a record with this exact timestamp does not exist,
        /// the iterator returned is for the next (later) record. If the timestamp is older than
        /// the current trim horizon, the iterator returned is for the oldest untrimmed data record
        /// (TRIM_HORIZON). Valid only for Kinesis streams. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartingPositionTimestamp { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMEventSourceMapping (CreateEventSourceMapping)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("BatchSize"))
                context.BatchSize = this.BatchSize;
            if (ParameterWasBound("Enabled"))
                context.Enabled = this.Enabled;
            context.EventSourceArn = this.EventSourceArn;
            context.FunctionName = this.FunctionName;
            context.StartingPosition = this.StartingPosition;
            if (ParameterWasBound("StartingPositionTimestamp"))
                context.StartingPositionTimestamp = this.StartingPositionTimestamp;
            
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
            var request = new Amazon.Lambda.Model.CreateEventSourceMappingRequest();
            
            if (cmdletContext.BatchSize != null)
            {
                request.BatchSize = cmdletContext.BatchSize.Value;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EventSourceArn != null)
            {
                request.EventSourceArn = cmdletContext.EventSourceArn;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.StartingPosition != null)
            {
                request.StartingPosition = cmdletContext.StartingPosition;
            }
            if (cmdletContext.StartingPositionTimestamp != null)
            {
                request.StartingPositionTimestamp = cmdletContext.StartingPositionTimestamp.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private static Amazon.Lambda.Model.CreateEventSourceMappingResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.CreateEventSourceMappingRequest request)
        {
            #if DESKTOP
            return client.CreateEventSourceMapping(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateEventSourceMappingAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? BatchSize { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String EventSourceArn { get; set; }
            public System.String FunctionName { get; set; }
            public Amazon.Lambda.EventSourcePosition StartingPosition { get; set; }
            public System.DateTime? StartingPositionTimestamp { get; set; }
        }
        
    }
}
