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
    /// Removes the association between an S/MIME certificate and an email identity. After
    /// the association is removed, Amazon SES API v2 stops adding an S/MIME signature to
    /// messages sent from that address.
    /// 
    ///  
    /// <para>
    /// If the email identity is a domain, specify the <c>FromAddress</c> whose certificate
    /// association you want to remove.
    /// </para><para>
    /// This operation is idempotent. If the specified email identity exists but there's no
    /// matching certificate association, the operation succeeds without making any changes.
    /// Amazon SES API v2 returns a <c>NotFoundException</c> only when the specified email
    /// identity doesn't exist.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "SES2EmailIdentityCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) DisassociateEmailIdentityCertificate API operation.", Operation = new[] {"DisassociateEmailIdentityCertificate"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.DisassociateEmailIdentityCertificateResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.DisassociateEmailIdentityCertificateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.DisassociateEmailIdentityCertificateResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveSES2EmailIdentityCertificateCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EmailIdentity
        /// <summary>
        /// <para>
        /// <para>The email identity whose certificate association you want to remove.</para>
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
        public System.String EmailIdentity { get; set; }
        #endregion
        
        #region Parameter FromAddress
        /// <summary>
        /// <para>
        /// <para>The email address whose certificate association you want to remove. This value is
        /// required when the email identity is a domain. When the email identity is an email
        /// address, this value is optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.DisassociateEmailIdentityCertificateResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EmailIdentity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SES2EmailIdentityCertificate (DisassociateEmailIdentityCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.DisassociateEmailIdentityCertificateResponse, RemoveSES2EmailIdentityCertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.SimpleEmailV2.Model.DisassociateEmailIdentityCertificateRequest();
            
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
        
        private Amazon.SimpleEmailV2.Model.DisassociateEmailIdentityCertificateResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.DisassociateEmailIdentityCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "DisassociateEmailIdentityCertificate");
            try
            {
                return client.DisassociateEmailIdentityCertificateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EmailIdentity { get; set; }
            public System.String FromAddress { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.DisassociateEmailIdentityCertificateResponse, RemoveSES2EmailIdentityCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
