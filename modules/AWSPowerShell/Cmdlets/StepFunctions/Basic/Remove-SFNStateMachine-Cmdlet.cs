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
    /// Deletes a state machine. This is an asynchronous operation. It sets the state machine's
    /// status to <c>DELETING</c> and begins the deletion process. A state machine is deleted
    /// only when all its executions are completed. On the next state transition, the state
    /// machine's executions are terminated.
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
    /// The following unqualified state machine ARN refers to a state machine named <c>myStateMachine</c>.
    /// </para><para><c>arn:partition:states:region:account-id:stateMachine:myStateMachine</c></para></li></ul><para>
    /// This API action also deletes all <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-state-machine-version.html">versions</a>
    /// and <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-state-machine-alias.html">aliases</a>
    /// associated with a state machine.
    /// </para><note><para>
    /// For <c>EXPRESS</c> state machines, the deletion happens eventually (usually in less
    /// than a minute). Running executions may emit logs after <c>DeleteStateMachine</c> API
    /// is called.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "SFNStateMachine", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Step Functions DeleteStateMachine API operation.", Operation = new[] {"DeleteStateMachine"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.DeleteStateMachineResponse))]
    [AWSCmdletOutput("None or Amazon.StepFunctions.Model.DeleteStateMachineResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.StepFunctions.Model.DeleteStateMachineResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSFNStateMachineCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StateMachineArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the state machine to delete.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.DeleteStateMachineResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SFNStateMachine (DeleteStateMachine)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.DeleteStateMachineResponse, RemoveSFNStateMachineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StateMachineArn = this.StateMachineArn;
            #if MODULAR
            if (this.StateMachineArn == null && ParameterWasBound(nameof(this.StateMachineArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StateMachineArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StepFunctions.Model.DeleteStateMachineRequest();
            
            if (cmdletContext.StateMachineArn != null)
            {
                request.StateMachineArn = cmdletContext.StateMachineArn;
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
        
        private Amazon.StepFunctions.Model.DeleteStateMachineResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.DeleteStateMachineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "DeleteStateMachine");
            try
            {
                #if DESKTOP
                return client.DeleteStateMachine(request);
                #elif CORECLR
                return client.DeleteStateMachineAsync(request).GetAwaiter().GetResult();
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
            public System.String StateMachineArn { get; set; }
            public System.Func<Amazon.StepFunctions.Model.DeleteStateMachineResponse, RemoveSFNStateMachineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
