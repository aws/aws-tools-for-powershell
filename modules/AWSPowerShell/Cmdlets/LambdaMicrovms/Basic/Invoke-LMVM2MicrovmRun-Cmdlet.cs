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
using Amazon.LambdaMicrovms;
using Amazon.LambdaMicrovms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMVM2
{
    /// <summary>
    /// Runs a new MicroVM from the specified image. The MicroVM starts in PENDING state and
    /// transitions to RUNNING once provisioning completes. To connect, generate an authentication
    /// token using CreateMicrovmAuthToken.
    /// </summary>
    [Cmdlet("Invoke", "LMVM2MicrovmRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LambdaMicrovms.Model.RunMicrovmResponse")]
    [AWSCmdlet("Calls the Lambda MicroVMs RunMicrovm API operation.", Operation = new[] {"RunMicrovm"}, SelectReturnType = typeof(Amazon.LambdaMicrovms.Model.RunMicrovmResponse))]
    [AWSCmdletOutput("Amazon.LambdaMicrovms.Model.RunMicrovmResponse",
        "This cmdlet returns an Amazon.LambdaMicrovms.Model.RunMicrovmResponse object containing multiple properties."
    )]
    public partial class InvokeLMVM2MicrovmRunCmdlet : AmazonLambdaMicrovmsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdlePolicy_AutoResumeEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the MicroVM automatically resumes when it receives a request while
        /// suspended.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IdlePolicy_AutoResumeEnabled { get; set; }
        #endregion
        
        #region Parameter Logging_Disabled
        /// <summary>
        /// <para>
        /// <para>Specifies that logging is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LambdaMicrovms.Model.LoggingDisabled Logging_Disabled { get; set; }
        #endregion
        
        #region Parameter EgressNetworkConnector
        /// <summary>
        /// <para>
        /// <para>The list of egress network connectors to configure for the MicroVM.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EgressNetworkConnectors")]
        public System.String[] EgressNetworkConnector { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role to be assumed by the MicroVM during execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ImageIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier (ARN or ID) of the MicroVM image to run.</para>
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
        public System.String ImageIdentifier { get; set; }
        #endregion
        
        #region Parameter ImageVersion
        /// <summary>
        /// <para>
        /// <para>The version of the MicroVM image to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageVersion { get; set; }
        #endregion
        
        #region Parameter IngressNetworkConnector
        /// <summary>
        /// <para>
        /// <para>The list of ingress network connectors to configure for the MicroVM.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IngressNetworkConnectors")]
        public System.String[] IngressNetworkConnector { get; set; }
        #endregion
        
        #region Parameter Logging_CloudWatch_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log group to send logs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Logging_CloudWatch_LogGroup { get; set; }
        #endregion
        
        #region Parameter Logging_CloudWatch_LogStream
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log stream within the log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Logging_CloudWatch_LogStream { get; set; }
        #endregion
        
        #region Parameter IdlePolicy_MaxIdleDurationSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds that a MicroVM can remain idle before it is automatically
        /// suspended.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdlePolicy_MaxIdleDurationSeconds")]
        public System.Int32? IdlePolicy_MaxIdleDurationSecond { get; set; }
        #endregion
        
        #region Parameter MaximumDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum duration in seconds that the MicroVM can exist before being terminated
        /// by the platform. Valid range: 1–28,800 (8 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumDurationInSeconds")]
        public System.Int32? MaximumDurationInSecond { get; set; }
        #endregion
        
        #region Parameter RunHookPayload
        /// <summary>
        /// <para>
        /// <para>Per-MicroVM initialization data delivered as the request body of the /run lifecycle
        /// hook. Use to pass tenant-specific configuration such as session IDs or secret references.
        /// Maximum: 16,384 bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RunHookPayload { get; set; }
        #endregion
        
        #region Parameter IdlePolicy_SuspendedDurationSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds that a MicroVM can remain suspended before it is automatically
        /// terminated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdlePolicy_SuspendedDurationSeconds")]
        public System.Int32? IdlePolicy_SuspendedDurationSecond { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier you provide to ensure the idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaMicrovms.Model.RunMicrovmResponse).
        /// Specifying the name of a property of type Amazon.LambdaMicrovms.Model.RunMicrovmResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-LMVM2MicrovmRun (RunMicrovm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaMicrovms.Model.RunMicrovmResponse, InvokeLMVM2MicrovmRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.EgressNetworkConnector != null)
            {
                context.EgressNetworkConnector = new List<System.String>(this.EgressNetworkConnector);
            }
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.IdlePolicy_AutoResumeEnabled = this.IdlePolicy_AutoResumeEnabled;
            context.IdlePolicy_MaxIdleDurationSecond = this.IdlePolicy_MaxIdleDurationSecond;
            context.IdlePolicy_SuspendedDurationSecond = this.IdlePolicy_SuspendedDurationSecond;
            context.ImageIdentifier = this.ImageIdentifier;
            #if MODULAR
            if (this.ImageIdentifier == null && ParameterWasBound(nameof(this.ImageIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageVersion = this.ImageVersion;
            if (this.IngressNetworkConnector != null)
            {
                context.IngressNetworkConnector = new List<System.String>(this.IngressNetworkConnector);
            }
            context.Logging_CloudWatch_LogGroup = this.Logging_CloudWatch_LogGroup;
            context.Logging_CloudWatch_LogStream = this.Logging_CloudWatch_LogStream;
            context.Logging_Disabled = this.Logging_Disabled;
            context.MaximumDurationInSecond = this.MaximumDurationInSecond;
            context.RunHookPayload = this.RunHookPayload;
            
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
            var request = new Amazon.LambdaMicrovms.Model.RunMicrovmRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EgressNetworkConnector != null)
            {
                request.EgressNetworkConnectors = cmdletContext.EgressNetworkConnector;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate IdlePolicy
            var requestIdlePolicyIsNull = true;
            request.IdlePolicy = new Amazon.LambdaMicrovms.Model.IdlePolicy();
            System.Boolean? requestIdlePolicy_idlePolicy_AutoResumeEnabled = null;
            if (cmdletContext.IdlePolicy_AutoResumeEnabled != null)
            {
                requestIdlePolicy_idlePolicy_AutoResumeEnabled = cmdletContext.IdlePolicy_AutoResumeEnabled.Value;
            }
            if (requestIdlePolicy_idlePolicy_AutoResumeEnabled != null)
            {
                request.IdlePolicy.AutoResumeEnabled = requestIdlePolicy_idlePolicy_AutoResumeEnabled.Value;
                requestIdlePolicyIsNull = false;
            }
            System.Int32? requestIdlePolicy_idlePolicy_MaxIdleDurationSecond = null;
            if (cmdletContext.IdlePolicy_MaxIdleDurationSecond != null)
            {
                requestIdlePolicy_idlePolicy_MaxIdleDurationSecond = cmdletContext.IdlePolicy_MaxIdleDurationSecond.Value;
            }
            if (requestIdlePolicy_idlePolicy_MaxIdleDurationSecond != null)
            {
                request.IdlePolicy.MaxIdleDurationSeconds = requestIdlePolicy_idlePolicy_MaxIdleDurationSecond.Value;
                requestIdlePolicyIsNull = false;
            }
            System.Int32? requestIdlePolicy_idlePolicy_SuspendedDurationSecond = null;
            if (cmdletContext.IdlePolicy_SuspendedDurationSecond != null)
            {
                requestIdlePolicy_idlePolicy_SuspendedDurationSecond = cmdletContext.IdlePolicy_SuspendedDurationSecond.Value;
            }
            if (requestIdlePolicy_idlePolicy_SuspendedDurationSecond != null)
            {
                request.IdlePolicy.SuspendedDurationSeconds = requestIdlePolicy_idlePolicy_SuspendedDurationSecond.Value;
                requestIdlePolicyIsNull = false;
            }
             // determine if request.IdlePolicy should be set to null
            if (requestIdlePolicyIsNull)
            {
                request.IdlePolicy = null;
            }
            if (cmdletContext.ImageIdentifier != null)
            {
                request.ImageIdentifier = cmdletContext.ImageIdentifier;
            }
            if (cmdletContext.ImageVersion != null)
            {
                request.ImageVersion = cmdletContext.ImageVersion;
            }
            if (cmdletContext.IngressNetworkConnector != null)
            {
                request.IngressNetworkConnectors = cmdletContext.IngressNetworkConnector;
            }
            
             // populate Logging
            var requestLoggingIsNull = true;
            request.Logging = new Amazon.LambdaMicrovms.Model.Logging();
            Amazon.LambdaMicrovms.Model.LoggingDisabled requestLogging_logging_Disabled = null;
            if (cmdletContext.Logging_Disabled != null)
            {
                requestLogging_logging_Disabled = cmdletContext.Logging_Disabled;
            }
            if (requestLogging_logging_Disabled != null)
            {
                request.Logging.Disabled = requestLogging_logging_Disabled;
                requestLoggingIsNull = false;
            }
            Amazon.LambdaMicrovms.Model.CloudWatchLogging requestLogging_logging_CloudWatch = null;
            
             // populate CloudWatch
            var requestLogging_logging_CloudWatchIsNull = true;
            requestLogging_logging_CloudWatch = new Amazon.LambdaMicrovms.Model.CloudWatchLogging();
            System.String requestLogging_logging_CloudWatch_logging_CloudWatch_LogGroup = null;
            if (cmdletContext.Logging_CloudWatch_LogGroup != null)
            {
                requestLogging_logging_CloudWatch_logging_CloudWatch_LogGroup = cmdletContext.Logging_CloudWatch_LogGroup;
            }
            if (requestLogging_logging_CloudWatch_logging_CloudWatch_LogGroup != null)
            {
                requestLogging_logging_CloudWatch.LogGroup = requestLogging_logging_CloudWatch_logging_CloudWatch_LogGroup;
                requestLogging_logging_CloudWatchIsNull = false;
            }
            System.String requestLogging_logging_CloudWatch_logging_CloudWatch_LogStream = null;
            if (cmdletContext.Logging_CloudWatch_LogStream != null)
            {
                requestLogging_logging_CloudWatch_logging_CloudWatch_LogStream = cmdletContext.Logging_CloudWatch_LogStream;
            }
            if (requestLogging_logging_CloudWatch_logging_CloudWatch_LogStream != null)
            {
                requestLogging_logging_CloudWatch.LogStream = requestLogging_logging_CloudWatch_logging_CloudWatch_LogStream;
                requestLogging_logging_CloudWatchIsNull = false;
            }
             // determine if requestLogging_logging_CloudWatch should be set to null
            if (requestLogging_logging_CloudWatchIsNull)
            {
                requestLogging_logging_CloudWatch = null;
            }
            if (requestLogging_logging_CloudWatch != null)
            {
                request.Logging.CloudWatch = requestLogging_logging_CloudWatch;
                requestLoggingIsNull = false;
            }
             // determine if request.Logging should be set to null
            if (requestLoggingIsNull)
            {
                request.Logging = null;
            }
            if (cmdletContext.MaximumDurationInSecond != null)
            {
                request.MaximumDurationInSeconds = cmdletContext.MaximumDurationInSecond.Value;
            }
            if (cmdletContext.RunHookPayload != null)
            {
                request.RunHookPayload = cmdletContext.RunHookPayload;
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
        
        private Amazon.LambdaMicrovms.Model.RunMicrovmResponse CallAWSServiceOperation(IAmazonLambdaMicrovms client, Amazon.LambdaMicrovms.Model.RunMicrovmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Lambda MicroVMs", "RunMicrovm");
            try
            {
                return client.RunMicrovmAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> EgressNetworkConnector { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.Boolean? IdlePolicy_AutoResumeEnabled { get; set; }
            public System.Int32? IdlePolicy_MaxIdleDurationSecond { get; set; }
            public System.Int32? IdlePolicy_SuspendedDurationSecond { get; set; }
            public System.String ImageIdentifier { get; set; }
            public System.String ImageVersion { get; set; }
            public List<System.String> IngressNetworkConnector { get; set; }
            public System.String Logging_CloudWatch_LogGroup { get; set; }
            public System.String Logging_CloudWatch_LogStream { get; set; }
            public Amazon.LambdaMicrovms.Model.LoggingDisabled Logging_Disabled { get; set; }
            public System.Int32? MaximumDurationInSecond { get; set; }
            public System.String RunHookPayload { get; set; }
            public System.Func<Amazon.LambdaMicrovms.Model.RunMicrovmResponse, InvokeLMVM2MicrovmRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
