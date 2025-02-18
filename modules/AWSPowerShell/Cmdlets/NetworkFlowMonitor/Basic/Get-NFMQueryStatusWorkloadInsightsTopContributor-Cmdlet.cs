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
using Amazon.NetworkFlowMonitor;
using Amazon.NetworkFlowMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.NFM
{
    /// <summary>
    /// Return the data for a query with the Network Flow Monitor query interface. Specify
    /// the query that you want to return results for by providing a query ID and a monitor
    /// name. This query returns the top contributors for workload insights.
    /// 
    ///  
    /// <para>
    /// When you start a query, use this call to check the status of the query to make sure
    /// that it has has <c>SUCCEEDED</c> before you review the results. Use the same query
    /// ID that you used for the corresponding API call to start the query, <c>StartQueryWorkloadInsightsTopContributors</c>.
    /// </para><para>
    /// Top contributors in Network Flow Monitor are network flows with the highest values
    /// for a specific metric type, related to a scope (for workload insights) or a monitor.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NFMQueryStatusWorkloadInsightsTopContributor")]
    [OutputType("Amazon.NetworkFlowMonitor.QueryStatus")]
    [AWSCmdlet("Calls the Network Flow Monitor GetQueryStatusWorkloadInsightsTopContributors API operation.", Operation = new[] {"GetQueryStatusWorkloadInsightsTopContributors"}, SelectReturnType = typeof(Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsResponse))]
    [AWSCmdletOutput("Amazon.NetworkFlowMonitor.QueryStatus or Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsResponse",
        "This cmdlet returns an Amazon.NetworkFlowMonitor.QueryStatus object.",
        "The service call response (type Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetNFMQueryStatusWorkloadInsightsTopContributorCmdlet : AmazonNetworkFlowMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter QueryId
        /// <summary>
        /// <para>
        /// <para>The identifier for the query. A query ID is an internally-generated identifier for
        /// a specific query returned from an API call to start a query.</para>
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
        public System.String QueryId { get; set; }
        #endregion
        
        #region Parameter ScopeId
        /// <summary>
        /// <para>
        /// <para>The identifier for the scope that includes the resources you want to get data results
        /// for. A scope ID is an internally-generated identifier that includes all the resources
        /// for a specific root account.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ScopeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsResponse).
        /// Specifying the name of a property of type Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
                context.Select = CreateSelectDelegate<Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsResponse, GetNFMQueryStatusWorkloadInsightsTopContributorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.QueryId = this.QueryId;
            #if MODULAR
            if (this.QueryId == null && ParameterWasBound(nameof(this.QueryId)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScopeId = this.ScopeId;
            #if MODULAR
            if (this.ScopeId == null && ParameterWasBound(nameof(this.ScopeId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsRequest();
            
            if (cmdletContext.QueryId != null)
            {
                request.QueryId = cmdletContext.QueryId;
            }
            if (cmdletContext.ScopeId != null)
            {
                request.ScopeId = cmdletContext.ScopeId;
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
        
        private Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsResponse CallAWSServiceOperation(IAmazonNetworkFlowMonitor client, Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Network Flow Monitor", "GetQueryStatusWorkloadInsightsTopContributors");
            try
            {
                return client.GetQueryStatusWorkloadInsightsTopContributorsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String QueryId { get; set; }
            public System.String ScopeId { get; set; }
            public System.Func<Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsResponse, GetNFMQueryStatusWorkloadInsightsTopContributorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
