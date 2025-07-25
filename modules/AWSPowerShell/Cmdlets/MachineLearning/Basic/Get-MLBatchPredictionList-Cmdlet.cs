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
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Returns a list of <c>BatchPrediction</c> operations that match the search criteria
    /// in the request.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "MLBatchPredictionList")]
    [OutputType("Amazon.MachineLearning.Model.BatchPrediction")]
    [AWSCmdlet("Calls the Amazon Machine Learning DescribeBatchPredictions API operation.", Operation = new[] {"DescribeBatchPredictions"}, SelectReturnType = typeof(Amazon.MachineLearning.Model.DescribeBatchPredictionsResponse), LegacyAlias="Get-MLBatchPredictions")]
    [AWSCmdletOutput("Amazon.MachineLearning.Model.BatchPrediction or Amazon.MachineLearning.Model.DescribeBatchPredictionsResponse",
        "This cmdlet returns a collection of Amazon.MachineLearning.Model.BatchPrediction objects.",
        "The service call response (type Amazon.MachineLearning.Model.DescribeBatchPredictionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMLBatchPredictionListCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EQ
        /// <summary>
        /// <para>
        /// <para>The equal to operator. The <c>BatchPrediction</c> results will have <c>FilterVariable</c>
        /// values that exactly match the value specified with <c>EQ</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EQ { get; set; }
        #endregion
        
        #region Parameter FilterVariable
        /// <summary>
        /// <para>
        /// <para>Use one of the following variables to filter a list of <c>BatchPrediction</c>:</para><ul><li><para><c>CreatedAt</c> - Sets the search criteria to the <c>BatchPrediction</c> creation
        /// date.</para></li><li><para><c>Status</c> - Sets the search criteria to the <c>BatchPrediction</c> status.</para></li><li><para><c>Name</c> - Sets the search criteria to the contents of the <c>BatchPrediction</c><b></b><c>Name</c>.</para></li><li><para><c>IAMUser</c> - Sets the search criteria to the user account that invoked the <c>BatchPrediction</c>
        /// creation.</para></li><li><para><c>MLModelId</c> - Sets the search criteria to the <c>MLModel</c> used in the <c>BatchPrediction</c>.</para></li><li><para><c>DataSourceId</c> - Sets the search criteria to the <c>DataSource</c> used in the
        /// <c>BatchPrediction</c>.</para></li><li><para><c>DataURI</c> - Sets the search criteria to the data file(s) used in the <c>BatchPrediction</c>.
        /// The URL can identify either a file or an Amazon Simple Storage Solution (Amazon S3)
        /// bucket or directory.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MachineLearning.BatchPredictionFilterVariable")]
        public Amazon.MachineLearning.BatchPredictionFilterVariable FilterVariable { get; set; }
        #endregion
        
        #region Parameter GE
        /// <summary>
        /// <para>
        /// <para>The greater than or equal to operator. The <c>BatchPrediction</c> results will have
        /// <c>FilterVariable</c> values that are greater than or equal to the value specified
        /// with <c>GE</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GE { get; set; }
        #endregion
        
        #region Parameter GT
        /// <summary>
        /// <para>
        /// <para>The greater than operator. The <c>BatchPrediction</c> results will have <c>FilterVariable</c>
        /// values that are greater than the value specified with <c>GT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GT { get; set; }
        #endregion
        
        #region Parameter LE
        /// <summary>
        /// <para>
        /// <para>The less than or equal to operator. The <c>BatchPrediction</c> results will have <c>FilterVariable</c>
        /// values that are less than or equal to the value specified with <c>LE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LE { get; set; }
        #endregion
        
        #region Parameter LT
        /// <summary>
        /// <para>
        /// <para>The less than operator. The <c>BatchPrediction</c> results will have <c>FilterVariable</c>
        /// values that are less than the value specified with <c>LT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LT { get; set; }
        #endregion
        
        #region Parameter NE
        /// <summary>
        /// <para>
        /// <para>The not equal to operator. The <c>BatchPrediction</c> results will have <c>FilterVariable</c>
        /// values not equal to the value specified with <c>NE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NE { get; set; }
        #endregion
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// <para>A string that is found at the beginning of a variable, such as <c>Name</c> or <c>Id</c>.</para><para>For example, a <c>Batch Prediction</c> operation could have the <c>Name</c><c>2014-09-09-HolidayGiftMailer</c>.
        /// To search for this <c>BatchPrediction</c>, select <c>Name</c> for the <c>FilterVariable</c>
        /// and any of the following strings for the <c>Prefix</c>: </para><ul><li><para>2014-09</para></li><li><para>2014-09-09</para></li><li><para>2014-09-09-Holiday</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>A two-value parameter that determines the sequence of the resulting list of <c>MLModel</c>s.</para><ul><li><para><c>asc</c> - Arranges the list in ascending order (A-Z, 0-9).</para></li><li><para><c>dsc</c> - Arranges the list in descending order (Z-A, 9-0).</para></li></ul><para>Results are sorted by <c>FilterVariable</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MachineLearning.SortOrder")]
        public Amazon.MachineLearning.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The number of pages of information to include in the result. The range of acceptable
        /// values is <c>1</c> through <c>100</c>. The default value is <c>100</c>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>100</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An ID of the page in the paginated results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MachineLearning.Model.DescribeBatchPredictionsResponse).
        /// Specifying the name of a property of type Amazon.MachineLearning.Model.DescribeBatchPredictionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
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
                context.Select = CreateSelectDelegate<Amazon.MachineLearning.Model.DescribeBatchPredictionsResponse, GetMLBatchPredictionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EQ = this.EQ;
            context.FilterVariable = this.FilterVariable;
            context.GE = this.GE;
            context.GT = this.GT;
            context.LE = this.LE;
            context.Limit = this.Limit;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.Limit)))
            {
                WriteVerbose("Limit parameter unset, using default value of '100'");
                context.Limit = 100;
            }
            #endif
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.LT = this.LT;
            context.NE = this.NE;
            context.NextToken = this.NextToken;
            context.Prefix = this.Prefix;
            context.SortOrder = this.SortOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.MachineLearning.Model.DescribeBatchPredictionsRequest();
            
            if (cmdletContext.EQ != null)
            {
                request.EQ = cmdletContext.EQ;
            }
            if (cmdletContext.FilterVariable != null)
            {
                request.FilterVariable = cmdletContext.FilterVariable;
            }
            if (cmdletContext.GE != null)
            {
                request.GE = cmdletContext.GE;
            }
            if (cmdletContext.GT != null)
            {
                request.GT = cmdletContext.GT;
            }
            if (cmdletContext.LE != null)
            {
                request.LE = cmdletContext.LE;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.LT != null)
            {
                request.LT = cmdletContext.LT;
            }
            if (cmdletContext.NE != null)
            {
                request.NE = cmdletContext.NE;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.MachineLearning.Model.DescribeBatchPredictionsRequest();
            if (cmdletContext.EQ != null)
            {
                request.EQ = cmdletContext.EQ;
            }
            if (cmdletContext.FilterVariable != null)
            {
                request.FilterVariable = cmdletContext.FilterVariable;
            }
            if (cmdletContext.GE != null)
            {
                request.GE = cmdletContext.GE;
            }
            if (cmdletContext.GT != null)
            {
                request.GT = cmdletContext.GT;
            }
            if (cmdletContext.LE != null)
            {
                request.LE = cmdletContext.LE;
            }
            if (cmdletContext.LT != null)
            {
                request.LT = cmdletContext.LT;
            }
            if (cmdletContext.NE != null)
            {
                request.NE = cmdletContext.NE;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Limit.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.Limit)))
                {
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(100);
                }
                
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
                    int _receivedThisCall = response.Results?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MachineLearning.Model.DescribeBatchPredictionsResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.DescribeBatchPredictionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "DescribeBatchPredictions");
            try
            {
                return client.DescribeBatchPredictionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EQ { get; set; }
            public Amazon.MachineLearning.BatchPredictionFilterVariable FilterVariable { get; set; }
            public System.String GE { get; set; }
            public System.String GT { get; set; }
            public System.String LE { get; set; }
            public int? Limit { get; set; }
            public System.String LT { get; set; }
            public System.String NE { get; set; }
            public System.String NextToken { get; set; }
            public System.String Prefix { get; set; }
            public Amazon.MachineLearning.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.MachineLearning.Model.DescribeBatchPredictionsResponse, GetMLBatchPredictionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
