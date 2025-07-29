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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Submits a service job to a specified job queue to run on SageMaker AI. A service job
    /// is a unit of work that you submit to Batch for execution on SageMaker AI.
    /// </summary>
    [Cmdlet("Submit", "BATServiceJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.SubmitServiceJobResponse")]
    [AWSCmdlet("Calls the AWS Batch SubmitServiceJob API operation.", Operation = new[] {"SubmitServiceJob"}, SelectReturnType = typeof(Amazon.Batch.Model.SubmitServiceJobResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.SubmitServiceJobResponse",
        "This cmdlet returns an Amazon.Batch.Model.SubmitServiceJobResponse object containing multiple properties."
    )]
    public partial class SubmitBATServiceJobCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TimeoutConfig_AttemptDurationSecond
        /// <summary>
        /// <para>
        /// <para>The maximum duration in seconds that a service job attempt can run. After this time
        /// is reached, Batch terminates the service job attempt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutConfig_AttemptDurationSeconds")]
        public System.Int32? TimeoutConfig_AttemptDurationSecond { get; set; }
        #endregion
        
        #region Parameter RetryStrategy_Attempt
        /// <summary>
        /// <para>
        /// <para>The number of times to move a service job to <c>RUNNABLE</c> status. You can specify
        /// between 1 and 10 attempts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryStrategy_Attempts")]
        public System.Int32? RetryStrategy_Attempt { get; set; }
        #endregion
        
        #region Parameter RetryStrategy_EvaluateOnExit
        /// <summary>
        /// <para>
        /// <para>Array of <c>ServiceJobEvaluateOnExit</c> objects that specify conditions under which
        /// the service job should be retried or failed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.ServiceJobEvaluateOnExit[] RetryStrategy_EvaluateOnExit { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the service job. It can be up to 128 characters long. It can contain uppercase
        /// and lowercase letters, numbers, hyphens (-), and underscores (_).</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobQueue
        /// <summary>
        /// <para>
        /// <para>The job queue into which the service job is submitted. You can specify either the
        /// name or the ARN of the queue. The job queue must have the type <c>SAGEMAKER_TRAINING</c>.</para>
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
        public System.String JobQueue { get; set; }
        #endregion
        
        #region Parameter SchedulingPriority
        /// <summary>
        /// <para>
        /// <para>The scheduling priority of the service job. Valid values are integers between 0 and
        /// 9999.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SchedulingPriority { get; set; }
        #endregion
        
        #region Parameter ServiceJobType
        /// <summary>
        /// <para>
        /// <para>The type of service job. For SageMaker Training jobs, specify <c>SAGEMAKER_TRAINING</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Batch.ServiceJobType")]
        public Amazon.Batch.ServiceJobType ServiceJobType { get; set; }
        #endregion
        
        #region Parameter ServiceRequestPayload
        /// <summary>
        /// <para>
        /// <para>The request, in JSON, for the service that the SubmitServiceJob operation is queueing.
        /// </para>
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
        public System.String ServiceRequestPayload { get; set; }
        #endregion
        
        #region Parameter ShareIdentifier
        /// <summary>
        /// <para>
        /// <para>The share identifier for the service job. Don't specify this parameter if the job
        /// queue doesn't have a fair- share scheduling policy. If the job queue has a fair-share
        /// scheduling policy, then this parameter must be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShareIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you apply to the service job request. Each tag consists of a key and
        /// an optional value. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/using-tags.html">Tagging
        /// your Batch resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the request. This token is used to ensure idempotency of requests.
        /// If this parameter is specified and two submit requests with identical payloads and
        /// <c>clientToken</c>s are received, these requests are considered the same request and
        /// the second request is rejected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.SubmitServiceJobResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.SubmitServiceJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-BATServiceJob (SubmitServiceJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.SubmitServiceJobResponse, SubmitBATServiceJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobQueue = this.JobQueue;
            #if MODULAR
            if (this.JobQueue == null && ParameterWasBound(nameof(this.JobQueue)))
            {
                WriteWarning("You are passing $null as a value for parameter JobQueue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetryStrategy_Attempt = this.RetryStrategy_Attempt;
            if (this.RetryStrategy_EvaluateOnExit != null)
            {
                context.RetryStrategy_EvaluateOnExit = new List<Amazon.Batch.Model.ServiceJobEvaluateOnExit>(this.RetryStrategy_EvaluateOnExit);
            }
            context.SchedulingPriority = this.SchedulingPriority;
            context.ServiceJobType = this.ServiceJobType;
            #if MODULAR
            if (this.ServiceJobType == null && ParameterWasBound(nameof(this.ServiceJobType)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceJobType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceRequestPayload = this.ServiceRequestPayload;
            #if MODULAR
            if (this.ServiceRequestPayload == null && ParameterWasBound(nameof(this.ServiceRequestPayload)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceRequestPayload which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShareIdentifier = this.ShareIdentifier;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TimeoutConfig_AttemptDurationSecond = this.TimeoutConfig_AttemptDurationSecond;
            
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
            var request = new Amazon.Batch.Model.SubmitServiceJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobQueue != null)
            {
                request.JobQueue = cmdletContext.JobQueue;
            }
            
             // populate RetryStrategy
            var requestRetryStrategyIsNull = true;
            request.RetryStrategy = new Amazon.Batch.Model.ServiceJobRetryStrategy();
            System.Int32? requestRetryStrategy_retryStrategy_Attempt = null;
            if (cmdletContext.RetryStrategy_Attempt != null)
            {
                requestRetryStrategy_retryStrategy_Attempt = cmdletContext.RetryStrategy_Attempt.Value;
            }
            if (requestRetryStrategy_retryStrategy_Attempt != null)
            {
                request.RetryStrategy.Attempts = requestRetryStrategy_retryStrategy_Attempt.Value;
                requestRetryStrategyIsNull = false;
            }
            List<Amazon.Batch.Model.ServiceJobEvaluateOnExit> requestRetryStrategy_retryStrategy_EvaluateOnExit = null;
            if (cmdletContext.RetryStrategy_EvaluateOnExit != null)
            {
                requestRetryStrategy_retryStrategy_EvaluateOnExit = cmdletContext.RetryStrategy_EvaluateOnExit;
            }
            if (requestRetryStrategy_retryStrategy_EvaluateOnExit != null)
            {
                request.RetryStrategy.EvaluateOnExit = requestRetryStrategy_retryStrategy_EvaluateOnExit;
                requestRetryStrategyIsNull = false;
            }
             // determine if request.RetryStrategy should be set to null
            if (requestRetryStrategyIsNull)
            {
                request.RetryStrategy = null;
            }
            if (cmdletContext.SchedulingPriority != null)
            {
                request.SchedulingPriority = cmdletContext.SchedulingPriority.Value;
            }
            if (cmdletContext.ServiceJobType != null)
            {
                request.ServiceJobType = cmdletContext.ServiceJobType;
            }
            if (cmdletContext.ServiceRequestPayload != null)
            {
                request.ServiceRequestPayload = cmdletContext.ServiceRequestPayload;
            }
            if (cmdletContext.ShareIdentifier != null)
            {
                request.ShareIdentifier = cmdletContext.ShareIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TimeoutConfig
            var requestTimeoutConfigIsNull = true;
            request.TimeoutConfig = new Amazon.Batch.Model.ServiceJobTimeout();
            System.Int32? requestTimeoutConfig_timeoutConfig_AttemptDurationSecond = null;
            if (cmdletContext.TimeoutConfig_AttemptDurationSecond != null)
            {
                requestTimeoutConfig_timeoutConfig_AttemptDurationSecond = cmdletContext.TimeoutConfig_AttemptDurationSecond.Value;
            }
            if (requestTimeoutConfig_timeoutConfig_AttemptDurationSecond != null)
            {
                request.TimeoutConfig.AttemptDurationSeconds = requestTimeoutConfig_timeoutConfig_AttemptDurationSecond.Value;
                requestTimeoutConfigIsNull = false;
            }
             // determine if request.TimeoutConfig should be set to null
            if (requestTimeoutConfigIsNull)
            {
                request.TimeoutConfig = null;
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
        
        private Amazon.Batch.Model.SubmitServiceJobResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.SubmitServiceJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "SubmitServiceJob");
            try
            {
                #if DESKTOP
                return client.SubmitServiceJob(request);
                #elif CORECLR
                return client.SubmitServiceJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String JobName { get; set; }
            public System.String JobQueue { get; set; }
            public System.Int32? RetryStrategy_Attempt { get; set; }
            public List<Amazon.Batch.Model.ServiceJobEvaluateOnExit> RetryStrategy_EvaluateOnExit { get; set; }
            public System.Int32? SchedulingPriority { get; set; }
            public Amazon.Batch.ServiceJobType ServiceJobType { get; set; }
            public System.String ServiceRequestPayload { get; set; }
            public System.String ShareIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? TimeoutConfig_AttemptDurationSecond { get; set; }
            public System.Func<Amazon.Batch.Model.SubmitServiceJobResponse, SubmitBATServiceJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
