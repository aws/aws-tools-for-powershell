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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// Lists all in-progress, completed, or failed StartEngagementByAcceptingInvitationTask
    /// tasks that were initiated by the caller's account.
    /// </summary>
    [Cmdlet("Get", "PCEngagementByAcceptingInvitationTaskList")]
    [OutputType("Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTaskSummary")]
    [AWSCmdlet("Calls the Partner Central Selling API ListEngagementByAcceptingInvitationTasks API operation.", Operation = new[] {"ListEngagementByAcceptingInvitationTasks"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTaskSummary or Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksResponse",
        "This cmdlet returns a collection of Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTaskSummary objects.",
        "The service call response (type Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCEngagementByAcceptingInvitationTaskListCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para> Specifies the catalog related to the request. Valid values are: </para><ul><li><para> AWS: Retrieves the request from the production AWS environment. </para></li><li><para> Sandbox: Retrieves the request from a sandbox environment used for testing or development
        /// purposes. </para></li></ul>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter EngagementInvitationIdentifier
        /// <summary>
        /// <para>
        /// <para> Filters tasks by the identifiers of the engagement invitations they are processing.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EngagementInvitationIdentifier { get; set; }
        #endregion
        
        #region Parameter OpportunityIdentifier
        /// <summary>
        /// <para>
        /// <para> Filters tasks by the identifiers of the opportunities they created or are associated
        /// with. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OpportunityIdentifier { get; set; }
        #endregion
        
        #region Parameter Sort_SortBy
        /// <summary>
        /// <para>
        /// <para> Specifies the field by which the task list should be sorted. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.ListTasksSortName")]
        public Amazon.PartnerCentralSelling.ListTasksSortName Sort_SortBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para> Determines the order in which the sorted results are presented. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.SortOrder")]
        public Amazon.PartnerCentralSelling.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter TaskIdentifier
        /// <summary>
        /// <para>
        /// <para> Filters tasks by their unique identifiers. Use this when you want to retrieve information
        /// about specific tasks. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TaskIdentifier { get; set; }
        #endregion
        
        #region Parameter TaskStatus
        /// <summary>
        /// <para>
        /// <para> Filters the tasks based on their current status. This allows you to focus on tasks
        /// in specific states. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TaskStatus { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> Use this parameter to control the number of items returned in each request, which
        /// can be useful for performance tuning and managing large result sets. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> Use this parameter for pagination when the result set spans multiple pages. This
        /// value is obtained from the NextToken field in the response of a previous call to this
        /// API. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Catalog parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksResponse, GetPCEngagementByAcceptingInvitationTaskListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Catalog;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EngagementInvitationIdentifier != null)
            {
                context.EngagementInvitationIdentifier = new List<System.String>(this.EngagementInvitationIdentifier);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.OpportunityIdentifier != null)
            {
                context.OpportunityIdentifier = new List<System.String>(this.OpportunityIdentifier);
            }
            context.Sort_SortBy = this.Sort_SortBy;
            context.Sort_SortOrder = this.Sort_SortOrder;
            if (this.TaskIdentifier != null)
            {
                context.TaskIdentifier = new List<System.String>(this.TaskIdentifier);
            }
            if (this.TaskStatus != null)
            {
                context.TaskStatus = new List<System.String>(this.TaskStatus);
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
            var request = new Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.EngagementInvitationIdentifier != null)
            {
                request.EngagementInvitationIdentifier = cmdletContext.EngagementInvitationIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.OpportunityIdentifier != null)
            {
                request.OpportunityIdentifier = cmdletContext.OpportunityIdentifier;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.PartnerCentralSelling.Model.ListTasksSortBase();
            Amazon.PartnerCentralSelling.ListTasksSortName requestSort_sort_SortBy = null;
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
            if (cmdletContext.TaskIdentifier != null)
            {
                request.TaskIdentifier = cmdletContext.TaskIdentifier;
            }
            if (cmdletContext.TaskStatus != null)
            {
                request.TaskStatus = cmdletContext.TaskStatus;
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
        
        private Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "ListEngagementByAcceptingInvitationTasks");
            try
            {
                #if DESKTOP
                return client.ListEngagementByAcceptingInvitationTasks(request);
                #elif CORECLR
                return client.ListEngagementByAcceptingInvitationTasksAsync(request).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public List<System.String> EngagementInvitationIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> OpportunityIdentifier { get; set; }
            public Amazon.PartnerCentralSelling.ListTasksSortName Sort_SortBy { get; set; }
            public Amazon.PartnerCentralSelling.SortOrder Sort_SortOrder { get; set; }
            public List<System.String> TaskIdentifier { get; set; }
            public List<System.String> TaskStatus { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.ListEngagementByAcceptingInvitationTasksResponse, GetPCEngagementByAcceptingInvitationTaskListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskSummaries;
        }
        
    }
}
