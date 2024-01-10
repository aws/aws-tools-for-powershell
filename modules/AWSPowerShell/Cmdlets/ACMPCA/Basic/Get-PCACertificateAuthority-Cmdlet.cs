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
using Amazon.ACMPCA;
using Amazon.ACMPCA.Model;

namespace Amazon.PowerShell.Cmdlets.PCA
{
    /// <summary>
    /// Lists information about your private certificate authority (CA) or one that has been
    /// shared with you. You specify the private CA on input by its ARN (Amazon Resource Name).
    /// The output contains the status of your CA. This can be any of the following: 
    /// 
    ///  <ul><li><para><c>CREATING</c> - Amazon Web Services Private CA is creating your private certificate
    /// authority.
    /// </para></li><li><para><c>PENDING_CERTIFICATE</c> - The certificate is pending. You must use your Amazon
    /// Web Services Private CA-hosted or on-premises root or subordinate CA to sign your
    /// private CA CSR and then import it into Amazon Web Services Private CA. 
    /// </para></li><li><para><c>ACTIVE</c> - Your private CA is active.
    /// </para></li><li><para><c>DISABLED</c> - Your private CA has been disabled.
    /// </para></li><li><para><c>EXPIRED</c> - Your private CA certificate has expired.
    /// </para></li><li><para><c>FAILED</c> - Your private CA has failed. Your CA can fail because of problems
    /// such a network outage or back-end Amazon Web Services failure or other errors. A failed
    /// CA can never return to the pending state. You must create a new CA. 
    /// </para></li><li><para><c>DELETED</c> - Your private CA is within the restoration period, after which it
    /// is permanently deleted. The length of time remaining in the CA's restoration period
    /// is also included in this action's output.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "PCACertificateAuthority")]
    [OutputType("Amazon.ACMPCA.Model.CertificateAuthority")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority DescribeCertificateAuthority API operation.", Operation = new[] {"DescribeCertificateAuthority"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse))]
    [AWSCmdletOutput("Amazon.ACMPCA.Model.CertificateAuthority or Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse",
        "This cmdlet returns an Amazon.ACMPCA.Model.CertificateAuthority object.",
        "The service call response (type Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPCACertificateAuthorityCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_CreateCertificateAuthority.html">CreateCertificateAuthority</a>.
        /// This must be of the form: </para><para><c>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></c>. </para>
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
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CertificateAuthority'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse).
        /// Specifying the name of a property of type Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CertificateAuthority";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CertificateAuthorityArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CertificateAuthorityArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CertificateAuthorityArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse, GetPCACertificateAuthorityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CertificateAuthorityArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            #if MODULAR
            if (this.CertificateAuthorityArn == null && ParameterWasBound(nameof(this.CertificateAuthorityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ACMPCA.Model.DescribeCertificateAuthorityRequest();
            
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
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
        
        private Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.DescribeCertificateAuthorityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "DescribeCertificateAuthority");
            try
            {
                #if DESKTOP
                return client.DescribeCertificateAuthority(request);
                #elif CORECLR
                return client.DescribeCertificateAuthorityAsync(request).GetAwaiter().GetResult();
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
            public System.String CertificateAuthorityArn { get; set; }
            public System.Func<Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse, GetPCACertificateAuthorityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateAuthority;
        }
        
    }
}
