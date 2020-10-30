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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Get an aggregation of service statistics defined by a specific time range.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "XRTimeSeriesServiceStatistic")]
    [OutputType("Amazon.XRay.Model.TimeSeriesServiceStatistics")]
    [AWSCmdlet("Calls the AWS X-Ray GetTimeSeriesServiceStatistics API operation.", Operation = new[] {"GetTimeSeriesServiceStatistics"}, SelectReturnType = typeof(Amazon.XRay.Model.GetTimeSeriesServiceStatisticsResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.TimeSeriesServiceStatistics or Amazon.XRay.Model.GetTimeSeriesServiceStatisticsResponse",
        "This cmdlet returns a collection of Amazon.XRay.Model.TimeSeriesServiceStatistics objects.",
        "The service call response (type Amazon.XRay.Model.GetTimeSeriesServiceStatisticsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetXRTimeSeriesServiceStatisticCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time frame for which to aggregate statistics.</para>
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
        
        #region Parameter EntitySelectorExpression
        /// <summary>
        /// <para>
        /// <para>A filter expression defining entities that will be aggregated for statistics. Supports
        /// ID, service, and edge functions. If no selector expression is specified, edge statistics
        /// are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntitySelectorExpression { get; set; }
        #endregion
        
        #region Parameter ForecastStatistic
        /// <summary>
        /// <para>
        /// <para>The forecasted high and low fault count values. Forecast enabled requests require
        /// the EntitySelectorExpression ID be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ForecastStatistics")]
        public System.Boolean? ForecastStatistic { get; set; }
        #endregion
        
        #region Parameter GroupARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the group for which to pull statistics from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupARN { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The case-sensitive name of the group for which to pull statistics from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>Aggregation period in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Period { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time frame for which to aggregate statistics.</para>
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
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TimeSeriesServiceStatistics'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.GetTimeSeriesServiceStatisticsResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.GetTimeSeriesServiceStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TimeSeriesServiceStatistics";
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.GetTimeSeriesServiceStatisticsResponse, GetXRTimeSeriesServiceStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntitySelectorExpression = this.EntitySelectorExpression;
            context.ForecastStatistic = this.ForecastStatistic;
            context.GroupARN = this.GroupARN;
            context.GroupName = this.GroupName;
            context.NextToken = this.NextToken;
            context.Period = this.Period;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.XRay.Model.GetTimeSeriesServiceStatisticsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.EntitySelectorExpression != null)
            {
                request.EntitySelectorExpression = cmdletContext.EntitySelectorExpression;
            }
            if (cmdletContext.ForecastStatistic != null)
            {
                request.ForecastStatistics = cmdletContext.ForecastStatistic.Value;
            }
            if (cmdletContext.GroupARN != null)
            {
                request.GroupARN = cmdletContext.GroupARN;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period.Value;
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
        
        private Amazon.XRay.Model.GetTimeSeriesServiceStatisticsResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.GetTimeSeriesServiceStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "GetTimeSeriesServiceStatistics");
            try
            {
                #if DESKTOP
                return client.GetTimeSeriesServiceStatistics(request);
                #elif CORECLR
                return client.GetTimeSeriesServiceStatisticsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String EntitySelectorExpression { get; set; }
            public System.Boolean? ForecastStatistic { get; set; }
            public System.String GroupARN { get; set; }
            public System.String GroupName { get; set; }
            public System.String NextToken { get; set; }
            public System.Int32? Period { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.XRay.Model.GetTimeSeriesServiceStatisticsResponse, GetXRTimeSeriesServiceStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TimeSeriesServiceStatistics;
        }
        
    }
}
