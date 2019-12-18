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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// <important><para><i><b>Cost Category is in preview release for AWS Billing and Cost Management and
    /// is subject to change. Your use of Cost Categories is subject to the Beta Service Participation
    /// terms of the <a href="https://aws.amazon.com/service-terms/">AWS Service Terms</a>
    /// (Section 1.10).</b></i></para></important><para>
    /// Returns the name, ARN, rules, definition, and effective dates of a Cost Category that's
    /// defined in the account.
    /// </para><para>
    /// You have the option to use <code>EffectiveOn</code> to return a Cost Category that
    /// is active on a specific date. If there is no <code>EffectiveOn</code> specified, you’ll
    /// see a Cost Category that is effective on the current date. If Cost Category is still
    /// effective, <code>EffectiveEnd</code> is omitted in the response. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CECostCategoryDefinition")]
    [OutputType("Amazon.CostExplorer.Model.CostCategory")]
    [AWSCmdlet("Calls the AWS Cost Explorer DescribeCostCategoryDefinition API operation.", Operation = new[] {"DescribeCostCategoryDefinition"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.CostCategory or Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.CostCategory object.",
        "The service call response (type Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCECostCategoryDefinitionCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter CostCategoryArn
        /// <summary>
        /// <para>
        /// <para> The unique identifier for your Cost Category. </para>
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
        public System.String CostCategoryArn { get; set; }
        #endregion
        
        #region Parameter EffectiveOn
        /// <summary>
        /// <para>
        /// <para> The date when the Cost Category was effective. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EffectiveOn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CostCategory'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CostCategory";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CostCategoryArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CostCategoryArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CostCategoryArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionResponse, GetCECostCategoryDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CostCategoryArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CostCategoryArn = this.CostCategoryArn;
            #if MODULAR
            if (this.CostCategoryArn == null && ParameterWasBound(nameof(this.CostCategoryArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CostCategoryArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EffectiveOn = this.EffectiveOn;
            
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
            var request = new Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionRequest();
            
            if (cmdletContext.CostCategoryArn != null)
            {
                request.CostCategoryArn = cmdletContext.CostCategoryArn;
            }
            if (cmdletContext.EffectiveOn != null)
            {
                request.EffectiveOn = cmdletContext.EffectiveOn;
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
        
        private Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "DescribeCostCategoryDefinition");
            try
            {
                #if DESKTOP
                return client.DescribeCostCategoryDefinition(request);
                #elif CORECLR
                return client.DescribeCostCategoryDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String CostCategoryArn { get; set; }
            public System.String EffectiveOn { get; set; }
            public System.Func<Amazon.CostExplorer.Model.DescribeCostCategoryDefinitionResponse, GetCECostCategoryDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CostCategory;
        }
        
    }
}
