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
using Amazon.PaymentCryptography;
using Amazon.PaymentCryptography.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PAYCC
{
    /// <summary>
    /// Retrieves the list of regions where default key replication is currently enabled for
    /// your account.
    /// 
    ///  
    /// <para>
    /// This operation returns the current configuration of default Replication Regions. New
    /// keys created in your account will be automatically replicated to these regions unless
    /// explicitly overridden during key creation.
    /// </para><para><b>Cross-account use:</b> This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_EnableDefaultKeyReplicationRegions.html">EnableDefaultKeyReplicationRegions</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_DisableDefaultKeyReplicationRegions.html">DisableDefaultKeyReplicationRegions</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "PAYCCDefaultKeyReplicationRegion")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane GetDefaultKeyReplicationRegions API operation.", Operation = new[] {"GetDefaultKeyReplicationRegions"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsResponse))]
    [AWSCmdletOutput("System.String or Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPAYCCDefaultKeyReplicationRegionCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnabledReplicationRegions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnabledReplicationRegions";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsResponse, GetPAYCCDefaultKeyReplicationRegionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsRequest();
            
            
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
        
        private Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "GetDefaultKeyReplicationRegions");
            try
            {
                return client.GetDefaultKeyReplicationRegionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.PaymentCryptography.Model.GetDefaultKeyReplicationRegionsResponse, GetPAYCCDefaultKeyReplicationRegionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnabledReplicationRegions;
        }
        
    }
}
