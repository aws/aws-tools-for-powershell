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
using Amazon.PrometheusService;
using Amazon.PrometheusService.Model;

namespace Amazon.PowerShell.Cmdlets.PROM
{
    /// <summary>
    /// Lists all scrapers in a customer account, including scrapers being created or deleted.
    /// You may provide filters to return a more specific list of results.
    /// </summary>
    [Cmdlet("Get", "PROMScraperList")]
    [OutputType("Amazon.PrometheusService.Model.ScraperSummary")]
    [AWSCmdlet("Calls the Amazon Prometheus Service ListScrapers API operation.", Operation = new[] {"ListScrapers"}, SelectReturnType = typeof(Amazon.PrometheusService.Model.ListScrapersResponse))]
    [AWSCmdletOutput("Amazon.PrometheusService.Model.ScraperSummary or Amazon.PrometheusService.Model.ListScrapersResponse",
        "This cmdlet returns a collection of Amazon.PrometheusService.Model.ScraperSummary objects.",
        "The service call response (type Amazon.PrometheusService.Model.ListScrapersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPROMScraperListCmdlet : AmazonPrometheusServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A list of scraper filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public System.Collections.Hashtable Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum results to return in response (default=100, maximum=1000).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token to request the next page in a paginated list. This token is obtained
        /// from the output of the previous ListScrapers request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Scrapers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PrometheusService.Model.ListScrapersResponse).
        /// Specifying the name of a property of type Amazon.PrometheusService.Model.ListScrapersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Scrapers";
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
                context.Select = CreateSelectDelegate<Amazon.PrometheusService.Model.ListScrapersResponse, GetPROMScraperListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter.Keys)
                {
                    object hashValue = this.Filter[hashKey];
                    if (hashValue == null)
                    {
                        context.Filter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Filter.Add((String)hashKey, valueSet);
                }
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.PrometheusService.Model.ListScrapersRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.PrometheusService.Model.ListScrapersResponse CallAWSServiceOperation(IAmazonPrometheusService client, Amazon.PrometheusService.Model.ListScrapersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Prometheus Service", "ListScrapers");
            try
            {
                #if DESKTOP
                return client.ListScrapers(request);
                #elif CORECLR
                return client.ListScrapersAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, List<System.String>> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.PrometheusService.Model.ListScrapersResponse, GetPROMScraperListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Scrapers;
        }
        
    }
}
