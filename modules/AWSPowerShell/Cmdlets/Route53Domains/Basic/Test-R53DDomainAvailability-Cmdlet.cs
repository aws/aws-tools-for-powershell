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
    /// This operation checks the availability of one domain name. Note that if the availability
    /// status of a domain is pending, you must submit another request to determine the availability
    /// of the domain name.
    /// </summary>
    [Cmdlet("Test", "R53DDomainAvailability")]
    [OutputType("Amazon.Route53Domains.DomainAvailability")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains CheckDomainAvailability API operation.", Operation = new[] {"CheckDomainAvailability"}, SelectReturnType = typeof(Amazon.Route53Domains.Model.CheckDomainAvailabilityResponse), LegacyAlias="Get-R53DDomainAvailability")]
    [AWSCmdletOutput("Amazon.Route53Domains.DomainAvailability or Amazon.Route53Domains.Model.CheckDomainAvailabilityResponse",
        "This cmdlet returns an Amazon.Route53Domains.DomainAvailability object.",
        "The service call response (type Amazon.Route53Domains.Model.CheckDomainAvailabilityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestR53DDomainAvailabilityCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to get availability for. The top-level domain
        /// (TLD), such as .com, must be a TLD that Route 53 supports. For a list of supported
        /// TLDs, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i>.</para><para>The domain name can contain only the following characters:</para><ul><li><para>Letters a through z. Domain names are not case sensitive.</para></li><li><para>Numbers 0 through 9.</para></li><li><para>Hyphen (-). You can't specify a hyphen at the beginning or end of a label. </para></li><li><para>Period (.) to separate the labels in the name, such as the <c>.</c> in <c>example.com</c>.</para></li></ul><para>Internationalized domain names are not supported for some top-level domains. To determine
        /// whether the TLD that you want to use supports internationalized domain names, see
        /// <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a>. For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DomainNameFormat.html#domain-name-format-idns">Formatting
        /// Internationalized Domain Names</a>. </para>
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
        
        #region Parameter IdnLangCode
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdnLangCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Availability'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Domains.Model.CheckDomainAvailabilityResponse).
        /// Specifying the name of a property of type Amazon.Route53Domains.Model.CheckDomainAvailabilityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Availability";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Domains.Model.CheckDomainAvailabilityResponse, TestR53DDomainAvailabilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdnLangCode = this.IdnLangCode;
            
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
            var request = new Amazon.Route53Domains.Model.CheckDomainAvailabilityRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.IdnLangCode != null)
            {
                request.IdnLangCode = cmdletContext.IdnLangCode;
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
        
        private Amazon.Route53Domains.Model.CheckDomainAvailabilityResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.CheckDomainAvailabilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "CheckDomainAvailability");
            try
            {
                #if DESKTOP
                return client.CheckDomainAvailability(request);
                #elif CORECLR
                return client.CheckDomainAvailabilityAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.String IdnLangCode { get; set; }
            public System.Func<Amazon.Route53Domains.Model.CheckDomainAvailabilityResponse, TestR53DDomainAvailabilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Availability;
        }
        
    }
}
