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
using Amazon.IoT;
using Amazon.IoT.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Transfers the specified certificate to the specified Amazon Web Services account.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">TransferCertificate</a>
    /// action.
    /// </para><para>
    /// You can cancel the transfer until it is acknowledged by the recipient.
    /// </para><para>
    /// No notification is sent to the transfer destination's account. It's up to the caller
    /// to notify the transfer target.
    /// </para><para>
    /// The certificate being transferred must not be in the <c>ACTIVE</c> state. You can
    /// use the <a>UpdateCertificate</a> action to deactivate it.
    /// </para><para>
    /// The certificate must not have any policies attached to it. You can use the <a>DetachPolicy</a>
    /// action to detach them.
    /// </para><para><b>Customer managed key behavior:</b> When you use a customer managed key to secure
    /// your data and then transfer the key to a customer in a different account using the
    /// <a>TransferCertificate</a> operation, the certificates will no longer be protected
    /// by their customer managed key configuration. During the transfer process, certificates
    /// are encrypted using IoT owned keys.
    /// </para><para>
    /// While a certificate is in the <b>PENDING_TRANSFER</b> state, it's always protected
    /// by IoT owned keys, regardless of the customer managed key configuration of either
    /// the source or destination account. 
    /// </para><para>
    /// Once the transfer is completed through <a>AcceptCertificateTransfer</a>, <a>RejectCertificateTransfer</a>,
    /// or <a>CancelCertificateTransfer</a>, the certificate will be protected by the customer
    /// managed key configuration of the account that owns the certificate after the transfer
    /// operation:
    /// </para><ul><li><para>
    /// If the transfer is accepted: The certificate is protected by the destination account's
    /// customer managed key configuration.
    /// </para></li><li><para>
    /// If the transfer is rejected or cancelled: The certificate is protected by the source
    /// account's customer managed key configuration.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Request", "IOTCertificateTransfer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT TransferCertificate API operation.", Operation = new[] {"TransferCertificate"}, SelectReturnType = typeof(Amazon.IoT.Model.TransferCertificateResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoT.Model.TransferCertificateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoT.Model.TransferCertificateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RequestIOTCertificateTransferCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateId
        /// <summary>
        /// <para>
        /// <para>The ID of the certificate. (The last part of the certificate ARN contains the certificate
        /// ID.)</para>
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
        public System.String CertificateId { get; set; }
        #endregion
        
        #region Parameter TargetAwsAccount
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account.</para>
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
        public System.String TargetAwsAccount { get; set; }
        #endregion
        
        #region Parameter TransferMessage
        /// <summary>
        /// <para>
        /// <para>The transfer message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransferMessage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransferredCertificateArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.TransferCertificateResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.TransferCertificateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransferredCertificateArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-IOTCertificateTransfer (TransferCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.TransferCertificateResponse, RequestIOTCertificateTransferCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateId = this.CertificateId;
            #if MODULAR
            if (this.CertificateId == null && ParameterWasBound(nameof(this.CertificateId)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetAwsAccount = this.TargetAwsAccount;
            #if MODULAR
            if (this.TargetAwsAccount == null && ParameterWasBound(nameof(this.TargetAwsAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetAwsAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
        
        private Amazon.IoT.Model.TransferCertificateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.TransferCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "TransferCertificate");
            try
            {
                return client.TransferCertificateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.IoT.Model.TransferCertificateResponse, RequestIOTCertificateTransferCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransferredCertificateArn;
        }
        
    }
}
