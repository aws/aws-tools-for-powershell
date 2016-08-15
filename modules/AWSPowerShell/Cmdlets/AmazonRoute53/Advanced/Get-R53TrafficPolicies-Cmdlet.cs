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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets information about the latest version for every traffic policy that is associated
    /// with the current AWS account. To get the information, send a <code>GET</code> request
    /// to the <code>2015-01-01/trafficpolicy</code> resource.
    /// 
    ///  
    /// <para>
    /// Amazon Route 53 returns a maximum of 100 items in each response. If you have a lot
    /// of traffic policies, you can use the <code>maxitems</code> parameter to list them
    /// in groups of up to 100.
    /// </para><para>
    /// The response includes three values that help you navigate from one group of <code>maxitems</code>
    /// traffic policies to the next:
    /// </para><ul><li><b>IsTruncated</b></li><para>
    /// If the value of <code>IsTruncated</code> in the response is <code>true</code>, there
    /// are more traffic policies associated with the current AWS account.
    /// </para><para>
    /// If <code>IsTruncated</code> is <code>false</code>, this response includes the last
    /// traffic policy that is associated with the current account.
    /// </para><li><b>TrafficPolicyIdMarker</b></li><para>
    /// If <code>IsTruncated</code> is <code>true</code>, <code>TrafficPolicyIdMarker</code>
    /// is the ID of the first traffic policy in the next group of <code>MaxItems</code> traffic
    /// policies. If you want to list more traffic policies, make another call to <code>ListTrafficPolicies</code>,
    /// and specify the value of the <code>TrafficPolicyIdMarker</code> element from the response
    /// in the <code>TrafficPolicyIdMarker</code> request parameter.
    /// </para><para>
    /// If <code>IsTruncated</code> is <code>false</code>, the <code>TrafficPolicyIdMarker</code>
    /// element is omitted from the response.
    /// </para><li><b>MaxItems</b></li><para>
    /// The value that you specified for the <code>MaxItems</code> parameter in the request
    /// that produced the current response.
    /// </para></ul>
    /// </summary>
    [Cmdlet("Get", "R53TrafficPolicies")]
    [OutputType("Amazon.Route53.Model.TrafficPolicySummary")]
    [AWSCmdlet("Invokes the ListTrafficPolicies operation against Amazon Route 53.", Operation = new[] {"ListTrafficPolicies"})]
    [AWSCmdletOutput("Amazon.Route53.Model.TrafficPolicySummary",
        "This cmdlet returns a collection of TrafficPolicySummary objects.",
        "The service call response (type Amazon.Route53.Model.ListTrafficPoliciesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: IsTruncated (type System.Boolean), TrafficPolicyIdMarker (type System.String), MaxItems (type System.String)"
    )]
    public class GetR53TrafficPoliciesCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of traffic policies to be included in the response body for this
        /// request. If you have more than <code>MaxItems</code> traffic policies, the value of
        /// the <code>IsTruncated</code> element in the response is <code>true</code>, and the
        /// value of the <code>TrafficPolicyIdMarker</code> element is the ID of the first traffic
        /// policy in the next group of <code>MaxItems</code> traffic policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        #endregion

        #region Parameter TrafficPolicyIdMarker
        /// <summary>
        /// <para>
        /// <para>For your first request to <code>ListTrafficPolicies</code>, do not include the <code>TrafficPolicyIdMarker</code>
        /// parameter.</para><para>If you have more traffic policies than the value of <code>MaxItems</code>, <code>ListTrafficPolicies</code>
        /// returns only the first <code>MaxItems</code> traffic policies. To get the next group
        /// of <code>MaxItems</code> policies, submit another request to <code>ListTrafficPolicies</code>.
        /// For the value of <code>TrafficPolicyIdMarker</code>, specify the value of the <code>TrafficPolicyIdMarker</code>
        /// element that was returned in the previous response.</para><para>Policies are listed in the order in which they were created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String TrafficPolicyIdMarker { get; set; }
        #endregion


        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.TrafficPolicyIdMarker = this.TrafficPolicyIdMarker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.Route53.Model.ListTrafficPoliciesRequest();
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 100;
            if (AutoIterationHelpers.HasValue(cmdletContext.TrafficPolicyIdMarker))
            {
                _nextMarker = cmdletContext.TrafficPolicyIdMarker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItems))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxItems;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.TrafficPolicyIdMarker) || AutoIterationHelpers.HasValue(cmdletContext.MaxItems);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.TrafficPolicyIdMarker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToString(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.MaxItems))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.MaxItems);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToString(correctPageSize);
                    }

                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.TrafficPolicySummaries;
                        notes = new Dictionary<string, object>();
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["TrafficPolicyIdMarker"] = response.TrafficPolicyIdMarker;
                        notes["MaxItems"] = response.MaxItems;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.TrafficPolicySummaries.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.TrafficPolicyIdMarker));
                        }
                        
                        _nextMarker = response.TrafficPolicyIdMarker;
                        
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

        #region AWS Service Operation Call

        private static Amazon.Route53.Model.ListTrafficPoliciesResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListTrafficPoliciesRequest request)
        {
#if DESKTOP
            return client.ListTrafficPolicies(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListTrafficPoliciesAsync(request);
            return task.Result;
#else
#error "Unknown build edition"
#endif
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public System.String TrafficPolicyIdMarker { get; set; }
            public int? MaxItems { get; set; }
        }
        
    }
}
