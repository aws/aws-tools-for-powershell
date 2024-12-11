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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// A list of the pricing plans that are associated with a pricing rule.
    /// </summary>
    [Cmdlet("Get", "ABCPricingPlansAssociatedWithPricingRuleList")]
    [OutputType("Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleResponse")]
    [AWSCmdlet("Calls the AWSBillingConductor ListPricingPlansAssociatedWithPricingRule API operation.", Operation = new[] {"ListPricingPlansAssociatedWithPricingRule"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleResponse",
        "This cmdlet returns an Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleResponse object containing multiple properties."
    )]
    public partial class GetABCPricingPlansAssociatedWithPricingRuleListCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BillingPeriod
        /// <summary>
        /// <para>
        /// <para> The pricing plan billing period for which associations will be listed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingPeriod { get; set; }
        #endregion
        
        #region Parameter PricingRuleArn
        /// <summary>
        /// <para>
        /// <para> The pricing rule Amazon Resource Name (ARN) for which associations will be listed.
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
        public System.String PricingRuleArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The optional maximum number of pricing rule associations to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The optional pagination token returned by a previous call. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleResponse, GetABCPricingPlansAssociatedWithPricingRuleListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingPeriod = this.BillingPeriod;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PricingRuleArn = this.PricingRuleArn;
            #if MODULAR
            if (this.PricingRuleArn == null && ParameterWasBound(nameof(this.PricingRuleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PricingRuleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleRequest();
            
            if (cmdletContext.BillingPeriod != null)
            {
                request.BillingPeriod = cmdletContext.BillingPeriod;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PricingRuleArn != null)
            {
                request.PricingRuleArn = cmdletContext.PricingRuleArn;
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
        
        private Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListPricingPlansAssociatedWithPricingRule");
            try
            {
                #if DESKTOP
                return client.ListPricingPlansAssociatedWithPricingRule(request);
                #elif CORECLR
                return client.ListPricingPlansAssociatedWithPricingRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String BillingPeriod { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PricingRuleArn { get; set; }
            public System.Func<Amazon.BillingConductor.Model.ListPricingPlansAssociatedWithPricingRuleResponse, GetABCPricingPlansAssociatedWithPricingRuleListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
