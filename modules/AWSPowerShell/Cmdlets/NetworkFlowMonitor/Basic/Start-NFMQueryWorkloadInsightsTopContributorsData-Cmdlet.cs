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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NFM
{
    /// <summary>
    /// Create a query with the Network Flow Monitor query interface that you can run to return
    /// data for workload insights top contributors. Specify the scope that you want to create
    /// a query for.
    /// 
    ///  
    /// <para>
    /// The call returns a query ID that you can use with <a href="https://docs.aws.amazon.com/networkflowmonitor/2.0/APIReference/API_GetQueryResultsWorkloadInsightsTopContributorsData.html">
    /// GetQueryResultsWorkloadInsightsTopContributorsData</a> to run the query and return
    /// the data for the top contributors for the workload insights for a scope.
    /// </para><para>
    /// Top contributors in Network Flow Monitor are network flows with the highest values
    /// for a specific metric type. Top contributors can be across all workload insights,
    /// for a given scope, or for a specific monitor. Use the applicable call for the top
    /// contributors that you want to be returned.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "NFMQueryWorkloadInsightsTopContributorsData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Network Flow Monitor StartQueryWorkloadInsightsTopContributorsData API operation.", Operation = new[] {"StartQueryWorkloadInsightsTopContributorsData"}, SelectReturnType = typeof(Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataResponse))]
    [AWSCmdletOutput("System.String or Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartNFMQueryWorkloadInsightsTopContributorsDataCmdlet : AmazonNetworkFlowMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DestinationCategory
        /// <summary>
        /// <para>
        /// <para>The destination category for a top contributors. Destination categories can be one
        /// of the following: </para><ul><li><para><c>INTRA_AZ</c>: Top contributor network flows within a single Availability Zone</para></li><li><para><c>INTER_AZ</c>: Top contributor network flows between Availability Zones</para></li><li><para><c>INTER_VPC</c>: Top contributor network flows between VPCs</para></li><li><para><c>AWS_SERVICES</c>: Top contributor network flows to or from Amazon Web Services
        /// services</para></li><li><para><c>UNCLASSIFIED</c>: Top contributor network flows that do not have a bucket classification</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NetworkFlowMonitor.DestinationCategory")]
        public Amazon.NetworkFlowMonitor.DestinationCategory DestinationCategory { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The timestamp that is the date and time end of the period that you want to retrieve
        /// results for with your query.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The metric that you want to query top contributors for. That is, you can specify this
        /// metric to return the top contributor network flows, for this type of metric, for a
        /// monitor and (optionally) within a specific category, such as network flows between
        /// Availability Zones.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NetworkFlowMonitor.WorkloadInsightsMetric")]
        public Amazon.NetworkFlowMonitor.WorkloadInsightsMetric MetricName { get; set; }
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ScopeId { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The timestamp that is the date and time beginning of the period that you want to retrieve
        /// results for with your query.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueryId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataResponse).
        /// Specifying the name of a property of type Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueryId";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScopeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-NFMQueryWorkloadInsightsTopContributorsData (StartQueryWorkloadInsightsTopContributorsData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataResponse, StartNFMQueryWorkloadInsightsTopContributorsDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationCategory = this.DestinationCategory;
            #if MODULAR
            if (this.DestinationCategory == null && ParameterWasBound(nameof(this.DestinationCategory)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationCategory which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricName = this.MetricName;
            #if MODULAR
            if (this.MetricName == null && ParameterWasBound(nameof(this.MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScopeId = this.ScopeId;
            #if MODULAR
            if (this.ScopeId == null && ParameterWasBound(nameof(this.ScopeId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataRequest();
            
            if (cmdletContext.DestinationCategory != null)
            {
                request.DestinationCategory = cmdletContext.DestinationCategory;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.ScopeId != null)
            {
                request.ScopeId = cmdletContext.ScopeId;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataResponse CallAWSServiceOperation(IAmazonNetworkFlowMonitor client, Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Network Flow Monitor", "StartQueryWorkloadInsightsTopContributorsData");
            try
            {
                return client.StartQueryWorkloadInsightsTopContributorsDataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.NetworkFlowMonitor.DestinationCategory DestinationCategory { get; set; }
            public System.DateTime? EndTime { get; set; }
            public Amazon.NetworkFlowMonitor.WorkloadInsightsMetric MetricName { get; set; }
            public System.String ScopeId { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.NetworkFlowMonitor.Model.StartQueryWorkloadInsightsTopContributorsDataResponse, StartNFMQueryWorkloadInsightsTopContributorsDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueryId;
        }
        
    }
}
