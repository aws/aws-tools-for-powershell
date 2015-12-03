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
    /// This action gets the list of ChangeBatches in a given time period for a given hosted
    /// zone.
    /// </summary>
    [Cmdlet("Get", "R53ChangeBatchesByHostedZone")]
    [OutputType("Amazon.Route53.Model.ChangeBatchRecord")]
    [AWSCmdlet("Invokes the ListChangeBatchesByHostedZone operation against Amazon Route 53.", Operation = new[] {"ListChangeBatchesByHostedZone"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ChangeBatchRecord",
        "This cmdlet returns a collection of ChangeBatchRecord objects.",
        "The service call response (type Amazon.Route53.Model.ListChangeBatchesByHostedZoneResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: MaxItems (type System.String), Marker (type System.String), IsTruncated (type System.Boolean), NextMarker (type System.String)"
    )]
    public class GetR53ChangeBatchesByHostedZoneCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The end of the time period you want to see changes for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndDate { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that you want to see changes for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HostedZoneId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The start of the time period you want to see changes for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartDate { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The page marker.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of items on a page.</para>
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
            
            context.HostedZoneId = this.HostedZoneId;
            context.StartDate = this.StartDate;
            context.EndDate = this.EndDate;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            context.Marker = this.Marker;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.Route53.Model.ListChangeBatchesByHostedZoneRequest();
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate;
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
                        
                        var response = client.ListChangeBatchesByHostedZone(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ChangeBatchRecords;
                        notes = new Dictionary<string, object>();
                        notes["MaxItems"] = response.MaxItems;
                        notes["Marker"] = response.Marker;
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["NextMarker"] = response.NextMarker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ChangeBatchRecords.Count;
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
            public System.String HostedZoneId { get; set; }
            public System.String StartDate { get; set; }
            public System.String EndDate { get; set; }
            public int? MaxItems { get; set; }
            public System.String Marker { get; set; }
        }
        
    }
}
