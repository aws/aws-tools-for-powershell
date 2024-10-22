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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves the Savings Plans utilization for your account across date ranges with daily
    /// or monthly granularity. Management account in an organization have access to member
    /// accounts. You can use <c>GetDimensionValues</c> in <c>SAVINGS_PLANS</c> to determine
    /// the possible dimension values.
    /// 
    ///  <note><para>
    /// You can't group by any dimension values for <c>GetSavingsPlansUtilization</c>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CESavingsPlansUtilization")]
    [OutputType("Amazon.CostExplorer.Model.GetSavingsPlansUtilizationResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetSavingsPlansUtilization API operation.", Operation = new[] {"GetSavingsPlansUtilization"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetSavingsPlansUtilizationResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetSavingsPlansUtilizationResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetSavingsPlansUtilizationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCESavingsPlansUtilizationCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters Savings Plans utilization coverage data for active Savings Plans dimensions.
        /// You can filter data with the following dimensions:</para><ul><li><para><c>LINKED_ACCOUNT</c></para></li><li><para><c>SAVINGS_PLAN_ARN</c></para></li><li><para><c>SAVINGS_PLANS_TYPE</c></para></li><li><para><c>REGION</c></para></li><li><para><c>PAYMENT_OPTION</c></para></li><li><para><c>INSTANCE_TYPE_FAMILY</c></para></li></ul><para><c>GetSavingsPlansUtilization</c> uses the same <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Expression.html">Expression</a>
        /// object as the other operations, but only <c>AND</c> is supported among each dimension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>The granularity of the Amazon Web Services utillization data for your Savings Plans.</para><para>The <c>GetSavingsPlansUtilization</c> operation supports only <c>DAILY</c> and <c>MONTHLY</c>
        /// granularities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.Granularity")]
        public Amazon.CostExplorer.Granularity Granularity { get; set; }
        #endregion
        
        #region Parameter SortBy_Key
        /// <summary>
        /// <para>
        /// <para>The key that's used to sort the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SortBy_Key { get; set; }
        #endregion
        
        #region Parameter SortBy_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order that's used to sort the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.SortOrder")]
        public Amazon.CostExplorer.SortOrder SortBy_SortOrder { get; set; }
        #endregion
        
        #region Parameter TimePeriod
        /// <summary>
        /// <para>
        /// <para>The time period that you want the usage and costs for. The <c>Start</c> date must
        /// be within 13 months. The <c>End</c> date must be after the <c>Start</c> date, and
        /// before the current date. Future dates can't be used as an <c>End</c> date.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetSavingsPlansUtilizationResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetSavingsPlansUtilizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetSavingsPlansUtilizationResponse, GetCESavingsPlansUtilizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter = this.Filter;
            context.Granularity = this.Granularity;
            context.SortBy_Key = this.SortBy_Key;
            context.SortBy_SortOrder = this.SortBy_SortOrder;
            context.TimePeriod = this.TimePeriod;
            #if MODULAR
            if (this.TimePeriod == null && ParameterWasBound(nameof(this.TimePeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CostExplorer.Model.GetSavingsPlansUtilizationRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            
             // populate SortBy
            var requestSortByIsNull = true;
            request.SortBy = new Amazon.CostExplorer.Model.SortDefinition();
            System.String requestSortBy_sortBy_Key = null;
            if (cmdletContext.SortBy_Key != null)
            {
                requestSortBy_sortBy_Key = cmdletContext.SortBy_Key;
            }
            if (requestSortBy_sortBy_Key != null)
            {
                request.SortBy.Key = requestSortBy_sortBy_Key;
                requestSortByIsNull = false;
            }
            Amazon.CostExplorer.SortOrder requestSortBy_sortBy_SortOrder = null;
            if (cmdletContext.SortBy_SortOrder != null)
            {
                requestSortBy_sortBy_SortOrder = cmdletContext.SortBy_SortOrder;
            }
            if (requestSortBy_sortBy_SortOrder != null)
            {
                request.SortBy.SortOrder = requestSortBy_sortBy_SortOrder;
                requestSortByIsNull = false;
            }
             // determine if request.SortBy should be set to null
            if (requestSortByIsNull)
            {
                request.SortBy = null;
            }
            if (cmdletContext.TimePeriod != null)
            {
                request.TimePeriod = cmdletContext.TimePeriod;
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
        
        private Amazon.CostExplorer.Model.GetSavingsPlansUtilizationResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetSavingsPlansUtilizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetSavingsPlansUtilization");
            try
            {
                #if DESKTOP
                return client.GetSavingsPlansUtilization(request);
                #elif CORECLR
                return client.GetSavingsPlansUtilizationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public Amazon.CostExplorer.Granularity Granularity { get; set; }
            public System.String SortBy_Key { get; set; }
            public Amazon.CostExplorer.SortOrder SortBy_SortOrder { get; set; }
            public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetSavingsPlansUtilizationResponse, GetCESavingsPlansUtilizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
