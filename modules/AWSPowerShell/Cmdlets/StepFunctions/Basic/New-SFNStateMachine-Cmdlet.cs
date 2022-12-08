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
    /// do work (<code>Task</code> states), determine to which states to transition next (<code>Choice</code>
    /// states), stop an execution with an error (<code>Fail</code> states), and so on. State
    /// machines are specified using a JSON-based, structured language. For more information,
    /// see <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-amazon-states-language.html">Amazon
    /// States Language</a> in the Step Functions User Guide.
    /// 
    ///  <note><para>
    /// This operation is eventually consistent. The results are best effort and may not reflect
    /// very recent updates and changes.
    /// </para></note><note><para><code>CreateStateMachine</code> is an idempotent API. Subsequent requests won’t create
    /// a duplicate resource if it was already created. <code>CreateStateMachine</code>'s
    /// idempotency check is based on the state machine <code>name</code>, <code>definition</code>,
    /// <code>type</code>, <code>LoggingConfiguration</code> and <code>TracingConfiguration</code>.
    /// If a following request has a different <code>roleArn</code> or <code>tags</code>,
    /// Step Functions will ignore these differences and treat it as an idempotent request
    /// of the previous. In this case, <code>roleArn</code> and <code>tags</code> will not
    /// be updated, even if they are different.
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
        /// Limited to size 1. Required, if your log level is not set to <code>OFF</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_Destinations")]
        public Amazon.StepFunctions.Model.LogDestination[] LoggingConfiguration_Destination { get; set; }
        #endregion
        
        #region Parameter TracingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>When set to <code>true</code>, X-Ray tracing is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TracingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_IncludeExecutionData
        /// <summary>
        /// <para>
        /// <para>Determines whether execution data is included in your log. When set to <code>false</code>,
        /// data is excluded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingConfiguration_IncludeExecutionData { get; set; }
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
        /// <para>The name of the state machine. </para><para>A name must <i>not</i> contain:</para><ul><li><para>white space</para></li><li><para>brackets <code>&lt; &gt; { } [ ]</code></para></li><li><para>wildcard characters <code>? *</code></para></li><li><para>special characters <code>" # % \ ^ | ~ ` $ &amp; , ; : /</code></para></li><li><para>control characters (<code>U+0000-001F</code>, <code>U+007F-009F</code>)</para></li></ul><para>To enable logging with CloudWatch Logs, the name should only contain 0-9, A-Z, a-z,
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
        /// Access Using IAM Tags</a>.</para><para>Tags may only contain Unicode letters, digits, white space, or these symbols: <code>_
        /// . : / = + - @</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StepFunctions.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Determines whether a Standard or Express state machine is created. The default is
        /// <code>STANDARD</code>. You cannot update the <code>type</code> of a state machine
        /// once it has been created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.StateMachineType")]
        public Amazon.StepFunctions.StateMachineType Type { get; set; }
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
            public List<Amazon.StepFunctions.Model.LogDestination> LoggingConfiguration_Destination { get; set; }
            public System.Boolean? LoggingConfiguration_IncludeExecutionData { get; set; }
            public Amazon.StepFunctions.LogLevel LoggingConfiguration_Level { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.StepFunctions.Model.Tag> Tag { get; set; }
            public System.Boolean? TracingConfiguration_Enabled { get; set; }
            public Amazon.StepFunctions.StateMachineType Type { get; set; }
            public System.Func<Amazon.StepFunctions.Model.CreateStateMachineResponse, NewSFNStateMachineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
