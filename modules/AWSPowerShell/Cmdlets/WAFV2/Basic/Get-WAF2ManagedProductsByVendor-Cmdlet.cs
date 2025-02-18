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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Provides high-level information for the managed rule groups owned by a specific vendor.
    /// </summary>
    [Cmdlet("Get", "WAF2ManagedProductsByVendor")]
    [OutputType("Amazon.WAFV2.Model.ManagedProductDescriptor")]
    [AWSCmdlet("Calls the AWS WAF V2 DescribeManagedProductsByVendor API operation.", Operation = new[] {"DescribeManagedProductsByVendor"}, SelectReturnType = typeof(Amazon.WAFV2.Model.DescribeManagedProductsByVendorResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.ManagedProductDescriptor or Amazon.WAFV2.Model.DescribeManagedProductsByVendorResponse",
        "This cmdlet returns a collection of Amazon.WAFV2.Model.ManagedProductDescriptor objects.",
        "The service call response (type Amazon.WAFV2.Model.DescribeManagedProductsByVendorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWAF2ManagedProductsByVendorCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Specifies whether this is for an Amazon CloudFront distribution or for a regional
        /// application. A regional application can be an Application Load Balancer (ALB), an
        /// Amazon API Gateway REST API, an AppSync GraphQL API, an Amazon Cognito user pool,
        /// an App Runner service, or an Amazon Web Services Verified Access instance. </para><para>To work with CloudFront, you must also specify the Region US East (N. Virginia) as
        /// follows: </para><ul><li><para>CLI - Specify the Region when you use the CloudFront scope: <c>--scope=CLOUDFRONT
        /// --region=us-east-1</c>. </para></li><li><para>API and SDKs - For all calls, use the Region endpoint us-east-1. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Scope")]
        public Amazon.WAFV2.Scope Scope { get; set; }
        #endregion
        
        #region Parameter VendorName
        /// <summary>
        /// <para>
        /// <para>The name of the managed rule group vendor. You use this, along with the rule group
        /// name, to identify a rule group.</para>
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
        public System.String VendorName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ManagedProducts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.DescribeManagedProductsByVendorResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.DescribeManagedProductsByVendorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ManagedProducts";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.DescribeManagedProductsByVendorResponse, GetWAF2ManagedProductsByVendorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VendorName = this.VendorName;
            #if MODULAR
            if (this.VendorName == null && ParameterWasBound(nameof(this.VendorName)))
            {
                WriteWarning("You are passing $null as a value for parameter VendorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFV2.Model.DescribeManagedProductsByVendorRequest();
            
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.VendorName != null)
            {
                request.VendorName = cmdletContext.VendorName;
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
        
        private Amazon.WAFV2.Model.DescribeManagedProductsByVendorResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.DescribeManagedProductsByVendorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "DescribeManagedProductsByVendor");
            try
            {
                return client.DescribeManagedProductsByVendorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.WAFV2.Scope Scope { get; set; }
            public System.String VendorName { get; set; }
            public System.Func<Amazon.WAFV2.Model.DescribeManagedProductsByVendorResponse, GetWAF2ManagedProductsByVendorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ManagedProducts;
        }
        
    }
}
