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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Updates an existing state machine by modifying its <c>definition</c>, <c>roleArn</c>,
    /// <c>loggingConfiguration</c>, or <c>EncryptionConfiguration</c>. Running executions
    /// will continue to use the previous <c>definition</c> and <c>roleArn</c>. You must include
    /// at least one of <c>definition</c> or <c>roleArn</c> or you will receive a <c>MissingRequiredParameter</c>
    /// error.
    /// 
    ///  
    /// <para>
    /// A qualified state machine ARN refers to a <i>Distributed Map state</i> defined within
    /// a state machine. For example, the qualified state machine ARN <c>arn:partition:states:region:account-id:stateMachine:stateMachineName/mapStateLabel</c>
    /// refers to a <i>Distributed Map state</i> with a label <c>mapStateLabel</c> in the
    /// state machine named <c>stateMachineName</c>.
    /// </para><para>
    /// A qualified state machine ARN can either refer to a <i>Distributed Map state</i> defined
    /// within a state machine, a version ARN, or an alias ARN.
    /// </para><para>
    /// The following are some examples of qualified and unqualified state machine ARNs:
    /// </para><ul><li><para>
    /// The following qualified state machine ARN refers to a <i>Distributed Map state</i>
    /// with a label <c>mapStateLabel</c> in a state machine named <c>myStateMachine</c>.
    /// </para><para><c>arn:partition:states:region:account-id:stateMachine:myStateMachine/mapStateLabel</c></para><note><para>
    /// If you provide a qualified state machine ARN that refers to a <i>Distributed Map state</i>,
    /// the request fails with <c>ValidationException</c>.
    /// </para></note></li><li><para>
    /// The following qualified state machine ARN refers to an alias named <c>PROD</c>.
    /// </para><para><c>arn:&lt;partition&gt;:states:&lt;region&gt;:&lt;account-id&gt;:stateMachine:&lt;myStateMachine:PROD&gt;</c></para><note><para>
    /// If you provide a qualified state machine ARN that refers to a version ARN or an alias
    /// ARN, the request starts execution for that version or alias.
    /// </para></note></li><li><para>
    /// The following unqualified state machine ARN refers to a state machine named <c>myStateMachine</c>.
    /// </para><para><c>arn:&lt;partition&gt;:states:&lt;region&gt;:&lt;account-id&gt;:stateMachine:&lt;myStateMachine&gt;</c></para></li></ul><para>
    /// After you update your state machine, you can set the <c>publish</c> parameter to <c>true</c>
    /// in the same action to publish a new <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-state-machine-version.html">version</a>.
    /// This way, you can opt-in to strict versioning of your state machine.
    /// </para><note><para>
    /// Step Functions assigns monotonically increasing integers for state machine versions,
    /// starting at version number 1.
    /// </para></note><note><para>
    /// All <c>StartExecution</c> calls within a few seconds use the updated <c>definition</c>
    /// and <c>roleArn</c>. Executions started immediately after you call <c>UpdateStateMachine</c>
    /// may use the previous state machine <c>definition</c> and <c>roleArn</c>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SFNStateMachine", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.DateTime")]
    [AWSCmdlet("Calls the AWS Step Functions UpdateStateMachine API operation.", Operation = new[] {"UpdateStateMachine"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.UpdateStateMachineResponse))]
    [AWSCmdletOutput("System.DateTime or Amazon.StepFunctions.Model.UpdateStateMachineResponse",
        "This cmdlet returns a collection of System.DateTime objects.",
        "The service call response (type Amazon.StepFunctions.Model.UpdateStateMachineResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSFNStateMachineCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Definition
        /// <summary>
        /// <para>
        /// <para>The Amazon States Language definition of the state machine. See <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-amazon-states-language.html">Amazon
        /// States Language</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Definition { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_Destination
        /// <summary>
        /// <para>
        /// <para>An array of objects that describes where your execution history events will be logged.
        /// Limited to size 1. Required, if your log level is not set to <c>OFF</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_Destinations")]
        public Amazon.StepFunctions.Model.LogDestination[] LoggingConfiguration_Destination { get; set; }
        #endregion
        
        #region Parameter TracingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>When set to <c>true</c>, X-Ray tracing is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TracingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_IncludeExecutionData
        /// <summary>
        /// <para>
        /// <para>Determines whether execution data is included in your log. When set to <c>false</c>,
        /// data is excluded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingConfiguration_IncludeExecutionData { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsDataKeyReusePeriodSecond
        /// <summary>
        /// <para>
        /// <para>Maximum duration that Step Functions will reuse data keys. When the period expires,
        /// Step Functions will call <c>GenerateDataKey</c>. Only applies to customer managed
        /// keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionConfiguration_KmsDataKeyReusePeriodSeconds")]
        public System.Int32? EncryptionConfiguration_KmsDataKeyReusePeriodSecond { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>An alias, alias ARN, key ID, or key ARN of a symmetric encryption KMS key to encrypt
        /// data. To specify a KMS key in a different Amazon Web Services account, you must use
        /// the key ARN or alias ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_Level
        /// <summary>
        /// <para>
        /// <para>Defines which category of execution history events are logged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.LogLevel")]
        public Amazon.StepFunctions.LogLevel LoggingConfiguration_Level { get; set; }
        #endregion
        
        #region Parameter Publish
        /// <summary>
        /// <para>
        /// <para>Specifies whether the state machine version is published. The default is <c>false</c>.
        /// To publish a version after updating the state machine, set <c>publish</c> to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Publish { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role of the state machine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter StateMachineArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the state machine.</para>
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
        public System.String StateMachineArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>Encryption type</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.EncryptionType")]
        public Amazon.StepFunctions.EncryptionType EncryptionConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>An optional description of the state machine version to publish.</para><para>You can only specify the <c>versionDescription</c> parameter if you've set <c>publish</c>
        /// to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UpdateDate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.UpdateStateMachineResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.UpdateStateMachineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UpdateDate";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StateMachineArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SFNStateMachine (UpdateStateMachine)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.UpdateStateMachineResponse, UpdateSFNStateMachineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Definition = this.Definition;
            context.EncryptionConfiguration_KmsDataKeyReusePeriodSecond = this.EncryptionConfiguration_KmsDataKeyReusePeriodSecond;
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            if (this.LoggingConfiguration_Destination != null)
            {
                context.LoggingConfiguration_Destination = new List<Amazon.StepFunctions.Model.LogDestination>(this.LoggingConfiguration_Destination);
            }
            context.LoggingConfiguration_IncludeExecutionData = this.LoggingConfiguration_IncludeExecutionData;
            context.LoggingConfiguration_Level = this.LoggingConfiguration_Level;
            context.Publish = this.Publish;
            context.RoleArn = this.RoleArn;
            context.StateMachineArn = this.StateMachineArn;
            #if MODULAR
            if (this.StateMachineArn == null && ParameterWasBound(nameof(this.StateMachineArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StateMachineArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TracingConfiguration_Enabled = this.TracingConfiguration_Enabled;
            context.VersionDescription = this.VersionDescription;
            
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
            var request = new Amazon.StepFunctions.Model.UpdateStateMachineRequest();
            
            if (cmdletContext.Definition != null)
            {
                request.Definition = cmdletContext.Definition;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.StepFunctions.Model.EncryptionConfiguration();
            System.Int32? requestEncryptionConfiguration_encryptionConfiguration_KmsDataKeyReusePeriodSecond = null;
            if (cmdletContext.EncryptionConfiguration_KmsDataKeyReusePeriodSecond != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsDataKeyReusePeriodSecond = cmdletContext.EncryptionConfiguration_KmsDataKeyReusePeriodSecond.Value;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsDataKeyReusePeriodSecond != null)
            {
                request.EncryptionConfiguration.KmsDataKeyReusePeriodSeconds = requestEncryptionConfiguration_encryptionConfiguration_KmsDataKeyReusePeriodSecond.Value;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = cmdletContext.EncryptionConfiguration_KmsKeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId != null)
            {
                request.EncryptionConfiguration.KmsKeyId = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.StepFunctions.EncryptionType requestEncryptionConfiguration_encryptionConfiguration_Type = null;
            if (cmdletContext.EncryptionConfiguration_Type != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_Type = cmdletContext.EncryptionConfiguration_Type;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_Type != null)
            {
                request.EncryptionConfiguration.Type = requestEncryptionConfiguration_encryptionConfiguration_Type;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.StepFunctions.Model.LoggingConfiguration();
            List<Amazon.StepFunctions.Model.LogDestination> requestLoggingConfiguration_loggingConfiguration_Destination = null;
            if (cmdletContext.LoggingConfiguration_Destination != null)
            {
                requestLoggingConfiguration_loggingConfiguration_Destination = cmdletContext.LoggingConfiguration_Destination;
            }
            if (requestLoggingConfiguration_loggingConfiguration_Destination != null)
            {
                request.LoggingConfiguration.Destinations = requestLoggingConfiguration_loggingConfiguration_Destination;
                requestLoggingConfigurationIsNull = false;
            }
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_IncludeExecutionData = null;
            if (cmdletContext.LoggingConfiguration_IncludeExecutionData != null)
            {
                requestLoggingConfiguration_loggingConfiguration_IncludeExecutionData = cmdletContext.LoggingConfiguration_IncludeExecutionData.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_IncludeExecutionData != null)
            {
                request.LoggingConfiguration.IncludeExecutionData = requestLoggingConfiguration_loggingConfiguration_IncludeExecutionData.Value;
                requestLoggingConfigurationIsNull = false;
            }
            Amazon.StepFunctions.LogLevel requestLoggingConfiguration_loggingConfiguration_Level = null;
            if (cmdletContext.LoggingConfiguration_Level != null)
            {
                requestLoggingConfiguration_loggingConfiguration_Level = cmdletContext.LoggingConfiguration_Level;
            }
            if (requestLoggingConfiguration_loggingConfiguration_Level != null)
            {
                request.LoggingConfiguration.Level = requestLoggingConfiguration_loggingConfiguration_Level;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            if (cmdletContext.Publish != null)
            {
                request.Publish = cmdletContext.Publish.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.StateMachineArn != null)
            {
                request.StateMachineArn = cmdletContext.StateMachineArn;
            }
            
             // populate TracingConfiguration
            var requestTracingConfigurationIsNull = true;
            request.TracingConfiguration = new Amazon.StepFunctions.Model.TracingConfiguration();
            System.Boolean? requestTracingConfiguration_tracingConfiguration_Enabled = null;
            if (cmdletContext.TracingConfiguration_Enabled != null)
            {
                requestTracingConfiguration_tracingConfiguration_Enabled = cmdletContext.TracingConfiguration_Enabled.Value;
            }
            if (requestTracingConfiguration_tracingConfiguration_Enabled != null)
            {
                request.TracingConfiguration.Enabled = requestTracingConfiguration_tracingConfiguration_Enabled.Value;
                requestTracingConfigurationIsNull = false;
            }
             // determine if request.TracingConfiguration should be set to null
            if (requestTracingConfigurationIsNull)
            {
                request.TracingConfiguration = null;
            }
            if (cmdletContext.VersionDescription != null)
            {
                request.VersionDescription = cmdletContext.VersionDescription;
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
        
        private Amazon.StepFunctions.Model.UpdateStateMachineResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.UpdateStateMachineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "UpdateStateMachine");
            try
            {
                return client.UpdateStateMachineAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Definition { get; set; }
            public System.Int32? EncryptionConfiguration_KmsDataKeyReusePeriodSecond { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public Amazon.StepFunctions.EncryptionType EncryptionConfiguration_Type { get; set; }
            public List<Amazon.StepFunctions.Model.LogDestination> LoggingConfiguration_Destination { get; set; }
            public System.Boolean? LoggingConfiguration_IncludeExecutionData { get; set; }
            public Amazon.StepFunctions.LogLevel LoggingConfiguration_Level { get; set; }
            public System.Boolean? Publish { get; set; }
            public System.String RoleArn { get; set; }
            public System.String StateMachineArn { get; set; }
            public System.Boolean? TracingConfiguration_Enabled { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.StepFunctions.Model.UpdateStateMachineResponse, UpdateSFNStateMachineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UpdateDate;
        }
        
    }
}
