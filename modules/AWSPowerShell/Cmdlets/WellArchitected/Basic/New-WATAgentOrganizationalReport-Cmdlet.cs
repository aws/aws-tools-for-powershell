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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Creates an Organizational Report, which is an asynchronously-materialized, point-in-time
    /// snapshot of recommendations across all Agent Profiles within the caller's AWS Organization.
    /// You can optionally narrow the scope with filters. The operation is idempotent on the
    /// caller-supplied clientToken. The AWS Organization the report belongs to is inferred
    /// from the caller's authorization context. Reports are retained for 90 days from creation,
    /// after which they are automatically deleted. Use DeleteAgentOrganizationalReport to
    /// delete a report earlier.
    /// </summary>
    [Cmdlet("New", "WATAgentOrganizationalReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WellArchitected.Model.CreateAgentOrganizationalReportResponse")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool CreateAgentOrganizationalReport API operation.", Operation = new[] {"CreateAgentOrganizationalReport"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.CreateAgentOrganizationalReportResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.CreateAgentOrganizationalReportResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.CreateAgentOrganizationalReportResponse object containing multiple properties."
    )]
    public partial class NewWATAgentOrganizationalReportCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>AWS account IDs to include in the report. Absent or empty means all accounts in the
        /// organization are in scope. Each supplied account is validated against AWS Organizations
        /// membership. Accounts that do not belong to the caller's organization are excluded
        /// and recorded on the report's coverage summary.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_AccountIds")]
        public System.String[] Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter Filters_CreatedAtRange_From
        /// <summary>
        /// <para>
        /// <para>Lower bound of the window (inclusive). Absent means no lower bound.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_CreatedAtRange_From { get; set; }
        #endregion
        
        #region Parameter Filters_UpdatedAtRange_From
        /// <summary>
        /// <para>
        /// <para>Lower bound of the window (inclusive). Absent means no lower bound.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_UpdatedAtRange_From { get; set; }
        #endregion
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>Optional human-readable label (1-500 characters) that helps callers distinguish reports
        /// created with the same filters. Carried through list and get responses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Label { get; set; }
        #endregion
        
        #region Parameter Filters_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>AWS Organizational Unit IDs whose member accounts are included in the report. Absent
        /// or empty means no OU-based scoping is applied. Account and OU filters combine as a
        /// union.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_OrganizationalUnitIds")]
        public System.String[] Filters_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter Filters_Pillar
        /// <summary>
        /// <para>
        /// <para>Well-Architected pillars to include. Absent or empty means all pillars.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Pillars")]
        public System.String[] Filters_Pillar { get; set; }
        #endregion
        
        #region Parameter Filters_Priority
        /// <summary>
        /// <para>
        /// <para>Recommendation priorities (HIGH, MEDIUM, LOW) to include. Absent or empty means all
        /// priorities.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Priorities")]
        public System.String[] Filters_Priority { get; set; }
        #endregion
        
        #region Parameter Filters_RecommendationType
        /// <summary>
        /// <para>
        /// <para>Recommendation types (RESOURCE, ARCHITECTURE, APPLICATION) to include. Absent or empty
        /// means all types.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_RecommendationTypes")]
        public System.String[] Filters_RecommendationType { get; set; }
        #endregion
        
        #region Parameter Filters_Status
        /// <summary>
        /// <para>
        /// <para>Recommendation statuses (ACTIVE, SUPPRESSED, COMPLETED) to include. Absent or empty
        /// means all statuses.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Statuses")]
        public System.String[] Filters_Status { get; set; }
        #endregion
        
        #region Parameter Filters_CreatedAtRange_To
        /// <summary>
        /// <para>
        /// <para>Upper bound of the window (inclusive). Absent means no upper bound.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_CreatedAtRange_To { get; set; }
        #endregion
        
        #region Parameter Filters_UpdatedAtRange_To
        /// <summary>
        /// <para>
        /// <para>Upper bound of the window (inclusive). Absent means no upper bound.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_UpdatedAtRange_To { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A caller-supplied idempotency token. Two create calls sharing the same token within
        /// the service's idempotency window return the same reportId.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.CreateAgentOrganizationalReportResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.CreateAgentOrganizationalReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Label), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WATAgentOrganizationalReport (CreateAgentOrganizationalReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.CreateAgentOrganizationalReportResponse, NewWATAgentOrganizationalReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.Filters_AccountId != null)
            {
                context.Filters_AccountId = new List<System.String>(this.Filters_AccountId);
            }
            context.Filters_CreatedAtRange_From = this.Filters_CreatedAtRange_From;
            context.Filters_CreatedAtRange_To = this.Filters_CreatedAtRange_To;
            if (this.Filters_OrganizationalUnitId != null)
            {
                context.Filters_OrganizationalUnitId = new List<System.String>(this.Filters_OrganizationalUnitId);
            }
            if (this.Filters_Pillar != null)
            {
                context.Filters_Pillar = new List<System.String>(this.Filters_Pillar);
            }
            if (this.Filters_Priority != null)
            {
                context.Filters_Priority = new List<System.String>(this.Filters_Priority);
            }
            if (this.Filters_RecommendationType != null)
            {
                context.Filters_RecommendationType = new List<System.String>(this.Filters_RecommendationType);
            }
            if (this.Filters_Status != null)
            {
                context.Filters_Status = new List<System.String>(this.Filters_Status);
            }
            context.Filters_UpdatedAtRange_From = this.Filters_UpdatedAtRange_From;
            context.Filters_UpdatedAtRange_To = this.Filters_UpdatedAtRange_To;
            context.Label = this.Label;
            
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
            var request = new Amazon.WellArchitected.Model.CreateAgentOrganizationalReportRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.WellArchitected.Model.OrganizationalReportFilters();
            List<System.String> requestFilters_filters_AccountId = null;
            if (cmdletContext.Filters_AccountId != null)
            {
                requestFilters_filters_AccountId = cmdletContext.Filters_AccountId;
            }
            if (requestFilters_filters_AccountId != null)
            {
                request.Filters.AccountIds = requestFilters_filters_AccountId;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_OrganizationalUnitId = null;
            if (cmdletContext.Filters_OrganizationalUnitId != null)
            {
                requestFilters_filters_OrganizationalUnitId = cmdletContext.Filters_OrganizationalUnitId;
            }
            if (requestFilters_filters_OrganizationalUnitId != null)
            {
                request.Filters.OrganizationalUnitIds = requestFilters_filters_OrganizationalUnitId;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Pillar = null;
            if (cmdletContext.Filters_Pillar != null)
            {
                requestFilters_filters_Pillar = cmdletContext.Filters_Pillar;
            }
            if (requestFilters_filters_Pillar != null)
            {
                request.Filters.Pillars = requestFilters_filters_Pillar;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Priority = null;
            if (cmdletContext.Filters_Priority != null)
            {
                requestFilters_filters_Priority = cmdletContext.Filters_Priority;
            }
            if (requestFilters_filters_Priority != null)
            {
                request.Filters.Priorities = requestFilters_filters_Priority;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_RecommendationType = null;
            if (cmdletContext.Filters_RecommendationType != null)
            {
                requestFilters_filters_RecommendationType = cmdletContext.Filters_RecommendationType;
            }
            if (requestFilters_filters_RecommendationType != null)
            {
                request.Filters.RecommendationTypes = requestFilters_filters_RecommendationType;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Status = null;
            if (cmdletContext.Filters_Status != null)
            {
                requestFilters_filters_Status = cmdletContext.Filters_Status;
            }
            if (requestFilters_filters_Status != null)
            {
                request.Filters.Statuses = requestFilters_filters_Status;
                requestFiltersIsNull = false;
            }
            Amazon.WellArchitected.Model.TimeWindow requestFilters_filters_CreatedAtRange = null;
            
             // populate CreatedAtRange
            var requestFilters_filters_CreatedAtRangeIsNull = true;
            requestFilters_filters_CreatedAtRange = new Amazon.WellArchitected.Model.TimeWindow();
            System.DateTime? requestFilters_filters_CreatedAtRange_filters_CreatedAtRange_From = null;
            if (cmdletContext.Filters_CreatedAtRange_From != null)
            {
                requestFilters_filters_CreatedAtRange_filters_CreatedAtRange_From = cmdletContext.Filters_CreatedAtRange_From.Value;
            }
            if (requestFilters_filters_CreatedAtRange_filters_CreatedAtRange_From != null)
            {
                requestFilters_filters_CreatedAtRange.From = requestFilters_filters_CreatedAtRange_filters_CreatedAtRange_From.Value;
                requestFilters_filters_CreatedAtRangeIsNull = false;
            }
            System.DateTime? requestFilters_filters_CreatedAtRange_filters_CreatedAtRange_To = null;
            if (cmdletContext.Filters_CreatedAtRange_To != null)
            {
                requestFilters_filters_CreatedAtRange_filters_CreatedAtRange_To = cmdletContext.Filters_CreatedAtRange_To.Value;
            }
            if (requestFilters_filters_CreatedAtRange_filters_CreatedAtRange_To != null)
            {
                requestFilters_filters_CreatedAtRange.To = requestFilters_filters_CreatedAtRange_filters_CreatedAtRange_To.Value;
                requestFilters_filters_CreatedAtRangeIsNull = false;
            }
             // determine if requestFilters_filters_CreatedAtRange should be set to null
            if (requestFilters_filters_CreatedAtRangeIsNull)
            {
                requestFilters_filters_CreatedAtRange = null;
            }
            if (requestFilters_filters_CreatedAtRange != null)
            {
                request.Filters.CreatedAtRange = requestFilters_filters_CreatedAtRange;
                requestFiltersIsNull = false;
            }
            Amazon.WellArchitected.Model.TimeWindow requestFilters_filters_UpdatedAtRange = null;
            
             // populate UpdatedAtRange
            var requestFilters_filters_UpdatedAtRangeIsNull = true;
            requestFilters_filters_UpdatedAtRange = new Amazon.WellArchitected.Model.TimeWindow();
            System.DateTime? requestFilters_filters_UpdatedAtRange_filters_UpdatedAtRange_From = null;
            if (cmdletContext.Filters_UpdatedAtRange_From != null)
            {
                requestFilters_filters_UpdatedAtRange_filters_UpdatedAtRange_From = cmdletContext.Filters_UpdatedAtRange_From.Value;
            }
            if (requestFilters_filters_UpdatedAtRange_filters_UpdatedAtRange_From != null)
            {
                requestFilters_filters_UpdatedAtRange.From = requestFilters_filters_UpdatedAtRange_filters_UpdatedAtRange_From.Value;
                requestFilters_filters_UpdatedAtRangeIsNull = false;
            }
            System.DateTime? requestFilters_filters_UpdatedAtRange_filters_UpdatedAtRange_To = null;
            if (cmdletContext.Filters_UpdatedAtRange_To != null)
            {
                requestFilters_filters_UpdatedAtRange_filters_UpdatedAtRange_To = cmdletContext.Filters_UpdatedAtRange_To.Value;
            }
            if (requestFilters_filters_UpdatedAtRange_filters_UpdatedAtRange_To != null)
            {
                requestFilters_filters_UpdatedAtRange.To = requestFilters_filters_UpdatedAtRange_filters_UpdatedAtRange_To.Value;
                requestFilters_filters_UpdatedAtRangeIsNull = false;
            }
             // determine if requestFilters_filters_UpdatedAtRange should be set to null
            if (requestFilters_filters_UpdatedAtRangeIsNull)
            {
                requestFilters_filters_UpdatedAtRange = null;
            }
            if (requestFilters_filters_UpdatedAtRange != null)
            {
                request.Filters.UpdatedAtRange = requestFilters_filters_UpdatedAtRange;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.Label != null)
            {
                request.Label = cmdletContext.Label;
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
        
        private Amazon.WellArchitected.Model.CreateAgentOrganizationalReportResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.CreateAgentOrganizationalReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "CreateAgentOrganizationalReport");
            try
            {
                return client.CreateAgentOrganizationalReportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<System.String> Filters_AccountId { get; set; }
            public System.DateTime? Filters_CreatedAtRange_From { get; set; }
            public System.DateTime? Filters_CreatedAtRange_To { get; set; }
            public List<System.String> Filters_OrganizationalUnitId { get; set; }
            public List<System.String> Filters_Pillar { get; set; }
            public List<System.String> Filters_Priority { get; set; }
            public List<System.String> Filters_RecommendationType { get; set; }
            public List<System.String> Filters_Status { get; set; }
            public System.DateTime? Filters_UpdatedAtRange_From { get; set; }
            public System.DateTime? Filters_UpdatedAtRange_To { get; set; }
            public System.String Label { get; set; }
            public System.Func<Amazon.WellArchitected.Model.CreateAgentOrganizationalReportResponse, NewWATAgentOrganizationalReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
