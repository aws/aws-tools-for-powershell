/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// This operation updates the specified domain contact's privacy setting. When privacy
    /// protection is enabled, contact information such as email address is replaced either
    /// with contact information for Amazon Registrar (for .com, .net, and .org domains) or
    /// with contact information for our registrar associate, Gandi.
    /// 
    ///  
    /// <para>
    /// This operation affects only the contact information for the specified contact type
    /// (registrant, administrator, or tech). If the request succeeds, Amazon Route 53 returns
    /// an operation ID that you can use with <a>GetOperationDetail</a> to track the progress
    /// and completion of the action. If the request doesn't complete successfully, the domain
    /// registrant will be notified by email.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53DDomainContactPrivacy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains UpdateDomainContactPrivacy API operation.", Operation = new[] {"UpdateDomainContactPrivacy"}, SelectReturnType = typeof(Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse))]
    [AWSCmdletOutput("System.String or Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateR53DDomainContactPrivacyCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        #region Parameter AdminPrivacy
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <code>true</code>, WHOIS ("who is") queries return contact information either for
        /// Amazon Registrar (for .com, .net, and .org domains) or for our registrar associate,
        /// Gandi (for all other TLDs). If you specify <code>false</code>, WHOIS queries return
        /// the information that you entered for the admin contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdminPrivacy { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to update the privacy setting for.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter RegistrantPrivacy
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <code>true</code>, WHOIS ("who is") queries return contact information either for
        /// Amazon Registrar (for .com, .net, and .org domains) or for our registrar associate,
        /// Gandi (for all other TLDs). If you specify <code>false</code>, WHOIS queries return
        /// the information that you entered for the registrant contact (domain owner).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RegistrantPrivacy { get; set; }
        #endregion
        
        #region Parameter TechPrivacy
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <code>true</code>, WHOIS ("who is") queries return contact information either for
        /// Amazon Registrar (for .com, .net, and .org domains) or for our registrar associate,
        /// Gandi (for all other TLDs). If you specify <code>false</code>, WHOIS queries return
        /// the information that you entered for the technical contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TechPrivacy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse).
        /// Specifying the name of a property of type Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53DDomainContactPrivacy (UpdateDomainContactPrivacy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse, UpdateR53DDomainContactPrivacyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdminPrivacy = this.AdminPrivacy;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegistrantPrivacy = this.RegistrantPrivacy;
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
        
        private Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.UpdateDomainContactPrivacyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "UpdateDomainContactPrivacy");
            try
            {
                #if DESKTOP
                return client.UpdateDomainContactPrivacy(request);
                #elif CORECLR
                return client.UpdateDomainContactPrivacyAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Route53Domains.Model.UpdateDomainContactPrivacyResponse, UpdateR53DDomainContactPrivacyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
