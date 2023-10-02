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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// This is a paginated call to list linked accounts that are linked to the payer account
    /// for the specified time period. If no information is provided, the current billing
    /// period is used. The response will optionally include the billing group that's associated
    /// with the linked account.
    /// </summary>
    [Cmdlet("Get", "ABCAccountAssociationList")]
    [OutputType("Amazon.BillingConductor.Model.AccountAssociationsListElement")]
    [AWSCmdlet("Calls the AWSBillingConductor ListAccountAssociations API operation.", Operation = new[] {"ListAccountAssociations"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.ListAccountAssociationsResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.AccountAssociationsListElement or Amazon.BillingConductor.Model.ListAccountAssociationsResponse",
        "This cmdlet returns a collection of Amazon.BillingConductor.Model.AccountAssociationsListElement objects.",
        "The service call response (type Amazon.BillingConductor.Model.ListAccountAssociationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetABCAccountAssociationListCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para><code>MONITORED</code>: linked accounts that are associated to billing groups.</para><para><code>UNMONITORED</code>: linked accounts that are not associated to billing groups.</para><para><code>Billing Group Arn</code>: linked accounts that are associated to the provided
        /// Billing Group Arn.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BillingPeriod parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BillingPeriod' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BillingPeriod' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListAccountAssociationsResponse, GetABCAccountAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BillingPeriod;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            // create request
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
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.BillingConductor.Model.ListAccountAssociationsResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListAccountAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListAccountAssociations");
            try
            {
                #if DESKTOP
                return client.ListAccountAssociations(request);
                #elif CORECLR
                return client.ListAccountAssociationsAsync(request).GetAwaiter().GetResult();
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
