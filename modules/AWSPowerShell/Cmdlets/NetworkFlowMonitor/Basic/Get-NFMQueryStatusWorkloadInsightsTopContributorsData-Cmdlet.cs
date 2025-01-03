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
using Amazon.NetworkFlowMonitor;
using Amazon.NetworkFlowMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.NFM
{
    /// <summary>
    /// Returns the current status of a query for the Network Flow Monitor query interface,
    /// for a specified query ID and monitor. This call returns the query status for the top
    /// contributors data for workload insights.
    /// 
    ///  
    /// <para>
    /// When you start a query, use this call to check the status of the query to make sure
    /// that it has has <c>SUCCEEDED</c> before you review the results. Use the same query
    /// ID that you used for the corresponding API call to start the query, <c>StartQueryWorkloadInsightsTopContributorsData</c>.
    /// </para><para>
    /// Top contributors in Network Flow Monitor are network flows with the highest values
    /// for a specific metric type, related to a scope (for workload insights) or a monitor.
    /// </para><para>
    /// The top contributor network flows overall for a specific metric type, for example,
    /// the number of retransmissions.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NFMQueryStatusWorkloadInsightsTopContributorsData")]
    [OutputType("Amazon.NetworkFlowMonitor.QueryStatus")]
    [AWSCmdlet("Calls the Network Flow Monitor GetQueryStatusWorkloadInsightsTopContributorsData API operation.", Operation = new[] {"GetQueryStatusWorkloadInsightsTopContributorsData"}, SelectReturnType = typeof(Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataResponse))]
    [AWSCmdletOutput("Amazon.NetworkFlowMonitor.QueryStatus or Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataResponse",
        "This cmdlet returns an Amazon.NetworkFlowMonitor.QueryStatus object.",
        "The service call response (type Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetNFMQueryStatusWorkloadInsightsTopContributorsDataCmdlet : AmazonNetworkFlowMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// for a specific root account. A scope ID is returned from a <c>CreateScope</c> API
        /// call.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataResponse).
        /// Specifying the name of a property of type Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueryId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueryId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueryId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataResponse, GetNFMQueryStatusWorkloadInsightsTopContributorsDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueryId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataRequest();
            
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
        
        private Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataResponse CallAWSServiceOperation(IAmazonNetworkFlowMonitor client, Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Network Flow Monitor", "GetQueryStatusWorkloadInsightsTopContributorsData");
            try
            {
                #if DESKTOP
                return client.GetQueryStatusWorkloadInsightsTopContributorsData(request);
                #elif CORECLR
                return client.GetQueryStatusWorkloadInsightsTopContributorsDataAsync(request).GetAwaiter().GetResult();
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
            public System.String QueryId { get; set; }
            public System.String ScopeId { get; set; }
            public System.Func<Amazon.NetworkFlowMonitor.Model.GetQueryStatusWorkloadInsightsTopContributorsDataResponse, GetNFMQueryStatusWorkloadInsightsTopContributorsDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
