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
    /// Validates the syntax of a state machine definition specified in <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-amazon-states-language.html">Amazon
    /// States Language</a> (ASL), a JSON-based, structured language.
    /// 
    ///  
    /// <para>
    /// You can validate that a state machine definition is correct without creating a state
    /// machine resource.
    /// </para><para>
    /// Suggested uses for <c>ValidateStateMachineDefinition</c>:
    /// </para><ul><li><para>
    /// Integrate automated checks into your code review or Continuous Integration (CI) process
    /// to check state machine definitions before starting deployments.
    /// </para></li><li><para>
    /// Run validation from a Git pre-commit hook to verify the definition before committing
    /// to your source repository.
    /// </para></li></ul><para>
    /// Validation will look for problems in your state machine definition and return a <b>result</b>
    /// and a list of <b>diagnostic elements</b>.
    /// </para><para>
    /// The <b>result</b> value will be <c>OK</c> when your workflow definition can be successfully
    /// created or updated. Note the result can be <c>OK</c> even when diagnostic warnings
    /// are present in the response. The <b>result</b> value will be <c>FAIL</c> when the
    /// workflow definition contains errors that would prevent you from creating or updating
    /// your state machine. 
    /// </para><para>
    /// The list of <a href="https://docs.aws.amazon.com/step-functions/latest/apireference/API_ValidateStateMachineDefinitionDiagnostic.html">ValidateStateMachineDefinitionDiagnostic</a>
    /// data elements can contain zero or more <b>WARNING</b> and/or <b>ERROR</b> elements.
    /// </para><note><para>
    /// The <b>ValidateStateMachineDefinition API</b> might add new diagnostics in the future,
    /// adjust diagnostic codes, or change the message wording. Your automated processes should
    /// only rely on the value of the <b>result</b> field value (OK, FAIL). Do <b>not</b>
    /// rely on the exact order, count, or wording of diagnostic messages.
    /// </para></note>
    /// </summary>
    [Cmdlet("Test", "SFNStateMachineDefinitionValidation")]
    [OutputType("Amazon.StepFunctions.Model.ValidateStateMachineDefinitionResponse")]
    [AWSCmdlet("Calls the AWS Step Functions ValidateStateMachineDefinition API operation.", Operation = new[] {"ValidateStateMachineDefinition"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.ValidateStateMachineDefinitionResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.ValidateStateMachineDefinitionResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.ValidateStateMachineDefinitionResponse object containing multiple properties."
    )]
    public partial class TestSFNStateMachineDefinitionValidationCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Definition
        /// <summary>
        /// <para>
        /// <para>The Amazon States Language definition of the state machine. For more information,
        /// see <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-amazon-states-language.html">Amazon
        /// States Language</a> (ASL).</para>
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
        public System.String Definition { get; set; }
        #endregion
        
        #region Parameter Severity
        /// <summary>
        /// <para>
        /// <para>Minimum level of diagnostics to return. <c>ERROR</c> returns only <c>ERROR</c> diagnostics,
        /// whereas <c>WARNING</c> returns both <c>WARNING</c> and <c>ERROR</c> diagnostics. The
        /// default is <c>ERROR</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.ValidateStateMachineDefinitionSeverity")]
        public Amazon.StepFunctions.ValidateStateMachineDefinitionSeverity Severity { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The target type of state machine for this definition. The default is <c>STANDARD</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.StateMachineType")]
        public Amazon.StepFunctions.StateMachineType Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of diagnostics that are returned per call. The default and maximum
        /// value is 100. Setting the value to 0 will also use the default of 100.</para><para>If the number of diagnostics returned in the response exceeds <c>maxResults</c>, the
        /// value of the <c>truncated</c> field in the response will be set to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.ValidateStateMachineDefinitionResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.ValidateStateMachineDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Definition parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Definition' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Definition' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.ValidateStateMachineDefinitionResponse, TestSFNStateMachineDefinitionValidationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Definition;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Definition = this.Definition;
            #if MODULAR
            if (this.Definition == null && ParameterWasBound(nameof(this.Definition)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.Severity = this.Severity;
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
            var request = new Amazon.StepFunctions.Model.ValidateStateMachineDefinitionRequest();
            
            if (cmdletContext.Definition != null)
            {
                request.Definition = cmdletContext.Definition;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Severity != null)
            {
                request.Severity = cmdletContext.Severity;
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
        
        private Amazon.StepFunctions.Model.ValidateStateMachineDefinitionResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.ValidateStateMachineDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "ValidateStateMachineDefinition");
            try
            {
                #if DESKTOP
                return client.ValidateStateMachineDefinition(request);
                #elif CORECLR
                return client.ValidateStateMachineDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public Amazon.StepFunctions.ValidateStateMachineDefinitionSeverity Severity { get; set; }
            public Amazon.StepFunctions.StateMachineType Type { get; set; }
            public System.Func<Amazon.StepFunctions.Model.ValidateStateMachineDefinitionResponse, TestSFNStateMachineDefinitionValidationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
