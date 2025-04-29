/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.MigrationHubStrategyRecommendations;
using Amazon.MigrationHubStrategyRecommendations.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MHS
{
    /// <summary>
    /// Retrieves a list of all the application components (processes).
    /// </summary>
    [Cmdlet("Get", "MHSApplicationComponentList")]
    [OutputType("Amazon.MigrationHubStrategyRecommendations.Model.ApplicationComponentDetail")]
    [AWSCmdlet("Calls the Migration Hub Strategy Recommendations ListApplicationComponents API operation.", Operation = new[] {"ListApplicationComponents"}, SelectReturnType = typeof(Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubStrategyRecommendations.Model.ApplicationComponentDetail or Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsResponse",
        "This cmdlet returns a collection of Amazon.MigrationHubStrategyRecommendations.Model.ApplicationComponentDetail objects.",
        "The service call response (type Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMHSApplicationComponentListCmdlet : AmazonMigrationHubStrategyRecommendationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationComponentCriterion
        /// <summary>
        /// <para>
        /// <para> Criteria for filtering the list of application components. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationComponentCriteria")]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.ApplicationComponentCriteria")]
        public Amazon.MigrationHubStrategyRecommendations.ApplicationComponentCriteria ApplicationComponentCriterion { get; set; }
        #endregion
        
        #region Parameter FilterValue
        /// <summary>
        /// <para>
        /// <para> Specify the value based on the application component criteria type. For example,
        /// if <c>applicationComponentCriteria</c> is set to <c>SERVER_ID</c> and <c>filterValue</c>
        /// is set to <c>server1</c>, then <a>ListApplicationComponents</a> returns all the application
        /// components running on server1. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterValue { get; set; }
        #endregion
        
        #region Parameter GroupIdFilter
        /// <summary>
        /// <para>
        /// <para> The group ID specified in to filter on. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MigrationHubStrategyRecommendations.Model.Group[] GroupIdFilter { get; set; }
        #endregion
        
        #region Parameter Sort
        /// <summary>
        /// <para>
        /// <para> Specifies whether to sort by ascending (<c>ASC</c>) or descending (<c>DESC</c>) order.
        /// </para>
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
        /// For example, if a previous call to this action returned 100 items, but you set <c>maxResults</c>
        /// to 10. You'll receive a set of 10 results along with a token. You then use the returned
        /// token to retrieve the next set of 10. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationComponentInfos'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationComponentInfos";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsResponse, GetMHSApplicationComponentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationComponentCriterion = this.ApplicationComponentCriterion;
            context.FilterValue = this.FilterValue;
            if (this.GroupIdFilter != null)
            {
                context.GroupIdFilter = new List<Amazon.MigrationHubStrategyRecommendations.Model.Group>(this.GroupIdFilter);
            }
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
            var request = new Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsRequest();
            
            if (cmdletContext.ApplicationComponentCriterion != null)
            {
                request.ApplicationComponentCriteria = cmdletContext.ApplicationComponentCriterion;
            }
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
        
        private Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsResponse CallAWSServiceOperation(IAmazonMigrationHubStrategyRecommendations client, Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Migration Hub Strategy Recommendations", "ListApplicationComponents");
            try
            {
                return client.ListApplicationComponentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.MigrationHubStrategyRecommendations.ApplicationComponentCriteria ApplicationComponentCriterion { get; set; }
            public System.String FilterValue { get; set; }
            public List<Amazon.MigrationHubStrategyRecommendations.Model.Group> GroupIdFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.SortOrder Sort { get; set; }
            public System.Func<Amazon.MigrationHubStrategyRecommendations.Model.ListApplicationComponentsResponse, GetMHSApplicationComponentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationComponentInfos;
        }
        
    }
}
