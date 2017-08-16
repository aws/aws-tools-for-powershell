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
    /// Creates, changes, or deletes a resource record set, which contains authoritative DNS
    /// information for a specified domain name or subdomain name. For example, you can use
    /// <code>ChangeResourceRecordSets</code> to create a resource record set that routes
    /// traffic for test.example.com to a web server that has an IP address of 192.0.2.44.
    /// 
    ///  
    /// <para><b>Change Batches and Transactional Changes</b></para><para>
    /// The request body must include a document with a <code>ChangeResourceRecordSetsRequest</code>
    /// element. The request body contains a list of change items, known as a change batch.
    /// Change batches are considered transactional changes. When using the Amazon Route 53
    /// API to change resource record sets, Amazon Route 53 either makes all or none of the
    /// changes in a change batch request. This ensures that Amazon Route 53 never partially
    /// implements the intended changes to the resource record sets in a hosted zone. 
    /// </para><para>
    /// For example, a change batch request that deletes the <code>CNAME</code> record for
    /// www.example.com and creates an alias resource record set for www.example.com. Amazon
    /// Route 53 deletes the first resource record set and creates the second resource record
    /// set in a single operation. If either the <code>DELETE</code> or the <code>CREATE</code>
    /// action fails, then both changes (plus any other changes in the batch) fail, and the
    /// original <code>CNAME</code> record continues to exist.
    /// </para><important><para>
    /// Due to the nature of transactional changes, you can't delete the same resource record
    /// set more than once in a single change batch. If you attempt to delete the same change
    /// batch more than once, Amazon Route 53 returns an <code>InvalidChangeBatch</code> error.
    /// </para></important><para><b>Traffic Flow</b></para><para>
    /// To create resource record sets for complex routing configurations, use either the
    /// traffic flow visual editor in the Amazon Route 53 console or the API actions for traffic
    /// policies and traffic policy instances. Save the configuration as a traffic policy,
    /// then associate the traffic policy with one or more domain names (such as example.com)
    /// or subdomain names (such as www.example.com), in the same hosted zone or in multiple
    /// hosted zones. You can roll back the updates if the new configuration isn't performing
    /// as expected. For more information, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/traffic-flow.html">Using
    /// Traffic Flow to Route DNS Traffic</a> in the <i>Amazon Route 53 Developer Guide</i>.
    /// </para><para><b>Create, Delete, and Upsert</b></para><para>
    /// Use <code>ChangeResourceRecordsSetsRequest</code> to perform the following actions:
    /// </para><ul><li><para><code>CREATE</code>: Creates a resource record set that has the specified values.
    /// </para></li><li><para><code>DELETE</code>: Deletes an existing resource record set that has the specified
    /// values.
    /// </para></li><li><para><code>UPSERT</code>: If a resource record set does not already exist, AWS creates
    /// it. If a resource set does exist, Amazon Route 53 updates it with the values in the
    /// request. 
    /// </para></li></ul><para><b>Syntaxes for Creating, Updating, and Deleting Resource Record Sets</b></para><para>
    /// The syntax for a request depends on the type of resource record set that you want
    /// to create, delete, or update, such as weighted, alias, or failover. The XML elements
    /// in your request must appear in the order listed in the syntax. 
    /// </para><para>
    /// For an example for each type of resource record set, see "Examples."
    /// </para><para>
    /// Don't refer to the syntax in the "Parameter Syntax" section, which includes all of
    /// the elements for every kind of resource record set that you can create, delete, or
    /// update by using <code>ChangeResourceRecordSets</code>. 
    /// </para><para><b>Change Propagation to Amazon Route 53 DNS Servers</b></para><para>
    /// When you submit a <code>ChangeResourceRecordSets</code> request, Amazon Route 53 propagates
    /// your changes to all of the Amazon Route 53 authoritative DNS servers. While your changes
    /// are propagating, <code>GetChange</code> returns a status of <code>PENDING</code>.
    /// When propagation is complete, <code>GetChange</code> returns a status of <code>INSYNC</code>.
    /// Changes generally propagate to all Amazon Route 53 name servers within 60 seconds.
    /// For more information, see <a>GetChange</a>.
    /// </para><para><b>Limits on ChangeResourceRecordSets Requests</b></para><para>
    /// For information about the limits on a <code>ChangeResourceRecordSets</code> request,
    /// see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DNSLimitations.html">Limits</a>
    /// in the <i>Amazon Route 53 Developer Guide</i>.
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
        [Alias("Id")]
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
        
        private Amazon.Route53.Model.ChangeResourceRecordSetsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ChangeResourceRecordSetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ChangeResourceRecordSets");
            try
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
            public System.String ChangeBatch_Comment { get; set; }
            public List<Amazon.Route53.Model.Change> ChangeBatch_Changes { get; set; }
        }
        
    }
}
