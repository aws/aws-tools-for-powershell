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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <code>ListAssignmentsForHIT</code> operation retrieves completed assignments
    /// for a HIT. You can use this operation to retrieve the results for a HIT. 
    /// 
    ///  
    /// <para>
    ///  You can get assignments for a HIT at any time, even if the HIT is not yet Reviewable.
    /// If a HIT requested multiple assignments, and has received some results but has not
    /// yet become Reviewable, you can still retrieve the partial results with this operation.
    /// 
    /// </para><para>
    ///  Use the AssignmentStatus parameter to control which set of assignments for a HIT
    /// are returned. The ListAssignmentsForHIT operation can return submitted assignments
    /// awaiting approval, or it can return assignments that have already been approved or
    /// rejected. You can set AssignmentStatus=Approved,Rejected to get assignments that have
    /// already been approved and rejected together in one result set. 
    /// </para><para>
    ///  Only the Requester who created the HIT can retrieve the assignments for that HIT.
    /// 
    /// </para><para>
    ///  Results are sorted and divided into numbered pages and the operation returns a single
    /// page of results. You can use the parameters of the operation to control sorting and
    /// pagination. 
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "MTRHITAssignmentList")]
    [OutputType("Amazon.MTurk.Model.Assignment")]
    [AWSCmdlet("Calls the Amazon MTurk Service ListAssignmentsForHIT API operation.", Operation = new[] {"ListAssignmentsForHIT"})]
    [AWSCmdletOutput("Amazon.MTurk.Model.Assignment",
        "This cmdlet returns a collection of Assignment objects.",
        "The service call response (type Amazon.MTurk.Model.ListAssignmentsForHITResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String), NumResults (type System.Int32)"
    )]
    public partial class GetMTRHITAssignmentListCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter AssignmentStatus
        /// <summary>
        /// <para>
        /// <para>The status of the assignments to return: Submitted | Approved | Rejected</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AssignmentStatuses")]
        public System.String[] AssignmentStatus { get; set; }
        #endregion
        
        #region Parameter HITId
        /// <summary>
        /// <para>
        /// <para>The ID of the HIT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HITId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token</para>
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
            
            if (this.AssignmentStatus != null)
            {
                context.AssignmentStatuses = new List<System.String>(this.AssignmentStatus);
            }
            context.HITId = this.HITId;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
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
            
            // create request and set iteration invariants
            var request = new Amazon.MTurk.Model.ListAssignmentsForHITRequest();
            if (cmdletContext.AssignmentStatuses != null)
            {
                request.AssignmentStatuses = cmdletContext.AssignmentStatuses;
            }
            if (cmdletContext.HITId != null)
            {
                request.HITId = cmdletContext.HITId;
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
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
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
                    int correctPageSize = 100;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(100, _emitLimit.Value);
                    }
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Assignments;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        notes["NumResults"] = response.NumResults;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Assignments.Count;
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
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
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
        
        private Amazon.MTurk.Model.ListAssignmentsForHITResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.ListAssignmentsForHITRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "ListAssignmentsForHIT");
            try
            {
                #if DESKTOP
                return client.ListAssignmentsForHIT(request);
                #elif CORECLR
                return client.ListAssignmentsForHITAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AssignmentStatuses { get; set; }
            public System.String HITId { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
