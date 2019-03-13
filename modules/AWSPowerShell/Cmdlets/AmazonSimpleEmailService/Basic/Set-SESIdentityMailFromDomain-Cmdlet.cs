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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Enables or disables the custom MAIL FROM domain setup for a verified identity (an
    /// email address or a domain).
    /// 
    ///  <important><para>
    /// To send emails using the specified MAIL FROM domain, you must add an MX record to
    /// your MAIL FROM domain's DNS settings. If you want your emails to pass Sender Policy
    /// Framework (SPF) checks, you must also add or update an SPF record. For more information,
    /// see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/mail-from-set.html">Amazon
    /// SES Developer Guide</a>.
    /// </para></important><para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "SESIdentityMailFromDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service SetIdentityMailFromDomain API operation.", Operation = new[] {"SetIdentityMailFromDomain"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Identity parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SimpleEmail.Model.SetIdentityMailFromDomainResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetSESIdentityMailFromDomainCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter BehaviorOnMXFailure
        /// <summary>
        /// <para>
        /// <para>The action that you want Amazon SES to take if it cannot successfully read the required
        /// MX record when you send an email. If you choose <code>UseDefaultValue</code>, Amazon
        /// SES will use amazonses.com (or a subdomain of that) as the MAIL FROM domain. If you
        /// choose <code>RejectMessage</code>, Amazon SES will return a <code>MailFromDomainNotVerified</code>
        /// error and not send the email.</para><para>The action specified in <code>BehaviorOnMXFailure</code> is taken when the custom
        /// MAIL FROM domain setup is in the <code>Pending</code>, <code>Failed</code>, and <code>TemporaryFailure</code>
        /// states.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [AWSConstantClassSource("Amazon.SimpleEmail.BehaviorOnMXFailure")]
        public Amazon.SimpleEmail.BehaviorOnMXFailure BehaviorOnMXFailure { get; set; }
        #endregion
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>The verified identity for which you want to enable or disable the specified custom
        /// MAIL FROM domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Identity { get; set; }
        #endregion
        
        #region Parameter MailFromDomain
        /// <summary>
        /// <para>
        /// <para>The custom MAIL FROM domain that you want the verified identity to use. The MAIL FROM
        /// domain must 1) be a subdomain of the verified identity, 2) not be used in a "From"
        /// address if the MAIL FROM domain is the destination of email feedback forwarding (for
        /// more information, see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/mail-from.html">Amazon
        /// SES Developer Guide</a>), and 3) not be used to receive emails. A value of <code>null</code>
        /// disables the custom MAIL FROM setting for the identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String MailFromDomain { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Identity parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Identity", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SESIdentityMailFromDomain (SetIdentityMailFromDomain)"))
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
            
            context.BehaviorOnMXFailure = this.BehaviorOnMXFailure;
            context.Identity = this.Identity;
            context.MailFromDomain = this.MailFromDomain;
            
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
            var request = new Amazon.SimpleEmail.Model.SetIdentityMailFromDomainRequest();
            
            if (cmdletContext.BehaviorOnMXFailure != null)
            {
                request.BehaviorOnMXFailure = cmdletContext.BehaviorOnMXFailure;
            }
            if (cmdletContext.Identity != null)
            {
                request.Identity = cmdletContext.Identity;
            }
            if (cmdletContext.MailFromDomain != null)
            {
                request.MailFromDomain = cmdletContext.MailFromDomain;
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
                    pipelineOutput = this.Identity;
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
        
        private Amazon.SimpleEmail.Model.SetIdentityMailFromDomainResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SetIdentityMailFromDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "SetIdentityMailFromDomain");
            try
            {
                #if DESKTOP
                return client.SetIdentityMailFromDomain(request);
                #elif CORECLR
                return client.SetIdentityMailFromDomainAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SimpleEmail.BehaviorOnMXFailure BehaviorOnMXFailure { get; set; }
            public System.String Identity { get; set; }
            public System.String MailFromDomain { get; set; }
        }
        
    }
}
