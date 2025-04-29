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
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Lists Amazon GuardDuty usage statistics over the last 30 days for the specified detector
    /// ID. For newly enabled detectors or data sources, the cost returned will include only
    /// the usage so far under 30 days. This may differ from the cost metrics in the console,
    /// which project usage over 30 days to provide a monthly cost estimate. For more information,
    /// see <a href="https://docs.aws.amazon.com/guardduty/latest/ug/monitoring_costs.html#usage-calculations">Understanding
    /// How Usage Costs are Calculated</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GDUsageStatistic")]
    [OutputType("Amazon.GuardDuty.Model.UsageStatistics")]
    [AWSCmdlet("Calls the Amazon GuardDuty GetUsageStatistics API operation.", Operation = new[] {"GetUsageStatistics"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.GetUsageStatisticsResponse))]
    [AWSCmdletOutput("Amazon.GuardDuty.Model.UsageStatistics or Amazon.GuardDuty.Model.GetUsageStatisticsResponse",
        "This cmdlet returns an Amazon.GuardDuty.Model.UsageStatistics object.",
        "The service call response (type Amazon.GuardDuty.Model.GetUsageStatisticsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGDUsageStatisticCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter UsageCriteria_AccountId
        /// <summary>
        /// <para>
        /// <para>The account IDs to aggregate usage statistics from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UsageCriteria_AccountIds")]
        public System.String[] UsageCriteria_AccountId { get; set; }
        #endregion
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The ID of the detector that specifies the GuardDuty service whose usage statistics
        /// you want to retrieve.</para><para>To find the <c>detectorId</c> in the current Region, see the Settings page in the
        /// GuardDuty console, or run the <a href="https://docs.aws.amazon.com/guardduty/latest/APIReference/API_ListDetectors.html">ListDetectors</a>
        /// API.</para>
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
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter UsageCriteria_Feature
        /// <summary>
        /// <para>
        /// <para>The features to aggregate usage statistics from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UsageCriteria_Features")]
        public System.String[] UsageCriteria_Feature { get; set; }
        #endregion
        
        #region Parameter UsageCriteria_Resource
        /// <summary>
        /// <para>
        /// <para>The resources to aggregate usage statistics from. Only accepts exact resource names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UsageCriteria_Resources")]
        public System.String[] UsageCriteria_Resource { get; set; }
        #endregion
        
        #region Parameter Unit
        /// <summary>
        /// <para>
        /// <para>The currency unit you would like to view your usage statistics in. Current valid values
        /// are USD.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Unit { get; set; }
        #endregion
        
        #region Parameter UsageStatisticType
        /// <summary>
        /// <para>
        /// <para>The type of usage statistics to retrieve.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GuardDuty.UsageStatisticType")]
        public Amazon.GuardDuty.UsageStatisticType UsageStatisticType { get; set; }
        #endregion
        
        #region Parameter UsageCriteria_DataSource
        /// <summary>
        /// <para>
        /// <para>The data sources to aggregate usage statistics from.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated, use Features instead")]
        [Alias("UsageCriteria_DataSources")]
        public System.String[] UsageCriteria_DataSource { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to use for paginating results that are returned in the response. Set the value
        /// of this parameter to null for the first request to a list action. For subsequent calls,
        /// use the NextToken value returned from the previous request to continue listing results
        /// after the first page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UsageStatistics'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.GetUsageStatisticsResponse).
        /// Specifying the name of a property of type Amazon.GuardDuty.Model.GetUsageStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UsageStatistics";
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.GetUsageStatisticsResponse, GetGDUsageStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Unit = this.Unit;
            if (this.UsageCriteria_AccountId != null)
            {
                context.UsageCriteria_AccountId = new List<System.String>(this.UsageCriteria_AccountId);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.UsageCriteria_DataSource != null)
            {
                context.UsageCriteria_DataSource = new List<System.String>(this.UsageCriteria_DataSource);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.UsageCriteria_Feature != null)
            {
                context.UsageCriteria_Feature = new List<System.String>(this.UsageCriteria_Feature);
            }
            if (this.UsageCriteria_Resource != null)
            {
                context.UsageCriteria_Resource = new List<System.String>(this.UsageCriteria_Resource);
            }
            context.UsageStatisticType = this.UsageStatisticType;
            #if MODULAR
            if (this.UsageStatisticType == null && ParameterWasBound(nameof(this.UsageStatisticType)))
            {
                WriteWarning("You are passing $null as a value for parameter UsageStatisticType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.GuardDuty.Model.GetUsageStatisticsRequest();
            
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Unit != null)
            {
                request.Unit = cmdletContext.Unit;
            }
            
             // populate UsageCriteria
            var requestUsageCriteriaIsNull = true;
            request.UsageCriteria = new Amazon.GuardDuty.Model.UsageCriteria();
            List<System.String> requestUsageCriteria_usageCriteria_AccountId = null;
            if (cmdletContext.UsageCriteria_AccountId != null)
            {
                requestUsageCriteria_usageCriteria_AccountId = cmdletContext.UsageCriteria_AccountId;
            }
            if (requestUsageCriteria_usageCriteria_AccountId != null)
            {
                request.UsageCriteria.AccountIds = requestUsageCriteria_usageCriteria_AccountId;
                requestUsageCriteriaIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            List<System.String> requestUsageCriteria_usageCriteria_DataSource = null;
            if (cmdletContext.UsageCriteria_DataSource != null)
            {
                requestUsageCriteria_usageCriteria_DataSource = cmdletContext.UsageCriteria_DataSource;
            }
            if (requestUsageCriteria_usageCriteria_DataSource != null)
            {
                request.UsageCriteria.DataSources = requestUsageCriteria_usageCriteria_DataSource;
                requestUsageCriteriaIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            List<System.String> requestUsageCriteria_usageCriteria_Feature = null;
            if (cmdletContext.UsageCriteria_Feature != null)
            {
                requestUsageCriteria_usageCriteria_Feature = cmdletContext.UsageCriteria_Feature;
            }
            if (requestUsageCriteria_usageCriteria_Feature != null)
            {
                request.UsageCriteria.Features = requestUsageCriteria_usageCriteria_Feature;
                requestUsageCriteriaIsNull = false;
            }
            List<System.String> requestUsageCriteria_usageCriteria_Resource = null;
            if (cmdletContext.UsageCriteria_Resource != null)
            {
                requestUsageCriteria_usageCriteria_Resource = cmdletContext.UsageCriteria_Resource;
            }
            if (requestUsageCriteria_usageCriteria_Resource != null)
            {
                request.UsageCriteria.Resources = requestUsageCriteria_usageCriteria_Resource;
                requestUsageCriteriaIsNull = false;
            }
             // determine if request.UsageCriteria should be set to null
            if (requestUsageCriteriaIsNull)
            {
                request.UsageCriteria = null;
            }
            if (cmdletContext.UsageStatisticType != null)
            {
                request.UsageStatisticType = cmdletContext.UsageStatisticType;
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
        
        private Amazon.GuardDuty.Model.GetUsageStatisticsResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.GetUsageStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "GetUsageStatistics");
            try
            {
                return client.GetUsageStatisticsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DetectorId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Unit { get; set; }
            public List<System.String> UsageCriteria_AccountId { get; set; }
            [System.ObsoleteAttribute]
            public List<System.String> UsageCriteria_DataSource { get; set; }
            public List<System.String> UsageCriteria_Feature { get; set; }
            public List<System.String> UsageCriteria_Resource { get; set; }
            public Amazon.GuardDuty.UsageStatisticType UsageStatisticType { get; set; }
            public System.Func<Amazon.GuardDuty.Model.GetUsageStatisticsResponse, GetGDUsageStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UsageStatistics;
        }
        
    }
}
