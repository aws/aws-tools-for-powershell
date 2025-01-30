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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Retrieves the ca certificate bundle.
    /// 
    ///  
    /// <para>
    /// This action returns a pre-signed S3 URI which is active for ten minutes.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ELB2TrustStoreCaCertificatesBundle")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 GetTrustStoreCaCertificatesBundle API operation.", Operation = new[] {"GetTrustStoreCaCertificatesBundle"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetELB2TrustStoreCaCertificatesBundleCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TrustStoreArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the trust store.</para>
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
        public System.String TrustStoreArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Location'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Location";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrustStoreArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrustStoreArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrustStoreArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleResponse, GetELB2TrustStoreCaCertificatesBundleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrustStoreArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TrustStoreArn = this.TrustStoreArn;
            #if MODULAR
            if (this.TrustStoreArn == null && ParameterWasBound(nameof(this.TrustStoreArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustStoreArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleRequest();
            
            if (cmdletContext.TrustStoreArn != null)
            {
                request.TrustStoreArn = cmdletContext.TrustStoreArn;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "GetTrustStoreCaCertificatesBundle");
            try
            {
                #if DESKTOP
                return client.GetTrustStoreCaCertificatesBundle(request);
                #elif CORECLR
                return client.GetTrustStoreCaCertificatesBundleAsync(request).GetAwaiter().GetResult();
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
            public System.String TrustStoreArn { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.GetTrustStoreCaCertificatesBundleResponse, GetELB2TrustStoreCaCertificatesBundleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Location;
        }
        
    }
}
