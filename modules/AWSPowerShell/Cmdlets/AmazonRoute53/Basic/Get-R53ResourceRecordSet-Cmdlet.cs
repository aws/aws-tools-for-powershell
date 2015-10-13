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
    /// Imagine all the resource record sets in a zone listed out in front of you. Imagine
    /// them sorted lexicographically first by DNS name (with the labels reversed, like "com.amazon.www"
    /// for example), and secondarily, lexicographically by record type. This operation retrieves
    /// at most MaxItems resource record sets from this list, in order, starting at a position
    /// specified by the Name and Type arguments:
    /// 
    ///  <ul><li>If both Name and Type are omitted, this means start the results at the first
    /// RRSET in the HostedZone.</li><li>If Name is specified but Type is omitted, this means
    /// start the results at the first RRSET in the list whose name is greater than or equal
    /// to Name. </li><li>If both Name and Type are specified, this means start the results
    /// at the first RRSET in the list whose name is greater than or equal to Name and whose
    /// type is greater than or equal to Type.</li><li>It is an error to specify the Type
    /// but not the Name.</li></ul><para>
    /// Use ListResourceRecordSets to retrieve a single known record set by specifying the
    /// record set's name and type, and setting MaxItems = 1
    /// </para><para>
    /// To retrieve all the records in a HostedZone, first pause any processes making calls
    /// to ChangeResourceRecordSets. Initially call ListResourceRecordSets without a Name
    /// and Type to get the first page of record sets. For subsequent calls, set Name and
    /// Type to the NextName and NextType values returned by the previous response. 
    /// </para><para>
    /// In the presence of concurrent ChangeResourceRecordSets calls, there is no consistency
    /// of results across calls to ListResourceRecordSets. The only way to get a consistent
    /// multi-page snapshot of all RRSETs in a zone is to stop making changes while pagination
    /// is in progress.
    /// </para><para>
    /// However, the results from ListResourceRecordSets are consistent within a page. If
    /// MakeChange calls are taking place concurrently, the result of each one will either
    /// be completely visible in your results or not at all. You will not see partial changes,
    /// or changes that do not ultimately succeed. (This follows from the fact that MakeChange
    /// is atomic) 
    /// </para><para>
    /// The results from ListResourceRecordSets are strongly consistent with ChangeResourceRecordSets.
    /// To be precise, if a single process makes a call to ChangeResourceRecordSets and receives
    /// a successful response, the effects of that change will be visible in a subsequent
    /// call to ListResourceRecordSets by that process.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53ResourceRecordSet")]
    [OutputType("Amazon.Route53.Model.ListResourceRecordSetsResponse")]
    [AWSCmdlet("Invokes the ListResourceRecordSets operation against AWS Route 53.", Operation = new[] {"ListResourceRecordSets"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ListResourceRecordSetsResponse",
        "This cmdlet returns a Amazon.Route53.Model.ListResourceRecordSetsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetR53ResourceRecordSetCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The ID of the hosted zone that contains the resource record sets that you want to
        /// get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HostedZoneId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para><i>Weighted resource record sets only:</i> If results were truncated for a given DNS
        /// name and type, specify the value of <code>ListResourceRecordSetsResponse$NextRecordIdentifier</code>
        /// from the previous response to get the next resource record set that has the current
        /// DNS name and type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartRecordIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The first name in the lexicographic ordering of domain names that you want the <code>ListResourceRecordSets</code>
        /// request to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String StartRecordName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The DNS type at which to begin the listing of resource record sets. </para><para>Valid values: <code>A</code> | <code>AAAA</code> | <code>CNAME</code> | <code>MX</code>
        /// | <code>NS</code> | <code>PTR</code> | <code>SOA</code> | <code>SPF</code> | <code>SRV</code>
        /// | <code>TXT</code></para><para>Values for Weighted Resource Record Sets: <code>A</code> | <code>AAAA</code> | <code>CNAME</code>
        /// | <code>TXT</code></para><para> Values for Regional Resource Record Sets: <code>A</code> | <code>AAAA</code> | <code>CNAME</code>
        /// | <code>TXT</code></para><para>Values for Alias Resource Record Sets: <code>A</code> | <code>AAAA</code></para><para>Constraint: Specifying <code>type</code> without specifying <code>name</code> returns
        /// an <a>InvalidInput</a> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public Amazon.Route53.RRType StartRecordType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of records you want in the response body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.HostedZoneId = this.HostedZoneId;
            context.StartRecordName = this.StartRecordName;
            context.StartRecordType = this.StartRecordType;
            context.StartRecordIdentifier = this.StartRecordIdentifier;
            context.MaxItems = this.MaxItem;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.ListResourceRecordSetsRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.StartRecordName != null)
            {
                request.StartRecordName = cmdletContext.StartRecordName;
            }
            if (cmdletContext.StartRecordType != null)
            {
                request.StartRecordType = cmdletContext.StartRecordType;
            }
            if (cmdletContext.StartRecordIdentifier != null)
            {
                request.StartRecordIdentifier = cmdletContext.StartRecordIdentifier;
            }
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListResourceRecordSets(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String HostedZoneId { get; set; }
            public System.String StartRecordName { get; set; }
            public Amazon.Route53.RRType StartRecordType { get; set; }
            public System.String StartRecordIdentifier { get; set; }
            public System.String MaxItems { get; set; }
        }
        
    }
}
