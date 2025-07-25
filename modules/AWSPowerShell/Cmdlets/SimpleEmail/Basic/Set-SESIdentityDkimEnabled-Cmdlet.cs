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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Enables or disables Easy DKIM signing of email sent from an identity. If Easy DKIM
    /// signing is enabled for a domain, then Amazon SES uses DKIM to sign all email that
    /// it sends from addresses on that domain. If Easy DKIM signing is enabled for an email
    /// address, then Amazon SES uses DKIM to sign all email it sends from that address.
    /// 
    ///  <note><para>
    /// For email addresses (for example, <c>user@example.com</c>), you can only enable DKIM
    /// signing if the corresponding domain (in this case, <c>example.com</c>) has been set
    /// up to use Easy DKIM.
    /// </para></note><para>
    /// You can enable DKIM signing for an identity at any time after you start the verification
    /// process for the identity, even if the verification process isn't complete. 
    /// </para><para>
    /// You can execute this operation no more than once per second.
    /// </para><para>
    /// For more information about Easy DKIM signing, go to the <a href="https://docs.aws.amazon.com/ses/latest/dg/send-email-authentication-dkim-easy.html">Amazon
    /// SES Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "SESIdentityDkimEnabled", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) SetIdentityDkimEnabled API operation.", Operation = new[] {"SetIdentityDkimEnabled"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.SetIdentityDkimEnabledResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmail.Model.SetIdentityDkimEnabledResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmail.Model.SetIdentityDkimEnabledResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetSESIdentityDkimEnabledCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DkimEnabled
        /// <summary>
        /// <para>
        /// <para>Sets whether DKIM signing is enabled for an identity. Set to <c>true</c> to enable
        /// DKIM signing for this identity; <c>false</c> to disable it. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? DkimEnabled { get; set; }
        #endregion
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>The identity for which DKIM signing should be enabled or disabled.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.SetIdentityDkimEnabledResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SESIdentityDkimEnabled (SetIdentityDkimEnabled)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.SetIdentityDkimEnabledResponse, SetSESIdentityDkimEnabledCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DkimEnabled = this.DkimEnabled;
            #if MODULAR
            if (this.DkimEnabled == null && ParameterWasBound(nameof(this.DkimEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter DkimEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmail.Model.SetIdentityDkimEnabledRequest();
            
            if (cmdletContext.DkimEnabled != null)
            {
                request.DkimEnabled = cmdletContext.DkimEnabled.Value;
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
        
        private Amazon.SimpleEmail.Model.SetIdentityDkimEnabledResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SetIdentityDkimEnabledRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "SetIdentityDkimEnabled");
            try
            {
                return client.SetIdentityDkimEnabledAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DkimEnabled { get; set; }
            public System.String Identity { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.SetIdentityDkimEnabledResponse, SetSESIdentityDkimEnabledCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
