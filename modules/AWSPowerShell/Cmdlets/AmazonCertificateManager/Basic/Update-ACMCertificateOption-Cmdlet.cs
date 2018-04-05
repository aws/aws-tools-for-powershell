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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Updates a certificate. Currently, you can use this function to specify whether to
    /// opt in to or out of recording your certificate in a certificate transparency log.
    /// For more information, see <a href="http://docs.aws.amazon.com/http:/docs.aws.amazon.comacm/latest/userguide/acm-bestpractices.html#best-practices-transparency">
    /// Opting Out of Certificate Transparency Logging</a>.
    /// </summary>
    [Cmdlet("Update", "ACMCertificateOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager UpdateCertificateOptions API operation.", Operation = new[] {"UpdateCertificateOptions"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the CertificateArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CertificateManager.Model.UpdateCertificateOptionsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateACMCertificateOptionCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>ARN of the requested certificate to update. This must be of the form:</para><para><code>arn:aws:acm:us-east-1:<i>account</i>:certificate/<i>12345678-1234-1234-1234-123456789012</i></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter Options_CertificateTransparencyLoggingPreference
        /// <summary>
        /// <para>
        /// <para>You can opt out of certificate transparency logging by specifying the <code>DISABLED</code>
        /// option. Opt in by specifying <code>ENABLED</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CertificateManager.CertificateTransparencyLoggingPreference")]
        public Amazon.CertificateManager.CertificateTransparencyLoggingPreference Options_CertificateTransparencyLoggingPreference { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the CertificateArn parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificateArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ACMCertificateOption (UpdateCertificateOptions)"))
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
            
            context.CertificateArn = this.CertificateArn;
            context.Options_CertificateTransparencyLoggingPreference = this.Options_CertificateTransparencyLoggingPreference;
            
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
            var request = new Amazon.CertificateManager.Model.UpdateCertificateOptionsRequest();
            
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
            }
            
             // populate Options
            bool requestOptionsIsNull = true;
            request.Options = new Amazon.CertificateManager.Model.CertificateOptions();
            Amazon.CertificateManager.CertificateTransparencyLoggingPreference requestOptions_options_CertificateTransparencyLoggingPreference = null;
            if (cmdletContext.Options_CertificateTransparencyLoggingPreference != null)
            {
                requestOptions_options_CertificateTransparencyLoggingPreference = cmdletContext.Options_CertificateTransparencyLoggingPreference;
            }
            if (requestOptions_options_CertificateTransparencyLoggingPreference != null)
            {
                request.Options.CertificateTransparencyLoggingPreference = requestOptions_options_CertificateTransparencyLoggingPreference;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
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
                    pipelineOutput = this.CertificateArn;
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
        
        private Amazon.CertificateManager.Model.UpdateCertificateOptionsResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.UpdateCertificateOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "UpdateCertificateOptions");
            try
            {
                #if DESKTOP
                return client.UpdateCertificateOptions(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateCertificateOptionsAsync(request);
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
            public System.String CertificateArn { get; set; }
            public Amazon.CertificateManager.CertificateTransparencyLoggingPreference Options_CertificateTransparencyLoggingPreference { get; set; }
        }
        
    }
}
