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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Given an identity (an email address or a domain), enables or disables whether Amazon
    /// SES forwards bounce and complaint notifications as email. Feedback forwarding can
    /// only be disabled when Amazon Simple Notification Service (Amazon SNS) topics are specified
    /// for both bounces and complaints.
    /// 
    ///  <note><para>
    /// Feedback forwarding does not apply to delivery notifications. Delivery notifications
    /// are only available through Amazon SNS.
    /// </para></note><para>
    /// You can execute this operation no more than once per second.
    /// </para><para>
    /// For more information about using notifications with Amazon SES, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/monitor-sending-activity-using-notifications.html">Amazon
    /// SES Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "SESIdentityFeedbackForwardingEnabled", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) SetIdentityFeedbackForwardingEnabled API operation.", Operation = new[] {"SetIdentityFeedbackForwardingEnabled"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.SetIdentityFeedbackForwardingEnabledResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmail.Model.SetIdentityFeedbackForwardingEnabledResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmail.Model.SetIdentityFeedbackForwardingEnabledResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetSESIdentityFeedbackForwardingEnabledCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ForwardingEnabled
        /// <summary>
        /// <para>
        /// <para>Sets whether Amazon SES forwards bounce and complaint notifications as email. <c>true</c>
        /// specifies that Amazon SES forwards bounce and complaint notifications as email, in
        /// addition to any Amazon SNS topic publishing otherwise specified. <c>false</c> specifies
        /// that Amazon SES publishes bounce and complaint notifications only through Amazon SNS.
        /// This value can only be set to <c>false</c> when Amazon SNS topics are set for both
        /// <c>Bounce</c> and <c>Complaint</c> notification types.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? ForwardingEnabled { get; set; }
        #endregion
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>The identity for which to set bounce and complaint notification forwarding. Examples:
        /// <c>user@example.com</c>, <c>example.com</c>.</para>
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
        public System.String Identity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.SetIdentityFeedbackForwardingEnabledResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SESIdentityFeedbackForwardingEnabled (SetIdentityFeedbackForwardingEnabled)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.SetIdentityFeedbackForwardingEnabledResponse, SetSESIdentityFeedbackForwardingEnabledCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ForwardingEnabled = this.ForwardingEnabled;
            #if MODULAR
            if (this.ForwardingEnabled == null && ParameterWasBound(nameof(this.ForwardingEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter ForwardingEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identity = this.Identity;
            #if MODULAR
            if (this.Identity == null && ParameterWasBound(nameof(this.Identity)))
            {
                WriteWarning("You are passing $null as a value for parameter Identity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmail.Model.SetIdentityFeedbackForwardingEnabledRequest();
            
            if (cmdletContext.ForwardingEnabled != null)
            {
                request.ForwardingEnabled = cmdletContext.ForwardingEnabled.Value;
            }
            if (cmdletContext.Identity != null)
            {
                request.Identity = cmdletContext.Identity;
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
        
        private Amazon.SimpleEmail.Model.SetIdentityFeedbackForwardingEnabledResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SetIdentityFeedbackForwardingEnabledRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "SetIdentityFeedbackForwardingEnabled");
            try
            {
                return client.SetIdentityFeedbackForwardingEnabledAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ForwardingEnabled { get; set; }
            public System.String Identity { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.SetIdentityFeedbackForwardingEnabledResponse, SetSESIdentityFeedbackForwardingEnabledCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
