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
using Amazon.BCMPricingCalculator;
using Amazon.BCMPricingCalculator.Model;

namespace Amazon.PowerShell.Cmdlets.BCMPC
{
    /// <summary>
    /// Delete commitment that you have created in a Bill Scenario. You can only delete a
    /// commitment that you had added and cannot model deletion (or removal) of a existing
    /// commitment. If you want model deletion of an existing commitment, see the negate <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_AWSBCMPricingCalculator_BillScenarioCommitmentModificationAction.html">
    /// BillScenarioCommitmentModificationAction</a> of <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_AWSBCMPricingCalculator_BatchCreateBillScenarioUsageModification.html">
    /// BatchCreateBillScenarioCommitmentModification</a> operation.
    /// </summary>
    [Cmdlet("New", "BCMPCDeleteBillScenarioCommitmentModification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationError")]
    [AWSCmdlet("Calls the AWS Pricing Calculator BatchDeleteBillScenarioCommitmentModification API operation.", Operation = new[] {"BatchDeleteBillScenarioCommitmentModification"}, SelectReturnType = typeof(Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationResponse))]
    [AWSCmdletOutput("Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationError or Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationResponse",
        "This cmdlet returns a collection of Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationError objects.",
        "The service call response (type Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBCMPCDeleteBillScenarioCommitmentModificationCmdlet : AmazonBCMPricingCalculatorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BillScenarioId
        /// <summary>
        /// <para>
        /// <para> The ID of the Bill Scenario for which you want to delete the modeled commitment.
        /// </para>
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
        public System.String BillScenarioId { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para> List of commitments that you want to delete from the Bill Scenario. </para>
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
        [Alias("Ids")]
        public System.String[] Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Errors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationResponse).
        /// Specifying the name of a property of type Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Errors";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BillScenarioId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BillScenarioId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BillScenarioId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BillScenarioId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BCMPCDeleteBillScenarioCommitmentModification (BatchDeleteBillScenarioCommitmentModification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationResponse, NewBCMPCDeleteBillScenarioCommitmentModificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BillScenarioId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BillScenarioId = this.BillScenarioId;
            #if MODULAR
            if (this.BillScenarioId == null && ParameterWasBound(nameof(this.BillScenarioId)))
            {
                WriteWarning("You are passing $null as a value for parameter BillScenarioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Id != null)
            {
                context.Id = new List<System.String>(this.Id);
            }
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationRequest();
            
            if (cmdletContext.BillScenarioId != null)
            {
                request.BillScenarioId = cmdletContext.BillScenarioId;
            }
            if (cmdletContext.Id != null)
            {
                request.Ids = cmdletContext.Id;
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
        
        private Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationResponse CallAWSServiceOperation(IAmazonBCMPricingCalculator client, Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Pricing Calculator", "BatchDeleteBillScenarioCommitmentModification");
            try
            {
                #if DESKTOP
                return client.BatchDeleteBillScenarioCommitmentModification(request);
                #elif CORECLR
                return client.BatchDeleteBillScenarioCommitmentModificationAsync(request).GetAwaiter().GetResult();
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
            public System.String BillScenarioId { get; set; }
            public List<System.String> Id { get; set; }
            public System.Func<Amazon.BCMPricingCalculator.Model.BatchDeleteBillScenarioCommitmentModificationResponse, NewBCMPCDeleteBillScenarioCommitmentModificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Errors;
        }
        
    }
}
