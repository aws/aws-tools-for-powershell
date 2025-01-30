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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Creates, changes, or deletes a resource record set, which contains authoritative DNS
    /// information for a specified domain name or subdomain name. For example, you can use
    /// <c>ChangeResourceRecordSets</c> to create a resource record set that routes traffic
    /// for test.example.com to a web server that has an IP address of 192.0.2.44.
    /// 
    ///  
    /// <para><b>Deleting Resource Record Sets</b></para><para>
    /// To delete a resource record set, you must specify all the same values that you specified
    /// when you created it.
    /// </para><para><b>Change Batches and Transactional Changes</b></para><para>
    /// The request body must include a document with a <c>ChangeResourceRecordSetsRequest</c>
    /// element. The request body contains a list of change items, known as a change batch.
    /// Change batches are considered transactional changes. Route 53 validates the changes
    /// in the request and then either makes all or none of the changes in the change batch
    /// request. This ensures that DNS routing isn't adversely affected by partial changes
    /// to the resource record sets in a hosted zone. 
    /// </para><para>
    /// For example, suppose a change batch request contains two changes: it deletes the <c>CNAME</c>
    /// resource record set for www.example.com and creates an alias resource record set for
    /// www.example.com. If validation for both records succeeds, Route 53 deletes the first
    /// resource record set and creates the second resource record set in a single operation.
    /// If validation for either the <c>DELETE</c> or the <c>CREATE</c> action fails, then
    /// the request is canceled, and the original <c>CNAME</c> record continues to exist.
    /// </para><note><para>
    /// If you try to delete the same resource record set more than once in a single change
    /// batch, Route 53 returns an <c>InvalidChangeBatch</c> error.
    /// </para></note><para><b>Traffic Flow</b></para><para>
    /// To create resource record sets for complex routing configurations, use either the
    /// traffic flow visual editor in the Route 53 console or the API actions for traffic
    /// policies and traffic policy instances. Save the configuration as a traffic policy,
    /// then associate the traffic policy with one or more domain names (such as example.com)
    /// or subdomain names (such as www.example.com), in the same hosted zone or in multiple
    /// hosted zones. You can roll back the updates if the new configuration isn't performing
    /// as expected. For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/traffic-flow.html">Using
    /// Traffic Flow to Route DNS Traffic</a> in the <i>Amazon Route 53 Developer Guide</i>.
    /// </para><para><b>Create, Delete, and Upsert</b></para><para>
    /// Use <c>ChangeResourceRecordsSetsRequest</c> to perform the following actions:
    /// </para><ul><li><para><c>CREATE</c>: Creates a resource record set that has the specified values.
    /// </para></li><li><para><c>DELETE</c>: Deletes an existing resource record set that has the specified values.
    /// </para></li><li><para><c>UPSERT</c>: If a resource set doesn't exist, Route 53 creates it. If a resource
    /// set exists Route 53 updates it with the values in the request. 
    /// </para></li></ul><para><b>Syntaxes for Creating, Updating, and Deleting Resource Record Sets</b></para><para>
    /// The syntax for a request depends on the type of resource record set that you want
    /// to create, delete, or update, such as weighted, alias, or failover. The XML elements
    /// in your request must appear in the order listed in the syntax. 
    /// </para><para>
    /// For an example for each type of resource record set, see "Examples."
    /// </para><para>
    /// Don't refer to the syntax in the "Parameter Syntax" section, which includes all of
    /// the elements for every kind of resource record set that you can create, delete, or
    /// update by using <c>ChangeResourceRecordSets</c>. 
    /// </para><para><b>Change Propagation to Route 53 DNS Servers</b></para><para>
    /// When you submit a <c>ChangeResourceRecordSets</c> request, Route 53 propagates your
    /// changes to all of the Route 53 authoritative DNS servers managing the hosted zone.
    /// While your changes are propagating, <c>GetChange</c> returns a status of <c>PENDING</c>.
    /// When propagation is complete, <c>GetChange</c> returns a status of <c>INSYNC</c>.
    /// Changes generally propagate to all Route 53 name servers managing the hosted zone
    /// within 60 seconds. For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_GetChange.html">GetChange</a>.
    /// </para><para><b>Limits on ChangeResourceRecordSets Requests</b></para><para>
    /// For information about the limits on a <c>ChangeResourceRecordSets</c> request, see
    /// <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DNSLimitations.html">Limits</a>
    /// in the <i>Amazon Route 53 Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "R53ResourceRecordSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.ChangeInfo")]
    [AWSCmdlet("Calls the Amazon Route 53 ChangeResourceRecordSets API operation.", Operation = new[] {"ChangeResourceRecordSets"}, SelectReturnType = typeof(Amazon.Route53.Model.ChangeResourceRecordSetsResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.ChangeInfo or Amazon.Route53.Model.ChangeResourceRecordSetsResponse",
        "This cmdlet returns an Amazon.Route53.Model.ChangeInfo object.",
        "The service call response (type Amazon.Route53.Model.ChangeResourceRecordSetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditR53ResourceRecordSetCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChangeBatch_Change
        /// <summary>
        /// <para>
        /// <para>Information about the changes to make to the record sets.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ChangeBatch_Changes")]
        public Amazon.Route53.Model.Change[] ChangeBatch_Change { get; set; }
        #endregion
        
        #region Parameter ChangeBatch_Comment
        /// <summary>
        /// <para>
        /// <para><i>Optional:</i> Any comments you want to include about a change batch request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ChangeBatch_Comment { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that contains the resource record sets that you want to
        /// change.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeInfo'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ChangeResourceRecordSetsResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ChangeResourceRecordSetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeInfo";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HostedZoneId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HostedZoneId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HostedZoneId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HostedZoneId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-R53ResourceRecordSet (ChangeResourceRecordSets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ChangeResourceRecordSetsResponse, EditR53ResourceRecordSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HostedZoneId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChangeBatch_Comment = this.ChangeBatch_Comment;
            if (this.ChangeBatch_Change != null)
            {
                context.ChangeBatch_Change = new List<Amazon.Route53.Model.Change>(this.ChangeBatch_Change);
            }
            #if MODULAR
            if (this.ChangeBatch_Change == null && ParameterWasBound(nameof(this.ChangeBatch_Change)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeBatch_Change which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var requestChangeBatchIsNull = true;
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
            if (cmdletContext.ChangeBatch_Change != null)
            {
                requestChangeBatch_changeBatch_Change = cmdletContext.ChangeBatch_Change;
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
        
        private Amazon.Route53.Model.ChangeResourceRecordSetsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ChangeResourceRecordSetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ChangeResourceRecordSets");
            try
            {
                #if DESKTOP
                return client.ChangeResourceRecordSets(request);
                #elif CORECLR
                return client.ChangeResourceRecordSetsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Route53.Model.Change> ChangeBatch_Change { get; set; }
            public System.Func<Amazon.Route53.Model.ChangeResourceRecordSetsResponse, EditR53ResourceRecordSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeInfo;
        }
        
    }
}
