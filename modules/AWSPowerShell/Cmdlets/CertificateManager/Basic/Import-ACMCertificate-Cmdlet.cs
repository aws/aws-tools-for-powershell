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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Imports a certificate into Certificate Manager (ACM) to use with services that are
    /// integrated with ACM. Note that <a href="https://docs.aws.amazon.com/acm/latest/userguide/acm-services.html">integrated
    /// services</a> allow only certificate types and keys they support to be associated with
    /// their resources. Further, their support differs depending on whether the certificate
    /// is imported into IAM or into ACM. For more information, see the documentation for
    /// each service. For more information about importing certificates into ACM, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/import-certificate.html">Importing
    /// Certificates</a> in the <i>Certificate Manager User Guide</i>. 
    /// 
    ///  <note><para>
    /// ACM does not provide <a href="https://docs.aws.amazon.com/acm/latest/userguide/acm-renewal.html">managed
    /// renewal</a> for certificates that you import.
    /// </para></note><para>
    /// Note the following guidelines when importing third party certificates:
    /// </para><ul><li><para>
    /// You must enter the private key that matches the certificate you are importing.
    /// </para></li><li><para>
    /// The private key must be unencrypted. You cannot import a private key that is protected
    /// by a password or a passphrase.
    /// </para></li><li><para>
    /// The private key must be no larger than 5 KB (5,120 bytes).
    /// </para></li><li><para>
    /// The certificate, private key, and certificate chain must be PEM-encoded.
    /// </para></li><li><para>
    /// The current time must be between the <c>Not Before</c> and <c>Not After</c> certificate
    /// fields.
    /// </para></li><li><para>
    /// The <c>Issuer</c> field must not be empty.
    /// </para></li><li><para>
    /// The OCSP authority URL, if present, must not exceed 1000 characters.
    /// </para></li><li><para>
    /// To import a new certificate, omit the <c>CertificateArn</c> argument. Include this
    /// argument only when you want to replace a previously imported certificate.
    /// </para></li><li><para>
    /// When you import a certificate by using the CLI, you must specify the certificate,
    /// the certificate chain, and the private key by their file names preceded by <c>fileb://</c>.
    /// For example, you can specify a certificate saved in the <c>C:\temp</c> folder as <c>fileb://C:\temp\certificate_to_import.pem</c>.
    /// If you are making an HTTP or HTTPS Query request, include these arguments as BLOBs.
    /// 
    /// </para></li><li><para>
    /// When you import a certificate by using an SDK, you must specify the certificate, the
    /// certificate chain, and the private key files in the manner required by the programming
    /// language you're using. 
    /// </para></li><li><para>
    /// The cryptographic algorithm of an imported certificate must match the algorithm of
    /// the signing CA. For example, if the signing CA key type is RSA, then the certificate
    /// key type must also be RSA.
    /// </para></li></ul><para>
    /// This operation returns the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
    /// Resource Name (ARN)</a> of the imported certificate.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "ACMCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager ImportCertificate API operation.", Operation = new[] {"ImportCertificate"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.ImportCertificateResponse))]
    [AWSCmdletOutput("System.String or Amazon.CertificateManager.Model.ImportCertificateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CertificateManager.Model.ImportCertificateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportACMCertificateCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>The certificate to import.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Certificate { get; set; }
        #endregion
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of an imported certificate to replace. To import a new certificate,
        /// omit this field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter CertificateChain
        /// <summary>
        /// <para>
        /// <para>The PEM encoded certificate chain.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] CertificateChain { get; set; }
        #endregion
        
        #region Parameter PrivateKey
        /// <summary>
        /// <para>
        /// <para>The private key that matches the public key in the certificate.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] PrivateKey { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more resource tags to associate with the imported certificate. </para><para>Note: You cannot apply tags when reimporting a certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CertificateManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CertificateArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.ImportCertificateResponse).
        /// Specifying the name of a property of type Amazon.CertificateManager.Model.ImportCertificateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CertificateArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-ACMCertificate (ImportCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.ImportCertificateResponse, ImportACMCertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Certificate = this.Certificate;
            #if MODULAR
            if (this.Certificate == null && ParameterWasBound(nameof(this.Certificate)))
            {
                WriteWarning("You are passing $null as a value for parameter Certificate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateArn = this.CertificateArn;
            context.CertificateChain = this.CertificateChain;
            context.PrivateKey = this.PrivateKey;
            #if MODULAR
            if (this.PrivateKey == null && ParameterWasBound(nameof(this.PrivateKey)))
            {
                WriteWarning("You are passing $null as a value for parameter PrivateKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CertificateManager.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _CertificateStream = null;
            System.IO.MemoryStream _CertificateChainStream = null;
            System.IO.MemoryStream _PrivateKeyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.CertificateManager.Model.ImportCertificateRequest();
                
                if (cmdletContext.Certificate != null)
                {
                    _CertificateStream = new System.IO.MemoryStream(cmdletContext.Certificate);
                    request.Certificate = _CertificateStream;
                }
                if (cmdletContext.CertificateArn != null)
                {
                    request.CertificateArn = cmdletContext.CertificateArn;
                }
                if (cmdletContext.CertificateChain != null)
                {
                    _CertificateChainStream = new System.IO.MemoryStream(cmdletContext.CertificateChain);
                    request.CertificateChain = _CertificateChainStream;
                }
                if (cmdletContext.PrivateKey != null)
                {
                    _PrivateKeyStream = new System.IO.MemoryStream(cmdletContext.PrivateKey);
                    request.PrivateKey = _PrivateKeyStream;
                }
                if (cmdletContext.Tag != null)
                {
                    request.Tags = cmdletContext.Tag;
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
            finally
            {
                if( _CertificateStream != null)
                {
                    _CertificateStream.Dispose();
                }
                if( _CertificateChainStream != null)
                {
                    _CertificateChainStream.Dispose();
                }
                if( _PrivateKeyStream != null)
                {
                    _PrivateKeyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CertificateManager.Model.ImportCertificateResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.ImportCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "ImportCertificate");
            try
            {
                #if DESKTOP
                return client.ImportCertificate(request);
                #elif CORECLR
                return client.ImportCertificateAsync(request).GetAwaiter().GetResult();
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
            public byte[] Certificate { get; set; }
            public System.String CertificateArn { get; set; }
            public byte[] CertificateChain { get; set; }
            public byte[] PrivateKey { get; set; }
            public List<Amazon.CertificateManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CertificateManager.Model.ImportCertificateResponse, ImportACMCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateArn;
        }
        
    }
}
