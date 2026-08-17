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
using Amazon.Drs;
using Amazon.Drs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Reorders steps in a Recovery Plan. Accepts a complete ordered list of step ARNs.
    /// </summary>
    [Cmdlet("Set", "EDRSRecoveryPlanStepOrder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Drs.Model.RecoveryPlanStep")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service ReorderRecoveryPlanSteps API operation.", Operation = new[] {"ReorderRecoveryPlanSteps"}, SelectReturnType = typeof(Amazon.Drs.Model.ReorderRecoveryPlanStepsResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.RecoveryPlanStep or Amazon.Drs.Model.ReorderRecoveryPlanStepsResponse",
        "This cmdlet returns a collection of Amazon.Drs.Model.RecoveryPlanStep objects.",
        "The service call response (type Amazon.Drs.Model.ReorderRecoveryPlanStepsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetEDRSRecoveryPlanStepOrderCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OrderedStepArn
        /// <summary>
        /// <para>
        /// <para>Ordered list of all step ARNs representing the desired sequence.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("OrderedStepArns")]
        public System.String[] OrderedStepArn { get; set; }
        #endregion
        
        #region Parameter RecoveryPlanArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Recovery Plan.</para>
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
        public System.String RecoveryPlanArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecoveryPlanSteps'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.ReorderRecoveryPlanStepsResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.ReorderRecoveryPlanStepsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecoveryPlanSteps";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EDRSRecoveryPlanStepOrder (ReorderRecoveryPlanSteps)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.ReorderRecoveryPlanStepsResponse, SetEDRSRecoveryPlanStepOrderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.OrderedStepArn != null)
            {
                context.OrderedStepArn = new List<System.String>(this.OrderedStepArn);
            }
            #if MODULAR
            if (this.OrderedStepArn == null && ParameterWasBound(nameof(this.OrderedStepArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OrderedStepArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecoveryPlanArn = this.RecoveryPlanArn;
            #if MODULAR
            if (this.RecoveryPlanArn == null && ParameterWasBound(nameof(this.RecoveryPlanArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryPlanArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Drs.Model.ReorderRecoveryPlanStepsRequest();
            
            if (cmdletContext.OrderedStepArn != null)
            {
                request.OrderedStepArns = cmdletContext.OrderedStepArn;
            }
            if (cmdletContext.RecoveryPlanArn != null)
            {
                request.RecoveryPlanArn = cmdletContext.RecoveryPlanArn;
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
        
        private Amazon.Drs.Model.ReorderRecoveryPlanStepsResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.ReorderRecoveryPlanStepsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "ReorderRecoveryPlanSteps");
            try
            {
                return client.ReorderRecoveryPlanStepsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> OrderedStepArn { get; set; }
            public System.String RecoveryPlanArn { get; set; }
            public System.Func<Amazon.Drs.Model.ReorderRecoveryPlanStepsResponse, SetEDRSRecoveryPlanStepOrderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecoveryPlanSteps;
        }
        
    }
}
