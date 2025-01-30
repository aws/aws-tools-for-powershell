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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Searches for tasks.
    /// </summary>
    [Cmdlet("Search", "ADCTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Deadline.Model.SearchTasksResponse")]
    [AWSCmdlet("Calls the AWSDeadlineCloud SearchTasks API operation.", Operation = new[] {"SearchTasks"}, SelectReturnType = typeof(Amazon.Deadline.Model.SearchTasksResponse))]
    [AWSCmdletOutput("Amazon.Deadline.Model.SearchTasksResponse",
        "This cmdlet returns an Amazon.Deadline.Model.SearchTasksResponse object containing multiple properties."
    )]
    public partial class SearchADCTaskCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID of the task.</para>
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
        public System.String FarmId { get; set; }
        #endregion
        
        #region Parameter FilterExpressions_Filter
        /// <summary>
        /// <para>
        /// <para>The filters to use for the search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterExpressions_Filters")]
        public Amazon.Deadline.Model.SearchFilterExpression[] FilterExpressions_Filter { get; set; }
        #endregion
        
        #region Parameter ItemOffset
        /// <summary>
        /// <para>
        /// <para>Defines how far into the scrollable list to start the return of results.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ItemOffset { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The job ID for the task search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter FilterExpressions_Operator
        /// <summary>
        /// <para>
        /// <para>The operators to include in the search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.LogicalOperator")]
        public Amazon.Deadline.LogicalOperator FilterExpressions_Operator { get; set; }
        #endregion
        
        #region Parameter QueueId
        /// <summary>
        /// <para>
        /// <para>The queue IDs to include in the search.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("QueueIds")]
        public System.String[] QueueId { get; set; }
        #endregion
        
        #region Parameter SortExpression
        /// <summary>
        /// <para>
        /// <para>The search terms for a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SortExpressions")]
        public Amazon.Deadline.Model.SearchSortExpression[] SortExpression { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>Specifies the number of items per page for the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.SearchTasksResponse).
        /// Specifying the name of a property of type Amazon.Deadline.Model.SearchTasksResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FarmId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-ADCTask (SearchTasks)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.SearchTasksResponse, SearchADCTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FilterExpressions_Filter != null)
            {
                context.FilterExpressions_Filter = new List<Amazon.Deadline.Model.SearchFilterExpression>(this.FilterExpressions_Filter);
            }
            context.FilterExpressions_Operator = this.FilterExpressions_Operator;
            context.ItemOffset = this.ItemOffset;
            #if MODULAR
            if (this.ItemOffset == null && ParameterWasBound(nameof(this.ItemOffset)))
            {
                WriteWarning("You are passing $null as a value for parameter ItemOffset which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobId = this.JobId;
            context.PageSize = this.PageSize;
            if (this.QueueId != null)
            {
                context.QueueId = new List<System.String>(this.QueueId);
            }
            #if MODULAR
            if (this.QueueId == null && ParameterWasBound(nameof(this.QueueId)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SortExpression != null)
            {
                context.SortExpression = new List<Amazon.Deadline.Model.SearchSortExpression>(this.SortExpression);
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
            var request = new Amazon.Deadline.Model.SearchTasksRequest();
            
            if (cmdletContext.FarmId != null)
            {
                request.FarmId = cmdletContext.FarmId;
            }
            
             // populate FilterExpressions
            var requestFilterExpressionsIsNull = true;
            request.FilterExpressions = new Amazon.Deadline.Model.SearchGroupedFilterExpressions();
            List<Amazon.Deadline.Model.SearchFilterExpression> requestFilterExpressions_filterExpressions_Filter = null;
            if (cmdletContext.FilterExpressions_Filter != null)
            {
                requestFilterExpressions_filterExpressions_Filter = cmdletContext.FilterExpressions_Filter;
            }
            if (requestFilterExpressions_filterExpressions_Filter != null)
            {
                request.FilterExpressions.Filters = requestFilterExpressions_filterExpressions_Filter;
                requestFilterExpressionsIsNull = false;
            }
            Amazon.Deadline.LogicalOperator requestFilterExpressions_filterExpressions_Operator = null;
            if (cmdletContext.FilterExpressions_Operator != null)
            {
                requestFilterExpressions_filterExpressions_Operator = cmdletContext.FilterExpressions_Operator;
            }
            if (requestFilterExpressions_filterExpressions_Operator != null)
            {
                request.FilterExpressions.Operator = requestFilterExpressions_filterExpressions_Operator;
                requestFilterExpressionsIsNull = false;
            }
             // determine if request.FilterExpressions should be set to null
            if (requestFilterExpressionsIsNull)
            {
                request.FilterExpressions = null;
            }
            if (cmdletContext.ItemOffset != null)
            {
                request.ItemOffset = cmdletContext.ItemOffset.Value;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.QueueId != null)
            {
                request.QueueIds = cmdletContext.QueueId;
            }
            if (cmdletContext.SortExpression != null)
            {
                request.SortExpressions = cmdletContext.SortExpression;
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
        
        private Amazon.Deadline.Model.SearchTasksResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.SearchTasksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "SearchTasks");
            try
            {
                #if DESKTOP
                return client.SearchTasks(request);
                #elif CORECLR
                return client.SearchTasksAsync(request).GetAwaiter().GetResult();
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
            public System.String FarmId { get; set; }
            public List<Amazon.Deadline.Model.SearchFilterExpression> FilterExpressions_Filter { get; set; }
            public Amazon.Deadline.LogicalOperator FilterExpressions_Operator { get; set; }
            public System.Int32? ItemOffset { get; set; }
            public System.String JobId { get; set; }
            public System.Int32? PageSize { get; set; }
            public List<System.String> QueueId { get; set; }
            public List<Amazon.Deadline.Model.SearchSortExpression> SortExpression { get; set; }
            public System.Func<Amazon.Deadline.Model.SearchTasksResponse, SearchADCTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
