/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kinesis.html">Using AWS
    /// Lambda with Amazon Kinesis</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-sqs.html">Using AWS Lambda
    /// with Amazon SQS</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-ddb.html">Using AWS Lambda
    /// with Amazon DynamoDB</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "LMEventSourceMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CreateEventSourceMappingResponse")]
    [AWSCmdlet("Calls the AWS Lambda CreateEventSourceMapping API operation.", Operation = new[] {"CreateEventSourceMapping"}, SelectReturnType = typeof(Amazon.Lambda.Model.CreateEventSourceMappingResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.CreateEventSourceMappingResponse",
        "This cmdlet returns an Amazon.Lambda.Model.CreateEventSourceMappingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLMEventSourceMappingCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to retrieve in a single batch.</para><ul><li><para><b>Amazon Kinesis</b> - Default 100. Max 10,000.</para></li><li><para><b>Amazon DynamoDB Streams</b> - Default 100. Max 1,000.</para></li><li><para><b>Amazon Simple Queue Service</b> - Default 10. Max 10.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BatchSize { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Disables the event source mapping to pause polling and invocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the event source.</para><ul><li><para><b>Amazon Kinesis</b> - The ARN of the data stream or a stream consumer.</para></li><li><para><b>Amazon DynamoDB Streams</b> - The ARN of the stream.</para></li><li><para><b>Amazon Simple Queue Service</b> - The ARN of the queue.</para></li></ul>
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
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.CreateEventSourceMappingRequest.FunctionName
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
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumBatchingWindowInSeconds")]
        public System.Int32? MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter StartingPosition
        /// <summary>
        /// <para>
        /// <para>The position in a stream from which to start reading. Required for Amazon Kinesis
        /// and Amazon DynamoDB Streams sources. <code>AT_TIMESTAMP</code> is only supported for
        /// Amazon Kinesis streams.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.EventSourcePosition")]
        public Amazon.Lambda.EventSourcePosition StartingPosition { get; set; }
        #endregion
        
        #region Parameter StartingPositionTimestamp
        /// <summary>
        /// <para>
        /// <para>With <code>StartingPosition</code> set to <code>AT_TIMESTAMP</code>, the time from
        /// which to start reading.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartingPositionTimestamp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.CreateEventSourceMappingResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.CreateEventSourceMappingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FunctionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMEventSourceMapping (CreateEventSourceMapping)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.CreateEventSourceMappingResponse, NewLMEventSourceMappingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FunctionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BatchSize = this.BatchSize;
            context.Enabled = this.Enabled;
            context.EventSourceArn = this.EventSourceArn;
            #if MODULAR
            if (this.EventSourceArn == null && ParameterWasBound(nameof(this.EventSourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventSourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaximumBatchingWindowInSecond = this.MaximumBatchingWindowInSecond;
            context.StartingPosition = this.StartingPosition;
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
            if (cmdletContext.MaximumBatchingWindowInSecond != null)
            {
                request.MaximumBatchingWindowInSeconds = cmdletContext.MaximumBatchingWindowInSecond.Value;
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
        
        private Amazon.Lambda.Model.CreateEventSourceMappingResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.CreateEventSourceMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "CreateEventSourceMapping");
            try
            {
                #if DESKTOP
                return client.CreateEventSourceMapping(request);
                #elif CORECLR
                return client.CreateEventSourceMappingAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaximumBatchingWindowInSecond { get; set; }
            public Amazon.Lambda.EventSourcePosition StartingPosition { get; set; }
            public System.DateTime? StartingPositionTimestamp { get; set; }
            public System.Func<Amazon.Lambda.Model.CreateEventSourceMappingResponse, NewLMEventSourceMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
