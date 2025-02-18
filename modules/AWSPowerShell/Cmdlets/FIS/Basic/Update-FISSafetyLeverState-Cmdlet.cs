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
using Amazon.FIS;
using Amazon.FIS.Model;

namespace Amazon.PowerShell.Cmdlets.FIS
{
    /// <summary>
    /// Updates the specified safety lever state.
    /// </summary>
    [Cmdlet("Update", "FISSafetyLeverState", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FIS.Model.SafetyLever")]
    [AWSCmdlet("Calls the AWS Fault Injection Simulator UpdateSafetyLeverState API operation.", Operation = new[] {"UpdateSafetyLeverState"}, SelectReturnType = typeof(Amazon.FIS.Model.UpdateSafetyLeverStateResponse))]
    [AWSCmdletOutput("Amazon.FIS.Model.SafetyLever or Amazon.FIS.Model.UpdateSafetyLeverStateResponse",
        "This cmdlet returns an Amazon.FIS.Model.SafetyLever object.",
        "The service call response (type Amazon.FIS.Model.UpdateSafetyLeverStateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateFISSafetyLeverStateCmdlet : AmazonFISClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para> The ID of the safety lever. </para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter State_Reason
        /// <summary>
        /// <para>
        /// <para> The reason for updating the state of the safety lever. </para>
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
        public System.String State_Reason { get; set; }
        #endregion
        
        #region Parameter State_Status
        /// <summary>
        /// <para>
        /// <para> The updated state of the safety lever. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FIS.SafetyLeverStatusInput")]
        public Amazon.FIS.SafetyLeverStatusInput State_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SafetyLever'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FIS.Model.UpdateSafetyLeverStateResponse).
        /// Specifying the name of a property of type Amazon.FIS.Model.UpdateSafetyLeverStateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SafetyLever";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FISSafetyLeverState (UpdateSafetyLeverState)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FIS.Model.UpdateSafetyLeverStateResponse, UpdateFISSafetyLeverStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.State_Reason = this.State_Reason;
            #if MODULAR
            if (this.State_Reason == null && ParameterWasBound(nameof(this.State_Reason)))
            {
                WriteWarning("You are passing $null as a value for parameter State_Reason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.State_Status = this.State_Status;
            #if MODULAR
            if (this.State_Status == null && ParameterWasBound(nameof(this.State_Status)))
            {
                WriteWarning("You are passing $null as a value for parameter State_Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FIS.Model.UpdateSafetyLeverStateRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate State
            var requestStateIsNull = true;
            request.State = new Amazon.FIS.Model.UpdateSafetyLeverStateInput();
            System.String requestState_state_Reason = null;
            if (cmdletContext.State_Reason != null)
            {
                requestState_state_Reason = cmdletContext.State_Reason;
            }
            if (requestState_state_Reason != null)
            {
                request.State.Reason = requestState_state_Reason;
                requestStateIsNull = false;
            }
            Amazon.FIS.SafetyLeverStatusInput requestState_state_Status = null;
            if (cmdletContext.State_Status != null)
            {
                requestState_state_Status = cmdletContext.State_Status;
            }
            if (requestState_state_Status != null)
            {
                request.State.Status = requestState_state_Status;
                requestStateIsNull = false;
            }
             // determine if request.State should be set to null
            if (requestStateIsNull)
            {
                request.State = null;
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
        
        private Amazon.FIS.Model.UpdateSafetyLeverStateResponse CallAWSServiceOperation(IAmazonFIS client, Amazon.FIS.Model.UpdateSafetyLeverStateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Fault Injection Simulator", "UpdateSafetyLeverState");
            try
            {
                return client.UpdateSafetyLeverStateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String State_Reason { get; set; }
            public Amazon.FIS.SafetyLeverStatusInput State_Status { get; set; }
            public System.Func<Amazon.FIS.Model.UpdateSafetyLeverStateResponse, UpdateFISSafetyLeverStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SafetyLever;
        }
        
    }
}
