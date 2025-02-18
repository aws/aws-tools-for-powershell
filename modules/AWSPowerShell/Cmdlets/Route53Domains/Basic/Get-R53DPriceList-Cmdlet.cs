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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// Lists the following prices for either all the TLDs supported by Route 53, or the specified
    /// TLD:
    /// 
    ///  <ul><li><para>
    /// Registration
    /// </para></li><li><para>
    /// Transfer
    /// </para></li><li><para>
    /// Owner change
    /// </para></li><li><para>
    /// Domain renewal
    /// </para></li><li><para>
    /// Domain restoration
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "R53DPriceList")]
    [OutputType("Amazon.Route53Domains.Model.DomainPrice")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains ListPrices API operation.", Operation = new[] {"ListPrices"}, SelectReturnType = typeof(Amazon.Route53Domains.Model.ListPricesResponse))]
    [AWSCmdletOutput("Amazon.Route53Domains.Model.DomainPrice or Amazon.Route53Domains.Model.ListPricesResponse",
        "This cmdlet returns a collection of Amazon.Route53Domains.Model.DomainPrice objects.",
        "The service call response (type Amazon.Route53Domains.Model.ListPricesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53DPriceListCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Tld
        /// <summary>
        /// <para>
        /// <para>The TLD for which you want to receive the pricing information. For example. <c>.net</c>.</para><para>If a <c>Tld</c> value is not provided, a list of prices for all TLDs supported by
        /// Route 53 is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Tld { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>For an initial request for a list of prices, omit this element. If the number of prices
        /// that are not yet complete is greater than the value that you specified for <c>MaxItems</c>,
        /// you can use <c>Marker</c> to return additional prices. Get the value of <c>NextPageMarker</c>
        /// from the previous response, and submit another request that includes the value of
        /// <c>NextPageMarker</c> in the <c>Marker</c> element. </para><para>Used only for all TLDs. If you specify a TLD, don't specify a <c>Marker</c>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Number of <c>Prices</c> to be returned.</para><para>Used only for all TLDs. If you specify a TLD, don't specify a <c>MaxItems</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.Int32? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Prices'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Domains.Model.ListPricesResponse).
        /// Specifying the name of a property of type Amazon.Route53Domains.Model.ListPricesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Prices";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
                context.Select = CreateSelectDelegate<Amazon.Route53Domains.Model.ListPricesResponse, GetR53DPriceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            context.Tld = this.Tld;
            
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
            var request = new Amazon.Route53Domains.Model.ListPricesRequest();
            
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
            }
            if (cmdletContext.Tld != null)
            {
                request.Tld = cmdletContext.Tld;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.NextPageMarker;
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
        
        private Amazon.Route53Domains.Model.ListPricesResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.ListPricesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "ListPrices");
            try
            {
                return client.ListPricesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public System.Int32? MaxItem { get; set; }
            public System.String Tld { get; set; }
            public System.Func<Amazon.Route53Domains.Model.ListPricesResponse, GetR53DPriceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Prices;
        }
        
    }
}
