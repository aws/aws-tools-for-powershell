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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// Associates a batch of resources to a percentage custom line item.
    /// </summary>
    [Cmdlet("Register", "ABCResourceBatchToCustomLineItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemResponse")]
    [AWSCmdlet("Calls the AWSBillingConductor BatchAssociateResourcesToCustomLineItem API operation.", Operation = new[] {"BatchAssociateResourcesToCustomLineItem"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemResponse",
        "This cmdlet returns an Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemResponse object containing multiple properties."
    )]
    public partial class RegisterABCResourceBatchToCustomLineItemCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BillingPeriodRange_ExclusiveEndBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The inclusive end billing period that defines a billing period range where a custom
        /// line is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingPeriodRange_ExclusiveEndBillingPeriod { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_InclusiveStartBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The inclusive start billing period that defines a billing period range where a custom
        /// line is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingPeriodRange_InclusiveStartBillingPeriod { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para> A list containing the ARNs of the resources to be associated. </para>
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
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para> A percentage custom line item ARN to associate the resources to. </para>
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
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-ABCResourceBatchToCustomLineItem (BatchAssociateResourcesToCustomLineItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemResponse, RegisterABCResourceBatchToCustomLineItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BillingPeriodRange_ExclusiveEndBillingPeriod = this.BillingPeriodRange_ExclusiveEndBillingPeriod;
            context.BillingPeriodRange_InclusiveStartBillingPeriod = this.BillingPeriodRange_InclusiveStartBillingPeriod;
            if (this.ResourceArn != null)
            {
                context.ResourceArn = new List<System.String>(this.ResourceArn);
            }
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetArn = this.TargetArn;
            #if MODULAR
            if (this.TargetArn == null && ParameterWasBound(nameof(this.TargetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemRequest();
            
            
             // populate BillingPeriodRange
            var requestBillingPeriodRangeIsNull = true;
            request.BillingPeriodRange = new Amazon.BillingConductor.Model.CustomLineItemBillingPeriodRange();
            System.String requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_ExclusiveEndBillingPeriod != null)
            {
                requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod = cmdletContext.BillingPeriodRange_ExclusiveEndBillingPeriod;
            }
            if (requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod != null)
            {
                request.BillingPeriodRange.ExclusiveEndBillingPeriod = requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod;
                requestBillingPeriodRangeIsNull = false;
            }
            System.String requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_InclusiveStartBillingPeriod != null)
            {
                requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod = cmdletContext.BillingPeriodRange_InclusiveStartBillingPeriod;
            }
            if (requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod != null)
            {
                request.BillingPeriodRange.InclusiveStartBillingPeriod = requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod;
                requestBillingPeriodRangeIsNull = false;
            }
             // determine if request.BillingPeriodRange should be set to null
            if (requestBillingPeriodRangeIsNull)
            {
                request.BillingPeriodRange = null;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
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
        
        private Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "BatchAssociateResourcesToCustomLineItem");
            try
            {
                #if DESKTOP
                return client.BatchAssociateResourcesToCustomLineItem(request);
                #elif CORECLR
                return client.BatchAssociateResourcesToCustomLineItemAsync(request).GetAwaiter().GetResult();
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
            public System.String BillingPeriodRange_ExclusiveEndBillingPeriod { get; set; }
            public System.String BillingPeriodRange_InclusiveStartBillingPeriod { get; set; }
            public List<System.String> ResourceArn { get; set; }
            public System.String TargetArn { get; set; }
            public System.Func<Amazon.BillingConductor.Model.BatchAssociateResourcesToCustomLineItemResponse, RegisterABCResourceBatchToCustomLineItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
