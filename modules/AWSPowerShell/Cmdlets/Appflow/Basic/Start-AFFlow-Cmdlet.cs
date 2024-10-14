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
using Amazon.Appflow;
using Amazon.Appflow.Model;

namespace Amazon.PowerShell.Cmdlets.AF
{
    /// <summary>
    /// Activates an existing flow. For on-demand flows, this operation runs the flow immediately.
    /// For schedule and event-triggered flows, this operation activates the flow.
    /// </summary>
    [Cmdlet("Start", "AFFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Appflow.Model.StartFlowResponse")]
    [AWSCmdlet("Calls the Amazon Appflow StartFlow API operation.", Operation = new[] {"StartFlow"}, SelectReturnType = typeof(Amazon.Appflow.Model.StartFlowResponse))]
    [AWSCmdletOutput("Amazon.Appflow.Model.StartFlowResponse",
        "This cmdlet returns an Amazon.Appflow.Model.StartFlowResponse object containing multiple properties."
    )]
    public partial class StartAFFlowCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FlowName
        /// <summary>
        /// <para>
        /// <para> The specified name of the flow. Spaces are not allowed. Use underscores (_) or hyphens
        /// (-) only. </para>
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
        public System.String FlowName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The <c>clientToken</c> parameter is an idempotency token. It ensures that your <c>StartFlow</c>
        /// request completes only once. You choose the value to pass. For example, if you don't
        /// receive a response from your request, you can safely retry the request with the same
        /// <c>clientToken</c> parameter value.</para><para>If you omit a <c>clientToken</c> value, the Amazon Web Services SDK that you are using
        /// inserts a value for you. This way, the SDK can safely retry requests multiple times
        /// after a network error. You must provide your own value for other use cases.</para><para>If you specify input parameters that differ from your first request, an error occurs
        /// for flows that run on a schedule or based on an event. However, the error doesn't
        /// occur for flows that run on demand. You set the conditions that initiate your flow
        /// for the <c>triggerConfig</c> parameter.</para><para>If you use a different value for <c>clientToken</c>, Amazon AppFlow considers it a
        /// new call to <c>StartFlow</c>. The token is active for 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.StartFlowResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.StartFlowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FlowName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FlowName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FlowName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FlowName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-AFFlow (StartFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.StartFlowResponse, StartAFFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FlowName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.FlowName = this.FlowName;
            #if MODULAR
            if (this.FlowName == null && ParameterWasBound(nameof(this.FlowName)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Appflow.Model.StartFlowRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.FlowName != null)
            {
                request.FlowName = cmdletContext.FlowName;
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
        
        private Amazon.Appflow.Model.StartFlowResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.StartFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "StartFlow");
            try
            {
                #if DESKTOP
                return client.StartFlow(request);
                #elif CORECLR
                return client.StartFlowAsync(request).GetAwaiter().GetResult();
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
            public System.String FlowName { get; set; }
            public System.Func<Amazon.Appflow.Model.StartFlowResponse, StartAFFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
