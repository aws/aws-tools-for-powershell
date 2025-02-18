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

namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Retrieves aggregated statistics for your account. If you are a GuardDuty administrator,
    /// you can retrieve the statistics for all the resources associated with the active member
    /// accounts in your organization who have enabled Runtime Monitoring and have the GuardDuty
    /// security agent running on their resources.
    /// </summary>
    [Cmdlet("Get", "GDCoverageStatistic")]
    [OutputType("Amazon.GuardDuty.Model.CoverageStatistics")]
    [AWSCmdlet("Calls the Amazon GuardDuty GetCoverageStatistics API operation.", Operation = new[] {"GetCoverageStatistics"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.GetCoverageStatisticsResponse))]
    [AWSCmdletOutput("Amazon.GuardDuty.Model.CoverageStatistics or Amazon.GuardDuty.Model.GetCoverageStatisticsResponse",
        "This cmdlet returns an Amazon.GuardDuty.Model.CoverageStatistics object.",
        "The service call response (type Amazon.GuardDuty.Model.GetCoverageStatisticsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGDCoverageStatisticCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the GuardDuty detector.</para><para>To find the <c>detectorId</c> in the current Region, see the Settings page in the
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
        
        #region Parameter FilterCriteria_FilterCriterion
        /// <summary>
        /// <para>
        /// <para>Represents a condition that when matched will be added to the response of the operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GuardDuty.Model.CoverageFilterCriterion[] FilterCriteria_FilterCriterion { get; set; }
        #endregion
        
        #region Parameter StatisticsType
        /// <summary>
        /// <para>
        /// <para>Represents the statistics type used to aggregate the coverage details.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] StatisticsType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CoverageStatistics'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.GetCoverageStatisticsResponse).
        /// Specifying the name of a property of type Amazon.GuardDuty.Model.GetCoverageStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CoverageStatistics";
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
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.GetCoverageStatisticsResponse, GetGDCoverageStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FilterCriteria_FilterCriterion != null)
            {
                context.FilterCriteria_FilterCriterion = new List<Amazon.GuardDuty.Model.CoverageFilterCriterion>(this.FilterCriteria_FilterCriterion);
            }
            if (this.StatisticsType != null)
            {
                context.StatisticsType = new List<System.String>(this.StatisticsType);
            }
            #if MODULAR
            if (this.StatisticsType == null && ParameterWasBound(nameof(this.StatisticsType)))
            {
                WriteWarning("You are passing $null as a value for parameter StatisticsType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GuardDuty.Model.GetCoverageStatisticsRequest();
            
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.GuardDuty.Model.CoverageFilterCriteria();
            List<Amazon.GuardDuty.Model.CoverageFilterCriterion> requestFilterCriteria_filterCriteria_FilterCriterion = null;
            if (cmdletContext.FilterCriteria_FilterCriterion != null)
            {
                requestFilterCriteria_filterCriteria_FilterCriterion = cmdletContext.FilterCriteria_FilterCriterion;
            }
            if (requestFilterCriteria_filterCriteria_FilterCriterion != null)
            {
                request.FilterCriteria.FilterCriterion = requestFilterCriteria_filterCriteria_FilterCriterion;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.StatisticsType != null)
            {
                request.StatisticsType = cmdletContext.StatisticsType;
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
        
        private Amazon.GuardDuty.Model.GetCoverageStatisticsResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.GetCoverageStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "GetCoverageStatistics");
            try
            {
                return client.GetCoverageStatisticsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.GuardDuty.Model.CoverageFilterCriterion> FilterCriteria_FilterCriterion { get; set; }
            public List<System.String> StatisticsType { get; set; }
            public System.Func<Amazon.GuardDuty.Model.GetCoverageStatisticsResponse, GetGDCoverageStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CoverageStatistics;
        }
        
    }
}
