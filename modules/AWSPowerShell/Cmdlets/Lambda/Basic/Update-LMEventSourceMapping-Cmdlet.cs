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
    /// Updates an event source mapping. You can change the function that Lambda invokes,
    /// or pause invocation and resume later from the same location.
    /// 
    ///  
    /// <para>
    /// The following error handling options are only available for stream sources (DynamoDB
    /// and Kinesis):
    /// </para><ul><li><para><code>BisectBatchOnFunctionError</code> - If the function returns an error, split
    /// the batch in two and retry.
    /// </para></li><li><para><code>DestinationConfig</code> - Send discarded records to an Amazon SQS queue or
    /// Amazon SNS topic.
    /// </para></li><li><para><code>MaximumRecordAgeInSeconds</code> - Discard records older than the specified
    /// age. The default value is infinite (-1). When set to infinite (-1), failed records
    /// are retried until the record expires
    /// </para></li><li><para><code>MaximumRetryAttempts</code> - Discard records after the specified number of
    /// retries. The default value is infinite (-1). When set to infinite (-1), failed records
    /// are retried until the record expires.
    /// </para></li><li><para><code>ParallelizationFactor</code> - Process multiple batches from each shard concurrently.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "LMEventSourceMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateEventSourceMappingResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateEventSourceMapping API operation.", Operation = new[] {"UpdateEventSourceMapping"}, SelectReturnType = typeof(Amazon.Lambda.Model.UpdateEventSourceMappingResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateEventSourceMappingResponse",
        "This cmdlet returns an Amazon.Lambda.Model.UpdateEventSourceMappingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMEventSourceMappingCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of records in each batch that Lambda pulls from your stream or
        /// queue and sends to your function. Lambda passes all of the records in the batch to
        /// the function in a single call, up to the payload limit for synchronous invocation
        /// (6 MB).</para><ul><li><para><b>Amazon Kinesis</b> - Default 100. Max 10,000.</para></li><li><para><b>Amazon DynamoDB Streams</b> - Default 100. Max 1,000.</para></li><li><para><b>Amazon Simple Queue Service</b> - Default 10. For standard queues the max is 10,000.
        /// For FIFO queues the max is 10.</para></li><li><para><b>Amazon Managed Streaming for Apache Kafka</b> - Default 100. Max 10,000.</para></li><li><para><b>Self-Managed Apache Kafka</b> - Default 100. Max 10,000.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BatchSize { get; set; }
        #endregion
        
        #region Parameter BisectBatchOnFunctionError
        /// <summary>
        /// <para>
        /// <para>(Streams only) If the function returns an error, split the batch in two and retry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BisectBatchOnFunctionError { get; set; }
        #endregion
        
        #region Parameter OnFailure_Destination
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination resource.</para>
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
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>When true, the event source mapping is active. When false, Lambda pauses polling and
        /// invocation.</para><para>Default: True</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.UpdateEventSourceMappingRequest.FunctionName
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter FunctionResponseType
        /// <summary>
        /// <para>
        /// <para>(Streams only) A list of current response type enums applied to the event source mapping.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FunctionResponseTypes")]
        public System.String[] FunctionResponseType { get; set; }
        #endregion
        
        #region Parameter MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>(Streams and Amazon SQS standard queues) The maximum amount of time, in seconds, that
        /// Lambda spends gathering records before invoking the function.</para><para>Default: 0</para><para>Related setting: When you set <code>BatchSize</code> to a value greater than 10, you
        /// must set <code>MaximumBatchingWindowInSeconds</code> to at least 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumBatchingWindowInSeconds")]
        public System.Int32? MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter MaximumRecordAgeInSecond
        /// <summary>
        /// <para>
        /// <para>(Streams only) Discard records older than the specified age. The default value is
        /// infinite (-1).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumRecordAgeInSeconds")]
        public System.Int32? MaximumRecordAgeInSecond { get; set; }
        #endregion
        
        #region Parameter MaximumRetryAttempt
        /// <summary>
        /// <para>
        /// <para>(Streams only) Discard records after the specified number of retries. The default
        /// value is infinite (-1). When set to infinite (-1), failed records will be retried
        /// until the record expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumRetryAttempts")]
        public System.Int32? MaximumRetryAttempt { get; set; }
        #endregion
        
        #region Parameter ParallelizationFactor
        /// <summary>
        /// <para>
        /// <para>(Streams only) The number of batches to process from each shard concurrently.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ParallelizationFactor { get; set; }
        #endregion
        
        #region Parameter SourceAccessConfiguration
        /// <summary>
        /// <para>
        /// <para>An array of authentication protocols or VPC components required to secure your event
        /// source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceAccessConfigurations")]
        public Amazon.Lambda.Model.SourceAccessConfiguration[] SourceAccessConfiguration { get; set; }
        #endregion
        
        #region Parameter TumblingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>(Streams only) The duration in seconds of a processing window. The range is between
        /// 1 second up to 900 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TumblingWindowInSeconds")]
        public System.Int32? TumblingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter UUID
        /// <summary>
        /// <para>
        /// <para>The identifier of the event source mapping.</para>
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
        public System.String UUID { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.UpdateEventSourceMappingResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.UpdateEventSourceMappingResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMEventSourceMapping (UpdateEventSourceMapping)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateEventSourceMappingResponse, UpdateLMEventSourceMappingCmdlet>(Select) ??
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
            context.BisectBatchOnFunctionError = this.BisectBatchOnFunctionError;
            context.OnFailure_Destination = this.OnFailure_Destination;
            context.OnSuccess_Destination = this.OnSuccess_Destination;
            context.Enabled = this.Enabled;
            context.FunctionName = this.FunctionName;
            if (this.FunctionResponseType != null)
            {
                context.FunctionResponseType = new List<System.String>(this.FunctionResponseType);
            }
            context.MaximumBatchingWindowInSecond = this.MaximumBatchingWindowInSecond;
            context.MaximumRecordAgeInSecond = this.MaximumRecordAgeInSecond;
            context.MaximumRetryAttempt = this.MaximumRetryAttempt;
            context.ParallelizationFactor = this.ParallelizationFactor;
            if (this.SourceAccessConfiguration != null)
            {
                context.SourceAccessConfiguration = new List<Amazon.Lambda.Model.SourceAccessConfiguration>(this.SourceAccessConfiguration);
            }
            context.TumblingWindowInSecond = this.TumblingWindowInSecond;
            context.UUID = this.UUID;
            #if MODULAR
            if (this.UUID == null && ParameterWasBound(nameof(this.UUID)))
            {
                WriteWarning("You are passing $null as a value for parameter UUID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Lambda.Model.UpdateEventSourceMappingRequest();
            
            if (cmdletContext.BatchSize != null)
            {
                request.BatchSize = cmdletContext.BatchSize.Value;
            }
            if (cmdletContext.BisectBatchOnFunctionError != null)
            {
                request.BisectBatchOnFunctionError = cmdletContext.BisectBatchOnFunctionError.Value;
            }
            
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
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.FunctionResponseType != null)
            {
                request.FunctionResponseTypes = cmdletContext.FunctionResponseType;
            }
            if (cmdletContext.MaximumBatchingWindowInSecond != null)
            {
                request.MaximumBatchingWindowInSeconds = cmdletContext.MaximumBatchingWindowInSecond.Value;
            }
            if (cmdletContext.MaximumRecordAgeInSecond != null)
            {
                request.MaximumRecordAgeInSeconds = cmdletContext.MaximumRecordAgeInSecond.Value;
            }
            if (cmdletContext.MaximumRetryAttempt != null)
            {
                request.MaximumRetryAttempts = cmdletContext.MaximumRetryAttempt.Value;
            }
            if (cmdletContext.ParallelizationFactor != null)
            {
                request.ParallelizationFactor = cmdletContext.ParallelizationFactor.Value;
            }
            if (cmdletContext.SourceAccessConfiguration != null)
            {
                request.SourceAccessConfigurations = cmdletContext.SourceAccessConfiguration;
            }
            if (cmdletContext.TumblingWindowInSecond != null)
            {
                request.TumblingWindowInSeconds = cmdletContext.TumblingWindowInSecond.Value;
            }
            if (cmdletContext.UUID != null)
            {
                request.UUID = cmdletContext.UUID;
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
        
        private Amazon.Lambda.Model.UpdateEventSourceMappingResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateEventSourceMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateEventSourceMapping");
            try
            {
                #if DESKTOP
                return client.UpdateEventSourceMapping(request);
                #elif CORECLR
                return client.UpdateEventSourceMappingAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? BisectBatchOnFunctionError { get; set; }
            public System.String OnFailure_Destination { get; set; }
            public System.String OnSuccess_Destination { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String FunctionName { get; set; }
            public List<System.String> FunctionResponseType { get; set; }
            public System.Int32? MaximumBatchingWindowInSecond { get; set; }
            public System.Int32? MaximumRecordAgeInSecond { get; set; }
            public System.Int32? MaximumRetryAttempt { get; set; }
            public System.Int32? ParallelizationFactor { get; set; }
            public List<Amazon.Lambda.Model.SourceAccessConfiguration> SourceAccessConfiguration { get; set; }
            public System.Int32? TumblingWindowInSecond { get; set; }
            public System.String UUID { get; set; }
            public System.Func<Amazon.Lambda.Model.UpdateEventSourceMappingResponse, UpdateLMEventSourceMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
