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
using Amazon.ComputeOptimizerAutomation;
using Amazon.ComputeOptimizerAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.COA
{
    /// <summary>
    /// Initiates a one-time, on-demand automation for the specified recommended action.
    /// 
    /// 
    ///  <note><para>
    /// Management accounts and delegated administrators can only initiate recommended actions
    /// for associated member accounts. You can associate a member account using <c>AssociateAccounts</c>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "COAAutomationEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventResponse")]
    [AWSCmdlet("Calls the Compute Optimizer Automation Service StartAutomationEvent API operation.", Operation = new[] {"StartAutomationEvent"}, SelectReturnType = typeof(Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventResponse",
        "This cmdlet returns an Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventResponse object containing multiple properties."
    )]
    public partial class StartCOAAutomationEventCmdlet : AmazonComputeOptimizerAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RecommendedActionId
        /// <summary>
        /// <para>
        /// <para> The ID of the recommended action to automate. </para>
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
        public System.String RecommendedActionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Must be 1-64 characters long and contain only alphanumeric characters,
        /// underscores, and hyphens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RecommendedActionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RecommendedActionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RecommendedActionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecommendedActionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-COAAutomationEvent (StartAutomationEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventResponse, StartCOAAutomationEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RecommendedActionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.RecommendedActionId = this.RecommendedActionId;
            #if MODULAR
            if (this.RecommendedActionId == null && ParameterWasBound(nameof(this.RecommendedActionId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommendedActionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.RecommendedActionId != null)
            {
                request.RecommendedActionId = cmdletContext.RecommendedActionId;
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
        
        private Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventResponse CallAWSServiceOperation(IAmazonComputeOptimizerAutomation client, Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Compute Optimizer Automation Service", "StartAutomationEvent");
            try
            {
                #if DESKTOP
                return client.StartAutomationEvent(request);
                #elif CORECLR
                return client.StartAutomationEventAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String RecommendedActionId { get; set; }
            public System.Func<Amazon.ComputeOptimizerAutomation.Model.StartAutomationEventResponse, StartCOAAutomationEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
