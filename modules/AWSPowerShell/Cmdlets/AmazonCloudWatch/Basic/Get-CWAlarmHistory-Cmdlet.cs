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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Retrieves the history for the specified alarm. You can filter the results by date
    /// range or item type. If an alarm name is not specified, the histories for all alarms
    /// are returned.
    /// 
    ///  
    /// <para>
    /// CloudWatch retains the history of an alarm even if you delete the alarm.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "CWAlarmHistory")]
    [OutputType("Amazon.CloudWatch.Model.AlarmHistoryItem")]
    [AWSCmdlet("Calls the Amazon CloudWatch DescribeAlarmHistory API operation.", Operation = new[] {"DescribeAlarmHistory"})]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.AlarmHistoryItem",
        "This cmdlet returns a collection of AlarmHistoryItem objects.",
        "The service call response (type Amazon.CloudWatch.Model.DescribeAlarmHistoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCWAlarmHistoryCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The name of the alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AlarmName { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The ending date to retrieve alarm history.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.DateTime EndDate { get; set; }
        #endregion
        
        #region Parameter HistoryItemType
        /// <summary>
        /// <para>
        /// <para>The type of alarm histories to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [AWSConstantClassSource("Amazon.CloudWatch.HistoryItemType")]
        public Amazon.CloudWatch.HistoryItemType HistoryItemType { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The starting date to retrieve alarm history.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.DateTime StartDate { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of alarm history records to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned by a previous call to indicate that there is more data available.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AlarmName = this.AlarmName;
            if (ParameterWasBound("EndDate"))
                context.EndDate = this.EndDate;
            context.HistoryItemType = this.HistoryItemType;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            context.NextToken = this.NextToken;
            if (ParameterWasBound("StartDate"))
                context.StartDate = this.StartDate;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.CloudWatch.Model.DescribeAlarmHistoryRequest();
            if (cmdletContext.AlarmName != null)
            {
                request.AlarmName = cmdletContext.AlarmName;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.HistoryItemType != null)
            {
                request.HistoryItemType = cmdletContext.HistoryItemType;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxRecords))
            {
                _emitLimit = cmdletContext.MaxRecords;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxRecords);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.AlarmHistoryItems;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.AlarmHistoryItems.Count;
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
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatch.Model.DescribeAlarmHistoryResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.DescribeAlarmHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "DescribeAlarmHistory");
            try
            {
                #if DESKTOP
                return client.DescribeAlarmHistory(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeAlarmHistoryAsync(request);
                return task.Result;
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
            public System.String AlarmName { get; set; }
            public System.DateTime? EndDate { get; set; }
            public Amazon.CloudWatch.HistoryItemType HistoryItemType { get; set; }
            public int? MaxRecords { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartDate { get; set; }
        }
        
    }
}
