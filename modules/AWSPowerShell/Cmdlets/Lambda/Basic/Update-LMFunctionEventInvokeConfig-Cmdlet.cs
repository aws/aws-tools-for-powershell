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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Updates the configuration for asynchronous invocation for a function, version, or
    /// alias.
    /// 
    ///  
    /// <para>
    /// To configure options for asynchronous invocation, use <a>PutFunctionEventInvokeConfig</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LMFunctionEventInvokeConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateFunctionEventInvokeConfig API operation.", Operation = new[] {"UpdateFunctionEventInvokeConfig"}, SelectReturnType = typeof(Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigResponse",
        "This cmdlet returns an Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigResponse object containing multiple properties."
    )]
    public partial class UpdateLMFunctionEventInvokeConfigCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OnFailure_Destination
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination resource.</para><para>To retain records of failed invocations from <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kinesis.html">Kinesis</a>,
        /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-ddb.html">DynamoDB</a>,
        /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/kafka-on-failure.html">self-managed
        /// Apache Kafka</a>, or <a href="https://docs.aws.amazon.com/lambda/latest/dg/kafka-on-failure.html">Amazon
        /// MSK</a>, you can configure an Amazon SNS topic, Amazon SQS queue, Amazon S3 bucket,
        /// or Kafka topic as the destination.</para><note><para>Amazon SNS destinations have a message size limit of 256 KB. If the combined size
        /// of the function request and response payload exceeds the limit, Lambda will drop the
        /// payload when sending <c>OnFailure</c> event to the destination. For details on this
        /// behavior, refer to <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async-retain-records.html">Retaining
        /// records of asynchronous invocations</a>.</para></note><para>To retain records of failed invocations from <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kinesis.html">Kinesis</a>,
        /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-ddb.html">DynamoDB</a>,
        /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kafka.html#services-smaa-onfailure-destination">self-managed
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
        /// <para>The Amazon Resource Name (ARN) of the destination resource.</para><note><para>Amazon SNS destinations have a message size limit of 256 KB. If the combined size
        /// of the function request and response payload exceeds the limit, Lambda will drop the
        /// payload when sending <c>OnFailure</c> event to the destination. For details on this
        /// behavior, refer to <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async-retain-records.html">Retaining
        /// records of asynchronous invocations</a>.</para></note>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMFunctionEventInvokeConfig (UpdateFunctionEventInvokeConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigResponse, UpdateLMFunctionEventInvokeConfigCmdlet>(Select) ??
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
            var request = new Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigRequest();
            
            
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
        
        private Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateFunctionEventInvokeConfig");
            try
            {
                #if DESKTOP
                return client.UpdateFunctionEventInvokeConfig(request);
                #elif CORECLR
                return client.UpdateFunctionEventInvokeConfigAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Lambda.Model.UpdateFunctionEventInvokeConfigResponse, UpdateLMFunctionEventInvokeConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
