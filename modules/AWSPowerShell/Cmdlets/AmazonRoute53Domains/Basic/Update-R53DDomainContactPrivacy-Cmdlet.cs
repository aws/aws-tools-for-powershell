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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// This operation updates the specified domain contact's privacy setting. When the privacy
    /// option is enabled, personal information such as postal or email address is hidden
    /// from the results of a public WHOIS query. The privacy services are provided by the
    /// AWS registrar, Gandi. For more information, see the <a href="http://www.gandi.net/domain/whois/?currency=USD&amp;amp;lang=en">Gandi
    /// privacy features</a>.
    /// 
    ///  
    /// <para>
    /// This operation only affects the privacy of the specified contact type (registrant,
    /// administrator, or tech). Successful acceptance returns an operation ID that you can
    /// use with <a>GetOperationDetail</a> to track the progress and completion of the action.
    /// If the request is not completed successfully, the domain registrant will be notified
    /// by email.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53DDomainContactPrivacy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains UpdateDomainContactPrivacy API operation.", Operation = new[] {"UpdateDomainContactPrivacy"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateR53DDomainContactPrivacyCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        #region Parameter AdminPrivacy
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <code>true</code>, WHOIS ("who is") queries will return contact information for our
        /// registrar partner, Gandi, instead of the contact information that you enter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AdminPrivacy { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to update the privacy setting for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter RegistrantPrivacy
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <code>true</code>, WHOIS ("who is") queries will return contact information for our
        /// registrar partner, Gandi, instead of the contact information that you enter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RegistrantPrivacy { get; set; }
        #endregion
        
        #region Parameter TechPrivacy
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <code>true</code>, WHOIS ("who is") queries will return contact information for our
        /// registrar partner, Gandi, instead of the contact information that you enter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean TechPrivacy { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53DDomainContactPrivacy (UpdateDomainContactPrivacy)"))
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
            
            if (ParameterWasBound("AdminPrivacy"))
                context.AdminPrivacy = this.AdminPrivacy;
            context.DomainName = this.DomainName;
            if (ParameterWasBound("RegistrantPrivacy"))
                context.RegistrantPrivacy = this.RegistrantPrivacy;
            if (ParameterWasBound("TechPrivacy"))
                context.TechPrivacy = this.TechPrivacy;
            
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
            var request = new Amazon.Route53Domains.Model.UpdateDomainContactPrivacyRequest();
            
            if (cmdletContext.AdminPrivacy != null)
            {
                request.AdminPrivacy = cmdletContext.AdminPrivacy.Value;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.RegistrantPrivacy != null)
            {
                request.RegistrantPrivacy = cmdletContext.RegistrantPrivacy.Value;
            }
            if (cmdletContext.TechPrivacy != null)
            {
                request.TechPrivacy = cmdletContext.TechPrivacy.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.OperationId;
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
        
        private Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.UpdateDomainContactPrivacyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "UpdateDomainContactPrivacy");
            try
            {
                #if DESKTOP
                return client.UpdateDomainContactPrivacy(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateDomainContactPrivacyAsync(request);
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
            public System.Boolean? AdminPrivacy { get; set; }
            public System.String DomainName { get; set; }
            public System.Boolean? RegistrantPrivacy { get; set; }
            public System.Boolean? TechPrivacy { get; set; }
        }
        
    }
}
