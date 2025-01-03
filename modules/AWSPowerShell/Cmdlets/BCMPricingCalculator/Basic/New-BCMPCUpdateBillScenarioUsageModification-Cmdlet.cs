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
    /// Update a newly added or existing usage lines. You can update the usage amounts, usage
    /// hour, and usage group based on a usage ID and a Bill scenario ID.
    /// </summary>
    [Cmdlet("New", "BCMPCUpdateBillScenarioUsageModification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationResponse")]
    [AWSCmdlet("Calls the AWS Pricing Calculator BatchUpdateBillScenarioUsageModification API operation.", Operation = new[] {"BatchUpdateBillScenarioUsageModification"}, SelectReturnType = typeof(Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationResponse))]
    [AWSCmdletOutput("Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationResponse",
        "This cmdlet returns an Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationResponse object containing multiple properties."
    )]
    public partial class NewBCMPCUpdateBillScenarioUsageModificationCmdlet : AmazonBCMPricingCalculatorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BillScenarioId
        /// <summary>
        /// <para>
        /// <para> The ID of the Bill Scenario for which you want to modify the usage lines. </para>
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
        
        #region Parameter UsageModification
        /// <summary>
        /// <para>
        /// <para> List of usage lines that you want to update in a Bill Scenario identified by the
        /// usage ID. </para>
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
        [Alias("UsageModifications")]
        public Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationEntry[] UsageModification { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationResponse).
        /// Specifying the name of a property of type Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BCMPCUpdateBillScenarioUsageModification (BatchUpdateBillScenarioUsageModification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationResponse, NewBCMPCUpdateBillScenarioUsageModificationCmdlet>(Select) ??
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
            if (this.UsageModification != null)
            {
                context.UsageModification = new List<Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationEntry>(this.UsageModification);
            }
            #if MODULAR
            if (this.UsageModification == null && ParameterWasBound(nameof(this.UsageModification)))
            {
                WriteWarning("You are passing $null as a value for parameter UsageModification which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationRequest();
            
            if (cmdletContext.BillScenarioId != null)
            {
                request.BillScenarioId = cmdletContext.BillScenarioId;
            }
            if (cmdletContext.UsageModification != null)
            {
                request.UsageModifications = cmdletContext.UsageModification;
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
        
        private Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationResponse CallAWSServiceOperation(IAmazonBCMPricingCalculator client, Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Pricing Calculator", "BatchUpdateBillScenarioUsageModification");
            try
            {
                #if DESKTOP
                return client.BatchUpdateBillScenarioUsageModification(request);
                #elif CORECLR
                return client.BatchUpdateBillScenarioUsageModificationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationEntry> UsageModification { get; set; }
            public System.Func<Amazon.BCMPricingCalculator.Model.BatchUpdateBillScenarioUsageModificationResponse, NewBCMPCUpdateBillScenarioUsageModificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
