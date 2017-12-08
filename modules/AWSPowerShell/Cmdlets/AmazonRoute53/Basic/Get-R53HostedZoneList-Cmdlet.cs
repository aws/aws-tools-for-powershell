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
    /// Retrieves a list of the public and private hosted zones that are associated with the
    /// current AWS account. The response includes a <code>HostedZones</code> child element
    /// for each hosted zone.
    /// 
    ///  
    /// <para>
    /// Amazon Route 53 returns a maximum of 100 items in each response. If you have a lot
    /// of hosted zones, you can use the <code>maxitems</code> parameter to list them in groups
    /// of up to 100.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "R53HostedZoneList")]
    [OutputType("Amazon.Route53.Model.HostedZone")]
    [AWSCmdlet("Calls the Amazon Route 53 ListHostedZones API operation.", Operation = new[] {"ListHostedZones"}, LegacyAlias="Get-R53HostedZones")]
    [AWSCmdletOutput("Amazon.Route53.Model.HostedZone",
        "This cmdlet returns a collection of HostedZone objects.",
        "The service call response (type Amazon.Route53.Model.ListHostedZonesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String), IsTruncated (type System.Boolean), NextMarker (type System.String), MaxItems (type System.String)"
    )]
    public partial class GetR53HostedZoneListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter DelegationSetId
        /// <summary>
        /// <para>
        /// <para>If you're using reusable delegation sets and you want to list all of the hosted zones
        /// that are associated with a reusable delegation set, specify the ID of that reusable
        /// delegation set. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DelegationSetId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>If the value of <code>IsTruncated</code> in the previous response was <code>true</code>,
        /// you have more hosted zones. To get more hosted zones, submit another <code>ListHostedZones</code>
        /// request. </para><para>For the value of <code>marker</code>, specify the value of <code>NextMarker</code>
        /// from the previous response, which is the ID of the first hosted zone that Amazon Route
        /// 53 will return if you submit another request.</para><para>If the value of <code>IsTruncated</code> in the previous response was <code>false</code>,
        /// there are no more hosted zones to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>(Optional) The maximum number of hosted zones that you want Amazon Route 53 to return.
        /// If you have more than <code>maxitems</code> hosted zones, the value of <code>IsTruncated</code>
        /// in the response is <code>true</code>, and the value of <code>NextMarker</code> is
        /// the hosted zone ID of the first hosted zone that Amazon Route 53 will return if you
        /// submit another request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
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
            
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            context.DelegationSetId = this.DelegationSetId;
            
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
            var request = new Amazon.Route53.Model.ListHostedZonesRequest();
            if (cmdletContext.DelegationSetId != null)
            {
                request.DelegationSetId = cmdletContext.DelegationSetId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 100;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
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
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.MaxItems);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
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
                        object pipelineOutput = response.HostedZones;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["NextMarker"] = response.NextMarker;
                        notes["MaxItems"] = response.MaxItems;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.HostedZones.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.NextMarker;
                        
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
        
        private Amazon.Route53.Model.ListHostedZonesResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListHostedZonesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListHostedZones");
            try
            {
                #if DESKTOP
                return client.ListHostedZones(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListHostedZonesAsync(request);
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
            public System.String Marker { get; set; }
            public int? MaxItems { get; set; }
            public System.String DelegationSetId { get; set; }
        }
        
    }
}
