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
using Amazon.Invoicing;
using Amazon.Invoicing.Model;

namespace Amazon.PowerShell.Cmdlets.INV
{
    /// <summary>
    /// This fetches a list of all invoice unit definitions for a given account, as of the
    /// provided <c>AsOf</c> date.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "INVInvoiceUnitList")]
    [OutputType("Amazon.Invoicing.Model.InvoiceUnit")]
    [AWSCmdlet("Calls the AWS Invoicing ListInvoiceUnits API operation.", Operation = new[] {"ListInvoiceUnits"}, SelectReturnType = typeof(Amazon.Invoicing.Model.ListInvoiceUnitsResponse))]
    [AWSCmdletOutput("Amazon.Invoicing.Model.InvoiceUnit or Amazon.Invoicing.Model.ListInvoiceUnitsResponse",
        "This cmdlet returns a collection of Amazon.Invoicing.Model.InvoiceUnit objects.",
        "The service call response (type Amazon.Invoicing.Model.ListInvoiceUnitsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINVInvoiceUnitListCmdlet : AmazonInvoicingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_Account
        /// <summary>
        /// <para>
        /// <para> You can specify a list of Amazon Web Services account IDs inside filters to return
        /// invoice units that match only the specified accounts. If multiple accounts are provided,
        /// the result is an <c>OR</c> condition (match any) of the specified accounts. The specified
        /// account IDs are matched with either the receiver or the linked accounts in the rules.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Accounts")]
        public System.String[] Filters_Account { get; set; }
        #endregion
        
        #region Parameter AsOf
        /// <summary>
        /// <para>
        /// <para> The state of an invoice unit at a specified time. You can see legacy invoice units
        /// that are currently deleted if the <c>AsOf</c> time is set to before it was deleted.
        /// If an <c>AsOf</c> is not provided, the default value is the current time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? AsOf { get; set; }
        #endregion
        
        #region Parameter Filters_InvoiceReceiver
        /// <summary>
        /// <para>
        /// <para> You can specify a list of Amazon Web Services account IDs inside filters to return
        /// invoice units that match only the specified accounts. If multiple accounts are provided,
        /// the result is an <c>OR</c> condition (match any) of the specified accounts. This filter
        /// only matches the specified accounts on the invoice receivers of the invoice units.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_InvoiceReceivers")]
        public System.String[] Filters_InvoiceReceiver { get; set; }
        #endregion
        
        #region Parameter Filters_Name
        /// <summary>
        /// <para>
        /// <para> An optional input to the list API. You can specify a list of invoice unit names inside
        /// filters to return invoice units that match only the specified invoice unit names.
        /// If multiple names are provided, the result is an <c>OR</c> condition (match any) of
        /// the specified invoice unit names. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Names")]
        public System.String[] Filters_Name { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of invoice units that can be returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The next token used to indicate where the returned list should start from. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvoiceUnits'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Invoicing.Model.ListInvoiceUnitsResponse).
        /// Specifying the name of a property of type Amazon.Invoicing.Model.ListInvoiceUnitsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvoiceUnits";
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
                context.Select = CreateSelectDelegate<Amazon.Invoicing.Model.ListInvoiceUnitsResponse, GetINVInvoiceUnitListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AsOf = this.AsOf;
            if (this.Filters_Account != null)
            {
                context.Filters_Account = new List<System.String>(this.Filters_Account);
            }
            if (this.Filters_InvoiceReceiver != null)
            {
                context.Filters_InvoiceReceiver = new List<System.String>(this.Filters_InvoiceReceiver);
            }
            if (this.Filters_Name != null)
            {
                context.Filters_Name = new List<System.String>(this.Filters_Name);
            }
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.Invoicing.Model.ListInvoiceUnitsRequest();
            
            if (cmdletContext.AsOf != null)
            {
                request.AsOf = cmdletContext.AsOf.Value;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Invoicing.Model.Filters();
            List<System.String> requestFilters_filters_Account = null;
            if (cmdletContext.Filters_Account != null)
            {
                requestFilters_filters_Account = cmdletContext.Filters_Account;
            }
            if (requestFilters_filters_Account != null)
            {
                request.Filters.Accounts = requestFilters_filters_Account;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_InvoiceReceiver = null;
            if (cmdletContext.Filters_InvoiceReceiver != null)
            {
                requestFilters_filters_InvoiceReceiver = cmdletContext.Filters_InvoiceReceiver;
            }
            if (requestFilters_filters_InvoiceReceiver != null)
            {
                request.Filters.InvoiceReceivers = requestFilters_filters_InvoiceReceiver;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Name = null;
            if (cmdletContext.Filters_Name != null)
            {
                requestFilters_filters_Name = cmdletContext.Filters_Name;
            }
            if (requestFilters_filters_Name != null)
            {
                request.Filters.Names = requestFilters_filters_Name;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.Invoicing.Model.ListInvoiceUnitsResponse CallAWSServiceOperation(IAmazonInvoicing client, Amazon.Invoicing.Model.ListInvoiceUnitsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Invoicing", "ListInvoiceUnits");
            try
            {
                return client.ListInvoiceUnitsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? AsOf { get; set; }
            public List<System.String> Filters_Account { get; set; }
            public List<System.String> Filters_InvoiceReceiver { get; set; }
            public List<System.String> Filters_Name { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Invoicing.Model.ListInvoiceUnitsResponse, GetINVInvoiceUnitListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvoiceUnits;
        }
        
    }
}
