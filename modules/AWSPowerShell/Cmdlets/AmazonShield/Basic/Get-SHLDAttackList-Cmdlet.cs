/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Returns all ongoing DDoS attacks or all DDoS attacks during a specified time period.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "SHLDAttackList")]
    [OutputType("Amazon.Shield.Model.AttackSummary")]
    [AWSCmdlet("Calls the AWS Shield ListAttacks API operation.", Operation = new[] {"ListAttacks"})]
    [AWSCmdletOutput("Amazon.Shield.Model.AttackSummary",
        "This cmdlet returns a collection of AttackSummary objects.",
        "The service call response (type Amazon.Shield.Model.ListAttacksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetSHLDAttackListCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime_FromInclusive
        /// <summary>
        /// <para>
        /// <para>The start time, in Unix time in seconds. For more information see <a href="http://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#parameter-types">timestamp</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime_FromInclusive { get; set; }
        #endregion
        
        #region Parameter StartTime_FromInclusive
        /// <summary>
        /// <para>
        /// <para>The start time, in Unix time in seconds. For more information see <a href="http://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#parameter-types">timestamp</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime_FromInclusive { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN (Amazon Resource Name) of the resource that was attacked. If this is left
        /// blank, all applicable resources for this account will be included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter EndTime_ToExclusive
        /// <summary>
        /// <para>
        /// <para>The end time, in Unix time in seconds. For more information see <a href="http://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#parameter-types">timestamp</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime_ToExclusive { get; set; }
        #endregion
        
        #region Parameter StartTime_ToExclusive
        /// <summary>
        /// <para>
        /// <para>The end time, in Unix time in seconds. For more information see <a href="http://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#parameter-types">timestamp</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime_ToExclusive { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of <a>AttackSummary</a> objects to be returned. If this is left
        /// blank, the first 20 results will be returned.</para><para>This is a maximum value; it is possible that AWS WAF will return the results in smaller
        /// batches. That is, the number of <a>AttackSummary</a> objects returned could be less
        /// than <code>MaxResults</code>, even if there are still more <a>AttackSummary</a> objects
        /// yet to return. If there are more <a>AttackSummary</a> objects to return, AWS WAF will
        /// always also return a <code>NextToken</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>ListAttacksRequest.NextMarker</code> value from a previous call to <code>ListAttacksRequest</code>.
        /// Pass null if this is the first call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
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
            
            if (ParameterWasBound("EndTime_FromInclusive"))
                context.EndTime_FromInclusive = this.EndTime_FromInclusive;
            if (ParameterWasBound("EndTime_ToExclusive"))
                context.EndTime_ToExclusive = this.EndTime_ToExclusive;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ResourceArn != null)
            {
                context.ResourceArns = new List<System.String>(this.ResourceArn);
            }
            if (ParameterWasBound("StartTime_FromInclusive"))
                context.StartTime_FromInclusive = this.StartTime_FromInclusive;
            if (ParameterWasBound("StartTime_ToExclusive"))
                context.StartTime_ToExclusive = this.StartTime_ToExclusive;
            
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
            var request = new Amazon.Shield.Model.ListAttacksRequest();
            
             // populate EndTime
            bool requestEndTimeIsNull = true;
            request.EndTime = new Amazon.Shield.Model.TimeRange();
            System.DateTime? requestEndTime_endTime_FromInclusive = null;
            if (cmdletContext.EndTime_FromInclusive != null)
            {
                requestEndTime_endTime_FromInclusive = cmdletContext.EndTime_FromInclusive.Value;
            }
            if (requestEndTime_endTime_FromInclusive != null)
            {
                request.EndTime.FromInclusive = requestEndTime_endTime_FromInclusive.Value;
                requestEndTimeIsNull = false;
            }
            System.DateTime? requestEndTime_endTime_ToExclusive = null;
            if (cmdletContext.EndTime_ToExclusive != null)
            {
                requestEndTime_endTime_ToExclusive = cmdletContext.EndTime_ToExclusive.Value;
            }
            if (requestEndTime_endTime_ToExclusive != null)
            {
                request.EndTime.ToExclusive = requestEndTime_endTime_ToExclusive.Value;
                requestEndTimeIsNull = false;
            }
             // determine if request.EndTime should be set to null
            if (requestEndTimeIsNull)
            {
                request.EndTime = null;
            }
            if (cmdletContext.ResourceArns != null)
            {
                request.ResourceArns = cmdletContext.ResourceArns;
            }
            
             // populate StartTime
            bool requestStartTimeIsNull = true;
            request.StartTime = new Amazon.Shield.Model.TimeRange();
            System.DateTime? requestStartTime_startTime_FromInclusive = null;
            if (cmdletContext.StartTime_FromInclusive != null)
            {
                requestStartTime_startTime_FromInclusive = cmdletContext.StartTime_FromInclusive.Value;
            }
            if (requestStartTime_startTime_FromInclusive != null)
            {
                request.StartTime.FromInclusive = requestStartTime_startTime_FromInclusive.Value;
                requestStartTimeIsNull = false;
            }
            System.DateTime? requestStartTime_startTime_ToExclusive = null;
            if (cmdletContext.StartTime_ToExclusive != null)
            {
                requestStartTime_startTime_ToExclusive = cmdletContext.StartTime_ToExclusive.Value;
            }
            if (requestStartTime_startTime_ToExclusive != null)
            {
                request.StartTime.ToExclusive = requestStartTime_startTime_ToExclusive.Value;
                requestStartTimeIsNull = false;
            }
             // determine if request.StartTime should be set to null
            if (requestStartTimeIsNull)
            {
                request.StartTime = null;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 10000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 10000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken");
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    int correctPageSize = 10000;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(10000, _emitLimit.Value);
                    }
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.AttackSummaries;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.AttackSummaries.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
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
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 0));
                
            }
            finally
            {
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Shield.Model.ListAttacksResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.ListAttacksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "ListAttacks");
            try
            {
                #if DESKTOP
                return client.ListAttacks(request);
                #elif CORECLR
                return client.ListAttacksAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime_FromInclusive { get; set; }
            public System.DateTime? EndTime_ToExclusive { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ResourceArns { get; set; }
            public System.DateTime? StartTime_FromInclusive { get; set; }
            public System.DateTime? StartTime_ToExclusive { get; set; }
        }
        
    }
}
