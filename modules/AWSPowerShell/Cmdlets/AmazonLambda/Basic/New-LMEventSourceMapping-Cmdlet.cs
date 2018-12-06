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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Creates a mapping between an event source and an AWS Lambda function. Lambda reads
    /// items from the event source and triggers the function.
    /// 
    ///  
    /// <para>
    /// For details about each event source type, see the following topics.
    /// </para><ul><li><para><a href="http://docs.aws.amazon.com/lambda/latest/dg/with-kinesis.html">Using AWS
    /// Lambda with Amazon Kinesis</a></para></li><li><para><a href="http://docs.aws.amazon.com/lambda/latest/dg/with-sqs.html">Using AWS Lambda
    /// with Amazon SQS</a></para></li><li><para><a href="http://docs.aws.amazon.com/lambda/latest/dg/with-ddb.html">Using AWS Lambda
    /// with Amazon DynamoDB</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "LMEventSourceMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CreateEventSourceMappingResponse")]
    [AWSCmdlet("Calls the AWS Lambda CreateEventSourceMapping API operation.", Operation = new[] {"CreateEventSourceMapping"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.CreateEventSourceMappingResponse",
        "This cmdlet returns a Amazon.Lambda.Model.CreateEventSourceMappingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLMEventSourceMappingCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to retrieve in a single batch.</para><ul><li><para><b>Amazon Kinesis</b> - Default 100. Max 10,000.</para></li><li><para><b>Amazon DynamoDB Streams</b> - Default 100. Max 1,000.</para></li><li><para><b>Amazon Simple Queue Service</b> - Default 10. Max 10.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 BatchSize { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Disables the event source mapping to pause polling and invocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Enabled { get; set; }
        #endregion
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the event source.</para><ul><li><para><b>Amazon Kinesis</b> - The ARN of the data stream or a stream consumer.</para></li><li><para><b>Amazon DynamoDB Streams</b> - The ARN of the stream.</para></li><li><para><b>Amazon Simple Queue Service</b> - The ARN of the queue.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.CreateEventSourceMappingRequest.FunctionName
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter StartingPosition
        /// <summary>
        /// <para>
        /// <para>The position in a stream from which to start reading. Required for Amazon Kinesis
        /// and Amazon DynamoDB Streams sources. <code>AT_TIMESTAMP</code> is only supported for
        /// Amazon Kinesis streams.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Lambda.EventSourcePosition")]
        public Amazon.Lambda.EventSourcePosition StartingPosition { get; set; }
        #endregion
        
        #region Parameter StartingPositionTimestamp
        /// <summary>
        /// <para>
        /// <para>With <code>StartingPosition</code> set to <code>AT_TIMESTAMP</code>, the Unix time
        /// in seconds from which to start reading.</para>
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
        
        private Amazon.Lambda.Model.CreateEventSourceMappingResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.CreateEventSourceMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "CreateEventSourceMapping");
            try
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
            public System.Int32? BatchSize { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String EventSourceArn { get; set; }
            public System.String FunctionName { get; set; }
            public Amazon.Lambda.EventSourcePosition StartingPosition { get; set; }
            public System.DateTime? StartingPositionTimestamp { get; set; }
        }
        
    }
}
