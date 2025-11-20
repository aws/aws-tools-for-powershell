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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Accepts the definition of a single state and executes it. You can test a state without
    /// creating a state machine or updating an existing state machine. Using this API, you
    /// can test the following:
    /// 
    ///  <ul><li><para>
    /// A state's <a href="https://docs.aws.amazon.com/step-functions/latest/dg/test-state-isolation.html#test-state-input-output-dataflow">input
    /// and output processing</a> data flow
    /// </para></li><li><para>
    /// An <a href="https://docs.aws.amazon.com/step-functions/latest/dg/connect-to-services.html">Amazon
    /// Web Services service integration</a> request and response
    /// </para></li><li><para>
    /// An <a href="https://docs.aws.amazon.com/step-functions/latest/dg/call-https-apis.html">HTTP
    /// Task</a> request and response
    /// </para></li></ul><para>
    /// You can call this API on only one state at a time. The states that you can test include
    /// the following:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-task-state.html#task-types">All
    /// Task types</a> except <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-activities.html">Activity</a></para></li><li><para><a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-pass-state.html">Pass</a></para></li><li><para><a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-wait-state.html">Wait</a></para></li><li><para><a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-choice-state.html">Choice</a></para></li><li><para><a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-succeed-state.html">Succeed</a></para></li><li><para><a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-fail-state.html">Fail</a></para></li></ul><para>
    /// The <c>TestState</c> API assumes an IAM role which must contain the required IAM permissions
    /// for the resources your state is accessing. For information about the permissions a
    /// state might need, see <a href="https://docs.aws.amazon.com/step-functions/latest/dg/test-state-isolation.html#test-state-permissions">IAM
    /// permissions to test a state</a>.
    /// </para><para>
    /// The <c>TestState</c> API can run for up to five minutes. If the execution of a state
    /// exceeds this duration, it fails with the <c>States.Timeout</c> error.
    /// </para><para><c>TestState</c> only supports the following when a mock is specified: <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-activities.html">Activity
    /// tasks</a>, <c>.sync</c> or <c>.waitForTaskToken</c><a href="https://docs.aws.amazon.com/step-functions/latest/dg/connect-to-resource.html">service
    /// integration patterns</a>, <a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-parallel-state.html">Parallel</a>,
    /// or <a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-map-state.html">Map</a>
    /// states.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "SFNState")]
    [OutputType("Amazon.StepFunctions.Model.TestStateResponse")]
    [AWSCmdlet("Calls the AWS Step Functions TestState API operation.", Operation = new[] {"TestState"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.TestStateResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.TestStateResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.TestStateResponse object containing multiple properties."
    )]
    public partial class TestSFNStateCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ErrorOutput_Cause
        /// <summary>
        /// <para>
        /// <para>A string containing the cause of the exception thrown when executing the state's logic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Mock_ErrorOutput_Cause")]
        public System.String ErrorOutput_Cause { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>A JSON string representing a valid Context object for the state under test. This field
        /// may only be specified if a mock is specified in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context { get; set; }
        #endregion
        
        #region Parameter Definition
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-amazon-states-language.html">Amazon
        /// States Language</a> (ASL) definition of the state or state machine.</para>
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
        
        #region Parameter ErrorOutput_Error
        /// <summary>
        /// <para>
        /// <para>A string denoting the error code of the exception thrown when invoking the tested
        /// state. This field is required if <c>mock.errorOutput</c> is specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Mock_ErrorOutput_Error")]
        public System.String ErrorOutput_Error { get; set; }
        #endregion
        
        #region Parameter StateConfiguration_ErrorCausedByState
        /// <summary>
        /// <para>
        /// <para>The name of the state from which an error originates when an error is mocked for a
        /// Map or Parallel state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StateConfiguration_ErrorCausedByState { get; set; }
        #endregion
        
        #region Parameter Mock_FieldValidationMode
        /// <summary>
        /// <para>
        /// <para>Determines the level of strictness when validating mocked results against their respective
        /// API models. Values include:</para><ul><li><para><c>STRICT</c>: All required fields must be present, and all present fields must conform
        /// to the API's schema.</para></li><li><para><c>PRESENT</c>: All present fields must conform to the API's schema.</para></li><li><para><c>NONE</c>: No validation is performed.</para></li></ul><para>If no value is specified, the default value is <c>STRICT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.MockResponseValidationMode")]
        public Amazon.StepFunctions.MockResponseValidationMode Mock_FieldValidationMode { get; set; }
        #endregion
        
        #region Parameter Input
        /// <summary>
        /// <para>
        /// <para>A string that contains the JSON input data for the state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input { get; set; }
        #endregion
        
        #region Parameter InspectionLevel
        /// <summary>
        /// <para>
        /// <para>Determines the values to return when a state is tested. You can specify one of the
        /// following types:</para><ul><li><para><c>INFO</c>: Shows the final state output. By default, Step Functions sets <c>inspectionLevel</c>
        /// to <c>INFO</c> if you don't specify a level.</para></li><li><para><c>DEBUG</c>: Shows the final state output along with the input and output data processing
        /// result.</para></li><li><para><c>TRACE</c>: Shows the HTTP request and response for an HTTP Task. This level also
        /// shows the final state output along with the input and output data processing result.</para></li></ul><para>Each of these levels also provide information about the status of the state execution
        /// and the next state to transition to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.InspectionLevel")]
        public Amazon.StepFunctions.InspectionLevel InspectionLevel { get; set; }
        #endregion
        
        #region Parameter StateConfiguration_MapItemReaderData
        /// <summary>
        /// <para>
        /// <para>The data read by ItemReader in Distributed Map states as found in its original source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StateConfiguration_MapItemReaderData { get; set; }
        #endregion
        
        #region Parameter StateConfiguration_MapIterationFailureCount
        /// <summary>
        /// <para>
        /// <para>The number of Map state iterations that failed during the Map state invocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StateConfiguration_MapIterationFailureCount { get; set; }
        #endregion
        
        #region Parameter Mock_Result
        /// <summary>
        /// <para>
        /// <para>A JSON string containing the mocked result of the state invocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Mock_Result { get; set; }
        #endregion
        
        #region Parameter StateConfiguration_RetrierRetryCount
        /// <summary>
        /// <para>
        /// <para>The number of retry attempts that have occurred for the state's Retry that applies
        /// to the mocked error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StateConfiguration_RetrierRetryCount { get; set; }
        #endregion
        
        #region Parameter RevealSecret
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not to include secret information in the test result. For HTTP
        /// Tasks, a secret includes the data that an EventBridge connection adds to modify the
        /// HTTP request headers, query parameters, and body. Step Functions doesn't omit any
        /// information included in the state definition or the HTTP response.</para><para>If you set <c>revealSecrets</c> to <c>true</c>, you must make sure that the IAM user
        /// that calls the <c>TestState</c> API has permission for the <c>states:RevealSecrets</c>
        /// action. For an example of IAM policy that sets the <c>states:RevealSecrets</c> permission,
        /// see <a href="https://docs.aws.amazon.com/step-functions/latest/dg/test-state-isolation.html#test-state-permissions">IAM
        /// permissions to test a state</a>. Without this permission, Step Functions throws an
        /// access denied error.</para><para>By default, <c>revealSecrets</c> is set to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RevealSecrets")]
        public System.Boolean? RevealSecret { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the execution role with the required IAM permissions
        /// for the state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter StateName
        /// <summary>
        /// <para>
        /// <para>Denotes the particular state within a state machine definition to be tested. If this
        /// field is specified, the <c>definition</c> must contain a fully-formed state machine
        /// definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StateName { get; set; }
        #endregion
        
        #region Parameter Variable
        /// <summary>
        /// <para>
        /// <para>JSON object literal that sets variables used in the state under test. Object keys
        /// are the variable names and values are the variable values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Variables")]
        public System.String Variable { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.TestStateResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.TestStateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.TestStateResponse, TestSFNStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Context = this.Context;
            context.Definition = this.Definition;
            #if MODULAR
            if (this.Definition == null && ParameterWasBound(nameof(this.Definition)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Input = this.Input;
            context.InspectionLevel = this.InspectionLevel;
            context.ErrorOutput_Cause = this.ErrorOutput_Cause;
            context.ErrorOutput_Error = this.ErrorOutput_Error;
            context.Mock_FieldValidationMode = this.Mock_FieldValidationMode;
            context.Mock_Result = this.Mock_Result;
            context.RevealSecret = this.RevealSecret;
            context.RoleArn = this.RoleArn;
            context.StateConfiguration_ErrorCausedByState = this.StateConfiguration_ErrorCausedByState;
            context.StateConfiguration_MapItemReaderData = this.StateConfiguration_MapItemReaderData;
            context.StateConfiguration_MapIterationFailureCount = this.StateConfiguration_MapIterationFailureCount;
            context.StateConfiguration_RetrierRetryCount = this.StateConfiguration_RetrierRetryCount;
            context.StateName = this.StateName;
            context.Variable = this.Variable;
            
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
            var request = new Amazon.StepFunctions.Model.TestStateRequest();
            
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.Definition != null)
            {
                request.Definition = cmdletContext.Definition;
            }
            if (cmdletContext.Input != null)
            {
                request.Input = cmdletContext.Input;
            }
            if (cmdletContext.InspectionLevel != null)
            {
                request.InspectionLevel = cmdletContext.InspectionLevel;
            }
            
             // populate Mock
            var requestMockIsNull = true;
            request.Mock = new Amazon.StepFunctions.Model.MockInput();
            Amazon.StepFunctions.MockResponseValidationMode requestMock_mock_FieldValidationMode = null;
            if (cmdletContext.Mock_FieldValidationMode != null)
            {
                requestMock_mock_FieldValidationMode = cmdletContext.Mock_FieldValidationMode;
            }
            if (requestMock_mock_FieldValidationMode != null)
            {
                request.Mock.FieldValidationMode = requestMock_mock_FieldValidationMode;
                requestMockIsNull = false;
            }
            System.String requestMock_mock_Result = null;
            if (cmdletContext.Mock_Result != null)
            {
                requestMock_mock_Result = cmdletContext.Mock_Result;
            }
            if (requestMock_mock_Result != null)
            {
                request.Mock.Result = requestMock_mock_Result;
                requestMockIsNull = false;
            }
            Amazon.StepFunctions.Model.MockErrorOutput requestMock_mock_ErrorOutput = null;
            
             // populate ErrorOutput
            var requestMock_mock_ErrorOutputIsNull = true;
            requestMock_mock_ErrorOutput = new Amazon.StepFunctions.Model.MockErrorOutput();
            System.String requestMock_mock_ErrorOutput_errorOutput_Cause = null;
            if (cmdletContext.ErrorOutput_Cause != null)
            {
                requestMock_mock_ErrorOutput_errorOutput_Cause = cmdletContext.ErrorOutput_Cause;
            }
            if (requestMock_mock_ErrorOutput_errorOutput_Cause != null)
            {
                requestMock_mock_ErrorOutput.Cause = requestMock_mock_ErrorOutput_errorOutput_Cause;
                requestMock_mock_ErrorOutputIsNull = false;
            }
            System.String requestMock_mock_ErrorOutput_errorOutput_Error = null;
            if (cmdletContext.ErrorOutput_Error != null)
            {
                requestMock_mock_ErrorOutput_errorOutput_Error = cmdletContext.ErrorOutput_Error;
            }
            if (requestMock_mock_ErrorOutput_errorOutput_Error != null)
            {
                requestMock_mock_ErrorOutput.Error = requestMock_mock_ErrorOutput_errorOutput_Error;
                requestMock_mock_ErrorOutputIsNull = false;
            }
             // determine if requestMock_mock_ErrorOutput should be set to null
            if (requestMock_mock_ErrorOutputIsNull)
            {
                requestMock_mock_ErrorOutput = null;
            }
            if (requestMock_mock_ErrorOutput != null)
            {
                request.Mock.ErrorOutput = requestMock_mock_ErrorOutput;
                requestMockIsNull = false;
            }
             // determine if request.Mock should be set to null
            if (requestMockIsNull)
            {
                request.Mock = null;
            }
            if (cmdletContext.RevealSecret != null)
            {
                request.RevealSecrets = cmdletContext.RevealSecret.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StateConfiguration
            var requestStateConfigurationIsNull = true;
            request.StateConfiguration = new Amazon.StepFunctions.Model.TestStateConfiguration();
            System.String requestStateConfiguration_stateConfiguration_ErrorCausedByState = null;
            if (cmdletContext.StateConfiguration_ErrorCausedByState != null)
            {
                requestStateConfiguration_stateConfiguration_ErrorCausedByState = cmdletContext.StateConfiguration_ErrorCausedByState;
            }
            if (requestStateConfiguration_stateConfiguration_ErrorCausedByState != null)
            {
                request.StateConfiguration.ErrorCausedByState = requestStateConfiguration_stateConfiguration_ErrorCausedByState;
                requestStateConfigurationIsNull = false;
            }
            System.String requestStateConfiguration_stateConfiguration_MapItemReaderData = null;
            if (cmdletContext.StateConfiguration_MapItemReaderData != null)
            {
                requestStateConfiguration_stateConfiguration_MapItemReaderData = cmdletContext.StateConfiguration_MapItemReaderData;
            }
            if (requestStateConfiguration_stateConfiguration_MapItemReaderData != null)
            {
                request.StateConfiguration.MapItemReaderData = requestStateConfiguration_stateConfiguration_MapItemReaderData;
                requestStateConfigurationIsNull = false;
            }
            System.Int32? requestStateConfiguration_stateConfiguration_MapIterationFailureCount = null;
            if (cmdletContext.StateConfiguration_MapIterationFailureCount != null)
            {
                requestStateConfiguration_stateConfiguration_MapIterationFailureCount = cmdletContext.StateConfiguration_MapIterationFailureCount.Value;
            }
            if (requestStateConfiguration_stateConfiguration_MapIterationFailureCount != null)
            {
                request.StateConfiguration.MapIterationFailureCount = requestStateConfiguration_stateConfiguration_MapIterationFailureCount.Value;
                requestStateConfigurationIsNull = false;
            }
            System.Int32? requestStateConfiguration_stateConfiguration_RetrierRetryCount = null;
            if (cmdletContext.StateConfiguration_RetrierRetryCount != null)
            {
                requestStateConfiguration_stateConfiguration_RetrierRetryCount = cmdletContext.StateConfiguration_RetrierRetryCount.Value;
            }
            if (requestStateConfiguration_stateConfiguration_RetrierRetryCount != null)
            {
                request.StateConfiguration.RetrierRetryCount = requestStateConfiguration_stateConfiguration_RetrierRetryCount.Value;
                requestStateConfigurationIsNull = false;
            }
             // determine if request.StateConfiguration should be set to null
            if (requestStateConfigurationIsNull)
            {
                request.StateConfiguration = null;
            }
            if (cmdletContext.StateName != null)
            {
                request.StateName = cmdletContext.StateName;
            }
            if (cmdletContext.Variable != null)
            {
                request.Variables = cmdletContext.Variable;
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
        
        private Amazon.StepFunctions.Model.TestStateResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.TestStateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "TestState");
            try
            {
                #if DESKTOP
                return client.TestState(request);
                #elif CORECLR
                return client.TestStateAsync(request).GetAwaiter().GetResult();
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
            public System.String Context { get; set; }
            public System.String Definition { get; set; }
            public System.String Input { get; set; }
            public Amazon.StepFunctions.InspectionLevel InspectionLevel { get; set; }
            public System.String ErrorOutput_Cause { get; set; }
            public System.String ErrorOutput_Error { get; set; }
            public Amazon.StepFunctions.MockResponseValidationMode Mock_FieldValidationMode { get; set; }
            public System.String Mock_Result { get; set; }
            public System.Boolean? RevealSecret { get; set; }
            public System.String RoleArn { get; set; }
            public System.String StateConfiguration_ErrorCausedByState { get; set; }
            public System.String StateConfiguration_MapItemReaderData { get; set; }
            public System.Int32? StateConfiguration_MapIterationFailureCount { get; set; }
            public System.Int32? StateConfiguration_RetrierRetryCount { get; set; }
            public System.String StateName { get; set; }
            public System.String Variable { get; set; }
            public System.Func<Amazon.StepFunctions.Model.TestStateResponse, TestSFNStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
