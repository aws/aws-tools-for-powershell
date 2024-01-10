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
using Amazon.Pricing;
using Amazon.Pricing.Model;

namespace Amazon.PowerShell.Cmdlets.PLS
{
    /// <summary>
    /// <i><b>This feature is in preview release and is subject to change. Your use of Amazon
    /// Web Services Price List API is subject to the Beta Service Participation terms of
    /// the <a href="https://aws.amazon.com/service-terms/">Amazon Web Services Service Terms</a>
    /// (Section 1.10).</b></i><para>
    /// This returns the URL that you can retrieve your Price List file from. This URL is
    /// based on the <c>PriceListArn</c> and <c>FileFormat</c> that you retrieve from the
    /// <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_pricing_ListPriceLists.html">ListPriceLists</a>
    /// response. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PLSPriceListFileUrl")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Price List Service GetPriceListFileUrl API operation.", Operation = new[] {"GetPriceListFileUrl"}, SelectReturnType = typeof(Amazon.Pricing.Model.GetPriceListFileUrlResponse))]
    [AWSCmdletOutput("System.String or Amazon.Pricing.Model.GetPriceListFileUrlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Pricing.Model.GetPriceListFileUrlResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPLSPriceListFileUrlCmdlet : AmazonPricingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FileFormat
        /// <summary>
        /// <para>
        /// <para>The format that you want to retrieve your Price List files in. The <c>FileFormat</c>
        /// can be obtained from the <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_pricing_ListPriceLists.html">ListPriceLists</a>
        /// response. </para>
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
        public System.String FileFormat { get; set; }
        #endregion
        
        #region Parameter PriceListArn
        /// <summary>
        /// <para>
        /// <para>The unique identifier that maps to where your Price List files are located. <c>PriceListArn</c>
        /// can be obtained from the <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_pricing_ListPriceLists.html">ListPriceLists</a>
        /// response. </para>
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
        public System.String PriceListArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Url'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pricing.Model.GetPriceListFileUrlResponse).
        /// Specifying the name of a property of type Amazon.Pricing.Model.GetPriceListFileUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Url";
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
                context.Select = CreateSelectDelegate<Amazon.Pricing.Model.GetPriceListFileUrlResponse, GetPLSPriceListFileUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileFormat = this.FileFormat;
            #if MODULAR
            if (this.FileFormat == null && ParameterWasBound(nameof(this.FileFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter FileFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PriceListArn = this.PriceListArn;
            #if MODULAR
            if (this.PriceListArn == null && ParameterWasBound(nameof(this.PriceListArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PriceListArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Pricing.Model.GetPriceListFileUrlRequest();
            
            if (cmdletContext.FileFormat != null)
            {
                request.FileFormat = cmdletContext.FileFormat;
            }
            if (cmdletContext.PriceListArn != null)
            {
                request.PriceListArn = cmdletContext.PriceListArn;
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
        
        private Amazon.Pricing.Model.GetPriceListFileUrlResponse CallAWSServiceOperation(IAmazonPricing client, Amazon.Pricing.Model.GetPriceListFileUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Price List Service", "GetPriceListFileUrl");
            try
            {
                #if DESKTOP
                return client.GetPriceListFileUrl(request);
                #elif CORECLR
                return client.GetPriceListFileUrlAsync(request).GetAwaiter().GetResult();
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
            public System.String FileFormat { get; set; }
            public System.String PriceListArn { get; set; }
            public System.Func<Amazon.Pricing.Model.GetPriceListFileUrlResponse, GetPLSPriceListFileUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Url;
        }
        
    }
}
