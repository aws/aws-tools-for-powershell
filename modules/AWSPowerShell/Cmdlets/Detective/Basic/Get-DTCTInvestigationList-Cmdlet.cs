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
using Amazon.Detective;
using Amazon.Detective.Model;

namespace Amazon.PowerShell.Cmdlets.DTCT
{
    /// <summary>
    /// Detective investigations lets you investigate IAM users and IAM roles using indicators
    /// of compromise. An indicator of compromise (IOC) is an artifact observed in or on a
    /// network, system, or environment that can (with a high level of confidence) identify
    /// malicious activity or a security incident. <c>ListInvestigations</c> lists all active
    /// Detective investigations.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DTCTInvestigationList")]
    [OutputType("Amazon.Detective.Model.InvestigationDetail")]
    [AWSCmdlet("Calls the Amazon Detective ListInvestigations API operation.", Operation = new[] {"ListInvestigations"}, SelectReturnType = typeof(Amazon.Detective.Model.ListInvestigationsResponse))]
    [AWSCmdletOutput("Amazon.Detective.Model.InvestigationDetail or Amazon.Detective.Model.ListInvestigationsResponse",
        "This cmdlet returns a collection of Amazon.Detective.Model.InvestigationDetail objects.",
        "The service call response (type Amazon.Detective.Model.ListInvestigationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDTCTInvestigationListCmdlet : AmazonDetectiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreatedTime_EndInclusive
        /// <summary>
        /// <para>
        /// <para>A timestamp representing the end date of the time period until when data is filtered,
        /// including the end date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_CreatedTime_EndInclusive")]
        public System.DateTime? CreatedTime_EndInclusive { get; set; }
        #endregion
        
        #region Parameter SortCriteria_Field
        /// <summary>
        /// <para>
        /// <para>Represents the <c>Field</c> attribute to sort investigations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Detective.Field")]
        public Amazon.Detective.Field SortCriteria_Field { get; set; }
        #endregion
        
        #region Parameter GraphArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the behavior graph.</para>
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
        public System.String GraphArn { get; set; }
        #endregion
        
        #region Parameter SortCriteria_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order by which the sorted findings are displayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Detective.SortOrder")]
        public Amazon.Detective.SortOrder SortCriteria_SortOrder { get; set; }
        #endregion
        
        #region Parameter CreatedTime_StartInclusive
        /// <summary>
        /// <para>
        /// <para>A timestamp representing the start of the time period from when data is filtered,
        /// including the start date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_CreatedTime_StartInclusive")]
        public System.DateTime? CreatedTime_StartInclusive { get; set; }
        #endregion
        
        #region Parameter EntityArn_Value
        /// <summary>
        /// <para>
        /// <para>The string filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_EntityArn_Value")]
        public System.String EntityArn_Value { get; set; }
        #endregion
        
        #region Parameter Severity_Value
        /// <summary>
        /// <para>
        /// <para>The string filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_Severity_Value")]
        public System.String Severity_Value { get; set; }
        #endregion
        
        #region Parameter State_Value
        /// <summary>
        /// <para>
        /// <para>The string filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_State_Value")]
        public System.String State_Value { get; set; }
        #endregion
        
        #region Parameter Status_Value
        /// <summary>
        /// <para>
        /// <para>The string filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_Status_Value")]
        public System.String Status_Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Lists the maximum number of investigations in a page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Lists if there are more results available. The value of nextToken is a unique pagination
        /// token for each page. Repeat the call using the returned token to retrieve the next
        /// page. Keep all other arguments unchanged.</para><para>Each pagination token expires after 24 hours. Using an expired pagination token will
        /// return a Validation Exception error.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvestigationDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Detective.Model.ListInvestigationsResponse).
        /// Specifying the name of a property of type Amazon.Detective.Model.ListInvestigationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvestigationDetails";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.Detective.Model.ListInvestigationsResponse, GetDTCTInvestigationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatedTime_EndInclusive = this.CreatedTime_EndInclusive;
            context.CreatedTime_StartInclusive = this.CreatedTime_StartInclusive;
            context.EntityArn_Value = this.EntityArn_Value;
            context.Severity_Value = this.Severity_Value;
            context.State_Value = this.State_Value;
            context.Status_Value = this.Status_Value;
            context.GraphArn = this.GraphArn;
            #if MODULAR
            if (this.GraphArn == null && ParameterWasBound(nameof(this.GraphArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GraphArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortCriteria_Field = this.SortCriteria_Field;
            context.SortCriteria_SortOrder = this.SortCriteria_SortOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Detective.Model.ListInvestigationsRequest();
            
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Detective.Model.FilterCriteria();
            Amazon.Detective.Model.StringFilter requestFilterCriteria_filterCriteria_EntityArn = null;
            
             // populate EntityArn
            var requestFilterCriteria_filterCriteria_EntityArnIsNull = true;
            requestFilterCriteria_filterCriteria_EntityArn = new Amazon.Detective.Model.StringFilter();
            System.String requestFilterCriteria_filterCriteria_EntityArn_entityArn_Value = null;
            if (cmdletContext.EntityArn_Value != null)
            {
                requestFilterCriteria_filterCriteria_EntityArn_entityArn_Value = cmdletContext.EntityArn_Value;
            }
            if (requestFilterCriteria_filterCriteria_EntityArn_entityArn_Value != null)
            {
                requestFilterCriteria_filterCriteria_EntityArn.Value = requestFilterCriteria_filterCriteria_EntityArn_entityArn_Value;
                requestFilterCriteria_filterCriteria_EntityArnIsNull = false;
            }
             // determine if requestFilterCriteria_filterCriteria_EntityArn should be set to null
            if (requestFilterCriteria_filterCriteria_EntityArnIsNull)
            {
                requestFilterCriteria_filterCriteria_EntityArn = null;
            }
            if (requestFilterCriteria_filterCriteria_EntityArn != null)
            {
                request.FilterCriteria.EntityArn = requestFilterCriteria_filterCriteria_EntityArn;
                requestFilterCriteriaIsNull = false;
            }
            Amazon.Detective.Model.StringFilter requestFilterCriteria_filterCriteria_Severity = null;
            
             // populate Severity
            var requestFilterCriteria_filterCriteria_SeverityIsNull = true;
            requestFilterCriteria_filterCriteria_Severity = new Amazon.Detective.Model.StringFilter();
            System.String requestFilterCriteria_filterCriteria_Severity_severity_Value = null;
            if (cmdletContext.Severity_Value != null)
            {
                requestFilterCriteria_filterCriteria_Severity_severity_Value = cmdletContext.Severity_Value;
            }
            if (requestFilterCriteria_filterCriteria_Severity_severity_Value != null)
            {
                requestFilterCriteria_filterCriteria_Severity.Value = requestFilterCriteria_filterCriteria_Severity_severity_Value;
                requestFilterCriteria_filterCriteria_SeverityIsNull = false;
            }
             // determine if requestFilterCriteria_filterCriteria_Severity should be set to null
            if (requestFilterCriteria_filterCriteria_SeverityIsNull)
            {
                requestFilterCriteria_filterCriteria_Severity = null;
            }
            if (requestFilterCriteria_filterCriteria_Severity != null)
            {
                request.FilterCriteria.Severity = requestFilterCriteria_filterCriteria_Severity;
                requestFilterCriteriaIsNull = false;
            }
            Amazon.Detective.Model.StringFilter requestFilterCriteria_filterCriteria_State = null;
            
             // populate State
            var requestFilterCriteria_filterCriteria_StateIsNull = true;
            requestFilterCriteria_filterCriteria_State = new Amazon.Detective.Model.StringFilter();
            System.String requestFilterCriteria_filterCriteria_State_state_Value = null;
            if (cmdletContext.State_Value != null)
            {
                requestFilterCriteria_filterCriteria_State_state_Value = cmdletContext.State_Value;
            }
            if (requestFilterCriteria_filterCriteria_State_state_Value != null)
            {
                requestFilterCriteria_filterCriteria_State.Value = requestFilterCriteria_filterCriteria_State_state_Value;
                requestFilterCriteria_filterCriteria_StateIsNull = false;
            }
             // determine if requestFilterCriteria_filterCriteria_State should be set to null
            if (requestFilterCriteria_filterCriteria_StateIsNull)
            {
                requestFilterCriteria_filterCriteria_State = null;
            }
            if (requestFilterCriteria_filterCriteria_State != null)
            {
                request.FilterCriteria.State = requestFilterCriteria_filterCriteria_State;
                requestFilterCriteriaIsNull = false;
            }
            Amazon.Detective.Model.StringFilter requestFilterCriteria_filterCriteria_Status = null;
            
             // populate Status
            var requestFilterCriteria_filterCriteria_StatusIsNull = true;
            requestFilterCriteria_filterCriteria_Status = new Amazon.Detective.Model.StringFilter();
            System.String requestFilterCriteria_filterCriteria_Status_status_Value = null;
            if (cmdletContext.Status_Value != null)
            {
                requestFilterCriteria_filterCriteria_Status_status_Value = cmdletContext.Status_Value;
            }
            if (requestFilterCriteria_filterCriteria_Status_status_Value != null)
            {
                requestFilterCriteria_filterCriteria_Status.Value = requestFilterCriteria_filterCriteria_Status_status_Value;
                requestFilterCriteria_filterCriteria_StatusIsNull = false;
            }
             // determine if requestFilterCriteria_filterCriteria_Status should be set to null
            if (requestFilterCriteria_filterCriteria_StatusIsNull)
            {
                requestFilterCriteria_filterCriteria_Status = null;
            }
            if (requestFilterCriteria_filterCriteria_Status != null)
            {
                request.FilterCriteria.Status = requestFilterCriteria_filterCriteria_Status;
                requestFilterCriteriaIsNull = false;
            }
            Amazon.Detective.Model.DateFilter requestFilterCriteria_filterCriteria_CreatedTime = null;
            
             // populate CreatedTime
            var requestFilterCriteria_filterCriteria_CreatedTimeIsNull = true;
            requestFilterCriteria_filterCriteria_CreatedTime = new Amazon.Detective.Model.DateFilter();
            System.DateTime? requestFilterCriteria_filterCriteria_CreatedTime_createdTime_EndInclusive = null;
            if (cmdletContext.CreatedTime_EndInclusive != null)
            {
                requestFilterCriteria_filterCriteria_CreatedTime_createdTime_EndInclusive = cmdletContext.CreatedTime_EndInclusive.Value;
            }
            if (requestFilterCriteria_filterCriteria_CreatedTime_createdTime_EndInclusive != null)
            {
                requestFilterCriteria_filterCriteria_CreatedTime.EndInclusive = requestFilterCriteria_filterCriteria_CreatedTime_createdTime_EndInclusive.Value;
                requestFilterCriteria_filterCriteria_CreatedTimeIsNull = false;
            }
            System.DateTime? requestFilterCriteria_filterCriteria_CreatedTime_createdTime_StartInclusive = null;
            if (cmdletContext.CreatedTime_StartInclusive != null)
            {
                requestFilterCriteria_filterCriteria_CreatedTime_createdTime_StartInclusive = cmdletContext.CreatedTime_StartInclusive.Value;
            }
            if (requestFilterCriteria_filterCriteria_CreatedTime_createdTime_StartInclusive != null)
            {
                requestFilterCriteria_filterCriteria_CreatedTime.StartInclusive = requestFilterCriteria_filterCriteria_CreatedTime_createdTime_StartInclusive.Value;
                requestFilterCriteria_filterCriteria_CreatedTimeIsNull = false;
            }
             // determine if requestFilterCriteria_filterCriteria_CreatedTime should be set to null
            if (requestFilterCriteria_filterCriteria_CreatedTimeIsNull)
            {
                requestFilterCriteria_filterCriteria_CreatedTime = null;
            }
            if (requestFilterCriteria_filterCriteria_CreatedTime != null)
            {
                request.FilterCriteria.CreatedTime = requestFilterCriteria_filterCriteria_CreatedTime;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.GraphArn != null)
            {
                request.GraphArn = cmdletContext.GraphArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate SortCriteria
            var requestSortCriteriaIsNull = true;
            request.SortCriteria = new Amazon.Detective.Model.SortCriteria();
            Amazon.Detective.Field requestSortCriteria_sortCriteria_Field = null;
            if (cmdletContext.SortCriteria_Field != null)
            {
                requestSortCriteria_sortCriteria_Field = cmdletContext.SortCriteria_Field;
            }
            if (requestSortCriteria_sortCriteria_Field != null)
            {
                request.SortCriteria.Field = requestSortCriteria_sortCriteria_Field;
                requestSortCriteriaIsNull = false;
            }
            Amazon.Detective.SortOrder requestSortCriteria_sortCriteria_SortOrder = null;
            if (cmdletContext.SortCriteria_SortOrder != null)
            {
                requestSortCriteria_sortCriteria_SortOrder = cmdletContext.SortCriteria_SortOrder;
            }
            if (requestSortCriteria_sortCriteria_SortOrder != null)
            {
                request.SortCriteria.SortOrder = requestSortCriteria_sortCriteria_SortOrder;
                requestSortCriteriaIsNull = false;
            }
             // determine if request.SortCriteria should be set to null
            if (requestSortCriteriaIsNull)
            {
                request.SortCriteria = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Detective.Model.ListInvestigationsResponse CallAWSServiceOperation(IAmazonDetective client, Amazon.Detective.Model.ListInvestigationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Detective", "ListInvestigations");
            try
            {
                return client.ListInvestigationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? CreatedTime_EndInclusive { get; set; }
            public System.DateTime? CreatedTime_StartInclusive { get; set; }
            public System.String EntityArn_Value { get; set; }
            public System.String Severity_Value { get; set; }
            public System.String State_Value { get; set; }
            public System.String Status_Value { get; set; }
            public System.String GraphArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Detective.Field SortCriteria_Field { get; set; }
            public Amazon.Detective.SortOrder SortCriteria_SortOrder { get; set; }
            public System.Func<Amazon.Detective.Model.ListInvestigationsResponse, GetDTCTInvestigationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvestigationDetails;
        }
        
    }
}
