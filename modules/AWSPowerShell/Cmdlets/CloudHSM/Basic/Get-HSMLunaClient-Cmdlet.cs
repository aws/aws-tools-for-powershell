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
using Amazon.CloudHSM;
using Amazon.CloudHSM.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.HSM
{
    /// <summary>
    /// This is documentation for <b>AWS CloudHSM Classic</b>. For more information, see <a href="http://aws.amazon.com/cloudhsm/faqs-classic/">AWS CloudHSM Classic FAQs</a>,
    /// the <a href="https://docs.aws.amazon.com/cloudhsm/classic/userguide/">AWS CloudHSM
    /// Classic User Guide</a>, and the <a href="https://docs.aws.amazon.com/cloudhsm/classic/APIReference/">AWS
    /// CloudHSM Classic API Reference</a>.
    /// 
    ///  
    /// <para><b>For information about the current version of AWS CloudHSM</b>, see <a href="http://aws.amazon.com/cloudhsm/">AWS
    /// CloudHSM</a>, the <a href="https://docs.aws.amazon.com/cloudhsm/latest/userguide/">AWS
    /// CloudHSM User Guide</a>, and the <a href="https://docs.aws.amazon.com/cloudhsm/latest/APIReference/">AWS
    /// CloudHSM API Reference</a>.
    /// </para><para>
    /// Retrieves information about an HSM client.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "HSMLunaClient")]
    [OutputType("Amazon.CloudHSM.Model.DescribeLunaClientResponse")]
    [AWSCmdlet("Calls the AWS CloudHSM DescribeLunaClient API operation.", Operation = new[] {"DescribeLunaClient"}, SelectReturnType = typeof(Amazon.CloudHSM.Model.DescribeLunaClientResponse))]
    [AWSCmdletOutput("Amazon.CloudHSM.Model.DescribeLunaClientResponse",
        "This cmdlet returns an Amazon.CloudHSM.Model.DescribeLunaClientResponse object containing multiple properties."
    )]
    [System.ObsoleteAttribute("This API is deprecated.")]
    public partial class GetHSMLunaClientCmdlet : AmazonCloudHSMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateFingerprint
        /// <summary>
        /// <para>
        /// <para>The certificate fingerprint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateFingerprint { get; set; }
        #endregion
        
        #region Parameter ClientArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClientArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudHSM.Model.DescribeLunaClientResponse).
        /// Specifying the name of a property of type Amazon.CloudHSM.Model.DescribeLunaClientResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CloudHSM.Model.DescribeLunaClientResponse, GetHSMLunaClientCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateFingerprint = this.CertificateFingerprint;
            context.ClientArn = this.ClientArn;
            
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
            var request = new Amazon.CloudHSM.Model.DescribeLunaClientRequest();
            
            if (cmdletContext.CertificateFingerprint != null)
            {
                request.CertificateFingerprint = cmdletContext.CertificateFingerprint;
            }
            if (cmdletContext.ClientArn != null)
            {
                request.ClientArn = cmdletContext.ClientArn;
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
        
        private Amazon.CloudHSM.Model.DescribeLunaClientResponse CallAWSServiceOperation(IAmazonCloudHSM client, Amazon.CloudHSM.Model.DescribeLunaClientRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudHSM", "DescribeLunaClient");
            try
            {
                return client.DescribeLunaClientAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CertificateFingerprint { get; set; }
            public System.String ClientArn { get; set; }
            public System.Func<Amazon.CloudHSM.Model.DescribeLunaClientResponse, GetHSMLunaClientCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
