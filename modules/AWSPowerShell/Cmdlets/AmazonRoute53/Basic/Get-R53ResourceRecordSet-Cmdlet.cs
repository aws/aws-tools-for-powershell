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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Lists the resource record sets in a specified hosted zone.
    /// 
    ///  
    /// <para><code>ListResourceRecordSets</code> returns up to 100 resource record sets at a time
    /// in ASCII order, beginning at a position specified by the <code>name</code> and <code>type</code>
    /// elements.
    /// </para><para><b>Sort order</b></para><para><code>ListResourceRecordSets</code> sorts results first by DNS name with the labels
    /// reversed, for example:
    /// </para><para><code>com.example.www.</code></para><para>
    /// Note the trailing dot, which can change the sort order when the record name contains
    /// characters that appear before <code>.</code> (decimal 46) in the ASCII table. These
    /// characters include the following: <code>! " # $ % &amp; ' ( ) * + , -</code></para><para>
    /// When multiple records have the same DNS name, <code>ListResourceRecordSets</code>
    /// sorts results by the record type.
    /// </para><para><b>Specifying where to start listing records</b></para><para>
    /// You can use the name and type elements to specify the resource record set that the
    /// list begins with:
    /// </para><dl><dt>If you do not specify Name or Type</dt><dd><para>
    /// The results begin with the first resource record set that the hosted zone contains.
    /// </para></dd><dt>If you specify Name but not Type</dt><dd><para>
    /// The results begin with the first resource record set in the list whose name is greater
    /// than or equal to <code>Name</code>.
    /// </para></dd><dt>If you specify Type but not Name</dt><dd><para>
    /// Amazon Route 53 returns the <code>InvalidInput</code> error.
    /// </para></dd><dt>If you specify both Name and Type</dt><dd><para>
    /// The results begin with the first resource record set in the list whose name is greater
    /// than or equal to <code>Name</code>, and whose type is greater than or equal to <code>Type</code>.
    /// </para></dd></dl><para><b>Resource record sets that are PENDING</b></para><para>
    /// This action returns the most current version of the records. This includes records
    /// that are <code>PENDING</code>, and that are not yet available on all Route 53 DNS
    /// servers.
    /// </para><para><b>Changing resource record sets</b></para><para>
    /// To ensure that you get an accurate listing of the resource record sets for a hosted
    /// zone at a point in time, do not submit a <code>ChangeResourceRecordSets</code> request
    /// while you're paging through the results of a <code>ListResourceRecordSets</code> request.
    /// If you do, some pages may display results without the latest changes while other pages
    /// display results with the latest changes.
    /// </para><para><b>Displaying the next page of results</b></para><para>
    /// If a <code>ListResourceRecordSets</code> command returns more than one page of results,
    /// the value of <code>IsTruncated</code> is <code>true</code>. To display the next page
    /// of results, get the values of <code>NextRecordName</code>, <code>NextRecordType</code>,
    /// and <code>NextRecordIdentifier</code> (if any) from the response. Then submit another
    /// <code>ListResourceRecordSets</code> request, and specify those values for <code>StartRecordName</code>,
    /// <code>StartRecordType</code>, and <code>StartRecordIdentifier</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53ResourceRecordSet")]
    [OutputType("Amazon.Route53.Model.ListResourceRecordSetsResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 ListResourceRecordSets API operation.", Operation = new[] {"ListResourceRecordSets"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ListResourceRecordSetsResponse",
        "This cmdlet returns a Amazon.Route53.Model.ListResourceRecordSetsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53ResourceRecordSetCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that contains the resource record sets that you want to
        /// list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Id")]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter StartRecordIdentifier
        /// <summary>
        /// <para>
        /// <para><i>Weighted resource record sets only:</i> If results were truncated for a given
        /// DNS name and type, specify the value of <code>NextRecordIdentifier</code> from the
        /// previous response to get the next resource record set that has the current DNS name
        /// and type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartRecordIdentifier { get; set; }
        #endregion
        
        #region Parameter StartRecordName
        /// <summary>
        /// <para>
        /// <para>The first name in the lexicographic ordering of resource record sets that you want
        /// to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String StartRecordName { get; set; }
        #endregion
        
        #region Parameter StartRecordType
        /// <summary>
        /// <para>
        /// <para>The type of resource record set to begin the record listing from.</para><para>Valid values for basic resource record sets: <code>A</code> | <code>AAAA</code> |
        /// <code>CAA</code> | <code>CNAME</code> | <code>MX</code> | <code>NAPTR</code> | <code>NS</code>
        /// | <code>PTR</code> | <code>SOA</code> | <code>SPF</code> | <code>SRV</code> | <code>TXT</code></para><para>Values for weighted, latency, geolocation, and failover resource record sets: <code>A</code>
        /// | <code>AAAA</code> | <code>CAA</code> | <code>CNAME</code> | <code>MX</code> | <code>NAPTR</code>
        /// | <code>PTR</code> | <code>SPF</code> | <code>SRV</code> | <code>TXT</code></para><para>Values for alias resource record sets: </para><ul><li><para><b>API Gateway custom regional API or edge-optimized API</b>: A</para></li><li><para><b>CloudFront distribution</b>: A or AAAA</para></li><li><para><b>Elastic Beanstalk environment that has a regionalized subdomain</b>: A</para></li><li><para><b>Elastic Load Balancing load balancer</b>: A | AAAA</para></li><li><para><b>Amazon S3 bucket</b>: A</para></li><li><para><b>Amazon VPC interface VPC endpoint</b>: A</para></li><li><para><b>Another resource record set in this hosted zone:</b> The type of the resource
        /// record set that the alias references.</para></li></ul><para>Constraint: Specifying <code>type</code> without specifying <code>name</code> returns
        /// an <code>InvalidInput</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType StartRecordType { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>(Optional) The maximum number of resource records sets to include in the response
        /// body for this request. If the response includes more than <code>maxitems</code> resource
        /// record sets, the value of the <code>IsTruncated</code> element in the response is
        /// <code>true</code>, and the values of the <code>NextRecordName</code> and <code>NextRecordType</code>
        /// elements in the response identify the first resource record set in the next group
        /// of <code>maxitems</code> resource record sets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
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
            
            context.HostedZoneId = this.HostedZoneId;
            context.StartRecordName = this.StartRecordName;
            context.StartRecordType = this.StartRecordType;
            context.StartRecordIdentifier = this.StartRecordIdentifier;
            context.MaxItems = this.MaxItem;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.Route53.Model.ListResourceRecordSetsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListResourceRecordSetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListResourceRecordSets");
            try
            {
                #if DESKTOP
                return client.ListResourceRecordSets(request);
                #elif CORECLR
                return client.ListResourceRecordSetsAsync(request).GetAwaiter().GetResult();
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
            public System.String HostedZoneId { get; set; }
            public System.String StartRecordName { get; set; }
            public Amazon.Route53.RRType StartRecordType { get; set; }
            public System.String StartRecordIdentifier { get; set; }
            public System.String MaxItems { get; set; }
        }
        
    }
}
