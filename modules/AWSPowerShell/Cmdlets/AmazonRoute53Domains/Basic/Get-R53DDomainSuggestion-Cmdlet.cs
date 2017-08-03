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
    /// The GetDomainSuggestions operation returns a list of suggested domain names given
    /// a string, which can either be a domain name or simply a word or phrase (without spaces).
    /// </summary>
    [Cmdlet("Get", "R53DDomainSuggestion")]
    [OutputType("Amazon.Route53Domains.Model.DomainSuggestion")]
    [AWSCmdlet("Invokes the GetDomainSuggestions operation against Amazon Route 53 Domains.", Operation = new[] {"GetDomainSuggestions"})]
    [AWSCmdletOutput("Amazon.Route53Domains.Model.DomainSuggestion",
        "This cmdlet returns a collection of DomainSuggestion objects.",
        "The service call response (type Amazon.Route53Domains.Model.GetDomainSuggestionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53DDomainSuggestionCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>A domain name that you want to use as the basis for a list of possible domain names.
        /// The domain name must contain a top-level domain (TLD), such as .com, that Amazon Route
        /// 53 supports. For a list of TLDs, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter OnlyAvailable
        /// <summary>
        /// <para>
        /// <para>If <code>OnlyAvailable</code> is <code>true</code>, Amazon Route 53 returns only domain
        /// names that are available. If <code>OnlyAvailable</code> is <code>false</code>, Amazon
        /// Route 53 returns domain names without checking whether they're available to be registered.
        /// To determine whether the domain is available, you can call <code>checkDomainAvailability</code>
        /// for each suggestion.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean OnlyAvailable { get; set; }
        #endregion
        
        #region Parameter SuggestionCount
        /// <summary>
        /// <para>
        /// <para>The number of suggested domain names that you want Amazon Route 53 to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SuggestionCount { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DomainName = this.DomainName;
            if (ParameterWasBound("OnlyAvailable"))
                context.OnlyAvailable = this.OnlyAvailable;
            if (ParameterWasBound("SuggestionCount"))
                context.SuggestionCount = this.SuggestionCount;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SuggestionsList;
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
        
        private Amazon.Route53Domains.Model.GetDomainSuggestionsResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.GetDomainSuggestionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "GetDomainSuggestions");
            #if DESKTOP
            return client.GetDomainSuggestions(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetDomainSuggestionsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String DomainName { get; set; }
            public System.Boolean? OnlyAvailable { get; set; }
            public System.Int32? SuggestionCount { get; set; }
        }
        
    }
}
