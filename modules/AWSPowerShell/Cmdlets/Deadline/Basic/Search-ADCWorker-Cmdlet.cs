/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Searches for workers.
    /// </summary>
    [Cmdlet("Search", "ADCWorker", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Deadline.Model.SearchWorkersResponse")]
    [AWSCmdlet("Calls the AWSDeadlineCloud SearchWorkers API operation.", Operation = new[] {"SearchWorkers"}, SelectReturnType = typeof(Amazon.Deadline.Model.SearchWorkersResponse))]
    [AWSCmdletOutput("Amazon.Deadline.Model.SearchWorkersResponse",
        "This cmdlet returns an Amazon.Deadline.Model.SearchWorkersResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchADCWorkerCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID in the workers search.</para>
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
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>The fleet ID of the workers to search for.</para>
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
        [Alias("FleetIds")]
        public System.String[] FleetId { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.SearchWorkersResponse).
        /// Specifying the name of a property of type Amazon.Deadline.Model.SearchWorkersResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-ADCWorker (SearchWorkers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.SearchWorkersResponse, SearchADCWorkerCmdlet>(Select) ??
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
            if (this.FleetId != null)
            {
                context.FleetId = new List<System.String>(this.FleetId);
            }
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ItemOffset = this.ItemOffset;
            #if MODULAR
            if (this.ItemOffset == null && ParameterWasBound(nameof(this.ItemOffset)))
            {
                WriteWarning("You are passing $null as a value for parameter ItemOffset which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PageSize = this.PageSize;
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
            var request = new Amazon.Deadline.Model.SearchWorkersRequest();
            
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
            if (cmdletContext.FleetId != null)
            {
                request.FleetIds = cmdletContext.FleetId;
            }
            if (cmdletContext.ItemOffset != null)
            {
                request.ItemOffset = cmdletContext.ItemOffset.Value;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
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
        
        private Amazon.Deadline.Model.SearchWorkersResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.SearchWorkersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "SearchWorkers");
            try
            {
                #if DESKTOP
                return client.SearchWorkers(request);
                #elif CORECLR
                return client.SearchWorkersAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> FleetId { get; set; }
            public System.Int32? ItemOffset { get; set; }
            public System.Int32? PageSize { get; set; }
            public List<Amazon.Deadline.Model.SearchSortExpression> SortExpression { get; set; }
            public System.Func<Amazon.Deadline.Model.SearchWorkersResponse, SearchADCWorkerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
