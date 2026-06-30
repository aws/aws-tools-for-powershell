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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Returns detailed metadata about the specified domain validation, including its status,
    /// domain scope, and DNS resource records required for validation.
    /// </summary>
    [Cmdlet("Get", "ACMAcmeDomainValidationDetail")]
    [OutputType("Amazon.CertificateManager.Model.AcmeDomainValidation")]
    [AWSCmdlet("Calls the AWS Certificate Manager DescribeAcmeDomainValidation API operation.", Operation = new[] {"DescribeAcmeDomainValidation"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.DescribeAcmeDomainValidationResponse))]
    [AWSCmdletOutput("Amazon.CertificateManager.Model.AcmeDomainValidation or Amazon.CertificateManager.Model.DescribeAcmeDomainValidationResponse",
        "This cmdlet returns an Amazon.CertificateManager.Model.AcmeDomainValidation object.",
        "The service call response (type Amazon.CertificateManager.Model.DescribeAcmeDomainValidationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetACMAcmeDomainValidationDetailCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcmeDomainValidationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the ACME domain validation.</para>
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
        public System.String AcmeDomainValidationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AcmeDomainValidation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.DescribeAcmeDomainValidationResponse).
        /// Specifying the name of a property of type Amazon.CertificateManager.Model.DescribeAcmeDomainValidationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AcmeDomainValidation";
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
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.DescribeAcmeDomainValidationResponse, GetACMAcmeDomainValidationDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcmeDomainValidationArn = this.AcmeDomainValidationArn;
            #if MODULAR
            if (this.AcmeDomainValidationArn == null && ParameterWasBound(nameof(this.AcmeDomainValidationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AcmeDomainValidationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CertificateManager.Model.DescribeAcmeDomainValidationRequest();
            
            if (cmdletContext.AcmeDomainValidationArn != null)
            {
                request.AcmeDomainValidationArn = cmdletContext.AcmeDomainValidationArn;
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
        
        private Amazon.CertificateManager.Model.DescribeAcmeDomainValidationResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.DescribeAcmeDomainValidationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "DescribeAcmeDomainValidation");
            try
            {
                return client.DescribeAcmeDomainValidationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AcmeDomainValidationArn { get; set; }
            public System.Func<Amazon.CertificateManager.Model.DescribeAcmeDomainValidationResponse, GetACMAcmeDomainValidationDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AcmeDomainValidation;
        }
        
    }
}
