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
using Amazon.MigrationHubStrategyRecommendations;
using Amazon.MigrationHubStrategyRecommendations.Model;

namespace Amazon.PowerShell.Cmdlets.MHS
{
    /// <summary>
    /// Retrieves a list of all the servers fetched from customer vCenter using Strategy Recommendation
    /// Collector.
    /// </summary>
    [Cmdlet("Get", "MHSAnalyzableServerList")]
    [OutputType("Amazon.MigrationHubStrategyRecommendations.Model.AnalyzableServerSummary")]
    [AWSCmdlet("Calls the Migration Hub Strategy Recommendations ListAnalyzableServers API operation.", Operation = new[] {"ListAnalyzableServers"}, SelectReturnType = typeof(Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubStrategyRecommendations.Model.AnalyzableServerSummary or Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersResponse",
        "This cmdlet returns a collection of Amazon.MigrationHubStrategyRecommendations.Model.AnalyzableServerSummary objects.",
        "The service call response (type Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMHSAnalyzableServerListCmdlet : AmazonMigrationHubStrategyRecommendationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Sort
        /// <summary>
        /// <para>
        /// <para>Specifies whether to sort by ascending (ASC) or descending (DESC) order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.SortOrder")]
        public Amazon.MigrationHubStrategyRecommendations.SortOrder Sort { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to include in the response. The maximum value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token from a previous call that you use to retrieve the next set of results. For
        /// example, if a previous call to this action returned 100 items, but you set maxResults
        /// to 10. You'll receive a set of 10 results along with a token. You then use the returned
        /// token to retrieve the next set of 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalyzableServers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnalyzableServers";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Sort parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Sort' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Sort' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersResponse, GetMHSAnalyzableServerListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Sort;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Sort = this.Sort;
            
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
            var request = new Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Sort != null)
            {
                request.Sort = cmdletContext.Sort;
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
        
        private Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersResponse CallAWSServiceOperation(IAmazonMigrationHubStrategyRecommendations client, Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Migration Hub Strategy Recommendations", "ListAnalyzableServers");
            try
            {
                #if DESKTOP
                return client.ListAnalyzableServers(request);
                #elif CORECLR
                return client.ListAnalyzableServersAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.SortOrder Sort { get; set; }
            public System.Func<Amazon.MigrationHubStrategyRecommendations.Model.ListAnalyzableServersResponse, GetMHSAnalyzableServerListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalyzableServers;
        }
        
    }
}
