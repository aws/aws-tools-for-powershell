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
    /// Creates a <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-state-machine-version.html">version</a>
    /// from the current revision of a state machine. Use versions to create immutable snapshots
    /// of your state machine. You can start executions from versions either directly or with
    /// an alias. To create an alias, use <a>CreateStateMachineAlias</a>.
    /// 
    ///  
    /// <para>
    /// You can publish up to 1000 versions for each state machine. You must manually delete
    /// unused versions using the <a>DeleteStateMachineVersion</a> API action.
    /// </para><para><c>PublishStateMachineVersion</c> is an idempotent API. It doesn't create a duplicate
    /// state machine version if it already exists for the current revision. Step Functions
    /// bases <c>PublishStateMachineVersion</c>'s idempotency check on the <c>stateMachineArn</c>,
    /// <c>name</c>, and <c>revisionId</c> parameters. Requests with the same parameters return
    /// a successful idempotent response. If you don't specify a <c>revisionId</c>, Step Functions
    /// checks for a previously published version of the state machine's current revision.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>DeleteStateMachineVersion</a></para></li><li><para><a>ListStateMachineVersions</a></para></li></ul>
    /// </summary>
    [Cmdlet("Publish", "SFNStateMachineVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StepFunctions.Model.PublishStateMachineVersionResponse")]
    [AWSCmdlet("Calls the AWS Step Functions PublishStateMachineVersion API operation.", Operation = new[] {"PublishStateMachineVersion"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.PublishStateMachineVersionResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.PublishStateMachineVersionResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.PublishStateMachineVersionResponse object containing multiple properties."
    )]
    public partial class PublishSFNStateMachineVersionCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the state machine version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>Only publish the state machine version if the current state machine's revision ID
        /// matches the specified ID.</para><para>Use this option to avoid publishing a version if the state machine changed since you
        /// last updated it. If the specified revision ID doesn't match the state machine's current
        /// revision ID, the API returns <c>ConflictException</c>.</para><note><para>To specify an initial revision ID for a state machine with no revision ID assigned,
        /// specify the string <c>INITIAL</c> for the <c>revisionId</c> parameter. For example,
        /// you can specify a <c>revisionID</c> of <c>INITIAL</c> when you create a state machine
        /// using the <a>CreateStateMachine</a> API action.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionId { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.PublishStateMachineVersionResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.PublishStateMachineVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StateMachineArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-SFNStateMachineVersion (PublishStateMachineVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.PublishStateMachineVersionResponse, PublishSFNStateMachineVersionCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.RevisionId = this.RevisionId;
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
            var request = new Amazon.StepFunctions.Model.PublishStateMachineVersionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.RevisionId != null)
            {
                request.RevisionId = cmdletContext.RevisionId;
            }
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
        
        private Amazon.StepFunctions.Model.PublishStateMachineVersionResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.PublishStateMachineVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "PublishStateMachineVersion");
            try
            {
                #if DESKTOP
                return client.PublishStateMachineVersion(request);
                #elif CORECLR
                return client.PublishStateMachineVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String RevisionId { get; set; }
            public System.String StateMachineArn { get; set; }
            public System.Func<Amazon.StepFunctions.Model.PublishStateMachineVersionResponse, PublishSFNStateMachineVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
