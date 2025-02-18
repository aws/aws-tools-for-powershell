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
    /// Given an identity (an email address or a domain), sets whether Amazon SES includes
    /// the original email headers in the Amazon Simple Notification Service (Amazon SNS)
    /// notifications of a specified type.
    /// 
    ///  
    /// <para>
    /// You can execute this operation no more than once per second.
    /// </para><para>
    /// For more information about using notifications with Amazon SES, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/monitor-sending-activity-using-notifications.html">Amazon
    /// SES Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "SESIdentityHeadersInNotificationsEnabled", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) SetIdentityHeadersInNotificationsEnabled API operation.", Operation = new[] {"SetIdentityHeadersInNotificationsEnabled"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.SetIdentityHeadersInNotificationsEnabledResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmail.Model.SetIdentityHeadersInNotificationsEnabledResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmail.Model.SetIdentityHeadersInNotificationsEnabledResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetSESIdentityHeadersInNotificationsEnabledCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Sets whether Amazon SES includes the original email headers in Amazon SNS notifications
        /// of the specified notification type. A value of <c>true</c> specifies that Amazon SES
        /// includes headers in notifications, and a value of <c>false</c> specifies that Amazon
        /// SES does not include headers in notifications.</para><para>This value can only be set when <c>NotificationType</c> is already set to use a particular
        /// Amazon SNS topic.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>The identity for which to enable or disable headers in notifications. Examples: <c>user@example.com</c>,
        /// <c>example.com</c>.</para>
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
        
        #region Parameter NotificationType
        /// <summary>
        /// <para>
        /// <para>The notification type for which to enable or disable headers in notifications. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmail.NotificationType")]
        public Amazon.SimpleEmail.NotificationType NotificationType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.SetIdentityHeadersInNotificationsEnabledResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SESIdentityHeadersInNotificationsEnabled (SetIdentityHeadersInNotificationsEnabled)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.SetIdentityHeadersInNotificationsEnabledResponse, SetSESIdentityHeadersInNotificationsEnabledCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Enabled = this.Enabled;
            #if MODULAR
            if (this.Enabled == null && ParameterWasBound(nameof(this.Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identity = this.Identity;
            #if MODULAR
            if (this.Identity == null && ParameterWasBound(nameof(this.Identity)))
            {
                WriteWarning("You are passing $null as a value for parameter Identity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationType = this.NotificationType;
            #if MODULAR
            if (this.NotificationType == null && ParameterWasBound(nameof(this.NotificationType)))
            {
                WriteWarning("You are passing $null as a value for parameter NotificationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmail.Model.SetIdentityHeadersInNotificationsEnabledRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.Identity != null)
            {
                request.Identity = cmdletContext.Identity;
            }
            if (cmdletContext.NotificationType != null)
            {
                request.NotificationType = cmdletContext.NotificationType;
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
        
        private Amazon.SimpleEmail.Model.SetIdentityHeadersInNotificationsEnabledResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SetIdentityHeadersInNotificationsEnabledRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "SetIdentityHeadersInNotificationsEnabled");
            try
            {
                return client.SetIdentityHeadersInNotificationsEnabledAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Enabled { get; set; }
            public System.String Identity { get; set; }
            public Amazon.SimpleEmail.NotificationType NotificationType { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.SetIdentityHeadersInNotificationsEnabledResponse, SetSESIdentityHeadersInNotificationsEnabledCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
