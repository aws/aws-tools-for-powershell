/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// </summary>
    [Cmdlet("Start", "SFNExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StepFunctions.Model.StartExecutionResponse")]
    [AWSCmdlet("Calls the AWS Step Functions StartExecution API operation.", Operation = new[] {"StartExecution"})]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.StartExecutionResponse",
        "This cmdlet returns a Amazon.StepFunctions.Model.StartExecutionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartSFNExecutionCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        #region Parameter Input
        /// <summary>
        /// <para>
        /// <para>The string that contains the JSON input data for the execution, for example:</para><para><code>"input": "{\"first_name\" : \"test\"}"</code></para><note><para>If you don't include any JSON input data, you still must include the two braces, for
        /// example: <code>"input": "{}"</code></para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Input { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the execution. This name must be unique for your AWS account and region
        /// for 90 days. For more information, see <a href="http://docs.aws.amazon.com/step-functions/latest/dg/limits.html#service-limits-state-machine-executions">
        /// Limits Related to State Machine Executions</a> in the <i>AWS Step Functions Developer
        /// Guide</i>.</para><important><para>An execution can't use the name of another execution for 90 days.</para><para>When you make multiple <code>StartExecution</code> calls with the same name, the new
        /// execution doesn't run and the following rules apply:</para><ul><li><para>When the original execution is open and the execution input from the new call is <i>different</i>,
        /// the <code>ExecutionAlreadyExists</code> message is returned.</para></li><li><para>When the original execution is open and the execution input from the new call is <i>identical</i>,
        /// the <code>Success</code> message is returned.</para></li><li><para>When the original execution is closed, the <code>ExecutionAlreadyExists</code> message
        /// is returned regardless of input.</para></li></ul></important><para>A name must <i>not</i> contain:</para><ul><li><para>whitespace</para></li><li><para>brackets <code>&lt; &gt; { } [ ]</code></para></li><li><para>wildcard characters <code>? *</code></para></li><li><para>special characters <code>" # % \ ^ | ~ ` $ &amp; , ; : /</code></para></li><li><para>control characters (<code>U+0000-001F</code>, <code>U+007F-009F</code>)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StateMachineArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the state machine to execute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StateMachineArn { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StateMachineArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SFNExecution (StartExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Input = this.Input;
            context.Name = this.Name;
            context.StateMachineArn = this.StateMachineArn;
            
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartExecutionAsync(request);
                return task.Result;
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
        }
        
    }
}
