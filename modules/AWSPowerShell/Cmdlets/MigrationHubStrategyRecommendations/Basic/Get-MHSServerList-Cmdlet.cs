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
    /// Returns a list of all the servers.
    /// </summary>
    [Cmdlet("Get", "MHSServerList")]
    [OutputType("Amazon.MigrationHubStrategyRecommendations.Model.ServerDetail")]
    [AWSCmdlet("Calls the Migration Hub Strategy Recommendations ListServers API operation.", Operation = new[] {"ListServers"}, SelectReturnType = typeof(Amazon.MigrationHubStrategyRecommendations.Model.ListServersResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubStrategyRecommendations.Model.ServerDetail or Amazon.MigrationHubStrategyRecommendations.Model.ListServersResponse",
        "This cmdlet returns a collection of Amazon.MigrationHubStrategyRecommendations.Model.ServerDetail objects.",
        "The service call response (type Amazon.MigrationHubStrategyRecommendations.Model.ListServersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMHSServerListCmdlet : AmazonMigrationHubStrategyRecommendationsClientCmdlet, IExecutor
    {
        
        #region Parameter FilterValue
        /// <summary>
        /// <para>
        /// <para> Specifies the filter value, which is based on the type of server criteria. For example,
        /// if <code>serverCriteria</code> is <code>OS_NAME</code>, and the <code>filterValue</code>
        /// is equal to <code>WindowsServer</code>, then <code>ListServers</code> returns all
        /// of the servers matching the OS name <code>WindowsServer</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterValue { get; set; }
        #endregion
        
        #region Parameter GroupIdFilter
        /// <summary>
        /// <para>
        /// <para> Specifies the group ID to filter on. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MigrationHubStrategyRecommendations.Model.Group[] GroupIdFilter { get; set; }
        #endregion
        
        #region Parameter ServerCriterion
        /// <summary>
        /// <para>
        /// <para> Criteria for filtering servers. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServerCriteria")]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.ServerCriteria")]
        public Amazon.MigrationHubStrategyRecommendations.ServerCriteria ServerCriterion { get; set; }
        #endregion
        
        #region Parameter Sort
        /// <summary>
        /// <para>
        /// <para> Specifies whether to sort by ascending (<code>ASC</code>) or descending (<code>DESC</code>)
        /// order. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.SortOrder")]
        public Amazon.MigrationHubStrategyRecommendations.SortOrder Sort { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of items to include in the response. The maximum value is 100.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token from a previous call that you use to retrieve the next set of results.
        /// For example, if a previous call to this action returned 100 items, but you set <code>maxResults</code>
        /// to 10. You'll receive a set of 10 results along with a token. You then use the returned
        /// token to retrieve the next set of 10. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerInfos'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubStrategyRecommendations.Model.ListServersResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubStrategyRecommendations.Model.ListServersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerInfos";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubStrategyRecommendations.Model.ListServersResponse, GetMHSServerListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FilterValue = this.FilterValue;
            if (this.GroupIdFilter != null)
            {
                context.GroupIdFilter = new List<Amazon.MigrationHubStrategyRecommendations.Model.Group>(this.GroupIdFilter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ServerCriterion = this.ServerCriterion;
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
            var request = new Amazon.MigrationHubStrategyRecommendations.Model.ListServersRequest();
            
            if (cmdletContext.FilterValue != null)
            {
                request.FilterValue = cmdletContext.FilterValue;
            }
            if (cmdletContext.GroupIdFilter != null)
            {
                request.GroupIdFilter = cmdletContext.GroupIdFilter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ServerCriterion != null)
            {
                request.ServerCriteria = cmdletContext.ServerCriterion;
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
        
        private Amazon.MigrationHubStrategyRecommendations.Model.ListServersResponse CallAWSServiceOperation(IAmazonMigrationHubStrategyRecommendations client, Amazon.MigrationHubStrategyRecommendations.Model.ListServersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Migration Hub Strategy Recommendations", "ListServers");
            try
            {
                #if DESKTOP
                return client.ListServers(request);
                #elif CORECLR
                return client.ListServersAsync(request).GetAwaiter().GetResult();
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
            public System.String FilterValue { get; set; }
            public List<Amazon.MigrationHubStrategyRecommendations.Model.Group> GroupIdFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.ServerCriteria ServerCriterion { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.SortOrder Sort { get; set; }
            public System.Func<Amazon.MigrationHubStrategyRecommendations.Model.ListServersResponse, GetMHSServerListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerInfos;
        }
        
    }
}
