/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Deletes a private certificate authority (CA). You must provide the ARN (Amazon Resource
    /// Name) of the private CA that you want to delete. You can find the ARN by calling the
    /// <a>ListCertificateAuthorities</a> operation. Before you can delete a CA, you must
    /// disable it. Call the <a>UpdateCertificateAuthority</a> operation and set the <b>CertificateAuthorityStatus</b>
    /// parameter to <code>DISABLED</code>. 
    /// 
    ///  
    /// <para>
    /// Additionally, you can delete a CA if you are waiting for it to be created (the <b>Status</b>
    /// field of the <a>CertificateAuthority</a> is <code>CREATING</code>). You can also delete
    /// it if the CA has been created but you haven't yet imported the signed certificate
    /// (the <b>Status</b> is <code>PENDING_CERTIFICATE</code>) into ACM PCA. 
    /// </para><para>
    /// If the CA is in one of the aforementioned states and you call <a>DeleteCertificateAuthority</a>,
    /// the CA's status changes to <code>DELETED</code>. However, the CA won't be permentantly
    /// deleted until the restoration period has passed. By default, if you do not set the
    /// <code>PermanentDeletionTimeInDays</code> parameter, the CA remains restorable for
    /// 30 days. You can set the parameter from 7 to 30 days. The <a>DescribeCertificateAuthority</a>
    /// operation returns the time remaining in the restoration window of a Private CA in
    /// the <code>DELETED</code> state. To restore an eligable CA, call the <a>RestoreCertificateAuthority</a>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "PCACertificateAuthority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority DeleteCertificateAuthority API operation.", Operation = new[] {"DeleteCertificateAuthority"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the CertificateAuthorityArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ACMPCA.Model.DeleteCertificateAuthorityResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemovePCACertificateAuthorityCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a>CreateCertificateAuthority</a>.
        /// This must have the following form: </para><para><code>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter PermanentDeletionTimeInDay
        /// <summary>
        /// <para>
        /// <para>The number of days to make a CA restorable after it has been deleted. This can be
        /// anywhere from 7 to 30 days, with 30 being the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PermanentDeletionTimeInDays")]
        public System.Int32 PermanentDeletionTimeInDay { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the CertificateAuthorityArn parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificateAuthorityArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-PCACertificateAuthority (DeleteCertificateAuthority)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            if (ParameterWasBound("PermanentDeletionTimeInDay"))
                context.PermanentDeletionTimeInDays = this.PermanentDeletionTimeInDay;
            
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
            if (cmdletContext.PermanentDeletionTimeInDays != null)
            {
                request.PermanentDeletionTimeInDays = cmdletContext.PermanentDeletionTimeInDays.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.CertificateAuthorityArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteCertificateAuthorityAsync(request);
                return task.Result;
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
            public System.Int32? PermanentDeletionTimeInDays { get; set; }
        }
        
    }
}
