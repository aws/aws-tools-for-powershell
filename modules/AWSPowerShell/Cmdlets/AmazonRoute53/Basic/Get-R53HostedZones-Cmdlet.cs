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
    /// To retrieve a list of your hosted zones, send a <code>GET</code> request to the <code>2013-04-01/hostedzone</code>
    /// resource. The response to this request includes a <code>HostedZones</code> element
    /// with zero, one, or multiple <code>HostedZone</code> child elements. By default, the
    /// list of hosted zones is displayed on a single page. You can control the length of
    /// the page that is displayed by using the <code>MaxItems</code> parameter. You can use
    /// the <code>Marker</code> parameter to control the hosted zone that the list begins
    /// with. 
    /// 
    ///  <note> Amazon Route 53 returns a maximum of 100 items. If you set MaxItems to a value
    /// greater than 100, Amazon Route 53 returns only the first 100.</note>
    /// </summary>
    [Cmdlet("Get", "R53HostedZones")]
    [OutputType("Amazon.Route53.Model.HostedZone")]
    [AWSCmdlet("Invokes the ListHostedZones operation against Amazon Route 53.", Operation = new[] {"ListHostedZones"})]
    [AWSCmdletOutput("Amazon.Route53.Model.HostedZone",
        "This cmdlet returns a collection of HostedZone objects.",
        "The service call response (type Amazon.Route53.Model.ListHostedZonesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String), IsTruncated (type System.Boolean), NextMarker (type System.String), MaxItems (type System.String)"
    )]
    public class GetR53HostedZonesCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DelegationSetId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If the request returned more than one page of results, submit another request and
        /// specify the value of <code>NextMarker</code> from the last response in the <code>marker</code>
        /// parameter to get the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specify the maximum number of hosted zones to return per page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            context.DelegationSetId = this.DelegationSetId;
            
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
                        
                        var response = client.ListHostedZones(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Marker { get; set; }
            public int? MaxItems { get; set; }
            public System.String DelegationSetId { get; set; }
        }
        
    }
}
