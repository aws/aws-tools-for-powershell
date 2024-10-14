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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Retrieves search metrics data. The data provides a snapshot of how your users interact
    /// with your search application and how effective the application is.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "KNDRSnapshot")]
    [OutputType("Amazon.Kendra.Model.GetSnapshotsResponse")]
    [AWSCmdlet("Calls the Amazon Kendra GetSnapshots API operation.", Operation = new[] {"GetSnapshots"}, SelectReturnType = typeof(Amazon.Kendra.Model.GetSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.Kendra.Model.GetSnapshotsResponse",
        "This cmdlet returns an Amazon.Kendra.Model.GetSnapshotsResponse object containing multiple properties."
    )]
    public partial class GetKNDRSnapshotCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index to get search metrics data.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter Interval
        /// <summary>
        /// <para>
        /// <para>The time interval or time window to get search metrics data. The time interval uses
        /// the time zone of your index. You can view data in the following time windows:</para><ul><li><para><c>THIS_WEEK</c>: The current week, starting on the Sunday and ending on the day
        /// before the current date.</para></li><li><para><c>ONE_WEEK_AGO</c>: The previous week, starting on the Sunday and ending on the
        /// following Saturday.</para></li><li><para><c>TWO_WEEKS_AGO</c>: The week before the previous week, starting on the Sunday and
        /// ending on the following Saturday.</para></li><li><para><c>THIS_MONTH</c>: The current month, starting on the first day of the month and
        /// ending on the day before the current date.</para></li><li><para><c>ONE_MONTH_AGO</c>: The previous month, starting on the first day of the month
        /// and ending on the last day of the month.</para></li><li><para><c>TWO_MONTHS_AGO</c>: The month before the previous month, starting on the first
        /// day of the month and ending on last day of the month.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Kendra.Interval")]
        public Amazon.Kendra.Interval Interval { get; set; }
        #endregion
        
        #region Parameter MetricType
        /// <summary>
        /// <para>
        /// <para>The metric you want to retrieve. You can specify only one metric per call.</para><para>For more information about the metrics you can view, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/search-analytics.html">Gaining
        /// insights with search analytics</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Kendra.MetricType")]
        public Amazon.Kendra.MetricType MetricType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of returned data for the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there is more data to retrieve),
        /// Amazon Kendra returns a pagination token in the response. You can use this pagination
        /// token to retrieve the next set of search metrics data.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.GetSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.Kendra.Model.GetSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IndexId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IndexId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IndexId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.GetSnapshotsResponse, GetKNDRSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IndexId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Interval = this.Interval;
            #if MODULAR
            if (this.Interval == null && ParameterWasBound(nameof(this.Interval)))
            {
                WriteWarning("You are passing $null as a value for parameter Interval which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.MetricType = this.MetricType;
            #if MODULAR
            if (this.MetricType == null && ParameterWasBound(nameof(this.MetricType)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Kendra.Model.GetSnapshotsRequest();
            
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.Interval != null)
            {
                request.Interval = cmdletContext.Interval;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MetricType != null)
            {
                request.MetricType = cmdletContext.MetricType;
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
        
        private Amazon.Kendra.Model.GetSnapshotsResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.GetSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "GetSnapshots");
            try
            {
                #if DESKTOP
                return client.GetSnapshots(request);
                #elif CORECLR
                return client.GetSnapshotsAsync(request).GetAwaiter().GetResult();
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
            public System.String IndexId { get; set; }
            public Amazon.Kendra.Interval Interval { get; set; }
            public System.Int32? MaxResult { get; set; }
            public Amazon.Kendra.MetricType MetricType { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Kendra.Model.GetSnapshotsResponse, GetKNDRSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
