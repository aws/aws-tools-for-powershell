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
using Amazon.ApplicationInsights;
using Amazon.ApplicationInsights.Model;

namespace Amazon.PowerShell.Cmdlets.CWAI
{
    /// <summary>
    /// Lists the INFO, WARN, and ERROR events for periodic configuration updates performed
    /// by Application Insights. Examples of events represented are: 
    /// 
    ///  <ul><li><para>
    /// INFO: creating a new alarm or updating an alarm threshold.
    /// </para></li><li><para>
    /// WARN: alarm not created due to insufficient data points used to predict thresholds.
    /// </para></li><li><para>
    /// ERROR: alarm not created due to permission errors or exceeding quotas. 
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWAIConfigurationHistoryList")]
    [OutputType("Amazon.ApplicationInsights.Model.ConfigurationEvent")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Insights ListConfigurationHistory API operation.", Operation = new[] {"ListConfigurationHistory"}, SelectReturnType = typeof(Amazon.ApplicationInsights.Model.ListConfigurationHistoryResponse))]
    [AWSCmdletOutput("Amazon.ApplicationInsights.Model.ConfigurationEvent or Amazon.ApplicationInsights.Model.ListConfigurationHistoryResponse",
        "This cmdlet returns a collection of Amazon.ApplicationInsights.Model.ConfigurationEvent objects.",
        "The service call response (type Amazon.ApplicationInsights.Model.ListConfigurationHistoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWAIConfigurationHistoryListCmdlet : AmazonApplicationInsightsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID for the resource group owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter EventStatus
        /// <summary>
        /// <para>
        /// <para>The status of the configuration update event. Possible values include INFO, WARN,
        /// and ERROR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationInsights.ConfigurationEventStatus")]
        public Amazon.ApplicationInsights.ConfigurationEventStatus EventStatus { get; set; }
        #endregion
        
        #region Parameter ResourceGroupName
        /// <summary>
        /// <para>
        /// <para>Resource group to which the application belongs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResourceGroupName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the event. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of results returned by <c>ListConfigurationHistory</c> in paginated
        /// output. When this parameter is used, <c>ListConfigurationHistory</c> returns only
        /// <c>MaxResults</c> in a single page along with a <c>NextToken</c> response element.
        /// The remaining results of the initial request can be seen by sending another <c>ListConfigurationHistory</c>
        /// request with the returned <c>NextToken</c> value. If this parameter is not used, then
        /// <c>ListConfigurationHistory</c> returns all results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>NextToken</c> value returned from a previous paginated <c>ListConfigurationHistory</c>
        /// request where <c>MaxResults</c> was used and the results exceeded the value of that
        /// parameter. Pagination continues from the end of the previous results that returned
        /// the <c>NextToken</c> value. This value is <c>null</c> when there are no more results
        /// to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationInsights.Model.ListConfigurationHistoryResponse).
        /// Specifying the name of a property of type Amazon.ApplicationInsights.Model.ListConfigurationHistoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventList";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationInsights.Model.ListConfigurationHistoryResponse, GetCWAIConfigurationHistoryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            context.EndTime = this.EndTime;
            context.EventStatus = this.EventStatus;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceGroupName = this.ResourceGroupName;
            context.StartTime = this.StartTime;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ApplicationInsights.Model.ListConfigurationHistoryRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.EventStatus != null)
            {
                request.EventStatus = cmdletContext.EventStatus;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ResourceGroupName != null)
            {
                request.ResourceGroupName = cmdletContext.ResourceGroupName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ApplicationInsights.Model.ListConfigurationHistoryResponse CallAWSServiceOperation(IAmazonApplicationInsights client, Amazon.ApplicationInsights.Model.ListConfigurationHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Insights", "ListConfigurationHistory");
            try
            {
                return client.ListConfigurationHistoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.DateTime? EndTime { get; set; }
            public Amazon.ApplicationInsights.ConfigurationEventStatus EventStatus { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceGroupName { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.ApplicationInsights.Model.ListConfigurationHistoryResponse, GetCWAIConfigurationHistoryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventList;
        }
        
    }
}
