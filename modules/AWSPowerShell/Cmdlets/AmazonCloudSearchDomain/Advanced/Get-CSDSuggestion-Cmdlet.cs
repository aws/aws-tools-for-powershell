/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CloudSearchDomain;
using Amazon.CloudSearchDomain.Model;

namespace Amazon.PowerShell.Cmdlets.CSD
{
    /// <summary>
    /// Retrieves autocomplete suggestions for a partial query string. You can use suggestions
    /// enable you to display likely matches before users finish typing. In Amazon CloudSearch,
    /// suggestions are based on the contents of a particular text field. When you request
    /// suggestions, Amazon CloudSearch finds all of the documents whose values in the suggester
    /// field start with the specified query string. The beginning of the field must match
    /// the query string to be considered a match. 
    /// 
    ///       
    /// <para>
    /// For more information about configuring suggesters and retrieving suggestions, see
    /// <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/getting-suggestions.html">Getting
    /// Suggestions</a> in the <i>Amazon CloudSearch Developer Guide</i>. 
    /// </para><para>
    /// The endpoint for submitting <code>Suggest</code> requests is domain-specific. You
    /// submit suggest requests to a domain's search endpoint. To get the search endpoint
    /// for your domain, use the Amazon CloudSearch configuration service <code>DescribeDomains</code>
    /// action. A domain's endpoints are also displayed on the domain dashboard in the Amazon
    /// CloudSearch console. 
    /// </para>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Get-CSDSuggestions</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CSDSuggestion")]
    [OutputType("Amazon.CloudSearchDomain.Model.SuggestResult")]
    [AWSCmdlet("Calls the Amazon CloudSearchDomain Suggest API operation.", Operation = new[] { "Suggest" }, LegacyAlias = "Get-CSDSuggestions")]
    [AWSCmdletOutput("Amazon.CloudSearchDomain.Model.SuggestResult",
        "This cmdlet returns an Amazon.CloudSearchDomain.Model.SuggestResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCSDSuggestionCmdlet : AmazonCloudSearchDomainClientCmdlet, IExecutor
    {
        #region Parameter ServiceUrl
        /// <summary>
        /// Specifies the Search or Document service endpoint.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public System.String ServiceUrl { get; set; }
        #endregion

        #region Parameter Query
        /// <summary>
        /// Specifies the string for which you want to get suggestions.
        /// </summary>
        [Parameter(Mandatory = true,Position = 1)]
        public System.String Query { get; set; }
        #endregion

        #region Parameter Size
        /// <summary>
        /// Specifies the maximum number of suggestions to return. 
        /// </summary>
        [Parameter]
        public System.Int64? Size { get; set; }
        #endregion

        #region Parameter Suggester
        /// <summary>
        /// Specifies the name of the suggester to use to find suggested matches.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2)]
        public System.String Suggester { get; set; }
        #endregion

        #region Parameter UseAnonymousCredentials
        /// <summary>
        /// If set, the cmdlet calls the service operation using anonymous credentials.
        /// </summary>
        [Parameter]
        public SwitchParameter UseAnonymousCredentials { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            this.ExecuteWithAnonymousCredentials = 
                this.UseAnonymousCredentials.IsPresent;

            base.ProcessRecord();

            var context = new CmdletContext();

            context.ServiceUrl = this.ServiceUrl;
            context.Query = this.Query;
            context.Size = this.Size;
            context.Suggester = this.Suggester;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new SuggestRequest();
            
            if (cmdletContext.Query != null)
            {
                request.Query = cmdletContext.Query;
            }
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size.Value;
            }
            if (cmdletContext.Suggester != null)
            {
                request.Suggester = cmdletContext.Suggester;
            }
            
            CmdletOutput output;

            // issue call
            using (var client = CreateClient(cmdletContext.ServiceUrl))
            {
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response;
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
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.CloudSearchDomain.Model.SuggestResponse CallAWSServiceOperation(IAmazonCloudSearchDomain client, Amazon.CloudSearchDomain.Model.SuggestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearchDomain", "Suggest");

            try
            {
#if DESKTOP
                return client.Suggest(request);
#elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SuggestAsync(request);
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

        internal class CmdletContext : ExecutorContext
        {
            public string ServiceUrl { get; set; }
            public String Query { get; set; }
            public Int64? Size { get; set; }
            public String Suggester { get; set; }
        }
        
    }
}
