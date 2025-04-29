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
using System.Threading;
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Updates the configuration of an existing state machine <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-state-machine-alias.html">alias</a>
    /// by modifying its <c>description</c> or <c>routingConfiguration</c>.
    /// 
    ///  
    /// <para>
    /// You must specify at least one of the <c>description</c> or <c>routingConfiguration</c>
    /// parameters to update a state machine alias.
    /// </para><note><para><c>UpdateStateMachineAlias</c> is an idempotent API. Step Functions bases the idempotency
    /// check on the <c>stateMachineAliasArn</c>, <c>description</c>, and <c>routingConfiguration</c>
    /// parameters. Requests with the same parameters return an idempotent response.
    /// </para></note><note><para>
    /// This operation is eventually consistent. All <a>StartExecution</a> requests made within
    /// a few seconds use the latest alias configuration. Executions started immediately after
    /// calling <c>UpdateStateMachineAlias</c> may use the previous routing configuration.
    /// </para></note><para><b>Related operations:</b></para><ul><li><para><a>CreateStateMachineAlias</a></para></li><li><para><a>DescribeStateMachineAlias</a></para></li><li><para><a>ListStateMachineAliases</a></para></li><li><para><a>DeleteStateMachineAlias</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "SFNStateMachineAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.DateTime")]
    [AWSCmdlet("Calls the AWS Step Functions UpdateStateMachineAlias API operation.", Operation = new[] {"UpdateStateMachineAlias"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.UpdateStateMachineAliasResponse))]
    [AWSCmdletOutput("System.DateTime or Amazon.StepFunctions.Model.UpdateStateMachineAliasResponse",
        "This cmdlet returns a collection of System.DateTime objects.",
        "The service call response (type Amazon.StepFunctions.Model.UpdateStateMachineAliasResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSFNStateMachineAliasCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the state machine alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RoutingConfiguration
        /// <summary>
        /// <para>
        /// <para>The routing configuration of the state machine alias.</para><para>An array of <c>RoutingConfig</c> objects that specifies up to two state machine versions
        /// that the alias starts executions for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.StepFunctions.Model.RoutingConfigurationListItem[] RoutingConfiguration { get; set; }
        #endregion
        
        #region Parameter StateMachineAliasArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the state machine alias.</para>
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
        public System.String StateMachineAliasArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UpdateDate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.UpdateStateMachineAliasResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.UpdateStateMachineAliasResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UpdateDate";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StateMachineAliasArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SFNStateMachineAlias (UpdateStateMachineAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.UpdateStateMachineAliasResponse, UpdateSFNStateMachineAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.RoutingConfiguration != null)
            {
                context.RoutingConfiguration = new List<Amazon.StepFunctions.Model.RoutingConfigurationListItem>(this.RoutingConfiguration);
            }
            context.StateMachineAliasArn = this.StateMachineAliasArn;
            #if MODULAR
            if (this.StateMachineAliasArn == null && ParameterWasBound(nameof(this.StateMachineAliasArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StateMachineAliasArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StepFunctions.Model.UpdateStateMachineAliasRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.RoutingConfiguration != null)
            {
                request.RoutingConfiguration = cmdletContext.RoutingConfiguration;
            }
            if (cmdletContext.StateMachineAliasArn != null)
            {
                request.StateMachineAliasArn = cmdletContext.StateMachineAliasArn;
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
        
        private Amazon.StepFunctions.Model.UpdateStateMachineAliasResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.UpdateStateMachineAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "UpdateStateMachineAlias");
            try
            {
                return client.UpdateStateMachineAliasAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.StepFunctions.Model.RoutingConfigurationListItem> RoutingConfiguration { get; set; }
            public System.String StateMachineAliasArn { get; set; }
            public System.Func<Amazon.StepFunctions.Model.UpdateStateMachineAliasResponse, UpdateSFNStateMachineAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UpdateDate;
        }
        
    }
}
