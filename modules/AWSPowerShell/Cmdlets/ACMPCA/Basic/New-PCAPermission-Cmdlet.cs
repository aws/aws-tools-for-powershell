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
using Amazon.ACMPCA;
using Amazon.ACMPCA.Model;

namespace Amazon.PowerShell.Cmdlets.PCA
{
    /// <summary>
    /// Grants one or more permissions on a private CA to the Certificate Manager (ACM) service
    /// principal (<c>acm.amazonaws.com</c>). These permissions allow ACM to issue and renew
    /// ACM certificates that reside in the same Amazon Web Services account as the CA.
    /// 
    ///  
    /// <para>
    /// You can list current permissions with the <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_ListPermissions.html">ListPermissions</a>
    /// action and revoke them with the <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_DeletePermission.html">DeletePermission</a>
    /// action.
    /// </para><para><b>About Permissions</b></para><ul><li><para>
    /// If the private CA and the certificates it issues reside in the same account, you can
    /// use <c>CreatePermission</c> to grant permissions for ACM to carry out automatic certificate
    /// renewals.
    /// </para></li><li><para>
    /// For automatic certificate renewal to succeed, the ACM service principal needs permissions
    /// to create, retrieve, and list certificates.
    /// </para></li><li><para>
    /// If the private CA and the ACM certificates reside in different accounts, then permissions
    /// cannot be used to enable automatic renewals. Instead, the ACM certificate owner must
    /// set up a resource-based policy to enable cross-account issuance and renewals. For
    /// more information, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/pca-rbp.html">Using
    /// a Resource Based Policy with Amazon Web Services Private CA</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "PCAPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority CreatePermission API operation.", Operation = new[] {"CreatePermission"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.CreatePermissionResponse))]
    [AWSCmdletOutput("None or Amazon.ACMPCA.Model.CreatePermissionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ACMPCA.Model.CreatePermissionResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewPCAPermissionCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The actions that the specified Amazon Web Services service principal can use. These
        /// include <c>IssueCertificate</c>, <c>GetCertificate</c>, and <c>ListPermissions</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Actions")]
        public System.String[] Action { get; set; }
        #endregion
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the CA that grants the permissions. You can find
        /// the ARN by calling the <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_ListCertificateAuthorities.html">ListCertificateAuthorities</a>
        /// action. This must have the following form: </para><para><c>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></c>. </para>
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
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services service or identity that receives the permission. At this
        /// time, the only valid principal is <c>acm.amazonaws.com</c>.</para>
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
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter SourceAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the calling account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceAccount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.CreatePermissionResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateAuthorityArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCAPermission (CreatePermission)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.CreatePermissionResponse, NewPCAPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Action != null)
            {
                context.Action = new List<System.String>(this.Action);
            }
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            #if MODULAR
            if (this.CertificateAuthorityArn == null && ParameterWasBound(nameof(this.CertificateAuthorityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Principal = this.Principal;
            #if MODULAR
            if (this.Principal == null && ParameterWasBound(nameof(this.Principal)))
            {
                WriteWarning("You are passing $null as a value for parameter Principal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceAccount = this.SourceAccount;
            
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
            var request = new Amazon.ACMPCA.Model.CreatePermissionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
            }
            if (cmdletContext.SourceAccount != null)
            {
                request.SourceAccount = cmdletContext.SourceAccount;
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
        
        private Amazon.ACMPCA.Model.CreatePermissionResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.CreatePermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "CreatePermission");
            try
            {
                return client.CreatePermissionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Action { get; set; }
            public System.String CertificateAuthorityArn { get; set; }
            public System.String Principal { get; set; }
            public System.String SourceAccount { get; set; }
            public System.Func<Amazon.ACMPCA.Model.CreatePermissionResponse, NewPCAPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
