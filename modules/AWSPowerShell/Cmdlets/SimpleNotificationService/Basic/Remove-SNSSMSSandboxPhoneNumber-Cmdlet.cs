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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Deletes an Amazon Web Services account's verified or pending phone number from the
    /// SMS sandbox.
    /// 
    ///  
    /// <para>
    /// When you start using Amazon SNS to send SMS messages, your Amazon Web Services account
    /// is in the <i>SMS sandbox</i>. The SMS sandbox provides a safe environment for you
    /// to try Amazon SNS features without risking your reputation as an SMS sender. While
    /// your Amazon Web Services account is in the SMS sandbox, you can use all of the features
    /// of Amazon SNS. However, you can send SMS messages only to verified destination phone
    /// numbers. For more information, including how to move out of the sandbox to send messages
    /// without restrictions, see <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-sms-sandbox.html">SMS
    /// sandbox</a> in the <i>Amazon SNS Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "SNSSMSSandboxPhoneNumber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) DeleteSMSSandboxPhoneNumber API operation.", Operation = new[] {"DeleteSMSSandboxPhoneNumber"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.DeleteSMSSandboxPhoneNumberResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleNotificationService.Model.DeleteSMSSandboxPhoneNumberResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleNotificationService.Model.DeleteSMSSandboxPhoneNumberResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveSNSSMSSandboxPhoneNumberCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The destination phone number to delete.</para>
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
        public System.String PhoneNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.DeleteSMSSandboxPhoneNumberResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PhoneNumber), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SNSSMSSandboxPhoneNumber (DeleteSMSSandboxPhoneNumber)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.DeleteSMSSandboxPhoneNumberResponse, RemoveSNSSMSSandboxPhoneNumberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PhoneNumber = this.PhoneNumber;
            #if MODULAR
            if (this.PhoneNumber == null && ParameterWasBound(nameof(this.PhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter PhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleNotificationService.Model.DeleteSMSSandboxPhoneNumberRequest();
            
            if (cmdletContext.PhoneNumber != null)
            {
                request.PhoneNumber = cmdletContext.PhoneNumber;
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
        
        private Amazon.SimpleNotificationService.Model.DeleteSMSSandboxPhoneNumberResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.DeleteSMSSandboxPhoneNumberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "DeleteSMSSandboxPhoneNumber");
            try
            {
                return client.DeleteSMSSandboxPhoneNumberAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PhoneNumber { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.DeleteSMSSandboxPhoneNumberResponse, RemoveSNSSMSSandboxPhoneNumberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
