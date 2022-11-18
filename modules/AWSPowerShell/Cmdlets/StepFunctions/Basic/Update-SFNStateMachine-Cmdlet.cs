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
    /// Updates an existing state machine by modifying its <code>definition</code>, <code>roleArn</code>,
    /// or <code>loggingConfiguration</code>. Running executions will continue to use the
    /// previous <code>definition</code> and <code>roleArn</code>. You must include at least
    /// one of <code>definition</code> or <code>roleArn</code> or you will receive a <code>MissingRequiredParameter</code>
    /// error.
    /// 
    ///  <note><para>
    /// All <code>StartExecution</code> calls within a few seconds will use the updated <code>definition</code>
    /// and <code>roleArn</code>. Executions started immediately after calling <code>UpdateStateMachine</code>
    /// may use the previous state machine <code>definition</code> and <code>roleArn</code>.
    /// 
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SFNStateMachine", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.DateTime")]
    [AWSCmdlet("Calls the AWS Step Functions UpdateStateMachine API operation.", Operation = new[] {"UpdateStateMachine"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.UpdateStateMachineResponse))]
    [AWSCmdletOutput("System.DateTime or Amazon.StepFunctions.Model.UpdateStateMachineResponse",
        "This cmdlet returns a System.DateTime object.",
        "The service call response (type Amazon.StepFunctions.Model.UpdateStateMachineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSFNStateMachineCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StateMachineArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StateMachineArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StateMachineArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StateMachineArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SFNStateMachine (UpdateStateMachine)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.UpdateStateMachineResponse, UpdateSFNStateMachineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StateMachineArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Definition = this.Definition;
            if (this.LoggingConfiguration_Destination != null)
            {
                context.LoggingConfiguration_Destination = new List<Amazon.StepFunctions.Model.LogDestination>(this.LoggingConfiguration_Destination);
            }
            context.LoggingConfiguration_IncludeExecutionData = this.LoggingConfiguration_IncludeExecutionData;
            context.LoggingConfiguration_Level = this.LoggingConfiguration_Level;
            context.RoleArn = this.RoleArn;
            context.StateMachineArn = this.StateMachineArn;
            #if MODULAR
            if (this.StateMachineArn == null && ParameterWasBound(nameof(this.StateMachineArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StateMachineArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TracingConfiguration_Enabled = this.TracingConfiguration_Enabled;
            
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
                #if DESKTOP
                return client.UpdateStateMachine(request);
                #elif CORECLR
                return client.UpdateStateMachineAsync(request).GetAwaiter().GetResult();
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
            public System.String RoleArn { get; set; }
            public System.String StateMachineArn { get; set; }
            public System.Boolean? TracingConfiguration_Enabled { get; set; }
            public System.Func<Amazon.StepFunctions.Model.UpdateStateMachineResponse, UpdateSFNStateMachineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UpdateDate;
        }
        
    }
}
