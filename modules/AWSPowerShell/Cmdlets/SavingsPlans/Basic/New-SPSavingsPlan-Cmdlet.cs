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
using Amazon.SavingsPlans;
using Amazon.SavingsPlans.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SP
{
    /// <summary>
    /// Creates a Savings Plan.
    /// </summary>
    [Cmdlet("New", "SPSavingsPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Savings Plans CreateSavingsPlan API operation.", Operation = new[] {"CreateSavingsPlan"}, SelectReturnType = typeof(Amazon.SavingsPlans.Model.CreateSavingsPlanResponse))]
    [AWSCmdletOutput("System.String or Amazon.SavingsPlans.Model.CreateSavingsPlanResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SavingsPlans.Model.CreateSavingsPlanResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSPSavingsPlanCmdlet : AmazonSavingsPlansClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Commitment
        /// <summary>
        /// <para>
        /// <para>The hourly commitment, in the same currency of the <c>savingsPlanOfferingId</c>. This
        /// is a value between 0.001 and 1 million. You cannot specify more than five digits after
        /// the decimal point.</para>
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
        public System.String Commitment { get; set; }
        #endregion
        
        #region Parameter PurchaseTime
        /// <summary>
        /// <para>
        /// <para>The purchase time of the Savings Plan in UTC format (YYYY-MM-DDTHH:MM:SSZ).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? PurchaseTime { get; set; }
        #endregion
        
        #region Parameter SavingsPlanOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the offering.</para>
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
        public System.String SavingsPlanOfferingId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter UpfrontPaymentAmount
        /// <summary>
        /// <para>
        /// <para>The up-front payment amount. This is a whole number between 50 and 99 percent of the
        /// total value of the Savings Plan. This parameter is only supported if the payment option
        /// is <c>Partial Upfront</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpfrontPaymentAmount { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SavingsPlanId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SavingsPlans.Model.CreateSavingsPlanResponse).
        /// Specifying the name of a property of type Amazon.SavingsPlans.Model.CreateSavingsPlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SavingsPlanId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SavingsPlanOfferingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SPSavingsPlan (CreateSavingsPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SavingsPlans.Model.CreateSavingsPlanResponse, NewSPSavingsPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Commitment = this.Commitment;
            #if MODULAR
            if (this.Commitment == null && ParameterWasBound(nameof(this.Commitment)))
            {
                WriteWarning("You are passing $null as a value for parameter Commitment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PurchaseTime = this.PurchaseTime;
            context.SavingsPlanOfferingId = this.SavingsPlanOfferingId;
            #if MODULAR
            if (this.SavingsPlanOfferingId == null && ParameterWasBound(nameof(this.SavingsPlanOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter SavingsPlanOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.UpfrontPaymentAmount = this.UpfrontPaymentAmount;
            
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
            var request = new Amazon.SavingsPlans.Model.CreateSavingsPlanRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Commitment != null)
            {
                request.Commitment = cmdletContext.Commitment;
            }
            if (cmdletContext.PurchaseTime != null)
            {
                request.PurchaseTime = cmdletContext.PurchaseTime.Value;
            }
            if (cmdletContext.SavingsPlanOfferingId != null)
            {
                request.SavingsPlanOfferingId = cmdletContext.SavingsPlanOfferingId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UpfrontPaymentAmount != null)
            {
                request.UpfrontPaymentAmount = cmdletContext.UpfrontPaymentAmount;
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
        
        private Amazon.SavingsPlans.Model.CreateSavingsPlanResponse CallAWSServiceOperation(IAmazonSavingsPlans client, Amazon.SavingsPlans.Model.CreateSavingsPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Savings Plans", "CreateSavingsPlan");
            try
            {
                return client.CreateSavingsPlanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Commitment { get; set; }
            public System.DateTime? PurchaseTime { get; set; }
            public System.String SavingsPlanOfferingId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String UpfrontPaymentAmount { get; set; }
            public System.Func<Amazon.SavingsPlans.Model.CreateSavingsPlanResponse, NewSPSavingsPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SavingsPlanId;
        }
        
    }
}
