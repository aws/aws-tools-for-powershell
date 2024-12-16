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
    /// An <a href="https://docs.aws.amazon.com/step-functions/latest/dg/connect-third-party-apis.html">HTTP
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
    /// </para><para><c>TestState</c> doesn't support <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-activities.html">Activity
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
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Definition
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-amazon-states-language.html">Amazon
        /// States Language</a> (ASL) definition of the state.</para>
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
            context.Definition = this.Definition;
            #if MODULAR
            if (this.Definition == null && ParameterWasBound(nameof(this.Definition)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Input = this.Input;
            context.InspectionLevel = this.InspectionLevel;
            context.RevealSecret = this.RevealSecret;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StepFunctions.Model.TestStateRequest();
            
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
            if (cmdletContext.RevealSecret != null)
            {
                request.RevealSecrets = cmdletContext.RevealSecret.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
            public System.String Definition { get; set; }
            public System.String Input { get; set; }
            public Amazon.StepFunctions.InspectionLevel InspectionLevel { get; set; }
            public System.Boolean? RevealSecret { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.StepFunctions.Model.TestStateResponse, TestSFNStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
