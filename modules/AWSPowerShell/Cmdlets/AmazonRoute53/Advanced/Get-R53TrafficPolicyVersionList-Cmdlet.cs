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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Route53;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets information about all of the versions for a specified traffic policy. <code>ListTrafficPolicyVersions</code>
    /// lists only versions that have not been deleted.
    /// 
    ///  
    /// <para>
    /// Amazon Route 53 returns a maximum of 100 items in each response. If you have a lot
    /// of traffic policies, you can use the <code>maxitems</code> parameter to list them
    /// in groups of up to 100.
    /// </para><para>
    /// The response includes three values that help you navigate from one group of <code>maxitems</code>maxitems
    /// traffic policies to the next:
    /// </para><ul><li><b>IsTruncated</b></li><para>
    /// If the value of <code>IsTruncated</code> in the response is <code>true</code>, there
    /// are more traffic policy versions associated with the specified traffic policy.
    /// </para><para>
    /// If <code>IsTruncated</code> is <code>false</code>, this response includes the last
    /// traffic policy version that is associated with the specified traffic policy.
    /// </para><li><b>TrafficPolicyVersionMarker</b></li><para>
    /// The ID of the next traffic policy version that is associated with the current AWS
    /// account. If you want to list more traffic policies, make another call to <code>ListTrafficPolicyVersions</code>,
    /// and specify the value of the <code>TrafficPolicyVersionMarker</code> element in the
    /// <code>TrafficPolicyVersionMarker</code> request parameter.
    /// </para><para>
    /// If <code>IsTruncated</code> is <code>false</code>, Amazon Route 53 omits the <code>TrafficPolicyVersionMarker</code>
    /// element from the response.
    /// </para><li><b>MaxItems</b></li><para>
    /// The value that you specified for the <code>MaxItems</code> parameter in the request
    /// that produced the current response.
    /// </para></ul>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Get-R53TrafficPolicyVersions</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53TrafficPolicyVersionList")]
    [OutputType("Amazon.Route53.Model.TrafficPolicy")]
    [AWSCmdlet("Calls the Amazon Route 53 ListTrafficPolicyVersions API operation.", Operation = new[] { "ListTrafficPolicyVersions" }, LegacyAlias = "Get-R53TrafficPolicyVersions")]
    [AWSCmdletOutput("Amazon.Route53.Model.TrafficPolicy",
        "This cmdlet returns a collection of TrafficPolicy objects.",
        "The service call response (type Amazon.Route53.Model.ListTrafficPolicyVersionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: IsTruncated (type System.Boolean), TrafficPolicyVersionMarker (type System.String), MaxItems (type System.String)"
    )]
    public class GetR53TrafficPolicyVersionListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>Specify the value of <code>Id</code> of the traffic policy for which you want to list
        /// all versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion

        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of traffic policy versions that you want Amazon Route 53 to include
        /// in the response body for this request. If the specified traffic policy has more than
        /// <code>MaxItems</code> versions, the value of the <code>IsTruncated</code> element
        /// in the response is <code>true</code>, and the value of the <code>TrafficPolicyVersionMarker</code>
        /// element is the ID of the first version in the next group of <code>MaxItems</code>
        /// traffic policy versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        #endregion

        #region Parameter TrafficPolicyVersionMarker
        /// <summary>
        /// <para>
        /// <para>For your first request to <code>ListTrafficPolicyVersions</code>, do not include the
        /// <code>TrafficPolicyVersionMarker</code> parameter.</para><para>If you have more traffic policy versions than the value of <code>MaxItems</code>,
        /// <code>ListTrafficPolicyVersions</code> returns only the first group of <code>MaxItems</code>
        /// versions. To get the next group of <code>MaxItems</code> traffic policy versions,
        /// submit another request to <code>ListTrafficPolicyVersions</code>. For the value of
        /// <code>TrafficPolicyVersionMarker</code>, specify the value of the <code>TrafficPolicyVersionMarker</code>
        /// element that was returned in the previous response.</para><para>Traffic policy versions are listed in sequential order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String TrafficPolicyVersionMarker { get; set; }
        #endregion


        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Id = this.Id;
            context.TrafficPolicyVersionMarker = this.TrafficPolicyVersionMarker;
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
            var request = new Amazon.Route53.Model.ListTrafficPolicyVersionsRequest();
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 100;
            if (AutoIterationHelpers.HasValue(cmdletContext.TrafficPolicyVersionMarker))
            {
                _nextMarker = cmdletContext.TrafficPolicyVersionMarker;
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
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.TrafficPolicyVersionMarker) || AutoIterationHelpers.HasValue(cmdletContext.MaxItems);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.TrafficPolicyVersionMarker = _nextMarker;
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
                        object pipelineOutput = response.TrafficPolicies;
                        notes = new Dictionary<string, object>();
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["TrafficPolicyVersionMarker"] = response.TrafficPolicyVersionMarker;
                        notes["MaxItems"] = response.MaxItems;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.TrafficPolicies.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.TrafficPolicyVersionMarker));
                        }
                        
                        _nextMarker = response.TrafficPolicyVersionMarker;
                        
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

        private Amazon.Route53.Model.ListTrafficPolicyVersionsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListTrafficPolicyVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route 53", "ListTrafficPolicyVersions");

            try
            {
#if DESKTOP
                return client.ListTrafficPolicyVersions(request);
#elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListTrafficPolicyVersionsAsync(request);
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

        internal class CmdletContext : ExecutorContext
        {
            public System.String Id { get; set; }
            public System.String TrafficPolicyVersionMarker { get; set; }
            public int? MaxItems { get; set; }
        }
        
    }
}
