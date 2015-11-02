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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// This operation returns all the domain names registered with Amazon Route 53 for the
    /// current AWS account.
    /// </summary>
    [Cmdlet("Get", "R53DDomains")]
    [OutputType("Amazon.Route53Domains.Model.DomainSummary")]
    [AWSCmdlet("Invokes the ListDomains operation against Amazon Route 53 Domains.", Operation = new[] {"ListDomains"})]
    [AWSCmdletOutput("Amazon.Route53Domains.Model.DomainSummary",
        "This cmdlet returns a collection of DomainSummary objects.",
        "The service call response (type Amazon.Route53Domains.Model.ListDomainsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextPageMarker (type System.String)"
    )]
    public class GetR53DDomainsCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>For an initial request for a list of domains, omit this element. If the number of
        /// domains that are associated with the current AWS account is greater than the value
        /// that you specified for <code>MaxItems</code>, you can use <code>Marker</code> to return
        /// additional domains. Get the value of <code>NextPageMarker</code> from the previous
        /// response, and submit another request that includes the value of <code>NextPageMarker</code>
        /// in the <code>Marker</code> element.</para><para>Type: String</para><para>Default: None</para><para>Constraints: The marker must match the value specified in the previous request. </para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Number of domains to be returned.</para><para>Type: Integer</para><para>Default: 20</para><para>Constraints: A numeral between 1 and 100.</para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.Int32 MaxItem { get; set; }
        
        
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
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.Route53Domains.Model.ListDomainsRequest();
            
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems.Value;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.ListDomains(request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Domains;
                        notes = new Dictionary<string, object>();
                        notes["NextPageMarker"] = response.NextPageMarker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.Domains.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.NextPageMarker;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (AutoIterationHelpers.HasValue(_nextMarker));
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
            public System.Int32? MaxItems { get; set; }
        }
        
    }
}
