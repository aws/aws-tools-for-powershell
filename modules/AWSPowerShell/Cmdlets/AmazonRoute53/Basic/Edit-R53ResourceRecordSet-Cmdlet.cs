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
    /// Use this action to create or change your authoritative DNS information. To use this
    /// action, send a <code>POST</code> request to the <code>2013-04-01/hostedzone/<i>hosted
    /// Zone ID</i>/rrset</code> resource. The request body must include an XML document with
    /// a <code>ChangeResourceRecordSetsRequest</code> element.
    /// 
    ///  
    /// <para>
    /// Changes are a list of change items and are considered transactional. For more information
    /// on transactional changes, also known as change batches, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/RRSchanges.html#RRSchanges_API">Creating,
    /// Changing, and Deleting Resource Record Sets Using the Route 53 API</a> in the <i>Amazon
    /// Route 53 Developer Guide</i>.
    /// </para><important>Due to the nature of transactional changes, you cannot delete the same
    /// resource record set more than once in a single change batch. If you attempt to delete
    /// the same change batch more than once, Route 53 returns an <code>InvalidChangeBatch</code>
    /// error.</important><para>
    /// In response to a <code>ChangeResourceRecordSets</code> request, your DNS data is changed
    /// on all Route 53 DNS servers. Initially, the status of a change is <code>PENDING</code>.
    /// This means the change has not yet propagated to all the authoritative Route 53 DNS
    /// servers. When the change is propagated to all hosts, the change returns a status of
    /// <code>INSYNC</code>.
    /// </para><para>
    /// Note the following limitations on a <code>ChangeResourceRecordSets</code> request:
    /// </para><para>
    /// - A request cannot contain more than 100 Change elements.
    /// </para><para>
    /// - A request cannot contain more than 1000 ResourceRecord elements.
    /// </para><para>
    /// The sum of the number of characters (including spaces) in all <code>Value</code> elements
    /// in a request cannot exceed 32,000 characters.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "R53ResourceRecordSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.ChangeInfo")]
    [AWSCmdlet("Invokes the ChangeResourceRecordSets operation against AWS Route 53.", Operation = new[] {"ChangeResourceRecordSets"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ChangeInfo",
        "This cmdlet returns a ChangeInfo object.",
        "The service call response (type Amazon.Route53.Model.ChangeResourceRecordSetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditR53ResourceRecordSetCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A complex type that contains one <code>Change</code> element for each resource record
        /// set that you want to create or delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("ChangeBatch_Changes")]
        public Amazon.Route53.Model.Change[] ChangeBatch_Change { get; set; }
        
        /// <summary>
        /// <para>
        /// <para><i>Optional:</i> Any comments you want to include about a change batch request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String ChangeBatch_Comment { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The ID of the hosted zone that contains the resource record sets that you want to
        /// change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HostedZoneId { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            context.HostedZoneId = this.HostedZoneId;
            context.ChangeBatch_Comment = this.ChangeBatch_Comment;
            if (this.ChangeBatch_Change != null)
            {
                context.ChangeBatch_Changes = new List<Amazon.Route53.Model.Change>(this.ChangeBatch_Change);
            }
            
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
                var response = client.ChangeResourceRecordSets(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String HostedZoneId { get; set; }
            public System.String ChangeBatch_Comment { get; set; }
            public List<Amazon.Route53.Model.Change> ChangeBatch_Changes { get; set; }
        }
        
    }
}
