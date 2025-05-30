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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// This is a paginated call to list linked accounts that are linked to the payer account
    /// for the specified time period. If no information is provided, the current billing
    /// period is used. The response will optionally include the billing group that's associated
    /// with the linked account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "ABCAccountAssociationList")]
    [OutputType("Amazon.BillingConductor.Model.AccountAssociationsListElement")]
    [AWSCmdlet("Calls the AWSBillingConductor ListAccountAssociations API operation.", Operation = new[] {"ListAccountAssociations"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.ListAccountAssociationsResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.AccountAssociationsListElement or Amazon.BillingConductor.Model.ListAccountAssociationsResponse",
        "This cmdlet returns a collection of Amazon.BillingConductor.Model.AccountAssociationsListElement objects.",
        "The service call response (type Amazon.BillingConductor.Model.ListAccountAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetABCAccountAssociationListCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter Filters_AccountIds
        /// <summary>
        /// <para>
        /// <para> The list of Amazon Web Services IDs to retrieve their associated billing group for
        /// a given time range. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_AccountIds { get; set; }
        #endregion
        
        #region Parameter Filters_Association
        /// <summary>
        /// <para>
        /// <para><c>MONITORED</c>: linked accounts that are associated to billing groups.</para><para><c>UNMONITORED</c>: linked accounts that are not associated to billing groups.</para><para><c>Billing Group Arn</c>: linked accounts that are associated to the provided Billing
        /// Group Arn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_Association { get; set; }
        #endregion
        
        #region Parameter BillingPeriod
        /// <summary>
        /// <para>
        /// <para> The preferred billing period to get account associations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BillingPeriod { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The pagination token that's used on subsequent calls to retrieve accounts. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LinkedAccounts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.ListAccountAssociationsResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.ListAccountAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LinkedAccounts";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListAccountAssociationsResponse, GetABCAccountAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingPeriod = this.BillingPeriod;
            context.Filters_AccountId = this.Filters_AccountId;
            if (this.Filters_AccountIds != null)
            {
                context.Filters_AccountIds = new List<System.String>(this.Filters_AccountIds);
            }
            context.Filters_Association = this.Filters_Association;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.BillingConductor.Model.ListAccountAssociationsRequest();
            
            if (cmdletContext.BillingPeriod != null)
            {
                request.BillingPeriod = cmdletContext.BillingPeriod;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.BillingConductor.Model.ListAccountAssociationsFilter();
            System.String requestFilters_filters_AccountId = null;
            if (cmdletContext.Filters_AccountId != null)
            {
                requestFilters_filters_AccountId = cmdletContext.Filters_AccountId;
            }
            if (requestFilters_filters_AccountId != null)
            {
                request.Filters.AccountId = requestFilters_filters_AccountId;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_AccountIds = null;
            if (cmdletContext.Filters_AccountIds != null)
            {
                requestFilters_filters_AccountIds = cmdletContext.Filters_AccountIds;
            }
            if (requestFilters_filters_AccountIds != null)
            {
                request.Filters.AccountIds = requestFilters_filters_AccountIds;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_Association = null;
            if (cmdletContext.Filters_Association != null)
            {
                requestFilters_filters_Association = cmdletContext.Filters_Association;
            }
            if (requestFilters_filters_Association != null)
            {
                request.Filters.Association = requestFilters_filters_Association;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.BillingConductor.Model.ListAccountAssociationsResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListAccountAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListAccountAssociations");
            try
            {
                return client.ListAccountAssociationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BillingPeriod { get; set; }
            public System.String Filters_AccountId { get; set; }
            public List<System.String> Filters_AccountIds { get; set; }
            public System.String Filters_Association { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BillingConductor.Model.ListAccountAssociationsResponse, GetABCAccountAssociationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LinkedAccounts;
        }
        
    }
}
