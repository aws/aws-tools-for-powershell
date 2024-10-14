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
    /// Cancels active runs for a flow.
    /// 
    ///  
    /// <para>
    /// You can cancel all of the active runs for a flow, or you can cancel specific runs
    /// by providing their IDs.
    /// </para><para>
    /// You can cancel a flow run only when the run is in progress. You can't cancel a run
    /// that has already completed or failed. You also can't cancel a run that's scheduled
    /// to occur but hasn't started yet. To prevent a scheduled run, you can deactivate the
    /// flow with the <c>StopFlow</c> action.
    /// </para><para>
    /// You cannot resume a run after you cancel it.
    /// </para><para>
    /// When you send your request, the status for each run becomes <c>CancelStarted</c>.
    /// When the cancellation completes, the status becomes <c>Canceled</c>.
    /// </para><note><para>
    /// When you cancel a run, you still incur charges for any data that the run already processed
    /// before the cancellation. If the run had already written some data to the flow destination,
    /// then that data remains in the destination. If you configured the flow to use a batch
    /// API (such as the Salesforce Bulk API 2.0), then the run will finish reading or writing
    /// its entire batch of data after the cancellation. For these operations, the data processing
    /// charges for Amazon AppFlow apply. For the pricing information, see <a href="http://aws.amazon.com/appflow/pricing/">Amazon
    /// AppFlow pricing</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Stop", "AFFlowExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Appflow CancelFlowExecutions API operation.", Operation = new[] {"CancelFlowExecutions"}, SelectReturnType = typeof(Amazon.Appflow.Model.CancelFlowExecutionsResponse))]
    [AWSCmdletOutput("System.String or Amazon.Appflow.Model.CancelFlowExecutionsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Appflow.Model.CancelFlowExecutionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopAFFlowExecutionCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExecutionId
        /// <summary>
        /// <para>
        /// <para>The ID of each active run to cancel. These runs must belong to the flow you specify
        /// in your request.</para><para>If you omit this parameter, your request ends all active runs that belong to the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionIds")]
        public System.String[] ExecutionId { get; set; }
        #endregion
        
        #region Parameter FlowName
        /// <summary>
        /// <para>
        /// <para>The name of a flow with active runs that you want to cancel.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvalidExecutions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.CancelFlowExecutionsResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.CancelFlowExecutionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvalidExecutions";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-AFFlowExecution (CancelFlowExecutions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.CancelFlowExecutionsResponse, StopAFFlowExecutionCmdlet>(Select) ??
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
            if (this.ExecutionId != null)
            {
                context.ExecutionId = new List<System.String>(this.ExecutionId);
            }
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
            var request = new Amazon.Appflow.Model.CancelFlowExecutionsRequest();
            
            if (cmdletContext.ExecutionId != null)
            {
                request.ExecutionIds = cmdletContext.ExecutionId;
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
        
        private Amazon.Appflow.Model.CancelFlowExecutionsResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.CancelFlowExecutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "CancelFlowExecutions");
            try
            {
                #if DESKTOP
                return client.CancelFlowExecutions(request);
                #elif CORECLR
                return client.CancelFlowExecutionsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ExecutionId { get; set; }
            public System.String FlowName { get; set; }
            public System.Func<Amazon.Appflow.Model.CancelFlowExecutionsResponse, StopAFFlowExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvalidExecutions;
        }
        
    }
}
