/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Returns a list of <code>BatchPrediction</code> operations that match the search criteria
    /// in the request.
    /// </summary>
    [Cmdlet("Get", "MLBatchPredictions")]
    [OutputType("Amazon.MachineLearning.Model.BatchPrediction")]
    [AWSCmdlet("Invokes the DescribeBatchPredictions operation against Amazon Machine Learning.", Operation = new[] {"DescribeBatchPredictions"})]
    [AWSCmdletOutput("Amazon.MachineLearning.Model.BatchPrediction",
        "This cmdlet returns a collection of BatchPrediction objects.",
        "The service call response (type Amazon.MachineLearning.Model.DescribeBatchPredictionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetMLBatchPredictionsCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The equal to operator. The <code>BatchPrediction</code> results will have <code>FilterVariable</code>
        /// values that exactly match the value specified with <code>EQ</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EQ { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Use one of the following variables to filter a list of <code>BatchPrediction</code>:</para><ul><li><code>CreatedAt</code> - Sets the search criteria to the <code>BatchPrediction</code>
        /// creation date.</li><li><code>Status</code> - Sets the search criteria to the <code>BatchPrediction</code>
        /// status.</li><li><code>Name</code> - Sets the search criteria to the contents of
        /// the <code>BatchPrediction</code><b></b><code>Name</code>.</li><li><code>IAMUser</code>
        /// - Sets the search criteria to the user account that invoked the <code>BatchPrediction</code>
        /// creation.</li><li><code>MLModelId</code> - Sets the search criteria to the <code>MLModel</code>
        /// used in the <code>BatchPrediction</code>.</li><li><code>DataSourceId</code> - Sets
        /// the search criteria to the <code>DataSource</code> used in the <code>BatchPrediction</code>.</li><li><code>DataURI</code> - Sets the search criteria to the data file(s) used in the
        /// <code>BatchPrediction</code>. The URL can identify either a file or an Amazon Simple
        /// Storage Solution (Amazon S3) bucket or directory.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MachineLearning.BatchPredictionFilterVariable FilterVariable { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The greater than or equal to operator. The <code>BatchPrediction</code> results will
        /// have <code>FilterVariable</code> values that are greater than or equal to the value
        /// specified with <code>GE</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GE { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The greater than operator. The <code>BatchPrediction</code> results will have <code>FilterVariable</code>
        /// values that are greater than the value specified with <code>GT</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GT { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The less than or equal to operator. The <code>BatchPrediction</code> results will
        /// have <code>FilterVariable</code> values that are less than or equal to the value specified
        /// with <code>LE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LE { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The less than operator. The <code>BatchPrediction</code> results will have <code>FilterVariable</code>
        /// values that are less than the value specified with <code>LT</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LT { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The not equal to operator. The <code>BatchPrediction</code> results will have <code>FilterVariable</code>
        /// values not equal to the value specified with <code>NE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NE { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A string that is found at the beginning of a variable, such as <code>Name</code> or
        /// <code>Id</code>.</para><para>For example, a <code>Batch Prediction</code> operation could have the <code>Name</code><code>2014-09-09-HolidayGiftMailer</code>. To search for this <code>BatchPrediction</code>,
        /// select <code>Name</code> for the <code>FilterVariable</code> and any of the following
        /// strings for the <code>Prefix</code>: </para><ul><li><para>2014-09</para></li><li><para>2014-09-09</para></li><li><para>2014-09-09-Holiday</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Prefix { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A two-value parameter that determines the sequence of the resulting list of <code>MLModel</code>s.</para><ul><li><code>asc</code> - Arranges the list in ascending order (A-Z, 0-9).</li><li><code>dsc</code> - Arranges the list in descending order (Z-A, 9-0).</li></ul><para>Results are sorted by <code>FilterVariable</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MachineLearning.SortOrder SortOrder { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of pages of information to include in the result. The range of acceptable
        /// values is 1 through 100. The default value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An ID of the page in the paginated results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.EQ = this.EQ;
            context.FilterVariable = this.FilterVariable;
            context.GE = this.GE;
            context.GT = this.GT;
            context.LE = this.LE;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.LT = this.LT;
            context.NE = this.NE;
            context.NextToken = this.NextToken;
            context.Prefix = this.Prefix;
            context.SortOrder = this.SortOrder;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 100;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.Limit);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.Limit))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.Limit);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.DescribeBatchPredictions(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Results;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Results.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    // The service has a maximum page size of 100 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < _pageSize)
                    {
                        _emitLimit = _remainingItems;
                    }
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
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
        }
        
    }
}
