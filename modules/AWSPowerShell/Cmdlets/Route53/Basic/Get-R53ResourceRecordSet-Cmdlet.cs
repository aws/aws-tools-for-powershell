/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Route53;
using Amazon.Route53.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Lists the resource record sets in a specified hosted zone.
    /// 
    ///  
    /// <para><c>ListResourceRecordSets</c> returns up to 300 resource record sets at a time in
    /// ASCII order, beginning at a position specified by the <c>name</c> and <c>type</c>
    /// elements.
    /// </para><para><b>Sort order</b></para><para><c>ListResourceRecordSets</c> sorts results first by DNS name with the labels reversed,
    /// for example:
    /// </para><para><c>com.example.www.</c></para><para>
    /// Note the trailing dot, which can change the sort order when the record name contains
    /// characters that appear before <c>.</c> (decimal 46) in the ASCII table. These characters
    /// include the following: <c>! " # $ % &amp; ' ( ) * + , -</c></para><para>
    /// When multiple records have the same DNS name, <c>ListResourceRecordSets</c> sorts
    /// results by the record type.
    /// </para><para><b>Specifying where to start listing records</b></para><para>
    /// You can use the name and type elements to specify the resource record set that the
    /// list begins with:
    /// </para><dl><dt>If you do not specify Name or Type</dt><dd><para>
    /// The results begin with the first resource record set that the hosted zone contains.
    /// </para></dd><dt>If you specify Name but not Type</dt><dd><para>
    /// The results begin with the first resource record set in the list whose name is greater
    /// than or equal to <c>Name</c>.
    /// </para></dd><dt>If you specify Type but not Name</dt><dd><para>
    /// Amazon Route 53 returns the <c>InvalidInput</c> error.
    /// </para></dd><dt>If you specify both Name and Type</dt><dd><para>
    /// The results begin with the first resource record set in the list whose name is greater
    /// than or equal to <c>Name</c>, and whose type is greater than or equal to <c>Type</c>.
    /// </para><note><para>
    /// Type is only used to sort between records with the same record Name.
    /// </para></note></dd></dl><para><b>Resource record sets that are PENDING</b></para><para>
    /// This action returns the most current version of the records. This includes records
    /// that are <c>PENDING</c>, and that are not yet available on all Route 53 DNS servers.
    /// </para><para><b>Changing resource record sets</b></para><para>
    /// To ensure that you get an accurate listing of the resource record sets for a hosted
    /// zone at a point in time, do not submit a <c>ChangeResourceRecordSets</c> request while
    /// you're paging through the results of a <c>ListResourceRecordSets</c> request. If you
    /// do, some pages may display results without the latest changes while other pages display
    /// results with the latest changes.
    /// </para><para><b>Displaying the next page of results</b></para><para>
    /// If a <c>ListResourceRecordSets</c> command returns more than one page of results,
    /// the value of <c>IsTruncated</c> is <c>true</c>. To display the next page of results,
    /// get the values of <c>NextRecordName</c>, <c>NextRecordType</c>, and <c>NextRecordIdentifier</c>
    /// (if any) from the response. Then submit another <c>ListResourceRecordSets</c> request,
    /// and specify those values for <c>StartRecordName</c>, <c>StartRecordType</c>, and <c>StartRecordIdentifier</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53ResourceRecordSet")]
    [OutputType("Amazon.Route53.Model.ListResourceRecordSetsResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 ListResourceRecordSets API operation.", Operation = new[] {"ListResourceRecordSets"}, SelectReturnType = typeof(Amazon.Route53.Model.ListResourceRecordSetsResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.ListResourceRecordSetsResponse",
        "This cmdlet returns an Amazon.Route53.Model.ListResourceRecordSetsResponse object containing multiple properties."
    )]
    public partial class GetR53ResourceRecordSetCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that contains the resource record sets that you want to
        /// list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Id")]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter StartRecordIdentifier
        /// <summary>
        /// <para>
        /// <para><i>Resource record sets that have a routing policy other than simple:</i> If results
        /// were truncated for a given DNS name and type, specify the value of <c>NextRecordIdentifier</c>
        /// from the previous response to get the next resource record set that has the current
        /// DNS name and type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartRecordIdentifier { get; set; }
        #endregion
        
        #region Parameter StartRecordName
        /// <summary>
        /// <para>
        /// <para>The first name in the lexicographic ordering of resource record sets that you want
        /// to list. If the specified record name doesn't exist, the results begin with the first
        /// resource record set that has a name greater than the value of <c>name</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String StartRecordName { get; set; }
        #endregion
        
        #region Parameter StartRecordType
        /// <summary>
        /// <para>
        /// <para>The type of resource record set to begin the record listing from.</para><para>Valid values for basic resource record sets: <c>A</c> | <c>AAAA</c> | <c>CAA</c> |
        /// <c>CNAME</c> | <c>MX</c> | <c>NAPTR</c> | <c>NS</c> | <c>PTR</c> | <c>SOA</c> | <c>SPF</c>
        /// | <c>SRV</c> | <c>TXT</c></para><para>Values for weighted, latency, geolocation, and failover resource record sets: <c>A</c>
        /// | <c>AAAA</c> | <c>CAA</c> | <c>CNAME</c> | <c>MX</c> | <c>NAPTR</c> | <c>PTR</c>
        /// | <c>SPF</c> | <c>SRV</c> | <c>TXT</c></para><para>Values for alias resource record sets: </para><ul><li><para><b>API Gateway custom regional API or edge-optimized API</b>: A</para></li><li><para><b>CloudFront distribution</b>: A or AAAA</para></li><li><para><b>Elastic Beanstalk environment that has a regionalized subdomain</b>: A</para></li><li><para><b>Elastic Load Balancing load balancer</b>: A | AAAA</para></li><li><para><b>S3 bucket</b>: A</para></li><li><para><b>VPC interface VPC endpoint</b>: A</para></li><li><para><b>Another resource record set in this hosted zone:</b> The type of the resource
        /// record set that the alias references.</para></li></ul><para>Constraint: Specifying <c>type</c> without specifying <c>name</c> returns an <c>InvalidInput</c>
        /// error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType StartRecordType { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>(Optional) The maximum number of resource records sets to include in the response
        /// body for this request. If the response includes more than <c>maxitems</c> resource
        /// record sets, the value of the <c>IsTruncated</c> element in the response is <c>true</c>,
        /// and the values of the <c>NextRecordName</c> and <c>NextRecordType</c> elements in
        /// the response identify the first resource record set in the next group of <c>maxitems</c>
        /// resource record sets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListResourceRecordSetsResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListResourceRecordSetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListResourceRecordSetsResponse, GetR53ResourceRecordSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartRecordName = this.StartRecordName;
            context.StartRecordType = this.StartRecordType;
            context.StartRecordIdentifier = this.StartRecordIdentifier;
            context.MaxItem = this.MaxItem;
            
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
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.ListResourceRecordSetsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MaxItem { get; set; }
            public System.Func<Amazon.Route53.Model.ListResourceRecordSetsResponse, GetR53ResourceRecordSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
