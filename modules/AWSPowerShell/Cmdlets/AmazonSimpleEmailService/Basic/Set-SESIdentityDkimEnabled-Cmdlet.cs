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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Enables or disables Easy DKIM signing of email sent from an identity:
    /// 
    ///  <ul><li><para>
    /// If Easy DKIM signing is enabled for a domain name identity (e.g., <code>example.com</code>),
    /// then Amazon SES will DKIM-sign all email sent by addresses under that domain name
    /// (e.g., <code>user@example.com</code>).
    /// </para></li><li><para>
    /// If Easy DKIM signing is enabled for an email address, then Amazon SES will DKIM-sign
    /// all email sent by that email address.
    /// </para></li></ul><para>
    /// For email addresses (e.g., <code>user@example.com</code>), you can only enable Easy
    /// DKIM signing if the corresponding domain (e.g., <code>example.com</code>) has been
    /// set up for Easy DKIM using the AWS Console or the <code>VerifyDomainDkim</code> action.
    /// </para><para>
    /// This action is throttled at one request per second.
    /// </para><para>
    /// For more information about Easy DKIM signing, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/easy-dkim.html">Amazon
    /// SES Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "SESIdentityDkimEnabled", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetIdentityDkimEnabled operation against Amazon Simple Email Service.", Operation = new[] {"SetIdentityDkimEnabled"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Identity parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SimpleEmail.Model.SetIdentityDkimEnabledResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetSESIdentityDkimEnabledCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DkimEnabled
        /// <summary>
        /// <para>
        /// <para>Sets whether DKIM signing is enabled for an identity. Set to <code>true</code> to
        /// enable DKIM signing for this identity; <code>false</code> to disable it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Boolean DkimEnabled { get; set; }
        #endregion
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>The identity for which DKIM signing should be enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Identity { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SESIdentityDkimEnabled (SetIdentityDkimEnabled)"))
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
            
            if (ParameterWasBound("DkimEnabled"))
                context.DkimEnabled = this.DkimEnabled;
            context.Identity = this.Identity;
            
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
        
        private Amazon.SimpleEmail.Model.SetIdentityDkimEnabledResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SetIdentityDkimEnabledRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "SetIdentityDkimEnabled");
            try
            {
                #if DESKTOP
                return client.SetIdentityDkimEnabled(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SetIdentityDkimEnabledAsync(request);
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
            public System.Boolean? DkimEnabled { get; set; }
            public System.String Identity { get; set; }
        }
        
    }
}
