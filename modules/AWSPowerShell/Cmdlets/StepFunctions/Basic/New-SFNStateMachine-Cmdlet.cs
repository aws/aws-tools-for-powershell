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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Creates a state machine. A state machine consists of a collection of states that can
    /// do work (<c>Task</c> states), determine to which states to transition next (<c>Choice</c>
    /// states), stop an execution with an error (<c>Fail</c> states), and so on. State machines
    /// are specified using a JSON-based, structured language. For more information, see <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-amazon-states-language.html">Amazon
    /// States Language</a> in the Step Functions User Guide.
    /// 
    ///  
    /// <para>
    /// If you set the <c>publish</c> parameter of this API action to <c>true</c>, it publishes
    /// version <c>1</c> as the first revision of the state machine.
    /// </para><para>
    ///  For additional control over security, you can encrypt your data using a <b>customer-managed
    /// key</b> for Step Functions state machines. You can configure a symmetric KMS key and
    /// data key reuse period when creating or updating a <b>State Machine</b>. The execution
    /// history and state machine definition will be encrypted with the key applied to the
    /// State Machine. 
    /// </para><note><para>
    /// This operation is eventually consistent. The results are best effort and may not reflect
    /// very recent updates and changes.
    /// </para></note><note><para><c>CreateStateMachine</c> is an idempotent API. Subsequent requests won’t create
    /// a duplicate resource if it was already created. <c>CreateStateMachine</c>'s idempotency
    /// check is based on the state machine <c>name</c>, <c>definition</c>, <c>type</c>, <c>LoggingConfiguration</c>,
    /// <c>TracingConfiguration</c>, and <c>EncryptionConfiguration</c> The check is also
    /// based on the <c>publish</c> and <c>versionDescription</c> parameters. If a following
    /// request has a different <c>roleArn</c> or <c>tags</c>, Step Functions will ignore
    /// these differences and treat it as an idempotent request of the previous. In this case,
    /// <c>roleArn</c> and <c>tags</c> will not be updated, even if they are different.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SFNStateMachine", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StepFunctions.Model.CreateStateMachineResponse")]
    [AWSCmdlet("Calls the AWS Step Functions CreateStateMachine API operation.", Operation = new[] {"CreateStateMachine"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.CreateStateMachineResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.CreateStateMachineResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.CreateStateMachineResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSFNStateMachineCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Definition
        /// <summary>
        /// <para>
        /// <para>The Amazon States Language definition of the state machine. See <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-amazon-states-language.html">Amazon
        /// States Language</a>.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the state machine. </para><para>A name must <i>not</i> contain:</para><ul><li><para>white space</para></li><li><para>brackets <c>&lt; &gt; { } [ ]</c></para></li><li><para>wildcard characters <c>? *</c></para></li><li><para>special characters <c>" # % \ ^ | ~ ` $ &amp; , ; : /</c></para></li><li><para>control characters (<c>U+0000-001F</c>, <c>U+007F-009F</c>)</para></li></ul><para>To enable logging with CloudWatch Logs, the name should only contain 0-9, A-Z, a-z,
        /// - and _.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Publish
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to publish the first version of the state machine during creation.
        /// The default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Publish { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to use for this state machine.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to be added when creating a state machine.</para><para>An array of key-value pairs. For more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html">Using
        /// Cost Allocation Tags</a> in the <i>Amazon Web Services Billing and Cost Management
        /// User Guide</i>, and <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_iam-tags.html">Controlling
        /// Access Using IAM Tags</a>.</para><para>Tags may only contain Unicode letters, digits, white space, or these symbols: <c>_
        /// . : / = + - @</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StepFunctions.Model.Tag[] Tag { get; set; }
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Determines whether a Standard or Express state machine is created. The default is
        /// <c>STANDARD</c>. You cannot update the <c>type</c> of a state machine once it has
        /// been created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.StateMachineType")]
        public Amazon.StepFunctions.StateMachineType Type { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>Sets description about the state machine version. You can only set the description
        /// if the <c>publish</c> parameter is set to <c>true</c>. Otherwise, if you set <c>versionDescription</c>,
        /// but <c>publish</c> to <c>false</c>, this API action throws <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.CreateStateMachineResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.CreateStateMachineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SFNStateMachine (CreateStateMachine)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.CreateStateMachineResponse, NewSFNStateMachineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Definition = this.Definition;
            #if MODULAR
            if (this.Definition == null && ParameterWasBound(nameof(this.Definition)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionConfiguration_KmsDataKeyReusePeriodSecond = this.EncryptionConfiguration_KmsDataKeyReusePeriodSecond;
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            if (this.LoggingConfiguration_Destination != null)
            {
                context.LoggingConfiguration_Destination = new List<Amazon.StepFunctions.Model.LogDestination>(this.LoggingConfiguration_Destination);
            }
            context.LoggingConfiguration_IncludeExecutionData = this.LoggingConfiguration_IncludeExecutionData;
            context.LoggingConfiguration_Level = this.LoggingConfiguration_Level;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Publish = this.Publish;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StepFunctions.Model.Tag>(this.Tag);
            }
            context.TracingConfiguration_Enabled = this.TracingConfiguration_Enabled;
            context.Type = this.Type;
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
            var request = new Amazon.StepFunctions.Model.CreateStateMachineRequest();
            
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Publish != null)
            {
                request.Publish = cmdletContext.Publish.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.StepFunctions.Model.CreateStateMachineResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.CreateStateMachineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "CreateStateMachine");
            try
            {
                #if DESKTOP
                return client.CreateStateMachine(request);
                #elif CORECLR
                return client.CreateStateMachineAsync(request).GetAwaiter().GetResult();
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
            public System.String Definition { get; set; }
            public System.Int32? EncryptionConfiguration_KmsDataKeyReusePeriodSecond { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public Amazon.StepFunctions.EncryptionType EncryptionConfiguration_Type { get; set; }
            public List<Amazon.StepFunctions.Model.LogDestination> LoggingConfiguration_Destination { get; set; }
            public System.Boolean? LoggingConfiguration_IncludeExecutionData { get; set; }
            public Amazon.StepFunctions.LogLevel LoggingConfiguration_Level { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? Publish { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.StepFunctions.Model.Tag> Tag { get; set; }
            public System.Boolean? TracingConfiguration_Enabled { get; set; }
            public Amazon.StepFunctions.StateMachineType Type { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.StepFunctions.Model.CreateStateMachineResponse, NewSFNStateMachineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
