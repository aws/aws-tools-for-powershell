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
    /// Configures options for <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async.html">asynchronous
    /// invocation</a> on a function, version, or alias. If a configuration already exists
    /// for a function, version, or alias, this operation overwrites it. If you exclude any
    /// settings, they are removed. To set one option without affecting existing settings
    /// for other options, use <a>UpdateFunctionEventInvokeConfig</a>.
    /// 
    ///  
    /// <para>
    /// By default, Lambda retries an asynchronous invocation twice if the function returns
    /// an error. It retains events in a queue for up to six hours. When an event fails all
    /// processing attempts or stays in the asynchronous invocation queue for too long, Lambda
    /// discards it. To retain discarded events, configure a dead-letter queue with <a>UpdateFunctionConfiguration</a>.
    /// </para><para>
    /// To send an invocation record to a queue, topic, function, or event bus, specify a
    /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async.html#invocation-async-destinations">destination</a>.
    /// You can configure separate destinations for successful invocations (on-success) and
    /// events that fail all processing attempts (on-failure). You can configure destinations
    /// in addition to or instead of a dead-letter queue.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LMFunctionEventInvokeConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.PutFunctionEventInvokeConfigResponse")]
    [AWSCmdlet("Calls the AWS Lambda PutFunctionEventInvokeConfig API operation.", Operation = new[] {"PutFunctionEventInvokeConfig"}, SelectReturnType = typeof(Amazon.Lambda.Model.PutFunctionEventInvokeConfigResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.PutFunctionEventInvokeConfigResponse",
        "This cmdlet returns an Amazon.Lambda.Model.PutFunctionEventInvokeConfigResponse object containing multiple properties."
    )]
    public partial class WriteLMFunctionEventInvokeConfigCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OnFailure_Destination
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination resource.</para><para>To retain records of <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async.html#invocation-async-destinations">asynchronous
        /// invocations</a>, you can configure an Amazon SNS topic, Amazon SQS queue, Lambda function,
        /// or Amazon EventBridge event bus as the destination.</para><para>To retain records of failed invocations from <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-eventsourcemapping.html#event-source-mapping-destinations">Kinesis
        /// and DynamoDB event sources</a>, you can configure an Amazon SNS topic or Amazon SQS
        /// queue as the destination.</para><para>To retain records of failed invocations from <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kafka.html#services-smaa-onfailure-destination">self-managed
        /// Kafka</a> or <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-msk.html#services-msk-onfailure-destination">Amazon
        /// MSK</a>, you can configure an Amazon SNS topic, Amazon SQS queue, or Amazon S3 bucket
        /// as the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfig_OnFailure_Destination")]
        public System.String OnFailure_Destination { get; set; }
        #endregion
        
        #region Parameter OnSuccess_Destination
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfig_OnSuccess_Destination")]
        public System.String OnSuccess_Destination { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the Lambda function, version, or alias.</para><para><b>Name formats</b></para><ul><li><para><b>Function name</b> - <c>my-function</c> (name-only), <c>my-function:v1</c> (with
        /// alias).</para></li><li><para><b>Function ARN</b> - <c>arn:aws:lambda:us-west-2:123456789012:function:my-function</c>.</para></li><li><para><b>Partial ARN</b> - <c>123456789012:function:my-function</c>.</para></li></ul><para>You can append a version number or alias to any of the formats. The length constraint
        /// applies only to the full ARN. If you specify only the function name, it is limited
        /// to 64 characters in length.</para>
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
        
        #region Parameter MaximumEventAgeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum age of a request that Lambda sends to a function for processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumEventAgeInSeconds")]
        public System.Int32? MaximumEventAgeInSecond { get; set; }
        #endregion
        
        #region Parameter MaximumRetryAttempt
        /// <summary>
        /// <para>
        /// <para>The maximum number of times to retry when the function returns an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumRetryAttempts")]
        public System.Int32? MaximumRetryAttempt { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>A version number or alias name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.PutFunctionEventInvokeConfigResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.PutFunctionEventInvokeConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMFunctionEventInvokeConfig (PutFunctionEventInvokeConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.PutFunctionEventInvokeConfigResponse, WriteLMFunctionEventInvokeConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OnFailure_Destination = this.OnFailure_Destination;
            context.OnSuccess_Destination = this.OnSuccess_Destination;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaximumEventAgeInSecond = this.MaximumEventAgeInSecond;
            context.MaximumRetryAttempt = this.MaximumRetryAttempt;
            context.Qualifier = this.Qualifier;
            
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
            var request = new Amazon.Lambda.Model.PutFunctionEventInvokeConfigRequest();
            
            
             // populate DestinationConfig
            var requestDestinationConfigIsNull = true;
            request.DestinationConfig = new Amazon.Lambda.Model.DestinationConfig();
            Amazon.Lambda.Model.OnFailure requestDestinationConfig_destinationConfig_OnFailure = null;
            
             // populate OnFailure
            var requestDestinationConfig_destinationConfig_OnFailureIsNull = true;
            requestDestinationConfig_destinationConfig_OnFailure = new Amazon.Lambda.Model.OnFailure();
            System.String requestDestinationConfig_destinationConfig_OnFailure_onFailure_Destination = null;
            if (cmdletContext.OnFailure_Destination != null)
            {
                requestDestinationConfig_destinationConfig_OnFailure_onFailure_Destination = cmdletContext.OnFailure_Destination;
            }
            if (requestDestinationConfig_destinationConfig_OnFailure_onFailure_Destination != null)
            {
                requestDestinationConfig_destinationConfig_OnFailure.Destination = requestDestinationConfig_destinationConfig_OnFailure_onFailure_Destination;
                requestDestinationConfig_destinationConfig_OnFailureIsNull = false;
            }
             // determine if requestDestinationConfig_destinationConfig_OnFailure should be set to null
            if (requestDestinationConfig_destinationConfig_OnFailureIsNull)
            {
                requestDestinationConfig_destinationConfig_OnFailure = null;
            }
            if (requestDestinationConfig_destinationConfig_OnFailure != null)
            {
                request.DestinationConfig.OnFailure = requestDestinationConfig_destinationConfig_OnFailure;
                requestDestinationConfigIsNull = false;
            }
            Amazon.Lambda.Model.OnSuccess requestDestinationConfig_destinationConfig_OnSuccess = null;
            
             // populate OnSuccess
            var requestDestinationConfig_destinationConfig_OnSuccessIsNull = true;
            requestDestinationConfig_destinationConfig_OnSuccess = new Amazon.Lambda.Model.OnSuccess();
            System.String requestDestinationConfig_destinationConfig_OnSuccess_onSuccess_Destination = null;
            if (cmdletContext.OnSuccess_Destination != null)
            {
                requestDestinationConfig_destinationConfig_OnSuccess_onSuccess_Destination = cmdletContext.OnSuccess_Destination;
            }
            if (requestDestinationConfig_destinationConfig_OnSuccess_onSuccess_Destination != null)
            {
                requestDestinationConfig_destinationConfig_OnSuccess.Destination = requestDestinationConfig_destinationConfig_OnSuccess_onSuccess_Destination;
                requestDestinationConfig_destinationConfig_OnSuccessIsNull = false;
            }
             // determine if requestDestinationConfig_destinationConfig_OnSuccess should be set to null
            if (requestDestinationConfig_destinationConfig_OnSuccessIsNull)
            {
                requestDestinationConfig_destinationConfig_OnSuccess = null;
            }
            if (requestDestinationConfig_destinationConfig_OnSuccess != null)
            {
                request.DestinationConfig.OnSuccess = requestDestinationConfig_destinationConfig_OnSuccess;
                requestDestinationConfigIsNull = false;
            }
             // determine if request.DestinationConfig should be set to null
            if (requestDestinationConfigIsNull)
            {
                request.DestinationConfig = null;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.MaximumEventAgeInSecond != null)
            {
                request.MaximumEventAgeInSeconds = cmdletContext.MaximumEventAgeInSecond.Value;
            }
            if (cmdletContext.MaximumRetryAttempt != null)
            {
                request.MaximumRetryAttempts = cmdletContext.MaximumRetryAttempt.Value;
            }
            if (cmdletContext.Qualifier != null)
            {
                request.Qualifier = cmdletContext.Qualifier;
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
        
        private Amazon.Lambda.Model.PutFunctionEventInvokeConfigResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.PutFunctionEventInvokeConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "PutFunctionEventInvokeConfig");
            try
            {
                #if DESKTOP
                return client.PutFunctionEventInvokeConfig(request);
                #elif CORECLR
                return client.PutFunctionEventInvokeConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String OnFailure_Destination { get; set; }
            public System.String OnSuccess_Destination { get; set; }
            public System.String FunctionName { get; set; }
            public System.Int32? MaximumEventAgeInSecond { get; set; }
            public System.Int32? MaximumRetryAttempt { get; set; }
            public System.String Qualifier { get; set; }
            public System.Func<Amazon.Lambda.Model.PutFunctionEventInvokeConfigResponse, WriteLMFunctionEventInvokeConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
