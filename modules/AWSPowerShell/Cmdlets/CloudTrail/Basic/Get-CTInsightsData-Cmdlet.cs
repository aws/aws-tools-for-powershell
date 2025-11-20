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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Returns Insights events generated on a trail that logs data events. You can list Insights
    /// events that occurred in a Region within the last 90 days.
    /// 
    ///  
    /// <para>
    /// ListInsightsData supports the following Dimensions for Insights events:
    /// </para><ul><li><para>
    /// Event ID
    /// </para></li><li><para>
    /// Event name
    /// </para></li><li><para>
    /// Event source
    /// </para></li></ul><para>
    /// All dimensions are optional. The default number of results returned is 50, with a
    /// maximum of 50 possible. The response includes a token that you can use to get the
    /// next page of results.
    /// </para><para>
    /// The rate of ListInsightsData requests is limited to two per second, per account, per
    /// Region. If this limit is exceeded, a throttling error occurs.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CTInsightsData")]
    [OutputType("Amazon.CloudTrail.Model.Event")]
    [AWSCmdlet("Calls the AWS CloudTrail ListInsightsData API operation.", Operation = new[] {"ListInsightsData"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.ListInsightsDataResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.Event or Amazon.CloudTrail.Model.ListInsightsDataResponse",
        "This cmdlet returns a collection of Amazon.CloudTrail.Model.Event objects.",
        "The service call response (type Amazon.CloudTrail.Model.ListInsightsDataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCTInsightsDataCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataType
        /// <summary>
        /// <para>
        /// <para>Specifies the category of events returned. To fetch Insights events, specify <c>InsightsEvents</c>
        /// as the value of <c>DataType</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudTrail.ListInsightsDataType")]
        public Amazon.CloudTrail.ListInsightsDataType DataType { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>Contains a map of dimensions. Currently the map can contain only one item.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Dimensions")]
        public System.Collections.Hashtable Dimension { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>Specifies that only events that occur before or at the specified time are returned.
        /// If the specified end time is before the specified start time, an error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter InsightSource
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name(ARN) of the trail for which you want to retrieve Insights
        /// events.</para>
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
        public System.String InsightSource { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>Specifies that only events that occur after or at the specified time are returned.
        /// If the specified start time is after the specified end time, an error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The number of events to return. Possible values are 1 through 50. The default is 50.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to use to get the next page of results after a previous API call. This token
        /// must be passed in with the same parameters that were specified in the original call.
        /// For example, if the original call specified a EventName as a dimension with <c>PutObject</c>
        /// as a value, the call with NextToken should include those same parameters. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Events'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.ListInsightsDataResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.ListInsightsDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Events";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.ListInsightsDataResponse, GetCTInsightsDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataType = this.DataType;
            #if MODULAR
            if (this.DataType == null && ParameterWasBound(nameof(this.DataType)))
            {
                WriteWarning("You are passing $null as a value for parameter DataType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Dimension != null)
            {
                context.Dimension = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Dimension.Keys)
                {
                    context.Dimension.Add((String)hashKey, (System.String)(this.Dimension[hashKey]));
                }
            }
            context.EndTime = this.EndTime;
            context.InsightSource = this.InsightSource;
            #if MODULAR
            if (this.InsightSource == null && ParameterWasBound(nameof(this.InsightSource)))
            {
                WriteWarning("You are passing $null as a value for parameter InsightSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
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
            var request = new Amazon.CloudTrail.Model.ListInsightsDataRequest();
            
            if (cmdletContext.DataType != null)
            {
                request.DataType = cmdletContext.DataType;
            }
            if (cmdletContext.Dimension != null)
            {
                request.Dimensions = cmdletContext.Dimension;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.InsightSource != null)
            {
                request.InsightSource = cmdletContext.InsightSource;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.CloudTrail.Model.ListInsightsDataResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.ListInsightsDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "ListInsightsData");
            try
            {
                #if DESKTOP
                return client.ListInsightsData(request);
                #elif CORECLR
                return client.ListInsightsDataAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CloudTrail.ListInsightsDataType DataType { get; set; }
            public Dictionary<System.String, System.String> Dimension { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.String InsightSource { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.CloudTrail.Model.ListInsightsDataResponse, GetCTInsightsDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Events;
        }
        
    }
}
