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
    /// Starts a state machine execution.
    /// 
    ///  
    /// <para>
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
    /// If you start an execution with an unqualified state machine ARN, Step Functions uses
    /// the latest revision of the state machine for the execution.
    /// </para><para>
    /// To start executions of a state machine <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-state-machine-version.html">version</a>,
    /// call <c>StartExecution</c> and provide the version ARN or the ARN of an <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-state-machine-alias.html">alias</a>
    /// that points to the version.
    /// </para><note><para><c>StartExecution</c> is idempotent for <c>STANDARD</c> workflows. For a <c>STANDARD</c>
    /// workflow, if you call <c>StartExecution</c> with the same name and input as a running
    /// execution, the call succeeds and return the same response as the original request.
    /// If the execution is closed or if the input is different, it returns a <c>400 ExecutionAlreadyExists</c>
    /// error. You can reuse names after 90 days. 
    /// </para><para><c>StartExecution</c> isn't idempotent for <c>EXPRESS</c> workflows. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "SFNExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StepFunctions.Model.StartExecutionResponse")]
    [AWSCmdlet("Calls the AWS Step Functions StartExecution API operation.", Operation = new[] {"StartExecution"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.StartExecutionResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.StartExecutionResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.StartExecutionResponse object containing multiple properties."
    )]
    public partial class StartSFNExecutionCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Input
        /// <summary>
        /// <para>
        /// <para>The string that contains the JSON input data for the execution, for example:</para><para><c>"input": "{\"first_name\" : \"test\"}"</c></para><note><para>If you don't include any JSON input data, you still must include the two braces, for
        /// example: <c>"input": "{}"</c></para></note><para>Length constraints apply to the payload size, and are expressed as bytes in UTF-8
        /// encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Optional name of the execution. This name must be unique for your Amazon Web Services
        /// account, Region, and state machine for 90 days. For more information, see <a href="https://docs.aws.amazon.com/step-functions/latest/dg/limits.html#service-limits-state-machine-executions">
        /// Limits Related to State Machine Executions</a> in the <i>Step Functions Developer
        /// Guide</i>.</para><para>If you don't provide a name for the execution, Step Functions automatically generates
        /// a universally unique identifier (UUID) as the execution name.</para><para>A name must <i>not</i> contain:</para><ul><li><para>white space</para></li><li><para>brackets <c>&lt; &gt; { } [ ]</c></para></li><li><para>wildcard characters <c>? *</c></para></li><li><para>special characters <c>" # % \ ^ | ~ ` $ &amp; , ; : /</c></para></li><li><para>control characters (<c>U+0000-001F</c>, <c>U+007F-009F</c>)</para></li></ul><para>To enable logging with CloudWatch Logs, the name should only contain 0-9, A-Z, a-z,
        /// - and _.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StateMachineArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the state machine to execute.</para><para>The <c>stateMachineArn</c> parameter accepts one of the following inputs:</para><ul><li><para><b>An unqualified state machine ARN</b> – Refers to a state machine ARN that isn't
        /// qualified with a version or alias ARN. The following is an example of an unqualified
        /// state machine ARN.</para><para><c>arn:&lt;partition&gt;:states:&lt;region&gt;:&lt;account-id&gt;:stateMachine:&lt;myStateMachine&gt;</c></para><para>Step Functions doesn't associate state machine executions that you start with an unqualified
        /// ARN with a version. This is true even if that version uses the same revision that
        /// the execution used.</para></li><li><para><b>A state machine version ARN</b> – Refers to a version ARN, which is a combination
        /// of state machine ARN and the version number separated by a colon (:). The following
        /// is an example of the ARN for version 10. </para><para><c>arn:&lt;partition&gt;:states:&lt;region&gt;:&lt;account-id&gt;:stateMachine:&lt;myStateMachine&gt;:10</c></para><para>Step Functions doesn't associate executions that you start with a version ARN with
        /// any aliases that point to that version.</para></li><li><para><b>A state machine alias ARN</b> – Refers to an alias ARN, which is a combination
        /// of state machine ARN and the alias name separated by a colon (:). The following is
        /// an example of the ARN for an alias named <c>PROD</c>.</para><para><c>arn:&lt;partition&gt;:states:&lt;region&gt;:&lt;account-id&gt;:stateMachine:&lt;myStateMachine:PROD&gt;</c></para><para>Step Functions associates executions that you start with an alias ARN with that alias
        /// and the state machine version used for that execution.</para></li></ul>
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
        
        #region Parameter TraceHeader
        /// <summary>
        /// <para>
        /// <para>Passes the X-Ray trace header. The trace header can also be passed in the request
        /// payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TraceHeader { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.StartExecutionResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.StartExecutionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StateMachineArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SFNExecution (StartExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.StartExecutionResponse, StartSFNExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Input = this.Input;
            context.Name = this.Name;
            context.StateMachineArn = this.StateMachineArn;
            #if MODULAR
            if (this.StateMachineArn == null && ParameterWasBound(nameof(this.StateMachineArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StateMachineArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TraceHeader = this.TraceHeader;
            
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
            var request = new Amazon.StepFunctions.Model.StartExecutionRequest();
            
            if (cmdletContext.Input != null)
            {
                request.Input = cmdletContext.Input;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.StateMachineArn != null)
            {
                request.StateMachineArn = cmdletContext.StateMachineArn;
            }
            if (cmdletContext.TraceHeader != null)
            {
                request.TraceHeader = cmdletContext.TraceHeader;
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
        
        private Amazon.StepFunctions.Model.StartExecutionResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.StartExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "StartExecution");
            try
            {
                #if DESKTOP
                return client.StartExecution(request);
                #elif CORECLR
                return client.StartExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.String Input { get; set; }
            public System.String Name { get; set; }
            public System.String StateMachineArn { get; set; }
            public System.String TraceHeader { get; set; }
            public System.Func<Amazon.StepFunctions.Model.StartExecutionResponse, StartSFNExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
