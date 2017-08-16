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
    /// Transfers the specified certificate to the specified AWS account.
    /// 
    ///  
    /// <para>
    /// You can cancel the transfer until it is acknowledged by the recipient.
    /// </para><para>
    /// No notification is sent to the transfer destination's account. It is up to the caller
    /// to notify the transfer target.
    /// </para><para>
    /// The certificate being transferred must not be in the ACTIVE state. You can use the
    /// UpdateCertificate API to deactivate it.
    /// </para><para>
    /// The certificate must not have any policies attached to it. You can use the DetachPrincipalPolicy
    /// API to detach them.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "IOTCertificateTransfer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the TransferCertificate operation against AWS IoT.", Operation = new[] {"TransferCertificate"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.IoT.Model.TransferCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestIOTCertificateTransferCmdlet : AmazonIoTClientCmdlet, IExecutor
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
        
        #region Parameter TargetAwsAccount
        /// <summary>
        /// <para>
        /// <para>The AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetAwsAccount { get; set; }
        #endregion
        
        #region Parameter TransferMessage
        /// <summary>
        /// <para>
        /// <para>The transfer message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TransferMessage { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-IOTCertificateTransfer (TransferCertificate)"))
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
            context.TargetAwsAccount = this.TargetAwsAccount;
            context.TransferMessage = this.TransferMessage;
            
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
            var request = new Amazon.IoT.Model.TransferCertificateRequest();
            
            if (cmdletContext.CertificateId != null)
            {
                request.CertificateId = cmdletContext.CertificateId;
            }
            if (cmdletContext.TargetAwsAccount != null)
            {
                request.TargetAwsAccount = cmdletContext.TargetAwsAccount;
            }
            if (cmdletContext.TransferMessage != null)
            {
                request.TransferMessage = cmdletContext.TransferMessage;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TransferredCertificateArn;
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
        
        private Amazon.IoT.Model.TransferCertificateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.TransferCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "TransferCertificate");
            try
            {
                #if DESKTOP
                return client.TransferCertificate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.TransferCertificateAsync(request);
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
            public System.String TargetAwsAccount { get; set; }
            public System.String TransferMessage { get; set; }
        }
        
    }
}
