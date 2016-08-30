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
    /// Create, change, update, or delete authoritative DNS information on all Amazon Route
    /// 53 servers. Send a <code>POST</code> request to: 
    /// 
    ///  
    /// <para><code>/2013-04-01/hostedzone/<i>Amazon Route 53 hosted Zone ID</i>/rrset</code> resource.
    /// 
    /// </para><para>
    /// The request body must include a document with a <code>ChangeResourceRecordSetsRequest</code>
    /// element. The request body contains a list of change items, known as a change batch.
    /// Change batches are considered transactional changes. When using the Amazon Route 53
    /// API to change resource record sets, Amazon Route 53 either makes all or none of the
    /// changes in a change batch request. This ensures that Amazon Route 53 never partially
    /// implements the intended changes to the resource record sets in a hosted zone. 
    /// </para><para>
    /// For example, a change batch request that deletes the <code>CNAME</code>record for
    /// www.example.com and creates an alias resource record set for www.example.com. Amazon
    /// Route 53 deletes the first resource record set and creates the second resource record
    /// set in a single operation. If either the <code>DELETE</code> or the <code>CREATE</code>
    /// action fails, then both changes (plus any other changes in the batch) fail, and the
    /// original <code>CNAME</code> record continues to exist.
    /// </para><important><para>
    /// Due to the nature of transactional changes, you cannot delete the same resource record
    /// set more than once in a single change batch. If you attempt to delete the same change
    /// batch more than once, Amazon Route 53 returns an <code>InvalidChangeBatch</code> error.
    /// </para></important><note><para>
    /// To create resource record sets for complex routing configurations, use either the
    /// traffic flow visual editor in the Amazon Route 53 console or the API actions for traffic
    /// policies and traffic policy instances. Save the configuration as a traffic policy,
    /// then associate the traffic policy with one or more domain names (such as example.com)
    /// or subdomain names (such as www.example.com), in the same hosted zone or in multiple
    /// hosted zones. You can roll back the updates if the new configuration isn't performing
    /// as expected. For more information, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/traffic-flow.html">Using
    /// Traffic Flow to Route DNS Traffic</a> in the Amazon Route 53 API Reference or <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/actions-on-polices">Actions
    /// on Traffic Policies and Traffic Policy Instances</a> in this guide.
    /// </para></note><para>
    /// Use <code>ChangeResourceRecordsSetsRequest</code> to perform the following actions:
    /// </para><ul><li><para><code>CREATE</code>:Creates a resource record set that has the specified values.
    /// </para></li><li><para><code>DELETE</code>: Deletes an existing resource record set that has the specified
    /// values for <code>Name</code>, <code>Type</code>, <code>Set Identifier</code> (for
    /// code latency, weighted, geolocation, and failover resource record sets), and <code>TTL</code>
    /// (except alias resource record sets, for which the TTL is determined by the AWS resource
    /// you're routing queries to).
    /// </para></li><li><para><code>UPSERT</code>: If a resource record set does not already exist, AWS creates
    /// it. If a resource set does exist, Amazon Route 53 updates it with the values in the
    /// request. Amazon Route 53 can update an existing resource record set only when all
    /// of the following values match: <code>Name</code>, <code>Type</code>, and <code>Set
    /// Identifier</code> (for weighted, latency, geolocation, and failover resource record
    /// sets).
    /// </para></li></ul><para>
    /// In response to a <code>ChangeResourceRecordSets</code> request, the DNS data is changed
    /// on all Amazon Route 53 DNS servers. Initially, the status of a change is <code>PENDING</code>,
    /// meaning the change has not yet propagated to all the authoritative Amazon Route 53
    /// DNS servers. When the change is propagated to all hosts, the change returns a status
    /// of <code>INSYNC</code>.
    /// </para><para>
    /// After sending a change request, confirm your change has propagated to all Amazon Route
    /// 53 DNS servers. Changes generally propagate to all Amazon Route 53 name servers in
    /// a few minutes. In rare circumstances, propagation can take up to 30 minutes. For more
    /// information, see <a>GetChange</a>.
    /// </para><para>
    /// Note the following limitations on a <code>ChangeResourceRecordSets</code> request:
    /// </para><ul><li><para>
    ///  A request cannot contain more than 100 Change elements.
    /// </para></li><li><para>
    ///  A request cannot contain more than 1000 ResourceRecord elements.
    /// </para></li><li><para>
    /// The sum of the number of characters (including spaces) in all <code>Value</code> elements
    /// in a request cannot exceed 32,000 characters.
    /// </para></li><li><note><para>
    /// If the value of the Action element in a ChangeResourceRecordSets request is <code>UPSERT</code>
    /// and the resource record set already exists, Amazon Route 53 automatically performs
    /// a <code>DELETE</code> request and a <code>CREATE</code> request. When Amazon Route
    /// 53 calculates the number of characters in the Value elements of a change batch request,
    /// it adds the number of characters in the Value element of the resource record set being
    /// deleted and the number of characters in the Value element of the resource record set
    /// being created.
    /// </para></note></li><li><para>
    /// The same resource cannot be deleted more than once in a single batch.
    /// </para></li></ul><note><para>
    /// If the value of the Action element in a ChangeResourceRecordSets request is <code>UPSERT</code>
    /// and the resource record set already exists, Amazon Route 53 automatically performs
    /// a <code>DELETE</code> request and a <code>CREATE</code> request. When Amazon Route
    /// 53 calculates the number of characters in the Value elements of a change batch request,
    /// it adds the number of characters in the Value element of the resource record set being
    /// deleted and the number of characters in the Value element of the resource record set
    /// being created.
    /// </para></note><para>
    /// For more information on transactional changes, see <a>ChangeResourceRecordSets</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "R53ResourceRecordSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.ChangeInfo")]
    [AWSCmdlet("Invokes the ChangeResourceRecordSets operation against Amazon Route 53.", Operation = new[] {"ChangeResourceRecordSets"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ChangeInfo",
        "This cmdlet returns a ChangeInfo object.",
        "The service call response (type Amazon.Route53.Model.ChangeResourceRecordSetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditR53ResourceRecordSetCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeBatch_Change
        /// <summary>
        /// <para>
        /// <para>Information about the changes to make to the record sets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("ChangeBatch_Changes")]
        public Amazon.Route53.Model.Change[] ChangeBatch_Change { get; set; }
        #endregion
        
        #region Parameter ChangeBatch_Comment
        /// <summary>
        /// <para>
        /// <para><i>Optional:</i> Any comments you want to include about a change batch request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String ChangeBatch_Comment { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that contains the resource record sets that you want to
        /// change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("HostedZoneId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-R53ResourceRecordSet (ChangeResourceRecordSets)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.HostedZoneId = this.HostedZoneId;
            context.ChangeBatch_Comment = this.ChangeBatch_Comment;
            if (this.ChangeBatch_Change != null)
            {
                context.ChangeBatch_Changes = new List<Amazon.Route53.Model.Change>(this.ChangeBatch_Change);
            }
            
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
            var request = new Amazon.Route53.Model.ChangeResourceRecordSetsRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            
             // populate ChangeBatch
            bool requestChangeBatchIsNull = true;
            request.ChangeBatch = new Amazon.Route53.Model.ChangeBatch();
            System.String requestChangeBatch_changeBatch_Comment = null;
            if (cmdletContext.ChangeBatch_Comment != null)
            {
                requestChangeBatch_changeBatch_Comment = cmdletContext.ChangeBatch_Comment;
            }
            if (requestChangeBatch_changeBatch_Comment != null)
            {
                request.ChangeBatch.Comment = requestChangeBatch_changeBatch_Comment;
                requestChangeBatchIsNull = false;
            }
            List<Amazon.Route53.Model.Change> requestChangeBatch_changeBatch_Change = null;
            if (cmdletContext.ChangeBatch_Changes != null)
            {
                requestChangeBatch_changeBatch_Change = cmdletContext.ChangeBatch_Changes;
            }
            if (requestChangeBatch_changeBatch_Change != null)
            {
                request.ChangeBatch.Changes = requestChangeBatch_changeBatch_Change;
                requestChangeBatchIsNull = false;
            }
             // determine if request.ChangeBatch should be set to null
            if (requestChangeBatchIsNull)
            {
                request.ChangeBatch = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ChangeInfo;
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
        
        private static Amazon.Route53.Model.ChangeResourceRecordSetsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ChangeResourceRecordSetsRequest request)
        {
            #if DESKTOP
            return client.ChangeResourceRecordSets(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ChangeResourceRecordSetsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String HostedZoneId { get; set; }
            public System.String ChangeBatch_Comment { get; set; }
            public List<Amazon.Route53.Model.Change> ChangeBatch_Changes { get; set; }
        }
        
    }
}
