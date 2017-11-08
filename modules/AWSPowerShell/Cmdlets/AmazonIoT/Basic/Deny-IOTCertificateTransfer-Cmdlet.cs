/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Rejects a pending certificate transfer. After AWS IoT rejects a certificate transfer,
    /// the certificate status changes from <b>PENDING_TRANSFER</b> to <b>INACTIVE</b>.
    /// 
    ///  
    /// <para>
    /// To check for pending certificate transfers, call <a>ListCertificates</a> to enumerate
    /// your certificates.
    /// </para><para>
    /// This operation can only be called by the transfer destination. After it is called,
    /// the certificate will be returned to the source's account in the INACTIVE state.
    /// </para>
    /// </summary>
    [Cmdlet("Deny", "IOTCertificateTransfer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS IoT RejectCertificateTransfer API operation.", Operation = new[] {"RejectCertificateTransfer"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the CertificateId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IoT.Model.RejectCertificateTransferResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DenyIOTCertificateTransferCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateId
        /// <summary>
        /// <para>
        /// <para>The ID of the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CertificateId { get; set; }
        #endregion
        
        #region Parameter RejectReason
        /// <summary>
        /// <para>
        /// <para>The reason the certificate transfer was rejected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RejectReason { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the CertificateId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificateId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Deny-IOTCertificateTransfer (RejectCertificateTransfer)"))
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
            
            context.CertificateId = this.CertificateId;
            context.RejectReason = this.RejectReason;
            
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
            var request = new Amazon.IoT.Model.RejectCertificateTransferRequest();
            
            if (cmdletContext.CertificateId != null)
            {
                request.CertificateId = cmdletContext.CertificateId;
            }
            if (cmdletContext.RejectReason != null)
            {
                request.RejectReason = cmdletContext.RejectReason;
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
                    pipelineOutput = this.CertificateId;
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
        
        private Amazon.IoT.Model.RejectCertificateTransferResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.RejectCertificateTransferRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "RejectCertificateTransfer");
            try
            {
                #if DESKTOP
                return client.RejectCertificateTransfer(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RejectCertificateTransferAsync(request);
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
            public System.String CertificateId { get; set; }
            public System.String RejectReason { get; set; }
        }
        
    }
}
