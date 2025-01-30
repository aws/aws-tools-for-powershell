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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Imports the signing and encryption certificates that you need to create local (AS2)
    /// profiles and partner profiles.
    /// </summary>
    [Cmdlet("Import", "TFRCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP ImportCertificate API operation.", Operation = new[] {"ImportCertificate"}, SelectReturnType = typeof(Amazon.Transfer.Model.ImportCertificateResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.ImportCertificateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.ImportCertificateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportTFRCertificateCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActiveDate
        /// <summary>
        /// <para>
        /// <para>An optional date that specifies when the certificate becomes active.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ActiveDate { get; set; }
        #endregion
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <ul><li><para>For the CLI, provide a file path for a certificate in URI format. For example, <c>--certificate
        /// file://encryption-cert.pem</c>. Alternatively, you can provide the raw content.</para></li><li><para>For the SDK, specify the raw content of a certificate file. For example, <c>--certificate
        /// "`cat encryption-cert.pem`"</c>.</para></li></ul>
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
        public System.String Certificate { get; set; }
        #endregion
        
        #region Parameter CertificateChain
        /// <summary>
        /// <para>
        /// <para>An optional list of certificates that make up the chain for the certificate that's
        /// being imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateChain { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A short description that helps identify the certificate. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InactiveDate
        /// <summary>
        /// <para>
        /// <para>An optional date that specifies when the certificate becomes inactive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? InactiveDate { get; set; }
        #endregion
        
        #region Parameter PrivateKey
        /// <summary>
        /// <para>
        /// <ul><li><para>For the CLI, provide a file path for a private key in URI format.For example, <c>--private-key
        /// file://encryption-key.pem</c>. Alternatively, you can provide the raw content of the
        /// private key file.</para></li><li><para>For the SDK, specify the raw content of a private key file. For example, <c>--private-key
        /// "`cat encryption-key.pem`"</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateKey { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that can be used to group and search for certificates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Transfer.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Usage
        /// <summary>
        /// <para>
        /// <para>Specifies how this certificate is used. It can be used in the following ways:</para><ul><li><para><c>SIGNING</c>: For signing AS2 messages</para></li><li><para><c>ENCRYPTION</c>: For encrypting AS2 messages</para></li><li><para><c>TLS</c>: For securing AS2 communications sent over HTTPS</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Transfer.CertificateUsageType")]
        public Amazon.Transfer.CertificateUsageType Usage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CertificateId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.ImportCertificateResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.ImportCertificateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CertificateId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Certificate parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Certificate' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Certificate' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Certificate), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-TFRCertificate (ImportCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.ImportCertificateResponse, ImportTFRCertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Certificate;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActiveDate = this.ActiveDate;
            context.Certificate = this.Certificate;
            #if MODULAR
            if (this.Certificate == null && ParameterWasBound(nameof(this.Certificate)))
            {
                WriteWarning("You are passing $null as a value for parameter Certificate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateChain = this.CertificateChain;
            context.Description = this.Description;
            context.InactiveDate = this.InactiveDate;
            context.PrivateKey = this.PrivateKey;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Transfer.Model.Tag>(this.Tag);
            }
            context.Usage = this.Usage;
            #if MODULAR
            if (this.Usage == null && ParameterWasBound(nameof(this.Usage)))
            {
                WriteWarning("You are passing $null as a value for parameter Usage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Transfer.Model.ImportCertificateRequest();
            
            if (cmdletContext.ActiveDate != null)
            {
                request.ActiveDate = cmdletContext.ActiveDate.Value;
            }
            if (cmdletContext.Certificate != null)
            {
                request.Certificate = cmdletContext.Certificate;
            }
            if (cmdletContext.CertificateChain != null)
            {
                request.CertificateChain = cmdletContext.CertificateChain;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InactiveDate != null)
            {
                request.InactiveDate = cmdletContext.InactiveDate.Value;
            }
            if (cmdletContext.PrivateKey != null)
            {
                request.PrivateKey = cmdletContext.PrivateKey;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Usage != null)
            {
                request.Usage = cmdletContext.Usage;
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
        
        private Amazon.Transfer.Model.ImportCertificateResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.ImportCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "ImportCertificate");
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
            public System.DateTime? ActiveDate { get; set; }
            public System.String Certificate { get; set; }
            public System.String CertificateChain { get; set; }
            public System.String Description { get; set; }
            public System.DateTime? InactiveDate { get; set; }
            public System.String PrivateKey { get; set; }
            public List<Amazon.Transfer.Model.Tag> Tag { get; set; }
            public Amazon.Transfer.CertificateUsageType Usage { get; set; }
            public System.Func<Amazon.Transfer.Model.ImportCertificateResponse, ImportTFRCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateId;
        }
        
    }
}
