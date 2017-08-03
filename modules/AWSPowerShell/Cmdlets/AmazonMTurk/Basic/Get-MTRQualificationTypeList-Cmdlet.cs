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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <code>ListQualificationRequests</code> operation retrieves requests for Qualifications
    /// of a particular Qualification type. The owner of the Qualification type calls this
    /// operation to poll for pending requests, and accepts them using the AcceptQualification
    /// operation.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "MTRQualificationTypeList")]
    [OutputType("Amazon.MTurk.Model.QualificationType")]
    [AWSCmdlet("Invokes the ListQualificationTypes operation against Amazon MTurk Service.", Operation = new[] {"ListQualificationTypes"})]
    [AWSCmdletOutput("Amazon.MTurk.Model.QualificationType",
        "This cmdlet returns a collection of QualificationType objects.",
        "The service call response (type Amazon.MTurk.Model.ListQualificationTypesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String), NumResults (type System.Int32)"
    )]
    public partial class GetMTRQualificationTypeListCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter MustBeOwnedByCaller
        /// <summary>
        /// <para>
        /// <para> Specifies that only Qualification types that the Requester created are returned.
        /// If false, the operation returns all Qualification types. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean MustBeOwnedByCaller { get; set; }
        #endregion
        
        #region Parameter MustBeRequestable
        /// <summary>
        /// <para>
        /// <para>Specifies that only Qualification types that a user can request through the Amazon
        /// Mechanical Turk web site, such as by taking a Qualification test, are returned as
        /// results of the search. Some Qualification types, such as those assigned automatically
        /// by the system, cannot be requested directly by users. If false, all Qualification
        /// types, including those managed by the system, are considered. Valid values are True
        /// | False. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean MustBeRequestable { get; set; }
        #endregion
        
        #region Parameter Query
        /// <summary>
        /// <para>
        /// <para> A text query against all of the searchable attributes of Qualification types. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Query { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of results to return in a single call. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
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
            
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            if (ParameterWasBound("MustBeOwnedByCaller"))
                context.MustBeOwnedByCaller = this.MustBeOwnedByCaller;
            if (ParameterWasBound("MustBeRequestable"))
                context.MustBeRequestable = this.MustBeRequestable;
            context.NextToken = this.NextToken;
            context.Query = this.Query;
            
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
            var request = new Amazon.MTurk.Model.ListQualificationTypesRequest();
            if (cmdletContext.MustBeOwnedByCaller != null)
            {
                request.MustBeOwnedByCaller = cmdletContext.MustBeOwnedByCaller.Value;
            }
            if (cmdletContext.MustBeRequestable != null)
            {
                request.MustBeRequestable = cmdletContext.MustBeRequestable.Value;
            }
            if (cmdletContext.Query != null)
            {
                request.Query = cmdletContext.Query;
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
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.QualificationTypes;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        notes["NumResults"] = response.NumResults;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.QualificationTypes.Count;
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
        
        private Amazon.MTurk.Model.ListQualificationTypesResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.ListQualificationTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "ListQualificationTypes");
            #if DESKTOP
            return client.ListQualificationTypes(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListQualificationTypesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public int? MaxResults { get; set; }
            public System.Boolean? MustBeOwnedByCaller { get; set; }
            public System.Boolean? MustBeRequestable { get; set; }
            public System.String NextToken { get; set; }
            public System.String Query { get; set; }
        }
        
    }
}
