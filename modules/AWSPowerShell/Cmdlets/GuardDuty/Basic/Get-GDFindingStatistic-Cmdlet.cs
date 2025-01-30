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
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Lists GuardDuty findings statistics for the specified detector ID.
    /// 
    ///  
    /// <para>
    /// You must provide either <c>findingStatisticTypes</c> or <c>groupBy</c> parameter,
    /// and not both. You can use the <c>maxResults</c> and <c>orderBy</c> parameters only
    /// when using <c>groupBy</c>.
    /// </para><para>
    /// There might be regional differences because some flags might not be available in all
    /// the Regions where GuardDuty is currently supported. For more information, see <a href="https://docs.aws.amazon.com/guardduty/latest/ug/guardduty_regions.html">Regions
    /// and endpoints</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GDFindingStatistic")]
    [OutputType("Amazon.GuardDuty.Model.FindingStatistics")]
    [AWSCmdlet("Calls the Amazon GuardDuty GetFindingsStatistics API operation.", Operation = new[] {"GetFindingsStatistics"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.GetFindingsStatisticsResponse))]
    [AWSCmdletOutput("Amazon.GuardDuty.Model.FindingStatistics or Amazon.GuardDuty.Model.GetFindingsStatisticsResponse",
        "This cmdlet returns an Amazon.GuardDuty.Model.FindingStatistics object.",
        "The service call response (type Amazon.GuardDuty.Model.GetFindingsStatisticsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGDFindingStatisticCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The ID of the detector whose findings statistics you want to retrieve.</para><para>To find the <c>detectorId</c> in the current Region, see the Settings page in the
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
        
        #region Parameter FindingCriterion
        /// <summary>
        /// <para>
        /// <para>Represents the criteria that is used for querying findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FindingCriteria")]
        public Amazon.GuardDuty.Model.FindingCriteria FindingCriterion { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>Displays the findings statistics grouped by one of the listed valid values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GuardDuty.GroupByType")]
        public Amazon.GuardDuty.GroupByType GroupBy { get; set; }
        #endregion
        
        #region Parameter OrderBy
        /// <summary>
        /// <para>
        /// <para>Displays the sorted findings in the requested order. The default value of <c>orderBy</c>
        /// is <c>DESC</c>.</para><para>You can use this parameter only with the <c>groupBy</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GuardDuty.OrderBy")]
        public Amazon.GuardDuty.OrderBy OrderBy { get; set; }
        #endregion
        
        #region Parameter FindingStatisticType
        /// <summary>
        /// <para>
        /// <para>The types of finding statistics to retrieve.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated, please use GroupBy instead")]
        [Alias("FindingStatisticTypes")]
        public System.String[] FindingStatisticType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned in the response. The default value is
        /// 25.</para><para>You can use this parameter only with the <c>groupBy</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FindingStatistics'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.GetFindingsStatisticsResponse).
        /// Specifying the name of a property of type Amazon.GuardDuty.Model.GetFindingsStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FindingStatistics";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DetectorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DetectorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DetectorId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.GetFindingsStatisticsResponse, GetGDFindingStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DetectorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FindingCriterion = this.FindingCriterion;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FindingStatisticType != null)
            {
                context.FindingStatisticType = new List<System.String>(this.FindingStatisticType);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GroupBy = this.GroupBy;
            context.MaxResult = this.MaxResult;
            context.OrderBy = this.OrderBy;
            
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
            var request = new Amazon.GuardDuty.Model.GetFindingsStatisticsRequest();
            
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            if (cmdletContext.FindingCriterion != null)
            {
                request.FindingCriteria = cmdletContext.FindingCriterion;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.FindingStatisticType != null)
            {
                request.FindingStatisticTypes = cmdletContext.FindingStatisticType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OrderBy != null)
            {
                request.OrderBy = cmdletContext.OrderBy;
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
        
        private Amazon.GuardDuty.Model.GetFindingsStatisticsResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.GetFindingsStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "GetFindingsStatistics");
            try
            {
                #if DESKTOP
                return client.GetFindingsStatistics(request);
                #elif CORECLR
                return client.GetFindingsStatisticsAsync(request).GetAwaiter().GetResult();
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
            public System.String DetectorId { get; set; }
            public Amazon.GuardDuty.Model.FindingCriteria FindingCriterion { get; set; }
            [System.ObsoleteAttribute]
            public List<System.String> FindingStatisticType { get; set; }
            public Amazon.GuardDuty.GroupByType GroupBy { get; set; }
            public System.Int32? MaxResult { get; set; }
            public Amazon.GuardDuty.OrderBy OrderBy { get; set; }
            public System.Func<Amazon.GuardDuty.Model.GetFindingsStatisticsResponse, GetGDFindingStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FindingStatistics;
        }
        
    }
}
