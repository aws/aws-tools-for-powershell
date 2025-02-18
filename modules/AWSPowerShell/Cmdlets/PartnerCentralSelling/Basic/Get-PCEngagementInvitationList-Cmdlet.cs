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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// Retrieves a list of engagement invitations sent to the partner. This allows partners
    /// to view all pending or past engagement invitations, helping them track opportunities
    /// shared by AWS.
    /// </summary>
    [Cmdlet("Get", "PCEngagementInvitationList")]
    [OutputType("Amazon.PartnerCentralSelling.Model.EngagementInvitationSummary")]
    [AWSCmdlet("Calls the Partner Central Selling API ListEngagementInvitations API operation.", Operation = new[] {"ListEngagementInvitations"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.EngagementInvitationSummary or Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsResponse",
        "This cmdlet returns a collection of Amazon.PartnerCentralSelling.Model.EngagementInvitationSummary objects.",
        "The service call response (type Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCEngagementInvitationListCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>Specifies the catalog from which to list the engagement invitations. Use <c>AWS</c>
        /// for production invitations or <c>Sandbox</c> for testing environments.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter EngagementIdentifier
        /// <summary>
        /// <para>
        /// <para> Retrieves a list of engagement invitation summaries based on specified filters. The
        /// ListEngagementInvitations operation allows you to view all invitations that you have
        /// sent or received. You must specify the ParticipantType to filter invitations where
        /// you are either the SENDER or the RECEIVER. Invitations will automatically expire if
        /// not accepted within 15 days. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EngagementIdentifier { get; set; }
        #endregion
        
        #region Parameter ParticipantType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of participant for which to list engagement invitations. Identifies
        /// the role of the participant.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.ParticipantType")]
        public Amazon.PartnerCentralSelling.ParticipantType ParticipantType { get; set; }
        #endregion
        
        #region Parameter PayloadType
        /// <summary>
        /// <para>
        /// <para>Defines the type of payload associated with the engagement invitations to be listed.
        /// The attributes in this payload help decide on acceptance or rejection of the invitation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PayloadType { get; set; }
        #endregion
        
        #region Parameter SenderAwsAccountId
        /// <summary>
        /// <para>
        /// <para> List of sender AWS account IDs to filter the invitations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] SenderAwsAccountId { get; set; }
        #endregion
        
        #region Parameter Sort_SortBy
        /// <summary>
        /// <para>
        /// <para>Specifies the field by which the Engagement Invitations are sorted. Common values
        /// include <c>InvitationDate</c> and <c>Status</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.OpportunityEngagementInvitationSortName")]
        public Amazon.PartnerCentralSelling.OpportunityEngagementInvitationSortName Sort_SortBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para>Defines the order in which the Engagement Invitations are sorted. The values can be
        /// <c>ASC</c> (ascending) or <c>DESC</c> (descending).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.SortOrder")]
        public Amazon.PartnerCentralSelling.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para> Status values to filter the invitations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of engagement invitations to return in the response.
        /// If more results are available, a pagination token will be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token used to retrieve additional pages of results when the response
        /// to a previous request was truncated. Pass this token to continue listing invitations
        /// from where the previous call left off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EngagementInvitationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EngagementInvitationSummaries";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsResponse, GetPCEngagementInvitationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EngagementIdentifier != null)
            {
                context.EngagementIdentifier = new List<System.String>(this.EngagementIdentifier);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ParticipantType = this.ParticipantType;
            #if MODULAR
            if (this.ParticipantType == null && ParameterWasBound(nameof(this.ParticipantType)))
            {
                WriteWarning("You are passing $null as a value for parameter ParticipantType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PayloadType != null)
            {
                context.PayloadType = new List<System.String>(this.PayloadType);
            }
            if (this.SenderAwsAccountId != null)
            {
                context.SenderAwsAccountId = new List<System.String>(this.SenderAwsAccountId);
            }
            context.Sort_SortBy = this.Sort_SortBy;
            context.Sort_SortOrder = this.Sort_SortOrder;
            if (this.Status != null)
            {
                context.Status = new List<System.String>(this.Status);
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
            var request = new Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.EngagementIdentifier != null)
            {
                request.EngagementIdentifier = cmdletContext.EngagementIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ParticipantType != null)
            {
                request.ParticipantType = cmdletContext.ParticipantType;
            }
            if (cmdletContext.PayloadType != null)
            {
                request.PayloadType = cmdletContext.PayloadType;
            }
            if (cmdletContext.SenderAwsAccountId != null)
            {
                request.SenderAwsAccountId = cmdletContext.SenderAwsAccountId;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.PartnerCentralSelling.Model.OpportunityEngagementInvitationSort();
            Amazon.PartnerCentralSelling.OpportunityEngagementInvitationSortName requestSort_sort_SortBy = null;
            if (cmdletContext.Sort_SortBy != null)
            {
                requestSort_sort_SortBy = cmdletContext.Sort_SortBy;
            }
            if (requestSort_sort_SortBy != null)
            {
                request.Sort.SortBy = requestSort_sort_SortBy;
                requestSortIsNull = false;
            }
            Amazon.PartnerCentralSelling.SortOrder requestSort_sort_SortOrder = null;
            if (cmdletContext.Sort_SortOrder != null)
            {
                requestSort_sort_SortOrder = cmdletContext.Sort_SortOrder;
            }
            if (requestSort_sort_SortOrder != null)
            {
                request.Sort.SortOrder = requestSort_sort_SortOrder;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "ListEngagementInvitations");
            try
            {
                return client.ListEngagementInvitationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public List<System.String> EngagementIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.PartnerCentralSelling.ParticipantType ParticipantType { get; set; }
            public List<System.String> PayloadType { get; set; }
            public List<System.String> SenderAwsAccountId { get; set; }
            public Amazon.PartnerCentralSelling.OpportunityEngagementInvitationSortName Sort_SortBy { get; set; }
            public Amazon.PartnerCentralSelling.SortOrder Sort_SortOrder { get; set; }
            public List<System.String> Status { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.ListEngagementInvitationsResponse, GetPCEngagementInvitationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EngagementInvitationSummaries;
        }
        
    }
}
