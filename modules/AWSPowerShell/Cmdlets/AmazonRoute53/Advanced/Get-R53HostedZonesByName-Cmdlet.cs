/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// To retrieve a list of your hosted zones in lexicographic order, send a <code>GET</code>
    /// request to the <code>2013-04-01/hostedzonesbyname</code> resource. The response to
    /// this request includes a <code>HostedZones</code> element with zero or more <code>HostedZone</code>
    /// child elements lexicographically ordered by DNS name. By default, the list of hosted
    /// zones is displayed on a single page. You can control the length of the page that is
    /// displayed by using the <code>MaxItems</code> parameter. You can use the <code>DNSName</code>
    /// and <code>HostedZoneId</code> parameters to control the hosted zone that the list
    /// begins with.
    /// 
    ///  <note> Amazon Route 53 returns a maximum of 100 items. If you set MaxItems to a value
    /// greater than 100, Amazon Route 53 returns only the first 100.</note>
    /// </summary>
    [Cmdlet("Get", "R53HostedZonesByName")]
    [OutputType("Amazon.Route53.Model.HostedZone")]
    [AWSCmdlet("Invokes the ListHostedZonesByName operation against AWS Route 53.")]
    [AWSCmdletOutput("Amazon.Route53.Model.HostedZone",
        "This cmdlet returns a collection of HostedZone objects.",
        "The service call response (type ListHostedZonesByNameResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: IsTruncated (type Boolean), Marker (type HostedZonePageMarker), NextMarker (type HostedZonePageMarker), MaxItems (type String)"
    )]
    public class GetR53HostedZonesByNameCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Gets and sets the property DNSName. 
        /// <para>
        /// The first name in the lexicographic ordering of domain names that you want the <code>ListHostedZonesByNameRequest</code>
        /// request to list.
        /// </para><para>
        /// If the request returned more than one page of results, submit another request and
        /// specify the value of <code>NextMarker$DNSName</code> and <code>NextMarker$HostedZoneId</code>
        /// from the last response in the <code>DNSName</code> and <code>HostedZoneId</code> parameters
        /// to get the next page of results.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DNSName { get; set; }
        
        /// <summary>
        /// <para>
        /// Gets and sets the property HostedZoneId. 
        /// <para>
        /// If the request returned more than one page of results, submit another request and
        /// specify the value of <code>NextMarker$DNSName</code> and <code>NextMarker$HostedZoneId</code>
        /// from the last response in the <code>DNSName</code> and <code>HostedZoneId</code> parameters
        /// to get the next page of results.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String HostedZoneId { get; set; }
        
        /// <summary>
        /// <para>
        /// Gets and sets the property MaxItems. 
        /// <para>
        /// Specify the maximum number of hosted zones to return per page of results.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int? MaxItem { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DNSName = this.DNSName;
            context.HostedZoneId = this.HostedZoneId;
            context.MaxItems = this.MaxItem;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            // create request and set iteration invariants
            var request = new ListHostedZonesByNameRequest();

            if (cmdletContext.DNSName != null)
            {
                request.DNSName = cmdletContext.DNSName;
            }
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }

            // Initialize loop variants and commence piping
            string _nextDnsName = null;
            string _nextHostedZoneId = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItems))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, we rely on the service
                // ignoring the set maximum and giving us 100 items back. We'll
                // make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxItems;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.MaxItems);
            bool _continueIteration = true;

            try
            {
                do
                {
                    if (_nextDnsName != null || _nextHostedZoneId != null)
                    {
                        request.DNSName = _nextDnsName;
                        request.HostedZoneId = _nextHostedZoneId;
                    }
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToString(_emitLimit.Value);
                    }

                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;

                    try
                    {

                        var response = client.ListHostedZonesByName(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.HostedZones;
                        notes = new Dictionary<string, object>();
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["DNSName"] = response.DNSName;
                        notes["HostedZoneId"] = response.HostedZoneId;
                        notes["NextDNSName"] = response.NextDNSName;
                        notes["NextHostedZoneId"] = response.NextHostedZoneId;
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
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from DNSName '{1}' and HostedZoneId '{2}'", _receivedThisCall, request.DNSName, request.HostedZoneId));
                        }

                        _nextDnsName = response.NextDNSName;
                        _nextHostedZoneId = response.NextHostedZoneId;

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
                    if (_remainingItems < 100)
                    {
                        _emitLimit = _remainingItems;
                    }
                } while (_continueIteration && (_nextDnsName != null && _nextHostedZoneId != null));

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
            public String DNSName { get; set; }
            public String HostedZoneId { get; set; }
            public int? MaxItems { get; set; }
        }
        
    }
}
