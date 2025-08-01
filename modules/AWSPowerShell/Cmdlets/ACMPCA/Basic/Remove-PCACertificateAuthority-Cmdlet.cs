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
using Amazon.ACMPCA;
using Amazon.ACMPCA.Model;

namespace Amazon.PowerShell.Cmdlets.PCA
{
    /// <summary>
    /// Deletes a private certificate authority (CA). You must provide the Amazon Resource
    /// Name (ARN) of the private CA that you want to delete. You can find the ARN by calling
    /// the <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_ListCertificateAuthorities.html">ListCertificateAuthorities</a>
    /// action. 
    /// 
    ///  <note><para>
    /// Deleting a CA will invalidate other CAs and certificates below it in your CA hierarchy.
    /// </para></note><para>
    /// Before you can delete a CA that you have created and activated, you must disable it.
    /// To do this, call the <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_UpdateCertificateAuthority.html">UpdateCertificateAuthority</a>
    /// action and set the <b>CertificateAuthorityStatus</b> parameter to <c>DISABLED</c>.
    /// 
    /// </para><para>
    /// Additionally, you can delete a CA if you are waiting for it to be created (that is,
    /// the status of the CA is <c>CREATING</c>). You can also delete it if the CA has been
    /// created but you haven't yet imported the signed certificate into Amazon Web Services
    /// Private CA (that is, the status of the CA is <c>PENDING_CERTIFICATE</c>). 
    /// </para><para>
    /// When you successfully call <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_DeleteCertificateAuthority.html">DeleteCertificateAuthority</a>,
    /// the CA's status changes to <c>DELETED</c>. However, the CA won't be permanently deleted
    /// until the restoration period has passed. By default, if you do not set the <c>PermanentDeletionTimeInDays</c>
    /// parameter, the CA remains restorable for 30 days. You can set the parameter from 7
    /// to 30 days. The <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_DescribeCertificateAuthority.html">DescribeCertificateAuthority</a>
    /// action returns the time remaining in the restoration window of a private CA in the
    /// <c>DELETED</c> state. To restore an eligible CA, call the <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_RestoreCertificateAuthority.html">RestoreCertificateAuthority</a>
    /// action.
    /// </para><important><para>
    /// A private CA can be deleted if it is in the <c>PENDING_CERTIFICATE</c>, <c>CREATING</c>,
    /// <c>EXPIRED</c>, <c>DISABLED</c>, or <c>FAILED</c> state. To delete a CA in the <c>ACTIVE</c>
    /// state, you must first disable it, or else the delete request results in an exception.
    /// If you are deleting a private CA in the <c>PENDING_CERTIFICATE</c> or <c>DISABLED</c>
    /// state, you can set the length of its restoration period to 7-30 days. The default
    /// is 30. During this time, the status is set to <c>DELETED</c> and the CA can be restored.
    /// A private CA deleted in the <c>CREATING</c> or <c>FAILED</c> state has no assigned
    /// restoration period and cannot be restored.
    /// </para></important>
    /// </summary>
    [Cmdlet("Remove", "PCACertificateAuthority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority DeleteCertificateAuthority API operation.", Operation = new[] {"DeleteCertificateAuthority"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.DeleteCertificateAuthorityResponse))]
    [AWSCmdletOutput("None or Amazon.ACMPCA.Model.DeleteCertificateAuthorityResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ACMPCA.Model.DeleteCertificateAuthorityResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemovePCACertificateAuthorityCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_CreateCertificateAuthority.html">CreateCertificateAuthority</a>.
        /// This must have the following form: </para><para><c>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></c>. </para>
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
        
        #region Parameter PermanentDeletionTimeInDay
        /// <summary>
        /// <para>
        /// <para>The number of days to make a CA restorable after it has been deleted. This can be
        /// anywhere from 7 to 30 days, with 30 being the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PermanentDeletionTimeInDays")]
        public System.Int32? PermanentDeletionTimeInDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.DeleteCertificateAuthorityResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateAuthorityArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-PCACertificateAuthority (DeleteCertificateAuthority)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.DeleteCertificateAuthorityResponse, RemovePCACertificateAuthorityCmdlet>(Select) ??
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
            context.PermanentDeletionTimeInDay = this.PermanentDeletionTimeInDay;
            
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
            var request = new Amazon.ACMPCA.Model.DeleteCertificateAuthorityRequest();
            
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
            }
            if (cmdletContext.PermanentDeletionTimeInDay != null)
            {
                request.PermanentDeletionTimeInDays = cmdletContext.PermanentDeletionTimeInDay.Value;
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
        
        private Amazon.ACMPCA.Model.DeleteCertificateAuthorityResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.DeleteCertificateAuthorityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "DeleteCertificateAuthority");
            try
            {
                #if DESKTOP
                return client.DeleteCertificateAuthority(request);
                #elif CORECLR
                return client.DeleteCertificateAuthorityAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? PermanentDeletionTimeInDay { get; set; }
            public System.Func<Amazon.ACMPCA.Model.DeleteCertificateAuthorityResponse, RemovePCACertificateAuthorityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
