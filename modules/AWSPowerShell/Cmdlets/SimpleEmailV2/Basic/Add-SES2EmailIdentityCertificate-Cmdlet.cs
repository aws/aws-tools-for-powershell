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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Associates an S/MIME certificate with an email identity. After the certificate is
    /// active, Amazon SES API v2 can add an S/MIME signature to messages that you send from
    /// the associated address when signing is enabled on the configuration set used to send
    /// the message.
    /// 
    ///  
    /// <para>
    /// The certificate is an X.509 certificate that you manage in Certificate Manager (ACM).
    /// You identify it by its Amazon Resource Name (ARN).
    /// </para><ul><li><para>
    /// If the email identity is a domain, you must specify a <c>FromAddress</c> that belongs
    /// to that domain or one of its subdomains. The certificate applies to messages sent
    /// from that address.
    /// </para></li><li><para>
    /// If the email identity is an email address, <c>FromAddress</c> is optional. If you
    /// specify it, it must exactly match the email identity.
    /// </para></li></ul><para>
    /// When the association is created, the certificate begins provisioning and its status
    /// is <c>PROVISIONING</c>. The status changes to <c>ACTIVE</c> when the certificate is
    /// ready to use for signing. Each email address can have only one certificate association.
    /// If an association already exists for the address, this operation returns an error,
    /// unless the existing association is in the <c>DEPROVISIONING</c> state.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "SES2EmailIdentityCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) AssociateEmailIdentityCertificate API operation.", Operation = new[] {"AssociateEmailIdentityCertificate"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.AssociateEmailIdentityCertificateResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.AssociateEmailIdentityCertificateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.AssociateEmailIdentityCertificateResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddSES2EmailIdentityCertificateCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Certificate Manager (ACM) certificate to associate
        /// with the email identity.</para>
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
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter EmailIdentity
        /// <summary>
        /// <para>
        /// <para>The email identity, either an email address or a domain, to associate the certificate
        /// with.</para>
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
        public System.String EmailIdentity { get; set; }
        #endregion
        
        #region Parameter FromAddress
        /// <summary>
        /// <para>
        /// <para>The email address that the certificate applies to. This value is required when the
        /// email identity is a domain, and the address must belong to that domain or one of its
        /// subdomains. When the email identity is an email address, this value is optional. If
        /// you specify it, it must exactly match the email identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.AssociateEmailIdentityCertificateResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-SES2EmailIdentityCertificate (AssociateEmailIdentityCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.AssociateEmailIdentityCertificateResponse, AddSES2EmailIdentityCertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateArn = this.CertificateArn;
            #if MODULAR
            if (this.CertificateArn == null && ParameterWasBound(nameof(this.CertificateArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailIdentity = this.EmailIdentity;
            #if MODULAR
            if (this.EmailIdentity == null && ParameterWasBound(nameof(this.EmailIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FromAddress = this.FromAddress;
            
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
            var request = new Amazon.SimpleEmailV2.Model.AssociateEmailIdentityCertificateRequest();
            
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
            }
            if (cmdletContext.EmailIdentity != null)
            {
                request.EmailIdentity = cmdletContext.EmailIdentity;
            }
            if (cmdletContext.FromAddress != null)
            {
                request.FromAddress = cmdletContext.FromAddress;
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
        
        private Amazon.SimpleEmailV2.Model.AssociateEmailIdentityCertificateResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.AssociateEmailIdentityCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "AssociateEmailIdentityCertificate");
            try
            {
                return client.AssociateEmailIdentityCertificateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CertificateArn { get; set; }
            public System.String EmailIdentity { get; set; }
            public System.String FromAddress { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.AssociateEmailIdentityCertificateResponse, AddSES2EmailIdentityCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
