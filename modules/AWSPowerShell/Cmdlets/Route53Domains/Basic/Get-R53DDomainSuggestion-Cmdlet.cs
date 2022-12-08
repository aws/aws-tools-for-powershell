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
    /// The GetDomainSuggestions operation returns a list of suggested domain names.
    /// </summary>
    [Cmdlet("Get", "R53DDomainSuggestion")]
    [OutputType("Amazon.Route53Domains.Model.DomainSuggestion")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains GetDomainSuggestions API operation.", Operation = new[] {"GetDomainSuggestions"}, SelectReturnType = typeof(Amazon.Route53Domains.Model.GetDomainSuggestionsResponse))]
    [AWSCmdletOutput("Amazon.Route53Domains.Model.DomainSuggestion or Amazon.Route53Domains.Model.GetDomainSuggestionsResponse",
        "This cmdlet returns a collection of Amazon.Route53Domains.Model.DomainSuggestion objects.",
        "The service call response (type Amazon.Route53Domains.Model.GetDomainSuggestionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53DDomainSuggestionCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>A domain name that you want to use as the basis for a list of possible domain names.
        /// The top-level domain (TLD), such as .com, must be a TLD that Route 53 supports. For
        /// a list of supported TLDs, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i>.</para><para>The domain name can contain only the following characters:</para><ul><li><para>Letters a through z. Domain names are not case sensitive.</para></li><li><para>Numbers 0 through 9.</para></li><li><para>Hyphen (-). You can't specify a hyphen at the beginning or end of a label. </para></li><li><para>Period (.) to separate the labels in the name, such as the <code>.</code> in <code>example.com</code>.</para></li></ul><para>Internationalized domain names are not supported for some top-level domains. To determine
        /// whether the TLD that you want to use supports internationalized domain names, see
        /// <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a>. </para>
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
        
        #region Parameter OnlyAvailable
        /// <summary>
        /// <para>
        /// <para>If <code>OnlyAvailable</code> is <code>true</code>, Route 53 returns only domain names
        /// that are available. If <code>OnlyAvailable</code> is <code>false</code>, Route 53
        /// returns domain names without checking whether they're available to be registered.
        /// To determine whether the domain is available, you can call <code>checkDomainAvailability</code>
        /// for each suggestion.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? OnlyAvailable { get; set; }
        #endregion
        
        #region Parameter SuggestionCount
        /// <summary>
        /// <para>
        /// <para>The number of suggested domain names that you want Route 53 to return. Specify a value
        /// between 1 and 50.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? SuggestionCount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SuggestionsList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Domains.Model.GetDomainSuggestionsResponse).
        /// Specifying the name of a property of type Amazon.Route53Domains.Model.GetDomainSuggestionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SuggestionsList";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Domains.Model.GetDomainSuggestionsResponse, GetR53DDomainSuggestionCmdlet>(Select) ??
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
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OnlyAvailable = this.OnlyAvailable;
            #if MODULAR
            if (this.OnlyAvailable == null && ParameterWasBound(nameof(this.OnlyAvailable)))
            {
                WriteWarning("You are passing $null as a value for parameter OnlyAvailable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SuggestionCount = this.SuggestionCount;
            #if MODULAR
            if (this.SuggestionCount == null && ParameterWasBound(nameof(this.SuggestionCount)))
            {
                WriteWarning("You are passing $null as a value for parameter SuggestionCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53Domains.Model.GetDomainSuggestionsRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.OnlyAvailable != null)
            {
                request.OnlyAvailable = cmdletContext.OnlyAvailable.Value;
            }
            if (cmdletContext.SuggestionCount != null)
            {
                request.SuggestionCount = cmdletContext.SuggestionCount.Value;
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
        
        private Amazon.Route53Domains.Model.GetDomainSuggestionsResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.GetDomainSuggestionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "GetDomainSuggestions");
            try
            {
                #if DESKTOP
                return client.GetDomainSuggestions(request);
                #elif CORECLR
                return client.GetDomainSuggestionsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? OnlyAvailable { get; set; }
            public System.Int32? SuggestionCount { get; set; }
            public System.Func<Amazon.Route53Domains.Model.GetDomainSuggestionsResponse, GetR53DDomainSuggestionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SuggestionsList;
        }
        
    }
}
