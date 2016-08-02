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
    /// 
    ///  
    /// <para>
    ///  Parameters: <ul><li>DomainName (string): The basis for your domain suggestion search,
    /// a string with (or without) top-level domain specified.</li><li>SuggestionCount (int):
    /// The number of domain suggestions to be returned, maximum 50, minimum 1.</li><li>OnlyAvailable
    /// (bool): If true, availability check will be performed on suggestion results, and only
    /// available domains will be returned. If false, suggestions will be returned without
    /// checking whether the domain is actually available, and caller will have to call checkDomainAvailability
    /// for each suggestion to determine availability for registration.</li></ul></para>
    /// </summary>
    [Cmdlet("Get", "R53DDomainSuggestion")]
    [OutputType("Amazon.Route53Domains.Model.DomainSuggestion")]
    [AWSCmdlet("Invokes the GetDomainSuggestions operation against Amazon Route 53 Domains.", Operation = new[] {"GetDomainSuggestions"})]
    [AWSCmdletOutput("Amazon.Route53Domains.Model.DomainSuggestion",
        "This cmdlet returns a collection of DomainSuggestion objects.",
        "The service call response (type Amazon.Route53Domains.Model.GetDomainSuggestionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetR53DDomainSuggestionCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter OnlyAvailable
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean OnlyAvailable { get; set; }
        #endregion
        
        #region Parameter SuggestionCount
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
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
            
            context.DomainName = this.DomainName;
            if (ParameterWasBound("OnlyAvailable"))
                context.OnlyAvailable = this.OnlyAvailable;
            if (ParameterWasBound("SuggestionCount"))
                context.SuggestionCount = this.SuggestionCount;
            
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
        
        private static Amazon.Route53Domains.Model.GetDomainSuggestionsResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.GetDomainSuggestionsRequest request)
        {
            return client.GetDomainSuggestions(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DomainName { get; set; }
            public System.Boolean? OnlyAvailable { get; set; }
            public System.Int32? SuggestionCount { get; set; }
        }
        
    }
}
